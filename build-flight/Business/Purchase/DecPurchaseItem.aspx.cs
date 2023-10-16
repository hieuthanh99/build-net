using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using KTQTData;

public partial class Pages_DecPurchaseItem : BasePage
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
        var list = entities.DEC_PURCHASE_ITEM.OrderBy(x => x.SEQ).ToList();
        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }
    #endregion
    protected void ParentEditor_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DEC_PURCHASE_ITEM.OrderBy(x => x.SEQ).ToList();
        s.DataSource = list;
        s.ValueField = "ID";
        s.TextField = "PURCHASE_ITEM_NAME";
        s.DataBind();

    }



    protected void PurchaseUnitEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DEC_ITEM_UNITS.OrderBy(x => x.ID).ToList();
        s.DataSource = list;
        s.ValueField = "ID";
        s.TextField = "UNIT_NAME";
        s.DataBind();
    }

    protected void DataGrid_CustomColumnDisplayText(object sender, TreeListColumnDisplayTextEventArgs e)
    {

        if (e.Column.FieldName == "ITEM_UNIT_ID")
        {
            var ItemUnitID = e.Value;
            var ItemUnitName = entities.Database.SqlQuery<string>("SELECT UNIT_NAME From DEC_ITEM_UNITS Where ID = " + ItemUnitID).SingleOrDefault();

            e.DisplayText = ItemUnitName;
        }
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

            var entity = (from x in entities.DEC_PURCHASE_ITEM where x.ID == key select x).FirstOrDefault();
            if (entity != null)
            {
                entities.DEC_PURCHASE_ITEM.Remove(entity);
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


                        var entity = entities.DEC_PURCHASE_ITEM.Where(x => x.ID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            if (ParentEditor.Value != null)
                                entity.PARENT_ID = Convert.ToInt32(ParentEditor.Value);
                            else
                                entity.PARENT_ID = null;

                            if (IS_PARENTEditor.Value != null)
                                entity.IS_PARENT = IS_PARENTEditor.Value.ToString();
                            else
                                entity.IS_PARENT = "N";
                            entity.SORTING = SortingEditor.Text;
                            entity.PURCHASE_ITEM_NAME = PURCHASE_ITEM_NAMEEditor.Text;
                            entity.ITEM_UNIT_ID = Convert.ToInt32(PurchaseUnitEditor.Value);
                            entity.ACTIVE = ActiveEditor.Checked ? "Y" : "N";
                            entities.SaveChanges();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new DEC_PURCHASE_ITEM();
                        if (ParentEditor.Value != null)
                            entity.PARENT_ID = Convert.ToInt32(ParentEditor.Value);
                        else
                            entity.PARENT_ID = null;


                        if (IS_PARENTEditor.Value != null)
                            entity.IS_PARENT = IS_PARENTEditor.Value.ToString();
                        else
                            entity.IS_PARENT = "N";

                        entity.SORTING = SortingEditor.Text;
                        entity.PURCHASE_ITEM_NAME = PURCHASE_ITEM_NAMEEditor.Text;
                        entity.ITEM_UNIT_ID = Convert.ToInt32(PurchaseUnitEditor.Value);

                        entity.ACTIVE = ActiveEditor.Checked ? "Y" : "N";

                        entities.DEC_PURCHASE_ITEM.Add(entity);
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

        var enty = entities.DEC_PURCHASE_ITEM.SingleOrDefault(x => x.ID == key);
        if (enty == null)
            return;

        var result = new Dictionary<string, string>();
        result["PARENT_ID"] = (enty.PARENT_ID ?? decimal.Zero).ToString();
        result["PURCHASE_ITEM_NAME"] = enty.PURCHASE_ITEM_NAME;
        result["ITEM_UNIT_ID"] = enty.ITEM_UNIT_ID.ToString();
        result["IS_PARENT"] = enty.IS_PARENT;
        result["SORTING"] = enty.SORTING;
        //result["ACTIVE"] = (enty.ACTIVE ?? false) ? "True" : "False";

        e.Result = result;
    }
}