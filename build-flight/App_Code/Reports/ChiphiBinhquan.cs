using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ChiphiBinhquan
/// </summary>
public class ChiphiBinhquan : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private ReportHeaderBand ReportHeader;
    private XRPivotGrid xrPivotGrid1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldSubaccountID1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldDescription1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCARRIER1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldACGroup1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldNetwork1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCost1;
    private XRLabel xrLabel1;
    private DevExpress.XtraReports.Parameters.Parameter pAreaCode;
    private DevExpress.XtraReports.Parameters.Parameter pFromDate;
    private DevExpress.XtraReports.Parameters.Parameter pToDate;
    private DevExpress.XtraReports.Parameters.Parameter pDateStr;
    private XRLabel xrLabel2;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldSorting;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public ChiphiBinhquan()
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
            string resourceFileName = "ChiphiBinhquan.resx";
            System.Resources.ResourceManager resources = global::Resources.ChiphiBinhquan.ResourceManager;
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
            this.fieldSubaccountID1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldDescription1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldCARRIER1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldACGroup1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldNetwork1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldCost1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pAreaCode = new DevExpress.XtraReports.Parameters.Parameter();
            this.pFromDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.pToDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.pDateStr = new DevExpress.XtraReports.Parameters.Parameter();
            this.fieldSorting = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Expanded = false;
            this.Detail.HeightF = 100F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel1});
            this.TopMargin.HeightF = 105.8333F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters].[pDateStr]")});
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 72.33332F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(800.9999F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 39.33333F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(800.9999F, 32.99999F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Chi phí bình quân của 1 loại máy bay";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 45F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "KTQT_Data_Connection";
            this.sqlDataSource1.ConnectionOptions.CommandTimeout = 3600;
            this.sqlDataSource1.ConnectionOptions.DbCommandTimeout = 3600;
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            queryParameter1.Name = "pAreaCode";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.pAreaCode]", typeof(string));
            queryParameter2.Name = "pFromDate";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.pFromDate]", typeof(System.DateTime));
            queryParameter3.Name = "pToDate";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.pToDate]", typeof(System.DateTime));
            customSqlQuery1.Parameters.Add(queryParameter1);
            customSqlQuery1.Parameters.Add(queryParameter2);
            customSqlQuery1.Parameters.Add(queryParameter3);
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
            this.ReportHeader.HeightF = 744.1667F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrPivotGrid1
            // 
            this.xrPivotGrid1.Appearance.Cell.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.xrPivotGrid1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Tahoma", 6.6F);
            this.xrPivotGrid1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 6.6F);
            this.xrPivotGrid1.Appearance.FieldValue.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.xrPivotGrid1.Appearance.FieldValue.WordWrap = true;
            this.xrPivotGrid1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 6.6F);
            this.xrPivotGrid1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 6.6F);
            this.xrPivotGrid1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 6.6F);
            this.xrPivotGrid1.Appearance.Lines.Font = new System.Drawing.Font("Tahoma", 6.6F);
            this.xrPivotGrid1.Appearance.Lines.WordWrap = true;
            this.xrPivotGrid1.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 6.6F);
            this.xrPivotGrid1.DataMember = "Query";
            this.xrPivotGrid1.DataSource = this.sqlDataSource1;
            this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.fieldSorting,
            this.fieldSubaccountID1,
            this.fieldDescription1,
            this.fieldCARRIER1,
            this.fieldACGroup1,
            this.fieldNetwork1,
            this.fieldCost1});
            this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPivotGrid1.Name = "xrPivotGrid1";
            this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
            this.xrPivotGrid1.OptionsView.ShowColumnGrandTotals = false;
            this.xrPivotGrid1.OptionsView.ShowColumnHeaders = false;
            this.xrPivotGrid1.OptionsView.ShowColumnTotals = false;
            this.xrPivotGrid1.OptionsView.ShowDataHeaders = false;
            this.xrPivotGrid1.OptionsView.ShowFilterHeaders = false;
            this.xrPivotGrid1.OptionsView.ShowRowGrandTotals = false;
            this.xrPivotGrid1.OptionsView.ShowRowTotals = false;
            this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(800.9999F, 744.1667F);
            this.xrPivotGrid1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrPivotGrid1_BeforePrint);
            // 
            // fieldSubaccountID1
            // 
            this.fieldSubaccountID1.AreaIndex = 0;
            this.fieldSubaccountID1.FieldName = "SubaccountID";
            this.fieldSubaccountID1.Name = "fieldSubaccountID1";
            // 
            // fieldDescription1
            // 
            this.fieldDescription1.Appearance.FieldHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.fieldDescription1.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldDescription1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldDescription1.AreaIndex = 1;
            this.fieldDescription1.FieldName = "Description";
            this.fieldDescription1.Name = "fieldDescription1";
            this.fieldDescription1.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.True;
            this.fieldDescription1.Width = 300;
            // 
            // fieldCARRIER1
            // 
            this.fieldCARRIER1.Appearance.FieldValue.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold);
            this.fieldCARRIER1.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCARRIER1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldCARRIER1.AreaIndex = 0;
            this.fieldCARRIER1.FieldName = "CARRIER";
            this.fieldCARRIER1.Name = "fieldCARRIER1";
            // 
            // fieldACGroup1
            // 
            this.fieldACGroup1.Appearance.FieldValue.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.fieldACGroup1.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldACGroup1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldACGroup1.AreaIndex = 1;
            this.fieldACGroup1.FieldName = "AC_Group";
            this.fieldACGroup1.Name = "fieldACGroup1";
            // 
            // fieldNetwork1
            // 
            this.fieldNetwork1.Appearance.FieldValue.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.fieldNetwork1.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldNetwork1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldNetwork1.AreaIndex = 2;
            this.fieldNetwork1.FieldName = "Network";
            this.fieldNetwork1.Name = "fieldNetwork1";
            // 
            // fieldCost1
            // 
            this.fieldCost1.Appearance.FieldValue.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.fieldCost1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldCost1.AreaIndex = 0;
            this.fieldCost1.CellFormat.FormatString = "n0";
            this.fieldCost1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldCost1.FieldName = "Cost";
            this.fieldCost1.Name = "fieldCost1";
            // 
            // pAreaCode
            // 
            this.pAreaCode.Name = "pAreaCode";
            this.pAreaCode.ValueInfo = "SGN";
            this.pAreaCode.Visible = false;
            // 
            // pFromDate
            // 
            this.pFromDate.Name = "pFromDate";
            this.pFromDate.Type = typeof(System.DateTime);
            this.pFromDate.ValueInfo = "2018-09-01";
            this.pFromDate.Visible = false;
            // 
            // pToDate
            // 
            this.pToDate.Name = "pToDate";
            this.pToDate.Type = typeof(System.DateTime);
            this.pToDate.ValueInfo = "2018-09-30";
            this.pToDate.Visible = false;
            // 
            // pDateStr
            // 
            this.pDateStr.Name = "pDateStr";
            this.pDateStr.Visible = false;
            // 
            // fieldSorting
            // 
            this.fieldSorting.Appearance.FieldHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.fieldSorting.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldSorting.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldSorting.AreaIndex = 0;
            this.fieldSorting.FieldName = "Sorting";
            this.fieldSorting.Name = "fieldSorting";
            // 
            // ChiphiBinhquan
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
            this.Margins = new System.Drawing.Printing.Margins(27, 22, 106, 45);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.pAreaCode,
            this.pFromDate,
            this.pToDate,
            this.pDateStr});
            this.Version = "17.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion

    private void xrPivotGrid1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        this.xrPivotGrid1.BestFit(fieldSorting);
        this.xrPivotGrid1.BestFit(fieldCARRIER1);
        this.xrPivotGrid1.BestFit(fieldACGroup1);
        this.xrPivotGrid1.BestFit(fieldNetwork1);
        this.xrPivotGrid1.BestFit(fieldCost1);
    }
}
