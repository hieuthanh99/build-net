using DevExpress.Web;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Business_KTQT_PlanQuantity : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
            this.FromDateEditor.Date = DateUtils.FirstDayOfMonth(true).AddMonths(-3);
            this.ToDateEditor.Date = DateUtils.LastDayOfMonth(true).AddMonths(-3);

            this.MonthEditor.Value = DateTime.Now.Month;
            this.YearEditor.Value = DateTime.Now.Year;

            //this.SyncDataListBox.SelectAll();
        }
        //if (!IsPostBack || this.FltOpsGrid.IsCallback)
        //{
        LoadFltOps();
        //}
    }

   

    #region Load data

    private void LoadFltOps()
    {
        var fromDate = this.FromDateEditor.Date;
        var toDate = this.ToDateEditor.Date;
        var airport = this.AirportsEditor.Value != null ? this.AirportsEditor.Value.ToString() : string.Empty;

        var list = entities.V_PLAN_FLT_OPS.Where(x => x.Flt_Date >= fromDate && x.Flt_Date <= toDate && x.Area == airport).OrderBy(x => x.Flt_Date).ToList();
        this.FltOpsGrid.DataSource = list;
        this.FltOpsGrid.DataBind();
    }

    #endregion
    protected void FltOpsGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        if (args[0] == "LoadData")
        {
            LoadFltOps();
        }
           
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExporter.FileName = "PlanQuantity.xlsx";
        DevExpress.XtraPrinting.XlsxExportOptionsEx options = new DevExpress.XtraPrinting.XlsxExportOptionsEx() { ExportType = DevExpress.Export.ExportType.WYSIWYG };
        GridViewExporter.WriteXlsxToResponse(options);
    }
    protected void AirportsEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Airports.Where(x => (x.IsCity ?? false) == true).ToList();
        s.DataSource = list;
        s.ValueField = "Code";
        s.TextField = "NameE";
        s.DataBind();
        if (s.Items.Count > 0)
            s.Value = "SGN";
    }
}