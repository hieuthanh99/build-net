using Quartz;
using System;

/// <summary>
/// Summary description for NotificationJob
/// </summary>
public class NotificationJob : IJob
{
    public System.Threading.Tasks.Task Execute(IJobExecutionContext context)
    {
        throw new NotImplementedException();
    }
    System.Threading.Tasks.Task IJob.Execute(IJobExecutionContext context)
    {
        try
        {
            //do somthing here
        }
        catch (Exception ex)
        {
            Common.writeLog("IJob.Execute", ex.Message, true);
        }
        return System.Threading.Tasks.Task.CompletedTask;
    }




}