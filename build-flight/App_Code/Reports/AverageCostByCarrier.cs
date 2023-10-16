using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using KTQTData;
using System.Linq;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraReports.UI.PivotGrid;

/// <summary>
/// Summary description for ChiphiBinhquan
/// </summary>
public class AverageCostByCarrier : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field5;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field4;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field3;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field2;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field;
    private XRLabel xrLabel1;
    private DevExpress.XtraReports.Parameters.Parameter pAreaCode;
    private DevExpress.XtraReports.Parameters.Parameter pFromDate;
    private DevExpress.XtraReports.Parameters.Parameter pToDate;
    private DevExpress.XtraReports.Parameters.Parameter pDateStr;
    private XRLabel xrLabel2;
    private XRPivotGrid xrPivotGrid1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldSubaccountID1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldSeq1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldSorting1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldDescription1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCARRIER1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldACGroup1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldNetwork1;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCost1;
    private DevExpress.XtraReports.Parameters.Parameter pCarrier;
    private DevExpress.XtraReports.Parameters.Parameter pNetwork;
    private DevExpress.XtraReports.Parameters.Parameter pFltType;
    private DevExpress.XtraReports.Parameters.Parameter pVersionID;
    private DevExpress.XtraReports.Parameters.Parameter pCostType;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField xrPivotGridField2;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldFASTCode;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldFeeCode;
    private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCalculation;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public AverageCostByCarrier()
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
            string resourceFileName = "AverageCostByCarrier.resx";
            System.Resources.ResourceManager resources = global::Resources.AverageCostByCarrier.ResourceManager;
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
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.fieldSubaccountID1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldSeq1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldSorting1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldDescription1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldCalculation = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldFASTCode = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldFeeCode = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldCARRIER1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldACGroup1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldNetwork1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldCost1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.field5 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.field4 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.field3 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.field2 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.field1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.field = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pAreaCode = new DevExpress.XtraReports.Parameters.Parameter();
            this.pFromDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.pToDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.pDateStr = new DevExpress.XtraReports.Parameters.Parameter();
            this.pCarrier = new DevExpress.XtraReports.Parameters.Parameter();
            this.pNetwork = new DevExpress.XtraReports.Parameters.Parameter();
            this.pFltType = new DevExpress.XtraReports.Parameters.Parameter();
            this.pVersionID = new DevExpress.XtraReports.Parameters.Parameter();
            this.pCostType = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrPivotGridField2 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
            this.Detail.HeightF = 125.4167F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPivotGrid1
            // 
            this.xrPivotGrid1.Appearance.Cell.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.xrPivotGrid1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Tahoma", 6.6F);
            this.xrPivotGrid1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 6.6F, System.Drawing.FontStyle.Bold);
            this.xrPivotGrid1.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrPivotGrid1.Appearance.FieldValue.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.xrPivotGrid1.Appearance.FieldValue.WordWrap = true;
            this.xrPivotGrid1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 6.6F);
            this.xrPivotGrid1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 6.6F);
            this.xrPivotGrid1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 6.6F);
            this.xrPivotGrid1.Appearance.Lines.Font = new System.Drawing.Font("Tahoma", 6.6F);
            this.xrPivotGrid1.Appearance.Lines.WordWrap = true;
            this.xrPivotGrid1.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 6.6F);
            this.xrPivotGrid1.DataMember = "Query";
            this.xrPivotGrid1.DataSource = this.sqlDataSource1;
            this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.fieldSubaccountID1,
            this.fieldSeq1,
            this.fieldSorting1,
            this.fieldDescription1,
            this.fieldCalculation,
            this.fieldFASTCode,
            this.fieldFeeCode,
            this.fieldCARRIER1,
            this.fieldACGroup1,
            this.fieldNetwork1,
            this.fieldCost1});
            this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPivotGrid1.Name = "xrPivotGrid1";
            this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
            this.xrPivotGrid1.OptionsView.ShowColumnGrandTotals = false;
            this.xrPivotGrid1.OptionsView.ShowColumnHeaders = false;
            this.xrPivotGrid1.OptionsView.ShowColumnTotals = false;
            this.xrPivotGrid1.OptionsView.ShowDataHeaders = false;
            this.xrPivotGrid1.OptionsView.ShowFilterHeaders = false;
            this.xrPivotGrid1.OptionsView.ShowRowGrandTotals = false;
            this.xrPivotGrid1.OptionsView.ShowRowTotals = false;
            this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(800.9999F, 125.4167F);
            this.xrPivotGrid1.CustomCellDisplayText += new System.EventHandler<DevExpress.XtraReports.UI.PivotGrid.PivotCellDisplayTextEventArgs>(this.xrPivotGrid1_CustomCellDisplayText);
            this.xrPivotGrid1.PrintCell += new System.EventHandler<DevExpress.XtraReports.UI.PivotGrid.CustomExportCellEventArgs>(this.xrPivotGrid1_PrintCell);
            this.xrPivotGrid1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrPivotGrid1_BeforePrint);
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "KTQT_Data_Connection";
            this.sqlDataSource1.ConnectionOptions.DbCommandTimeout = 0;
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "Query";
            queryParameter1.Name = "@pVersionID";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.pVersionID]", typeof(long));
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
            storedProcQuery1.StoredProcName = "AverageCostByCarrier";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // fieldSubaccountID1
            // 
            this.fieldSubaccountID1.AreaIndex = 0;
            this.fieldSubaccountID1.FieldName = "SubaccountID";
            this.fieldSubaccountID1.Name = "fieldSubaccountID1";
            // 
            // fieldSeq1
            // 
            this.fieldSeq1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldSeq1.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldSeq1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldSeq1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldSeq1.AreaIndex = 0;
            this.fieldSeq1.FieldName = "Seq";
            this.fieldSeq1.Name = "fieldSeq1";
            // 
            // fieldSorting1
            // 
            this.fieldSorting1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldSorting1.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldSorting1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldSorting1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldSorting1.AreaIndex = 1;
            this.fieldSorting1.FieldName = "Sorting";
            this.fieldSorting1.Name = "fieldSorting1";
            // 
            // fieldDescription1
            // 
            this.fieldDescription1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldDescription1.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldDescription1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldDescription1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldDescription1.AreaIndex = 2;
            this.fieldDescription1.FieldName = "Description";
            this.fieldDescription1.Name = "fieldDescription1";
            this.fieldDescription1.Width = 280;
            // 
            // fieldCalculation
            // 
            this.fieldCalculation.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCalculation.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCalculation.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCalculation.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldCalculation.AreaIndex = 3;
            this.fieldCalculation.Caption = "Calc.";
            this.fieldCalculation.FieldName = "Calculation";
            this.fieldCalculation.Name = "fieldCalculation";
            // 
            // fieldFASTCode
            // 
            this.fieldFASTCode.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldFASTCode.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldFASTCode.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldFASTCode.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldFASTCode.AreaIndex = 4;
            this.fieldFASTCode.FieldName = "FASTCode";
            this.fieldFASTCode.Name = "fieldFASTCode";
            // 
            // fieldFeeCode
            // 
            this.fieldFeeCode.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldFeeCode.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldFeeCode.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldFeeCode.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldFeeCode.AreaIndex = 5;
            this.fieldFeeCode.FieldName = "FeeCode";
            this.fieldFeeCode.Name = "fieldFeeCode";
            // 
            // fieldCARRIER1
            // 
            this.fieldCARRIER1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCARRIER1.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCARRIER1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldCARRIER1.AreaIndex = 0;
            this.fieldCARRIER1.FieldName = "CARRIER";
            this.fieldCARRIER1.Name = "fieldCARRIER1";
            // 
            // fieldACGroup1
            // 
            this.fieldACGroup1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldACGroup1.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldACGroup1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldACGroup1.AreaIndex = 1;
            this.fieldACGroup1.FieldName = "AC_Group";
            this.fieldACGroup1.Name = "fieldACGroup1";
            // 
            // fieldNetwork1
            // 
            this.fieldNetwork1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldNetwork1.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldNetwork1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldNetwork1.AreaIndex = 2;
            this.fieldNetwork1.FieldName = "Network";
            this.fieldNetwork1.Name = "fieldNetwork1";
            // 
            // fieldCost1
            // 
            this.fieldCost1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCost1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCost1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCost1.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fieldCost1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldCost1.AreaIndex = 0;
            this.fieldCost1.CellFormat.FormatString = "{0:n2}";
            this.fieldCost1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldCost1.FieldName = "Cost";
            this.fieldCost1.Name = "fieldCost1";
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrLabel4,
            this.xrLabel2,
            this.xrLabel1});
            this.TopMargin.HeightF = 146.4583F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 95.33332F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(800.9999F, 22.99999F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 72.33331F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(800.9999F, 23.00001F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters].[pDateStr]")});
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 118.3333F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(800.9999F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 39.33333F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(800.9999F, 32.99999F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "CHI PHÍ BÌNH QUÂN CỦA MỘT LOẠI MÁY BAY";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 45F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // field5
            // 
            this.field5.AreaIndex = 5;
            this.field5.Name = "field5";
            // 
            // field4
            // 
            this.field4.Appearance.FieldHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.field4.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.field4.AreaIndex = 4;
            this.field4.Name = "field4";
            this.field4.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.True;
            // 
            // field3
            // 
            this.field3.Appearance.FieldValue.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold);
            this.field3.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.field3.AreaIndex = 3;
            this.field3.Name = "field3";
            // 
            // field2
            // 
            this.field2.Appearance.FieldValue.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.field2.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.field2.AreaIndex = 2;
            this.field2.Name = "field2";
            // 
            // field1
            // 
            this.field1.Appearance.FieldValue.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.field1.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.field1.AreaIndex = 1;
            this.field1.Name = "field1";
            // 
            // field
            // 
            this.field.Appearance.FieldValue.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.field.AreaIndex = 0;
            this.field.Name = "field";
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
            this.pFromDate.ValueInfo = "2018-09-01";
            this.pFromDate.Visible = false;
            // 
            // pToDate
            // 
            this.pToDate.Name = "pToDate";
            this.pToDate.Type = typeof(System.DateTime);
            this.pToDate.ValueInfo = "2018-09-01";
            this.pToDate.Visible = false;
            // 
            // pDateStr
            // 
            this.pDateStr.Name = "pDateStr";
            this.pDateStr.Visible = false;
            // 
            // pCarrier
            // 
            this.pCarrier.Description = "Carrier";
            this.pCarrier.Name = "pCarrier";
            this.pCarrier.ValueInfo = "VN";
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
            this.pVersionID.ValueInfo = "2";
            this.pVersionID.Visible = false;
            // 
            // pCostType
            // 
            this.pCostType.Name = "pCostType";
            this.pCostType.ValueInfo = "ALL";
            this.pCostType.Visible = false;
            // 
            // xrPivotGridField2
            // 
            this.xrPivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.xrPivotGridField2.AreaIndex = 3;
            this.xrPivotGridField2.Name = "xrPivotGridField2";
            // 
            // AverageCostByCarrier
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.Margins = new System.Drawing.Printing.Margins(27, 22, 146, 45);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.pAreaCode,
            this.pFromDate,
            this.pToDate,
            this.pDateStr,
            this.pCarrier,
            this.pNetwork,
            this.pFltType,
            this.pVersionID,
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
        this.xrPivotGrid1.BestFit(fieldSeq1);
        this.xrPivotGrid1.BestFit(fieldSorting1);
        //this.xrPivotGrid1.BestFit(fieldDescription1);
        this.xrPivotGrid1.BestFit(fieldCARRIER1);
        this.xrPivotGrid1.BestFit(fieldACGroup1);
        this.xrPivotGrid1.BestFit(fieldNetwork1);
        this.xrPivotGrid1.BestFit(fieldCost1);
        this.xrPivotGrid1.BestFit(fieldFASTCode);
        this.xrPivotGrid1.BestFit(fieldCalculation);
        this.xrPivotGrid1.BestFit(fieldFeeCode);

    }

    private void xrPivotGrid1_CustomCellDisplayText(object sender, DevExpress.XtraReports.UI.PivotGrid.PivotCellDisplayTextEventArgs e)
    {
        if (e.ColumnField == fieldNetwork1)
        {
            if (e.Value != null && (decimal)e.Value == decimal.Zero)
                e.DisplayText = null;
        }
    }

    private void xrPivotGrid1_PrintCell(object sender, DevExpress.XtraReports.UI.PivotGrid.CustomExportCellEventArgs e)
    {
        XRPivotGrid grid = sender as XRPivotGrid;        
        if (e.DataField.Area != DevExpress.XtraPivotGrid.PivotArea.FilterArea)
        {
            PivotDrillDownDataSource drillDownSource = (grid as IPivotGridDataContainer).Data.CreateDrillDownDataSource(e.ColumnIndex, e.RowIndex);

            bool isSumField = Object.Equals(drillDownSource[0]["Calculation"], "SUM");

            if (isSumField)
                e.Appearance.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            
        }
    }


 
   
}
