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
public class SanLuongChuyenBay : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private DevExpress.XtraReports.Parameters.Parameter P_AREA_CODE;
    private DevExpress.XtraReports.Parameters.Parameter P_FROM_DATE;
    private DevExpress.XtraReports.Parameters.Parameter P_TO_DATE;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private XRLabel xrLabel1;
    private DevExpress.XtraReports.Parameters.Parameter P_DATE_STR;
    private XRLabel xrLabel2;
    private XRPivotGrid xrPivotGrid1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCARRIER;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldNW;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldAIRCRAFT;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldAREACODE;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldFLS;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldOPT;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldSL;
    private ReportHeaderBand ReportHeader;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public SanLuongChuyenBay()
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
            string resourceFileName = "SanLuongChuyenBay.resx";
            System.Resources.ResourceManager resources = global::Resources.SanLuongChuyenBay.ResourceManager;
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.XtraReports.Parameters.StaticListLookUpSettings staticListLookUpSettings1 = new DevExpress.XtraReports.Parameters.StaticListLookUpSettings();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.fieldCARRIER = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldOPT = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldNW = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldAIRCRAFT = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldSL = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldAREACODE = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldFLS = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.P_AREA_CODE = new DevExpress.XtraReports.Parameters.Parameter();
            this.P_FROM_DATE = new DevExpress.XtraReports.Parameters.Parameter();
            this.P_TO_DATE = new DevExpress.XtraReports.Parameters.Parameter();
            this.P_DATE_STR = new DevExpress.XtraReports.Parameters.Parameter();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
            this.Detail.HeightF = 96.87497F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPivotGrid1
            // 
            this.xrPivotGrid1.Appearance.Cell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrPivotGrid1.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrPivotGrid1.Appearance.FieldHeader.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.xrPivotGrid1.Appearance.FieldHeader.WordWrap = true;
            this.xrPivotGrid1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrPivotGrid1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrPivotGrid1.Appearance.Lines.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrPivotGrid1.DataMember = "Query";
            this.xrPivotGrid1.DataSource = this.sqlDataSource1;
            this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.fieldCARRIER,
            this.fieldOPT,
            this.fieldNW,
            this.fieldAIRCRAFT,
            this.fieldSL,
            this.fieldAREACODE,
            this.fieldFLS});
            this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPivotGrid1.Name = "xrPivotGrid1";
            this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
            this.xrPivotGrid1.OptionsView.ShowColumnHeaders = false;
            this.xrPivotGrid1.OptionsView.ShowDataHeaders = false;
            this.xrPivotGrid1.OptionsView.ShowRowTotals = false;
            this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(419.375F, 96.87497F);
            this.xrPivotGrid1.FieldValueDisplayText += new System.EventHandler<DevExpress.XtraReports.UI.PivotGrid.PivotFieldDisplayTextEventArgs>(this.xrPivotGrid1_FieldValueDisplayText);
            this.xrPivotGrid1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrPivotGrid1_BeforePrint);
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "STG_KTQT_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            queryParameter1.Name = "P_FROM_DATE";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.P_FROM_DATE]", typeof(System.DateTime));
            queryParameter2.Name = "P_TO_DATE";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.P_TO_DATE]", typeof(System.DateTime));
            customSqlQuery1.Parameters.Add(queryParameter1);
            customSqlQuery1.Parameters.Add(queryParameter2);
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // fieldCARRIER
            // 
            this.fieldCARRIER.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldCARRIER.AreaIndex = 0;
            this.fieldCARRIER.Caption = "STT";
            this.fieldCARRIER.FieldName = "CARRIER";
            this.fieldCARRIER.Name = "fieldCARRIER";
            // 
            // fieldOPT
            // 
            this.fieldOPT.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldOPT.AreaIndex = 2;
            this.fieldOPT.Caption = "Hãng";
            this.fieldOPT.FieldName = "OPT";
            this.fieldOPT.Name = "fieldOPT";
            // 
            // fieldNW
            // 
            this.fieldNW.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldNW.AreaIndex = 1;
            this.fieldNW.Caption = "QT/QN";
            this.fieldNW.FieldName = "NW";
            this.fieldNW.Name = "fieldNW";
            // 
            // fieldAIRCRAFT
            // 
            this.fieldAIRCRAFT.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldAIRCRAFT.AreaIndex = 3;
            this.fieldAIRCRAFT.Caption = "Loại tàu bay";
            this.fieldAIRCRAFT.FieldName = "AIRCRAFT";
            this.fieldAIRCRAFT.Name = "fieldAIRCRAFT";
            // 
            // fieldSL
            // 
            this.fieldSL.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldSL.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldSL.Appearance.FieldHeader.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fieldSL.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldSL.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldSL.Appearance.FieldValue.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fieldSL.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldSL.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldSL.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldSL.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldSL.AreaIndex = 0;
            this.fieldSL.Caption = "Sản lượng";
            this.fieldSL.FieldName = "SL";
            this.fieldSL.Name = "fieldSL";
            // 
            // fieldAREACODE
            // 
            this.fieldAREACODE.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldAREACODE.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldAREACODE.Appearance.FieldHeader.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fieldAREACODE.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldAREACODE.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldAREACODE.Appearance.FieldValue.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fieldAREACODE.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldAREACODE.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldAREACODE.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldAREACODE.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldAREACODE.AreaIndex = 1;
            this.fieldAREACODE.Caption = "Sân bay";
            this.fieldAREACODE.FieldName = "AREACODE";
            this.fieldAREACODE.Name = "fieldAREACODE";
            // 
            // fieldFLS
            // 
            this.fieldFLS.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldFLS.AreaIndex = 0;
            this.fieldFLS.Caption = "Fls";
            this.fieldFLS.CellFormat.FormatString = "{0:#,#}";
            this.fieldFLS.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldFLS.FieldName = "FLS";
            this.fieldFLS.GrandTotalCellFormat.FormatString = "{0:#,#}";
            this.fieldFLS.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldFLS.Name = "fieldFLS";
            this.fieldFLS.TotalCellFormat.FormatString = "{0:#,#}";
            this.fieldFLS.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldFLS.TotalValueFormat.FormatString = "{0:#,#}";
            this.fieldFLS.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldFLS.ValueFormat.FormatString = "{0:#,#}";
            this.fieldFLS.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 10.41667F;
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
            this.xrLabel2.SizeF = new System.Drawing.SizeF(388.0697F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(199.1386F, 23.87498F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(388.0697F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "SẢN LƯỢNG CHUYẾN BAY";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            // P_DATE_STR
            // 
            this.P_DATE_STR.Name = "P_DATE_STR";
            this.P_DATE_STR.Visible = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel1});
            this.ReportHeader.HeightF = 92.70834F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // SanLuongChuyenBay
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.Margins = new System.Drawing.Printing.Margins(32, 36, 10, 100);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.P_AREA_CODE,
            this.P_FROM_DATE,
            this.P_TO_DATE,
            this.P_DATE_STR});
            this.Version = "17.2";
            this.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart;
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

    private void xrPivotGrid1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        this.xrPivotGrid1.BestFit(fieldCARRIER);
        this.xrPivotGrid1.BestFit(fieldOPT);
        this.xrPivotGrid1.BestFit(fieldAREACODE);
        this.xrPivotGrid1.BestFit(fieldAIRCRAFT);
        this.xrPivotGrid1.BestFit(fieldNW);
        this.xrPivotGrid1.BestFit(fieldFLS);
        this.xrPivotGrid1.BestFit(fieldSL);
    }

    private void xrPivotGrid1_FieldValueDisplayText(object sender, DevExpress.XtraReports.UI.PivotGrid.PivotFieldDisplayTextEventArgs e)
    {
        if (e.ValueType == DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal)
        {
            // if (!e.IsColumn && e.DataField.Name == "FLS")
            e.DisplayText = "Tổng";
        }
        if (e.ValueType == DevExpress.XtraPivotGrid.PivotGridValueType.Total)
        {
            e.DisplayText = "Tổng";
        }
    }


}
