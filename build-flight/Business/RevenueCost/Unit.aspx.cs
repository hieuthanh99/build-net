using DevExpress.Web;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Business_RevenueCost_Unit : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.UnitGrid.SettingsDataSecurity.AllowInsert = IsGranted("Pages.KHTC.Business.RevenueCost.Unit.Create");
        this.UnitGrid.SettingsDataSecurity.AllowEdit = IsGranted("Pages.KHTC.Business.RevenueCost.Unit.Edit");
        this.UnitGrid.SettingsDataSecurity.AllowDelete = false;
        this.btnSyncData.Visible = IsGranted("Pages.KHTC.Business.RevenueCost.Unit.SyncData");

        if (!IsPostBack)
        {
            this.FilterYearEditor.Value = DateTime.Now.Year;
            LoadVersion();
        }
        LoadCompanyID(this.UnitGrid);
        LoadSubaccountID(this.UnitGrid);
        LoadUnits();
    }


    #region Load data

    private void LoadUnits()
    {

        var versionID = this.VersionEditor.Value != null ? Convert.ToDecimal(this.VersionEditor.Value) : 0;

        var list = entities.Units.Where(x => x.VersionID == versionID)
            .OrderBy(x => x.Item).ThenBy(x => x.UnitID)
            .ToList();
        this.UnitGrid.DataSource = list;
        this.UnitGrid.DataBind();
    }

    private void LoadCompanyID(ASPxGridView Grid)
    {
        GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)Grid.Columns["CompanyID"];


        var list = entities.DecCompanies.Where(x => x.CompanyType == "D").OrderBy(x => x.Seq).ToList();
        aCombo.PropertiesComboBox.DataSource = list;
        aCombo.PropertiesComboBox.ValueField = "CompanyID";
        aCombo.PropertiesComboBox.TextField = "NameV";
    }

    private void LoadSubaccountID(ASPxGridView Grid)
    {
        GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)Grid.Columns["SubaccountID"];


        var list = entities.DecSubaccounts.Where(x => x.Calculation != "SUM").OrderBy(x => x.Seq).ToList();
        aCombo.PropertiesComboBox.DataSource = list;
        aCombo.PropertiesComboBox.ValueField = "SubaccountID";
        aCombo.PropertiesComboBox.TextField = "Description";
    }
    #endregion
    protected void UnitGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        if (args[0] == "LoadData")
        {
            LoadUnits();
        }
        if (args[0] == "DELETE")
        {
            if (!IsGranted("Pages.KHTC.Business.RevenueCost.Unit.Delete"))
                throw new UserFriendlyException("Bạn không có quyền xóa dữ liệu", SessionUser.UserName);

            decimal key;
            if (!decimal.TryParse(args[1], out key))
                return;

            var entity = entities.Units.SingleOrDefault(x => x.UnitID == key);
            if (entity != null)
            {
                entities.Units.Remove(entity);

                entities.SaveChanges();
                LoadUnits();
            }
        }
        if (args[0].Equals(Action.SYNC_DATA))
        {
            var versionID = this.VersionEditor.Value != null ? Convert.ToDecimal(this.VersionEditor.Value) : 0;
            if (versionID != decimal.Zero)
            {
                var version = entities.Versions.Where(x => x.VersionID == versionID).FirstOrDefault();
                if (version == null) return;

                if (!version.OriID.HasValue) return;

                entities.Sync_1VersionUnits(Convert.ToDouble(version.OriID.Value));

                LoadUnits();
            }
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExporter.FileName = "Unit.xlsx";
        DevExpress.XtraPrinting.XlsxExportOptionsEx options = new DevExpress.XtraPrinting.XlsxExportOptionsEx() { ExportType = DevExpress.Export.ExportType.WYSIWYG };
        options.SheetName = "Unit";
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

    protected void UnitGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;

        try
        {
            foreach (ASPxDataInsertValues insValues in e.InsertValues)
            {
                var entity = new KTQTData.Unit();
                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;

                entity.VersionID = Convert.ToDecimal(VersionEditor.Value);

                if (insValues.NewValues["Item"] != null)
                {
                    string aItem = insValues.NewValues["Item"].ToString();
                    entity.Item = aItem;
                }
                if (insValues.NewValues["Carrier"] != null)
                {
                    string aCarrier = insValues.NewValues["Carrier"].ToString();
                    entity.Carrier = aCarrier;
                }

                if (insValues.NewValues["Flt_Type"] != null)
                {
                    string aFlt_Type = insValues.NewValues["Flt_Type"].ToString();
                    entity.Flt_Type = aFlt_Type;
                }

                if (insValues.NewValues["Fleet_Type"] != null)
                {
                    string aFleet_Type = insValues.NewValues["Fleet_Type"].ToString();
                    entity.Fleet_Type = aFleet_Type;
                }

                if (insValues.NewValues["Ac_ID"] != null)
                {
                    string aAc_ID = insValues.NewValues["Ac_ID"].ToString();
                    entity.Ac_ID = aAc_ID;
                }

                if (insValues.NewValues["Ori"] != null)
                {
                    string aOri = insValues.NewValues["Ori"].ToString();
                    entity.Ori = aOri;
                }

                if (insValues.NewValues["Des"] != null)
                {
                    string aDes = insValues.NewValues["Des"].ToString();
                    entity.Des = aDes;
                }
                if (insValues.NewValues["Network"] != null)
                {
                    string aNetwork = insValues.NewValues["Network"].ToString();
                    entity.Network = aNetwork;
                }
                if (insValues.NewValues["Curr"] != null)
                {
                    string aCurr = insValues.NewValues["Curr"].ToString();
                    entity.Curr = aCurr;
                }

                if (insValues.NewValues["CompanyID"] != null)
                {
                    int aCompanyID = Convert.ToInt32(insValues.NewValues["CompanyID"]);
                    entity.CompanyID = aCompanyID;
                }

                if (insValues.NewValues["SubaccountID"] != null)
                {
                    int aSubaccountID = Convert.ToInt32(insValues.NewValues["SubaccountID"]);
                    entity.SubaccountID = aSubaccountID;
                }

                decimal aMonth = decimal.Zero;
                if (insValues.NewValues["M01"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M01"]);
                    entity.M01 = aMonth;
                }

                if (insValues.NewValues["M02"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M02"]);
                    entity.M02 = aMonth;
                }

                if (insValues.NewValues["M03"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M03"]);
                    entity.M03 = aMonth;
                }

                if (insValues.NewValues["M04"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M04"]);
                    entity.M04 = aMonth;
                }

                if (insValues.NewValues["M05"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M05"]);
                    entity.M05 = aMonth;
                }

                if (insValues.NewValues["M06"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M06"]);
                    entity.M06 = aMonth;
                }

                if (insValues.NewValues["M07"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M07"]);
                    entity.M07 = aMonth;
                }

                if (insValues.NewValues["M08"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M08"]);
                    entity.M08 = aMonth;
                }

                if (insValues.NewValues["M09"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M09"]);
                    entity.M09 = aMonth;
                }

                if (insValues.NewValues["M10"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M10"]);
                    entity.M10 = aMonth;
                }

                if (insValues.NewValues["M11"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M11"]);
                    entity.M11 = aMonth;
                }

                if (insValues.NewValues["M12"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M12"]);
                    entity.M12 = aMonth;
                }

                if (insValues.NewValues["K1"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["K1"]);
                    entity.K1 = aMonth;
                }

                if (insValues.NewValues["K2"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["K2"]);
                    entity.K2 = aMonth;
                }

                if (insValues.NewValues["K3"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["K3"]);
                    entity.K3 = aMonth;
                }

                if (insValues.NewValues["K4"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["K4"]);
                    entity.K4 = aMonth;
                }

                if (insValues.NewValues["K5"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["K5"]);
                    entity.K5 = aMonth;
                }

                if (insValues.NewValues["K6"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["K6"]);
                    entity.K6 = aMonth;
                }

                if (insValues.NewValues["K7"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["K7"]);
                    entity.K7 = aMonth;
                }

                if (insValues.NewValues["K8"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["K8"]);
                    entity.K8 = aMonth;
                }

                if (insValues.NewValues["K9"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["K9"]);
                    entity.K9 = aMonth;
                }

                if (insValues.NewValues["K10"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["K10"]);
                    entity.K10 = aMonth;
                }

                if (insValues.NewValues["K11"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["K11"]);
                    entity.K11 = aMonth;
                }

                if (insValues.NewValues["K12"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["K12"]);
                    entity.K12 = aMonth;
                }

                entities.Units.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                long key = Convert.ToInt64(updValues.Keys["UnitID"]);
                var entity = entities.Units.SingleOrDefault(x => x.UnitID == key);
                if (entity != null)
                {
                    entity.UpdateDate = DateTime.Now;
                    entity.UpdatedBy = SessionUser.UserID;

                    if (updValues.NewValues["Item"] != null)
                    {
                        string aItem = updValues.NewValues["Item"].ToString();
                        entity.Item = aItem;
                    }
                    else
                        entity.Item = null;

                    if (updValues.NewValues["Carrier"] != null)
                    {
                        string aCarrier = updValues.NewValues["Carrier"].ToString();
                        entity.Carrier = aCarrier;
                    }
                    else
                        entity.Carrier = null;

                    if (updValues.NewValues["Flt_Type"] != null)
                    {
                        string aFlt_Type = updValues.NewValues["Flt_Type"].ToString();
                        entity.Flt_Type = aFlt_Type;
                    }
                    else
                        entity.Flt_Type = null;

                    if (updValues.NewValues["Fleet_Type"] != null)
                    {
                        string aFleet_Type = updValues.NewValues["Fleet_Type"].ToString();
                        entity.Fleet_Type = aFleet_Type;
                    }
                    else
                        entity.Fleet_Type = null;

                    if (updValues.NewValues["Ac_ID"] != null)
                    {
                        string aAc_ID = updValues.NewValues["Ac_ID"].ToString();
                        entity.Ac_ID = aAc_ID;
                    }
                    else
                        entity.Ac_ID = null;

                    if (updValues.NewValues["Ori"] != null)
                    {
                        string aOri = updValues.NewValues["Ori"].ToString();
                        entity.Ori = aOri;
                    }
                    else
                        entity.Ori = null;

                    if (updValues.NewValues["Des"] != null)
                    {
                        string aDes = updValues.NewValues["Des"].ToString();
                        entity.Des = aDes;
                    }
                    else
                        entity.Des = null;
                    if (updValues.NewValues["Network"] != null)
                    {
                        string aNetwork = updValues.NewValues["Network"].ToString();
                        entity.Network = aNetwork;
                    }
                    else
                        entity.Network = null;

                    if (updValues.NewValues["Curr"] != null)
                    {
                        string aCurr = updValues.NewValues["Curr"].ToString();
                        entity.Curr = aCurr;
                    }
                    else
                        entity.Curr = null;

                    if (updValues.NewValues["CompanyID"] != null)
                    {
                        int aCompanyID = Convert.ToInt32(updValues.NewValues["CompanyID"]);
                        entity.CompanyID = aCompanyID;
                    }
                    else
                        entity.CompanyID = null;

                    if (updValues.NewValues["SubaccountID"] != null)
                    {
                        int aSubaccountID = Convert.ToInt32(updValues.NewValues["SubaccountID"]);
                        entity.SubaccountID = aSubaccountID;
                    }
                    else
                        entity.SubaccountID = null;

                    decimal aMonth = decimal.Zero;
                    if (updValues.NewValues["M01"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M01"]);
                        entity.M01 = aMonth;
                    }
                    else
                        entity.M01 = decimal.Zero;

                    if (updValues.NewValues["M02"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M02"]);
                        entity.M02 = aMonth;
                    }
                    else
                        entity.M02 = decimal.Zero;

                    if (updValues.NewValues["M03"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M03"]);
                        entity.M03 = aMonth;
                    }
                    else
                        entity.M03 = decimal.Zero;

                    if (updValues.NewValues["M04"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M04"]);
                        entity.M04 = aMonth;
                    }
                    else
                        entity.M04 = decimal.Zero;

                    if (updValues.NewValues["M05"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M05"]);
                        entity.M05 = aMonth;
                    }
                    else
                        entity.M05 = decimal.Zero;

                    if (updValues.NewValues["M06"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M06"]);
                        entity.M06 = aMonth;
                    }
                    else
                        entity.M06 = decimal.Zero;

                    if (updValues.NewValues["M07"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M07"]);
                        entity.M07 = aMonth;
                    }
                    else
                        entity.M07 = decimal.Zero;

                    if (updValues.NewValues["M08"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M08"]);
                        entity.M08 = aMonth;
                    }
                    else
                        entity.M08 = decimal.Zero;

                    if (updValues.NewValues["M09"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M09"]);
                        entity.M09 = aMonth;
                    }
                    else
                        entity.M09 = decimal.Zero;

                    if (updValues.NewValues["M10"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M10"]);
                        entity.M10 = aMonth;
                    }
                    else
                        entity.M10 = decimal.Zero;

                    if (updValues.NewValues["M11"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M11"]);
                        entity.M11 = aMonth;
                    }
                    else
                        entity.M11 = decimal.Zero;

                    if (updValues.NewValues["M12"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M12"]);
                        entity.M12 = aMonth;
                    }
                    else
                        entity.M12 = decimal.Zero;

                    if (updValues.NewValues["K1"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["K1"]);
                        entity.K1 = aMonth;
                    }
                    else
                        entity.K1 = 1;

                    if (updValues.NewValues["K2"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["K2"]);
                        entity.K2 = aMonth;
                    }
                    else
                        entity.K2 = 1;

                    if (updValues.NewValues["K3"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["K3"]);
                        entity.K3 = aMonth;
                    }
                    else
                        entity.K3 = 1;

                    if (updValues.NewValues["K4"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["K4"]);
                        entity.K4 = aMonth;
                    }
                    else
                        entity.K4 = 1;

                    if (updValues.NewValues["K5"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["K5"]);
                        entity.K5 = aMonth;
                    }
                    else
                        entity.K5 = 1;

                    if (updValues.NewValues["K6"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["K6"]);
                        entity.K6 = aMonth;
                    }
                    else
                        entity.K6 = 1;

                    if (updValues.NewValues["K7"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["K7"]);
                        entity.K7 = aMonth;
                    }
                    else
                        entity.K7 = 1;

                    if (updValues.NewValues["K8"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["K8"]);
                        entity.K8 = aMonth;
                    }
                    else
                        entity.K8 = 1;

                    if (updValues.NewValues["K9"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["K9"]);
                        entity.K9 = aMonth;
                    }
                    else
                        entity.K9 = 1;

                    if (updValues.NewValues["K10"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["K10"]);
                        entity.K10 = aMonth;
                    }
                    else
                        entity.K10 = 1;

                    if (updValues.NewValues["K11"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["K11"]);
                        entity.K11 = aMonth;
                    }
                    else
                        entity.K11 = 1;

                    if (updValues.NewValues["K12"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["K12"]);
                        entity.K12 = aMonth;
                    }
                    else
                        entity.K12 = 1;
                }
            }
            entities.SaveChangesWithAuditLogs();

            LoadUnits();
        }
        catch (Exception ex)
        {
            throw new UserFriendlyException(ex.Message, ex, SessionUser.UserName);
        }
        finally
        {
            e.Handled = true;
        }
    }

    protected void UnitGrid_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
    {
        ASPxEdit editor = (ASPxEdit)e.Editor;
        editor.ValidationSettings.Display = Display.None;
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