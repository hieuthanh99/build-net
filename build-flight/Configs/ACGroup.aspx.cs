using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using KTQTData;

public partial class Pages_ACGroup : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

        this.mMain.Items.FindByName("New").Visible = IsGranted("Pages.KHTC.Configs.ACGroup.Create");
        this.mMain.Items.FindByName("Edit").Visible = IsGranted("Pages.KHTC.Configs.ACGroup.Edit");
        this.mMain.Items.FindByName("Delete").Visible = IsGranted("Pages.KHTC.Configs.ACGroup.Delete");

        if (!IsPostBack)
            ASPxLabel1.Text = LoadMissingAC();

        LoadAircafts();
       
    }

    #region Load data
    private void LoadAircafts()
    {
        var list = entities.AcGroupConverts.OrderBy(x => x.AcIataCode).ToList();
        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }

    private string LoadMissingAC()
    {
        var listAC = entities.DecAircrafts
            .Where(x => !entities.AcGroupConverts.Select(t => t.AcIataCode).Contains(x.Aircraft_Iata.Trim()))
            .Select(x => x.Aircraft_Iata.Trim())
            .Distinct().ToList();
        if (listAC != null && listAC.Count > 0)
            return "Danh sách các tàu bay chưa khai báo: " + String.Join(", ", listAC.ToArray());

        return string.Empty;
    }

    #endregion

    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        if (args[0].Equals(Action.REFRESH))
        {
            s.JSProperties["cpResult"] = Action.REFRESH;
            LoadAircafts();
        }
        else if (args[0].Equals(Action.DELETE))
        {
            s.JSProperties["cpResult"] = Action.DELETE;
            int key;
            if (!int.TryParse(args[1], out key))
                return;

            var entity = (from x in entities.AcGroupConverts where x.ID == key select x).FirstOrDefault();
            if (entity != null)
            {
                entities.AcGroupConverts.Remove(entity);
                entities.SaveChangesWithAuditLogs();
                LoadAircafts();
            }
        }

        else if (args[0].Equals("SaveForm"))
        {
            if (args.Length > 1)
            {
                try
                {
                    string command = args[1];

                    if (command.ToUpper() == "EDIT")
                    {
                        int key;
                        if (!int.TryParse(args[2], out key))
                            return;

                        var entity = entities.AcGroupConverts.Where(x => x.ID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            entity.AcIataCode = AcIataCodeEditor.Text.Trim();
                            entity.AcICAOCode = AcICAOCodeEditor.Text.Trim();
                            entity.AcGroup = ACGroupEditor.Text.Trim();
                            entity.AcName = AcNameEditor.Text.Trim();
                            entity.Remarks = RemarkEditor.Text.Trim();
                            entity.Convert_321 = Convert_321Editor.Number;
                            entity.UpdatedDate = DateTime.Now;
                            entity.UpdatedBy = SessionUser.UserID;

                            entities.SaveChangesWithAuditLogs();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new AcGroupConvert();

                        entity.AcIataCode = AcIataCodeEditor.Text.Trim();
                        entity.AcICAOCode = AcICAOCodeEditor.Text.Trim();
                        entity.AcGroup = ACGroupEditor.Text.Trim();
                        entity.AcName = AcNameEditor.Text.Trim();
                        entity.Remarks = RemarkEditor.Text.Trim();
                        entity.Convert_321 = Convert_321Editor.Number;
                        entity.CreatedDate = DateTime.Now;
                        entity.CreatedBy = SessionUser.UserID;

                        entities.AcGroupConverts.Add(entity);
                        entities.SaveChangesWithAuditLogs();
                    }
                    LoadAircafts();

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

            var entity = entities.AcGroupConverts.SingleOrDefault(x => x.ID == key);
            if (entity == null)
                return;

            var result = new Dictionary<string, object>();

            result["AcIataCode"] = entity.AcIataCode;
            result["AcICAOCode"] = entity.AcICAOCode;
            result["AcGroup"] = entity.AcGroup;
            result["AcName"] = entity.AcName;
            result["Remarks"] = entity.Remarks;
            result["Convert_321"] = entity.Convert_321.HasValue ? entity.Convert_321.Value : 0;

            e.Result = result;
        }
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
                options.SheetName = "ACGroup";
                GridViewExporter.WriteXlsxToResponse(options);
                break;
            case "RTF":
                GridViewExporter.Landscape = true;
                GridViewExporter.WriteRtfToResponse();
                break;
        }
    }
}