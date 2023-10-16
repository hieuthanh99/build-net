using DevExpress.Web;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Business_KTQT_VMSExternalRev : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        SetPermistion();
        if (!IsPostBack)
        {
            this.QueryYearEditor.Value = DateTime.Now.Year;

            this.FromMonthEditor.Value = DateUtils.FirstDayOfMonth(true).Month;
            this.ToMonthEditor.Value = DateUtils.FirstDayOfMonth(true).Month;
        }

        LoadDTNCBData();
    }
    private void SetPermistion()
    {
        if (!(SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR)))
        {
            btnSyncDTNCB.Visible = (SessionUser.IsInRole(PermissionConstant.SYNC_FAST_DATA));
            cboArea.Enabled = false;
        }
        else
        {
            btnSyncDTNCB.Visible = true;
            cboArea.Enabled = true;
        }
    }
    #region Load data

    private void LoadDTNCBData()
    {
        var year = this.QueryYearEditor.Number;
        var areaCode = cboArea.Value.ToString();

        var list = entities.Basic_External_Rev.Where(x => x.ForYear == year && (x.AreaCode == areaCode || areaCode == "ALL")).ToList();
        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }


    private void LoadActualVersion()
    {
        var year = this.QueryYearEditor.Number;
        var list = entities.Versions.Where(x => x.Status != "APPROVED" && x.Active == true && x.VersionYear == year).OrderByDescending(x => x.VersionYear).OrderBy(x => x.Sorting).ToList();
        this.VersionGrid.DataSource = list;
        this.VersionGrid.DataBind();
    }

    #endregion
    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        if (args[0] == "LoadData")
        {
            LoadDTNCBData();
        }

        if (args[0] == "SyncDTNCBData")
        {
            var year = Convert.ToInt32(this.QueryYearEditor.Number);
            string areaCode = cboArea.Value.ToString();


            entities.Sync_KH_DoanhThuNgoaiCoBan(year);

            LoadDTNCBData();
        }

        if (args[0] == "ApplyToVersion")
        {
            decimal versionID;

            if (!decimal.TryParse(args[1], out versionID))
                return;

            var version = entities.Versions.SingleOrDefault(x => x.VersionID == versionID);
            if (version != null)
            {
                var fromMonth = Convert.ToInt32(this.FromMonthEditor.Number);
                var toMonth = Convert.ToInt32(this.ToMonthEditor.Number);

                string areaCode = cboArea.Value.ToString();

                var year = version.VersionYear;

                if (areaCode.Equals("ALL"))
                {
                    var list = entities.Airports.ToList();
                    foreach (var item in list)
                    {
                        entities.ApplyExtRevToVersion(versionID, fromMonth, toMonth, year, item.Code);
                    }
                }
                else
                {
                    entities.ApplyExtRevToVersion(versionID, fromMonth, toMonth, year, areaCode);
                }
            }

        }


        if (args[0] == "ExportTemplate")
        {
            ExportTemplate();
        }

    }

    private void ExportTemplate()
    {

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExporter.FileName = "GLBudgetReport.xlsx";
        DevExpress.XtraPrinting.XlsxExportOptionsEx options = new DevExpress.XtraPrinting.XlsxExportOptionsEx() { ExportType = DevExpress.Export.ExportType.WYSIWYG };
        options.SheetName = "GLBudgetReport";
        GridViewExporter.WriteXlsxToResponse(options);

    }
    protected void AirportsEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Airports.Where(x => (x.VNDes ?? false) == true).ToList();
        ListEditItem le = new ListEditItem();
        le.Value = "ALL";
        le.Text = "--ALL--";
        s.Items.Add(le);
        foreach (var item in list)
        {
            le = new ListEditItem();
            le.Value = item.Code == "CTY" ? "KCQ" : item.Code;
            le.Text = item.NameE;
            s.Items.Add(le);
        }
        if (s.Items.Count > 0)
        {
            var curCompany = entities.DecCompanies.SingleOrDefault(x => x.CompanyID == SessionUser.CompanyID);
            if (curCompany != null)
                s.Value = curCompany.AreaCode == "CTY" ? "KCQ" : curCompany.AreaCode;
        }
    }
    protected void VersionGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        if (args[0] == "LoadVersion")
        {
            LoadActualVersion();
        }

    }

    protected void cboArea1_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Airports.Where(x => (x.VNDes ?? false) == true).ToList();
        ListEditItem le = new ListEditItem();
        foreach (var item in list)
        {
            le = new ListEditItem();
            le.Value = item.Code;
            le.Text = item.NameE;
            s.Items.Add(le);
        }
        if (s.Items.Count > 0)
        {
            var curCompany = entities.DecCompanies.SingleOrDefault(x => x.CompanyID == SessionUser.CompanyID);
            if (curCompany != null)
                s.Value = curCompany.AreaCode;
        }
    }
}