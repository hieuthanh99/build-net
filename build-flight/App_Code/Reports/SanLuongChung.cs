using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Native.Presenters;
using System.Globalization;

/// <summary>
/// Summary description for SLChitietSanbay
/// </summary>
public class SanLuongChung : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private DevExpress.XtraReports.Parameters.Parameter P_AREA_CODE;
    private DevExpress.XtraReports.Parameters.Parameter P_FROM_DATE;
    private DevExpress.XtraReports.Parameters.Parameter P_TO_DATE;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell42;
    private XRTableCell xrTableCell41;
    private XRTableCell xrTableCell40;
    private XRTableCell xrTableCell39;
    private XRTableCell xrTableCell38;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell36;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell29;
    private XRTableRow xrTableRow3;
    private XRTable xrTable3;
    private GroupFooterBand GroupFooter1;
    private GroupHeaderBand GroupHeader1;
    private XRTableCell xrTableCell33;
    private XRLabel xrLabel1;
    private DevExpress.XtraReports.Parameters.Parameter P_DATE_STR;
    private XRLabel xrLabel2;
    private ReportFooterBand ReportFooter;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell43;
    private XRTableCell xrTableCell47;
    private XRTableCell xrTableCell48;
    private XRTableCell xrTableCell49;
    private XRTableCell xrTableCell50;
    private XRTableCell xrTableCell51;
    private XRTableCell xrTableCell52;
    private XRTableCell xrTableCell53;
    private XRTableCell xrTableCell54;
    private XRTableCell xrTableCell55;
    private XRTableCell xrTableCell56;
    private XRTableCell xrTableCell44;
    private XRTableCell xrTableCell45;
    private XRTableCell xrTableCell57;
    private XRTableCell xrTableCell58;
    private XRTableCell xrTableCell59;
    private XRTable xrTable2;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell60;
    private XRTableCell xrTableCell61;
    private XRTableCell xrTableCell62;
    private XRTableCell xrTableCell71;
    private XRTableCell xrTableCell72;
    private XRTableCell xrTableCell73;
    private XRTableCell xrTableCell74;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell46;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell66;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public SanLuongChung()
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
            string resourceFileName = "SanLuongChung.resx";
            System.Resources.ResourceManager resources = global::Resources.SanLuongChung.ResourceManager;
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.Parameters.StaticListLookUpSettings staticListLookUpSettings1 = new DevExpress.XtraReports.Parameters.StaticListLookUpSettings();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary10 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary11 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary12 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary13 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary14 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary15 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary16 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary17 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary18 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary19 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary20 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary21 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary22 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary23 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary24 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary25 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell57 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell60 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell61 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell62 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell71 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell72 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell73 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell74 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.P_AREA_CODE = new DevExpress.XtraReports.Parameters.Parameter();
            this.P_FROM_DATE = new DevExpress.XtraReports.Parameters.Parameter();
            this.P_TO_DATE = new DevExpress.XtraReports.Parameters.Parameter();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell58 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.P_DATE_STR = new DevExpress.XtraReports.Parameters.Parameter();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell59 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell53 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell54 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell55 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell56 = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
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
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1030.778F, 25F);
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell57,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrTableCell13,
            this.xrTableCell14});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumRecordNumber([OPT])")});
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell1.StylePriority.UseBorders = false;
            this.xrTableCell1.StylePriority.UsePadding = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell1.Summary = xrSummary1;
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell1.Weight = 0.28750001922607449D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OPT]")});
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell2.StylePriority.UseBorders = false;
            this.xrTableCell2.StylePriority.UsePadding = false;
            this.xrTableCell2.Weight = 0.44499985827636374D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FLIGHT_TYPE]")});
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell3.StylePriority.UseBorders = false;
            this.xrTableCell3.StylePriority.UsePadding = false;
            this.xrTableCell3.Weight = 0.43930020603760289D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FLS]")});
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell4.StylePriority.UseBorders = false;
            this.xrTableCell4.StylePriority.UsePadding = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell4.TextFormatString = "{0:#,#}";
            this.xrTableCell4.Weight = 0.46799939814174424D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FLS_VIP]")});
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell5.StylePriority.UseBorders = false;
            this.xrTableCell5.StylePriority.UsePadding = false;
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell5.TextFormatString = "{0:#,#}";
            this.xrTableCell5.Weight = 0.46799994212914314D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FLS_VIPA]")});
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell6.StylePriority.UseBorders = false;
            this.xrTableCell6.StylePriority.UsePadding = false;
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell6.TextFormatString = "{0:#,#}";
            this.xrTableCell6.Weight = 0.46800049144558231D;
            // 
            // xrTableCell57
            // 
            this.xrTableCell57.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell57.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FLS_TOTAL]")});
            this.xrTableCell57.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell57.Name = "xrTableCell57";
            this.xrTableCell57.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell57.StylePriority.UseBorders = false;
            this.xrTableCell57.StylePriority.UseFont = false;
            this.xrTableCell57.StylePriority.UsePadding = false;
            this.xrTableCell57.StylePriority.UseTextAlignment = false;
            this.xrTableCell57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell57.TextFormatString = "{0:#,#}";
            this.xrTableCell57.Weight = 0.519801292795248D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PAX_VIP]")});
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell7.StylePriority.UseBorders = false;
            this.xrTableCell7.StylePriority.UsePadding = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell7.TextFormatString = "{0:#,#}";
            this.xrTableCell7.Weight = 0.46800028136769889D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PAX_F]")});
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell8.StylePriority.UseBorders = false;
            this.xrTableCell8.StylePriority.UsePadding = false;
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell8.TextFormatString = "{0:#,#}";
            this.xrTableCell8.Weight = 0.46800027793634053D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PAX_C]")});
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell9.StylePriority.UseBorders = false;
            this.xrTableCell9.StylePriority.UsePadding = false;
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell9.TextFormatString = "{0:#,#}";
            this.xrTableCell9.Weight = 0.46800052424057664D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell10.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PAX_Y]")});
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell10.StylePriority.UseBorders = false;
            this.xrTableCell10.StylePriority.UsePadding = false;
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell10.TextFormatString = "{0:#,#}";
            this.xrTableCell10.Weight = 0.46799918285612518D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell11.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PAX_INF]")});
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell11.StylePriority.UseBorders = false;
            this.xrTableCell11.StylePriority.UsePadding = false;
            this.xrTableCell11.StylePriority.UseTextAlignment = false;
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell11.TextFormatString = "{0:#,#}";
            this.xrTableCell11.Weight = 0.46800006176250075D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell12.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[BAG_PCS]")});
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell12.StylePriority.UseBorders = false;
            this.xrTableCell12.StylePriority.UsePadding = false;
            this.xrTableCell12.StylePriority.UseTextAlignment = false;
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell12.TextFormatString = "{0:#,#}";
            this.xrTableCell12.Weight = 0.64540026998004929D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell13.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[MAIL]")});
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell13.StylePriority.UseBorders = false;
            this.xrTableCell13.StylePriority.UsePadding = false;
            this.xrTableCell13.StylePriority.UseTextAlignment = false;
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell13.TextFormatString = "{0:#,#}";
            this.xrTableCell13.Weight = 0.63430143760517832D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell14.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CARGO]")});
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell14.StylePriority.UseBorders = false;
            this.xrTableCell14.StylePriority.UsePadding = false;
            this.xrTableCell14.StylePriority.UseTextAlignment = false;
            this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell14.TextFormatString = "{0:#,#}";
            this.xrTableCell14.Weight = 0.70629908582873713D;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel1,
            this.xrTable2});
            this.TopMargin.HeightF = 168.375F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(199.1386F, 46.875F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(601.6114F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(199.1386F, 23.875F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(601.6114F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "SẢN LƯỢNG CHUNG";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTable2
            // 
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 94.45833F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5,
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1030.778F, 73.91669F);
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell60,
            this.xrTableCell61,
            this.xrTableCell62,
            this.xrTableCell66,
            this.xrTableCell71,
            this.xrTableCell72,
            this.xrTableCell73,
            this.xrTableCell74});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 2.6616233550828796D;
            // 
            // xrTableCell60
            // 
            this.xrTableCell60.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell60.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell60.Name = "xrTableCell60";
            this.xrTableCell60.RowSpan = 2;
            this.xrTableCell60.StylePriority.UseBorders = false;
            this.xrTableCell60.StylePriority.UseFont = false;
            this.xrTableCell60.StylePriority.UseTextAlignment = false;
            this.xrTableCell60.Text = "STT";
            this.xrTableCell60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell60.Weight = 0.39930557250976562D;
            // 
            // xrTableCell61
            // 
            this.xrTableCell61.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell61.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell61.Name = "xrTableCell61";
            this.xrTableCell61.RowSpan = 2;
            this.xrTableCell61.StylePriority.UseBorders = false;
            this.xrTableCell61.StylePriority.UseFont = false;
            this.xrTableCell61.StylePriority.UseTextAlignment = false;
            this.xrTableCell61.Text = "Hãng Hàng Không";
            this.xrTableCell61.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell61.Weight = 0.61805534362792969D;
            // 
            // xrTableCell62
            // 
            this.xrTableCell62.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell62.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell62.Name = "xrTableCell62";
            this.xrTableCell62.RowSpan = 2;
            this.xrTableCell62.StylePriority.UseBorders = false;
            this.xrTableCell62.StylePriority.UseFont = false;
            this.xrTableCell62.StylePriority.UseTextAlignment = false;
            this.xrTableCell62.Text = "Loại (đi/đến)";
            this.xrTableCell62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell62.Weight = 0.61013877868652355D;
            // 
            // xrTableCell66
            // 
            this.xrTableCell66.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell66.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell66.Name = "xrTableCell66";
            this.xrTableCell66.StylePriority.UseBorders = false;
            this.xrTableCell66.StylePriority.UseFont = false;
            this.xrTableCell66.StylePriority.UseTextAlignment = false;
            this.xrTableCell66.Text = "Chuyến bay";
            this.xrTableCell66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell66.Weight = 2.67194672517708D;
            // 
            // xrTableCell71
            // 
            this.xrTableCell71.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell71.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell71.Name = "xrTableCell71";
            this.xrTableCell71.StylePriority.UseBorders = false;
            this.xrTableCell71.StylePriority.UseFont = false;
            this.xrTableCell71.StylePriority.UseTextAlignment = false;
            this.xrTableCell71.Text = "Pax";
            this.xrTableCell71.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell71.Weight = 3.2500007634184063D;
            // 
            // xrTableCell72
            // 
            this.xrTableCell72.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell72.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell72.Multiline = true;
            this.xrTableCell72.Name = "xrTableCell72";
            this.xrTableCell72.RowSpan = 2;
            this.xrTableCell72.StylePriority.UseBorders = false;
            this.xrTableCell72.StylePriority.UseFont = false;
            this.xrTableCell72.StylePriority.UseTextAlignment = false;
            this.xrTableCell72.Text = "Hành lý\r\n(Kg)";
            this.xrTableCell72.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell72.Weight = 0.89638930861082555D;
            // 
            // xrTableCell73
            // 
            this.xrTableCell73.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell73.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell73.Multiline = true;
            this.xrTableCell73.Name = "xrTableCell73";
            this.xrTableCell73.RowSpan = 2;
            this.xrTableCell73.StylePriority.UseBorders = false;
            this.xrTableCell73.StylePriority.UseFont = false;
            this.xrTableCell73.StylePriority.UseTextAlignment = false;
            this.xrTableCell73.Text = "Mail\r\n(Kg)";
            this.xrTableCell73.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell73.Weight = 0.88097304217345185D;
            // 
            // xrTableCell74
            // 
            this.xrTableCell74.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell74.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell74.Multiline = true;
            this.xrTableCell74.Name = "xrTableCell74";
            this.xrTableCell74.RowSpan = 2;
            this.xrTableCell74.StylePriority.UseBorders = false;
            this.xrTableCell74.StylePriority.UseFont = false;
            this.xrTableCell74.StylePriority.UseTextAlignment = false;
            this.xrTableCell74.Text = "CGO\r\n(Kg)";
            this.xrTableCell74.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell74.Weight = 0.98097199333000551D;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell15,
            this.xrTableCell16,
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrTableCell19,
            this.xrTableCell20,
            this.xrTableCell46,
            this.xrTableCell21,
            this.xrTableCell22,
            this.xrTableCell23,
            this.xrTableCell24,
            this.xrTableCell25,
            this.xrTableCell26,
            this.xrTableCell27,
            this.xrTableCell28});
            this.xrTableRow2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.StylePriority.UseFont = false;
            this.xrTableRow2.StylePriority.UseTextAlignment = false;
            this.xrTableRow2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableRow2.Weight = 2.6616233550828796D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.StylePriority.UseBorders = false;
            this.xrTableCell15.StylePriority.UseTextAlignment = false;
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell15.Weight = 0.39930557250976562D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.StylePriority.UseBorders = false;
            this.xrTableCell16.StylePriority.UseTextAlignment = false;
            this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell16.Weight = 0.61805534362792969D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.StylePriority.UseBorders = false;
            this.xrTableCell17.StylePriority.UseTextAlignment = false;
            this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell17.Weight = 0.61013877868652355D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.StylePriority.UseBorders = false;
            this.xrTableCell18.StylePriority.UseTextAlignment = false;
            this.xrTableCell18.Text = "Thường lệ";
            this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell18.Weight = 0.65000010481485493D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.StylePriority.UseBorders = false;
            this.xrTableCell19.StylePriority.UseTextAlignment = false;
            this.xrTableCell19.Text = "VIP";
            this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell19.Weight = 0.6500000976316872D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.StylePriority.UseBorders = false;
            this.xrTableCell20.StylePriority.UseTextAlignment = false;
            this.xrTableCell20.Text = "VIPA";
            this.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell20.Weight = 0.65000009763166922D;
            // 
            // xrTableCell46
            // 
            this.xrTableCell46.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell46.Name = "xrTableCell46";
            this.xrTableCell46.StylePriority.UseBorders = false;
            this.xrTableCell46.StylePriority.UseTextAlignment = false;
            this.xrTableCell46.Text = "Tổng";
            this.xrTableCell46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell46.Weight = 0.72194642509886842D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.StylePriority.UseBorders = false;
            this.xrTableCell21.StylePriority.UseTextAlignment = false;
            this.xrTableCell21.Text = "VIP";
            this.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell21.Weight = 0.650000114541462D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.StylePriority.UseBorders = false;
            this.xrTableCell22.StylePriority.UseTextAlignment = false;
            this.xrTableCell22.Text = "F";
            this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell22.Weight = 0.65000014980057774D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.StylePriority.UseBorders = false;
            this.xrTableCell23.StylePriority.UseTextAlignment = false;
            this.xrTableCell23.Text = "C";
            this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell23.Weight = 0.65000011000690694D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.StylePriority.UseBorders = false;
            this.xrTableCell24.StylePriority.UseTextAlignment = false;
            this.xrTableCell24.Text = "Y";
            this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell24.Weight = 0.65000011824069759D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.StylePriority.UseBorders = false;
            this.xrTableCell25.StylePriority.UseTextAlignment = false;
            this.xrTableCell25.Text = "INF";
            this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell25.Weight = 0.65000011824084214D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.StylePriority.UseBorders = false;
            this.xrTableCell26.StylePriority.UseTextAlignment = false;
            this.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell26.Weight = 0.89638930861082555D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.StylePriority.UseBorders = false;
            this.xrTableCell27.StylePriority.UseTextAlignment = false;
            this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell27.Weight = 0.88097304217345185D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.StylePriority.UseBorders = false;
            this.xrTableCell28.StylePriority.UseTextAlignment = false;
            this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell28.Weight = 0.98097214591792559D;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // P_AREA_CODE
            // 
            this.P_AREA_CODE.Description = "Area Code";
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue("HAN", "HAN"));
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue("DAD", "DAD"));
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue("SGN", "SGN"));
            this.P_AREA_CODE.LookUpSettings = staticListLookUpSettings1;
            this.P_AREA_CODE.Name = "P_AREA_CODE";
            this.P_AREA_CODE.ValueInfo = "SGN";
            this.P_AREA_CODE.Visible = false;
            // 
            // P_FROM_DATE
            // 
            this.P_FROM_DATE.Description = "From Date";
            this.P_FROM_DATE.Name = "P_FROM_DATE";
            this.P_FROM_DATE.Type = typeof(System.DateTime);
            this.P_FROM_DATE.ValueInfo = "2018-06-01";
            this.P_FROM_DATE.Visible = false;
            // 
            // P_TO_DATE
            // 
            this.P_TO_DATE.Description = "To Date";
            this.P_TO_DATE.Name = "P_TO_DATE";
            this.P_TO_DATE.Type = typeof(System.DateTime);
            this.P_TO_DATE.ValueInfo = "2018-06-26";
            this.P_TO_DATE.Visible = false;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "STG_KTQT_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            queryParameter1.Name = "P_AREA_CODE";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.P_AREA_CODE]", typeof(string));
            queryParameter2.Name = "P_FROM_DATE";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.P_FROM_DATE]", typeof(System.DateTime));
            queryParameter3.Name = "P_TO_DATE";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.P_TO_DATE]", typeof(System.DateTime));
            customSqlQuery1.Parameters.Add(queryParameter1);
            customSqlQuery1.Parameters.Add(queryParameter2);
            customSqlQuery1.Parameters.Add(queryParameter3);
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell42.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CARGO])")});
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell42.StylePriority.UseBorders = false;
            this.xrTableCell42.StylePriority.UsePadding = false;
            this.xrTableCell42.StylePriority.UseTextAlignment = false;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrTableCell42.Summary = xrSummary2;
            this.xrTableCell42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell42.TextFormatString = "{0:#,#}";
            this.xrTableCell42.Weight = 0.70629908582873713D;
            // 
            // xrTableCell41
            // 
            this.xrTableCell41.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell41.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([MAIL])")});
            this.xrTableCell41.Name = "xrTableCell41";
            this.xrTableCell41.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell41.StylePriority.UseBorders = false;
            this.xrTableCell41.StylePriority.UsePadding = false;
            this.xrTableCell41.StylePriority.UseTextAlignment = false;
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrTableCell41.Summary = xrSummary3;
            this.xrTableCell41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell41.TextFormatString = "{0:#,#}";
            this.xrTableCell41.Weight = 0.63430143760517832D;
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell40.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([BAG_PCS])")});
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell40.StylePriority.UseBorders = false;
            this.xrTableCell40.StylePriority.UsePadding = false;
            this.xrTableCell40.StylePriority.UseTextAlignment = false;
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrTableCell40.Summary = xrSummary4;
            this.xrTableCell40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell40.TextFormatString = "{0:#,#}";
            this.xrTableCell40.Weight = 0.64540026998004929D;
            // 
            // xrTableCell39
            // 
            this.xrTableCell39.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell39.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([PAX_INF])")});
            this.xrTableCell39.Name = "xrTableCell39";
            this.xrTableCell39.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell39.StylePriority.UseBorders = false;
            this.xrTableCell39.StylePriority.UsePadding = false;
            this.xrTableCell39.StylePriority.UseTextAlignment = false;
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrTableCell39.Summary = xrSummary5;
            this.xrTableCell39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell39.TextFormatString = "{0:#,#}";
            this.xrTableCell39.Weight = 0.46800006176250075D;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell38.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([PAX_Y])")});
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell38.StylePriority.UseBorders = false;
            this.xrTableCell38.StylePriority.UsePadding = false;
            this.xrTableCell38.StylePriority.UseTextAlignment = false;
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrTableCell38.Summary = xrSummary6;
            this.xrTableCell38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell38.TextFormatString = "{0:#,#}";
            this.xrTableCell38.Weight = 0.46799918285612518D;
            // 
            // xrTableCell37
            // 
            this.xrTableCell37.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell37.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([PAX_C])")});
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell37.StylePriority.UseBorders = false;
            this.xrTableCell37.StylePriority.UsePadding = false;
            this.xrTableCell37.StylePriority.UseTextAlignment = false;
            xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrTableCell37.Summary = xrSummary7;
            this.xrTableCell37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell37.TextFormatString = "{0:#,#}";
            this.xrTableCell37.Weight = 0.46800052424057664D;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell36.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([PAX_F])")});
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell36.StylePriority.UseBorders = false;
            this.xrTableCell36.StylePriority.UsePadding = false;
            this.xrTableCell36.StylePriority.UseTextAlignment = false;
            xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrTableCell36.Summary = xrSummary8;
            this.xrTableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell36.TextFormatString = "{0:#,#}";
            this.xrTableCell36.Weight = 0.46800027793634053D;
            // 
            // xrTableCell35
            // 
            this.xrTableCell35.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell35.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([PAX_VIP])")});
            this.xrTableCell35.Name = "xrTableCell35";
            this.xrTableCell35.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell35.StylePriority.UseBorders = false;
            this.xrTableCell35.StylePriority.UsePadding = false;
            this.xrTableCell35.StylePriority.UseTextAlignment = false;
            xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrTableCell35.Summary = xrSummary9;
            this.xrTableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell35.TextFormatString = "{0:#,#}";
            this.xrTableCell35.Weight = 0.46800028136771188D;
            // 
            // xrTableCell34
            // 
            this.xrTableCell34.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell34.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([FLS_VIPA])")});
            this.xrTableCell34.Name = "xrTableCell34";
            this.xrTableCell34.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell34.StylePriority.UseBorders = false;
            this.xrTableCell34.StylePriority.UsePadding = false;
            this.xrTableCell34.StylePriority.UseTextAlignment = false;
            xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrTableCell34.Summary = xrSummary10;
            this.xrTableCell34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell34.TextFormatString = "{0:#,#}";
            this.xrTableCell34.Weight = 0.46800049144558231D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell32.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([FLS])")});
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell32.StylePriority.UseBorders = false;
            this.xrTableCell32.StylePriority.UsePadding = false;
            this.xrTableCell32.StylePriority.UseTextAlignment = false;
            xrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrTableCell32.Summary = xrSummary11;
            this.xrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell32.TextFormatString = "{0:#,#}";
            this.xrTableCell32.Weight = 0.46799939814174424D;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell31.StylePriority.UseBorders = false;
            this.xrTableCell31.StylePriority.UsePadding = false;
            this.xrTableCell31.Weight = 0.43930020603760289D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell30.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OPT]")});
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell30.StylePriority.UseBorders = false;
            this.xrTableCell30.StylePriority.UsePadding = false;
            this.xrTableCell30.Weight = 0.44499985827636374D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell29.StylePriority.UseBorders = false;
            this.xrTableCell29.StylePriority.UsePadding = false;
            this.xrTableCell29.Text = "Tổng";
            this.xrTableCell29.Weight = 0.28750001922607449D;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell29,
            this.xrTableCell30,
            this.xrTableCell31,
            this.xrTableCell32,
            this.xrTableCell33,
            this.xrTableCell34,
            this.xrTableCell58,
            this.xrTableCell35,
            this.xrTableCell36,
            this.xrTableCell37,
            this.xrTableCell38,
            this.xrTableCell39,
            this.xrTableCell40,
            this.xrTableCell41,
            this.xrTableCell42});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell33.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([FLS_VIP])")});
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell33.StylePriority.UseBorders = false;
            this.xrTableCell33.StylePriority.UsePadding = false;
            this.xrTableCell33.StylePriority.UseTextAlignment = false;
            xrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrTableCell33.Summary = xrSummary12;
            this.xrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell33.TextFormatString = "{0:#,#}";
            this.xrTableCell33.Weight = 0.46799972240252313D;
            // 
            // xrTableCell58
            // 
            this.xrTableCell58.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell58.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([FLS_TOTAL])")});
            this.xrTableCell58.Name = "xrTableCell58";
            this.xrTableCell58.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell58.StylePriority.UseBorders = false;
            this.xrTableCell58.StylePriority.UsePadding = false;
            this.xrTableCell58.StylePriority.UseTextAlignment = false;
            xrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrTableCell58.Summary = xrSummary13;
            this.xrTableCell58.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell58.TextFormatString = "{0:#,#}";
            this.xrTableCell58.Weight = 0.51980151252185491D;
            // 
            // xrTable3
            // 
            this.xrTable3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(1030.778F, 25F);
            this.xrTable3.StylePriority.UseFont = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
            this.GroupFooter1.Expanded = false;
            this.GroupFooter1.HeightF = 25F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.Visible = false;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("OPT", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("FLIGHTTYPE", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 0F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.Visible = false;
            // 
            // P_DATE_STR
            // 
            this.P_DATE_STR.Name = "P_DATE_STR";
            this.P_DATE_STR.Visible = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4});
            this.ReportFooter.HeightF = 53.125F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrTable4
            // 
            this.xrTable4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable4.SizeF = new System.Drawing.SizeF(1030.778F, 25F);
            this.xrTable4.StylePriority.UseFont = false;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell44,
            this.xrTableCell45,
            this.xrTableCell43,
            this.xrTableCell47,
            this.xrTableCell48,
            this.xrTableCell59,
            this.xrTableCell49,
            this.xrTableCell50,
            this.xrTableCell51,
            this.xrTableCell52,
            this.xrTableCell53,
            this.xrTableCell54,
            this.xrTableCell55,
            this.xrTableCell56});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell44
            // 
            this.xrTableCell44.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell44.Name = "xrTableCell44";
            this.xrTableCell44.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell44.StylePriority.UseBorders = false;
            this.xrTableCell44.StylePriority.UsePadding = false;
            this.xrTableCell44.StylePriority.UseTextAlignment = false;
            this.xrTableCell44.Text = "Tổng cộng";
            this.xrTableCell44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell44.Weight = 0.73249985083625613D;
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell45.StylePriority.UseBorders = false;
            this.xrTableCell45.StylePriority.UsePadding = false;
            this.xrTableCell45.StylePriority.UseTextAlignment = false;
            this.xrTableCell45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell45.Weight = 0.43930050827582312D;
            // 
            // xrTableCell43
            // 
            this.xrTableCell43.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell43.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([FLS])")});
            this.xrTableCell43.Name = "xrTableCell43";
            this.xrTableCell43.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell43.StylePriority.UseBorders = false;
            this.xrTableCell43.StylePriority.UsePadding = false;
            this.xrTableCell43.StylePriority.UseTextAlignment = false;
            xrSummary14.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell43.Summary = xrSummary14;
            this.xrTableCell43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell43.TextFormatString = "{0:#,#}";
            this.xrTableCell43.Weight = 0.46799944004068073D;
            // 
            // xrTableCell47
            // 
            this.xrTableCell47.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell47.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([FLS_VIP])")});
            this.xrTableCell47.Name = "xrTableCell47";
            this.xrTableCell47.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell47.StylePriority.UseBorders = false;
            this.xrTableCell47.StylePriority.UsePadding = false;
            this.xrTableCell47.StylePriority.UseTextAlignment = false;
            xrSummary15.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell47.Summary = xrSummary15;
            this.xrTableCell47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell47.TextFormatString = "{0:#,#}";
            this.xrTableCell47.Weight = 0.46799976937004373D;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell48.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([FLS_VIPA])")});
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell48.StylePriority.UseBorders = false;
            this.xrTableCell48.StylePriority.UsePadding = false;
            this.xrTableCell48.StylePriority.UseTextAlignment = false;
            xrSummary16.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell48.Summary = xrSummary16;
            this.xrTableCell48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell48.TextFormatString = "{0:#,#}";
            this.xrTableCell48.Weight = 0.46800053841312295D;
            // 
            // xrTableCell59
            // 
            this.xrTableCell59.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell59.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([FLS_TOTAL])")});
            this.xrTableCell59.Name = "xrTableCell59";
            this.xrTableCell59.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell59.StylePriority.UseBorders = false;
            this.xrTableCell59.StylePriority.UsePadding = false;
            this.xrTableCell59.StylePriority.UseTextAlignment = false;
            xrSummary17.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell59.Summary = xrSummary17;
            this.xrTableCell59.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell59.TextFormatString = "{0:#,#}";
            this.xrTableCell59.Weight = 0.51980150106969569D;
            // 
            // xrTableCell49
            // 
            this.xrTableCell49.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell49.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([PAX_VIP])")});
            this.xrTableCell49.Name = "xrTableCell49";
            this.xrTableCell49.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell49.StylePriority.UseBorders = false;
            this.xrTableCell49.StylePriority.UsePadding = false;
            this.xrTableCell49.StylePriority.UseTextAlignment = false;
            xrSummary18.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell49.Summary = xrSummary18;
            this.xrTableCell49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell49.TextFormatString = "{0:#,#}";
            this.xrTableCell49.Weight = 0.46800032144612352D;
            // 
            // xrTableCell50
            // 
            this.xrTableCell50.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell50.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([PAX_F])")});
            this.xrTableCell50.Name = "xrTableCell50";
            this.xrTableCell50.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell50.StylePriority.UseBorders = false;
            this.xrTableCell50.StylePriority.UsePadding = false;
            this.xrTableCell50.StylePriority.UseTextAlignment = false;
            xrSummary19.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell50.Summary = xrSummary19;
            this.xrTableCell50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell50.TextFormatString = "{0:#,#}";
            this.xrTableCell50.Weight = 0.4680003283508366D;
            // 
            // xrTableCell51
            // 
            this.xrTableCell51.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell51.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([PAX_C])")});
            this.xrTableCell51.Name = "xrTableCell51";
            this.xrTableCell51.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell51.StylePriority.UseBorders = false;
            this.xrTableCell51.StylePriority.UsePadding = false;
            this.xrTableCell51.StylePriority.UseTextAlignment = false;
            xrSummary20.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell51.Summary = xrSummary20;
            this.xrTableCell51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell51.TextFormatString = "{0:#,#}";
            this.xrTableCell51.Weight = 0.46799964032458563D;
            // 
            // xrTableCell52
            // 
            this.xrTableCell52.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell52.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([PAX_Y])")});
            this.xrTableCell52.Name = "xrTableCell52";
            this.xrTableCell52.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell52.StylePriority.UseBorders = false;
            this.xrTableCell52.StylePriority.UsePadding = false;
            this.xrTableCell52.StylePriority.UseTextAlignment = false;
            xrSummary21.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell52.Summary = xrSummary21;
            this.xrTableCell52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell52.TextFormatString = "{0:#,#}";
            this.xrTableCell52.Weight = 0.4680001141466692D;
            // 
            // xrTableCell53
            // 
            this.xrTableCell53.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell53.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([PAX_INF])")});
            this.xrTableCell53.Name = "xrTableCell53";
            this.xrTableCell53.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell53.StylePriority.UseBorders = false;
            this.xrTableCell53.StylePriority.UsePadding = false;
            this.xrTableCell53.StylePriority.UseTextAlignment = false;
            xrSummary22.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell53.Summary = xrSummary22;
            this.xrTableCell53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell53.TextFormatString = "{0:#,#}";
            this.xrTableCell53.Weight = 0.46800011414666931D;
            // 
            // xrTableCell54
            // 
            this.xrTableCell54.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell54.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([BAG_PCS])")});
            this.xrTableCell54.Name = "xrTableCell54";
            this.xrTableCell54.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell54.StylePriority.UseBorders = false;
            this.xrTableCell54.StylePriority.UsePadding = false;
            this.xrTableCell54.StylePriority.UseTextAlignment = false;
            xrSummary23.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell54.Summary = xrSummary23;
            this.xrTableCell54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell54.TextFormatString = "{0:#,#}";
            this.xrTableCell54.Weight = 0.64540032711773376D;
            // 
            // xrTableCell55
            // 
            this.xrTableCell55.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell55.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([MAIL])")});
            this.xrTableCell55.Name = "xrTableCell55";
            this.xrTableCell55.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell55.StylePriority.UseBorders = false;
            this.xrTableCell55.StylePriority.UsePadding = false;
            this.xrTableCell55.StylePriority.UseTextAlignment = false;
            xrSummary24.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell55.Summary = xrSummary24;
            this.xrTableCell55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell55.TextFormatString = "{0:#,#}";
            this.xrTableCell55.Weight = 0.63430149253691415D;
            // 
            // xrTableCell56
            // 
            this.xrTableCell56.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell56.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CARGO])")});
            this.xrTableCell56.Name = "xrTableCell56";
            this.xrTableCell56.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell56.StylePriority.UseBorders = false;
            this.xrTableCell56.StylePriority.UsePadding = false;
            this.xrTableCell56.StylePriority.UseTextAlignment = false;
            xrSummary25.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell56.Summary = xrSummary25;
            this.xrTableCell56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell56.TextFormatString = "{0:#,#}";
            this.xrTableCell56.Weight = 0.70629887082933673D;
            // 
            // SanLuongChung
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupFooter1,
            this.GroupHeader1,
            this.ReportFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(32, 36, 168, 100);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.P_AREA_CODE,
            this.P_FROM_DATE,
            this.P_TO_DATE,
            this.P_DATE_STR});
            this.Version = "17.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    protected override BandPresenter CreateBandPresenter()
    {
        var bandPresenter = base.CreateBandPresenter();
        CultureInfo culture = new CultureInfo("vi-VN");

        return new BandPresenterWrapper(bandPresenter, culture, this);
    }

    protected override void OnBeforePrint(System.Drawing.Printing.PrintEventArgs e)
    {
        base.OnBeforePrint(e);

        this.xrLabel2.Text = "Từ ngày: " + ((DateTime)this.P_FROM_DATE.Value).ToString("dd/MM/yyyy") + " đến ngày: " + ((DateTime)this.P_TO_DATE.Value).ToString("dd/MM/yyyy");
    }


}
