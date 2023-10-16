using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_ExportTemplateStoreCompany : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            XtraReport report = new ExportTemplateStoreCompany();

            report.CreateDocument();
            ReportViewer.OpenReport(report);
        }
    }

}