using Hangfire;
using Hangfire.Client;
using Hangfire.Common;
using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PreventConcurrentExecutionJobFilter
/// </summary>
public class PreventConcurrentExecutionJobFilter : JobFilterAttribute, IClientFilter, IServerFilter
{
    public void OnCreating(CreatingContext filterContext)
    {
        var jobs = JobStorage.Current.GetMonitoringApi().ProcessingJobs(0, 100);
        if (jobs.Count(x => x.Value.Job.Type == filterContext.Job.Type && string.Join(".", x.Value.Job.Arguments) == string.Join(".", filterContext.Job.Arguments)) > 0)
        {
            filterContext.Canceled = true;
        }
    }

    public void OnPerformed(PerformedContext filterContext) { }

    void IClientFilter.OnCreated(CreatedContext filterContext) { }

    void IServerFilter.OnPerforming(PerformingContext filterContext) { }
}