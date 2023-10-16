using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;

public partial class Business_RevenueCost_RevenueCostForCompany : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    string fileStorage = ConfigurationManager.AppSettings["FileStorage"];

    const string CURRENT_COMPANY = "618202CB-2F41-4A51-ABB7-254E91B9EB34";
    const string COLOR_SETTINGS = "B5A44DEC-302D-4D44-8944-55737F3C1580";
    const string REVIEW_STATUS = "D5EFA597-BA3F-41A5-9F0C-29258A06D4C8";
    const string APPROVE_STATUS = "AEF958DA-3D6B-4232-9CBB-3A71958550A9";

    private string StoreStatus;
    private string VerCompanyStatus;
    private string VersionStatus;
    private bool aOutAllowUpdate = false;
    private bool aDecAllowUpdate = false;

    private string versionType;
    private int versionYear;

    #region Declare Enum
    enum AllocateType
    {
        Q1 = 1,
        Q2 = 2,
        Q3 = 3,
        Q4 = 4,
        Y = 5
    };
    enum AmountType
    {
        FinalAmount = 1,
        Adjust = 2,
        Saving = 3
    };
    enum AllocateColumn
    {
        Instandard = 1,
        Outstandard = 2,
        Decentralization = 3,
        InAdjust = 4,
        OutAdjust = 5,
        DecAdjust = 6,
        InSaving = 7,
        OutSaving = 8,
        DecSaving = 9
    };

    #endregion

    #region Show/Hide Button
    private void ShowHideButton()
    {
        ASPxButton btnNewVersion = (ASPxButton)this.VersionGrid.FindTitleTemplateControl("btnNewVersion");
        ASPxButton btnChangeCompany = (ASPxButton)this.VersionCompanyGrid.FindStatusBarTemplateControl("btnChangeCompany");
        ASPxButton btnNewVersionCompany = (ASPxButton)this.VersionCompanyGrid.FindTitleTemplateControl("btnNewVersionCompany");
        bool visible = SessionUser.CompanyType == "K";
        if (btnNewVersion != null)
            btnNewVersion.ClientVisible = visible;
        //if (btnChangeCompany != null)
        //    btnChangeCompany.ClientVisible = visible;
        if (btnNewVersionCompany != null)
            btnNewVersionCompany.ClientVisible = visible;

        btnPost.ClientEnabled = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Post");
        btnUnpost.ClientEnabled = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Unpost");
        btnComApprove.ClientEnabled = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.ComApprove");
        btnComUnapprove.ClientEnabled = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.ComUnapprove");
    }
    #endregion

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

    private void ShowHideColumnTreeList(ASPxTreeList grid, string bandName, bool visibled)
    {
        TreeListColumn c = grid.Columns[bandName] as TreeListColumn;
        c.Visible = visibled;
    }
    private string GetVersionName(decimal? versionId)
    {
        if (!versionId.HasValue) return "";
        var versionName = entities.Versions.Where(x => x.VersionID == versionId)
            .Select(x => x.VersionName)
           .FirstOrDefault();

        return versionName;
    }

    private void SetVersionBaseColumnName(decimal versionId)
    {
        var version = entities.Versions.Where(x => x.VersionID == versionId)
            .FirstOrDefault();
        if (version != null)
        {
            ShowHideColumnTreeList(this.StoresGrid, "Percentage01", version.VerIDBase.HasValue);
            ShowHideColumnTreeList(this.StoresGrid, "Percentage02", version.VerIDBase1.HasValue);
            ShowHideColumnTreeList(this.StoresGrid, "Percentage03", version.VerIDBase2.HasValue);
            ShowHideColumnTreeList(this.StoresGrid, "Percentage04", version.VerIDBase3.HasValue);
            ShowHideColumnTreeList(this.StoresGrid, "Percentage05", version.VerIDBase4.HasValue);

            if (version.VerIDBase.HasValue)
                StoresGrid.Columns["Percentage01"].Caption = "% " + version.VersionName + " / " + GetVersionName(version.VerIDBase);

            if (version.VerIDBase1.HasValue)
                StoresGrid.Columns["Percentage02"].Caption = "% " + version.VersionName + " / " + GetVersionName(version.VerIDBase1);

            if (version.VerIDBase2.HasValue)
                StoresGrid.Columns["Percentage03"].Caption = "% " + version.VersionName + " / " + GetVersionName(version.VerIDBase2);

            if (version.VerIDBase3.HasValue)
                StoresGrid.Columns["Percentage04"].Caption = "% " + version.VersionName + " / " + GetVersionName(version.VerIDBase3);

            if (version.VerIDBase4.HasValue)
                StoresGrid.Columns["Percentage05"].Caption = "% " + version.VersionName + " / " + GetVersionName(version.VerIDBase4);

        }
    }

    private void ShowHideColumnStore()
    {

        //ShowHideColumnTreeList(this.StoresGrid, "OutStandards", ShowToColumn("FA"));
        //ShowHideColumnTreeList(this.StoresGrid, "OutAdjust", ShowToColumn("AD"));
        //ShowHideColumnTreeList(this.StoresGrid, "OutSaving", ShowToColumn("SA"));
        //ShowHideColumnTreeList(this.StoresGrid, "OutAfterSaving", ShowToColumn("AS"));

    }

    private void ShowHideColumnStoreDetail()
    {
        //ShowHideColumnInBand(this.StoreDetailsGrid, "OrginalAmount", ShowToColumn("FA"));
        //ShowHideColumnInBand(this.StoreDetailsGrid, "AdjustAmount", ShowToColumn("AD"));
        //ShowHideColumnInBand(this.StoreDetailsGrid, "SavingAmount", ShowToColumn("SA"));
        //ShowHideColumnInBand(this.StoreDetailsGrid, "AfterSavingAmount", ShowToColumn("AS"));
    }

    //protected bool ShowToColumn(string type)
    //{
    //    return rdoAmountType.Value != null && rdoAmountType.Value == type;
    //}
    #endregion
    #region Load data

    private void LoadTableValues(ASPxTreeList Grid, string Column, string Table, string Field)
    {
        TreeListComboBoxColumn aCombo = (TreeListComboBoxColumn)Grid.Columns[Column];
        if (Field == "REVIEW_STATUS")
            aCombo.PropertiesComboBox.DataSource = GetTableValues(Table, Field, REVIEW_STATUS);
        else if (Field == "APPROVE_STATUS")
            aCombo.PropertiesComboBox.DataSource = GetTableValues(Table, Field, APPROVE_STATUS);

        aCombo.PropertiesComboBox.ValueField = "DefValue";
        aCombo.PropertiesComboBox.TextField = "Description";
    }

    private object GetTableValues(string Table, string Field, string SesionName)
    {
        if (Session[SesionName] != null)
        {
            var list = Session[SesionName];
            return list;
        }
        else
        {
            var list = entities.DecTableValues
            .Where(x => x.Tables == Table && x.Field == Field)
            .Select(x => new { DefValue = x.DefValue, Description = x.Description })
            .ToList();

            Session[SesionName] = list;

            return list;
        }
    }

    private void LoadCompanies()
    {
        var currentCompanyID = SessionUser.CompanyID;
        if (Session[CURRENT_COMPANY] != null)
            currentCompanyID = (int?)Session[CURRENT_COMPANY];

        string areaCode = string.Empty;
        var curCompany = entities.DecCompanies.SingleOrDefault(x => x.CompanyID == currentCompanyID);
        if (curCompany != null)
            areaCode = curCompany.AreaCode;

        List<int> companies = new List<int>();
        using (APPData.QLKHAppEntities app = new APPData.QLKHAppEntities())
        {
            companies = app.UserCompanies.Where(x => x.UserID == SessionUser.UserID).Select(x => x.CompanyID).ToList();
        }
        //&& x.AreaCode == areaCode
        var list = entities.DecCompanies.Where(x => x.CompanyID != currentCompanyID && x.CompanyType == "D" && companies.Contains(x.CompanyID)).OrderByDescending(x => x.AreaCode).ThenBy(x => x.Seq).ToList();
        this.CompanyGrid.DataSource = list;

        //var list = entities.Companies.Where(x => x.CompanyID != currentCompanyID && x.CompanyType == "D").OrderBy(x => x.Seq).ToList();
        //this.CompanyGrid.DataSource = list;
        this.CompanyGrid.DataBind();
    }

    private void LoadVersions(string versionType, int versionYear)
    {
        var list = entities.Versions.Where(x => x.VersionType == versionType && x.VersionYear == versionYear && x.Active == true).OrderByDescending(x => x.VersionYear).OrderBy(x => x.Sorting).ToList();
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

    private void LoadStores(decimal verCompanyID)
    {
        var query = from st in entities.Stores.Where(x => x.VerCompanyID == verCompanyID)
                    join sc in entities.DecSubaccounts on st.SubaccountID equals sc.SubaccountID into scg
                    from sc in scg.DefaultIfEmpty()
                    select new
                    {
                        st.StoreID,
                        st.ParentStoreID,
                        st.AccountGroup,
                        st.Description,
                        st.Calculation,
                        st.Sorting,
                        st.Seq,
                        st.IsOK,
                        st.OutStandards,
                        st.Decentralization,
                        st.Amount,
                        st.AmountVND,
                        st.Percentage01,
                        st.Percentage02,
                        st.Percentage03,
                        st.Percentage04,
                        st.Percentage05,
                        st.ReviewStatus,
                        st.ApproveStatus,
                        st.Status,
                        st.ReviewedNote,
                        st.ApprovedNote,
                        sc.IsCommercial,
                        sc.OutAllowUpdate,
                        sc.DecAllowUpdate
                    };

        if (cboReviewStatus.Value != null)
        {
            var aReviewStatus = cboReviewStatus.Value.ToString();
            if (!string.IsNullOrEmpty(aReviewStatus))
                query = query.Where(x => x.ReviewStatus == aReviewStatus);
        }
        var list = query.OrderByDescending(x => x.AccountGroup)
           .ThenBy(x => x.Seq).ToList();
        this.StoresGrid.DataSource = list;
        this.StoresGrid.DataBind();

    }

    private void LoadStoreDetails(decimal storeID)
    {
        var list = entities.StoreDetails.Where(x => x.StoreID == storeID).OrderBy(x => x.Seq).ToList();
        this.StoreDetailsGrid.DataSource = list;
        this.StoreDetailsGrid.DataBind();
    }

    private void LoadStoreFiles(decimal storeID)
    {
        var list = entities.StoreFiles.Where(x => x.StoreID == storeID).ToList();
        this.StoreFilesGrid.DataSource = list;
        this.StoreFilesGrid.DataBind();
    }

    private void LoadVerCompanyFiles(decimal verCompanyID)
    {
        var list = entities.VersionCompanyFiles.Where(x => x.VerCompanyID == verCompanyID).ToList();
        this.VersionCompanyFilesGrid.DataSource = list;
        this.VersionCompanyFilesGrid.DataBind();
    }

    private void LoadCopyVersions()
    {
        var list = entities.Versions.Where(x => x.Active == true).OrderByDescending(x => x.VersionYear).OrderBy(x => x.Sorting).ToList();
        this.VersionCopyGrid.DataSource = list;
        this.VersionCopyGrid.DataBind();
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        this.ShowHideButton();
        this.LoadTableValues(StoresGrid, "ReviewStatus", "STORE", "REVIEW_STATUS");
        this.LoadTableValues(StoresGrid, "ApproveStatus", "STORE", "APPROVE_STATUS");
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
                this.versionType = rdoVersionType.Value.ToString();
                this.versionYear = Convert.ToInt32(this.VersionYearEditor.Value);
                this.LoadVersions(this.versionType, this.versionYear);
            }
        }

        if (!IsPostBack || this.StoresGrid.IsCallback)
        {
            this.ShowHideColumnStore();
            if (this.StoresGrid.IsCallback)
            {
                if (this.GetGridCallbackType() != ASPxGridViewCallbackType.Custom)
                {
                    if (this.RevCostHiddenField.Contains("VerCompanyID"))
                    {
                        var verCompanyID = Convert.ToDecimal(RevCostHiddenField.Get("VerCompanyID"));
                        if (this.RevCostHiddenField.Contains("VersionID"))
                        {
                            var verID = Convert.ToDecimal(RevCostHiddenField.Get("VersionID"));
                            this.SetVersionBaseColumnName(verID);
                        }
                        this.LoadStores(verCompanyID);

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

        if (!IsPostBack || this.StoreDetailsGrid.IsCallback)
            this.ShowHideColumnStoreDetail();

        if (this.VersionCopyGrid.IsCallback)
            this.LoadCopyVersions();

        if (this.CompanyGrid.IsCallback) //!IsPostBack || 
        {
            this.LoadCompanies();
        }

        SetActionRights();

    }

    private void SetActionRights()
    {
        try
        {
            btnCalculateStore.Visible = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.CalculateStore");
            btnAutoItem.Visible = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.AutoItem");
            btnAutoAllItem.Visible = btnAutoItem.Visible;// IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.AutoItem");
            btnPost.Visible = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Post");
            btnUnpost.Visible = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Unpost");
            btnComApprove.Visible = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.ComApprove");
            btnComUnapprove.Visible = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.ComUnapprove");

            this.StoresGrid.SettingsDataSecurity.AllowInsert = false;
            this.StoresGrid.SettingsDataSecurity.AllowEdit = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Edit");
            this.StoresGrid.SettingsDataSecurity.AllowDelete = false;
            btnSaveChangesStore.Visible = this.StoresGrid.SettingsDataSecurity.AllowEdit;

            this.StoreDetailsGrid.SettingsDataSecurity.AllowEdit = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Edit");
            this.StoreDetailsGrid.SettingsDataSecurity.AllowInsert = false;
            this.StoreDetailsGrid.SettingsDataSecurity.AllowDelete = false;

            var btnSaveStoreDetail = (ASPxButton)StoreDetailsGrid.FindStatusBarTemplateControl("btnSaveStoreDetail");
            btnSaveStoreDetail.Visible = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Edit");

            var btnApprove = (ASPxButton)VersionGrid.FindStatusBarTemplateControl("btnApprove");
            var btnUnApprove = (ASPxButton)VersionGrid.FindStatusBarTemplateControl("btnUnApprove");
            btnApprove.Visible = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Approve");
            btnUnApprove.Visible = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Unapprove");

            btnSaveStoreFiles.Visible = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Edit");

            StoreNoteEditor.ReadOnly = !IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Edit");
            StoreReviewEditor.ReadOnly = !IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Edit");
            StoreApproveEditor.ReadOnly = !IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Edit");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void VersionGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');

        if (args[0] == "Reload")
        {
            s.JSProperties["cpCommand"] = args[0];
            try
            {
                var btnApprove = (ASPxButton)VersionGrid.FindStatusBarTemplateControl("btnApprove");
                var btnUnApprove = (ASPxButton)VersionGrid.FindStatusBarTemplateControl("btnUnApprove");
                btnApprove.Visible = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Approve");
                btnUnApprove.Visible = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Unapprove");
            }
            catch { }
        }
        else if (args[0] == "ApproveVersion")
        {

            decimal versionID;
            if (!decimal.TryParse(args[1], out versionID))
                return;

            var entity = entities.Versions.SingleOrDefault(x => x.VersionID == versionID);
            if (entity == null) return;

            entity.Status = "APPROVED";

            entities.SaveChanges();

            entities.ApproveDisapprove1Version(versionID, SessionUser.UserID, "APPROVE");

            this.LoadVersions(this.versionType, this.versionYear);
        }
        else if (args[0] == "DisApproveVersion")
        {

            decimal versionID;
            if (!decimal.TryParse(args[1], out versionID))
                return;

            var entity = entities.Versions.SingleOrDefault(x => x.VersionID == versionID);
            if (entity == null) return;

            entity.Status = "WORKING";

            entities.SaveChanges();
            entities.ApproveDisapprove1Version(versionID, SessionUser.UserID, "WORKING");

            this.LoadVersions(this.versionType, this.versionYear);
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

            var version = entities.Versions.Where(x => x.VersionID == versionID).FirstOrDefault();
            if (version != null)
            {
                this.VersionStatus = version.Status;
                var colors = entities.VersionBaseSettings.Where(x => x.ForYear == version.VersionYear)
                    .Select(x => new ColorSettings
                    {
                        ForYear = x.ForYear.Value,
                        MinPercent = x.MinPecent ?? 0,
                        MaxPercent = x.MaxPecent ?? 999999999,
                        Color = x.Color
                    })
                    .ToList();

                Session[COLOR_SETTINGS] = colors;
            }
            s.JSProperties["cpCompanyName"] = this.GetCompanyName(SessionUser.CompanyID);

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
            s.JSProperties["cpCompanyName"] = this.GetCompanyName(companyID);

            LoadVersionCompany(versionID);
        }

        if (args[0] == "Duplicate")
        {
            decimal versionID;
            if (!decimal.TryParse(args[1], out versionID))
                return;

            int verCompanyID;
            if (!int.TryParse(args[2], out verCompanyID))
                return;

            var verCompany = entities.VersionCompanies.Where(x => x.VerCompanyID == verCompanyID).FirstOrDefault();

            entities.DuplicateVersionCompany(verCompanyID, verCompany.VerLevel, versionID, SessionUser.UserID);

            LoadVersionCompany(versionID);
        }

        if (args[0] == "NewVersionCompany")
        {
            decimal versionID;
            if (!decimal.TryParse(args[1], out versionID))
                return;

            entities.CreateVersionCompany(versionID, Convert.ToInt32(Session[CURRENT_COMPANY]), SessionUser.UserID);
            LoadVersionCompany(versionID);
            s.JSProperties["cpCompanyName"] = this.GetCompanyName(Convert.ToInt32(Session[CURRENT_COMPANY]));
        }

        if (args[0] == "SaveNote")
        {
            decimal versionID;
            if (!decimal.TryParse(args[1], out versionID))
                return;

            int verCompanyID;
            if (!int.TryParse(args[2], out verCompanyID))
                return;

            var entity = entities.VersionCompanies.SingleOrDefault(x => x.VerCompanyID == verCompanyID);
            if (entity == null) return;

            entity.ApprovedNote = VerCompanyApproveNoteEditor.Text;
            entity.ReviewedNote = VerCompanyReviewNoteEditor.Text;
            entity.Description = VerCompanyDescriptionEditor.Text;

            entities.SaveChangesWithAuditLogs();

            LoadVersionCompany(versionID);
        }

        if (args[0] == "POST" || args[0] == "UNPOST" || args[0] == "APPROVE" || args[0] == "UNAPPROVE")
        {
            int verCompanyID;
            if (!int.TryParse(args[1], out verCompanyID))
                return;

            var verCompany = entities.VersionCompanies.Where(x => x.VerCompanyID == verCompanyID).SingleOrDefault();
            if (verCompany == null) return;

            switch (args[0])
            {
                case "POST":
                    entities.PostUnpost1VerCompany(verCompanyID, SessionUser.UserID, "POST");
                    break;

                case "UNPOST":
                    entities.PostUnpost1VerCompany(verCompanyID, SessionUser.UserID, "WORKING");
                    break;

                case "APPROVE":
                    entities.ApproveDisApprove1VersionCompany(verCompanyID, SessionUser.UserID, "APPROVE");
                    break;

                case "UNAPPROVE":
                    entities.ApproveDisApprove1VersionCompany(verCompanyID, SessionUser.UserID, "WORKING");
                    break;
            }

            //entities.SaveChanges();
            //LoadVersionCompany(verCompany.VersionID.Value);
        }


    }

    protected void StoresGrid_CustomCallback(object sender, TreeListCustomCallbackEventArgs e)
    {
        ASPxTreeList s = sender as ASPxTreeList;

        string[] args = e.Argument.Split('|');

        s.JSProperties["cpCommand"] = args[0];

        if (args[0] == "LoadStore" || args[0] == "RefreshStore")
        {
            decimal verCompanyID;
            if (!decimal.TryParse(args[1], out verCompanyID))
                return;

            Session["VERCOMPANYID"] = verCompanyID;
            InitStores(verCompanyID);
            LoadStores(verCompanyID);
            if (args[0] == "LoadStore")
                this.StoresGrid.ExpandToLevel(1);
            // Load Title Company Name
            var aVerCompany = entities.VersionCompanies.Where(x => x.VerCompanyID == verCompanyID).FirstOrDefault();
            if (aVerCompany != null)
            {
                this.VerCompanyStatus = aVerCompany.ApproveStatus != "APPROVED" ? aVerCompany.ReviewStatus : aVerCompany.ApproveStatus;

                var aCompany = entities.DecCompanies.Where(x => x.CompanyID == aVerCompany.CompanyID).FirstOrDefault();
                if (aCompany != null)
                {
                    s.JSProperties["cpTitle"] = aCompany.AreaCode + "-" + aCompany.NameV + " : " + aVerCompany.VersionName + " - <span style='color: Orange; font-weight: 700;'> Currency: " + aCompany.Curr + "</span>";
                    Session["CompanyName"] = aCompany.NameV + " - " + aVerCompany.VersionName;

                }
            }
        }

        if (args[0] == "CalculateStore")
        {
            decimal verCompanyID;
            if (!decimal.TryParse(args[1], out verCompanyID))
                return;

            entities.CalculateSumItem(verCompanyID);

            LoadStores(verCompanyID);
        }

        if (args[0] == "AutoItem")
        {
            decimal verCompanyID, storeID;
            if (!decimal.TryParse(args[1], out verCompanyID))
                return;

            if (!decimal.TryParse(args[2], out storeID))
                return;

            var aVersion = entities.VersionCompanies.Where(x => x.VerCompanyID == verCompanyID)
                .Select(x => new { x.VersionID, x.CompanyID }).FirstOrDefault();

            if (!aVersion.VersionID.HasValue) return;

            var version = entities.Versions.Where(x => x.VersionID == aVersion.VersionID.Value).FirstOrDefault();
            if (version != null && version.Status == "APPROVED")
            {
                new UserFriendlyMessage("Version đã APPROVE, không thể chạy Auto Item", SessionUser.UserName, UserFriendlyMessage.MessageType.ERROR);
                return;
            }

            List<int?> companyIds = new List<int?>();
            companyIds.Add(aVersion.CompanyID);

            var job = new KTQTData.BackgroundJob
            {
                VersionID = aVersion.VersionID.Value,
                JobType = "AUTOITEM",
                IssueDate = DateTime.Now,
                Status = "QUEUED",
                CreateDate = DateTime.Now,
                CreatedBy = SessionUser.UserID
            };
            entities.BackgroundJobs.Add(job);

            entities.SaveChanges();

            //Hangfire.BackgroundJob.Schedule<BackgroundJobSchedule>(t => t.RunAutoItem(job.Id, aVersion.VersionID.Value, companyIds, 1, 12, SessionUser.UserID, SessionUser.UserName), TimeSpan.FromSeconds((job.IssueDate.Value - DateTime.Now).TotalSeconds));

            var hfJobId = Hangfire.BackgroundJob.Enqueue<ReveneCostJob>(t => t.AutoItemExecute(job.Id, verCompanyID, storeID, SessionUser.UserID, SessionUser.UserName));

            var addedJob = entities.BackgroundJobs.Where(x => x.Id == job.Id).FirstOrDefault();
            if (addedJob != null)
            {
                addedJob.HFJobId = hfJobId;
                entities.SaveChanges();
            }
            //RunAutoItem(verCompanyID, storeID);

            new UserFriendlyMessage("Tiến trình đã thêm vào queued để chạy.", SessionUser.UserName, UserFriendlyMessage.MessageType.SUCCESS);

            //LoadStores(verCompanyID);
        }

        if (args[0] == "AutoAllItem")
        {
            decimal verCompanyID;
            if (!decimal.TryParse(args[1], out verCompanyID))
                return;

            //var aVersionID = entities.VersionCompanies.Where(x => x.VerCompanyID == verCompanyID)
            //    .Select(x => x.VersionID).FirstOrDefault();

            var verCompany = entities.VersionCompanies.Where(x => x.VerCompanyID == verCompanyID).FirstOrDefault();
            if (verCompany == null)
                throw new UserFriendlyException("Không tìm thấy Version chỉ tiêu phân bổ", SessionUser.UserName);

            var aVersionID = verCompany.VersionID;
            var aCompanyID = verCompany.CompanyID;

            if (!aVersionID.HasValue) return;

            var version = entities.Versions.Where(x => x.VersionID == aVersionID.Value).FirstOrDefault();
            if (version != null && version.Status == "APPROVED")
            {
                new UserFriendlyMessage("Version đã APPROVE, không thể chạy Auto Item", SessionUser.UserName, UserFriendlyMessage.MessageType.ERROR);
                return;
            }

            //var companys = entities.DecCompanies.Where(x => x.CompanyType == "D").Select(x => x.CompanyID).ToList();

            //List<int?> companyIds = entities.VersionCompanies.Where(x => x.VersionID == aVersionID && companys.Contains(x.CompanyID.Value))
            //    .Select(x => x.CompanyID).ToList(); ;

            var job = new KTQTData.BackgroundJob
            {
                VersionID = aVersionID,
                JobType = "AUTOITEM",
                IssueDate = DateTime.Now,
                Status = "QUEUED",
                CreateDate = DateTime.Now,
                CreatedBy = SessionUser.UserID
            };
            entities.BackgroundJobs.Add(job);

            entities.SaveChanges();

            //Hangfire.BackgroundJob.Schedule<BackgroundJobSchedule>(t => t.RunAutoItem(job.Id, aVersionID.Value, companyIds, 1, 12, SessionUser.UserID, SessionUser.UserName), TimeSpan.FromSeconds((job.IssueDate.Value - DateTime.Now).TotalSeconds));

            var hfJobId = Hangfire.BackgroundJob.Enqueue<ReveneCostJob>(t => t.AutoAllItemExecute(job.Id, aVersionID.Value, aCompanyID.Value, SessionUser.UserID, SessionUser.UserName));

            var addedJob = entities.BackgroundJobs.Where(x => x.Id == job.Id).FirstOrDefault();
            if (addedJob != null)
            {
                addedJob.HFJobId = hfJobId;
                entities.SaveChanges();
            }
            //RunAutoAllItem(verCompanyID);
            //LoadStores(verCompanyID);
            new UserFriendlyMessage("Tiến trình đã thêm vào queued để chạy.", SessionUser.UserName, UserFriendlyMessage.MessageType.SUCCESS);

        }

        if (args[0] == "IsOK")
        {
            decimal storeID;
            if (!decimal.TryParse(args[1], out storeID))
                return;

            var isOK = args[2];

            var entity = entities.Stores.SingleOrDefault(x => x.StoreID == storeID);
            if (entity == null) return;
            entity.IsOK = Convert.ToBoolean(isOK);

            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = SessionUser.UserID;

            entities.SaveChangesWithAuditLogs();
        }

        if (args[0] == "ExpandAll")
        {
            this.StoresGrid.ExpandAll();
        }

        if (args[0] == "CollapseAll")
        {
            this.StoresGrid.CollapseAll();
            this.StoresGrid.ExpandToLevel(1);
        }

    }

    private void InitStores(decimal verCompanyID)
    {
        try
        {
            var verCompany = entities.VersionCompanies.FirstOrDefault(x => x.VerCompanyID == verCompanyID);
            if (verCompany != null)
            {
                var exists = entities.Stores.Where(s => s.VerCompanyID == verCompanyID).Any();
                if (!exists)
                    entities.InitStores(verCompany.VerCompanyID, verCompany.CompanyID, SessionUser.UserID);
            }
        }
        catch { }
    }

    protected void StoreDetailsGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');

        grid.JSProperties["cpCommand"] = args[0];

        if (args[0] == "LoadStoreDetail")
        {
            decimal storeID;
            if (!decimal.TryParse(args[1], out storeID))
                return;

            var store = entities.Stores.FirstOrDefault(x => x.StoreID == storeID);
            if (store != null)
            {
                this.StoreStatus = store != null ? store.Status : "";
                if (store.Calculation == "DATA")
                    entities.InitStoreDetail(storeID, SessionUser.UserID);

                var subacount = entities.DecSubaccounts.FirstOrDefault(x => x.SubaccountID == store.SubaccountID);
                if (subacount != null)
                {
                    this.aOutAllowUpdate = subacount.OutAllowUpdate ?? false;
                    this.aDecAllowUpdate = subacount.DecAllowUpdate ?? false;
                }
            }
            //ASPxRoundPanel RoundPanel = (ASPxRoundPanel)grid.FindTitleTemplateControl("AllocateRoundPanel");
            //ASPxFormLayout FormLayout = (ASPxFormLayout)RoundPanel.FindControl("AllocateForm");
            //ASPxButton btnAllocateApply = (ASPxButton)FormLayout.FindControl("btnAllocateApply");
            //if (store != null || store.Calculation == "SUM")            
            //    btnAllocateApply.Enabled = false;
            //else
            //    btnAllocateApply.Enabled = true;

            LoadStoreDetails(storeID);

            try
            {
                var btnSaveStoreDetail = (ASPxButton)StoreDetailsGrid.FindStatusBarTemplateControl("btnSaveStoreDetail");
                btnSaveStoreDetail.Visible = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Edit");
            }
            catch { }

        }

        if (args[0] == "Allocate")
        {
            decimal storeID;
            if (!decimal.TryParse(args[1], out storeID))
                return;

            var store = entities.Stores.SingleOrDefault(x => x.StoreID == storeID);
            this.StoreStatus = store.Status;
            if (store.Status.ToUpper().Equals("APPROVED"))
                return;

            //var col1 = AllocateColumn.Outstandard;
            //var col2 = AllocateColumn.OutAdjust;
            //var col3 = AllocateColumn.OutSaving;
            //var amountType = AmountType.FinalAmount;

            //if (Object.Equals(rdoAmountType.Value, "FA"))
            //{
            //    amountType = AmountType.FinalAmount;
            //    //col1 = AllocateColumn.Instandard;
            //    col2 = AllocateColumn.Outstandard;
            //    col3 = AllocateColumn.Decentralization;
            //}
            //else if (Object.Equals(rdoAmountType.Value, "AD"))
            //{
            //    amountType = AmountType.Adjust;
            //    //col1 = AllocateColumn.InAdjust;
            //    col2 = AllocateColumn.OutAdjust;
            //    col3 = AllocateColumn.DecAdjust;
            //}
            //else if (Object.Equals(rdoAmountType.Value, "SA"))
            //{
            //    amountType = AmountType.Saving;
            //    //col1 = AllocateColumn.InSaving;
            //    col2 = AllocateColumn.OutSaving;
            //    col3 = AllocateColumn.DecSaving;
            //}
            //else
            //{
            //    return;
            //}


            var storeDetails = entities.StoreDetails.Where(x => x.StoreID == storeID).OrderBy(x => x.RevCostMonth).ToList();
            if (storeDetails == null || storeDetails.Count <= 0)
                return;

            ASPxRoundPanel RoundPanel = (ASPxRoundPanel)grid.FindTitleTemplateControl("AllocateRoundPanel");
            if (RoundPanel == null) return;

            ASPxFormLayout FormLayout = (ASPxFormLayout)RoundPanel.FindControl("AllocateForm");
            if (FormLayout == null) return;

            ASPxComboBox StoreDetailTypeOfAmount = (ASPxComboBox)FormLayout.FindControl("StoreDetailTypeOfAmount");
            ASPxSpinEdit StoreDetailMonthFrom = (ASPxSpinEdit)FormLayout.FindControl("StoreDetailMonthFrom");
            ASPxSpinEdit StoreDetailMonthTo = (ASPxSpinEdit)FormLayout.FindControl("StoreDetailMonthTo");
            ASPxSpinEdit StoreDetailAmount = (ASPxSpinEdit)FormLayout.FindControl("StoreDetailAmount");

            var column = AllocateColumn.Outstandard;
            if (StoreDetailTypeOfAmount.Value.ToString().ToUpper() == "Outstandard".ToUpper())
                column = AllocateColumn.Outstandard;
            else if (StoreDetailTypeOfAmount.Value.ToString().ToUpper() == "Decentralization".ToUpper())
                column = AllocateColumn.Decentralization;
            //else if (StoreDetailTypeOfAmount.Value.ToString().ToUpper() == "OutSaving".ToUpper())
            //    column = AllocateColumn.OutSaving;

            //if (StoreDetailTypeOfAmount.Value.ToString().ToUpper() == "Outstandard".ToUpper())
            //{
            AllocateStoreDetail(store.VersionID.Value, store.Curr, storeDetails, StoreDetailMonthFrom.Number, StoreDetailMonthTo.Number, StoreDetailAmount, column);
            //}
            //else if (StoreDetailTypeOfAmount.Value.ToString().ToUpper() == "Decentralization".ToUpper())
            //{
            //    AllocateStoreDetail(storeDetails, amountType, StoreDetailMonthFrom.Number, StoreDetailMonthTo.Number, StoreDetailAmount, col3);
            //}

            entities.SaveChangesWithAuditLogs();

            foreach (var entity in storeDetails)
            {
                entities.CalcStoreDetailAfterSavingAmt(entity.StoreDetailID);
            }

            //Update Stores/Load Store detail

            UpdateStore(storeID);

            LoadStoreDetails(storeID);

            try
            {
                var btnSaveStoreDetail = (ASPxButton)StoreDetailsGrid.FindStatusBarTemplateControl("btnSaveStoreDetail");
                btnSaveStoreDetail.Visible = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Edit");
            }
            catch { }
        }

        if (args[0] == "IsOK")
        {
            decimal storeDetailID;
            if (!decimal.TryParse(args[1], out storeDetailID))
                return;

            var isOK = args[2];

            var entity = entities.StoreDetails.SingleOrDefault(x => x.StoreDetailID == storeDetailID);
            if (entity == null) return;
            entity.IsOK = Convert.ToBoolean(isOK);
            entity.IsOKDate = DateTime.Now;
            entity.IsOKBy = SessionUser.UserID;

            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = SessionUser.UserID;

            entities.SaveChangesWithAuditLogs();

            try
            {
                var btnSaveStoreDetail = (ASPxButton)StoreDetailsGrid.FindStatusBarTemplateControl("btnSaveStoreDetail");
                btnSaveStoreDetail.Visible = IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Edit");
            }
            catch { }
        }

    }

    private void AllocateStoreDetail(decimal versionID, string curr, List<KTQTData.StoreDetail> storeDetails, decimal fromMonth, decimal toMonth, ASPxSpinEdit editor, AllocateColumn column)
    {
        if (editor == null || editor.Value == null)
            return;

        var average = Math.Round(editor.Number / (toMonth - fromMonth + 1), 2);
        decimal lastMonth = decimal.Zero;

        lastMonth = editor.Number - average * (toMonth - fromMonth);

        foreach (var entity in storeDetails.Where(x => x.RevCostMonth >= fromMonth && x.RevCostMonth <= toMonth))
        {

            if (entity.Posted == true)
            {
                continue;
            }


            /*if (column == AllocateColumn.Instandard)
            {
                if (entity.RevCostMonth >= fromMonth && entity.RevCostMonth < toMonth)
                    entity.InStandards = average;
                else
                    entity.InStandards = lastMonth;
            }*/
            if (column == AllocateColumn.Outstandard)
            {
                if (entity.RevCostMonth >= fromMonth && entity.RevCostMonth < toMonth)
                    entity.OutStandards = average;
                else
                    entity.OutStandards = lastMonth;
            }
            if (column == AllocateColumn.Decentralization)
            {
                if (entity.RevCostMonth >= fromMonth && entity.RevCostMonth < toMonth)
                    entity.Decentralization = average;
                else
                    entity.Decentralization = lastMonth;
            }
            /*if (column == AllocateColumn.InAdjust)
            {
                if (entity.RevCostMonth >= fromMonth && entity.RevCostMonth < toMonth)
                    entity.InAdjust = average;
                else
                    entity.InAdjust = lastMonth;
            }*/
            if (column == AllocateColumn.OutAdjust)
            {
                if (entity.RevCostMonth >= fromMonth && entity.RevCostMonth < toMonth)
                    entity.OutAdjust = average;
                else
                    entity.OutAdjust = lastMonth;
            }
            if (column == AllocateColumn.DecAdjust)
            {
                if (entity.RevCostMonth >= fromMonth && entity.RevCostMonth < toMonth)
                    entity.DecAdjust = average;
                else
                    entity.DecAdjust = lastMonth;
            }
            /*if (column == AllocateColumn.InSaving)
            {
                if (entity.RevCostMonth >= fromMonth && entity.RevCostMonth < toMonth)
                    entity.InSaving = average;
                else
                    entity.InSaving = lastMonth;
            }*/
            if (column == AllocateColumn.OutSaving)
            {
                if (entity.RevCostMonth >= fromMonth && entity.RevCostMonth < toMonth)
                    entity.OutSaving = average;
                else
                    entity.OutSaving = lastMonth;
            }
            if (column == AllocateColumn.DecSaving)
            {
                if (entity.RevCostMonth >= fromMonth && entity.RevCostMonth < toMonth)
                    entity.DecSaving = average;
                else
                    entity.DecSaving = lastMonth;
            }

            var roe = decimal.One;
            if (curr != "VND")
                roe = GetRoeVND(versionID, curr, entity.RevCostMonth.Value);

            entity.OutStandardsVND = entity.OutStandards * roe;
            entity.Amount = (entity.OutStandards ?? 0) + (entity.Decentralization ?? 0);
            entity.AmountVND = entity.Amount * roe;


            //entities.CalcStoreDetailAfterSavingAmt(entity.StoreDetailID);
        }
    }

    /*
    private void AllocateStoreDetail(ASPxSpinEdit editor, List<StoreDetail> storeDetails, AmountType amountType, AllocateType allocateType, AllocateColumn column)
    {
        if (editor == null || editor.Value == null)
            return;

        var average = Math.Round(editor.Number / 3, 2);
        int fromMonth = 0;
        int toMonth = 0;
        decimal lastMonth = decimal.Zero;
        if (allocateType == AllocateType.Q1)
        {
            fromMonth = 1;
            toMonth = 3;
            lastMonth = editor.Number - average * 2;
        }
        else if (allocateType == AllocateType.Q2)
        {
            fromMonth = 4;
            toMonth = 6;
            lastMonth = editor.Number - average * 2;
        }
        else if (allocateType == AllocateType.Q3)
        {
            fromMonth = 7;
            toMonth = 9;
            lastMonth = editor.Number - average * 2;
        }
        else if (allocateType == AllocateType.Q4)
        {
            fromMonth = 10;
            toMonth = 12;
            lastMonth = editor.Number - average * 2;
        }
        else if (allocateType == AllocateType.Y)
        {
            fromMonth = 1;
            toMonth = 12;
            average = Math.Round(editor.Number / 12, 2);
            lastMonth = editor.Number - average * 11;
        }
        foreach (var entity in storeDetails.Where(x => x.RevCostMonth >= fromMonth && x.RevCostMonth <= toMonth))
        {
            if (column == AllocateColumn.Instandard)
            {
                if (entity.RevCostMonth >= fromMonth && entity.RevCostMonth < toMonth)
                    entity.InStandards = average;
                else
                    entity.InStandards = lastMonth;
            }
            if (column == AllocateColumn.Outstandard)
            {
                if (entity.RevCostMonth >= fromMonth && entity.RevCostMonth < toMonth)
                    entity.OutStandards = average;
                else
                    entity.OutStandards = lastMonth;
            }
            if (column == AllocateColumn.Decentralization)
            {
                if (entity.RevCostMonth >= fromMonth && entity.RevCostMonth < toMonth)
                    entity.Decentralization = average;
                else
                    entity.Decentralization = lastMonth;
            }
            if (column == AllocateColumn.InAdjust)
            {
                if (entity.RevCostMonth >= fromMonth && entity.RevCostMonth < toMonth)
                    entity.InAdjust = average;
                else
                    entity.InAdjust = lastMonth;
            }
            if (column == AllocateColumn.OutAdjust)
            {
                if (entity.RevCostMonth >= fromMonth && entity.RevCostMonth < toMonth)
                    entity.OutAdjust = average;
                else
                    entity.OutAdjust = lastMonth;
            }
            if (column == AllocateColumn.DecAdjust)
            {
                if (entity.RevCostMonth >= fromMonth && entity.RevCostMonth < toMonth)
                    entity.DecAdjust = average;
                else
                    entity.DecAdjust = lastMonth;
            }
            if (column == AllocateColumn.InSaving)
            {
                if (entity.RevCostMonth >= fromMonth && entity.RevCostMonth < toMonth)
                    entity.InSaving = average;
                else
                    entity.InSaving = lastMonth;
            }
            if (column == AllocateColumn.OutSaving)
            {
                if (entity.RevCostMonth >= fromMonth && entity.RevCostMonth < toMonth)
                    entity.OutSaving = average;
                else
                    entity.OutSaving = lastMonth;
            }
            if (column == AllocateColumn.DecSaving)
            {
                if (entity.RevCostMonth >= fromMonth && entity.RevCostMonth < toMonth)
                    entity.DecSaving = average;
                else
                    entity.DecSaving = lastMonth;
            }

            entities.CalcStoreDetailAfterSavingAmt(entity.StoreDetailID);
        }
    }
    */


    protected void StoresGrid_HtmlRowPrepared(object sender, TreeListHtmlRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("Calculation"), "SUM"))
        {
            e.Row.Font.Bold = true;
        }

    }
    protected void StoreDetailIsOK_Init(object sender, EventArgs e)
    {
        ASPxCheckBox chk = sender as ASPxCheckBox;
        GridViewDataItemTemplateContainer container = chk.NamingContainer as GridViewDataItemTemplateContainer;
        chk.ClientSideEvents.ValueChanged = String.Format("function(s, e) {{ RevCost.ClientStoreDetailIsOK_ValueChanged({0}, s.GetChecked());}}", container.KeyValue);
    }
    protected void StoreIsOK_Init(object sender, EventArgs e)
    {
        ASPxCheckBox chk = sender as ASPxCheckBox;
        TreeListDataCellTemplateContainer container = chk.NamingContainer as TreeListDataCellTemplateContainer;
        chk.ClientSideEvents.ValueChanged = String.Format("function(s, e) {{ RevCost.ClientStoreIsOK_ValueChanged({0}, s.GetChecked());}}", container.NodeKey);
    }

    private decimal GetRoeVND(decimal verId, string curr, int month)
    {
        try
        {
            decimal roe = entities.Database
                     .SqlQuery<decimal>("SELECT [dbo].[GetRoeVN](@verId, @curr, @month)",
                                        new SqlParameter("@verId", verId),
                                        new SqlParameter("@curr", curr),
                                        new SqlParameter("@month", month))
                     .FirstOrDefault();

            return roe;
        }
        catch { }
        return 1;

    }

    protected void StoreDetailsGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;

        try
        {
            decimal storeID = decimal.Zero;
            decimal versionID = decimal.Zero;
            string curr = "VND";
            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {

                decimal? aOutStandards = null;
                decimal? aOutAdjust = null;
                decimal? aOutSaving = null;
                decimal? aDecentralization = null;
                decimal? aOutAfterSaving = null;

                decimal vStoreDetailID = Convert.ToDecimal(updValues.Keys["StoreDetailID"]);
                var entity = entities.StoreDetails.SingleOrDefault(x => x.StoreDetailID == vStoreDetailID);
                if (entity != null)

                {
                    if (storeID == decimal.Zero)
                    {
                        storeID = (decimal)entity.StoreID;

                        var store = entities.Stores.Where(x => x.StoreID == storeID).FirstOrDefault();
                        if (store != null)
                        {
                            versionID = store.VersionID.Value;
                            curr = store.Curr;
                        }
                    }

                    if (updValues.NewValues["OutStandards"] != null)
                        aOutStandards = Convert.ToDecimal(updValues.NewValues["OutStandards"]);
                    if (updValues.NewValues["OutAdjust"] != null)
                        aOutAdjust = Convert.ToDecimal(updValues.NewValues["OutAdjust"]);
                    if (updValues.NewValues["OutSaving"] != null)
                        aOutSaving = Convert.ToDecimal(updValues.NewValues["OutSaving"]);
                    if (updValues.NewValues["OutAfterSaving"] != null)
                        aOutAfterSaving = Convert.ToDecimal(updValues.NewValues["OutAfterSaving"]);
                    if (updValues.NewValues["Decentralization"] != null)
                        aDecentralization = Convert.ToDecimal(updValues.NewValues["Decentralization"]);

                    //aOutAfterSaving = (aOutStandards ?? 0) + (aOutAdjust ?? 0) - (aOutSaving ?? 0);
                    var roe = decimal.One;
                    if (curr != "VND")
                        roe = GetRoeVND(versionID, curr, entity.RevCostMonth.Value);

                    entity.OutStandards = aOutStandards;
                    entity.OutStandardsVND = aOutStandards * roe;
                    entity.Decentralization = aDecentralization;
                    entity.OutAdjust = aOutAdjust;
                    entity.OutSaving = aOutSaving;
                    entity.OutAfterSaving = aOutAfterSaving;
                    entity.OutAfterSavingVND = aOutAfterSaving * roe;
                    entity.AfterSaving = aOutAfterSaving;
                    entity.Amount = (aOutStandards ?? 0) + (aDecentralization ?? 0);
                    entity.AmountVND = (aOutStandards ?? 0) + (aDecentralization ?? 0) * roe;

                    //if (rdoAmountType.Value != null && rdoAmountType.Value == "FA")
                    //{
                    //    if (updValues.NewValues["InStandards"] != null)
                    //        instandard = Convert.ToDecimal(updValues.NewValues["InStandards"]);
                    //    if (updValues.NewValues["OutStandards"] != null)
                    //        outstandard = Convert.ToDecimal(updValues.NewValues["OutStandards"]);
                    //    if (updValues.NewValues["Decentralization"] != null)
                    //        decentralization = Convert.ToDecimal(updValues.NewValues["Decentralization"]);

                    //    total = (instandard ?? 0) + (outstandard ?? 0) + (decentralization ?? 0);
                    //    entity.InStandards = instandard;
                    //    entity.OutStandards = outstandard;
                    //    entity.Decentralization = decentralization;
                    //    entity.Amount = total;

                    //}
                    //else if (rdoAmountType.Value != null && rdoAmountType.Value == "AD")
                    //{
                    //if (updValues.NewValues["InAdjust"] != null)
                    //    instandard = Convert.ToDecimal(updValues.NewValues["InAdjust"]);
                    //if (updValues.NewValues["OutAdjust"] != null)
                    //    outstandard = Convert.ToDecimal(updValues.NewValues["OutAdjust"]);
                    //if (updValues.NewValues["DecAdjust"] != null)
                    //    decentralization = Convert.ToDecimal(updValues.NewValues["DecAdjust"]);
                    //total = (instandard ?? 0) + (outstandard ?? 0) + (decentralization ?? 0);

                    //entity.InAdjust = instandard;
                    //entity.OutAdjust = outstandard;
                    //entity.DecAdjust = decentralization;
                    //entity.Adjust = total;
                    //}
                    //else if (rdoAmountType.Value != null && rdoAmountType.Value == "SA")
                    //{
                    //    if (updValues.NewValues["InSaving"] != null)
                    //        instandard = Convert.ToDecimal(updValues.NewValues["InSaving"]);
                    //    if (updValues.NewValues["OutSaving"] != null)
                    //        outstandard = Convert.ToDecimal(updValues.NewValues["OutSaving"]);
                    //    if (updValues.NewValues["DecSaving"] != null)
                    //        decentralization = Convert.ToDecimal(updValues.NewValues["DecSaving"]);
                    //    total = (instandard ?? 0) + (outstandard ?? 0) + (decentralization ?? 0);

                    //    entity.InSaving = instandard;
                    //    entity.OutSaving = outstandard;
                    //    entity.DecSaving = decentralization;
                    //    entity.Saving = total;
                    //}
                    //else if (rdoAmountType.Value != null && rdoAmountType.Value == "AS")
                    //{
                    //if (updValues.NewValues["InAfterSaving"] != null)
                    //    instandard = Convert.ToDecimal(updValues.NewValues["InAfterSaving"]);
                    //if (updValues.NewValues["OutAfterSaving"] != null)
                    //    outstandard = Convert.ToDecimal(updValues.NewValues["OutAfterSaving"]);
                    //if (updValues.NewValues["DecAfterSaving"] != null)
                    //    decentralization = Convert.ToDecimal(updValues.NewValues["DecAfterSaving"]);
                    //total = (instandard ?? 0) + (outstandard ?? 0) + (decentralization ?? 0);

                    //entity.InAfterSaving = instandard;
                    //entity.OutAfterSaving = outstandard;
                    //entity.DecAfterSaving = decentralization;
                    //entity.AfterSaving = total;
                    //}

                    if (updValues.NewValues["IsOK"] != null)
                    {
                        var isOK = Convert.ToBoolean(updValues.NewValues["IsOK"]);
                        entity.IsOK = isOK;
                        entity.IsOKBy = SessionUser.UserID;
                        entity.IsOKDate = DateTime.Now;
                    }

                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = SessionUser.UserID;

                    entities.SaveChangesWithAuditLogs();

                    //Calculate Store Detail   
                    entities.CalcStoreDetailAfterSavingAmt(entity.StoreDetailID);
                }
            }

            //Update Stores/Load Store detail
            if (storeID != decimal.Zero)
            {
                UpdateStore(storeID);

                LoadStoreDetails(storeID);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            e.Handled = true;
        }
    }

    private void UpdateStore(decimal storeID)
    {
        var sumStoreDetail = entities.StoreDetails
                            .Where(x => x.StoreID == storeID)
                            .GroupBy(x => x.StoreID)
                            .Select(g => new
                            {
                                StoreID = g.Key,
                                InStandards = g.Sum(c => c.InStandards),
                                OutStandards = g.Sum(c => c.OutStandards),
                                Decentralization = g.Sum(c => c.Decentralization),
                                InAdjust = g.Sum(c => c.InAdjust),
                                OutAdjust = g.Sum(c => c.OutAdjust),
                                DecAdjust = g.Sum(c => c.DecAdjust),
                                InSaving = g.Sum(c => c.InSaving),
                                OutSaving = g.Sum(c => c.OutSaving),
                                DecSaving = g.Sum(c => c.DecSaving),
                                InAfterSaving = g.Sum(c => c.InAfterSaving),
                                OutAfterSaving = g.Sum(c => c.OutAfterSaving),
                                DecAfterSaving = g.Sum(c => c.DecAfterSaving)
                            }).SingleOrDefault();

        if (sumStoreDetail != null)
        {
            var store = entities.Stores.SingleOrDefault(x => x.StoreID == storeID);
            if (store != null)
            {
                store.InStandards = sumStoreDetail.InStandards;
                store.OutStandards = sumStoreDetail.OutStandards;
                store.Decentralization = sumStoreDetail.Decentralization;
                store.Amount = (sumStoreDetail.InStandards ?? 0)
                    + (sumStoreDetail.OutStandards ?? 0)
                    + (sumStoreDetail.Decentralization ?? 0);

                store.InAdjust = sumStoreDetail.InAdjust;
                store.OutAdjust = sumStoreDetail.OutAdjust;
                store.DecAdjust = sumStoreDetail.DecAdjust;
                store.Adjust = (sumStoreDetail.InAdjust ?? 0)
                    + (sumStoreDetail.OutAdjust ?? 0)
                    + (sumStoreDetail.DecAdjust ?? 0);

                store.InSaving = sumStoreDetail.InSaving;
                store.OutSaving = sumStoreDetail.OutSaving;
                store.DecSaving = sumStoreDetail.DecSaving;
                store.Saving = (sumStoreDetail.InSaving ?? 0)
                    + (sumStoreDetail.OutSaving ?? 0)
                    + (sumStoreDetail.DecSaving ?? 0);

                store.InAfterSaving = sumStoreDetail.InAfterSaving;
                store.OutAfterSaving = sumStoreDetail.OutAfterSaving;
                store.DecAfterSaving = sumStoreDetail.DecAfterSaving;
                store.AfterSaving = (sumStoreDetail.InAfterSaving ?? 0)
                    + (sumStoreDetail.OutAfterSaving ?? 0)
                    + (sumStoreDetail.InAfterSaving ?? 0);

                store.LastUpdateDate = DateTime.Now;
                store.LastUpdatedBy = SessionUser.UserID;

                entities.SaveChanges();

                entities.CalculateSumItem(store.VerCompanyID);
            }
        }
    }

    protected void CancelEditing(ASPxGridView grid, CancelEventArgs e)
    {
        e.Cancel = true;
        //grid.CancelEdit();
    }

    protected void StoreDetailsGrid_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
    {

    }
    protected void StoreDetailsGrid_RowInserting(object sender, ASPxDataInsertingEventArgs e)
    {
        CancelEditing(sender as ASPxGridView, e);
    }
    protected void StoreDetailsGrid_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
    {
        CancelEditing(sender as ASPxGridView, e);
    }
    protected void StoreDetailsGrid_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
    {
        CancelEditing(sender as ASPxGridView, e);
    }
    protected void StoreDetailsGrid_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
    {

        ASPxGridView grid = sender as ASPxGridView;
        var abc1 = e;
        if (e.Column.FieldName == "RevCostMonth")
        {
            e.Editor.ReadOnly = true;
            var abc = e.Value;
        }

        if (e.Column.FieldName == "OutStandards" || e.Column.FieldName == "Decentralization" || e.Column.FieldName == "OutAdjust" || e.Column.FieldName == "DecAdjust" || e.Column.FieldName == "OutSaving" || e.Column.FieldName == "DecSaving")
        {
            if (this.VerCompanyStatus == "APPROVED" || this.VerCompanyStatus == "POSTED" || this.VersionStatus == "APPROVED" || this.StoreStatus == "APPROVED")
            {
                e.Editor.BackColor = System.Drawing.ColorTranslator.FromHtml("#e6e6e6");
                e.Editor.ReadOnly = true;
            }
            else if (e.Column.FieldName == "OutStandards" && !this.aOutAllowUpdate)
            {
                e.Editor.BackColor = System.Drawing.ColorTranslator.FromHtml("#e6e6e6");
                e.Editor.ReadOnly = true;
            }
            else if (e.Column.FieldName == "Decentralization" && !this.aDecAllowUpdate)
            {
                e.Editor.BackColor = System.Drawing.ColorTranslator.FromHtml("#e6e6e6");
                e.Editor.ReadOnly = true;
            }
        }

        if (e.Column.FieldName == "InAfterSaving"
            //|| e.Column.FieldName == "OutAfterSaving"
            || e.Column.FieldName == "DecAfterSaving")
        {
            //e.Editor.ClientVisible = false;
            e.Editor.ReadOnly = true;
        }

    }

    protected void StoreDetailsGrid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
    {
        var a1 = e;
        if (this.StoreStatus == "APPROVED")
        {
            e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#e6e6e6");
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

    protected void StoreFilesUploadControl_FilesUploadComplete(object sender, FilesUploadCompleteEventArgs e)
    {
        for (int i = 0; i < StoreFilesUploadControl.UploadedFiles.Length; i++)
        {
            UploadedFile file = StoreFilesUploadControl.UploadedFiles[i];

            if (file.FileName != "" && file.IsValid)
            {
                try
                {
                    string fileName = Path.Combine(fileStorage + @"StoreFiles\", file.FileName);
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
                    e.ErrorText = "Error while uploading file!";//ex.Message;
                }
            }
        }
    }
    protected void StoreFilesGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        if (args[0] == "LoadStoreFiles")
        {
            decimal storeID;
            if (!decimal.TryParse(args[1], out storeID))
                return;

            LoadStoreFiles(storeID);
        }
        else if (args[0] == "SaveStoreFile")
        {
            decimal storeID;
            if (!decimal.TryParse(args[1], out storeID))
                return;

            var filePath = args[2];

            FileInfo fi = new FileInfo(filePath);

            var entity = new KTQTData.StoreFile();
            entity.FileName = fi.Name;
            entity.FilePath = filePath;
            entity.StoreID = storeID;

            entity.CreateDate = DateTime.Now;
            entity.CreatedBy = (int)SessionUser.UserID;

            entities.StoreFiles.Add(entity);

            entities.SaveChanges();

            LoadStoreFiles(storeID);
        }
        else if (args[0] == "Delete")
        {
            decimal aStoreFileID;
            if (!decimal.TryParse(args[1], out aStoreFileID))
                return;

            var entity = entities.StoreFiles.Where(x => x.StoreFileID == aStoreFileID).FirstOrDefault();
            if (entity != null)
            {
                entities.StoreFiles.Remove(entity);

                entities.SaveChangesWithAuditLogs();

                LoadStoreFiles(entity.StoreID.Value);
            }
        }
    }
    protected void StoreFilesGrid_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        if (e.Column.FieldName == "FileName")
            e.Editor.ReadOnly = true;
    }
    protected void StoreFilesGrid_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        decimal storeID = decimal.Zero;
        try
        {
            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal vStoreFilelID = Convert.ToDecimal(updValues.Keys["StoreFileID"]);
                var entity = entities.StoreFiles.SingleOrDefault(x => x.StoreFileID == vStoreFilelID);
                if (entity != null)
                {
                    if (updValues.NewValues["Description"] != null)
                    {
                        string description = updValues.NewValues["Description"].ToString();
                        entity.Description = description;
                    }

                    if (storeID == decimal.Zero)
                        storeID = (decimal)entity.StoreID;
                }
            }
            entities.SaveChanges();
            LoadStoreFiles(storeID);
        }
        catch (Exception ex) { throw new UserFriendlyException(ex.Message, ex, SessionUser.UserName); }
        finally
        {
            e.Handled = true;
        }
    }
    protected void StoresGrid_CustomColumnDisplayText(object sender, TreeListColumnDisplayTextEventArgs e)
    {
        //string[] columns = new string[] { "AmountAuto", "Amount", "InStandards", "OutStandards" };
        //if (columns.Contains(e.Column.FieldName) && e.Value != null)
        //{
        //    e.DisplayText = string.Format("{N}", e.Value);
        //}
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

        else if (args[0] == "Delete")
        {
            decimal aVerCompanyFileID;
            if (!decimal.TryParse(args[1], out aVerCompanyFileID))
                return;

            var entity = entities.VersionCompanyFiles.Where(x => x.VerCompanyFileID == aVerCompanyFileID).FirstOrDefault();
            if (entity != null)
            {
                entities.VersionCompanyFiles.Remove(entity);

                entities.SaveChangesWithAuditLogs();

                LoadVerCompanyFiles(entity.VerCompanyID.Value);
            }
        }
    }

    protected void VersionCompanyFilesGrid_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
    {

    }
    protected void VersionCompanyFilesGrid_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
    {

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

    protected void VersionCopyGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');

        if (args[0] == "CopyVersionCompany")
        {
            int verCompanyID;
            if (!int.TryParse(args[1], out verCompanyID))
                return;

            decimal versionID;
            if (!decimal.TryParse(args[2], out versionID))
                return;

            var verCompany = entities.VersionCompanies.Where(x => x.VerCompanyID == verCompanyID).FirstOrDefault();

            entities.CopyVersionCompany(verCompanyID, verCompany.VerLevel, versionID, SessionUser.UserID);

        }

        if (args[0] == "CopyVersion")
        {
            int oriVerID;
            if (!int.TryParse(args[1], out oriVerID))
                return;

            decimal desVerID;
            if (!decimal.TryParse(args[2], out desVerID))
                return;

            entities.CopyVersion(oriVerID, desVerID, SessionUser.UserID);

        }
    }
    protected void VersionCompanyBaseGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');

        if (args[0] == "LoadVersionBase")
        {
            int verCompanyID;
            if (!int.TryParse(args[1], out verCompanyID))
                return;

            var list = entities.VersionCompanies.Where(v => v.VerCompanyID != verCompanyID && v.CompanyID == SessionUser.CompanyID).ToList();
            grid.DataSource = list;
            grid.DataBind();

        }

        if (args[0] == "ApplyVersionBase")
        {
            decimal verCompanyID;
            if (!decimal.TryParse(args[1], out verCompanyID))
                return;

            List<object> fieldValues = grid.GetSelectedFieldValues(new string[] { "VerCompanyID" });
            if (fieldValues.Count == 0)
                return;
            else
            {
                decimal[] versions = new decimal[4];
                int i = 0;
                foreach (object item in fieldValues)
                {
                    versions[i] = Convert.ToDecimal(item);
                    i += 1;
                    if (i > 3) break;
                }

                entities.Select_Version(verCompanyID, versions[0], versions[1], versions[2], versions[3]);
            }

        }
    }

    private string GetCompanyName(int? companyID)
    {
        try
        {
            var company = entities.DecCompanies
                .Where(x => x.CompanyID == companyID)
                .Select(x => new { CompanyID = x.CompanyID, NameV = x.NameV, AreaCode = x.AreaCode, Curr = x.Curr })
                .SingleOrDefault();
            if (company != null)
                return company.CompanyID + "-" + "(" + company.AreaCode + ")" + company.NameV + "-Currency: " + company.Curr;
        }
        catch
        {

        }
        return "";
    }


    protected void VersionCompanyUnitGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');

        if (args[0] == "LoadCompanyUnit")
        {
            decimal VersionID;
            decimal StoreId;
            if (!decimal.TryParse(args[1], out VersionID))
                return;

            if (!decimal.TryParse(args[2], out StoreId))
                return;

            var subaccount = entities.Stores.Where(s => s.StoreID == StoreId).SingleOrDefault();
            if (subaccount != null)
            {
                var list = entities.Units.Where(v => v.VersionID == VersionID && v.SubaccountID == subaccount.SubaccountID).ToList();
                grid.DataSource = list;
                grid.DataBind();
            }

        }
    }


    protected void btnPrint_Click(object sender, EventArgs e)
    {
        // decimal VerCompanyID = entities.v
        int Year = 0;
        string VerType = string.Empty;
        int VerCompanyID = 0;
        if (this.RevCostHiddenField.Contains("VerCompanyID"))
        {
            VerCompanyID = Convert.ToInt32(RevCostHiddenField.Get("VerCompanyID"));
            Session["VerCompanyID"] = VerCompanyID;
        }

        if (this.RevCostHiddenField.Contains("Year"))
        {
            Year = Convert.ToInt32(RevCostHiddenField.Get("Year"));
            Session["Year"] = Year;
        }

        if (this.RevCostHiddenField.Contains("VerType"))
        {
            VerType = RevCostHiddenField.Get("VerType").ToString();
            Session["VerType"] = VerType;
        }

        Response.Write("<script>");
        Response.Write("window.open('/Reports/Report_RevCost_Department.aspx' ,'_blank')");
        Response.Write("</script>");


    }
    // ClientUploadUnit_Click
    protected void btnUploadUnit_Click(object sender, EventArgs e)
    {
        int VerCompanyID = 0;
        if (this.RevCostHiddenField.Contains("VerCompanyID"))
        {
            VerCompanyID = Convert.ToInt32(RevCostHiddenField.Get("VerCompanyID"));
            Session["VerCompanyID"] = VerCompanyID;
        }
        else
            VerCompanyID = (int)Session["VerCompanyID"];
        //  decimal Year;

        var Year = (from v in entities.Versions
                    join vc in entities.VersionCompanies
                        on v.VersionID equals vc.VersionID
                    where vc.VerCompanyID == VerCompanyID
                    select new { Year = v.VersionYear }).FirstOrDefault();
        var VerType = (from v in entities.Versions
                       join vc in entities.VersionCompanies
                           on v.VersionID equals vc.VersionID
                       where vc.VerCompanyID == VerCompanyID
                       select new { Year = v.VersionType }).FirstOrDefault();
        Session["Year"] = Year;
        Session["VerType"] = VerType;


        Response.Write("<script>");
        Response.Write("window.open('/Imports/ImportUnitStore.aspx' ,'_blank')");
        Response.Write("</script>");
    }

    // Import RevCost
    protected void btnImportRevCost_Click(object sender, EventArgs e)
    {
        int VerCompanyID = 0;
        decimal StoreID = 0;

        int CompanyID = 0;
        int VersionID = 0;
        int SubaccountID = 0;

        if (this.RevCostHiddenField.Contains("VerCompanyID"))
        {
            VerCompanyID = Convert.ToInt32(RevCostHiddenField.Get("VerCompanyID"));
        }


        if (this.RevCostHiddenField.Contains("StoreID"))
        {
            StoreID = Convert.ToDecimal(RevCostHiddenField.Get("StoreID"));
        }


        CompanyID = Convert.ToInt32(entities.VersionCompanies.Where(vs => vs.VerCompanyID == VerCompanyID).SingleOrDefault().CompanyID);
        VersionID = Convert.ToInt32(entities.VersionCompanies.Where(vs => vs.VerCompanyID == VerCompanyID).SingleOrDefault().VersionID);
        SubaccountID = Convert.ToInt32(entities.Stores.Where(s => s.StoreID == StoreID).SingleOrDefault().SubaccountID);

        Session["CompanyID"] = CompanyID;
        Session["VersionID"] = VersionID;
        Session["SubaccountID"] = SubaccountID;


        Response.Write("<script>");
        Response.Write("window.open('/Imports/ImportQuantiy.aspx' ,'_blank');");
        Response.Write("</script>");
    }


    protected void StoresGrid_BatchUpdate(object sender, ASPxTreeListBatchUpdateEventArgs e)
    {
        try
        {
            decimal vVerCompanyID = decimal.Zero;
            foreach (var updValues in e.UpdateValues)
            {
                decimal vStoreID = Convert.ToDecimal(updValues.Keys["StoreID"]);
                var entity = entities.Stores.SingleOrDefault(x => x.StoreID == vStoreID);
                if (entity != null)
                {
                    if (vVerCompanyID == decimal.Zero)
                        vVerCompanyID = entity.VerCompanyID.Value;

                    decimal? aOutStandards = decimal.Zero;
                    decimal? aDecentralization = decimal.Zero;
                    string aReviewStatus = string.Empty;
                    string aApproveStatus = string.Empty;

                    if (updValues.NewValues["OutStandards"] != null)
                        aOutStandards = Convert.ToDecimal(updValues.NewValues["OutStandards"]);
                    else
                        aOutStandards = null;

                    if (updValues.NewValues["Decentralization"] != null)
                        aDecentralization = Convert.ToDecimal(updValues.NewValues["Decentralization"]);
                    else
                        aDecentralization = null;

                    if (updValues.NewValues["ReviewStatus"] != null)
                        aReviewStatus = updValues.NewValues["ReviewStatus"].ToString();
                    else
                        aReviewStatus = string.Empty;

                    if (updValues.NewValues["ApproveStatus"] != null)
                        aApproveStatus = updValues.NewValues["ApproveStatus"].ToString();
                    else
                        aApproveStatus = string.Empty;

                    entity.OutStandards = aOutStandards;
                    entity.Decentralization = aDecentralization;
                    entity.Amount = (aDecentralization ?? 0) + (aOutStandards ?? 0);

                    entity.ReviewStatus = aReviewStatus;
                    if (!string.IsNullOrEmpty(aReviewStatus))
                    {
                        entity.Reviewer = SessionUser.UserID;
                        entity.ReviewedDate = DateTime.Now;
                    }
                    entity.ApproveStatus = aApproveStatus;
                    if (!string.IsNullOrEmpty(aApproveStatus))
                    {
                        entity.Approver = SessionUser.UserID;
                        entity.ApprovedDate = DateTime.Now;
                    }

                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = SessionUser.UserID;

                    entities.SaveChangesWithAuditLogs();

                    UpdateStoreAmount(entity.VersionID.Value, entity.Curr, vStoreID, aOutStandards, aDecentralization);

                }
            }

            if (vVerCompanyID != decimal.Zero)
            {
                entities.CalculateSumItem(vVerCompanyID);
                entities.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            e.Handled = true;
        }
    }


    private void UpdateStoreAmount(decimal vVerId, string vCurr, decimal vStoreID, decimal? aOutStandards, decimal? aDecentralization)
    {
        decimal totalOutStandards = decimal.Zero;
        decimal totalDecentralization = decimal.Zero;

        if (aOutStandards.HasValue)
            totalOutStandards = aOutStandards.Value;

        if (aDecentralization.HasValue)
            totalDecentralization = aDecentralization.Value;

        var runningOutStandards = decimal.Zero;
        var runningDecentralization = decimal.Zero;

        var outStandardPerMonth = Math.Round(totalOutStandards / 12, 2);
        var decentralizationPerMonth = Math.Round(totalDecentralization / 12, 2);

        var dts = entities.StoreDetails
            .Where(x => x.StoreID == vStoreID)
            .OrderBy(x => x.RevCostMonth)
            .ToList();

        //for (var month = 1; month <= 12; month++)
        foreach (var dt in dts)
        {
            //if (month == 12)
            if (dt.RevCostMonth.Value == 12)
            {
                outStandardPerMonth = totalOutStandards - runningOutStandards;
                decentralizationPerMonth = totalDecentralization - runningDecentralization;
            }
            else
            {
                runningOutStandards = runningOutStandards + outStandardPerMonth;
                runningDecentralization = runningDecentralization + decentralizationPerMonth;
            }

            //var dt = entities.StoreDetails.Where(x => x.StoreID == vStoreID && x.RevCostMonth == month).FirstOrDefault();
            //if (dt != null)
            //{
            dt.OutStandards = outStandardPerMonth;
            //dt.OutStandardsVND = outStandardPerMonth * GetRoeVND(vVerId, vCurr, month);
            dt.Decentralization = decentralizationPerMonth;
            //dt.OutAfterSavingVND = outDecentralizationPerMonth * GetRoeVND(vVerId, vCurr, month);
            dt.Amount = decentralizationPerMonth + outStandardPerMonth;

            var roe = decimal.One;
            if (vCurr != "VND")
                roe = GetRoeVND(vVerId, vCurr, dt.RevCostMonth.Value);

            //roe = GetRoeVND(vVerId, vCurr, month);

            dt.AmountVND = (decentralizationPerMonth + outStandardPerMonth) * roe;
            //}
        }

        entities.SaveChangesWithAuditLogs();
    }

    protected void StoresGrid_HtmlDataCellPrepared(object sender, TreeListHtmlDataCellEventArgs e)
    {
        if (e.Column.FieldName == "Percentage01" || e.Column.FieldName == "Percentage02" || e.Column.FieldName == "Percentage03" || e.Column.FieldName == "Percentage04" || e.Column.FieldName == "Percentage05")
        {
            if (e.CellValue == null)
                return;

            if (Session[COLOR_SETTINGS] != null)
            {
                var colors = (List<ColorSettings>)Session[COLOR_SETTINGS];

                decimal value = Math.Round(((decimal)e.CellValue), 2);

                e.Cell.ForeColor = ColorTranslator.FromHtml(colors.Where(x => x.MinPercent <= value && value < x.MaxPercent).Select(x => x.Color).FirstOrDefault());
                //if (value >= 100)
                //    e.Cell.ForeColor = System.Drawing.Color.Green;
                //else if (value >= 90 && value < 100)
                //    e.Cell.ForeColor = System.Drawing.Color.Blue;
                //else if (value >= 50 && value < 90)
                //    e.Cell.ForeColor = System.Drawing.Color.Orange;
                //else if (value < 50)
                //    e.Cell.ForeColor = System.Drawing.Color.Red;
            }
        }
        else if (e.Column.FieldName == "ReviewStatus")
        {
            if (e.CellValue == null)
                return;

            if (e.CellValue.Equals("NK"))
            {
                e.Cell.ForeColor = Color.Red;
                e.Cell.Font.Bold = true;
            }
            if (e.CellValue.Equals("OK"))
            {
                e.Cell.ForeColor = Color.Blue;
                e.Cell.Font.Bold = true;
            }
        }

        //else if (e.Column.FieldName == "OutStandards")
        //{
        //    var calc = e.GetValue("Calculation");
        //    var obj = e.GetValue("OutAllowUpdate");
        //    var aOutAllowUpdate = obj != null ? Convert.ToBoolean(obj) : false;

        //    if (calc != null && !calc.Equals("SUM") && aOutAllowUpdate)
        //    {
        //        e.Cell.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
        //        e.Cell.BorderWidth = new System.Web.UI.WebControls.Unit(1, System.Web.UI.WebControls.UnitType.Pixel);
        //        e.Cell.BorderColor = Color.Green;
        //    }
        //}
        //else if (e.Column.FieldName == "Decentralization")
        //{
        //    var calc = e.GetValue("Calculation");
        //    var obj = e.GetValue("DecAllowUpdate");
        //    var aDecAllowUpdate = obj != null ? Convert.ToBoolean(obj) : false;

        //    if (calc != null && !calc.Equals("SUM") && aDecAllowUpdate)
        //    {
        //        e.Cell.BorderColor = Color.Green;
        //        e.Cell.BorderWidth = new System.Web.UI.WebControls.Unit(1, System.Web.UI.WebControls.UnitType.Pixel);
        //        e.Cell.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
        //    }
        //}
    }

    protected void RoeDataGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');

        if (args[0] == "LOAD_ROE")
        {
            decimal VersionID;

            if (!decimal.TryParse(args[1], out VersionID))
                return;

            var roes = entities.RoeVNs.Where(s => s.Ver_ID == VersionID).ToList();
            RoeDataGrid.DataSource = roes;
            RoeDataGrid.DataBind();
        }
    }

    protected void cboReviewStatus_Init(object sender, EventArgs e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        var list = GetTableValues("STORE", "REVIEW_STATUS", REVIEW_STATUS);
        cbo.DataSource = list;
        cbo.ValueField = "DefValue";
        cbo.TextField = "Description";
        cbo.DataBind();
    }

    protected void StoresGrid_CellEditorInitialize(object sender, TreeListColumnEditorEventArgs e)
    {
        if (e.Column.FieldName == "OutStandards"
          || e.Column.FieldName == "Decentralization")
        {
            if (this.VerCompanyStatus == "APPROVED" || this.VerCompanyStatus == "POSTED" || this.VersionStatus == "APPROVED")
            {
                e.Editor.BackColor = System.Drawing.ColorTranslator.FromHtml("#F4F6F9");
                e.Editor.ReadOnly = true;
            }

            //var node = StoresGrid.FindNodeByKeyValue(e.NodeKey);
            //if (node != null)
            //{
            //    var data = node.DataItem;
            //}
        }

    }
}
