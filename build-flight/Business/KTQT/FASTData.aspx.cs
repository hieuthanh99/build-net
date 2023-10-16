using DevExpress.Web;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Business_KTQT_FASTData : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        SetPermistion();
        if (!IsPostBack)
        {
            int vMonth = DateTime.Now.Month;
            int vYear = DateTime.Now.Year;
            if (vMonth == 1)
            {
                vMonth = 12;
                vYear = vYear - 1;
            }
            else
            {
                vMonth = vMonth - 1;
            }
            this.QueryFromMonthEditor.Value = vMonth;
            this.QueryToMonthEditor.Value = vMonth;
            this.QueryYearEditor.Value = vYear;

            this.SyncFromMonthEditor.Value = vMonth;
            this.SyncToMonthEditor.Value = vMonth;
            this.YearEditor.Value = vYear;
            this.ApplyFromMonthEditor.Value = vMonth;
            this.ApplyToMonthEditor.Value = vMonth;

        }
        //if (!IsPostBack || this.FltOpsGrid.IsCallback)
        //{
        LoadFASTData();
        //}
    }
    private void SetPermistion()
    {
        if (!(SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR)))
        {
            btnSyncFAST.Visible = (SessionUser.IsInRole(PermissionConstant.SYNC_FAST_DATA));
            cboArea.Enabled = false;
            cboArea1.Enabled = false;
        }
        else
        {
            btnSyncFAST.Visible = true;
            cboArea.Enabled = true;
            cboArea1.Enabled = true;
        }
    }
    #region Load data

    private void LoadFASTData()
    {
        var fromMonth = this.QueryFromMonthEditor.Number;
        var toMonth = this.QueryToMonthEditor.Number;
        var year = this.QueryYearEditor.Number;
        var areaCode = cboArea.Value.ToString();

        var list = entities.FASTDatas
            .Where(x => x.Year == year && x.Month >= fromMonth && x.Month <= toMonth && (x.AreaCode == areaCode || areaCode == "ALL"))
            .OrderBy(x => x.AreaCode).ThenBy(x => x.Month).ThenBy(x => x.ShortName).ThenBy(x => x.STT).ToList();

        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }


    private void LoadActualVersion()
    {
        var year = this.QueryYearEditor.Number;
        var list = entities.Versions
            .Where(x => x.VersionType == "A" && x.VersionYear == year && x.Status != "APPROVED" && x.Active == true)
            .OrderByDescending(x => x.VersionYear)
            .ThenBy(x => x.Sorting).ToList();
        this.VersionGrid.DataSource = list;
        this.VersionGrid.DataBind();
    }

    //private void LoadCompany(string AreaCode)
    //{
    //    var list = entities.DecCompanies.Where(x => x.AreaCode == AreaCode).OrderByDescending(x => x.Seq).ToList();
    //    this.cboApplyCompany.DataSource = list;
    //    this.cboApplyCompany.ValueField = "CompanyID";
    //    this.cboApplyCompany.TextField = "NameV";
    //    this.cboApplyCompany.DataBind();
    //}
    #endregion
    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        if (args[0] == "LoadData")
        {
            LoadFASTData();
        }

        if (args[0] == "SyncFASTData")
        {
            try
            {
                var fromMonth = Convert.ToInt32(this.SyncFromMonthEditor.Number);
                var toMonth = Convert.ToInt32(this.SyncToMonthEditor.Number);
                var year = Convert.ToInt32(this.YearEditor.Number);
                string areaCode = cboArea1.Value.ToString();
                decimal versionID = 0;

                if (areaCode.Equals("ALL"))
                {
                    var list = entities.Airports.Where(x => (x.VNDes ?? false) == true).ToList();
                    foreach (var item in list)
                    {
                        for (int month = fromMonth; month <= toMonth; month++)
                        {
                            SqlParameter[] parameters = new SqlParameter[] {
                                new SqlParameter("@pVersionID", versionID),
                                new SqlParameter("@pMonth", month),
                                new SqlParameter("@pYear", year),
                                new SqlParameter("@pAreaCode", item.Code)                 
                            };

                            entities.Database.ExecuteSqlCommand(DbHelper.GenerateCommandText("[KTQT_Data].[dbo].[SynchronizeFASTData]", parameters), parameters);

                            //entities.SynchronizeFASTData(null, month, year, item.Code);
                        }
                    }
                }
                else
                {
                    for (int month = fromMonth; month <= toMonth; month++)
                    {
                        SqlParameter[] parameters = new SqlParameter[] {
                                new SqlParameter("@pVersionID",versionID),
                                new SqlParameter("@pMonth", month),
                                new SqlParameter("@pYear", year),
                                new SqlParameter("@pAreaCode", areaCode)                 
                            };

                        entities.Database.ExecuteSqlCommand(DbHelper.GenerateCommandText("[KTQT_Data].[dbo].[SynchronizeFASTData]", parameters), parameters);

                        //entities.SynchronizeFASTData(null, month, year, areaCode);
                    }
                }
                LoadFASTData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        if (args[0] == "ApplyToVersion")
        {
            decimal versionID;

            if (!decimal.TryParse(args[1], out versionID))
                return;

            var version = entities.Versions.SingleOrDefault(x => x.VersionID == versionID);
            if (version != null)
            {
                var fromMonth = Convert.ToInt32(this.ApplyFromMonthEditor.Number);
                var toMonth = Convert.ToInt32(this.ApplyToMonthEditor.Number);

                string areaCode = cboArea.Value.ToString();

                int? companyID = 0;// Convert.ToInt32(cboApplyCompany.Value == null ? 0 : cboApplyCompany.Value);
                var year = version.VersionYear;

                if (areaCode.Equals("ALL"))
                {
                    var list = entities.Airports.Where(x => (x.VNDes ?? false) == true).ToList();
                    foreach (var item in list)
                    {
                        SqlParameter[] parameters = new SqlParameter[] {
                                new SqlParameter("@pVersionID", versionID),
                                new SqlParameter("@pAreaCode", item.Code),
                                new SqlParameter("@pCompanyID", companyID),
                                new SqlParameter("@pFromMonth", fromMonth),
                                new SqlParameter("@pToMonth", toMonth),
                                new SqlParameter("@pYear", year)                     
                            };

                        entities.Database.ExecuteSqlCommand(DbHelper.GenerateCommandText("[KTQT_Data].[dbo].[ApplyGLBudgetToVersion]", parameters), parameters);
                        //entities.ApplyGLBudgetToVersion(versionID, item.Code, companyID, fromMonth, toMonth, year);
                    }
                }
                else
                {
                    SqlParameter[] parameters = new SqlParameter[] {
                                new SqlParameter("@pVersionID", versionID),
                                new SqlParameter("@pAreaCode", areaCode),
                                new SqlParameter("@pCompanyID", companyID),
                                new SqlParameter("@pFromMonth", fromMonth),
                                new SqlParameter("@pToMonth", toMonth),
                                new SqlParameter("@pYear", year)         
                    };

                    entities.Database.ExecuteSqlCommand(DbHelper.GenerateCommandText("[KTQT_Data].[dbo].[ApplyGLBudgetToVersion]", parameters), parameters);

                    //entities.ApplyGLBudgetToVersion(versionID, areaCode, companyID, fromMonth, toMonth, year);
                }
            }

        }

        if (args[0] == "ExportTemplate")
        {
            ExportTemplate();
        }

        if (args[0] == "SaveAdjust")
        {
            decimal aFASTDataID;
            if (!decimal.TryParse(args[1], out aFASTDataID))
                return;

            var entity = entities.FASTDatas.SingleOrDefault(x => x.FASTDataID == aFASTDataID);
            if (entity != null)
            {
                if (txtAdjust.Value != null)
                    entity.Adjust = txtAdjust.Number;
                else
                    entity.Adjust = null;

                entities.SaveChanges();
            }
            LoadFASTData();
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

        //le = new ListEditItem();
        //le.Value = "CTY";
        //le.Text = "CTY";
        //s.Items.Add(le);

        foreach (var item in list)
        {
            le = new ListEditItem();
            le.Value = item.Code;
            le.Text = item.NameE;
            s.Items.Add(le);
        }
        //s.DataSource = list;
        //s.ValueField = "Code";
        //s.TextField = "NameE";
        //s.DataBind();
        if (s.Items.Count > 0)
        {
            var curCompany = entities.DecCompanies.SingleOrDefault(x => x.CompanyID == SessionUser.CompanyID);
            if (curCompany != null)
                s.Value = curCompany.AreaCode == "KCQ" ? "CTY" : curCompany.AreaCode;
        }
    }
    protected void VersionGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        if (args[0] == "LoadVersion")
        {
            LoadActualVersion();
        }
        if (args[0] == "ApplyToVersion")
        {
            decimal versionID;
            if (!decimal.TryParse(args[1], out versionID))
                return;


        }


    }
    protected void cboApplyCompany_Callback(object sender, CallbackEventArgsBase e)
    {
        //var args = e.Parameter.Split('|');
        //if (args[0] == "LoadCompany")
        //{
        //    LoadCompany(args[1]);
        //}

    }
    protected void cboArea1_Init(object sender, EventArgs e)
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
            le.Value = item.Code;
            le.Text = item.NameE;
            s.Items.Add(le);
        }
        if (s.Items.Count > 0)
        {
            var curCompany = entities.DecCompanies.SingleOrDefault(x => x.CompanyID == SessionUser.CompanyID);
            if (curCompany != null)
                s.Value = curCompany.AreaCode == "KCQ" ? "CTY" : curCompany.AreaCode;
        }
    }
    protected void DataGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {

    }
    protected void FASTDataCallback_Callback(object source, CallbackEventArgs e)
    {
        decimal aFASTDataID;
        if (!decimal.TryParse(e.Parameter, out aFASTDataID))
        {
            e.Result = "0";
            return;
        }
        var entity = entities.FASTDatas.SingleOrDefault(x => x.FASTDataID == aFASTDataID);
        if (entity != null)
            e.Result = entity.Adjust.HasValue ? entity.Adjust.Value.ToString() : "0";
        else
            e.Result = "0";
    }
}