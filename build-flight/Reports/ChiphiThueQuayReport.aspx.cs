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

public partial class Reports_ChiphiThueQuayReport : BasePage
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
            this.dtFromMonth.Value = DateUtils.FirstDayOfMonth(true).Month;
            this.dtToMonth.Value = DateUtils.LastDayOfMonth(true).Month;

        }


    }


    protected MemoryStream CreateXlsxFileReport()
    {
        XtraReport report = null;
        if (rdReport.Value.ToString() == "ChiTietChiPhiThueQuay")
        {
            report = new ChiTietChiPhiThueQuay();
            report.Parameters["pVersionID"].Value = this.cboVersion.Value;
            report.Parameters["pAreaCode"].Value = this.cboAreaCode.Value;
            report.Parameters["pCarrier"].Value = this.cboCarrier.Value != null && this.cboCarrier.Value != string.Empty ? this.cboCarrier.Value.ToString() : "ALL";
            report.Parameters["pACID"].Value = this.cboAcGroup.Value != null && this.cboAcGroup.Value != string.Empty ? this.cboAcGroup.Value.ToString() : "ALL";
            report.Parameters["pFromMonth"].Value = this.dtFromMonth.Value;
            report.Parameters["pToMonth"].Value = this.dtToMonth.Value;
        }

        if (rdReport.Value.ToString() == "TongHopChiPhiThueQuay")
        {
            report = new TongHopChiPhiThueQuay();
            report.Parameters["pVersionID"].Value = this.cboVersion.Value;
            report.Parameters["pAreaCode"].Value = this.cboAreaCode.Value;
            report.Parameters["pCarrier"].Value = this.cboCarrier.Value != null && this.cboCarrier.Value != string.Empty ? this.cboCarrier.Value.ToString() : "ALL";
            report.Parameters["pACID"].Value = this.cboAcGroup.Value != null && this.cboAcGroup.Value != string.Empty ? this.cboAcGroup.Value.ToString() : "ALL";
            report.Parameters["pFromMonth"].Value = this.dtFromMonth.Value;
            report.Parameters["pToMonth"].Value = this.dtToMonth.Value;
        }

        if (rdReport.Value.ToString() == "CountersCostDetail")
        {
            report = new rptCountersCostDetail();
            report.Parameters["pVersionID"].Value = this.cboVersion.Value;
            report.Parameters["pDateStr"].Value = "Từ tháng: " + this.dtFromMonth.Value + " đến tháng: " + this.dtToMonth.Value;
            report.Parameters["pAreaCode"].Value = this.cboAreaCode.Value.ToString();
            report.Parameters["pFromMonth"].Value = this.dtFromMonth.Value;
            report.Parameters["pToMonth"].Value = this.dtToMonth.Value;
            report.Parameters["pCarrier"].Value = this.cboCarrier.Value != null && this.cboCarrier.Value != string.Empty ? this.cboCarrier.Value.ToString() : "ALL";
            report.Parameters["pNetwork"].Value = "ALL";
            //report.Parameters["pFltType"].Value = this.cboFltType.Value != null && this.cboFltType.Value != string.Empty ? this.cboFltType.Value.ToString() : "ALL";
        }

        if (rdReport.Value.ToString() == "CountersCostTotal")
        {
            report = new rptCountersCostTotal();
            report.Parameters["pVersionID"].Value = this.cboVersion.Value;
            report.Parameters["pDateStr"].Value = "Từ tháng: " + this.dtFromMonth.Value + " đến tháng: " + this.dtToMonth.Value;
            report.Parameters["pAreaCode"].Value = this.cboAreaCode.Value.ToString();
            report.Parameters["pFromMonth"].Value = this.dtFromMonth.Value;
            report.Parameters["pToMonth"].Value = this.dtToMonth.Value;
            report.Parameters["pCarrier"].Value = this.cboCarrier.Value != null && this.cboCarrier.Value != string.Empty ? this.cboCarrier.Value.ToString() : "ALL";
            report.Parameters["pNetwork"].Value = "ALL";
            //report.Parameters["pFltType"].Value = this.cboFltType.Value != null && this.cboFltType.Value != string.Empty ? this.cboFltType.Value.ToString() : "ALL";
        }

        MemoryStream stream = new MemoryStream();

        XlsxExportOptions options = new XlsxExportOptions();
        options.ExportMode = XlsxExportMode.SingleFile;
        options.SheetName = rdReport.Value.ToString();
        report.ExportToXlsx(stream, options);

        stream.Position = 0;
        return stream;
    }


    private bool hasParams(string name, XtraReport report)
    {
        foreach (var param in report.Parameters)
        {
            if (Object.Equals(param.Name, name))
                return true;
        }

        return false;
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
    protected void cboFltType_Init(object sender, EventArgs e)
    {
        ASPxTokenBox s = sender as ASPxTokenBox;

        var list = entities.DecTableValues
            .Where(x => x.Tables == "FLT_OPS" && x.Field == "FLT_TYPE")
            .Select(x => new { DefValue = x.DefValue, Description = x.DefValue + "-" + x.Description })
            .ToList();

        s.DataSource = list;

        s.ValueField = "DefValue";
        s.TextField = "DefValue";
        s.DataBind();
    }
    protected void cboVersion_Init(object sender, EventArgs e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        var versions = entities.Versions
            .Where(x => x.UsedStatus == "USED" && x.Active == true)
            .OrderByDescending(x => x.VersionYear)
            .ToList();
        cbo.DataSource = versions;
        cbo.ValueField = "VersionID";
        cbo.TextField = "Description";
        cbo.DataBind();

        if (cbo.Items.Count > 0)
            cbo.Value = cbo.Items[0];
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
    protected void cboAcGroup_Init(object sender, EventArgs e)
    {
        ASPxTokenBox s = sender as ASPxTokenBox;

        if (Session[SessionConstant.AC_LIST] != null)
            s.DataSource = Session[SessionConstant.AC_LIST];
        else
        {
            var list = entities.AcGroupConverts
                .Select(x => new { ACGroup = x.AcGroup.Trim() })
                .Distinct()
                .OrderBy(x => x.ACGroup).ToList();
            Session[SessionConstant.AC_LIST] = list;
            s.DataSource = list;
        }

        s.ValueField = "ACGroup";
        s.TextField = "ACGroup";
        s.DataBind();
    }
}