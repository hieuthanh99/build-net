using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;


public partial class Pages_DecPurchaseForm : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack || DataGrid.IsCallback)
        {
            LoadDataToGrid();
            this.DataGrid.ExpandAll();
        }
    }

    #region Load data
    private void LoadDataToGrid()
    {
        var list = entities.DEC_PURCHASE_FORM.OrderBy(x => x.SEQ).ToList();
        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }
    #endregion
    protected void ParentEditor_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DEC_PURCHASE_FORM.OrderBy(x => x.SEQ).ToList();
        s.DataSource = list;
        s.ValueField = "ID";
        s.TextField = "Description";
        s.DataBind();

    }
    protected void DataGrid_CustomCallback(object sender, TreeListCustomCallbackEventArgs e)
    {
        ASPxTreeList s = sender as ASPxTreeList;
        string[] args = e.Argument.Split('|');
        if (args[0].Equals(Action.REFRESH))
        {
            s.JSProperties["cpResult"] = Action.REFRESH;
            LoadDataToGrid();
        }
        else if (args[0].Equals(Action.DELETE))
        {
            s.JSProperties["cpResult"] = Action.DELETE;
            decimal key;
            if (!decimal.TryParse(args[1], out key))
                return;

            var entity = (from x in entities.DEC_PURCHASE_FORM where x.ID == key select x).FirstOrDefault();
            if (entity != null)
            {
                entities.DEC_PURCHASE_FORM.Remove(entity);
                entities.SaveChanges();
                LoadDataToGrid();
            }
        }

        else if (args[0].Equals("SaveForm"))
        {
            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];

                    if (command.ToUpper() == "EDIT")
                    {
                        decimal key;
                        if (!decimal.TryParse(args[2], out key))
                            return;


                        var entity = entities.DEC_PURCHASE_FORM.Where(x => x.ID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            if (ParentEditor.Value != null)
                                entity.PARENT_ID = Convert.ToInt32(ParentEditor.Value);
                            else
                                entity.PARENT_ID = null;
                            entity.DESCRIPTION = DescriptionEditor.Text;
                            if (IS_PARENTEditor.Value != null)
                                entity.IS_PARENT = IS_PARENTEditor.Value.ToString();
                            else
                                entity.IS_PARENT = "N";
                            entity.SORTING = SortingEditor.Text;
                            entity.ACTIVE = ActiveEditor.Checked ? "Y" : "N";
                            entities.SaveChanges();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new DEC_PURCHASE_FORM();
                        if (ParentEditor.Value != null)
                            entity.PARENT_ID = Convert.ToInt32(ParentEditor.Value);
                        else
                            entity.PARENT_ID = null;
                        entity.DESCRIPTION = DescriptionEditor.Text;

                        if (IS_PARENTEditor.Value != null)
                            entity.IS_PARENT = IS_PARENTEditor.Value.ToString();
                        else
                            entity.IS_PARENT = "N";
                        
                        entity.SORTING = SortingEditor.Text;
                        entity.ACTIVE = ActiveEditor.Checked ? "Y" : "N";

                        entities.DEC_PURCHASE_FORM.Add(entity);
                        entities.SaveChanges();
                    }
                    LoadDataToGrid();

                    s.JSProperties["cpResult"] = "Success";
                }
                catch (Exception ex)
                {
                    s.JSProperties["cpResult"] = ex.Message;
                }
            }
        }
    }
    protected void DataGrid_CustomDataCallback(object sender, TreeListCustomDataCallbackEventArgs e)
    {
        decimal key;
        if (!decimal.TryParse(e.Argument, out key))
            return;

        var enty = entities.DEC_PURCHASE_FORM.SingleOrDefault(x => x.ID == key);
        if (enty == null)
            return;

        var result = new Dictionary<string, string>();
        result["PARENT_ID"] = (enty.PARENT_ID ?? decimal.Zero).ToString();
        result["DESCRIPTION"] = enty.DESCRIPTION;
        result["IS_PARENT"] = enty.IS_PARENT;
        result["SORTING"] = enty.SORTING;
        //result["ACTIVE"] = (enty.ACTIVE ?? false) ? "True" : "False";

        e.Result = result;
    }   
}