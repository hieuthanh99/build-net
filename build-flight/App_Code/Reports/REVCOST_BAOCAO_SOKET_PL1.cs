using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using KHNNData;
using System.Linq;

/// <summary>
/// Summary description for REVCOST_BAOCAO_SOKET_PL1
/// </summary>
public class REVCOST_BAOCAO_SOKET_PL1 : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel5;
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
    public DevExpress.XtraReports.Parameters.Parameter pCreated_user;
    private XRLabel xrLabel4;
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
    private XRTableCell xrTableCell12;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

    public REVCOST_BAOCAO_SOKET_PL1()
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

        int FMonth, TMonth, p_CompanyID, p_VersionID, p_VersionIDBase1, p_VersionIDBase2, p_VersionIDBase3;
        string hochiphi = string.Empty;

        decimal p_VercompanyID, p_VercompanyBase1ID, p_VercompanyBase2ID, p_VercompanyBase3ID;
        string p_Type, p_TypeBase1, p_TypeBase2, p_TypeBase3;


        try
        {


            p_VersionID = Convert.ToInt32(this.Parameters["p_VersionID"].Value);
            p_VersionIDBase1 = Convert.ToInt32(this.Parameters["p_VersionIDBase1"].Value);
            p_VersionIDBase2 = Convert.ToInt32(this.Parameters["p_VersionIDBase2"].Value);
            p_VersionIDBase3 = Convert.ToInt32(this.Parameters["p_VersionIDBase3"].Value);

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
                                    VersionType = vs.VersionType,
                                    Version_name = vs.VersionName
                                }).ToList();
                var aVersionBase1 = (from vs in entites.Versions
                                     where vs.VersionID == p_VersionIDBase1
                                     select new
                                     {
                                         VersionID = vs.VersionID,
                                         VersionYear = vs.VersionYear,
                                         VersionType = vs.VersionType,
                                         Version_name = vs.VersionName
                                     }).ToList();
                var aVersionBase2 = (from vs in entites.Versions
                                     where vs.VersionID == p_VersionIDBase2
                                     select new
                                     {
                                         VersionID = vs.VersionID,
                                         VersionYear = vs.VersionYear,
                                         VersionType = vs.VersionType,
                                         Version_name = vs.VersionName
                                     }).ToList();
                var aVersionBase3 = (from vs in entites.Versions
                                     where vs.VersionID == p_VersionIDBase3
                                     select new
                                     {
                                         VersionID = vs.VersionID,
                                         VersionYear = vs.VersionYear,
                                         VersionType = vs.VersionType,
                                         Version_name = vs.VersionName
                                     }).ToList();

                p_VercompanyID = (decimal)entites.VersionCompanies.Where(x => x.VersionID == p_VersionID && x.CompanyID == p_CompanyID).SingleOrDefault().VerCompanyID;
                p_VercompanyBase1ID = (decimal)entites.VersionCompanies.Where(x => x.VersionID == p_VersionIDBase1 && x.CompanyID == p_CompanyID).SingleOrDefault().VerCompanyID;
                p_VercompanyBase2ID = (decimal)entites.VersionCompanies.Where(x => x.VersionID == p_VersionIDBase2 && x.CompanyID == p_CompanyID).SingleOrDefault().VerCompanyID;
                p_VercompanyBase3ID = (decimal)entites.VersionCompanies.Where(x => x.VersionID == p_VersionIDBase3 && x.CompanyID == p_CompanyID).SingleOrDefault().VerCompanyID;

                p_Type = aVersion.FirstOrDefault().VersionType.ToString();
                p_TypeBase1 = aVersionBase1.FirstOrDefault().VersionType.ToString();
                p_TypeBase2 = aVersionBase2.FirstOrDefault().VersionType.ToString();
                p_TypeBase3 = aVersionBase3.FirstOrDefault().VersionType.ToString();

                xrLabel1.Text = "CÔNG TY DỊCH VỤ MẶT ĐẤT SÂN BAY VIỆT NAM";

                if (p_Type == "P")
                {
                    if (TMonth ==12)
                    {
                        xrLabel2.Text = "BÁO CÁO SƠ KẾT KẾ HOẠCH NĂM " + aVersion.SingleOrDefault().VersionYear;
                    }
                    else
                    {
                        xrLabel2.Text = "BÁO CÁO SƠ KẾT KẾ HOẠCH " + TMonth + "T NĂM " + aVersion.SingleOrDefault().VersionYear;
                    }
                   
                }
                else if (p_Type == "E")
                {
                    if (TMonth == 12)
                    {
                        xrLabel2.Text = "BÁO CÁO SƠ KẾT ƯỚC THỰC HIỆN NĂM " + aVersion.SingleOrDefault().VersionYear;
                    }
                    else
                    {
                        xrLabel2.Text = "BÁO CÁO SƠ KẾT ƯỚC THỰC HIỆN " + TMonth + "T NĂM " + aVersion.SingleOrDefault().VersionYear;
                    }
                    
                }
                else if (p_Type == "A")
                {
                    if (TMonth == 12)
                    {
                        xrLabel2.Text = "BÁO CÁO SƠ KẾT THỰC HIỆN NĂM " + aVersion.SingleOrDefault().VersionYear;
                    }
                    else
                    {
                        xrLabel2.Text = "BÁO CÁO SƠ KẾT THỰC HIỆN " + TMonth + "T NĂM " + aVersion.SingleOrDefault().VersionYear;
                    }
                    
                }

                xrLabel3.Text = "Hộ Thu Chi: " + hochiphi;
                xrLabel4.Text = "Kỳ báo cáo: Từ tháng " + FMonth + " đến " + TMonth;

                // Base1
                xrTableCell3.Text = aVersionBase1.SingleOrDefault().Version_name;
                //Base2
                xrTableCell5.Text = aVersionBase2.SingleOrDefault().Version_name + ":" + TMonth + "T:" + aVersionBase2.SingleOrDefault().VersionYear;
                //Base 3
                xrTableCell6.Text = aVersionBase3.SingleOrDefault().Version_name + ":" + TMonth + "T:" + aVersionBase3.SingleOrDefault().VersionYear;
                // 
                xrTableCell4.Text = aVersion.SingleOrDefault().Version_name + ":" + TMonth + "T:" + aVersion.SingleOrDefault().VersionYear;

                //if (p_TypeBase2 == "A")
                //{
                //    xrTableCell3.Text = aVersionBase2.SingleOrDefault().Version_name;
                //    //xrTableCell42.Text = "Thực hiện năm " + aVersionBase2.SingleOrDefault().VersionYear + " từ tháng:" + FMonth + "-" + TMonth;
                //    //xrTableCell43.Text = "Thực hiện so với cùng kỳ năm " + aVersionBase1.SingleOrDefault().VersionYear;
                //    //xrTableCell45.Text = "Thực hiện so với ";
                //    //xrTableCell32.Text = "Thực hiện so với ";
                //    //xrTableCell46.Text = "Giải trình nguyên nhân chênh lệch Thực hiện so với ";
                //}
                //else if (p_TypeBase2 == "P")
                //{
                //    xrTableCell42.Text = "Kế hoạch năm " + aVersionBase2.SingleOrDefault().VersionYear + " từ tháng:" + FMonth + "-" + TMonth;
                //    xrTableCell43.Text = "Kế hoạch so với cùng kỳ năm " + aVersionBase1.SingleOrDefault().VersionYear;
                //    xrTableCell45.Text = "Kế hoạch so với ";
                //    xrTableCell32.Text = "Kế hoạch so với ";
                //    xrTableCell46.Text = "Giải trình nguyên nhân chênh lệch Kế hoạch so với ";
                //}
                //else if (p_TypeBase2 == "E")
                //{
                //    xrTableCell42.Text = "Uớc thực hiện năm " + aVersionBase2.SingleOrDefault().VersionYear + " từ tháng:" + FMonth + "-" + TMonth;
                //    xrTableCell43.Text = "Ước thực hiện so với cùng kỳ năm " + aVersionBase1.SingleOrDefault().VersionYear;
                //    xrTableCell45.Text = "Ước thực hiện so với ";
                //    xrTableCell32.Text = "Ước thực hiện so với ";
                //    xrTableCell46.Text = "Giải trình nguyên nhân chênh lệch Ước thực hiện so với ";
                //}

                //if (p_TypeBase2 == "A")
                //{
                //    xrTableCell5.Text =  aVersionBase2.SingleOrDefault().VersionYear + " từ tháng:" + FMonth + "-" + TMonth;
                //}
                //else if (p_TypeBase1 == "P")
                //{
                //    xrTableCell5.Text = "Số kế hoạch cùng kỳ năm " + aVersionBase1.SingleOrDefault().VersionYear + " từ tháng:" + FMonth + "-" + TMonth;
                //}
                //else if (p_TypeBase1 == "E")
                //{
                //    xrTableCell5.Text = "Số ước thực hiện cùng kỳ năm " + aVersionBase1.SingleOrDefault().VersionYear + " từ tháng:" + FMonth + "-" + TMonth;
                //}


                //if (p_Type == "P")
                //{
                //    xrTableCell7.Text = "Kế hoạch năm " + aVersion.SingleOrDefault().VersionYear;
                //    xrTableCell41.Text = "Kế hoạch phân kỳ năm " + aVersion.SingleOrDefault().VersionYear + " từ tháng:" + FMonth + "-" + TMonth;
                //    xrTableCell45.Text = xrTableCell45.Text + " kế hoạch năm  " + aVersion.SingleOrDefault().VersionYear;
                //    xrTableCell32.Text = xrTableCell32.Text + " kế hoạch phân kỳ năm  " + aVersion.SingleOrDefault().VersionYear;
                //    xrTableCell46.Text = xrTableCell46.Text + " KH phân kỳ";
                //}
                //else if (p_Type == "E")
                //{
                //    xrTableCell7.Text = "Ước thực hiện năm " + aVersion.SingleOrDefault().VersionYear;
                //    xrTableCell41.Text = "Ước thực hiện phân kỳ năm " + aVersion.SingleOrDefault().VersionYear + " từ tháng:" + FMonth + "-" + TMonth;
                //    xrTableCell45.Text = xrTableCell45.Text + " ước thực hiện năm  " + aVersion.SingleOrDefault().VersionYear;
                //    xrTableCell32.Text = xrTableCell32.Text + " ước thực hiện phân kỳ năm  " + aVersion.SingleOrDefault().VersionYear;
                //    xrTableCell46.Text = xrTableCell46.Text + " UTH phân kỳ";
                //}
                //else if (p_Type == "A")
                //{
                //    xrTableCell7.Text = "Thực hiện năm " + aVersion.SingleOrDefault().VersionYear;
                //    xrTableCell41.Text = "Thực hiện phân kỳ năm " + aVersion.SingleOrDefault().VersionYear + " từ tháng:" + FMonth + "-" + TMonth;
                //    xrTableCell45.Text = xrTableCell45.Text + " thực hiện năm  " + aVersion.SingleOrDefault().VersionYear;
                //    xrTableCell32.Text = xrTableCell32.Text + " ước thực hiện phân kỳ năm  " + aVersion.SingleOrDefault().VersionYear;
                //    xrTableCell46.Text = xrTableCell46.Text + " TH phân kỳ";
                //}



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
            string resourceFileName = "REVCOST_BAOCAO_SOKET_PL1.resx";
            System.Resources.ResourceManager resources = global::Resources.REVCOST_BAOCAO_SOKET_PL1.ResourceManager;
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
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
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
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
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
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
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.pCreated_user = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
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
            this.xrTable3.SizeF = new System.Drawing.SizeF(1098.333F, 25F);
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
            this.xrTableCell27});
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
            this.xrTableCell20.Weight = 2.7739259695083405D;
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
            this.xrTableCell21.Weight = 1.2914033439896544D;
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
            this.xrTableCell22.Weight = 1.3714759009866036D;
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
            this.xrTableCell23.Weight = 1.3547805225014185D;
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
            this.xrTableCell24.Weight = 1.1728776649657737D;
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
            this.xrTableCell25.Weight = 1.2275673096124922D;
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
            this.xrTableCell26.Weight = 1.1652450703060495D;
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
            this.xrTableCell27.Weight = 1.1082889361082691D;
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
            this.xrTable1,
            this.xrLabel4,
            this.xrTable2,
            this.xrLabel5,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
            this.ReportHeader.HeightF = 376.375F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 276.0417F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1099F, 72.62494F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
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
            this.xrTableCell12});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell1.StylePriority.UsePadding = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "STT";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell1.Weight = 0.45000152587890629D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell2.StylePriority.UsePadding = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "Diễn giải";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell2.Weight = 2.5499984741210939D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell3.StylePriority.UsePadding = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "KH2019";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell3.Weight = 1.1871539306640624D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell4.StylePriority.UsePadding = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "UTH 6T 2019";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell4.Weight = 1.2607617187499998D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell5.StylePriority.UsePadding = false;
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.Text = "KHPK 6T 2019";
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell5.Weight = 1.2454156494140622D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell6.StylePriority.UsePadding = false;
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.Text = "TH 6T 2019";
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell6.Weight = 1.07819580078125D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell7.StylePriority.UsePadding = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "UTH 6T 2019\r\n/KHPK 6T 2019";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell7.Weight = 1.1284716796875D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Multiline = true;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell8.StylePriority.UsePadding = false;
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.Text = "UTH 6T2019\r\n/KH 2019";
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell8.Weight = 1.0711798095703125D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Multiline = true;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.StylePriority.UseTextAlignment = false;
            this.xrTableCell12.Text = "UTH 6T2019\r\n/TH 6T2019";
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell12.Weight = 1.0188214111328127D;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0.6669312F, 184.3333F);
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
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0.0001220703F, 348.6666F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1099F, 27.70834F);
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
            this.xrTableCell44});
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
            this.xrTableCell10.Weight = 2.54999768301347D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.StylePriority.UseTextAlignment = false;
            this.xrTableCell11.Text = "3";
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell11.Weight = 1.187153548664015D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.StylePriority.UseTextAlignment = false;
            this.xrTableCell15.Text = " 4";
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell15.Weight = 1.2607613009346945D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.StylePriority.UseTextAlignment = false;
            this.xrTableCell28.Text = "5";
            this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell28.Weight = 1.2454152421297255D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.StylePriority.UseTextAlignment = false;
            this.xrTableCell29.Text = "6";
            this.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell29.Weight = 1.0781954296228593D;
            // 
            // xrTableCell34
            // 
            this.xrTableCell34.Name = "xrTableCell34";
            this.xrTableCell34.StylePriority.UseTextAlignment = false;
            this.xrTableCell34.Text = "(7=4/5)";
            this.xrTableCell34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell34.Weight = 1.1284719576859219D;
            // 
            // xrTableCell35
            // 
            this.xrTableCell35.Name = "xrTableCell35";
            this.xrTableCell35.StylePriority.UseTextAlignment = false;
            this.xrTableCell35.Text = "(8=4/3)";
            this.xrTableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell35.Weight = 1.0711788695413866D;
            // 
            // xrTableCell44
            // 
            this.xrTableCell44.Name = "xrTableCell44";
            this.xrTableCell44.StylePriority.UseTextAlignment = false;
            this.xrTableCell44.Text = "(9=4/6)";
            this.xrTableCell44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell44.Weight = 1.018821080189809D;
            // 
            // xrLabel5
            // 
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 207.3333F);
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
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 159.6667F);
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
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 120F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(1102.5F, 39.66667F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "BÁO CÁO SƠ KẾT 6T PL1";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 81.33332F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(20, 2, 2, 2, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(1102.5F, 22.99999F);
            this.xrLabel1.StylePriority.UsePadding = false;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "QLKH_Data_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "REPORT_REVCOST_TB_DANHGIA_KH_KHOI";
            queryParameter1.Name = "pCreated_user";
            queryParameter1.Type = typeof(string);
            queryParameter1.ValueInfo = "9999";
            customSqlQuery1.Parameters.Add(queryParameter1);
            customSqlQuery1.Sql = "select * from [dbo].[REPORT_REVCOST_TB_DANHGIA_KH_Khoi]\r\nWHERE CREATED_USERS =@pC" +
    "reated_user\r\nORDER BY ACCOUNTGROUP DESC, SEQ\r\n";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // pCreated_user
            // 
            this.pCreated_user.Description = "pCreated_user";
            this.pCreated_user.Name = "pCreated_user";
            this.pCreated_user.ValueInfo = "9999";
            this.pCreated_user.Visible = false;
            // 
            // REVCOST_BAOCAO_SOKET_PL1
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
            this.pCreated_user});
            this.Version = "17.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
