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
public class SanLuongHHChung : DevExpress.XtraReports.UI.XtraReport
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
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field8;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field7;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field6;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field5;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field4;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field3;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field2;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField xrPivotGridField1;
    private XRPivotGrid xrPivotGrid1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldFLIGHTTYPE2;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldOPT1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldNW1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldAreaCode1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldFLS1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldTITLE1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldSEQ;
    private ReportHeaderBand ReportHeader;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

    public SanLuongHHChung()
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
	protected override void Dispose(bool disposing) {
		if (disposing && (components != null)) {
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
            string resourceFileName = "SanLuongHHChung.resx";
            System.Resources.ResourceManager resources = global::Resources.SanLuongHHChung.ResourceManager;
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.XtraReports.Parameters.StaticListLookUpSettings staticListLookUpSettings1 = new DevExpress.XtraReports.Parameters.StaticListLookUpSettings();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.fieldOPT1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldFLIGHTTYPE2 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldNW1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldSEQ = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldTITLE1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldAreaCode1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldFLS1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.P_AREA_CODE = new DevExpress.XtraReports.Parameters.Parameter();
            this.P_FROM_DATE = new DevExpress.XtraReports.Parameters.Parameter();
            this.P_TO_DATE = new DevExpress.XtraReports.Parameters.Parameter();
            this.P_DATE_STR = new DevExpress.XtraReports.Parameters.Parameter();
            this.field8 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.field7 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.field6 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.field5 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.field4 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.field3 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.field2 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.field1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.field = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
            this.Detail.HeightF = 97.91666F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPivotGrid1
            // 
            this.xrPivotGrid1.Appearance.Cell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.Cell.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.xrPivotGrid1.Appearance.Cell.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.xrPivotGrid1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrPivotGrid1.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrPivotGrid1.Appearance.FieldHeader.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.xrPivotGrid1.Appearance.FieldHeader.WordWrap = true;
            this.xrPivotGrid1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrPivotGrid1.Appearance.FieldValue.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.xrPivotGrid1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrPivotGrid1.Appearance.FieldValueTotal.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrPivotGrid1.Appearance.FieldValueTotal.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.xrPivotGrid1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.Lines.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.DataMember = "Query";
            this.xrPivotGrid1.DataSource = this.sqlDataSource1;
            this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.fieldOPT1,
            this.fieldFLIGHTTYPE2,
            this.fieldNW1,
            this.fieldSEQ,
            this.fieldTITLE1,
            this.fieldAreaCode1,
            this.fieldFLS1});
            this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPivotGrid1.Name = "xrPivotGrid1";
            this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
            this.xrPivotGrid1.OptionsView.ShowColumnGrandTotalHeader = false;
            this.xrPivotGrid1.OptionsView.ShowColumnGrandTotals = false;
            this.xrPivotGrid1.OptionsView.ShowColumnHeaders = false;
            this.xrPivotGrid1.OptionsView.ShowColumnTotals = false;
            this.xrPivotGrid1.OptionsView.ShowDataHeaders = false;
            this.xrPivotGrid1.OptionsView.ShowFilterHeaders = false;
            this.xrPivotGrid1.OptionsView.ShowRowGrandTotalHeader = false;
            this.xrPivotGrid1.OptionsView.ShowRowTotals = false;
            this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(512.9167F, 97.91666F);
            this.xrPivotGrid1.FieldValueDisplayText += new System.EventHandler<DevExpress.XtraReports.UI.PivotGrid.PivotFieldDisplayTextEventArgs>(this.xrPivotGrid1_FieldValueDisplayText);
            this.xrPivotGrid1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrPivotGrid1_BeforePrint);
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
            // fieldOPT1
            // 
            this.fieldOPT1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldOPT1.AreaIndex = 0;
            this.fieldOPT1.Caption = "Hãng hàng không";
            this.fieldOPT1.FieldName = "OPT";
            this.fieldOPT1.Name = "fieldOPT1";
            this.fieldOPT1.Width = 70;
            // 
            // fieldFLIGHTTYPE2
            // 
            this.fieldFLIGHTTYPE2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldFLIGHTTYPE2.AreaIndex = 1;
            this.fieldFLIGHTTYPE2.Caption = "Loại (đi/đến)";
            this.fieldFLIGHTTYPE2.FieldName = "FLIGHT_TYPE";
            this.fieldFLIGHTTYPE2.Name = "fieldFLIGHTTYPE2";
            this.fieldFLIGHTTYPE2.Width = 70;
            // 
            // fieldNW1
            // 
            this.fieldNW1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldNW1.AreaIndex = 2;
            this.fieldNW1.Caption = "QT/QN";
            this.fieldNW1.FieldName = "NW";
            this.fieldNW1.Name = "fieldNW1";
            this.fieldNW1.Width = 50;
            // 
            // fieldSEQ
            // 
            this.fieldSEQ.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldSEQ.AreaIndex = 0;
            this.fieldSEQ.FieldName = "SEQ";
            this.fieldSEQ.Name = "fieldSEQ";
            this.fieldSEQ.Visible = false;
            // 
            // fieldTITLE1
            // 
            this.fieldTITLE1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldTITLE1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldTITLE1.AreaIndex = 0;
            this.fieldTITLE1.Caption = "Nhóm";
            this.fieldTITLE1.FieldName = "TITLE";
            this.fieldTITLE1.Name = "fieldTITLE1";
            // 
            // fieldAreaCode1
            // 
            this.fieldAreaCode1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldAreaCode1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldAreaCode1.AreaIndex = 1;
            this.fieldAreaCode1.Caption = "Sân bay";
            this.fieldAreaCode1.FieldName = "AreaCode";
            this.fieldAreaCode1.Name = "fieldAreaCode1";
            this.fieldAreaCode1.Width = 70;
            // 
            // fieldFLS1
            // 
            this.fieldFLS1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldFLS1.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldFLS1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldFLS1.AreaIndex = 0;
            this.fieldFLS1.Caption = "Sản lượng";
            this.fieldFLS1.CellFormat.FormatString = "{0:#,#}";
            this.fieldFLS1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldFLS1.FieldName = "FLS";
            this.fieldFLS1.GrandTotalCellFormat.FormatString = "{0:#,#}";
            this.fieldFLS1.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldFLS1.Name = "fieldFLS1";
            this.fieldFLS1.TotalCellFormat.FormatString = "{0:#,#}";
            this.fieldFLS1.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldFLS1.TotalValueFormat.FormatString = "{0:#,#}";
            this.fieldFLS1.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldFLS1.ValueFormat.FormatString = "{0:#,#}";
            this.fieldFLS1.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldFLS1.Width = 70;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 22.9167F;
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
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(199.1386F, 23.87498F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(601.6114F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "SẢN LƯỢNG HÀNG HÓA CHUNG (CHI TIẾT THEO CHI NHÁNH)";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.BottomMargin.Visible = false;
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
            // 
            // P_FROM_DATE
            // 
            this.P_FROM_DATE.Description = "From Date";
            this.P_FROM_DATE.Name = "P_FROM_DATE";
            this.P_FROM_DATE.Type = typeof(System.DateTime);
            this.P_FROM_DATE.ValueInfo = "2018-06-01";
            // 
            // P_TO_DATE
            // 
            this.P_TO_DATE.Description = "To Date";
            this.P_TO_DATE.Name = "P_TO_DATE";
            this.P_TO_DATE.Type = typeof(System.DateTime);
            this.P_TO_DATE.ValueInfo = "2018-06-26";
            // 
            // P_DATE_STR
            // 
            this.P_DATE_STR.Name = "P_DATE_STR";
            this.P_DATE_STR.Visible = false;
            // 
            // field8
            // 
            this.field8.AreaIndex = 8;
            this.field8.Name = "field8";
            // 
            // field7
            // 
            this.field7.AreaIndex = 7;
            this.field7.Name = "field7";
            // 
            // field6
            // 
            this.field6.AreaIndex = 6;
            this.field6.Name = "field6";
            // 
            // field5
            // 
            this.field5.AreaIndex = 5;
            this.field5.Name = "field5";
            // 
            // field4
            // 
            this.field4.AreaIndex = 4;
            this.field4.Name = "field4";
            // 
            // field3
            // 
            this.field3.AreaIndex = 3;
            this.field3.Name = "field3";
            // 
            // field2
            // 
            this.field2.AreaIndex = 2;
            this.field2.Name = "field2";
            // 
            // field1
            // 
            this.field1.AreaIndex = 1;
            this.field1.Name = "field1";
            // 
            // field
            // 
            this.field.AreaIndex = 0;
            this.field.Name = "field";
            // 
            // xrPivotGridField1
            // 
            this.xrPivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.xrPivotGridField1.AreaIndex = 3;
            this.xrPivotGridField1.Name = "xrPivotGridField1";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel1});
            this.ReportHeader.HeightF = 88.54166F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // SanLuongHHChung
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(32, 36, 23, 100);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.P_AREA_CODE,
            this.P_FROM_DATE,
            this.P_TO_DATE,
            this.P_DATE_STR});
            this.Version = "17.2";
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

    private void xrPivotGrid1_FieldValueDisplayText(object sender, DevExpress.XtraReports.UI.PivotGrid.PivotFieldDisplayTextEventArgs e)
    {
        if (e.ValueType == DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal)
        {
            if (!e.IsColumn && e.DataField.Name == "FLS")
                e.DisplayText = "Tổng";
            if (!e.IsColumn && e.DataField.Name == "TITLE")
                e.DisplayText = "Tổng";
            if (!e.IsColumn && e.DataField.Name == "AreaCode")
                e.DisplayText = "Tổng";
        }
    }

    private void xrPivotGrid1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        this.xrPivotGrid1.BestFit(fieldOPT1);
        this.xrPivotGrid1.BestFit(fieldFLIGHTTYPE2);
        this.xrPivotGrid1.BestFit(fieldNW1);
        this.xrPivotGrid1.BestFit(fieldTITLE1);
        this.xrPivotGrid1.BestFit(fieldAreaCode1);
        this.xrPivotGrid1.BestFit(fieldFLS1);
    }

}
