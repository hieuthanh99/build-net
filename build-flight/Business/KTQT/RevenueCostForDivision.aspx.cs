using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using KTQTData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Business_KTQT_RevenueCostForDivision : BasePageNotCheckURL
{
    KTQTDataEntities entities = new KTQTDataEntities();

    string fileStorage = ConfigurationManager.AppSettings["FileStorage"];

    //const string CURRENT_COMPANY = "618202CB-2F41-4A51-ABB7-254E91B9EB34";
    //const string COMPANY_LIST = "F5B01218-A419-486E-A779-B9B15D58F364";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            this.VersionYearEditor.Value = DateTime.Now.Year;

        if (!IsPostBack || this.VersionGrid.IsCallback)
        {
            if (rdoVersionType.Value != null && this.VersionYearEditor.Value != null)
            {
                string versionType = rdoVersionType.Value.ToString();
                int versionYear = Convert.ToInt32(this.VersionYearEditor.Value);
                this.LoadVersions(versionType, versionYear);
            }
        }
    }

    #region Load data
    //private void LoadCompanies()
    //{
    //    var currentCompanyID = SessionUser.CompanyID;
    //    if (Session[CURRENT_COMPANY] != null)
    //        currentCompanyID = (int?)Session[CURRENT_COMPANY];

    //    var list = entities.DecCompanies.Where(x => x.CompanyID != currentCompanyID && x.CompanyType == "D").OrderBy(x => x.Seq).ToList();
    //    this.CompanyGrid.DataSource = list;
    //    this.CompanyGrid.DataBind();
    //}

    private void LoadVersions(string versionType, int versionYear)
    {
        var list = entities.Versions.Where(x => x.VersionType == versionType && x.VersionYear == versionYear).OrderByDescending(x => x.VersionYear).OrderBy(x => x.Sorting).ToList();
        this.VersionGrid.DataSource = list;
        this.VersionGrid.DataBind();
    }

    private bool HasChild(int companyID)
    {
        return entities.DecCompanies.Where(x => x.ParentID == companyID).Any();
    }

    private IList<int> GetChildCompanies(int companyID)
    {
        IList<int> list = new List<int>();
        if (!HasChild(companyID))
            list.Add(companyID);
        else
        {
            AddCompanyToList(companyID, list);
        }

        return list;
    }

    private void AddCompanyToList(int companyID, IList<int> list)
    {
        var children = entities.DecCompanies.Where(x => x.ParentID == companyID).Select(x => new { CompanyID = x.CompanyID }).ToList();
        foreach (var child in children)
        {
            list.Add(child.CompanyID);
            AddCompanyToList(child.CompanyID, list);
        }
    }

    private void LoadVersionCompany(decimal versionID, int companyID)
    {
        //var companyID = SessionUser.CompanyID;
        //if (Session[CURRENT_COMPANY] != null)
        //    companyID = (int?)Session[CURRENT_COMPANY];

        IList<int> companies = GetChildCompanies(companyID);
        var list = entities.VersionCompanies
            .Where(x => x.VersionID == versionID && x.HotData == true && companies.Contains((int)x.CompanyID)) //&& x.CompanyID == companyID
            .OrderByDescending(x => x.VersionNumber)
            .ToList();
        this.VersionCompanyGrid.DataSource = list;
        this.VersionCompanyGrid.DataBind();
    }

    private void LoadStores(decimal verCompanyID)
    {
        var list = entities.Stores.Where(x => x.VerCompanyID == verCompanyID).OrderBy(x => x.Seq).ToList();
        this.StoresGrid.DataSource = list;
        this.StoresGrid.DataBind();
    }

    //private void LoadStoreDetails(decimal storeID)
    //{
    //    var list = entities.StoreDetails.Where(x => x.StoreID == storeID).OrderBy(x => x.Seq).ToList();
    //    this.StoreDetailsGrid.DataSource = list;
    //    this.StoreDetailsGrid.DataBind();
    //}

    //private void LoadStoreFiles(decimal storeID)
    //{
    //    var list = entities.StoreFiles.Where(x => x.StoreID == storeID).ToList();
    //    this.StoreFilesGrid.DataSource = list;
    //    this.StoreFilesGrid.DataBind();
    //}

    //private void LoadVerCompanyFiles(decimal verCompanyID)
    //{
    //    var list = entities.VersionCompanyFiles.Where(x => x.VerCompanyID == verCompanyID).ToList();
    //    this.VersionCompanyFilesGrid.DataSource = list;
    //    this.VersionCompanyFilesGrid.DataBind();
    //}

    //private void LoadCopyVersions()
    //{
    //    var list = entities.Versions.OrderByDescending(x => x.VersionYear).OrderBy(x => x.Sorting).ToList();
    //    this.VersionCopyGrid.DataSource = list;
    //    this.VersionCopyGrid.DataBind();
    //}
    #endregion
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
            int companyID;
            if (!decimal.TryParse(args[1], out versionID))
                return;

            if (!int.TryParse(args[2], out companyID))
                return;
            LoadVersionCompany(versionID, companyID);
        }

    }
    protected void VersionCompanyGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
    {

    }
    protected void StoresGrid_HtmlRowPrepared(object sender, DevExpress.Web.ASPxTreeList.TreeListHtmlRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("Calculation"), "SUM"))
        {
            e.Row.Font.Bold = true;
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
        }
    }
    protected void StoresGrid_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxTreeList.TreeListColumnDisplayTextEventArgs e)
    {

    }
    protected void cboCompanies_Init(object sender, EventArgs e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        if (Session[SessionConstant.COMPANY_LIST] != null)
        {
            var list = Session[SessionConstant.COMPANY_LIST];
            cbo.DataSource = list;
        }
        else
        {
            var list = entities.DecCompanies
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
                .Where(x => x.CompanyType == "D")
                .OrderBy(x => x.Seq).ToList();

            Session[SessionConstant.COMPANY_LIST] = list;
            cbo.DataSource = list;
        }
        cbo.ValueField = "CompanyID";
        cbo.TextField = "DisplayName";
        cbo.DataBind();
        if (cbo.Items.Count > 0)
            cbo.SelectedIndex = 0;
    }
    protected void TreeCompanies_CustomJSProperties(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomJSPropertiesEventArgs e)
    {
        ASPxTreeList tree = sender as ASPxTreeList;
        Hashtable companyNames = new Hashtable();
        foreach (TreeListNode node in tree.GetVisibleNodes())
            companyNames.Add(node.Key, node["NameV"]);
        e.Properties["cpCompanyNames"] = companyNames;
    }
    protected void TreeCompanies_DataBound(object sender, EventArgs e)
    {
        if (!IsCallback && !IsPostBack)
        {
            ASPxTreeList tree = sender as ASPxTreeList;
            tree.ExpandAll();
        }
    }

    protected void TreeCompanies_Init(object sender, EventArgs e)
    {
        ASPxTreeList tree = sender as ASPxTreeList;
        if (Session[SessionConstant.COMPANY_LIST] != null)
        {
            var list = Session[SessionConstant.COMPANY_LIST];
            tree.DataSource = list;
            tree.DataBind();
        }
        else
        {
            var list = entities.DecCompanies
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

            Session[SessionConstant.COMPANY_LIST] = list;
            tree.DataSource = list;
            tree.DataBind();
        }
    }
    protected void TreeCompanies_HtmlRowPrepared(object sender, TreeListHtmlRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("CompanyType"), "K"))
        {
            e.Row.Font.Bold = true;
        }
    }
}