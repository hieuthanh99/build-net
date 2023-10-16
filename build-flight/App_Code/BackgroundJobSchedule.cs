using Hangfire;
using KTQTData;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BackgroundJobSchedule
/// </summary>
public class BackgroundJobSchedule
{
    public BackgroundJobSchedule()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private AllocateJobParameter InsertJobParameters(long jobId, int fromMonth, int toMonth, VersionCompanyView row, string userName)
    {
        using (var context = new KTQTDataEntities())
        {
            var check = context.AllocateJobParameters
                .Where(x => x.BackgroundJobID == jobId && x.VersionID == row.VersionID && x.CompanyID == row.CompanyID).Any();
            if (!check)
            {
                var jobParam = new AllocateJobParameter();
                jobParam.BackgroundJobID = jobId;
                jobParam.AllocateType = 0;
                jobParam.AreaCode = row.AreaCode;
                jobParam.VersionID = row.VersionID;
                jobParam.VersionYear = row.VersionYear;
                jobParam.CompanyID = row.CompanyID;
                jobParam.FromMonth = fromMonth;
                jobParam.ToMonth = toMonth;
                jobParam.RunDate = DateTime.Now;
                //jobParam.RunBy = 0;
                jobParam.Status = "QUEUED";

                context.AllocateJobParameters.Add(jobParam);
                context.SaveChanges();

                return jobParam;
            }

            return null;
        }
    }

    private string GetMessage(Exception ex)
    {
        if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
            return ex.InnerException.Message;

        return ex.Message;
    }
    private void UpdateBackgroundJobStatus(long jobId, string status, string remark)
    {
        try
        {
            using (var context = new KTQTDataEntities())
            {
                var backgroundJob = context.BackgroundJobs.Where(x => x.Id == jobId).FirstOrDefault();
                if (backgroundJob != null)
                {
                    if (status == "FINISHED")
                        backgroundJob.EndTime = DateTime.Now;
                    else if (status == "RUNNING")
                        backgroundJob.StartTime = DateTime.Now;

                    backgroundJob.Status = status;
                    backgroundJob.Remark = remark;
                    context.SaveChanges();
                }
            }
        }
        catch (Exception ex)
        {
            //Common.writeLog("UpdateBackgroundJobStatus", ex.Message, true);
        }
    }

    private void UpdateJobParametersStatus(long paramId, string status, string mesage)
    {
        try
        {
            using (var context = new KTQTDataEntities())
            {
                var param = context.AllocateJobParameters.Where(x => x.Id == paramId).FirstOrDefault();
                if (param != null)
                {
                    if (status == "FINISHED")
                        param.FinishDate = DateTime.Now;
                    else if (status == "RUNNING")
                        param.RunDate = DateTime.Now;

                    param.Status = status;
                    param.Message = mesage;
                    context.SaveChanges();
                }
            }
        }
        catch (Exception ex)
        {
            //Common.writeLog("UpdateJobParametersStatus", ex.Message, true);
        }
    }

    [PreventConcurrentExecutionJobFilter()]
    public void RunAutoItem(long jobId, decimal versionId, List<int?> companyIds, int fromMonth, int toMonth, int? userId, string userName)
    {
        try
        {
            using (var context = new KTQTDataEntities())
            {
                //var backgroundJob = context.BackgroundJobs.Where(x => x.Id == jobId).FirstOrDefault();
                //if (backgroundJob != null)
                //{
                try
                {
                    UpdateBackgroundJobStatus(jobId, "RUNNING", "");
                    bool hasErrors = false;
                    string errorMessage = string.Empty;
                    var versionCompanyView = context.VersionCompanyViews
                           .Where(x => x.VersionID == versionId && x.CompanyType == "D" && companyIds.Contains(x.CompanyID)).ToList();

                    foreach (var versionCompany in versionCompanyView)
                    {
                        InsertJobParameters(jobId, fromMonth, toMonth, versionCompany, userName);
                    }

                    var jobParams = context.AllocateJobParameters.Where(x => x.BackgroundJobID == jobId).ToList();
                    foreach (var jobParam in jobParams)
                    {
                        //Lấy thông tin Job kiểm tra trạng thái
                        var backgroundJob = context.BackgroundJobs
                            .Where(x => x.Id == jobId)
                            .FirstOrDefault();

                        if (backgroundJob != null && (backgroundJob.Status == "CANCELED" || backgroundJob.Status == "DELETED"))
                            throw new Exception("The process is canceled or deleted by the user");

                        UpdateJobParametersStatus(jobParam.Id, "RUNNING", "");

                        try
                        {
                            var stores = context.Stores.Where(x => x.VersionID == jobParam.VersionID && x.CompanyID == jobParam.CompanyID && x.Calculation == "AUTO").ToList();

                            foreach (var store in stores)
                            {
                                context.Auto_1Subaccount(store.VersionID, store.SubaccountID, store.CompanyID, store.StoreID, userId, jobParam.FromMonth, jobParam.ToMonth, "");
                            }
                        }
                        catch (Exception ex)
                        {
                            hasErrors = true;
                            errorMessage = GetMessage(ex);
                            UpdateJobParametersStatus(jobParam.Id, "FINISHED", errorMessage);
                            //Common.writeLog("RunAutoItem", ex.Message, true);
                            continue;
                        }

                        UpdateJobParametersStatus(jobParam.Id, "FINISHED", "Success");

                    }

                    //var stores = context.Stores.Where(x => x.VersionID == versionId && companyIds.Contains(x.CompanyID) && x.Calculation == "AUTO").ToList();

                    //foreach (var store in stores)
                    //{
                    //    context.Auto_1Subaccount(store.VersionID, store.SubaccountID, store.CompanyID, store.StoreID, userId, fromMonth, toMonth, "");
                    //}

                    if (hasErrors)
                        UpdateBackgroundJobStatus(jobId, "FINISHED", errorMessage);
                    else
                        UpdateBackgroundJobStatus(jobId, "FINISHED", "Success");

                }
                catch (Exception ex)
                {
                    //Common.writeLog("RunAutoItem", ex.Message, true);
                    UpdateBackgroundJobStatus(jobId, "FINISHED", GetMessage(ex));
                }

                new UserFriendlyMessage("Tiến trình AUTO đã thực hiện thành công.", userName, UserFriendlyMessage.MessageType.SUCCESS);

                //IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

                //var connectionIds = NotificationHub._users.Where(c => c.Value == userName);

                //foreach (KeyValuePair<string, string> connections in connectionIds)
                //{
                //    hubContext.Clients.Client(connections.Key).notify(userName, "Tiến trình " + backgroundJob.JobType + " đã thực hiện thành công.");
                //}
            }
            //}
        }
        catch (Exception ex)
        {
            UpdateBackgroundJobStatus(jobId, "FINISHED", GetMessage(ex));
            new UserFriendlyMessage(ex.Message, userName, UserFriendlyMessage.MessageType.ERROR);
        }
    }

    public void RunAllocate(long jobId, decimal versionId, List<int?> companyIds, int fromMonth, int toMonth, int? userId, string userName)
    {
        try
        {
            using (var context = new KTQTDataEntities())
            {
                bool hasErrors = false;
                string errorMessage = string.Empty;

                try
                {
                    UpdateBackgroundJobStatus(jobId, "RUNNING", "");

                    var version = context.Versions.Where(x => x.VersionID == versionId).FirstOrDefault();

                    var versionCompanyView = context.VersionCompanyViews
                            .Where(x => x.VersionID == versionId && x.CompanyType == "D" && companyIds.Contains(x.CompanyID)).ToList();

                    foreach (var versionCompany in versionCompanyView)
                    {
                        //Lấy thông tin Job kiểm tra trạng thái
                        var backgroundJob = context.BackgroundJobs
                            .Where(x => x.Id == jobId)
                            .FirstOrDefault();

                        if (backgroundJob != null && (backgroundJob.Status == "CANCELED" || backgroundJob.Status == "DELETED"))
                            throw new Exception("The process is canceled or deleted by the user");

                        var jobParam = InsertJobParameters(jobId, fromMonth, toMonth, versionCompany, userName);

                        if (jobParam != null)
                        {
                            UpdateJobParametersStatus(jobParam.Id, "RUNNING", "");
                            try
                            {
                                var jobCompletionStatus = new ObjectParameter("JobCompletionStatus", 0);
                                context.sp_sp_start_job_wait("RunAllocate", DateTime.Now.Date.AddHours(0).AddMinutes(0).AddSeconds(5), jobCompletionStatus);
                                var value = (int)jobCompletionStatus.Value;
                            }
                            catch (Exception ex)
                            {
                                hasErrors = true;
                                errorMessage = GetMessage(ex);
                                UpdateJobParametersStatus(jobParam.Id, "FINISHED", GetMessage(ex));
                                //Common.writeLog("RunAllocate", ex.Message, true);
                                continue;
                            }

                            UpdateJobParametersStatus(jobParam.Id, "FINISHED", "Success");
                        }
                    }

                    if (hasErrors)
                        UpdateBackgroundJobStatus(jobId, "FINISHED", errorMessage);
                    else
                        UpdateBackgroundJobStatus(jobId, "FINISHED", "Success");

                }
                catch (Exception ex)
                {
                    UpdateBackgroundJobStatus(jobId, "FINISHED", GetMessage(ex));
                    // Common.writeLog("RunAllocate", ex.Message, true);
                }

                new UserFriendlyMessage("Tiến trình ALLOCATE đã được thực hiện.", userName, UserFriendlyMessage.MessageType.SUCCESS);

            }

        }
        catch (Exception ex)
        {
            UpdateBackgroundJobStatus(jobId, "FINISHED", GetMessage(ex));
            new UserFriendlyMessage(ex.Message, userName, UserFriendlyMessage.MessageType.ERROR);
        }

    }


}