using DevExpress.Web;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_DM_BoardingUnitPrices : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsCallback || this.NormYearGrid.IsCallback)
            LoadNormYears();

        if (!this.IsCallback || this.ACConfigGrid.IsCallback)
            LoadACConfigs();

        if (!this.IsCallback || this.UnitPriceGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");
            var aACConfigID = this.GetCallbackKeyValue("ACConfigID");
            if (aACConfigID != null)
                LoadBoardingUnitPrices(aNormYearID, aACConfigID);
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

    private void LoadACConfigs()
    {
        var list = entities.DM_ACConfigs
            .Where(x => x.Inactive == false)
            .OrderByDescending(x => x.AreaCode)
            .ThenBy(x => x.Carrier)
            .ThenBy(x => x.Network)
            .ThenBy(x => x.AcID)
            .ToList();

        this.ACConfigGrid.DataSource = list;
        this.ACConfigGrid.DataBind();
    }

    private void LoadNormYears()
    {
        var list = entities.DM_NormYears
            .OrderByDescending(x => x.ForYear)
            .ToList();

        this.NormYearGrid.DataSource = list;
        this.NormYearGrid.DataBind();
    }

    private void LoadBoardingUnitPrices(int NormYearID, int ACConfigID)
    {
        var list = entities.DM_BoardingUnitPrices
            .Where(x => x.NormYearID == NormYearID && x.ACConfigID == ACConfigID && (x.Inactive ?? false) == false)
            .OrderByDescending(x => x.EffectiveDateFrom)
            .ToList();

        this.UnitPriceGrid.DataSource = list;
        this.UnitPriceGrid.DataBind();
    }


    #endregion
    protected void UnitPriceGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        decimal aUnitPriceID;
        int aNormYearID;
        int aACConfigID;

        if (Object.Equals(args[0], "DELETE_UNIT_PRICE"))
        {
            if (!decimal.TryParse(args[1], out aUnitPriceID))
                return;

            var entity = entities.DM_BoardingUnitPrices.SingleOrDefault(x => x.BoardingUnitPriceID == aUnitPriceID);
            if (entity != null)
            {
                aNormYearID = entity.NormYearID;
                aACConfigID = entity.ACConfigID;
                entities.DM_BoardingUnitPrices.Remove(entity);

                entities.SaveChanges();

                LoadBoardingUnitPrices(aNormYearID, aACConfigID);
            }

        }
    }
    protected void UnitPriceGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");
            var aACConfigID = this.GetCallbackKeyValue("ACConfigID");

            foreach (ASPxDataInsertValues insValues in e.InsertValues)
            {
                var entity = new DM_BoardingUnitPrices();

                entity.NormYearID = aNormYearID;
                entity.ACConfigID = aACConfigID;
                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;

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

                if (insValues.NewValues["Inactive"] != null)
                {
                    bool aInactive = Convert.ToBoolean(insValues.NewValues["Inactive"]);
                    entity.Inactive = aInactive;
                }
                else
                    entity.Inactive = false;

                entities.DM_BoardingUnitPrices.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aBoardingUnitPriceID = Convert.ToDecimal(updValues.Keys["BoardingUnitPriceID"]);
                var entity = entities.DM_BoardingUnitPrices.SingleOrDefault(x => x.BoardingUnitPriceID == aBoardingUnitPriceID);
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

                    if (updValues.NewValues["Inactive"] != null)
                    {
                        bool aInactive = Convert.ToBoolean(updValues.NewValues["Inactive"]);
                        entity.Inactive = aInactive;
                    }


                }
            }
            entities.SaveChanges();

            LoadBoardingUnitPrices(aNormYearID, aACConfigID);
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
    protected void ACConfigGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {

    }

}