using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using KHNNData;
using System.Linq;

/// <summary>
/// Summary description for RevCost_DanhGia_KH_Division
/// </summary>
public class RevCost_DanhGia_KH_Division : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel5;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell46;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell38;
    private XRTableCell xrTableCell39;
    private XRTableCell xrTableCell40;
    private XRTableCell xrTableCell41;
    private XRTableCell xrTableCell42;
    private XRTableCell xrTableCell43;
    private XRTableCell xrTableCell45;
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
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell53;
    private XRTableCell xrTableCell54;
    private XRTableCell xrTableCell55;
    private XRTableCell xrTableCell56;
    private DevExpress.XtraReports.Parameters.Parameter p_VersionID;
    private DevExpress.XtraReports.Parameters.Parameter p_VersionIDBase1;
    private DevExpress.XtraReports.Parameters.Parameter p_VersionIDBase2;
    private DevExpress.XtraReports.Parameters.Parameter p_fMonth;
    private DevExpress.XtraReports.Parameters.Parameter p_toMonth;
    private DevExpress.XtraReports.Parameters.Parameter P_COMPANYID;
    public DevExpress.XtraReports.Parameters.Parameter pCreated_user;
    private XRLabel xrLabel4;
    private XRLabel xrLabel6;
    private XRPictureBox xrPictureBox1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

	public RevCost_DanhGia_KH_Division()
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

        int FMonth, TMonth, p_CompanyID, p_VersionID, p_VersionIDBase1, p_VersionIDBase2;
        string hochiphi = string.Empty;

        decimal p_VercompanyID, p_VercompanyBase1ID, p_VercompanyBase2ID;
        string p_Type, p_TypeBase1, p_TypeBase2;


        try
        {


            p_VersionID = Convert.ToInt32(this.Parameters["p_VersionID"].Value);
            p_VersionIDBase1 = Convert.ToInt32(this.Parameters["p_VersionIDBase1"].Value);
            p_VersionIDBase2 = Convert.ToInt32(this.Parameters["p_VersionIDBase2"].Value);

            FMonth = Convert.ToInt32(this.Parameters["p_fMonth"].Value);
            TMonth = Convert.ToInt32(this.Parameters["p_toMonth"].Value);

            p_CompanyID = Convert.ToInt32(this.Parameters["P_COMPANYID"].Value);

            using (QLKHDataEntities entites = new QLKHDataEntities())
            {
                var aCompany = entites.Companies.Where(x => x.CompanyID == p_CompanyID);
                hochiphi = aCompany.SingleOrDefault().AreaCode + "-" + aCompany.SingleOrDefault().NameV;
                var aVersion = (from vs in entites.Versions
                                where vs.VersionID == p_VersionID
                                select new
                                {
                                    VersionID = vs.VersionID,
                                    VersionYear = vs.VersionYear,
                                    VersionType = vs.VersionType
                                }).ToList();
                var aVersionBase1 = (from vs in entites.Versions
                                     where vs.VersionID == p_VersionIDBase1
                                     select new
                                     {
                                         VersionID = vs.VersionID,
                                         VersionYear = vs.VersionYear,
                                         VersionType = vs.VersionType
                                     }).ToList();
                var aVersionBase2 = (from vs in entites.Versions
                                     where vs.VersionID == p_VersionIDBase2
                                     select new
                                     {
                                         VersionID = vs.VersionID,
                                         VersionYear = vs.VersionYear,
                                         VersionType = vs.VersionType
                                     }).ToList();

                p_VercompanyID = (decimal)entites.VersionCompanies.Where(x => x.VersionID == p_VersionID && x.CompanyID == p_CompanyID).SingleOrDefault().VerCompanyID;
                p_VercompanyBase1ID = (decimal)entites.VersionCompanies.Where(x => x.VersionID == p_VersionIDBase1 && x.CompanyID == p_CompanyID).SingleOrDefault().VerCompanyID;
                p_VercompanyBase2ID = (decimal)entites.VersionCompanies.Where(x => x.VersionID == p_VersionIDBase2 && x.CompanyID == p_CompanyID).SingleOrDefault().VerCompanyID;

                p_Type = aVersion.FirstOrDefault().VersionType.ToString();
                p_TypeBase1 = aVersionBase1.FirstOrDefault().VersionType.ToString();
                p_TypeBase2 = aVersionBase2.FirstOrDefault().VersionType.ToString();

              
                if (p_Type == "P")
                {
                    xrLabel2.Text = "BÁO CÁO ĐÁNH GIÁ THỰC HIỆN KẾ HOẠCH NĂM " + aVersion.SingleOrDefault().VersionYear;
                }
                else if (p_Type == "E")
                {
                    xrLabel2.Text = "BÁO CÁO ĐÁNH GIÁ ƯỚC THỰC HIỆN NĂM " + aVersion.SingleOrDefault().VersionYear;
                }
                else if (p_Type == "A")
                {
                    xrLabel2.Text = "BÁO CÁO ĐÁNH GIÁ THỰC HIỆN NĂM " + aVersion.SingleOrDefault().VersionYear;
                }

                xrLabel3.Text = "Hộ Thu Chi: " + hochiphi;
                xrLabel4.Text = "Kỳ báo cáo: Từ tháng " + FMonth + " đến " + TMonth;

                if (p_TypeBase2 == "A")
                {
                    xrTableCell42.Text = "Thực hiện năm " + aVersionBase2.SingleOrDefault().VersionYear + " từ tháng:" + FMonth + "-" + TMonth;
                    xrTableCell43.Text = "Thực hiện so với cùng kỳ năm " + aVersionBase1.SingleOrDefault().VersionYear;
                    xrTableCell45.Text = "Thực hiện so với ";
                    xrTableCell32.Text = "Thực hiện so với ";
                    xrTableCell46.Text = "Giải trình nguyên nhân chênh lệch Thực hiện so với ";
                }
                else if (p_TypeBase2 == "P")
                {
                    xrTableCell42.Text = "Kế hoạch năm " + aVersionBase2.SingleOrDefault().VersionYear + " từ tháng:" + FMonth + "-" + TMonth;
                    xrTableCell43.Text = "Kế hoạch so với cùng kỳ năm " + aVersionBase1.SingleOrDefault().VersionYear;
                    xrTableCell45.Text = "Kế hoạch so với ";
                    xrTableCell32.Text = "Kế hoạch so với ";
                    xrTableCell46.Text = "Giải trình nguyên nhân chênh lệch Kế hoạch so với ";
                }
                else if (p_TypeBase2 == "E")
                {
                    xrTableCell42.Text = "Uớc thực hiện năm " + aVersionBase2.SingleOrDefault().VersionYear + " từ tháng:" + FMonth + "-" + TMonth;
                    xrTableCell43.Text = "Ước thực hiện so với cùng kỳ năm " + aVersionBase1.SingleOrDefault().VersionYear;
                    xrTableCell45.Text = "Ước thực hiện so với ";
                    xrTableCell32.Text = "Ước thực hiện so với ";
                    xrTableCell46.Text = "Giải trình nguyên nhân chênh lệch Ước thực hiện so với ";
                }

                if (p_TypeBase1 == "A")
                {
                    xrTableCell3.Text = "Số thực hiện cùng kỳ năm " + aVersionBase1.SingleOrDefault().VersionYear + " từ tháng:" + FMonth + "-" + TMonth;
                }
                else if (p_TypeBase1 == "P")
                {
                    xrTableCell3.Text = "Số kế hoạch cùng kỳ năm " + aVersionBase1.SingleOrDefault().VersionYear + " từ tháng:" + FMonth + "-" + TMonth;
                }
                else if (p_TypeBase1 == "E")
                {
                    xrTableCell3.Text = "Số ước thực hiện cùng kỳ năm " + aVersionBase1.SingleOrDefault().VersionYear + " từ tháng:" + FMonth + "-" + TMonth;
                }


                if (p_Type == "P")
                {
                    xrTableCell7.Text = "Kế hoạch năm " + aVersion.SingleOrDefault().VersionYear;
                    xrTableCell41.Text = "Kế hoạch phân kỳ năm " + aVersion.SingleOrDefault().VersionYear + " từ tháng:" + FMonth + "-" + TMonth;
                    xrTableCell45.Text = xrTableCell45.Text + " kế hoạch năm  " + aVersion.SingleOrDefault().VersionYear;
                    xrTableCell32.Text = xrTableCell32.Text + " kế hoạch phân kỳ năm  " + aVersion.SingleOrDefault().VersionYear;
                    xrTableCell46.Text = xrTableCell46.Text + " KH phân kỳ";
                }
                else if (p_Type == "E")
                {
                    xrTableCell7.Text = "Ước thực hiện năm " + aVersion.SingleOrDefault().VersionYear;
                    xrTableCell41.Text = "Ước thực hiện phân kỳ năm " + aVersion.SingleOrDefault().VersionYear + " từ tháng:" + FMonth + "-" + TMonth;
                    xrTableCell45.Text = xrTableCell45.Text + " ước thực hiện năm  " + aVersion.SingleOrDefault().VersionYear;
                    xrTableCell32.Text = xrTableCell32.Text + " ước thực hiện phân kỳ năm  " + aVersion.SingleOrDefault().VersionYear;
                    xrTableCell46.Text = xrTableCell46.Text + " UTH phân kỳ";
                }
                else if (p_Type == "A")
                {
                    xrTableCell7.Text = "Thực hiện năm " + aVersion.SingleOrDefault().VersionYear;
                    xrTableCell41.Text = "Thực hiện phân kỳ năm " + aVersion.SingleOrDefault().VersionYear + " từ tháng:" + FMonth + "-" + TMonth;
                    xrTableCell45.Text = xrTableCell45.Text + " thực hiện năm  " + aVersion.SingleOrDefault().VersionYear;
                    xrTableCell32.Text = xrTableCell32.Text + " ước thực hiện phân kỳ năm  " + aVersion.SingleOrDefault().VersionYear;
                    xrTableCell46.Text = xrTableCell46.Text + " TH phân kỳ";
                }



            }
            FormattingRule rule = new FormattingRule();
            this.FormattingRuleSheet.Add(rule);

            rule.DataSource = this.DataSource;
            rule.DataMember = this.DataMember;
            rule.Condition = "[CALCULATION] == 'SUM'";
            rule.Formatting.Font = new Font("Times New Roman", 8, FontStyle.Bold);
            this.xrTableCell19.FormattingRules.Add(rule);
        }
        catch (Exception ex) { new Exception(ex.Message); }
    }

	#region Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
            string resourceFileName = "RevCost_DanhGia_KH_Division.resx";
            System.Resources.ResourceManager resources = global::Resources.RevCost_DanhGia_KH_Division.ResourceManager;
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter6 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter7 = new DevExpress.DataAccess.Sql.QueryParameter();
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
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
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
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.p_VersionID = new DevExpress.XtraReports.Parameters.Parameter();
            this.p_VersionIDBase1 = new DevExpress.XtraReports.Parameters.Parameter();
            this.p_VersionIDBase2 = new DevExpress.XtraReports.Parameters.Parameter();
            this.p_fMonth = new DevExpress.XtraReports.Parameters.Parameter();
            this.p_toMonth = new DevExpress.XtraReports.Parameters.Parameter();
            this.P_COMPANYID = new DevExpress.XtraReports.Parameters.Parameter();
            this.pCreated_user = new DevExpress.XtraReports.Parameters.Parameter();
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
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0.6669312F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(1101.833F, 25F);
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
            this.xrTableCell19.Weight = 0.48226317797904D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DESCRIPTION]")});
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Text = "xrTableCell20";
            this.xrTableCell20.Weight = 2.1665636481881574D;
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
            this.xrTableCell21.Weight = 0.88838116104300724D;
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
            this.xrTableCell22.Weight = 1.0103837825775379D;
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
            this.xrTableCell23.Weight = 0.94617328018844227D;
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
            this.xrTableCell24.Weight = 0.83776812744144569D;
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
            this.xrTableCell25.Weight = 0.94231539247197094D;
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
            this.xrTableCell26.Weight = 0.60630752715086711D;
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
            this.xrTableCell27.Weight = 0.97034471388528465D;
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
            this.xrTableCell53.Weight = 0.61151997141947134D;
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
            this.xrTableCell54.Weight = 0.89026743157780419D;
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
            this.xrTableCell55.Weight = 0.67270953095103059D;
            // 
            // xrTableCell56
            // 
            this.xrTableCell56.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[NOTES]")});
            this.xrTableCell56.Name = "xrTableCell56";
            this.xrTableCell56.Text = "xrTableCell56";
            this.xrTableCell56.TextFormatString = "{0}";
            this.xrTableCell56.Weight = 0.96090222573570416D;
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
            this.xrLabel6,
            this.xrPictureBox1,
            this.xrLabel4,
            this.xrTable2,
            this.xrTable1,
            this.xrLabel5,
            this.xrLabel3,
            this.xrLabel2});
            this.ReportHeader.HeightF = 344.3749F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel6
            // 
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 65F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(325.8335F, 23F);
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "BAMBOO AIRWAYS";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleLeft;
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(325.8334F, 65F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(1.500244F, 152.3333F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(1101F, 22.99997F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Kỳ báo cáo:";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0.0001220703F, 316.6666F);
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
            this.xrTableCell11.Weight = 0.81666584367066553D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.StylePriority.UseTextAlignment = false;
            this.xrTableCell15.Text = "4";
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell15.Weight = 0.92881987877911409D;
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
            this.xrTableCell50.Weight = 0.81840096666416517D;
            // 
            // xrTableCell51
            // 
            this.xrTableCell51.Name = "xrTableCell51";
            this.xrTableCell51.StylePriority.UseTextAlignment = false;
            this.xrTableCell51.Text = "(12=6/5)";
            this.xrTableCell51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell51.Weight = 0.61840308383180753D;
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
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 198.3333F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1,
            this.xrTableRow5,
            this.xrTableRow2});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1102.5F, 118.3333F);
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
            this.xrTableCell1.Weight = 0.46760273080300041D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.RowSpan = 3;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "Chỉ tiêu";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell2.Weight = 2.0695685486570143D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.RowSpan = 3;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "Số thực hiện\r\ncùng kỳ\r\nnăm trước";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell3.Weight = 0.84860911048161081D;
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
            this.xrTableCell7.Weight = 0.96514941949047184D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Multiline = true;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.Text = "Cùng kỳ báo cáo";
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell8.Weight = 1.7040753594259386D;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.StylePriority.UseTextAlignment = false;
            this.xrTableCell31.Text = "Đánh giá thực hiện";
            this.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell31.Weight = 4.4833409842570084D;
            // 
            // xrTableCell46
            // 
            this.xrTableCell46.Multiline = true;
            this.xrTableCell46.Name = "xrTableCell46";
            this.xrTableCell46.RowSpan = 3;
            this.xrTableCell46.StylePriority.UseTextAlignment = false;
            this.xrTableCell46.Text = "Giải trình nguyên nhân chênh lệch\r\nThực hiện so với KH phân kỳ";
            this.xrTableCell46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell46.Weight = 0.91788347708311646D;
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
            this.xrTableCell37.Weight = 0.46760273080300041D;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.Text = "xrTableCell38";
            this.xrTableCell38.Weight = 2.0695685486570143D;
            // 
            // xrTableCell39
            // 
            this.xrTableCell39.Name = "xrTableCell39";
            this.xrTableCell39.Text = "xrTableCell39";
            this.xrTableCell39.Weight = 0.84860911048161081D;
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.Text = "xrTableCell40";
            this.xrTableCell40.Weight = 0.965149736602802D;
            // 
            // xrTableCell41
            // 
            this.xrTableCell41.Multiline = true;
            this.xrTableCell41.Name = "xrTableCell41";
            this.xrTableCell41.RowSpan = 2;
            this.xrTableCell41.StylePriority.UseTextAlignment = false;
            this.xrTableCell41.Text = "Kế hoạch\r\nphân kỳ";
            this.xrTableCell41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell41.Weight = 0.9038136979521989D;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.RowSpan = 2;
            this.xrTableCell42.StylePriority.UseTextAlignment = false;
            this.xrTableCell42.Text = "Thực hiện";
            this.xrTableCell42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell42.Weight = 0.80026183520069616D;
            // 
            // xrTableCell43
            // 
            this.xrTableCell43.Name = "xrTableCell43";
            this.xrTableCell43.StylePriority.UseTextAlignment = false;
            this.xrTableCell43.Text = "Thực hiện so với cùng kỳ năm trước";
            this.xrTableCell43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell43.Weight = 1.4792935496744153D;
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.StylePriority.UseTextAlignment = false;
            this.xrTableCell45.Text = "Thực hiện so với kế hoạch năm";
            this.xrTableCell45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell45.Weight = 1.5110419457297606D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.StylePriority.UseTextAlignment = false;
            this.xrTableCell32.Text = "Thực hiện so với kế hoạch phân kỳ";
            this.xrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell32.Weight = 1.4930049980135456D;
            // 
            // xrTableCell47
            // 
            this.xrTableCell47.Name = "xrTableCell47";
            this.xrTableCell47.Text = "xrTableCell47";
            this.xrTableCell47.Weight = 0.91788347708311646D;
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
            this.xrTableCell4.Weight = 0.46760273080300041D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "xrTableCell5";
            this.xrTableCell5.Weight = 2.0695685486570143D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "xrTableCell6";
            this.xrTableCell6.Weight = 0.84860911048161081D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "xrTableCell12";
            this.xrTableCell12.Weight = 0.96514965732471947D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Text = "xrTableCell13";
            this.xrTableCell13.Weight = 0.90381377723028145D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Text = "xrTableCell14";
            this.xrTableCell14.Weight = 0.80026084422466426D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.StylePriority.UseTextAlignment = false;
            this.xrTableCell16.Text = "Chênh lệch";
            this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell16.Weight = 0.9001297294228463D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.StylePriority.UseTextAlignment = false;
            this.xrTableCell17.Text = "Tỷ lệ (%)";
            this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell17.Weight = 0.57916444762713659D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.StylePriority.UseTextAlignment = false;
            this.xrTableCell18.Text = "Chênh lệch";
            this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell18.Weight = 0.926901463569655D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.StylePriority.UseTextAlignment = false;
            this.xrTableCell30.Text = "Tỷ lệ (%)";
            this.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell30.Weight = 0.58414091364569221D;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.StylePriority.UseTextAlignment = false;
            this.xrTableCell33.Text = "Chênh lệch";
            this.xrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell33.Weight = 0.85041206243474021D;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.StylePriority.UseTextAlignment = false;
            this.xrTableCell36.Text = "Tỷ lệ (%)";
            this.xrTableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell36.Weight = 0.642592172639532D;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.Text = "xrTableCell48";
            this.xrTableCell48.Weight = 0.91788417213726681D;
            // 
            // xrLabel5
            // 
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 175.3333F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(1102.5F, 23F);
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "ĐVT: Triệu đồng";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 127.6667F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(1102.5F, 24.66667F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Hộ Kế Hoạch:";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 88F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(1102.5F, 39.66667F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "BÁO CÁO ĐÁNH GIÁ THỰC HIỆN KẾ HOẠCH";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "KTQT_Data_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "REPORT_REVCOST_TB_DANHGIA_KH_KHOI";
            queryParameter1.Name = "pCreated_user";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.pCreated_user]", typeof(string));
            queryParameter2.Name = "P_COMPANYID";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.P_COMPANYID]", typeof(int));
            queryParameter3.Name = "p_fMonth";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.p_fMonth]", typeof(int));
            queryParameter4.Name = "p_toMonth";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("[Parameters.p_toMonth]", typeof(int));
            queryParameter5.Name = "p_VersionID";
            queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter5.Value = new DevExpress.DataAccess.Expression("[Parameters.p_VersionID]", typeof(int));
            queryParameter6.Name = "p_VersionIDBase1";
            queryParameter6.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter6.Value = new DevExpress.DataAccess.Expression("[Parameters.p_VersionIDBase1]", typeof(int));
            queryParameter7.Name = "p_VersionIDBase2";
            queryParameter7.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter7.Value = new DevExpress.DataAccess.Expression("[Parameters.p_VersionIDBase2]", typeof(int));
            customSqlQuery1.Parameters.Add(queryParameter1);
            customSqlQuery1.Parameters.Add(queryParameter2);
            customSqlQuery1.Parameters.Add(queryParameter3);
            customSqlQuery1.Parameters.Add(queryParameter4);
            customSqlQuery1.Parameters.Add(queryParameter5);
            customSqlQuery1.Parameters.Add(queryParameter6);
            customSqlQuery1.Parameters.Add(queryParameter7);
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // p_VersionID
            // 
            this.p_VersionID.Description = "p_VersionID";
            this.p_VersionID.Name = "p_VersionID";
            this.p_VersionID.Type = typeof(int);
            this.p_VersionID.ValueInfo = "0";
            this.p_VersionID.Visible = false;
            // 
            // p_VersionIDBase1
            // 
            this.p_VersionIDBase1.Description = "p_VersionIDBase1";
            this.p_VersionIDBase1.Name = "p_VersionIDBase1";
            this.p_VersionIDBase1.Type = typeof(int);
            this.p_VersionIDBase1.ValueInfo = "0";
            this.p_VersionIDBase1.Visible = false;
            // 
            // p_VersionIDBase2
            // 
            this.p_VersionIDBase2.Description = "p_VersionIDBase2";
            this.p_VersionIDBase2.Name = "p_VersionIDBase2";
            this.p_VersionIDBase2.Type = typeof(int);
            this.p_VersionIDBase2.ValueInfo = "0";
            this.p_VersionIDBase2.Visible = false;
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
            // P_COMPANYID
            // 
            this.P_COMPANYID.Description = "P_COMPANYID";
            this.P_COMPANYID.Name = "P_COMPANYID";
            this.P_COMPANYID.Type = typeof(int);
            this.P_COMPANYID.ValueInfo = "0";
            this.P_COMPANYID.Visible = false;
            // 
            // pCreated_user
            // 
            this.pCreated_user.Description = "pCreated_user";
            this.pCreated_user.Name = "pCreated_user";
            this.pCreated_user.ValueInfo = "508";
            this.pCreated_user.Visible = false;
            // 
            // RevCost_DanhGia_KH_Division
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "REPORT_REVCOST_TB_DANHGIA_KH_KHOI";
            this.DataSource = this.sqlDataSource1;
            this.Margins = new System.Drawing.Printing.Margins(31, 29, 0, 100);
            this.PageHeight = 1654;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A3;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.p_VersionID,
            this.p_VersionIDBase1,
            this.p_VersionIDBase2,
            this.p_fMonth,
            this.p_toMonth,
            this.P_COMPANYID,
            this.pCreated_user});
            this.Version = "17.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
