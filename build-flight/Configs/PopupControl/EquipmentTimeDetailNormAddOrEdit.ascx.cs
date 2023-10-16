using DevExpress.Web;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_PopupControl_EquipmentTimeDetailNormAddOrEdit : System.Web.UI.UserControl
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GroupEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        var ttbs = new string[] { "TTBTX", "TTBKTX" };
        var list = entities.DecTableValues
                            .Where(x => x.Tables == "ITEMMASTER" && x.Field == "GROUPITEM" && ttbs.Contains(x.DefValue))
                            .Select(x => new
                            {
                                DefValue = x.DefValue,
                                Description = x.Description
                            })
                            .ToList();

        cbo.DataSource = list;
        cbo.ValueField = "DefValue";
        cbo.TextField = "Description";
        cbo.DataBind();
    }
    protected void CodeEditor_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;

        var groupItem = e.Parameter;
        var list = entities.ItemMasters.Where(x => x.GroupItem == groupItem && (x.Active ?? false) == true).ToList();

        cbo.DataSource = list;
        cbo.ValueField = "ItemID";
        cbo.TextField = "Name";
        cbo.DataBind();
    }

}