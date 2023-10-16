using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Pages_AutoItem : BasePage
{

    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.mMain.Items.FindByName("New").Visible = IsGranted("Pages.KHTC.Configs.AutoItem.Create");
        this.mMain.Items.FindByName("Edit").Visible = IsGranted("Pages.KHTC.Configs.AutoItem.Edit");
        this.mMain.Items.FindByName("Delete").Visible = IsGranted("Pages.KHTC.Configs.AutoItem.Delete");
        this.mMain.Items.FindByName("SyncData").Visible = IsGranted("Pages.KHTC.Configs.AutoItem.SyncData");

        LoadCompanyID(this.DataGrid);
        LoadSubaccountID(this.DataGrid);
        LoadActivityID(this.DataGrid);
        LoadUnitVersionID(this.DataGrid);


        LoadDataToGrid();

        if (!IsPostBack || DataGrid.IsCallback)
        {
            this.DataGrid.ExpandAll();
        }



    }

    #region Load data
    private void LoadDataToGrid()
    {
        var list = entities.AutoItems.OrderBy(x => x.Seq).ToList();
        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }
    private void LoadCompanyID(ASPxTreeList Grid)
    {
        TreeListComboBoxColumn aCombo = (TreeListComboBoxColumn)Grid.Columns["CompanyID"];


        var list = entities.DecCompanies.Where(x => x.CompanyType == "D").OrderBy(x => x.Seq).ToList();
        aCombo.PropertiesComboBox.DataSource = list;
        aCombo.PropertiesComboBox.ValueField = "CompanyID";
        aCombo.PropertiesComboBox.TextField = "NameV";
    }

    private void LoadSubaccountID(ASPxTreeList Grid)
    {
        TreeListComboBoxColumn aCombo = (TreeListComboBoxColumn)Grid.Columns["SubaccountID"];


        var list = entities.DecSubaccounts.Where(x => x.Calculation != "SUM").OrderBy(x => x.Seq).ToList();
        aCombo.PropertiesComboBox.DataSource = list;
        aCombo.PropertiesComboBox.ValueField = "SubaccountID";
        aCombo.PropertiesComboBox.TextField = "Description";
    }
    private void LoadActivityID(ASPxTreeList Grid)
    {
        TreeListComboBoxColumn aCombo = (TreeListComboBoxColumn)Grid.Columns["ActivityID"];


        var list = entities.Activities.Where(x => x.Calculation != "SUM").OrderBy(x => x.Seq).ToList();
        aCombo.PropertiesComboBox.DataSource = list;
        aCombo.PropertiesComboBox.ValueField = "ActivityID";
        aCombo.PropertiesComboBox.TextField = "ActivityName";
    }

    private void LoadUnitVersionID(ASPxTreeList Grid)
    {
        TreeListComboBoxColumn aCombo = (TreeListComboBoxColumn)Grid.Columns["UnitVersionID"];


        var list = entities.Versions.OrderBy(x => x.VersionYear).ToList();
        aCombo.PropertiesComboBox.DataSource = list;
        aCombo.PropertiesComboBox.ValueField = "VersionID";
        aCombo.PropertiesComboBox.TextField = "VersionName";
    }
    #endregion
    protected void ParentEditor_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.AutoItems.OrderBy(x => x.Seq).ToList();
        s.DataSource = list;
        s.ValueField = "AutoItemID";
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

            var entity = (from x in entities.AutoItems where x.AutoItemID == key select x).FirstOrDefault();
            if (entity != null)
            {
                entities.AutoItems.Remove(entity);
                entities.SaveChangesWithAuditLogs();
                LoadDataToGrid();
            }
        }
        else if (args[0].Equals(Action.SYNC_DATA))
        {
            s.JSProperties["cpResult"] = Action.SYNC_DATA;
            entities.Sync_PMSAutoItem();

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


                        var entity = entities.AutoItems.Where(x => x.AutoItemID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            if (ParentEditor.Value != null)
                                entity.ParentID = Convert.ToInt32(ParentEditor.Value);
                            else
                                entity.ParentID = null;
                            entity.ViewName = ViewNameEditor.Text;
                            entity.ModuleName = ModuleNameEditor.Text;
                            entity.RunSelect = RunSelectEditor.Checked;
                            entity.Inputs = InputsEditor.Text;
                            entity.Outputs = OutputsEditor.Text;
                            entity.Description = DescriptionEditor.Text;
                            if (CompanyEditor.Value != null)
                                entity.CompanyID = Convert.ToInt32(CompanyEditor.Value);
                            else
                                entity.CompanyID = null;
                            if (SubaccountEditor.Value != null)
                                entity.SubaccountID = Convert.ToInt32(SubaccountEditor.Value);
                            else
                                entity.SubaccountID = null;
                            entity.Item = ItemEditor.Text;
                            entity.CheckBefore = CheckBeforeEditor.Text;
                            entity.CheckAfter = CheckAfterEditor.Text;
                            if (StepsEditor.Value != null)
                                entity.Steps = Convert.ToInt32(StepsEditor.Number);
                            else
                                entity.Steps = null;

                            entity.SQL_P1 = SqlP1Editor.Text;
                            entity.SQL_P2 = SqlP2Editor.Text;
                            entity.SQL_Q1 = SqlQ1Editor.Text;
                            entity.SQL_Q2 = SqlQ2Editor.Text;
                            if (ActiveEditor.Value != null)
                                entity.ActivityID = Convert.ToInt32(ActiveEditor.Value);
                            else
                                entity.ActivityID = null;

                            entity.Cls = ClsEditor.Text;
                            if (UnitVersionEditor.Value != null)
                                entity.UnitVersionID = Convert.ToDecimal(UnitVersionEditor.Value);
                            else
                                entity.UnitVersionID = null;

                            entity.UnitFormula = UnitFormulaEditor.Text;
                            //entity.SimilarGroup = SimilarGroupEditor.Text;
                            //entity.SqlSimilar = SQLSimilarEditor.Text;
                            entity.GroupType = GroupTypeEditor.Text;
                            entity.AutoType = AutoTypeEditor.Text;

                            entity.Active = ActiveEditor.Checked;
                            if (SeqEditor.Value != null)
                                entity.Seq = Convert.ToInt32(SeqEditor.Number);
                            else
                                entity.Seq = null;

                            entity.LastUpdateDate = DateTime.Now;
                            entity.LastUpdatedBy = (int)SessionUser.UserID;
                            entities.SaveChangesWithAuditLogs();



                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new AutoItem();
                        if (ParentEditor.Value != null)
                            entity.ParentID = Convert.ToInt32(ParentEditor.Value);
                        else
                            entity.ParentID = null;
                        entity.ViewName = ViewNameEditor.Text;
                        entity.ModuleName = ModuleNameEditor.Text;
                        entity.RunSelect = RunSelectEditor.Checked;
                        entity.Inputs = InputsEditor.Text;
                        entity.Outputs = OutputsEditor.Text;
                        entity.Description = DescriptionEditor.Text;
                        if (CompanyEditor.Value != null)
                            entity.CompanyID = Convert.ToInt32(CompanyEditor.Value);
                        else
                            entity.CompanyID = null;
                        if (SubaccountEditor.Value != null)
                            entity.SubaccountID = Convert.ToInt32(SubaccountEditor.Value);
                        else
                            entity.SubaccountID = null;
                        entity.Item = ItemEditor.Text;
                        entity.CheckBefore = CheckBeforeEditor.Text;
                        entity.CheckAfter = CheckAfterEditor.Text;
                        if (StepsEditor.Value != null)
                            entity.Steps = Convert.ToInt32(StepsEditor.Number);
                        else
                            entity.Steps = null;

                        entity.SQL_P1 = SqlP1Editor.Text;
                        entity.SQL_P2 = SqlP2Editor.Text;
                        entity.SQL_Q1 = SqlQ1Editor.Text;
                        entity.SQL_Q2 = SqlQ2Editor.Text;
                        if (ActiveEditor.Value != null)
                            entity.ActivityID = Convert.ToInt32(ActiveEditor.Value);
                        else
                            entity.ActivityID = null;

                        entity.Cls = ClsEditor.Text;
                        if (UnitVersionEditor.Value != null)
                            entity.UnitVersionID = Convert.ToDecimal(UnitVersionEditor.Value);
                        else
                            entity.UnitVersionID = null;

                        entity.UnitFormula = UnitFormulaEditor.Text;
                        //entity.SimilarGroup = SimilarGroupEditor.Text;
                        //entity.SqlSimilar = SQLSimilarEditor.Text;
                        entity.GroupType = GroupTypeEditor.Text;
                        entity.AutoType = AutoTypeEditor.Text;

                        entity.Active = ActiveEditor.Checked;
                        if (SeqEditor.Value != null)
                            entity.Seq = Convert.ToInt32(SeqEditor.Number);
                        else
                            entity.Seq = null;

                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.AutoItems.Add(entity);
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
    protected void DataGrid_CustomDataCallback(object sender, TreeListCustomDataCallbackEventArgs e)
    {
        decimal key;
        if (!decimal.TryParse(e.Argument, out key))
            return;

        var autoItem = entities.AutoItems.SingleOrDefault(x => x.AutoItemID == key);
        if (autoItem == null)
            return;

        var result = new Dictionary<string, string>();
        result["ParentID"] = (autoItem.ParentID ?? decimal.Zero).ToString();
        result["ViewName"] = autoItem.ViewName;
        result["ModuleName"] = autoItem.ModuleName;
        result["RunSelect"] = (autoItem.RunSelect ?? false) ? "True" : "False";
        result["Inputs"] = autoItem.Inputs;
        result["Outputs"] = autoItem.Outputs;
        result["Description"] = autoItem.Description;
        result["CompanyID"] = autoItem.CompanyID.HasValue ? autoItem.CompanyID.ToString() : "";
        result["SubaccountID"] = autoItem.SubaccountID.HasValue ? autoItem.SubaccountID.ToString() : "";
        result["Item"] = autoItem.Item;
        result["CheckBefore"] = autoItem.CheckBefore;
        result["CheckAfter"] = autoItem.CheckAfter;
        result["Steps"] = autoItem.Steps.HasValue ? autoItem.Steps.ToString() : "";
        result["SQL_Q1"] = autoItem.SQL_Q1;
        result["SQL_Q2"] = autoItem.SQL_Q2;
        result["SQL_P1"] = autoItem.SQL_P1;
        result["SQL_P2"] = autoItem.SQL_P2;
        result["ActivityID"] = autoItem.ActivityID.HasValue ? autoItem.ActivityID.ToString() : "";
        result["Cls"] = autoItem.Cls;
        result["UnitVersionID"] = autoItem.UnitVersionID.HasValue ? autoItem.UnitVersionID.ToString() : "";
        result["UnitFormula"] = autoItem.UnitFormula;
        result["SimilarGroup"] = autoItem.SimilarGroup;
        result["SqlSimilar"] = autoItem.SqlSimilar;
        result["GroupType"] = autoItem.GroupType;
        result["AutoType"] = autoItem.AutoType;
        result["Active"] = (autoItem.Active ?? false) ? "True" : "False";
        result["Seq"] = (autoItem.Seq ?? 0).ToString();

        e.Result = result;
    }

    protected void DataGrid_HtmlRowPrepared(object sender, TreeListHtmlRowEventArgs e)
    {
        //if (Object.Equals(e.GetValue("Calculation"), "SUM"))
        //{
        //    e.Row.Font.Bold = true;
        //}
    }


    protected void mMain_ItemClick(object source, MenuItemEventArgs e)
    {
        string strParams = string.Empty;
        string url = string.Empty;

        TreeListExporter.WriteXlsxToResponse();

    }
    protected void ASPxButton2_Click(object sender, EventArgs e)
    {
        TreeListExporter.WriteXlsxToResponse();
    }

    protected void CompanyEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DecCompanies.Where(x => x.CompanyType == "D").Select(x => new { ValueField = x.CompanyID, TextField = x.NameV }).ToList();
        s.DataSource = list;
        s.ValueField = "ValueField";
        s.TextField = "TextField";
        s.DataBind();
    }

    protected void SubaccountEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DecSubaccounts.Where(x => x.Calculation != "SUM").Select(x => new { ValueField = x.SubaccountID, TextField = x.Description }).ToList();
        s.DataSource = list;
        s.ValueField = "ValueField";
        s.TextField = "TextField";
        s.DataBind();
    }

    protected void ActivityEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Activities.Select(x => new { ValueField = x.ActivityID, TextField = x.ActivityName }).ToList();
        s.DataSource = list;
        s.ValueField = "ValueField";
        s.TextField = "TextField";
        s.DataBind();
    }

    protected void UnitVersionEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Versions.Select(x => new { ValueField = x.VersionID, TextField = x.VersionName }).ToList();
        s.DataSource = list;
        s.ValueField = "ValueField";
        s.TextField = "TextField";
        s.DataBind();
    }
}