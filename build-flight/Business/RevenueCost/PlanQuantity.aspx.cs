using DevExpress.Web;
using KTQTData;
using System;
using System.Linq;
using System.Web.UI.WebControls;



public partial class Business_RevenueCost_PlanQuantity : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    const string KEY = "42A01D01-226B-42AF-8917-7A5D61CAE1DB";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session[KEY] = null;
            this.QueryMonthEditor.Value = 0;
            this.QueryYearEditor.Value = DateTime.Now.Year;

        }
        LoadHistories();
        if (this.DataGrid.IsCallback && Session[KEY] != null)
        {
            decimal key;
            if (decimal.TryParse(Session[KEY].ToString(), out key))
            {
                LoadDataHistories(key);
            }
        }
    }
    #region LoadData
    private void LoadHistories()
    {
        string areaCode = "ALL";
        if (this.cboArea.Value != null)
            areaCode = cboArea.Value.ToString();

        int year = Convert.ToInt32(this.QueryYearEditor.Number);

        var list = entities.TmpFlsHistories.Where(x => x.AreaCode == areaCode && x.FltYear == year).OrderByDescending(x => x.HisID).ToList();
        this.HistoryGrid.DataSource = list;
        this.HistoryGrid.DataBind();
    }
    private void LoadDataHistories(decimal historyID)
    {
        int month = Convert.ToInt32(this.QueryMonthEditor.Number);
        var list = entities.TmpFls.Where(x => x.HisID == historyID && (x.Flt_Month == month || month == 0)).OrderBy(x => x.Flt_Year).ThenBy(x => x.Flt_Month).ToList();
        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }

    private void LoadPlanVersion()
    {
        int year = Convert.ToInt32(this.QueryYearEditor.Number);
        var list = entities.Versions.Where(x => x.VersionType == "P" && x.Status != "APPROVED" && x.VersionYear == year).OrderByDescending(x => x.VersionYear).OrderBy(x => x.Sorting).ToList();
        this.VersionGrid.DataSource = list;
        this.VersionGrid.DataBind();
    }
    #endregion
    protected void HistoryGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');

        s.JSProperties["cpCommand"] = args[0];

        if (args[0] == "LoadHistory")
        {
            LoadHistories();
        }

        if (args[0] == "SyncVMSData")
        {
            if (this.cboArea.Value != null)
            {
                string areaCode = cboArea.Value.ToString();

                int year = Convert.ToInt32(this.QueryYearEditor.Number);
                entities.Sync_KH_Airlines_GetSL(areaCode, year, 1, 12, SessionUser.UserID);
            }
            LoadHistories();
        }
    }
    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        if (args[0] == "LoadDataHistory")
        {
            decimal key;
            if (!decimal.TryParse(args[1], out key))
                return;

            Session[KEY] = key;
            LoadDataHistories(key);
        }

        if (args[0] == "ApplyToVersion")
        {
            decimal versionID;
            if (!decimal.TryParse(args[1], out versionID))
                return;

            decimal hisID;
            if (!decimal.TryParse(args[2], out hisID))
                return;

            entities.Transfer_Plan_Fls_Date(versionID, hisID, SessionUser.UserID);
        }
    }
    protected void cboArea_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Airports.Where(x => x.Code != "CTY").ToList();
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
    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (Session[KEY] != null)
        {
            decimal key;
            if (decimal.TryParse(Session[KEY].ToString(), out key))
            {
                LoadDataHistories(key);
            }
        }
        //  GridViewExporter.FileName = "PlanQuantity.xlsx";
        //DevExpress.XtraPrinting.XlsxExportOptionsEx options = new DevExpress.XtraPrinting.XlsxExportOptionsEx() { ExportType = DevExpress.Export.ExportType.WYSIWYG };
        //GridViewExporter.WriteXlsxToResponse(options);
    }
    protected void VersionGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        if (args[0] == "LoadVersion")
        {
            LoadPlanVersion();
        }
    }
}