using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ExportTemplateStoreCompany
/// </summary>
public class ExportTemplateStoreCompany : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private ReportHeaderBand reportHeaderBand1;
    private GroupHeaderBand groupHeaderBand1;
    private XRControlStyle Title;
    private XRControlStyle DetailCaption3;
    private XRControlStyle DetailData3;
    private XRControlStyle DetailData3_Odd;
    private XRControlStyle DetailCaptionBackground3;
    private XRControlStyle PageInfo;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField QOutStandard;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField xrPivotGridField1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField xrPivotGridField2;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField xrPivotGridField3;
    private XRPivotGrid xrPivotGrid1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField RSubaccount;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField xrPivotGridField4;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField xrPivotGridField5;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField xrPivotGridField6;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField xrPivotGridField7;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField xrPivotGridField8;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField xrPivotGridField9;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField xrPivotGridField10;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField xrPivotGridField11;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField RSeq;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField RSorting;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField RCalculation;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField RRevCostMonth;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField CFASTCode;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField CNameV;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField pivotGridField1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField pivotGridField3;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField pivotGridField2;
    private DevExpress.XtraReports.Parameters.Parameter PVERSION;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public ExportTemplateStoreCompany()
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
            string resourceFileName = "ExportTemplateStoreCompany.resx";
            System.Resources.ResourceManager resources = global::Resources.ExportTemplateStoreCompany.ResourceManager;
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField RDescription;
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery2 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
            this.pivotGridField1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField4 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.RSubaccount = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField5 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField6 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField7 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField8 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pivotGridField3 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pivotGridField2 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField10 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField9 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField11 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailCaption3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData3_Odd = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailCaptionBackground3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.QOutStandard = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField2 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField3 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.RSeq = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.RSorting = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.RCalculation = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.RRevCostMonth = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.CFASTCode = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.CNameV = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.PVERSION = new DevExpress.XtraReports.Parameters.Parameter();
            RDescription = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // RDescription
            // 
            RDescription.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            RDescription.AreaIndex = 3;
            RDescription.Caption = "Description";
            RDescription.FieldName = "Description";
            RDescription.Name = "RDescription";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "KTQT_Data_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            queryParameter1.Name = "PVERSION";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.PVERSION]", typeof(int));
            customSqlQuery1.Parameters.Add(queryParameter1);
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            customSqlQuery2.Name = "Version";
            customSqlQuery2.Sql = "select  cast(VersionYear as varchar) + \'_\' + VersionType + \'_\' + Description NoiD" +
    "ung, VersionID\r\nfrom version\r\nwhere active = 1\r\norder by VersionYear desc, Versi" +
    "onType asc, versionid desc";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1,
            customSqlQuery2});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // Detail
            // 
            this.Detail.HeightF = 8.750026F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("seq", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 3.000005F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 332.6667F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.HeightF = 60F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // groupHeaderBand1
            // 
            this.groupHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
            this.groupHeaderBand1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.groupHeaderBand1.HeightF = 204.5834F;
            this.groupHeaderBand1.Name = "groupHeaderBand1";
            // 
            // xrPivotGrid1
            // 
            this.xrPivotGrid1.Appearance.Cell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.Cell.WordWrap = true;
            this.xrPivotGrid1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.CustomTotalCell.WordWrap = true;
            this.xrPivotGrid1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValue.WordWrap = true;
            this.xrPivotGrid1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValueGrandTotal.WordWrap = true;
            this.xrPivotGrid1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValueTotal.WordWrap = true;
            this.xrPivotGrid1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.GrandTotalCell.WordWrap = true;
            this.xrPivotGrid1.Appearance.Lines.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.Lines.WordWrap = true;
            this.xrPivotGrid1.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.TotalCell.WordWrap = true;
            this.xrPivotGrid1.DataMember = "Query";
            this.xrPivotGrid1.DataSource = this.sqlDataSource1;
            this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.pivotGridField1,
            this.xrPivotGridField4,
            this.RSubaccount,
            this.xrPivotGridField5,
            this.xrPivotGridField6,
            this.xrPivotGridField7,
            this.xrPivotGridField8,
            this.pivotGridField3,
            this.pivotGridField2,
            this.xrPivotGridField10,
            this.xrPivotGridField9,
            this.xrPivotGridField11});
            this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPivotGrid1.Name = "xrPivotGrid1";
            this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
            this.xrPivotGrid1.OptionsPrint.MergeColumnFieldValues = false;
            this.xrPivotGrid1.OptionsPrint.MergeRowFieldValues = false;
            this.xrPivotGrid1.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.xrPivotGrid1.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.xrPivotGrid1.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.xrPivotGrid1.OptionsPrint.PrintRowHeaders = DevExpress.Utils.DefaultBoolean.True;
            this.xrPivotGrid1.OptionsPrint.PrintVertLines = DevExpress.Utils.DefaultBoolean.True;
            this.xrPivotGrid1.OptionsView.ShowColumnGrandTotalHeader = false;
            this.xrPivotGrid1.OptionsView.ShowColumnGrandTotals = false;
            this.xrPivotGrid1.OptionsView.ShowColumnTotals = false;
            this.xrPivotGrid1.OptionsView.ShowRowGrandTotalHeader = false;
            this.xrPivotGrid1.OptionsView.ShowRowGrandTotals = false;
            this.xrPivotGrid1.OptionsView.ShowRowTotals = false;
            this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(1083F, 204.5834F);
            this.xrPivotGrid1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrPivotGrid1_BeforePrint);
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField1.AreaIndex = 0;
            this.pivotGridField1.Caption = "Group";
            this.pivotGridField1.FieldName = "AccountGroup";
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
            this.pivotGridField1.Width = 40;
            // 
            // xrPivotGridField4
            // 
            this.xrPivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.xrPivotGridField4.AreaIndex = 1;
            this.xrPivotGridField4.Caption = "Seq";
            this.xrPivotGridField4.FieldName = "seq";
            this.xrPivotGridField4.Name = "xrPivotGridField4";
            this.xrPivotGridField4.Width = 50;
            // 
            // RSubaccount
            // 
            this.RSubaccount.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.RSubaccount.AreaIndex = 2;
            this.RSubaccount.Caption = "Subaccount";
            this.RSubaccount.FieldName = "SubaccountID";
            this.RSubaccount.Name = "RSubaccount";
            this.RSubaccount.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.None;
            this.RSubaccount.Width = 70;
            // 
            // xrPivotGridField5
            // 
            this.xrPivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.xrPivotGridField5.AreaIndex = 3;
            this.xrPivotGridField5.Caption = "Sorting";
            this.xrPivotGridField5.FieldName = "Sorting";
            this.xrPivotGridField5.Name = "xrPivotGridField5";
            this.xrPivotGridField5.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.None;
            // 
            // xrPivotGridField6
            // 
            this.xrPivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.xrPivotGridField6.AreaIndex = 4;
            this.xrPivotGridField6.Caption = "Description";
            this.xrPivotGridField6.FieldName = "Description";
            this.xrPivotGridField6.Name = "xrPivotGridField6";
            this.xrPivotGridField6.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.None;
            this.xrPivotGridField6.Width = 300;
            // 
            // xrPivotGridField7
            // 
            this.xrPivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.xrPivotGridField7.AreaIndex = 5;
            this.xrPivotGridField7.Caption = "Calculation";
            this.xrPivotGridField7.FieldName = "Calculation";
            this.xrPivotGridField7.Name = "xrPivotGridField7";
            this.xrPivotGridField7.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.None;
            this.xrPivotGridField7.Width = 70;
            // 
            // xrPivotGridField8
            // 
            this.xrPivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.xrPivotGridField8.AreaIndex = 6;
            this.xrPivotGridField8.Caption = "Month";
            this.xrPivotGridField8.FieldName = "RevCostMonth";
            this.xrPivotGridField8.Name = "xrPivotGridField8";
            this.xrPivotGridField8.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.None;
            this.xrPivotGridField8.Width = 50;
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField3.AreaIndex = 0;
            this.pivotGridField3.FieldName = "VerCompanyID";
            this.pivotGridField3.Name = "pivotGridField3";
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField2.AreaIndex = 1;
            this.pivotGridField2.FieldName = "CompanyID";
            this.pivotGridField2.Name = "pivotGridField2";
            // 
            // xrPivotGridField10
            // 
            this.xrPivotGridField10.Appearance.Cell.WordWrap = true;
            this.xrPivotGridField10.Appearance.CustomTotalCell.WordWrap = true;
            this.xrPivotGridField10.Appearance.FieldHeader.WordWrap = true;
            this.xrPivotGridField10.Appearance.FieldValue.WordWrap = true;
            this.xrPivotGridField10.Appearance.FieldValueGrandTotal.WordWrap = true;
            this.xrPivotGridField10.Appearance.FieldValueTotal.WordWrap = true;
            this.xrPivotGridField10.Appearance.GrandTotalCell.WordWrap = true;
            this.xrPivotGridField10.Appearance.TotalCell.WordWrap = true;
            this.xrPivotGridField10.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.xrPivotGridField10.AreaIndex = 2;
            this.xrPivotGridField10.ColumnValueLineCount = 3;
            this.xrPivotGridField10.FieldName = "NameV";
            this.xrPivotGridField10.Name = "xrPivotGridField10";
            // 
            // xrPivotGridField9
            // 
            this.xrPivotGridField9.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.xrPivotGridField9.AreaIndex = 3;
            this.xrPivotGridField9.FieldName = "FASTCode";
            this.xrPivotGridField9.Name = "xrPivotGridField9";
            // 
            // xrPivotGridField11
            // 
            this.xrPivotGridField11.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.xrPivotGridField11.AreaIndex = 0;
            this.xrPivotGridField11.CellFormat.FormatString = "0";
            this.xrPivotGridField11.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.xrPivotGridField11.FieldName = "OutStandards";
            this.xrPivotGridField11.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.xrPivotGridField11.Name = "xrPivotGridField11";
            this.xrPivotGridField11.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.xrPivotGridField11.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.xrPivotGridField11.UnboundFieldName = "xrPivotGridField11";
            this.xrPivotGridField11.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
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
            // QOutStandard
            // 
            this.QOutStandard.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.QOutStandard.AreaIndex = 0;
            this.QOutStandard.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.QOutStandard.ColumnValueLineCount = 3;
            this.QOutStandard.FieldName = "OutStandards";
            this.QOutStandard.Name = "QOutStandard";
            this.QOutStandard.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None;
            // 
            // xrPivotGridField1
            // 
            this.xrPivotGridField1.Name = "xrPivotGridField1";
            // 
            // xrPivotGridField2
            // 
            this.xrPivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.xrPivotGridField2.AreaIndex = 1;
            this.xrPivotGridField2.FieldName = "Sorting";
            this.xrPivotGridField2.Name = "xrPivotGridField2";
            // 
            // xrPivotGridField3
            // 
            this.xrPivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.xrPivotGridField3.AreaIndex = 1;
            this.xrPivotGridField3.FieldName = "Sorting";
            this.xrPivotGridField3.Name = "xrPivotGridField3";
            // 
            // RSeq
            // 
            this.RSeq.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.RSeq.AreaIndex = 1;
            this.RSeq.Caption = "Seq";
            this.RSeq.FieldName = "seq";
            this.RSeq.Name = "RSeq";
            // 
            // RSorting
            // 
            this.RSorting.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.RSorting.AreaIndex = 2;
            this.RSorting.Caption = "Sorting";
            this.RSorting.FieldName = "Sorting";
            this.RSorting.Name = "RSorting";
            // 
            // RCalculation
            // 
            this.RCalculation.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.RCalculation.AreaIndex = 4;
            this.RCalculation.Caption = "Calculation";
            this.RCalculation.FieldName = "Calculation";
            this.RCalculation.Name = "RCalculation";
            // 
            // RRevCostMonth
            // 
            this.RRevCostMonth.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.RRevCostMonth.AreaIndex = 5;
            this.RRevCostMonth.Caption = "Month";
            this.RRevCostMonth.FieldName = "RevCostMonth";
            this.RRevCostMonth.Name = "RRevCostMonth";
            // 
            // CFASTCode
            // 
            this.CFASTCode.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.CFASTCode.AreaIndex = 0;
            this.CFASTCode.FieldName = "FASTCode";
            this.CFASTCode.Name = "CFASTCode";
            // 
            // CNameV
            // 
            this.CNameV.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.CNameV.AreaIndex = 1;
            this.CNameV.FieldName = "NameV";
            this.CNameV.Name = "CNameV";
            // 
            // PVERSION
            // 
            this.PVERSION.Description = "Version";
            dynamicListLookUpSettings1.DataAdapter = null;
            dynamicListLookUpSettings1.DataMember = "Version";
            dynamicListLookUpSettings1.DataSource = this.sqlDataSource1;
            dynamicListLookUpSettings1.DisplayMember = "NoiDung";
            dynamicListLookUpSettings1.ValueMember = "VersionID";
            this.PVERSION.LookUpSettings = dynamicListLookUpSettings1;
            this.PVERSION.Name = "PVERSION";
            this.PVERSION.Type = typeof(int);
            this.PVERSION.ValueInfo = "4";
            // 
            // ExportTemplateStoreCompany
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.reportHeaderBand1,
            this.groupHeaderBand1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(8, 9, 3, 333);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.PVERSION});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.DetailCaption3,
            this.DetailData3,
            this.DetailData3_Odd,
            this.DetailCaptionBackground3,
            this.PageInfo});
            this.Version = "17.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion

    private void xrPivotGrid1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        FormattingRule rule = new FormattingRule();
        this.FormattingRuleSheet.Add(rule);

        rule.DataSource = this.DataSource;
        rule.DataMember = this.DataMember;
        rule.Condition = "[Calculation] == 'SUM'";
        rule.Formatting.Font = new Font("Tahoma", 8, FontStyle.Bold);
        this.xrPivotGrid1.FormattingRules.Add(rule);
        
    }

  
}
