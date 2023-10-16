using DevExpress.Web;
using KTQTData;
using System;
using System.Linq;


public partial class Business_RevenueCost_RevenuCostForReview : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
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
    }

    #region Load data  

    private void LoadVersions(string versionType, int versionYear)
    {
        var list = entities.Versions.Where(x => x.VersionType == versionType && x.VersionYear == versionYear).OrderByDescending(x => x.VersionYear).OrderBy(x => x.Sorting).ToList();
        this.VersionGrid.DataSource = list;
        this.VersionGrid.DataBind();
    }


    private void LoadVersionCompany(decimal versionID)
    {
        var companyID = cboCompanies.Value != null ? Convert.ToDecimal(cboCompanies.Value) : decimal.Zero;

        var list = entities.VersionCompanies
            .Where(x => x.VersionID == versionID && x.CompanyID == companyID)
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

   
    #endregion
    protected void VersionCompanyGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
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
    }
    protected void cboCompanies_Init(object sender, EventArgs e)
    {
        var list = entities.DecCompanies.Where(x => x.CompanyType == "D").OrderBy(x => x.Seq).ToList();
        this.cboCompanies.DataSource = list;
        this.cboCompanies.ValueField = "CompanyID";
        this.cboCompanies.TextField = "NameV";
        this.cboCompanies.DataBind();
        if (this.cboCompanies.Items.Count > 0)
            this.cboCompanies.SelectedIndex = 0;
    }
    protected void StoresGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;

        string[] args = e.Parameters.Split('|');

        s.JSProperties["cpCommand"] = args[0];

        if (args[0] == "LoadStore" || args[0] == "RefreshStore")
        {
            decimal verCompanyID;
            if (!decimal.TryParse(args[1], out verCompanyID))
                return;

            LoadStores(verCompanyID);
        }
    }
    protected void StoresGrid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("Calculation"), "SUM"))
        {
            e.Row.Font.Bold = true;
        }
    }
    protected void VersionGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;

        string[] args = e.Parameters.Split('|');

        s.JSProperties["cpCommand"] = args[0];
    }
}