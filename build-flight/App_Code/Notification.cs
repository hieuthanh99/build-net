using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Message
/// </summary>
public class Notification
{
    public decimal id { get; set; }
    public string subject { get; set; }
    public string content { get; set; }
    public string membername { get; set; }
    public string receivename { get; set; }
    public string requesttime { get; set; }
    public string deadlinedate { get; set; }
}