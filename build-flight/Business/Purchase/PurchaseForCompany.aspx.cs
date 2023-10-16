using DevExpress.Web;
using DevExpress.Web.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using KTQTData;

public partial class Business_RevenueCost_RevenueCostForCompany : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    string fileStorage = ConfigurationManager.AppSettings["FileStorage"];

    const string CURRENT_COMPANY = "618202CB-2F41-4A51-ABB7-254E91B9EB34";

    private string StoreStatus;


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
        ASPxButton btnChangeCompany = (ASPxButton)this.VersionGrid.FindStatusBarTemplateControl("btnChangeCompany");
        //ASPxButton btnNewVersionCompany = (ASPxButton)this.VersionCompanyGrid.FindTitleTemplateControl("btnNewVersionCompany");
        bool visible = SessionUser.CompanyType == "K";
        if (btnNewVersion != null)
            btnNewVersion.ClientVisible = visible;
        if (btnChangeCompany != null)
            btnChangeCompany.ClientVisible = visible;
        //if (btnNewVersionCompany != null)
        //btnNewVersionCompany.ClientVisible = visible;
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
    private void ShowHideColumnStore()
    {
        //this.StoresGrid.DataColumns["AmountAuto"].Visible = ShowToColumn("FA");
        /*ShowHideColumnInBand(this.StoresGrid, "OrginalAmount", ShowToColumn("FA"));
        ShowHideColumnInBand(this.StoresGrid, "AdjustAmount", ShowToColumn("AD"));
        ShowHideColumnInBand(this.StoresGrid, "SavingAmount", ShowToColumn("SA"));
        ShowHideColumnInBand(this.StoresGrid, "AfterSavingAmount", ShowToColumn("AS"));
        ShowHideColumnInBand(this.StoresGrid, "Compare", ShowToColumn("CO"));
        ShowHideColumnInBand(this.StoresGrid, "General", ShowToColumn("GE"));*/
    }

    private void ShowHideColumnStoreDetail()
    {
        /*ShowHideColumnInBand(this.StoreDetailsGrid, "OrginalAmount", ShowToColumn("FA"));
        ShowHideColumnInBand(this.StoreDetailsGrid, "AdjustAmount", ShowToColumn("AD"));
        ShowHideColumnInBand(this.StoreDetailsGrid, "SavingAmount", ShowToColumn("SA"));
        ShowHideColumnInBand(this.StoreDetailsGrid, "AfterSavingAmount", ShowToColumn("AS"));*/
    }

    /*protected bool ShowToColumn(string type)
    {
        return rdoAmountType.Value != null && rdoAmountType.Value == type;
    }*/
    #endregion
    #region Load data
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
        var list = entities.Versions.Where(x => x.VersionType == versionType && x.VersionYear == versionYear).OrderByDescending(x => x.VersionYear).OrderBy(x => x.Sorting).ToList();
        this.VersionGrid.DataSource = list;
        this.VersionGrid.DataBind();
    }


    private void LoadPurchaseLvl()
    {
        var list = entities.PurchaseLevels.OrderBy(x => x.SEQ).ToList();
        this.PurchaseLVLGrid.DataSource = list;
        this.PurchaseLVLGrid.DataBind();
    }

    private void LoadPurchase(decimal versionId, decimal verCompanyID, decimal purchaselvlid)
    {
        var list = entities.PURCHASEs.Where(x => x.VER_ID == versionId).Where(x => x.VER_COMPANY_ID == verCompanyID).Where(y => y.PURCHASE_LEVEL_ID == purchaselvlid).OrderBy(x => x.SEQ).ToList();
        this.PurchaseGrid.DataSource = list;
        this.PurchaseGrid.DataBind();
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
        var list = entities.Stores.Where(x => x.VerCompanyID == verCompanyID).OrderByDescending(x => x.AccountGroup).ThenBy(x => x.Seq).ToList();
        //this.StoresGrid.DataSource = list;
        //this.StoresGrid.DataBind();

    }

    private void LoadStoreDetails(decimal storeID)
    {
        var list = entities.StoreDetails.Where(x => x.StoreID == storeID).OrderBy(x => x.Seq).ToList();
        //this.StoreDetailsGrid.DataSource = list;
        //this.StoreDetailsGrid.DataBind();
    }

    private void LoadStoreFiles(decimal storeID)
    {
        var list = entities.StoreFiles.Where(x => x.StoreID == storeID).ToList();
        //this.StoreFilesGrid.DataSource = list;
        //this.StoreFilesGrid.DataBind();
    }

    private void LoadVerCompanyFiles(decimal verCompanyID)
    {
        var list = entities.VersionCompanyFiles.Where(x => x.VerCompanyID == verCompanyID).ToList();
        this.VersionCompanyFilesGrid.DataSource = list;
        this.VersionCompanyFilesGrid.DataBind();
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

    protected void PurchaseItemEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DEC_PURCHASE_ITEM.OrderBy(x => x.ID).ToList();
        s.DataSource = list;
        s.ValueField = "ID";
        s.TextField = "PURCHASE_ITEM_NAME";
        s.DataBind();
    }


    protected void PurchaseFormEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DEC_PURCHASE_FORM.OrderBy(x => x.ID).ToList();
        s.DataSource = list;
        s.ValueField = "ID";
        s.TextField = "DESCRIPTION";
        s.DataBind();
    }

    protected void SupplierEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DEC_SUPPLIER.OrderBy(x => x.ID).ToList();
        s.DataSource = list;
        s.ValueField = "ID";
        s.TextField = "SUP_NAME";
        s.DataBind();
    }

    /*private void LoadCopyVersions()
    {
        var list = entities.Versions.OrderByDescending(x => x.VersionYear).OrderBy(x => x.Sorting).ToList();
        this.VersionCopyGrid.DataSource = list;
        this.VersionCopyGrid.DataBind();
    }*/
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        this.ShowHideButton();

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
            this.LoadPurchaseLvl();

            if (rdoVersionType.Value != null && this.VersionYearEditor.Value != null)
            {
                this.versionType = rdoVersionType.Value.ToString();
                this.versionYear = Convert.ToInt32(this.VersionYearEditor.Value);
                this.LoadVersions(this.versionType, this.versionYear);
            }
        }

        if (!IsPostBack || this.PurchaseGrid.IsCallback)
        {
            //this.ShowHideColumnStore();

            if (this.PurchaseGrid.IsCallback)
            {
                if (this.GetGridCallbackType() != ASPxGridViewCallbackType.Custom)
                {
                    if (this.RevCostHiddenField.Contains("VerCompanyID"))
                    {
                        var verCompanyID = Convert.ToDecimal(RevCostHiddenField.Get("VerCompanyID"));
                        //this.LoadPurchase(null, verCompanyID);

                    }
                }
            }
        }

        /*if (this.VersionCompanyGrid.IsCallback)
        {
            if (this.GetGridCallbackType() != ASPxGridViewCallbackType.Custom)
            {
                if (this.RevCostHiddenField.Contains("VersionID"))
                {
                    var verID = Convert.ToDecimal(RevCostHiddenField.Get("VersionID"));
                    this.LoadVersionCompany(verID);
                }
            }
        }*/

        /*if (!IsPostBack || this.StoreDetailsGrid.IsCallback)
            this.ShowHideColumnStoreDetail();
        */
        /*if (this.VersionCopyGrid.IsCallback)
            this.LoadCopyVersions();*/

        if (this.CompanyGrid.IsCallback) //!IsPostBack || 
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

            /*int companyID;
            if (!int.TryParse(args[2], out companyID))
                return;
            */
            //s.JSProperties["cpCompanyName"] = this.GetCompanyName(SessionUser.CompanyID);

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
            //s.JSProperties["cpCompanyName"] = this.GetCompanyName(companyID);

            LoadVersionCompany(versionID);
        }        

    }

    protected void PurchaseGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;

        string[] args = e.Parameters.Split('|');

        s.JSProperties["cpCommand"] = args[0];

        if (args[0] == "LoadPurchase")
        {
            decimal dverID;
            if (!decimal.TryParse(args[1], out dverID)) return;

            decimal dverCompanyID;
            if (!decimal.TryParse(args[2], out dverCompanyID)) return;

            decimal dpurchaselvl;
            if (!decimal.TryParse(args[3], out dpurchaselvl)) return;

            LoadPurchase(dverID, dverCompanyID, dpurchaselvl);
        }
        if (args[1].ToUpper() == "NEW")
        {
            var entity = new PURCHASE();

            decimal dQuantityEditor;
            decimal dPriceEditor;
            decimal dImplementDurationEditor;
            decimal dPurchaseFormEditor;
            decimal dTaxRateEditor;
            decimal dPlanAmountEditor;
            decimal dPlanTimeEditor;
            decimal dverCompanyID;
            decimal dPurchaselvlid;
            decimal dverID;

            if (!decimal.TryParse(args[5], out dPurchaselvlid)) return;
            if (!decimal.TryParse(args[4], out dverCompanyID)) return;
            if (!decimal.TryParse(args[3], out dverID)) return;
            if (!decimal.TryParse(QuantityEditor.Text, out dQuantityEditor)) return;
            if (!decimal.TryParse(PriceEditor.Text, out dPriceEditor)) return;
            if (!decimal.TryParse(ImplementDurationEditor.Text, out dImplementDurationEditor)) return;
            if (!decimal.TryParse(PurchaseFormEditor.Value.ToString(), out dPurchaseFormEditor)) return;
            if (!decimal.TryParse(TaxRateEditor.Text, out dTaxRateEditor)) return;
            if (!decimal.TryParse(PlanAmountEditor.Text, out dPlanAmountEditor)) return;
            if (!decimal.TryParse(PlanTimeEditor.Text, out dPlanTimeEditor)) return;


            entity.VER_ID = dverID;
            entity.VER_COMPANY_ID = dverCompanyID;
            entity.PURCHASE_LEVEL_ID = dPurchaselvlid;
            entity.PURCHASE_ITEM_ID = Convert.ToInt32(PurchaseItemEditor.Value);
            entity.DESCRIPTION = PurchaseItemEditor.Text;
            entity.ITEM_UNIT_ID = Convert.ToInt32(PurchaseUnitEditor.Value);

            entity.QUANTITY = dQuantityEditor;
            entity.PRICE = dPriceEditor;
            entity.AMOUNT = dQuantityEditor * dPriceEditor;
            entity.PURCHASE_TIME = Convert.ToInt32(PurchaseTimeEditor.Value);
            entity.PURCHASE_TIME_UNIT = PurchaseTimeUnitEditor.Value.ToString();
            entity.IMPLEMENT_DURATION = dImplementDurationEditor;
            entity.SUP_SEL_FORM = dPurchaseFormEditor;
            entity.SUP_SEL_CODE = SupplierEditor.Value.ToString();

            entity.TAX_RATE = dTaxRateEditor;
            entity.TAX_AMOUNT = (dQuantityEditor * dPriceEditor) * dTaxRateEditor;

            entity.PLAN_AMOUNT = dPlanAmountEditor;
            entity.PLAN_TIME = dPlanTimeEditor;

            entity.NOTE = NoteEditor.Text;

            entities.PURCHASEs.Add(entity);
            entities.SaveChanges();
            LoadPurchase(dverID, dverCompanyID, dPurchaselvlid);
        }
        else if (args[1].ToUpper() == "EDIT")
        {
            decimal dPurchaseID;
            if (!decimal.TryParse(args[2], out dPurchaseID)) return;

            var entity = entities.PURCHASEs.SingleOrDefault(x => x.ID == dPurchaseID);
            //var entity = new PURCHASE();

            decimal dQuantityEditor;
            decimal dPriceEditor;
            decimal dImplementDurationEditor;
            decimal dPurchaseFormEditor;
            decimal dTaxRateEditor;
            decimal dPlanAmountEditor;
            decimal dPlanTimeEditor;
            decimal dverCompanyID;
            decimal dPurchaselvlid;
            decimal dSupCode;
            decimal dverID;

            if (!decimal.TryParse(args[5], out dPurchaselvlid)) return;
            if (!decimal.TryParse(args[4], out dverCompanyID)) return;
            if (!decimal.TryParse(args[3], out dverID)) return;
            if (!decimal.TryParse(QuantityEditor.Text, out dQuantityEditor)) return;
            if (!decimal.TryParse(PriceEditor.Text, out dPriceEditor)) return;
            if (!decimal.TryParse(ImplementDurationEditor.Text, out dImplementDurationEditor)) return;
            if (!decimal.TryParse(PurchaseFormEditor.Value.ToString(), out dPurchaseFormEditor)) return;
            if (!decimal.TryParse(TaxRateEditor.Text, out dTaxRateEditor)) return;
            if (!decimal.TryParse(PlanAmountEditor.Text, out dPlanAmountEditor)) return;
            if (!decimal.TryParse(PlanTimeEditor.Text, out dPlanTimeEditor)) return;
            if (!decimal.TryParse(SupplierEditor.Value.ToString(), out dSupCode)) return;

            entity.VER_ID = dverID;
            entity.VER_COMPANY_ID = dverCompanyID;
            entity.PURCHASE_LEVEL_ID = dPurchaselvlid;
            entity.PURCHASE_ITEM_ID = Convert.ToInt32(PurchaseItemEditor.Value);
            entity.DESCRIPTION = PurchaseItemEditor.Text;
            entity.ITEM_UNIT_ID = Convert.ToInt32(PurchaseUnitEditor.Value);

            entity.QUANTITY = dQuantityEditor;
            entity.PRICE = dPriceEditor;
            entity.AMOUNT = dQuantityEditor * dPriceEditor;
            entity.PURCHASE_TIME = Convert.ToInt32(PurchaseTimeEditor.Value);
            entity.PURCHASE_TIME_UNIT = PurchaseTimeUnitEditor.Value.ToString();
            entity.IMPLEMENT_DURATION = dImplementDurationEditor;
            entity.SUP_SEL_FORM = dPurchaseFormEditor;
            entity.SUP_SEL_CODE = SupplierEditor.Value.ToString();

            entity.TAX_RATE = dTaxRateEditor;
            entity.TAX_AMOUNT = (dQuantityEditor * dPriceEditor) * dTaxRateEditor;

            entity.PLAN_AMOUNT = dPlanAmountEditor;
            entity.PLAN_TIME = dPlanTimeEditor;

            entity.NOTE = NoteEditor.Text;

            entities.SaveChanges();
            LoadPurchase(dverID, dverCompanyID, dPurchaselvlid);
        }
        else if (args[0].ToUpper() == "DELETE")
        {
            decimal key;
            decimal dverCompanyID;
            decimal dPurchaselvlid;
            decimal dverID;

            if (!decimal.TryParse(args[1], out key)) return;
            if (!decimal.TryParse(args[2], out dverID)) return;
            if (!decimal.TryParse(args[3], out dverCompanyID)) return;
            if (!decimal.TryParse(args[4], out dPurchaselvlid)) return;

            var entity = (from x in entities.PURCHASEs where x.ID == key select x).FirstOrDefault();
            if (entity != null)
            {
                entities.PURCHASEs.Remove(entity);
                entities.SaveChanges();
                LoadPurchase(dverID, dverCompanyID, dPurchaselvlid);
            }
        }
    }


    protected void PurchaseGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "EditForm" && args.Length == 3)
        {
            string key = args[2];

            decimal dID;
            if (!decimal.TryParse(key, out dID)) return;

            var values = entities.PURCHASEs.SingleOrDefault(x => x.ID == dID);
            if (values == null)
                return;

            var result = new Dictionary<string, string>();
            result["PurchaseItemEditor"] = values.PURCHASE_ITEM_ID.ToString();
            result["PurchaseUnitEditor"] = values.ITEM_UNIT_ID.ToString();
            result["QuantityEditor"] = values.QUANTITY.ToString();
            result["PriceEditor"] = values.PRICE.ToString();
            result["TaxRateEditor"] = values.TAX_RATE.ToString();
            result["PlanAmountEditor"] = values.PLAN_AMOUNT.ToString();
            result["PlanTimeEditor"] = values.PLAN_TIME.ToString();
            result["PurchaseTimeEditor"] = values.PURCHASE_TIME.ToString();
            result["ImplementDurationEditor"] = values.IMPLEMENT_DURATION.ToString();
            result["PurchaseTimeUnitEditor"] = values.PURCHASE_TIME_UNIT.ToString();
            result["PurchaseFormEditor"] = values.PURCHASE_ITEM_ID.ToString();
            result["SupplierEditor"] = values.SUP_SEL_FORM.ToString();
            result["NoteEditor"] = values.NOTE.ToString();

            e.Result = result;
        }
    }


    protected void PurchaseGrid_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
    {
        /*if (e.Column.FieldName == "ITEM_UNIT_ID")
        {
            var ItemUnitID = e.Value;
            var ItemUnitName = entities.Database.SqlQuery<string>("SELECT UNIT_NAME From DEC_ITEM_UNITS Where ID = " + ItemUnitID).SingleOrDefault();

            e.DisplayText = ItemUnitName;
        }*/

        var Grid = (sender as ASPxGridView);
        if (e.Column.FieldName == "ITEM_UNIT_ID")
        {
            if (Grid.GetRow(e.VisibleIndex) != null)
            {
                var ItemUnitID = e.Value;
                if (ItemUnitID != null)
                {
                    var ItemUnitName = entities.Database.SqlQuery<string>("SELECT UNIT_NAME From DEC_ITEM_UNITS Where ID = " + ItemUnitID).SingleOrDefault();

                    e.DisplayText = ItemUnitName;
                }
            }
        }

        if (e.Column.FieldName == "PURCHASE_TIME")
        {
            if (Grid.GetRow(e.VisibleIndex) != null)
            {

                var value = e.Value;
                var name = "";

                switch (Convert.ToInt32(value))
                {
                    case 1: name = "Tháng 1"; break;
                    case 2: name = "Tháng 2"; break;
                    case 3: name = "Tháng 3"; break;
                    case 4: name = "Tháng 4"; break;
                    case 5: name = "Tháng 5"; break;
                    case 6: name = "Tháng 6"; break;
                    case 7: name = "Tháng 7"; break;
                    case 8: name = "Tháng 8"; break;
                    case 9: name = "Tháng 9"; break;
                    case 10: name = "Tháng 10"; break;
                    case 11: name = "Tháng 11"; break;
                    case 12: name = "Tháng 12"; break;
                    default: name = "Tháng";
                        break;
                }

                e.DisplayText = name;
            }
        }

        if (e.Column.FieldName == "PURCHASE_TIME_UNIT")
        {
            if (Grid.GetRow(e.VisibleIndex) != null)
            {

                var value = e.Value;
                var name = "";

                switch (value.ToString())
                {
                    case "T": name = "Tháng"; break;
                    default: name = "Tháng";
                        break;
                }

                e.DisplayText = name;
            }
        }

        if (e.Column.FieldName == "SUP_SEL_FORM")
        {
            if (Grid.GetRow(e.VisibleIndex) != null)
            {

                var value = e.Value;
                if (value != null)
                {
                    var name = entities.Database.SqlQuery<string>("SELECT DESCRIPTION From DEC_PURCHASE_FORM Where ID = " + value).SingleOrDefault();
                    e.DisplayText = name;
                }
            }
        }

        if (e.Column.FieldName == "SUP_SEL_CODE")
        {
            if (Grid.GetRow(e.VisibleIndex) != null)
            {

                var value = e.Value;
                if (value != null)
                {
                    var name = entities.Database.SqlQuery<string>("SELECT SUP_CODE From DEC_SUPPLIER Where ID = " + value).SingleOrDefault();
                    e.DisplayText = name;
                }
            }
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

            var store = entities.Stores.SingleOrDefault(x => x.StoreID == storeID);
            this.StoreStatus = store.Status;
            if (store != null && store.Calculation == "DATA")
                entities.InitStoreDetail(storeID, SessionUser.UserID);

            //ASPxRoundPanel RoundPanel = (ASPxRoundPanel)grid.FindTitleTemplateControl("AllocateRoundPanel");
            //ASPxFormLayout FormLayout = (ASPxFormLayout)RoundPanel.FindControl("AllocateForm");
            //ASPxButton btnAllocateApply = (ASPxButton)FormLayout.FindControl("btnAllocateApply");
            //if (store != null || store.Calculation == "SUM")            
            //    btnAllocateApply.Enabled = false;
            //else
            //    btnAllocateApply.Enabled = true;

            LoadStoreDetails(storeID);
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


            //var col1 = AllocateColumn.Instandard;
            var col2 = AllocateColumn.Outstandard;
            var col3 = AllocateColumn.Decentralization;
            var amountType = AmountType.FinalAmount;

            /*if (Object.Equals(rdoAmountType.Value, "FA"))
            {
                amountType = AmountType.FinalAmount;
                //col1 = AllocateColumn.Instandard;
                col2 = AllocateColumn.Outstandard;
                col3 = AllocateColumn.Decentralization;
            }
            else if (Object.Equals(rdoAmountType.Value, "AD"))
            {
                amountType = AmountType.Adjust;
                //col1 = AllocateColumn.InAdjust;
                col2 = AllocateColumn.OutAdjust;
                col3 = AllocateColumn.DecAdjust;
            }
            else if (Object.Equals(rdoAmountType.Value, "SA"))
            {
                amountType = AmountType.Saving;
                //col1 = AllocateColumn.InSaving;
                col2 = AllocateColumn.OutSaving;
                col3 = AllocateColumn.DecSaving;
            }
            else
            {
                return;
            }*/

            ASPxRoundPanel RoundPanel = (ASPxRoundPanel)grid.FindTitleTemplateControl("AllocateRoundPanel");
            if (RoundPanel == null) return;

            ASPxFormLayout FormLayout = (ASPxFormLayout)RoundPanel.FindControl("AllocateForm");
            if (FormLayout == null) return;

            ASPxComboBox StoreDetailTypeOfAmount = (ASPxComboBox)FormLayout.FindControl("StoreDetailTypeOfAmount");
            ASPxSpinEdit StoreDetailMonthFrom = (ASPxSpinEdit)FormLayout.FindControl("StoreDetailMonthFrom");
            ASPxSpinEdit StoreDetailMonthTo = (ASPxSpinEdit)FormLayout.FindControl("StoreDetailMonthTo");
            ASPxSpinEdit StoreDetailAmount = (ASPxSpinEdit)FormLayout.FindControl("StoreDetailAmount");

            var storeDetails = entities.StoreDetails.Where(x => x.StoreID == storeID).OrderBy(x => x.RevCostMonth).ToList();
            if (storeDetails == null || storeDetails.Count <= 0)
                return;

            if (StoreDetailTypeOfAmount.Value.ToString().ToUpper() == "Outstandard".ToUpper())
            {
                AllocateStoreDetail(storeDetails, amountType, StoreDetailMonthFrom.Number, StoreDetailMonthTo.Number, StoreDetailAmount, col2);
            }
            else if (StoreDetailTypeOfAmount.Value.ToString().ToUpper() == "Decentralization".ToUpper())
            {
                AllocateStoreDetail(storeDetails, amountType, StoreDetailMonthFrom.Number, StoreDetailMonthTo.Number, StoreDetailAmount, col3);
            }

            entities.SaveChanges();

            foreach (var entity in storeDetails)
            {
                entities.CalcStoreDetailAfterSavingAmt(entity.StoreDetailID);
            }

            //Update Stores/Load Store detail

            //UpdateStore(storeID);

            LoadStoreDetails(storeID);

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

            entities.SaveChanges();
        }

    }

    private void AllocateStoreDetail(List<StoreDetail> storeDetails, AmountType amountType, decimal fromMonth, decimal toMonth, ASPxSpinEdit editor, AllocateColumn column)
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

            entities.CalcStoreDetailAfterSavingAmt(entity.StoreDetailID);
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


    protected void StoresGrid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
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
                decimal? instandard = null;
                decimal? outstandard = null;
                decimal? decentralization = null;

                decimal? total = null;

                decimal vStoreDetailID = Convert.ToDecimal(updValues.Keys["StoreDetailID"]);
                var entity = entities.StoreDetails.SingleOrDefault(x => x.StoreDetailID == vStoreDetailID);
                if (entity != null)
                {
                    /*if (rdoAmountType.Value != null && rdoAmountType.Value == "FA")
                    {
                        if (updValues.NewValues["InStandards"] != null)
                            instandard = Convert.ToDecimal(updValues.NewValues["InStandards"]);
                        if (updValues.NewValues["OutStandards"] != null)
                            outstandard = Convert.ToDecimal(updValues.NewValues["OutStandards"]);
                        if (updValues.NewValues["Decentralization"] != null)
                            decentralization = Convert.ToDecimal(updValues.NewValues["Decentralization"]);

                        total = (instandard ?? 0) + (outstandard ?? 0) + (decentralization ?? 0);
                        entity.InStandards = instandard;
                        entity.OutStandards = outstandard;
                        entity.Decentralization = decentralization;
                        entity.Amount = total;

                    }
                    else if (rdoAmountType.Value != null && rdoAmountType.Value == "AD")
                    {
                        if (updValues.NewValues["InAdjust"] != null)
                            instandard = Convert.ToDecimal(updValues.NewValues["InAdjust"]);
                        if (updValues.NewValues["OutAdjust"] != null)
                            outstandard = Convert.ToDecimal(updValues.NewValues["OutAdjust"]);
                        if (updValues.NewValues["DecAdjust"] != null)
                            decentralization = Convert.ToDecimal(updValues.NewValues["DecAdjust"]);
                        total = (instandard ?? 0) + (outstandard ?? 0) + (decentralization ?? 0);

                        entity.InAdjust = instandard;
                        entity.OutAdjust = outstandard;
                        entity.DecAdjust = decentralization;
                        entity.Adjust = total;
                    }
                    else if (rdoAmountType.Value != null && rdoAmountType.Value == "SA")
                    {
                        if (updValues.NewValues["InSaving"] != null)
                            instandard = Convert.ToDecimal(updValues.NewValues["InSaving"]);
                        if (updValues.NewValues["OutSaving"] != null)
                            outstandard = Convert.ToDecimal(updValues.NewValues["OutSaving"]);
                        if (updValues.NewValues["DecSaving"] != null)
                            decentralization = Convert.ToDecimal(updValues.NewValues["DecSaving"]);
                        total = (instandard ?? 0) + (outstandard ?? 0) + (decentralization ?? 0);

                        entity.InSaving = instandard;
                        entity.OutSaving = outstandard;
                        entity.DecSaving = decentralization;
                        entity.Saving = total;
                    }
                    else if (rdoAmountType.Value != null && rdoAmountType.Value == "AS")
                    {
                        if (updValues.NewValues["InAfterSaving"] != null)
                            instandard = Convert.ToDecimal(updValues.NewValues["InAfterSaving"]);
                        if (updValues.NewValues["OutAfterSaving"] != null)
                            outstandard = Convert.ToDecimal(updValues.NewValues["OutAfterSaving"]);
                        if (updValues.NewValues["DecAfterSaving"] != null)
                            decentralization = Convert.ToDecimal(updValues.NewValues["DecAfterSaving"]);
                        total = (instandard ?? 0) + (outstandard ?? 0) + (decentralization ?? 0);

                        entity.InAfterSaving = instandard;
                        entity.OutAfterSaving = outstandard;
                        entity.DecAfterSaving = decentralization;
                        entity.AfterSaving = total;
                    }*/

                    if (updValues.NewValues["IsOK"] != null)
                    {
                        var isOK = Convert.ToBoolean(updValues.NewValues["IsOK"]);
                        entity.IsOK = isOK;
                        entity.IsOKBy = SessionUser.UserID;
                        entity.IsOKDate = DateTime.Now;
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

        if (this.StoreStatus == "APPROVED" && (e.Column.FieldName == "OutStandards" || e.Column.FieldName == "Decentralization" || e.Column.FieldName == "OutAdjust" || e.Column.FieldName == "DecAdjust" || e.Column.FieldName == "OutSaving" || e.Column.FieldName == "DecSaving"))
        {
            e.Editor.BackColor = System.Drawing.ColorTranslator.FromHtml("#e6e6e6");
            e.Editor.ReadOnly = true;
        }

        if (e.Column.FieldName == "InAfterSaving"
            || e.Column.FieldName == "OutAfterSaving"
            || e.Column.FieldName == "DecAfterSaving")
        {
            e.Editor.ClientVisible = false;
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
        /*for (int i = 0; i < StoreFilesUploadControl.UploadedFiles.Length; i++)
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
                    e.ErrorText = ex.Message;
                }
            }
        }*/
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

            var entity = new StoreFile();
            entity.FileName = fi.Name;
            entity.FilePath = filePath;
            entity.StoreID = storeID;

            entity.CreateDate = DateTime.Now;
            entity.CreatedBy = (int)SessionUser.UserID;

            entities.StoreFiles.Add(entity);

            entities.SaveChanges();

            LoadStoreFiles(storeID);
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
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
    protected void StoresGrid_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
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
                .Select(x => new { CompanyID = x.CompanyID, NameV = x.NameV, AreaCode = x.AreaCode })
                .SingleOrDefault();
            if (company != null)
                return company.CompanyID + "-" + "(" + company.AreaCode + ")" + company.NameV;
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

            var SubaccountId = entities.Stores.Where(s => s.StoreID == StoreId).SingleOrDefault().SubaccountID;
            var list = entities.Units.Where(v => v.VersionID == VersionID && v.SubaccountID == SubaccountId).ToList();
            grid.DataSource = list;
            grid.DataBind();

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
        Response.Write("window.open('/Imports/ImportQuantiy.aspx' ,'_blank')");
        Response.Write("</script>");
    }

}