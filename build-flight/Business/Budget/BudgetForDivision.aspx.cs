
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Business_Budget_BudgetForDivision : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Initialize();

        LoadTree(0);

        // Report
        if (this.RevCostHiddenField.Contains("VerCompanyID"))
        {
            var verCompanyID1 = Convert.ToDecimal(RevCostHiddenField.Get("VerCompanyID"));
            var aVerCompany = entities.VersionCompanies.Where(x => x.VerCompanyID == verCompanyID1).FirstOrDefault();
            if (aVerCompany != null)
            {
                var aCompany = entities.DecCompanies.Where(x => x.CompanyID == aVerCompany.CompanyID).FirstOrDefault();
                if (aCompany != null)
                {
                    if (rdReport.Value.ToString().Equals("1"))
                    {
                        var aVersion = entities.Versions.Where(x => x.VersionID == aVerCompany.VersionID).FirstOrDefault();
                        if (aVersion != null)
                        {
                            //var report = new RptPlanningBudgetByPeriod();
                            //report.Parameters["pVerCompanyID"].Value = verCompanyID1;
                            //report.Parameters["pYear"].Value = aVersion.VersionYear;
                            //report.Parameters["pCompany"].Value = aCompany.NameV;
                            //report.Parameters["pRunTime"].Value = DateTime.Now;
                            //report.Parameters["pVersion"].Value = aVerCompany.VersionName;
                            //report.CreateDocument();
                            //ReportViewer.OpenReport( report);
                        }
                    }
                    else if (rdReport.Value.ToString().Equals("2"))
                    {
                        //var report = new RptPlanningBudget();
                        //report.Parameters["pVerCompanyID"].Value = verCompanyID1;
                        //report.Parameters["pCompany"].Value = aCompany.NameV;
                        //report.Parameters["pRunTime"].Value = DateTime.Now;
                        //report.Parameters["pFromDate"].Value = Convert.ToDateTime(dedFromDate.Value);
                        //report.Parameters["pToDate"].Value = Convert.ToDateTime(dedToDate.Value);
                        //report.CreateDocument();
                        //ReportViewer.OpenReport ( report);
                    }
                }
            }
        }
    }

    private void Initialize()
    {
        // Year
        this.VersionYearEditor.Value = DateTime.Now.Year;

        // Load Version
        LoadVersion();

        // Init Division
        gluDivision.Value = entities.DecCompanies.Where(x => x.CompanyType == "K" && x.Active == true).FirstOrDefault().CompanyID;
    }

    private void LoadVersion()
    {
        int aYear = Convert.ToInt32(VersionYearEditor.Value);
        grdVersion.DataSource = entities.Versions.Where(x => x.VersionYear == aYear && x.VersionType == rdoVersionType.Value.ToString()
            && x.Calculation == "BOTTOMUP" && x.Active == true).OrderBy(x => x.Sorting).ToList();
        grdVersion.DataBind();
    }

    private void LoadVersionCompanies(int pCompanyID, decimal pVersionID)
    {
        //var datasource = entities.VersionCompanies.Where(x => x.CompanyID == pCompanyID
        //    && x.VersionID == pVersionID && x.ReportType == "DOWN").OrderBy(x => x.VerLevel).ToList();
        var datasource = entities.VersionCompanies.Where(x => x.CompanyID == pCompanyID
            && x.VersionID == pVersionID).OrderBy(x => x.VerLevel).ToList();
        grdVersionCompany.DataSource = datasource;
        grdVersionCompany.DataBind();

        if (datasource == null || datasource.Count == 0)
            LoadTree(0);
    }

    private void GetAllChild(List<VersionCompanyView> lstVersionCompanyView, decimal pParentVerCompanyID)
    {
        var lstVerCompany = entities.VersionCompanyViews.Where(x => x.VerCompanyParentID == pParentVerCompanyID).ToList();
        lstVersionCompanyView.AddRange(lstVerCompany);

        foreach (var item in lstVerCompany)
        {
            GetAllChild(lstVersionCompanyView, item.VerCompanyID);
        }
    }

    private void LoadTree(decimal verCompanyID)
    {
        decimal pVerCompanyID = 0;
        if (verCompanyID > 0)
            pVerCompanyID = verCompanyID;
        else
        {
            if (grdVersionCompany.FocusedRowIndex < 0)
            {
                tltVersion.DataSource = null;
                tltVersion.DataBind();
                return;
            }
            pVerCompanyID = Convert.ToDecimal(grdVersionCompany.GetRowValues(grdVersionCompany.FocusedRowIndex, "VerCompanyID"));
        }

        List<VersionCompanyView> lstVersionCompanyView = entities.VersionCompanyViews.Where(x => x.VerCompanyID == pVerCompanyID).ToList();
        GetAllChild(lstVersionCompanyView, pVerCompanyID);

        tltVersion.DataSource = lstVersionCompanyView.Select(x => new
                                                                    {
                                                                        VerCompanyID = x.VerCompanyID,
                                                                        VerCompanyParentID = x.VerCompanyParentID,
                                                                        Name = x.CompanyType + " - " + x.VersionName + " - " + x.ShortName + " - " + x.NameV
                                                                    });
        tltVersion.DataBind();
        tltVersion.ExpandAll();
    }

    private void LoadStores()
    {

    }

    protected void DivisionDatasource_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
    {
        e.QueryableSource = entities.DecCompanies.Where(x => x.CompanyType == "K" && x.Active == true);
        //e.QueryableSource = entities.Companies.Where(x => x.Active == true);
        e.KeyExpression = "CompanyID";
    }

    protected void grdVersion_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0].Equals("Reload"))
            LoadVersion();
    }
    protected void grdVersionCompany_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0].Equals("Reload"))
        {
            if (args.Count() > 1 && args[1].Equals("null"))
            {
                grdVersionCompany.DataSource = null;
                grdVersionCompany.DataBind();
                return;
            }

            decimal aVersionID = 0;
            if (args.Count() > 1 && !args[1].Equals("0"))
            {
                aVersionID = Convert.ToDecimal(args[1]);
            }
            else
            {
                if (grdVersion.FocusedRowIndex < 0 || gluDivision.Value == null)
                {
                    grdVersionCompany.DataSource = null;
                    grdVersionCompany.DataBind();
                    return;
                }
                aVersionID = Convert.ToDecimal(grdVersion.GetRowValues(grdVersion.FocusedRowIndex, "VersionID"));
            }            
            int aCompanyID = Convert.ToInt32(gluDivision.Value);
            LoadVersionCompanies(aCompanyID, aVersionID);
        }
    }
    protected void tltVersion_CustomCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomCallbackEventArgs e)
    {
        string[] args = e.Argument.Split('|');
        if (args[0].Equals("Reload"))
        {
            if (args.Count() > 1 && !args[1].Equals("null"))
            {
                decimal verCompanyID = Convert.ToDecimal(args[1]); ;
                LoadTree(verCompanyID);
            }
        }
    }
    protected void grdStore_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args.Count() > 1)
        {
            if (args[0].Equals("Gen"))
            {
                decimal aVerCompanyID = Convert.ToDecimal(args[1]);
                entities.GenBudget(aVerCompanyID);
                grdStore.DataSource = entities.TmpBudgets.OrderBy(x => x.SEQ).ToList();
                grdStore.DataBind();
            }
            else if (args[0].Equals("General"))
            {
                decimal aVerCompanyIDDivision = Convert.ToDecimal(args[1]);
                decimal aVerCompanyID = Convert.ToDecimal(args[2]);

                var aVerCompany = entities.VersionCompanies.Find(aVerCompanyID);
                entities.GenralBudget(aVerCompany.VersionID.Value, aVerCompany.CompanyID, aVerCompanyIDDivision, SessionUser.UserName);
            }
            
            
        }
    }

    protected void StoresGrid_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("CALCULATION"), "SUM"))
            e.Row.Font.Bold = true;
    }
}