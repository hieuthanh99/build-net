using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for RevCost_SoSanhThuChi_VerCompany
/// </summary>
public class RevCost_SoSanhThuChi_VerCompany : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private DevExpress.XtraReports.Parameters.Parameter pVerCompanyId;
    private DevExpress.XtraReports.Parameters.Parameter pVerCompanyBase1Id;
    private DevExpress.XtraReports.Parameters.Parameter pVerCompanyBase2Id;
    private DevExpress.XtraReports.Parameters.Parameter pVerCompanyBase3Id;
    private DevExpress.XtraReports.Parameters.Parameter pFMonth;
    private DevExpress.XtraReports.Parameters.Parameter pFMonthBase1;
    private DevExpress.XtraReports.Parameters.Parameter pFMonthBase2;
    private DevExpress.XtraReports.Parameters.Parameter pFMonthBase3;
    private DevExpress.XtraReports.Parameters.Parameter pTMonth;
    private DevExpress.XtraReports.Parameters.Parameter pTMonthBase1;
    private DevExpress.XtraReports.Parameters.Parameter pTMonthBase2;
    private DevExpress.XtraReports.Parameters.Parameter pTMonthBase3;
    private DevExpress.XtraReports.Parameters.Parameter pYear;
    private DevExpress.XtraReports.Parameters.Parameter pType;
    private DevExpress.XtraReports.Parameters.Parameter pCreated_User;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell20;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
    private XRLabel xrLabel10;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell30;
    private DevExpress.XtraReports.Parameters.Parameter pVerCompanyName;
    private DevExpress.XtraReports.Parameters.Parameter pVerCompanyBase1Name;
    private DevExpress.XtraReports.Parameters.Parameter pVerCompanyBase2Name;
    private DevExpress.XtraReports.Parameters.Parameter pVerCompanyBase3Name;
    private DevExpress.XtraReports.Parameters.Parameter pTypeBase1;
    private DevExpress.XtraReports.Parameters.Parameter pTypeBase2;
    private DevExpress.XtraReports.Parameters.Parameter pTypeBase3;
    private DevExpress.XtraReports.Parameters.Parameter pYearBase1;
    private DevExpress.XtraReports.Parameters.Parameter pYearBase2;
    private DevExpress.XtraReports.Parameters.Parameter pYearBase3;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public RevCost_SoSanhThuChi_VerCompany()
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
            string resourceFileName = "RevCost_SoSanhThuChi_VerCompany.resx";
            System.Resources.ResourceManager resources = global::Resources.RevCost_SoSanhThuChi_VerCompany.ResourceManager;
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter6 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter7 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter8 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter9 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter10 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter11 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter12 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter13 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter14 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter15 = new DevExpress.DataAccess.Sql.QueryParameter();
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
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.pVerCompanyId = new DevExpress.XtraReports.Parameters.Parameter();
            this.pVerCompanyBase1Id = new DevExpress.XtraReports.Parameters.Parameter();
            this.pVerCompanyBase2Id = new DevExpress.XtraReports.Parameters.Parameter();
            this.pVerCompanyBase3Id = new DevExpress.XtraReports.Parameters.Parameter();
            this.pFMonth = new DevExpress.XtraReports.Parameters.Parameter();
            this.pFMonthBase1 = new DevExpress.XtraReports.Parameters.Parameter();
            this.pFMonthBase2 = new DevExpress.XtraReports.Parameters.Parameter();
            this.pFMonthBase3 = new DevExpress.XtraReports.Parameters.Parameter();
            this.pTMonth = new DevExpress.XtraReports.Parameters.Parameter();
            this.pTMonthBase1 = new DevExpress.XtraReports.Parameters.Parameter();
            this.pTMonthBase2 = new DevExpress.XtraReports.Parameters.Parameter();
            this.pTMonthBase3 = new DevExpress.XtraReports.Parameters.Parameter();
            this.pYear = new DevExpress.XtraReports.Parameters.Parameter();
            this.pType = new DevExpress.XtraReports.Parameters.Parameter();
            this.pCreated_User = new DevExpress.XtraReports.Parameters.Parameter();
            this.pVerCompanyName = new DevExpress.XtraReports.Parameters.Parameter();
            this.pVerCompanyBase1Name = new DevExpress.XtraReports.Parameters.Parameter();
            this.pVerCompanyBase2Name = new DevExpress.XtraReports.Parameters.Parameter();
            this.pVerCompanyBase3Name = new DevExpress.XtraReports.Parameters.Parameter();
            this.pTypeBase1 = new DevExpress.XtraReports.Parameters.Parameter();
            this.pTypeBase2 = new DevExpress.XtraReports.Parameters.Parameter();
            this.pTypeBase3 = new DevExpress.XtraReports.Parameters.Parameter();
            this.pYearBase1 = new DevExpress.XtraReports.Parameters.Parameter();
            this.pYearBase2 = new DevExpress.XtraReports.Parameters.Parameter();
            this.pYearBase3 = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
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
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(757.0001F, 25F);
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
            this.xrTableCell9,
            this.xrTableCell10});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SORTING]")});
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "xrTableCell1";
            this.xrTableCell1.Weight = 0.52083332061767584D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DESCRIPTION]")});
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "xrTableCell2";
            this.xrTableCell2.Weight = 1.4791666793823242D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SUBACCOUNT_ID]")});
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "xrTableCell3";
            this.xrTableCell3.Weight = 0.5D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL1]")});
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "xrTableCell4";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell4.TextFormatString = "{0:n1}";
            this.xrTableCell4.Weight = 0.71874999999999989D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL2]")});
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.Text = "xrTableCell5";
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell5.TextFormatString = "{0:n1}";
            this.xrTableCell5.Weight = 0.7604165649414063D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL3]")});
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.Text = "xrTableCell6";
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell6.TextFormatString = "{0:n1}";
            this.xrTableCell6.Weight = 0.7708331298828125D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL4]")});
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "xrTableCell7";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell7.TextFormatString = "{0:n1}";
            this.xrTableCell7.Weight = 0.750000305175781D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL5]")});
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.Text = "xrTableCell8";
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell8.TextFormatString = "{0:n1}";
            this.xrTableCell8.Weight = 0.60416809082031209D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL6]")});
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.Text = "xrTableCell9";
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell9.TextFormatString = "{0:n1}";
            this.xrTableCell9.Weight = 0.73958312988281216D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL7]")});
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.Text = "xrTableCell10";
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell10.TextFormatString = "{0:n1}";
            this.xrTableCell10.Weight = 0.72624999999999962D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 0F;
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
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12,
            this.xrLabel11,
            this.xrTable3,
            this.xrTable2,
            this.xrLabel2,
            this.xrLabel1});
            this.ReportHeader.HeightF = 263.3333F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(0F, 127.75F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(804.9997F, 23F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Kỳ báo cáo:";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(804.9999F, 23F);
            // 
            // xrTable3
            // 
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 238.3333F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(757.0001F, 25F);
            this.xrTable3.StylePriority.UseBorders = false;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell21,
            this.xrTableCell22,
            this.xrTableCell23,
            this.xrTableCell24,
            this.xrTableCell25,
            this.xrTableCell26,
            this.xrTableCell27,
            this.xrTableCell28,
            this.xrTableCell29,
            this.xrTableCell30});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.StylePriority.UseTextAlignment = false;
            this.xrTableCell21.Text = "A";
            this.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell21.Weight = 0.52083332061767584D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.StylePriority.UseTextAlignment = false;
            this.xrTableCell22.Text = "B";
            this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell22.Weight = 1.4791666793823242D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.StylePriority.UseTextAlignment = false;
            this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell23.Weight = 0.4999996948242188D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.StylePriority.UseTextAlignment = false;
            this.xrTableCell24.Text = "1";
            this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell24.Weight = 0.71875030517578131D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.StylePriority.UseTextAlignment = false;
            this.xrTableCell25.Text = "2";
            this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell25.Weight = 0.76041549007286946D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.StylePriority.UseTextAlignment = false;
            this.xrTableCell26.Text = "3";
            this.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell26.Weight = 0.77083327402883406D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.StylePriority.UseTextAlignment = false;
            this.xrTableCell27.Text = "4";
            this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell27.Weight = 0.75000018566972571D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.StylePriority.UseTextAlignment = false;
            this.xrTableCell28.Text = "(5 = 2/1)";
            this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell28.Weight = 0.60416921565439807D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.StylePriority.UseTextAlignment = false;
            this.xrTableCell29.Text = "(6 = 3/1)";
            this.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell29.Weight = 0.73958175321533126D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.StylePriority.UseTextAlignment = false;
            this.xrTableCell30.Text = "(7 = 4/3)";
            this.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell30.Weight = 0.72625007507834494D;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 192.5F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(757F, 45.83333F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UsePadding = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrTableCell13,
            this.xrTableCell14,
            this.xrTableCell15,
            this.xrTableCell16,
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrTableCell19,
            this.xrTableCell20});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.StylePriority.UseTextAlignment = false;
            this.xrTableCell11.Text = "STT";
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell11.Weight = 0.52083332061767584D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.StylePriority.UseTextAlignment = false;
            this.xrTableCell12.Text = "Description";
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell12.Weight = 1.4791666793823242D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.StylePriority.UseTextAlignment = false;
            this.xrTableCell13.Text = "Sub";
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell13.Weight = 0.5D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4});
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Text = "xrTableCell14";
            this.xrTableCell14.Weight = 0.7187500038327993D;
            // 
            // xrLabel4
            // 
            this.xrLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(71.87503F, 45.83333F);
            this.xrLabel4.StylePriority.UseBackColor = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5});
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Text = "xrTableCell15";
            this.xrTableCell15.Weight = 0.76041656494140619D;
            // 
            // xrLabel5
            // 
            this.xrLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(76.04166F, 45.83333F);
            this.xrLabel5.StylePriority.UseBackColor = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6});
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Text = "xrTableCell16";
            this.xrTableCell16.Weight = 0.77083343544188154D;
            // 
            // xrLabel6
            // 
            this.xrLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(77.08327F, 45.83333F);
            this.xrLabel6.StylePriority.UseBackColor = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel7});
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Text = "xrTableCell17";
            this.xrTableCell17.Weight = 0.75000030095969394D;
            // 
            // xrLabel7
            // 
            this.xrLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(75F, 45.8334F);
            this.xrLabel7.StylePriority.UseBackColor = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "xrLabel7";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel8});
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Text = "xrTableCell18";
            this.xrTableCell18.Weight = 0.60416807833362784D;
            // 
            // xrLabel8
            // 
            this.xrLabel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(60.41692F, 45.8334F);
            this.xrLabel8.StylePriority.UseBackColor = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "xrLabel8";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel9});
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Text = "xrTableCell19";
            this.xrTableCell19.Weight = 0.73958312305231733D;
            // 
            // xrLabel9
            // 
            this.xrLabel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(0.0001271566F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(73.95821F, 45.83333F);
            this.xrLabel9.StylePriority.UseBackColor = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "xrLabel9";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel10});
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Text = "xrTableCell20";
            this.xrTableCell20.Weight = 0.72624877197574356D;
            // 
            // xrLabel10
            // 
            this.xrLabel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(72.62497F, 43.83335F);
            this.xrLabel10.StylePriority.UseBackColor = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "xrLabel10";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 104.75F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(805.0001F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Hộ Thu - Chi:";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 71.33336F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(804.9998F, 33.41664F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "BÁO CÁO ĐÁNH GIÁ THỰC HIỆN KẾ HOẠCH";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "KTQT_Data_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "Report_RevCost_SosanhVersion";
            queryParameter1.Name = "@p_Year";
            queryParameter1.Type = typeof(decimal);
            queryParameter1.ValueInfo = "2018";
            queryParameter2.Name = "@p_Ver_Company_Id";
            queryParameter2.Type = typeof(decimal);
            queryParameter2.ValueInfo = "2";
            queryParameter3.Name = "@p_Ver_Company_Id_Base1";
            queryParameter3.Type = typeof(decimal);
            queryParameter3.ValueInfo = "140";
            queryParameter4.Name = "@p_Ver_Company_Id_Base2";
            queryParameter4.Type = typeof(decimal);
            queryParameter4.ValueInfo = "20";
            queryParameter5.Name = "@p_Ver_Company_Id_Base3";
            queryParameter5.Type = typeof(decimal);
            queryParameter5.ValueInfo = "8";
            queryParameter6.Name = "@p_Type";
            queryParameter6.Type = typeof(string);
            queryParameter6.ValueInfo = "P";
            queryParameter7.Name = "@p_fMonth";
            queryParameter7.Type = typeof(decimal);
            queryParameter7.ValueInfo = "1";
            queryParameter8.Name = "@p_fMonth_Base1";
            queryParameter8.Type = typeof(decimal);
            queryParameter8.ValueInfo = "1";
            queryParameter9.Name = "@p_fMonth_Base2";
            queryParameter9.Type = typeof(decimal);
            queryParameter9.ValueInfo = "1";
            queryParameter10.Name = "@p_fMonth_Base3";
            queryParameter10.Type = typeof(decimal);
            queryParameter10.ValueInfo = "1";
            queryParameter11.Name = "@p_toMonth";
            queryParameter11.Type = typeof(decimal);
            queryParameter11.ValueInfo = "12";
            queryParameter12.Name = "@p_toMonth_Base1";
            queryParameter12.Type = typeof(decimal);
            queryParameter12.ValueInfo = "12";
            queryParameter13.Name = "@p_toMonth_Base2";
            queryParameter13.Type = typeof(decimal);
            queryParameter13.ValueInfo = "12";
            queryParameter14.Name = "@p_toMonth_Base3";
            queryParameter14.Type = typeof(decimal);
            queryParameter14.ValueInfo = "12";
            queryParameter15.Name = "@pCreated_user";
            queryParameter15.Type = typeof(string);
            queryParameter15.ValueInfo = "TEST";
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.Parameters.Add(queryParameter4);
            storedProcQuery1.Parameters.Add(queryParameter5);
            storedProcQuery1.Parameters.Add(queryParameter6);
            storedProcQuery1.Parameters.Add(queryParameter7);
            storedProcQuery1.Parameters.Add(queryParameter8);
            storedProcQuery1.Parameters.Add(queryParameter9);
            storedProcQuery1.Parameters.Add(queryParameter10);
            storedProcQuery1.Parameters.Add(queryParameter11);
            storedProcQuery1.Parameters.Add(queryParameter12);
            storedProcQuery1.Parameters.Add(queryParameter13);
            storedProcQuery1.Parameters.Add(queryParameter14);
            storedProcQuery1.Parameters.Add(queryParameter15);
            storedProcQuery1.StoredProcName = "Report_RevCost_SosanhVersion";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // pVerCompanyId
            // 
            this.pVerCompanyId.Description = "pVerCompanyId";
            this.pVerCompanyId.Name = "pVerCompanyId";
            this.pVerCompanyId.Type = typeof(int);
            this.pVerCompanyId.ValueInfo = "2";
            this.pVerCompanyId.Visible = false;
            // 
            // pVerCompanyBase1Id
            // 
            this.pVerCompanyBase1Id.Description = "pVerCompanyBase1Id";
            this.pVerCompanyBase1Id.Name = "pVerCompanyBase1Id";
            this.pVerCompanyBase1Id.Type = typeof(int);
            this.pVerCompanyBase1Id.ValueInfo = "140";
            this.pVerCompanyBase1Id.Visible = false;
            // 
            // pVerCompanyBase2Id
            // 
            this.pVerCompanyBase2Id.Description = "pVerCompanyBase2Id";
            this.pVerCompanyBase2Id.Name = "pVerCompanyBase2Id";
            this.pVerCompanyBase2Id.Type = typeof(int);
            this.pVerCompanyBase2Id.ValueInfo = "242";
            this.pVerCompanyBase2Id.Visible = false;
            // 
            // pVerCompanyBase3Id
            // 
            this.pVerCompanyBase3Id.Description = "pVerCompanyBase3Id";
            this.pVerCompanyBase3Id.Name = "pVerCompanyBase3Id";
            this.pVerCompanyBase3Id.Type = typeof(int);
            this.pVerCompanyBase3Id.ValueInfo = "0";
            this.pVerCompanyBase3Id.Visible = false;
            // 
            // pFMonth
            // 
            this.pFMonth.Description = "pFMonth";
            this.pFMonth.Name = "pFMonth";
            this.pFMonth.Type = typeof(int);
            this.pFMonth.ValueInfo = "1";
            this.pFMonth.Visible = false;
            // 
            // pFMonthBase1
            // 
            this.pFMonthBase1.Description = "pFMonthBase1";
            this.pFMonthBase1.Name = "pFMonthBase1";
            this.pFMonthBase1.Type = typeof(int);
            this.pFMonthBase1.ValueInfo = "1";
            this.pFMonthBase1.Visible = false;
            // 
            // pFMonthBase2
            // 
            this.pFMonthBase2.Description = "pFMonthBase2";
            this.pFMonthBase2.Name = "pFMonthBase2";
            this.pFMonthBase2.Type = typeof(int);
            this.pFMonthBase2.ValueInfo = "1";
            this.pFMonthBase2.Visible = false;
            // 
            // pFMonthBase3
            // 
            this.pFMonthBase3.Description = "pFMonthBase3";
            this.pFMonthBase3.Name = "pFMonthBase3";
            this.pFMonthBase3.Type = typeof(int);
            this.pFMonthBase3.ValueInfo = "1";
            this.pFMonthBase3.Visible = false;
            // 
            // pTMonth
            // 
            this.pTMonth.Description = "pTMonth";
            this.pTMonth.Name = "pTMonth";
            this.pTMonth.Type = typeof(int);
            this.pTMonth.ValueInfo = "12";
            this.pTMonth.Visible = false;
            // 
            // pTMonthBase1
            // 
            this.pTMonthBase1.Description = "pTMonthBase1";
            this.pTMonthBase1.Name = "pTMonthBase1";
            this.pTMonthBase1.Type = typeof(int);
            this.pTMonthBase1.ValueInfo = "12";
            this.pTMonthBase1.Visible = false;
            // 
            // pTMonthBase2
            // 
            this.pTMonthBase2.Description = "pTMonthBase2";
            this.pTMonthBase2.Name = "pTMonthBase2";
            this.pTMonthBase2.Type = typeof(int);
            this.pTMonthBase2.ValueInfo = "12";
            this.pTMonthBase2.Visible = false;
            // 
            // pTMonthBase3
            // 
            this.pTMonthBase3.Description = "pTMonthBase3";
            this.pTMonthBase3.Name = "pTMonthBase3";
            this.pTMonthBase3.Type = typeof(int);
            this.pTMonthBase3.ValueInfo = "12";
            this.pTMonthBase3.Visible = false;
            // 
            // pYear
            // 
            this.pYear.Description = "pYear";
            this.pYear.Name = "pYear";
            this.pYear.Type = typeof(int);
            this.pYear.ValueInfo = "2019";
            this.pYear.Visible = false;
            // 
            // pType
            // 
            this.pType.Description = "Parameter1";
            this.pType.Name = "pType";
            this.pType.ValueInfo = "P";
            this.pType.Visible = false;
            // 
            // pCreated_User
            // 
            this.pCreated_User.Description = "pCreated_User";
            this.pCreated_User.Name = "pCreated_User";
            this.pCreated_User.ValueInfo = "TEST";
            this.pCreated_User.Visible = false;
            // 
            // pVerCompanyName
            // 
            this.pVerCompanyName.Description = "pVerCompanyName";
            this.pVerCompanyName.Name = "pVerCompanyName";
            this.pVerCompanyName.Visible = false;
            // 
            // pVerCompanyBase1Name
            // 
            this.pVerCompanyBase1Name.Description = "pVerCompanyBase1Name";
            this.pVerCompanyBase1Name.Name = "pVerCompanyBase1Name";
            this.pVerCompanyBase1Name.Visible = false;
            // 
            // pVerCompanyBase2Name
            // 
            this.pVerCompanyBase2Name.Description = "pVerCompanyBase2Name";
            this.pVerCompanyBase2Name.Name = "pVerCompanyBase2Name";
            this.pVerCompanyBase2Name.Visible = false;
            // 
            // pVerCompanyBase3Name
            // 
            this.pVerCompanyBase3Name.Description = "pVerCompanyBase3Name";
            this.pVerCompanyBase3Name.Name = "pVerCompanyBase3Name";
            this.pVerCompanyBase3Name.Visible = false;
            // 
            // pTypeBase1
            // 
            this.pTypeBase1.Description = "pTypeBase1";
            this.pTypeBase1.Name = "pTypeBase1";
            this.pTypeBase1.Visible = false;
            // 
            // pTypeBase2
            // 
            this.pTypeBase2.Description = "pTypeBase2";
            this.pTypeBase2.Name = "pTypeBase2";
            this.pTypeBase2.Visible = false;
            // 
            // pTypeBase3
            // 
            this.pTypeBase3.Description = "pTypeBase3";
            this.pTypeBase3.Name = "pTypeBase3";
            this.pTypeBase3.Visible = false;
            // 
            // pYearBase1
            // 
            this.pYearBase1.Description = "pYearBase1";
            this.pYearBase1.Name = "pYearBase1";
            this.pYearBase1.Type = typeof(int);
            this.pYearBase1.ValueInfo = "0";
            this.pYearBase1.Visible = false;
            // 
            // pYearBase2
            // 
            this.pYearBase2.Description = "pYearBase2";
            this.pYearBase2.Name = "pYearBase2";
            this.pYearBase2.Type = typeof(int);
            this.pYearBase2.ValueInfo = "0";
            this.pYearBase2.Visible = false;
            // 
            // pYearBase3
            // 
            this.pYearBase3.Description = "Parameter3";
            this.pYearBase3.Name = "pYearBase3";
            this.pYearBase3.Type = typeof(int);
            this.pYearBase3.ValueInfo = "0";
            this.pYearBase3.Visible = false;
            // 
            // RevCost_SoSanhThuChi_VerCompany
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Report_RevCost_SosanhVersion";
            this.DataSource = this.sqlDataSource1;
            this.Margins = new System.Drawing.Printing.Margins(22, 23, 0, 100);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.pVerCompanyId,
            this.pVerCompanyBase1Id,
            this.pVerCompanyBase2Id,
            this.pVerCompanyBase3Id,
            this.pFMonth,
            this.pFMonthBase1,
            this.pFMonthBase2,
            this.pFMonthBase3,
            this.pTMonth,
            this.pTMonthBase1,
            this.pTMonthBase2,
            this.pTMonthBase3,
            this.pYear,
            this.pType,
            this.pCreated_User,
            this.pVerCompanyName,
            this.pVerCompanyBase1Name,
            this.pVerCompanyBase2Name,
            this.pVerCompanyBase3Name,
            this.pTypeBase1,
            this.pTypeBase2,
            this.pTypeBase3,
            this.pYearBase1,
            this.pYearBase2,
            this.pYearBase3});
            this.Version = "17.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion

    protected override void OnBeforePrint(System.Drawing.Printing.PrintEventArgs e)
    {
        base.OnBeforePrint(e);

        int pYear = Convert.ToInt32(this.Parameters["pYear"].Value);
        int pYearBase1 = Convert.ToInt32(this.Parameters["pYearBase1"].Value);
        int pYearBase2 = Convert.ToInt32(this.Parameters["pYearBase2"].Value);
        int pYearBase3 = Convert.ToInt32(this.Parameters["pYearBase3"].Value);

        string pType = this.Parameters["pType"].Value.ToString();
        string pTypeBase1 = this.Parameters["pTypeBase1"].Value.ToString();
        string pTypeBase2 = this.Parameters["pTypeBase2"].Value.ToString();
        string pTypeBase3 = this.Parameters["pTypeBase3"].Value.ToString();


        int pFMonth = Convert.ToInt32(this.Parameters["pFMonth"].Value);
        int pFMonthBase1 = Convert.ToInt32(this.Parameters["pFMonthBase1"].Value);
        int pFMonthBase2 = Convert.ToInt32(this.Parameters["pFMonthBase2"].Value);
        int pFMonthBase3 = Convert.ToInt32(this.Parameters["pFMonthBase3"].Value);

        int pTMonth = Convert.ToInt32(this.Parameters["pTMonth"].Value);
        int pTMonthBase1 = Convert.ToInt32(this.Parameters["pTMonthBase1"].Value);
        int pTMonthBase2 = Convert.ToInt32(this.Parameters["pTMonthBase2"].Value);
        int pTMonthBase3 = Convert.ToInt32(this.Parameters["pTMonthBase3"].Value);

        int pVerCompanyId = Convert.ToInt32(this.Parameters["pVerCompanyId"].Value);
        int pVerCompanyBase1Id = Convert.ToInt32(this.Parameters["pVerCompanyBase1Id"].Value);
        int pVerCompanyBase2Id = Convert.ToInt32(this.Parameters["pVerCompanyBase2Id"].Value);
        int pVerCompanyBase3Id = Convert.ToInt32(this.Parameters["pVerCompanyBase3Id"].Value);

        string pVerCompanyName = this.Parameters["pVerCompanyName"].Value.ToString();
        string pVerCompanyBase1Name = this.Parameters["pVerCompanyBase1Name"].Value.ToString();
        string pVerCompanyBase2Name =this.Parameters["pVerCompanyBase2Name"].Value.ToString();
        string pVerCompanyBase3Name = this.Parameters["pVerCompanyBase3Name"].Value.ToString();





        xrLabel1.Text = "BÁO CÁO ĐÁNH GIÁ THỰC HIỆN KẾ HOẠCH NĂM " + pYear;
        xrLabel2.Text = "Hộ Thu - Chi:" + pVerCompanyName;
        xrLabel12.Text = "Kỳ báo cáo:";

        xrLabel4.Text = pVerCompanyBase3Name;
        xrLabel5.Text = pVerCompanyBase2Name;
        xrLabel6.Text = pVerCompanyBase1Name;
        xrLabel7.Text = pVerCompanyName;
        xrLabel8.Text = pVerCompanyBase2Name + "/" + pVerCompanyBase3Name;
        xrLabel9.Text = pVerCompanyBase1Name + "/" + pVerCompanyBase3Name;
        xrLabel10.Text = pVerCompanyName + "/" + pVerCompanyBase1Name;
    }
}
