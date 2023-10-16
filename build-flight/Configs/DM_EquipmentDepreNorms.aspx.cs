using DevExpress.Web;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_DM_EquipmentDepreNorms : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsCallback || this.NormYearGrid.IsCallback)
            LoadNormYears();

        if (!this.IsCallback || this.NormYearGrid2.IsCallback)
            LoadNormYears2();

        if (!this.IsCallback || this.ACConfigGrid.IsCallback)
            LoadACConfigs();

        LoadItems(this.EDNormGrid);

        if (!this.IsCallback || this.EDNormGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");
            var aACConfigID = this.GetCallbackKeyValue("ACConfigID");
            if (aACConfigID != null && aNormYearID != null)
                LoadEquipmentDepreciationNorms(aNormYearID, aACConfigID);
        }

        LoadItems(this.EDNormGrid2);
        if (!this.IsCallback || this.EDNormGrid2.IsCallback)
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");
            if (aNormYearID != null)
                LoadEquipmentDepreciationNorms(aNormYearID);
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

    private void LoadNormYears2()
    {
        var list = entities.DM_NormYears
            .OrderByDescending(x => x.ForYear)
            .ToList();

        this.NormYearGrid2.DataSource = list;
        this.NormYearGrid2.DataBind();

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


    private void LoadEquipmentDepreciationNorms(int NormYearID, int ACConfigID)
    {
        var list = entities.DM_EquipmentDepreNorms
            .Where(x => x.NormYearID == NormYearID && x.ACConfigID == ACConfigID && x.EDNormType == "C")
            .OrderBy(x => x.ItemID)
            .ThenBy(x => x.ForMonth)
            .ToList();

        this.EDNormGrid.DataSource = list;
        this.EDNormGrid.DataBind();
    }

    private void LoadEquipmentDepreciationNorms(int NormYearID)
    {
        var list = entities.DM_EquipmentDepreNorms
            .Where(x => x.NormYearID == NormYearID && x.EDNormType == "N")
            .OrderBy(x => x.ItemID)
            .ThenBy(x => x.ForMonth)
            .ToList();

        this.EDNormGrid2.DataSource = list;
        this.EDNormGrid2.DataBind();
    }



    private void LoadItems(ASPxGridView Grid)
    {
        GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)Grid.Columns["ItemID"];

        if (Session[SessionConstant.ITEM_LIST] != null)
            aCombo.PropertiesComboBox.DataSource = Session[SessionConstant.ITEM_LIST];
        else
        {
            string[] aGroupItem = new string[] { "TTBTX", "TTBKTX" };
            var list = entities.ItemMasters.Where(x => aGroupItem.Contains(x.GroupItem)).OrderByDescending(x => x.GroupItem).ToList();
            Session[SessionConstant.ITEM_LIST] = list;
            aCombo.PropertiesComboBox.DataSource = list;
        }

        aCombo.PropertiesComboBox.ValueField = "ItemID";
        aCombo.PropertiesComboBox.TextField = "Name";
    }


    #endregion
    protected void EDNormGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        decimal aUnitPriceID;
        int aNormYearID;
        int aACConfigID;

        if (Object.Equals(args[0], "DELETE_ED_NORM"))
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

                LoadEquipmentDepreciationNorms(aNormYearID, aACConfigID);
            }

        }
    }
    protected void EDNormGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");
            var aACConfigID = this.GetCallbackKeyValue("ACConfigID");

            foreach (ASPxDataInsertValues insValues in e.InsertValues)
            {
                var entity = new DM_EquipmentDepreNorms();

                entity.NormYearID = aNormYearID;
                entity.ACConfigID = aACConfigID;
                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;
                entity.EDNormType = "C";

                if (insValues.NewValues["ItemID"] != null)
                {
                    int aItemID = Convert.ToInt32(insValues.NewValues["ItemID"]);
                    entity.ItemID = aItemID;
                }

                //if (insValues.NewValues["EDNormType"] != null)
                //{
                //    string aEDNormType = insValues.NewValues["EDNormType"].ToString();
                //    entity.EDNormType = aEDNormType;
                //}

                if (insValues.NewValues["ForMonth"] != null)
                {
                    int aForMonth = Convert.ToInt32(insValues.NewValues["ForMonth"]);
                    entity.ForMonth = aForMonth;
                }


                if (insValues.NewValues["Amount"] != null)
                {
                    decimal aAmount = Convert.ToDecimal(insValues.NewValues["Amount"]);
                    entity.Amount = aAmount;
                }

                if (insValues.NewValues["CurrencyCode"] != null)
                {
                    string aCurrencyCode = insValues.NewValues["CurrencyCode"].ToString();
                    entity.CurrencyCode = aCurrencyCode;
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

                entities.DM_EquipmentDepreNorms.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aEDNormID = Convert.ToDecimal(updValues.Keys["EDNormID"]);
                var entity = entities.DM_EquipmentDepreNorms.SingleOrDefault(x => x.EDNormID == aEDNormID);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["ItemID"] != null)
                    {
                        int aItemID = Convert.ToInt32(updValues.NewValues["ItemID"]);
                        entity.ItemID = aItemID;
                    }

                    if (updValues.NewValues["EDNormType"] != null)
                    {
                        string aEDNormType = updValues.NewValues["EDNormType"].ToString();
                        entity.EDNormType = aEDNormType;
                    }

                    if (updValues.NewValues["ForMonth"] != null)
                    {
                        int aForMonth = Convert.ToInt32(updValues.NewValues["ForMonth"]);
                        entity.ForMonth = aForMonth;
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
                    else
                        entity.Inactive = false;

                }
            }
            entities.SaveChanges();

            LoadEquipmentDepreciationNorms(aNormYearID, aACConfigID);
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
    protected void EDNormGrid2_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");

            foreach (ASPxDataInsertValues insValues in e.InsertValues)
            {
                var entity = new DM_EquipmentDepreNorms();

                entity.NormYearID = aNormYearID;
                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;
                entity.EDNormType = "N";

                if (insValues.NewValues["ItemID"] != null)
                {
                    int aItemID = Convert.ToInt32(insValues.NewValues["ItemID"]);
                    entity.ItemID = aItemID;
                }

                if (insValues.NewValues["ForMonth"] != null)
                {
                    int aForMonth = Convert.ToInt32(insValues.NewValues["ForMonth"]);
                    entity.ForMonth = aForMonth;
                }


                if (insValues.NewValues["Amount"] != null)
                {
                    decimal aAmount = Convert.ToDecimal(insValues.NewValues["Amount"]);
                    entity.Amount = aAmount;
                }

                if (insValues.NewValues["CurrencyCode"] != null)
                {
                    string aCurrencyCode = insValues.NewValues["CurrencyCode"].ToString();
                    entity.CurrencyCode = aCurrencyCode;
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

                entities.DM_EquipmentDepreNorms.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aEDNormID = Convert.ToDecimal(updValues.Keys["EDNormID"]);
                var entity = entities.DM_EquipmentDepreNorms.SingleOrDefault(x => x.EDNormID == aEDNormID);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["ItemID"] != null)
                    {
                        int aItemID = Convert.ToInt32(updValues.NewValues["ItemID"]);
                        entity.ItemID = aItemID;
                    }

                    if (updValues.NewValues["ForMonth"] != null)
                    {
                        int aForMonth = Convert.ToInt32(updValues.NewValues["ForMonth"]);
                        entity.ForMonth = aForMonth;
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
                    else
                        entity.Inactive = false;

                }
            }
            entities.SaveChanges();

            LoadEquipmentDepreciationNorms(aNormYearID);
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
    protected void EDNormGrid2_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        decimal aUnitPriceID;
        int aNormYearID;

        if (Object.Equals(args[0], "DELETE_ED_NORM"))
        {
            if (!decimal.TryParse(args[1], out aUnitPriceID))
                return;

            var entity = entities.DM_BoardingUnitPrices.SingleOrDefault(x => x.BoardingUnitPriceID == aUnitPriceID);
            if (entity != null)
            {
                aNormYearID = entity.NormYearID;
                entities.DM_BoardingUnitPrices.Remove(entity);

                entities.SaveChanges();

                LoadEquipmentDepreciationNorms(aNormYearID);
            }

        }
    }
}