using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using System;
using System.Collections.Generic;
using System.Linq;
using KTQTData;
using System.IO;
using DevExpress.XtraPrinting;

public partial class Configs_KTQTCompanyStores : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {


        LoadRepID(this.CompanyStoresGrid);
        LoadReportGroup(this.CompanyStoresGrid);

        if (!IsPostBack)
        {
            Session.Remove(SessionConstant.COMPANIES_SESSION);
            //cboArea1.Value = SessionUser.AreaCode;
        }

        if (!IsPostBack || CompaniesGrid.IsCallback || CompanyStoresGrid.IsCallback || SubaccountGrid.IsCallback)
        {
            LoadCompaniesToGrid();
            this.CompaniesGrid.ExpandAll();
        }

        if (!IsPostBack || CompanyStoresGrid.IsCallback)
        {
            var subaccountID = this.CompaniesGrid.FocusedNode.Key;
            if (!StringUtils.isEmpty(subaccountID))
                LoadCompanyStores(Convert.ToInt32(subaccountID));
        }

        if (!IsPostBack || SubaccountGrid.IsCallback)
        {
            var subaccountID = this.CompaniesGrid.FocusedNode.Key;
            if (!StringUtils.isEmpty(subaccountID))
                LoadSubaccountGrid(Convert.ToInt32(subaccountID));
        }

        if (this.VersionGrid.IsCallback)
            this.LoadVersions();


        SetActionRights();
    }

    private void SetActionRights()
    {
        this.CompanyStoresGrid.SettingsDataSecurity.AllowInsert = IsGranted("Pages.KHTC.Configs.KTQTCompanyStores.Create");
        this.CompanyStoresGrid.SettingsDataSecurity.AllowEdit = IsGranted("Pages.KHTC.Configs.KTQTCompanyStores.Edit");
        this.CompanyStoresGrid.SettingsDataSecurity.AllowDelete = IsGranted("Pages.KHTC.Configs.KTQTCompanyStores.Delete");

        var btnAddSubaccount = (ASPxButton)CompanyStoresGrid.FindStatusBarTemplateControl("btnAddSubaccount");
        btnAddSubaccount.Visible = IsGranted("Pages.KHTC.Configs.KTQTCompanyStores.Create");

        var btnRemoveSubaccount = (ASPxButton)CompanyStoresGrid.FindStatusBarTemplateControl("btnRemoveSubaccount");
        btnRemoveSubaccount.Visible = IsGranted("Pages.KHTC.Configs.KTQTCompanyStores.Delete");

        var btnSyncData = (ASPxButton)CompanyStoresGrid.FindStatusBarTemplateControl("btnSyncData");
        btnSyncData.Visible = IsGranted("Pages.KHTC.Configs.KTQTCompanyStores.SyncData");

        var btnApplyVersion = (ASPxButton)CompanyStoresGrid.FindStatusBarTemplateControl("btnApplyVersion");
        btnApplyVersion.Visible = IsGranted("Pages.KHTC.Configs.KTQTCompanyStores.ApplyVersion");
    }

    #region Load data
    private void LoadRepID(ASPxGridView Grid)
    {
        GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)Grid.Columns["RepID"];

        var list = entities.RepRouteProfits.ToList();
        aCombo.PropertiesComboBox.DataSource = list;
        aCombo.PropertiesComboBox.ValueField = "RouteProfitID";
        aCombo.PropertiesComboBox.TextField = "Description";
    }

    private void LoadReportGroup(ASPxGridView Grid)
    {
        GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)Grid.Columns["ReportGroup"];

        var list = entities.DecTableValues
                      .Where(x => x.Tables == "COMPANY_STORE" && x.Field == "REPORT_GROUP")
                      .Select(x => new { DefValue = x.DefValue, Description = x.Description })
                      .ToList();

        aCombo.PropertiesComboBox.DataSource = list;
        aCombo.PropertiesComboBox.ValueField = "DefValue";
        aCombo.PropertiesComboBox.TextField = "Description";
    }

    private void LoadCompaniesToGrid()
    {
        if (Session[SessionConstant.COMPANIES_SESSION] != null)
        {
            this.CompaniesGrid.DataSource = (List<DecCompany>)Session[SessionConstant.COMPANIES_SESSION];
        }
        else
        {
            if (SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR))
            {
                //string areaCode = SessionUser.AreaCode;
                var list = entities.DecCompanies.OrderBy(x => x.Seq).ToList();
                this.CompaniesGrid.DataSource = list;
                Session[SessionConstant.COMPANIES_SESSION] = list;
            }
            else
            {
                List<int> companies = new List<int>();
                using (APPData.QLKHAppEntities app = new APPData.QLKHAppEntities())
                {
                    companies = app.UserCompanies.Where(x => x.UserID == SessionUser.UserID).Select(x => x.CompanyID).ToList();
                }

                DateTime validDate = DateTime.Now.Date;

                var list = entities.DecCompanies.Where(x => companies.Contains(x.CompanyID) && (x.Active ?? false) == true && ((x.ValidFrom ?? validDate) <= validDate && validDate <= (x.ValidTo ?? validDate))).OrderBy(x => x.Seq).ToList();
                this.CompaniesGrid.DataSource = list;
                Session[SessionConstant.COMPANIES_SESSION] = list;
            }

        }
        this.CompaniesGrid.DataBind();
    }

    private void LoadCompanyStores(int companyID)
    {
        var list = entities.CompanyStoreViews.Where(x => x.CompanyID == companyID).OrderBy(x => x.Seq).ToList();
        this.CompanyStoresGrid.DataSource = list;
        this.CompanyStoresGrid.DataBind();
    }

    private void LoadSubaccountGrid(int companyID)
    {
        var subaccountIDs = entities.CompanyStores.Where(x => x.CompanyID == companyID).Select(x => x.SubaccountID).ToList();
        var list = entities.DecSubaccounts
            .Where(x => x.CompanyID == SessionUser.CompanyID || x.CompanyID == null)
            .Where(x => !subaccountIDs.Contains(x.SubaccountID)).OrderBy(x => x.Seq).ToList();

        this.SubaccountGrid.DataSource = list;
        this.SubaccountGrid.DataBind();
        this.SubaccountGrid.ExpandAll();
    }

    private void LoadVersions()
    {
        var list = entities.Versions.Where(x => x.Active == true).OrderByDescending(x => x.VersionYear).ThenBy(x => x.Sorting).ToList();
        this.VersionGrid.DataSource = list;
        this.VersionGrid.DataBind();
    }

    #endregion

    protected void CompanyStoresGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        int companyID;
        decimal companyStoreID;
        switch (args[0])
        {
            case "Refresh":
                if (!int.TryParse(args[1], out companyID))
                    return;

                LoadCompanyStores(companyID);
                SetActionRights();
                break;
            case "Remove":
                if (!IsGranted("Pages.KHTC.Configs.KTQTCompanyStores.Delete"))
                    throw new UserFriendlyException("Bạn không có quyền xóa dữ liệu", SessionUser.UserName);

                if (!decimal.TryParse(args[1], out companyStoreID))
                    return;

                var entity = entities.CompanyStores.SingleOrDefault(x => x.CompanyStoreID == companyStoreID);
                if (entity != null)
                {
                    companyID = entity.CompanyID.Value;
                    entities.CompanyStores.Remove(entity);
                    entities.SaveChanges();

                    LoadCompanyStores(companyID);
                }

                break;
            case "SYNC_DATA":
                if (!IsGranted("Pages.KHTC.Configs.KTQTCompanyStores.SyncData"))
                    throw new UserFriendlyException("Bạn không có quyền cập nhật dữ liệu", SessionUser.UserName);

                if (!int.TryParse(args[1], out companyID))
                    return;
                entities.Sync_PMSCompanyStore();

                LoadCompanyStores(companyID);
                break;
            case "SaveForm":
                try
                {
                    if (!IsGranted("Pages.KHTC.Configs.KTQTCompanyStores.Edit"))
                        throw new UserFriendlyException("Bạn không có quyền cập nhật dữ liệu", SessionUser.UserName);

                    var command = args[1];
                    if (command.ToUpper() == "EDIT")
                    {
                        if (!decimal.TryParse(args[2], out companyStoreID))
                            return;

                        var cs = entities.CompanyStores.Where(x => x.CompanyStoreID == companyStoreID).SingleOrDefault();
                        if (cs == null)
                            return;

                        cs.CompanyID = Convert.ToInt32(CompanyEditor.Value);
                        cs.Curr = CurrEditor.Text;
                        cs.AllocatedDriver = DriverEditor.Value != null ? DriverEditor.Value.ToString() : string.Empty;
                        cs.Carrier = CarrierEditor.Text;
                        cs.AllocatedFLT = FltTypeEditor.Value != null ? FltTypeEditor.Value.ToString() : string.Empty;
                        cs.Fleet_Type = FleetTypeEditor.Value != null ? FleetTypeEditor.Value.ToString() : string.Empty;
                        //cs.AllocatedRT = RouteEditor.Value != null ? RouteEditor.Value.ToString() : string.Empty;
                        cs.Route2W = Route2WEditor.Value != null ? Route2WEditor.Value.ToString() : string.Empty;
                        cs.Country = CountryEditor.Value != null ? CountryEditor.Value.ToString() : string.Empty;
                        cs.Ori = OriEditor.Value != null ? OriEditor.Value.ToString() : string.Empty;
                        cs.Des = DesEditor.Value != null ? DesEditor.Value.ToString() : string.Empty;
                        cs.ACID = ACIDEditor.Value != null ? ACIDEditor.Value.ToString() : string.Empty;
                        cs.AllocateFltDirection = DirectionEditor.Value != null ? DirectionEditor.Value.ToString() : string.Empty;
                        cs.Network = NetworkEditor.Value != null ? NetworkEditor.Value.ToString() : string.Empty;
                        cs.Division = DivisionEditor.Value != null ? DivisionEditor.Value.ToString() : string.Empty;
                        //cs.CostType = CostTypeEditor.Value != null ? CostTypeEditor.Value.ToString() : string.Empty;
                        cs.CostGroup = CostGroupEditor.Value != null ? CostGroupEditor.Value.ToString() : string.Empty;
                        cs.AllocateK = AllocateKEditor.Checked;
                        cs.AccLevel1 = AccLevel1Editor.Text;
                        cs.AccLevel2 = AccLevel2Editor.Text;
                        cs.AccLevel3 = AccLevel3Editor.Text;
                        cs.AccLevel4 = AccLevel4Editor.Text;
                        cs.AccLevel5 = AccLevel5Editor.Text;
                        cs.ACCode = ACCodeEditor.Text;
                        cs.MaBoPhan = MaBoPhanEditor.Text;
                        cs.ManagermentCode = ManagermentCodeEditor.Text;
                        cs.OriCountry = OriCountryEditor.Text;
                        cs.DesCountry = DesCountryEditor.Text;
                        cs.ReportGroup = ReportGroupEditor.Value != null ? ReportGroupEditor.Value.ToString() : string.Empty;

                        cs.LastUpdateDate = DateTime.Now;
                        cs.LastUpdatedBy = (int)SessionUser.UserID;
                        entities.SaveChangesWithAuditLogs();

                        //LoadCompanyStores((int)cs.CompanyID);
                    }

                    s.JSProperties["cpResult"] = "Success";
                }
                catch (Exception ex)
                {
                    s.JSProperties["cpResult"] = ex.Message;
                }

                break;
        }
    }
    protected void CompanyStoresGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "EditForm" && args.Length == 3)
        {
            decimal key;
            if (!decimal.TryParse(args[2], out key))
                return;


            var entity = entities.CompanyStores.SingleOrDefault(x => x.CompanyStoreID == key);
            if (entity == null)
                return;

            var result = new Dictionary<string, string>();
            result["CompanyID"] = entity.CompanyID.ToString();
            result["SubaccountID"] = entity.SubaccountID.ToString();
            result["Curr"] = entity.Curr;
            result["AllocatedDriver"] = entity.AllocatedDriver;
            result["Carrier"] = entity.Carrier;
            result["AllocatedFLT"] = entity.AllocatedFLT;
            result["FleetType"] = entity.Fleet_Type;
            result["AllocatedRT"] = entity.AllocatedRT;
            result["Route2W"] = entity.Route2W;
            result["Country"] = entity.Country;
            result["Ori"] = entity.Ori;
            result["Des"] = entity.Des;
            result["Airports"] = entity.Airports;
            result["ACID"] = entity.ACID;
            result["AllocateK"] = (entity.AllocateK ?? false) ? "True" : "False";
            result["Direction"] = entity.AllocateFltDirection;
            result["Network"] = entity.Network;
            result["Division"] = entity.Division;
            result["CostGroup"] = entity.CostGroup;
            result["CostType"] = entity.CostType;
            result["AccLevel1"] = entity.AccLevel1;
            result["AccLevel2"] = entity.AccLevel2;
            result["AccLevel3"] = entity.AccLevel3;
            result["AccLevel4"] = entity.AccLevel4;
            result["AccLevel5"] = entity.AccLevel5;
            result["ACCode"] = entity.ACCode;
            result["ManagermentCode"] = entity.ManagermentCode;
            result["MaBoPhan"] = entity.MaBoPhan;
            result["OriCountry"] = entity.OriCountry;
            result["DesCountry"] = entity.DesCountry;
            result["ReportGroup"] = entity.ReportGroup;

            e.Result = result;
        }
    }

    protected void CompaniesGrid_HtmlRowPrepared(object sender, TreeListHtmlRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("CompanyType"), "K"))
        {
            e.Row.Font.Bold = true;
        }
    }

    protected void CompanyStoresGrid_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
    {
        //var Grid = (sender as ASPxGridView);
        //if (e.Column.FieldName == "ShortName")
        //{
        //    if (Grid.GetRow(e.VisibleIndex) != null)
        //    {
        //        var companyStore = Grid.GetRow(e.VisibleIndex) as CompanyStore;
        //        if (companyStore == null)
        //            return;
        //        var companyID = companyStore.CompanyID;
        //        var companyName = entities.Database.SqlQuery<string>("SELECT ShortName From Companies Where CompanyID = " + companyID).SingleOrDefault();

        //        e.DisplayText = companyName;
        //    }
        //}
        //if (e.Column.FieldName == "NameV")
        //{
        //    if (Grid.GetRow(e.VisibleIndex) != null)
        //    {
        //        var companyStore = Grid.GetRow(e.VisibleIndex) as CompanyStore;
        //        if (companyStore == null)
        //            return;
        //        var companyID = companyStore.CompanyID;
        //        var companyName = entities.Database.SqlQuery<string>("SELECT NameV From Companies Where CompanyID = " + companyID).SingleOrDefault();

        //        e.DisplayText = companyName;
        //    }
        //}
    }

    protected void CompanyEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        if (Session[SessionConstant.COMPANY_LIST] != null)
        {
            var companies = Session[SessionConstant.COMPANY_LIST];
            s.DataSource = companies;
        }
        else
        {
            var companies = entities.DecCompanies
                .Select(x => new
                {
                    CompanyID = x.CompanyID,
                    ParentID = x.ParentID,
                    ShortName = x.ShortName,
                    AreaCode = x.AreaCode,
                    NameV = x.NameV,
                    CompanyType = x.CompanyType,
                    Seq = x.Seq,
                    DisplayName = x.AreaCode + "-" + x.NameV
                })
                .OrderBy(x => x.Seq).ToList();
            Session[SessionConstant.COMPANY_LIST] = companies;
            s.DataSource = companies;
        }
        s.ValueField = "CompanyID";
        s.TextField = "NameV";
        s.DataBind();
    }
    protected void SubaccountGrid_CustomCallback(object sender, TreeListCustomCallbackEventArgs e)
    {
        ASPxTreeList s = sender as ASPxTreeList;
        string[] args = e.Argument.Split('|');
        int key;
        switch (args[0])
        {
            case "Refresh":
                if (!int.TryParse(args[1], out key))
                    return;

                s.UnselectAll();
                LoadSubaccountGrid(key);

                break;
            case "Apply":

                if (!int.TryParse(args[1], out key))
                    return;

                var companies = CompaniesGrid.GetSelectedNodes();
                foreach (TreeListNode com in companies)
                {
                    var companyId = Convert.ToInt32(com.Key);
                    var company = entities.DecCompanies.SingleOrDefault(x => x.CompanyID == companyId);
                    if (company != null && company.CompanyType == "D")
                    {
                        List<TreeListNode> fieldValues = s.GetSelectedNodes();
                        if (fieldValues.Count == 0)
                            return;
                        else
                        {
                            foreach (TreeListNode item in fieldValues)
                            {
                                var subaccountID = Convert.ToDecimal(item.Key);
                                var check = entities.CompanyStores.Where(x => x.CompanyID == companyId && x.SubaccountID == subaccountID).Any();
                                if (!check)
                                {

                                    var subaccount = entities.DecSubaccounts.SingleOrDefault(x => x.SubaccountID == subaccountID);
                                    if (subaccount == null)
                                        return;

                                    var companyStore = new CompanyStore();
                                    companyStore.CompanyID = companyId;
                                    companyStore.SubaccountID = subaccount.SubaccountID;
                                    companyStore.SubaccountParentID = subaccount.SubaccountParentID;
                                    companyStore.AccountGroup = subaccount.AccountGroup;
                                    companyStore.Seq = subaccount.Seq;
                                    companyStore.Sorting = subaccount.Sorting.Trim();
                                    companyStore.Calculation = subaccount.Calculation.Trim();
                                    companyStore.Description = subaccount.Description.Trim();
                                    companyStore.AllocatedDriver = subaccount.AllocatedDriver;
                                    companyStore.AllocatedFLT = subaccount.AllocatedFLT;
                                    companyStore.AllocatedRT = subaccount.AllocatedRT;
                                    companyStore.Division = company != null && StringUtils.isEmpty(company.CompanyGroup) ? "XXXX" : company.CompanyGroup;// subaccount.Division;
                                    companyStore.Airports = subaccount.Airports;
                                    companyStore.ACID = subaccount.ACID;
                                    companyStore.AllocateFltDirection = subaccount.AllocateFltDirection;
                                    companyStore.Network = subaccount.Network;
                                    companyStore.AllocateK = false;
                                    companyStore.Carrier = subaccount.Carrier;
                                    companyStore.CostType = subaccount.CostType;
                                    companyStore.CostGroup = subaccount.CostGroup;
                                    companyStore.RepID = subaccount.RouteProfitID;
                                    companyStore.Curr = company != null && StringUtils.isEmpty(company.Curr) ? "VND" : company.Curr;
                                    companyStore.AccLevel1 = subaccount.AccLevel1;
                                    companyStore.AccLevel2 = subaccount.AccLevel2;
                                    companyStore.AccLevel3 = subaccount.AccLevel3;
                                    companyStore.AccLevel4 = subaccount.AccLevel4;
                                    companyStore.AccLevel5 = subaccount.AccLevel5;
                                    companyStore.ACCode = subaccount.ACCode;
                                    companyStore.MaBoPhan = subaccount.MaBoPhan;
                                    companyStore.ManagermentCode = subaccount.ManagermentCode;
                                    companyStore.Fleet_Type = subaccount.Fleet_Type;
                                    companyStore.OriCountry = subaccount.OriCountry;
                                    companyStore.DesCountry = subaccount.DesCountry;
                                    companyStore.Ori = subaccount.Ori;
                                    companyStore.Des = subaccount.Des;
                                    companyStore.Route2W = subaccount.Route2W;
                                    companyStore.Country = subaccount.Country;

                                    companyStore.CreateDate = DateTime.Now;
                                    companyStore.CreatedBy = (int)SessionUser.UserID;

                                    entities.CompanyStores.Add(companyStore);

                                }
                            }
                            entities.SaveChangesWithAuditLogs();
                        }
                    }
                }

                LoadSubaccountGrid(key);
                s.UnselectAll();
                CompaniesGrid.UnselectAll();
                break;

        }
    }
    protected void SubaccountGrid_HtmlRowPrepared(object sender, TreeListHtmlRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("Calculation"), "SUM"))
        {
            e.Row.Font.Bold = true;
        }
    }
    protected void CompanyStoresGrid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("Calculation"), "SUM"))
        {
            e.Row.Font.Bold = true;
        }
    }
    protected void SubaccountEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        if (Session[SessionConstant.SUBACCOUNT_LIST] != null)
        {
            var subaccounts = Session[SessionConstant.SUBACCOUNT_LIST];
            s.DataSource = subaccounts;
        }
        else
        {
            var subaccounts = entities.DecSubaccounts
                .Where(x => x.CompanyID == SessionUser.CompanyID || x.CompanyID == null)
                .Select(x => new { SubaccountID = x.SubaccountID, Description = x.Description, Seq = x.Seq })
                .OrderBy(x => x.Seq).ToList();
            Session[SessionConstant.SUBACCOUNT_LIST] = subaccounts;
            s.DataSource = subaccounts;
        }
        s.ValueField = "SubaccountID";
        s.TextField = "Description";
        s.DataBind();
    }

    protected void ACIDEditor_Init(object sender, EventArgs e)
    {
        ASPxTokenBox s = sender as ASPxTokenBox;
        if (Session[SessionConstant.AIRCRAFT_LIST] != null)
        {
            var acs = Session[SessionConstant.AIRCRAFT_LIST];
            s.DataSource = acs;
        }
        else
        {
            var acs = entities.AcGroupConverts
                .Select(x => new { AcGroup = x.AcGroup }).Distinct()
                .ToList();
            Session[SessionConstant.AIRCRAFT_LIST] = acs;
            s.DataSource = acs;
        }
        s.ValueField = "AcGroup";
        s.TextField = "AcGroup";
        s.DataBind();
    }
    protected void DriverEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        if (Session[SessionConstant.ALLOCATE_DRIVER] != null)
        {
            var list = Session[SessionConstant.ALLOCATE_DRIVER];
            s.DataSource = list;
        }
        else
        {
            var list = entities.DecTableValues
                .Where(x => x.Tables == "DEC_COMPANY" && x.Field == "ALLOCATE_DRIVER")
                .Select(x => new { DefValue = x.DefValue, Description = x.DefValue + "-" + x.Description })
                .ToList();
            Session[SessionConstant.ALLOCATE_DRIVER] = list;
            s.DataSource = list;
        }
        s.ValueField = "DefValue";
        s.TextField = "Description";
        s.DataBind();
    }
    protected void CarrierEditor_Init(object sender, EventArgs e)
    {
        ASPxTokenBox s = sender as ASPxTokenBox;
        if (Session[SessionConstant.CARRIER_LIST] != null)
        {
            var list = Session[SessionConstant.CARRIER_LIST];
            s.DataSource = list;
        }
        else
        {
            var list = entities.Code_Airlines
                .Select(x => new { AirlinesCode = x.AirlinesCode.Trim() })
                  .OrderBy(x => x.AirlinesCode).ToList();
            Session[SessionConstant.CARRIER_LIST] = list;
            s.DataSource = list;
        }
        s.ValueField = "AirlinesCode";
        s.TextField = "AirlinesCode";
        s.DataBind();
    }
    protected void FltTypeEditor_Init(object sender, EventArgs e)
    {
        ASPxTokenBox s = sender as ASPxTokenBox;
        if (Session[SessionConstant.FLT_TYPE] != null)
        {
            var list = Session[SessionConstant.FLT_TYPE];
            s.DataSource = list;
        }
        else
        {
            var list = entities.DecTableValues
                .Where(x => x.Tables == "FLT_OPS" && x.Field == "FLT_TYPE")
                .Select(x => new { DefValue = x.DefValue, Description = x.DefValue + "-" + x.Description })
                .ToList();
            Session[SessionConstant.FLT_TYPE] = list;
            s.DataSource = list;
        }
        s.ValueField = "DefValue";
        s.TextField = "Description";
        s.DataBind();
    }
    protected void AirportsEditor_Init(object sender, EventArgs e)
    {
        ASPxTokenBox s = sender as ASPxTokenBox;
        if (Session[SessionConstant.AIRPORT] != null)
        {
            var list = Session[SessionConstant.AIRPORT];
            s.DataSource = list;
        }
        else
        {
            var list = entities.AIRPORTS1
                .Select(x => new { Code = x.CODE, NameE = x.CODE })
                .ToList();
            Session[SessionConstant.AIRPORT] = list;
            s.DataSource = list;
        }
        s.ValueField = "Code";
        s.TextField = "NameE";
        s.DataBind();
    }

    protected void RouteEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        if (Session[SessionConstant.ALLOCATED_RT] != null)
        {
            var list = Session[SessionConstant.ALLOCATED_RT];
            s.DataSource = list;
        }
        else
        {
            var list = entities.DecTableValues
                .Where(x => x.Tables == "DEC_COMPANY" && x.Field == "ALLOCATED_RT")
                .Select(x => new { DefValue = x.DefValue, Description = x.DefValue + "-" + x.Description })
                .ToList();
            Session[SessionConstant.ALLOCATED_RT] = list;
            s.DataSource = list;
        }
        s.ValueField = "DefValue";
        s.TextField = "Description";
        s.DataBind();
    }

    private void LoadDivision(object sender)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        if (Session[SessionConstant.COMPANY_GROUP] != null)
        {
            var list = Session[SessionConstant.COMPANY_GROUP];
            s.DataSource = list;
        }
        else
        {
            var list = entities.DecTableValues
                .Where(x => x.Tables == "DEC_COMPANY" && x.Field == "COMPANY_GROUP")
                .Select(x => new { DefValue = x.DefValue, Description = x.DefValue + "-" + x.Description })
                .ToList();
            Session[SessionConstant.COMPANY_GROUP] = list;
            s.DataSource = list;
        }
        s.ValueField = "DefValue";
        s.TextField = "Description";
        s.DataBind();
    }
    protected void DivisionEditor_Init(object sender, EventArgs e)
    {
        LoadDivision(sender);
    }

    private void LoadCostGroup(object sender)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        if (Session[SessionConstant.COST_GROUP] != null)
        {
            var list = Session[SessionConstant.COST_GROUP];
            s.DataSource = list;
        }
        else
        {
            var list = entities.DecTableValues
                .Where(x => x.Tables == "DEC_COMPANY" && x.Field == "COST_GROUP")
                .Select(x => new { DefValue = x.DefValue, Description = x.DefValue + "-" + x.Description })
                .ToList();
            Session[SessionConstant.COST_GROUP] = list;
            s.DataSource = list;
        }
        s.ValueField = "DefValue";
        s.TextField = "Description";
        s.DataBind();
    }
    protected void CostGroupEditor_Init(object sender, EventArgs e)
    {
        LoadCostGroup(sender);
    }
    protected void ACIDEditor_Callback(object sender, CallbackEventArgsBase e)
    {
        var args = e.Parameter.Split('|');
        ASPxTokenBox s = sender as ASPxTokenBox;
        //if (Session[AIRCRAFT_LIST] != null)
        //{
        //    var acs = Session[AIRCRAFT_LIST];
        //    s.DataSource = acs;
        //}
        //else
        //{
        string[] carries = args[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        if (carries != null && carries.Count() > 0)
        {
            var acs = entities.DecAircrafts
                .Where(x => carries.Contains(x.Carrier))
                .Select(x => new { Aircraft_Iata = x.Aircraft_Iata })
                .ToList();
            //Session[AIRCRAFT_LIST] = acs;
            s.DataSource = acs;
        }
        else
        {
            var acs = entities.DecAircrafts
               //.Where(x => carries.Contains(x.Carrier))
               .Select(x => new { Aircraft_Iata = x.Aircraft_Iata })
               .ToList();
            s.DataSource = acs;
        }
        s.ValueField = "Aircraft_Iata";
        s.TextField = "Aircraft_Iata";
        s.DataBind();
    }


    protected bool TryParseKeyValues(IEnumerable<string> stringKeys, out decimal[] resultKeys)
    {
        resultKeys = null;
        var list = new List<decimal>();
        foreach (var sKey in stringKeys)
        {
            decimal key;
            if (!decimal.TryParse(sKey, out key))
                return false;
            list.Add(key);
        }
        resultKeys = list.ToArray();
        return true;
    }

    protected void VersionGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        var args = e.Parameters.Split('|');

        s.JSProperties["cpCommand"] = args[0];

        if (args[0] == "ApplyToVersion")
        {
            try
            {
                int companyID;
                if (!int.TryParse(args[1], out companyID))
                    return;

                decimal[] verKeys = null;
                if (!TryParseKeyValues(args.Skip(2), out verKeys))
                    return;

                foreach (decimal versionID in verKeys)
                {
                    entities.ApplyCStoreToVersion(versionID, companyID, SessionUser.UserID);
                }

                s.JSProperties["cpResult"] = "Success";
            }
            catch (Exception ex)
            {
                s.JSProperties["cpResult"] = ex.Message;
            }
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {

        //var report = new ExportCompanyStore();
        //report.Parameters["pAreaCode"].Value = cboArea1.Value.ToString();

        //MemoryStream stream = new MemoryStream();

        //XlsxExportOptions options = new XlsxExportOptions();
        //options.ExportMode = XlsxExportMode.SingleFile;

        //report.ExportToXlsx(stream, options);

        //stream.Position = 0;


        //Response.Clear();
        //Response.ContentType = "application/xls";
        //Response.AddHeader("Accept-Header", stream.Length.ToString());
        //Response.AddHeader("Content-Disposition", "Attachment; filename=CompanyStore.xlsx");
        //Response.AddHeader("Content-Length", stream.Length.ToString());
        //Response.ContentEncoding = System.Text.Encoding.Default;
        //Response.OutputStream.Write(stream.ToArray(), 0, Convert.ToInt32(stream.Length));
        //Response.End();


    }
    protected void cboArea1_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        if (Session[SessionConstant.AIRPORT] != null)
        {
            var list = Session[SessionConstant.AIRPORT];
            s.DataSource = list;
        }
        else
        {
            var list = entities.AIRPORTS1
                .Select(x => new { Code = x.CODE, NameE = x.CODE })
                .ToList();
            Session[SessionConstant.AIRPORT] = list;
            s.DataSource = list;
        }
        s.ValueField = "Code";
        s.TextField = "NameE";
        s.DataBind();
    }

    protected void FleetTypeEditor_Init(object sender, EventArgs e)
    {
        ASPxTokenBox s = sender as ASPxTokenBox;

        if (Session[SessionConstant.FLEETTYPE] != null)
        {
            var list = Session[SessionConstant.FLEETTYPE];
            s.DataSource = list;
        }
        else
        {
            var list = entities.DecTableValues
                 .Where(x => x.Tables == "DEC_SUBACCOUNT" && x.Field == "FLEETTYPE")
                 .Select(x => new { DefValue = x.DefValue, Description = x.Description })
                 .ToList();

            Session[SessionConstant.FLEETTYPE] = list;
            s.DataSource = list;
        }

        s.ValueField = "DefValue";
        s.TextField = "Description";
        s.DataBind();
    }

    protected void ReportGroupEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;

        if (Session[SessionConstant.REPORT_GROUP] != null)
        {
            var list = Session[SessionConstant.REPORT_GROUP];
            s.DataSource = list;
        }
        else
        {
            var list = entities.DecTableValues
                .Where(x => x.Tables == "COMPANY_STORE" && x.Field == "REPORT_GROUP")
                .Select(x => new { DefValue = x.DefValue, Description = x.Description })
                .ToList();

            Session[SessionConstant.REPORT_GROUP] = list;
            s.DataSource = list;
        }

        s.ValueField = "DefValue";
        s.TextField = "Description";
        s.DataBind();
    }

    protected void CountryEditor_Init(object sender, EventArgs e)
    {

        ASPxTokenBox s = sender as ASPxTokenBox;

        if (Session[SessionConstant.COUNTRY] != null)
        {
            var list = Session[SessionConstant.COUNTRY];
            s.DataSource = list;
        }
        else
        {
            var list = entities.Countries.Where(x => x.CountryCode != "**")
              .Select(x => new { CountryCode = x.CountryCode })
              .ToList();

            Session[SessionConstant.COUNTRY] = list;
            s.DataSource = list;
        }

        s.ValueField = "CountryCode";
        s.TextField = "CountryCode";
        s.DataBind();
    }

    protected void Route2WEditor_Init(object sender, EventArgs e)
    {
        ASPxTokenBox s = sender as ASPxTokenBox;

        if (Session[SessionConstant.Route2W] != null)
        {
            var list = Session[SessionConstant.Route2W];
            s.DataSource = list;
        }
        else
        {
            var list = entities.DecRoutes.Select(x => new { Route = x.Route2W })
            .ToList();

            Session[SessionConstant.Route2W] = list;
            s.DataSource = list;
        }

        s.ValueField = "Route";
        s.TextField = "Route";
        s.DataBind();
    }
}