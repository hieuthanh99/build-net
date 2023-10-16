using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using KTQTData;
using System.Linq;

/// <summary>
/// Summary description for ChitietChiphiTheoNhomChiphi
/// </summary>
public class ChitietChiphiTheoNhomChiphi : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private DevExpress.XtraReports.Parameters.Parameter pVersionID;
    private DevExpress.XtraReports.Parameters.Parameter pFromDate;
    private DevExpress.XtraReports.Parameters.Parameter pToDate;
    private DevExpress.XtraReports.Parameters.Parameter pAreaCode;
    private DevExpress.XtraReports.Parameters.Parameter pCarrier;
    private DevExpress.XtraReports.Parameters.Parameter pNetwork;
    private DevExpress.XtraReports.Parameters.Parameter pFltType;
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
    private GroupHeaderBand GroupHeader1;
    private XRLabel xrLabel1;
    private ReportHeaderBand ReportHeader;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell19;
    private ReportFooterBand ReportFooter;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell22;
    private XRLabel xrLabel2;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private XRLabel xrLabel5;
    private DevExpress.XtraReports.Parameters.Parameter pDateStr;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell26;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell25;
    private DevExpress.XtraReports.Parameters.Parameter pCostType;
    private XRTable xrTable5;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell30;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ChitietChiphiTheoNhomChiphi()
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
            string resourceFileName = "ChitietChiphiTheoNhomChiphi.resx";
            System.Resources.ResourceManager resources = global::Resources.ChitietChiphiTheoNhomChiphi.ResourceManager;
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter6 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter7 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter8 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.pVersionID = new DevExpress.XtraReports.Parameters.Parameter();
            this.pFromDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.pToDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.pAreaCode = new DevExpress.XtraReports.Parameters.Parameter();
            this.pCarrier = new DevExpress.XtraReports.Parameters.Parameter();
            this.pNetwork = new DevExpress.XtraReports.Parameters.Parameter();
            this.pFltType = new DevExpress.XtraReports.Parameters.Parameter();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.pDateStr = new DevExpress.XtraReports.Parameters.Parameter();
            this.pCostType = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
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
            this.Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("TOTAL_COST", DevExpress.XtraReports.UI.XRColumnSortOrder.Descending)});
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
            this.xrTable1.SizeF = new System.Drawing.SizeF(796.0002F, 25F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UsePadding = false;
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
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell24});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Flt_Month]")});
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Weight = 0.67708328247070315D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Flt_Year]")});
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Weight = 0.6770834350585937D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CARRIER]")});
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Weight = 0.6875D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AC_Group]")});
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Weight = 0.71874984741210945D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Network]")});
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Weight = 0.8020834350585937D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Flt_Type]")});
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Weight = 0.7604165649414063D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COST]")});
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell7.TextFormatString = "{0:n2}";
            this.xrTableCell7.Weight = 1.1770834350585933D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COSTCTY]")});
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell8.TextFormatString = "{0:n2}";
            this.xrTableCell8.Weight = 1.1579168701171878D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TOTAL_COST]")});
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.StylePriority.UseTextAlignment = false;
            this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell24.TextFormatString = "{0:n2}";
            this.xrTableCell24.Weight = 1.3020855712890627D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 23.91669F;
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
            this.pVersionID.Type = typeof(long);
            this.pVersionID.ValueInfo = "4";
            this.pVersionID.Visible = false;
            // 
            // pFromDate
            // 
            this.pFromDate.Name = "pFromDate";
            this.pFromDate.Type = typeof(System.DateTime);
            this.pFromDate.ValueInfo = "2018-12-01";
            this.pFromDate.Visible = false;
            // 
            // pToDate
            // 
            this.pToDate.Name = "pToDate";
            this.pToDate.Type = typeof(System.DateTime);
            this.pToDate.ValueInfo = "2018-12-02";
            this.pToDate.Visible = false;
            // 
            // pAreaCode
            // 
            this.pAreaCode.Name = "pAreaCode";
            this.pAreaCode.ValueInfo = "SGN";
            this.pAreaCode.Visible = false;
            // 
            // pCarrier
            // 
            this.pCarrier.Name = "pCarrier";
            this.pCarrier.ValueInfo = "ALL";
            this.pCarrier.Visible = false;
            // 
            // pNetwork
            // 
            this.pNetwork.Name = "pNetwork";
            this.pNetwork.ValueInfo = "ALL";
            this.pNetwork.Visible = false;
            // 
            // pFltType
            // 
            this.pFltType.Name = "pFltType";
            this.pFltType.ValueInfo = "ALL";
            this.pFltType.Visible = false;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "KTQT_Data_Connection";
            this.sqlDataSource1.ConnectionOptions.DbCommandTimeout = 0;
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            queryParameter1.Name = "pVersionID";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.pVersionID]", typeof(long));
            queryParameter2.Name = "pFromDate";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.pFromDate]", typeof(System.DateTime));
            queryParameter3.Name = "pToDate";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.pToDate]", typeof(System.DateTime));
            queryParameter4.Name = "pAreaCode";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("[Parameters.pAreaCode]", typeof(string));
            queryParameter5.Name = "pCarrier";
            queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter5.Value = new DevExpress.DataAccess.Expression("[Parameters.pCarrier]", typeof(string));
            queryParameter6.Name = "pNetwork";
            queryParameter6.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter6.Value = new DevExpress.DataAccess.Expression("[Parameters.pNetwork]", typeof(string));
            queryParameter7.Name = "pFltType";
            queryParameter7.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter7.Value = new DevExpress.DataAccess.Expression("[Parameters.pFltType]", typeof(string));
            queryParameter8.Name = "pCostType";
            queryParameter8.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter8.Value = new DevExpress.DataAccess.Expression("[Parameters.pCostType]", typeof(string));
            customSqlQuery1.Parameters.Add(queryParameter1);
            customSqlQuery1.Parameters.Add(queryParameter2);
            customSqlQuery1.Parameters.Add(queryParameter3);
            customSqlQuery1.Parameters.Add(queryParameter4);
            customSqlQuery1.Parameters.Add(queryParameter5);
            customSqlQuery1.Parameters.Add(queryParameter6);
            customSqlQuery1.Parameters.Add(queryParameter7);
            customSqlQuery1.Parameters.Add(queryParameter8);
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable5,
            this.xrTable2,
            this.xrLabel1});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Sort", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("CostGroup", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 74.04169F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrTable5
            // 
            this.xrTable5.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 48.00002F);
            this.xrTable5.Name = "xrTable5";
            this.xrTable5.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
            this.xrTable5.SizeF = new System.Drawing.SizeF(796.0004F, 26.04167F);
            this.xrTable5.StylePriority.UseBorders = false;
            this.xrTable5.StylePriority.UsePadding = false;
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell27,
            this.xrTableCell28,
            this.xrTableCell29,
            this.xrTableCell30});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 1D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.StylePriority.UseFont = false;
            this.xrTableCell27.StylePriority.UseTextAlignment = false;
            this.xrTableCell27.Text = "Rate/Grand Total";
            this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell27.Weight = 4.3229165885797283D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.StylePriority.UseFont = false;
            this.xrTableCell28.StylePriority.UseTextAlignment = false;
            this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell28.TextFormatString = "{0:n2}";
            this.xrTableCell28.Weight = 1.1770843697441327D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.StylePriority.UseFont = false;
            this.xrTableCell29.StylePriority.UseTextAlignment = false;
            this.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell29.TextFormatString = "{0:n2}";
            this.xrTableCell29.Weight = 1.1579168198376475D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.StylePriority.UseFont = false;
            this.xrTableCell30.StylePriority.UseTextAlignment = false;
            this.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell30.TextFormatString = "{0:n2}";
            this.xrTableCell30.Weight = 1.3020856697173435D;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 23F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(796.0004F, 25F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UsePadding = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell9,
            this.xrTableCell15,
            this.xrTableCell16,
            this.xrTableCell25});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseFont = false;
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.Text = "Total";
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell9.Weight = 4.3229165885797283D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([COST])")});
            this.xrTableCell15.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.StylePriority.UseFont = false;
            this.xrTableCell15.StylePriority.UseTextAlignment = false;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrTableCell15.Summary = xrSummary1;
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell15.TextFormatString = "{0:n2}";
            this.xrTableCell15.Weight = 1.1770843697441327D;
            this.xrTableCell15.SummaryCalculated += new DevExpress.XtraReports.UI.TextFormatEventHandler(this.xrTableCell15_SummaryCalculated);
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([COSTCTY])")});
            this.xrTableCell16.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.StylePriority.UseFont = false;
            this.xrTableCell16.StylePriority.UseTextAlignment = false;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrTableCell16.Summary = xrSummary2;
            this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell16.TextFormatString = "{0:n2}";
            this.xrTableCell16.Weight = 1.1579168198376475D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([TOTAL_COST])")});
            this.xrTableCell25.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.StylePriority.UseFont = false;
            this.xrTableCell25.StylePriority.UseTextAlignment = false;
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrTableCell25.Summary = xrSummary3;
            this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell25.TextFormatString = "{0:n2}";
            this.xrTableCell25.Weight = 1.3020856697173435D;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CostGroupName]")});
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(796.0001F, 23F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UsePadding = false;
            this.xrLabel1.Text = "xrLabel1";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel5,
            this.xrTable3});
            this.ReportHeader.HeightF = 161.4583F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(796.0002F, 28F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "BÁO CÁO CHI PHÍ THEO PHÂN LOẠI CHI PHÍ";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 27.99999F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(796.0002F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50.99999F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(796.0002F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters].[pDateStr]")});
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 74.00001F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(796.0002F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "xrLabel2";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTable3
            // 
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 118.75F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(796.0002F, 42.70833F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UseFont = false;
            this.xrTable3.StylePriority.UsePadding = false;
            this.xrTable3.StylePriority.UseTextAlignment = false;
            this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrTableCell13,
            this.xrTableCell14,
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrTableCell19,
            this.xrTableCell23});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Text = "Month";
            this.xrTableCell10.Weight = 0.67708328247070315D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Text = "Year";
            this.xrTableCell11.Weight = 0.6770834350585937D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "Opt";
            this.xrTableCell12.Weight = 0.6875D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Text = "Aircraft";
            this.xrTableCell13.Weight = 0.71874984741210945D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Text = "Network";
            this.xrTableCell14.Weight = 0.8020834350585937D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Text = "Flight Type";
            this.xrTableCell17.Weight = 0.7604165649414063D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Multiline = true;
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.StylePriority.UseTextAlignment = false;
            this.xrTableCell18.Text = "Cost\r\n(Branch)";
            this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell18.Weight = 1.1770834350585933D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Multiline = true;
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.StylePriority.UseTextAlignment = false;
            this.xrTableCell19.Text = "Cost\r\n(KVP)";
            this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell19.Weight = 1.1579168701171878D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Multiline = true;
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.StylePriority.UseTextAlignment = false;
            this.xrTableCell23.Text = "Total\r\nCost";
            this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell23.Weight = 1.3020855712890627D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4});
            this.ReportFooter.HeightF = 26.04167F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrTable4
            // 
            this.xrTable4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable4.SizeF = new System.Drawing.SizeF(796.0004F, 25F);
            this.xrTable4.StylePriority.UseBorders = false;
            this.xrTable4.StylePriority.UsePadding = false;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell20,
            this.xrTableCell21,
            this.xrTableCell22,
            this.xrTableCell26});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.StylePriority.UseFont = false;
            this.xrTableCell20.StylePriority.UseTextAlignment = false;
            this.xrTableCell20.Text = "Grand Total";
            this.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell20.Weight = 4.3229165885797283D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([COST])")});
            this.xrTableCell21.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.StylePriority.UseFont = false;
            this.xrTableCell21.StylePriority.UseTextAlignment = false;
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell21.Summary = xrSummary4;
            this.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell21.TextFormatString = "{0:n2}";
            this.xrTableCell21.Weight = 1.1770843697441327D;
            this.xrTableCell21.SummaryCalculated += new DevExpress.XtraReports.UI.TextFormatEventHandler(this.xrTableCell21_SummaryCalculated);
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([COSTCTY])")});
            this.xrTableCell22.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.StylePriority.UseFont = false;
            this.xrTableCell22.StylePriority.UseTextAlignment = false;
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell22.Summary = xrSummary5;
            this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell22.TextFormatString = "{0:n2}";
            this.xrTableCell22.Weight = 1.1579168198376475D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([TOTAL_COST])")});
            this.xrTableCell26.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.StylePriority.UseFont = false;
            this.xrTableCell26.StylePriority.UseTextAlignment = false;
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell26.Summary = xrSummary6;
            this.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell26.TextFormatString = "{0:n2}";
            this.xrTableCell26.Weight = 1.3020856697173435D;
            // 
            // pDateStr
            // 
            this.pDateStr.Name = "pDateStr";
            this.pDateStr.Visible = false;
            // 
            // pCostType
            // 
            this.pCostType.Name = "pCostType";
            this.pCostType.ValueInfo = "ALLOCATED";
            this.pCostType.Visible = false;
            // 
            // ChitietChiphiTheoNhomChiphi
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.ReportHeader,
            this.ReportFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Margins = new System.Drawing.Printing.Margins(15, 16, 24, 100);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.pVersionID,
            this.pFromDate,
            this.pToDate,
            this.pAreaCode,
            this.pCarrier,
            this.pNetwork,
            this.pFltType,
            this.pDateStr,
            this.pCostType});
            this.Version = "17.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    protected override void OnBeforePrint(System.Drawing.Printing.PrintEventArgs e)
    {
        base.OnBeforePrint(e);

        this.xrLabel3.Text = "Area: " + this.pAreaCode.Value;

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

    public double ReportResult;
    public double GroupResult;

    private void xrTableCell15_SummaryCalculated(object sender, TextFormatEventArgs e)
    {
        GroupResult = Convert.ToDouble(e.Value);
    }

    private void xrTableCell21_SummaryCalculated(object sender, TextFormatEventArgs e)
    {
        ReportResult = Convert.ToDouble(e.Value);
    }
}
