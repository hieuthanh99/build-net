using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using System;
using System.Collections.Generic;
using System.Linq;
using KHNNData;

public partial class Configs_CompanyStoresV2 : BasePage
{
    QLKHDataEntities entities = new QLKHDataEntities();
    const string COMPANIES_SESSION = "FEE67C61-B297-4285-9A46-748C959470BF";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Session.Remove(COMPANIES_SESSION);

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
    }

    #region Load data
    private void LoadCompaniesToGrid()
    {
        if (Session[COMPANIES_SESSION] != null)
        {
            this.CompaniesGrid.DataSource = (List<Company>)Session[COMPANIES_SESSION];
        }
        else
        {
            var list = entities.Companies.OrderBy(x => x.Seq).ToList();
            this.CompaniesGrid.DataSource = list;
            Session[COMPANIES_SESSION] = list;
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
        var list = entities.Subaccounts.Where(x => !subaccountIDs.Contains(x.SubaccountID)).OrderBy(x => x.Seq).ToList();
        this.SubaccountGrid.DataSource = list;
        this.SubaccountGrid.DataBind();
        this.SubaccountGrid.ExpandAll();
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
                break;
            case "Remove":
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

            case "SaveForm":
                try
                {
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
                        cs.AllocatedRT = RouteEditor.Text;
                        cs.Airports = AirportsEditor.Value != null ? AirportsEditor.Value.ToString() : string.Empty;
                        cs.ACID = ACIDEditor.Value != null ? ACIDEditor.Value.ToString() : string.Empty;
                        cs.AllocateK = AllocateKEditor.Checked;

                        cs.LastUpdateDate = DateTime.Now;
                        cs.LastUpdatedBy = (int)SessionUser.UserID;
                        entities.SaveChanges();

                        LoadCompanyStores((int)cs.CompanyID);
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
            result["AllocatedRT"] = entity.AllocatedRT;
            result["Airports"] = entity.Airports;
            result["ACID"] = entity.ACID;
            result["AllocateK"] = (entity.AllocateK ?? false) ? "True" : "False";

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
        var companies = entities.Companies.OrderBy(x => x.Seq).ToList();
        s.DataSource = companies;
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

                List<TreeListNode> fieldValues = s.GetSelectedNodes();
                if (fieldValues.Count == 0)
                    return;
                else
                {
                    foreach (TreeListNode item in fieldValues)
                    {
                        var subaccountID = Convert.ToDecimal(item.Key);
                        var subaccount = entities.Subaccounts.SingleOrDefault(x => x.SubaccountID == subaccountID);
                        if (subaccount == null)
                            return;
                        var company = entities.Companies.Where(x => x.CompanyID == key).SingleOrDefault();

                        var companyStore = new CompanyStore();
                        companyStore.CompanyID = key;
                        companyStore.SubaccountID = subaccount.SubaccountID;
                        companyStore.SubaccountParentID = subaccount.SubaccountParentID;
                        //companyStore.AccountType = subaccount.AccountType;
                        companyStore.Division = company != null && StringUtils.isEmpty(company.CompanyGroup) ? "XXXX" : company.CompanyGroup;
                        companyStore.Seq = subaccount.Seq;
                        companyStore.Sorting = subaccount.Sorting.Trim();
                        companyStore.Calculation = subaccount.Calculation.Trim();
                        companyStore.Description = subaccount.Description.Trim();
                        companyStore.ACID = "XXX";
                        companyStore.AllocateK = false;
                        companyStore.Carrier = "VN";
                        companyStore.Curr = company != null && StringUtils.isEmpty(company.Curr) ? "XXX" : company.Curr; 

                        companyStore.CreateDate = DateTime.Now;
                        companyStore.CreatedBy = (int)SessionUser.UserID;

                        entities.CompanyStores.Add(companyStore);
                        entities.SaveChanges();
                    }
                    s.UnselectAll();
                    LoadSubaccountGrid(key);
                }
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
        var subaccounts = entities.Subaccounts.OrderBy(x => x.Seq).ToList();
        s.DataSource = subaccounts;
        s.ValueField = "SubaccountID";
        s.TextField = "Description";
        s.DataBind();
    }

    protected void ACIDEditor_Init(object sender, EventArgs e)
    {
        ASPxTokenBox s = sender as ASPxTokenBox;
        var acs = entities.Aircraft.ToList();
        s.DataSource = acs;
        s.ValueField = "ACID";
        s.TextField = "ACID";
        s.DataBind();
    }
    protected void DriverEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DecTableValues.Where(x => x.Tables == "DEC_COMPANY" && x.Field == "ALLOCATE_DRIVER").ToList();
        s.DataSource = list;
        s.ValueField = "DefValue";
        s.TextField = "Description";
        s.DataBind();
    }
    protected void CarrierEditor_Init(object sender, EventArgs e)
    {

    }
    protected void FltTypeEditor_Init(object sender, EventArgs e)
    {
        ASPxTokenBox s = sender as ASPxTokenBox;
        var list = entities.DecTableValues.Where(x => x.Tables == "FLT_OPS" && x.Field == "FLT_TYPE").ToList();
        s.DataSource = list;
        s.ValueField = "DefValue";
        s.TextField = "Description";
        s.DataBind();
    }
    protected void RouteEditor_Init(object sender, EventArgs e)
    {

    }
    protected void AirportsEditor_Init(object sender, EventArgs e)
    {
        ASPxTokenBox s = sender as ASPxTokenBox;

        var list = entities.Airports.ToList();
        s.DataSource = list;
        s.ValueField = "Code";
        s.TextField = "NameE";
        s.DataBind();

    }
}