using DevExpress.Web;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_PopupControl_EquipmentTimeNormAddOrEdit : System.Web.UI.UserControl
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void AreaEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        var list = entities.Airports.Select(x => new { Code = x.Code.Trim(), NameV = x.NameV }).ToList();

        cbo.DataSource = list;
        cbo.ValueField = "Code";
        cbo.TextField = "NameV";
        cbo.DataBind();
    }
    protected void CarrierEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        var list = entities.Code_Airlines.Select(x => new { AirlinesCode = x.AirlinesCode.Trim() }).ToList();

        cbo.DataSource = list;
        cbo.ValueField = "AirlinesCode";
        cbo.TextField = "AirlinesCode";
        cbo.DataBind();

    }
    protected void AircraftEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        var list = entities.AcGroupConverts.Select(x => new { ACGroup = x.AcGroup.Trim() }).Distinct().ToList();

        cbo.DataSource = list;
        cbo.ValueField = "ACGroup";
        cbo.TextField = "ACGroup";
        cbo.DataBind();
    }
}