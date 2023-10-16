using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.UI;

public partial class Business_RevenueCost_RevenueCostForCompany : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    string fileStorage = ConfigurationManager.AppSettings["FileStorage"];

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
        Amount = 0,
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
        if (btnChangeCompany != null)
            btnChangeCompany.ClientVisible = visible;
        if (btnNewVersionCompany != null)
            btnNewVersionCompany.ClientVisible = visible;
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
    //private void ShowHideColumnStore()
    //{
    //    this.StoresGrid.DataColumns["AmountAuto"].Visible = ShowToColumn("FA");
    //    ShowHideColumnInBand(this.StoresGrid, "OrginalAmount", ShowToColumn("FA"));
    //    ShowHideColumnInBand(this.StoresGrid, "AdjustAmount", ShowToColumn("AD"));
    //    ShowHideColumnInBand(this.StoresGrid, "SavingAmount", ShowToColumn("SA"));
    //    ShowHideColumnInBand(this.StoresGrid, "AfterSavingAmount", ShowToColumn("AS"));
    //    ShowHideColumnInBand(this.StoresGrid, "Compare", ShowToColumn("CO"));
    //    ShowHideColumnInBand(this.StoresGrid, "General", ShowToColumn("GE"));
    //}

    //private void ShowHideColumnStoreDetail()
    //{
    //    ShowHideColumnInBand(this.StoreDetailsGrid, "OrginalAmount", ShowToColumn("FA"));
    //    ShowHideColumnInBand(this.StoreDetailsGrid, "AdjustAmount", ShowToColumn("AD"));
    //    ShowHideColumnInBand(this.StoreDetailsGrid, "SavingAmount", ShowToColumn("SA"));
    //    ShowHideColumnInBand(this.StoreDetailsGrid, "AfterSavingAmount", ShowToColumn("AS"));
    //}

    //protected bool ShowToColumn(string type)
    //{
    //    return rdoAmountType.Value != null && rdoAmountType.Value == type;
    //}
    #endregion
    #region Load data
    private void LoadCompanies()
    {
        var currentCompanyID = SessionUser.CompanyID;
        if (Session[SessionConstant.CURRENT_COMPANY] != null)
            currentCompanyID = (int?)Session[SessionConstant.CURRENT_COMPANY];
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
        var list = entities.DecCompanies.Where(x => x.CompanyID != currentCompanyID && x.CompanyType == "D" && companies.Contains(x.CompanyID))
            .OrderByDescending(x => x.OriArea).ThenBy(x => x.Seq).ToList();
        this.CompanyGrid.DataSource = list;
        this.CompanyGrid.DataBind();
    }

    private void LoadVersions(string versionType, int versionYear)
    {
        Session[SessionConstant.VERSION_TYPE] = versionType;
        Session[SessionConstant.VERSION_YEAR] = versionYear;

        var list = entities.Versions
            .Where(x => x.VersionType == versionType && x.VersionYear == versionYear && x.Active == true)
            .OrderByDescending(x => x.VersionYear).OrderBy(x => x.Sorting).ToList();
        this.VersionGrid.DataSource = list;
        this.VersionGrid.DataBind();
    }


    private void LoadVersionCompany(decimal versionID)
    {
        var companyID = SessionUser.CompanyID;
        if (Session[SessionConstant.CURRENT_COMPANY] != null)
            companyID = (int?)Session[SessionConstant.CURRENT_COMPANY];

        var list = entities.VersionCompanies
            .Where(x => x.VersionID == versionID && x.CompanyID == companyID)
            .OrderByDescending(x => x.VersionNumber)
            .ToList();
        this.VersionCompanyGrid.DataSource = list;
        this.VersionCompanyGrid.DataBind();
    }

    private void LoadStores(decimal verCompanyID)
    {
        var list = entities.Stores.Where(x => x.VerCompanyID == verCompanyID).OrderByDescending(x => x.AccountGroup).ThenBy(x => x.Seq).ToList();
        this.StoresGrid.DataSource = list;
        this.StoresGrid.DataBind();
    }

    private void LoadStoreDetails(decimal storeID)
    {
        var list = entities.StoreDetails.Where(x => x.StoreID == storeID).OrderBy(x => x.Seq).ToList();
        this.StoreDetailsGrid.DataSource = list;
        this.StoreDetailsGrid.DataBind();
    }

    //private void LoadStoreFiles(decimal storeID)
    //{
    //    var list = entities.StoreFiles.Where(x => x.StoreID == storeID).ToList();
    //    this.StoreFilesGrid.DataSource = list;
    //    this.StoreFilesGrid.DataBind();
    //}

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


    private void SetPermistion()
    {
        if (!(SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR)))
        {
            btnAllocateStore.Visible = (SessionUser.IsInRole(PermissionConstant.RUN_ALLOCATE));
            btnRunAllocate.Visible = (SessionUser.IsInRole(PermissionConstant.RUN_ALLOCATE));
            btnApprove.Visible = (SessionUser.IsInRole(PermissionConstant.APPROVE_VERSION_COMPANY));
            btnUnApprove.Visible = (SessionUser.IsInRole(PermissionConstant.APPROVE_VERSION_COMPANY));

            btnPrintStore.Visible = (SessionUser.IsInRole(PermissionConstant.RUN_REPORT));
        }
        else
        {
            btnAllocateStore.Visible = true;
            btnRunAllocate.Visible = true;
            btnApprove.Visible = true;
            btnUnApprove.Visible = true;

            btnPrintStore.Visible = true;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.ShowHideButton();
        this.SetPermistion();
        if (!IsPostBack)
        {
            //Session.Remove(CURRENT_COMPANY);
            if (Session[SessionConstant.CURRENT_COMPANY] == null)
                Session[SessionConstant.CURRENT_COMPANY] = SessionUser.CompanyID;

            if (Session[SessionConstant.VERSION_TYPE] != null)
                this.rdoVersionType.Value = Session[SessionConstant.VERSION_TYPE].ToString();

            if (Session[SessionConstant.VERSION_YEAR] == null)
                this.VersionYearEditor.Value = Convert.ToInt32(Session[SessionConstant.VERSION_YEAR]);

            this.FromMonthEditor.Value = DateTime.Now.Month;
            this.ToMonthEditor.Value = DateTime.Now.Month;

            var hiddenField = this.Master.Master.FindControl("HiddenField") as ASPxHiddenField;
            hiddenField.Set("CompanyID", SessionUser.CompanyID);
            hiddenField.Set("CompanyType", SessionUser.CompanyType);
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

        if (!IsPostBack || this.StoresGrid.IsCallback)
        {
            if (this.StoresGrid.IsCallback)
            {
                if (this.GetGridCallbackType() != ASPxGridViewCallbackType.Custom)
                {
                    var verCompanyID = this.GetCallbackKeyValue("VerCompanyID");
                    this.LoadStores(verCompanyID);
                }
            }
        }

        if (this.VersionCompanyGrid.IsCallback)
        {
            if (this.GetGridCallbackType() != ASPxGridViewCallbackType.Custom)
            {
                var verID = this.GetCallbackKeyValue("VersionID");
                this.LoadVersionCompany(verID);
            }
        }

        if (this.VersionCopyGrid.IsCallback)
            this.LoadCopyVersions();

        if (this.CompanyGrid.IsCallback)
        {
            this.LoadCompanies();
        }

        if (!IsPostBack)
        {
            if (Session[SessionConstant.CURRENT_COMPANY] != null)
            {
                int companyID = Convert.ToInt32(Session[SessionConstant.CURRENT_COMPANY]);
                this.ComapnyName.Text = GetCompanyName(companyID);
            }
        }
    }

    private string GetCompanyName(int? companyID)
    {
        try
        {
            var company = entities.DecCompanies
                .Where(x => x.CompanyID == companyID)
                .Select(x => new { CompanyID = x.CompanyID, NameV = x.NameV, AreaCode = x.AreaCode, FASTCode = x.FASTCode })
                .SingleOrDefault();
            if (company != null)
                return company.CompanyID + "-" + "(" + company.AreaCode + ":" + company.FASTCode + ")" + company.NameV;
        }
        catch
        {

        }
        return "";
    }
    private decimal GetCallbackKeyValue(string keyStr)
    {
        string result = null;
        if (Utils.TryGetClientStateValue<string>(this, keyStr, out result))
            return Convert.ToDecimal(result);
        return decimal.Zero;
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

            var version = entities.Versions.SingleOrDefault(x => x.VersionID == versionID);
            if (version != null)
                s.JSProperties["cpVersionType"] = version.VersionType;
            else
                s.JSProperties["cpVersionType"] = "";

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

            s.JSProperties["cpCompanyName"] = this.GetCompanyName(companyID);

            Session[SessionConstant.CURRENT_COMPANY] = companyID;

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

            int companyID = (int)SessionUser.CompanyID;
            if (Session[SessionConstant.CURRENT_COMPANY] != null)
                companyID = (int)Session[SessionConstant.CURRENT_COMPANY];

            entities.CreateVersionCompany(versionID, companyID, SessionUser.UserID);
            LoadVersionCompany(versionID);
        }

        if (args[0] == "SetWorkingVersion")
        {
            decimal verCompanyID;
            if (!decimal.TryParse(args[1], out verCompanyID))
                return;

            var entity = entities.VersionCompanies.SingleOrDefault(x => x.VerCompanyID == verCompanyID);
            if (entity == null)
                return;

            int companyID = (int)entity.CompanyID;
            decimal versionID = (decimal)entity.VersionID;
            if (entity.HotData.HasValue && entity.HotData.Value)
            {
                LoadVersionCompany(versionID);
                return;
            }

            entity.HotData = true;

            var friends = entities.VersionCompanies.Where(x => x.VersionID == versionID && x.VerCompanyID != verCompanyID && x.CompanyID == companyID).ToList();
            friends.ForEach(a => a.HotData = false);

            entities.SaveChanges();

            LoadVersionCompany(versionID);
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

            int companyID = (int)entity.CompanyID;

            entity.ApprovedNote = VerCompanyApproveNoteEditor.Text;
            entity.ReviewedNote = VerCompanyReviewNoteEditor.Text;
            entity.Description = VerCompanyDescriptionEditor.Text;
            entity.HotData = chkHotData.Checked;
            //Neu set hotdata thi update cac version company khac inactive
            if (chkHotData.Checked)
            {
                var friends = entities.VersionCompanies.Where(x => x.VersionID == versionID && x.VerCompanyID != verCompanyID && x.CompanyID == companyID).ToList();
                friends.ForEach(a => a.HotData = false);
            }

            entities.SaveChanges();

            LoadVersionCompany(versionID);
        }


        if (args[0] == "ApproveUnApproved")
        {
            decimal verCompanyID;
            if (!decimal.TryParse(args[1], out verCompanyID))
                return;

            var verCompany = entities.VersionCompanies.SingleOrDefault(x => x.VerCompanyID == verCompanyID);
            if (verCompany != null)
            {
                verCompany.Status = verCompany.Status == "APPROVED" ? "UNAPPROVED" : "APPROVED";
                verCompany.ApproveStatus = verCompany.ApproveStatus == "APPROVED" ? "UNAPPROVED" : "APPROVED";
                verCompany.ApprovedDate = DateTime.Now;
                verCompany.Approver = SessionUser.UserID;
                verCompany.ApprovedNote = ApproveNoteEditor.Text;
                verCompany.HotData = verCompany.Status == "APPROVED" ? false : true;
                entities.SaveChanges();

                LoadVersionCompany((decimal)verCompany.VersionID);
            }
        }

    }

    protected void StoresGrid_CustomCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomCallbackEventArgs e)
    {
        ASPxTreeList s = sender as ASPxTreeList;

        string[] args = e.Argument.Split('|');

        s.JSProperties["cpCommand"] = args[0];

        if (args[0] == "LoadStore" || args[0] == "RefreshStore")
        {
            decimal verCompanyID;
            if (!decimal.TryParse(args[1], out verCompanyID))
                return;

            LoadStores(verCompanyID);
            if (args[0] == "LoadStore")
                this.StoresGrid.ExpandAll();

            EnableOrDisableControl(verCompanyID);
        }

        if (args[0] == "CalculateStore")
        {
            decimal verCompanyID;
            if (!decimal.TryParse(args[1], out verCompanyID))
                return;

            entities.CalculateSumItem(verCompanyID);
            entities.SaveChanges();

            LoadStores(verCompanyID);

            EnableOrDisableControl(verCompanyID);
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

            entities.SaveChanges();

            EnableOrDisableControl((decimal)entity.VerCompanyID);
        }


        if (args[0] == "RunAllocate")
        {
            decimal verCompanyID;
            if (!decimal.TryParse(args[1], out verCompanyID))
                return;

            var verCompany = entities.VersionCompanies.SingleOrDefault(x => x.VerCompanyID == verCompanyID);
            if (verCompany == null) return;
            var versionID = verCompany.VersionID;
            var version = entities.Versions.SingleOrDefault(x => x.VersionID == versionID);
            if (version == null) return;

            int fromMonth = Convert.ToInt32(this.FromMonthEditor.Number);
            int toMonth = Convert.ToInt32(this.ToMonthEditor.Number);
            bool allocateMonthlyOnbyOne = chkAllocateOnByOne.Checked;
            bool runAggregate = chkRunAggregate.Checked;

            //if (version.VersionType != "P")
            if (allocateMonthlyOnbyOne)
                entities.Pr_Allocate(version.VersionID, verCompany.CompanyID, verCompany.VerCompanyID, fromMonth, toMonth, version.VersionYear);
            else
                entities.Pr_AllocateV2(version.VersionID, verCompany.CompanyID, verCompany.VerCompanyID, fromMonth, toMonth, version.VersionYear);
            //else
            //    entities.Plan_Pr_Allocate(version.VersionID, verCompany.CompanyID, verCompany.VerCompanyID, null, null);

            entities.SaveChanges();

            if (runAggregate)
            {
                string areaCode = SessionUser.AreaCode;
                areaCode = entities.DecCompanies.Where(x => x.CompanyID == verCompany.CompanyID).Select(x => x.OriArea).SingleOrDefault();

                entities.AppendRouteProfitFactV3(versionID, areaCode, fromMonth, toMonth);
            }

            LoadStores(verCompanyID);

            EnableOrDisableControl(verCompany.Status);
        }

        if (args[0] == "RunAllocateAll")
        {
            decimal verCompanyID;
            if (!decimal.TryParse(args[1], out verCompanyID))
                return;

            var verCompany = entities.VersionCompanies.SingleOrDefault(x => x.VerCompanyID == verCompanyID);
            if (verCompany == null) return;
            var versionID = verCompany.VersionID;
            var version = entities.Versions.SingleOrDefault(x => x.VersionID == versionID);
            if (version == null) return;

            int fromMonth = Convert.ToInt32(this.FromMonthEditor.Number);
            int toMonth = Convert.ToInt32(this.ToMonthEditor.Number);
            bool allocateMonthlyOnbyOne = chkAllocateOnByOne.Checked;
            bool runAggregate = chkRunAggregate.Checked;

            if (allocateMonthlyOnbyOne)
                //if (version.VersionType != "P")
                entities.Run_Allocate_All(version.VersionID, fromMonth, toMonth, version.VersionYear);
            //else
            //    entities.Plan_Run_Allocate_All(version.VersionID, fromMonth, toMonth, version.VersionYear);
            else
                entities.Run_Allocate_AllV2(version.VersionID, fromMonth, toMonth, version.VersionYear);

            entities.SaveChanges();

            if (runAggregate)
            {
                string areaCode = SessionUser.AreaCode;
                areaCode = entities.DecCompanies.Where(x => x.CompanyID == verCompany.CompanyID).Select(x => x.OriArea).SingleOrDefault();

                entities.AppendRouteProfitFactV3(versionID, areaCode, fromMonth, toMonth);
            }

            LoadStores(verCompanyID);

            EnableOrDisableControl(verCompany.Status);
        }

        if (args[0] == "RunAllocate1Store")
        {
            decimal verCompanyID;
            decimal storeID;

            if (!decimal.TryParse(args[1], out verCompanyID))
                return;

            if (!decimal.TryParse(args[2], out storeID))
                return;

            var verCompany = entities.VersionCompanies.SingleOrDefault(x => x.VerCompanyID == verCompanyID);
            if (verCompany == null) return;
            var versionID = verCompany.VersionID;
            var version = entities.Versions.SingleOrDefault(x => x.VersionID == versionID);
            if (version == null) return;

            var store = entities.Stores.SingleOrDefault(x => x.StoreID == storeID);
            if (store == null) return;

            int fromMonth = Convert.ToInt32(this.FromMonthEditor.Number);
            int toMonth = Convert.ToInt32(this.ToMonthEditor.Number);
            bool allocateMonthlyOnbyOne = chkAllocateOnByOne.Checked;
            bool runAggregate = chkRunAggregate.Checked;

            if (allocateMonthlyOnbyOne)
                for (int i = fromMonth; i <= toMonth; i++)
                {
                    var amount = entities.StoreDetails.Where(x => x.StoreID == store.StoreID && x.RevCostMonth == i).Select(x => x.Amount).SingleOrDefault();

                    //if (version.VersionType != "P")


                    //if (version.VersionType != "P")

                    entities.Allocate_1Store(versionID, verCompany.CompanyID, verCompany.VerCompanyID, store.SubaccountID, storeID, store.ActivityID,
                                             store.ACID, store.Airports, store.AllocatedFLT, store.AllocatedRT, store.AllocatedDriver, store.Carrier,
                                             store.RepID, amount, store.Curr, i, store.AccountGroup, version.VersionYear, store.Division, store.Network, 
                                             store.AllocateFltDirection, store.FleetType, store.OriCountry, store.DesCountry, store.Ori, store.Des);

                    //else
                    //    entities.Plan_Allocate_1Store(versionID, verCompany.CompanyID, verCompany.VerCompanyID, store.SubaccountID, storeID, store.ActivityID,
                    //                      store.ACID, store.Airports, store.AllocatedFLT, store.AllocatedRT, store.AllocatedDriver, store.Carrier,
                    //                      store.RepID, amount, store.Curr, i, string.Empty, version.VersionYear, store.Division, store.Network, store.AllocateFltDirection);
                }
            else
            {
                var amount = entities.StoreDetails.Where(x => x.StoreID == store.StoreID && x.RevCostMonth >= fromMonth && x.RevCostMonth <= toMonth).Select(x => x.Amount).Sum();

                entities.Allocate_1StoreV2(versionID, verCompany.CompanyID, verCompany.VerCompanyID, store.SubaccountID, storeID, store.ActivityID,
                     store.ACID, store.Airports, store.AllocatedFLT, store.AllocatedRT, store.AllocatedDriver, store.Carrier,
                     store.RepID, amount, store.Curr, fromMonth, toMonth, store.AccountGroup, version.VersionYear, store.Division, store.Network, store.AllocateFltDirection);
            }

            entities.SaveChanges();

            if (runAggregate)
            {
                string areaCode = SessionUser.AreaCode;
                areaCode = entities.DecCompanies.Where(x => x.CompanyID == verCompany.CompanyID).Select(x => x.OriArea).SingleOrDefault();

                entities.AppendRouteProfitFactV4(versionID, areaCode, store.SubaccountID, fromMonth, toMonth);
            }

            LoadStores(verCompanyID);

            EnableOrDisableControl(verCompany.Status);
        }
    }

    private void EnableOrDisableControl(string status)
    {
        btnCalculateStore.Enabled = status != "APPROVED";
        btnAllocateStore.Enabled = status != "APPROVED";
    }

    private void EnableOrDisableControl(decimal verCompanyID)
    {
        var verCompany = entities.VersionCompanies.SingleOrDefault(x => x.VerCompanyID == verCompanyID);
        if (verCompany != null)
        {
            btnCalculateStore.Enabled = verCompany.Status != "APPROVED";
            btnAllocateStore.Enabled = verCompany.Status != "APPROVED";
        }
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
            if (storeID == decimal.Zero)
            {
                LoadStoreDetails(storeID);
                return;
            }

            var store = entities.Stores.SingleOrDefault(x => x.StoreID == storeID);
            if (store != null && store.Calculation == "DATA")
                entities.InitStoreDetail(storeID, SessionUser.UserID);

            LoadStoreDetails(storeID);

            //var verCompany = entities.VersionCompanies.SingleOrDefault(x => x.VerCompanyID == store.VerCompanyID);
            //if (verCompany != null)
            //{
            //    ASPxButton btnSaveStoreDetail = (ASPxButton)grid.FindStatusBarTemplateControl("btnSaveStoreDetail");
            //    if (btnSaveStoreDetail != null)
            //        btnSaveStoreDetail.Enabled = verCompany.ApproveStatus != "APPROVED";
            //}

        }

        if (args[0] == "Allocate")
        {
            decimal storeID;
            if (!decimal.TryParse(args[1], out storeID))
                return;

            var col1 = AllocateColumn.Amount;
            //var col2 = AllocateColumn.Outstandard;
            //var col3 = AllocateColumn.Decentralization;
            var amountType = AmountType.FinalAmount;

            ASPxRoundPanel RoundPanel = (ASPxRoundPanel)grid.FindTitleTemplateControl("AllocateRoundPanel");
            if (RoundPanel == null) return;

            ASPxFormLayout FormLayout = (ASPxFormLayout)RoundPanel.FindControl("AllocateForm");
            if (FormLayout == null) return;

            ASPxSpinEdit Q1Instandard = (ASPxSpinEdit)FormLayout.FindControl("Q1AmountEditor");
            //ASPxSpinEdit Q1Outstandard = (ASPxSpinEdit)FormLayout.FindControl("Q1OutstandardEditor");
            //ASPxSpinEdit Q1Decentralization = (ASPxSpinEdit)FormLayout.FindControl("Q1DecentralizationEditor");

            ASPxSpinEdit Q2Instandard = (ASPxSpinEdit)FormLayout.FindControl("Q2AmountEditor");
            //ASPxSpinEdit Q2Outstandard = (ASPxSpinEdit)FormLayout.FindControl("Q2OutstandardEditor");
            //ASPxSpinEdit Q2Decentralization = (ASPxSpinEdit)FormLayout.FindControl("Q2DecentralizationEditor");

            ASPxSpinEdit Q3Instandard = (ASPxSpinEdit)FormLayout.FindControl("Q3AmountEditor");
            //ASPxSpinEdit Q3Outstandard = (ASPxSpinEdit)FormLayout.FindControl("Q3OutstandardEditor");
            //ASPxSpinEdit Q3Decentralization = (ASPxSpinEdit)FormLayout.FindControl("Q3DecentralizationEditor");

            ASPxSpinEdit Q4Instandard = (ASPxSpinEdit)FormLayout.FindControl("Q4AmountEditor");
            //ASPxSpinEdit Q4Outstandard = (ASPxSpinEdit)FormLayout.FindControl("Q4OutstandardEditor");
            //ASPxSpinEdit Q4Decentralization = (ASPxSpinEdit)FormLayout.FindControl("Q4DecentralizationEditor");

            ASPxSpinEdit YearInstandard = (ASPxSpinEdit)FormLayout.FindControl("YearAmountEditor");
            //ASPxSpinEdit YearOutstandard = (ASPxSpinEdit)FormLayout.FindControl("YearOutstandardEditor");
            //ASPxSpinEdit YearDecentralization = (ASPxSpinEdit)FormLayout.FindControl("YearDecentralizationEditor");

            var storeDetails = entities.StoreDetails.Where(x => x.StoreID == storeID).OrderBy(x => x.RevCostMonth).ToList();
            if (storeDetails == null || storeDetails.Count <= 0)
                return;

            AllocateStoreDetail(Q1Instandard, storeDetails, amountType, AllocateType.Q1, col1);
            //AllocateStoreDetail(Q1Outstandard, storeDetails, amountType, AllocateType.Q1, col2);
            //AllocateStoreDetail(Q1Decentralization, storeDetails, amountType, AllocateType.Q1, col3);

            AllocateStoreDetail(Q2Instandard, storeDetails, amountType, AllocateType.Q2, col1);
            //AllocateStoreDetail(Q2Outstandard, storeDetails, amountType, AllocateType.Q2, col2);
            //AllocateStoreDetail(Q2Decentralization, storeDetails, amountType, AllocateType.Q2, col3);

            AllocateStoreDetail(Q3Instandard, storeDetails, amountType, AllocateType.Q3, col1);
            //AllocateStoreDetail(Q3Outstandard, storeDetails, amountType, AllocateType.Q3, col2);
            //AllocateStoreDetail(Q3Decentralization, storeDetails, amountType, AllocateType.Q3, col3);

            AllocateStoreDetail(Q4Instandard, storeDetails, amountType, AllocateType.Q4, col1);
            //AllocateStoreDetail(Q4Outstandard, storeDetails, amountType, AllocateType.Q4, col2);
            //AllocateStoreDetail(Q4Decentralization, storeDetails, amountType, AllocateType.Q4, col3);

            AllocateStoreDetail(YearInstandard, storeDetails, amountType, AllocateType.Y, col1);
            //AllocateStoreDetail(YearOutstandard, storeDetails, amountType, AllocateType.Y, col2);
            //AllocateStoreDetail(YearDecentralization, storeDetails, amountType, AllocateType.Y, col3);

            entities.SaveChanges();

            foreach (var entity in storeDetails)
            {
                entities.CalcStoreDetailAfterSavingAmt(entity.StoreDetailID);
            }

            //Update Stores/Load Store detail

            UpdateStore(storeID);

            LoadStoreDetails(storeID);

        }

        if (args[0] == "Posted")
        {
            decimal storeDetailID;
            if (!decimal.TryParse(args[1], out storeDetailID))
                return;

            var isOK = args[2];

            var entity = entities.StoreDetails.SingleOrDefault(x => x.StoreDetailID == storeDetailID);
            if (entity == null) return;
            entity.Posted = Convert.ToBoolean(isOK);
            entity.PosteDate = DateTime.Now;
            entity.PostedBy = SessionUser.UserID;

            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = SessionUser.UserID;

            entities.SaveChanges();
        }
    }

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
            if (column == AllocateColumn.Amount)
            {
                if (entity.RevCostMonth >= fromMonth && entity.RevCostMonth < toMonth)
                    entity.Amount = average;
                else
                    entity.Amount = lastMonth;
            }
            //if (column == AllocateColumn.Instandard)
            //    entity.InStandards = average;
            //if (column == AllocateColumn.Outstandard)
            //    entity.OutStandards = average;
            //if (column == AllocateColumn.Decentralization)
            //    entity.Decentralization = average;
            //if (column == AllocateColumn.InAdjust)
            //    entity.InAdjust = average;
            //if (column == AllocateColumn.OutAdjust)
            //    entity.OutAdjust = average;
            //if (column == AllocateColumn.DecAdjust)
            //    entity.DecAdjust = average;
            //if (column == AllocateColumn.InSaving)
            //    entity.InSaving = average;
            //if (column == AllocateColumn.OutSaving)
            //    entity.OutSaving = average;
            //if (column == AllocateColumn.DecSaving)
            //    entity.DecSaving = average;

            //entities.CalcStoreDetailAfterSavingAmt(entity.StoreDetailID);
        }
    }
    protected void StoresGrid_HtmlRowPrepared(object sender, DevExpress.Web.ASPxTreeList.TreeListHtmlRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("Calculation"), "SUM"))
        {
            e.Row.Font.Bold = true;
        }
    }
    protected void StoreDetailPosted_Init(object sender, EventArgs e)
    {
        ASPxCheckBox chk = sender as ASPxCheckBox;
        GridViewDataItemTemplateContainer container = chk.NamingContainer as GridViewDataItemTemplateContainer;
        chk.ClientSideEvents.ValueChanged = String.Format("function(s, e) {{ RevCost.ClientStoreDetailPosted_ValueChanged({0}, s.GetChecked());}}", container.KeyValue);
    }
    protected void StoreIsOK_Init(object sender, EventArgs e)
    {
        ASPxCheckBox chk = sender as ASPxCheckBox;
        GridViewDataItemTemplateContainer container = chk.NamingContainer as GridViewDataItemTemplateContainer;
        chk.ClientSideEvents.ValueChanged = String.Format("function(s, e) {{ RevCost.ClientStoreIsOK_ValueChanged({0}, s.GetChecked());}}", container.KeyValue);
    }

    protected void StoreDetailsGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        decimal storeID = decimal.Zero;
        try
        {
            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                //decimal? instandard = null;
                //decimal? outstandard = null;
                //decimal? decentralization = null;
                decimal? amount = null;
                //decimal? total = null;

                decimal vStoreDetailID = Convert.ToDecimal(updValues.Keys["StoreDetailID"]);
                var entity = entities.StoreDetails.SingleOrDefault(x => x.StoreDetailID == vStoreDetailID);
                if (entity != null)
                {
                    if (updValues.NewValues["Amount"] != null)
                        amount = Convert.ToDecimal(updValues.NewValues["Amount"]);

                    //if (updValues.NewValues["InStandards"] != null)
                    //    instandard = Convert.ToDecimal(updValues.NewValues["InStandards"]);
                    //if (updValues.NewValues["OutStandards"] != null)
                    //    outstandard = Convert.ToDecimal(updValues.NewValues["OutStandards"]);
                    //if (updValues.NewValues["Decentralization"] != null)
                    //    decentralization = Convert.ToDecimal(updValues.NewValues["Decentralization"]);

                    //total = (instandard ?? 0) + (outstandard ?? 0) + (decentralization ?? 0);
                    //entity.InStandards = instandard;
                    //entity.OutStandards = outstandard;
                    //entity.Decentralization = decentralization;
                    entity.Amount = amount;

                    if (updValues.NewValues["Posted"] != null)
                    {
                        var posted = Convert.ToBoolean(updValues.NewValues["Posted"]);
                        entity.Posted = posted;
                    }

                    if (storeID == decimal.Zero)
                        storeID = (decimal)entity.StoreID;

                    entities.SaveChanges();

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
        catch (Exception ex) { }
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
                                Amount = g.Sum(c => c.Amount),
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
                //store.InStandards = sumStoreDetail.InStandards;
                //store.OutStandards = sumStoreDetail.OutStandards;
                //store.Decentralization = sumStoreDetail.Decentralization;
                //store.Amount = (sumStoreDetail.InStandards ?? 0)
                //    + (sumStoreDetail.OutStandards ?? 0)
                //    + (sumStoreDetail.Decentralization ?? 0);

                //store.InAdjust = sumStoreDetail.InAdjust;
                //store.OutAdjust = sumStoreDetail.OutAdjust;
                //store.DecAdjust = sumStoreDetail.DecAdjust;
                //store.Adjust = (sumStoreDetail.InAdjust ?? 0)
                //    + (sumStoreDetail.OutAdjust ?? 0)
                //    + (sumStoreDetail.DecAdjust ?? 0);

                //store.InSaving = sumStoreDetail.InSaving;
                //store.OutSaving = sumStoreDetail.OutSaving;
                //store.DecSaving = sumStoreDetail.DecSaving;
                //store.Saving = (sumStoreDetail.InSaving ?? 0)
                //    + (sumStoreDetail.OutSaving ?? 0)
                //    + (sumStoreDetail.DecSaving ?? 0);

                //store.InAfterSaving = sumStoreDetail.InAfterSaving;
                //store.OutAfterSaving = sumStoreDetail.OutAfterSaving;
                //store.DecAfterSaving = sumStoreDetail.DecAfterSaving;
                //store.AfterSaving = (sumStoreDetail.InAfterSaving ?? 0)
                //    + (sumStoreDetail.OutAfterSaving ?? 0)
                //    + (sumStoreDetail.InAfterSaving ?? 0);

                store.Amount = sumStoreDetail.Amount;
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
        if (e.Column.FieldName == "RevCostMonth")
            e.Editor.ReadOnly = true;

        //if (e.Column.FieldName == "InAfterSaving"
        //    || e.Column.FieldName == "OutAfterSaving"
        //    || e.Column.FieldName == "DecAfterSaving")
        //{
        //    e.Editor.ClientVisible = false;
        //    e.Editor.ReadOnly = true;
        //}

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

    //protected void StoreFilesUploadControl_FilesUploadComplete(object sender, FilesUploadCompleteEventArgs e)
    //{
    //    for (int i = 0; i < StoreFilesUploadControl.UploadedFiles.Length; i++)
    //    {
    //        UploadedFile file = StoreFilesUploadControl.UploadedFiles[i];

    //        if (file.FileName != "" && file.IsValid)
    //        {
    //            try
    //            {
    //                string fileName = Path.Combine(fileStorage + @"StoreFiles\", file.FileName);
    //                if (File.Exists(fileName))
    //                {
    //                    e.CallbackData = "error";
    //                    e.ErrorText = "File name already exists. Please rename before upload.";
    //                    return;
    //                }

    //                SaveFile(fileName, file);

    //                e.CallbackData = fileName;
    //            }
    //            catch (Exception ex)
    //            {
    //                e.CallbackData = "error";
    //                e.ErrorText = ex.Message;
    //            }
    //        }
    //    }
    //}
    //protected void StoreFilesGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    //{
    //    ASPxGridView grid = sender as ASPxGridView;
    //    string[] args = e.Parameters.Split('|');
    //    if (args[0] == "LoadStoreFiles")
    //    {
    //        decimal storeID;
    //        if (!decimal.TryParse(args[1], out storeID))
    //            return;

    //        LoadStoreFiles(storeID);
    //    }
    //    else if (args[0] == "SaveStoreFile")
    //    {
    //        decimal storeID;
    //        if (!decimal.TryParse(args[1], out storeID))
    //            return;

    //        var filePath = args[2];

    //        FileInfo fi = new FileInfo(filePath);

    //        var entity = new StoreFile();
    //        entity.FileName = fi.Name;
    //        entity.FilePath = filePath;
    //        entity.StoreID = storeID;

    //        entity.CreateDate = DateTime.Now;
    //        entity.CreatedBy = (int)SessionUser.UserID;

    //        entities.StoreFiles.Add(entity);

    //        entities.SaveChanges();

    //        LoadStoreFiles(storeID);
    //    }
    //}
    //protected void StoreFilesGrid_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
    //{
    //    ASPxGridView grid = sender as ASPxGridView;
    //    if (e.Column.FieldName == "FileName")
    //        e.Editor.ReadOnly = true;
    //}
    //protected void StoreFilesGrid_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
    //{
    //    ASPxGridView grid = sender as ASPxGridView;
    //    decimal storeID = decimal.Zero;
    //    try
    //    {
    //        foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
    //        {
    //            decimal vStoreFilelID = Convert.ToDecimal(updValues.Keys["StoreFileID"]);
    //            var entity = entities.StoreFiles.SingleOrDefault(x => x.StoreFileID == vStoreFilelID);
    //            if (entity != null)
    //            {
    //                if (updValues.NewValues["Description"] != null)
    //                {
    //                    string description = updValues.NewValues["Description"].ToString();
    //                    entity.Description = description;
    //                }

    //                if (storeID == decimal.Zero)
    //                    storeID = (decimal)entity.StoreID;
    //            }
    //        }
    //        entities.SaveChanges();
    //        LoadStoreFiles(storeID);
    //    }
    //    catch (Exception ex) { }
    //    finally
    //    {
    //        e.Handled = true;
    //    }
    //}
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
            result["HotData"] = entity.HotData.HasValue && entity.HotData.Value ? "True" : "False";
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
            decimal verCompanyID;
            if (!decimal.TryParse(args[1], out verCompanyID))
                return;

            decimal versionID;
            if (!decimal.TryParse(args[2], out versionID))
                return;

            var verCompany = entities.VersionCompanies.Where(x => x.VerCompanyID == verCompanyID).FirstOrDefault();

            entities.CopyVersionCompany(verCompanyID, verCompany.VerLevel, versionID, SessionUser.UserID);


        }

        if (args[0] == "CopyVersion")
        {
            decimal desVerID;
            if (!decimal.TryParse(args[1], out desVerID))
                return;

            decimal srcVerID;
            if (!decimal.TryParse(args[2], out srcVerID))
                return;

            entities.CopyVersion(srcVerID, desVerID, SessionUser.UserID);

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

            var list = entities.VersionCompanies.Where(v => v.VerCompanyID != verCompanyID).ToList();
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


    protected void RevCostCallback_Callback(object source, CallbackEventArgs e)
    {
        var args = e.Parameter.Split('|');
        if (args[0] == "CheckVerCompanyStatus")
        {
            decimal verCompanyID;
            if (!decimal.TryParse(args[1], out verCompanyID))
                return;

            var ver = entities.VersionCompanies.SingleOrDefault(v => v.VerCompanyID == verCompanyID);
            if (ver == null)
            {
                e.Result = "FAIL";
                return;
            }
            e.Result = ver.ApproveStatus;
        }
    }
    protected void VersionCompanyGrid_FillContextMenuItems(object sender, ASPxGridViewContextMenuEventArgs e)
    {
        if (e.MenuType == GridViewContextMenuType.Rows)
        {
            var item = e.CreateItem("New", "NewVerCompany");
            item.Image.Url = "../../Content/images/SpinEditPlus.png";
            e.Items.Insert(e.Items.IndexOfCommand(GridViewContextMenuCommand.Refresh), item);
            item = e.CreateItem("Copy", "CopyVerCompany");
            item.Image.Url = "../../Content/images/if_simpline_4_2305586.png";
            e.Items.Insert(e.Items.IndexOfCommand(GridViewContextMenuCommand.Refresh), item);
            item = e.CreateItem("Duplicate", "DuplicateVerCompany");
            item.Image.Url = "../../Content/images/duplicate.png";
            e.Items.Insert(e.Items.IndexOfCommand(GridViewContextMenuCommand.Refresh), item);
            item = e.CreateItem("Set working version", "SetWorkingVersion");
            item.BeginGroup = true;
            item.Image.Url = "../../Content/images/tick.png";
            e.Items.Insert(e.Items.IndexOfCommand(GridViewContextMenuCommand.Refresh), item);

        }
    }
    protected void VersionGrid_FillContextMenuItems(object sender, ASPxGridViewContextMenuEventArgs e)
    {
        if (e.MenuType == GridViewContextMenuType.Rows)
        {
            var item = e.CreateItem("Copy", "CopyVersion");
            item.Image.Url = "../../Content/images/if_simpline_4_2305586.png";
            e.Items.Insert(e.Items.IndexOfCommand(GridViewContextMenuCommand.Refresh), item);

        }
    }
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.GetGridCallbackType() != ASPxGridViewCallbackType.Custom)
            {
                var verCompanyID = this.GetCallbackKeyValue("VerCompanyID");
                this.LoadStores(verCompanyID);
            }
            ASPxTreeListExporter1.WriteXlsToResponse(true);
        }
        catch (Exception ex) { }
    }
}


