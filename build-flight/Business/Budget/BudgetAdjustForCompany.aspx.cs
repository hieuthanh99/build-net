using DevExpress.Web;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;

public partial class Business_Budget_BudgetAdjustForCompany : BasePage
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
        || action.Contains(ActionCloseFilterControl))
            return ASPxGridViewCallbackType.FilterEditing;
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
    private void LoadVersions(string versionType, int versionYear)
    {
        var list = entities.Versions.Where(x => x.VersionType == versionType && x.VersionYear == versionYear && x.Calculation.Equals("BOTTOMUP") && x.Active.Value).OrderBy(x => x.Sorting).ToList();
        this.VersionGrid.DataSource = list;
        this.VersionGrid.DataBind();
    }

    private void LoadBudgetAdjust(decimal versionID)
    {
        var list = entities.BudgetAdjusts.Where(x => x.VER_ID == versionID).OrderBy(x => x.DOC_DATE).ToList();
        this.BudgetAdjustGrid.DataSource = list;
        this.BudgetAdjustGrid.DataBind();
    }

    private void LoadBudgetAdjustFiles(decimal BudgetAdjustID)
    {
        var list = entities.BudgetAdjustFiles.Where(x => x.ADJUST_ID == BudgetAdjustID).ToList();
        this.BudgetAdjustFilesGrid.DataSource = list;
        this.BudgetAdjustFilesGrid.DataBind();
    }

    private void LoadBudgetAdjustRoe(decimal BudgetAdjustID)
    {
        var list = entities.BudgetAdjustRoes.Where(x => x.ADJUST_ID == BudgetAdjustID).ToList();
        BudgetAdjustRoeGrid.DataSource = list;
        BudgetAdjustRoeGrid.DataBind();
    }

    private void LoadBudgetAdjusTransactionHD(decimal BudgetAdjustID)
    {
        var list = entities.BudgetAdjustTransactionSummaryViews.Where(x => x.ADJUST_ID == BudgetAdjustID).ToList();
        BudgetAdjustTransactionHDGrid.DataSource = list;
        BudgetAdjustTransactionHDGrid.DataBind();
    }

    private void LoadBudgetAdjusTransaction(decimal BudgetAdjustTranHdID)
    {
        var list = entities.BudgetAdjustTransactionViews.Where(x => x.HEADER_ID == BudgetAdjustTranHdID).ToList();
        BudgetAdjustTransactionGrid.DataSource = list;
        BudgetAdjustTransactionGrid.DataBind();
    }

    private void LoadVersionCompanyOri(decimal versionID)
    {
        var lstVerCompany = entities.VersionCompanyViews.Where(x => x.VersionID == versionID && x.HotData.Value).ToList();
        VersionCompanyGrid.DataSource = lstVerCompany;
        VersionCompanyGrid.DataBind();
    }

    private void LoadBudgetOri(decimal verCompanyID)
    {
        var lstBudget = entities.Budgets.Where(x => x.VER_COMPANY_ID == verCompanyID).ToList();
        BudgetGrid.DataSource = lstBudget;
        BudgetGrid.DataBind();
    }

    private void LoadCompany(decimal budgetID)
    {
        // get budget
        var aSubaccountID = entities.Budgets.Find( budgetID).SUBACCOUNT_ID;

        // Get companys by subaccountID and version
        decimal versionID = Convert.ToDecimal(VersionGrid.GetRowValues(VersionGrid.FocusedRowIndex, VersionGrid.KeyFieldName));

        var lstCompany = from vc in entities.VersionCompanies
                         from bg in entities.Budgets
                         from cp in entities.DecCompanies
                         where vc.VerCompanyID == bg.VER_COMPANY_ID
                         where vc.VersionID == versionID
                         where bg.SUBACCOUNT_ID == aSubaccountID
                         where cp.CompanyID == vc.CompanyID
                         select new {
                             cp.CompanyID,
                            cp.ShortName,
                            cp.NameV
                         };
        
        CompanyGrid.DataSource = lstCompany.ToList();
        CompanyGrid.DataBind();
    }

    private void LoadVersionCompanyDes(decimal versionID)
    {
        var lstVerCompany = entities.VersionCompanyViews.Where(x => x.VersionID == versionID && x.HotData.Value).ToList();
        VersionCompanyDesGrid.DataSource = lstVerCompany;
        VersionCompanyDesGrid.DataBind();
    }

    private void LoadBudgetDes(decimal verCompanyID)
    {
        var lstBudget = entities.Budgets.Where(x => x.VER_COMPANY_ID == verCompanyID).ToList();
        BudgetDesGrid.DataSource = lstBudget;
        BudgetDesGrid.DataBind();
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.VersionYearEditor.Value = DateTime.Now.Year;
            Session.Remove(CURRENT_COMPANY);
            Session[CURRENT_COMPANY] = SessionUser.CompanyID;

            this.RevCostHiddenField.Set("CompanyID", SessionUser.CompanyID);
            this.RevCostHiddenField.Set("CompanyType", SessionUser.CompanyType);
        }

        if (rdoVersionType.Value != null && this.VersionYearEditor.Value != null)
        {
            string versionType = rdoVersionType.Value.ToString();
            int versionYear = Convert.ToInt32(this.VersionYearEditor.Value);
            this.LoadVersions(versionType, versionYear);

            //decimal versionID = -1;
            //if (VersionGrid.FocusedRowIndex >= 0)
            //    versionID = Convert.ToDecimal(VersionGrid.GetRowValues(VersionGrid.FocusedRowIndex, VersionGrid.KeyFieldName));
            //LoadVersionCompany(versionID);

            //double verCompanyID = -1;
            //if (VersionCompanyGrid.FocusedRowIndex >= 0)
            //    verCompanyID = Convert.ToDouble(VersionCompanyGrid.GetRowValues(VersionGrid.FocusedRowIndex, VersionCompanyGrid.KeyFieldName));
            //LoadBudget(verCompanyID);

            //double budgetID = -1;
            //if (BudgetGrid.FocusedRowIndex >= 0)
            //    budgetID = Convert.ToDouble(BudgetGrid.GetRowValues(VersionGrid.FocusedRowIndex, BudgetGrid.KeyFieldName));
            //LoadCompany(budgetID);

        }
        

        //if (!IsPostBack || this.VersionGrid.IsCallback)
        //{
        //    if (!IsPostBack)
        //        this.VersionYearEditor.Value = DateTime.Now.Year;

        //    if (rdoVersionType.Value != null && this.VersionYearEditor.Value != null)
        //    {
        //        string versionType = rdoVersionType.Value.ToString();
        //        int versionYear = Convert.ToInt32(this.VersionYearEditor.Value);
        //        this.LoadVersions(versionType, versionYear);
        //    }
        //}

        if (!IsPostBack || this.BudgetAdjustGrid.IsCallback)
        {
            if (this.BudgetAdjustGrid.IsCallback)
            {
                if (this.GetGridCallbackType() != ASPxGridViewCallbackType.Custom)
                {
                    if (this.RevCostHiddenField.Contains("VersionID"))
                    {
                        var verCompanyID = Convert.ToDecimal(RevCostHiddenField.Get("VersionID"));
                        this.LoadBudgetAdjust(verCompanyID);
                    }
                }
            }
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

    private void SaveFile(string filePath, UploadedFile file)
    {
        string aDirectoryPath = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(aDirectoryPath))
        {
            Directory.CreateDirectory(aDirectoryPath);
        }
        file.SaveAs(filePath);
    }

    protected void BudgetAdjustFilesGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');

        if (args[0] == "LoadBudgetAdjustFile")
        {
            decimal BudgetAdjustID;
            if (!decimal.TryParse(args[1], out BudgetAdjustID))
                return;

            LoadBudgetAdjustFiles(BudgetAdjustID);
        }

        if (args[0] == "SaveBudgetAdjustFile")
        {
            decimal BudgetAdjustID;
            if (!decimal.TryParse(args[1], out BudgetAdjustID))
                return;

            var filePath = args[2];

            FileInfo fi = new FileInfo(filePath);

            var entity = new BudgetAdjustFile();
            entity.FILE_NAME = fi.Name;
            entity.FILE_PATH = filePath;
            entity.ADJUST_ID = BudgetAdjustID;

            entity.CREATED_DATE = DateTime.Now;
            entity.CREATED_BY = SessionUser.UserName;

            entities.BudgetAdjustFiles.Add(entity);
            entities.SaveChanges();

            LoadBudgetAdjustFiles(BudgetAdjustID);
        }
    }

    protected void BudgetAdjustFilesUC_FilesUploadComplete(object sender, FilesUploadCompleteEventArgs e)
    {
        for (int i = 0; i < BudgetAdjustFilesUC.UploadedFiles.Length; i++)
        {
            UploadedFile file = BudgetAdjustFilesUC.UploadedFiles[i];

            if (file.FileName != "" && file.IsValid)
            {
                try
                {
                    string fileName = Path.Combine(fileStorage + @"BudgetAdjustFiles\", file.FileName);
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

    protected void BudgetAdjustGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        ASPxGridView s = sender as ASPxGridView;

        if (args.Count() < 1) return;

        if (args[0] == "LoadBudgetAdjust")
        {
            decimal aVersionID = Convert.ToDecimal(args[1]);
            LoadBudgetAdjust(aVersionID);
            s.JSProperties["cpCommand"] = args[0];
        }
    }

    protected void BudgetAdjustGrid_RowInserting(object sender, ASPxDataInsertingEventArgs e)
    {
        try
        {
            if (VersionGrid.FocusedRowIndex >= 0)
            {
                var aBudgetAdjust = new BudgetAdjust();
                decimal versionID = Convert.ToDecimal(VersionGrid.GetRowValues(VersionGrid.FocusedRowIndex, VersionGrid.KeyFieldName));
                aBudgetAdjust.VER_ID = versionID;
                aBudgetAdjust.DOC_NUMBER = e.NewValues["DOC_NUMBER"] == null ? string.Empty : e.NewValues["DOC_NUMBER"].ToString();
                aBudgetAdjust.DOC_DATE = e.NewValues["DOC_DATE"] == null ? DateTime.MinValue : Convert.ToDateTime(e.NewValues["DOC_DATE"]);
                aBudgetAdjust.APPROVED_BY = e.NewValues["APPROVED_BY"] == null ? string.Empty : e.NewValues["APPROVED_BY"].ToString();
                aBudgetAdjust.DOC_MONTH = e.NewValues["DOC_MONTH"] == null ? 1 : Convert.ToDouble(e.NewValues["DOC_MONTH"]);
                aBudgetAdjust.ADJUST_TYPE = e.NewValues["ADJUST_TYPE"] == null ? string.Empty : e.NewValues["ADJUST_TYPE"].ToString();
                aBudgetAdjust.STATUS = e.NewValues["STATUS"] == null ? "00" : e.NewValues["STATUS"].ToString();
                aBudgetAdjust.NOTES = e.NewValues["NOTES"] == null ? string.Empty : e.NewValues["NOTES"].ToString();
                aBudgetAdjust.CREATED_DATE = DateTime.Now;
                aBudgetAdjust.CREATED_BY = SessionUser.UserName;

                entities.BudgetAdjusts.Add(aBudgetAdjust);
                entities.SaveChanges();

                // Load Budget Adjust
                LoadBudgetAdjust(versionID);
            }
            BudgetAdjustGrid.CancelEdit();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            e.Cancel = true;
        }
    }

    protected void BudgetAdjustGrid_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
    {
        try
        {
            var aBudgetAdjust = entities.BudgetAdjusts.Find(Convert.ToDecimal(e.Keys[0]));
            if (aBudgetAdjust != null)
            {
                aBudgetAdjust.DOC_NUMBER = e.NewValues["DOC_NUMBER"] == null ? string.Empty : e.NewValues["DOC_NUMBER"].ToString();
                aBudgetAdjust.DOC_DATE = e.NewValues["DOC_DATE"] == null ? DateTime.MinValue : Convert.ToDateTime(e.NewValues["DOC_DATE"]);
                aBudgetAdjust.APPROVED_BY = e.NewValues["APPROVED_BY"] == null ? string.Empty : e.NewValues["APPROVED_BY"].ToString();
                aBudgetAdjust.DOC_MONTH = e.NewValues["DOC_MONTH"] == null ? 0 : Convert.ToDouble(e.NewValues["DOC_MONTH"]);
                aBudgetAdjust.ADJUST_TYPE = e.NewValues["ADJUST_TYPE"] == null ? string.Empty : e.NewValues["ADJUST_TYPE"].ToString();
                aBudgetAdjust.STATUS = e.NewValues["STATUS"] == null ? "00" : e.NewValues["STATUS"].ToString();
                aBudgetAdjust.NOTES = e.NewValues["NOTES"] == null ? string.Empty : e.NewValues["NOTES"].ToString();
                aBudgetAdjust.UPDATED_DATE = DateTime.Now;
                aBudgetAdjust.UPDATED_BY = SessionUser.UserName;
                entities.SaveChanges();
                BudgetAdjustGrid.CancelEdit();

                // Load Budget Adjust
                LoadBudgetAdjust(aBudgetAdjust.VER_ID);

                // reset FocusedRowIndex
                int index = BudgetAdjustGrid.FocusedRowIndex;
                BudgetAdjustGrid.FocusedRowIndex = -1;
                BudgetAdjustGrid.FocusedRowIndex = index;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            e.Cancel = true;
        }
    }

    protected void BudgetAdjustGrid_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
    {
        try
        {
            var aBudgetAdjust = entities.BudgetAdjusts.Find(Convert.ToDecimal(e.Keys[0]));
            if (aBudgetAdjust != null)
            {
                if (aBudgetAdjust.STATUS.Equals("00"))
                {
                    entities.BudgetAdjusts.Remove(aBudgetAdjust);
                    entities.SaveChanges();

                    decimal versionID = Convert.ToDecimal(VersionGrid.GetRowValues(VersionGrid.FocusedRowIndex, VersionGrid.KeyFieldName));
                    // Load Budget Adjust
                    LoadBudgetAdjust(aBudgetAdjust.VER_ID);
                }
                //else
                //    Response.Write("<script type='text/javascript'>alert('Record is posted, can not delete');</script>");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            e.Cancel = true;
        }
    }

    protected void BudgetAdjustGrid_CustomUnboundColumnData(object sender, ASPxGridViewColumnDataEventArgs e)
    {
        if (e.Column.FieldName.Equals("NO"))
            e.Value = string.Format("{0}", e.ListSourceRowIndex + 1);
    }

    protected void BudgetAdjustTransactionHDGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args.Count() <= 0) return;
         
        if (args[0] == "NewTransactionHD")
        {
            decimal adjustID, verCompanyID, budgetID, headerID;

            if (!decimal.TryParse(args[1], out adjustID))
                return;
            if (!decimal.TryParse(args[2], out verCompanyID))
                return;
            if (!decimal.TryParse(args[3], out budgetID))
                return;

            // Get version company
            var aVersionCompany = entities.VersionCompanies.Find(verCompanyID);
            // Get budget
            var aBudget = entities.Budgets.Find(budgetID);

            // Insert Transaction HD
            ObjectParameter prHeaderID = new ObjectParameter("pHeaderID", typeof(decimal));
            entities.BudgetAdjustTranHd(adjustID, budgetID, aBudget.DESCRIPTION, aVersionCompany.VersionID, aBudget.SUBACCOUNT_ID, aVersionCompany.CompanyID,
                aBudget.CURR, SessionUser.UserName, aBudget.SORTING, prHeaderID);
            headerID = Convert.ToDecimal(prHeaderID.Value);

            // Get adjust
            var aAdjust = entities.BudgetAdjusts.Find(adjustID);

            // Get Company checked
            bool chk = false;
            foreach (var item in CompanyGrid.GetSelectedFieldValues(new string[] { "CompanyID" }))
            {
                chk = true;
                // get vercompanyid by company checked
                decimal versionID = Convert.ToDecimal(VersionGrid.GetRowValues(VersionGrid.FocusedRowIndex, VersionGrid.KeyFieldName));
                decimal desCompany = Convert.ToDecimal(item);

                var desVerCompany = (from vc in entities.VersionCompanies
                                     from bg in entities.Budgets
                                     where vc.VerCompanyID == bg.VER_COMPANY_ID.Value
                                     where vc.VersionID == versionID
                                     where bg.SUBACCOUNT_ID == aBudget.SUBACCOUNT_ID
                                     where vc.CompanyID == desCompany
                                     select vc).FirstOrDefault();

                // get bugget des
                var desBudget = entities.Budgets.Where(x => x.VER_COMPANY_ID == desVerCompany.VerCompanyID && x.SUBACCOUNT_ID == aBudget.SUBACCOUNT_ID).FirstOrDefault();
                if (desBudget != null)
                {
                    entities.BudgetAdjustTran(headerID, aVersionCompany.VersionID, aBudget.SUBACCOUNT_ID, aBudget.DESCRIPTION, desCompany, desBudget.CURR,
                    SessionUser.UserName, aBudget.SORTING, desBudget.ID);

                    entities.BudgetAdjustRoePrc(aAdjust.VER_ID, adjustID, desBudget.CURR, aBudget.CURR, SessionUser.UserName);
                }
            }
            if (chk)
            {
                LoadBudgetAdjustRoe(adjustID);
                LoadBudgetAdjusTransactionHD(adjustID);
                LoadBudgetAdjusTransaction(headerID);
            }
        }
        else if (args[0].Equals("LoadTransactionHD"))
        {
            ASPxGridView s = sender as ASPxGridView;
            decimal adjustID;
            if (!decimal.TryParse(args[1], out adjustID))
                return;

            LoadBudgetAdjusTransactionHD(adjustID);
            s.JSProperties["cpCommand"] = args[0];
            
            ASPxButton btnSelectionCompany = s.FindStatusBarTemplateControl("btnSelectCompany") as ASPxButton;
            if (adjustID > 0)
            {
                var aBudgetAdjust = entities.BudgetAdjusts.Find(adjustID);
                if (aBudgetAdjust.STATUS.Equals("00"))
                    btnSelectionCompany.Enabled = true;
                else
                    btnSelectionCompany.Enabled = false;
            }
            else
                btnSelectionCompany.Enabled = false;
        }
    }

    protected void BudgetAdjustTransactionHDGrid_CustomUnboundColumnData(object sender, ASPxGridViewColumnDataEventArgs e)
    {
        if (e.Column.FieldName.Equals("NO"))
            e.Value = string.Format("{0}", e.ListSourceRowIndex + 1);
    }
    
    protected void BudgetAdjustTransactionGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args.Count() <= 0) return;

        if (args[0] == "NewTransaction")
        {
            decimal adjustID, verCompanyID, headerID;

            if (!decimal.TryParse(args[1], out adjustID))
                return;
            if (!decimal.TryParse(args[2], out verCompanyID))
                return;
            if (!decimal.TryParse(args[3], out headerID))
                return;

            // Get adjust
            var aAdjust = entities.BudgetAdjusts.Find(adjustID);
            // Get version company
            var aVersionCompany = entities.VersionCompanies.Find(verCompanyID);
            // get transaction hd
            var aTranHD = entities.BudgetAdjustTransactionHds.Find(headerID);

            // Get Company checked
            bool chk = false;
            foreach (var item in BudgetDesGrid.GetSelectedFieldValues(new string[] { "ID" }))
            {
                chk = true;
                decimal desBudgetID = Convert.ToDecimal(item);
                var desBudget = entities.Budgets.Find(desBudgetID);

                entities.BudgetAdjustTran(headerID, aVersionCompany.VersionID, desBudget.SUBACCOUNT_ID, desBudget.DESCRIPTION, aVersionCompany.CompanyID, desBudget.CURR,
                SessionUser.UserName, desBudget.SORTING, desBudget.ID);

                entities.BudgetAdjustRoePrc(aAdjust.VER_ID, adjustID, desBudget.CURR, aTranHD.CURR, SessionUser.UserName);
            }

            if (chk)
            {
                LoadBudgetAdjustRoe(adjustID);
                LoadBudgetAdjusTransaction(headerID);
            }
        }
        else if (args[0].Equals("LoadTransaction"))
        {
            decimal transactionHdID;
            if (!decimal.TryParse(args[1], out transactionHdID))
                return;

            LoadBudgetAdjusTransaction(transactionHdID);

            if (transactionHdID > 0)
            {
                ASPxGridView s = sender as ASPxGridView;
                var aTransactionHD = entities.BudgetAdjustTransactionHds.Find(transactionHdID);
                var aBudgetAdjust = entities.BudgetAdjusts.Find(aTransactionHD.ADJUST_ID);
                if (aBudgetAdjust.STATUS.Equals("00"))
                    s.Columns[9].Visible = true;
                else
                    s.Columns[9].Visible = false;
            }
        }
    }

    protected void BudgetAdjustTransactionGrid_CustomUnboundColumnData(object sender, ASPxGridViewColumnDataEventArgs e)
    {
        if (e.Column.FieldName.Equals("NO"))
            e.Value = string.Format("{0}", e.ListSourceRowIndex + 1);
    }
    

    protected void BudgetAdjustRoeGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args.Count() < 1) return;

        if (args[0] == "LoadBudgetAdjustRoe")
        {
            decimal aBudgetAdjustID = Convert.ToDecimal(args[1]);
            LoadBudgetAdjustRoe(aBudgetAdjustID);

            ASPxGridView s = sender as ASPxGridView;
            ASPxButton btnSelectionSubaccount = s.FindStatusBarTemplateControl("btnSelectSubAccount") as ASPxButton;
            if (aBudgetAdjustID > 0)
            {
                var aBudgetAdjust = entities.BudgetAdjusts.Find(aBudgetAdjustID);
                if (aBudgetAdjust.STATUS.Equals("00"))
                {
                    s.Columns[2].Visible = true;
                    btnSelectionSubaccount.Enabled = true;
                    s.JSProperties["cpActive"] = "Y";
                }
                else
                {
                    s.Columns[2].Visible = false;
                    btnSelectionSubaccount.Enabled = false;
                    s.JSProperties["cpActive"] = "N";
                }
            }
            else
            {
                s.Columns[2].Visible = false;
                btnSelectionSubaccount.Enabled = false;
                s.JSProperties["cpActive"] = "N";
            }
        }
    }

    protected void BudgetAdjustRoeGrid_RowInserting(object sender, ASPxDataInsertingEventArgs e)
    {
        try
        {
            if (BudgetAdjustGrid.FocusedRowIndex >= 0)
            {
                var aBudgetAdjustRoe = new BudgetAdjustRoe();
                decimal aBudgetAdjustID = Convert.ToDecimal(BudgetAdjustGrid.GetRowValues(BudgetAdjustGrid.FocusedRowIndex, BudgetAdjustGrid.KeyFieldName));
                aBudgetAdjustRoe.ADJUST_ID = aBudgetAdjustID;
                aBudgetAdjustRoe.CURR = e.NewValues["CURR"] == null ? string.Empty : e.NewValues["CURR"].ToString();
                aBudgetAdjustRoe.ROE = e.NewValues["ROE"] == null ? 0 : Convert.ToDouble(e.NewValues["ROE"]);
                aBudgetAdjustRoe.CREATED_BY = SessionUser.UserName;
                aBudgetAdjustRoe.CREATED_DATE = DateTime.Now;
                entities.BudgetAdjustRoes.Add(aBudgetAdjustRoe);
                entities.SaveChanges();

                // Load budget adjust roe
                LoadBudgetAdjustRoe(aBudgetAdjustID);
            }
            BudgetAdjustRoeGrid.CancelEdit();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            e.Cancel = true;
        }
    }

    protected void BudgetAdjustRoeGrid_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
    {
        try
        {
            if (BudgetAdjustGrid.FocusedRowIndex >= 0)
            {
                var aBudgetAdjustRoe = entities.BudgetAdjustRoes.Find(Convert.ToDecimal(e.Keys[0]));
                aBudgetAdjustRoe.CURR = e.NewValues["CURR"] == null ? string.Empty : e.NewValues["CURR"].ToString();
                aBudgetAdjustRoe.ROE = e.NewValues["ROE"] == null ? 0 : Convert.ToDouble(e.NewValues["ROE"]);
                aBudgetAdjustRoe.UPDATED_BY = SessionUser.UserName;
                aBudgetAdjustRoe.UPDATED_DATE = DateTime.Now;
                entities.SaveChanges();

                // Load budget adjust roe
                LoadBudgetAdjustRoe(aBudgetAdjustRoe.ADJUST_ID);
            }
            BudgetAdjustRoeGrid.CancelEdit();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            e.Cancel = true;
        }
    }

    protected void BudgetAdjustRoeGrid_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
    {
        try
        {
            var aBudgetAdjustRoe = entities.BudgetAdjustRoes.Find(Convert.ToDecimal(e.Keys[0]));
            if (aBudgetAdjustRoe != null)
            {
                entities.BudgetAdjustRoes.Remove(aBudgetAdjustRoe);
                entities.SaveChanges();

                // Load budget adjust roe
                LoadBudgetAdjustRoe(aBudgetAdjustRoe.ADJUST_ID);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            e.Cancel = true;
        }
    }

    protected void VesionCompanyGrid_CustomUnboundColumnData(object sender, ASPxGridViewColumnDataEventArgs e)
    {
        if (e.Column.FieldName.Equals("NO"))
            e.Value = string.Format("{0}", e.ListSourceRowIndex + 1);
    }

    protected void CompanyGrid_CustomUnboundColumnData(object sender, ASPxGridViewColumnDataEventArgs e)
    {
        if (e.Column.FieldName.Equals("NO"))
            e.Value = string.Format("{0}", e.ListSourceRowIndex + 1);
    }

    protected void BudgetGrid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("CALCULATION"), "SUM"))
            e.Row.Font.Bold = true;
    }

    protected void VersionCompanyGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        ASPxGridView s = sender as ASPxGridView;
        if (args.Count() <= 0) return;

        if (args[0].Equals("LoadVerCompany"))
        {
            decimal versionID;
            if (!decimal.TryParse(args[1], out versionID))
                return;

            LoadVersionCompanyOri(versionID);
            s.JSProperties["cpCommand"] = args[0];
        }
    }

    protected void BudgetGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        ASPxGridView s = sender as ASPxGridView;
        if (args.Count() <= 0) return;

        if (args[0].Equals("LoadBudget"))
        {
            decimal verCompanyID;
            if (!decimal.TryParse(args[1], out verCompanyID))
                return;

            LoadBudgetOri(verCompanyID);
            s.JSProperties["cpCommand"] = args[0];
        }
    }

    protected void CompanyGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args.Count() <= 0) return;

        if (args[0].Equals("LoadCompany"))
        {
            decimal budgetID;
            if (!decimal.TryParse(args[1], out budgetID))
                return;

            LoadCompany(budgetID);
        }
    }

    protected void VersionCompanyDesGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        ASPxGridView s = sender as ASPxGridView;
        if (args.Count() <= 0) return;

        if (args[0].Equals("LoadVerCompany"))
        {
            decimal versionID;
            if (!decimal.TryParse(args[1], out versionID))
                return;

            LoadVersionCompanyDes(versionID);
            s.JSProperties["cpCommand"] = args[0];
        }
    }

    protected void BudgetDesGrid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("CALCULATION"), "SUM"))
            e.Row.Font.Bold = true;
    }

    protected void BudgetDesGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args.Count() <= 0) return;

        if (args[0].Equals("LoadBudget"))
        {
            decimal verCompanyID;
            if (!decimal.TryParse(args[1], out verCompanyID))
                return;

            LoadBudgetDes(verCompanyID);
        }
    }

    protected void BudgetAdjustTransactionGrid_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
    {
        try
        {
            if (BudgetAdjustTransactionGrid.FocusedRowIndex >= 0)
            {
                var aBudgetAdjustTransaction = entities.BudgetAdjustTransactions.Find(Convert.ToDecimal(e.Keys[0]));
                var aBudgetAdjustTransactionHD = entities.BudgetAdjustTransactionHds.Find(aBudgetAdjustTransaction.HEADER_ID);

                // Get Roe
                var aRoe = entities.BudgetAdjustRoes.Where(x => x.ADJUST_ID == aBudgetAdjustTransactionHD.ADJUST_ID && x.CURR == aBudgetAdjustTransactionHD.CURR).FirstOrDefault();
                double iRoe = 0;
                if (aRoe != null)
                    iRoe = aRoe.ROE;

                aBudgetAdjustTransaction.CREDIT_AMOUNT = e.NewValues["CREDIT_AMOUNT"] == null ? 0 : Convert.ToDouble(e.NewValues["CREDIT_AMOUNT"]);
                aBudgetAdjustTransaction.DEBIT_AMOUNT = aBudgetAdjustTransaction.CREDIT_AMOUNT * iRoe;
                aBudgetAdjustTransaction.REMARKS = e.NewValues["REMARKS"] == null ? string.Empty : e.NewValues["REMARKS"].ToString().Trim();
                aBudgetAdjustTransaction.UPDATED_BY = SessionUser.UserName;
                aBudgetAdjustTransaction.UPDATED_DATE = DateTime.Now;
                entities.SaveChanges();

                // Load budget adjust transaction
                LoadBudgetAdjusTransaction(aBudgetAdjustTransaction.HEADER_ID);
            }
            BudgetAdjustTransactionGrid.CancelEdit();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            e.Cancel = true;
        }
    }

    //protected void PermissionCallback_Callback(object source, CallbackEventArgs e)
    //{
    //    var args = e.Parameter.Split('|');
    //    if (args.Count() <= 1) return;

    //    if (args[0].Equals("SetPermission"))
    //    {
    //        decimal budgetAdjustID;
    //        if (!decimal.TryParse(args[1], out budgetAdjustID))
    //            return;

    //        var aBudgetAdjust = entities.BudgetAdjusts.Find(budgetAdjustID);
    //        if (aBudgetAdjust.STATUS.Equals("00"))
    //            e.Result = "N";
    //        else
    //            e.Result = "Y";
    //    }
        
    //}
}