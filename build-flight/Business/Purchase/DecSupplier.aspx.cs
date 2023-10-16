using DevExpress.Web;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;


public partial class Pages_DecSupplier : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack || DecSupplierGrid.IsCallback)
        {
            LoadDecSupplier();
        }
    }

    #region Load data
    private void LoadDecSupplier()
    {
        var list = entities.DEC_SUPPLIER.OrderBy(x => x.SUP_CODE).ToList();
        this.DecSupplierGrid.DataSource = list;
        this.DecSupplierGrid.DataBind();
    }
    #endregion

    protected void DecSupplierGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        if (args[0].Equals(Action.REFRESH))
        {
            s.JSProperties["cpResult"] = Action.REFRESH;
            LoadDecSupplier();
        }
        else if (args[0].Equals(Action.DELETE))
        {
            s.JSProperties["cpResult"] = Action.DELETE;
            string key = args[1];

            var sup_code = (from x in entities.DEC_SUPPLIER where x.SUP_CODE == key select x).FirstOrDefault();
            if (sup_code != null)
            {
                entities.DEC_SUPPLIER.Remove(sup_code);
                entities.SaveChanges();
                LoadDecSupplier();
            }
        }

        else if (args[0].Equals("SaveForm"))
        {
            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];
                    var aSUP_CODEEditor = SUP_CODEEditor.Text;
                    var aSUP_NAMEEditor = SUP_NAMEEditor.Text;
                    var aSHORT_NAMEEditor = SHORT_NAMEEditor.Text;
                    var aDESCRIPTIONEditor = DESCRIPTIONEditor.Text;
                    var aADDRESSEditor = ADDRESSEditor.Text;
                    var aTELEditor = TELEditor.Text;
                    var aFAXEditor = FAXEditor.Text;
                    var aEMAILEditor = EMAILEditor.Text;
                    var aWEBSITEEditor = WEBSITEEditor.Text;
                    var aActive = "Y";//ActiveEditor.Checked;

                    if (command.ToUpper() == "EDIT")
                    {
                        string key = args[2];

                        var entity = entities.DEC_SUPPLIER.Where(x => x.SUP_CODE == key).SingleOrDefault();
                        if (entity != null)
                        {
                            entity.SUP_CODE = aSUP_CODEEditor;
                            entity.SUP_NAME = aSUP_NAMEEditor;
                            entity.SHORT_NAME = aSHORT_NAMEEditor;
                            entity.DESCRIPTION = aDESCRIPTIONEditor;
                            entity.ADDRESS = aADDRESSEditor;
                            entity.TEL = aTELEditor;
                            entity.FAX = aFAXEditor;
                            entity.EMAIL = aEMAILEditor;
                            entity.WEBSITE = aWEBSITEEditor;
                            entity.ACTIVE = aActive;

                            entities.SaveChanges();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new DEC_SUPPLIER();
                        entity.SUP_CODE = aSUP_CODEEditor;
                        entity.SUP_NAME = aSUP_NAMEEditor;
                        entity.SHORT_NAME = aSHORT_NAMEEditor;
                        entity.DESCRIPTION = aDESCRIPTIONEditor;
                        entity.ADDRESS = aADDRESSEditor;
                        entity.TEL = aTELEditor;
                        entity.FAX = aFAXEditor;
                        entity.EMAIL = aEMAILEditor;
                        entity.WEBSITE = aWEBSITEEditor;
                        entity.ACTIVE = aActive;

                        entities.DEC_SUPPLIER.Add(entity);
                        entities.SaveChanges();
                    }
                    LoadDecSupplier();

                    s.JSProperties["cpResult"] = "Success";
                }
                catch (Exception ex)
                {
                    s.JSProperties["cpResult"] = ex.Message;
                }
            }
        }
    }
    protected void DecSupplierGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "EditForm" && args.Length == 3)
        {
            string key = args[2];

            var supplier = entities.DEC_SUPPLIER.SingleOrDefault(x => x.SUP_CODE == key);
            if (supplier == null)
                return;

            var result = new Dictionary<string, string>();
            result["SUP_CODE"] = supplier.SUP_CODE;
            result["SUP_NAME"] = supplier.SUP_NAME;
            result["SHORT_NAME"] = supplier.SHORT_NAME;
            result["DESCRIPTION"] = supplier.DESCRIPTION;
            result["ADDRESS"] = supplier.ADDRESS;
            result["TEL"] = supplier.TEL;
            result["FAX"] = supplier.FAX;
            result["EMAIL"] = supplier.EMAIL;
            result["WEBSITE"] = supplier.WEBSITE;
            //result["Active"] = (supplier.ACTIVE ?? false) ? "TRUE" : "FALSE";

            e.Result = result;
        }
    }
}

