using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using KTQTData;
using System.Linq;

/// <summary>
/// Summary description for ChiTietChiPhiThueQuay
/// </summary>
public class TongHopChiPhiThueQuay : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private ReportHeaderBand reportHeaderBand1;
    private XRLabel xrLabel1;
    private XRControlStyle Title;
    private XRControlStyle DetailCaption3;
    private XRControlStyle DetailData3;
    private XRControlStyle DetailData3_Odd;
    private XRControlStyle DetailCaptionBackground3;
    private XRControlStyle PageInfo;
    private DevExpress.XtraReports.Parameters.Parameter pVersionID;
    private DevExpress.XtraReports.Parameters.Parameter pAreaCode;
    private DevExpress.XtraReports.Parameters.Parameter pCarrier;
    private DevExpress.XtraReports.Parameters.Parameter pACID;
    private DevExpress.XtraReports.Parameters.Parameter pFromMonth;
    private DevExpress.XtraReports.Parameters.Parameter pToMonth;
    private XRPivotGrid xrPivotGrid1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCARRIER;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCounterTypeName;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldAmount;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldFls;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private XRLabel xrLabel2;
    private DevExpress.XtraReports.Parameters.Parameter pDateStr;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public TongHopChiPhiThueQuay()
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
            string resourceFileName = "TongHopChiPhiThueQuay.resx";
            System.Resources.ResourceManager resources = global::Resources.TongHopChiPhiThueQuay.ResourceManager;
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter6 = new DevExpress.DataAccess.Sql.QueryParameter();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.fieldCARRIER = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldFls = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldCounterTypeName = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldAmount = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailCaption3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData3_Odd = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailCaptionBackground3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.pVersionID = new DevExpress.XtraReports.Parameters.Parameter();
            this.pAreaCode = new DevExpress.XtraReports.Parameters.Parameter();
            this.pCarrier = new DevExpress.XtraReports.Parameters.Parameter();
            this.pACID = new DevExpress.XtraReports.Parameters.Parameter();
            this.pFromMonth = new DevExpress.XtraReports.Parameters.Parameter();
            this.pToMonth = new DevExpress.XtraReports.Parameters.Parameter();
            this.pDateStr = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
            this.Detail.HeightF = 68.33334F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPivotGrid1
            // 
            this.xrPivotGrid1.Appearance.Cell.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.xrPivotGrid1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.xrPivotGrid1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.xrPivotGrid1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.xrPivotGrid1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.xrPivotGrid1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.xrPivotGrid1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.xrPivotGrid1.Appearance.Lines.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.xrPivotGrid1.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.xrPivotGrid1.DataMember = "PrcRptCounterCost";
            this.xrPivotGrid1.DataSource = this.sqlDataSource1;
            this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.fieldCARRIER,
            this.fieldFls,
            this.fieldCounterTypeName,
            this.fieldAmount});
            this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPivotGrid1.Name = "xrPivotGrid1";
            this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
            this.xrPivotGrid1.OptionsView.ShowColumnHeaders = false;
            this.xrPivotGrid1.OptionsView.ShowColumnTotals = false;
            this.xrPivotGrid1.OptionsView.ShowDataHeaders = false;
            this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(647.7083F, 50F);
            this.xrPivotGrid1.FieldValueDisplayText += new System.EventHandler<DevExpress.XtraReports.UI.PivotGrid.PivotFieldDisplayTextEventArgs>(this.xrPivotGrid1_FieldValueDisplayText);
            this.xrPivotGrid1.PrintFieldValue += new System.EventHandler<DevExpress.XtraReports.UI.PivotGrid.CustomExportFieldValueEventArgs>(this.xrPivotGrid1_PrintFieldValue);
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "KTQT_Data_Connection";
            this.sqlDataSource1.ConnectionOptions.DbCommandTimeout = 0;
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "PrcRptCounterCost";
            queryParameter1.Name = "@pVersionID";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.pVersionID]", typeof(decimal));
            queryParameter2.Name = "@pAreaCode";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.pAreaCode]", typeof(string));
            queryParameter3.Name = "@pCarrier";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.pCarrier]", typeof(string));
            queryParameter4.Name = "@pACID";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("[Parameters.pACID]", typeof(string));
            queryParameter5.Name = "@pFromMonth";
            queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter5.Value = new DevExpress.DataAccess.Expression("[Parameters.pFromMonth]", typeof(int));
            queryParameter6.Name = "@pToMonth";
            queryParameter6.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter6.Value = new DevExpress.DataAccess.Expression("[Parameters.pToMonth]", typeof(int));
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.Parameters.Add(queryParameter4);
            storedProcQuery1.Parameters.Add(queryParameter5);
            storedProcQuery1.Parameters.Add(queryParameter6);
            storedProcQuery1.StoredProcName = "PrcRptCounterCostSum";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // fieldCARRIER
            // 
            this.fieldCARRIER.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.fieldCARRIER.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCARRIER.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.fieldCARRIER.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldCARRIER.AreaIndex = 0;
            this.fieldCARRIER.Caption = "Hãng";
            this.fieldCARRIER.FieldName = "CARRIER";
            this.fieldCARRIER.Name = "fieldCARRIER";
            this.fieldCARRIER.Options.ShowGrandTotal = false;
            this.fieldCARRIER.Options.ShowTotals = false;
            // 
            // fieldFls
            // 
            this.fieldFls.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.fieldFls.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldFls.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.fieldFls.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.fieldFls.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldFls.AreaIndex = 1;
            this.fieldFls.Caption = "Sản lượng CB";
            this.fieldFls.FieldName = "Fls";
            this.fieldFls.Name = "fieldFls";
            this.fieldFls.ValueFormat.FormatString = "{0:N0}";
            this.fieldFls.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // fieldCounterTypeName
            // 
            this.fieldCounterTypeName.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.fieldCounterTypeName.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.fieldCounterTypeName.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCounterTypeName.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldCounterTypeName.AreaIndex = 0;
            this.fieldCounterTypeName.FieldName = "CounterTypeName";
            this.fieldCounterTypeName.GrandTotalText = "Tổng cộng";
            this.fieldCounterTypeName.Name = "fieldCounterTypeName";
            this.fieldCounterTypeName.Width = 88;
            // 
            // fieldAmount
            // 
            this.fieldAmount.Appearance.Cell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.fieldAmount.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.fieldAmount.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.fieldAmount.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.fieldAmount.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.fieldAmount.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.fieldAmount.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.fieldAmount.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldAmount.AreaIndex = 0;
            this.fieldAmount.CellFormat.FormatString = "{0:N0}";
            this.fieldAmount.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldAmount.FieldName = "Amount";
            this.fieldAmount.GrandTotalCellFormat.FormatString = "{0:N0}";
            this.fieldAmount.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldAmount.GrandTotalText = "Tổng cộng";
            this.fieldAmount.Name = "fieldAmount";
            this.fieldAmount.TotalCellFormat.FormatString = "{0:N0}";
            this.fieldAmount.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldAmount.TotalValueFormat.FormatString = "{0:N0}";
            this.fieldAmount.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldAmount.ValueFormat.FormatString = "{0:N0}";
            this.fieldAmount.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 32.5F;
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
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
            this.reportHeaderBand1.HeightF = 112.0833F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 34.04168F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(1130F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabel4.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrLabel4_BeforePrint);
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 57.04168F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(1130F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabel3.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrLabel3_BeforePrint);
            // 
            // xrLabel2
            // 
            this.xrLabel2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters].[pDateStr]")});
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 80.04166F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(1130F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 5.000003F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(1130F, 26F);
            this.xrLabel1.StyleName = "Title";
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "BÁO CÁO TỔNG HỢP CHI PHÍ THUÊ QUẦY";
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Tahoma", 14F);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.Title.Name = "Title";
            // 
            // DetailCaption3
            // 
            this.DetailCaption3.BackColor = System.Drawing.Color.Transparent;
            this.DetailCaption3.BorderColor = System.Drawing.Color.Transparent;
            this.DetailCaption3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DetailCaption3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.DetailCaption3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.DetailCaption3.Name = "DetailCaption3";
            this.DetailCaption3.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailCaption3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData3
            // 
            this.DetailData3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.DetailData3.ForeColor = System.Drawing.Color.Black;
            this.DetailData3.Name = "DetailData3";
            this.DetailData3.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData3_Odd
            // 
            this.DetailData3_Odd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.DetailData3_Odd.BorderColor = System.Drawing.Color.Transparent;
            this.DetailData3_Odd.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DetailData3_Odd.BorderWidth = 1F;
            this.DetailData3_Odd.Font = new System.Drawing.Font("Tahoma", 8F);
            this.DetailData3_Odd.ForeColor = System.Drawing.Color.Black;
            this.DetailData3_Odd.Name = "DetailData3_Odd";
            this.DetailData3_Odd.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData3_Odd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailCaptionBackground3
            // 
            this.DetailCaptionBackground3.BackColor = System.Drawing.Color.Transparent;
            this.DetailCaptionBackground3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.DetailCaptionBackground3.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.DetailCaptionBackground3.BorderWidth = 2F;
            this.DetailCaptionBackground3.Name = "DetailCaptionBackground3";
            // 
            // PageInfo
            // 
            this.PageInfo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.PageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.PageInfo.Name = "PageInfo";
            this.PageInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // pVersionID
            // 
            this.pVersionID.Name = "pVersionID";
            this.pVersionID.Type = typeof(decimal);
            this.pVersionID.ValueInfo = "8";
            // 
            // pAreaCode
            // 
            this.pAreaCode.Name = "pAreaCode";
            this.pAreaCode.ValueInfo = "SGN";
            // 
            // pCarrier
            // 
            this.pCarrier.Name = "pCarrier";
            this.pCarrier.ValueInfo = "ALL";
            // 
            // pACID
            // 
            this.pACID.Name = "pACID";
            this.pACID.ValueInfo = "ALL";
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
            // TongHopChiPhiThueQuay
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.reportHeaderBand1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.Margins = new System.Drawing.Printing.Margins(20, 19, 32, 100);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4Rotated;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.pVersionID,
            this.pAreaCode,
            this.pCarrier,
            this.pACID,
            this.pFromMonth,
            this.pToMonth,
            this.pDateStr});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.DetailCaption3,
            this.DetailData3,
            this.DetailData3_Odd,
            this.DetailCaptionBackground3,
            this.PageInfo});
            this.Version = "17.2";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ChiTietChiPhiThueQuay_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private void ChiTietChiPhiThueQuay_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        this.xrPivotGrid1.BestFit(fieldCARRIER);
        this.xrPivotGrid1.BestFit(fieldFls);
        this.xrPivotGrid1.BestFit(fieldCounterTypeName);
        this.xrPivotGrid1.BestFit(fieldAmount);
    }

    private void xrPivotGrid1_FieldValueDisplayText(object sender, DevExpress.XtraReports.UI.PivotGrid.PivotFieldDisplayTextEventArgs e)
    {
        if (e.ValueType == DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal)
        {
            e.DisplayText = "Tổng cộng";
        }
        if (e.ValueType == DevExpress.XtraPivotGrid.PivotGridValueType.Total)
        {
           e.DisplayText = "Tổng " + e.DisplayText.Replace("Total", string.Empty);
        }
    }

    private void xrPivotGrid1_PrintFieldValue(object sender, DevExpress.XtraReports.UI.PivotGrid.CustomExportFieldValueEventArgs e)
    {
        if (e.ValueType == DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal || e.ValueType == DevExpress.XtraPivotGrid.PivotGridValueType.Total)
        {
            e.Appearance.Font = new Font(new FontFamily("Tahoma"), 10, FontStyle.Bold);
            e.Appearance.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
        }
    }

    protected override void OnBeforePrint(System.Drawing.Printing.PrintEventArgs e)
    {
        base.OnBeforePrint(e);

        this.pDateStr.Value = "Từ tháng " + this.pFromMonth.Value + " đến tháng " + this.pToMonth.Value;
    }

    private void xrLabel4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        this.xrLabel4.Text = "Chi nhánh: " + this.pAreaCode.Value;
    }

    private void xrLabel3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
      
        if (this.pVersionID.Value != null)
        {
            using (KTQTDataEntities entities = new KTQTDataEntities())
            {
                decimal versionID;
                if (!decimal.TryParse(this.pVersionID.Value.ToString(), out versionID))
                    return;
                var version = entities.Versions.SingleOrDefault(x => x.VersionID == versionID);

                 this.xrLabel3.Text =  version != null ? "Version sản lượng: " + version.VersionName : string.Empty;
            }
        }
    }
}
