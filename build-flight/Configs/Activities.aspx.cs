using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;


public partial class Pages_Activities : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.mMain.Items.FindByName("New").Visible = IsGranted("Pages.KHTC.Configs.Activities.Create");
        this.mMain.Items.FindByName("Edit").Visible = IsGranted("Pages.KHTC.Configs.Activities.Edit");
        this.mMain.Items.FindByName("Delete").Visible = IsGranted("Pages.KHTC.Configs.Activities.Delete");

        if (!IsPostBack || DataGrid.IsCallback)
        {
            LoadDataToGrid();
            this.DataGrid.ExpandAll();
        }
    }

    #region Load data
    private void LoadDataToGrid()
    {
        var list = entities.Activities.OrderBy(x => x.Seq).ToList();
        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }
    #endregion
    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomCallbackEventArgs e)
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

            var entity = (from x in entities.Activities where x.ActivityID == key select x).FirstOrDefault();
            if (entity != null)
            {
                entities.Activities.Remove(entity);
                entities.SaveChangesWithAuditLogs();
                LoadDataToGrid();
            }
        }
        else if (args[0].Equals(Action.SYNC_DATA))
        {
            s.JSProperties["cpResult"] = Action.SYNC_DATA;
            entities.Sync_PMSActivity();

            LoadDataToGrid();
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


                        var entity = entities.Activities.Where(x => x.ActivityID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            if (ParentActivityEditor.Value != null)
                                entity.ParentID = Convert.ToInt32(ParentActivityEditor.Value);
                            else
                                entity.ParentID = null;
                            entity.ActivityName = ActivityNameEditor.Text;
                            entity.Driver = DriverEditor.Text;
                            entity.Unit = UnitEditor.Text;
                            entity.Indent = Convert.ToInt32(IndentEditor.Number);
                            entity.DataModule = DataModuleEditor.Text;
                            entity.Calculation = CalculationEditor.Text; ;
                            entity.Active = ActiveEditor.Checked;
                            entity.Seq = (int)SeqEditor.Number;
                            entity.Sorting = SortingEditor.Text;
                            entity.Note = NoteEditor.Text;

                            entity.LastUpdateDate = DateTime.Now;
                            entity.LastUpdatedBy = (int)SessionUser.UserID;
                            entities.SaveChangesWithAuditLogs();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new Activity();
                        if (ParentActivityEditor.Value != null)
                            entity.ParentID = Convert.ToInt32(ParentActivityEditor.Value);
                        else
                            entity.ParentID = null;
                        entity.ActivityName = ActivityNameEditor.Text;
                        entity.Driver = DriverEditor.Text;
                        entity.Unit = UnitEditor.Text;
                        entity.Indent = Convert.ToInt32(IndentEditor.Number);
                        entity.DataModule = DataModuleEditor.Text;
                        entity.Calculation = CalculationEditor.Text; ;
                        entity.Active = ActiveEditor.Checked;
                        entity.Seq = (int)SeqEditor.Number;
                        entity.Sorting = SortingEditor.Text;
                        entity.Note = NoteEditor.Text;

                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.Activities.Add(entity);
                        entities.SaveChangesWithAuditLogs();
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
    protected void DataGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
    {
        decimal key;
        if (!decimal.TryParse(e.Argument, out key))
            return;

        var activity = entities.Activities.SingleOrDefault(x => x.ActivityID == key);
        if (activity == null)
            return;

        var result = new Dictionary<string, string>();
        result["ParentID"] = (activity.ParentID ?? decimal.Zero).ToString();
        result["ActivityName"] = activity.ActivityName;
        result["Driver"] = activity.Driver;
        result["Unit"] = activity.Unit;
        result["Indent"] = (activity.Indent ?? 0).ToString();
        result["DataModule"] = activity.DataModule;
        result["Calculation"] = activity.Calculation;
        result["Active"] = (activity.Active ?? false) ? "True" : "False";
        result["Seq"] = (activity.Seq ?? 0).ToString();
        result["Sorting"] = activity.Sorting;
        result["Note"] = activity.Note;

        e.Result = result;

    }
    protected void ParentActivityEditor_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Activities.OrderBy(x => x.Seq).ToList();
        s.DataSource = list;
        s.ValueField = "ActivityID";
        s.TextField = "ActivityName";
        s.DataBind();
    }
}