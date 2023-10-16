using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
public partial class Reports_Quantity : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi-VN");
            this.rdReport.Value = this.rdReport.Items[0].Value;
            this.cboAreaCode.Value = "SGN";
            this.dtFromDate.Value = DateUtils.FirstDayOfMonth(true);
            this.dtToDate.Value = DateUtils.LastDayOfMonth(true);
            //this.cboPormat.Value = "XLSX";
        }
       
    }


    protected MemoryStream CreateXlsxFileReport()
    {
        XtraReport report = null;
        //string fileExt = fileExtension(cboPormat.Value.ToString());
        //string fileName = "SanLuong" + fileExt;
        if (rdReport.Value.ToString() == "SanLuongChung")
        {
            report = new SanLuongChung();
            //fileName = "SanLuongChung" + fileExt;
        }
        else if (rdReport.Value.ToString() == "SLChitietSanbay")
        {
            report = new SLChitietSanbay();
            //fileName = "SLChitietSanbay" + fileExt;
        }
        else if (rdReport.Value.ToString() == "ChitietOTPChuyenDen")
        {
            report = new ChitietOTPChuyenDen();
            //fileName = "ChitietOTPChuyenDen" + fileExt;
        }
        else if (rdReport.Value.ToString() == "SanLuongHHChung")
        {
            report = new SanLuongHHChung();
            //fileName = "SanLuongHHChung" + fileExt;
        }
        else if (rdReport.Value.ToString() == "SanLuongChuyenBay")
        {
            report = new SanLuongChuyenBay();
            //fileName = "SanLuongChuyenBay" + fileExt;
        }       
        report.Parameters["P_DATE_STR"].Value = "Từ ngày: " + (this.dtFromDate.Date).ToString("dd/MM/yyyy") + " đến ngày: " + (this.dtToDate.Date).ToString("dd/MM/yyyy");
        report.Parameters["P_AREA_CODE"].Value = this.cboAreaCode.Value == "ALL" ? null : this.cboAreaCode.Value.ToString();
        report.Parameters["P_FROM_DATE"].Value = this.dtFromDate.Value;
        report.Parameters["P_TO_DATE"].Value = this.dtToDate.Value;

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
    protected void ASPxCallbackPanel1_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        ASPxSpreadsheet1.Open(Guid.NewGuid().ToString(), DevExpress.Spreadsheet.DocumentFormat.Xlsx, () => { return CreateXlsxFileReport(); });
    }
}