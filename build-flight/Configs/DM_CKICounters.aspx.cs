using DevExpress.Web;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_DM_CKICounters : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsCallback || this.NormYearGrid.IsCallback)
            LoadNormYears();

        if (!this.IsCallback || this.CKICountersGrid.IsCallback)
            LoadAircraft(this.CKICountersGrid);

        if (!this.IsCallback || this.VNAACConfigGrid.IsCallback)
            LoadAircraft(this.VNAACConfigGrid);

        if (!this.IsCallback || this.CKICountersGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");
            LoadCKICounters(aNormYearID);
        }
        if (!this.IsCallback || this.CKIAverageTimeGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");
            LoadCKIAverageTime(aNormYearID);
        }

        if (!this.IsCallback || this.VNAACConfigGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");
            LoadVNAACConfigs(aNormYearID);
        }
    }

    #region Load Data

    private int GetCallbackKeyValue(string keyStr)
    {
        string result = null;
        if (Utils.TryGetClientStateValue<string>(this, keyStr, out result))
            return Convert.ToInt32(result);
        return 0;
    }


    private void LoadNormYears()
    {
        var list = entities.DM_NormYears
            .OrderByDescending(x => x.ForYear)
            .ToList();

        this.NormYearGrid.DataSource = list;
        this.NormYearGrid.DataBind();
    }


    private void LoadCKICounters(int NormYearID)
    {
        var list = entities.DM_CKICounters.Where(x => x.NormYearID == NormYearID).ToList();

        this.CKICountersGrid.DataSource = list;
        this.CKICountersGrid.DataBind();
    }


    private void LoadCKIAverageTime(int NormYearID)
    {
        var list = entities.DM_CKIAverageTime.Where(x => x.NormYearID == NormYearID).ToList();

        this.CKIAverageTimeGrid.DataSource = list;
        this.CKIAverageTimeGrid.DataBind();
    }

    private void LoadVNAACConfigs(int NormYearID)
    {
        var list = entities.DM_VNAACConfigs.Where(x => x.NormYearID == NormYearID).ToList();

        this.VNAACConfigGrid.DataSource = list;
        this.VNAACConfigGrid.DataBind();
    }


    private void LoadAircraft()
    {
        GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)CKICountersGrid.Columns["ACID"];

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

    private void LoadAircraft(ASPxGridView Grid)
    {
        GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)Grid.Columns["ACID"];

        if (Session[SessionConstant.AC_LIST] != null)
            aCombo.PropertiesComboBox.DataSource = Session[SessionConstant.AC_LIST];
        else
        {
            var list = entities.AircraftGroups
                .Select(x => new { ACGroup = x.ACGroup.Trim() })
                .OrderBy(x => x.ACGroup).ToList();
            Session[SessionConstant.AC_LIST] = list;
            aCombo.PropertiesComboBox.DataSource = list;
        }

        aCombo.PropertiesComboBox.ValueField = "ACGroup";
        aCombo.PropertiesComboBox.TextField = "ACGroup";
    }

    #endregion
    protected void CKICountersGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        decimal aCKICountersID;
        var aNormYearID = this.GetCallbackKeyValue("NormYearID");

        if (args[0] == "DELETE_CKI_COUNTERS")
        {
            if (!decimal.TryParse(args[0], out aCKICountersID))
                return;

            var entity = entities.DM_CKICounters.SingleOrDefault(x => x.CKICountersID == aCKICountersID);

            if (entity != null)
            {
                aNormYearID = entity.NormYearID;
                entities.DM_CKICounters.Remove(entity);

                entities.SaveChanges();

                LoadCKICounters(aNormYearID);
            }
        }
    }
    protected void CKIAverageTimeGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        int aCKIAvgTimeID;
        var aNormYearID = this.GetCallbackKeyValue("NormYearID");

        if (args[0] == "DELETE_CKI_AVG_TIME")
        {
            if (!int.TryParse(args[0], out aCKIAvgTimeID))
                return;

            var entity = entities.DM_CKIAverageTime.SingleOrDefault(x => x.CKIAvgTimeID == aCKIAvgTimeID);

            if (entity != null)
            {
                aNormYearID = entity.NormYearID;
                entities.DM_CKIAverageTime.Remove(entity);

                entities.SaveChanges();

                LoadCKIAverageTime(aNormYearID);
            }
        }
    }
    protected void VNAACConfigGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        int aVNAACConfigID;
        var aNormYearID = this.GetCallbackKeyValue("NormYearID");

        if (args[0] == "DELETE_VNA_AC_CONFIG")
        {
            if (!int.TryParse(args[0], out aVNAACConfigID))
                return;

            var entity = entities.DM_VNAACConfigs.SingleOrDefault(x => x.VNAACConfigID == aVNAACConfigID);

            if (entity != null)
            {
                aNormYearID = entity.NormYearID;
                entities.DM_VNAACConfigs.Remove(entity);

                entities.SaveChanges();

                LoadVNAACConfigs(aNormYearID);
            }
        }

    }
    protected void CKICountersGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;

        try
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");

            foreach (ASPxDataInsertValues insValues in e.InsertValues)
            {
                var entity = new DM_CKICounters();
                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;

                entity.NormYearID = aNormYearID;

                if (insValues.NewValues["ACType"] != null)
                {
                    string aACType = insValues.NewValues["ACType"].ToString();
                    entity.ACType = aACType;
                }

                if (insValues.NewValues["ACID"] != null)
                {
                    string aACID = insValues.NewValues["ACID"].ToString();
                    entity.ACID = aACID;
                }

                if (insValues.NewValues["PaxFC"] != null)
                {
                    int aPaxFC = Convert.ToInt32(insValues.NewValues["PaxFC"].ToString());
                    entity.PaxFC = aPaxFC;
                }

                if (insValues.NewValues["PaxY"] != null)
                {
                    int aPaxY = Convert.ToInt32(insValues.NewValues["PaxY"].ToString());
                    entity.PaxY = aPaxY;
                }

                entity.TotalPax = entity.PaxFC + entity.PaxY;

                if (insValues.NewValues["MaxCountersPaxFC"] != null)
                {
                    int aMaxCountersPaxFC = Convert.ToInt32(insValues.NewValues["MaxCountersPaxFC"].ToString());
                    entity.MaxCountersPaxFC = aMaxCountersPaxFC;
                }

                if (insValues.NewValues["MaxCountersPaxY"] != null)
                {
                    int aMaxCountersPaxY = Convert.ToInt32(insValues.NewValues["MaxCountersPaxY"].ToString());
                    entity.MaxCountersPaxY = aMaxCountersPaxY;
                }

                entity.TotalMaxCounters = entity.MaxCountersPaxFC + entity.MaxCountersPaxY;

                if (insValues.NewValues["MinCountersPaxFC"] != null)
                {
                    int aMinCountersPaxFC = Convert.ToInt32(insValues.NewValues["MinCountersPaxFC"].ToString());
                    entity.MinCountersPaxFC = aMinCountersPaxFC;
                }

                if (insValues.NewValues["MinCountersPaxY"] != null)
                {
                    int aMinCountersPaxY = Convert.ToInt32(insValues.NewValues["MinCountersPaxY"].ToString());
                    entity.MinCountersPaxY = aMinCountersPaxY;
                }

                entity.TotalMinCounters = entity.MinCountersPaxFC + entity.MinCountersPaxY;

                if (insValues.NewValues["Description"] != null)
                {
                    string aDescription = insValues.NewValues["Description"].ToString();
                    entity.Description = aDescription;
                }

                entities.DM_CKICounters.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aCKICountersID = Convert.ToDecimal(updValues.Keys["CKICountersID"]);
                var entity = entities.DM_CKICounters.SingleOrDefault(x => x.CKICountersID == aCKICountersID);
                if (entity != null)
                {

                    if (updValues.NewValues["ACType"] != null)
                    {
                        string aACType = updValues.NewValues["ACType"].ToString();
                        entity.ACType = aACType;
                    }

                    if (updValues.NewValues["ACID"] != null)
                    {
                        string aACID = updValues.NewValues["ACID"].ToString();
                        entity.ACID = aACID;
                    }

                    if (updValues.NewValues["PaxFC"] != null)
                    {
                        int aPaxFC = Convert.ToInt32(updValues.NewValues["PaxFC"].ToString());
                        entity.PaxFC = aPaxFC;
                    }

                    if (updValues.NewValues["PaxY"] != null)
                    {
                        int aPaxY = Convert.ToInt32(updValues.NewValues["PaxY"].ToString());
                        entity.PaxY = aPaxY;
                    }

                    entity.TotalPax = entity.PaxFC + entity.PaxY;

                    if (updValues.NewValues["MaxCountersPaxFC"] != null)
                    {
                        int aMaxCountersPaxFC = Convert.ToInt32(updValues.NewValues["MaxCountersPaxFC"].ToString());
                        entity.MaxCountersPaxFC = aMaxCountersPaxFC;
                    }

                    if (updValues.NewValues["MaxCountersPaxY"] != null)
                    {
                        int aMaxCountersPaxY = Convert.ToInt32(updValues.NewValues["MaxCountersPaxY"].ToString());
                        entity.MaxCountersPaxY = aMaxCountersPaxY;
                    }

                    entity.TotalMaxCounters = entity.MaxCountersPaxFC + entity.MaxCountersPaxY;

                    if (updValues.NewValues["MinCountersPaxFC"] != null)
                    {
                        int aMinCountersPaxFC = Convert.ToInt32(updValues.NewValues["MinCountersPaxFC"].ToString());
                        entity.MinCountersPaxFC = aMinCountersPaxFC;
                    }

                    if (updValues.NewValues["MinCountersPaxY"] != null)
                    {
                        int aMinCountersPaxY = Convert.ToInt32(updValues.NewValues["MinCountersPaxY"].ToString());
                        entity.MinCountersPaxY = aMinCountersPaxY;
                    }

                    entity.TotalMinCounters = entity.MinCountersPaxFC + entity.MinCountersPaxY;

                    if (updValues.NewValues["Description"] != null)
                    {
                        string aDescription = updValues.NewValues["Description"].ToString();
                        entity.Description = aDescription;
                    }
                }
            }
            foreach (ASPxDataDeleteValues delValues in e.DeleteValues)
            {
                decimal aCKICountersID = Convert.ToDecimal(delValues.Keys["CKICountersID"]);
                var entity = entities.DM_CKICounters.SingleOrDefault(x => x.CKICountersID == aCKICountersID);
                if (entity != null)
                {
                    entities.DM_CKICounters.Remove(entity);
                }
            }

            entities.SaveChanges();


        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
    protected void CKIAverageTimeGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;

        try
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");

            foreach (ASPxDataInsertValues insValues in e.InsertValues)
            {
                var entity = new DM_CKIAverageTime();
                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;

                entity.NormYearID = aNormYearID;

                if (insValues.NewValues["AreaCode"] != null)
                {
                    string aAreaCode = insValues.NewValues["AreaCode"].ToString();
                    entity.AreaCode = aAreaCode;
                }

                if (insValues.NewValues["PaxCTotalSample"] != null)
                {
                    int aPaxCTotalSample = Convert.ToInt32(insValues.NewValues["PaxCTotalSample"].ToString());
                    entity.PaxCTotalSample = aPaxCTotalSample;
                }

                if (insValues.NewValues["PaxCAvgTime"] != null)
                {
                    int aPaxCAvgTime = Convert.ToInt32(insValues.NewValues["PaxCAvgTime"].ToString());
                    entity.PaxCAvgTime = aPaxCAvgTime;
                }

                if (insValues.NewValues["PaxYTotalSample"] != null)
                {
                    int aPaxYTotalSample = Convert.ToInt32(insValues.NewValues["PaxYTotalSample"].ToString());
                    entity.PaxYTotalSample = aPaxYTotalSample;
                }

                if (insValues.NewValues["PaxYAvgTime"] != null)
                {
                    int aPaxYAvgTime = Convert.ToInt32(insValues.NewValues["PaxYAvgTime"].ToString());
                    entity.PaxYAvgTime = aPaxYAvgTime;
                }


                if (insValues.NewValues["Description"] != null)
                {
                    string aDescription = insValues.NewValues["Description"].ToString();
                    entity.Description = aDescription;
                }

                entities.DM_CKIAverageTime.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aCKIAvgTimeID = Convert.ToDecimal(updValues.Keys["CKIAvgTimeID"]);
                var entity = entities.DM_CKIAverageTime.SingleOrDefault(x => x.CKIAvgTimeID == aCKIAvgTimeID);
                if (entity != null)
                {
                    if (updValues.NewValues["AreaCode"] != null)
                    {
                        string aAreaCode = updValues.NewValues["AreaCode"].ToString();
                        entity.AreaCode = aAreaCode;
                    }

                    if (updValues.NewValues["PaxCTotalSample"] != null)
                    {
                        int aPaxCTotalSample = Convert.ToInt32(updValues.NewValues["PaxCTotalSample"].ToString());
                        entity.PaxCTotalSample = aPaxCTotalSample;
                    }

                    if (updValues.NewValues["PaxCAvgTime"] != null)
                    {
                        int aPaxCAvgTime = Convert.ToInt32(updValues.NewValues["PaxCAvgTime"].ToString());
                        entity.PaxCAvgTime = aPaxCAvgTime;
                    }

                    if (updValues.NewValues["PaxYTotalSample"] != null)
                    {
                        int aPaxYTotalSample = Convert.ToInt32(updValues.NewValues["PaxYTotalSample"].ToString());
                        entity.PaxYTotalSample = aPaxYTotalSample;
                    }

                    if (updValues.NewValues["PaxYAvgTime"] != null)
                    {
                        int aPaxYAvgTime = Convert.ToInt32(updValues.NewValues["PaxYAvgTime"].ToString());
                        entity.PaxYAvgTime = aPaxYAvgTime;
                    }

                    if (updValues.NewValues["Description"] != null)
                    {
                        string aDescription = updValues.NewValues["Description"].ToString();
                        entity.Description = aDescription;
                    }
                }
            }
            foreach (ASPxDataDeleteValues delValues in e.DeleteValues)
            {
                decimal aCKIAvgTimeID = Convert.ToDecimal(delValues.Keys["CKIAvgTimeID"]);
                var entity = entities.DM_CKIAverageTime.SingleOrDefault(x => x.CKIAvgTimeID == aCKIAvgTimeID);
                if (entity != null)
                {
                    entities.DM_CKIAverageTime.Remove(entity);
                }
            }

            entities.SaveChanges();


        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
    protected void VNAACConfigGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;

        try
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");

            foreach (ASPxDataInsertValues insValues in e.InsertValues)
            {
                var entity = new DM_VNAACConfigs();
                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;
                entity.NormYearID = aNormYearID;

                if (insValues.NewValues["ACID"] != null)
                {
                    string aACID = insValues.NewValues["ACID"].ToString();
                    entity.ACID = aACID;
                }

                if (insValues.NewValues["PaxC"] != null)
                {
                    int aPaxC = Convert.ToInt32(insValues.NewValues["PaxC"].ToString());
                    entity.PaxC = aPaxC;
                }

                if (insValues.NewValues["PaxY"] != null)
                {
                    int aPaxY = Convert.ToInt32(insValues.NewValues["PaxY"].ToString());
                    entity.PaxY = aPaxY;
                }

                entity.TotalPax = entity.PaxC + entity.PaxY;

                if (insValues.NewValues["Description"] != null)
                {
                    string aDescription = insValues.NewValues["Description"].ToString();
                    entity.Description = aDescription;
                }

                entities.DM_VNAACConfigs.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aVNAACConfigID = Convert.ToDecimal(updValues.Keys["VNAACConfigID"]);
                var entity = entities.DM_VNAACConfigs.SingleOrDefault(x => x.VNAACConfigID == aVNAACConfigID);
                if (entity != null)
                {

                    if (updValues.NewValues["ACID"] != null)
                    {
                        string aACID = updValues.NewValues["ACID"].ToString();
                        entity.ACID = aACID;
                    }

                    if (updValues.NewValues["PaxC"] != null)
                    {
                        int aPaxC = Convert.ToInt32(updValues.NewValues["PaxC"].ToString());
                        entity.PaxC = aPaxC;
                    }

                    if (updValues.NewValues["PaxY"] != null)
                    {
                        int aPaxY = Convert.ToInt32(updValues.NewValues["PaxY"].ToString());
                        entity.PaxY = aPaxY;
                    }

                    entity.TotalPax = entity.PaxC + entity.PaxY;

                    if (updValues.NewValues["Description"] != null)
                    {
                        string aDescription = updValues.NewValues["Description"].ToString();
                        entity.Description = aDescription;
                    }
                }
            }
            foreach (ASPxDataDeleteValues delValues in e.DeleteValues)
            {
                decimal aVNAACConfigID = Convert.ToDecimal(delValues.Keys["VNAACConfigID"]);
                var entity = entities.DM_VNAACConfigs.SingleOrDefault(x => x.VNAACConfigID == aVNAACConfigID);
                if (entity != null)
                {
                    entities.DM_VNAACConfigs.Remove(entity);
                }
            }

            entities.SaveChanges();


        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
}