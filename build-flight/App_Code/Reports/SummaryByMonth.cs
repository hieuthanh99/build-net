using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using KTQTData;
using System.Linq;


/// <summary>
/// Summary description for ChiphiTheoNhomPhanloai
/// </summary>
public class SummaryByMonth : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private DevExpress.XtraReports.Parameters.Parameter pVersionID;
    private DevExpress.XtraReports.Parameters.Parameter pFromMonth;
    private DevExpress.XtraReports.Parameters.Parameter pToMonth;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private DevExpress.XtraReports.Parameters.Parameter pDateStr;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel2;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    private XRLabel xrLabel1;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell2;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell33;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell36;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell38;
    private XRTableCell xrTableCell39;
    private XRTableCell xrTableCell40;
    private XRTableCell xrTableCell41;
    private XRTableCell xrTableCell42;
    private XRTableCell xrTableCell48;
    private XRPictureBox xrPictureBox1;

    //private FormattingRule formattingRule1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public SummaryByMonth()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            string resourceFileName = "SummaryByMonth.resx";
            System.Resources.ResourceManager resources = global::Resources.SummaryByMonth.ResourceManager;
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.pVersionID = new DevExpress.XtraReports.Parameters.Parameter();
            this.pFromMonth = new DevExpress.XtraReports.Parameters.Parameter();
            this.pToMonth = new DevExpress.XtraReports.Parameters.Parameter();
            this.pDateStr = new DevExpress.XtraReports.Parameters.Parameter();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.HeightF = 25.83333F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1821.429F, 25.83333F);
            this.xrTable1.StylePriority.UseBackColor = false;
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UsePadding = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell23,
            this.xrTableCell25,
            this.xrTableCell26,
            this.xrTableCell27,
            this.xrTableCell28,
            this.xrTableCell29,
            this.xrTableCell30,
            this.xrTableCell31,
            this.xrTableCell33,
            this.xrTableCell35,
            this.xrTableCell36,
            this.xrTableCell37,
            this.xrTableCell38,
            this.xrTableCell39,
            this.xrTableCell40,
            this.xrTableCell41,
            this.xrTableCell42,
            this.xrTableCell48});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Sorting]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Size", "Iif([Calculation] == \'SUM\', \'10.2\', ?)"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "Iif([Calculation] == \'SUM\', \'True\', ?)")});
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.StylePriority.UseBackColor = false;
            this.xrTableCell23.StylePriority.UseTextAlignment = false;
            this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell23.Weight = 0.13353103907064789D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ManagementCode]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Size", "Iif([Calculation] == \'SUM\', \'10.2\', ?)"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "Iif([Calculation] == \'SUM\', \'True\', ?)")});
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.StylePriority.UseTextAlignment = false;
            this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell25.Weight = 0.19212879579824777D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Description]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Size", "Iif([Calculation] == \'SUM\', \'10.2\', ?)"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "Iif([Calculation] == \'SUM\', \'True\', ?)")});
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.StylePriority.UseTextAlignment = false;
            this.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell26.Weight = 0.660594664504813D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Unit]")});
            this.xrTableCell27.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic);
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.StylePriority.UseFont = false;
            this.xrTableCell27.StylePriority.UseTextAlignment = false;
            this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell27.Weight = 0.15367246174310348D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Note]")});
            this.xrTableCell28.Multiline = true;
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.StylePriority.UseTextAlignment = false;
            this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell28.Weight = 0.14681545375025026D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Total]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "Iif([Calculation] == \'SUM\', \'True\', ?)"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Italic", "Iif([Calculation] == \'SUM\', \'True\', ?)")});
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.StylePriority.UseTextAlignment = false;
            this.xrTableCell29.TextFormatString = "{0:n2}";
            this.xrTableCell29.Weight = 0.24061003543647544D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount1]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "Iif([Calculation] == \'SUM\', \'True\', ?)"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Italic", "Iif([Calculation] == \'SUM\', \'True\', ?)")});
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.TextFormatString = "{0:n2}";
            this.xrTableCell30.Weight = 0.20342472400284653D;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount2]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "Iif([Calculation] == \'SUM\', \'True\', ?)"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Italic", "Iif([Calculation] == \'SUM\', \'True\', ?)")});
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.TextFormatString = "{0:n2}";
            this.xrTableCell31.Weight = 0.19686275484028248D;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount3]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "Iif([Calculation] == \'SUM\', \'True\', ?)"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Italic", "Iif([Calculation] == \'SUM\', \'True\', ?)")});
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.TextFormatString = "{0:n2}";
            this.xrTableCell33.Weight = 0.20342458572228628D;
            // 
            // xrTableCell35
            // 
            this.xrTableCell35.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount4]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "Iif([Calculation] == \'SUM\', \'True\', ?)"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Italic", "Iif([Calculation] == \'SUM\', \'True\', ?)")});
            this.xrTableCell35.Name = "xrTableCell35";
            this.xrTableCell35.TextFormatString = "{0:n2}";
            this.xrTableCell35.Weight = 0.20342498420647909D;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount5]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "Iif([Calculation] == \'SUM\', \'True\', ?)"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Italic", "Iif([Calculation] == \'SUM\', \'True\', ?)")});
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.TextFormatString = "{0:n2}";
            this.xrTableCell36.Weight = 0.20342459177362207D;
            // 
            // xrTableCell37
            // 
            this.xrTableCell37.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount6]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "Iif([Calculation] == \'SUM\', \'True\', ?)"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Italic", "Iif([Calculation] == \'SUM\', \'True\', ?)")});
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.TextFormatString = "{0:n2}";
            this.xrTableCell37.Weight = 0.20342511555428508D;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount7]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "Iif([Calculation] == \'SUM\', \'True\', ?)"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Italic", "Iif([Calculation] == \'SUM\', \'True\', ?)")});
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.TextFormatString = "{0:n2}";
            this.xrTableCell38.Weight = 0.20342458785222903D;
            // 
            // xrTableCell39
            // 
            this.xrTableCell39.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount8]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "Iif([Calculation] == \'SUM\', \'True\', ?)"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Italic", "Iif([Calculation] == \'SUM\', \'True\', ?)")});
            this.xrTableCell39.Name = "xrTableCell39";
            this.xrTableCell39.TextFormatString = "{0:n2}";
            this.xrTableCell39.Weight = 0.2034248548644349D;
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount9]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "Iif([Calculation] == \'SUM\', \'True\', ?)"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Italic", "Iif([Calculation] == \'SUM\', \'True\', ?)")});
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.TextFormatString = "{0:n2}";
            this.xrTableCell40.Weight = 0.20342485486443485D;
            // 
            // xrTableCell41
            // 
            this.xrTableCell41.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount10]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "Iif([Calculation] == \'SUM\', \'True\', ?)"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Italic", "Iif([Calculation] == \'SUM\', \'True\', ?)")});
            this.xrTableCell41.Name = "xrTableCell41";
            this.xrTableCell41.TextFormatString = "{0:n2}";
            this.xrTableCell41.Weight = 0.2034248548644349D;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount11]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "Iif([Calculation] == \'SUM\', \'True\', ?)"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Italic", "Iif([Calculation] == \'SUM\', \'True\', ?)")});
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.TextFormatString = "{0:n2}";
            this.xrTableCell42.Weight = 0.20342565590110107D;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount12]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "Iif([Calculation] == \'SUM\', \'True\', ?)"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Italic", "Iif([Calculation] == \'SUM\', \'True\', ?)")});
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.TextFormatString = "{0:n2}";
            this.xrTableCell48.Weight = 0.22566347375857498D;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "KTQT_Data_Connection";
            this.sqlDataSource1.ConnectionOptions.DbCommandTimeout = 0;
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "RepSummaryByMonth";
            queryParameter1.Name = "@pVersionId";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.pVersionID]", typeof(decimal));
            queryParameter2.Name = "@pFromMonth";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.pFromMonth]", typeof(int));
            queryParameter3.Name = "@pToMonth";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.pToMonth]", typeof(int));
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.StoredProcName = "RepSummaryByMonth";
            customSqlQuery1.Name = "Query";
            queryParameter4.Name = "pVersionID";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("[Parameters.pVersionID]", typeof(decimal));
            customSqlQuery1.Parameters.Add(queryParameter4);
            customSqlQuery1.Sql = "Select * From Version Where VersionID = @pVersionID";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1,
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 33F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // pVersionID
            // 
            this.pVersionID.Name = "pVersionID";
            this.pVersionID.Type = typeof(decimal);
            this.pVersionID.ValueInfo = "1";
            // 
            // pFromMonth
            // 
            this.pFromMonth.Name = "pFromMonth";
            this.pFromMonth.Type = typeof(int);
            this.pFromMonth.ValueInfo = "1";
            // 
            // pToMonth
            // 
            this.pToMonth.Name = "pToMonth";
            this.pToMonth.Type = typeof(int);
            this.pToMonth.ValueInfo = "12";
            // 
            // pDateStr
            // 
            this.pDateStr.Name = "pDateStr";
            this.pDateStr.Visible = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox1,
            this.xrTable2,
            this.xrLabel1,
            this.xrLabel2,
            this.xrLabel4,
            this.xrLabel5});
            this.ReportHeader.HeightF = 220.3333F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleLeft;
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(450.8871F, 65F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // xrTable2
            // 
            this.xrTable2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(194)))), ((int)(((byte)(230)))));
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 162F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1821.429F, 58.33333F);
            this.xrTable2.StylePriority.UseBackColor = false;
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UsePadding = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell14,
            this.xrTableCell15,
            this.xrTableCell9,
            this.xrTableCell16,
            this.xrTableCell17,
            this.xrTableCell19,
            this.xrTableCell6,
            this.xrTableCell11,
            this.xrTableCell20,
            this.xrTableCell24,
            this.xrTableCell32,
            this.xrTableCell34,
            this.xrTableCell4,
            this.xrTableCell3,
            this.xrTableCell5,
            this.xrTableCell1,
            this.xrTableCell7,
            this.xrTableCell2});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(194)))), ((int)(((byte)(230)))));
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.StylePriority.UseBackColor = false;
            this.xrTableCell14.Text = "No.";
            this.xrTableCell14.Weight = 0.13365960045135911D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.StylePriority.UseTextAlignment = false;
            this.xrTableCell15.Text = "Mã BCQT/ Management code";
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell15.Weight = 0.19231385426647496D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Text = "CHỈ TIÊU";
            this.xrTableCell9.Weight = 0.66123074031922224D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Text = "Đơn vị tính/Unit";
            this.xrTableCell16.Weight = 0.15382060345259138D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Multiline = true;
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Text = "Ghi chú/Notes";
            this.xrTableCell17.Weight = 0.14695683672934717D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Text = "Tổng [Query.VersionYear]/Total [Query.VersionYear]";
            this.xrTableCell19.Weight = 0.24084175195034024D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'Jan-\'+Substring([Query.VersionYear], 2)")});
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Weight = 0.20362077771503126D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'Feb-\'+Substring([Query.VersionYear], 2)")});
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Weight = 0.19705236688299979D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'Mar-\'+Substring([Query.VersionYear], 2)")});
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Weight = 0.20362077294057396D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'Apr-\'+Substring([Query.VersionYear], 2)")});
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.Text = "Apr";
            this.xrTableCell24.Weight = 0.20362077090645792D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'May-\'+Substring([Query.VersionYear], 2)")});
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.Text = "May";
            this.xrTableCell32.Weight = 0.20362077899190975D;
            // 
            // xrTableCell34
            // 
            this.xrTableCell34.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'Jun-\'+Substring([Query.VersionYear], 2)")});
            this.xrTableCell34.Name = "xrTableCell34";
            this.xrTableCell34.Text = "Jun";
            this.xrTableCell34.Weight = 0.20362076874816096D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'Jul-\'+Substring([Query.VersionYear], 2)")});
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "Jul";
            this.xrTableCell4.Weight = 0.20362077507051671D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'Aug-\'+Substring([Query.VersionYear], 2)")});
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Aug";
            this.xrTableCell3.Weight = 0.20362077507051668D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'Sep-\'+Substring([Query.VersionYear], 2)")});
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "Sep";
            this.xrTableCell5.Weight = 0.20362077507051665D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'Oct-\'+Substring([Query.VersionYear], 2)")});
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "Oct";
            this.xrTableCell1.Weight = 0.20362077507051668D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'Nov-\'+Substring([Query.VersionYear], 2)")});
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "Nov";
            this.xrTableCell7.Weight = 0.20362077507051668D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'Dec-\'+Substring([Query.VersionYear], 2)")});
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Dec";
            this.xrTableCell2.Weight = 0.22588055482421934D;
            // 
            // xrLabel1
            // 
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 65F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(450.8871F, 23F);
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "BAMBOO AIRWAYS";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 88.00001F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(1067.262F, 27.99999F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "BÁO CÁO TỔNG HỢP \r\n";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 116F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(1067.262F, 23.00002F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters].[pDateStr]")});
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 139F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(1067.262F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "xrLabel2";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // SummaryByMonth
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "RepSummaryByMonth";
            this.DataSource = this.sqlDataSource1;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 33, 100);
            this.PageHeight = 1169;
            this.PageWidth = 1850;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.pVersionID,
            this.pFromMonth,
            this.pToMonth,
            this.pDateStr});
            this.Version = "17.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    protected override void OnBeforePrint(System.Drawing.Printing.PrintEventArgs e)
    {
        base.OnBeforePrint(e);

        if (this.pVersionID.Value != null)
        {
            using (KTQTDataEntities entities = new KTQTDataEntities())
            {
                decimal versionID;
                if (!decimal.TryParse(this.pVersionID.Value.ToString(), out versionID))
                    return;
                var version = entities.Versions.SingleOrDefault(x => x.VersionID == versionID);

                this.xrLabel4.Text = version != null ? "Version: " + version.VersionName : string.Empty;
            }
        }
    }

    private void xrPivotGrid1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

       

    }

    private void xrPivotGrid1_FieldValueDisplayText(object sender, DevExpress.XtraReports.UI.PivotGrid.PivotFieldDisplayTextEventArgs e)
    {
        //if (e.ValueType == DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal)

    }
}
