using DevExpress.Web;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_DM_ACConfigs : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadAreaLOV();

        LoadCarrierLOV();

        LoadAcIDLOV();

        LoadFltTypeLOV();

        if (!this.IsCallback || this.DataGrid.IsCallback)
            LoadACConfigs();

        if (!this.IsCallback || this.CountersGrid.IsCallback)
        {
            var aACConfigID = this.GetCallbackIntKeyValue("ACConfigID");
            LoadACCounters(aACConfigID);
        }

        if (!this.IsCallback || this.LOVCountersGrid.IsCallback)
        {
            var aACConfigID = this.GetCallbackIntKeyValue("ACConfigID");
            LoadLOVCounters(aACConfigID);
        }
    }

    #region Load Data

    private int GetCallbackIntKeyValue(string keyStr)
    {
        string result = null;
        if (Utils.TryGetClientStateValue<string>(this, keyStr, out result))
            return Convert.ToInt32(result);
        return 0;
    }

    private void LoadACConfigs()
    {
        var list = entities.DM_ACConfigs
            .OrderByDescending(x => x.AreaCode)
            .ThenBy(x => x.Carrier)
            .ThenBy(x => x.AcID)
            .ThenBy(x => x.Network)
            .ToList();

        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }

    private void LoadACCounters(int ACConfigID)
    {
        var list = entities.DM_ACCounters
            .Where(x => x.ACConfigID == ACConfigID)
            .ToList();

        this.CountersGrid.DataSource = list;
        this.CountersGrid.DataBind();
    }

    private void LoadAreaLOV()
    {
        try
        {
            GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)DataGrid.Columns["AreaCode"];

            aCombo.PropertiesComboBox.Items.Clear();
            if (Session[SessionConstant.AREA_LIST] != null)
                aCombo.PropertiesComboBox.DataSource = Session[SessionConstant.AREA_LIST];
            else
            {
                var list = entities.Airports.Where(x => x.IsCity == true).ToList();
                Session[SessionConstant.AREA_LIST] = list;
                aCombo.PropertiesComboBox.DataSource = list;
            }

            aCombo.PropertiesComboBox.ValueField = "Code";
            aCombo.PropertiesComboBox.TextField = "Code";
        }
        catch { }
    }

    private void LoadCarrierLOV()
    {
        try
        {
            GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)DataGrid.Columns["Carrier"];

            aCombo.PropertiesComboBox.Items.Clear();
            if (Session[SessionConstant.CARRIER_LIST] != null)
                aCombo.PropertiesComboBox.DataSource = Session[SessionConstant.CARRIER_LIST];
            else
            {
                var list = entities.Code_Airlines
                    .Select(x => new { AirlinesCode = x.AirlinesCode.Trim() })
                    .OrderBy(x => x.AirlinesCode).ToList();
                Session[SessionConstant.CARRIER_LIST] = list;
                aCombo.PropertiesComboBox.DataSource = list;
            }

            aCombo.PropertiesComboBox.ValueField = "AirlinesCode";
            aCombo.PropertiesComboBox.TextField = "AirlinesCode";
        }
        catch { }
    }

    private void LoadAcIDLOV()
    {
        try
        {
            GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)DataGrid.Columns["AcID"];

            aCombo.PropertiesComboBox.Items.Clear();
            if (Session[SessionConstant.AC_LIST] != null)
                aCombo.PropertiesComboBox.DataSource = Session[SessionConstant.AC_LIST];
            else
            {
                var list = entities.AcGroupConverts
                    .Select(x => new { ACGroup = x.AcGroup.Trim() })
                    .Distinct()
                    .OrderBy(x => x.ACGroup).ToList();
                Session[SessionConstant.AC_LIST] = list;
                aCombo.PropertiesComboBox.DataSource = list;
            }

            aCombo.PropertiesComboBox.ValueField = "ACGroup";
            aCombo.PropertiesComboBox.TextField = "ACGroup";
        }
        catch { }
    }

    private void LoadFltTypeLOV()
    {
        try
        {
            GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)DataGrid.Columns["FltType"];

            aCombo.PropertiesComboBox.Items.Clear();
            if (Session[SessionConstant.FLT_TYPE] != null)
                aCombo.PropertiesComboBox.DataSource = Session[SessionConstant.FLT_TYPE];
            else
            {
                var list = entities.DecTableValues
                         .Where(x => x.Tables == "FLT_OPS" && x.Field == "FLT_TYPE")
                         .Select(x => new { DefValue = x.DefValue, Description = x.DefValue + "-" + x.Description })
                         .ToList();
                Session[SessionConstant.FLT_TYPE] = list;
                aCombo.PropertiesComboBox.DataSource = list;
            }

            aCombo.PropertiesComboBox.ValueField = "DefValue";
            aCombo.PropertiesComboBox.TextField = "DefValue";
        }
        catch { }
    }

    #endregion
    protected void DataGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            foreach (ASPxDataInsertValues insValues in e.InsertValues)
            {
                var entity = new DM_ACConfigs();

                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;

                if (insValues.NewValues["AreaCode"] != null)
                {
                    string aAreaCode = insValues.NewValues["AreaCode"].ToString();
                    entity.AreaCode = aAreaCode;
                }

                if (insValues.NewValues["Carrier"] != null)
                {
                    string aCarrier = insValues.NewValues["Carrier"].ToString();
                    entity.Carrier = aCarrier;
                }

                if (insValues.NewValues["Network"] != null)
                {
                    string aNetwork = insValues.NewValues["Network"].ToString();
                    entity.Network = aNetwork;
                }

                if (insValues.NewValues["AcID"] != null)
                {
                    string aAcID = insValues.NewValues["AcID"].ToString();
                    entity.AcID = aAcID;
                }

                if (insValues.NewValues["FltType"] != null)
                {
                    string aFltType = insValues.NewValues["FltType"].ToString();
                    entity.FltType = aFltType;
                }

                if (insValues.NewValues["PaxF"] != null)
                {
                    int aPaxF = Convert.ToInt32(insValues.NewValues["PaxF"]);
                    entity.PaxF = aPaxF;
                }

                if (insValues.NewValues["PaxC"] != null)
                {
                    int aPaxC = Convert.ToInt32(insValues.NewValues["PaxC"]);
                    entity.PaxC = aPaxC;
                }

                if (insValues.NewValues["PaxY"] != null)
                {
                    int aPaxY = Convert.ToInt32(insValues.NewValues["PaxY"]);
                    entity.PaxY = aPaxY;
                }

                if (insValues.NewValues["CountersNbr"] != null)
                {
                    int aCountersNbr = Convert.ToInt32(insValues.NewValues["CountersNbr"]);
                    entity.CountersNbr = aCountersNbr;
                }

                if (insValues.NewValues["CountersMin"] != null)
                {
                    int aCountersMin = Convert.ToInt32(insValues.NewValues["CountersMin"]);
                    entity.CountersMin = aCountersMin;
                }

                if (insValues.NewValues["CountersMax"] != null)
                {
                    int aCountersMax = Convert.ToInt32(insValues.NewValues["CountersMax"]);
                    entity.CountersMax = aCountersMax;
                }

                if (insValues.NewValues["CommonCKI"] != null)
                {
                    decimal aCommonCKI = Convert.ToDecimal(insValues.NewValues["CommonCKI"]);
                    entity.CommonCKI = aCommonCKI;
                }

                if (insValues.NewValues["Description"] != null)
                {
                    string aDescription = insValues.NewValues["Description"].ToString();
                    entity.Description = aDescription;
                }

                if (insValues.NewValues["Inactive"] != null)
                {
                    bool aInactive = Convert.ToBoolean(insValues.NewValues["Inactive"]);
                    entity.Inactive = aInactive;
                }

                entities.DM_ACConfigs.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aACConfigID = Convert.ToDecimal(updValues.Keys["ACConfigID"]);
                var entity = entities.DM_ACConfigs.SingleOrDefault(x => x.ACConfigID == aACConfigID);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["AreaCode"] != null)
                    {
                        string aAreaCode = updValues.NewValues["AreaCode"].ToString();
                        entity.AreaCode = aAreaCode;
                    }

                    if (updValues.NewValues["Carrier"] != null)
                    {
                        string aCarrier = updValues.NewValues["Carrier"].ToString();
                        entity.Carrier = aCarrier;
                    }

                    if (updValues.NewValues["Network"] != null)
                    {
                        string aNetwork = updValues.NewValues["Network"].ToString();
                        entity.Network = aNetwork;
                    }

                    if (updValues.NewValues["AcID"] != null)
                    {
                        string aAcID = updValues.NewValues["AcID"].ToString();
                        entity.AcID = aAcID;
                    }

                    if (updValues.NewValues["FltType"] != null)
                    {
                        string aFltType = updValues.NewValues["FltType"].ToString();
                        entity.FltType = aFltType;
                    }

                    if (updValues.NewValues["PaxF"] != null)
                    {
                        int aPaxF = Convert.ToInt32(updValues.NewValues["PaxF"]);
                        entity.PaxF = aPaxF;
                    }

                    if (updValues.NewValues["PaxC"] != null)
                    {
                        int aPaxC = Convert.ToInt32(updValues.NewValues["PaxC"]);
                        entity.PaxC = aPaxC;
                    }

                    if (updValues.NewValues["PaxY"] != null)
                    {
                        int aPaxY = Convert.ToInt32(updValues.NewValues["PaxY"]);
                        entity.PaxY = aPaxY;
                    }

                    if (updValues.NewValues["CountersNbr"] != null)
                    {
                        int aCountersNbr = Convert.ToInt32(updValues.NewValues["CountersNbr"]);
                        entity.CountersNbr = aCountersNbr;
                    }

                    if (updValues.NewValues["CountersMin"] != null)
                    {
                        int aCountersMin = Convert.ToInt32(updValues.NewValues["CountersMin"]);
                        entity.CountersMin = aCountersMin;
                    }

                    if (updValues.NewValues["CountersMax"] != null)
                    {
                        int aCountersMax = Convert.ToInt32(updValues.NewValues["CountersMax"]);
                        entity.CountersMax = aCountersMax;
                    }

                    if (updValues.NewValues["CommonCKI"] != null)
                    {
                        decimal aCommonCKI = Convert.ToDecimal(updValues.NewValues["CommonCKI"]);
                        entity.CommonCKI = aCommonCKI;
                    }

                    if (updValues.NewValues["Description"] != null)
                    {
                        string aDescription = updValues.NewValues["Description"].ToString();
                        entity.Description = aDescription;
                    }

                    if (updValues.NewValues["Inactive"] != null)
                    {
                        bool aInactive = Convert.ToBoolean(updValues.NewValues["Inactive"]);
                        entity.Inactive = aInactive;
                    }

                }
            }
            entities.SaveChanges();

            LoadACConfigs();
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        int aACConfigID;

        if (Object.Equals(args[0], "DELETE"))
        {
            if (!int.TryParse(args[1], out aACConfigID))
                return;

            var entity = entities.DM_ACConfigs.SingleOrDefault(x => x.ACConfigID == aACConfigID);
            if (entity != null)
            {
                entities.DM_ACConfigs.Remove(entity);

                entities.SaveChanges();
            }
            LoadACConfigs();
        }

    }

    private string GetCounterDescription(string CounterType)
    {
        var aDescription = entities.DecTableValues
                  .Where(x => x.Tables == "DM_COUNTERSUNITPRICE" && x.Field == "COUNTERSTYPE"
                      && x.DefValue == CounterType).Select(x => x.Description).SingleOrDefault();

        return aDescription;

    }

    protected void CountersGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        int aACConfigID = 0;

        if (Object.Equals(args[0], "LOAD_COUNTER"))
        {

            if (!int.TryParse(args[1], out aACConfigID))
                return;


            SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@pACConfigID", aACConfigID),              
                        new SqlParameter("@pUserID", SessionUser.UserID)
                };

            entities.Database.ExecuteSqlCommand(DbHelper.GenerateCommandText("[KTQT_Data].[dbo].[PrcInitACCounters]", parameters), parameters);


            LoadACCounters(aACConfigID);
        }

        if (Object.Equals(args[0], "ADD_COUNTERS"))
        {
            if (!int.TryParse(args[1], out aACConfigID))
                return;

            string[] counterKeys;

            if (!TryParseKeyValues(args.Skip(2), out counterKeys))
                return;

            foreach (string key in counterKeys)
            {

                var entity = new DM_ACCounters()
                {
                    ACConfigID = aACConfigID,
                    CounterType = key,
                    CounterNbr = 1,
                    Description = GetCounterDescription(key),
                    CreateDate = DateTime.Now,
                    CreatedBy = (int)SessionUser.UserID
                };

                entities.DM_ACCounters.Add(entity);
            }
            entities.SaveChanges();

            LoadACCounters(aACConfigID);
        }

        if (Object.Equals(args[0], "DELETE"))
        {
            decimal aACCounterID;
            if (!decimal.TryParse(args[1], out aACCounterID))
                return;

            var entity = entities.DM_ACCounters.SingleOrDefault(x => x.ACCounterID == aACCounterID);
            if (entity != null)
            {
                aACConfigID = entity.ACConfigID;
                entities.DM_ACCounters.Remove(entity);

                entities.SaveChanges();
            }


            LoadACCounters(aACConfigID);
        }
    }
    protected void CountersGrid_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aACCounterID = Convert.ToDecimal(updValues.Keys["ACCounterID"]);
                var entity = entities.DM_ACCounters.SingleOrDefault(x => x.ACCounterID == aACCounterID);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["UnitOfMeasure"] != null)
                    {
                        string aUnitOfMeasure =updValues.NewValues["UnitOfMeasure"].ToString();
                        entity.UnitOfMeasure = aUnitOfMeasure;
                    }

                    if (updValues.NewValues["CounterNbr"] != null)
                    {
                        int aCountersNbr = Convert.ToInt32(updValues.NewValues["CounterNbr"]);
                        entity.CounterNbr = aCountersNbr;
                    }

                }
            }
            entities.SaveChanges();

            LoadACConfigs();
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
    protected void LOVCountersGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        int aACConfigID;
        if (args[0] == "LOAD_COUNTERS")
        {
            if (!int.TryParse(args[1], out aACConfigID))
                return;

            LoadLOVCounters(aACConfigID);

        }


    }

    private void LoadLOVCounters(int aACConfigID)
    {

        var list = entities.DecTableValues
                      .Where(x => x.Tables == "DM_COUNTERSUNITPRICE" && x.Field == "COUNTERSTYPE"
                          && !entities.DM_ACCounters.Where(a => a.ACConfigID == aACConfigID).Select(a => a.CounterType).Contains(x.DefValue))
                      .Select(x => new { CounterType = x.DefValue, Description = x.Description })
                      .ToList();


        this.LOVCountersGrid.DataSource = list;
        this.LOVCountersGrid.DataBind();
    }

    protected bool TryParseKeyValues(IEnumerable<string> stringKeys, out string[] resultKeys)
    {
        resultKeys = null;
        var list = new List<string>();
        foreach (var sKey in stringKeys)
        {
            list.Add(sKey);
        }
        resultKeys = list.ToArray();
        return true;
    }
}