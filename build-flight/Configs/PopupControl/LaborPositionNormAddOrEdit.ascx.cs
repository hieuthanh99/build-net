using DevExpress.Web;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_PopupControl_LaborPositionNormAddOrEdit : System.Web.UI.UserControl
{
    KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        var aDMPositionID = this.GetCallbackKeyValue("DMPositionID");

        var entity = entities.DM_LaborPosition
               .Include("DM_PositionGroup")
               .Where(x => x.DMPositionID == aDMPositionID)
               .SingleOrDefault();

        if (entity != null)
        {
            var aPositionGroupType = entity.DM_PositionGroup.PositionGroupType;

            if (Object.Equals(aPositionGroupType, "DB"))
            {
                ShiftNbrEditor.ClientEnabled = true;
                WorkTotalEditor.ClientEnabled = true;
            }
            else
            {
                ShiftNbrEditor.ClientEnabled = false;
                WorkTotalEditor.ClientEnabled = false;
            }
        }

    }
    protected void AreaCodeEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        var list = entities.Airports.Select(x => new { Code = x.Code.Trim(), NameV = x.NameV }).ToList();
        cbo.DataSource = list;
        cbo.ValueField = "Code";
        cbo.TextField = "NameV";
        cbo.DataBind();

    }

    private int GetCallbackKeyValue(string keyStr)
    {
        string result = null;
        if (Utils.TryGetClientStateValue<string>(this.Page, keyStr, out result))
            return Convert.ToInt32(result);
        return 0;
    }
}