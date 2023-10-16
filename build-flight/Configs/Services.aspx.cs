using DevExpress.Web;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_Services : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

        LoadServices();

    }

    #region Load data
    private void LoadServices()
    {
        var list = entities.ItemMasters
                    .OrderByDescending(x => x.GroupItem)
                    .ThenBy(x => x.ITEM)
                    .ToList();
        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }

    private void LoadItemMasterCompany(int ItemID)
    {
        var list = (from x in entities.ItemMasterCompanies
                    join t in entities.DecCompanies on x.CompanyID equals t.CompanyID
                    where x.ItemID == ItemID
                    select new
                    {
                        ID = x.ID,
                        ItemID = x.ItemID,
                        AreaCode = t.OriArea,
                        ShortName = t.ShortName,
                        NameV = t.NameV
                    }).ToList();


        this.CompanyGrid.DataSource = list;
        this.CompanyGrid.DataBind();
    }
    #endregion
    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {

        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        if (args[0].Equals(Action.REFRESH))
        {
            s.JSProperties["cpResult"] = Action.REFRESH;
            LoadServices();
        }
        else if (args[0].Equals(Action.DELETE))
        {
            s.JSProperties["cpResult"] = Action.DELETE;
            int key;
            if (!int.TryParse(args[1], out key))
                return;

            var item = (from x in entities.ItemMasters where x.ItemID == key select x).FirstOrDefault();
            if (item != null)
            {
                entities.ItemMasters.Remove(item);
                entities.SaveChanges();

                LoadServices();
            }
        }

        else if (args[0].Equals("SaveForm"))
        {
            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];
                    var vCode = CodeEditor.Text;
                    var vName = NameEditor.Text;
                    var vFuelType = FuelTypeEditor.Value != null ? FuelTypeEditor.Value.ToString() : string.Empty;
                    var vFuel = FuelEditor.Number;
                    var vGroup = GroupEditor.Value.ToString();
                    var vActive = ActiveEditor.Checked;
                    var vOwned = OwnedEditor.Checked;
                    var vEditor = HiredEditor.Checked;

                    if (command.ToUpper() == "EDIT")
                    {
                        int key;
                        if (!int.TryParse(args[2], out key))
                            return;

                        var entity = entities.ItemMasters.Where(x => x.ItemID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            entity.ITEM = vCode;
                            entity.Name = vName;
                            entity.FuelType = vFuelType;
                            entity.Fuel = vFuel;
                            entity.GroupItem = vGroup;
                            entity.Active = vActive;
                            entity.Owned = vOwned;
                            entity.Hired = vEditor;

                            entity.LastUpdateDate = DateTime.Now;
                            entity.LastUpdatedBy = (int)SessionUser.UserID;
                            entities.SaveChanges();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new ItemMaster();
                        entity.ITEM = vCode;
                        entity.Name = vName;
                        entity.FuelType = vFuelType;
                        entity.Fuel = vFuel;
                        entity.GroupItem = vGroup;
                        entity.Active = vActive;
                        entity.Owned = vOwned;
                        entity.Hired = vEditor;

                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.ItemMasters.Add(entity);
                        entities.SaveChanges();
                    }
                    LoadServices();

                    s.JSProperties["cpResult"] = "Success";
                }
                catch (Exception ex)
                {
                    s.JSProperties["cpResult"] = ex.Message;
                }
            }
        }
    }
    protected void DataGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "EditForm" && args.Length == 3)
        {
            int key;
            if (!int.TryParse(args[2], out key))
                return;

            var item = entities.ItemMasters.SingleOrDefault(x => x.ItemID == key);
            if (item == null)
                return;

            var result = new Dictionary<string, string>();
            result["Item"] = item.ITEM;
            result["Name"] = item.Name;
            result["FuelType"] = item.FuelType;
            result["Fuel"] = (item.Fuel ?? 0).ToString();
            result["GroupItem"] = item.GroupItem;
            result["Owned"] = (item.Owned ?? false) ? "True" : "False";
            result["Hired"] = (item.Hired ?? false) ? "True" : "False";
            result["Active"] = (item.Active ?? false) ? "True" : "False";

            e.Result = result;
        }
    }
    protected void DataGrid_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e)
    {

    }
    protected void DataGrid_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
    {
        var Grid = (sender as ASPxGridView);
        if (e.Column.FieldName == "GroupItemName")
        {
            var service = Grid.GetRow(e.VisibleIndex) as KTQTData.ItemMaster;
            if (service == null) return;
            var groupItem = service.GroupItem;
            var group = entities.DecTableValues.Where(x => x.Tables == "ITEMMASTER" && x.Field == "GROUPITEM" && x.DefValue == groupItem).SingleOrDefault();
            if (group != null)
            {
                e.EncodeHtml = false;
                e.DisplayText = group.Description;
            }
        }


    }
    protected void GroupEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        var list = entities.DecTableValues
                            .Where(x => x.Tables == "ITEMMASTER" && x.Field == "GROUPITEM")
                            .Select(x => new
                            {
                                DefValue = x.DefValue,
                                Description = x.Description
                            })
                            .ToList();

        cbo.DataSource = list;
        cbo.ValueField = "DefValue";
        cbo.TextField = "Description";
        cbo.DataBind();
    }

    protected void mMain_ItemClick(object source, MenuItemEventArgs e)
    {
        switch (e.Item.Name.ToUpper())
        {
            case "PDF":
                GridViewExporter.Landscape = true;
                GridViewExporter.WritePdfToResponse();
                break;
            case "XLS":
                GridViewExporter.WriteXlsToResponse();
                break;
            case "XLSX":
                DevExpress.XtraPrinting.XlsxExportOptionsEx options = new DevExpress.XtraPrinting.XlsxExportOptionsEx() { ExportType = DevExpress.Export.ExportType.WYSIWYG };
                GridViewExporter.WriteXlsxToResponse(options);
                break;
            case "RTF":
                GridViewExporter.Landscape = true;
                GridViewExporter.WriteRtfToResponse();
                break;
        }
    }

    protected bool TryParseKeyValues(IEnumerable<string> stringKeys, out int[] resultKeys)
    {
        resultKeys = null;
        var list = new List<int>();
        foreach (var sKey in stringKeys)
        {
            int key;
            if (!int.TryParse(sKey, out key))
                return false;
            list.Add(key);
        }
        resultKeys = list.ToArray();
        return true;
    }

    protected void CompanyGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        if (args[0] == "LOAD_COMPANY")
        {
            int key;
            if (!int.TryParse(args[1], out key))
                return;

            LoadItemMasterCompany(key);

        }

        if (args[0] == "ADD_COMPANY")
        {
            int itemKey;
            int[] companyKeys = null;

            if (!int.TryParse(args[1], out itemKey))
                return;

            if (!TryParseKeyValues(args.Skip(2), out companyKeys))
                return;

            foreach (int companyKey in companyKeys)
            {
                var entity = new ItemMasterCompany() { ItemID = itemKey, CompanyID = companyKey, CreateDate = DateTime.Now, CreatedBy = (int)SessionUser.UserID };

                entities.ItemMasterCompanies.Add(entity);
            }
            entities.SaveChanges();

            LoadItemMasterCompany(itemKey);
        }

        if (args[0] == "DELETE_COMPANY")
        {
            int key;
            if (!int.TryParse(args[1], out key))
                return;

            int itemKey;

            var entity = entities.ItemMasterCompanies.Where(x => x.ID == key).SingleOrDefault();
            if (entity != null)
            {
                itemKey = (int)entity.ItemID;
                entities.ItemMasterCompanies.Remove(entity);

                entities.SaveChanges();

                LoadItemMasterCompany(itemKey);
            }

        }
    }
    protected void DataGrid_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
    {
        var Grid = (sender as ASPxGridView);
        if (e.DataColumn.FieldName == "Owned" || e.DataColumn.FieldName == "Hired")
        {
            var aGroupItem = Grid.GetRowValues(e.VisibleIndex, "GroupItem");

            if (!Object.Equals(aGroupItem, "TTBTX") && !Object.Equals(aGroupItem, "TTBKTX") && !Object.Equals(aGroupItem, "TTBKHAC"))
                e.Cell.Controls[0].Visible = false;
        }
    }
}