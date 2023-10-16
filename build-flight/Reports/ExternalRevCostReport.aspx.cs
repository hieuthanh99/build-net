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

public partial class Reports_ExternalRevCostReport : BasePage
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
                areaCode = curCompany.AreaCode == "KCQ" ? "CTY" : curCompany.AreaCode;

            this.cboAreaCode.Value = StringUtils.isEmpty(areaCode) ? "ALL" : areaCode;
            this.dtFromMonth.Value = DateUtils.FirstDayOfMonth(true).Month;
            this.dtToMonth.Value = DateUtils.LastDayOfMonth(true).Month;
            this.dtYear.Value = DateUtils.FirstDayOfMonth(true).Year;
        }
    }

    protected MemoryStream CreateXlsxFileReport()
    {
        XtraReport report = null;
        if (rdReport.Value.ToString() == "ExternalRevCost")
        {
            report = new BCDoanhthuNCB();

            report.Parameters["pVersionType"].Value = "A";
        }
        if (rdReport.Value.ToString() == "ExternalRevCostM2")
        {
            report = new BCDoanhthuNCB_M2();

            report.Parameters["pVersionType"].Value = "A";
        }
        if (rdReport.Value.ToString() == "BCTTNDN")
        {
            report = new BCTTNDN();

            report.Parameters["pVersionType"].Value = "A";
        }
        else if (rdReport.Value.ToString() == "ExtRevCostDetail")
        {
            report = new CTDoanhthuCPNCB();
        }
        else if (rdReport.Value.ToString() == "ExtRevCostDetailM2")
        {
            report = new CTDoanhthuCPNCB_M2();
        }
        else if (rdReport.Value.ToString() == "TTNDNDetail")
        {
            report = new CTTTNDN();
        }

        report.Parameters["pAreaCode"].Value = this.cboAreaCode.Value.ToString();
        report.Parameters["pFromMonth"].Value = this.dtFromMonth.Value;
        report.Parameters["pToMonth"].Value = this.dtToMonth.Value;
        report.Parameters["pYear"].Value = this.dtYear.Value;
       

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
    protected void cboCarrier_Init(object sender, EventArgs e)
    {
        ASPxTokenBox s = sender as ASPxTokenBox;

        var list = entities.Code_Airlines
            .Select(x => new { AirlinesCode = x.AirlinesCode })
            .ToList();
        s.DataSource = list;
        s.ValueField = "AirlinesCode";
        s.TextField = "AirlinesCode";
        s.DataBind();
    }

    protected void ASPxCallbackPanel1_Callback(object sender, CallbackEventArgsBase e)
    {
        ASPxSpreadsheet1.Open(Guid.NewGuid().ToString(), DevExpress.Spreadsheet.DocumentFormat.Xlsx, () => { return CreateXlsxFileReport(); });
    }
    protected void cboAreaCode_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Airports.Where(x => (x.VNDes ?? false) == true).ToList();

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
            s.Value = SessionUser.AreaCode != "KCQ" ? SessionUser.AreaCode : "CTY";
    }
}