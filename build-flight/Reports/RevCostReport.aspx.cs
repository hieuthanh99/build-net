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

public partial class Reports_RevCostReport : BasePage
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
            this.dtFromDate.Value = DateUtils.FirstDayOfMonth(true);
            this.dtToDate.Value = DateUtils.LastDayOfMonth(true);
            this.cboNetwork.Value = "ALL";
            this.cboCostType.Value = "ALL";
        }


    }


    protected MemoryStream CreateXlsxFileReport()
    {
        XtraReport report = null;
        if (rdReport.Value.ToString() == "DTChuyenbay")
        {
            report = new SLDoanhthuChiphiChuyenbay();
            if (this.cboVersion.Value != null)
            {
                decimal versionID = Convert.ToDecimal(this.cboVersion.Value);
                var version = entities.Versions.SingleOrDefault(x => x.VersionID == versionID);
                if (version != null)
                {
                    if (version.VersionType == "P")
                        report = new SLDoanhthuChiphiChuyenbayKH();
                    else
                        report = new SLDoanhthuChiphiChuyenbay();
                }
            }
            report.Parameters["pVersionID"].Value = this.cboVersion.Value;
            report.Parameters["pCostType"].Value = this.cboCostType.Value;
        }
        else if (rdReport.Value.ToString() == "ChitietDTChuyenbay")
        {
            report = new ChitietSLDoanhthuChiphiChuyenbay();
            if (this.cboVersion.Value != null)
            {
                decimal versionID = Convert.ToDecimal(this.cboVersion.Value);
                var version = entities.Versions.SingleOrDefault(x => x.VersionID == versionID);
                if (version != null)
                {
                    if (version.VersionType == "P")
                        report = new ChitietSLDoanhthuChiphiChuyenbayKH();
                    else
                        report = new ChitietSLDoanhthuChiphiChuyenbay();
                }
            }
            report.Parameters["pVersionID"].Value = this.cboVersion.Value;
            report.Parameters["pCostType"].Value = this.cboCostType.Value;
        }
        else if (rdReport.Value.ToString() == "DTKhongChuyenbay")
        {
            report = new DTKhongTheoChuyenbay();
        }
        else if (rdReport.Value.ToString() == "ChiphiBinhquan")
        {
            report = new AverageCostByCarrier();
            report.Parameters["pVersionID"].Value = this.cboVersion.Value;
            report.Parameters["pCostType"].Value = this.cboCostType.Value;
        }
        else if (rdReport.Value.ToString() == "TonDTChiphi")
        {
            report = new TongDTChiphi();
            if (this.cboVersion.Value != null)
            {
                decimal versionID = Convert.ToDecimal(this.cboVersion.Value);
                var version = entities.Versions.SingleOrDefault(x => x.VersionID == versionID);
                if (version != null)
                {
                    if (version.VersionType == "P")
                        report = new TongDTChiphiKH();
                    else
                        report = new TongDTChiphi();
                }
            }
            report.Parameters["pVersionID"].Value = this.cboVersion.Value;
            report.Parameters["pCostType"].Value = this.cboCostType.Value;
        }
        else if (rdReport.Value.ToString() == "PhanLoaiChiphi")
        {
            report = new ChitietChiphiTheoNhomChiphi();
            if (this.cboVersion.Value != null)
            {
                decimal versionID = Convert.ToDecimal(this.cboVersion.Value);
                var version = entities.Versions.SingleOrDefault(x => x.VersionID == versionID);
                if (version != null)
                {
                    if (version.VersionType == "P")
                        report = new ChitietChiphiTheoNhomChiphiKH();
                    else
                        report = new ChitietChiphiTheoNhomChiphi();
                }
            }
            report.Parameters["pVersionID"].Value = this.cboVersion.Value;
            report.Parameters["pCostType"].Value = this.cboCostType.Value;
        }
        else if (rdReport.Value.ToString() == "PhanNhomChiphi")
        {
            report = new ChiphiTheoNhomFields();
            if (this.cboVersion.Value != null)
            {
                decimal versionID = Convert.ToDecimal(this.cboVersion.Value);
                var version = entities.Versions.SingleOrDefault(x => x.VersionID == versionID);
                if (version != null)
                {
                    if (version.VersionType == "P")
                        report = new ChiphiTheoNhomFieldsKH();
                    else
                        report = new ChiphiTheoNhomFields();
                }
            }
            report.Parameters["pVersionID"].Value = this.cboVersion.Value;
            report.Parameters["pCostType"].Value = this.cboCostType.Value;
        }
        else if (rdReport.Value.ToString() == "PhanLoaiChiphi2")
        {
            report = new ChiphiTheoNhomPhanloai();
            report.Parameters["pVersionID"].Value = this.cboVersion.Value;
            report.Parameters["pCostType"].Value = this.cboCostType.Value;
        }
        else if (rdReport.Value.ToString() == "PhanNhomChiphi2")
        {
            report = new ChiphiTheoRouteProfit();
            report.Parameters["pVersionID"].Value = this.cboVersion.Value;
            report.Parameters["pCostType"].Value = this.cboCostType.Value;
        }
        else if (rdReport.Value.ToString() == "PhanNhomDoanhThu")
        {
            report = new DTCPTheo8NhomChiPhi();
            report.Parameters["pVersionID"].Value = this.cboVersion.Value;
            report.Parameters["pCostType"].Value = this.cboCostType.Value;
        }
        else if (rdReport.Value.ToString() == "CTDTKhongTheoCB")
        {
            report = new ChitietDTKhongTheoCB();

        }
        report.Parameters["pDateStr"].Value = "Từ ngày: " + (this.dtFromDate.Date).ToString("dd/MM/yyyy") + " đến ngày: " + (this.dtToDate.Date).ToString("dd/MM/yyyy");
        report.Parameters["pAreaCode"].Value = this.cboAreaCode.Value.ToString();
        report.Parameters["pFromDate"].Value = this.dtFromDate.Value;
        report.Parameters["pToDate"].Value = this.dtToDate.Value;
        report.Parameters["pCarrier"].Value = this.cboCarrier.Value != null && this.cboCarrier.Value != string.Empty ? this.cboCarrier.Value.ToString() : "ALL";
        report.Parameters["pNetwork"].Value = this.cboNetwork.Value.ToString();
        report.Parameters["pFltType"].Value = this.cboFltType.Value != null && this.cboFltType.Value != string.Empty ? this.cboFltType.Value.ToString() : "ALL";

        if (hasParams("pNotProfitable", report))
        {
            report.Parameters["pNotProfitable"].Value = this.chkNotProfitable.Value;
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
            .Where(x => x.Active == true)
            .OrderByDescending(x => x.VersionYear)
            .ToList();
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