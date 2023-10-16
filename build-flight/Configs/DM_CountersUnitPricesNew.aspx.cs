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

public partial class Configs_DM_CountersUnitPricesNew : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.seCalcUnitPriceFromMonth.Value = DateUtils.FirstDayOfMonth(true).Month;
            this.seCalcUnitPriceToMonth.Value = DateUtils.FirstDayOfMonth(true).Month;
        }

        if (!this.IsCallback || this.NormYearGrid.IsCallback)
            LoadNormYears();

        LoadLOVCountersType();

        if (!this.IsCallback || this.MasterGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackIntKeyValue("NormYearID");
            LoadCounterTypes(aNormYearID);
        }

        if (!this.IsCallback || this.CountersCostGrid.IsCallback)
        {
            var aCounterTypeID = this.GetCallbackKeyValue("CounterTypeID");
            var aVersionID = this.GetCallbackKeyValue("VersionID");
            LoadCountersCost(aCounterTypeID, aVersionID);
        }

        if (!this.IsCallback || this.CarrierUsageRateGrid.IsCallback)
        {
            var aCarrierCounterID = this.GetCallbackKeyValue("CarrierCounterID");
            var aVersionID = this.GetCallbackKeyValue("VersionID");
            LoadCarrierCounterUsages(aCarrierCounterID, aVersionID);
        }

        if (!this.IsCallback || this.CarrierGrid.IsCallback)
        {
            var aCounterTypeID = this.GetCallbackKeyValue("CounterTypeID");

            LoadCarrier(aCounterTypeID);
        }

        if (!this.IsCallback || this.UnitPriceGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackIntKeyValue("NormYearID");
            LoadLOVVersion(aNormYearID);

            var aCarrierCounterID = this.GetCallbackKeyValue("CarrierCounterID");
            var aVersionID = this.GetCallbackKeyValue("VersionID");

            LoadUnitPrice(aCarrierCounterID, aVersionID);

        }


        if (!this.IsCallback || this.LOVCarrierGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackIntKeyValue("NormYearID");
            var aCounterTypeID = this.GetCallbackKeyValue("CounterTypeID");

            LoadLOVCarrier(aNormYearID, aCounterTypeID);
        }
    }

    #region Load data
    private void LoadNormYears()
    {
        var list = entities.DM_NormYears
            .OrderByDescending(x => x.ForYear)
            .ToList();

        this.NormYearGrid.DataSource = list;
        this.NormYearGrid.DataBind();
    }

    private int GetCallbackIntKeyValue(string keyStr)
    {
        string result = null;
        if (Utils.TryGetClientStateValue<string>(this, keyStr, out result))
            return Convert.ToInt32(result);
        return 0;
    }

    private decimal GetCallbackKeyValue(string keyStr)
    {
        if (string.IsNullOrEmpty(keyStr))
            return decimal.Zero;

        string result = null;
        if (Utils.TryGetClientStateValue<string>(this, keyStr, out result))
            return Convert.ToDecimal(result);
        return decimal.Zero;
    }

    private void LoadCounterTypes(int pNormYearID)
    {
        string aAreaCode = SessionUser.AreaCode;

        if (Object.Equals(aAreaCode, "KCQ"))
            aAreaCode = "ALL";

        var list = entities.DM_CountersTypes
            .Where(x => x.NormYearID == pNormYearID && ((x.AreaCode == aAreaCode) || aAreaCode == "ALL"))
            .OrderByDescending(x => x.AreaCode)
            .ThenBy(x => x.RentalType)
            .ToList();

        this.MasterGrid.DataSource = list;
        this.MasterGrid.DataBind();
    }

    private void LoadCountersCost(decimal pCounterTypeID, decimal pVersionID)
    {
        var list = entities.DM_CountersCosts
            .Where(x => x.CounterTypeID == pCounterTypeID && x.VersionID == pVersionID)
            .OrderBy(x => x.ForMonth)
            .ToList();

        this.CountersCostGrid.DataSource = list;
        this.CountersCostGrid.DataBind();
    }

    private void LoadCarrierCounterUsages(decimal pCarrierCounterID, decimal pVersionID)
    {
        var list = entities.DM_CarrierCounterUsages
            .Where(x => x.CarrierCounterID == pCarrierCounterID && x.VersionID == pVersionID)
            .OrderBy(x => x.ForMonth)
            .ToList();

        this.CarrierUsageRateGrid.DataSource = list;
        this.CarrierUsageRateGrid.DataBind();
    }

    private void LoadUnitPrice(decimal pCarrierCounterID, decimal pVersionID)
    {
        var list = entities.DM_CountersUnitPrices
            .Where(x => x.CarrierCounterID == pCarrierCounterID && x.VersionID == pVersionID)
            .OrderBy(x => x.Carrier)
            .ThenBy(x => x.ForMonth)
            .ToList();

        this.UnitPriceGrid.DataSource = list;
        this.UnitPriceGrid.DataBind();

    }

    private void LoadCarrier(decimal pCounterTypeID)
    {
        var list = entities.DM_CarrierCounters
            .Where(x => x.CounterTypeID == pCounterTypeID)
            .OrderByDescending(x => x.AreaCode)
            .ThenBy(x => x.Carrier)
            .ToList();

        this.CarrierGrid.DataSource = list;
        this.CarrierGrid.DataBind();

    }

    private void LoadLOVCarrier(int pNormYearID, decimal pCounterTypeID)
    {
        var aAreaCode = "ALL";
        var aCountersType = entities.DM_CountersTypes.SingleOrDefault(x => x.CounterTypeID == pCounterTypeID);

        if (aCountersType != null)
            aAreaCode = aCountersType.AreaCode;

        var list = entities.DM_ACConfigs
            .Where(x => x.AreaCode == aAreaCode && !entities.DM_CarrierCounters
                                .Where(c => c.NormYearID == pNormYearID && c.CounterTypeID == pCounterTypeID)
                                .Select(c => c.AreaCode + c.Carrier)
                                .Contains(x.AreaCode + x.Carrier))

            .Select(x => new { AreaCode = x.AreaCode, Carrier = x.Carrier })
            .Distinct()
            .OrderBy(x => x.AreaCode).ThenBy(x => x.Carrier)
            .ToList();

        this.LOVCarrierGrid.DataSource = list;
        this.LOVCarrierGrid.DataBind();
    }

    private void LoadLOVCountersType()
    {
        try
        {
            GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)MasterGrid.Columns["CountersType"];

            aCombo.PropertiesComboBox.Items.Clear();
            if (Session[SessionConstant.COUNTERS_TYPE] != null)
                aCombo.PropertiesComboBox.DataSource = Session[SessionConstant.COUNTERS_TYPE];
            else
            {
                var list = entities.DecTableValues
                    .Where(x => x.Tables == "DM_COUNTERSUNITPRICE" && x.Field == "COUNTERSTYPE")
                    .Select(x => new
                    {
                        DefValue = x.DefValue,
                        Description = x.Description,
                        Sort = x.Sort
                    })
                    .OrderBy(x => x.Sort)
                    .ToList();
                Session[SessionConstant.COUNTERS_TYPE] = list;
                aCombo.PropertiesComboBox.DataSource = list;
            }

            aCombo.PropertiesComboBox.ValueField = "DefValue";
            aCombo.PropertiesComboBox.TextField = "Description";
        }
        catch { }
    }

    private void LoadLOVVersion(int NormYearID)
    {
        try
        {
            GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)UnitPriceGrid.Columns["VersionID"];

            aCombo.PropertiesComboBox.Items.Clear();

            var aNormYear = entities.DM_NormYears.SingleOrDefault(x => x.NormYearID == NormYearID);

            var list = entities.Versions
             .Where(x => x.VersionYear == aNormYear.ForYear && (x.Active ?? false) == true)
             .OrderBy(x => x.VersionType).ToList();


            aCombo.PropertiesComboBox.DataSource = list;


            aCombo.PropertiesComboBox.ValueField = "VersionID";
            aCombo.PropertiesComboBox.TextField = "Description";
        }
        catch { }

    }
    #endregion
    protected void MasterGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        decimal aCounterTypeID;

        var aNormYearID = this.GetCallbackIntKeyValue("NormYearID");

        if (args[0] == "DELETE_MASTER_ROW")
        {
            if (!decimal.TryParse(args[1], out aCounterTypeID))
                return;

            var entity = entities.DM_CountersTypes.SingleOrDefault(x => x.CounterTypeID == aCounterTypeID);
            if (entity != null)
            {
                aNormYearID = entity.NormYearID.Value;

                entities.DM_CountersTypes.Remove(entity);

                entities.SaveChanges();
            }

            LoadCounterTypes(aNormYearID);
        }



    }
    protected void MasterGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            var aNormYearID = this.GetCallbackIntKeyValue("NormYearID");

            foreach (ASPxDataInsertValues insValues in e.InsertValues)
            {
                var entity = new DM_CountersTypes();
                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;

                entity.NormYearID = aNormYearID;

                if (insValues.NewValues["CountersType"] != null)
                {
                    string aCountersType = insValues.NewValues["CountersType"].ToString();
                    entity.CountersType = aCountersType;
                }

                //if (insValues.NewValues["RentalType"] != null)
                //{
                //    string aRentalType = insValues.NewValues["RentalType"].ToString();
                //    entity.RentalType = aRentalType;
                //}

                if (insValues.NewValues["AreaCode"] != null)
                {
                    string aAreaCode = insValues.NewValues["AreaCode"].ToString();
                    entity.AreaCode = aAreaCode;
                }

                if (insValues.NewValues["Network"] != null)
                {
                    string aNetwork = insValues.NewValues["Network"].ToString();
                    entity.Network = aNetwork;
                }

                //if (insValues.NewValues["UnitOfMeasure"] != null)
                //{
                //    string aUnitOfMeasure = insValues.NewValues["UnitOfMeasure"].ToString();
                //    entity.UnitOfMeasure = aUnitOfMeasure;
                //}

                //if (insValues.NewValues["Quantity"] != null)
                //{
                //    int aQuantity = Convert.ToInt32(insValues.NewValues["Quantity"]);
                //    entity.Quantity = aQuantity;
                //}

                //if (insValues.NewValues["Amount"] != null)
                //{
                //    decimal aAmount = Convert.ToDecimal(insValues.NewValues["Amount"]);
                //    entity.Amount = aAmount;
                //}

                //if (insValues.NewValues["CurrencyCode"] != null)
                //{
                //    string aCurrencyCode = insValues.NewValues["CurrencyCode"].ToString();
                //    entity.CurrencyCode = aCurrencyCode;
                //}

                if (insValues.NewValues["Description"] != null)
                {
                    string aDescription = insValues.NewValues["Description"].ToString();
                    entity.Description = aDescription;
                }

                entities.DM_CountersTypes.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aCounterTypeID = Convert.ToDecimal(updValues.Keys["CounterTypeID"]);
                var entity = entities.DM_CountersTypes.SingleOrDefault(x => x.CounterTypeID == aCounterTypeID);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["CountersType"] != null)
                    {
                        string aCountersType = updValues.NewValues["CountersType"].ToString();
                        entity.CountersType = aCountersType;
                    }

                    if (updValues.NewValues["AreaCode"] != null)
                    {
                        string aAreaCode = updValues.NewValues["AreaCode"].ToString();
                        entity.AreaCode = aAreaCode;
                    }

                    //if (updValues.NewValues["RentalType"] != null)
                    //{
                    //    string aRentalType = updValues.NewValues["RentalType"].ToString();
                    //    entity.RentalType = aRentalType;
                    //}

                    if (updValues.NewValues["Network"] != null)
                    {
                        string aNetwork = updValues.NewValues["Network"].ToString();
                        entity.Network = aNetwork;
                    }

                    //if (updValues.NewValues["UnitOfMeasure"] != null)
                    //{
                    //    string aUnitOfMeasure = updValues.NewValues["UnitOfMeasure"].ToString();
                    //    entity.UnitOfMeasure = aUnitOfMeasure;
                    //}

                    //if (updValues.NewValues["Quantity"] != null)
                    //{
                    //    int aQuantity = Convert.ToInt32(updValues.NewValues["Quantity"]);
                    //    entity.Quantity = aQuantity;
                    //}

                    //if (updValues.NewValues["Amount"] != null)
                    //{
                    //    decimal aAmount = Convert.ToDecimal(updValues.NewValues["Amount"]);
                    //    entity.Amount = aAmount;
                    //}

                    //if (updValues.NewValues["CurrencyCode"] != null)
                    //{
                    //    string aCurrencyCode = updValues.NewValues["CurrencyCode"].ToString();
                    //    entity.CurrencyCode = aCurrencyCode;
                    //}

                    if (updValues.NewValues["Description"] != null)
                    {
                        string aDescription = updValues.NewValues["Description"].ToString();
                        entity.Description = aDescription;
                    }
                    else
                        entity.Description = null;

                }
            }
            entities.SaveChanges();

            LoadCounterTypes(aNormYearID);
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
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

    protected bool TryParseKeyValues(IEnumerable<string> stringKeys, out decimal[] resultKeys)
    {
        resultKeys = null;
        var list = new List<decimal>();
        foreach (var sKey in stringKeys)
        {
            decimal key;
            if (!decimal.TryParse(sKey, out key))
                return false;

            list.Add(key);
        }
        resultKeys = list.ToArray();
        return true;
    }

    protected void CarrierGrid_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            var aNormYearID = this.GetCallbackIntKeyValue("NormYearID");
            var aCounterTypeID = this.GetCallbackKeyValue("CounterTypeID");

            foreach (ASPxDataInsertValues insValues in e.InsertValues)
            {
                var entity = new DM_CarrierCounters();
                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;

                entity.NormYearID = aNormYearID;
                entity.CounterTypeID = aCounterTypeID;

                if (insValues.NewValues["Carrier"] != null)
                {
                    string aCarrier = insValues.NewValues["Carrier"].ToString();
                    entity.Carrier = aCarrier;
                }

                if (insValues.NewValues["UsageRate"] != null)
                {
                    decimal aUsageRate = Convert.ToDecimal(insValues.NewValues["UsageRate"]);
                    entity.UsageRate = aUsageRate;
                }

                if (insValues.NewValues["Description"] != null)
                {
                    string aDescription = insValues.NewValues["Description"].ToString();
                    entity.Description = aDescription;
                }

                entities.DM_CarrierCounters.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aCarrierCounterID = Convert.ToDecimal(updValues.Keys["CarrierCounterID"]);
                var entity = entities.DM_CarrierCounters.SingleOrDefault(x => x.CarrierCounterID == aCarrierCounterID);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["Carrier"] != null)
                    {
                        string aCarrier = updValues.NewValues["Carrier"].ToString();
                        entity.Carrier = aCarrier;
                    }

                    if (updValues.NewValues["UsageRate"] != null)
                    {
                        decimal aUsageRate = Convert.ToDecimal(updValues.NewValues["UsageRate"]);
                        entity.UsageRate = aUsageRate;
                    }

                    if (updValues.NewValues["Description"] != null)
                    {
                        string aDescription = updValues.NewValues["Description"].ToString();
                        entity.Description = aDescription;
                    }

                }
            }
            entities.SaveChanges();

            LoadCarrier(aCounterTypeID);
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
    protected void CarrierGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split(';');

        decimal aCounterTypeID = decimal.Zero;
        var aNormYearID = this.GetCallbackIntKeyValue("NormYearID");

        if (args[0] == "ADD_CARRIER")
        {
            string[] carrierKeys = null;

            if (!decimal.TryParse(args[1], out aCounterTypeID))
                return;

            if (!int.TryParse(args[2], out aNormYearID))
                return;


            if (!TryParseKeyValues(args.Skip(3), out carrierKeys))
                return;

            var keyPairs = carrierKeys[0].Split(',');

            foreach (string keyPair in keyPairs)
            {
                var aAreaCode = keyPair.Split('|')[0];
                var aCarrier = keyPair.Split('|')[1];

                var entity = new DM_CarrierCounters()
                {
                    CounterTypeID = aCounterTypeID,
                    NormYearID = aNormYearID,
                    Carrier = aCarrier,
                    AreaCode = aAreaCode,
                    UsageRate = 100,
                    Description = string.Empty,
                    CreateDate = DateTime.Now,
                    CreatedBy = (int)SessionUser.UserID
                };

                entities.DM_CarrierCounters.Add(entity);
            }
            entities.SaveChanges();


            LoadCarrier(aCounterTypeID);
        }


        if (args[0] == "REMOVE_CARRIER")
        {
            aCounterTypeID = this.GetCallbackKeyValue("CounterTypeID");

            decimal[] aCarrierCounterKeys;

            if (!TryParseKeyValues(args.Skip(1), out aCarrierCounterKeys))
                return;

            entities.DM_CarrierCounters.RemoveRange(entities.DM_CarrierCounters.Where(c => aCarrierCounterKeys.Contains(c.CarrierCounterID)));

            entities.SaveChanges();

            LoadCarrier(aCounterTypeID);
        }
    }
    protected void UnitPriceGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {

        var args = e.Parameters.Split('|');

        var aCarrierCounterID = this.GetCallbackKeyValue("CarrierCounterID");
        var aVersionID = this.GetCallbackKeyValue("VersionID");

        decimal aUnitPriceID;
        if (args[0] == "DELETE_UNIT_PRICE")
        {
            if (!decimal.TryParse(args[1], out aUnitPriceID))
                return;

            var entity = entities.DM_CountersUnitPrices.SingleOrDefault(x => x.UnitPriceID == aUnitPriceID);
            if (entity != null)
            {
                aVersionID = entity.VersionID;
                entities.DM_CountersUnitPrices.Remove(entity);

                entities.SaveChanges();
            }

            LoadUnitPrice(aCarrierCounterID, aVersionID);
        }

        if (args[0] == "CALC_UNIT")
        {
            int aNormYearID;
            if (!int.TryParse(args[1], out aNormYearID))
                return;

            try
            {
                aVersionID = Convert.ToDecimal(cboCalcUnitPriceVersion.Value);
                string aAreaCode = cboCalcUnitPriceArea.Value.ToString();
                int aFromMonth = Convert.ToInt32(seCalcUnitPriceFromMonth.Number);
                int aToMonth = Convert.ToInt32(seCalcUnitPriceToMonth.Number);

                var aNormYear = entities.DM_NormYears.SingleOrDefault(x => x.NormYearID == aNormYearID).ForYear;

                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@pNormYearID", aNormYearID),
                        new SqlParameter("@pVersionID", aVersionID),
                        new SqlParameter("@pAreaCode", aAreaCode),
                        new SqlParameter("@pForYear", aNormYear),
                        new SqlParameter("@pFromMonth", aFromMonth),
                        new SqlParameter("@pToMonth", aToMonth),
                        new SqlParameter("@pUserID", SessionUser.UserID)
                };

                entities.Database.ExecuteSqlCommand(DbHelper.GenerateCommandText("[KTQT_Data].[dbo].[PrcCalcCountersUnitPriceNew]", parameters), parameters);
                //entities.Database.ExecuteSqlCommand("EXEC [KTQT_Data].[dbo].[PrcCalcCountersUnitPrice] @pNormYearID, @pVersionID, @pAreaCode, @pForYear, @pFromMonth, @pToMonth, @pUserID", parameters);
                //entities.PrcCalcCountersUnitPrice(aNormYearID, aVersionID, aAreaCode, aNormYear, aFromMonth, aToMonth, SessionUser.UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            LoadUnitPrice(aCarrierCounterID, aVersionID);
        }

    }


    protected void UnitPriceGrid_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            var aCarrierCounterID = this.GetCallbackKeyValue("CarrierCounterID");

            var aVersionID = this.GetCallbackKeyValue("VersionID");

            foreach (ASPxDataInsertValues insValues in e.InsertValues)
            {
                var entity = new DM_CountersUnitPrices();
                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;

                entity.CarrierCounterID = aCarrierCounterID;

                if (insValues.NewValues["EffectiveDateFrom"] != null)
                {
                    DateTime aEffectiveDateFrom = Convert.ToDateTime(insValues.NewValues["EffectiveDateFrom"]);
                    entity.EffectiveDateFrom = aEffectiveDateFrom;
                }

                if (insValues.NewValues["EffectiveDateTo"] != null)
                {
                    DateTime aEffectiveDateTo = Convert.ToDateTime(insValues.NewValues["EffectiveDateTo"]);
                    entity.EffectiveDateTo = aEffectiveDateTo;
                }

                if (insValues.NewValues["Quantity"] != null)
                {
                    int aQuantity = Convert.ToInt32(insValues.NewValues["Quantity"]);
                    entity.Quantity = aQuantity;
                }

                if (insValues.NewValues["UnitPrice"] != null)
                {
                    decimal aUnitPrice = Convert.ToDecimal(insValues.NewValues["UnitPrice"]);
                    entity.UnitPrice = aUnitPrice;
                }

                if (insValues.NewValues["CurrencyCode"] != null)
                {
                    string aCurrencyCode = insValues.NewValues["CurrencyCode"].ToString();
                    entity.CurrencyCode = aCurrencyCode;
                }

                if (insValues.NewValues["DiscountPercent"] != null)
                {
                    decimal aUnitPrice = Convert.ToDecimal(insValues.NewValues["DiscountPercent"]);
                    entity.DiscountPercent = aUnitPrice;
                }

                if (insValues.NewValues["Description"] != null)
                {
                    string aDescription = insValues.NewValues["Description"].ToString();
                    entity.Description = aDescription;
                }

                entities.DM_CountersUnitPrices.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aUnitPriceID = Convert.ToDecimal(updValues.Keys["UnitPriceID"]);
                var entity = entities.DM_CountersUnitPrices.SingleOrDefault(x => x.UnitPriceID == aUnitPriceID);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["EffectiveDateFrom"] != null)
                    {
                        DateTime aEffectiveDateFrom = Convert.ToDateTime(updValues.NewValues["EffectiveDateFrom"]);
                        entity.EffectiveDateFrom = aEffectiveDateFrom;
                    }

                    if (updValues.NewValues["EffectiveDateTo"] != null)
                    {
                        DateTime aEffectiveDateTo = Convert.ToDateTime(updValues.NewValues["EffectiveDateTo"]);
                        entity.EffectiveDateTo = aEffectiveDateTo;
                    }

                    if (updValues.NewValues["Quantity"] != null)
                    {
                        int aQuantity = Convert.ToInt32(updValues.NewValues["Quantity"]);
                        entity.Quantity = aQuantity;
                    }

                    if (updValues.NewValues["UnitPrice"] != null)
                    {
                        decimal aUnitPrice = Convert.ToDecimal(updValues.NewValues["UnitPrice"]);
                        entity.UnitPrice = aUnitPrice;
                    }

                    if (updValues.NewValues["CurrencyCode"] != null)
                    {
                        string aCurrencyCode = updValues.NewValues["CurrencyCode"].ToString();
                        entity.CurrencyCode = aCurrencyCode;
                    }

                    if (updValues.NewValues["DiscountPercent"] != null)
                    {
                        decimal aUnitPrice = Convert.ToDecimal(updValues.NewValues["DiscountPercent"]);
                        entity.DiscountPercent = aUnitPrice;
                    }

                    if (updValues.NewValues["Description"] != null)
                    {
                        string aDescription = updValues.NewValues["Description"].ToString();
                        entity.Description = aDescription;
                    }

                }
            }
            entities.SaveChanges();

            LoadUnitPrice(aCarrierCounterID, aVersionID);
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
    protected void LOVCarrierGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        if (args[0] == "LOAD_CARRIER")
        {

        }
    }

    protected void cboCalcUnitPriceVersion_Callback(object sender, CallbackEventArgsBase e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;

        var args = e.Parameter.Split('|');

        if (args[0] == "LOAD_VERSION")
        {
            int aNormYearID;
            if (!int.TryParse(args[1], out aNormYearID))
                return;

            var aNormYear = entities.DM_NormYears.SingleOrDefault(x => x.NormYearID == aNormYearID);

            if (aNormYear != null)
            {
                var list = entities.Versions.Where(x => x.VersionYear == aNormYear.ForYear && x.UsedStatus == "USED").ToList();

                cbo.DataSource = list;
                cbo.ValueField = "VersionID";
                cbo.TextField = "Description";
                cbo.DataBind();

                if (cbo.Items.Count > 0)
                    cbo.SelectedItem = cbo.Items.FindByValue(Convert.ToInt32(cboQuantityVersion.Value));
            }
        }
    }
    protected void UnitPriceGrid_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
    {
        var Grid = (sender as ASPxGridView);

        if (e.Column.FieldName == "VersionName")
        {
            var entity = Grid.GetRow(e.VisibleIndex) as DM_CountersUnitPrices;
            if (entity == null) return;
            var aDescription = entity.Version.Description;

            e.EncodeHtml = false;
            e.DisplayText = aDescription;

        }
    }
    protected void cboCalcUnitPriceArea_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Airports.Where(x => (x.IsCity ?? false) == true).ToList();

        ListEditItem le = new ListEditItem();
        le.Value = "ALL";
        le.Text = "--ALL--";
        s.Items.Add(le);
        foreach (var item in list)
        {
            le = new ListEditItem();
            le.Value = item.Code;
            le.Text = item.NameE;
            s.Items.Add(le);
        }

        if (s.Items.Count > 0)
            s.Value = SessionUser.AreaCode != "KCQ" ? SessionUser.AreaCode : "ALL";
    }
    protected void CountersCostGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        decimal aCounterTypeID = decimal.Zero;

        decimal aVersionID = decimal.Zero;
        if (args[0] == "LOAD_COST")
        {
            if (!decimal.TryParse(args[1], out aCounterTypeID))
                return;

            if (!decimal.TryParse(args[2], out aVersionID))
                return;

            if (aCounterTypeID != decimal.Zero)
            {
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@pCounterTypeID", aCounterTypeID),
                        new SqlParameter("@pVersionID", aVersionID),
                        new SqlParameter("@pUserID", SessionUser.UserID)
                };

                entities.Database.ExecuteSqlCommand(DbHelper.GenerateCommandText("[KTQT_Data].[dbo].[PrcInitCountersCost]", parameters), parameters);
            }

            LoadCountersCost(aCounterTypeID, aVersionID);
        }
    }
    protected void CountersCostGrid_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            var aCounterTypeID = this.GetCallbackKeyValue("CounterTypeID");
            var aVersionID = this.GetCallbackKeyValue("VersionID");

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aCounterCostID = Convert.ToDecimal(updValues.Keys["CounterCostID"]);
                var entity = entities.DM_CountersCosts.SingleOrDefault(x => x.CounterCostID == aCounterCostID);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["RentalType"] != null)
                    {
                        string aRentalType = updValues.NewValues["RentalType"].ToString();
                        entity.RentalType = aRentalType;
                    }

                    if (updValues.NewValues["Quantity"] != null)
                    {
                        int aQuantity = Convert.ToInt32(updValues.NewValues["Quantity"]);
                        entity.Quantity = aQuantity;
                    }

                    if (updValues.NewValues["UnitOfMeasure"] != null)
                    {
                        string aUnitOfMeasure = updValues.NewValues["UnitOfMeasure"].ToString();
                        entity.UnitOfMeasure = aUnitOfMeasure;
                    }

                    if (updValues.NewValues["Amount"] != null)
                    {
                        decimal aAmount = Convert.ToDecimal(updValues.NewValues["Amount"]);
                        entity.Amount = aAmount;
                    }

                    if (updValues.NewValues["CurrencyCode"] != null)
                    {
                        string aCurrencyCode = updValues.NewValues["CurrencyCode"].ToString();
                        entity.CurrencyCode = aCurrencyCode;
                    }

                    if (updValues.NewValues["DiscountPercent"] != null)
                    {
                        decimal aDiscountPercent = Convert.ToDecimal(updValues.NewValues["DiscountPercent"]);
                        entity.DiscountPercent = aDiscountPercent;
                    }

                    if (updValues.NewValues["Remark"] != null)
                    {
                        string aDescription = updValues.NewValues["Remark"].ToString();
                        entity.Remark = aDescription;
                    }
                    else
                        entity.Remark = null;

                }
            }
            entities.SaveChanges();

            LoadCountersCost(aCounterTypeID, aVersionID);
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
    protected void cboVersion_Callback(object sender, CallbackEventArgsBase e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        decimal aNormYearID;
        if (!decimal.TryParse(e.Parameter, out aNormYearID))
            return;

        var aNormYear = entities.DM_NormYears.SingleOrDefault(x => x.NormYearID == aNormYearID);
        if (aNormYear != null)
        {
            var list = entities.Versions.Where(x => x.VersionYear == aNormYear.ForYear && x.UsedStatus == "USED")
                .OrderByDescending(x => x.VersionType)
                .ThenByDescending(x => x.CreatedDate)
                .ToList();

            cbo.DataSource = list;
            cbo.ValueField = "VersionID";
            cbo.TextField = "Description";
            cbo.DataBind();

            if (cbo.Items.Count > 0)
                cbo.SelectedItem = cbo.Items[0];
        }
    }

    void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
    {
        if (errors.ContainsKey(column)) return;
        errors[column] = errorText;
    }
    protected void CarrierGrid_RowValidating(object sender, ASPxDataValidationEventArgs e)
    {
        ASPxGridView aGridView = sender as ASPxGridView;
        foreach (GridViewColumn column in aGridView.Columns)
        {
            if (e.NewValues["UsageRate"] == null)
                AddError(e.Errors, aGridView.Columns["UsageRate"], "Tỷ lệ sử dụng quầy bắt buộc nhập.");
            if (!CheckUsageRate(e))
                AddError(e.Errors, aGridView.Columns["UsageRate"], "Tỷ lệ sử dụng quầy không được phép lớn hơn 100%.");
        }

        if (string.IsNullOrEmpty(e.RowError) && e.Errors.Count > 0)
            e.RowError = "Không thể lưu thông tin!";
    }

    private bool CheckUsageRate(ASPxDataValidationEventArgs e)
    {
        //var key = Convert.ToDecimal(e.Keys["CarrierCounterID"]);

        //var aRow = entities.DM_CarrierCounters.SingleOrDefault(x => x.CarrierCounterID == key);

        //if (aRow != null)
        //{
        //    var aCounterTypes = entities.DM_CountersTypes.SingleOrDefault(x => x.CounterTypeID == aRow.CounterTypeID).CountersType;

        //    decimal aInputValue = Convert.ToDecimal(e.NewValues["UsageRate"]);
        //    decimal? aUsageRate;

        //    aUsageRate = entities.DM_CarrierCounters.Where(x => x.NormYearID == aRow.NormYearID && x.AreaCode == aRow.AreaCode
        //        && x.Carrier == aRow.Carrier && x.CarrierCounterID != key)
        //               .Sum(x => x.UsageRate);

        //    if (decimal.Add(aUsageRate.HasValue ? aUsageRate.Value : decimal.Zero, aInputValue) > 100)
        //        return false;

        //}

        return true;
    }
    protected void CarrierUsageRateGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        decimal aCarrierCounterID = decimal.Zero;

        decimal aVersionID = decimal.Zero;
        if (args[0] == "LOAD_DETAIL")
        {
            if (!decimal.TryParse(args[1], out aCarrierCounterID))
                return;

            if (!decimal.TryParse(args[2], out aVersionID))
                return;

            if (aCarrierCounterID != decimal.Zero)
            {
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@pCarrierCounterID", aCarrierCounterID),
                        new SqlParameter("@pVersionID", aVersionID),
                        new SqlParameter("@pUserID", SessionUser.UserID)
                };

                entities.Database.ExecuteSqlCommand(DbHelper.GenerateCommandText("[KTQT_Data].[dbo].[InitCarrierCounterUsages]", parameters), parameters);
            }

            LoadCarrierCounterUsages(aCarrierCounterID, aVersionID);
        }
    }
    protected void CarrierUsageRateGrid_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            var aCarrierCounterID = this.GetCallbackKeyValue("CarrierCounterID");
            var aVersionID = this.GetCallbackKeyValue("VersionID");

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aCarrierCounterUsageID = Convert.ToDecimal(updValues.Keys["CarrierCounterUsageID"]);
                var entity = entities.DM_CarrierCounterUsages.SingleOrDefault(x => x.CarrierCounterUsageID == aCarrierCounterUsageID);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["UsageRate"] != null)
                    {
                        decimal aUsageRate = Convert.ToDecimal(updValues.NewValues["UsageRate"]);
                        entity.UsageRate = aUsageRate;
                    }

                    if (updValues.NewValues["Description"] != null)
                    {
                        string aDescription = updValues.NewValues["Description"].ToString();
                        entity.Description = aDescription;
                    }
                    else
                        entity.Description = null;

                }
            }
            entities.SaveChanges();

            LoadCarrierCounterUsages(aCarrierCounterID, aVersionID);
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
}