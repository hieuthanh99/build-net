using DevExpress.Web;
using KTQTData;
using System;
using System.Linq;


public partial class Business_RouteProfit_RouteProfit : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        //|| this.VersionGrid.IsCallback || this.VersionCompanyGrid.IsCallback
        if (!IsPostBack)
        {
            if (rdoVersionType.Value != null)
            {
                string versionType = rdoVersionType.Value.ToString();
                LoadVersions(versionType);
            }
        }

    }
    #region Load data

    private void LoadVersions(string versionType)
    {
        var list = entities.Versions.Where(x => x.VersionType == versionType && x.Calculation == "BOTTOMUP" && x.Status != "APPROVED").OrderByDescending(x => x.VersionYear).OrderBy(x => x.Sorting).ToList();
        this.VersionGrid.DataSource = list;
        this.VersionGrid.DataBind();
    }


    private void LoadVersionCompany(decimal versionID)
    {
        var list = entities.VersionCompanyViews.Where(x => x.VersionID == versionID).ToList();
        this.VersionCompanyGrid.DataSource = list;
        this.VersionCompanyGrid.DataBind();
    }

    #endregion

    protected void VersionGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        switch (args[0])
        {
            case "Reload":
                if (rdoVersionType.Value != null)
                {
                    string versionType = rdoVersionType.Value.ToString();
                    LoadVersions(versionType);
                }
                break;
        }
    }
    protected void VersionCompanyGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {

        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        switch (args[0])
        {
            case "Reload":
                decimal versionID;
                if (!decimal.TryParse(args[1], out versionID))
                    return;
                LoadVersionCompany(versionID);
                break;
        }
    }
}