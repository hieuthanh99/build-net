using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_KhdtNam2019 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ASPxSpreadsheet1.Open(Server.MapPath("~/Templates/KHDT2019.xlsx"));
        }
    }


   
}