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
public class ChiphiTheoRouteProfit : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private DevExpress.XtraReports.Parameters.Parameter pVersionID;
    private DevExpress.XtraReports.Parameters.Parameter pAreaCode;
    private DevExpress.XtraReports.Parameters.Parameter pFromDate;
    private DevExpress.XtraReports.Parameters.Parameter pToDate;
    private DevExpress.XtraReports.Parameters.Parameter pCarrier;
    private DevExpress.XtraReports.Parameters.Parameter pNetwork;
    private DevExpress.XtraReports.Parameters.Parameter pFltType;
    private DevExpress.XtraReports.Parameters.Parameter pCostType;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private XRPivotGrid xrPivotGrid1;
    private DevExpress.XtraReports.Parameters.Parameter pDateStr;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldSorting;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldDescription;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldACGroup;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCARRIER;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldNetwork;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCOST;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCOSTCTY;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldTOTALCOST;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCOSTBRANCH;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldGroupName;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel2;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private XRLabel xrLabel5;
    private XRChart xrChart1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldSort;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldSeq;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldFASTCode;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldFeeCode;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCostBDS;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCostKST;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

    public ChiphiTheoRouteProfit()
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
            string resourceFileName = "ChiphiTheoRouteProfit.resx";
            System.Resources.ResourceManager resources = global::Resources.ChiphiTheoRouteProfit.ResourceManager;
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter6 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter7 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter8 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery2 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter9 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter10 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter11 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter12 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter13 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter14 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter15 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter16 = new DevExpress.DataAccess.Sql.QueryParameter();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrChart1 = new DevExpress.XtraReports.UI.XRChart();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
            this.fieldSort = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldGroupName = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldSeq = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldSorting = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldDescription = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldFASTCode = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldFeeCode = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldACGroup = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldCARRIER = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldNetwork = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldCOST = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldCOSTCTY = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldCOSTBRANCH = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldTOTALCOST = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.pVersionID = new DevExpress.XtraReports.Parameters.Parameter();
            this.pAreaCode = new DevExpress.XtraReports.Parameters.Parameter();
            this.pFromDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.pToDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.pCarrier = new DevExpress.XtraReports.Parameters.Parameter();
            this.pNetwork = new DevExpress.XtraReports.Parameters.Parameter();
            this.pFltType = new DevExpress.XtraReports.Parameters.Parameter();
            this.pCostType = new DevExpress.XtraReports.Parameters.Parameter();
            this.pDateStr = new DevExpress.XtraReports.Parameters.Parameter();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldCostBDS = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldCostKST = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrChart1,
            this.xrPivotGrid1});
            this.Detail.HeightF = 584.5834F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrChart1
            // 
            this.xrChart1.BorderColor = System.Drawing.Color.Black;
            this.xrChart1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrChart1.DataMember = "RepTotalCostByRepID";
            this.xrChart1.DataSource = this.sqlDataSource1;
            this.xrChart1.Legend.Name = "Default Legend";
            this.xrChart1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.xrChart1.LocationFloat = new DevExpress.Utils.PointFloat(132.5834F, 129.5834F);
            this.xrChart1.Name = "xrChart1";
            series1.ArgumentDataMember = "GroupName";
            series1.LegendTextPattern = "{A}: {V:n2}";
            series1.Name = "Series 1";
            series1.ValueDataMembersSerializable = "TOTAL_COST";
            series1.View = pieSeriesView1;
            this.xrChart1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.xrChart1.SizeF = new System.Drawing.SizeF(762.4999F, 445F);
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "KTQT_Data_Connection";
            this.sqlDataSource1.ConnectionOptions.DbCommandTimeout = 0;
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "RepSummaryCostByCostGroup";
            queryParameter1.Name = "@pVersionID";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.pVersionID]", typeof(decimal));
            queryParameter2.Name = "@pAreaCode";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.pAreaCode]", typeof(string));
            queryParameter3.Name = "@pFromDate";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.pFromDate]", typeof(System.DateTime));
            queryParameter4.Name = "@pToDate";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("[Parameters.pToDate]", typeof(System.DateTime));
            queryParameter5.Name = "@pCarrier";
            queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter5.Value = new DevExpress.DataAccess.Expression("[Parameters.pCarrier]", typeof(string));
            queryParameter6.Name = "@pNetwork";
            queryParameter6.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter6.Value = new DevExpress.DataAccess.Expression("[Parameters.pNetwork]", typeof(string));
            queryParameter7.Name = "@pFltType";
            queryParameter7.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter7.Value = new DevExpress.DataAccess.Expression("[Parameters.pFltType]", typeof(string));
            queryParameter8.Name = "@pCostType";
            queryParameter8.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter8.Value = new DevExpress.DataAccess.Expression("[Parameters.pCostType]", typeof(string));
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.Parameters.Add(queryParameter4);
            storedProcQuery1.Parameters.Add(queryParameter5);
            storedProcQuery1.Parameters.Add(queryParameter6);
            storedProcQuery1.Parameters.Add(queryParameter7);
            storedProcQuery1.Parameters.Add(queryParameter8);
            storedProcQuery1.StoredProcName = "RepSummaryCostByRepID";
            storedProcQuery2.Name = "RepTotalCostByRepID";
            queryParameter9.Name = "@pVersionID";
            queryParameter9.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter9.Value = new DevExpress.DataAccess.Expression("[Parameters.pVersionID]", typeof(decimal));
            queryParameter10.Name = "@pAreaCode";
            queryParameter10.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter10.Value = new DevExpress.DataAccess.Expression("[Parameters.pAreaCode]", typeof(string));
            queryParameter11.Name = "@pFromDate";
            queryParameter11.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter11.Value = new DevExpress.DataAccess.Expression("[Parameters.pFromDate]", typeof(System.DateTime));
            queryParameter12.Name = "@pToDate";
            queryParameter12.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter12.Value = new DevExpress.DataAccess.Expression("[Parameters.pToDate]", typeof(System.DateTime));
            queryParameter13.Name = "@pCarrier";
            queryParameter13.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter13.Value = new DevExpress.DataAccess.Expression("[Parameters.pCarrier]", typeof(string));
            queryParameter14.Name = "@pNetwork";
            queryParameter14.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter14.Value = new DevExpress.DataAccess.Expression("[Parameters.pNetwork]", typeof(string));
            queryParameter15.Name = "@pFltType";
            queryParameter15.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter15.Value = new DevExpress.DataAccess.Expression("[Parameters.pFltType]", typeof(string));
            queryParameter16.Name = "@pCostType";
            queryParameter16.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter16.Value = new DevExpress.DataAccess.Expression("[Parameters.pCostType]", typeof(string));
            storedProcQuery2.Parameters.Add(queryParameter9);
            storedProcQuery2.Parameters.Add(queryParameter10);
            storedProcQuery2.Parameters.Add(queryParameter11);
            storedProcQuery2.Parameters.Add(queryParameter12);
            storedProcQuery2.Parameters.Add(queryParameter13);
            storedProcQuery2.Parameters.Add(queryParameter14);
            storedProcQuery2.Parameters.Add(queryParameter15);
            storedProcQuery2.Parameters.Add(queryParameter16);
            storedProcQuery2.StoredProcName = "RepTotalCostByRepID";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1,
            storedProcQuery2});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // xrPivotGrid1
            // 
            this.xrPivotGrid1.Appearance.Cell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.Lines.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.DataMember = "RepSummaryCostByCostGroup";
            this.xrPivotGrid1.DataSource = this.sqlDataSource1;
            this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.fieldSort,
            this.fieldGroupName,
            this.fieldSeq,
            this.fieldSorting,
            this.fieldDescription,
            this.fieldFASTCode,
            this.fieldFeeCode,
            this.fieldACGroup,
            this.fieldCARRIER,
            this.fieldNetwork,
            this.fieldCOST,
            this.fieldCOSTCTY,
            this.fieldCOSTBRANCH,
            this.fieldCostBDS,
            this.fieldCostKST,
            this.fieldTOTALCOST});
            this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPivotGrid1.Name = "xrPivotGrid1";
            this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
            this.xrPivotGrid1.OptionsView.ShowColumnHeaders = false;
            this.xrPivotGrid1.OptionsView.ShowColumnTotals = false;
            this.xrPivotGrid1.OptionsView.ShowDataHeaders = false;
            this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(1126F, 112.5F);
            this.xrPivotGrid1.FieldValueDisplayText += new System.EventHandler<DevExpress.XtraReports.UI.PivotGrid.PivotFieldDisplayTextEventArgs>(this.xrPivotGrid1_FieldValueDisplayText);
            this.xrPivotGrid1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrPivotGrid1_BeforePrint);
            // 
            // fieldSort
            // 
            this.fieldSort.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldSort.AreaIndex = 3;
            this.fieldSort.FieldName = "Sort";
            this.fieldSort.Name = "fieldSort";
            this.fieldSort.Visible = false;
            // 
            // fieldGroupName
            // 
            this.fieldGroupName.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldGroupName.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldGroupName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldGroupName.AreaIndex = 0;
            this.fieldGroupName.FieldName = "GroupName";
            this.fieldGroupName.Name = "fieldGroupName";
            this.fieldGroupName.SortBySummaryInfo.Field = this.fieldSort;
            // 
            // fieldSeq
            // 
            this.fieldSeq.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldSeq.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldSeq.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldSeq.AreaIndex = 1;
            this.fieldSeq.FieldName = "Seq";
            this.fieldSeq.Name = "fieldSeq";
            this.fieldSeq.Width = 50;
            // 
            // fieldSorting
            // 
            this.fieldSorting.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldSorting.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldSorting.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldSorting.AreaIndex = 2;
            this.fieldSorting.FieldName = "Sorting";
            this.fieldSorting.Name = "fieldSorting";
            this.fieldSorting.Width = 50;
            // 
            // fieldDescription
            // 
            this.fieldDescription.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldDescription.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldDescription.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldDescription.AreaIndex = 3;
            this.fieldDescription.FieldName = "Description";
            this.fieldDescription.Name = "fieldDescription";
            this.fieldDescription.Width = 250;
            // 
            // fieldFASTCode
            // 
            this.fieldFASTCode.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldFASTCode.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldFASTCode.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldFASTCode.AreaIndex = 4;
            this.fieldFASTCode.FieldName = "FASTCode";
            this.fieldFASTCode.Name = "fieldFASTCode";
            // 
            // fieldFeeCode
            // 
            this.fieldFeeCode.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldFeeCode.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldFeeCode.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldFeeCode.AreaIndex = 5;
            this.fieldFeeCode.FieldName = "FeeCode";
            this.fieldFeeCode.Name = "fieldFeeCode";
            // 
            // fieldACGroup
            // 
            this.fieldACGroup.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldACGroup.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldACGroup.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldACGroup.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldACGroup.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldACGroup.AreaIndex = 1;
            this.fieldACGroup.FieldName = "AC_Group";
            this.fieldACGroup.Name = "fieldACGroup";
            // 
            // fieldCARRIER
            // 
            this.fieldCARRIER.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCARRIER.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCARRIER.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCARRIER.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCARRIER.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldCARRIER.AreaIndex = 0;
            this.fieldCARRIER.FieldName = "CARRIER";
            this.fieldCARRIER.Name = "fieldCARRIER";
            // 
            // fieldNetwork
            // 
            this.fieldNetwork.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldNetwork.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldNetwork.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldNetwork.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldNetwork.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldNetwork.AreaIndex = 2;
            this.fieldNetwork.FieldName = "Network";
            this.fieldNetwork.Name = "fieldNetwork";
            // 
            // fieldCOST
            // 
            this.fieldCOST.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCOST.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCOST.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCOST.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCOST.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCOST.Appearance.FieldValueGrandTotal.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCOST.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldCOST.AreaIndex = 0;
            this.fieldCOST.Caption = "Cost (Branch+Disburment)";
            this.fieldCOST.CellFormat.FormatString = "{0:n2}";
            this.fieldCOST.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldCOST.FieldName = "COST";
            this.fieldCOST.Name = "fieldCOST";
            // 
            // fieldCOSTCTY
            // 
            this.fieldCOSTCTY.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCOSTCTY.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCOSTCTY.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCOSTCTY.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCOSTCTY.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCOSTCTY.Appearance.FieldValueGrandTotal.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCOSTCTY.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldCOSTCTY.AreaIndex = 1;
            this.fieldCOSTCTY.Caption = "Cost (KVP)";
            this.fieldCOSTCTY.CellFormat.FormatString = "{0:n2}";
            this.fieldCOSTCTY.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldCOSTCTY.FieldName = "COSTCTY";
            this.fieldCOSTCTY.Name = "fieldCOSTCTY";
            // 
            // fieldCOSTBRANCH
            // 
            this.fieldCOSTBRANCH.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCOSTBRANCH.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCOSTBRANCH.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCOSTBRANCH.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCOSTBRANCH.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCOSTBRANCH.Appearance.FieldValueGrandTotal.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCOSTBRANCH.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldCOSTBRANCH.AreaIndex = 2;
            this.fieldCOSTBRANCH.Caption = "Disbursement (KVP)";
            this.fieldCOSTBRANCH.CellFormat.FormatString = "{0:n2}";
            this.fieldCOSTBRANCH.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldCOSTBRANCH.FieldName = "COST_BRANCH";
            this.fieldCOSTBRANCH.Name = "fieldCOSTBRANCH";
            // 
            // fieldTOTALCOST
            // 
            this.fieldTOTALCOST.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldTOTALCOST.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldTOTALCOST.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldTOTALCOST.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldTOTALCOST.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldTOTALCOST.Appearance.FieldValueGrandTotal.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldTOTALCOST.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldTOTALCOST.AreaIndex = 5;
            this.fieldTOTALCOST.Caption = "Total Cost";
            this.fieldTOTALCOST.CellFormat.FormatString = "{0:n2}";
            this.fieldTOTALCOST.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldTOTALCOST.FieldName = "TOTAL_COST";
            this.fieldTOTALCOST.Name = "fieldTOTALCOST";
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 33.33333F;
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
            this.pVersionID.ValueInfo = "8";
            this.pVersionID.Visible = false;
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
            this.pFromDate.ValueInfo = "2020-10-01";
            this.pFromDate.Visible = false;
            // 
            // pToDate
            // 
            this.pToDate.Name = "pToDate";
            this.pToDate.Type = typeof(System.DateTime);
            this.pToDate.ValueInfo = "2020-10-31";
            this.pToDate.Visible = false;
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
            // pCostType
            // 
            this.pCostType.Name = "pCostType";
            this.pCostType.ValueInfo = "ALL";
            this.pCostType.Visible = false;
            // 
            // pDateStr
            // 
            this.pDateStr.Name = "pDateStr";
            this.pDateStr.Visible = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel5});
            this.ReportHeader.HeightF = 124.1667F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(1126F, 27.99999F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "PHÂN LOẠI CHI PHÍ THEO NHÓM CHI PHÍ (8 LOẠI CHI PHÍ LỚN)";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 37.99998F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(1126F, 23.00001F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 60.99998F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(1126F, 22.99999F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters].[pDateStr]")});
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 84.00002F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(1126F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "xrLabel2";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // fieldCostBDS
            // 
            this.fieldCostBDS.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCostBDS.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCostBDS.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCostBDS.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCostBDS.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCostBDS.Appearance.FieldValueGrandTotal.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCostBDS.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldCostBDS.AreaIndex = 3;
            this.fieldCostBDS.Caption = "Cost (TT BDSC)";
            this.fieldCostBDS.CellFormat.FormatString = "{0:n2}";
            this.fieldCostBDS.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldCostBDS.FieldName = "Cost_BDS";
            this.fieldCostBDS.Name = "fieldCostBDS";
            // 
            // fieldCostKST
            // 
            this.fieldCostKST.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCostKST.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCostKST.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCostKST.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCostKST.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCostKST.Appearance.FieldValueGrandTotal.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCostKST.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldCostKST.AreaIndex = 4;
            this.fieldCostKST.Caption = "Cost (TT KST)";
            this.fieldCostKST.CellFormat.FormatString = "{0:n2}";
            this.fieldCostKST.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldCostKST.FieldName = "Cost_KST";
            this.fieldCostKST.Name = "fieldCostKST";
            // 
            // ChiphiTheoRouteProfit
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.Margins = new System.Drawing.Printing.Margins(22, 21, 33, 100);
            this.PageHeight = 1654;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A3;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.pVersionID,
            this.pAreaCode,
            this.pFromDate,
            this.pToDate,
            this.pCarrier,
            this.pNetwork,
            this.pFltType,
            this.pCostType,
            this.pDateStr});
            this.Version = "17.2";
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).EndInit();
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

    private void xrPivotGrid1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        this.fieldGroupName.BestFit();
        this.fieldSorting.BestFit();
        this.fieldSeq.BestFit();
        this.fieldCARRIER.BestFit();
        this.fieldACGroup.BestFit();
        this.fieldNetwork.BestFit();
        this.fieldCOST.BestFit();
        this.fieldCOSTBRANCH.BestFit();
        this.fieldCOSTCTY.BestFit();
        this.fieldCostBDS.BestFit();
        this.fieldCostKST.BestFit();
        this.fieldTOTALCOST.BestFit();
        this.fieldFASTCode.BestFit();
        this.fieldFeeCode.BestFit();
    }

    private void xrPivotGrid1_FieldValueDisplayText(object sender, DevExpress.XtraReports.UI.PivotGrid.PivotFieldDisplayTextEventArgs e)
    {
        //if (e.ValueType == DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal)
           
    }
}
