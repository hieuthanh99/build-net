using DevExpress.Web;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Business_KTQT_VersionType : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadVersionBaseID(VersionGrid);
        if (!IsPostBack)
        {
            this.VersionYearEditor.Value = DateTime.Now.Year;
            this.FromMonthEditor.Value = DateTime.Now.Month;
            this.ToMonthEditor.Value = DateTime.Now.Month;

            this.ApplyFromMonthEditor.Value = DateTime.Now.Month;
            this.ApplyToMonthEditor.Value = DateTime.Now.Month;
        }

        if (!IsPostBack || this.VersionGrid.IsCallback)
        {
            if (rdoVersionType.Value != null && this.VersionYearEditor.Value != null)
            {
                string versionType = rdoVersionType.Value.ToString();
                int versionYear = Convert.ToInt32(this.VersionYearEditor.Value);
                this.LoadVersions(versionType, versionYear);
            }
        }

        if (this.VersionCopyGrid.IsCallback)
            this.LoadCopyVersions();


        if (this.PlanVersionGrid.IsCallback)
            this.LoadCopyPlanVersions();

        SetPermistion();
    }
    private void SetPermistion()
    {
        btnSyncData.Visible = IsGranted("Pages.KHTC.Business.KTQT.VersionType.SyncData");

        var btnNew = (ASPxButton)VersionGrid.FindTitleTemplateControl("btnNew");
        var btnEdit = (ASPxButton)VersionGrid.FindTitleTemplateControl("btnEdit");
        var btnDelete = (ASPxButton)VersionGrid.FindTitleTemplateControl("btnDelete");

        btnNew.Visible = IsGranted("Pages.KHTC.Business.KTQT.VersionType.Create");
        btnEdit.Visible = IsGranted("Pages.KHTC.Business.KTQT.VersionType.Edit");
        btnDelete.Visible = IsGranted("Pages.KHTC.Business.KTQT.VersionType.Delete");

        btnApprove.Visible = IsGranted("Pages.KHTC.Business.KTQT.VersionType.Approve");
        btnUnApprove.Visible = IsGranted("Pages.KHTC.Business.KTQT.VersionType.Approve");
        btnCopy.Visible = IsGranted("Pages.KHTC.Business.KTQT.VersionType.Copy");
        btnApplyToDepartment.Visible = IsGranted("Pages.KHTC.Business.KTQT.VersionType.ApplyVersion");
        btnUsedStatus.Visible = IsGranted("Pages.KHTC.Business.KTQT.VersionType.UseStatus");
        btnSyncPMSData.Visible = IsGranted("Pages.KHTC.Business.KTQT.VersionType.SyncPMSData");

        //if (!(SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR)))
        //{
        //    //btnSynchronizeFASTData.Visible = (SessionUser.IsInRole(PermissionConstant.SYNC_FAST_DATA));
        //    btnApprove.Visible = (SessionUser.IsInRole(PermissionConstant.APPROVE_VERSION));
        //    btnUnApprove.Visible = (SessionUser.IsInRole(PermissionConstant.APPROVE_VERSION));
        //}
        //else
        //{
        //    //btnSynchronizeFASTData.Visible = true;
        //    btnApprove.Visible = true;
        //    btnUnApprove.Visible = true;
        //}
    }

    #region Load data
    private decimal GetCallbackKeyValue(string keyStr)
    {
        string result = null;
        if (Utils.TryGetClientStateValue<string>(this, keyStr, out result))
            return Convert.ToDecimal(result);
        return decimal.Zero;
    }
    private void LoadVersions(string versionType, int versionYear)
    {
        var list = entities.Versions.Where(x => x.VersionType == versionType && x.VersionYear == versionYear && (x.Active ?? false))
            .OrderByDescending(x => x.VersionYear).OrderBy(x => x.Sorting).ToList();
        this.VersionGrid.DataSource = list;
        this.VersionGrid.DataBind();
    }

    private void LoadCopyVersions()
    {
        var list = entities.Versions.OrderByDescending(x => x.VersionYear).OrderBy(x => x.Sorting).ToList();
        this.VersionCopyGrid.DataSource = list;
        this.VersionCopyGrid.DataBind();
    }

    private void LoadCopyPlanVersions()
    {

        var list = entities.V_QLKH_VERSION.OrderByDescending(x => x.VersionYear).OrderBy(x => x.Sorting).ToList();
        this.PlanVersionGrid.DataSource = list;
        this.PlanVersionGrid.DataBind();

    }

    private void LoadVersionBaseID(ASPxGridView Grid)
    {
        GridViewDataComboBoxColumn aComboVersionBase = (GridViewDataComboBoxColumn)Grid.Columns["VerIDBase"];
        GridViewDataComboBoxColumn aComboVersionBase1 = (GridViewDataComboBoxColumn)Grid.Columns["VerIDBase1"];
        GridViewDataComboBoxColumn aComboVersionBase2 = (GridViewDataComboBoxColumn)Grid.Columns["VerIDBase2"];
        GridViewDataComboBoxColumn aComboVersionBase3 = (GridViewDataComboBoxColumn)Grid.Columns["VerIDBase3"];
        GridViewDataComboBoxColumn aComboVersionBase4 = (GridViewDataComboBoxColumn)Grid.Columns["VerIDBase4"];

        var list = entities.Versions.ToList();
        aComboVersionBase.PropertiesComboBox.DataSource = list;
        aComboVersionBase.PropertiesComboBox.ValueField = "VersionID";
        aComboVersionBase.PropertiesComboBox.TextField = "VersionName";

        aComboVersionBase1.PropertiesComboBox.DataSource = list;
        aComboVersionBase1.PropertiesComboBox.ValueField = "VersionID";
        aComboVersionBase1.PropertiesComboBox.TextField = "VersionName";

        aComboVersionBase2.PropertiesComboBox.DataSource = list;
        aComboVersionBase2.PropertiesComboBox.ValueField = "VersionID";
        aComboVersionBase2.PropertiesComboBox.TextField = "VersionName";

        aComboVersionBase3.PropertiesComboBox.DataSource = list;
        aComboVersionBase3.PropertiesComboBox.ValueField = "VersionID";
        aComboVersionBase3.PropertiesComboBox.TextField = "VersionName";

        aComboVersionBase4.PropertiesComboBox.DataSource = list;
        aComboVersionBase4.PropertiesComboBox.ValueField = "VersionID";
        aComboVersionBase4.PropertiesComboBox.TextField = "VersionName";
    }
    #endregion
    protected void VersionGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');

        s.JSProperties["cpCommand"] = args[0];

        if (args[0] == "DELETE")
        {
            try
            {
                decimal key;
                if (!decimal.TryParse(args[1], out key)) return;

                var check = entities.VersionCompanies.Where(x => x.VersionID == key).Any();
                if (check)
                {
                    s.JSProperties["cpResult"] = "This version is in use. Unable to delete this version.";
                    return;
                }

                var entity = (from x in entities.Versions where x.VersionID == key select x).FirstOrDefault();
                if (entity != null)
                {
                    entities.Versions.Remove(entity);
                    entities.SaveChangesWithAuditLogs();

                    if (rdoVersionType.Value != null && this.VersionYearEditor.Value != null)
                    {
                        string versionType = rdoVersionType.Value.ToString();
                        int versionYear = Convert.ToInt32(this.VersionYearEditor.Value);
                        this.LoadVersions(versionType, versionYear);
                    }
                }
                s.JSProperties["cpResult"] = "Success";
            }
            catch (Exception ex)
            {
                s.JSProperties["cpResult"] = ex.Message;
            }
        }

        if (args[0] == "SaveForm")
        {
            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];

                    decimal? nullDecimal = null;
                    if (command.ToUpper() == "EDIT")
                    {
                        decimal key;
                        if (!decimal.TryParse(args[2], out key)) return;

                        var entity = entities.Versions.Where(x => x.VersionID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            entity.VersionYear = Convert.ToInt32(ForYearEditor.Number);
                            entity.VersionType = TypeEditor.Value.ToString();
                            entity.VersionName = NameEditor.Text;
                            entity.VersionQuantityName = VersionEditor.Text;
                            entity.VersionLevel = LevelEditor.Text;
                            //entity.CPI = CPIEditor.Number;
                            entity.Calculation = CalculationEditor.Value.ToString();
                            entity.Description = DescriptionEditor.Text;
                            entity.VerIDBase = Verbase01Editor.Value != null ? Convert.ToDecimal(Verbase01Editor.Value) : nullDecimal;
                            entity.VerIDBase1 = Verbase02Editor.Value != null ? Convert.ToDecimal(Verbase02Editor.Value) : nullDecimal;
                            entity.VerIDBase2 = Verbase03Editor.Value != null ? Convert.ToDecimal(Verbase03Editor.Value) : nullDecimal;
                            entity.VerIDBase3 = Verbase04Editor.Value != null ? Convert.ToDecimal(Verbase04Editor.Value) : nullDecimal;
                            entity.VerIDBase4 = Verbase05Editor.Value != null ? Convert.ToDecimal(Verbase05Editor.Value) : nullDecimal;

                            //entity.OnTop = Convert.ToInt32(rblActualType.Value);
                            entity.Active = ActiveEditor.Checked;

                            entity.CreateNote = CreateNoteEditor.Text;
                            entities.SaveChangesWithAuditLogs();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new KTQTData.Version();
                        entity.VersionYear = Convert.ToInt32(ForYearEditor.Number);
                        entity.VersionType = TypeEditor.Value.ToString();
                        entity.VersionName = NameEditor.Text;
                        entity.VersionQuantityName = VersionEditor.Text;
                        entity.VersionLevel = LevelEditor.Text;
                        entity.Calculation = CalculationEditor.Value.ToString();
                        //entity.CPI = CPIEditor.Number;
                        entity.Description = DescriptionEditor.Text;
                        entity.VerIDBase = Verbase01Editor.Value != null ? Convert.ToDecimal(Verbase01Editor.Value) : nullDecimal;
                        entity.VerIDBase1 = Verbase02Editor.Value != null ? Convert.ToDecimal(Verbase02Editor.Value) : nullDecimal;
                        entity.VerIDBase2 = Verbase03Editor.Value != null ? Convert.ToDecimal(Verbase03Editor.Value) : nullDecimal;
                        entity.VerIDBase3 = Verbase04Editor.Value != null ? Convert.ToDecimal(Verbase04Editor.Value) : nullDecimal;
                        entity.VerIDBase4 = Verbase05Editor.Value != null ? Convert.ToDecimal(Verbase05Editor.Value) : nullDecimal;
                        //entity.OnTop = Convert.ToInt32(rblActualType.Value);

                        entity.Active = ActiveEditor.Checked;
                        entity.Status = "WORKING";

                        entity.CreatedDate = DateTime.Now;
                        entity.CreateNote = CreateNoteEditor.Text;
                        entity.Creator = (int)SessionUser.UserID;

                        entities.Versions.Add(entity);
                        entities.SaveChangesWithAuditLogs();
                    }

                    if (rdoVersionType.Value != null && this.VersionYearEditor.Value != null)
                    {
                        string versionType = rdoVersionType.Value.ToString();
                        int versionYear = Convert.ToInt32(this.VersionYearEditor.Value);
                        this.LoadVersions(versionType, versionYear);
                    }

                    s.JSProperties["cpResult"] = "Success";
                }
                catch (Exception ex)
                {
                    s.JSProperties["cpResult"] = ex.Message;
                }
            }
        }
        if (args[0] == "ApplyVersion")
        {
            decimal key;
            if (!decimal.TryParse(args[1], out key)) return;

            var entity = (from x in entities.Versions where x.VersionID == key select x).FirstOrDefault();
            if (entity != null)
            {
                var companieIDs = entities.DecCompanies.Where(x => x.Active == true).Select(x => x.CompanyID).ToList(); // x.CompanyType == "D"
                foreach (int companyID in companieIDs)
                {
                    var check = entities.VersionCompanies.Where(x => x.VersionID == key && x.CompanyID == companyID).Any();
                    if (!check)
                    {
                        try
                        {
                            entities.CreateVersionCompany(entity.VersionID, companyID, SessionUser.UserID);
                        }
                        catch { }
                    }
                }
            }
        }

        if (args[0] == "ApproveUnApproved")
        {
            decimal verID;
            if (!decimal.TryParse(args[1], out verID))
                return;

            var verCompany = entities.Versions.SingleOrDefault(x => x.VersionID == verID);
            if (verCompany != null)
            {
                verCompany.Status = verCompany.Status == "APPROVED" ? "UNAPPROVED" : "APPROVED";
                //verCompany.ApproveStatus = verCompany.ApproveStatus == "APPROVED" ? "UNAPPROVED" : "APPROVED";
                verCompany.ApprovedDate = DateTime.Now;
                verCompany.Approver = SessionUser.UserID;
                verCompany.ApprovedNote = ApproveNoteEditor.Text;

                entities.SaveChangesWithAuditLogs();

                if (rdoVersionType.Value != null && this.VersionYearEditor.Value != null)
                {
                    string versionType = rdoVersionType.Value.ToString();
                    int versionYear = Convert.ToInt32(this.VersionYearEditor.Value);
                    this.LoadVersions(versionType, versionYear);
                }
            }
        }
        if (args[0].Equals(Action.SYNC_DATA))
        {
            entities.Sync_AllVersion();

            if (rdoVersionType.Value != null && this.VersionYearEditor.Value != null)
            {
                string versionType = rdoVersionType.Value.ToString();
                int versionYear = Convert.ToInt32(this.VersionYearEditor.Value);
                this.LoadVersions(versionType, versionYear);
            }

        }
        if (args[0].Equals("SYNC_PMS_DATA"))
        {
            decimal verID;
            if (!decimal.TryParse(args[1], out verID))
                return;

            var version = entities.Versions.Where(x => x.VersionID == verID).FirstOrDefault();
            if (version == null) return;

            if (!version.OriID.HasValue) return;

            Hangfire.BackgroundJob.Enqueue<CopyVersionJob>(t => t.SyncData((double)version.OriID.Value, SessionUser.UserName));

            new UserFriendlyMessage("Tiến trình đồng bộ đã thêm vào queued để thực hiện.", SessionUser.UserName, UserFriendlyMessage.MessageType.SUCCESS);

        }
        if (args[0] == "SynchronizeFASTData")
        {
            decimal verID;
            int fMonth;
            int tMonth;

            if (!decimal.TryParse(args[1], out verID))
                return;

            if (!int.TryParse(args[2], out fMonth))
                return;

            if (!int.TryParse(args[3], out tMonth))
                return;

            var version = entities.Versions.SingleOrDefault(x => x.VersionID == verID);
            if (version != null)
            {
                string areaCode = string.Empty;
                var curCompany = entities.DecCompanies.SingleOrDefault(x => x.CompanyID == SessionUser.CompanyID);
                if (curCompany != null)
                    areaCode = curCompany.AreaCode;
                for (int i = fMonth; i <= tMonth; i++)
                {
                    entities.SynchronizeFASTData(verID, i, version.VersionYear, areaCode);
                }
            }
        }
        if (args[0] == "SetUsedStatus")
        {
            decimal verID;

            if (!decimal.TryParse(args[1], out verID))
                return;
            var version = entities.Versions.SingleOrDefault(x => x.VersionID == verID);
            if (version != null)
            {
                var aUsedStatus = version.UsedStatus;
                if (!string.IsNullOrEmpty(aUsedStatus) && aUsedStatus.Equals("USED"))
                {
                    version.UsedStatus = null;
                }
                else
                {
                    var list = entities.Versions.Where(x => x.VersionID != verID && x.VersionYear == version.VersionYear && x.VersionType == version.VersionType).ToList();
                    foreach (var v in list)
                    {
                        v.UsedStatus = null;
                    }

                    version.UsedStatus = "USED";
                }

                entities.SaveChangesWithAuditLogs();
            }

            string versionType = rdoVersionType.Value.ToString();
            int versionYear = Convert.ToInt32(this.VersionYearEditor.Value);
            this.LoadVersions(versionType, versionYear);
        }
    }

    private int GetVerYear(decimal? verId)
    {
        if (!verId.HasValue) return DateTime.Now.Year;

        var version = entities.Versions.SingleOrDefault(x => x.VersionID == verId);
        if (version == null)
            return DateTime.Now.Year;

        return version.VersionYear.Value;
    }

    private string GetVerName(decimal? verId)
    {
        if (!verId.HasValue) return string.Empty;

        var version = entities.Versions.SingleOrDefault(x => x.VersionID == verId);
        if (version == null)
            return string.Empty;

        return version.VersionName;
    }

    protected void VersionGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "EditForm" && args.Length == 3)
        {
            decimal key;
            if (!decimal.TryParse(args[2], out key))
            {
                e.Result = null;
                return;
            }
            var version = entities.Versions.SingleOrDefault(x => x.VersionID == key);
            if (version == null)
                return;

            var result = new Dictionary<string, string>();
            result["VersionYear"] = (version.VersionYear ?? 0).ToString();
            result["VersionType"] = version.VersionType;
            result["VersionName"] = version.VersionName;
            result["VersionQuantityName"] = version.VersionQuantityName;
            result["VersionLevel"] = version.VersionLevel;
            result["Calculation"] = version.Calculation;
            result["CPI"] = version.CPI.HasValue ? version.CPI.ToString() : "0";
            result["Description"] = version.Description;
            result["OnTop"] = version.OnTop.HasValue ? version.OnTop.Value.ToString() : "0";
            result["CreateNote"] = version.CreateNote;
            result["VerIDBase"] = version.VerIDBase.HasValue ? version.VerIDBase.Value.ToString() : "";
            result["VerIDBase1"] = version.VerIDBase1.HasValue ? version.VerIDBase1.Value.ToString() : "";
            result["VerIDBase2"] = version.VerIDBase2.HasValue ? version.VerIDBase2.Value.ToString() : "";
            result["VerIDBase3"] = version.VerIDBase3.HasValue ? version.VerIDBase3.Value.ToString() : "";
            result["VerIDBase4"] = version.VerIDBase4.HasValue ? version.VerIDBase4.Value.ToString() : "";

            result["VerNameBase1"] = GetVerName(version.VerIDBase);
            result["VerNameBase2"] = GetVerName(version.VerIDBase1);
            result["VerNameBase3"] = GetVerName(version.VerIDBase2);
            result["VerNameBase4"] = GetVerName(version.VerIDBase3);
            result["VerNameBase5"] = GetVerName(version.VerIDBase4);

            result["VerYearBase1"] = GetVerYear(version.VerIDBase).ToString();
            result["VerYearBase2"] = GetVerYear(version.VerIDBase1).ToString();
            result["VerYearBase3"] = GetVerYear(version.VerIDBase2).ToString();
            result["VerYearBase4"] = GetVerYear(version.VerIDBase3).ToString();
            result["VerYearBase5"] = GetVerYear(version.VerIDBase4).ToString();


            result["Active"] = (version.Active ?? false) ? "True" : "False";

            e.Result = result;
        }
    }
    protected void RevCostCallback_Callback(object source, CallbackEventArgs e)
    {
        var args = e.Parameter.Split('|');
        if (args[0] == "CheckVerStatus")
        {
            decimal verID;
            if (!decimal.TryParse(args[1], out verID))
                return;

            var ver = entities.Versions.SingleOrDefault(v => v.VersionID == verID);
            if (ver == null)
            {
                e.Result = "FAIL";
                return;
            }
            e.Result = ver.Status;
        }
    }
    protected void VersionCopyGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');

        if (args[0] == "CopyVersion")
        {
            int srcVerID;
            if (!int.TryParse(args[1], out srcVerID))
                return;

            decimal desVerID;
            if (!decimal.TryParse(args[2], out desVerID))
                return;

            //entities.CopyVersion(srcVerID, desVerID, SessionUser.UserID);

            var job = new KTQTData.BackgroundJob
            {
                VersionID = desVerID,
                JobType = "COPYVERSION",
                IssueDate = DateTime.Now.AddSeconds(30),
                Status = "QUEUED",
                CreateDate = DateTime.Now,
                CreatedBy = SessionUser.UserID
            };
            entities.BackgroundJobs.Add(job);

            entities.SaveChangesWithAuditLogs();

            var hfJobId = Hangfire.BackgroundJob.Enqueue<CopyVersionJob>(t => t.Execute(job.Id, srcVerID, desVerID, SessionUser.UserID));

            var addedJob = entities.BackgroundJobs.Where(x => x.Id == job.Id).FirstOrDefault();
            if (addedJob != null)
            {
                addedJob.HFJobId = hfJobId;
                entities.SaveChanges();
            }

            //Hangfire.BackgroundJob.Schedule<CopyVersionJob>(t => t.Execute(job.Id, srcVerID, desVerID, SessionUser.UserID), TimeSpan.FromSeconds((job.IssueDate.Value - DateTime.Now).TotalSeconds));

        }
    }
    protected void PlanVersionGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');

        if (args[0] == "CopyPlanVersion")
        {
            int srcVerID;
            if (!int.TryParse(args[1], out srcVerID))
                return;

            decimal desVerID;
            if (!decimal.TryParse(args[2], out desVerID))
                return;

            int fromMonth = Convert.ToInt32(ApplyFromMonthEditor.Number);
            int toMonth = Convert.ToInt32(ApplyToMonthEditor.Number);

            entities.CopyVersionDataFromKHNH(srcVerID, desVerID, "T", fromMonth, toMonth, SessionUser.UserID);
            entities.CopyVersionDataFromKHNH(srcVerID, desVerID, "C", fromMonth, toMonth, SessionUser.UserID);
        }
    }

    protected void Verbase01Editor_Init(object sender, EventArgs e)
    {
        //ASPxComboBox s = sender as ASPxComboBox;
        //var list = entities.Versions
        //    .Select(x => new { VersionID = x.VersionID, VersionName = x.VersionName })
        //    .ToList();

        //s.DataSource = list;
        //s.ValueField = "VersionID";
        //s.TextField = "VersionName";
        //s.DataBind();
    }

    protected void Verbase05Editor_Callback(object sender, CallbackEventArgsBase e)
    {
        int aYear;
        if (!int.TryParse(e.Parameter, out aYear))
            return;

        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Versions
            .Where(x => x.VersionYear == aYear && (x.Active ?? false))
            .Select(x => new { VersionID = x.VersionID, VersionName = x.VersionName })
            .ToList();

        s.DataSource = list;
        s.ValueField = "VersionID";
        s.TextField = "VersionName";
        s.DataBind();
    }


}

