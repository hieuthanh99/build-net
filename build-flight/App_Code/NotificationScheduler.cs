using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NotificationScheduler
/// </summary>
public class NotificationScheduler
{
    private const string ServiceName = "Notiffication_Service";
    public static async void Start()
    {
        // construct a scheduler factory
        NameValueCollection props = new NameValueCollection();
        props.Add(StdSchedulerFactory.PropertySchedulerInstanceName, "NotificationScheduler_Info");


        StdSchedulerFactory factory = new StdSchedulerFactory(props);

        // get a scheduler
        IScheduler sched = await factory.GetScheduler();
        await sched.Start();
        string JobName = "Job_" + ServiceName;
        // define the job and tie it to our HelloJob class
        IJobDetail job = JobBuilder.Create<NotificationJob>()
            .WithIdentity(JobName)
            .Build();

        // Trigger the job to run now, and then every xxx seconds
        ITrigger trigger = TriggerBuilder.Create()
        .WithIdentity("Trigger_Notification_Info")
        .StartNow()
        .WithCronSchedule("0 */5 * ? * *")
        .ForJob(JobName)
        .Build();

        await sched.ScheduleJob(job, trigger);
    }
}