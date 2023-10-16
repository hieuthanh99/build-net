using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using KTQTData;
using System.Linq;

/// <summary>
/// Summary description for DTCPTheo8NhomChiPhi
/// </summary>
public class DTCPTheo8NhomChiPhi : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private DevExpress.XtraReports.Parameters.Parameter pVersionID;
    private DevExpress.XtraReports.Parameters.Parameter pAreaCode;
    private DevExpress.XtraReports.Parameters.Parameter pFromDate;
    private DevExpress.XtraReports.Parameters.Parameter pToDate;
    private DevExpress.XtraReports.Parameters.Parameter pCarrier;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private XRPivotGrid xrPivotGrid1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCARRIER1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldDescription1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCOST1;
    private PageHeaderBand PageHeader;
    private DevExpress.XtraReports.Parameters.Parameter pDateStr;
    private XRLabel xrLabel1;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private XRLabel xrLabel2;
    private DevExpress.XtraReports.Parameters.Parameter pNetwork;
    private DevExpress.XtraReports.Parameters.Parameter pFltType;
    private DevExpress.XtraReports.Parameters.Parameter pCostType;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldBASICREV;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldRRREV;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldSeq;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public DTCPTheo8NhomChiPhi()
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
            string resourceFileName = "DTCPTheo8NhomChiPhi.resx";
            System.Resources.ResourceManager resources = global::Resources.DTCPTheo8NhomChiPhi.ResourceManager;
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
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.fieldCARRIER1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldBASICREV = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldRRREV = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldDescription1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldSeq = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldCOST1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.pVersionID = new DevExpress.XtraReports.Parameters.Parameter();
            this.pAreaCode = new DevExpress.XtraReports.Parameters.Parameter();
            this.pFromDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.pToDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.pCarrier = new DevExpress.XtraReports.Parameters.Parameter();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.pDateStr = new DevExpress.XtraReports.Parameters.Parameter();
            this.pNetwork = new DevExpress.XtraReports.Parameters.Parameter();
            this.pFltType = new DevExpress.XtraReports.Parameters.Parameter();
            this.pCostType = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
            this.Detail.HeightF = 131.6667F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.xrPivotGrid1.DataMember = "Query";
            this.xrPivotGrid1.DataSource = this.sqlDataSource1;
            this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.fieldCARRIER1,
            this.fieldBASICREV,
            this.fieldRRREV,
            this.fieldDescription1,
            this.fieldSeq,
            this.fieldCOST1});
            this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPivotGrid1.Name = "xrPivotGrid1";
            this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
            this.xrPivotGrid1.OptionsView.ShowColumnHeaders = false;
            this.xrPivotGrid1.OptionsView.ShowDataHeaders = false;
            this.xrPivotGrid1.OptionsView.ShowFilterHeaders = false;
            this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(418.3334F, 131.6667F);
            this.xrPivotGrid1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrPivotGrid1_BeforePrint);
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "KTQT_Data_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            queryParameter1.Name = "pVersionID";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.pVersionID]", typeof(long));
            queryParameter2.Name = "pAreaCode";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.pAreaCode]", typeof(string));
            queryParameter3.Name = "pFromDate";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.pFromDate]", typeof(System.DateTime));
            queryParameter4.Name = "pToDate";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("[Parameters.pToDate]", typeof(System.DateTime));
            queryParameter5.Name = "pCarrier";
            queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter5.Value = new DevExpress.DataAccess.Expression("[Parameters.pCarrier]", typeof(string));
            queryParameter6.Name = "pCostType";
            queryParameter6.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter6.Value = new DevExpress.DataAccess.Expression("[Parameters.pCostType]", typeof(string));
            queryParameter7.Name = "pNetwork";
            queryParameter7.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter7.Value = new DevExpress.DataAccess.Expression("[Parameters.pNetwork]", typeof(string));
            queryParameter8.Name = "pFltType";
            queryParameter8.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter8.Value = new DevExpress.DataAccess.Expression("[Parameters.pFltType]", typeof(string));
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
            // fieldCARRIER1
            // 
            this.fieldCARRIER1.Appearance.FieldHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.fieldCARRIER1.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCARRIER1.Appearance.FieldValue.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.fieldCARRIER1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldCARRIER1.AreaIndex = 0;
            this.fieldCARRIER1.Caption = "Opt";
            this.fieldCARRIER1.FieldName = "CARRIER";
            this.fieldCARRIER1.Name = "fieldCARRIER1";
            this.fieldCARRIER1.Width = 50;
            // 
            // fieldBASICREV
            // 
            this.fieldBASICREV.Appearance.FieldHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.fieldBASICREV.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldBASICREV.Appearance.FieldValue.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.fieldBASICREV.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.fieldBASICREV.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldBASICREV.AreaIndex = 1;
            this.fieldBASICREV.Caption = "DT cơ bản";
            this.fieldBASICREV.CellFormat.FormatString = "n0";
            this.fieldBASICREV.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldBASICREV.FieldName = "BASIC_REV";
            this.fieldBASICREV.Name = "fieldBASICREV";
            this.fieldBASICREV.ValueFormat.FormatString = "n0";
            this.fieldBASICREV.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldBASICREV.Width = 120;
            // 
            // fieldRRREV
            // 
            this.fieldRRREV.Appearance.FieldHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.fieldRRREV.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldRRREV.Appearance.FieldValue.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.fieldRRREV.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.fieldRRREV.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldRRREV.AreaIndex = 2;
            this.fieldRRREV.Caption = "DT RR";
            this.fieldRRREV.FieldName = "RR_REV";
            this.fieldRRREV.Name = "fieldRRREV";
            this.fieldRRREV.ValueFormat.FormatString = "n0";
            this.fieldRRREV.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldRRREV.Width = 120;
            // 
            // fieldDescription1
            // 
            this.fieldDescription1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldDescription1.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldDescription1.Appearance.FieldValue.WordWrap = true;
            this.fieldDescription1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldDescription1.AreaIndex = 1;
            this.fieldDescription1.FieldName = "Description";
            this.fieldDescription1.Name = "fieldDescription1";
            this.fieldDescription1.Width = 120;
            // 
            // fieldSeq
            // 
            this.fieldSeq.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldSeq.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldSeq.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldSeq.AreaIndex = 0;
            this.fieldSeq.FieldName = "Seq";
            this.fieldSeq.Name = "fieldSeq";
            // 
            // fieldCOST1
            // 
            this.fieldCOST1.Appearance.FieldValue.WordWrap = true;
            this.fieldCOST1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCOST1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCOST1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCOST1.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCOST1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldCOST1.AreaIndex = 0;
            this.fieldCOST1.CellFormat.FormatString = "n0";
            this.fieldCOST1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldCOST1.FieldName = "COST";
            this.fieldCOST1.Name = "fieldCOST1";
            this.fieldCOST1.TotalCellFormat.FormatString = "n0";
            this.fieldCOST1.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldCOST1.TotalValueFormat.FormatString = "n0";
            this.fieldCOST1.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldCOST1.Width = 120;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 28.125F;
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
            this.pFromDate.ValueInfo = "2019-01-01";
            this.pFromDate.Visible = false;
            // 
            // pToDate
            // 
            this.pToDate.Name = "pToDate";
            this.pToDate.Type = typeof(System.DateTime);
            this.pToDate.ValueInfo = "2019-03-31";
            this.pToDate.Visible = false;
            // 
            // pCarrier
            // 
            this.pCarrier.Name = "pCarrier";
            this.pCarrier.ValueInfo = "ALL";
            this.pCarrier.Visible = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2});
            this.PageHeader.HeightF = 115.625F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 7.291667F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(810F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "DOANH THU, CHI PHÍ THEO 8 NHÓM YẾU TỐ";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 30.29167F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(810F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 53.29167F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(810F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters].[pDateStr]")});
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 76.29169F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(810F, 23.00001F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // pDateStr
            // 
            this.pDateStr.Name = "pDateStr";
            this.pDateStr.Visible = false;
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
            // DTCPTheo8NhomChiPhi
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.Margins = new System.Drawing.Printing.Margins(20, 20, 28, 100);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.pVersionID,
            this.pAreaCode,
            this.pFromDate,
            this.pToDate,
            this.pCarrier,
            this.pDateStr,
            this.pNetwork,
            this.pFltType,
            this.pCostType});
            this.Version = "17.2";
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
        //this.fieldCARRIER1.BestFit();
        //this.fieldBASICREV.BestFit();
        //this.fieldRRREV.BestFit();
        //this.fieldRepID1.BestFit();
        //this.fieldDescription1.BestFit();
        //this.fieldCOST1.BestFit();
    }
}
