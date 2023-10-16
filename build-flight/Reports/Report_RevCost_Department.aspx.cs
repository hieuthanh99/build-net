using DevExpress.Web;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using KTQTData;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.UI.WebControls;

public partial class Report_RevCost_Department : BasePage
{

    KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi-VN");

            // Chon cac gia tri ban dau
            this.cboFMonth.Value = 1;
            this.cboToMonth.Value = 12;

            decimal aVercompanyID;
            if (decimal.TryParse(Session["VerCompanyID"].ToString(), out aVercompanyID))
            {
                var versionCompany = entities.VersionCompanies.Where(x => x.VerCompanyID == aVercompanyID).SingleOrDefault();
                if (versionCompany != null)
                {
                    var aVersionID = versionCompany.VersionID;

                    var aVersion = entities.Versions.Where(x => x.VersionID == aVersionID).SingleOrDefault();
                    if (aVersion != null)
                    {
                        this.cboVersion.Text = aVersion.VersionType + aVersion.VersionYear + "-" + aVersion.Description;
                        this.cboVersion.Value = Convert.ToInt32(aVersionID);
                    }
                    // Version thuc hien
                    var version = entities.Versions.Where(x => x.VersionYear == aVersion.VersionYear && x.VersionType == "A" && x.UsedStatus == "USED").SingleOrDefault();
                    if (version != null)
                    {
                        aVersion = entities.Versions.Where(x => x.VersionID == version.VersionID).SingleOrDefault();
                        if (aVersion != null)
                        {
                            this.cboVersionBase2.Text = aVersion.VersionType + aVersion.VersionYear + "-" + aVersion.Description;
                            this.cboVersionBase2.Value = Convert.ToInt32(aVersionID);
                        }
                    }
                }
            }

        }


    }

    //protected void CurrentVersionDataSource_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
    //{
    //    int companyID;
    //    try
    //    {
    //        companyID = Convert.ToInt32(SessionUser.CompanyID);
    //        e.QueryableSource = entities.VersionCompanies.Where(x => x.CompanyID == companyID && x.Active == true && x.HotData == true).OrderByDescending(x => x.VersionID);
    //        e.KeyExpression = "VerCompanyID";

    //    }
    //    catch (Exception)
    //    {
    //    }

    //}
    //protected void CurrentVerBase1DataSource_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
    //{

    //    decimal verCompanyId;
    //    try
    //    {
    //        if (decimal.TryParse(Session["VerCompanyID"].ToString(), out verCompanyId))
    //        {
    //            var aVersionCompany = entities.VersionCompanies.SingleOrDefault(x => x.VerCompanyID == verCompanyId);
    //            e.QueryableSource = entities.VersionCompanies.Where(x => x.CompanyID == aVersionCompany.CompanyID && x.Active == true && x.HotData == true).OrderByDescending(x => x.VersionID);
    //            e.KeyExpression = "VerCompanyID";
    //        }
    //    }
    //    catch (Exception)
    //    {
    //    }
    //}
    //protected void CurrentVerBase2DataSource_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
    //{

    //    decimal verCompanyId;
    //    try
    //    {
    //        if (decimal.TryParse(Session["VerCompanyID"].ToString(), out verCompanyId))
    //        {
    //            var aVersionCompany = entities.VersionCompanies.SingleOrDefault(x => x.VerCompanyID == verCompanyId);
    //            e.QueryableSource = entities.VersionCompanies.Where(x => x.CompanyID == aVersionCompany.CompanyID && x.Active == true && x.HotData == true).OrderByDescending(x => x.VersionID);
    //            e.KeyExpression = "VerCompanyID";
    //        }
    //    }
    //    catch (Exception)
    //    {
    //    }
    //}
    //protected void CurrentVerBase3DataSource_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
    //{

    //    decimal verCompanyId;
    //    if (decimal.TryParse(Session["VerCompanyID"].ToString(), out verCompanyId))
    //    {
    //        var aVersionCompany = entities.VersionCompanies.SingleOrDefault(x => x.VerCompanyID == verCompanyId);
    //        e.QueryableSource = entities.VersionCompanies.Where(x => x.CompanyID == aVersionCompany.CompanyID && x.Active == true && x.HotData == true).OrderByDescending(x => x.VersionID);
    //        e.KeyExpression = "VerCompanyID";
    //    }
    //}



    protected MemoryStream CreateXlsxFileReport()
    {
        XtraReport report = null;
        // Bao cao

        if (rdReport.Value.ToString() == "RevCostChiTietThuChi")
        {
            int verCompanyId;
            report = new RevCost_ChitietThuChi();
            try
            {
                int.TryParse(Session["VERCOMPANYID"].ToString(), out verCompanyId);
                // Add tham so
                report.Parameters["pVercompanyId"].Value = Convert.ToInt32(verCompanyId);
            }
            catch (Exception) { }
        }
        else if (rdReport.Value.ToString() == "RevCostDanhGiaKehoach")
        {

            decimal p_Ver_Company_Id, p_Ver_Company_Id_Base1, p_Ver_Company_Id_Base2;

            int p_fMonth;
            int p_toMonth;
            string pCreated_user;

            int p_CompanyId;
            string hochiphi;
            string year;

            decimal aVersionID, aVersionBase1ID, aVersionBase2ID;

            report = new RevCost_DanhGia_KH();
            //QLKHDataEntities entities = new QLKHDataEntities();

            try
            {
                if (decimal.TryParse(Session["VerCompanyID"].ToString(), out p_Ver_Company_Id))
                {
                    p_CompanyId = (int)entities.VersionCompanies.Where(x => x.VerCompanyID == p_Ver_Company_Id).SingleOrDefault().CompanyID;

                    var company = entities.DecCompanies.Where(x => x.CompanyID == p_CompanyId).SingleOrDefault();
                    hochiphi = company.AreaCode + "-" + company.NameV;
                    // Xác định VerCompanyID

                    if (string.IsNullOrEmpty(this.cboVersion.Value.ToString()))
                        aVersionID = 0;
                    else
                        aVersionID = decimal.Parse(this.cboVersion.Value.ToString());

                    var aversion = entities.Versions.Where(x => x.VersionID == aVersionID).SingleOrDefault();
                    year = aversion.VersionYear.ToString();
                    //if (string.IsNullOrEmpty(this.cboVersionBase1.Value.ToString()))
                    //  aVersionBase1ID = 0;
                    //else
                    aVersionBase1ID = this.cboVersionBase1.Value.ToString() == null ? 0 : decimal.Parse(this.cboVersionBase1.Value.ToString());
                    //aVersionBase1ID = decimal.Parse(this.cboVersionBase1.Value.ToString());

                    if (string.IsNullOrEmpty(this.cboVersionBase2.Value.ToString()))
                        aVersionBase2ID = 0;
                    else
                        aVersionBase2ID = decimal.Parse(this.cboVersionBase2.Value.ToString());



                    p_Ver_Company_Id = (decimal)entities.VersionCompanies.Where(x => x.VersionID == aVersionID && x.CompanyID == p_CompanyId && x.HotData == true).SingleOrDefault().VerCompanyID;
                    p_Ver_Company_Id_Base1 = (decimal)entities.VersionCompanies.Where(x => x.VersionID == aVersionBase1ID && x.CompanyID == p_CompanyId && x.HotData == true).SingleOrDefault().VerCompanyID;
                    p_Ver_Company_Id_Base2 = (decimal)entities.VersionCompanies.Where(x => x.VersionID == aVersionBase2ID && x.CompanyID == p_CompanyId && x.HotData == true).SingleOrDefault().VerCompanyID;
                    p_fMonth = Convert.ToInt32(this.cboFMonth.Value.ToString());
                    p_toMonth = Convert.ToInt32(this.cboToMonth.Value.ToString());
                    pCreated_user = SessionUser.UserID.ToString();

                    entities.Report_RevCost_DanhGia_KH(p_Ver_Company_Id, p_Ver_Company_Id_Base1, p_Ver_Company_Id_Base2, p_fMonth, p_fMonth, p_fMonth, p_toMonth, p_toMonth, p_toMonth, pCreated_user);
                    //report.Parameters["p_Ver_Company_Id"].Value = p_Ver_Company_Id;
                    report.Parameters["pCreated_user"].Value = pCreated_user;
                    report.Parameters["p_fMonth"].Value = p_fMonth;
                    report.Parameters["p_toMonth"].Value = p_toMonth;
                    report.Parameters["pHochiphi"].Value = hochiphi;
                    report.Parameters["pYear"].Value = year;
                    report.Parameters["p_VercompanyID"].Value = p_Ver_Company_Id;
                    report.Parameters["p_VercompanyBase1ID"].Value = p_Ver_Company_Id_Base1;
                    report.Parameters["p_VercompanyBase2ID"].Value = p_Ver_Company_Id_Base2;
                }
            }
            catch (Exception) { }
        }




        // Tao bao cao
        MemoryStream stream = new MemoryStream();

        XlsxExportOptions options = new XlsxExportOptions();
        options.ExportMode = XlsxExportMode.SingleFile;
        options.SheetName = rdReport.Value.ToString();
        report.ExportToXlsx(stream, options);

        stream.Position = 0;
        return stream;
    }

    protected void cboVersion_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Versions.Where(x => x.Active ?? true).OrderByDescending(x => x.VersionYear).ThenByDescending(x => x.VersionID).ToList();
        ListEditItem le = new ListEditItem();
        foreach (var item in list)
        {
            le = new ListEditItem();
            le.Text = item.VersionType + item.VersionYear + '-' + item.Description;
            le.Value = Convert.ToInt32(item.VersionID);
            s.Items.Add(le);
        }
    }
    protected void cboVersionBase1_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Versions.Where(x => x.Active ?? true).OrderByDescending(x => x.VersionYear).ThenByDescending(x => x.VersionID).ToList();
        ListEditItem le = new ListEditItem();
        foreach (var item in list)
        {
            le = new ListEditItem();
            le.Text = item.VersionType + item.VersionYear + '-' + item.Description;
            le.Value = Convert.ToInt32(item.VersionID);
            s.Items.Add(le);
        }
    }
    protected void cboVersionBase2_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Versions.Where(x => x.Active ?? true).OrderByDescending(x => x.VersionYear).ThenByDescending(x => x.VersionID).ToList();
        ListEditItem le = new ListEditItem();
        foreach (var item in list)
        {
            le = new ListEditItem();
            le.Text = item.VersionType + item.VersionYear + '-' + item.Description;
            le.Value = Convert.ToInt32(item.VersionID);
            s.Items.Add(le);
        }
    }

    protected void cboFMonth_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        ListEditItem le = new ListEditItem();
        for (int i = 1; i <= 12; i++)
        {
            le = new ListEditItem();
            le.Text = i.ToString();
            le.Value = i;
            s.Items.Add(le);
        }
    }
    protected void cboToMonth_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        ListEditItem le = new ListEditItem();
        for (int i = 1; i <= 12; i++)
        {
            le = new ListEditItem();
            le.Text = i.ToString();
            le.Value = i;
            s.Items.Add(le);
        }
    }

    string fileExtension(string format)
    {
        switch (format)
        {
            case "XLSX": return ".xlsx";
            case "PDF": return ".pdf";
            case "RTF": return ".rtf";
            case "HTML": return ".html";
            default: break;
        }
        return "XLSX";
    }
    protected void ASPxCallbackPanel1_Callback(object sender, CallbackEventArgsBase e)
    {
        ASPxSpreadsheet1.Open(Guid.NewGuid().ToString(), DevExpress.Spreadsheet.DocumentFormat.Xlsx, () => { return CreateXlsxFileReport(); });
    }




}