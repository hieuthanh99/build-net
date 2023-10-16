using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_FlsOpsStoreView : System.Web.UI.UserControl
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack || this.FltOpsGrid.IsCallback)
        {
            string result = null;
            if (Utils.TryGetClientStateValue<string>(this.Page, "StoreID", out result))
            {
                var storeID = Convert.ToDecimal(result);
                LoadFltOpsStore(storeID);
            }
        }
        if (!IsPostBack || this.StoreAllocateLogGrid.IsCallback)
        {
            string result = null;
            if (Utils.TryGetClientStateValue<string>(this.Page, "StoreID", out result))
            {
                var storeID = Convert.ToDecimal(result);
                LoadStoreAllocateLog(storeID);
            }
        }
        if (!IsPostBack || this.StoreErrorListGrid.IsCallback)
        {
            string result = null;
            if (Utils.TryGetClientStateValue<string>(this.Page, "StoreID", out result))
            {
                var storeID = Convert.ToDecimal(result);
                LoadStoreErrorLists(storeID);
            }
        }
    }

    #region Load data

    private void LoadFltOpsStore(decimal storeID)
    {        
        //var list = entities.VW_FLT_OPS_STORE.Where(x => x.StoreID == storeID).ToList();
        //this.FltOpsGrid.DataSource = list;
        //this.FltOpsGrid.DataBind();
    }

    private void LoadStoreAllocateLog(decimal storeID)
    {
        var list = entities.StoreAllocateLogs.Where(x => x.StoreID == storeID).OrderBy(x => x.LogID).ToList();
        this.StoreAllocateLogGrid.DataSource = list;
        this.StoreAllocateLogGrid.DataBind();
    }

    private void LoadStoreErrorLists(decimal storeID)
    {
        var list = entities.StoreErrorLists.Where(x => x.StoreID == storeID).ToList();
        this.StoreErrorListGrid.DataSource = list;
        this.StoreErrorListGrid.DataBind();
    }

    #endregion Load data
    protected void FltOpsGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
    }
}