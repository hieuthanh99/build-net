using DevExpress.Web;
using KTQTData;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Business_RevenueCost_ActualQuantity : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.btnSyncData.Visible = IsGranted("Pages.KHTC.Business.RevenueCost.ActualQuantity.SyncData");
        //SetPermistion();
        if (!IsPostBack)
        {
            //this.FromDateEditor.Date = DateUtils.FirstDayOfMonth(true).AddMonths(-3);
            //this.ToDateEditor.Date = DateUtils.LastDayOfMonth(true).AddMonths(-3);

            this.MonthEditor.Value = DateTime.Now.Month;
            this.YearEditor.Value = DateTime.Now.Year;
            this.FilterYearEditor.Value = DateTime.Now.Year;
            //this.SyncDataListBox.SelectAll();

            LoadVersion();
        }
        //if (!IsPostBack || this.FltOpsGrid.IsCallback)
        //{
        LoadFltOps();
    }
    //private void SetPermistion()
    //{
    //    if (!(SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR)))
    //    {
    //        btnSyncVMS.Visible = (SessionUser.IsInRole(PermissionConstant.SYNC_VMS_DATA));
    //    }
    //    else
    //        btnSyncVMS.Visible = true;
    //}

    #region Load data

    private void LoadFltOps()
    {
        //var fromDate = this.FromDateEditor.Date;
        //var toDate = this.ToDateEditor.Date;
        var airport = this.VersionEditor.Value != null ? Convert.ToDecimal(this.VersionEditor.Value) : 0;

        var list = entities.V_FLT_OPS_ALL.Where(x => x.VersionID == airport)
            .OrderBy(x => x.FltDate)
            .ToList();
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
        if (args[0].Equals(Action.SYNC_DATA))
        {
            var versionID = this.VersionEditor.Value != null ? Convert.ToDecimal(this.VersionEditor.Value) : 0;

            if (versionID != decimal.Zero)
            {
                var version = entities.Versions.Where(x => x.VersionID == versionID).FirstOrDefault();
                if (version == null) return;

                if (!version.OriID.HasValue) return;

                entities.Sync_1VersionFlsOps(Convert.ToDouble(version.OriID.Value));

                LoadFltOps();
            }
        }

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExporter.FileName = "Quantity.xlsx";
        DevExpress.XtraPrinting.XlsxExportOptionsEx options = new DevExpress.XtraPrinting.XlsxExportOptionsEx() { ExportType = DevExpress.Export.ExportType.WYSIWYG };
        options.SheetName = "Quantity";
        GridViewExporter.WriteXlsxToResponse(options);
    }
    protected void VersionEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Versions.Where(x => x.Active == true).ToList();
        s.DataSource = list;
        s.ValueField = "VersionID";
        s.TextField = "Description";
        s.DataBind();
        if (s.Items.Count > 0)
            s.Value = s.Items[0].Value;
    }

    protected void VersionEditor_Callback(object sender, CallbackEventArgsBase e)
    {
        LoadVersion();
    }

    private void LoadVersion()
    {
        var versionYear = Convert.ToInt32(FilterYearEditor.Number);
        var list = entities.Versions.Where(x => x.VersionYear == versionYear && x.Active == true).ToList();
        VersionEditor.DataSource = list;
        VersionEditor.ValueField = "VersionID";
        VersionEditor.TextField = "Description";
        VersionEditor.DataBind();
        if (VersionEditor.Items.Count > 0)
            VersionEditor.Value = VersionEditor.Items[0].Value;
    }
}