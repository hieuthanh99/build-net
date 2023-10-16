using DevExpress.XtraPrinting;
using KTQTData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Business_RevenueCost_RevenueCostForDivision : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Initialize();

        LoadTree(0);

        if (Session["VercompanyID"] != null)
        {
            var aVerCompanyID = Convert.ToDecimal(Session["VercompanyID"]);
            LoadDivisionStore(aVerCompanyID, SessionUser.SessionID);
        }

    }

    private void Initialize()
    {
        Session.Remove("VercompanyID");
        // Year
        this.txtYear.Value = DateTime.Now.Year;

        // Load Version
        LoadVersion();

        // Init Division
        var company = entities.DecCompanies.Where(x => x.CompanyType == "K" && x.Active == true && x.Seq == 0)
              .FirstOrDefault();
        if (company != null)
            gluDivision.Value = company.CompanyID;
    }

    private void LoadVersion()
    {
        int aYear = Convert.ToInt32(txtYear.Value);
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
        e.QueryableSource = entities.DecCompanies.Where(x => x.CompanyType == "K" && x.Active == true).OrderBy(x => x.Seq);
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
    protected void grdStore_CustomCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomCallbackEventArgs e)
    {
        string[] args = e.Argument.Split('|');
        if (args.Count() > 1)
        {
            if (args[0].Equals("Gen"))
            {
                try
                {
                    decimal aVerCompanyID = Convert.ToDecimal(args[1]);
                    entities.DivisionGenStore(aVerCompanyID, SessionUser.SessionID, DateTime.Now.Date);
                    LoadDivisionStore(aVerCompanyID, SessionUser.SessionID);
                    Session["VercompanyID"] = aVerCompanyID;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (args[0].Equals("General"))
            {
                try
                {
                    decimal aVerCompanyIDDivision = Convert.ToDecimal(args[1]);
                    decimal aVerCompanyID = Convert.ToDecimal(args[2]);
                    entities.DivisionGenStore(aVerCompanyID, SessionUser.SessionID, DateTime.Now.Date);
                    LoadDivisionStore(aVerCompanyID, SessionUser.SessionID);
                    Session["VercompanyID"] = aVerCompanyID;

                    //  var aVerCompany = entities.VersionCompanies.Find(aVerCompanyID);
                    //  entities.GenralBudget(aVerCompany.VersionID.Value, aVerCompany.CompanyID, aVerCompanyIDDivision, SessionUser.UserName);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


        }
    }

    private void LoadDivisionStore(decimal aVerCompanyID, string aSessionID)
    {
        grdStore.DataSource = entities.TmpStores.Where(x => x.VER_COMPANY_ID == aVerCompanyID && x.SessionID == aSessionID)
            .OrderByDescending(x => x.ACCOUNTGROUP)
            .ThenBy(x => x.SEQ).ToList();
        grdStore.DataBind();
        grdStore.ExpandAll();
    }

    protected void StoresGrid_HtmlRowPrepared(object sender, DevExpress.Web.ASPxTreeList.TreeListHtmlRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("CALCULATION"), "SUM"))
            e.Row.Font.Bold = true;
    }

    // Exxport file Exxel duwx lieu chi tiet
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExporter.FileName = "RevenueCostForDivision";
        DevExpress.XtraPrinting.XlsxExportOptionsEx options = new DevExpress.XtraPrinting.XlsxExportOptionsEx() { ExportType = DevExpress.Export.ExportType.WYSIWYG };
        options.SheetName = "RevenueCostForDivision";
        GridViewExporter.WriteXlsxToResponse(options);
        //int aVercompanyID = 0;
        //int aCompanyID = 0;
        //string aCompanyName = string.Empty;
        //string aAreaCode = string.Empty;
        //try
        //{
        //    aVercompanyID = Convert.ToInt32(Session["VercompanyID"].ToString());
        //    var verCom = entities.VersionCompanies.Where(x => x.VerCompanyID == aVercompanyID).SingleOrDefault();
        //    aCompanyID = Convert.ToInt32(verCom != null && verCom.CompanyID.HasValue ? verCom.CompanyID.Value : 0);

        //    var company = entities.DecCompanies.Where(x => x.CompanyID == aCompanyID).SingleOrDefault();
        //    if (company != null)
        //    {
        //        aCompanyName = company.NameV;
        //        aAreaCode = company.AreaCode;
        //    }
        //    var report = new ExportRevCostForDevision();
        //    report.Parameters["P_VERCOMPANYID"].Value = aVercompanyID;
        //    report.Parameters["P_COMPANYNAME"].Value = aAreaCode + "-" + aCompanyName;

        //    MemoryStream stream = new MemoryStream();

        //    XlsxExportOptions options = new XlsxExportOptions();
        //    options.ExportMode = XlsxExportMode.SingleFile;

        //    report.ExportToXlsx(stream, options);

        //    stream.Position = 0;


        //    Response.Clear();
        //    Response.ContentType = "application/xls";
        //    Response.AddHeader("Accept-Header", stream.Length.ToString());
        //    Response.AddHeader("Content-Disposition", "Attachment; filename=RevCostForCompany.xlsx");
        //    Response.AddHeader("Content-Length", stream.Length.ToString());
        //    Response.ContentEncoding = System.Text.Encoding.Default;
        //    Response.OutputStream.Write(stream.ToArray(), 0, Convert.ToInt32(stream.Length));
        //    Response.End();

        //}
        //catch (Exception ex)
        //{

        //}


    }


}