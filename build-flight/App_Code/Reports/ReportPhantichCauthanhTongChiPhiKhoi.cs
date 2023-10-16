using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

/// <summary>
/// Summary description for ReportKehoachThuchiLVTM
/// </summary>
public class ReportPhantichCauthanhTongChiPhiKhoi : DevExpress.XtraReports.UI.XtraReport
{
    private TopMarginBand TopMargin;
    private BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLabel label1;
    private DetailBand Detail;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private XRControlStyle Title;
    private XRControlStyle DetailCaption1;
    private XRControlStyle DetailData1;
    private XRControlStyle DetailData3_Odd;
    private XRControlStyle PageInfo;
    private DevExpress.XtraReports.Parameters.Parameter pVersionID;
    private DevExpress.XtraReports.Parameters.Parameter pCompanyID;
    private DevExpress.XtraReports.Parameters.Parameter pFromMonth;
    private DevExpress.XtraReports.Parameters.Parameter pToMonth;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRPageInfo xrPageInfo1;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRCrossTab xrCrossTab1;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabHeaderCell1;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabDataCell1;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabHeaderCell2;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabHeaderCell3;
    private XRControlStyle crossTabGeneralStyle1;
    private XRControlStyle crossTabHeaderStyle1;
    private XRControlStyle crossTabDataStyle1;
    private XRControlStyle crossTabTotalStyle1;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabHeaderCell4;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabTotalCell1;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabHeaderCell5;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabHeaderCell6;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabHeaderCell7;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabTotalCell2;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabHeaderCell8;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabTotalCell3;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabTotalCell4;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabTotalCell5;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabHeaderCell9;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabHeaderCell10;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabHeaderCell11;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabTotalCell6;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabTotalCell7;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabHeaderCell12;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabHeaderCell13;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabHeaderCell14;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabTotalCell8;
    private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabTotalCell9;
    private DevExpress.XtraReports.Parameters.Parameter pReportName;
    private DevExpress.XtraReports.Parameters.Parameter pAreaCode;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ReportPhantichCauthanhTongChiPhiKhoi()
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
            string resourceFileName = "ReportPhantichCauthanhTongChiPhiKhoi.resx";
            System.Resources.ResourceManager resources = global::Resources.ReportPhantichCauthanhTongChiPhiKhoi.ResourceManager;
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraReports.UI.CrossTab.CrossTabColumnDefinition crossTabColumnDefinition1 = new DevExpress.XtraReports.UI.CrossTab.CrossTabColumnDefinition(30.83334F);
            DevExpress.XtraReports.UI.CrossTab.CrossTabColumnDefinition crossTabColumnDefinition2 = new DevExpress.XtraReports.UI.CrossTab.CrossTabColumnDefinition(2F);
            DevExpress.XtraReports.UI.CrossTab.CrossTabColumnDefinition crossTabColumnDefinition3 = new DevExpress.XtraReports.UI.CrossTab.CrossTabColumnDefinition(100F);
            DevExpress.XtraReports.UI.CrossTab.CrossTabColumnField crossTabColumnField1 = new DevExpress.XtraReports.UI.CrossTab.CrossTabColumnField();
            DevExpress.XtraReports.UI.CrossTab.CrossTabDataField crossTabDataField1 = new DevExpress.XtraReports.UI.CrossTab.CrossTabDataField();
            DevExpress.XtraReports.UI.CrossTab.CrossTabRowDefinition crossTabRowDefinition1 = new DevExpress.XtraReports.UI.CrossTab.CrossTabRowDefinition(25F);
            DevExpress.XtraReports.UI.CrossTab.CrossTabRowDefinition crossTabRowDefinition2 = new DevExpress.XtraReports.UI.CrossTab.CrossTabRowDefinition(25F);
            DevExpress.XtraReports.UI.CrossTab.CrossTabRowDefinition crossTabRowDefinition3 = new DevExpress.XtraReports.UI.CrossTab.CrossTabRowDefinition(25F);
            DevExpress.XtraReports.UI.CrossTab.CrossTabRowDefinition crossTabRowDefinition4 = new DevExpress.XtraReports.UI.CrossTab.CrossTabRowDefinition(25F);
            DevExpress.XtraReports.UI.CrossTab.CrossTabRowField crossTabRowField1 = new DevExpress.XtraReports.UI.CrossTab.CrossTabRowField();
            DevExpress.XtraReports.UI.CrossTab.CrossTabRowField crossTabRowField2 = new DevExpress.XtraReports.UI.CrossTab.CrossTabRowField();
            DevExpress.XtraReports.UI.CrossTab.CrossTabRowField crossTabRowField3 = new DevExpress.XtraReports.UI.CrossTab.CrossTabRowField();
            DevExpress.XtraReports.UI.CrossTab.CrossTabRowField crossTabRowField4 = new DevExpress.XtraReports.UI.CrossTab.CrossTabRowField();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter6 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter7 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery2 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter8 = new DevExpress.DataAccess.Sql.QueryParameter();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrCrossTab1 = new DevExpress.XtraReports.UI.XRCrossTab();
            this.crossTabHeaderCell1 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabDataCell1 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabHeaderCell2 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabHeaderCell3 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabHeaderCell4 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabTotalCell1 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabHeaderCell5 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabHeaderCell6 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabHeaderCell7 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabTotalCell2 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabHeaderCell8 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabTotalCell3 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabTotalCell4 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabTotalCell5 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabHeaderCell9 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabHeaderCell10 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabHeaderCell11 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabTotalCell6 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabTotalCell7 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabHeaderCell12 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabHeaderCell13 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabHeaderCell14 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabTotalCell8 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.crossTabTotalCell9 = new DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailCaption1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData3_Odd = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.pVersionID = new DevExpress.XtraReports.Parameters.Parameter();
            this.pCompanyID = new DevExpress.XtraReports.Parameters.Parameter();
            this.pFromMonth = new DevExpress.XtraReports.Parameters.Parameter();
            this.pToMonth = new DevExpress.XtraReports.Parameters.Parameter();
            this.crossTabGeneralStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.crossTabHeaderStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.crossTabDataStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.crossTabTotalStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.pReportName = new DevExpress.XtraReports.Parameters.Parameter();
            this.pAreaCode = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.xrCrossTab1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 30F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.BottomMargin.HeightF = 42.66673F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrCrossTab1,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.xrPageInfo1,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1,
            this.label1});
            this.ReportHeader.HeightF = 383.3334F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrCrossTab1
            // 
            this.xrCrossTab1.Cells.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.crossTabHeaderCell1,
            this.crossTabDataCell1,
            this.crossTabHeaderCell2,
            this.crossTabHeaderCell3,
            this.crossTabHeaderCell4,
            this.crossTabTotalCell1,
            this.crossTabHeaderCell5,
            this.crossTabHeaderCell6,
            this.crossTabHeaderCell7,
            this.crossTabTotalCell2,
            this.crossTabHeaderCell8,
            this.crossTabTotalCell3,
            this.crossTabTotalCell4,
            this.crossTabTotalCell5,
            this.crossTabHeaderCell9,
            this.crossTabHeaderCell10,
            this.crossTabHeaderCell11,
            this.crossTabTotalCell6,
            this.crossTabTotalCell7,
            this.crossTabHeaderCell12,
            this.crossTabHeaderCell13,
            this.crossTabHeaderCell14,
            this.crossTabTotalCell8,
            this.crossTabTotalCell9});
            crossTabColumnDefinition1.Visible = false;
            crossTabColumnDefinition2.Visible = false;
            crossTabColumnDefinition3.AutoWidthMode = DevExpress.XtraReports.UI.AutoSizeMode.GrowOnly;
            this.xrCrossTab1.ColumnDefinitions.AddRange(new DevExpress.XtraReports.UI.CrossTab.CrossTabColumnDefinition[] {
            crossTabColumnDefinition1,
            new DevExpress.XtraReports.UI.CrossTab.CrossTabColumnDefinition(52.50001F),
            new DevExpress.XtraReports.UI.CrossTab.CrossTabColumnDefinition(304.1667F),
            crossTabColumnDefinition2,
            new DevExpress.XtraReports.UI.CrossTab.CrossTabColumnDefinition(100F),
            crossTabColumnDefinition3});
            crossTabColumnField1.FieldName = "ShortName";
            this.xrCrossTab1.ColumnFields.AddRange(new DevExpress.XtraReports.UI.CrossTab.CrossTabColumnField[] {
            crossTabColumnField1});
            this.xrCrossTab1.DataAreaStyleName = "crossTabDataStyle1";
            crossTabDataField1.FieldName = "TotalAmount";
            this.xrCrossTab1.DataFields.AddRange(new DevExpress.XtraReports.UI.CrossTab.CrossTabDataField[] {
            crossTabDataField1});
            this.xrCrossTab1.DataMember = "ReportPhantichCauthanhTongChiPhiKhoi";
            this.xrCrossTab1.DataSource = this.sqlDataSource1;
            this.xrCrossTab1.GeneralStyleName = "crossTabGeneralStyle1";
            this.xrCrossTab1.HeaderAreaStyleName = "crossTabHeaderStyle1";
            this.xrCrossTab1.LayoutOptions.ColumnTotalsPosition = DevExpress.XtraReports.UI.CrossTab.TotalsPosition.BeforeData;
            this.xrCrossTab1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 233.3334F);
            this.xrCrossTab1.Name = "xrCrossTab1";
            crossTabRowDefinition1.Visible = false;
            crossTabRowDefinition2.Visible = false;
            crossTabRowDefinition3.Visible = false;
            crossTabRowDefinition4.Visible = false;
            this.xrCrossTab1.RowDefinitions.AddRange(new DevExpress.XtraReports.UI.CrossTab.CrossTabRowDefinition[] {
            new DevExpress.XtraReports.UI.CrossTab.CrossTabRowDefinition(25F),
            new DevExpress.XtraReports.UI.CrossTab.CrossTabRowDefinition(25F),
            crossTabRowDefinition1,
            crossTabRowDefinition2,
            crossTabRowDefinition3,
            crossTabRowDefinition4});
            crossTabRowField1.FieldName = "Seq";
            crossTabRowField2.FieldName = "Sorting";
            crossTabRowField3.FieldName = "Description";
            crossTabRowField4.FieldName = "Calculation";
            this.xrCrossTab1.RowFields.AddRange(new DevExpress.XtraReports.UI.CrossTab.CrossTabRowField[] {
            crossTabRowField1,
            crossTabRowField2,
            crossTabRowField3,
            crossTabRowField4});
            this.xrCrossTab1.SizeF = new System.Drawing.SizeF(589.5001F, 150F);
            this.xrCrossTab1.TotalAreaStyleName = "crossTabTotalStyle1";
            // 
            // crossTabHeaderCell1
            // 
            this.crossTabHeaderCell1.BackColor = System.Drawing.Color.Transparent;
            this.crossTabHeaderCell1.BorderColor = System.Drawing.Color.Black;
            this.crossTabHeaderCell1.ColumnIndex = 1;
            this.crossTabHeaderCell1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.crossTabHeaderCell1.Name = "crossTabHeaderCell1";
            this.crossTabHeaderCell1.RowIndex = 0;
            this.crossTabHeaderCell1.Text = "STT";
            this.crossTabHeaderCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // crossTabDataCell1
            // 
            this.crossTabDataCell1.BackColor = System.Drawing.Color.Transparent;
            this.crossTabDataCell1.BorderColor = System.Drawing.Color.Black;
            this.crossTabDataCell1.ColumnIndex = 5;
            this.crossTabDataCell1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.crossTabDataCell1.Name = "crossTabDataCell1";
            this.crossTabDataCell1.RowIndex = 1;
            this.crossTabDataCell1.TextFormatString = "{0:N0}";
            // 
            // crossTabHeaderCell2
            // 
            this.crossTabHeaderCell2.BackColor = System.Drawing.Color.Transparent;
            this.crossTabHeaderCell2.BorderColor = System.Drawing.Color.Black;
            this.crossTabHeaderCell2.ColumnIndex = 5;
            this.crossTabHeaderCell2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.crossTabHeaderCell2.Name = "crossTabHeaderCell2";
            this.crossTabHeaderCell2.RowIndex = 0;
            this.crossTabHeaderCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // crossTabHeaderCell3
            // 
            this.crossTabHeaderCell3.BackColor = System.Drawing.Color.Transparent;
            this.crossTabHeaderCell3.BorderColor = System.Drawing.Color.Black;
            this.crossTabHeaderCell3.ColumnIndex = 1;
            this.crossTabHeaderCell3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.crossTabHeaderCell3.Name = "crossTabHeaderCell3";
            this.crossTabHeaderCell3.RowIndex = 1;
            this.crossTabHeaderCell3.RowSpan = 2;
            // 
            // crossTabHeaderCell4
            // 
            this.crossTabHeaderCell4.BackColor = System.Drawing.Color.Transparent;
            this.crossTabHeaderCell4.BorderColor = System.Drawing.Color.Black;
            this.crossTabHeaderCell4.ColumnIndex = 0;
            this.crossTabHeaderCell4.ColumnSpan = 4;
            this.crossTabHeaderCell4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.crossTabHeaderCell4.Name = "crossTabHeaderCell4";
            this.crossTabHeaderCell4.RowIndex = 5;
            this.crossTabHeaderCell4.Text = "TỔNG CỘNG";
            // 
            // crossTabTotalCell1
            // 
            this.crossTabTotalCell1.ColumnIndex = 5;
            this.crossTabTotalCell1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.crossTabTotalCell1.Name = "crossTabTotalCell1";
            this.crossTabTotalCell1.RowIndex = 5;
            this.crossTabTotalCell1.TextFormatString = "{0:N0}";
            // 
            // crossTabHeaderCell5
            // 
            this.crossTabHeaderCell5.BackColor = System.Drawing.Color.Transparent;
            this.crossTabHeaderCell5.BorderColor = System.Drawing.Color.Black;
            this.crossTabHeaderCell5.ColumnIndex = 2;
            this.crossTabHeaderCell5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.crossTabHeaderCell5.Name = "crossTabHeaderCell5";
            this.crossTabHeaderCell5.RowIndex = 0;
            this.crossTabHeaderCell5.Text = "NỘI DUNG";
            this.crossTabHeaderCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // crossTabHeaderCell6
            // 
            this.crossTabHeaderCell6.BackColor = System.Drawing.Color.Transparent;
            this.crossTabHeaderCell6.BorderColor = System.Drawing.Color.Black;
            this.crossTabHeaderCell6.ColumnIndex = 2;
            this.crossTabHeaderCell6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.crossTabHeaderCell6.Name = "crossTabHeaderCell6";
            this.crossTabHeaderCell6.RowIndex = 1;
            // 
            // crossTabHeaderCell7
            // 
            this.crossTabHeaderCell7.ColumnIndex = 1;
            this.crossTabHeaderCell7.ColumnSpan = 3;
            this.crossTabHeaderCell7.Name = "crossTabHeaderCell7";
            this.crossTabHeaderCell7.RowIndex = 3;
            this.crossTabHeaderCell7.TextFormatString = "Total {0}";
            // 
            // crossTabTotalCell2
            // 
            this.crossTabTotalCell2.ColumnIndex = 5;
            this.crossTabTotalCell2.Name = "crossTabTotalCell2";
            this.crossTabTotalCell2.RowIndex = 3;
            // 
            // crossTabHeaderCell8
            // 
            this.crossTabHeaderCell8.BackColor = System.Drawing.Color.Transparent;
            this.crossTabHeaderCell8.BorderColor = System.Drawing.Color.Black;
            this.crossTabHeaderCell8.ColumnIndex = 4;
            this.crossTabHeaderCell8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.crossTabHeaderCell8.Name = "crossTabHeaderCell8";
            this.crossTabHeaderCell8.RowIndex = 0;
            this.crossTabHeaderCell8.Text = "TỔNG CỘNG";
            this.crossTabHeaderCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // crossTabTotalCell3
            // 
            this.crossTabTotalCell3.BackColor = System.Drawing.Color.Transparent;
            this.crossTabTotalCell3.BorderColor = System.Drawing.Color.Black;
            this.crossTabTotalCell3.ColumnIndex = 4;
            this.crossTabTotalCell3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.crossTabTotalCell3.Font = new System.Drawing.Font("Arial", 9.75F);
            this.crossTabTotalCell3.Name = "crossTabTotalCell3";
            this.crossTabTotalCell3.RowIndex = 1;
            this.crossTabTotalCell3.TextFormatString = "{0:N0}";
            // 
            // crossTabTotalCell4
            // 
            this.crossTabTotalCell4.ColumnIndex = 4;
            this.crossTabTotalCell4.Name = "crossTabTotalCell4";
            this.crossTabTotalCell4.RowIndex = 3;
            // 
            // crossTabTotalCell5
            // 
            this.crossTabTotalCell5.ColumnIndex = 4;
            this.crossTabTotalCell5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.crossTabTotalCell5.Name = "crossTabTotalCell5";
            this.crossTabTotalCell5.RowIndex = 5;
            this.crossTabTotalCell5.TextFormatString = "{0:N0}";
            // 
            // crossTabHeaderCell9
            // 
            this.crossTabHeaderCell9.BackColor = System.Drawing.Color.Transparent;
            this.crossTabHeaderCell9.BorderColor = System.Drawing.Color.Black;
            this.crossTabHeaderCell9.ColumnIndex = 0;
            this.crossTabHeaderCell9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.crossTabHeaderCell9.Name = "crossTabHeaderCell9";
            this.crossTabHeaderCell9.RowIndex = 0;
            this.crossTabHeaderCell9.Text = "Seq";
            this.crossTabHeaderCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // crossTabHeaderCell10
            // 
            this.crossTabHeaderCell10.ColumnIndex = 0;
            this.crossTabHeaderCell10.Name = "crossTabHeaderCell10";
            this.crossTabHeaderCell10.RowIndex = 1;
            this.crossTabHeaderCell10.RowSpan = 3;
            // 
            // crossTabHeaderCell11
            // 
            this.crossTabHeaderCell11.ColumnIndex = 0;
            this.crossTabHeaderCell11.ColumnSpan = 4;
            this.crossTabHeaderCell11.Name = "crossTabHeaderCell11";
            this.crossTabHeaderCell11.RowIndex = 4;
            this.crossTabHeaderCell11.TextFormatString = "Total {0}";
            // 
            // crossTabTotalCell6
            // 
            this.crossTabTotalCell6.ColumnIndex = 5;
            this.crossTabTotalCell6.Name = "crossTabTotalCell6";
            this.crossTabTotalCell6.RowIndex = 4;
            // 
            // crossTabTotalCell7
            // 
            this.crossTabTotalCell7.ColumnIndex = 4;
            this.crossTabTotalCell7.Name = "crossTabTotalCell7";
            this.crossTabTotalCell7.RowIndex = 4;
            // 
            // crossTabHeaderCell12
            // 
            this.crossTabHeaderCell12.ColumnIndex = 3;
            this.crossTabHeaderCell12.Name = "crossTabHeaderCell12";
            this.crossTabHeaderCell12.RowIndex = 0;
            this.crossTabHeaderCell12.Text = "Calculation";
            // 
            // crossTabHeaderCell13
            // 
            this.crossTabHeaderCell13.ColumnIndex = 3;
            this.crossTabHeaderCell13.Name = "crossTabHeaderCell13";
            this.crossTabHeaderCell13.RowIndex = 1;
            // 
            // crossTabHeaderCell14
            // 
            this.crossTabHeaderCell14.ColumnIndex = 2;
            this.crossTabHeaderCell14.ColumnSpan = 2;
            this.crossTabHeaderCell14.Name = "crossTabHeaderCell14";
            this.crossTabHeaderCell14.RowIndex = 2;
            this.crossTabHeaderCell14.TextFormatString = "Total {0}";
            // 
            // crossTabTotalCell8
            // 
            this.crossTabTotalCell8.ColumnIndex = 5;
            this.crossTabTotalCell8.Name = "crossTabTotalCell8";
            this.crossTabTotalCell8.RowIndex = 2;
            // 
            // crossTabTotalCell9
            // 
            this.crossTabTotalCell9.ColumnIndex = 4;
            this.crossTabTotalCell9.Name = "crossTabTotalCell9";
            this.crossTabTotalCell9.RowIndex = 2;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "KTQT_Data_Connection";
            this.sqlDataSource1.ConnectionOptions.CommandTimeout = 3600;
            this.sqlDataSource1.ConnectionOptions.DbCommandTimeout = 3600;
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "ReportPhantichCauthanhTongChiPhiKhoi";
            queryParameter1.Name = "@pVersionID";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("?pVersionID", typeof(decimal));
            queryParameter2.Name = "@pCompanyID";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("?pCompanyID", typeof(int));
            queryParameter3.Name = "@pFromMonth";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("?pFromMonth", typeof(int));
            queryParameter4.Name = "@pToMonth";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("?pToMonth", typeof(int));
            queryParameter5.Name = "@pReportName";
            queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter5.Value = new DevExpress.DataAccess.Expression("?pReportName", typeof(string));
            queryParameter6.Name = "@pAreaCode";
            queryParameter6.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter6.Value = new DevExpress.DataAccess.Expression("?pAreaCode", typeof(string));
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.Parameters.Add(queryParameter4);
            storedProcQuery1.Parameters.Add(queryParameter5);
            storedProcQuery1.Parameters.Add(queryParameter6);
            storedProcQuery1.StoredProcName = "ReportPhantichCauthanhTongChiPhiKhoi";
            customSqlQuery1.Name = "Query";
            queryParameter7.Name = "pVersionID";
            queryParameter7.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter7.Value = new DevExpress.DataAccess.Expression("?pVersionID", typeof(long));
            customSqlQuery1.Parameters.Add(queryParameter7);
            customSqlQuery1.Sql = "SELECT v.VersionName, v.VersionYear\r\n\tFROM [dbo].[Version] v  \r\n\tWHERE v.VersionI" +
    "D = @pVersionID";
            customSqlQuery2.Name = "Query_1";
            queryParameter8.Name = "pCompanyID";
            queryParameter8.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter8.Value = new DevExpress.DataAccess.Expression("?pCompanyID", typeof(int));
            customSqlQuery2.Parameters.Add(queryParameter8);
            customSqlQuery2.Sql = "select NameV From DecCompanies Where CompanyID = @pCompanyID";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1,
            customSqlQuery1,
            customSqlQuery2});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 23.00001F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(589.5001F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "Lĩnh vực: Thương mại";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(589.5001F, 23F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.Text = "TỔNG CÔNG TY HÀNG KHÔNG VIỆT NAM";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 99.19434F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(589.5001F, 22.99999F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseForeColor = false;
            this.xrLabel5.StylePriority.UsePadding = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Version: [Query.VersionName]";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.xrPageInfo1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 169.361F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(589.5001F, 23.00002F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseForeColor = false;
            this.xrPageInfo1.StylePriority.UsePadding = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrPageInfo1.TextFormatString = "Ngày giờ chạy báo cáo: {0:dd/MM/yyyy HH:mm}";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 192.361F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(387.5001F, 22.99998F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "ĐVT: 1.000.000 VND";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.xrLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 146.361F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(589.5001F, 22.99998F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseForeColor = false;
            this.xrLabel2.StylePriority.UsePadding = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Từ tháng [?pFromMonth] đến tháng [?pToMonth]/[Query.VersionYear]";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 123.361F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(589.5001F, 22.99999F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseForeColor = false;
            this.xrLabel1.StylePriority.UsePadding = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Đơn vị: [Query_1.NameV]";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50.00003F);
            this.label1.Name = "label1";
            this.label1.SizeF = new System.Drawing.SizeF(589.5001F, 49.19431F);
            this.label1.StyleName = "Title";
            this.label1.StylePriority.UseFont = false;
            this.label1.StylePriority.UseTextAlignment = false;
            this.label1.Text = "PHÂN TÍCH CẤU THÀNH TỔNG CHI PHÍ KHỐI THEO MỤC CHI";
            this.label1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Detail
            // 
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Arial", 14.25F);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.Title.Name = "Title";
            this.Title.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            // 
            // DetailCaption1
            // 
            this.DetailCaption1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.DetailCaption1.BorderColor = System.Drawing.Color.White;
            this.DetailCaption1.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.DetailCaption1.BorderWidth = 2F;
            this.DetailCaption1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.DetailCaption1.ForeColor = System.Drawing.Color.White;
            this.DetailCaption1.Name = "DetailCaption1";
            this.DetailCaption1.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailCaption1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData1
            // 
            this.DetailData1.BorderColor = System.Drawing.Color.Transparent;
            this.DetailData1.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.DetailData1.BorderWidth = 2F;
            this.DetailData1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.DetailData1.ForeColor = System.Drawing.Color.Black;
            this.DetailData1.Name = "DetailData1";
            this.DetailData1.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData3_Odd
            // 
            this.DetailData3_Odd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.DetailData3_Odd.BorderColor = System.Drawing.Color.Transparent;
            this.DetailData3_Odd.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DetailData3_Odd.BorderWidth = 1F;
            this.DetailData3_Odd.Font = new System.Drawing.Font("Arial", 8.25F);
            this.DetailData3_Odd.ForeColor = System.Drawing.Color.Black;
            this.DetailData3_Odd.Name = "DetailData3_Odd";
            this.DetailData3_Odd.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData3_Odd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageInfo
            // 
            this.PageInfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.PageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.PageInfo.Name = "PageInfo";
            this.PageInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            // 
            // pVersionID
            // 
            this.pVersionID.Name = "pVersionID";
            this.pVersionID.Type = typeof(decimal);
            this.pVersionID.ValueInfo = "2245";
            // 
            // pCompanyID
            // 
            this.pCompanyID.Name = "pCompanyID";
            this.pCompanyID.Type = typeof(int);
            this.pCompanyID.ValueInfo = "12";
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
            // crossTabGeneralStyle1
            // 
            this.crossTabGeneralStyle1.BackColor = System.Drawing.Color.White;
            this.crossTabGeneralStyle1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.crossTabGeneralStyle1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.crossTabGeneralStyle1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.crossTabGeneralStyle1.ForeColor = System.Drawing.Color.Black;
            this.crossTabGeneralStyle1.Name = "crossTabGeneralStyle1";
            this.crossTabGeneralStyle1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // crossTabHeaderStyle1
            // 
            this.crossTabHeaderStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.crossTabHeaderStyle1.Name = "crossTabHeaderStyle1";
            this.crossTabHeaderStyle1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // crossTabDataStyle1
            // 
            this.crossTabDataStyle1.Name = "crossTabDataStyle1";
            this.crossTabDataStyle1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // crossTabTotalStyle1
            // 
            this.crossTabTotalStyle1.Name = "crossTabTotalStyle1";
            this.crossTabTotalStyle1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // pReportName
            // 
            this.pReportName.Description = "ReportName";
            this.pReportName.Name = "pReportName";
            this.pReportName.ValueInfo = "ReportPhantichCauthanhTongChiPhiKhoi";
            // 
            // pAreaCode
            // 
            this.pAreaCode.Description = "Group";
            this.pAreaCode.Name = "pAreaCode";
            this.pAreaCode.ValueInfo = "ALL";
            // 
            // ReportPhantichCauthanhTongChiPhiKhoi
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.Detail});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "ReportPhantichCauthanhTongChiPhiKhoi";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(0, 20, 30, 43);
            this.PageHeight = 1654;
            this.PageWidth = 4120;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.pVersionID,
            this.pCompanyID,
            this.pFromMonth,
            this.pToMonth,
            this.pReportName,
            this.pAreaCode});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.DetailCaption1,
            this.DetailData1,
            this.DetailData3_Odd,
            this.PageInfo,
            this.crossTabGeneralStyle1,
            this.crossTabHeaderStyle1,
            this.crossTabDataStyle1,
            this.crossTabTotalStyle1});
            this.Version = "20.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrCrossTab1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
