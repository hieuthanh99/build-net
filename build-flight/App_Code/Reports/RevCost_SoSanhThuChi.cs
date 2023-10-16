using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for RevCost_SoSanhThuChi
/// </summary>
public class RevCost_SoSanhThuChi : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
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
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private DevExpress.XtraReports.Parameters.Parameter p_Year;
    private DevExpress.XtraReports.Parameters.Parameter p_Ver_Company_Id;
    private DevExpress.XtraReports.Parameters.Parameter p_Ver_Company_Id_Base1;
    private DevExpress.XtraReports.Parameters.Parameter p_Ver_Company_Id_Base2;
    private DevExpress.XtraReports.Parameters.Parameter p_Ver_Company_Id_Base3;
    private DevExpress.XtraReports.Parameters.Parameter p_Type;
    private DevExpress.XtraReports.Parameters.Parameter p_fMonth;
    private DevExpress.XtraReports.Parameters.Parameter p_fMonth_Base1;
    private DevExpress.XtraReports.Parameters.Parameter p_fMonth_Base2;
    private DevExpress.XtraReports.Parameters.Parameter p_fMonth_Base3;
    private DevExpress.XtraReports.Parameters.Parameter p_toMonth;
    private DevExpress.XtraReports.Parameters.Parameter p_toMonth_Base1;
    private DevExpress.XtraReports.Parameters.Parameter p_toMonth_Base2;
    private DevExpress.XtraReports.Parameters.Parameter p_toMonth_Base3;
    private DevExpress.XtraReports.Parameters.Parameter pCreated_user;
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
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
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
    private XRLabel xrLabel10;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public RevCost_SoSanhThuChi()
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
            string resourceFileName = "RevCost_SoSanhThuChi.resx";
            System.Resources.ResourceManager resources = global::Resources.RevCost_SoSanhThuChi.ResourceManager;
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
            DevExpress.DataAccess.Sql.QueryParameter queryParameter16 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter17 = new DevExpress.DataAccess.Sql.QueryParameter();
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
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
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
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.p_Year = new DevExpress.XtraReports.Parameters.Parameter();
            this.p_Ver_Company_Id = new DevExpress.XtraReports.Parameters.Parameter();
            this.p_Ver_Company_Id_Base1 = new DevExpress.XtraReports.Parameters.Parameter();
            this.p_Ver_Company_Id_Base2 = new DevExpress.XtraReports.Parameters.Parameter();
            this.p_Ver_Company_Id_Base3 = new DevExpress.XtraReports.Parameters.Parameter();
            this.p_Type = new DevExpress.XtraReports.Parameters.Parameter();
            this.p_fMonth = new DevExpress.XtraReports.Parameters.Parameter();
            this.p_fMonth_Base1 = new DevExpress.XtraReports.Parameters.Parameter();
            this.p_fMonth_Base2 = new DevExpress.XtraReports.Parameters.Parameter();
            this.p_fMonth_Base3 = new DevExpress.XtraReports.Parameters.Parameter();
            this.p_toMonth = new DevExpress.XtraReports.Parameters.Parameter();
            this.p_toMonth_Base1 = new DevExpress.XtraReports.Parameters.Parameter();
            this.p_toMonth_Base2 = new DevExpress.XtraReports.Parameters.Parameter();
            this.p_toMonth_Base3 = new DevExpress.XtraReports.Parameters.Parameter();
            this.pCreated_user = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.HeightF = 100F;
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
            this.xrTable1.SizeF = new System.Drawing.SizeF(751.0001F, 25F);
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
            this.xrTableCell1.Weight = 0.49999981627447171D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DESCRIPTION]")});
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "xrTableCell2";
            this.xrTableCell2.Weight = 1.9062503880747084D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SUBACCOUNT_ID]")});
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "xrTableCell3";
            this.xrTableCell3.Weight = 0.38541641343186511D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL1]")});
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "xrTableCell4";
            this.xrTableCell4.TextFormatString = "{0:n1}";
            this.xrTableCell4.Weight = 0.66666688359670623D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL2]")});
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "xrTableCell5";
            this.xrTableCell5.TextFormatString = "{0:n1}";
            this.xrTableCell5.Weight = 0.77083283764733568D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL3]")});
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "xrTableCell6";
            this.xrTableCell6.TextFormatString = "{0:n1}";
            this.xrTableCell6.Weight = 0.61458313473543291D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL4]")});
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "xrTableCell7";
            this.xrTableCell7.TextFormatString = "{0:n1}";
            this.xrTableCell7.Weight = 0.71875001024443086D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL5]")});
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "xrTableCell8";
            this.xrTableCell8.TextFormatString = "{0:n1}";
            this.xrTableCell8.Weight = 0.71874943803981184D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL6]")});
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Text = "xrTableCell9";
            this.xrTableCell9.TextFormatString = "{0:n1}";
            this.xrTableCell9.Weight = 0.53124996239221645D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL7]")});
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Text = "xrTableCell10";
            this.xrTableCell10.TextFormatString = "{0:n1}";
            this.xrTableCell10.Weight = 0.69750211464183831D;
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
            this.xrLabel2,
            this.xrLabel1,
            this.xrTable2});
            this.ReportHeader.HeightF = 272.9167F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(199.1386F, 48.54166F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(551.8613F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(199.1386F, 10.00001F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(551.8615F, 38.54166F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 87.5F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2,
            this.xrTableRow3});
            this.xrTable2.SizeF = new System.Drawing.SizeF(751F, 185.4167F);
            this.xrTable2.StylePriority.UseBorders = false;
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
            this.xrTableCell11.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel10});
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.StylePriority.UseTextAlignment = false;
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell11.Weight = 0.19973352995700311D;
            // 
            // xrLabel10
            // 
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00002F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(49.99998F, 23F);
            this.xrLabel10.Text = "STT";
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel11});
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.StylePriority.UseTextAlignment = false;
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell12.Weight = 0.761484848694185D;
            // 
            // xrLabel11
            // 
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(1.589457E-05F, 10.00002F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(190.625F, 23F);
            this.xrLabel11.Text = "Description";
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12});
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.StylePriority.UseTextAlignment = false;
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell13.Weight = 0.15396125039975561D;
            // 
            // xrLabel12
            // 
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00002F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(38.5416F, 23F);
            this.xrLabel12.Text = "Sub";
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3});
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Weight = 0.26631161067701359D;
            // 
            // xrLabel3
            // 
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(66.66657F, 82.70833F);
            this.xrLabel3.Text = "xrLabel3";
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4});
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Weight = 0.30792238113847276D;
            // 
            // xrLabel4
            // 
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(77.08327F, 82.70833F);
            this.xrLabel4.Text = "xrLabel4";
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5});
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Weight = 0.24550598163079479D;
            // 
            // xrLabel5
            // 
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(61.4583F, 82.70833F);
            this.xrLabel5.Text = "xrLabel5";
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6});
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Weight = 0.28711723972323239D;
            // 
            // xrLabel6
            // 
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(71.87503F, 82.70833F);
            this.xrLabel6.Text = "xrLabel6";
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel7});
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Weight = 0.28711723972323239D;
            // 
            // xrLabel7
            // 
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(71.87487F, 82.70833F);
            this.xrLabel7.Text = "xrLabel7";
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel8});
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Weight = 0.21221650910979867D;
            // 
            // xrLabel8
            // 
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(53.12487F, 82.70833F);
            this.xrLabel8.Text = "xrLabel8";
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel9});
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Weight = 0.27862892505801518D;
            // 
            // xrLabel9
            // 
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(69.75002F, 82.70833F);
            this.xrLabel9.Text = "xrLabel9";
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
            this.xrTableCell21.Weight = 0.19973352995700311D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.StylePriority.UseTextAlignment = false;
            this.xrTableCell22.Text = "B";
            this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell22.Weight = 0.761484848694185D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.StylePriority.UseTextAlignment = false;
            this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell23.Weight = 0.15396125039975561D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.StylePriority.UseTextAlignment = false;
            this.xrTableCell24.Text = "1";
            this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell24.Weight = 0.26631161067701359D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.StylePriority.UseTextAlignment = false;
            this.xrTableCell25.Text = "2";
            this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell25.Weight = 0.30792238113847276D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.StylePriority.UseTextAlignment = false;
            this.xrTableCell26.Text = "3";
            this.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell26.Weight = 0.24550598163079479D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.StylePriority.UseTextAlignment = false;
            this.xrTableCell27.Text = "4";
            this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell27.Weight = 0.28711723972323239D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.StylePriority.UseTextAlignment = false;
            this.xrTableCell28.Text = "5";
            this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell28.Weight = 0.28711723972323239D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.StylePriority.UseTextAlignment = false;
            this.xrTableCell29.Text = "6";
            this.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell29.Weight = 0.21221650910979867D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.StylePriority.UseTextAlignment = false;
            this.xrTableCell30.Text = "7";
            this.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell30.Weight = 0.27862892505801518D;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "KTQT_Data_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "Report_RevCost_SosanhVersion";
            queryParameter1.Name = "@p_Year";
            queryParameter1.Type = typeof(decimal);
            queryParameter1.ValueInfo = "2019";
            queryParameter2.Name = "@p_Ver_Company_Id";
            queryParameter2.Type = typeof(decimal);
            queryParameter2.ValueInfo = "140";
            queryParameter3.Name = "@p_Ver_Company_Id_Base1";
            queryParameter3.Type = typeof(decimal);
            queryParameter3.ValueInfo = "0";
            queryParameter4.Name = "@p_Ver_Company_Id_Base2";
            queryParameter4.Type = typeof(decimal);
            queryParameter4.ValueInfo = "0";
            queryParameter5.Name = "@p_Ver_Company_Id_Base3";
            queryParameter5.Type = typeof(decimal);
            queryParameter5.ValueInfo = "0";
            queryParameter6.Name = "@p_Company_Id";
            queryParameter6.Type = typeof(decimal);
            queryParameter6.ValueInfo = "0";
            queryParameter7.Name = "@p_Curr";
            queryParameter7.Type = typeof(string);
            queryParameter8.Name = "@p_Type";
            queryParameter8.Type = typeof(string);
            queryParameter9.Name = "@p_fMonth";
            queryParameter9.Type = typeof(decimal);
            queryParameter9.ValueInfo = "0";
            queryParameter10.Name = "@p_fMonth_Base1";
            queryParameter10.Type = typeof(decimal);
            queryParameter10.ValueInfo = "0";
            queryParameter11.Name = "@p_fMonth_Base2";
            queryParameter11.Type = typeof(decimal);
            queryParameter11.ValueInfo = "0";
            queryParameter12.Name = "@p_fMonth_Base3";
            queryParameter12.Type = typeof(decimal);
            queryParameter12.ValueInfo = "0";
            queryParameter13.Name = "@p_toMonth";
            queryParameter13.Type = typeof(decimal);
            queryParameter13.ValueInfo = "0";
            queryParameter14.Name = "@p_toMonth_Base1";
            queryParameter14.Type = typeof(decimal);
            queryParameter14.ValueInfo = "0";
            queryParameter15.Name = "@p_toMonth_Base2";
            queryParameter15.Type = typeof(decimal);
            queryParameter15.ValueInfo = "0";
            queryParameter16.Name = "@p_toMonth_Base3";
            queryParameter16.Type = typeof(decimal);
            queryParameter16.ValueInfo = "0";
            queryParameter17.Name = "@pCreated_user";
            queryParameter17.Type = typeof(string);
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
            storedProcQuery1.Parameters.Add(queryParameter16);
            storedProcQuery1.Parameters.Add(queryParameter17);
            storedProcQuery1.StoredProcName = "Report_RevCost_SosanhVersion";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // p_Year
            // 
            this.p_Year.Description = "p_Year";
            this.p_Year.Name = "p_Year";
            this.p_Year.Type = typeof(int);
            this.p_Year.ValueInfo = "2019";
            // 
            // p_Ver_Company_Id
            // 
            this.p_Ver_Company_Id.Description = "p_Ver_Company_Id";
            this.p_Ver_Company_Id.Name = "p_Ver_Company_Id";
            this.p_Ver_Company_Id.Type = typeof(int);
            this.p_Ver_Company_Id.ValueInfo = "2";
            // 
            // p_Ver_Company_Id_Base1
            // 
            this.p_Ver_Company_Id_Base1.Description = "p_Ver_Company_Id_Base1";
            this.p_Ver_Company_Id_Base1.Name = "p_Ver_Company_Id_Base1";
            this.p_Ver_Company_Id_Base1.Type = typeof(int);
            this.p_Ver_Company_Id_Base1.ValueInfo = "140";
            // 
            // p_Ver_Company_Id_Base2
            // 
            this.p_Ver_Company_Id_Base2.Description = "p_Ver_Company_Id_Base2";
            this.p_Ver_Company_Id_Base2.Name = "p_Ver_Company_Id_Base2";
            this.p_Ver_Company_Id_Base2.Type = typeof(int);
            this.p_Ver_Company_Id_Base2.ValueInfo = "242";
            // 
            // p_Ver_Company_Id_Base3
            // 
            this.p_Ver_Company_Id_Base3.Description = "p_Ver_Company_Id_Base3";
            this.p_Ver_Company_Id_Base3.Name = "p_Ver_Company_Id_Base3";
            this.p_Ver_Company_Id_Base3.Type = typeof(int);
            this.p_Ver_Company_Id_Base3.ValueInfo = "0";
            // 
            // p_Type
            // 
            this.p_Type.Description = "p_Type";
            this.p_Type.Name = "p_Type";
            this.p_Type.Type = typeof(int);
            this.p_Type.ValueInfo = "0";
            // 
            // p_fMonth
            // 
            this.p_fMonth.Description = "p_fMonth";
            this.p_fMonth.Name = "p_fMonth";
            this.p_fMonth.Type = typeof(int);
            this.p_fMonth.ValueInfo = "1";
            // 
            // p_fMonth_Base1
            // 
            this.p_fMonth_Base1.Description = "p_fMonth_Base1";
            this.p_fMonth_Base1.Name = "p_fMonth_Base1";
            this.p_fMonth_Base1.Type = typeof(int);
            this.p_fMonth_Base1.ValueInfo = "1";
            // 
            // p_fMonth_Base2
            // 
            this.p_fMonth_Base2.Description = "p_fMonth_Base2";
            this.p_fMonth_Base2.Name = "p_fMonth_Base2";
            this.p_fMonth_Base2.Type = typeof(int);
            this.p_fMonth_Base2.ValueInfo = "1";
            // 
            // p_fMonth_Base3
            // 
            this.p_fMonth_Base3.Description = "p_fMonth_Base3";
            this.p_fMonth_Base3.Name = "p_fMonth_Base3";
            this.p_fMonth_Base3.Type = typeof(int);
            this.p_fMonth_Base3.ValueInfo = "1";
            // 
            // p_toMonth
            // 
            this.p_toMonth.Description = "p_toMonth";
            this.p_toMonth.Name = "p_toMonth";
            this.p_toMonth.Type = typeof(int);
            this.p_toMonth.ValueInfo = "12";
            // 
            // p_toMonth_Base1
            // 
            this.p_toMonth_Base1.Description = "p_toMonth_Base1";
            this.p_toMonth_Base1.Name = "p_toMonth_Base1";
            this.p_toMonth_Base1.Type = typeof(int);
            this.p_toMonth_Base1.ValueInfo = "12";
            // 
            // p_toMonth_Base2
            // 
            this.p_toMonth_Base2.Description = "p_toMonth_Base2";
            this.p_toMonth_Base2.Name = "p_toMonth_Base2";
            this.p_toMonth_Base2.Type = typeof(int);
            this.p_toMonth_Base2.ValueInfo = "12";
            // 
            // p_toMonth_Base3
            // 
            this.p_toMonth_Base3.Description = "p_toMonth_Base3";
            this.p_toMonth_Base3.Name = "p_toMonth_Base3";
            this.p_toMonth_Base3.Type = typeof(int);
            this.p_toMonth_Base3.ValueInfo = "12";
            // 
            // pCreated_user
            // 
            this.pCreated_user.Description = "pCreated_user";
            this.pCreated_user.Name = "pCreated_user";
            this.pCreated_user.ValueInfo = "TEST";
            // 
            // RevCost_SoSanhThuChi
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
            this.Margins = new System.Drawing.Printing.Margins(51, 48, 0, 100);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.p_Year,
            this.p_Ver_Company_Id,
            this.p_Ver_Company_Id_Base1,
            this.p_Ver_Company_Id_Base2,
            this.p_Ver_Company_Id_Base3,
            this.p_Type,
            this.p_fMonth,
            this.p_fMonth_Base1,
            this.p_fMonth_Base2,
            this.p_fMonth_Base3,
            this.p_toMonth,
            this.p_toMonth_Base1,
            this.p_toMonth_Base2,
            this.p_toMonth_Base3,
            this.pCreated_user});
            this.Version = "17.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion

    protected override void OnBeforePrint(System.Drawing.Printing.PrintEventArgs e)
    {
        base.OnBeforePrint(e);
        //int year = Convert.ToInt32(this.Parameters["pYear"].Value);
        //string VerType = this.Parameters["pType"].Value.ToString();
        //string Title = string.Empty;
        //string titleCompany = string.Empty;
        //if (VerType.ToUpper() == "P")
        //{
        //    Title = "KẾ HOẠCH THU - CHI NĂM ";
        //    titleCompany = "Kế hoạch Năm ";
        //}
        //else if (VerType.ToUpper() == "E")
        //{
        //    Title = "ƯỚC THỰC HIỆN THU - CHI NĂM ";
        //    titleCompany = "Ước thực hiện Năm ";
        //}
        //else if (VerType.ToUpper() == "A")
        //{
        //    Title = "THỰC HIỆN THU - CHI NĂM ";
        //    titleCompany = "Thực hiện Năm ";
        //}
        //xrLabel1.Text = "KẾ HOẠCH DOANH TU - CHI PHÍ " + year;
        //xrLabel2.Text = "Hộ chi phí: " + year;
        //xrLabel3.Text = titleCompany + year;
    }
}
