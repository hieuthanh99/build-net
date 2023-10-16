using KTQTData;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReveneCostJob
/// </summary>
public class ReveneCostJob
{
    public ReveneCostJob()
    {
        //
        // TODO: Add constructor logic here
        //
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
    private string GetMessage(Exception ex)
    {
        if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
            return ex.InnerException.Message;

        return ex.Message;
    }
    [PreventConcurrentExecutionJobFilter]
    public void AutoAllItemExecute(long jobId, decimal aVersionID, int? userId, string userName)
    {
        using (var context = new KTQTDataEntities())
        {
            //var backgroundJob = context.BackgroundJobs.Where(x => x.Id == jobId).FirstOrDefault();
            //if (backgroundJob != null)
            //{
            try
            {
                //backgroundJob.StartTime = DateTime.Now;
                //backgroundJob.Status = "RUNNING";
                //context.SaveChanges();
                UpdateBackgroundJobStatus(jobId, "RUNNING", "");

                var stores = context.Stores.Where(x => x.VersionID == aVersionID && x.Calculation == "AUTO").ToList();

                foreach (var store in stores)
                {
                    //Lấy thông tin Job kiểm tra trạng thái
                    var backgroundJob = context.BackgroundJobs
                        .Where(x => x.Id == jobId)
                        .FirstOrDefault();

                    if (backgroundJob != null && (backgroundJob.Status == "CANCELED" || backgroundJob.Status == "DELETED"))
                        throw new Exception("The process is canceled or deleted by the user");

                    context.Auto_1Subaccount(store.VersionID, store.SubaccountID, store.CompanyID, store.StoreID, userId, 1, 12, "");
                }

                //backgroundJob.EndTime = DateTime.Now;
                //backgroundJob.Status = "FINISHED";
                //backgroundJob.Remark = "Success";
                //context.SaveChanges();
                UpdateBackgroundJobStatus(jobId, "FINISHED", "Success");

                new UserFriendlyMessage("Tiến trình tính chỉ tiêu AUTO đã thực hiện thành công.", userName, UserFriendlyMessage.MessageType.SUCCESS);

                //IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

                //var connectionIds = NotificationHub._users.Where(c => c.Value == userName);

                //foreach (KeyValuePair<string, string> connections in connectionIds)
                //{
                //    hubContext.Clients.Client(connections.Key).notify(userName, "Tiến trình tính chỉ tiêu AUTO đã thực hiện thành công.");
                //}
            }
            catch (Exception ex)
            {
                //backgroundJob.EndTime = DateTime.Now;
                //backgroundJob.Status = "FINISHED";
                //backgroundJob.Remark = ex.Message;
                //context.SaveChanges();
                UpdateBackgroundJobStatus(jobId, "FINISHED", GetMessage(ex));
                new UserFriendlyMessage(ex.Message, userName, UserFriendlyMessage.MessageType.ERROR);
            }
        }
        //}
    }


    [PreventConcurrentExecutionJobFilter]
    public void AutoAllItemExecute(long jobId, decimal aVersionID, int aCompanyID, int? userId, string userName)
    {
        using (var context = new KTQTDataEntities())
        {
            //var backgroundJob = context.BackgroundJobs.Where(x => x.Id == jobId).FirstOrDefault();
            //if (backgroundJob != null)
            //{
            try
            {
                //backgroundJob.StartTime = DateTime.Now;
                //backgroundJob.Status = "RUNNING";
                //context.SaveChanges();
                UpdateBackgroundJobStatus(jobId, "RUNNING", "");

                var stores = context.Stores.Where(x => x.VersionID == aVersionID && x.CompanyID == aCompanyID && x.Calculation == "AUTO").ToList();

                foreach (var store in stores)
                {
                    //Lấy thông tin Job kiểm tra trạng thái
                    var backgroundJob = context.BackgroundJobs
                        .Where(x => x.Id == jobId)
                        .FirstOrDefault();

                    if (backgroundJob != null && (backgroundJob.Status == "CANCELED" || backgroundJob.Status == "DELETED"))
                        throw new Exception("The process is canceled or deleted by the user");

                    context.Auto_1Subaccount(store.VersionID, store.SubaccountID, store.CompanyID, store.StoreID, userId, 1, 12, "");
                }

                //backgroundJob.EndTime = DateTime.Now;
                //backgroundJob.Status = "FINISHED";
                //backgroundJob.Remark = "Success";
                //context.SaveChanges();
                UpdateBackgroundJobStatus(jobId, "FINISHED", "Success");

                new UserFriendlyMessage("Tiến trình tính chỉ tiêu AUTO đã thực hiện thành công.", userName, UserFriendlyMessage.MessageType.SUCCESS);

                //IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

                //var connectionIds = NotificationHub._users.Where(c => c.Value == userName);

                //foreach (KeyValuePair<string, string> connections in connectionIds)
                //{
                //    hubContext.Clients.Client(connections.Key).notify(userName, "Tiến trình tính chỉ tiêu AUTO đã thực hiện thành công.");
                //}
            }
            catch (Exception ex)
            {
                //backgroundJob.EndTime = DateTime.Now;
                //backgroundJob.Status = "FINISHED";
                //backgroundJob.Remark = ex.Message;
                //context.SaveChanges();
                UpdateBackgroundJobStatus(jobId, "FINISHED", GetMessage(ex));
                new UserFriendlyMessage(ex.Message, userName, UserFriendlyMessage.MessageType.ERROR);
            }
        }
        //}
    }

    [PreventConcurrentExecutionJobFilter]
    public void AutoItemExecute(long jobId, decimal verCompanyID, decimal storeID, int? userId, string userName)
    {

        using (var context = new KTQTDataEntities())
        {
            //var backgroundJob = context.BackgroundJobs.Where(x => x.Id == jobId).FirstOrDefault();
            //if (backgroundJob != null)
            //{
            try
            {
                //backgroundJob.StartTime = DateTime.Now;
                //backgroundJob.Status = "RUNNING";
                //context.SaveChanges();
                UpdateBackgroundJobStatus(jobId, "RUNNING", "");

                var stores = context.Stores.Where(x => x.VerCompanyID == verCompanyID && x.StoreID == storeID && x.Calculation == "AUTO").ToList();

                foreach (var store in stores)
                {
                    context.Auto_1Subaccount(store.VersionID, store.SubaccountID, store.CompanyID, store.StoreID, userId, 1, 12, "");
                }

                //backgroundJob.EndTime = DateTime.Now;
                //backgroundJob.Status = "FINISHED";
                //backgroundJob.Remark = "Success";
                //context.SaveChanges();
                UpdateBackgroundJobStatus(jobId, "FINISHED", "Success");

                new UserFriendlyMessage("Tiến trình tính chỉ tiêu AUTO đã thực hiện thành công.", userName, UserFriendlyMessage.MessageType.SUCCESS);
                //IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

                //var connectionIds = NotificationHub._users.Where(c => c.Value == userName);

                //foreach (KeyValuePair<string, string> connections in connectionIds)
                //{
                //    hubContext.Clients.Client(connections.Key).notify(userName, "Tiến trình tính chỉ tiêu AUTO đã thực hiện thành công.");
                //}
            }
            catch (Exception ex)
            {
                //backgroundJob.EndTime = DateTime.Now;
                //backgroundJob.Status = "FINISHED";
                //backgroundJob.Remark = ex.Message;
                //context.SaveChanges();
                UpdateBackgroundJobStatus(jobId, "FINISHED", GetMessage(ex));
                new UserFriendlyMessage(ex.Message, userName, UserFriendlyMessage.MessageType.ERROR);
            }
            //}
        }

    }
}