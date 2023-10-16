using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using KTQTData;

public partial class Pages_Subaccount : BasePage
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
        var list = entities.DecSubaccounts.OrderBy(x => x.Seq).ToList();
        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }
    #endregion
    protected void ParentEditor_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DecSubaccounts.OrderBy(x => x.Seq).ToList();
        s.DataSource = list;
        s.ValueField = "SubaccountID";
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

            var entity = (from x in entities.DecSubaccounts where x.SubaccountID == key select x).FirstOrDefault();
            if (entity != null)
            {
                entities.DecSubaccounts.Remove(entity);
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


                        var entity = entities.DecSubaccounts.Where(x => x.SubaccountID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            if (ParentEditor.Value != null)
                                entity.SubaccountParentID = Convert.ToInt32(ParentEditor.Value);
                            else
                                entity.SubaccountParentID = null;
                            entity.Description = DescriptionEditor.Text;
                            entity.Calculation = CalculationEditor.Text;
                            if (AccountTypeEditor.Value != null)
                                entity.AccountType = (int)AccountTypeEditor.Value;
                            else
                                entity.AccountType = null;
                            if (AccountGroupEditor.Value != null)
                                entity.AccountGroup = AccountGroupEditor.Value.ToString();
                            else
                                entity.AccountGroup = string.Empty;
                            if (ActivityEditor.Value != null)
                                entity.ActivityID = Convert.ToDecimal(ActivityEditor.Value);
                            else
                                entity.ActivityID = null;
                            entity.Active = ActiveEditor.Checked;
                            entity.Seq = (int)SeqEditor.Number;
                            entity.Sorting = SortingEditor.Text;
                            entity.Note = NoteEditor.Text;

                            entity.LastUpdateDate = DateTime.Now;
                            entity.LastUpdatedBy = (int)SessionUser.UserID;
                            entities.SaveChanges();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new DecSubaccount();
                        if (ParentEditor.Value != null)
                            entity.SubaccountParentID = Convert.ToInt32(ParentEditor.Value);
                        else
                            entity.SubaccountParentID = null;
                        entity.Description = DescriptionEditor.Text;
                        entity.Calculation = CalculationEditor.Text;
                        if (AccountTypeEditor.Value != null)
                            entity.AccountType = (int)AccountTypeEditor.Value;
                        else
                            entity.AccountType = null;
                        if (AccountGroupEditor.Value != null)
                            entity.AccountGroup = AccountGroupEditor.Value.ToString();
                        else
                            entity.AccountGroup = string.Empty;
                        if (ActivityEditor.Value != null)
                            entity.ActivityID = Convert.ToDecimal(ActivityEditor.Value);
                        else
                            entity.ActivityID = null;
                        entity.Active = ActiveEditor.Checked;
                        entity.Seq = (int)SeqEditor.Number;
                        entity.Sorting = SortingEditor.Text;
                        entity.Note = NoteEditor.Text;

                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.DecSubaccounts.Add(entity);
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

        var subaccount = entities.DecSubaccounts.SingleOrDefault(x => x.SubaccountID == key);
        if (subaccount == null)
            return;

        var result = new Dictionary<string, string>();
        result["ParentID"] = (subaccount.SubaccountParentID ?? decimal.Zero).ToString();
        result["Description"] = subaccount.Description;
        result["Calculation"] = subaccount.Calculation;
        result["AccountGroup"] = subaccount.AccountGroup;
        result["AccountType"] = (subaccount.AccountType ?? 0).ToString();
        result["ActivityID"] = (subaccount.ActivityID ?? decimal.Zero).ToString();
        result["Active"] = (subaccount.Active ?? false) ? "True" : "False";
        result["Seq"] = (subaccount.Seq ?? 0).ToString();
        result["Sorting"] = subaccount.Sorting;
        result["Note"] = subaccount.Note;

        e.Result = result;
    }
    protected void ActivityEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Activities.OrderBy(x => x.Seq).ToList();
        s.DataSource = list;
        s.ValueField = "ActivityID";
        s.TextField = "ActivityName";
        s.DataBind();
    }
}