using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_StoreSub12MonthSumUpArea : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            XtraReport report = new StoreSub12MonthSumUpArea();
            //report.Parameters["PVERSIONID"].Value = 4;
            //report.Parameters["P_TO_DATE"].Value = DateUtils.LastDayOfMonth(true);

            report.CreateDocument();
            ReportViewer.OpenReport(report);
        }
    }

}