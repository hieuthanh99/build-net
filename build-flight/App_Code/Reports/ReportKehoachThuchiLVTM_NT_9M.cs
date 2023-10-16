using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

/// <summary>
/// Summary description for ReportKehoachThuchiLVTM
/// </summary>
public class ReportKehoachThuchiLVTM_NT_9M : DevExpress.XtraReports.UI.XtraReport
{
    private TopMarginBand TopMargin;
    private BottomMarginBand BottomMargin;
    private XRPageInfo pageInfo2;
    private ReportHeaderBand ReportHeader;
    private XRLabel label1;
    private GroupHeaderBand GroupHeader1;
    private XRTable table1;
    private XRTableRow tableRow1;
    private XRTableCell tableCell1;
    private XRTableCell tableCell2;
    private XRTableCell tableCell3;
    private XRTableCell tableCell4;
    private XRTableCell tableCell5;
    private XRTableCell tableCell6;
    private XRTableCell tableCell7;
    private XRTableCell tableCell8;
    private XRTableCell tableCell9;
    private XRTableCell tableCell10;
    private XRTableCell tableCell11;
    private XRTableCell tableCell12;
    private XRTableCell tableCell13;
    private XRTableCell tableCell14;
    private XRTableCell tableCell15;
    private XRTableCell tableCell16;
    private XRTableCell tableCell17;
    private XRTableCell tableCell18;
    private XRTableCell tableCell19;
    private XRTableCell tableCell20;
    private XRTableCell tableCell21;
    private XRTableCell tableCell22;
    private XRTableCell tableCell23;
    private XRTableCell tableCell24;
    private XRTableCell tableCell25;
    private DetailBand Detail;
    private XRTable table2;
    private XRTableRow tableRow2;
    private XRTableCell tableCell26;
    private XRTableCell tableCell27;
    private XRTableCell tableCell28;
    private XRTableCell tableCell29;
    private XRTableCell tableCell30;
    private XRTableCell tableCell31;
    private XRTableCell tableCell32;
    private XRTableCell tableCell33;
    private XRTableCell tableCell34;
    private XRTableCell tableCell35;
    private XRTableCell tableCell36;
    private XRTableCell tableCell37;
    private XRTableCell tableCell38;
    private XRTableCell tableCell39;
    private XRTableCell tableCell40;
    private XRTableCell tableCell41;
    private XRTableCell tableCell42;
    private XRTableCell tableCell43;
    private XRTableCell tableCell44;
    private XRTableCell tableCell45;
    private XRTableCell tableCell46;
    private XRTableCell tableCell47;
    private XRTableCell tableCell48;
    private XRTableCell tableCell49;
    private XRTableCell tableCell50;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private XRControlStyle Title;
    private XRControlStyle DetailCaption1;
    private XRControlStyle DetailData1;
    private XRControlStyle DetailData3_Odd;
    private XRControlStyle PageInfo;
    private DevExpress.XtraReports.Parameters.Parameter pVersionID;
    private DevExpress.XtraReports.Parameters.Parameter pCompanyID;
    private DevExpress.XtraReports.Parameters.Parameter pFromMonth;
    private DevExpress.XtraReports.Parameters.Parameter pToMonth;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell25;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell17;
    private XRPageInfo xrPageInfo1;
    private XRLabel xrLabel4;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell33;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell36;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell38;
    private XRTableCell xrTableCell39;
    private XRTableCell xrTableCell40;
    private XRTableCell xrTableCell41;
    private XRTableCell xrTableCell42;
    private XRTableCell xrTableCell43;
    private XRTableCell xrTableCell44;
    private XRTableCell xrTableCell45;
    private XRTableCell xrTableCell46;
    private XRTableCell xrTableCell47;
    private XRTableCell xrTableCell48;
    private XRTableCell xrTableCell49;
    private XRTableCell xrTableCell50;
    private XRTableCell xrTableCell51;
    private XRTableCell xrTableCell52;
    private XRTableCell xrTableCell53;
    private XRTableCell xrTableCell54;
    private XRTableCell xrTableCell55;
    private XRTableCell xrTableCell56;
    private XRTableCell xrTableCell57;
    private XRTableCell xrTableCell58;
    private XRTableCell xrTableCell59;
    private XRTableCell xrTableCell60;
    private XRTableCell xrTableCell61;
    private XRTableCell xrTableCell62;
    private XRTableCell xrTableCell63;
    private XRTableCell xrTableCell64;
    private XRTableCell xrTableCell65;
    private XRTableCell xrTableCell66;
    private XRTableCell xrTableCell67;
    private XRTableCell xrTableCell68;
    private XRTableCell xrTableCell69;
    private XRTableCell xrTableCell70;
    private XRTableCell xrTableCell71;
    private XRTableCell xrTableCell72;
    private XRTableCell xrTableCell73;
    private XRTableCell xrTableCell74;
    private XRTableCell xrTableCell75;
    private XRTableCell xrTableCell76;
    private XRTableCell xrTableCell77;
    private XRTableCell xrTableCell78;
    private XRTableCell xrTableCell79;
    private XRTableCell xrTableCell80;
    private XRTableCell xrTableCell81;
    private XRTableCell xrTableCell82;
    private XRTableCell xrTableCell83;
    private XRTableCell xrTableCell84;
    private XRTableCell xrTableCell85;
    private XRTableCell xrTableCell86;
    private XRTableCell xrTableCell87;
    private XRTableCell xrTableCell88;
    private XRTableCell xrTableCell89;
    private XRTableCell xrTableCell90;
    private XRTableCell xrTableCell91;
    private XRTableCell xrTableCell92;
    private XRTableCell xrTableCell93;
    private XRTableCell xrTableCell94;
    private XRTableCell xrTableCell95;
    private XRTableCell xrTableCell96;
    private XRTableCell xrTableCell97;
    private XRTableCell xrTableCell98;
    private XRLabel xrLabel3;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private DevExpress.XtraReports.Parameters.Parameter pReportName;
    private DevExpress.XtraReports.Parameters.Parameter pAreaCode;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ReportKehoachThuchiLVTM_NT_9M()
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
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            string resourceFileName = "ReportKehoachThuchiLVTM_NT_9M.resx";
            System.Resources.ResourceManager resources = global::Resources.ReportKehoachThuchiLVTM_NT_9M.ResourceManager;
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter6 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter7 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery2 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter8 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter9 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter10 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter11 = new DevExpress.DataAccess.Sql.QueryParameter();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.pageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.table1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell62 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell63 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell72 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell81 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell90 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell54 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell57 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell56 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell60 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell67 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell64 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell68 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell73 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell75 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell74 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell76 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell84 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell82 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell85 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell86 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell91 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell53 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell93 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell92 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell94 = new DevExpress.XtraReports.UI.XRTableCell();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.table2 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell55 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell59 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell58 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell61 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell69 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell70 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell65 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell71 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell77 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell79 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell78 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell80 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell87 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell83 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell88 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell89 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell95 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell98 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell96 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell97 = new DevExpress.XtraReports.UI.XRTableCell();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailCaption1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData3_Odd = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.pVersionID = new DevExpress.XtraReports.Parameters.Parameter();
            this.pCompanyID = new DevExpress.XtraReports.Parameters.Parameter();
            this.pFromMonth = new DevExpress.XtraReports.Parameters.Parameter();
            this.pToMonth = new DevExpress.XtraReports.Parameters.Parameter();
            this.pReportName = new DevExpress.XtraReports.Parameters.Parameter();
            this.pAreaCode = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 30F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.pageInfo2});
            this.BottomMargin.HeightF = 43.00008F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // pageInfo2
            // 
            this.pageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(3947.662F, 0F);
            this.pageInfo2.Name = "pageInfo2";
            this.pageInfo2.SizeF = new System.Drawing.SizeF(152.3384F, 23F);
            this.pageInfo2.StyleName = "PageInfo";
            this.pageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.pageInfo2.TextFormatString = "Page {0} of {1}";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel3,
            this.xrLabel4,
            this.xrPageInfo1,
            this.xrLabel2,
            this.xrLabel1,
            this.label1});
            this.ReportHeader.HeightF = 156.6667F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.xrLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(224.6748F, 79.00002F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(540.0001F, 22.99999F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseForeColor = false;
            this.xrLabel6.StylePriority.UsePadding = false;
            this.xrLabel6.Text = "Tỷ giá: [Query_1.Roe!N2]";
            // 
            // xrLabel5
            // 
            this.xrLabel5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "Iif([Query_1].[Curr]=\'VND\',  \'ĐVT: 1.000.000 VND\', \'\')\n")});
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(3947.662F, 102F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(152.3381F, 22.99998F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 24.19433F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(764.6751F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseForeColor = false;
            this.xrLabel3.StylePriority.UsePadding = false;
            this.xrLabel3.Text = "Version: [Query.VersionName]";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.xrLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 78.99999F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(224.6748F, 22.99999F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseForeColor = false;
            this.xrLabel4.StylePriority.UsePadding = false;
            this.xrLabel4.Text = "Loại tiền: [Query_1.Curr]";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.xrPageInfo1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 125F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(764.6751F, 23.00001F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseForeColor = false;
            this.xrPageInfo1.StylePriority.UsePadding = false;
            this.xrPageInfo1.TextFormatString = "Ngày giờ chạy báo cáo: {0:dd/MM/yyyy HH:mm}";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.xrLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 102F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(764.6751F, 22.99999F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseForeColor = false;
            this.xrLabel2.StylePriority.UsePadding = false;
            this.xrLabel2.Text = "Từ tháng [?pFromMonth] đến tháng [?pToMonth]/[Query.VersionYear]";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 47.19433F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(764.6751F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseForeColor = false;
            this.xrLabel1.StylePriority.UsePadding = false;
            this.xrLabel1.Text = "Đơn vị: [Query_1.NameV]";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.label1.Name = "label1";
            this.label1.SizeF = new System.Drawing.SizeF(764.6751F, 24.19433F);
            this.label1.StyleName = "Title";
            this.label1.StylePriority.UseFont = false;
            this.label1.Text = "BÁO CÁO KẾ HOẠCH THU CHI LVTM";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table1});
            this.GroupHeader1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.GroupHeader1.HeightF = 84.66665F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // table1
            // 
            this.table1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.table1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0.6666718F);
            this.table1.Name = "table1";
            this.table1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1,
            this.tableRow1,
            this.xrTableRow2});
            this.table1.SizeF = new System.Drawing.SizeF(4100F, 83.99998F);
            this.table1.StylePriority.UseBorders = false;
            this.table1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell6,
            this.xrTableCell9,
            this.xrTableCell12,
            this.xrTableCell15,
            this.xrTableCell18,
            this.xrTableCell21,
            this.xrTableCell22,
            this.xrTableCell23,
            this.xrTableCell24,
            this.xrTableCell25});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell1.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell1.BorderWidth = 1F;
            this.xrTableCell1.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell1.Multiline = true;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.RowSpan = 3;
            this.xrTableCell1.StyleName = "DetailCaption1";
            this.xrTableCell1.StylePriority.UseBackColor = false;
            this.xrTableCell1.StylePriority.UseBorderColor = false;
            this.xrTableCell1.StylePriority.UseBorders = false;
            this.xrTableCell1.StylePriority.UseBorderWidth = false;
            this.xrTableCell1.StylePriority.UseForeColor = false;
            this.xrTableCell1.Text = "TT";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell1.Weight = 0.017809512475562748D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell2.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell2.BorderWidth = 1F;
            this.xrTableCell2.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.RowSpan = 3;
            this.xrTableCell2.StyleName = "DetailCaption1";
            this.xrTableCell2.StylePriority.UseBackColor = false;
            this.xrTableCell2.StylePriority.UseBorderColor = false;
            this.xrTableCell2.StylePriority.UseBorders = false;
            this.xrTableCell2.StylePriority.UseBorderWidth = false;
            this.xrTableCell2.StylePriority.UseForeColor = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "Description";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell2.Weight = 0.07344751380823486D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell3.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell3.BorderWidth = 1F;
            this.xrTableCell3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Query].[VersionName1]")});
            this.xrTableCell3.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StyleName = "DetailCaption1";
            this.xrTableCell3.StylePriority.UseBackColor = false;
            this.xrTableCell3.StylePriority.UseBorderColor = false;
            this.xrTableCell3.StylePriority.UseBorders = false;
            this.xrTableCell3.StylePriority.UseBorderWidth = false;
            this.xrTableCell3.StylePriority.UseForeColor = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell3.Weight = 0.10966692534383762D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell6.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell6.BorderWidth = 1F;
            this.xrTableCell6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Query].[VersionName2]")});
            this.xrTableCell6.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell6.Multiline = true;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StyleName = "DetailCaption1";
            this.xrTableCell6.StylePriority.UseBackColor = false;
            this.xrTableCell6.StylePriority.UseBorderColor = false;
            this.xrTableCell6.StylePriority.UseBorders = false;
            this.xrTableCell6.StylePriority.UseBorderWidth = false;
            this.xrTableCell6.StylePriority.UseForeColor = false;
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell6.Weight = 0.10966701742079629D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell9.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell9.BorderWidth = 1F;
            this.xrTableCell9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Query].[VersionName3]")});
            this.xrTableCell9.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell9.Multiline = true;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StyleName = "DetailCaption1";
            this.xrTableCell9.StylePriority.UseBackColor = false;
            this.xrTableCell9.StylePriority.UseBorderColor = false;
            this.xrTableCell9.StylePriority.UseBorders = false;
            this.xrTableCell9.StylePriority.UseBorderWidth = false;
            this.xrTableCell9.StylePriority.UseForeColor = false;
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell9.Weight = 0.10966695854244971D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell12.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell12.BorderWidth = 1F;
            this.xrTableCell12.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Query].[VersionName4]")});
            this.xrTableCell12.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell12.Multiline = true;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.StyleName = "DetailCaption1";
            this.xrTableCell12.StylePriority.UseBackColor = false;
            this.xrTableCell12.StylePriority.UseBorderColor = false;
            this.xrTableCell12.StylePriority.UseBorders = false;
            this.xrTableCell12.StylePriority.UseBorderWidth = false;
            this.xrTableCell12.StylePriority.UseForeColor = false;
            this.xrTableCell12.StylePriority.UseTextAlignment = false;
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell12.Weight = 0.10966683148917553D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell15.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell15.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell15.BorderWidth = 1F;
            this.xrTableCell15.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Query].[VersionName5]")});
            this.xrTableCell15.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell15.Multiline = true;
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.StyleName = "DetailCaption1";
            this.xrTableCell15.StylePriority.UseBackColor = false;
            this.xrTableCell15.StylePriority.UseBorderColor = false;
            this.xrTableCell15.StylePriority.UseBorders = false;
            this.xrTableCell15.StylePriority.UseBorderWidth = false;
            this.xrTableCell15.StylePriority.UseForeColor = false;
            this.xrTableCell15.StylePriority.UseTextAlignment = false;
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell15.Weight = 0.10966703601395837D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell18.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell18.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell18.BorderWidth = 1F;
            this.xrTableCell18.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Query].[VersionName]")});
            this.xrTableCell18.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell18.Multiline = true;
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.StyleName = "DetailCaption1";
            this.xrTableCell18.StylePriority.UseBackColor = false;
            this.xrTableCell18.StylePriority.UseBorderColor = false;
            this.xrTableCell18.StylePriority.UseBorders = false;
            this.xrTableCell18.StylePriority.UseBorderWidth = false;
            this.xrTableCell18.StylePriority.UseForeColor = false;
            this.xrTableCell18.StylePriority.UseTextAlignment = false;
            this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell18.Weight = 0.10966688262037122D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell21.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell21.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell21.BorderWidth = 1F;
            this.xrTableCell21.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell21.Multiline = true;
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.StyleName = "DetailCaption1";
            this.xrTableCell21.StylePriority.UseBackColor = false;
            this.xrTableCell21.StylePriority.UseBorderColor = false;
            this.xrTableCell21.StylePriority.UseBorders = false;
            this.xrTableCell21.StylePriority.UseBorderWidth = false;
            this.xrTableCell21.StylePriority.UseForeColor = false;
            this.xrTableCell21.StylePriority.UseTextAlignment = false;
            this.xrTableCell21.Text = "[Query.VersionName]/[Query.VersionName1]";
            this.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell21.Weight = 0.18399143611734356D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell22.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell22.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell22.BorderWidth = 1F;
            this.xrTableCell22.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell22.Multiline = true;
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.StyleName = "DetailCaption1";
            this.xrTableCell22.StylePriority.UseBackColor = false;
            this.xrTableCell22.StylePriority.UseBorderColor = false;
            this.xrTableCell22.StylePriority.UseBorders = false;
            this.xrTableCell22.StylePriority.UseBorderWidth = false;
            this.xrTableCell22.StylePriority.UseForeColor = false;
            this.xrTableCell22.StylePriority.UseTextAlignment = false;
            this.xrTableCell22.Text = "[Query.VersionName]/[Query.VersionName2]";
            this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell22.Weight = 0.18277792240599258D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell23.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell23.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell23.BorderWidth = 1F;
            this.xrTableCell23.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell23.Multiline = true;
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.StyleName = "DetailCaption1";
            this.xrTableCell23.StylePriority.UseBackColor = false;
            this.xrTableCell23.StylePriority.UseBorderColor = false;
            this.xrTableCell23.StylePriority.UseBorders = false;
            this.xrTableCell23.StylePriority.UseBorderWidth = false;
            this.xrTableCell23.StylePriority.UseForeColor = false;
            this.xrTableCell23.StylePriority.UseTextAlignment = false;
            this.xrTableCell23.Text = "[Query.VersionName]/[Query.VersionName3]";
            this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell23.Weight = 0.18277821989658585D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell24.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell24.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell24.BorderWidth = 1F;
            this.xrTableCell24.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell24.Multiline = true;
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.StyleName = "DetailCaption1";
            this.xrTableCell24.StylePriority.UseBackColor = false;
            this.xrTableCell24.StylePriority.UseBorderColor = false;
            this.xrTableCell24.StylePriority.UseBorders = false;
            this.xrTableCell24.StylePriority.UseBorderWidth = false;
            this.xrTableCell24.StylePriority.UseForeColor = false;
            this.xrTableCell24.StylePriority.UseTextAlignment = false;
            this.xrTableCell24.Text = "[Query.VersionName]/[Query.VersionName4]";
            this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell24.Weight = 0.1827784197730781D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell25.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell25.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell25.BorderWidth = 1F;
            this.xrTableCell25.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell25.Multiline = true;
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.StyleName = "DetailCaption1";
            this.xrTableCell25.StylePriority.UseBackColor = false;
            this.xrTableCell25.StylePriority.UseBorderColor = false;
            this.xrTableCell25.StylePriority.UseBorders = false;
            this.xrTableCell25.StylePriority.UseBorderWidth = false;
            this.xrTableCell25.StylePriority.UseForeColor = false;
            this.xrTableCell25.StylePriority.UseTextAlignment = false;
            this.xrTableCell25.Text = "[Query.VersionName]/[Query.VersionName5]";
            this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell25.Weight = 0.1837278008673405D;
            // 
            // tableRow1
            // 
            this.tableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell1,
            this.tableCell2,
            this.tableCell3,
            this.tableCell4,
            this.tableCell5,
            this.tableCell6,
            this.tableCell7,
            this.tableCell8,
            this.tableCell9,
            this.tableCell10,
            this.tableCell11,
            this.tableCell12,
            this.tableCell13,
            this.tableCell14,
            this.tableCell15,
            this.tableCell16,
            this.tableCell17,
            this.tableCell18,
            this.tableCell19,
            this.tableCell20,
            this.tableCell21,
            this.xrTableCell11,
            this.tableCell22,
            this.xrTableCell13,
            this.xrTableCell62,
            this.xrTableCell63,
            this.tableCell23,
            this.xrTableCell14,
            this.xrTableCell72,
            this.tableCell24,
            this.xrTableCell81,
            this.xrTableCell16,
            this.tableCell25,
            this.xrTableCell17,
            this.xrTableCell90});
            this.tableRow1.Name = "tableRow1";
            this.tableRow1.Weight = 1D;
            // 
            // tableCell1
            // 
            this.tableCell1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell1.Name = "tableCell1";
            this.tableCell1.StyleName = "DetailCaption1";
            this.tableCell1.StylePriority.UseBorders = false;
            this.tableCell1.StylePriority.UseTextAlignment = false;
            this.tableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell1.Weight = 0.017809512475562748D;
            // 
            // tableCell2
            // 
            this.tableCell2.Name = "tableCell2";
            this.tableCell2.StyleName = "DetailCaption1";
            this.tableCell2.StylePriority.UseTextAlignment = false;
            this.tableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell2.Weight = 0.07344751380823486D;
            // 
            // tableCell3
            // 
            this.tableCell3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.tableCell3.BorderColor = System.Drawing.Color.Black;
            this.tableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell3.BorderWidth = 1F;
            this.tableCell3.ForeColor = System.Drawing.Color.Black;
            this.tableCell3.Name = "tableCell3";
            this.tableCell3.RowSpan = 2;
            this.tableCell3.StyleName = "DetailCaption1";
            this.tableCell3.StylePriority.UseBackColor = false;
            this.tableCell3.StylePriority.UseBorderColor = false;
            this.tableCell3.StylePriority.UseBorders = false;
            this.tableCell3.StylePriority.UseBorderWidth = false;
            this.tableCell3.StylePriority.UseForeColor = false;
            this.tableCell3.StylePriority.UseTextAlignment = false;
            this.tableCell3.Text = "ĐBHĐ";
            this.tableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell3.Weight = 0.036555645503283996D;
            // 
            // tableCell4
            // 
            this.tableCell4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.tableCell4.BorderColor = System.Drawing.Color.Black;
            this.tableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell4.BorderWidth = 1F;
            this.tableCell4.ForeColor = System.Drawing.Color.Black;
            this.tableCell4.Name = "tableCell4";
            this.tableCell4.RowSpan = 2;
            this.tableCell4.StyleName = "DetailCaption1";
            this.tableCell4.StylePriority.UseBackColor = false;
            this.tableCell4.StylePriority.UseBorderColor = false;
            this.tableCell4.StylePriority.UseBorders = false;
            this.tableCell4.StylePriority.UseBorderWidth = false;
            this.tableCell4.StylePriority.UseForeColor = false;
            this.tableCell4.StylePriority.UseTextAlignment = false;
            this.tableCell4.Text = "Nghiệp vụ";
            this.tableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell4.Weight = 0.036555643199379637D;
            // 
            // tableCell5
            // 
            this.tableCell5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.tableCell5.BorderColor = System.Drawing.Color.Black;
            this.tableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell5.BorderWidth = 1F;
            this.tableCell5.ForeColor = System.Drawing.Color.Black;
            this.tableCell5.Name = "tableCell5";
            this.tableCell5.RowSpan = 2;
            this.tableCell5.StyleName = "DetailCaption1";
            this.tableCell5.StylePriority.UseBackColor = false;
            this.tableCell5.StylePriority.UseBorderColor = false;
            this.tableCell5.StylePriority.UseBorders = false;
            this.tableCell5.StylePriority.UseBorderWidth = false;
            this.tableCell5.StylePriority.UseForeColor = false;
            this.tableCell5.StylePriority.UseTextAlignment = false;
            this.tableCell5.Text = "Tổng";
            this.tableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell5.Weight = 0.036555642838894696D;
            // 
            // tableCell6
            // 
            this.tableCell6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.tableCell6.BorderColor = System.Drawing.Color.Black;
            this.tableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell6.BorderWidth = 1F;
            this.tableCell6.ForeColor = System.Drawing.Color.Black;
            this.tableCell6.Name = "tableCell6";
            this.tableCell6.RowSpan = 2;
            this.tableCell6.StyleName = "DetailCaption1";
            this.tableCell6.StylePriority.UseBackColor = false;
            this.tableCell6.StylePriority.UseBorderColor = false;
            this.tableCell6.StylePriority.UseBorders = false;
            this.tableCell6.StylePriority.UseBorderWidth = false;
            this.tableCell6.StylePriority.UseForeColor = false;
            this.tableCell6.StylePriority.UseTextAlignment = false;
            this.tableCell6.Text = "ĐBHĐ";
            this.tableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell6.Weight = 0.03655564461443226D;
            // 
            // tableCell7
            // 
            this.tableCell7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.tableCell7.BorderColor = System.Drawing.Color.Black;
            this.tableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell7.BorderWidth = 1F;
            this.tableCell7.ForeColor = System.Drawing.Color.Black;
            this.tableCell7.Name = "tableCell7";
            this.tableCell7.RowSpan = 2;
            this.tableCell7.StyleName = "DetailCaption1";
            this.tableCell7.StylePriority.UseBackColor = false;
            this.tableCell7.StylePriority.UseBorderColor = false;
            this.tableCell7.StylePriority.UseBorders = false;
            this.tableCell7.StylePriority.UseBorderWidth = false;
            this.tableCell7.StylePriority.UseForeColor = false;
            this.tableCell7.StylePriority.UseTextAlignment = false;
            this.tableCell7.Text = "Nghiệp vụ";
            this.tableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell7.Weight = 0.036555643199379637D;
            // 
            // tableCell8
            // 
            this.tableCell8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.tableCell8.BorderColor = System.Drawing.Color.Black;
            this.tableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell8.BorderWidth = 1F;
            this.tableCell8.ForeColor = System.Drawing.Color.Black;
            this.tableCell8.Name = "tableCell8";
            this.tableCell8.RowSpan = 2;
            this.tableCell8.StyleName = "DetailCaption1";
            this.tableCell8.StylePriority.UseBackColor = false;
            this.tableCell8.StylePriority.UseBorderColor = false;
            this.tableCell8.StylePriority.UseBorders = false;
            this.tableCell8.StylePriority.UseBorderWidth = false;
            this.tableCell8.StylePriority.UseForeColor = false;
            this.tableCell8.StylePriority.UseTextAlignment = false;
            this.tableCell8.Text = "Tổng";
            this.tableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell8.Weight = 0.0365556428388947D;
            // 
            // tableCell9
            // 
            this.tableCell9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.tableCell9.BorderColor = System.Drawing.Color.Black;
            this.tableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell9.BorderWidth = 1F;
            this.tableCell9.ForeColor = System.Drawing.Color.Black;
            this.tableCell9.Name = "tableCell9";
            this.tableCell9.RowSpan = 2;
            this.tableCell9.StyleName = "DetailCaption1";
            this.tableCell9.StylePriority.UseBackColor = false;
            this.tableCell9.StylePriority.UseBorderColor = false;
            this.tableCell9.StylePriority.UseBorders = false;
            this.tableCell9.StylePriority.UseBorderWidth = false;
            this.tableCell9.StylePriority.UseForeColor = false;
            this.tableCell9.StylePriority.UseTextAlignment = false;
            this.tableCell9.Text = "ĐBHĐ";
            this.tableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell9.Weight = 0.036555644614432267D;
            // 
            // tableCell10
            // 
            this.tableCell10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.tableCell10.BorderColor = System.Drawing.Color.Black;
            this.tableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell10.BorderWidth = 1F;
            this.tableCell10.ForeColor = System.Drawing.Color.Black;
            this.tableCell10.Name = "tableCell10";
            this.tableCell10.RowSpan = 2;
            this.tableCell10.StyleName = "DetailCaption1";
            this.tableCell10.StylePriority.UseBackColor = false;
            this.tableCell10.StylePriority.UseBorderColor = false;
            this.tableCell10.StylePriority.UseBorders = false;
            this.tableCell10.StylePriority.UseBorderWidth = false;
            this.tableCell10.StylePriority.UseForeColor = false;
            this.tableCell10.StylePriority.UseTextAlignment = false;
            this.tableCell10.Text = "Nghiệp vụ";
            this.tableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell10.Weight = 0.036555643199379637D;
            // 
            // tableCell11
            // 
            this.tableCell11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.tableCell11.BorderColor = System.Drawing.Color.Black;
            this.tableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell11.BorderWidth = 1F;
            this.tableCell11.ForeColor = System.Drawing.Color.Black;
            this.tableCell11.Name = "tableCell11";
            this.tableCell11.RowSpan = 2;
            this.tableCell11.StyleName = "DetailCaption1";
            this.tableCell11.StylePriority.UseBackColor = false;
            this.tableCell11.StylePriority.UseBorderColor = false;
            this.tableCell11.StylePriority.UseBorders = false;
            this.tableCell11.StylePriority.UseBorderWidth = false;
            this.tableCell11.StylePriority.UseForeColor = false;
            this.tableCell11.StylePriority.UseTextAlignment = false;
            this.tableCell11.Text = "Tổng";
            this.tableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell11.Weight = 0.036555642838894689D;
            // 
            // tableCell12
            // 
            this.tableCell12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.tableCell12.BorderColor = System.Drawing.Color.Black;
            this.tableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell12.BorderWidth = 1F;
            this.tableCell12.ForeColor = System.Drawing.Color.Black;
            this.tableCell12.Name = "tableCell12";
            this.tableCell12.RowSpan = 2;
            this.tableCell12.StyleName = "DetailCaption1";
            this.tableCell12.StylePriority.UseBackColor = false;
            this.tableCell12.StylePriority.UseBorderColor = false;
            this.tableCell12.StylePriority.UseBorders = false;
            this.tableCell12.StylePriority.UseBorderWidth = false;
            this.tableCell12.StylePriority.UseForeColor = false;
            this.tableCell12.StylePriority.UseTextAlignment = false;
            this.tableCell12.Text = "ĐBHĐ";
            this.tableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell12.Weight = 0.036555644614432267D;
            // 
            // tableCell13
            // 
            this.tableCell13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.tableCell13.BorderColor = System.Drawing.Color.Black;
            this.tableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell13.BorderWidth = 1F;
            this.tableCell13.ForeColor = System.Drawing.Color.Black;
            this.tableCell13.Name = "tableCell13";
            this.tableCell13.RowSpan = 2;
            this.tableCell13.StyleName = "DetailCaption1";
            this.tableCell13.StylePriority.UseBackColor = false;
            this.tableCell13.StylePriority.UseBorderColor = false;
            this.tableCell13.StylePriority.UseBorders = false;
            this.tableCell13.StylePriority.UseBorderWidth = false;
            this.tableCell13.StylePriority.UseForeColor = false;
            this.tableCell13.StylePriority.UseTextAlignment = false;
            this.tableCell13.Text = "Nghiệp vụ";
            this.tableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell13.Weight = 0.036555646298239985D;
            // 
            // tableCell14
            // 
            this.tableCell14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.tableCell14.BorderColor = System.Drawing.Color.Black;
            this.tableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell14.BorderWidth = 1F;
            this.tableCell14.ForeColor = System.Drawing.Color.Black;
            this.tableCell14.Name = "tableCell14";
            this.tableCell14.RowSpan = 2;
            this.tableCell14.StyleName = "DetailCaption1";
            this.tableCell14.StylePriority.UseBackColor = false;
            this.tableCell14.StylePriority.UseBorderColor = false;
            this.tableCell14.StylePriority.UseBorders = false;
            this.tableCell14.StylePriority.UseBorderWidth = false;
            this.tableCell14.StylePriority.UseForeColor = false;
            this.tableCell14.StylePriority.UseTextAlignment = false;
            this.tableCell14.Text = "Tổng";
            this.tableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell14.Weight = 0.036555642838894689D;
            // 
            // tableCell15
            // 
            this.tableCell15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.tableCell15.BorderColor = System.Drawing.Color.Black;
            this.tableCell15.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell15.BorderWidth = 1F;
            this.tableCell15.ForeColor = System.Drawing.Color.Black;
            this.tableCell15.Name = "tableCell15";
            this.tableCell15.RowSpan = 2;
            this.tableCell15.StyleName = "DetailCaption1";
            this.tableCell15.StylePriority.UseBackColor = false;
            this.tableCell15.StylePriority.UseBorderColor = false;
            this.tableCell15.StylePriority.UseBorders = false;
            this.tableCell15.StylePriority.UseBorderWidth = false;
            this.tableCell15.StylePriority.UseForeColor = false;
            this.tableCell15.StylePriority.UseTextAlignment = false;
            this.tableCell15.Text = "ĐBHĐ";
            this.tableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell15.Weight = 0.036555644614432267D;
            // 
            // tableCell16
            // 
            this.tableCell16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.tableCell16.BorderColor = System.Drawing.Color.Black;
            this.tableCell16.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell16.BorderWidth = 1F;
            this.tableCell16.ForeColor = System.Drawing.Color.Black;
            this.tableCell16.Name = "tableCell16";
            this.tableCell16.RowSpan = 2;
            this.tableCell16.StyleName = "DetailCaption1";
            this.tableCell16.StylePriority.UseBackColor = false;
            this.tableCell16.StylePriority.UseBorderColor = false;
            this.tableCell16.StylePriority.UseBorders = false;
            this.tableCell16.StylePriority.UseBorderWidth = false;
            this.tableCell16.StylePriority.UseForeColor = false;
            this.tableCell16.StylePriority.UseTextAlignment = false;
            this.tableCell16.Text = "Nghiệp vụ";
            this.tableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell16.Weight = 0.036555643199379644D;
            // 
            // tableCell17
            // 
            this.tableCell17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.tableCell17.BorderColor = System.Drawing.Color.Black;
            this.tableCell17.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell17.BorderWidth = 1F;
            this.tableCell17.ForeColor = System.Drawing.Color.Black;
            this.tableCell17.Name = "tableCell17";
            this.tableCell17.RowSpan = 2;
            this.tableCell17.StyleName = "DetailCaption1";
            this.tableCell17.StylePriority.UseBackColor = false;
            this.tableCell17.StylePriority.UseBorderColor = false;
            this.tableCell17.StylePriority.UseBorders = false;
            this.tableCell17.StylePriority.UseBorderWidth = false;
            this.tableCell17.StylePriority.UseForeColor = false;
            this.tableCell17.StylePriority.UseTextAlignment = false;
            this.tableCell17.Text = "Tổng";
            this.tableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell17.Weight = 0.0365556428388947D;
            // 
            // tableCell18
            // 
            this.tableCell18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.tableCell18.BorderColor = System.Drawing.Color.Black;
            this.tableCell18.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell18.BorderWidth = 1F;
            this.tableCell18.ForeColor = System.Drawing.Color.Black;
            this.tableCell18.Name = "tableCell18";
            this.tableCell18.RowSpan = 2;
            this.tableCell18.StyleName = "DetailCaption1";
            this.tableCell18.StylePriority.UseBackColor = false;
            this.tableCell18.StylePriority.UseBorderColor = false;
            this.tableCell18.StylePriority.UseBorders = false;
            this.tableCell18.StylePriority.UseBorderWidth = false;
            this.tableCell18.StylePriority.UseForeColor = false;
            this.tableCell18.StylePriority.UseTextAlignment = false;
            this.tableCell18.Text = "ĐBHĐ";
            this.tableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell18.Weight = 0.036555641515571925D;
            // 
            // tableCell19
            // 
            this.tableCell19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.tableCell19.BorderColor = System.Drawing.Color.Black;
            this.tableCell19.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell19.BorderWidth = 1F;
            this.tableCell19.ForeColor = System.Drawing.Color.Black;
            this.tableCell19.Name = "tableCell19";
            this.tableCell19.RowSpan = 2;
            this.tableCell19.StyleName = "DetailCaption1";
            this.tableCell19.StylePriority.UseBackColor = false;
            this.tableCell19.StylePriority.UseBorderColor = false;
            this.tableCell19.StylePriority.UseBorders = false;
            this.tableCell19.StylePriority.UseBorderWidth = false;
            this.tableCell19.StylePriority.UseForeColor = false;
            this.tableCell19.StylePriority.UseTextAlignment = false;
            this.tableCell19.Text = "Nghiệp vụ";
            this.tableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell19.Weight = 0.036555646298239965D;
            // 
            // tableCell20
            // 
            this.tableCell20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.tableCell20.BorderColor = System.Drawing.Color.Black;
            this.tableCell20.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell20.BorderWidth = 1F;
            this.tableCell20.ForeColor = System.Drawing.Color.Black;
            this.tableCell20.Name = "tableCell20";
            this.tableCell20.RowSpan = 2;
            this.tableCell20.StyleName = "DetailCaption1";
            this.tableCell20.StylePriority.UseBackColor = false;
            this.tableCell20.StylePriority.UseBorderColor = false;
            this.tableCell20.StylePriority.UseBorders = false;
            this.tableCell20.StylePriority.UseBorderWidth = false;
            this.tableCell20.StylePriority.UseForeColor = false;
            this.tableCell20.StylePriority.UseTextAlignment = false;
            this.tableCell20.Text = "Tổng";
            this.tableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell20.Weight = 0.036555700167811088D;
            // 
            // tableCell21
            // 
            this.tableCell21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.tableCell21.BorderColor = System.Drawing.Color.Black;
            this.tableCell21.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell21.BorderWidth = 1F;
            this.tableCell21.ForeColor = System.Drawing.Color.Black;
            this.tableCell21.Name = "tableCell21";
            this.tableCell21.StyleName = "DetailCaption1";
            this.tableCell21.StylePriority.UseBackColor = false;
            this.tableCell21.StylePriority.UseBorderColor = false;
            this.tableCell21.StylePriority.UseBorders = false;
            this.tableCell21.StylePriority.UseBorderWidth = false;
            this.tableCell21.StylePriority.UseForeColor = false;
            this.tableCell21.StylePriority.UseTextAlignment = false;
            this.tableCell21.Text = "ĐBHĐ";
            this.tableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell21.Weight = 0.060926073206556117D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell11.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell11.BorderWidth = 1F;
            this.xrTableCell11.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell11.Multiline = true;
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.StyleName = "DetailCaption1";
            this.xrTableCell11.StylePriority.UseBackColor = false;
            this.xrTableCell11.StylePriority.UseBorderColor = false;
            this.xrTableCell11.StylePriority.UseBorders = false;
            this.xrTableCell11.StylePriority.UseBorderWidth = false;
            this.xrTableCell11.StylePriority.UseForeColor = false;
            this.xrTableCell11.StylePriority.UseTextAlignment = false;
            this.xrTableCell11.Text = "Nghiệp vụ";
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell11.Weight = 0.0621391902637828D;
            // 
            // tableCell22
            // 
            this.tableCell22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.tableCell22.BorderColor = System.Drawing.Color.Black;
            this.tableCell22.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell22.BorderWidth = 1F;
            this.tableCell22.ForeColor = System.Drawing.Color.Black;
            this.tableCell22.Name = "tableCell22";
            this.tableCell22.StyleName = "DetailCaption1";
            this.tableCell22.StylePriority.UseBackColor = false;
            this.tableCell22.StylePriority.UseBorderColor = false;
            this.tableCell22.StylePriority.UseBorders = false;
            this.tableCell22.StylePriority.UseBorderWidth = false;
            this.tableCell22.StylePriority.UseForeColor = false;
            this.tableCell22.StylePriority.UseTextAlignment = false;
            this.tableCell22.Text = "Tổng";
            this.tableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell22.Weight = 0.060926073206556131D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell13.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell13.BorderWidth = 1F;
            this.xrTableCell13.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell13.Multiline = true;
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.StyleName = "DetailCaption1";
            this.xrTableCell13.StylePriority.UseBackColor = false;
            this.xrTableCell13.StylePriority.UseBorderColor = false;
            this.xrTableCell13.StylePriority.UseBorders = false;
            this.xrTableCell13.StylePriority.UseBorderWidth = false;
            this.xrTableCell13.StylePriority.UseForeColor = false;
            this.xrTableCell13.StylePriority.UseTextAlignment = false;
            this.xrTableCell13.Text = "ĐBHĐ";
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell13.Weight = 0.06092607334501484D;
            // 
            // xrTableCell62
            // 
            this.xrTableCell62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell62.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell62.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell62.BorderWidth = 1F;
            this.xrTableCell62.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell62.Multiline = true;
            this.xrTableCell62.Name = "xrTableCell62";
            this.xrTableCell62.StyleName = "DetailCaption1";
            this.xrTableCell62.StylePriority.UseBackColor = false;
            this.xrTableCell62.StylePriority.UseBorderColor = false;
            this.xrTableCell62.StylePriority.UseBorders = false;
            this.xrTableCell62.StylePriority.UseBorderWidth = false;
            this.xrTableCell62.StylePriority.UseForeColor = false;
            this.xrTableCell62.StylePriority.UseTextAlignment = false;
            this.xrTableCell62.Text = "Nghiệp vụ";
            this.xrTableCell62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell62.Weight = 0.060926073414244185D;
            // 
            // xrTableCell63
            // 
            this.xrTableCell63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell63.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell63.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell63.BorderWidth = 1F;
            this.xrTableCell63.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell63.Multiline = true;
            this.xrTableCell63.Name = "xrTableCell63";
            this.xrTableCell63.StyleName = "DetailCaption1";
            this.xrTableCell63.StylePriority.UseBackColor = false;
            this.xrTableCell63.StylePriority.UseBorderColor = false;
            this.xrTableCell63.StylePriority.UseBorders = false;
            this.xrTableCell63.StylePriority.UseBorderWidth = false;
            this.xrTableCell63.StylePriority.UseForeColor = false;
            this.xrTableCell63.StylePriority.UseTextAlignment = false;
            this.xrTableCell63.Text = "Tổng";
            this.xrTableCell63.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell63.Weight = 0.060926023832478658D;
            // 
            // tableCell23
            // 
            this.tableCell23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.tableCell23.BorderColor = System.Drawing.Color.Black;
            this.tableCell23.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell23.BorderWidth = 1F;
            this.tableCell23.ForeColor = System.Drawing.Color.Black;
            this.tableCell23.Name = "tableCell23";
            this.tableCell23.StyleName = "DetailCaption1";
            this.tableCell23.StylePriority.UseBackColor = false;
            this.tableCell23.StylePriority.UseBorderColor = false;
            this.tableCell23.StylePriority.UseBorders = false;
            this.tableCell23.StylePriority.UseBorderWidth = false;
            this.tableCell23.StylePriority.UseForeColor = false;
            this.tableCell23.StylePriority.UseTextAlignment = false;
            this.tableCell23.Text = "ĐBHĐ";
            this.tableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell23.Weight = 0.06092607320655611D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell14.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell14.BorderWidth = 1F;
            this.xrTableCell14.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell14.Multiline = true;
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.StyleName = "DetailCaption1";
            this.xrTableCell14.StylePriority.UseBackColor = false;
            this.xrTableCell14.StylePriority.UseBorderColor = false;
            this.xrTableCell14.StylePriority.UseBorders = false;
            this.xrTableCell14.StylePriority.UseBorderWidth = false;
            this.xrTableCell14.StylePriority.UseForeColor = false;
            this.xrTableCell14.StylePriority.UseTextAlignment = false;
            this.xrTableCell14.Text = "Nghiệp vụ";
            this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell14.Weight = 0.060926073345014826D;
            // 
            // xrTableCell72
            // 
            this.xrTableCell72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell72.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell72.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell72.BorderWidth = 1F;
            this.xrTableCell72.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell72.Multiline = true;
            this.xrTableCell72.Name = "xrTableCell72";
            this.xrTableCell72.StyleName = "DetailCaption1";
            this.xrTableCell72.StylePriority.UseBackColor = false;
            this.xrTableCell72.StylePriority.UseBorderColor = false;
            this.xrTableCell72.StylePriority.UseBorders = false;
            this.xrTableCell72.StylePriority.UseBorderWidth = false;
            this.xrTableCell72.StylePriority.UseForeColor = false;
            this.xrTableCell72.StylePriority.UseTextAlignment = false;
            this.xrTableCell72.Text = "Tổng";
            this.xrTableCell72.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell72.Weight = 0.060925974181483759D;
            // 
            // tableCell24
            // 
            this.tableCell24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.tableCell24.BorderColor = System.Drawing.Color.Black;
            this.tableCell24.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell24.BorderWidth = 1F;
            this.tableCell24.ForeColor = System.Drawing.Color.Black;
            this.tableCell24.Name = "tableCell24";
            this.tableCell24.StyleName = "DetailCaption1";
            this.tableCell24.StylePriority.UseBackColor = false;
            this.tableCell24.StylePriority.UseBorderColor = false;
            this.tableCell24.StylePriority.UseBorders = false;
            this.tableCell24.StylePriority.UseBorderWidth = false;
            this.tableCell24.StylePriority.UseForeColor = false;
            this.tableCell24.StylePriority.UseTextAlignment = false;
            this.tableCell24.Text = "ĐBHĐ";
            this.tableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell24.Weight = 0.060926172895903428D;
            // 
            // xrTableCell81
            // 
            this.xrTableCell81.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell81.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell81.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell81.BorderWidth = 1F;
            this.xrTableCell81.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell81.Multiline = true;
            this.xrTableCell81.Name = "xrTableCell81";
            this.xrTableCell81.StyleName = "DetailCaption1";
            this.xrTableCell81.StylePriority.UseBackColor = false;
            this.xrTableCell81.StylePriority.UseBorderColor = false;
            this.xrTableCell81.StylePriority.UseBorders = false;
            this.xrTableCell81.StylePriority.UseBorderWidth = false;
            this.xrTableCell81.StylePriority.UseForeColor = false;
            this.xrTableCell81.StylePriority.UseTextAlignment = false;
            this.xrTableCell81.Text = "Nghiệp vụ";
            this.xrTableCell81.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell81.Weight = 0.060926073732372361D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell16.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell16.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell16.BorderWidth = 1F;
            this.xrTableCell16.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell16.Multiline = true;
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.StyleName = "DetailCaption1";
            this.xrTableCell16.StylePriority.UseBackColor = false;
            this.xrTableCell16.StylePriority.UseBorderColor = false;
            this.xrTableCell16.StylePriority.UseBorders = false;
            this.xrTableCell16.StylePriority.UseBorderWidth = false;
            this.xrTableCell16.StylePriority.UseForeColor = false;
            this.xrTableCell16.StylePriority.UseTextAlignment = false;
            this.xrTableCell16.Text = "Tổng";
            this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell16.Weight = 0.060926073981271242D;
            // 
            // tableCell25
            // 
            this.tableCell25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.tableCell25.BorderColor = System.Drawing.Color.Black;
            this.tableCell25.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell25.BorderWidth = 1F;
            this.tableCell25.ForeColor = System.Drawing.Color.Black;
            this.tableCell25.Name = "tableCell25";
            this.tableCell25.StyleName = "DetailCaption1";
            this.tableCell25.StylePriority.UseBackColor = false;
            this.tableCell25.StylePriority.UseBorderColor = false;
            this.tableCell25.StylePriority.UseBorders = false;
            this.tableCell25.StylePriority.UseBorderWidth = false;
            this.tableCell25.StylePriority.UseForeColor = false;
            this.tableCell25.StylePriority.UseTextAlignment = false;
            this.tableCell25.Text = "ĐBHĐ 9 tháng";
            this.tableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell25.Weight = 0.060926074959514243D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell17.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell17.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell17.BorderWidth = 1F;
            this.xrTableCell17.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell17.Multiline = true;
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.StyleName = "DetailCaption1";
            this.xrTableCell17.StylePriority.UseBackColor = false;
            this.xrTableCell17.StylePriority.UseBorderColor = false;
            this.xrTableCell17.StylePriority.UseBorders = false;
            this.xrTableCell17.StylePriority.UseBorderWidth = false;
            this.xrTableCell17.StylePriority.UseForeColor = false;
            this.xrTableCell17.StylePriority.UseTextAlignment = false;
            this.xrTableCell17.Text = "Nghiệp vụ 9 tháng";
            this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell17.Weight = 0.060926071122633547D;
            // 
            // xrTableCell90
            // 
            this.xrTableCell90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell90.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell90.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell90.BorderWidth = 1F;
            this.xrTableCell90.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell90.Multiline = true;
            this.xrTableCell90.Name = "xrTableCell90";
            this.xrTableCell90.StyleName = "DetailCaption1";
            this.xrTableCell90.StylePriority.UseBackColor = false;
            this.xrTableCell90.StylePriority.UseBorderColor = false;
            this.xrTableCell90.StylePriority.UseBorders = false;
            this.xrTableCell90.StylePriority.UseBorderWidth = false;
            this.xrTableCell90.StylePriority.UseForeColor = false;
            this.xrTableCell90.StylePriority.UseTextAlignment = false;
            this.xrTableCell90.Text = "Tổng";
            this.xrTableCell90.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell90.Weight = 0.061875710564678887D;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell19,
            this.xrTableCell20,
            this.xrTableCell26,
            this.xrTableCell27,
            this.xrTableCell28,
            this.xrTableCell29,
            this.xrTableCell30,
            this.xrTableCell31,
            this.xrTableCell32,
            this.xrTableCell33,
            this.xrTableCell34,
            this.xrTableCell35,
            this.xrTableCell36,
            this.xrTableCell37,
            this.xrTableCell38,
            this.xrTableCell39,
            this.xrTableCell40,
            this.xrTableCell41,
            this.xrTableCell42,
            this.xrTableCell43,
            this.xrTableCell44,
            this.xrTableCell54,
            this.xrTableCell45,
            this.xrTableCell57,
            this.xrTableCell56,
            this.xrTableCell60,
            this.xrTableCell46,
            this.xrTableCell66,
            this.xrTableCell47,
            this.xrTableCell67,
            this.xrTableCell64,
            this.xrTableCell68,
            this.xrTableCell48,
            this.xrTableCell73,
            this.xrTableCell49,
            this.xrTableCell75,
            this.xrTableCell74,
            this.xrTableCell76,
            this.xrTableCell50,
            this.xrTableCell84,
            this.xrTableCell82,
            this.xrTableCell85,
            this.xrTableCell51,
            this.xrTableCell86,
            this.xrTableCell52,
            this.xrTableCell91,
            this.xrTableCell53,
            this.xrTableCell93,
            this.xrTableCell92,
            this.xrTableCell94});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell19.Multiline = true;
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.StyleName = "DetailCaption1";
            this.xrTableCell19.StylePriority.UseBorders = false;
            this.xrTableCell19.StylePriority.UseTextAlignment = false;
            this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell19.Weight = 0.017809512475562748D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Multiline = true;
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.StyleName = "DetailCaption1";
            this.xrTableCell20.StylePriority.UseTextAlignment = false;
            this.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell20.Weight = 0.07344751380823486D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell26.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell26.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell26.BorderWidth = 1F;
            this.xrTableCell26.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell26.Multiline = true;
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.StyleName = "DetailCaption1";
            this.xrTableCell26.StylePriority.UseBackColor = false;
            this.xrTableCell26.StylePriority.UseBorderColor = false;
            this.xrTableCell26.StylePriority.UseBorders = false;
            this.xrTableCell26.StylePriority.UseBorderWidth = false;
            this.xrTableCell26.StylePriority.UseForeColor = false;
            this.xrTableCell26.StylePriority.UseTextAlignment = false;
            this.xrTableCell26.Text = "xrTableCell26";
            this.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell26.Weight = 0.036555620712401225D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell27.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell27.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell27.BorderWidth = 1F;
            this.xrTableCell27.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell27.Multiline = true;
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.StyleName = "DetailCaption1";
            this.xrTableCell27.StylePriority.UseBackColor = false;
            this.xrTableCell27.StylePriority.UseBorderColor = false;
            this.xrTableCell27.StylePriority.UseBorders = false;
            this.xrTableCell27.StylePriority.UseBorderWidth = false;
            this.xrTableCell27.StylePriority.UseForeColor = false;
            this.xrTableCell27.StylePriority.UseTextAlignment = false;
            this.xrTableCell27.Text = "xrTableCell27";
            this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell27.Weight = 0.036555667990262407D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell28.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell28.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell28.BorderWidth = 1F;
            this.xrTableCell28.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell28.Multiline = true;
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.StyleName = "DetailCaption1";
            this.xrTableCell28.StylePriority.UseBackColor = false;
            this.xrTableCell28.StylePriority.UseBorderColor = false;
            this.xrTableCell28.StylePriority.UseBorders = false;
            this.xrTableCell28.StylePriority.UseBorderWidth = false;
            this.xrTableCell28.StylePriority.UseForeColor = false;
            this.xrTableCell28.StylePriority.UseTextAlignment = false;
            this.xrTableCell28.Text = "xrTableCell28";
            this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell28.Weight = 0.036555642838894696D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell29.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell29.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell29.BorderWidth = 1F;
            this.xrTableCell29.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell29.Multiline = true;
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.StyleName = "DetailCaption1";
            this.xrTableCell29.StylePriority.UseBackColor = false;
            this.xrTableCell29.StylePriority.UseBorderColor = false;
            this.xrTableCell29.StylePriority.UseBorders = false;
            this.xrTableCell29.StylePriority.UseBorderWidth = false;
            this.xrTableCell29.StylePriority.UseForeColor = false;
            this.xrTableCell29.StylePriority.UseTextAlignment = false;
            this.xrTableCell29.Text = "xrTableCell29";
            this.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell29.Weight = 0.03655564461443226D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell30.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell30.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell30.BorderWidth = 1F;
            this.xrTableCell30.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell30.Multiline = true;
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.StyleName = "DetailCaption1";
            this.xrTableCell30.StylePriority.UseBackColor = false;
            this.xrTableCell30.StylePriority.UseBorderColor = false;
            this.xrTableCell30.StylePriority.UseBorders = false;
            this.xrTableCell30.StylePriority.UseBorderWidth = false;
            this.xrTableCell30.StylePriority.UseForeColor = false;
            this.xrTableCell30.StylePriority.UseTextAlignment = false;
            this.xrTableCell30.Text = "xrTableCell30";
            this.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell30.Weight = 0.036555643199379637D;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell31.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell31.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell31.BorderWidth = 1F;
            this.xrTableCell31.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell31.Multiline = true;
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.StyleName = "DetailCaption1";
            this.xrTableCell31.StylePriority.UseBackColor = false;
            this.xrTableCell31.StylePriority.UseBorderColor = false;
            this.xrTableCell31.StylePriority.UseBorders = false;
            this.xrTableCell31.StylePriority.UseBorderWidth = false;
            this.xrTableCell31.StylePriority.UseForeColor = false;
            this.xrTableCell31.StylePriority.UseTextAlignment = false;
            this.xrTableCell31.Text = "xrTableCell31";
            this.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell31.Weight = 0.036555642838894696D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell32.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell32.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell32.BorderWidth = 1F;
            this.xrTableCell32.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell32.Multiline = true;
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.StyleName = "DetailCaption1";
            this.xrTableCell32.StylePriority.UseBackColor = false;
            this.xrTableCell32.StylePriority.UseBorderColor = false;
            this.xrTableCell32.StylePriority.UseBorders = false;
            this.xrTableCell32.StylePriority.UseBorderWidth = false;
            this.xrTableCell32.StylePriority.UseForeColor = false;
            this.xrTableCell32.StylePriority.UseTextAlignment = false;
            this.xrTableCell32.Text = "xrTableCell32";
            this.xrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell32.Weight = 0.036555644614432267D;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell33.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell33.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell33.BorderWidth = 1F;
            this.xrTableCell33.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell33.Multiline = true;
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.StyleName = "DetailCaption1";
            this.xrTableCell33.StylePriority.UseBackColor = false;
            this.xrTableCell33.StylePriority.UseBorderColor = false;
            this.xrTableCell33.StylePriority.UseBorders = false;
            this.xrTableCell33.StylePriority.UseBorderWidth = false;
            this.xrTableCell33.StylePriority.UseForeColor = false;
            this.xrTableCell33.StylePriority.UseTextAlignment = false;
            this.xrTableCell33.Text = "xrTableCell33";
            this.xrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell33.Weight = 0.036555643199379637D;
            // 
            // xrTableCell34
            // 
            this.xrTableCell34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell34.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell34.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell34.BorderWidth = 1F;
            this.xrTableCell34.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell34.Multiline = true;
            this.xrTableCell34.Name = "xrTableCell34";
            this.xrTableCell34.StyleName = "DetailCaption1";
            this.xrTableCell34.StylePriority.UseBackColor = false;
            this.xrTableCell34.StylePriority.UseBorderColor = false;
            this.xrTableCell34.StylePriority.UseBorders = false;
            this.xrTableCell34.StylePriority.UseBorderWidth = false;
            this.xrTableCell34.StylePriority.UseForeColor = false;
            this.xrTableCell34.StylePriority.UseTextAlignment = false;
            this.xrTableCell34.Text = "xrTableCell34";
            this.xrTableCell34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell34.Weight = 0.036555642838894689D;
            // 
            // xrTableCell35
            // 
            this.xrTableCell35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell35.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell35.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell35.BorderWidth = 1F;
            this.xrTableCell35.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell35.Multiline = true;
            this.xrTableCell35.Name = "xrTableCell35";
            this.xrTableCell35.StyleName = "DetailCaption1";
            this.xrTableCell35.StylePriority.UseBackColor = false;
            this.xrTableCell35.StylePriority.UseBorderColor = false;
            this.xrTableCell35.StylePriority.UseBorders = false;
            this.xrTableCell35.StylePriority.UseBorderWidth = false;
            this.xrTableCell35.StylePriority.UseForeColor = false;
            this.xrTableCell35.StylePriority.UseTextAlignment = false;
            this.xrTableCell35.Text = "xrTableCell35";
            this.xrTableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell35.Weight = 0.036555644614432267D;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell36.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell36.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell36.BorderWidth = 1F;
            this.xrTableCell36.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell36.Multiline = true;
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.StyleName = "DetailCaption1";
            this.xrTableCell36.StylePriority.UseBackColor = false;
            this.xrTableCell36.StylePriority.UseBorderColor = false;
            this.xrTableCell36.StylePriority.UseBorders = false;
            this.xrTableCell36.StylePriority.UseBorderWidth = false;
            this.xrTableCell36.StylePriority.UseForeColor = false;
            this.xrTableCell36.StylePriority.UseTextAlignment = false;
            this.xrTableCell36.Text = "xrTableCell36";
            this.xrTableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell36.Weight = 0.036555643199379637D;
            // 
            // xrTableCell37
            // 
            this.xrTableCell37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell37.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell37.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell37.BorderWidth = 1F;
            this.xrTableCell37.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell37.Multiline = true;
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.StyleName = "DetailCaption1";
            this.xrTableCell37.StylePriority.UseBackColor = false;
            this.xrTableCell37.StylePriority.UseBorderColor = false;
            this.xrTableCell37.StylePriority.UseBorders = false;
            this.xrTableCell37.StylePriority.UseBorderWidth = false;
            this.xrTableCell37.StylePriority.UseForeColor = false;
            this.xrTableCell37.StylePriority.UseTextAlignment = false;
            this.xrTableCell37.Text = "xrTableCell37";
            this.xrTableCell37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell37.Weight = 0.036555642838894682D;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell38.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell38.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell38.BorderWidth = 1F;
            this.xrTableCell38.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell38.Multiline = true;
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.StyleName = "DetailCaption1";
            this.xrTableCell38.StylePriority.UseBackColor = false;
            this.xrTableCell38.StylePriority.UseBorderColor = false;
            this.xrTableCell38.StylePriority.UseBorders = false;
            this.xrTableCell38.StylePriority.UseBorderWidth = false;
            this.xrTableCell38.StylePriority.UseForeColor = false;
            this.xrTableCell38.StylePriority.UseTextAlignment = false;
            this.xrTableCell38.Text = "xrTableCell38";
            this.xrTableCell38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell38.Weight = 0.036555641515571918D;
            // 
            // xrTableCell39
            // 
            this.xrTableCell39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell39.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell39.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell39.BorderWidth = 1F;
            this.xrTableCell39.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell39.Multiline = true;
            this.xrTableCell39.Name = "xrTableCell39";
            this.xrTableCell39.StyleName = "DetailCaption1";
            this.xrTableCell39.StylePriority.UseBackColor = false;
            this.xrTableCell39.StylePriority.UseBorderColor = false;
            this.xrTableCell39.StylePriority.UseBorders = false;
            this.xrTableCell39.StylePriority.UseBorderWidth = false;
            this.xrTableCell39.StylePriority.UseForeColor = false;
            this.xrTableCell39.StylePriority.UseTextAlignment = false;
            this.xrTableCell39.Text = "xrTableCell39";
            this.xrTableCell39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell39.Weight = 0.03655564319937965D;
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell40.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell40.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell40.BorderWidth = 1F;
            this.xrTableCell40.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell40.Multiline = true;
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.StyleName = "DetailCaption1";
            this.xrTableCell40.StylePriority.UseBackColor = false;
            this.xrTableCell40.StylePriority.UseBorderColor = false;
            this.xrTableCell40.StylePriority.UseBorders = false;
            this.xrTableCell40.StylePriority.UseBorderWidth = false;
            this.xrTableCell40.StylePriority.UseForeColor = false;
            this.xrTableCell40.StylePriority.UseTextAlignment = false;
            this.xrTableCell40.Text = "xrTableCell40";
            this.xrTableCell40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell40.Weight = 0.036555642838894689D;
            // 
            // xrTableCell41
            // 
            this.xrTableCell41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell41.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell41.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell41.BorderWidth = 1F;
            this.xrTableCell41.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell41.Multiline = true;
            this.xrTableCell41.Name = "xrTableCell41";
            this.xrTableCell41.StyleName = "DetailCaption1";
            this.xrTableCell41.StylePriority.UseBackColor = false;
            this.xrTableCell41.StylePriority.UseBorderColor = false;
            this.xrTableCell41.StylePriority.UseBorders = false;
            this.xrTableCell41.StylePriority.UseBorderWidth = false;
            this.xrTableCell41.StylePriority.UseForeColor = false;
            this.xrTableCell41.StylePriority.UseTextAlignment = false;
            this.xrTableCell41.Text = "xrTableCell41";
            this.xrTableCell41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell41.Weight = 0.036555641515571918D;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell42.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell42.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell42.BorderWidth = 1F;
            this.xrTableCell42.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell42.Multiline = true;
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.StyleName = "DetailCaption1";
            this.xrTableCell42.StylePriority.UseBackColor = false;
            this.xrTableCell42.StylePriority.UseBorderColor = false;
            this.xrTableCell42.StylePriority.UseBorders = false;
            this.xrTableCell42.StylePriority.UseBorderWidth = false;
            this.xrTableCell42.StylePriority.UseForeColor = false;
            this.xrTableCell42.StylePriority.UseTextAlignment = false;
            this.xrTableCell42.Text = "xrTableCell42";
            this.xrTableCell42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell42.Weight = 0.036555646298239958D;
            // 
            // xrTableCell43
            // 
            this.xrTableCell43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell43.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell43.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell43.BorderWidth = 1F;
            this.xrTableCell43.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell43.Multiline = true;
            this.xrTableCell43.Name = "xrTableCell43";
            this.xrTableCell43.StyleName = "DetailCaption1";
            this.xrTableCell43.StylePriority.UseBackColor = false;
            this.xrTableCell43.StylePriority.UseBorderColor = false;
            this.xrTableCell43.StylePriority.UseBorders = false;
            this.xrTableCell43.StylePriority.UseBorderWidth = false;
            this.xrTableCell43.StylePriority.UseForeColor = false;
            this.xrTableCell43.StylePriority.UseTextAlignment = false;
            this.xrTableCell43.Text = "xrTableCell43";
            this.xrTableCell43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell43.Weight = 0.036555644388324871D;
            // 
            // xrTableCell44
            // 
            this.xrTableCell44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell44.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell44.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell44.BorderWidth = 1F;
            this.xrTableCell44.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell44.Multiline = true;
            this.xrTableCell44.Name = "xrTableCell44";
            this.xrTableCell44.StyleName = "DetailCaption1";
            this.xrTableCell44.StylePriority.UseBackColor = false;
            this.xrTableCell44.StylePriority.UseBorderColor = false;
            this.xrTableCell44.StylePriority.UseBorders = false;
            this.xrTableCell44.StylePriority.UseBorderWidth = false;
            this.xrTableCell44.StylePriority.UseForeColor = false;
            this.xrTableCell44.StylePriority.UseTextAlignment = false;
            this.xrTableCell44.Text = "+/-";
            this.xrTableCell44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell44.Weight = 0.036555705928832324D;
            // 
            // xrTableCell54
            // 
            this.xrTableCell54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell54.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell54.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell54.BorderWidth = 1F;
            this.xrTableCell54.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell54.Multiline = true;
            this.xrTableCell54.Name = "xrTableCell54";
            this.xrTableCell54.StyleName = "DetailCaption1";
            this.xrTableCell54.StylePriority.UseBackColor = false;
            this.xrTableCell54.StylePriority.UseBorderColor = false;
            this.xrTableCell54.StylePriority.UseBorders = false;
            this.xrTableCell54.StylePriority.UseBorderWidth = false;
            this.xrTableCell54.StylePriority.UseForeColor = false;
            this.xrTableCell54.StylePriority.UseTextAlignment = false;
            this.xrTableCell54.Text = "%";
            this.xrTableCell54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell54.Weight = 0.024370429254930711D;
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell45.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell45.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell45.BorderWidth = 1F;
            this.xrTableCell45.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell45.Multiline = true;
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.StyleName = "DetailCaption1";
            this.xrTableCell45.StylePriority.UseBackColor = false;
            this.xrTableCell45.StylePriority.UseBorderColor = false;
            this.xrTableCell45.StylePriority.UseBorders = false;
            this.xrTableCell45.StylePriority.UseBorderWidth = false;
            this.xrTableCell45.StylePriority.UseForeColor = false;
            this.xrTableCell45.StylePriority.UseTextAlignment = false;
            this.xrTableCell45.Text = "+/-";
            this.xrTableCell45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell45.Weight = 0.0380505342515894D;
            // 
            // xrTableCell57
            // 
            this.xrTableCell57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell57.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell57.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell57.BorderWidth = 1F;
            this.xrTableCell57.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell57.Multiline = true;
            this.xrTableCell57.Name = "xrTableCell57";
            this.xrTableCell57.StyleName = "DetailCaption1";
            this.xrTableCell57.StylePriority.UseBackColor = false;
            this.xrTableCell57.StylePriority.UseBorderColor = false;
            this.xrTableCell57.StylePriority.UseBorders = false;
            this.xrTableCell57.StylePriority.UseBorderWidth = false;
            this.xrTableCell57.StylePriority.UseForeColor = false;
            this.xrTableCell57.StylePriority.UseTextAlignment = false;
            this.xrTableCell57.Text = "%";
            this.xrTableCell57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell57.Weight = 0.0240886561506521D;
            // 
            // xrTableCell56
            // 
            this.xrTableCell56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell56.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell56.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell56.BorderWidth = 1F;
            this.xrTableCell56.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell56.Multiline = true;
            this.xrTableCell56.Name = "xrTableCell56";
            this.xrTableCell56.StyleName = "DetailCaption1";
            this.xrTableCell56.StylePriority.UseBackColor = false;
            this.xrTableCell56.StylePriority.UseBorderColor = false;
            this.xrTableCell56.StylePriority.UseBorders = false;
            this.xrTableCell56.StylePriority.UseBorderWidth = false;
            this.xrTableCell56.StylePriority.UseForeColor = false;
            this.xrTableCell56.StylePriority.UseTextAlignment = false;
            this.xrTableCell56.Text = "+/-";
            this.xrTableCell56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell56.Weight = 0.036555644020854761D;
            // 
            // xrTableCell60
            // 
            this.xrTableCell60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell60.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell60.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell60.BorderWidth = 1F;
            this.xrTableCell60.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell60.Multiline = true;
            this.xrTableCell60.Name = "xrTableCell60";
            this.xrTableCell60.StyleName = "DetailCaption1";
            this.xrTableCell60.StylePriority.UseBackColor = false;
            this.xrTableCell60.StylePriority.UseBorderColor = false;
            this.xrTableCell60.StylePriority.UseBorders = false;
            this.xrTableCell60.StylePriority.UseBorderWidth = false;
            this.xrTableCell60.StylePriority.UseForeColor = false;
            this.xrTableCell60.StylePriority.UseTextAlignment = false;
            this.xrTableCell60.Text = "%";
            this.xrTableCell60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell60.Weight = 0.024370429324160059D;
            // 
            // xrTableCell46
            // 
            this.xrTableCell46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell46.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell46.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell46.BorderWidth = 1F;
            this.xrTableCell46.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell46.Multiline = true;
            this.xrTableCell46.Name = "xrTableCell46";
            this.xrTableCell46.StyleName = "DetailCaption1";
            this.xrTableCell46.StylePriority.UseBackColor = false;
            this.xrTableCell46.StylePriority.UseBorderColor = false;
            this.xrTableCell46.StylePriority.UseBorders = false;
            this.xrTableCell46.StylePriority.UseBorderWidth = false;
            this.xrTableCell46.StylePriority.UseForeColor = false;
            this.xrTableCell46.StylePriority.UseTextAlignment = false;
            this.xrTableCell46.Text = "+/-";
            this.xrTableCell46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell46.Weight = 0.036555643951625416D;
            // 
            // xrTableCell66
            // 
            this.xrTableCell66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell66.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell66.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell66.BorderWidth = 1F;
            this.xrTableCell66.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell66.Multiline = true;
            this.xrTableCell66.Name = "xrTableCell66";
            this.xrTableCell66.StyleName = "DetailCaption1";
            this.xrTableCell66.StylePriority.UseBackColor = false;
            this.xrTableCell66.StylePriority.UseBorderColor = false;
            this.xrTableCell66.StylePriority.UseBorders = false;
            this.xrTableCell66.StylePriority.UseBorderWidth = false;
            this.xrTableCell66.StylePriority.UseForeColor = false;
            this.xrTableCell66.StylePriority.UseTextAlignment = false;
            this.xrTableCell66.Text = "%";
            this.xrTableCell66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell66.Weight = 0.024370429254930714D;
            // 
            // xrTableCell47
            // 
            this.xrTableCell47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell47.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell47.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell47.BorderWidth = 1F;
            this.xrTableCell47.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell47.Multiline = true;
            this.xrTableCell47.Name = "xrTableCell47";
            this.xrTableCell47.StyleName = "DetailCaption1";
            this.xrTableCell47.StylePriority.UseBackColor = false;
            this.xrTableCell47.StylePriority.UseBorderColor = false;
            this.xrTableCell47.StylePriority.UseBorders = false;
            this.xrTableCell47.StylePriority.UseBorderWidth = false;
            this.xrTableCell47.StylePriority.UseForeColor = false;
            this.xrTableCell47.StylePriority.UseTextAlignment = false;
            this.xrTableCell47.Text = "+/-";
            this.xrTableCell47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell47.Weight = 0.036555644020854774D;
            // 
            // xrTableCell67
            // 
            this.xrTableCell67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell67.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell67.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell67.BorderWidth = 1F;
            this.xrTableCell67.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell67.Multiline = true;
            this.xrTableCell67.Name = "xrTableCell67";
            this.xrTableCell67.StyleName = "DetailCaption1";
            this.xrTableCell67.StylePriority.UseBackColor = false;
            this.xrTableCell67.StylePriority.UseBorderColor = false;
            this.xrTableCell67.StylePriority.UseBorders = false;
            this.xrTableCell67.StylePriority.UseBorderWidth = false;
            this.xrTableCell67.StylePriority.UseForeColor = false;
            this.xrTableCell67.StylePriority.UseTextAlignment = false;
            this.xrTableCell67.Text = "%";
            this.xrTableCell67.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell67.Weight = 0.024370429324160066D;
            // 
            // xrTableCell64
            // 
            this.xrTableCell64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell64.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell64.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell64.BorderWidth = 1F;
            this.xrTableCell64.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell64.Multiline = true;
            this.xrTableCell64.Name = "xrTableCell64";
            this.xrTableCell64.StyleName = "DetailCaption1";
            this.xrTableCell64.StylePriority.UseBackColor = false;
            this.xrTableCell64.StylePriority.UseBorderColor = false;
            this.xrTableCell64.StylePriority.UseBorders = false;
            this.xrTableCell64.StylePriority.UseBorderWidth = false;
            this.xrTableCell64.StylePriority.UseForeColor = false;
            this.xrTableCell64.StylePriority.UseTextAlignment = false;
            this.xrTableCell64.Text = "+/-";
            this.xrTableCell64.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell64.Weight = 0.036555644020854768D;
            // 
            // xrTableCell68
            // 
            this.xrTableCell68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell68.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell68.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell68.BorderWidth = 1F;
            this.xrTableCell68.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell68.Multiline = true;
            this.xrTableCell68.Name = "xrTableCell68";
            this.xrTableCell68.StyleName = "DetailCaption1";
            this.xrTableCell68.StylePriority.UseBackColor = false;
            this.xrTableCell68.StylePriority.UseBorderColor = false;
            this.xrTableCell68.StylePriority.UseBorders = false;
            this.xrTableCell68.StylePriority.UseBorderWidth = false;
            this.xrTableCell68.StylePriority.UseForeColor = false;
            this.xrTableCell68.StylePriority.UseTextAlignment = false;
            this.xrTableCell68.Text = "%";
            this.xrTableCell68.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell68.Weight = 0.024370429324160069D;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell48.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell48.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell48.BorderWidth = 1F;
            this.xrTableCell48.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell48.Multiline = true;
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.StyleName = "DetailCaption1";
            this.xrTableCell48.StylePriority.UseBackColor = false;
            this.xrTableCell48.StylePriority.UseBorderColor = false;
            this.xrTableCell48.StylePriority.UseBorders = false;
            this.xrTableCell48.StylePriority.UseBorderWidth = false;
            this.xrTableCell48.StylePriority.UseForeColor = false;
            this.xrTableCell48.StylePriority.UseTextAlignment = false;
            this.xrTableCell48.Text = "+/-";
            this.xrTableCell48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell48.Weight = 0.0365556439516254D;
            // 
            // xrTableCell73
            // 
            this.xrTableCell73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell73.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell73.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell73.BorderWidth = 1F;
            this.xrTableCell73.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell73.Multiline = true;
            this.xrTableCell73.Name = "xrTableCell73";
            this.xrTableCell73.StyleName = "DetailCaption1";
            this.xrTableCell73.StylePriority.UseBackColor = false;
            this.xrTableCell73.StylePriority.UseBorderColor = false;
            this.xrTableCell73.StylePriority.UseBorders = false;
            this.xrTableCell73.StylePriority.UseBorderWidth = false;
            this.xrTableCell73.StylePriority.UseForeColor = false;
            this.xrTableCell73.StylePriority.UseTextAlignment = false;
            this.xrTableCell73.Text = "%";
            this.xrTableCell73.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell73.Weight = 0.024370429254930697D;
            // 
            // xrTableCell49
            // 
            this.xrTableCell49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell49.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell49.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell49.BorderWidth = 1F;
            this.xrTableCell49.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell49.Multiline = true;
            this.xrTableCell49.Name = "xrTableCell49";
            this.xrTableCell49.StyleName = "DetailCaption1";
            this.xrTableCell49.StylePriority.UseBackColor = false;
            this.xrTableCell49.StylePriority.UseBorderColor = false;
            this.xrTableCell49.StylePriority.UseBorders = false;
            this.xrTableCell49.StylePriority.UseBorderWidth = false;
            this.xrTableCell49.StylePriority.UseForeColor = false;
            this.xrTableCell49.StylePriority.UseTextAlignment = false;
            this.xrTableCell49.Text = "+/-";
            this.xrTableCell49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell49.Weight = 0.036555644020854761D;
            // 
            // xrTableCell75
            // 
            this.xrTableCell75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell75.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell75.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell75.BorderWidth = 1F;
            this.xrTableCell75.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell75.Multiline = true;
            this.xrTableCell75.Name = "xrTableCell75";
            this.xrTableCell75.StyleName = "DetailCaption1";
            this.xrTableCell75.StylePriority.UseBackColor = false;
            this.xrTableCell75.StylePriority.UseBorderColor = false;
            this.xrTableCell75.StylePriority.UseBorders = false;
            this.xrTableCell75.StylePriority.UseBorderWidth = false;
            this.xrTableCell75.StylePriority.UseForeColor = false;
            this.xrTableCell75.StylePriority.UseTextAlignment = false;
            this.xrTableCell75.Text = "%";
            this.xrTableCell75.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell75.Weight = 0.024370429324160059D;
            // 
            // xrTableCell74
            // 
            this.xrTableCell74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell74.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell74.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell74.BorderWidth = 1F;
            this.xrTableCell74.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell74.Multiline = true;
            this.xrTableCell74.Name = "xrTableCell74";
            this.xrTableCell74.StyleName = "DetailCaption1";
            this.xrTableCell74.StylePriority.UseBackColor = false;
            this.xrTableCell74.StylePriority.UseBorderColor = false;
            this.xrTableCell74.StylePriority.UseBorders = false;
            this.xrTableCell74.StylePriority.UseBorderWidth = false;
            this.xrTableCell74.StylePriority.UseForeColor = false;
            this.xrTableCell74.StylePriority.UseTextAlignment = false;
            this.xrTableCell74.Text = "+/-";
            this.xrTableCell74.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell74.Weight = 0.036555644020854761D;
            // 
            // xrTableCell76
            // 
            this.xrTableCell76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell76.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell76.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell76.BorderWidth = 1F;
            this.xrTableCell76.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell76.Multiline = true;
            this.xrTableCell76.Name = "xrTableCell76";
            this.xrTableCell76.StyleName = "DetailCaption1";
            this.xrTableCell76.StylePriority.UseBackColor = false;
            this.xrTableCell76.StylePriority.UseBorderColor = false;
            this.xrTableCell76.StylePriority.UseBorders = false;
            this.xrTableCell76.StylePriority.UseBorderWidth = false;
            this.xrTableCell76.StylePriority.UseForeColor = false;
            this.xrTableCell76.StylePriority.UseTextAlignment = false;
            this.xrTableCell76.Text = "%";
            this.xrTableCell76.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell76.Weight = 0.024370429324160055D;
            // 
            // xrTableCell50
            // 
            this.xrTableCell50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell50.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell50.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell50.BorderWidth = 1F;
            this.xrTableCell50.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell50.Multiline = true;
            this.xrTableCell50.Name = "xrTableCell50";
            this.xrTableCell50.StyleName = "DetailCaption1";
            this.xrTableCell50.StylePriority.UseBackColor = false;
            this.xrTableCell50.StylePriority.UseBorderColor = false;
            this.xrTableCell50.StylePriority.UseBorders = false;
            this.xrTableCell50.StylePriority.UseBorderWidth = false;
            this.xrTableCell50.StylePriority.UseForeColor = false;
            this.xrTableCell50.StylePriority.UseTextAlignment = false;
            this.xrTableCell50.Text = "+/-";
            this.xrTableCell50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell50.Weight = 0.036555644214533535D;
            // 
            // xrTableCell84
            // 
            this.xrTableCell84.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell84.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell84.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell84.BorderWidth = 1F;
            this.xrTableCell84.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell84.Multiline = true;
            this.xrTableCell84.Name = "xrTableCell84";
            this.xrTableCell84.StyleName = "DetailCaption1";
            this.xrTableCell84.StylePriority.UseBackColor = false;
            this.xrTableCell84.StylePriority.UseBorderColor = false;
            this.xrTableCell84.StylePriority.UseBorders = false;
            this.xrTableCell84.StylePriority.UseBorderWidth = false;
            this.xrTableCell84.StylePriority.UseForeColor = false;
            this.xrTableCell84.StylePriority.UseTextAlignment = false;
            this.xrTableCell84.Text = "%";
            this.xrTableCell84.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell84.Weight = 0.024370429517838833D;
            // 
            // xrTableCell82
            // 
            this.xrTableCell82.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell82.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell82.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell82.BorderWidth = 1F;
            this.xrTableCell82.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell82.Multiline = true;
            this.xrTableCell82.Name = "xrTableCell82";
            this.xrTableCell82.StyleName = "DetailCaption1";
            this.xrTableCell82.StylePriority.UseBackColor = false;
            this.xrTableCell82.StylePriority.UseBorderColor = false;
            this.xrTableCell82.StylePriority.UseBorders = false;
            this.xrTableCell82.StylePriority.UseBorderWidth = false;
            this.xrTableCell82.StylePriority.UseForeColor = false;
            this.xrTableCell82.StylePriority.UseTextAlignment = false;
            this.xrTableCell82.Text = "+/-";
            this.xrTableCell82.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell82.Weight = 0.036555644214533542D;
            // 
            // xrTableCell85
            // 
            this.xrTableCell85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell85.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell85.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell85.BorderWidth = 1F;
            this.xrTableCell85.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell85.Multiline = true;
            this.xrTableCell85.Name = "xrTableCell85";
            this.xrTableCell85.StyleName = "DetailCaption1";
            this.xrTableCell85.StylePriority.UseBackColor = false;
            this.xrTableCell85.StylePriority.UseBorderColor = false;
            this.xrTableCell85.StylePriority.UseBorders = false;
            this.xrTableCell85.StylePriority.UseBorderWidth = false;
            this.xrTableCell85.StylePriority.UseForeColor = false;
            this.xrTableCell85.StylePriority.UseTextAlignment = false;
            this.xrTableCell85.Text = "%";
            this.xrTableCell85.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell85.Weight = 0.02437042951783883D;
            // 
            // xrTableCell51
            // 
            this.xrTableCell51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell51.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell51.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell51.BorderWidth = 1F;
            this.xrTableCell51.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell51.Multiline = true;
            this.xrTableCell51.Name = "xrTableCell51";
            this.xrTableCell51.StyleName = "DetailCaption1";
            this.xrTableCell51.StylePriority.UseBackColor = false;
            this.xrTableCell51.StylePriority.UseBorderColor = false;
            this.xrTableCell51.StylePriority.UseBorders = false;
            this.xrTableCell51.StylePriority.UseBorderWidth = false;
            this.xrTableCell51.StylePriority.UseForeColor = false;
            this.xrTableCell51.StylePriority.UseTextAlignment = false;
            this.xrTableCell51.Text = "+/-";
            this.xrTableCell51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell51.Weight = 0.036555644338982972D;
            // 
            // xrTableCell86
            // 
            this.xrTableCell86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell86.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell86.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell86.BorderWidth = 1F;
            this.xrTableCell86.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell86.Multiline = true;
            this.xrTableCell86.Name = "xrTableCell86";
            this.xrTableCell86.StyleName = "DetailCaption1";
            this.xrTableCell86.StylePriority.UseBackColor = false;
            this.xrTableCell86.StylePriority.UseBorderColor = false;
            this.xrTableCell86.StylePriority.UseBorders = false;
            this.xrTableCell86.StylePriority.UseBorderWidth = false;
            this.xrTableCell86.StylePriority.UseForeColor = false;
            this.xrTableCell86.StylePriority.UseTextAlignment = false;
            this.xrTableCell86.Text = "%";
            this.xrTableCell86.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell86.Weight = 0.02437042964228826D;
            // 
            // xrTableCell52
            // 
            this.xrTableCell52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell52.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell52.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell52.BorderWidth = 1F;
            this.xrTableCell52.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell52.Multiline = true;
            this.xrTableCell52.Name = "xrTableCell52";
            this.xrTableCell52.StyleName = "DetailCaption1";
            this.xrTableCell52.StylePriority.UseBackColor = false;
            this.xrTableCell52.StylePriority.UseBorderColor = false;
            this.xrTableCell52.StylePriority.UseBorders = false;
            this.xrTableCell52.StylePriority.UseBorderWidth = false;
            this.xrTableCell52.StylePriority.UseForeColor = false;
            this.xrTableCell52.StylePriority.UseTextAlignment = false;
            this.xrTableCell52.Text = "+/-";
            this.xrTableCell52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell52.Weight = 0.036555644828104458D;
            // 
            // xrTableCell91
            // 
            this.xrTableCell91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell91.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell91.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell91.BorderWidth = 1F;
            this.xrTableCell91.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell91.Multiline = true;
            this.xrTableCell91.Name = "xrTableCell91";
            this.xrTableCell91.StyleName = "DetailCaption1";
            this.xrTableCell91.StylePriority.UseBackColor = false;
            this.xrTableCell91.StylePriority.UseBorderColor = false;
            this.xrTableCell91.StylePriority.UseBorders = false;
            this.xrTableCell91.StylePriority.UseBorderWidth = false;
            this.xrTableCell91.StylePriority.UseForeColor = false;
            this.xrTableCell91.StylePriority.UseTextAlignment = false;
            this.xrTableCell91.Text = "%";
            this.xrTableCell91.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell91.Weight = 0.024370430131409757D;
            // 
            // xrTableCell53
            // 
            this.xrTableCell53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell53.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell53.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell53.BorderWidth = 1F;
            this.xrTableCell53.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell53.Multiline = true;
            this.xrTableCell53.Name = "xrTableCell53";
            this.xrTableCell53.StyleName = "DetailCaption1";
            this.xrTableCell53.StylePriority.UseBackColor = false;
            this.xrTableCell53.StylePriority.UseBorderColor = false;
            this.xrTableCell53.StylePriority.UseBorders = false;
            this.xrTableCell53.StylePriority.UseBorderWidth = false;
            this.xrTableCell53.StylePriority.UseForeColor = false;
            this.xrTableCell53.StylePriority.UseTextAlignment = false;
            this.xrTableCell53.Text = "+/-";
            this.xrTableCell53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell53.Weight = 0.036555642909664121D;
            // 
            // xrTableCell93
            // 
            this.xrTableCell93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell93.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell93.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell93.BorderWidth = 1F;
            this.xrTableCell93.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell93.Multiline = true;
            this.xrTableCell93.Name = "xrTableCell93";
            this.xrTableCell93.StyleName = "DetailCaption1";
            this.xrTableCell93.StylePriority.UseBackColor = false;
            this.xrTableCell93.StylePriority.UseBorderColor = false;
            this.xrTableCell93.StylePriority.UseBorders = false;
            this.xrTableCell93.StylePriority.UseBorderWidth = false;
            this.xrTableCell93.StylePriority.UseForeColor = false;
            this.xrTableCell93.StylePriority.UseTextAlignment = false;
            this.xrTableCell93.Text = "%";
            this.xrTableCell93.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell93.Weight = 0.024370428212969419D;
            // 
            // xrTableCell92
            // 
            this.xrTableCell92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell92.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell92.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell92.BorderWidth = 1F;
            this.xrTableCell92.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell92.Multiline = true;
            this.xrTableCell92.Name = "xrTableCell92";
            this.xrTableCell92.StyleName = "DetailCaption1";
            this.xrTableCell92.StylePriority.UseBackColor = false;
            this.xrTableCell92.StylePriority.UseBorderColor = false;
            this.xrTableCell92.StylePriority.UseBorders = false;
            this.xrTableCell92.StylePriority.UseBorderWidth = false;
            this.xrTableCell92.StylePriority.UseForeColor = false;
            this.xrTableCell92.StylePriority.UseTextAlignment = false;
            this.xrTableCell92.Text = "+/-";
            this.xrTableCell92.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell92.Weight = 0.036555642909664121D;
            // 
            // xrTableCell94
            // 
            this.xrTableCell94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell94.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell94.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell94.BorderWidth = 1F;
            this.xrTableCell94.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell94.Multiline = true;
            this.xrTableCell94.Name = "xrTableCell94";
            this.xrTableCell94.StyleName = "DetailCaption1";
            this.xrTableCell94.StylePriority.UseBackColor = false;
            this.xrTableCell94.StylePriority.UseBorderColor = false;
            this.xrTableCell94.StylePriority.UseBorders = false;
            this.xrTableCell94.StylePriority.UseBorderWidth = false;
            this.xrTableCell94.StylePriority.UseForeColor = false;
            this.xrTableCell94.StylePriority.UseTextAlignment = false;
            this.xrTableCell94.Text = "%";
            this.xrTableCell94.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell94.Weight = 0.025320018073249219D;
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table2});
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            // 
            // table2
            // 
            this.table2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.table2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.table2.Name = "table2";
            this.table2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow2});
            this.table2.SizeF = new System.Drawing.SizeF(4100F, 25F);
            // 
            // tableRow2
            // 
            this.tableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell26,
            this.tableCell27,
            this.tableCell28,
            this.tableCell29,
            this.tableCell30,
            this.tableCell31,
            this.tableCell32,
            this.tableCell33,
            this.tableCell34,
            this.tableCell35,
            this.tableCell36,
            this.tableCell37,
            this.tableCell38,
            this.tableCell39,
            this.tableCell40,
            this.tableCell41,
            this.tableCell42,
            this.tableCell43,
            this.tableCell44,
            this.tableCell45,
            this.xrTableCell4,
            this.xrTableCell55,
            this.tableCell46,
            this.xrTableCell59,
            this.xrTableCell58,
            this.xrTableCell61,
            this.xrTableCell5,
            this.xrTableCell69,
            this.tableCell47,
            this.xrTableCell70,
            this.xrTableCell65,
            this.xrTableCell71,
            this.xrTableCell7,
            this.tableCell48,
            this.xrTableCell77,
            this.xrTableCell79,
            this.xrTableCell78,
            this.xrTableCell80,
            this.xrTableCell8,
            this.xrTableCell87,
            this.xrTableCell83,
            this.xrTableCell88,
            this.tableCell49,
            this.xrTableCell89,
            this.xrTableCell10,
            this.xrTableCell95,
            this.tableCell50,
            this.xrTableCell98,
            this.xrTableCell96,
            this.xrTableCell97});
            this.tableRow2.Name = "tableRow2";
            this.tableRow2.Weight = 11.5D;
            // 
            // tableCell26
            // 
            this.tableCell26.BorderColor = System.Drawing.Color.Black;
            this.tableCell26.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell26.BorderWidth = 1F;
            this.tableCell26.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Sorting]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell26.Name = "tableCell26";
            this.tableCell26.StyleName = "DetailData1";
            this.tableCell26.StylePriority.UseBorderColor = false;
            this.tableCell26.StylePriority.UseBorders = false;
            this.tableCell26.StylePriority.UseBorderWidth = false;
            this.tableCell26.Weight = 0.017809513836955393D;
            // 
            // tableCell27
            // 
            this.tableCell27.BorderColor = System.Drawing.Color.Black;
            this.tableCell27.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell27.BorderWidth = 1F;
            this.tableCell27.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Description]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell27.Name = "tableCell27";
            this.tableCell27.StyleName = "DetailData1";
            this.tableCell27.StylePriority.UseBorderColor = false;
            this.tableCell27.StylePriority.UseBorders = false;
            this.tableCell27.StylePriority.UseBorderWidth = false;
            this.tableCell27.Weight = 0.073447520696396D;
            // 
            // tableCell28
            // 
            this.tableCell28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.tableCell28.BorderColor = System.Drawing.Color.Black;
            this.tableCell28.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell28.BorderWidth = 1F;
            this.tableCell28.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OutStandards01]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell28.Name = "tableCell28";
            this.tableCell28.StyleName = "DetailData1";
            this.tableCell28.StylePriority.UseBackColor = false;
            this.tableCell28.StylePriority.UseBorderColor = false;
            this.tableCell28.StylePriority.UseBorders = false;
            this.tableCell28.StylePriority.UseBorderWidth = false;
            this.tableCell28.StylePriority.UseTextAlignment = false;
            this.tableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell28.TextFormatString = "{0:N2}";
            this.tableCell28.Weight = 0.036555647443933831D;
            // 
            // tableCell29
            // 
            this.tableCell29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.tableCell29.BorderColor = System.Drawing.Color.Black;
            this.tableCell29.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell29.BorderWidth = 1F;
            this.tableCell29.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Decentralization01]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell29.Name = "tableCell29";
            this.tableCell29.StyleName = "DetailData1";
            this.tableCell29.StylePriority.UseBackColor = false;
            this.tableCell29.StylePriority.UseBorderColor = false;
            this.tableCell29.StylePriority.UseBorders = false;
            this.tableCell29.StylePriority.UseBorderWidth = false;
            this.tableCell29.StylePriority.UseTextAlignment = false;
            this.tableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell29.TextFormatString = "{0:N2}";
            this.tableCell29.Weight = 0.036555645581915347D;
            // 
            // tableCell30
            // 
            this.tableCell30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.tableCell30.BorderColor = System.Drawing.Color.Black;
            this.tableCell30.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell30.BorderWidth = 1F;
            this.tableCell30.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TotalAmount01]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell30.Name = "tableCell30";
            this.tableCell30.StyleName = "DetailData1";
            this.tableCell30.StylePriority.UseBackColor = false;
            this.tableCell30.StylePriority.UseBorderColor = false;
            this.tableCell30.StylePriority.UseBorders = false;
            this.tableCell30.StylePriority.UseBorderWidth = false;
            this.tableCell30.StylePriority.UseTextAlignment = false;
            this.tableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell30.TextFormatString = "{0:N2}";
            this.tableCell30.Weight = 0.036555682316513786D;
            // 
            // tableCell31
            // 
            this.tableCell31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.tableCell31.BorderColor = System.Drawing.Color.Black;
            this.tableCell31.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell31.BorderWidth = 1F;
            this.tableCell31.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OutStandards02]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell31.Name = "tableCell31";
            this.tableCell31.StyleName = "DetailData1";
            this.tableCell31.StylePriority.UseBackColor = false;
            this.tableCell31.StylePriority.UseBorderColor = false;
            this.tableCell31.StylePriority.UseBorders = false;
            this.tableCell31.StylePriority.UseBorderWidth = false;
            this.tableCell31.StylePriority.UseTextAlignment = false;
            this.tableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell31.TextFormatString = "{0:N2}";
            this.tableCell31.Weight = 0.036555646771908007D;
            // 
            // tableCell32
            // 
            this.tableCell32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.tableCell32.BorderColor = System.Drawing.Color.Black;
            this.tableCell32.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell32.BorderWidth = 1F;
            this.tableCell32.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Decentralization02]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell32.Name = "tableCell32";
            this.tableCell32.StyleName = "DetailData1";
            this.tableCell32.StylePriority.UseBackColor = false;
            this.tableCell32.StylePriority.UseBorderColor = false;
            this.tableCell32.StylePriority.UseBorders = false;
            this.tableCell32.StylePriority.UseBorderWidth = false;
            this.tableCell32.StylePriority.UseTextAlignment = false;
            this.tableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell32.TextFormatString = "{0:N2}";
            this.tableCell32.Weight = 0.036555645581915354D;
            // 
            // tableCell33
            // 
            this.tableCell33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.tableCell33.BorderColor = System.Drawing.Color.Black;
            this.tableCell33.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell33.BorderWidth = 1F;
            this.tableCell33.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TotalAmount02]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell33.Name = "tableCell33";
            this.tableCell33.StyleName = "DetailData1";
            this.tableCell33.StylePriority.UseBackColor = false;
            this.tableCell33.StylePriority.UseBorderColor = false;
            this.tableCell33.StylePriority.UseBorders = false;
            this.tableCell33.StylePriority.UseBorderWidth = false;
            this.tableCell33.StylePriority.UseTextAlignment = false;
            this.tableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell33.TextFormatString = "{0:N2}";
            this.tableCell33.Weight = 0.036555645130187296D;
            // 
            // tableCell34
            // 
            this.tableCell34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.tableCell34.BorderColor = System.Drawing.Color.Black;
            this.tableCell34.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell34.BorderWidth = 1F;
            this.tableCell34.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OutStandards03]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell34.Name = "tableCell34";
            this.tableCell34.StyleName = "DetailData1";
            this.tableCell34.StylePriority.UseBackColor = false;
            this.tableCell34.StylePriority.UseBorderColor = false;
            this.tableCell34.StylePriority.UseBorders = false;
            this.tableCell34.StylePriority.UseBorderWidth = false;
            this.tableCell34.StylePriority.UseTextAlignment = false;
            this.tableCell34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell34.TextFormatString = "{0:N2}";
            this.tableCell34.Weight = 0.036555646771908007D;
            // 
            // tableCell35
            // 
            this.tableCell35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.tableCell35.BorderColor = System.Drawing.Color.Black;
            this.tableCell35.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell35.BorderWidth = 1F;
            this.tableCell35.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Decentralization03]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell35.Name = "tableCell35";
            this.tableCell35.StyleName = "DetailData1";
            this.tableCell35.StylePriority.UseBackColor = false;
            this.tableCell35.StylePriority.UseBorderColor = false;
            this.tableCell35.StylePriority.UseBorders = false;
            this.tableCell35.StylePriority.UseBorderWidth = false;
            this.tableCell35.StylePriority.UseTextAlignment = false;
            this.tableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell35.TextFormatString = "{0:N2}";
            this.tableCell35.Weight = 0.036555645581915347D;
            // 
            // tableCell36
            // 
            this.tableCell36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.tableCell36.BorderColor = System.Drawing.Color.Black;
            this.tableCell36.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell36.BorderWidth = 1F;
            this.tableCell36.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TotalAmount03]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell36.Name = "tableCell36";
            this.tableCell36.StyleName = "DetailData1";
            this.tableCell36.StylePriority.UseBackColor = false;
            this.tableCell36.StylePriority.UseBorderColor = false;
            this.tableCell36.StylePriority.UseBorders = false;
            this.tableCell36.StylePriority.UseBorderWidth = false;
            this.tableCell36.StylePriority.UseTextAlignment = false;
            this.tableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell36.TextFormatString = "{0:N2}";
            this.tableCell36.Weight = 0.036555645130187296D;
            // 
            // tableCell37
            // 
            this.tableCell37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.tableCell37.BorderColor = System.Drawing.Color.Black;
            this.tableCell37.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell37.BorderWidth = 1F;
            this.tableCell37.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OutStandards04]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell37.Name = "tableCell37";
            this.tableCell37.StyleName = "DetailData1";
            this.tableCell37.StylePriority.UseBackColor = false;
            this.tableCell37.StylePriority.UseBorderColor = false;
            this.tableCell37.StylePriority.UseBorders = false;
            this.tableCell37.StylePriority.UseBorderWidth = false;
            this.tableCell37.StylePriority.UseTextAlignment = false;
            this.tableCell37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell37.TextFormatString = "{0:N2}";
            this.tableCell37.Weight = 0.036555643673047464D;
            // 
            // tableCell38
            // 
            this.tableCell38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.tableCell38.BorderColor = System.Drawing.Color.Black;
            this.tableCell38.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell38.BorderWidth = 1F;
            this.tableCell38.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Decentralization04]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell38.Name = "tableCell38";
            this.tableCell38.StyleName = "DetailData1";
            this.tableCell38.StylePriority.UseBackColor = false;
            this.tableCell38.StylePriority.UseBorderColor = false;
            this.tableCell38.StylePriority.UseBorders = false;
            this.tableCell38.StylePriority.UseBorderWidth = false;
            this.tableCell38.StylePriority.UseTextAlignment = false;
            this.tableCell38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell38.TextFormatString = "{0:N2}";
            this.tableCell38.Weight = 0.036555645581915347D;
            // 
            // tableCell39
            // 
            this.tableCell39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.tableCell39.BorderColor = System.Drawing.Color.Black;
            this.tableCell39.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell39.BorderWidth = 1F;
            this.tableCell39.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TotalAmount04]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell39.Name = "tableCell39";
            this.tableCell39.StyleName = "DetailData1";
            this.tableCell39.StylePriority.UseBackColor = false;
            this.tableCell39.StylePriority.UseBorderColor = false;
            this.tableCell39.StylePriority.UseBorders = false;
            this.tableCell39.StylePriority.UseBorderWidth = false;
            this.tableCell39.StylePriority.UseTextAlignment = false;
            this.tableCell39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell39.TextFormatString = "{0:N2}";
            this.tableCell39.Weight = 0.036555648229047846D;
            // 
            // tableCell40
            // 
            this.tableCell40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.tableCell40.BorderColor = System.Drawing.Color.Black;
            this.tableCell40.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell40.BorderWidth = 1F;
            this.tableCell40.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OutStandards05]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell40.Name = "tableCell40";
            this.tableCell40.StyleName = "DetailData1";
            this.tableCell40.StylePriority.UseBackColor = false;
            this.tableCell40.StylePriority.UseBorderColor = false;
            this.tableCell40.StylePriority.UseBorders = false;
            this.tableCell40.StylePriority.UseBorderWidth = false;
            this.tableCell40.StylePriority.UseTextAlignment = false;
            this.tableCell40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell40.TextFormatString = "{0:N2}";
            this.tableCell40.Weight = 0.036555646771908007D;
            // 
            // tableCell41
            // 
            this.tableCell41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.tableCell41.BorderColor = System.Drawing.Color.Black;
            this.tableCell41.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell41.BorderWidth = 1F;
            this.tableCell41.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Decentralization05]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell41.Name = "tableCell41";
            this.tableCell41.StyleName = "DetailData1";
            this.tableCell41.StylePriority.UseBackColor = false;
            this.tableCell41.StylePriority.UseBorderColor = false;
            this.tableCell41.StylePriority.UseBorders = false;
            this.tableCell41.StylePriority.UseBorderWidth = false;
            this.tableCell41.StylePriority.UseTextAlignment = false;
            this.tableCell41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell41.TextFormatString = "{0:N2}";
            this.tableCell41.Weight = 0.036555648680775876D;
            // 
            // tableCell42
            // 
            this.tableCell42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.tableCell42.BorderColor = System.Drawing.Color.Black;
            this.tableCell42.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell42.BorderWidth = 1F;
            this.tableCell42.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TotalAmount05]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell42.Name = "tableCell42";
            this.tableCell42.StyleName = "DetailData1";
            this.tableCell42.StylePriority.UseBackColor = false;
            this.tableCell42.StylePriority.UseBorderColor = false;
            this.tableCell42.StylePriority.UseBorders = false;
            this.tableCell42.StylePriority.UseBorderWidth = false;
            this.tableCell42.StylePriority.UseTextAlignment = false;
            this.tableCell42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell42.TextFormatString = "{0:N2}";
            this.tableCell42.Weight = 0.036555648229047846D;
            // 
            // tableCell43
            // 
            this.tableCell43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.tableCell43.BorderColor = System.Drawing.Color.Black;
            this.tableCell43.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell43.BorderWidth = 1F;
            this.tableCell43.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OutStandards06]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell43.Name = "tableCell43";
            this.tableCell43.StyleName = "DetailData1";
            this.tableCell43.StylePriority.UseBackColor = false;
            this.tableCell43.StylePriority.UseBorderColor = false;
            this.tableCell43.StylePriority.UseBorders = false;
            this.tableCell43.StylePriority.UseBorderWidth = false;
            this.tableCell43.StylePriority.UseTextAlignment = false;
            this.tableCell43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell43.TextFormatString = "{0:N2}";
            this.tableCell43.Weight = 0.036555646771908007D;
            // 
            // tableCell44
            // 
            this.tableCell44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.tableCell44.BorderColor = System.Drawing.Color.Black;
            this.tableCell44.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell44.BorderWidth = 1F;
            this.tableCell44.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Decentralization06]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell44.Name = "tableCell44";
            this.tableCell44.StyleName = "DetailData1";
            this.tableCell44.StylePriority.UseBackColor = false;
            this.tableCell44.StylePriority.UseBorderColor = false;
            this.tableCell44.StylePriority.UseBorders = false;
            this.tableCell44.StylePriority.UseBorderWidth = false;
            this.tableCell44.StylePriority.UseTextAlignment = false;
            this.tableCell44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell44.TextFormatString = "{0:N2}";
            this.tableCell44.Weight = 0.036555644032485068D;
            // 
            // tableCell45
            // 
            this.tableCell45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.tableCell45.BorderColor = System.Drawing.Color.Black;
            this.tableCell45.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell45.BorderWidth = 1F;
            this.tableCell45.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TotalAmount06]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell45.Name = "tableCell45";
            this.tableCell45.StyleName = "DetailData1";
            this.tableCell45.StylePriority.UseBackColor = false;
            this.tableCell45.StylePriority.UseBorderColor = false;
            this.tableCell45.StylePriority.UseBorders = false;
            this.tableCell45.StylePriority.UseBorderWidth = false;
            this.tableCell45.StylePriority.UseTextAlignment = false;
            this.tableCell45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell45.TextFormatString = "{0:N2}";
            this.tableCell45.Weight = 0.036555646535734392D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell4.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell4.BorderWidth = 1F;
            this.xrTableCell4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Diff01]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StyleName = "DetailData1";
            this.xrTableCell4.StylePriority.UseBackColor = false;
            this.xrTableCell4.StylePriority.UseBorderColor = false;
            this.xrTableCell4.StylePriority.UseBorders = false;
            this.xrTableCell4.StylePriority.UseBorderWidth = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell4.TextFormatString = "{0:N2}";
            this.xrTableCell4.Weight = 0.036555646463792772D;
            // 
            // xrTableCell55
            // 
            this.xrTableCell55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell55.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell55.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell55.BorderWidth = 1F;
            this.xrTableCell55.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Percent01]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.xrTableCell55.Multiline = true;
            this.xrTableCell55.Name = "xrTableCell55";
            this.xrTableCell55.StyleName = "DetailData1";
            this.xrTableCell55.StylePriority.UseBackColor = false;
            this.xrTableCell55.StylePriority.UseBorderColor = false;
            this.xrTableCell55.StylePriority.UseBorders = false;
            this.xrTableCell55.StylePriority.UseBorderWidth = false;
            this.xrTableCell55.StylePriority.UseTextAlignment = false;
            this.xrTableCell55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell55.TextFormatString = "{0:N2}";
            this.xrTableCell55.Weight = 0.024370430999842402D;
            // 
            // tableCell46
            // 
            this.tableCell46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.tableCell46.BorderColor = System.Drawing.Color.Black;
            this.tableCell46.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell46.BorderWidth = 1F;
            this.tableCell46.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Diff02]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell46.Name = "tableCell46";
            this.tableCell46.StyleName = "DetailData1";
            this.tableCell46.StylePriority.UseBackColor = false;
            this.tableCell46.StylePriority.UseBorderColor = false;
            this.tableCell46.StylePriority.UseBorders = false;
            this.tableCell46.StylePriority.UseBorderWidth = false;
            this.tableCell46.StylePriority.UseTextAlignment = false;
            this.tableCell46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell46.TextFormatString = "{0:N2}";
            this.tableCell46.Weight = 0.038050585557233146D;
            // 
            // xrTableCell59
            // 
            this.xrTableCell59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell59.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell59.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell59.BorderWidth = 1F;
            this.xrTableCell59.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Percent02]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.xrTableCell59.Multiline = true;
            this.xrTableCell59.Name = "xrTableCell59";
            this.xrTableCell59.StyleName = "DetailData1";
            this.xrTableCell59.StylePriority.UseBackColor = false;
            this.xrTableCell59.StylePriority.UseBorderColor = false;
            this.xrTableCell59.StylePriority.UseBorders = false;
            this.xrTableCell59.StylePriority.UseBorderWidth = false;
            this.xrTableCell59.StylePriority.UseTextAlignment = false;
            this.xrTableCell59.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell59.TextFormatString = "{0:N2}";
            this.xrTableCell59.Weight = 0.024088607413633251D;
            // 
            // xrTableCell58
            // 
            this.xrTableCell58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell58.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell58.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell58.BorderWidth = 1F;
            this.xrTableCell58.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Diff03]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.xrTableCell58.Multiline = true;
            this.xrTableCell58.Name = "xrTableCell58";
            this.xrTableCell58.StyleName = "DetailData1";
            this.xrTableCell58.StylePriority.UseBackColor = false;
            this.xrTableCell58.StylePriority.UseBorderColor = false;
            this.xrTableCell58.StylePriority.UseBorders = false;
            this.xrTableCell58.StylePriority.UseBorderWidth = false;
            this.xrTableCell58.StylePriority.UseTextAlignment = false;
            this.xrTableCell58.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell58.TextFormatString = "{0:N2}";
            this.xrTableCell58.Weight = 0.036555645650602417D;
            // 
            // xrTableCell61
            // 
            this.xrTableCell61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell61.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell61.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell61.BorderWidth = 1F;
            this.xrTableCell61.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Percent03]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.xrTableCell61.Multiline = true;
            this.xrTableCell61.Name = "xrTableCell61";
            this.xrTableCell61.StyleName = "DetailData1";
            this.xrTableCell61.StylePriority.UseBackColor = false;
            this.xrTableCell61.StylePriority.UseBorderColor = false;
            this.xrTableCell61.StylePriority.UseBorders = false;
            this.xrTableCell61.StylePriority.UseBorderWidth = false;
            this.xrTableCell61.StylePriority.UseTextAlignment = false;
            this.xrTableCell61.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell61.TextFormatString = "{0:N2}";
            this.xrTableCell61.Weight = 0.024370430186652015D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell5.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell5.BorderWidth = 1F;
            this.xrTableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Diff04]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StyleName = "DetailData1";
            this.xrTableCell5.StylePriority.UseBackColor = false;
            this.xrTableCell5.StylePriority.UseBorderColor = false;
            this.xrTableCell5.StylePriority.UseBorders = false;
            this.xrTableCell5.StylePriority.UseBorderWidth = false;
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell5.TextFormatString = "{0:N2}";
            this.xrTableCell5.Weight = 0.036555646458783911D;
            // 
            // xrTableCell69
            // 
            this.xrTableCell69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell69.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell69.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell69.BorderWidth = 1F;
            this.xrTableCell69.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Percent04]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.xrTableCell69.Multiline = true;
            this.xrTableCell69.Name = "xrTableCell69";
            this.xrTableCell69.StyleName = "DetailData1";
            this.xrTableCell69.StylePriority.UseBackColor = false;
            this.xrTableCell69.StylePriority.UseBorderColor = false;
            this.xrTableCell69.StylePriority.UseBorders = false;
            this.xrTableCell69.StylePriority.UseBorderWidth = false;
            this.xrTableCell69.StylePriority.UseTextAlignment = false;
            this.xrTableCell69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell69.TextFormatString = "{0:N2}";
            this.xrTableCell69.Weight = 0.024370430994833516D;
            // 
            // tableCell47
            // 
            this.tableCell47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.tableCell47.BorderColor = System.Drawing.Color.Black;
            this.tableCell47.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell47.BorderWidth = 1F;
            this.tableCell47.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Diff05]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell47.Name = "tableCell47";
            this.tableCell47.StyleName = "DetailData1";
            this.tableCell47.StylePriority.UseBackColor = false;
            this.tableCell47.StylePriority.UseBorderColor = false;
            this.tableCell47.StylePriority.UseBorders = false;
            this.tableCell47.StylePriority.UseBorderWidth = false;
            this.tableCell47.StylePriority.UseTextAlignment = false;
            this.tableCell47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell47.TextFormatString = "{0:N2}";
            this.tableCell47.Weight = 0.036555646425317556D;
            // 
            // xrTableCell70
            // 
            this.xrTableCell70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell70.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell70.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell70.BorderWidth = 1F;
            this.xrTableCell70.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Percent05]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.xrTableCell70.Multiline = true;
            this.xrTableCell70.Name = "xrTableCell70";
            this.xrTableCell70.StyleName = "DetailData1";
            this.xrTableCell70.StylePriority.UseBackColor = false;
            this.xrTableCell70.StylePriority.UseBorderColor = false;
            this.xrTableCell70.StylePriority.UseBorders = false;
            this.xrTableCell70.StylePriority.UseBorderWidth = false;
            this.xrTableCell70.StylePriority.UseTextAlignment = false;
            this.xrTableCell70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell70.TextFormatString = "{0:N2}";
            this.xrTableCell70.Weight = 0.024370430961367161D;
            // 
            // xrTableCell65
            // 
            this.xrTableCell65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell65.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell65.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell65.BorderWidth = 1F;
            this.xrTableCell65.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Diff06]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.xrTableCell65.Multiline = true;
            this.xrTableCell65.Name = "xrTableCell65";
            this.xrTableCell65.StyleName = "DetailData1";
            this.xrTableCell65.StylePriority.UseBackColor = false;
            this.xrTableCell65.StylePriority.UseBorderColor = false;
            this.xrTableCell65.StylePriority.UseBorders = false;
            this.xrTableCell65.StylePriority.UseBorderWidth = false;
            this.xrTableCell65.StylePriority.UseTextAlignment = false;
            this.xrTableCell65.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell65.TextFormatString = "{0:N2}";
            this.xrTableCell65.Weight = 0.036555646425317556D;
            // 
            // xrTableCell71
            // 
            this.xrTableCell71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell71.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell71.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell71.BorderWidth = 1F;
            this.xrTableCell71.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Percent06]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.xrTableCell71.Multiline = true;
            this.xrTableCell71.Name = "xrTableCell71";
            this.xrTableCell71.StyleName = "DetailData1";
            this.xrTableCell71.StylePriority.UseBackColor = false;
            this.xrTableCell71.StylePriority.UseBorderColor = false;
            this.xrTableCell71.StylePriority.UseBorders = false;
            this.xrTableCell71.StylePriority.UseBorderWidth = false;
            this.xrTableCell71.StylePriority.UseTextAlignment = false;
            this.xrTableCell71.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell71.TextFormatString = "{0:N2}";
            this.xrTableCell71.Weight = 0.024370486740856893D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell7.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell7.BorderWidth = 1F;
            this.xrTableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Diff07]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StyleName = "DetailData1";
            this.xrTableCell7.StylePriority.UseBackColor = false;
            this.xrTableCell7.StylePriority.UseBorderColor = false;
            this.xrTableCell7.StylePriority.UseBorders = false;
            this.xrTableCell7.StylePriority.UseBorderWidth = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell7.TextFormatString = "{0:N2}";
            this.xrTableCell7.Weight = 0.036555547362179378D;
            // 
            // tableCell48
            // 
            this.tableCell48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.tableCell48.BorderColor = System.Drawing.Color.Black;
            this.tableCell48.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell48.BorderWidth = 1F;
            this.tableCell48.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Percent07]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell48.Name = "tableCell48";
            this.tableCell48.StyleName = "DetailData1";
            this.tableCell48.StylePriority.UseBackColor = false;
            this.tableCell48.StylePriority.UseBorderColor = false;
            this.tableCell48.StylePriority.UseBorders = false;
            this.tableCell48.StylePriority.UseBorderWidth = false;
            this.tableCell48.StylePriority.UseTextAlignment = false;
            this.tableCell48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell48.TextFormatString = "{0:N2}";
            this.tableCell48.Weight = 0.024370452686857315D;
            // 
            // xrTableCell77
            // 
            this.xrTableCell77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell77.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell77.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell77.BorderWidth = 1F;
            this.xrTableCell77.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Diff08]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.xrTableCell77.Multiline = true;
            this.xrTableCell77.Name = "xrTableCell77";
            this.xrTableCell77.StyleName = "DetailData1";
            this.xrTableCell77.StylePriority.UseBackColor = false;
            this.xrTableCell77.StylePriority.UseBorderColor = false;
            this.xrTableCell77.StylePriority.UseBorders = false;
            this.xrTableCell77.StylePriority.UseBorderWidth = false;
            this.xrTableCell77.StylePriority.UseTextAlignment = false;
            this.xrTableCell77.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell77.TextFormatString = "{0:N2}";
            this.xrTableCell77.Weight = 0.03655564563386924D;
            // 
            // xrTableCell79
            // 
            this.xrTableCell79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell79.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell79.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell79.BorderWidth = 1F;
            this.xrTableCell79.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Percent08]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.xrTableCell79.Multiline = true;
            this.xrTableCell79.Name = "xrTableCell79";
            this.xrTableCell79.StyleName = "DetailData1";
            this.xrTableCell79.StylePriority.UseBackColor = false;
            this.xrTableCell79.StylePriority.UseBorderColor = false;
            this.xrTableCell79.StylePriority.UseBorders = false;
            this.xrTableCell79.StylePriority.UseBorderWidth = false;
            this.xrTableCell79.StylePriority.UseTextAlignment = false;
            this.xrTableCell79.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell79.TextFormatString = "{0:N2}";
            this.xrTableCell79.Weight = 0.02437033100638154D;
            // 
            // xrTableCell78
            // 
            this.xrTableCell78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell78.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell78.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell78.BorderWidth = 1F;
            this.xrTableCell78.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Diff09]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.xrTableCell78.Multiline = true;
            this.xrTableCell78.Name = "xrTableCell78";
            this.xrTableCell78.StyleName = "DetailData1";
            this.xrTableCell78.StylePriority.UseBackColor = false;
            this.xrTableCell78.StylePriority.UseBorderColor = false;
            this.xrTableCell78.StylePriority.UseBorders = false;
            this.xrTableCell78.StylePriority.UseBorderWidth = false;
            this.xrTableCell78.StylePriority.UseTextAlignment = false;
            this.xrTableCell78.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell78.TextFormatString = "{0:N2}";
            this.xrTableCell78.Weight = 0.036555744797406545D;
            // 
            // xrTableCell80
            // 
            this.xrTableCell80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell80.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell80.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell80.BorderWidth = 1F;
            this.xrTableCell80.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Percent09]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.xrTableCell80.Multiline = true;
            this.xrTableCell80.Name = "xrTableCell80";
            this.xrTableCell80.StyleName = "DetailData1";
            this.xrTableCell80.StylePriority.UseBackColor = false;
            this.xrTableCell80.StylePriority.UseBorderColor = false;
            this.xrTableCell80.StylePriority.UseBorders = false;
            this.xrTableCell80.StylePriority.UseBorderWidth = false;
            this.xrTableCell80.StylePriority.UseTextAlignment = false;
            this.xrTableCell80.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell80.TextFormatString = "{0:N2}";
            this.xrTableCell80.Weight = 0.024370231842844235D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell8.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell8.BorderWidth = 1F;
            this.xrTableCell8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Diff10]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.xrTableCell8.Multiline = true;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StyleName = "DetailData1";
            this.xrTableCell8.StylePriority.UseBackColor = false;
            this.xrTableCell8.StylePriority.UseBorderColor = false;
            this.xrTableCell8.StylePriority.UseBorders = false;
            this.xrTableCell8.StylePriority.UseBorderWidth = false;
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell8.TextFormatString = "{0:N2}";
            this.xrTableCell8.Weight = 0.036555844752392173D;
            // 
            // xrTableCell87
            // 
            this.xrTableCell87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell87.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell87.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell87.BorderWidth = 1F;
            this.xrTableCell87.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Percent10]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.xrTableCell87.Multiline = true;
            this.xrTableCell87.Name = "xrTableCell87";
            this.xrTableCell87.StyleName = "DetailData1";
            this.xrTableCell87.StylePriority.UseBackColor = false;
            this.xrTableCell87.StylePriority.UseBorderColor = false;
            this.xrTableCell87.StylePriority.UseBorders = false;
            this.xrTableCell87.StylePriority.UseBorderWidth = false;
            this.xrTableCell87.StylePriority.UseTextAlignment = false;
            this.xrTableCell87.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell87.TextFormatString = "{0:N2}";
            this.xrTableCell87.Weight = 0.024370430961367161D;
            // 
            // xrTableCell83
            // 
            this.xrTableCell83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell83.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell83.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell83.BorderWidth = 1F;
            this.xrTableCell83.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Diff11]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.xrTableCell83.Multiline = true;
            this.xrTableCell83.Name = "xrTableCell83";
            this.xrTableCell83.StyleName = "DetailData1";
            this.xrTableCell83.StylePriority.UseBackColor = false;
            this.xrTableCell83.StylePriority.UseBorderColor = false;
            this.xrTableCell83.StylePriority.UseBorders = false;
            this.xrTableCell83.StylePriority.UseBorderWidth = false;
            this.xrTableCell83.StylePriority.UseTextAlignment = false;
            this.xrTableCell83.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell83.TextFormatString = "{0:N2}";
            this.xrTableCell83.Weight = 0.036555646425317556D;
            // 
            // xrTableCell88
            // 
            this.xrTableCell88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell88.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell88.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell88.BorderWidth = 1F;
            this.xrTableCell88.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Percent11]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.xrTableCell88.Multiline = true;
            this.xrTableCell88.Name = "xrTableCell88";
            this.xrTableCell88.StyleName = "DetailData1";
            this.xrTableCell88.StylePriority.UseBackColor = false;
            this.xrTableCell88.StylePriority.UseBorderColor = false;
            this.xrTableCell88.StylePriority.UseBorders = false;
            this.xrTableCell88.StylePriority.UseBorderWidth = false;
            this.xrTableCell88.StylePriority.UseTextAlignment = false;
            this.xrTableCell88.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell88.TextFormatString = "{0:N2}";
            this.xrTableCell88.Weight = 0.024370430961367155D;
            // 
            // tableCell49
            // 
            this.tableCell49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.tableCell49.BorderColor = System.Drawing.Color.Black;
            this.tableCell49.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell49.BorderWidth = 1F;
            this.tableCell49.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Diff12]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.tableCell49.Name = "tableCell49";
            this.tableCell49.StyleName = "DetailData1";
            this.tableCell49.StylePriority.UseBackColor = false;
            this.tableCell49.StylePriority.UseBorderColor = false;
            this.tableCell49.StylePriority.UseBorders = false;
            this.tableCell49.StylePriority.UseBorderWidth = false;
            this.tableCell49.StylePriority.UseTextAlignment = false;
            this.tableCell49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell49.TextFormatString = "{0:N2}";
            this.tableCell49.Weight = 0.036555646458783925D;
            // 
            // xrTableCell89
            // 
            this.xrTableCell89.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell89.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell89.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell89.BorderWidth = 1F;
            this.xrTableCell89.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Percent12]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'")});
            this.xrTableCell89.Multiline = true;
            this.xrTableCell89.Name = "xrTableCell89";
            this.xrTableCell89.StyleName = "DetailData1";
            this.xrTableCell89.StylePriority.UseBackColor = false;
            this.xrTableCell89.StylePriority.UseBorderColor = false;
            this.xrTableCell89.StylePriority.UseBorders = false;
            this.xrTableCell89.StylePriority.UseBorderWidth = false;
            this.xrTableCell89.StylePriority.UseTextAlignment = false;
            this.xrTableCell89.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell89.TextFormatString = "{0:N2}";
            this.xrTableCell89.Weight = 0.024370430994833523D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell10.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell10.BorderWidth = 1F;
            this.xrTableCell10.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Diff16]")});
            this.xrTableCell10.Multiline = true;
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.StyleName = "DetailData1";
            this.xrTableCell10.StylePriority.UseBackColor = false;
            this.xrTableCell10.StylePriority.UseBorderColor = false;
            this.xrTableCell10.StylePriority.UseBorders = false;
            this.xrTableCell10.StylePriority.UseBorderWidth = false;
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell10.TextFormatString = "{0:N2}";
            this.xrTableCell10.Weight = 0.036555646458783939D;
            // 
            // xrTableCell95
            // 
            this.xrTableCell95.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.xrTableCell95.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell95.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell95.BorderWidth = 1F;
            this.xrTableCell95.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Percent16]")});
            this.xrTableCell95.Multiline = true;
            this.xrTableCell95.Name = "xrTableCell95";
            this.xrTableCell95.StyleName = "DetailData1";
            this.xrTableCell95.StylePriority.UseBackColor = false;
            this.xrTableCell95.StylePriority.UseBorderColor = false;
            this.xrTableCell95.StylePriority.UseBorders = false;
            this.xrTableCell95.StylePriority.UseBorderWidth = false;
            this.xrTableCell95.StylePriority.UseTextAlignment = false;
            this.xrTableCell95.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell95.TextFormatString = "{0:N2}";
            this.xrTableCell95.Weight = 0.02437043099483353D;
            // 
            // tableCell50
            // 
            this.tableCell50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.tableCell50.BorderColor = System.Drawing.Color.Black;
            this.tableCell50.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell50.BorderWidth = 1F;
            this.tableCell50.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Diff17]")});
            this.tableCell50.Name = "tableCell50";
            this.tableCell50.StyleName = "DetailData1";
            this.tableCell50.StylePriority.UseBackColor = false;
            this.tableCell50.StylePriority.UseBorderColor = false;
            this.tableCell50.StylePriority.UseBorders = false;
            this.tableCell50.StylePriority.UseBorderWidth = false;
            this.tableCell50.StylePriority.UseTextAlignment = false;
            this.tableCell50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell50.TextFormatString = "{0:N2}";
            this.tableCell50.Weight = 0.036555643523499326D;
            // 
            // xrTableCell98
            // 
            this.xrTableCell98.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.xrTableCell98.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell98.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell98.BorderWidth = 1F;
            this.xrTableCell98.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Percent17]")});
            this.xrTableCell98.Multiline = true;
            this.xrTableCell98.Name = "xrTableCell98";
            this.xrTableCell98.StyleName = "DetailData1";
            this.xrTableCell98.StylePriority.UseBackColor = false;
            this.xrTableCell98.StylePriority.UseBorderColor = false;
            this.xrTableCell98.StylePriority.UseBorders = false;
            this.xrTableCell98.StylePriority.UseBorderWidth = false;
            this.xrTableCell98.StylePriority.UseTextAlignment = false;
            this.xrTableCell98.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell98.TextFormatString = "{0:N2}";
            this.xrTableCell98.Weight = 0.024370431158409468D;
            // 
            // xrTableCell96
            // 
            this.xrTableCell96.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell96.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell96.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell96.BorderWidth = 1F;
            this.xrTableCell96.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Diff18]")});
            this.xrTableCell96.Multiline = true;
            this.xrTableCell96.Name = "xrTableCell96";
            this.xrTableCell96.StyleName = "DetailData1";
            this.xrTableCell96.StylePriority.UseBackColor = false;
            this.xrTableCell96.StylePriority.UseBorderColor = false;
            this.xrTableCell96.StylePriority.UseBorders = false;
            this.xrTableCell96.StylePriority.UseBorderWidth = false;
            this.xrTableCell96.StylePriority.UseTextAlignment = false;
            this.xrTableCell96.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell96.TextFormatString = "{0:N2}";
            this.xrTableCell96.Weight = 0.036555646622359869D;
            // 
            // xrTableCell97
            // 
            this.xrTableCell97.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(203)))));
            this.xrTableCell97.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell97.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell97.BorderWidth = 1F;
            this.xrTableCell97.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Font.Bold", "[Calculation]==\'SUM\'"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Percent18]")});
            this.xrTableCell97.Multiline = true;
            this.xrTableCell97.Name = "xrTableCell97";
            this.xrTableCell97.StyleName = "DetailData1";
            this.xrTableCell97.StylePriority.UseBackColor = false;
            this.xrTableCell97.StylePriority.UseBorderColor = false;
            this.xrTableCell97.StylePriority.UseBorders = false;
            this.xrTableCell97.StylePriority.UseBorderWidth = false;
            this.xrTableCell97.StylePriority.UseTextAlignment = false;
            this.xrTableCell97.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell97.TextFormatString = "{0:N2}";
            this.xrTableCell97.Weight = 0.025320259803896929D;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "KTQT_Data_Connection";
            this.sqlDataSource1.ConnectionOptions.CommandTimeout = 3600;
            this.sqlDataSource1.ConnectionOptions.DbCommandTimeout = 3600;
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "ReportKehoachThuchiLVTM";
            queryParameter1.Name = "@pVersionID";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("?pVersionID", typeof(decimal));
            queryParameter2.Name = "@pCompanyID";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("?pCompanyID", typeof(int));
            queryParameter3.Name = "@pFromMonth";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("?pFromMonth", typeof(int));
            queryParameter4.Name = "@pToMonth";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("?pToMonth", typeof(int));
            queryParameter5.Name = "@pReportName";
            queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter5.Value = new DevExpress.DataAccess.Expression("?pReportName", typeof(string));
            queryParameter6.Name = "@pAreaCode";
            queryParameter6.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter6.Value = new DevExpress.DataAccess.Expression("?pAreaCode", typeof(string));
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.Parameters.Add(queryParameter4);
            storedProcQuery1.Parameters.Add(queryParameter5);
            storedProcQuery1.Parameters.Add(queryParameter6);
            storedProcQuery1.StoredProcName = "ReportKehoachThuchiLVTM_NT9M";
            customSqlQuery1.Name = "Query";
            queryParameter7.Name = "pVersionID";
            queryParameter7.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter7.Value = new DevExpress.DataAccess.Expression("?pVersionID", typeof(long));
            customSqlQuery1.Parameters.Add(queryParameter7);
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            customSqlQuery2.Name = "Query_1";
            queryParameter8.Name = "pCompanyID";
            queryParameter8.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter8.Value = new DevExpress.DataAccess.Expression("?pCompanyID", typeof(int));
            queryParameter9.Name = "pVersionID";
            queryParameter9.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter9.Value = new DevExpress.DataAccess.Expression("?pVersionID", typeof(long));
            queryParameter10.Name = "pFromMonth";
            queryParameter10.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter10.Value = new DevExpress.DataAccess.Expression("?pFromMonth", typeof(int));
            queryParameter11.Name = "pToMonth";
            queryParameter11.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter11.Value = new DevExpress.DataAccess.Expression("?pToMonth", typeof(int));
            customSqlQuery2.Parameters.Add(queryParameter8);
            customSqlQuery2.Parameters.Add(queryParameter9);
            customSqlQuery2.Parameters.Add(queryParameter10);
            customSqlQuery2.Parameters.Add(queryParameter11);
            customSqlQuery2.Sql = "select NameV, Curr, dbo.GetAVGRoeVN(@pVersionID, Curr, @pFromMonth, @pToMonth) Ro" +
    "e\r\nFrom DecCompanies Where CompanyID = @pCompanyID";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1,
            customSqlQuery1,
            customSqlQuery2});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Arial", 14.25F);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.Title.Name = "Title";
            this.Title.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            // 
            // DetailCaption1
            // 
            this.DetailCaption1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.DetailCaption1.BorderColor = System.Drawing.Color.White;
            this.DetailCaption1.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.DetailCaption1.BorderWidth = 2F;
            this.DetailCaption1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.DetailCaption1.ForeColor = System.Drawing.Color.White;
            this.DetailCaption1.Name = "DetailCaption1";
            this.DetailCaption1.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailCaption1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData1
            // 
            this.DetailData1.BorderColor = System.Drawing.Color.Transparent;
            this.DetailData1.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.DetailData1.BorderWidth = 2F;
            this.DetailData1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.DetailData1.ForeColor = System.Drawing.Color.Black;
            this.DetailData1.Name = "DetailData1";
            this.DetailData1.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData3_Odd
            // 
            this.DetailData3_Odd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.DetailData3_Odd.BorderColor = System.Drawing.Color.Transparent;
            this.DetailData3_Odd.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DetailData3_Odd.BorderWidth = 1F;
            this.DetailData3_Odd.Font = new System.Drawing.Font("Arial", 8.25F);
            this.DetailData3_Odd.ForeColor = System.Drawing.Color.Black;
            this.DetailData3_Odd.Name = "DetailData3_Odd";
            this.DetailData3_Odd.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData3_Odd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageInfo
            // 
            this.PageInfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.PageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.PageInfo.Name = "PageInfo";
            this.PageInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            // 
            // pVersionID
            // 
            this.pVersionID.Name = "pVersionID";
            this.pVersionID.Type = typeof(decimal);
            this.pVersionID.ValueInfo = "2245";
            // 
            // pCompanyID
            // 
            this.pCompanyID.Name = "pCompanyID";
            this.pCompanyID.Type = typeof(int);
            this.pCompanyID.ValueInfo = "12";
            // 
            // pFromMonth
            // 
            this.pFromMonth.Name = "pFromMonth";
            this.pFromMonth.Type = typeof(int);
            this.pFromMonth.ValueInfo = "1";
            // 
            // pToMonth
            // 
            this.pToMonth.Name = "pToMonth";
            this.pToMonth.Type = typeof(int);
            this.pToMonth.ValueInfo = "12";
            // 
            // pReportName
            // 
            this.pReportName.Description = "ReportName";
            this.pReportName.Name = "pReportName";
            this.pReportName.ValueInfo = "ReportKehoachThuchiLVTM_NT";
            // 
            // pAreaCode
            // 
            this.pAreaCode.Description = "Group";
            this.pAreaCode.Name = "pAreaCode";
            this.pAreaCode.ValueInfo = "ALL";
            // 
            // ReportKehoachThuchiLVTM_NT_9M
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.GroupHeader1,
            this.Detail});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "ReportKehoachThuchiLVTM";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(0, 20, 30, 43);
            this.PageHeight = 1654;
            this.PageWidth = 4120;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.pVersionID,
            this.pCompanyID,
            this.pFromMonth,
            this.pToMonth,
            this.pReportName,
            this.pAreaCode});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.DetailCaption1,
            this.DetailData1,
            this.DetailData3_Odd,
            this.PageInfo});
            this.Version = "20.2";
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
