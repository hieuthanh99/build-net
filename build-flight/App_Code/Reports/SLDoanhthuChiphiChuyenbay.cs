using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using KTQTData;
using System.Linq;

/// <summary>
/// Summary description for SLDoanhthuChiphiChuyenbay
/// </summary>
public class SLDoanhthuChiphiChuyenbay : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private DevExpress.XtraReports.Parameters.Parameter pFromDate;
    private DevExpress.XtraReports.Parameters.Parameter pToDate;
    private DevExpress.XtraReports.Parameters.Parameter pAreaCode;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
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
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell20;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel1;
    private DevExpress.XtraReports.Parameters.Parameter pDateStr;
    private XRLabel xrLabel2;
    private ReportFooterBand ReportFooter;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell33;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell36;
    private DevExpress.XtraReports.Parameters.Parameter pCarrier;
    private DevExpress.XtraReports.Parameters.Parameter pNetwork;
    private DevExpress.XtraReports.Parameters.Parameter pFltType;
    private DevExpress.XtraReports.Parameters.Parameter pVersionID;
    private XRTableCell xrTableCell38;
    private XRTableCell xrTableCell41;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell40;
    private XRTableCell xrTableCell39;
    private XRTableCell xrTableCell42;
    private XRLabel xrLabel3;
    private XRTableCell xrTableCell45;
    private XRTableCell xrTableCell46;
    private XRTableCell xrTableCell43;
    private XRTableCell xrTableCell44;
    private XRTableCell xrTableCell47;
    private XRTableCell xrTableCell48;
    private XRLabel xrLabel4;
    private DevExpress.XtraReports.Parameters.Parameter pCostType;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell49;
    private XRTableCell xrTableCell51;
    private XRTableCell xrTableCell50;
    private XRTableCell xrTableCell52;
    private XRTableCell xrTableCell54;
    private XRTableCell xrTableCell53;
    private XRTableCell xrTableCell55;
    private DetailReportBand DetailReport;
    private DetailBand Detail1;
    private ReportHeaderBand ReportHeader1;
    private ReportFooterBand ReportFooter1;
    private DetailReportBand DetailReport1;
    private DetailBand Detail2;
    private ReportHeaderBand ReportHeader2;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell56;
    private XRTableCell xrTableCell57;
    private XRTableCell xrTableCell58;
    private XRLabel xrLabel5;
    private XRTableCell xrTableCell59;
    private XRTableCell xrTableCell60;
    private XRTableCell xrTableCell61;
    private XRTableCell xrTableCell62;
    private XRTable xrTable5;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell63;
    private XRTableCell xrTableCell64;
    private XRTableCell xrTableCell65;
    private XRTableCell xrTableCell66;
    private XRTableCell xrTableCell67;
    private XRTableCell xrTableCell68;
    private XRTableCell xrTableCell69;
    private ReportFooterBand ReportFooter2;
    private XRTable xrTable6;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell70;
    private XRTableCell xrTableCell76;
    private XRTableCell xrTableCell72;
    private XRTableCell xrTableCell71;
    private XRTableCell xrTableCell73;
    private XRTableCell xrTableCell75;
    private XRTableCell xrTableCell74;
    private XRTableCell xrTableCell78;
    private XRTableCell xrTableCell77;
    private XRTableCell xrTableCell79;
    private DetailReportBand DetailReport2;
    private DetailBand Detail3;
    private ReportHeaderBand ReportHeader3;
    private ReportFooterBand ReportFooter3;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRTable xrTable7;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell80;
    private XRTableCell xrTableCell81;
    private XRTableCell xrTableCell82;
    private XRTable xrTable8;
    private XRTableRow xrTableRow8;
    private XRTableCell xrTableCell83;
    private XRTableCell xrTableCell84;
    private XRTableCell xrTableCell85;
    private XRTable xrTable9;
    private XRTableRow xrTableRow9;
    private XRTableCell xrTableCell86;
    private XRTableCell xrTableCell88;
    private XRTableCell xrTableCell89;
    private XRTableCell xrTableCell87;
    private XRTableCell xrTableCell90;
    private XRTableCell xrTableCell92;
    private XRTableCell xrTableCell91;
    private DevExpress.XtraReports.Parameters.Parameter pNotProfitable;
    private CalculatedField DIFF;
    private CalculatedField NOT_PROFIT;
    private XRTableCell xrTableCell95;
    private XRTableCell xrTableCell96;
    private XRTableCell xrTableCell93;
    private XRTableCell xrTableCell94;
    private XRTableCell xrTableCell97;
    private XRTableCell xrTableCell98;
    private XRLabel xrLabel6;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public SLDoanhthuChiphiChuyenbay()
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
            string resourceFileName = "SLDoanhthuChiphiChuyenbay.resx";
            System.Resources.ResourceManager resources = global::Resources.SLDoanhthuChiphiChuyenbay.ResourceManager;
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
            DevExpress.DataAccess.Sql.QueryParameter queryParameter9 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery2 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter10 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter11 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter12 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery3 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter13 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter14 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter15 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter16 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary10 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary11 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary12 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary13 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary14 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary15 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary16 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell75 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell54 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell72 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell95 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell96 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.pFromDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.pToDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.pAreaCode = new DevExpress.XtraReports.Parameters.Parameter();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell74 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell53 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell71 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell93 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell94 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.pDateStr = new DevExpress.XtraReports.Parameters.Parameter();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell55 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell73 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell97 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell98 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.pCarrier = new DevExpress.XtraReports.Parameters.Parameter();
            this.pNetwork = new DevExpress.XtraReports.Parameters.Parameter();
            this.pFltType = new DevExpress.XtraReports.Parameters.Parameter();
            this.pVersionID = new DevExpress.XtraReports.Parameters.Parameter();
            this.pCostType = new DevExpress.XtraReports.Parameters.Parameter();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ReportFooter1 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.DetailReport1 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail2 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell56 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell57 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell58 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell59 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell60 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell61 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell62 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell78 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportHeader2 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell63 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell64 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell65 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell67 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell68 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell69 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell77 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter2 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell70 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell76 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell79 = new DevExpress.XtraReports.UI.XRTableCell();
            this.DetailReport2 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail3 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable7 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell80 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell92 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell81 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell82 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell89 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportHeader3 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell83 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell91 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell84 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell85 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell87 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter3 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrTable9 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell86 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell88 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell90 = new DevExpress.XtraReports.UI.XRTableCell();
            this.pNotProfitable = new DevExpress.XtraReports.Parameters.Parameter();
            this.DIFF = new DevExpress.XtraReports.UI.CalculatedField();
            this.NOT_PROFIT = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Expanded = false;
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1837.332F, 25F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UsePadding = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell75,
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell51,
            this.xrTableCell54,
            this.xrTableCell9,
            this.xrTableCell45,
            this.xrTableCell46,
            this.xrTableCell10,
            this.xrTableCell72,
            this.xrTableCell38,
            this.xrTableCell30,
            this.xrTableCell95,
            this.xrTableCell96,
            this.xrTableCell41,
            this.xrTableCell34,
            this.xrTableCell27,
            this.xrTableCell28,
            this.xrTableCell33});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell75
            // 
            this.xrTableCell75.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AREA]")});
            this.xrTableCell75.Name = "xrTableCell75";
            this.xrTableCell75.Weight = 0.38958340958525994D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FLT_MONTH]")});
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Weight = 0.34791654143726514D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FLT_YEAR]")});
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Weight = 0.36875005023484358D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CARRIER]")});
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Weight = 0.40208250450045907D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AC_ID]")});
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Weight = 0.48333295493148332D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[NETWORK]")});
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Weight = 0.58999997112862479D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SECTOR]")});
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Weight = 0.60791715736518459D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FLT_TYPE]")});
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Weight = 0.52083280123150988D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FLS_ALL]")});
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell8.TextFormatString = "{0:#,#}";
            this.xrTableCell8.Weight = 0.38958280991635535D;
            // 
            // xrTableCell51
            // 
            this.xrTableCell51.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[STATUS]")});
            this.xrTableCell51.Name = "xrTableCell51";
            this.xrTableCell51.StylePriority.UseTextAlignment = false;
            this.xrTableCell51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell51.Weight = 0.34166685368507971D;
            // 
            // xrTableCell54
            // 
            this.xrTableCell54.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FLS_FULL]")});
            this.xrTableCell54.Name = "xrTableCell54";
            this.xrTableCell54.StylePriority.UseTextAlignment = false;
            this.xrTableCell54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell54.Weight = 0.40312650668458938D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[REV]")});
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell9.TextFormatString = "{0:n2}";
            this.xrTableCell9.Weight = 0.94687342922908169D;
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OTH_REV]")});
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.StylePriority.UseTextAlignment = false;
            this.xrTableCell45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell45.TextFormatString = "{0:n2}";
            this.xrTableCell45.Weight = 1.0062475108755857D;
            // 
            // xrTableCell46
            // 
            this.xrTableCell46.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TOTAL_REV]")});
            this.xrTableCell46.Name = "xrTableCell46";
            this.xrTableCell46.StylePriority.UseTextAlignment = false;
            this.xrTableCell46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell46.TextFormatString = "{0:n2}";
            this.xrTableCell46.Weight = 1.0437505499988504D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COST]")});
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell10.TextFormatString = "{0:n2}";
            this.xrTableCell10.Weight = 0.92708676799155376D;
            // 
            // xrTableCell72
            // 
            this.xrTableCell72.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ONBEHALFOFCTY]")});
            this.xrTableCell72.Name = "xrTableCell72";
            this.xrTableCell72.StylePriority.UseTextAlignment = false;
            this.xrTableCell72.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell72.TextFormatString = "{0:n2}";
            this.xrTableCell72.Weight = 0.86875240339083815D;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COSTCTY]")});
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.StylePriority.UseTextAlignment = false;
            this.xrTableCell38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell38.TextFormatString = "{0:n2}";
            this.xrTableCell38.Weight = 0.92083247905451293D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[COST_BRANCH]")});
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.StylePriority.UseTextAlignment = false;
            this.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell30.TextFormatString = "{0:n2}";
            this.xrTableCell30.Weight = 1.0208337066601214D;
            // 
            // xrTableCell95
            // 
            this.xrTableCell95.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Cost_BDS]")});
            this.xrTableCell95.Name = "xrTableCell95";
            this.xrTableCell95.StylePriority.UseTextAlignment = false;
            this.xrTableCell95.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell95.TextFormatString = "{0:n2}";
            this.xrTableCell95.Weight = 1.0416613215494321D;
            // 
            // xrTableCell96
            // 
            this.xrTableCell96.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Cost_KST]")});
            this.xrTableCell96.Name = "xrTableCell96";
            this.xrTableCell96.StylePriority.UseTextAlignment = false;
            this.xrTableCell96.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell96.TextFormatString = "{0:n2}";
            this.xrTableCell96.Weight = 1.0416613215494321D;
            // 
            // xrTableCell41
            // 
            this.xrTableCell41.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TOTAL_COST]")});
            this.xrTableCell41.Name = "xrTableCell41";
            this.xrTableCell41.StylePriority.UseTextAlignment = false;
            this.xrTableCell41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell41.TextFormatString = "{0:n2}";
            this.xrTableCell41.Weight = 1.0416613215494321D;
            // 
            // xrTableCell34
            // 
            this.xrTableCell34.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "Iif(IsNull([TOTAL_REV]), 0, [TOTAL_REV])-Iif(IsNull([TOTAL_COST]), 0, [TOTAL_COST" +
                    "])")});
            this.xrTableCell34.Name = "xrTableCell34";
            this.xrTableCell34.StylePriority.UseTextAlignment = false;
            this.xrTableCell34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell34.TextFormatString = "{0:n2}";
            this.xrTableCell34.Weight = 1.0145849478791722D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "Iif([STATUS]=\'CN\', 0, [TOTAL_REV]/[FLS_ALL])")});
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.StylePriority.UseTextAlignment = false;
            this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell27.TextFormatString = "{0:n2}";
            this.xrTableCell27.Weight = 0.92750236985251588D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "Iif([STATUS]=\'CN\', 0, [TOTAL_COST]/[FLS_FULL])")});
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.StylePriority.UseTextAlignment = false;
            this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell28.TextFormatString = "{0:n2}";
            this.xrTableCell28.Weight = 0.86374387678929876D;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "Iif([STATUS]=\'CN\', 0, Iif(IsNull([TOTAL_REV]), 0, [TOTAL_REV])/[FLS_FULL]-Iif(IsN" +
                    "ull([TOTAL_COST]), 0, [TOTAL_COST])/[FLS_FULL])")});
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.StylePriority.UseTextAlignment = false;
            this.xrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell33.TextFormatString = "{0:n2}";
            this.xrTableCell33.Weight = 0.86333830615656182D;
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
            this.BottomMargin.HeightF = 12F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // pFromDate
            // 
            this.pFromDate.Name = "pFromDate";
            this.pFromDate.Type = typeof(System.DateTime);
            this.pFromDate.ValueInfo = "2020-01-01";
            this.pFromDate.Visible = false;
            // 
            // pToDate
            // 
            this.pToDate.Name = "pToDate";
            this.pToDate.Type = typeof(System.DateTime);
            this.pToDate.ValueInfo = "2020-01-31";
            this.pToDate.Visible = false;
            // 
            // pAreaCode
            // 
            this.pAreaCode.Name = "pAreaCode";
            this.pAreaCode.ValueInfo = "SGN";
            this.pAreaCode.Visible = false;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "KTQT_Data_Connection";
            this.sqlDataSource1.ConnectionOptions.DbCommandTimeout = 0;
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            queryParameter1.Name = "pFromDate";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.pFromDate]", typeof(System.DateTime));
            queryParameter2.Name = "pToDate";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.pToDate]", typeof(System.DateTime));
            queryParameter3.Name = "pAreaCode";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.pAreaCode]", typeof(string));
            queryParameter4.Name = "pCarrier";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("[Parameters.pCarrier]", typeof(string));
            queryParameter5.Name = "pNetwork";
            queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter5.Value = new DevExpress.DataAccess.Expression("[Parameters.pNetwork]", typeof(string));
            queryParameter6.Name = "pFltType";
            queryParameter6.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter6.Value = new DevExpress.DataAccess.Expression("[Parameters.pFltType]", typeof(string));
            queryParameter7.Name = "pVersionID";
            queryParameter7.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter7.Value = new DevExpress.DataAccess.Expression("[Parameters.pVersionID]", typeof(long));
            queryParameter8.Name = "pCostType";
            queryParameter8.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter8.Value = new DevExpress.DataAccess.Expression("[Parameters.pCostType]", typeof(string));
            queryParameter9.Name = "pNotProfitable";
            queryParameter9.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter9.Value = new DevExpress.DataAccess.Expression("[Parameters.pNotProfitable]", typeof(string));
            customSqlQuery1.Parameters.Add(queryParameter1);
            customSqlQuery1.Parameters.Add(queryParameter2);
            customSqlQuery1.Parameters.Add(queryParameter3);
            customSqlQuery1.Parameters.Add(queryParameter4);
            customSqlQuery1.Parameters.Add(queryParameter5);
            customSqlQuery1.Parameters.Add(queryParameter6);
            customSqlQuery1.Parameters.Add(queryParameter7);
            customSqlQuery1.Parameters.Add(queryParameter8);
            customSqlQuery1.Parameters.Add(queryParameter9);
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            customSqlQuery2.Name = "Query_1";
            queryParameter10.Name = "pAreaCode";
            queryParameter10.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter10.Value = new DevExpress.DataAccess.Expression("[Parameters.pAreaCode]", typeof(string));
            queryParameter11.Name = "pFromDate";
            queryParameter11.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter11.Value = new DevExpress.DataAccess.Expression("[Parameters.pFromDate]", typeof(System.DateTime));
            queryParameter12.Name = "pToDate";
            queryParameter12.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter12.Value = new DevExpress.DataAccess.Expression("[Parameters.pToDate]", typeof(System.DateTime));
            customSqlQuery2.Parameters.Add(queryParameter10);
            customSqlQuery2.Parameters.Add(queryParameter11);
            customSqlQuery2.Parameters.Add(queryParameter12);
            customSqlQuery2.Sql = resources.GetString("customSqlQuery2.Sql");
            customSqlQuery3.Name = "Query_2";
            queryParameter13.Name = "pVersionID";
            queryParameter13.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter13.Value = new DevExpress.DataAccess.Expression("[Parameters.pVersionID]", typeof(long));
            queryParameter14.Name = "pAreaCode";
            queryParameter14.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter14.Value = new DevExpress.DataAccess.Expression("[Parameters.pAreaCode]", typeof(string));
            queryParameter15.Name = "pFromDate";
            queryParameter15.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter15.Value = new DevExpress.DataAccess.Expression("[Parameters.pFromDate]", typeof(System.DateTime));
            queryParameter16.Name = "pToDate";
            queryParameter16.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter16.Value = new DevExpress.DataAccess.Expression("[Parameters.pToDate]", typeof(System.DateTime));
            customSqlQuery3.Parameters.Add(queryParameter13);
            customSqlQuery3.Parameters.Add(queryParameter14);
            customSqlQuery3.Parameters.Add(queryParameter15);
            customSqlQuery3.Parameters.Add(queryParameter16);
            customSqlQuery3.Sql = resources.GetString("customSqlQuery3.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1,
            customSqlQuery2,
            customSqlQuery3});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1837.333F, 64.58334F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UsePadding = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell74,
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrTableCell14,
            this.xrTableCell13,
            this.xrTableCell15,
            this.xrTableCell16,
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrTableCell50,
            this.xrTableCell53,
            this.xrTableCell19,
            this.xrTableCell43,
            this.xrTableCell44,
            this.xrTableCell20,
            this.xrTableCell71,
            this.xrTableCell37,
            this.xrTableCell29,
            this.xrTableCell93,
            this.xrTableCell94,
            this.xrTableCell40,
            this.xrTableCell32,
            this.xrTableCell25,
            this.xrTableCell26,
            this.xrTableCell31});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell74
            // 
            this.xrTableCell74.Name = "xrTableCell74";
            this.xrTableCell74.Text = "Area";
            this.xrTableCell74.Weight = 0.38958338804883874D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Text = "Month";
            this.xrTableCell11.Weight = 0.34791684637516718D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "Year";
            this.xrTableCell12.Weight = 0.3687498911698523D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Text = "Opt";
            this.xrTableCell14.Weight = 0.4020837303280842D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Text = "AC";
            this.xrTableCell13.Weight = 0.48333237416775265D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Text = "Network";
            this.xrTableCell15.Weight = 0.590000204301293D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Text = "Sector";
            this.xrTableCell16.Weight = 0.60791772106742825D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Text = "Flight Type";
            this.xrTableCell17.Weight = 0.52083331344567474D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Multiline = true;
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Text = "Qty\r\nAll\r\n";
            this.xrTableCell18.Weight = 0.38958266459230789D;
            // 
            // xrTableCell50
            // 
            this.xrTableCell50.Name = "xrTableCell50";
            this.xrTableCell50.Text = "Stat";
            this.xrTableCell50.Weight = 0.34166669457106369D;
            // 
            // xrTableCell53
            // 
            this.xrTableCell53.Multiline = true;
            this.xrTableCell53.Name = "xrTableCell53";
            this.xrTableCell53.Text = "Qty\r\nFull";
            this.xrTableCell53.Weight = 0.40312667364632776D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Multiline = true;
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Text = "Revenue\r\n(On Flight)";
            this.xrTableCell19.Weight = 0.94687499861870728D;
            // 
            // xrTableCell43
            // 
            this.xrTableCell43.Multiline = true;
            this.xrTableCell43.Name = "xrTableCell43";
            this.xrTableCell43.Text = "Revenue\r\n(Not Flight)";
            this.xrTableCell43.Weight = 1.0062503761540507D;
            // 
            // xrTableCell44
            // 
            this.xrTableCell44.Name = "xrTableCell44";
            this.xrTableCell44.Text = "Total Revenue";
            this.xrTableCell44.Weight = 1.0437530536659554D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Multiline = true;
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Text = "Cost\r\n (Branch)";
            this.xrTableCell20.Weight = 0.92708102362480294D;
            // 
            // xrTableCell71
            // 
            this.xrTableCell71.Name = "xrTableCell71";
            this.xrTableCell71.Text = "Disbursement on behalf of KVP (Branch)";
            this.xrTableCell71.Weight = 0.86875212744245833D;
            // 
            // xrTableCell37
            // 
            this.xrTableCell37.Multiline = true;
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.Text = "Cost\r\n(KVP)";
            this.xrTableCell37.Weight = 0.92083588627608848D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.Text = "Disbursement on behalf of branch (KVP)";
            this.xrTableCell29.Weight = 1.0208340770850022D;
            // 
            // xrTableCell93
            // 
            this.xrTableCell93.Multiline = true;
            this.xrTableCell93.Name = "xrTableCell93";
            this.xrTableCell93.Text = "Cost\r\n(TT BDSC)";
            this.xrTableCell93.Weight = 1.0416630034167884D;
            // 
            // xrTableCell94
            // 
            this.xrTableCell94.Multiline = true;
            this.xrTableCell94.Name = "xrTableCell94";
            this.xrTableCell94.Text = "Cost\r\n(TT KST)";
            this.xrTableCell94.Weight = 1.0416630034167884D;
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.Multiline = true;
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.Text = "Total \r\nCost";
            this.xrTableCell40.Weight = 1.0416630034167884D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.Text = "Rev-Cost";
            this.xrTableCell32.Weight = 1.0145865372412981D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.Text = "AVG Rev";
            this.xrTableCell25.Weight = 0.92750396271232571D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.Text = "AVG Cost";
            this.xrTableCell26.Weight = 0.86374055005391981D;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Multiline = true;
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.Text = "AVG\r\n(Rev-Cost)";
            this.xrTableCell31.Weight = 0.86333671920120914D;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
            this.ReportHeader.HeightF = 123.125F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 45.50001F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(1837.331F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 68.50001F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(1837.331F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters].[pDateStr]")});
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 91.5F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(1837.331F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 22.50001F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(1837.331F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "DOANH THU, CHI PHÍ THEO CHUYẾN BAY";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // pDateStr
            // 
            this.pDateStr.Name = "pDateStr";
            this.pDateStr.Visible = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Expanded = false;
            this.ReportFooter.HeightF = 27.5F;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.ReportFooter.StylePriority.UsePadding = false;
            // 
            // xrTable3
            // 
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(1837.331F, 25F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UsePadding = false;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell24,
            this.xrTableCell21,
            this.xrTableCell52,
            this.xrTableCell55,
            this.xrTableCell22,
            this.xrTableCell47,
            this.xrTableCell48,
            this.xrTableCell23,
            this.xrTableCell73,
            this.xrTableCell39,
            this.xrTableCell49,
            this.xrTableCell97,
            this.xrTableCell98,
            this.xrTableCell42,
            this.xrTableCell36,
            this.xrTableCell35});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.StylePriority.UseBorders = false;
            this.xrTableCell24.StylePriority.UseFont = false;
            this.xrTableCell24.StylePriority.UseTextAlignment = false;
            this.xrTableCell24.Text = "Total";
            this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell24.Weight = 1.3492422684009959D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([FLS_ALL])")});
            this.xrTableCell21.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.StylePriority.UseFont = false;
            this.xrTableCell21.StylePriority.UseTextAlignment = false;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell21.Summary = xrSummary1;
            this.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell21.TextFormatString = "{0:#,#}";
            this.xrTableCell21.Weight = 0.14166638174716539D;
            // 
            // xrTableCell52
            // 
            this.xrTableCell52.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell52.Name = "xrTableCell52";
            this.xrTableCell52.StylePriority.UseFont = false;
            this.xrTableCell52.StylePriority.UseTextAlignment = false;
            this.xrTableCell52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell52.Weight = 0.12424251052961986D;
            // 
            // xrTableCell55
            // 
            this.xrTableCell55.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([FLS_FULL])")});
            this.xrTableCell55.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell55.Name = "xrTableCell55";
            this.xrTableCell55.StylePriority.UseFont = false;
            this.xrTableCell55.StylePriority.UseTextAlignment = false;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell55.Summary = xrSummary2;
            this.xrTableCell55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell55.TextFormatString = "{0:#,#}";
            this.xrTableCell55.Weight = 0.14659147465611594D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([REV])")});
            this.xrTableCell22.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.StylePriority.UseFont = false;
            this.xrTableCell22.StylePriority.UseTextAlignment = false;
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell22.Summary = xrSummary3;
            this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell22.TextFormatString = "{0:n2}";
            this.xrTableCell22.Weight = 0.34431653856792832D;
            // 
            // xrTableCell47
            // 
            this.xrTableCell47.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([OTH_REV])")});
            this.xrTableCell47.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell47.Name = "xrTableCell47";
            this.xrTableCell47.StylePriority.UseFont = false;
            this.xrTableCell47.StylePriority.UseTextAlignment = false;
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell47.Summary = xrSummary4;
            this.xrTableCell47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell47.TextFormatString = "{0:n2}";
            this.xrTableCell47.Weight = 0.36590801196588629D;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([TOTAL_REV])")});
            this.xrTableCell48.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.StylePriority.UseFont = false;
            this.xrTableCell48.StylePriority.UseTextAlignment = false;
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell48.Summary = xrSummary5;
            this.xrTableCell48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell48.TextFormatString = "{0:n2}";
            this.xrTableCell48.Weight = 0.37954506933737631D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([COST])")});
            this.xrTableCell23.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.StylePriority.UseFont = false;
            this.xrTableCell23.StylePriority.UseTextAlignment = false;
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell23.Summary = xrSummary6;
            this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell23.TextFormatString = "{0:n2}";
            this.xrTableCell23.Weight = 0.33712427094052216D;
            // 
            // xrTableCell73
            // 
            this.xrTableCell73.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([ONBEHALFOFCTY])")});
            this.xrTableCell73.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell73.Name = "xrTableCell73";
            this.xrTableCell73.StylePriority.UseFont = false;
            this.xrTableCell73.StylePriority.UseTextAlignment = false;
            xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell73.Summary = xrSummary7;
            this.xrTableCell73.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell73.TextFormatString = "{0:n2}";
            this.xrTableCell73.Weight = 0.31590932443047082D;
            // 
            // xrTableCell39
            // 
            this.xrTableCell39.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([COSTCTY])")});
            this.xrTableCell39.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell39.Name = "xrTableCell39";
            this.xrTableCell39.StylePriority.UseFont = false;
            this.xrTableCell39.StylePriority.UseTextAlignment = false;
            xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell39.Summary = xrSummary8;
            this.xrTableCell39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell39.TextFormatString = "{0:n2}";
            this.xrTableCell39.Weight = 0.33484997708368641D;
            // 
            // xrTableCell49
            // 
            this.xrTableCell49.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([COST_BRANCH])")});
            this.xrTableCell49.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell49.Name = "xrTableCell49";
            this.xrTableCell49.StylePriority.UseFont = false;
            this.xrTableCell49.StylePriority.UseTextAlignment = false;
            xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell49.Summary = xrSummary9;
            this.xrTableCell49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell49.TextFormatString = "{0:n2}";
            this.xrTableCell49.Weight = 0.37121316608093158D;
            // 
            // xrTableCell97
            // 
            this.xrTableCell97.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([Cost_BDS])")});
            this.xrTableCell97.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell97.Name = "xrTableCell97";
            this.xrTableCell97.StylePriority.UseFont = false;
            this.xrTableCell97.StylePriority.UseTextAlignment = false;
            xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell97.Summary = xrSummary10;
            this.xrTableCell97.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell97.TextFormatString = "{0:n2}";
            this.xrTableCell97.Weight = 0.37878286494967389D;
            // 
            // xrTableCell98
            // 
            this.xrTableCell98.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([Cost_KST])")});
            this.xrTableCell98.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell98.Name = "xrTableCell98";
            this.xrTableCell98.StylePriority.UseFont = false;
            this.xrTableCell98.StylePriority.UseTextAlignment = false;
            xrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell98.Summary = xrSummary11;
            this.xrTableCell98.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell98.TextFormatString = "{0:n2}";
            this.xrTableCell98.Weight = 0.37878286494967389D;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([TOTAL_COST])")});
            this.xrTableCell42.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.StylePriority.UseFont = false;
            this.xrTableCell42.StylePriority.UseTextAlignment = false;
            xrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell42.Summary = xrSummary12;
            this.xrTableCell42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell42.TextFormatString = "{0:n2}";
            this.xrTableCell42.Weight = 0.37878286494967389D;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([TOTAL_REV])-sumSum([TOTAL_COST])")});
            this.xrTableCell36.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.StylePriority.UseFont = false;
            this.xrTableCell36.StylePriority.UseTextAlignment = false;
            xrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell36.Summary = xrSummary13;
            this.xrTableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell36.TextFormatString = "{0:n2}";
            this.xrTableCell36.Weight = 0.36894090314883526D;
            // 
            // xrTableCell35
            // 
            this.xrTableCell35.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell35.Name = "xrTableCell35";
            this.xrTableCell35.StylePriority.UseFont = false;
            this.xrTableCell35.StylePriority.UseTextAlignment = false;
            this.xrTableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell35.Weight = 0.96530392070326965D;
            // 
            // pCarrier
            // 
            this.pCarrier.Description = "Carrier";
            this.pCarrier.Name = "pCarrier";
            this.pCarrier.ValueInfo = "ALL";
            this.pCarrier.Visible = false;
            // 
            // pNetwork
            // 
            this.pNetwork.Description = "Network";
            this.pNetwork.Name = "pNetwork";
            this.pNetwork.ValueInfo = "ALL";
            this.pNetwork.Visible = false;
            // 
            // pFltType
            // 
            this.pFltType.Description = "Flt Type";
            this.pFltType.Name = "pFltType";
            this.pFltType.ValueInfo = "ALL";
            this.pFltType.Visible = false;
            // 
            // pVersionID
            // 
            this.pVersionID.Name = "pVersionID";
            this.pVersionID.Type = typeof(long);
            this.pVersionID.ValueInfo = "17";
            this.pVersionID.Visible = false;
            // 
            // pCostType
            // 
            this.pCostType.Description = "Cost Type";
            this.pCostType.Name = "pCostType";
            this.pCostType.ValueInfo = "ALL";
            this.pCostType.Visible = false;
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1,
            this.ReportHeader1,
            this.ReportFooter1});
            this.DetailReport.DataMember = "Query";
            this.DetailReport.DataSource = this.sqlDataSource1;
            this.DetailReport.FilterString = "[NOT_PROFIT] = \'N\' Or [NOT_PROFIT] = \'Y\' And [DIFF] < 0.0m";
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail1.HeightF = 26.04167F;
            this.Detail1.Name = "Detail1";
            // 
            // ReportHeader1
            // 
            this.ReportHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.ReportHeader1.HeightF = 64.58334F;
            this.ReportHeader1.Name = "ReportHeader1";
            // 
            // ReportFooter1
            // 
            this.ReportFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
            this.ReportFooter1.HeightF = 53.74997F;
            this.ReportFooter1.Name = "ReportFooter1";
            // 
            // DetailReport1
            // 
            this.DetailReport1.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail2,
            this.ReportHeader2,
            this.ReportFooter2});
            this.DetailReport1.DataMember = "Query_1";
            this.DetailReport1.DataSource = this.sqlDataSource1;
            this.DetailReport1.Level = 1;
            this.DetailReport1.Name = "DetailReport1";
            // 
            // Detail2
            // 
            this.Detail2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4});
            this.Detail2.HeightF = 26.04167F;
            this.Detail2.Name = "Detail2";
            this.Detail2.StylePriority.UseTextAlignment = false;
            // 
            // xrTable4
            // 
            this.xrTable4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(3.814697E-05F, 0F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable4.SizeF = new System.Drawing.SizeF(784.167F, 25F);
            this.xrTable4.StylePriority.UseBorders = false;
            this.xrTable4.StylePriority.UsePadding = false;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell56,
            this.xrTableCell57,
            this.xrTableCell58,
            this.xrTableCell59,
            this.xrTableCell60,
            this.xrTableCell61,
            this.xrTableCell62,
            this.xrTableCell78});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell56
            // 
            this.xrTableCell56.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[VourcherNo]")});
            this.xrTableCell56.Name = "xrTableCell56";
            this.xrTableCell56.Weight = 1.5083318818544775D;
            // 
            // xrTableCell57
            // 
            this.xrTableCell57.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Date]")});
            this.xrTableCell57.Name = "xrTableCell57";
            this.xrTableCell57.TextFormatString = "{0:dd/MM/yyyy}";
            this.xrTableCell57.Weight = 1.0733335153340202D;
            // 
            // xrTableCell58
            // 
            this.xrTableCell58.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AreaCode]")});
            this.xrTableCell58.Name = "xrTableCell58";
            this.xrTableCell58.Weight = 0.60791651199118979D;
            // 
            // xrTableCell59
            // 
            this.xrTableCell59.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Carrier]")});
            this.xrTableCell59.Name = "xrTableCell59";
            this.xrTableCell59.Weight = 0.520833379875753D;
            // 
            // xrTableCell60
            // 
            this.xrTableCell60.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ApplyFromDate]")});
            this.xrTableCell60.Name = "xrTableCell60";
            this.xrTableCell60.TextFormatString = "{0:dd/MM/yyyy}";
            this.xrTableCell60.Weight = 1.1343764857967851D;
            // 
            // xrTableCell61
            // 
            this.xrTableCell61.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ApplyToDate]")});
            this.xrTableCell61.Name = "xrTableCell61";
            this.xrTableCell61.TextFormatString = "{0:dd/MM/yyyy}";
            this.xrTableCell61.Weight = 0.94687331019383991D;
            // 
            // xrTableCell62
            // 
            this.xrTableCell62.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount]")});
            this.xrTableCell62.Name = "xrTableCell62";
            this.xrTableCell62.StylePriority.UseTextAlignment = false;
            this.xrTableCell62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell62.TextFormatString = "{0:n2}";
            this.xrTableCell62.Weight = 1.0062499009673815D;
            // 
            // xrTableCell78
            // 
            this.xrTableCell78.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Discount]")});
            this.xrTableCell78.Name = "xrTableCell78";
            this.xrTableCell78.StylePriority.UseTextAlignment = false;
            this.xrTableCell78.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell78.TextFormatString = "{0:n2}";
            this.xrTableCell78.Weight = 1.0437535564797089D;
            // 
            // ReportHeader2
            // 
            this.ReportHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6,
            this.xrTable5,
            this.xrLabel5});
            this.ReportHeader2.HeightF = 111.2501F;
            this.ReportHeader2.Name = "ReportHeader2";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 35.24997F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(784.1659F, 23.00001F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "(Không phát sinh sản lượng trong kỳ Vourcher-Loại A/C XXX)";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTable5
            // 
            this.xrTable5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(6.103516E-05F, 84.16666F);
            this.xrTable5.Name = "xrTable5";
            this.xrTable5.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
            this.xrTable5.SizeF = new System.Drawing.SizeF(784.1669F, 25F);
            this.xrTable5.StylePriority.UseBorders = false;
            this.xrTable5.StylePriority.UseFont = false;
            this.xrTable5.StylePriority.UsePadding = false;
            this.xrTable5.StylePriority.UseTextAlignment = false;
            this.xrTable5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell63,
            this.xrTableCell64,
            this.xrTableCell65,
            this.xrTableCell66,
            this.xrTableCell67,
            this.xrTableCell68,
            this.xrTableCell69,
            this.xrTableCell77});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 1D;
            // 
            // xrTableCell63
            // 
            this.xrTableCell63.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell63.Name = "xrTableCell63";
            this.xrTableCell63.StylePriority.UseFont = false;
            this.xrTableCell63.StylePriority.UseTextAlignment = false;
            this.xrTableCell63.Text = "Vourcher No.";
            this.xrTableCell63.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell63.Weight = 1.5083318818544775D;
            // 
            // xrTableCell64
            // 
            this.xrTableCell64.Name = "xrTableCell64";
            this.xrTableCell64.Text = "Vourcher Date";
            this.xrTableCell64.Weight = 1.0733325998068484D;
            // 
            // xrTableCell65
            // 
            this.xrTableCell65.Name = "xrTableCell65";
            this.xrTableCell65.Text = "Area Code";
            this.xrTableCell65.Weight = 0.607917427518362D;
            // 
            // xrTableCell66
            // 
            this.xrTableCell66.Name = "xrTableCell66";
            this.xrTableCell66.Text = "Opt";
            this.xrTableCell66.Weight = 0.52083307470000206D;
            // 
            // xrTableCell67
            // 
            this.xrTableCell67.Name = "xrTableCell67";
            this.xrTableCell67.Text = "Apply From Date";
            this.xrTableCell67.Weight = 1.1343764857967851D;
            // 
            // xrTableCell68
            // 
            this.xrTableCell68.Name = "xrTableCell68";
            this.xrTableCell68.Text = "Apply To Date";
            this.xrTableCell68.Weight = 0.94687331019383991D;
            // 
            // xrTableCell69
            // 
            this.xrTableCell69.Name = "xrTableCell69";
            this.xrTableCell69.Text = "Revenue";
            this.xrTableCell69.Weight = 1.0062502061431327D;
            // 
            // xrTableCell77
            // 
            this.xrTableCell77.Name = "xrTableCell77";
            this.xrTableCell77.Text = "Discount";
            this.xrTableCell77.Weight = 1.043753252770532D;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 12.25001F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(784.1659F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "DOANH THU KHÔNG THEO CHUYẾN BAY KHÔNG PHÂN BỔ";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // ReportFooter2
            // 
            this.ReportFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable6});
            this.ReportFooter2.HeightF = 43.12503F;
            this.ReportFooter2.Name = "ReportFooter2";
            // 
            // xrTable6
            // 
            this.xrTable6.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(6.103516E-05F, 0F);
            this.xrTable6.Name = "xrTable6";
            this.xrTable6.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
            this.xrTable6.SizeF = new System.Drawing.SizeF(784.167F, 25F);
            this.xrTable6.StylePriority.UseBorders = false;
            this.xrTable6.StylePriority.UseFont = false;
            this.xrTable6.StylePriority.UsePadding = false;
            this.xrTable6.StylePriority.UseTextAlignment = false;
            this.xrTable6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell70,
            this.xrTableCell76,
            this.xrTableCell79});
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Weight = 1D;
            // 
            // xrTableCell70
            // 
            this.xrTableCell70.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell70.Name = "xrTableCell70";
            this.xrTableCell70.StylePriority.UseFont = false;
            this.xrTableCell70.StylePriority.UseTextAlignment = false;
            this.xrTableCell70.Text = "Total";
            this.xrTableCell70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell70.Weight = 5.7916595504634447D;
            // 
            // xrTableCell76
            // 
            this.xrTableCell76.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([Amount])")});
            this.xrTableCell76.Name = "xrTableCell76";
            this.xrTableCell76.StylePriority.UseTextAlignment = false;
            xrSummary14.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell76.Summary = xrSummary14;
            this.xrTableCell76.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell76.TextFormatString = "{0:n2}";
            this.xrTableCell76.Weight = 1.0062541281696762D;
            // 
            // xrTableCell79
            // 
            this.xrTableCell79.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([Discount])")});
            this.xrTableCell79.Name = "xrTableCell79";
            this.xrTableCell79.StylePriority.UseTextAlignment = false;
            xrSummary15.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell79.Summary = xrSummary15;
            this.xrTableCell79.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell79.TextFormatString = "{0:n2}";
            this.xrTableCell79.Weight = 1.04375350472233D;
            // 
            // DetailReport2
            // 
            this.DetailReport2.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail3,
            this.ReportHeader3,
            this.ReportFooter3});
            this.DetailReport2.DataMember = "Query_2";
            this.DetailReport2.DataSource = this.sqlDataSource1;
            this.DetailReport2.Level = 2;
            this.DetailReport2.Name = "DetailReport2";
            // 
            // Detail3
            // 
            this.Detail3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable7});
            this.Detail3.HeightF = 25F;
            this.Detail3.Name = "Detail3";
            // 
            // xrTable7
            // 
            this.xrTable7.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable7.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 0F);
            this.xrTable7.Name = "xrTable7";
            this.xrTable7.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable7.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
            this.xrTable7.SizeF = new System.Drawing.SizeF(784.1659F, 25F);
            this.xrTable7.StylePriority.UseBorders = false;
            this.xrTable7.StylePriority.UsePadding = false;
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell80,
            this.xrTableCell92,
            this.xrTableCell81,
            this.xrTableCell82,
            this.xrTableCell89});
            this.xrTableRow7.Name = "xrTableRow7";
            this.xrTableRow7.Weight = 1D;
            // 
            // xrTableCell80
            // 
            this.xrTableCell80.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell80.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Description]")});
            this.xrTableCell80.Name = "xrTableCell80";
            this.xrTableCell80.StylePriority.UseBorders = false;
            this.xrTableCell80.Weight = 0.98767151626130034D;
            // 
            // xrTableCell92
            // 
            this.xrTableCell92.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Airport]")});
            this.xrTableCell92.Name = "xrTableCell92";
            this.xrTableCell92.StylePriority.UseTextAlignment = false;
            this.xrTableCell92.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell92.Weight = 0.23257216649943163D;
            // 
            // xrTableCell81
            // 
            this.xrTableCell81.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[RevCostMonth]")});
            this.xrTableCell81.Name = "xrTableCell81";
            this.xrTableCell81.StylePriority.UseTextAlignment = false;
            this.xrTableCell81.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell81.TextFormatString = "{0:#,#}";
            this.xrTableCell81.Weight = 0.19925617176680077D;
            // 
            // xrTableCell82
            // 
            this.xrTableCell82.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount]")});
            this.xrTableCell82.Name = "xrTableCell82";
            this.xrTableCell82.StylePriority.UseTextAlignment = false;
            this.xrTableCell82.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell82.TextFormatString = "{0:n2}";
            this.xrTableCell82.Weight = 0.4339804944693999D;
            // 
            // xrTableCell89
            // 
            this.xrTableCell89.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ErrMsg]")});
            this.xrTableCell89.Name = "xrTableCell89";
            this.xrTableCell89.StylePriority.UseTextAlignment = false;
            this.xrTableCell89.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell89.Weight = 1.1465152418751066D;
            // 
            // ReportHeader3
            // 
            this.ReportHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable8,
            this.xrLabel7,
            this.xrLabel8});
            this.ReportHeader3.HeightF = 104.1667F;
            this.ReportHeader3.Name = "ReportHeader3";
            // 
            // xrTable8
            // 
            this.xrTable8.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 79.16666F);
            this.xrTable8.Name = "xrTable8";
            this.xrTable8.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8});
            this.xrTable8.SizeF = new System.Drawing.SizeF(784.1671F, 25F);
            this.xrTable8.StylePriority.UseBorders = false;
            this.xrTable8.StylePriority.UseFont = false;
            this.xrTable8.StylePriority.UsePadding = false;
            this.xrTable8.StylePriority.UseTextAlignment = false;
            this.xrTable8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow8
            // 
            this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell83,
            this.xrTableCell91,
            this.xrTableCell84,
            this.xrTableCell85,
            this.xrTableCell87});
            this.xrTableRow8.Name = "xrTableRow8";
            this.xrTableRow8.Weight = 1D;
            // 
            // xrTableCell83
            // 
            this.xrTableCell83.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell83.Name = "xrTableCell83";
            this.xrTableCell83.StylePriority.UseBorders = false;
            this.xrTableCell83.Text = "Description";
            this.xrTableCell83.Weight = 0.9876721000191564D;
            // 
            // xrTableCell91
            // 
            this.xrTableCell91.Name = "xrTableCell91";
            this.xrTableCell91.StylePriority.UseTextAlignment = false;
            this.xrTableCell91.Text = "Area";
            this.xrTableCell91.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell91.Weight = 0.23257134923843614D;
            // 
            // xrTableCell84
            // 
            this.xrTableCell84.Name = "xrTableCell84";
            this.xrTableCell84.StylePriority.UseTextAlignment = false;
            this.xrTableCell84.Text = "Month";
            this.xrTableCell84.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell84.Weight = 0.19925640526994026D;
            // 
            // xrTableCell85
            // 
            this.xrTableCell85.Name = "xrTableCell85";
            this.xrTableCell85.StylePriority.UseTextAlignment = false;
            this.xrTableCell85.Text = "Amount";
            this.xrTableCell85.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell85.Weight = 0.4339804944693999D;
            // 
            // xrTableCell87
            // 
            this.xrTableCell87.Name = "xrTableCell87";
            this.xrTableCell87.StylePriority.UseTextAlignment = false;
            this.xrTableCell87.Text = "Message";
            this.xrTableCell87.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell87.Weight = 1.1465199119381193D;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 9.999974F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(784.1659F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "CHI PHÍ TRONG KỲ KHÔNG PHÂN BỔ";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 32.99993F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(784.1659F, 23.00001F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "(Lỗi hoặc không phát sinh sản lượng trong kỳ phân bổ)";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // ReportFooter3
            // 
            this.ReportFooter3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable9});
            this.ReportFooter3.HeightF = 47.91667F;
            this.ReportFooter3.Name = "ReportFooter3";
            // 
            // xrTable9
            // 
            this.xrTable9.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable9.Name = "xrTable9";
            this.xrTable9.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable9.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow9});
            this.xrTable9.SizeF = new System.Drawing.SizeF(784.1659F, 25F);
            this.xrTable9.StylePriority.UseBorders = false;
            this.xrTable9.StylePriority.UsePadding = false;
            // 
            // xrTableRow9
            // 
            this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell86,
            this.xrTableCell88,
            this.xrTableCell90});
            this.xrTableRow9.Name = "xrTableRow9";
            this.xrTableRow9.Weight = 1D;
            // 
            // xrTableCell86
            // 
            this.xrTableCell86.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell86.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell86.Name = "xrTableCell86";
            this.xrTableCell86.StylePriority.UseBorders = false;
            this.xrTableCell86.StylePriority.UseFont = false;
            this.xrTableCell86.StylePriority.UseTextAlignment = false;
            this.xrTableCell86.Text = "Total";
            this.xrTableCell86.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell86.Weight = 1.2202439110451409D;
            // 
            // xrTableCell88
            // 
            this.xrTableCell88.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([Amount])")});
            this.xrTableCell88.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell88.Name = "xrTableCell88";
            this.xrTableCell88.StylePriority.UseFont = false;
            this.xrTableCell88.StylePriority.UseTextAlignment = false;
            xrSummary16.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell88.Summary = xrSummary16;
            this.xrTableCell88.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell88.TextFormatString = "{0:n2}";
            this.xrTableCell88.Weight = 0.63323667816012108D;
            // 
            // xrTableCell90
            // 
            this.xrTableCell90.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell90.Name = "xrTableCell90";
            this.xrTableCell90.StylePriority.UseFont = false;
            this.xrTableCell90.StylePriority.UseTextAlignment = false;
            this.xrTableCell90.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell90.Weight = 1.1465154156249642D;
            // 
            // pNotProfitable
            // 
            this.pNotProfitable.Name = "pNotProfitable";
            this.pNotProfitable.ValueInfo = "N";
            this.pNotProfitable.Visible = false;
            // 
            // DIFF
            // 
            this.DIFF.DataMember = "Query";
            this.DIFF.DataSource = this.sqlDataSource1;
            this.DIFF.Expression = "Iif(IsNull([TOTAL_REV]), 0, [TOTAL_REV])-Iif(IsNull([TOTAL_COST]), 0, [TOTAL_COST" +
    "])";
            this.DIFF.FieldType = DevExpress.XtraReports.UI.FieldType.Decimal;
            this.DIFF.Name = "DIFF";
            // 
            // NOT_PROFIT
            // 
            this.NOT_PROFIT.DataMember = "Query";
            this.NOT_PROFIT.DataSource = this.sqlDataSource1;
            this.NOT_PROFIT.Expression = "[Parameters].[pNotProfitable]";
            this.NOT_PROFIT.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.NOT_PROFIT.Name = "NOT_PROFIT";
            // 
            // SLDoanhthuChiphiChuyenbay
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter,
            this.DetailReport,
            this.DetailReport1,
            this.DetailReport2});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.DIFF,
            this.NOT_PROFIT});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 12, 0, 12);
            this.PageHeight = 1654;
            this.PageWidth = 2339;
            this.PaperKind = System.Drawing.Printing.PaperKind.A2;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.pFromDate,
            this.pToDate,
            this.pAreaCode,
            this.pDateStr,
            this.pCarrier,
            this.pNetwork,
            this.pFltType,
            this.pVersionID,
            this.pCostType,
            this.pNotProfitable});
            this.Version = "17.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).EndInit();
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
}
