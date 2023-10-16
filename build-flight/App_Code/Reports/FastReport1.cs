using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for FastReport1
/// </summary>
public class FastReport1 : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private DevExpress.XtraReports.Parameters.Parameter pMonth;
    private DevExpress.XtraReports.Parameters.Parameter pYear;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell18;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell33;
    private XRTableCell xrTableCell36;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell21;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell38;
    private XRTableCell xrTableCell39;
    private XRTableCell xrTableCell40;
    private XRTableCell xrTableCell41;
    private XRTableCell xrTableCell42;
    private XRTableCell xrTableCell43;
    private XRTableCell xrTableCell44;
    private XRTableCell xrTableCell45;
    private XRTableCell xrTableCell46;
    private XRTableCell xrTableCell47;
    private XRTableCell xrTableCell48;
    private XRTableCell xrTableCell49;
    private XRTableCell xrTableCell51;
    private XRTableCell xrTableCell52;
    private XRTableCell xrTableCell28;
    private XRLabel xrLabel2;
    private XRLabel xrLabel4;
    private DevExpress.XtraReports.Parameters.Parameter pMonthYear;
    private DevExpress.XtraReports.Parameters.Parameter pStrYear1;
    private DevExpress.XtraReports.Parameters.Parameter pStrYear2;
    private DevExpress.XtraReports.Parameters.Parameter pStrYear3;
    private DevExpress.XtraReports.Parameters.Parameter pStrMonth1;
    private DevExpress.XtraReports.Parameters.Parameter pStrMonth2;
    private XRLabel xrLabel3;
    private ReportHeaderBand ReportHeader;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public FastReport1()
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
            string resourceFileName = "FastReport1.resx";
            System.Resources.ResourceManager resources = global::Resources.FastReport1.ResourceManager;
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.pMonth = new DevExpress.XtraReports.Parameters.Parameter();
            this.pYear = new DevExpress.XtraReports.Parameters.Parameter();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
            this.pMonthYear = new DevExpress.XtraReports.Parameters.Parameter();
            this.pStrYear1 = new DevExpress.XtraReports.Parameters.Parameter();
            this.pStrYear2 = new DevExpress.XtraReports.Parameters.Parameter();
            this.pStrYear3 = new DevExpress.XtraReports.Parameters.Parameter();
            this.pStrMonth1 = new DevExpress.XtraReports.Parameters.Parameter();
            this.pStrMonth2 = new DevExpress.XtraReports.Parameters.Parameter();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1623F, 25F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UsePadding = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.xrTableCell4,
            this.xrTableCell8,
            this.xrTableCell1,
            this.xrTableCell9,
            this.xrTableCell5,
            this.xrTableCell10,
            this.xrTableCell2,
            this.xrTableCell11,
            this.xrTableCell6,
            this.xrTableCell12,
            this.xrTableCell3,
            this.xrTableCell13,
            this.xrTableCell14});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Sorting]")});
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Weight = 0.13576450467079798D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Description]")});
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Weight = 0.52240779514163971D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount1]")});
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell8.TextFormatString = "{0:n2}";
            this.xrTableCell8.Weight = 0.30316339586543939D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount2]")});
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell1.TextFormatString = "{0:n2}";
            this.xrTableCell1.Weight = 0.3031632551779605D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount3]")});
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell9.TextFormatString = "{0:n2}";
            this.xrTableCell9.Weight = 0.30316342462049861D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount4]")});
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell5.TextFormatString = "{0:n2}";
            this.xrTableCell5.Weight = 0.30316358587535941D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount5]")});
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell10.TextFormatString = "{0:n2}";
            this.xrTableCell10.Weight = 0.303163263803863D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount6]")});
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell2.TextFormatString = "{0:n2}";
            this.xrTableCell2.Weight = 0.30316342462049867D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount7]")});
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.StylePriority.UseTextAlignment = false;
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell11.TextFormatString = "{0:n2}";
            this.xrTableCell11.Weight = 0.30316375647902843D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount8]")});
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell6.TextFormatString = "{0:n2}";
            this.xrTableCell6.Weight = 0.30316341456417906D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount9]")});
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.StylePriority.UseTextAlignment = false;
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell12.TextFormatString = "{0:n2}";
            this.xrTableCell12.Weight = 0.30316343467681772D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount10]")});
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell3.TextFormatString = "{0:0.00%}";
            this.xrTableCell3.Weight = 0.30316341456417961D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount11]")});
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.StylePriority.UseTextAlignment = false;
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell13.TextFormatString = "{0:0.00%}";
            this.xrTableCell13.Weight = 0.30316343467681761D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Attribute1]")});
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Weight = 0.28558851441021116D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 35F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 59.16667F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.StylePriority.UseTextAlignment = false;
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // pMonth
            // 
            this.pMonth.Name = "pMonth";
            this.pMonth.Type = typeof(int);
            this.pMonth.ValueInfo = "11";
            this.pMonth.Visible = false;
            // 
            // pYear
            // 
            this.pYear.Name = "pYear";
            this.pYear.Type = typeof(int);
            this.pYear.ValueInfo = "2018";
            this.pYear.Visible = false;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "KTQT_Data_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            queryParameter1.Name = "pMonth";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.pMonth]", typeof(int));
            queryParameter2.Name = "pYear";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.pYear]", typeof(int));
            customSqlQuery1.Parameters.Add(queryParameter1);
            customSqlQuery1.Parameters.Add(queryParameter2);
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(7.152557E-05F, 75.99996F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(1623F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0.0001192093F, 98.99998F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(1623F, 23.00001F);
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Đơn vị: Triệu đồng";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 46.33334F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(1623F, 29.66665F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "BÁO CÁO MỘT SỐ CHỈ TIÊU SẢN XUẤT KINH DOANH ";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 142.7083F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2,
            this.xrTableRow3,
            this.xrTableRow4});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1623F, 112.5F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UsePadding = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell25,
            this.xrTableCell22,
            this.xrTableCell16,
            this.xrTableCell23,
            this.xrTableCell17,
            this.xrTableCell24,
            this.xrTableCell18});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 0.55932197603677247D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.RowSpan = 2;
            this.xrTableCell25.StylePriority.UseTextAlignment = false;
            this.xrTableCell25.Text = "STT";
            this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell25.Weight = 0.09519406846632239D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.RowSpan = 2;
            this.xrTableCell22.StylePriority.UseTextAlignment = false;
            this.xrTableCell22.Text = "CÁC CHỈ TIÊU";
            this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell22.Weight = 0.36629700975893026D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Weight = 0.63770776865789691D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.Weight = 0.63770790968181468D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Weight = 0.63770810711529968D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.Text = "So sánh";
            this.xrTableCell24.Weight = 0.42513860958840793D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.RowSpan = 2;
            this.xrTableCell18.Text = "Ghi chú";
            this.xrTableCell18.Weight = 0.200246526731328D;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell26,
            this.xrTableCell27,
            this.xrTableCell29,
            this.xrTableCell30,
            this.xrTableCell19,
            this.xrTableCell31,
            this.xrTableCell32,
            this.xrTableCell33,
            this.xrTableCell36,
            this.xrTableCell37,
            this.xrTableCell20,
            this.xrTableCell34,
            this.xrTableCell28,
            this.xrTableCell21});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1.1864406069542208D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.Weight = 0.095194171883862144D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.Weight = 0.36629689693979606D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.Weight = 0.21256929539260946D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.Weight = 0.21256929774300809D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Weight = 0.21256929774300812D;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.Text = "Thực hiện từ đầu năm đến hết tháng trước ";
            this.xrTableCell31.Weight = 0.21256929539260946D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.Text = "Ước thực hiện tháng báo cáo ";
            this.xrTableCell32.Weight = 0.21256929774300809D;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.Text = "Lũy kế từ đầu năm đến tháng báo cáo ";
            this.xrTableCell33.Weight = 0.21256930596940332D;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.Text = "Thực hiện từ đầu năm đến hết tháng trước ";
            this.xrTableCell36.Weight = 0.2125692959802091D;
            // 
            // xrTableCell37
            // 
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.Text = "Thực hiện tháng báo cáo năm trước ";
            this.xrTableCell37.Weight = 0.21256929803680791D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Text = "Lũy kế từ đầu năm đến tháng báo cáo năm trước ";
            this.xrTableCell20.Weight = 0.21256929803680796D;
            // 
            // xrTableCell34
            // 
            this.xrTableCell34.Name = "xrTableCell34";
            this.xrTableCell34.Text = "So với tháng báo cáo năm trước ";
            this.xrTableCell34.Weight = 0.21256930479420408D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.Text = "So với lũy kế cùng kỳ năm trước ";
            this.xrTableCell28.Weight = 0.2125692977430082D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Weight = 0.20024664660165817D;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell38,
            this.xrTableCell39,
            this.xrTableCell40,
            this.xrTableCell41,
            this.xrTableCell42,
            this.xrTableCell43,
            this.xrTableCell44,
            this.xrTableCell45,
            this.xrTableCell46,
            this.xrTableCell47,
            this.xrTableCell48,
            this.xrTableCell49,
            this.xrTableCell51,
            this.xrTableCell52});
            this.xrTableRow4.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.StylePriority.UseFont = false;
            this.xrTableRow4.StylePriority.UseTextAlignment = false;
            this.xrTableRow4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableRow4.Weight = 0.54237277352307611D;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.Text = "1";
            this.xrTableCell38.Weight = 0.095194171883862144D;
            // 
            // xrTableCell39
            // 
            this.xrTableCell39.Name = "xrTableCell39";
            this.xrTableCell39.Text = "2";
            this.xrTableCell39.Weight = 0.36629692514457962D;
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.Text = "3";
            this.xrTableCell40.Weight = 0.2125692671878259D;
            // 
            // xrTableCell41
            // 
            this.xrTableCell41.Name = "xrTableCell41";
            this.xrTableCell41.Text = "4";
            this.xrTableCell41.Weight = 0.21256929774300809D;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.Text = "5";
            this.xrTableCell42.Weight = 0.21256918492387383D;
            // 
            // xrTableCell43
            // 
            this.xrTableCell43.Name = "xrTableCell43";
            this.xrTableCell43.Text = "6";
            this.xrTableCell43.Weight = 0.21256940821174378D;
            // 
            // xrTableCell44
            // 
            this.xrTableCell44.Name = "xrTableCell44";
            this.xrTableCell44.Text = "7";
            this.xrTableCell44.Weight = 0.21256931184539987D;
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.Text = "8";
            this.xrTableCell45.Weight = 0.2125691790478772D;
            // 
            // xrTableCell46
            // 
            this.xrTableCell46.Name = "xrTableCell46";
            this.xrTableCell46.Text = "9";
            this.xrTableCell46.Weight = 0.21256952161847775D;
            // 
            // xrTableCell47
            // 
            this.xrTableCell47.Name = "xrTableCell47";
            this.xrTableCell47.Text = "10";
            this.xrTableCell47.Weight = 0.21256929803680794D;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.Text = "11";
            this.xrTableCell48.Weight = 0.21256929803680791D;
            // 
            // xrTableCell49
            // 
            this.xrTableCell49.Name = "xrTableCell49";
            this.xrTableCell49.Text = "12";
            this.xrTableCell49.Weight = 0.21256929069181219D;
            // 
            // xrTableCell51
            // 
            this.xrTableCell51.Name = "xrTableCell51";
            this.xrTableCell51.Text = "13";
            this.xrTableCell51.Weight = 0.21256929069181224D;
            // 
            // xrTableCell52
            // 
            this.xrTableCell52.Name = "xrTableCell52";
            this.xrTableCell52.Text = "14";
            this.xrTableCell52.Weight = 0.20024655493611157D;
            // 
            // pMonthYear
            // 
            this.pMonthYear.Name = "pMonthYear";
            this.pMonthYear.ValueInfo = "Thang 11/2018";
            this.pMonthYear.Visible = false;
            // 
            // pStrYear1
            // 
            this.pStrYear1.Name = "pStrYear1";
            this.pStrYear1.ValueInfo = "KH nam 2018";
            this.pStrYear1.Visible = false;
            // 
            // pStrYear2
            // 
            this.pStrYear2.Name = "pStrYear2";
            this.pStrYear2.ValueInfo = "UTH nam 2018";
            this.pStrYear2.Visible = false;
            // 
            // pStrYear3
            // 
            this.pStrYear3.Name = "pStrYear3";
            this.pStrYear3.ValueInfo = "Thuc hien nam 2017";
            this.pStrYear3.Visible = false;
            // 
            // pStrMonth1
            // 
            this.pStrMonth1.Name = "pStrMonth1";
            this.pStrMonth1.ValueInfo = "Thang 11/2018";
            this.pStrMonth1.Visible = false;
            // 
            // pStrMonth2
            // 
            this.pStrMonth2.Name = "pStrMonth2";
            this.pStrMonth2.ValueInfo = "Luy ke thang 11/2018";
            this.pStrMonth2.Visible = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2});
            this.ReportHeader.HeightF = 255.2083F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // FastReport1
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Margins = new System.Drawing.Printing.Margins(18, 13, 35, 59);
            this.PageHeight = 1169;
            this.PageWidth = 1654;
            this.PaperKind = System.Drawing.Printing.PaperKind.A3Rotated;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.pMonth,
            this.pYear,
            this.pMonthYear,
            this.pStrYear1,
            this.pStrYear2,
            this.pStrYear3,
            this.pStrMonth1,
            this.pStrMonth2});
            this.Version = "17.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    protected override void OnBeforePrint(System.Drawing.Printing.PrintEventArgs e)
    {
        base.OnBeforePrint(e);
        int month = Convert.ToInt32(this.pMonth.Value);
        int year = Convert.ToInt32(this.pYear.Value);
        xrLabel3.Text = "Tháng " + month + "/" + year;
        xrTableCell16.Text = "KH năm " + year;
        xrTableCell29.Text = "KH năm " + year;
        xrTableCell23.Text = "UTH năm " + year;
        xrTableCell17.Text = "Thực hiện năm " + (year - 1);
        xrTableCell30.Text = "KH tháng " + month + "/" + year;
        xrTableCell19.Text = "KH lũy kế đến tháng " + month + "/" + year;

        FormattingRule rule = new FormattingRule();
        this.FormattingRuleSheet.Add(rule);

        rule.DataSource = this.DataSource;
        rule.DataMember = this.DataMember;
        rule.Condition = "IsNullOrEmpty([ParentID])";
        rule.Formatting.Font = new Font("Times New Roman", 10, FontStyle.Bold );

        this.Detail.FormattingRules.Add(rule);
    }
   
}
