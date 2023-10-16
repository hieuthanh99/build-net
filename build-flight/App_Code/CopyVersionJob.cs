using KTQTData;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CopyVersionJob
/// </summary>
public class CopyVersionJob
{
    public CopyVersionJob()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void SyncData(double pmsVersionId, string userName)
    {
        try
        {
            using (var context = new KTQTDataEntities())
            {
                context.Sync_1PMSVersion(pmsVersionId);
            }
            new UserFriendlyMessage("Đồng bộ dữ liệu từ PMS thành công.", userName, UserFriendlyMessage.MessageType.SUCCESS);

        }
        catch (Exception ex)
        {
            new UserFriendlyMessage("Đồng bộ dữ liệu PMS lỗi: " + ex.Message, userName, UserFriendlyMessage.MessageType.ERROR);
        }
    }
    [PreventConcurrentExecutionJobFilter]
    public void Execute(long jobId, decimal srcVersionId, decimal desVersionId, int? userId)
    {
        using (var context = new KTQTDataEntities())
        {
            var backgroundJob = context.BackgroundJobs.Where(x => x.Id == jobId).FirstOrDefault();
            if (backgroundJob != null)
            {
                backgroundJob.StartTime = DateTime.Now;
                backgroundJob.Status = "RUNNING";
                context.SaveChanges();

                var newCopyLog = new CopyVersionLog
                {
                    BackgroundJobID = jobId,
                    FromVersionID = srcVersionId,
                    ToVersionID = desVersionId,
                    Status = "QUEUED",
                    CreateDate = DateTime.Now,
                    CreatedBy = userId,
                    Remark = ""
                };
                context.CopyVersionLogs.Add(newCopyLog);
                context.SaveChanges();

                var key = newCopyLog.Id;
                var hasError = false;
                var errMessage = "";

                try
                {
                    var jobCompletionStatus = new ObjectParameter("JobCompletionStatus", 0);
                    context.sp_sp_start_job_wait("RunCopyVersion", DateTime.Now.Date.AddHours(0).AddMinutes(0).AddSeconds(5), jobCompletionStatus);
                    var value = (int)jobCompletionStatus.Value;
                }
                catch (Exception ex)
                {
                    hasError = true;
                    errMessage = ex.Message;
                }

                if (hasError)
                    UpdateCopyVersionLogs(context, key, errMessage);
                else
                    UpdateCopyVersionLogs(context, key, "Success");

                backgroundJob.EndTime = DateTime.Now;
                backgroundJob.Status = "FINISHED";
                backgroundJob.Remark = hasError ? errMessage : "Success";
                context.SaveChanges();
            }
        }
    }

    private static void UpdateCopyVersionLogs(KTQTDataEntities context, int key, string message)
    {
        var log = context.CopyVersionLogs.Where(x => x.Id == key).FirstOrDefault();
        if (log != null)
        {
            log.Status = "FINISHED";
            log.Remark = message;
            context.SaveChanges();
        }
    }
}