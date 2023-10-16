using DevExpress.Web;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_ExchangeRates : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsCallback || this.DataGrid.IsCallback)
            LoadExchangeRates();
    }

    private void LoadExchangeRates()
    {
        var list = entities.ExchangeRates
            .Where(x => x.Status != "XX")
            .OrderByDescending(x => x.EffectiveDateFrom)
            .ToList();

        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }

    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        int aExchangeRateID;

        if (Object.Equals(args[0], "DELETE"))
        {
            if (!int.TryParse(args[1], out aExchangeRateID))
                return;

            var entity = entities.ExchangeRates.SingleOrDefault(x => x.ExchageRateID == aExchangeRateID);
            if (entity != null)
            {
                entity.Status = "XX";

                entities.SaveChanges();
            }
            LoadExchangeRates();
        }
    }
    protected void DataGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            foreach (ASPxDataInsertValues insValues in e.InsertValues)
            {
                var entity = new ExchangeRate();

                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;
                entity.Status = "OK";

                if (insValues.NewValues["CurrencyCode"] != null)
                {
                    string aCurrencyCode = insValues.NewValues["CurrencyCode"].ToString();
                    entity.CurrencyCode = aCurrencyCode;
                }

                if (insValues.NewValues["ExcRate"] != null)
                {
                    decimal aExcRate = Convert.ToDecimal(insValues.NewValues["ExcRate"]);
                    entity.ExcRate = aExcRate;
                }

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

                entities.ExchangeRates.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aExchangeRateID = Convert.ToDecimal(updValues.Keys["ExchageRateID"]);
                var entity = entities.ExchangeRates.SingleOrDefault(x => x.ExchageRateID == aExchangeRateID);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["CurrencyCode"] != null)
                    {
                        string aCurrencyCode = updValues.NewValues["CurrencyCode"].ToString();
                        entity.CurrencyCode = aCurrencyCode;
                    }

                    if (updValues.NewValues["ExcRate"] != null)
                    {
                        decimal aExcRate = Convert.ToDecimal(updValues.NewValues["ExcRate"]);
                        entity.ExcRate = aExcRate;
                    }

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


                    if (updValues.NewValues["Status"] != null)
                    {
                        string aStatus = updValues.NewValues["Status"].ToString();
                        entity.Status = aStatus;
                    }

                }
            }
            entities.SaveChanges();

            LoadExchangeRates();
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
}