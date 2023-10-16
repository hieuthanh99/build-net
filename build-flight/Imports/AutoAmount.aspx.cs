using DevExpress.Web;
using KTQTData;
using System;
using System.Linq;
using Hangfire;

public partial class Imports_AutoAmount : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadVersions();
        }
    }

    #region Load data

    private void LoadVersions()
    {
        var list = entities.Versions.Where(x => x.Calculation == "BOTTOMUP" && x.Status != "APPROVED").OrderByDescending(x => x.VersionYear).OrderBy(x => x.Sorting).ToList();
        this.VersionGrid.DataSource = list;
        this.VersionGrid.DataBind();
    }

    private void LoadBackgroundJobs(decimal versionId)
    {
        var list = entities.BackgroundJobs.Where(x => x.VersionID == versionId).OrderByDescending(x => x.CreateDate).ToList();
        this.JobGrid.DataSource = list;
        this.JobGrid.DataBind();
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
            decimal versionId;
            if (!decimal.TryParse(args[1], out versionId)) return;

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

            entities.SaveChangesWithAuditLogs();

            //Hangfire.BackgroundJob.Enqueue<BgJob>(t => t.RunAutoItem(job.Id, versionId, SessionUser.UserID));

            Hangfire.BackgroundJob.Schedule<BgJob>(t => t.RunAutoItem(job.Id, versionId, SessionUser.UserID), TimeSpan.FromSeconds((job.IssueDate.Value - DateTime.Now).TotalSeconds));

            LoadBackgroundJobs(versionId);
        }
    }
}


public class BgJob
{
    public BgJob() { }

    public void RunAutoItem(long jobId, decimal versionId, int? userId)
    {
        using (var context = new KTQTDataEntities())
        {
            var backgroundJob = context.BackgroundJobs.Where(x => x.Id == jobId).FirstOrDefault();
            if (backgroundJob != null)
            {
                backgroundJob.StartTime = DateTime.Now;
                backgroundJob.Status = "RUNNING";
                context.SaveChangesWithAuditLogs();

                var stores = context.Stores.Where(x => x.VersionID == versionId && x.Calculation == "AUTO").ToList();

                foreach (var store in stores)
                {
                    context.Auto_1Subaccount(store.VersionID, store.SubaccountID, store.CompanyID, store.StoreID, userId, 1, 12, "");
                }

                backgroundJob.EndTime = DateTime.Now;
                backgroundJob.Status = "FINISHED";
                context.SaveChangesWithAuditLogs();
            }
        }
    }


}