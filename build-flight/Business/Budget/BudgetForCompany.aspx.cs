using DevExpress.Web;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Web.UI;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
public partial class Business_Budget_BudgetForCompany : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    string fileStorage = ConfigurationManager.AppSettings["FileStorage"];

    const string CURRENT_COMPANY = "618202CB-2F41-4A51-ABB7-254E91B9EB34";

    #region Callback Type
    enum ASPxGridViewCallbackType
    {
        None, Custom, Sorting, ApplyFilter, FilterEditing, StartEdit, UpdateEdit,
        CancelEdit, AddNewRow, DeleteRow, FocusRow, GotoPage, ColumnMoved, ExpandGroup, CollapseGroup, Unknown
    };
    ASPxGridViewCallbackType GetGridCallbackType()
    {
        const string GridCallbackSuffix = "GB|";
        const string ActionSorting = "SORT";
        const string ActionEdit = "STARTEDIT";
        const string ActionUpdate = "UPDATEEDIT";
        const string ActionCancel = "CANCELEDIT";
        const string ActionAddNewRow = "ADDNEWROW";
        const string ActionDeleteRow = "DELETEROW";
        const string ActionFocusRow = "FOCUSEDROW";
        const string ActionGotoPage = "PAGERONCLICK";
        const string ActionCustom = "CUSTOMCALLBACK";
        const string ActionFilterShowMenu = "FILTERROWMENU";
        const string ActionFilterPopup = "FILTERPOPUP";
        const string ActionShowFilterControl = "SHOWFILTERCONTROL";
        const string ActionCloseFilterControl = "CLOSEFILTERCONTROL";
        const string ActionApplyFilter = "APPLYFILTER";
        const string ActionApplyColumnFilter = "APPLYHEADERCOLUMNFILTER";
        const string ActionColumnMoved = "COLUMNMOVE";
        const string ActionExpandGroup = "EXPANDROW";
        const string ActionCollapseGroup = "COLLAPSEROW";

        string callbackParam = Request.Params["__CALLBACKPARAM"];
        if (string.IsNullOrEmpty(callbackParam)) return ASPxGridViewCallbackType.None;
        if (!callbackParam.Contains(GridCallbackSuffix)) return ASPxGridViewCallbackType.None;
        string action = callbackParam.Substring(callbackParam.IndexOf(GridCallbackSuffix));
        if (action.Contains(ActionCustom)) return ASPxGridViewCallbackType.Custom;
        if (action.Contains(ActionSorting)) return ASPxGridViewCallbackType.Sorting;
        if (action.Contains(ActionEdit)) return ASPxGridViewCallbackType.StartEdit;
        if (action.Contains(ActionUpdate)) return ASPxGridViewCallbackType.UpdateEdit;
        if (action.Contains(ActionCancel)) return ASPxGridViewCallbackType.CancelEdit;
        if (action.Contains(ActionAddNewRow)) return ASPxGridViewCallbackType.AddNewRow;
        if (action.Contains(ActionDeleteRow)) return ASPxGridViewCallbackType.DeleteRow;
        if (action.Contains(ActionFocusRow)) return ASPxGridViewCallbackType.FocusRow;
        if (action.Contains(ActionGotoPage)) return ASPxGridViewCallbackType.GotoPage;
        if (action.Contains(ActionFilterShowMenu) || action.Contains(ActionFilterPopup) || action.Contains(ActionShowFilterControl)
        || action.Contains(ActionCloseFilterControl)) return ASPxGridViewCallbackType.FilterEditing;
        if (action.Contains(ActionApplyFilter) || action.Contains(ActionApplyColumnFilter)) return ASPxGridViewCallbackType.ApplyFilter;
        if (action.Contains(ActionColumnMoved)) return ASPxGridViewCallbackType.ColumnMoved;
        if (action.Contains(ActionExpandGroup)) return ASPxGridViewCallbackType.ExpandGroup;
        if (action.Contains(ActionCollapseGroup)) return ASPxGridViewCallbackType.CollapseGroup;
        return ASPxGridViewCallbackType.Unknown;
    }

    #endregion

    #region Show/Hide Column

    private void ShowHideColumnInBand(ASPxGridView grid, string bandName, bool visibled)
    {
        GridViewBandColumn c = grid.Columns[bandName] as GridViewBandColumn;
        c.Visible = visibled;
        foreach (GridViewColumn col in c.Columns)
        {
            col.Visible = visibled;
        }
    }
    
    #endregion
    #region Load data
    private void LoadCompanies()
    {
        var currentCompanyID = SessionUser.CompanyID;
        if (Session[CURRENT_COMPANY] != null)
            currentCompanyID = (int?)Session[CURRENT_COMPANY];

        var list = entities.DecCompanies.Where(x => x.CompanyID != currentCompanyID && x.CompanyType == "D").OrderBy(x => x.Seq).ToList();
        this.CompanyGrid.DataSource = list;
        this.CompanyGrid.DataBind();
    }

    private void LoadVersions(string versionType, int versionYear)
    {
        var list = entities.Versions.Where(x => x.VersionType == versionType && x.VersionYear == versionYear && x.Calculation.Equals("BOTTOMUP") && x.Active.Value).OrderBy(x => x.Sorting).ToList();
        this.VersionGrid.DataSource = list;
        this.VersionGrid.DataBind();
    }


    private void LoadVersionCompany(decimal versionID)
    {
        var companyID = SessionUser.CompanyID;
        if (Session[CURRENT_COMPANY] != null)
            companyID = (int?)Session[CURRENT_COMPANY];

        var list = entities.VersionCompanies
            .Where(x => x.VersionID == versionID && x.CompanyID == companyID)
            .OrderByDescending(x => x.VersionNumber)
            .ToList();
        this.VersionCompanyGrid.DataSource = list;
        this.VersionCompanyGrid.DataBind();
    }

    private void LoadBudget(decimal verCompanyID)
    {
        var list = entities.Budgets.Where(x => x.VER_COMPANY_ID == verCompanyID).OrderBy(x => x.SEQ).ToList();
        this.BudgetGrid.DataSource = list;
        this.BudgetGrid.DataBind();
    }

    private void LoadVerCompanyFiles(decimal verCompanyID)
    {
        var list = entities.VersionCompanyFiles.Where(x => x.VerCompanyID == verCompanyID).ToList();
        this.VersionCompanyFilesGrid.DataSource = list;
        this.VersionCompanyFilesGrid.DataBind();
    }

    private void LoadBudgetFiles(decimal BudgetID)
    {
        var list = entities.BudgetFiles.Where(x => x.BUDGET_ID == BudgetID).ToList();
        this.BudgetFilesGrid.DataSource = list;
        this.BudgetFilesGrid.DataBind();
    }

    private void LoadBudgetDetail(decimal BudgetID)
    {
        var list = entities.BudgetDetails.Where(x => x.BUDGET_ID == BudgetID).OrderBy(x => x.BUDGET_MONTH).ToList();
        BudgetDetailGrid.DataSource = list;
        BudgetDetailGrid.DataBind();
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Remove(CURRENT_COMPANY);
            Session[CURRENT_COMPANY] = SessionUser.CompanyID;

            this.RevCostHiddenField.Set("CompanyID", SessionUser.CompanyID);
            this.RevCostHiddenField.Set("CompanyType", SessionUser.CompanyType);
        }

        if (!IsPostBack || this.VersionGrid.IsCallback)
        {
            if (!IsPostBack)
                this.VersionYearEditor.Value = DateTime.Now.Year;

            if (rdoVersionType.Value != null && this.VersionYearEditor.Value != null)
            {
                string versionType = rdoVersionType.Value.ToString();
                int versionYear = Convert.ToInt32(this.VersionYearEditor.Value);
                this.LoadVersions(versionType, versionYear);
            }
        }

        if (!IsPostBack || this.BudgetGrid.IsCallback)
        {
            if (this.BudgetGrid.IsCallback)
            {
                if (this.GetGridCallbackType() != ASPxGridViewCallbackType.Custom)
                {
                    if (this.RevCostHiddenField.Contains("VerCompanyID"))
                    {
                        var verCompanyID = Convert.ToDecimal(RevCostHiddenField.Get("VerCompanyID"));
                        this.LoadBudget(verCompanyID);
                    }
                }
            }
        }

        if (this.VersionCompanyGrid.IsCallback)
        {
            if (this.GetGridCallbackType() != ASPxGridViewCallbackType.Custom)
            {
                if (this.RevCostHiddenField.Contains("VersionID"))
                {
                    var verID = Convert.ToDecimal(RevCostHiddenField.Get("VersionID"));
                    this.LoadVersionCompany(verID);
                }
            }
        }


        // Report
        if (this.RevCostHiddenField.Contains("VerCompanyID"))
        {
            var verCompanyID1 = Convert.ToDecimal(RevCostHiddenField.Get("VerCompanyID"));
            var aVerCompany = entities.VersionCompanies.Where(x => x.VerCompanyID == verCompanyID1).FirstOrDefault();
            if (aVerCompany != null)
            {
                var aCompany = entities.DecCompanies.Where(x => x.CompanyID == aVerCompany.CompanyID).FirstOrDefault();
                if (aCompany != null)
                {
                    if (rdReport.Value.ToString().Equals("1"))
                    {
                        var aVersion = entities.Versions.Where(x => x.VersionID == aVerCompany.VersionID).FirstOrDefault();
                        if (aVersion != null)
                        {
                            //var report = new RptPlanningBudgetByPeriod();
                            //report.Parameters["pVerCompanyID"].Value = verCompanyID1;
                            //report.Parameters["pYear"].Value = aVersion.VersionYear;
                            //report.Parameters["pCompany"].Value = aCompany.NameV;
                            //report.Parameters["pRunTime"].Value = DateTime.Now;
                            //report.Parameters["pVersion"].Value = aVerCompany.VersionName;
                            //report.CreateDocument();
                            //ReportViewer.Report = report;
                        }
                    }
                    else if (rdReport.Value.ToString().Equals("2"))
                    {
                        //var report = new RptPlanningBudget();
                        //report.Parameters["pVerCompanyID"].Value = verCompanyID1;
                        //report.Parameters["pCompany"].Value = aCompany.NameV;
                        //report.Parameters["pRunTime"].Value = DateTime.Now;
                        //report.Parameters["pFromDate"].Value = Convert.ToDateTime(dedFromDate.Value);
                        //report.Parameters["pToDate"].Value = Convert.ToDateTime(dedToDate.Value);
                        //report.CreateDocument();
                        //ReportViewer.Report = report;
                    }
                }
            }
        }

        if (this.CompanyGrid.IsCallback)
        {
            this.LoadCompanies();
        }
    }


    protected void VersionGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');

        if (args[0] == "Reload")
        {
            s.JSProperties["cpCommand"] = args[0];
        }
    }

    protected void VersionCompanyGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');

        s.JSProperties["cpCommand"] = args[0];

        if (args[0] == "LoadVerCompany")
        {
            decimal versionID;
            if (!decimal.TryParse(args[1], out versionID))
                return;
            LoadVersionCompany(versionID);
        }

        if (args[0] == "ChangeCompany")
        {
            decimal versionID;
            if (!decimal.TryParse(args[1], out versionID))
                return;

            int companyID;
            if (!int.TryParse(args[2], out companyID))
                return;

            Session[CURRENT_COMPANY] = companyID;

            LoadVersionCompany(versionID);
        }
        
        if (args[0] == "NewVersionCompany")
        {
            decimal versionID;
            if (!decimal.TryParse(args[1], out versionID))
                return;

            entities.CreateVersionCompany(versionID, SessionUser.CompanyID, SessionUser.UserID);
            LoadVersionCompany(versionID);
        }
    }
    protected void BudgetGrid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("CALCULATION"), "SUM"))
        {
            e.Row.Font.Bold = true;
        }
    }
    
    
    private void SaveFile(string filePath, UploadedFile file)
    {
        string aDirectoryPath = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(aDirectoryPath))
        {
            Directory.CreateDirectory(aDirectoryPath);
        }
        file.SaveAs(filePath);
    }

    protected void CompanyGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "LoadCompany")
        {
            LoadCompanies();
        }

    }

    protected void VersionCompanyGrid_CustomDataCallback(object sender, ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "EditForm" && args.Length == 2)
        {
            decimal verCompanyID;
            if (!decimal.TryParse(args[1], out verCompanyID))
                return;

            var entity = entities.VersionCompanies.SingleOrDefault(x => x.VerCompanyID == verCompanyID);
            if (entity == null)
                return;

            var result = new Dictionary<string, string>();
            result["Description"] = entity.Description;
            result["ApprovedNote"] = entity.ApprovedNote;
            result["ReviewedNote"] = entity.ReviewedNote;

            e.Result = result;
        }
    }

    protected void VersionCompanyFilesGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');

        if (args[0] == "LoadVerCompanyFiles")
        {
            decimal verCompanyID;
            if (!decimal.TryParse(args[1], out verCompanyID))
                return;

            LoadVerCompanyFiles(verCompanyID);
        }

        if (args[0] == "SaveVerCompanyFile")
        {
            decimal verCompanyID;
            if (!decimal.TryParse(args[1], out verCompanyID))
                return;

            var filePath = args[2];

            FileInfo fi = new FileInfo(filePath);

            var entity = new VersionCompanyFile();
            entity.FileName = fi.Name;
            entity.FilePath = filePath;
            entity.VerCompanyID = verCompanyID;

            entity.CreateDate = DateTime.Now;
            entity.CreatedBy = (int)SessionUser.UserID;

            entities.VersionCompanyFiles.Add(entity);

            entities.SaveChanges();

            LoadVerCompanyFiles(verCompanyID);
        }
    }

    //private string CheckValidationErrors(QLKHDataEntities ett)
    //{
    //    string errors = string.Empty;
    //    var validationErrors = ett.GetValidationErrors()
    //        .Where(vr => !vr.IsValid)
    //        .SelectMany(vr => vr.ValidationErrors);

    //    foreach (var error in validationErrors)
    //    {
    //        errors += error.ErrorMessage + "\n";
    //    }

    //    return errors;
    //}

    protected void BudgetFilesGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');

        if (args[0] == "LoadBudgetFile")
        {
            decimal BudgetID;
            if (!decimal.TryParse(args[1], out BudgetID))
                return;

            LoadBudgetFiles(BudgetID);
        }

        if (args[0] == "SaveBudgetFile")
        {
            decimal BudgetID;
            if (!decimal.TryParse(args[1], out BudgetID))
                return;

            var filePath = args[2];

            FileInfo fi = new FileInfo(filePath);

            var entity = new BudgetFile();
            entity.FILE_NAME = fi.Name;
            entity.FILE_PATH= filePath;
            entity.BUDGET_ID = BudgetID;

            entity.CREATED_DATE = DateTime.Now;
            entity.CREATED_BY = SessionUser.UserName;

            entities.BudgetFiles.Add(entity);
            entities.SaveChanges();

            LoadBudgetFiles(BudgetID);
        }
    }
    
    protected void VerCompanyFilesUC_FilesUploadComplete(object sender, FilesUploadCompleteEventArgs e)
    {
        for (int i = 0; i < VerCompanyFilesUC.UploadedFiles.Length; i++)
        {
            UploadedFile file = VerCompanyFilesUC.UploadedFiles[i];

            if (file.FileName != "" && file.IsValid)
            {
                try
                {
                    string fileName = Path.Combine(fileStorage + @"VerCompanyFiles\", file.FileName);
                    if (File.Exists(fileName))
                    {
                        e.CallbackData = "error";
                        e.ErrorText = "File name already exists. Please rename before upload.";
                        return;
                    }

                    SaveFile(fileName, file);

                    e.CallbackData = fileName;
                }
                catch (Exception ex)
                {
                    e.CallbackData = "error";
                    e.ErrorText = ex.Message;
                }
            }
        }
    }

    protected void BudgetFilesUC_FilesUploadComplete(object sender, FilesUploadCompleteEventArgs e)
    {
        for (int i = 0; i < BudgetFilesUC.UploadedFiles.Length; i++)
        {
            UploadedFile file = BudgetFilesUC.UploadedFiles[i];

            if (file.FileName != "" && file.IsValid)
            {
                try
                {
                    string fileName = Path.Combine(fileStorage + @"BudgetFiles\", file.FileName);
                    if (File.Exists(fileName))
                    {
                        e.CallbackData = "error";
                        e.ErrorText = "File name already exists. Please rename before upload.";
                        return;
                    }

                    SaveFile(fileName, file);

                    e.CallbackData = fileName;
                }
                catch (Exception ex)
                {
                    e.CallbackData = "error";
                    e.ErrorText = ex.Message;
                }
            }
        }
    }
    
    protected void BudgetGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');

        if (args.Count() < 1) return;
        
        BudgetGrid.JSProperties["cpCommand"] = args[0]; 

        if (args[0] == "LoadBudget")
        {
            decimal verCompanyID = Convert.ToDecimal(args[1]);
            LoadBudget(verCompanyID);

            // Load title
            var aVerCompany = entities.VersionCompanies.Where(x => x.VerCompanyID == verCompanyID).FirstOrDefault();
            if (aVerCompany != null)
            {
                var aCompany = entities.DecCompanies.Where(x => x.CompanyID == aVerCompany.CompanyID).FirstOrDefault();
                if (aCompany != null)
                {
                    BudgetGrid.JSProperties["cpTitle"] = aCompany.NameV + " - " + aVerCompany.VersionName;
                }
            }
        }

        if (args[0] == "GetDataBudget")
        {
            decimal verCompanyID = Convert.ToDecimal(args[1]);
            var aVerCompany = entities.VersionCompanies.Where(x => x.VerCompanyID == verCompanyID).FirstOrDefault();
            if (aVerCompany != null)
            {
                if (rdoVersionType.Value.ToString().Equals("P"))
                    entities.GetBudgetDataForTZeroTOne(aVerCompany.VersionID, aVerCompany.CompanyID, SessionUser.UserName, 0, -1);
                else
                    entities.GetBudgetDataActual(verCompanyID, SessionUser.UserName, aVerCompany.CompanyID, Convert.ToInt32(VersionYearEditor.Value));

                LoadBudget(verCompanyID);
            }
        }

        if (args[0].Equals("UpdateRevCostDataAll"))
        {
            decimal verCompanyID = Convert.ToDecimal(args[1]);
            var aVerCompany = entities.VersionCompanies.Where(x => x.VerCompanyID == verCompanyID).FirstOrDefault();
            if (aVerCompany != null)
            {
                entities.UpdateRevCostDataAll(verCompanyID, aVerCompany.CompanyID, SessionUser.UserName, -1);
                LoadBudget(verCompanyID);
            }
        }

        if (args[0].Equals("UpdateRevCost1Sub"))
        {
            decimal verCompanyID = Convert.ToDecimal(args[1]);
            decimal budgetID = Convert.ToDecimal(args[2]);
            var aBudget = entities.Budgets.Where(x => x.ID == budgetID).FirstOrDefault();
            if (aBudget != null)
            {
                entities.UpdateBudgetDetail(aBudget.SUBACCOUNT_ID, budgetID, Convert.ToDecimal(VersionYearEditor.Value), aBudget.CURR, verCompanyID, 0);
                //LoadBudget(verCompanyID);
                int pos = BudgetGrid.FocusedRowIndex;
                BudgetGrid.FocusedRowIndex = 0;
                BudgetGrid.FocusedRowIndex = pos;
            }
        }

        if (args[0].Equals("GetAllFieldFor1Sub"))
        {
            decimal verCompanyID = Convert.ToDecimal(args[1]);
            decimal budgetID = Convert.ToDecimal(args[2]);
            var aBudget = entities.Budgets.Where(x => x.ID == budgetID).FirstOrDefault();
            if (aBudget != null)
            {
                entities.UpdateBudgetDetail(aBudget.SUBACCOUNT_ID, budgetID, Convert.ToDecimal(VersionYearEditor.Value), aBudget.CURR, verCompanyID, 1);
                LoadBudget(verCompanyID);
            }
        }

        if (args[0].Equals("Calculate"))
        {
            decimal verCompanyID = Convert.ToDecimal(args[1]);
            entities.BudgetCalculateToParent(verCompanyID, SessionUser.UserName);
            LoadBudget(verCompanyID);
        }


        if (args[0].Equals("UpdateNote"))
        {
            decimal BudgetID = Convert.ToDecimal(args[1]);
            var aBudget = entities.Budgets.Where(x => x.ID == BudgetID).FirstOrDefault();
            if (aBudget != null)
            {
                aBudget.NOTE = mmNote.Value == null ? string.Empty : mmNote.Value.ToString();
                aBudget.UPDATED_BY = SessionUser.UserName;
                aBudget.UPDATED_DATE = DateTime.Now;
                entities.SaveChanges();
            }
        }

        //if (args[0] == "ShowReport")
        //{
        //    decimal verCompanyID = Convert.ToDecimal(args[1]);
        //    var aVerCompany = entities.VersionCompanies.Where(x => x.VerCompanyID == verCompanyID).FirstOrDefault();
        //    if (aVerCompany != null)
        //    {
        //        var aCompany = entities.Companies.Where(x => x.CompanyID == aVerCompany.CompanyID).FirstOrDefault();
        //        var aVersion = entities.Versions.Where(x => x.VersionID == aVerCompany.VersionID).FirstOrDefault();

        //        var report = new RptPlanningBudget();
        //        report.Parameters["pVerCompanyID"].Value = verCompanyID;
        //        report.Parameters["pYear"].Value = aVersion.VersionYear;
        //        report.Parameters["pCompany"].Value = aCompany.NameV;
        //        report.Parameters["pRunTime"].Value = DateTime.Now;
        //        report.Parameters["pVersion"].Value = aVersion.VersionName;
        //        report.CreateDocument();
        //        ReportViewer.Report = report;
        //    }
        //}
    }
    
    protected void BudgetDetailGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');

        if (args[0] == "LoadBudgetDetail")
        {
            decimal budgetID = Convert.ToDecimal(args[1]);
            LoadBudgetDetail(budgetID);

            // display Note and ...
            var aBudget = entities.Budgets.Where(x => x.ID == budgetID).FirstOrDefault();
            var ret = new Dictionary<string, string>();
            if (aBudget != null)
            {
                ret["NOTE"] = aBudget.NOTE;
                ret["CREATED_BY"] = aBudget.CREATED_BY;
                ret["UPDATED_BY"] = aBudget.UPDATED_BY;
                ret["CREATED_DATE"] = aBudget.CREATED_DATE.Value.ToString("dd/MM/yyyy");
                ret["UPDATED_DATE"] = aBudget.UPDATED_DATE == null ? string.Empty : aBudget.UPDATED_DATE.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                ret["NOTE"] = null;
                ret["CREATED_BY"] = null;
                ret["UPDATED_BY"] = null;
                ret["CREATED_DATE"] = null;
                ret["UPDATED_DATE"] = null;
            }

            grid.JSProperties["cpRet"] = ret;
        }
    }

    protected void BudgetDetailGrid_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
    {

    }

    protected void BudgetDetailGrid_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
    {

    }
}