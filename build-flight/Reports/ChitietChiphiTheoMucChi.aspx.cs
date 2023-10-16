using DevExpress.Web;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using KTQTData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_ChitietChiphiTheoMucChi : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi-VN");
            string areaCode = string.Empty;
            var curCompany = entities.DecCompanies.SingleOrDefault(x => x.CompanyID == SessionUser.CompanyID);
            if (curCompany != null)
                areaCode = curCompany.AreaCode == "KCQ" ? "ALL" : curCompany.AreaCode;

            this.cboAreaCode.Value = StringUtils.isEmpty(areaCode) ? "ALL" : areaCode;
            //LoadCompany(cboCompany, StringUtils.isEmpty(areaCode) ? "ALL" : areaCode);
            this.dtFromDate.Value = DateUtils.FirstDayOfMonth(true);
            this.dtToDate.Value = DateUtils.LastDayOfMonth(true);
        }

    }


    protected MemoryStream CreateXlsxFileReport()
    {
        XtraReport report = null;
        if (rdReport.Value.ToString() == "GiathanhChuyenbay")
        {
            report = new SosanhGiathanhCacChuyenbay();
        }
        else if (rdReport.Value.ToString() == "ChiphiBinhquan")
        {
            report = new ChiphiBinhquanTheohang();
        }

        report.Parameters["pDateStr"].Value = "Từ ngày: " + (this.dtFromDate.Date).ToString("dd/MM/yyyy") + " đến ngày: " + (this.dtToDate.Date).ToString("dd/MM/yyyy");
        report.Parameters["pAreaCode"].Value = this.cboAreaCode.Value.ToString();
        report.Parameters["pVersionID"].Value = this.cboVersion.Value;
        //report.Parameters["pCompanyID"].Value = this.cboCompany.Value;
        report.Parameters["pFromDate"].Value = this.dtFromDate.Value;
        report.Parameters["pToDate"].Value = this.dtToDate.Value;
        report.Parameters["pCarrier"].Value = StringUtils.isEmpty(this.txtCarrier.Text) ? "XX" : this.txtCarrier.Text;
        report.Parameters["pACID"].Value = StringUtils.isEmpty(this.txtAircraft.Text) ? "XXXX" : this.txtAircraft.Text;

        MemoryStream stream = new MemoryStream();

        XlsxExportOptions options = new XlsxExportOptions();
        options.ExportMode = XlsxExportMode.SingleFile;
        options.SheetName = rdReport.Value.ToString();
        report.ExportToXlsx(stream, options);

        stream.Position = 0;
        return stream;
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
    protected void cboCompany_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        string areaCode = e.Parameter;
        LoadCompany(cbo, areaCode);


    }

    private void LoadCompany(ASPxComboBox cbo, string areaCode)
    {
        cbo.Items.Clear();
        if (areaCode.Equals("ALL"))
        {
            var list = entities.DecCompanies
                .Where(x => x.CompanyType == "D" && x.Active == true)
                .Select(x => new { CompanyID = x.CompanyID, NameV = x.AreaCode + "-" + x.NameV })
                .ToList();

            ListEditItem le = new ListEditItem();
            le.Value = 0;
            le.Text = "--All--";
            cbo.Items.Add(le);
            foreach (var item in list)
            {
                le = new ListEditItem();
                le.Value = item.CompanyID;
                le.Text = item.NameV;
                cbo.Items.Add(le);
            }
            //cbo.DataSource = list;
            //cbo.ValueField = "CompanyID";
            //cbo.TextField = "NameV";
            //cbo.DataBind();
        }
        else
        {
            var list = entities.DecCompanies
                .Where(x => x.CompanyType == "D" && x.AreaCode == areaCode && x.Active == true)
                .Select(x => new { CompanyID = x.CompanyID, NameV = x.AreaCode + "-" + x.NameV })
                .ToList();
            ListEditItem le = new ListEditItem();
            le.Value = 0;
            le.Text = "--All--";
            cbo.Items.Add(le);
            foreach (var item in list)
            {
                le = new ListEditItem();
                le.Value = item.CompanyID;
                le.Text = item.NameV;
                cbo.Items.Add(le);
            }
            //cbo.DataSource = list;
            //cbo.ValueField = "CompanyID";
            //cbo.TextField = "NameV";
            //cbo.DataBind();
        }
    }
    protected void cboVersion_Init(object sender, EventArgs e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        var versions = entities.Versions.Where(x => x.Active == true).ToList();
        cbo.DataSource = versions;
        cbo.ValueField = "VersionID";
        cbo.TextField = "Description";
        cbo.DataBind();
    }
    protected void ASPxCallbackPanel1_Callback(object sender, CallbackEventArgsBase e)
    {
        ASPxSpreadsheet1.Open(Guid.NewGuid().ToString(), DevExpress.Spreadsheet.DocumentFormat.Xlsx, () => { return CreateXlsxFileReport(); });
    }
    protected void cboAreaCode_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Airports.Where(x => (x.IsCity ?? false) == true).ToList();

        ListEditItem le = new ListEditItem();
        le.Value = "ALL";
        le.Text = "--ALL--";
        s.Items.Add(le);
        foreach (var item in list)
        {
            le = new ListEditItem();
            le.Value = item.Code;
            le.Text = item.NameE;
            s.Items.Add(le);
        }

        if (s.Items.Count > 0)
            s.Value = SessionUser.AreaCode != "KCQ" ? SessionUser.AreaCode : "ALL";
    }
}