using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using KTQTData;

public partial class Pages_DecUnitItem : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack || DataGrid.IsCallback)
        {
            LoadDataGrid();
        }
    }

    #region Load data
    private void LoadDataGrid()
    {
        var list = entities.DEC_ITEM_UNITS.OrderBy(x => x.ID).ToList();
        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }
    #endregion

    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        if (args[0].Equals(Action.REFRESH))
        {
            s.JSProperties["cpResult"] = Action.REFRESH;
            LoadDataGrid();
        }
        else if (args[0].Equals(Action.DELETE))
        {
            s.JSProperties["cpResult"] = Action.DELETE;
            int key = Convert.ToInt32(args[1]);

            var id = (from x in entities.DEC_ITEM_UNITS where x.ID == key select x).FirstOrDefault();
            if (id != null)
            {
                entities.DEC_ITEM_UNITS.Remove(id);
                entities.SaveChanges();
                LoadDataGrid();
            }
        }

        else if (args[0].Equals("SaveForm"))
        {
            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];
                    var aUNIT_NAMEEditor = UNIT_NAMEEditor.Text;                    
                    var aActive = "Y";//ActiveEditor.Checked;

                    if (command.ToUpper() == "EDIT")
                    {
                        int key = Convert.ToInt32(args[2]);

                        var entity = entities.DEC_ITEM_UNITS.Where(x => x.ID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            entity.UNIT_NAME = aUNIT_NAMEEditor;
                            entity.ACTIVE = aActive;

                            entities.SaveChanges();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new DEC_ITEM_UNITS();
                        entity.UNIT_NAME = aUNIT_NAMEEditor;                        
                        entity.ACTIVE = aActive;

                        entities.DEC_ITEM_UNITS.Add(entity);
                        entities.SaveChanges();
                    }
                    LoadDataGrid();

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
            int key = Convert.ToInt32(args[2]);

            var enti = entities.DEC_ITEM_UNITS.SingleOrDefault(x => x.ID == key);
            if (enti == null)
                return;

            var result = new Dictionary<string, string>();
            result["UNIT_NAME"] = enti.UNIT_NAME;           
            //result["Active"] = (supplier.ACTIVE ?? false) ? "TRUE" : "FALSE";

            e.Result = result;
        }
    }
}

