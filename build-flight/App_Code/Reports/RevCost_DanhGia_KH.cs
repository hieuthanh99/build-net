using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using KHNNData;
using System.Linq;

/// <summary>
/// Summary description for RevCost_DanhGia_KH
/// </summary>
public class RevCost_DanhGia_KH : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell21;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private DevExpress.XtraReports.Parameters.Parameter pCreated_user;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell7;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell38;
    private XRTableCell xrTableCell39;
    private XRTableCell xrTableCell40;
    private XRTableCell xrTableCell41;
    private XRTableCell xrTableCell42;
    private XRTableCell xrTableCell43;
    private XRTableCell xrTableCell45;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell46;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell47;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell33;
    private XRTableCell xrTableCell36;
    private XRTableCell xrTableCell48;
    private XRTableCell xrTableCell8;
    private XRTable xrTable2;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell44;
    private XRTableCell xrTableCell49;
    private XRTableCell xrTableCell50;
    private XRTableCell xrTableCell51;
    private XRTableCell xrTableCell52;
    private XRTableCell xrTableCell53;
    private XRTableCell xrTableCell54;
    private XRTableCell xrTableCell55;
    private XRTableCell xrTableCell56;
    private XRLabel xrLabel5;
    private DevExpress.XtraReports.Parameters.Parameter p_Ver_Company_Id;
    private DevExpress.XtraReports.Parameters.Parameter p_fMonth;
    private DevExpress.XtraReports.Parameters.Parameter p_toMonth;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public RevCost_DanhGia_KH()
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

    protected override void OnBeforePrint(System.Drawing.Printing.PrintEventArgs e)
    {
        base.OnBeforePrint(e);

        int VerCompanyID;
        int VerCompanyBase1ID;
        int VerCompanyBase2ID;

        int FMonth;
        int FMonthBase1;
        int FMonthBase2;
        int TMonth;
        int TMonthBase1;
        int TMonthBase2;

        try
        {

            VerCompanyID = Convert.ToInt32(this.Parameters["p_Ver_Company_Id"].Value);

            FMonth = Convert.ToInt32(this.Parameters["p_fMonth"].Value);
            TMonth = Convert.ToInt32(this.Parameters["p_toMonth"].Value);


            using (QLKHDataEntities entites = new QLKHDataEntities())
            {
                var aVersionCompany = entites.VersionCompanies.SingleOrDefault(x => x.VerCompanyID == VerCompanyID);
                if (aVersionCompany != null)
                {
                    xrLabel1.Text = "CÔNG TY DỊCH VỤ MẶT ĐẤT SÂN BAY VIỆT NAM";
                    var aVersion = entites.Versions.SingleOrDefault(x => x.VersionID == aVersionCompany.VersionID);
                    var aCompany = entites.Companies.SingleOrDefault(x => x.CompanyID == aVersionCompany.CompanyID);
                   
                    xrLabel2.Text = "BÁO CÁO ĐÁNH GIÁ THỰC HIỆN KẾ HOẠCH NĂM " + aVersion.VersionYear.ToString();
                    xrLabel3.Text = "Hộ Kế Hoạch: " + aCompany.AreaCode.ToUpper() + "-" + aCompany.NameV;
                    xrLabel4.Text = "Kỳ báo cáo: Từ tháng " + FMonth + " đến: " + TMonth;
                    xrTableCell3.Text = "Số thực hiện cùng kỳ năm trước từ tháng:" + FMonth + "-" + TMonth;
                    xrTableCell41.Text = "Kế hoạch phân kỳ từ tháng:" + FMonth + "-" + TMonth;
                    xrTableCell42.Text = "Thực hiện từ tháng:" + FMonth + "-" + TMonth;
                }

            }
        }
        catch (Exception) { }

        
    }

	#region Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
            string resourceFileName = "RevCost_DanhGia_KH.resx";
            System.Resources.ResourceManager resources = global::Resources.RevCost_DanhGia_KH.ResourceManager;
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell53 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell54 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell55 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell56 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.pCreated_user = new DevExpress.XtraReports.Parameters.Parameter();
            this.p_Ver_Company_Id = new DevExpress.XtraReports.Parameters.Parameter();
            this.p_fMonth = new DevExpress.XtraReports.Parameters.Parameter();
            this.p_toMonth = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable3
            // 
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(1.5F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(1102.5F, 25F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UsePadding = false;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell19,
            this.xrTableCell20,
            this.xrTableCell21,
            this.xrTableCell22,
            this.xrTableCell23,
            this.xrTableCell24,
            this.xrTableCell25,
            this.xrTableCell26,
            this.xrTableCell27,
            this.xrTableCell53,
            this.xrTableCell54,
            this.xrTableCell55,
            this.xrTableCell56});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SORTING]")});
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Text = "xrTableCell19";
            this.xrTableCell19.Weight = 0.4650017616856118D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DESCRIPTION]")});
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Text = "xrTableCell20";
            this.xrTableCell20.Weight = 1.9916667852065881D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL1]")});
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.StylePriority.UseTextAlignment = false;
            this.xrTableCell21.Text = "xrTableCell21";
            this.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell21.TextFormatString = "{0:n1}";
            this.xrTableCell21.Weight = 0.71666786193836463D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL2]")});
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.StylePriority.UseTextAlignment = false;
            this.xrTableCell22.Text = "xrTableCell22";
            this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell22.TextFormatString = "{0:n1}";
            this.xrTableCell22.Weight = 1.0288180292376496D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL3]")});
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.StylePriority.UseTextAlignment = false;
            this.xrTableCell23.Text = "xrTableCell23";
            this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell23.TextFormatString = "{0:n1}";
            this.xrTableCell23.Weight = 0.86979273366439358D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL4]")});
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.StylePriority.UseTextAlignment = false;
            this.xrTableCell24.Text = "xrTableCell24";
            this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell24.TextFormatString = "{0:n1}";
            this.xrTableCell24.Weight = 0.77013849575968651D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL5]")});
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.StylePriority.UseTextAlignment = false;
            this.xrTableCell25.Text = "xrTableCell25";
            this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell25.TextFormatString = "{0:n1}";
            this.xrTableCell25.Weight = 0.86624745857158325D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL6]")});
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.StylePriority.UseTextAlignment = false;
            this.xrTableCell26.Text = "xrTableCell26";
            this.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell26.TextFormatString = "{0:n1}";
            this.xrTableCell26.Weight = 0.55736323151301459D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL7]")});
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.StylePriority.UseTextAlignment = false;
            this.xrTableCell27.Text = "xrTableCell27";
            this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell27.TextFormatString = "{0:n1}";
            this.xrTableCell27.Weight = 0.89201232839446165D;
            // 
            // xrTableCell53
            // 
            this.xrTableCell53.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL8]")});
            this.xrTableCell53.Name = "xrTableCell53";
            this.xrTableCell53.StylePriority.UseTextAlignment = false;
            this.xrTableCell53.Text = "xrTableCell53";
            this.xrTableCell53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell53.TextFormatString = "{0:n1}";
            this.xrTableCell53.Weight = 0.56215395420764613D;
            // 
            // xrTableCell54
            // 
            this.xrTableCell54.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL9]")});
            this.xrTableCell54.Name = "xrTableCell54";
            this.xrTableCell54.StylePriority.UseTextAlignment = false;
            this.xrTableCell54.Text = "xrTableCell54";
            this.xrTableCell54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell54.TextFormatString = "{0:n1}";
            this.xrTableCell54.Weight = 0.92673522878038117D;
            // 
            // xrTableCell55
            // 
            this.xrTableCell55.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COL10]")});
            this.xrTableCell55.Name = "xrTableCell55";
            this.xrTableCell55.StylePriority.UseTextAlignment = false;
            this.xrTableCell55.Text = "xrTableCell55";
            this.xrTableCell55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell55.TextFormatString = "{0:n1}";
            this.xrTableCell55.Weight = 0.51006960468524287D;
            // 
            // xrTableCell56
            // 
            this.xrTableCell56.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[NOTES]")});
            this.xrTableCell56.Name = "xrTableCell56";
            this.xrTableCell56.Text = "xrTableCell56";
            this.xrTableCell56.TextFormatString = "{0}";
            this.xrTableCell56.Weight = 0.8683288416270174D;
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
            this.xrLabel5,
            this.xrTable2,
            this.xrTable1,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
            this.ReportHeader.HeightF = 378.9583F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel5
            // 
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(1.500168F, 193.25F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(1102.5F, 23F);
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "ĐVT: triệu đồng";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(1.500244F, 351.25F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1102.5F, 27.70834F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UsePadding = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell9,
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell15,
            this.xrTableCell28,
            this.xrTableCell29,
            this.xrTableCell34,
            this.xrTableCell35,
            this.xrTableCell44,
            this.xrTableCell49,
            this.xrTableCell50,
            this.xrTableCell51,
            this.xrTableCell52});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.Text = "1";
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell9.Weight = 0.45000015258789061D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.Text = "2";
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell10.Weight = 1.9916667153440726D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.StylePriority.UseTextAlignment = false;
            this.xrTableCell11.Text = "3";
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell11.Weight = 0.7166674826539744D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.StylePriority.UseTextAlignment = false;
            this.xrTableCell15.Text = "4";
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell15.Weight = 1.0288182397958052D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.StylePriority.UseTextAlignment = false;
            this.xrTableCell28.Text = "5";
            this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell28.Weight = 0.8697926510833528D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.StylePriority.UseTextAlignment = false;
            this.xrTableCell29.Text = "6";
            this.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell29.Weight = 0.77013842975997138D;
            // 
            // xrTableCell34
            // 
            this.xrTableCell34.Name = "xrTableCell34";
            this.xrTableCell34.StylePriority.UseTextAlignment = false;
            this.xrTableCell34.Text = "(7=6-3)";
            this.xrTableCell34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell34.Weight = 0.86624586052334762D;
            // 
            // xrTableCell35
            // 
            this.xrTableCell35.Name = "xrTableCell35";
            this.xrTableCell35.StylePriority.UseTextAlignment = false;
            this.xrTableCell35.Text = "(8=6/3)";
            this.xrTableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell35.Weight = 0.55736441290284067D;
            // 
            // xrTableCell44
            // 
            this.xrTableCell44.Name = "xrTableCell44";
            this.xrTableCell44.StylePriority.UseTextAlignment = false;
            this.xrTableCell44.Text = "(9=6-4)";
            this.xrTableCell44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell44.Weight = 0.89201219130370135D;
            // 
            // xrTableCell49
            // 
            this.xrTableCell49.Name = "xrTableCell49";
            this.xrTableCell49.StylePriority.UseTextAlignment = false;
            this.xrTableCell49.Text = "(10=6/4)";
            this.xrTableCell49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell49.Weight = 0.562153726475209D;
            // 
            // xrTableCell50
            // 
            this.xrTableCell50.Name = "xrTableCell50";
            this.xrTableCell50.StylePriority.UseTextAlignment = false;
            this.xrTableCell50.Text = "(11=6-5)";
            this.xrTableCell50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell50.Weight = 0.92673508663630078D;
            // 
            // xrTableCell51
            // 
            this.xrTableCell51.Name = "xrTableCell51";
            this.xrTableCell51.StylePriority.UseTextAlignment = false;
            this.xrTableCell51.Text = "(12=6/5)";
            this.xrTableCell51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell51.Weight = 0.51006896385967193D;
            // 
            // xrTableCell52
            // 
            this.xrTableCell52.Name = "xrTableCell52";
            this.xrTableCell52.StylePriority.UseTextAlignment = false;
            this.xrTableCell52.Text = "13";
            this.xrTableCell52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell52.Weight = 0.883332028655922D;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(1.500162F, 216.25F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1,
            this.xrTableRow5,
            this.xrTableRow2});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1102.5F, 135F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UsePadding = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell31,
            this.xrTableCell46});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableRow1.StylePriority.UsePadding = false;
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.RowSpan = 3;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "Mã số";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell1.Weight = 0.45000002354870361D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.RowSpan = 3;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "Chỉ tiêu";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell2.Weight = 1.9916666939805932D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.RowSpan = 3;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "Số thực hiện\r\ncùng kỳ\r\nnăm trước";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell3.Weight = 0.71666681945579569D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.RowSpan = 3;
            this.xrTableCell7.StylePriority.UseBorders = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "Kế hoạch năm";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell7.Weight = 1.0288186942731552D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Multiline = true;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.Text = "Cùng kỳ báo cáo";
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell8.Weight = 1.6399309871658694D;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.StylePriority.UseTextAlignment = false;
            this.xrTableCell31.Text = "Đánh giá thực hiện";
            this.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell31.Weight = 4.314580822516044D;
            // 
            // xrTableCell46
            // 
            this.xrTableCell46.Multiline = true;
            this.xrTableCell46.Name = "xrTableCell46";
            this.xrTableCell46.RowSpan = 3;
            this.xrTableCell46.StylePriority.UseTextAlignment = false;
            this.xrTableCell46.Text = "Giải trình nguyên nhân chênh lệch\r\nThực hiện so với KH phân kỳ";
            this.xrTableCell46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell46.Weight = 0.88333214211242972D;
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell37,
            this.xrTableCell38,
            this.xrTableCell39,
            this.xrTableCell40,
            this.xrTableCell41,
            this.xrTableCell42,
            this.xrTableCell43,
            this.xrTableCell45,
            this.xrTableCell32,
            this.xrTableCell47});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 1D;
            // 
            // xrTableCell37
            // 
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.StylePriority.UseTextAlignment = false;
            this.xrTableCell37.Text = "xrTableCell37";
            this.xrTableCell37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell37.Weight = 0.45000002354870361D;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.Text = "xrTableCell38";
            this.xrTableCell38.Weight = 1.9916666939805932D;
            // 
            // xrTableCell39
            // 
            this.xrTableCell39.Name = "xrTableCell39";
            this.xrTableCell39.Text = "xrTableCell39";
            this.xrTableCell39.Weight = 0.71666681945579569D;
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.Text = "xrTableCell40";
            this.xrTableCell40.Weight = 1.0288186942731552D;
            // 
            // xrTableCell41
            // 
            this.xrTableCell41.Multiline = true;
            this.xrTableCell41.Name = "xrTableCell41";
            this.xrTableCell41.RowSpan = 2;
            this.xrTableCell41.StylePriority.UseTextAlignment = false;
            this.xrTableCell41.Text = "Kế hoạch\r\nphân kỳ";
            this.xrTableCell41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell41.Weight = 0.86979261871882652D;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.RowSpan = 2;
            this.xrTableCell42.StylePriority.UseTextAlignment = false;
            this.xrTableCell42.Text = "Thực hiện";
            this.xrTableCell42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell42.Weight = 0.77013850253495819D;
            // 
            // xrTableCell43
            // 
            this.xrTableCell43.Name = "xrTableCell43";
            this.xrTableCell43.StylePriority.UseTextAlignment = false;
            this.xrTableCell43.Text = "Thực hiện so với cùng kỳ năm trước";
            this.xrTableCell43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell43.Weight = 1.4236096468682713D;
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.StylePriority.UseTextAlignment = false;
            this.xrTableCell45.Text = "Thực hiện so với kế hoạch năm";
            this.xrTableCell45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell45.Weight = 1.4541665871560596D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.StylePriority.UseTextAlignment = false;
            this.xrTableCell32.Text = "Thực hiện so với kế hoạch phân kỳ";
            this.xrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell32.Weight = 1.4368044544037977D;
            // 
            // xrTableCell47
            // 
            this.xrTableCell47.Name = "xrTableCell47";
            this.xrTableCell47.Text = "xrTableCell47";
            this.xrTableCell47.Weight = 0.88333214211242972D;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell12,
            this.xrTableCell13,
            this.xrTableCell14,
            this.xrTableCell16,
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrTableCell30,
            this.xrTableCell33,
            this.xrTableCell36,
            this.xrTableCell48});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "xrTableCell4";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell4.Weight = 0.45000002354870361D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "xrTableCell5";
            this.xrTableCell5.Weight = 1.9916666939805932D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "xrTableCell6";
            this.xrTableCell6.Weight = 0.71666681945579569D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "xrTableCell12";
            this.xrTableCell12.Weight = 1.0288186942731552D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Text = "xrTableCell13";
            this.xrTableCell13.Weight = 0.86979261871882652D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Text = "xrTableCell14";
            this.xrTableCell14.Weight = 0.77013850253495819D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.StylePriority.UseTextAlignment = false;
            this.xrTableCell16.Text = "Chênh lệch";
            this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell16.Weight = 0.86624603910653386D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.StylePriority.UseTextAlignment = false;
            this.xrTableCell17.Text = "Tỷ lệ (%)";
            this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell17.Weight = 0.55736436229220587D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.StylePriority.UseTextAlignment = false;
            this.xrTableCell18.Text = "Chênh lệch";
            this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell18.Weight = 0.89201272098683726D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.StylePriority.UseTextAlignment = false;
            this.xrTableCell30.Text = "Tỷ lệ (%)";
            this.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell30.Weight = 0.56215317952387633D;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.StylePriority.UseTextAlignment = false;
            this.xrTableCell33.Text = "Chênh lệch";
            this.xrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell33.Weight = 0.92673500284925092D;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.StylePriority.UseTextAlignment = false;
            this.xrTableCell36.Text = "Tỷ lệ (%)";
            this.xrTableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell36.Weight = 0.51006868861527355D;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.Text = "xrTableCell48";
            this.xrTableCell48.Weight = 0.88333283716658018D;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 170.25F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(1104F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Kỳ báo cáo:";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 145.5833F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(1102.5F, 24.66666F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Hộ Kế Hoạch:";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 105.9167F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(1102.5F, 39.66667F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "BÁO CÁO ĐÁNH GIÁ THỰC HIỆN KẾ HOẠCH";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 72.00002F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(20, 2, 2, 2, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(1101F, 22.99999F);
            this.xrLabel1.StylePriority.UsePadding = false;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "KTQT_Data_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Report_RevCost_DanhGia_KH";
            customSqlQuery1.Sql = "select * from [QLKH_Data].dbo.REPORT_REVCOST_TB_DANHGIA_KH\r\norder by ACCOUNTGROUP" +
    " desc, SEQ";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // pCreated_user
            // 
            this.pCreated_user.Description = "pCreated_user";
            this.pCreated_user.Name = "pCreated_user";
            this.pCreated_user.ValueInfo = "508";
            this.pCreated_user.Visible = false;
            // 
            // p_Ver_Company_Id
            // 
            this.p_Ver_Company_Id.Description = "p_Ver_Company_Id";
            this.p_Ver_Company_Id.Name = "p_Ver_Company_Id";
            this.p_Ver_Company_Id.Type = typeof(int);
            this.p_Ver_Company_Id.ValueInfo = "0";
            this.p_Ver_Company_Id.Visible = false;
            // 
            // p_fMonth
            // 
            this.p_fMonth.Description = "p_fMonth";
            this.p_fMonth.Name = "p_fMonth";
            this.p_fMonth.Type = typeof(int);
            this.p_fMonth.ValueInfo = "0";
            this.p_fMonth.Visible = false;
            // 
            // p_toMonth
            // 
            this.p_toMonth.Description = "p_toMonth";
            this.p_toMonth.Name = "p_toMonth";
            this.p_toMonth.Type = typeof(int);
            this.p_toMonth.ValueInfo = "0";
            this.p_toMonth.Visible = false;
            // 
            // RevCost_DanhGia_KH
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Report_RevCost_DanhGia_KH";
            this.DataSource = this.sqlDataSource1;
            this.Margins = new System.Drawing.Printing.Margins(38, 27, 0, 100);
            this.PageHeight = 1654;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A3;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.pCreated_user,
            this.p_Ver_Company_Id,
            this.p_fMonth,
            this.p_toMonth});
            this.Version = "17.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
