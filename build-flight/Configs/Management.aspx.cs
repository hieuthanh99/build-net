using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using KTQTData;

public partial class Pages_Management : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack || DataGrid.IsCallback)
        {
            LoadDataToGrid();
            DataGrid.ExpandAll();
        }
    }

    #region Load data
    private void LoadDataToGrid()
    {
        var list = entities.DecManagements.OrderBy(x => x.Seq).ToList();
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
            int key;
            if (!int.TryParse(args[1], out key))
                return;

            var entity = (from x in entities.DecManagements where x.DivisionID == key select x).FirstOrDefault();
            if (entity != null)
            {
                entities.DecManagements.Remove(entity);
                entities.SaveChanges();
                LoadDataToGrid();
            }
        }
        else if (args[0].Equals(Action.SYNC_DATA))
        {
            s.JSProperties["cpResult"] = Action.SYNC_DATA;
            entities.Sync_PMSDecManagement();

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
                        int key;
                        if (!int.TryParse(args[2], out key))
                            return;


                        var entity = entities.DecManagements.Where(x => x.DivisionID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            if (ParentEditor.Value != null)
                                entity.ParentID = Convert.ToInt32(ParentEditor.Value);
                            else
                                entity.ParentID = null;
                            entity.ShortName = ShortNameEditor.Text;
                            entity.NameE = NameENEditor.Text;
                            entity.NameV = NameVNEditor.Text;
                            if (ValidFromEditor.Value != null)
                                entity.ValidFrom = ValidFromEditor.Date;
                            else
                                entity.ValidFrom = null;
                            if (ValidToEditor.Value != null)
                                entity.ValidTo = ValidToEditor.Date;
                            else
                                entity.ValidTo = null;
                            if (ActivityEditor.Value != null)
                                entity.ActivityID = Convert.ToDecimal(ActivityEditor.Value);
                            else
                                entity.ActivityID = null;
                            entity.Seq = (int)SeqEditor.Number;
                            entity.Note = NoteEditor.Text;

                            entity.LastUpdateDate = DateTime.Now;
                            entity.LastUpdatedBy = (int)SessionUser.UserID;
                            entities.SaveChanges();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new DecManagement();
                        if (ParentEditor.Value != null)
                            entity.ParentID = Convert.ToInt32(ParentEditor.Value);
                        else
                            entity.ParentID = null;
                        entity.ShortName = ShortNameEditor.Text;
                        entity.NameE = NameENEditor.Text;
                        entity.NameV = NameVNEditor.Text;
                        if (ValidFromEditor.Value != null)
                            entity.ValidFrom = ValidFromEditor.Date;                  
                        if (ValidToEditor.Value != null)
                            entity.ValidTo = ValidToEditor.Date;
                       
                        if (ActivityEditor.Value != null)
                            entity.ActivityID = Convert.ToDecimal(ActivityEditor.Value);
                        else
                            entity.ActivityID = null;
                        entity.Seq = (int)SeqEditor.Number;
                        entity.Note = NoteEditor.Text;

                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.DecManagements.Add(entity);
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
    protected void DataGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
    {
        int key;
        if (!int.TryParse(e.Argument, out key))
            return;

        var management = entities.DecManagements.SingleOrDefault(x => x.DivisionID == key);
        if (management == null)
            return;

        var result = new Dictionary<string, string>();
        result["ParentID"] = (management.ParentID ?? decimal.Zero).ToString();
        result["ShortName"] = management.ShortName;
        result["NameV"] = management.NameV;
        result["NameE"] = management.NameE;
        result["ValidFrom"] = management.ValidFrom.HasValue ? management.ValidFrom.Value.ToString("yyyy-MM-dd") : string.Empty;
        result["ValidTo"] = management.ValidTo.HasValue ? management.ValidTo.Value.ToString("yyyy-MM-dd") : string.Empty;
        result["ActivityID"] = (management.ActivityID ?? decimal.Zero).ToString();
        result["Seq"] = (management.Seq ?? 0).ToString();
        result["Note"] = management.Note;

        e.Result = result;
    }
    protected void ParentEditor_Callback(object sender, CallbackEventArgsBase e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DecManagements.OrderBy(x => x.Seq).ToList();
        s.DataSource = list;
        s.ValueField = "DivisionID";
        s.TextField = "NameV";
        s.DataBind();
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