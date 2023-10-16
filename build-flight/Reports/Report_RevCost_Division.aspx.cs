using DevExpress.Web;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using KTQTData;
using OfficeOpenXml;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.UI.WebControls;
public partial class Report_RevCost_Division : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi-VN");

            this.cboFromMonth.Value = 1;
            this.cboToMonth.Value = 12;

            //rdReport.Items.Clear();
            //if (IsGranted("Pages.KHTC.Reports.Report_RevCost_Division.ThuchiLVTM"))
            //    rdReport.Items.Add(new ListEditItem("Báo cáo kế hoạch thu chi LVTM", "ReportKehoachThuchiLVTM"));
            //if (IsGranted("Pages.KHTC.Reports.Report_RevCost_Division.ThuchiLVTM_NT"))
            //    rdReport.Items.Add(new ListEditItem("Báo cáo kế hoạch thu chi theo đơn vị", "ReportKehoachThuchiLVTM_NT"));
            //if (IsGranted("Pages.KHTC.Reports.Report_RevCost_Division.TongChiPhiKhoi"))
            //    rdReport.Items.Add(new ListEditItem("Báo cáo phân tích cấu thành chi phí khối", "ReportPhantichCauthanhTongChiPhiKhoi"));
            LoadReports();

            if (rdReport.Items.Count > 0)
                this.rdReport.Value = this.rdReport.Items[0].Value;
        }

    }

    private void LoadReports()
    {
        var list = entities.DecTableValues
            .Where(x => x.Tables == "KHTCReports" && x.Field == "REPORTS")
            .OrderBy(x => x.Sort)
            .ToList();

        rdReport.Items.Clear();
        foreach (var report in list)
        {
            if (IsGranted(report.ActionRight))
                rdReport.Items.Add(new ListEditItem(report.Description, report.DefValue));
        }
    }

    protected DevExpress.XtraReports.UI.XtraReport CreateReport()
    {
        XtraReport report = null;
        //string fileExt = fileExtension(cboPormat.Value.ToString());
        //string fileName = "SanLuong" + fileExt;
        //if (rdReport.Value.ToString() == "RevCostQuantityALL")
        //{
        //    if (this.cboVersion.Value == null)
        //    {
        //        return null;
        //    }

        //    report = new StoreSub12MonthSumUp();
        //    report.Parameters["PVERSIONID"].Value = this.cboVersion.Value;
        //    report.CreateDocument();
        //    ReportViewer.Report = report;
        //   // fileName = "SanLuongChung" + fileExt;
        //}
        //else if (rdReport.Value.ToString() == "RevCostQuantityCOMP")
        //{
        //    if (this.cboVersion.Value == null || this.cboCompany.Value == null)
        //    {
        //        return null;
        //    }

        //    report = new StoreSub12MonthSumUpComp();
        //    report.Parameters["PVERSIONID"].Value = this.cboVersion.Value;
        //    report.Parameters["PCOMPANYID"].Value = this.cboCompany.Value;
        //    report.CreateDocument();
        //    ReportViewer.Report = report;
        //    //fileName = "SLChitietSanbay" + fileExt;
        //}
        //else if (rdReport.Value.ToString() == "RevCostQuantityAREA")
        //{
        //    if (this.cboVersion.Value == null)
        //    {
        //        return null;
        //    }

        //    report = new StoreSub12MonthSumUpArea();
        //    report.Parameters["PVERSIONID"].Value = this.cboVersion.Value;
        //    report.CreateDocument();
        //    ReportViewer.Report = report;
        //    //fileName = "ChitietOTPChuyenDen" + fileExt;
        //}
        //else if (rdReport.Value.ToString() == "KHDTNAM")
        //{
        //    //string abc = Server.MapPath("~/Templates/KHDT2019.xlsx");
        //    //ASPxSpreadsheet1.Open(Server.MapPath("~") + "/Templates/KHDT2019.xlsx");


        //    //fileName = "SanLuongHHChung" + fileExt;
        //}


        /*report.Parameters["P_AREA_CODE"].Value = this.cboAreaCode.Value == "ALL" ? null : this.cboAreaCode.Value.ToString();
        report.Parameters["P_FROM_DATE"].Value = this.dtFromDate.Value;
        report.Parameters["P_TO_DATE"].Value = this.dtToDate.Value;  
       */

        return report;
    }

    protected MemoryStream CreateXlsxFileReport()
    {
        XtraReport report = null;
        if (rdReport.Value.ToString() == "RevCostQuantityALL")
        {
            if (this.cboVersion.Value == null)
            {
                return null;
            }

            report = new StoreSub12MonthSumUp();
            report.Parameters["PVERSIONID"].Value = this.cboVersion.Value;
            report.Parameters["PFROMMONTH"].Value = Convert.ToInt32(this.cboFromMonth.Value.ToString());
            report.Parameters["PTOMONTH"].Value = Convert.ToInt32(this.cboToMonth.Value.ToString());
            //report.CreateDocument();
            //  ReportViewer.Report = report;
            //fileName = "SanLuongChung" + fileExt;
        }
        else if (rdReport.Value.ToString() == "RevCostQuantityCOMP")
        {
            if (this.cboVersion.Value == null || this.cboCompany.Value == null)
            {
                return null;
            }

            report = new StoreSub12MonthSumUpComp();
            report.Parameters["PVERSIONID"].Value = this.cboVersion.Value;
            report.Parameters["PCOMPANYID"].Value = this.cboCompany.Value;
            report.Parameters["PFROMMONTH"].Value = Convert.ToInt32(this.cboFromMonth.Value.ToString());
            report.Parameters["PTOMONTH"].Value = Convert.ToInt32(this.cboToMonth.Value.ToString());
            // report.CreateDocument();
            // ReportViewer.Report = report;
            //fileName = "SLChitietSanbay" + fileExt;
        }
        else if (rdReport.Value.ToString() == "RevCostQuantityAREA")
        {
            if (this.cboVersion.Value == null)
            {
                return null;
            }

            report = new StoreSub12MonthSumUpArea();
            report.Parameters["PVERSIONID"].Value = this.cboVersion.Value;
            report.Parameters["PFROMMONTH"].Value = Convert.ToInt32(this.cboFromMonth.Value.ToString());
            report.Parameters["PTOMONTH"].Value = Convert.ToInt32(this.cboToMonth.Value.ToString());

            // report.CreateDocument();
            //ReportViewer.Report = report;
            //fileName = "ChitietOTPChuyenDen" + fileExt;
        }
        else if (rdReport.Value.ToString() == "KHDTNAM")
        {
            //string abc = Server.MapPath("~/Templates/KHDT2019.xlsx");
            //ASPxSpreadsheet1.Open(Server.MapPath("~") + "/Templates/KHDT2019.xlsx");


            //fileName = "SanLuongHHChung" + fileExt;
        }
        else if (rdReport.Value.ToString() == "RevCost_DanhGia_KH_Division")
        {
            try
            {
                //report = new RevCost_DanhGia_KH_Division();
                //decimal aVersionID, aVersionBase1ID, aVersionBase2ID;


                //if (this.cboVersion.Value == null)
                //    aVersionID = 0;
                //else
                //    aVersionID = decimal.Parse(this.cboVersion.Value.ToString());

                //if (this.cboVersionBase1.Value == null)
                //    aVersionBase1ID = 0;
                //else
                //    aVersionBase1ID = decimal.Parse(this.cboVersionBase1.Value.ToString());
                //// var aversion = entities.Versions.Where(x => x.VersionID == aVersionID).SingleOrDefault();


                //if (this.cboVersionBase2.Value == null)
                //    aVersionBase2ID = 0;
                //else
                //    aVersionBase2ID = decimal.Parse(this.cboVersionBase2.Value.ToString());


                //entities.Report_RevCost_DanhGia_KH_Khoi(Convert.ToInt32(this.cboCompany.Value), aVersionID, aVersionBase1ID, aVersionBase2ID, Convert.ToInt32(this.cboFromMonth.Value.ToString()), Convert.ToInt32(this.cboToMonth.Value.ToString()), SessionUser.UserID.ToString());
                //report.Parameters["pCreated_user"].Value = SessionUser.UserID.ToString();
                //report.Parameters["p_fMonth"].Value = Convert.ToInt32(this.cboFromMonth.Value.ToString());
                //report.Parameters["p_toMonth"].Value = Convert.ToInt32(this.cboToMonth.Value.ToString());
                //report.Parameters["P_COMPANYID"].Value = Convert.ToInt32(this.cboCompany.Value);
                //report.Parameters["p_VersionID"].Value = aVersionID;
                //report.Parameters["p_VersionIDBase1"].Value = aVersionBase1ID;
                //report.Parameters["p_VersionIDBase2"].Value = aVersionBase2ID;
            }
            catch (Exception) { }
        }
        else if (rdReport.Value.ToString() == "SummaryByDivision")
        {
            if (this.cboVersion.Value == null)
            {
                return null;
            }

            report = new SummaryByDivision();
            report.Parameters["pVersionID"].Value = this.cboVersion.Value;
            report.Parameters["pFromMonth"].Value = Convert.ToInt32(this.cboFromMonth.Value.ToString());
            report.Parameters["pToMonth"].Value = Convert.ToInt32(this.cboToMonth.Value.ToString());

        }
        else if (rdReport.Value.ToString() == "SummaryByMonth")
        {
            if (this.cboVersion.Value == null)
            {
                return null;
            }

            report = new SummaryByMonth();
            report.Parameters["pVersionID"].Value = this.cboVersion.Value;
            report.Parameters["pFromMonth"].Value = Convert.ToInt32(this.cboFromMonth.Value.ToString());
            report.Parameters["pToMonth"].Value = Convert.ToInt32(this.cboToMonth.Value.ToString());

        }
        else if (rdReport.Value.ToString() == "ReportKehoachThuchiLVTM")
        {
            report = new ReportKehoachThuchiLVTM_9M();
            report.Parameters["pVersionID"].Value = this.cboVersion.Value;
            report.Parameters["pCompanyID"].Value = Convert.ToInt32(this.cboCompany.Value);
            report.Parameters["pFromMonth"].Value = Convert.ToInt32(this.cboFromMonth.Value.ToString());
            report.Parameters["pToMonth"].Value = Convert.ToInt32(this.cboToMonth.Value.ToString());
            report.Parameters["pReportName"].Value = this.rdReport.Value;
            report.Parameters["pAreaCode"].Value = this.cboGroupUnit.Value;
        }
        else if (rdReport.Value.ToString() == "ReportKehoachThuchiLVTM_NT")
        {
            report = new ReportKehoachThuchiLVTM_NT_9M();
            report.Parameters["pVersionID"].Value = this.cboVersion.Value;
            report.Parameters["pCompanyID"].Value = Convert.ToInt32(this.cboCompany.Value);
            report.Parameters["pFromMonth"].Value = Convert.ToInt32(this.cboFromMonth.Value.ToString());
            report.Parameters["pToMonth"].Value = Convert.ToInt32(this.cboToMonth.Value.ToString());
            report.Parameters["pReportName"].Value = this.rdReport.Value;
            report.Parameters["pAreaCode"].Value = this.cboGroupUnit.Value;
        }
        else if (rdReport.Value.ToString() == "ReportKehoachThuchiLVTM_TheoTK")
        {
            report = new ReportKehoachThuchiLVTM_TheoTK();
            report.Parameters["pVersionID"].Value = this.cboVersion.Value;
            report.Parameters["pCompanyID"].Value = Convert.ToInt32(this.cboCompany.Value);
            report.Parameters["pFromMonth"].Value = Convert.ToInt32(this.cboFromMonth.Value.ToString());
            report.Parameters["pToMonth"].Value = Convert.ToInt32(this.cboToMonth.Value.ToString());
            report.Parameters["pReportName"].Value = this.rdReport.Value;
            report.Parameters["pAreaCode"].Value = this.cboGroupUnit.Value;
        }
        else if (rdReport.Value.ToString() == "ReportPhantichCauthanhTongChiPhiKhoi")
        {
            report = new ReportPhantichCauthanhTongChiPhiKhoi();
            report.Parameters["pVersionID"].Value = this.cboVersion.Value;
            report.Parameters["pCompanyID"].Value = Convert.ToInt32(this.cboCompany.Value);
            report.Parameters["pFromMonth"].Value = Convert.ToInt32(this.cboFromMonth.Value.ToString());
            report.Parameters["pToMonth"].Value = Convert.ToInt32(this.cboToMonth.Value.ToString());
            report.Parameters["pReportName"].Value = this.rdReport.Value;
            report.Parameters["pAreaCode"].Value = this.cboGroupUnit.Value;
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
    protected void btnPrintReport_Click(object sender, EventArgs e)
    {
        XtraReport report = null;
        // string fileExt = fileExtension(cboPormat.Value.ToString());
        // string fileName = "SanLuong" + fileExt;
        //if (rdReport.Value == "SanLuongChung")
        //{
        //    report = new SanLuongChung();
        // //   fileName = "SanLuongChung" + fileExt;
        //}
        //else if (rdReport.Value == "SLChitietSanbay")
        //{
        //    report = new SLChitietSanbay();
        // //   fileName = "SLChitietSanbay" + fileExt;
        //}
        //else if (rdReport.Value == "ChitietOTPChuyenDen")
        //{
        //    report = new ChitietOTPChuyenDen();
        //   // fileName = "ChitietOTPChuyenDen" + fileExt;
        //}

        //report.Parameters["P_AREA_CODE"].Value = this.cboAreaCode.Value == "ALL" ? null : this.cboAreaCode.Value.ToString();
        //report.Parameters["P_FROM_DATE"].Value = this.dtFromDate.Value;
        //report.Parameters["P_TO_DATE"].Value = this.dtToDate.Value;
        report.CreateDocument();

        //ReportViewer.Report = report;

        //MemoryStream memoryStream = new MemoryStream();
        //ExportOptions opt = report.ExportOptions;
        //opt.Pdf.ImageQuality = PdfJpegImageQuality.Highest;

        //switch (cboPormat.Value.ToString())
        //{
        //    case "XLSX":
        //        report.ExportToXlsx(memoryStream);
        //        break;
        //    case "PDF":
        //        report.ExportToPdf(memoryStream);
        //        break;
        //    case "RTF":
        //        report.ExportToRtf(memoryStream);
        //        break;
        //    case "HTML":
        //        report.ExportToHtml(memoryStream);
        //        break;
        //}


        //byte[] bytesInStream = memoryStream.ToArray(); // simpler way of converting to array
        //memoryStream.Close();

        //Response.Clear();
        //Response.ContentType = "application/force-download";
        //Response.AddHeader("content-disposition", "attachment; filename=\"" + fileName + "\"");
        //Response.BinaryWrite(bytesInStream);
        //Response.End();

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


    protected void cboCompany_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DecCompanies.Where(x => x.Active == true).ToList();

        ListEditItem le = new ListEditItem();
        foreach (var item in list)
        {
            le = new ListEditItem();

            le.Text = item.ShortName;
            le.Value = item.CompanyID;
            s.Items.Add(le);
        }

        if (s.Items.Count > 0)
        {
            s.Value = s.Items[0].Value;
            //var curCompany = entities.DecCompanies.SingleOrDefault(x => x.CompanyID == SessionUser.CompanyID);
            //if (curCompany != null)
            //    s.Value = curCompany.CompanyID;
        }
    }

    protected void cboVersion_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Versions.Where(x => x.Active ?? true).OrderByDescending(x => x.VersionYear).ThenBy(x => x.VersionType).ThenByDescending(x => x.VersionID).ToList();
        ListEditItem le = new ListEditItem();
        foreach (var item in list)
        {
            le = new ListEditItem();
            le.Text = item.VersionYear + "_" + item.VersionType + "_" + item.Description;
            le.Value = item.VersionID;
            s.Items.Add(le);
        }
    }


    protected void cboVersionBase1_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Versions.Where(x => x.Active ?? true).OrderByDescending(x => x.VersionYear).ThenBy(x => x.VersionType).ThenByDescending(x => x.VersionID).ToList();
        ListEditItem le = new ListEditItem();
        foreach (var item in list)
        {
            le = new ListEditItem();
            le.Text = item.VersionYear + "_" + item.VersionType + "_" + item.Description;
            le.Value = item.VersionID;
            s.Items.Add(le);
        }
    }
    protected void cboVersionBase2_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Versions.Where(x => x.Active ?? true).OrderByDescending(x => x.VersionYear).ThenBy(x => x.VersionType).ThenByDescending(x => x.VersionID).ToList();
        ListEditItem le = new ListEditItem();
        foreach (var item in list)
        {
            le = new ListEditItem();
            le.Text = item.VersionYear + "_" + item.VersionType + "_" + item.Description;
            le.Value = item.VersionID;
            s.Items.Add(le);
        }
    }

    protected void cboFromMonth_Init(object sender, EventArgs e)
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

    private decimal? GetExchangeRate(decimal versionId, int month, string currency)
    {
        var roe = entities.RoeVNs.Where(x => x.Ver_ID == versionId && x.Curr == currency).FirstOrDefault();
        if (roe == null) return 1;
        if (month == 1) return roe.M01;
        if (month == 2) return roe.M02;
        if (month == 3) return roe.M03;
        if (month == 4) return roe.M04;
        if (month == 5) return roe.M05;
        if (month == 6) return roe.M06;
        if (month == 7) return roe.M07;
        if (month == 8) return roe.M08;
        if (month == 9) return roe.M09;
        if (month == 10) return roe.M10;
        if (month == 11) return roe.M11;
        if (month == 12) return roe.M12;

        return 1;
    }

    protected void ASPxCallbackPanel1_Callback(object sender, CallbackEventArgsBase e)
    {
        if (rdReport.Value.ToString() == "SummaryByMonth")
        {
            try
            {
                MemoryStream newStream = new MemoryStream();
                using (ExcelPackage package = new ExcelPackage(newStream, CreateXlsxFileReport()))
                {
                    ExcelWorksheet sheet = package.Workbook.Worksheets.FirstOrDefault();

                    sheet.Cells["K5"].Value = "Tỷ giá";
                    sheet.Cells["L5"].Value = this.GetExchangeRate(decimal.Parse(this.cboVersion.Value.ToString()), 1, "USD");
                    sheet.Cells["F7"].Style.Font.Color.SetColor(Color.White);
                    sheet.Cells["C185"].Style.Font.Color.SetColor(Color.White);
                    sheet.Cells["C186"].Style.Font.Color.SetColor(Color.White);
                    sheet.Cells["F185"].Style.Font.Color.SetColor(Color.White);
                    sheet.Cells["F186"].Style.Font.Color.SetColor(Color.White);
                    //sheet.Cells["C185"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.None);
                    //sheet.Cells["C186"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.None);
                    //sheet.Cells["F185"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.None);
                    //sheet.Cells["F186"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.None);

                    var cells = new string[] { "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R" };
                    foreach (var cell in cells)
                    {
                        sheet.Cells[cell + "7"].Style.Font.Color.SetColor(Color.White);
                        sheet.Cells[cell + "12"].Formula = "=" + cell + "10 -" + cell + "11";
                        sheet.Cells[cell + "26"].Formula = "=" + cell + "17/" + cell + "8/" + cell + "7";
                        sheet.Cells[cell + "28"].Formula = "=" + cell + "27*1000/" + cell + "$17";
                        sheet.Cells[cell + "29"].Formula = "=" + cell + "$17/" + cell + "$16";
                        sheet.Cells[cell + "41"].Formula = "=SUM(" + cell + "$85," + cell + "$86," + cell + "$89)/" + cell + "$19/L5*100";
                        sheet.Cells[cell + "44"].Formula = "=" + cell + "$83/" + cell + "$16/L5*10^6";
                        sheet.Cells[cell + "45"].Formula = "=" + cell + "$83/" + cell + "$17/L5*10^6";
                        sheet.Cells[cell + "46"].Formula = "=SUM(" + cell + "$85," + cell + "$86," + cell + "$89)/" + cell + "$10";
                        sheet.Cells[cell + "49"].Formula = "=" + cell + "$83/" + cell + "$22/L5*100";
                        sheet.Cells[cell + "54"].Formula = "=SUM(" + cell + "$176," + cell + "$179)/" + cell + "$17/L5*10^6";
                        sheet.Cells[cell + "55"].Formula = "=(" + cell + "$176+" + cell + "$179-" + cell + "$108)/" + cell + "$17/L5*10^6";
                        sheet.Cells[cell + "56"].Formula = "=" + cell + "185/" + cell + "$17*10^6/L5";
                        sheet.Cells[cell + "57"].Formula = "=" + cell + "186/" + cell + "$17*10^6/L5";
                        sheet.Cells[cell + "58"].Formula = "=SUM(" + cell + "$176," + cell + "$179)/" + cell + "$16/L5*10^6";
                        sheet.Cells[cell + "59"].Formula = "=(" + cell + "$176+" + cell + "$179-" + cell + "$108)/" + cell + "$16/L5*10^6";
                        sheet.Cells[cell + "60"].Formula = "=" + cell + "185/" + cell + "$16*10^6/L5";
                        sheet.Cells[cell + "61"].Formula = "=" + cell + "186/" + cell + "$16*10^6/L5";
                        sheet.Cells[cell + "62"].Formula = "=" + cell + "$176/" + cell + "$22/L5*100";
                        sheet.Cells[cell + "63"].Formula = "=(" + cell + "$176-" + cell + "$108)/" + cell + "$22/L5*100";
                        sheet.Cells[cell + "64"].Formula = "=" + cell + "185/" + cell + "$22/L5*100";
                        sheet.Cells[cell + "65"].Formula = "=" + cell + "186/" + cell + "$22/L5*100";
                        sheet.Cells[cell + "70"].Formula = "=SUM(" + cell + "$109:" + cell + "$111," + cell + "$113:" + cell + "$114," + cell + "$121:" + cell + "$131)/" + cell + "$17*10^6/L5";
                        sheet.Cells[cell + "71"].Formula = "=" + cell + "185/" + cell + "$83";
                        sheet.Cells[cell + "71"].Style.Numberformat.Format = "0%";
                        //sheet.Cells[cell + "72"].Formula = "=" + cell + "186/" + cell + "$83";
                        //sheet.Cells[cell + "72"].Style.Numberformat.Format = "0%";
                        sheet.Cells[cell + "75"].Formula = "=" + cell + "$19/" + cell + "$22";
                        sheet.Cells[cell + "75"].Style.Numberformat.Format = "0%";
                        sheet.Cells[cell + "79"].Formula = "=(" + cell + "$176/" + cell + "$22)/(" + cell + "$83/" + cell + "$19)";
                        sheet.Cells[cell + "80"].Formula = "=" + cell + "$44-" + cell + "$58";
                        sheet.Cells[cell + "81"].Formula = "=" + cell + "$45-" + cell + "$54";
                        sheet.Cells[cell + "82"].Formula = "=(" + cell + "$83-" + cell + "$176-" + cell + "$179)/" + cell + "$83";
                        sheet.Cells[cell + "82"].Style.Numberformat.Format = "0%";
                        sheet.Cells[cell + "83"].Formula = "=SUM(" + cell + "84," + cell + "94," + cell + "97," + cell + "102)";
                        sheet.Cells[cell + "84"].Formula = "=SUM(" + cell + "85:" + cell + "93)";
                        sheet.Cells[cell + "94"].Formula = "=SUM(" + cell + "95:" + cell + "96)";
                        sheet.Cells[cell + "97"].Formula = "=SUM(" + cell + "98:" + cell + "101)";
                        sheet.Cells[cell + "102"].Formula = "=SUM(" + cell + "103:" + cell + "105)";
                        sheet.Cells[cell + "107"].Formula = "=SUM(" + cell + "108:" + cell + "118)";
                        sheet.Cells[cell + "119"].Formula = "=SUM(" + cell + "120:" + cell + "131)";
                        sheet.Cells[cell + "132"].Formula = "=SUM(" + cell + "133:" + cell + "141)";
                        sheet.Cells[cell + "142"].Formula = "=SUM(" + cell + "143:" + cell + "144)";
                        sheet.Cells[cell + "145"].Formula = "=SUM(" + cell + "146:" + cell + "148)";
                        sheet.Cells[cell + "149"].Formula = "=SUM(" + cell + "150:" + cell + "160)";
                        sheet.Cells[cell + "161"].Formula = "=SUM(" + cell + "162:" + cell + "172)";
                        sheet.Cells[cell + "173"].Formula = "=SUM(" + cell + "174:" + cell + "175)";
                        sheet.Cells[cell + "176"].Formula = "=SUM(" + cell + "107," + cell + "119," + cell + "132," + cell + "142," + cell + "145," + cell + "149," + cell + "161," + cell + "173)";
                        //sheet.Cells[cell + "176"].Formula = "=SUM(" + cell + "176:" + cell + "178)";
                        sheet.Cells[cell + "180"].Formula = "=" + cell + "178-" + cell + "179";
                        sheet.Cells[cell + "181"].Formula = "=" + cell + "83-" + cell + "176";
                        sheet.Cells[cell + "182"].Formula = "=SUM(" + cell + "180," + cell + "181)";


                        sheet.Cells[cell + "185"].Style.Font.Color.SetColor(Color.White);
                        sheet.Cells[cell + "186"].Style.Font.Color.SetColor(Color.White);
                        //sheet.Cells[cell + "185"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.None);
                        //sheet.Cells[cell + "186"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.None);
                    }

                    //sheet.Cells["F7"].Formula = "=AVERAGE(G7:R7)";
                    sheet.Cells["F8"].Formula = "=AVERAGE(G8:R8)";
                    sheet.Cells["F12"].Formula = "=SUM(G12:R12)";
                    sheet.Cells["F26"].Formula = "=AVERAGE(G26:R26)";
                    sheet.Cells["F28"].Formula = "=G27*1000/G$17";
                    sheet.Cells["F29"].Formula = "=AVERAGE(G29:R29)";
                    sheet.Cells["F41"].Formula = "=SUM(F$85,F$86,F$89)/F$19/L5*100";
                    sheet.Cells["F44"].Formula = "=F$83/F$16/L5*10^6";
                    sheet.Cells["F45"].Formula = "=F$83/F$17/L5*10^6";
                    sheet.Cells["F46"].Formula = "=SUM(F$85,F$86,F$89)/F$10";
                    sheet.Cells["F49"].Formula = "=F$83/F$22/L5*100";
                    sheet.Cells["F54"].Formula = "=SUM(F$176,F$179)/F$17/L5*10^6";
                    sheet.Cells["F55"].Formula = "=(F$176+F$179-F$108)/F$17/L5*10^6";
                    sheet.Cells["F56"].Formula = "=F185/F$17*10^6/L5";
                    sheet.Cells["F57"].Formula = "=F186/F$17*10^6/L5";
                    sheet.Cells["F58"].Formula = "=SUM(F$176,F$179)/F$16/L5*10^6";
                    sheet.Cells["F59"].Formula = "=(F$176+F$179-F$108)/F$16/L5*10^6";
                    sheet.Cells["F60"].Formula = "=F185/F$16*10^6/L5";
                    sheet.Cells["F61"].Formula = "=F186/F$16*10^6/L5";
                    sheet.Cells["F62"].Formula = "=F$176/F$22/L5*100";
                    sheet.Cells["F63"].Formula = "=(F$176-F$108)/F$22/L5*100";
                    sheet.Cells["F64"].Formula = "=F185/F$22/L5*100";
                    sheet.Cells["F65"].Formula = "=F186/F$22/L5*100";
                    sheet.Cells["F75"].Formula = "=F$19/F$22";
                    sheet.Cells["F70"].Formula = "=SUM(F$109:F$111,F$113:F$114,F$121:F$131)/F$17*10^6/L5";
                    sheet.Cells["F71"].Formula = "=F185/F$83";
                    sheet.Cells["F71"].Style.Numberformat.Format = "0%";
                    //sheet.Cells["F72"].Formula = "=F186/F$83";
                    //sheet.Cells["F72"].Style.Numberformat.Format = "0%";
                    sheet.Cells["F75"].Formula = "=F$19/F$22";
                    sheet.Cells["F75"].Style.Numberformat.Format = "0%";
                    sheet.Cells["F79"].Formula = "=(F$176/F$22)/(F$83/F$19)";
                    sheet.Cells["F80"].Formula = "=F$44-F$58";
                    sheet.Cells["F81"].Formula = "=F$45-F$54";
                    sheet.Cells["F82"].Formula = "=(F$83-F$176-F$179)/F$83";
                    sheet.Cells["F82"].Style.Numberformat.Format = "0%";
                    sheet.Cells["F83"].Formula = "=SUM(F84,F94,F97,F102)";
                    for (int i = 84; i <= 180; i++)
                    {
                        sheet.Cells["F" + i].Formula = "=SUM(G" + i + ":R" + i + ")";
                    }
                    sheet.Cells["F181"].Formula = "=F83-F176";
                    sheet.Cells["F182"].Formula = "=SUM(F180,F181)";

                    string documentId = Guid.NewGuid().ToString();
                    string dir = Server.MapPath("~") + "/Temp";
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    string fileName = dir + "/" + documentId + ".xlsx";

                    package.SaveAs(new FileInfo(fileName));
                    ASPxSpreadsheet1.Open(fileName);
                }
            }
            catch { }
        }
        else if (rdReport.Value.ToString() == "ReportKehoachThuchiLVTM" || rdReport.Value.ToString() == "ReportKehoachThuchiLVTM_NT" || rdReport.Value.ToString() == "ReportKehoachThuchiLVTM_TheoTK")
        {
            MemoryStream newStream = new MemoryStream();
            using (ExcelPackage package = new ExcelPackage(newStream, CreateXlsxFileReport()))
            {
                ExcelWorksheet sheet = package.Workbook.Worksheets.FirstOrDefault();

                var versionId = Convert.ToDecimal(this.cboVersion.Value);
                var companyId = Convert.ToInt32(this.cboCompany.Value); ;
                var version = entities.Versions.Where(x => x.VersionID == versionId).FirstOrDefault();
                if (version != null)
                {
                    var fileName = "KH ThuChi " + version.VersionYear;
                    var company = entities.DecCompanies.Where(x => x.CompanyID == companyId).FirstOrDefault();
                    if (company != null)
                        fileName = fileName + " " + company.ShortName;
                    fileName = fileName + " " + DateTime.Now.ToString("ddMMyyyyHHmm");
                    string dir = Server.MapPath("~") + @"\\App_Data\\WorkDirectory\\Temp";
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    fileName = dir + @"\\" + fileName + ".xlsx";

                    package.SaveAs(new FileInfo(fileName));
                    ASPxSpreadsheet1.Open(fileName);
                }
                else
                {
                    var fileName = "KH ThuChi " + DateTime.Now.Year;
                    var company = entities.DecCompanies.Where(x => x.CompanyID == companyId).FirstOrDefault();
                    if (company != null)
                        fileName = fileName + " " + company.ShortName;
                    fileName = fileName + " " + DateTime.Now.ToString("ddMMyyyyHHmm");
                    string dir = Server.MapPath("~") + @"\\App_Data\\WorkDirectory\\Temp";
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    fileName = dir + @"\\" + fileName + ".xlsx";

                    package.SaveAs(new FileInfo(fileName));
                    ASPxSpreadsheet1.Open(fileName);
                }
            }
        }
        else if (rdReport.Value.ToString() == "ReportPhantichCauthanhTongChiPhiKhoi")
        {
            MemoryStream newStream = new MemoryStream();
            using (ExcelPackage package = new ExcelPackage(newStream, CreateXlsxFileReport()))
            {
                ExcelWorksheet sheet = package.Workbook.Worksheets.FirstOrDefault();

                var versionId = Convert.ToDecimal(this.cboVersion.Value);
                var companyId = Convert.ToInt32(this.cboCompany.Value); ;
                var version = entities.Versions.Where(x => x.VersionID == versionId).FirstOrDefault();
                if (version != null)
                {
                    var fileName = "Cấu thành tổng chi phí " + version.VersionYear;
                    var company = entities.DecCompanies.Where(x => x.CompanyID == companyId).FirstOrDefault();
                    if (company != null)
                        fileName = fileName + " đơn vị " + company.ShortName;
                    fileName = fileName + " " + DateTime.Now.ToString("ddMMyyyyHHmm");
                    string dir = Server.MapPath("~") + @"\\App_Data\\WorkDirectory\\Temp";
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    fileName = dir + @"\\" + fileName + ".xlsx";

                    package.SaveAs(new FileInfo(fileName));
                    ASPxSpreadsheet1.Open(fileName);
                }
                else
                {
                    var fileName = "Cấu thành tổng chi phí " + DateTime.Now.Year;
                    var company = entities.DecCompanies.Where(x => x.CompanyID == companyId).FirstOrDefault();
                    if (company != null)
                        fileName = fileName + " đơn vị " + company.ShortName;
                    fileName = fileName + " " + DateTime.Now.ToString("ddMMyyyyHHmm");
                    string dir = Server.MapPath("~") + @"\\App_Data\\WorkDirectory\\Temp";
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    fileName = dir + @"\\" + fileName + ".xlsx";

                    package.SaveAs(new FileInfo(fileName));
                    ASPxSpreadsheet1.Open(fileName);
                }
            }
        }
        else
        {
            ASPxSpreadsheet1.Open(Guid.NewGuid().ToString(), DevExpress.Spreadsheet.DocumentFormat.Xlsx, () => { return CreateXlsxFileReport(); });
        }
    }

    protected void cboVersion_Callback(object sender, CallbackEventArgsBase e)
    {
        int aYear;
        if (!int.TryParse(e.Parameter, out aYear))
            return;

        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Versions
            .Where(x => x.VersionYear == aYear && (x.Active ?? false))
            .Select(x => new { VersionID = x.VersionID, VersionName = x.VersionName })
            .ToList();

        s.DataSource = list;
        s.ValueField = "VersionID";
        s.TextField = "VersionName";
        s.DataBind();
    }

    protected void cboGroupUnit_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DecTableValues
                       .Where(x => x.Tables == "DEC_COMPANY" && x.Field == "AREA")
                       .OrderBy(x => x.Sort)
                       .ToList();
        ListEditItem le = new ListEditItem();
        le = new ListEditItem();
        le.Value = "ALL";
        le.Text = "---ALL---";
        s.Items.Add(le);

        foreach (var item in list)
        {
            le = new ListEditItem();
            le.Value = item.DefValue;
            le.Text = item.Description;
            s.Items.Add(le);
        }
        if (s.Items.Count > 0)
        {
            s.SelectedItem = s.Items[0];
        }
    }
}