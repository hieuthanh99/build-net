using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using System;
using System.Collections.Generic;
using System.Linq;
using KHNNData;

public partial class Configs_CompanyStores : BasePage
{
    QLKHDataEntities entities = new QLKHDataEntities();
    const string SUBACCOUNTS_SESSION = "FEE67C61-B297-4285-9A46-748C959470BF";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack || SubacountsGrid.IsCallback || CompanyStoresGrid.IsCallback || CompanyGrid.IsCallback)
        {
            LoadSubaccountsToGrid();
            this.SubacountsGrid.ExpandAll();
        }

        if (!IsPostBack || CompanyStoresGrid.IsCallback)
        {
            var subaccountID = this.SubacountsGrid.FocusedNode.Key;
            if (!StringUtils.isEmpty(subaccountID))
                LoadCompanyStores(Convert.ToDecimal(subaccountID));
        }

        if (!IsPostBack || CompanyGrid.IsCallback)
        {
            var subaccountID = this.SubacountsGrid.FocusedNode.Key;
            if (!StringUtils.isEmpty(subaccountID))
                LoadCompanyGrid(Convert.ToDecimal(subaccountID));
        }
    }

    #region Load data
    private void LoadSubaccountsToGrid()
    {
        if (Session[SUBACCOUNTS_SESSION] != null)
        {
            this.SubacountsGrid.DataSource =(List<Subaccount>) Session[SUBACCOUNTS_SESSION];
        }
        else
        {
            var list = entities.Subaccounts.OrderBy(x => x.Seq).ToList();
            this.SubacountsGrid.DataSource = list;
            Session[SUBACCOUNTS_SESSION] = list;
        }
        this.SubacountsGrid.DataBind();
    }

    private void LoadCompanyStores(decimal subaccountID)
    {
        var list = entities.CompanyStoreViews.Where(x => x.SubaccountID == subaccountID).OrderBy(x => x.Seq).ToList();
        this.CompanyStoresGrid.DataSource = list;
        this.CompanyStoresGrid.DataBind();
    }

    private void LoadCompanyGrid(decimal subaccountID)
    {
        var companyIDs = entities.CompanyStores.Where(x => x.SubaccountID == subaccountID).Select(x => x.CompanyID).ToList();
        var list = entities.Companies.Where(x => !companyIDs.Contains(x.CompanyID)).OrderBy(x => x.Seq).ToList();
        this.CompanyGrid.DataSource = list;
        this.CompanyGrid.DataBind();
    }
    #endregion

    protected void CompanyStoresGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        decimal subaccountID;
        decimal companyStoreID;
        switch (args[0])
        {
            case "Refresh":
                if (!decimal.TryParse(args[1], out subaccountID))
                    return;

                LoadCompanyStores(subaccountID);
                break;
            case "Remove":
                if (!decimal.TryParse(args[1], out companyStoreID))
                    return;

                var entity = entities.CompanyStores.SingleOrDefault(x => x.CompanyStoreID == companyStoreID);
                if (entity != null)
                {
                    subaccountID = entity.SubaccountID.Value;
                    entities.CompanyStores.Remove(entity);
                    entities.SaveChanges();

                    LoadCompanyStores(subaccountID);
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
                        cs.AllocatedDriver = DriverEditor.Text;
                        cs.Carrier = CarrierEditor.Text;
                        cs.AllocatedFLT = FltTypeEditor.Text;
                        cs.AllocatedRT = RouteEditor.Text;
                        cs.Airports = AirportsEditor.Text;
                        cs.AllocateK = AllocateKEditor.Checked;

                        cs.LastUpdateDate = DateTime.Now;
                        cs.LastUpdatedBy = (int)SessionUser.UserID;
                        entities.SaveChanges();

                        LoadCompanyStores((decimal)cs.SubaccountID);
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

    protected void SubacountsGrid_HtmlRowPrepared(object sender, TreeListHtmlRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("Calculation"), "SUM"))
        {
            e.Row.Font.Bold = true;
        }
    }
    protected void CompanyGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        decimal key;
        switch (args[0])
        {
            case "Refresh":
                if (!decimal.TryParse(args[1], out key))
                    return;

                LoadCompanyGrid(key);

                break;
            case "Apply":

                if (!decimal.TryParse(args[1], out key))
                    return;

                var subaccount = entities.Subaccounts.SingleOrDefault(x => x.SubaccountID == key);
                if (subaccount == null)
                    return;

                List<object> fieldValues = s.GetSelectedFieldValues(new string[] { "CompanyID" });
                if (fieldValues.Count == 0)
                    return;
                else
                {
                    foreach (object item in fieldValues)
                    {
                        var companyStore = new CompanyStore();
                        companyStore.CompanyID = Convert.ToInt32(item);
                        companyStore.SubaccountID = subaccount.SubaccountID;
                        companyStore.SubaccountParentID = subaccount.SubaccountParentID;
                        //companyStore.AccountType = subaccount.AccountType;
                        companyStore.Seq = subaccount.Seq;
                        companyStore.Sorting = subaccount.Sorting.Trim();
                        companyStore.Calculation = subaccount.Calculation.Trim();
                        companyStore.Description = subaccount.Description.Trim();
                        companyStore.ACID = "XXX";
                        companyStore.AllocateK = false;
                        companyStore.Carrier = "VN";
                        companyStore.Curr = "VND";

                        companyStore.CreateDate = DateTime.Now;
                        companyStore.CreatedBy = (int)SessionUser.UserID;

                        entities.CompanyStores.Add(companyStore);
                        entities.SaveChanges();
                    }
                    s.Selection.UnselectAll();
                    LoadCompanyGrid(subaccount.SubaccountID);
                }
                break;

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
}