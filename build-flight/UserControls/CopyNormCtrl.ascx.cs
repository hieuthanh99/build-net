using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_CopyNormCtrl : System.Web.UI.UserControl
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void LoadToNormYear(int FromNormYear)
    {
        var list = entities.DM_NormYears.Where(x => x.NormYearID != FromNormYear).ToList();

        cboToNormYear.DataSource = list;
        cboToNormYear.ValueField = "NormYearID";
        cboToNormYear.TextField = "Description";
        cboToNormYear.DataBind();
    }

    protected void cboFromNormYear_Init(object sender, EventArgs e)
    {
        if (Session[SessionConstant.NORMYEAR_LIST] != null)
        {
            cboFromNormYear.DataSource = (List<KTQTData.DM_NormYears>)Session[SessionConstant.NORMYEAR_LIST];
            cboFromNormYear.ValueField = "NormYearID";
            cboFromNormYear.TextField = "Description";
            cboFromNormYear.DataBind();
        }
        else
        {

            var list = entities.DM_NormYears.OrderByDescending(x => x.ForYear).ToList();

            Session[SessionConstant.NORMYEAR_LIST] = list;

            cboFromNormYear.DataSource = list;
            cboFromNormYear.ValueField = "NormYearID";
            cboFromNormYear.TextField = "Description";
            cboFromNormYear.DataBind();

        }
    }
    protected void cboToNormYear_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        var args = e.Parameter.Split('|');

        if (Object.Equals(args[0], "LOAD_TO_NORM"))
        {
            int aFromNormYearID;

            if (!int.TryParse(args[1], out aFromNormYearID))
                return;

            LoadToNormYear(aFromNormYearID);
        }
    }
}