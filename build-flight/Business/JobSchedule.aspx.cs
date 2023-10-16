using DevExpress.Web;
using KTQTData;
using System;
using System.Linq;
using Hangfire;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using System.IO;
using System.Web;
using APPLibs;

public partial class Business_JobSchedule : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadCompanys();
        if (!IsPostBack)
        {
            FromMonthEditor.Value = 1;
            ToMonthEditor.Value = 12;
        }

        if (!IsPostBack || this.VersionGrid.IsCallback)
        {
            LoadVersions();
        }

        if (this.JobGrid.IsCallback)
        {
            if (this.GetGridCallbackType() != ASPxGridViewCallbackType.Custom)
            {
                if (this.JobScheduleHiddenField.Contains("VersionID"))
                {
                    var aVersionID = Convert.ToDecimal(JobScheduleHiddenField.Get("VersionID"));
                    this.LoadBackgroundJobs(aVersionID);

                }
            }

        }

        if (this.JobDetailGrid.IsCallback)
        {
            if (this.GetGridCallbackType() != ASPxGridViewCallbackType.Custom)
            {
                if (this.JobScheduleHiddenField.Contains("JobID"))
                {
                    var aJobID = Convert.ToDecimal(JobScheduleHiddenField.Get("JobID"));
                    this.LoadBackgroundJobDetails(aJobID);

                }
            }

        }
    }
    #region Callback Type
    enum ASPxGridViewCallbackType
    {
        None, Custom, Sorting, ApplyFilter, FilterEditing, StartEdit, UpdateEdit,
        CancelEdit, AddNewRow, DeleteRow, FocusRow, GotoPage, ColumnMoved, ExpandGroup, CollapseGroup, Unknown
    };
    ASPxGridViewCallbackType GetGridCallbackType()
    {
        const string GridCallbackSuffix = "GB|";
        const string ActionSorting = "SORT";
        const string ActionEdit = "STARTEDIT";
        const string ActionUpdate = "UPDATEEDIT";
        const string ActionCancel = "CANCELEDIT";
        const string ActionAddNewRow = "ADDNEWROW";
        const string ActionDeleteRow = "DELETEROW";
        const string ActionFocusRow = "FOCUSEDROW";
        const string ActionGotoPage = "PAGERONCLICK";
        const string ActionCustom = "CUSTOMCALLBACK";
        const string ActionFilterShowMenu = "FILTERROWMENU";
        const string ActionFilterPopup = "FILTERPOPUP";
        const string ActionShowFilterControl = "SHOWFILTERCONTROL";
        const string ActionCloseFilterControl = "CLOSEFILTERCONTROL";
        const string ActionApplyFilter = "APPLYFILTER";
        const string ActionApplyColumnFilter = "APPLYHEADERCOLUMNFILTER";
        const string ActionColumnMoved = "COLUMNMOVE";
        const string ActionExpandGroup = "EXPANDROW";
        const string ActionCollapseGroup = "COLLAPSEROW";

        string callbackParam = Request.Params["__CALLBACKPARAM"];
        if (string.IsNullOrEmpty(callbackParam)) return ASPxGridViewCallbackType.None;
        if (!callbackParam.Contains(GridCallbackSuffix)) return ASPxGridViewCallbackType.None;
        string action = callbackParam.Substring(callbackParam.IndexOf(GridCallbackSuffix));
        if (action.Contains(ActionCustom)) return ASPxGridViewCallbackType.Custom;
        if (action.Contains(ActionSorting)) return ASPxGridViewCallbackType.Sorting;
        if (action.Contains(ActionEdit)) return ASPxGridViewCallbackType.StartEdit;
        if (action.Contains(ActionUpdate)) return ASPxGridViewCallbackType.UpdateEdit;
        if (action.Contains(ActionCancel)) return ASPxGridViewCallbackType.CancelEdit;
        if (action.Contains(ActionAddNewRow)) return ASPxGridViewCallbackType.AddNewRow;
        if (action.Contains(ActionDeleteRow)) return ASPxGridViewCallbackType.DeleteRow;
        if (action.Contains(ActionFocusRow)) return ASPxGridViewCallbackType.FocusRow;
        if (action.Contains(ActionGotoPage)) return ASPxGridViewCallbackType.GotoPage;
        if (action.Contains(ActionFilterShowMenu) || action.Contains(ActionFilterPopup) || action.Contains(ActionShowFilterControl)
        || action.Contains(ActionCloseFilterControl)) return ASPxGridViewCallbackType.FilterEditing;
        if (action.Contains(ActionApplyFilter) || action.Contains(ActionApplyColumnFilter)) return ASPxGridViewCallbackType.ApplyFilter;
        if (action.Contains(ActionColumnMoved)) return ASPxGridViewCallbackType.ColumnMoved;
        if (action.Contains(ActionExpandGroup)) return ASPxGridViewCallbackType.ExpandGroup;
        if (action.Contains(ActionCollapseGroup)) return ASPxGridViewCallbackType.CollapseGroup;
        return ASPxGridViewCallbackType.Unknown;
    }

    #endregion

    #region Load data

    private void LoadVersions()
    {
        var list = entities.Versions.Where(x => x.Calculation == "BOTTOMUP" && x.Status != "APPROVED" && x.Active == true).OrderByDescending(x => x.VersionYear).OrderBy(x => x.VersionType).ToList();
        this.VersionGrid.DataSource = list;
        this.VersionGrid.DataBind();
    }

    private void LoadBackgroundJobs(decimal versionId)
    {
        var list = entities.BackgroundJobs.Where(x => x.VersionID == versionId).OrderByDescending(x => x.CreateDate).ToList();
        this.JobGrid.DataSource = list;
        this.JobGrid.DataBind();
    }
    private void LoadBackgroundJobDetails(decimal jobId)
    {
        var list = entities.AllocateJobParameters.Where(x => x.BackgroundJobID == jobId)
            .OrderBy(x => x.Id).ToList();
        this.JobDetailGrid.DataSource = list;
        this.JobDetailGrid.DataBind();
    }
    private void LoadCompanys()
    {
        var list = entities.DecCompanies.Where(x => x.CompanyType == "D")
          .OrderByDescending(x => x.OriArea).ThenBy(x => x.Seq).ToList();
        this.CompanyGrid.DataSource = list;
        this.CompanyGrid.DataBind();
    }
    #endregion
    protected void VersionGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {

    }

    protected void JobTypeEditor_Init(object sender, EventArgs e)
    {

    }

    protected void JobGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        if (args[0] == "LoadJobs")
        {
            decimal versionId;
            if (!decimal.TryParse(args[1], out versionId)) return;

            LoadBackgroundJobs(versionId);


        }

        if (args[0] == "CreateJob")
        {
            if (JobTypeEditor.Value.ToString().Equals("ALLOCATE"))
            {
                var exists = entities.BackgroundJobs
                    .Where(x => x.JobType == "ALLOCATE" && (x.Status == "QUEUED" || x.Status == "RUNNING"))
                    .Any();

                if (exists)
                {
                    new UserFriendlyMessage("Một tiến trình phân bổ đang được chạy", SessionUser.UserName, UserFriendlyMessage.MessageType.ERROR);
                    return;
                }
            }

            decimal versionId;
            if (!decimal.TryParse(args[1], out versionId))
                return;

            var version = entities.Versions.Where(x => x.VersionID == versionId).FirstOrDefault();
            if (version != null && version.Status == "APPROVED")
            {
                new UserFriendlyMessage("Version đã APPROVE, không thể chạy tạo Job cho version này", SessionUser.UserName, UserFriendlyMessage.MessageType.ERROR);
                return;
            }

            var selectedValues = CompanyGrid.GetSelectedFieldValues(new string[] { "CompanyID" });
            List<int?> companyIds = new List<int?>();
            foreach (var selectedValue in selectedValues)
            {
                companyIds.Add((int)selectedValue);
            }

            var fromMonth = Convert.ToInt32(FromMonthEditor.Value);
            var toMonth = Convert.ToInt32(ToMonthEditor.Value);

            var job = new KTQTData.BackgroundJob
            {
                VersionID = versionId,
                JobType = JobTypeEditor.Value.ToString(),
                IssueDate = ExecuteAtEditor.Date,
                Status = "QUEUED",
                CreateDate = DateTime.Now,
                CreatedBy = SessionUser.UserID
            };

            entities.BackgroundJobs.Add(job);

            entities.SaveChanges();

            string hfJobId = string.Empty;
            if (JobTypeEditor.Value.ToString().Equals("AUTOITEM"))
            {
                if (ExecuteTypeEditor.Value.ToString().Equals("Schedule"))
                    hfJobId = Hangfire.BackgroundJob.Schedule<BackgroundJobSchedule>(t => t.RunAutoItem(job.Id, versionId, companyIds, fromMonth, toMonth, SessionUser.UserID, SessionUser.UserName), TimeSpan.FromSeconds((job.IssueDate.Value - DateTime.Now).TotalSeconds));
                else
                    hfJobId = Hangfire.BackgroundJob.Enqueue<BackgroundJobSchedule>(t => t.RunAutoItem(job.Id, versionId, companyIds, fromMonth, toMonth, SessionUser.UserID, SessionUser.UserName));
            }
            if (JobTypeEditor.Value.ToString().Equals("ALLOCATE"))
            {
                if (ExecuteTypeEditor.Value.ToString().Equals("Schedule"))
                    hfJobId = Hangfire.BackgroundJob.Schedule<BackgroundJobSchedule>(t => t.RunAllocate(job.Id, versionId, companyIds, fromMonth, toMonth, SessionUser.UserID, SessionUser.UserName), TimeSpan.FromSeconds((job.IssueDate.Value - DateTime.Now).TotalSeconds));
                else
                    hfJobId = Hangfire.BackgroundJob.Enqueue<BackgroundJobSchedule>(t => t.RunAllocate(job.Id, versionId, companyIds, fromMonth, toMonth, SessionUser.UserID, SessionUser.UserName));
            }

            var addedJob = entities.BackgroundJobs.Where(x => x.Id == job.Id).FirstOrDefault();
            if (addedJob != null)
            {
                addedJob.HFJobId = hfJobId;
                entities.SaveChanges();
            }

            LoadBackgroundJobs(versionId);
        }

        if (args[0] == "StopJob")
        {
            decimal jobId;
            if (!decimal.TryParse(args[1], out jobId))
                return;

            var job = entities.BackgroundJobs.Where(x => x.Id == jobId).FirstOrDefault();
            if (job != null && job.Status != "FINISHED")
            {
                job.Status = "CANCELED";
                job.Remark = "The process is canceled or deleted by the user";
                entities.SaveChanges();

                try
                {
                    if (!string.IsNullOrEmpty(job.HFJobId))
                        Hangfire.BackgroundJob.Delete(job.HFJobId);

                    if (job.JobType == "ALLOCATE")
                        entities.sp_sp_stop_job("RunAllocate");
                }
                catch { }

                if (job.VersionID.HasValue)
                    LoadBackgroundJobs(job.VersionID.Value);
            }

        }
    }

    protected void JobDetailGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        if (args[0] == "LoadJobDetails")
        {
            decimal jobId;
            if (!decimal.TryParse(args[1], out jobId)) return;

            LoadBackgroundJobDetails(jobId);
        }
    }
}


