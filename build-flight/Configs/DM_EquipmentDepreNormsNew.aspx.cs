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

public partial class Configs_DM_EquipmentDepreNormsNew : BasePageNotCheckURL
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.seCalcUnitPriceFromMonth.Value = DateUtils.FirstDayOfMonth(true).Month;
            this.seCalcUnitPriceToMonth.Value = DateUtils.FirstDayOfMonth(true).Month;
        }

        LoadAreaLOV();
        LoadCarrierLOV();

        if (!this.IsCallback || this.NormYearGrid.IsCallback)
            LoadNormYears();

        if (!this.IsCallback || this.ItemGrid.IsCallback)
            LoadItems();

        //LoadItems(this.EDNormGrid);

        if (!this.IsCallback || this.EDNormGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");
            var aItemID = this.GetCallbackKeyValue("ItemID");
            if (aItemID != null && aNormYearID != null)
                LoadEquipmentDepreciationNorms(aNormYearID, aItemID);
        }

        if (!this.IsCallback || this.DepreCostDetailGrid.IsCallback)
        {
            var aEDNormID = this.GetCallbackKeyDecimalValue("EDNormID");
            if (aEDNormID != null)
                LoadDepreNormDetail(aEDNormID);

        }

        if (!this.IsCallback || this.UnitPriceGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");
            LoadLOVVersion(aNormYearID);

            var aEDNormID = this.GetCallbackKeyDecimalValue("EDNormID");
            if (aEDNormID != null)
                LoadUnitPrice(aEDNormID);

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

    private decimal GetCallbackKeyDecimalValue(string keyStr)
    {
        string result = null;
        if (Utils.TryGetClientStateValue<string>(this, keyStr, out result))
            return Convert.ToDecimal(result);
        return decimal.Zero;
    }

    private void LoadNormYears()
    {
        var list = entities.DM_NormYears
            .OrderByDescending(x => x.ForYear)
            .ToList();

        this.NormYearGrid.DataSource = list;
        this.NormYearGrid.DataBind();
    }

    private void LoadItems()
    {
        var aGroupItem = new string[] { "TTBTX", "TTBKTX", "TTBKHAC" };
        var list = entities.ItemMasters
            .Where(x => aGroupItem.Contains(x.GroupItem) && x.Active == true)
            .OrderByDescending(x => x.GroupItem)
            .ToList();

        this.ItemGrid.DataSource = list;
        this.ItemGrid.DataBind();
    }


    private void LoadEquipmentDepreciationNorms(int NormYearID, int ItemID)
    {
        var list = entities.DM_EquipmentDepreNorms
            .Where(x => x.NormYearID == NormYearID && x.ItemID == ItemID)
            .OrderBy(x => x.ItemID)
            .ThenBy(x => x.ForMonth)
            .ToList();

        this.EDNormGrid.DataSource = list;
        this.EDNormGrid.DataBind();
    }

    private void LoadUnitPrice(decimal pEDNormID)
    {
        var list = entities.DM_DepreUnitPrices
            .Where(x => x.EDNormID == pEDNormID)
            .OrderBy(x => x.VersionID)
            .ThenBy(x => x.ForMonth)
            .ThenBy(x => x.Network)
            .ThenBy(x => x.Aircraft)
            .ToList();

        this.UnitPriceGrid.DataSource = list;
        this.UnitPriceGrid.DataBind();

    }

    private void LoadDepreNormDetail(decimal pEDNormID)
    {
        var list = entities.DM_EquipmentDepreNormDetails
            .Where(x => x.EDNormID == pEDNormID)
            .OrderBy(x => x.ForMonth)
            .ToList();

        this.DepreCostDetailGrid.DataSource = list;
        this.DepreCostDetailGrid.DataBind();

    }

    private void LoadItems(ASPxGridView Grid)
    {
        GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)Grid.Columns["ItemID"];

        if (Session[SessionConstant.ITEM_LIST] != null)
            aCombo.PropertiesComboBox.DataSource = Session[SessionConstant.ITEM_LIST];
        else
        {
            string[] aGroupItem = new string[] { "TTBTX", "TTBKTX", "TTBKHAC" };
            var list = entities.ItemMasters.Where(x => aGroupItem.Contains(x.GroupItem)).OrderByDescending(x => x.GroupItem).ToList();
            Session[SessionConstant.ITEM_LIST] = list;
            aCombo.PropertiesComboBox.DataSource = list;
        }

        aCombo.PropertiesComboBox.ValueField = "ItemID";
        aCombo.PropertiesComboBox.TextField = "Name";
    }

    private void LoadAreaLOV()
    {
        try
        {
            GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)EDNormGrid.Columns["AreaCode"];

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
            GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)EDNormGrid.Columns["Carrier"];

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
    protected void EDNormGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        decimal aEDNormID;
        int aNormYearID;
        int aItemID;

        if (Object.Equals(args[0], "LOAD_ED"))
        {
            if (!int.TryParse(args[1], out aItemID))
                return;

            aNormYearID = this.GetCallbackKeyValue("NormYearID");

            SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@pNormYearID", aNormYearID),  
                        new SqlParameter("@pItemID", aNormYearID),  
                        new SqlParameter("@pUserID", SessionUser.UserID)
                };

            entities.Database.ExecuteSqlCommand(DbHelper.GenerateCommandText("[KTQT_Data].[dbo].[PrcInitEquipmentDepreNorms]", parameters), parameters);

            LoadEquipmentDepreciationNorms(aNormYearID, aItemID);
        }

        if (Object.Equals(args[0], "DELETE_ED_NORM"))
        {
            if (!decimal.TryParse(args[1], out aEDNormID))
                return;

            var entity = entities.DM_EquipmentDepreNorms.SingleOrDefault(x => x.EDNormID == aEDNormID);
            if (entity != null)
            {
                aNormYearID = entity.NormYearID;
                aItemID = entity.ItemID;
                entities.DM_EquipmentDepreNorms.Remove(entity);

                entities.SaveChanges();

                LoadEquipmentDepreciationNorms(aNormYearID, aItemID);
            }

        }
    }
    protected void EDNormGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");
            var aItemID = this.GetCallbackKeyValue("ItemID");

            foreach (ASPxDataInsertValues insValues in e.InsertValues)
            {
                var entity = new DM_EquipmentDepreNorms();

                entity.NormYearID = aNormYearID;
                entity.ItemID = aItemID;
                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;
                entity.EDNormType = "C";

                if (insValues.NewValues["ForMonth"] != null)
                {
                    int aForMonth = Convert.ToInt32(insValues.NewValues["ForMonth"]);
                    entity.ForMonth = aForMonth;
                }

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

                if (insValues.NewValues["Amount"] != null)
                {
                    decimal aAmount = Convert.ToDecimal(insValues.NewValues["Amount"]);
                    entity.Amount = aAmount;
                }

                if (insValues.NewValues["Frequency"] != null)
                {
                    decimal aFrequency = Convert.ToDecimal(insValues.NewValues["Frequency"]);
                    entity.Frequency = aFrequency;
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

                    if (updValues.NewValues["Amount"] != null)
                    {
                        decimal aAmount = Convert.ToDecimal(updValues.NewValues["Amount"]);
                        entity.Amount = aAmount;
                    }

                    if (updValues.NewValues["Frequency"] != null)
                    {
                        decimal aFrequency = Convert.ToDecimal(updValues.NewValues["Frequency"]);
                        entity.Frequency = aFrequency;
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

            LoadEquipmentDepreciationNorms(aNormYearID, aItemID);
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }


    protected void ItemGrid_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
    {
        var Grid = (sender as ASPxGridView);

        if (e.Column.FieldName == "GroupItemName")
        {
            var entity = Grid.GetRow(e.VisibleIndex) as ItemMaster;
            if (entity == null) return;
            var aGroupItem = entity.GroupItem;
            var group = entities.DecTableValues.Where(x => x.Tables == "ITEMMASTER" && x.Field == "GROUPITEM" && x.DefValue == aGroupItem).SingleOrDefault();
            if (group != null)
            {
                e.EncodeHtml = false;
                e.DisplayText = group.Description;
            }
        }
    }
    protected void UnitPriceGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        var aEDNormID = this.GetCallbackKeyValue("EDNormID");

        decimal aUnitPriceID;

        if (args[0] == "DELETE_UNIT_PRICE")
        {
            if (!decimal.TryParse(args[1], out aUnitPriceID))
                return;

            var entity = entities.DM_DepreUnitPrices.SingleOrDefault(x => x.UnitPriceID == aUnitPriceID);
            if (entity != null)
            {

                entities.DM_DepreUnitPrices.Remove(entity);

                entities.SaveChanges();
            }

            LoadUnitPrice(aEDNormID);
        }

        if (args[0] == "CALC_UNIT")
        {
            int aNormYearID;
            if (!int.TryParse(args[1], out aNormYearID))
                return;

            try
            {
                decimal aVersionID = Convert.ToDecimal(cboCalcUnitPriceVersion.Value);
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

                entities.Database.ExecuteSqlCommand(DbHelper.GenerateCommandText("[KTQT_Data].[dbo].[PrcCalcDepreUnitPriceV2]", parameters), parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            LoadUnitPrice(aEDNormID);
        }
    }
    protected void UnitPriceGrid_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
    {

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
                    cbo.SelectedItem = cbo.Items[0];
            }
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
    protected void DepreCostDetailGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        decimal aEDNormID = decimal.Zero;

        if (args[0] == "LOAD_COST")
        {
            if (!decimal.TryParse(args[1], out aEDNormID))
                return;
            if (aEDNormID != decimal.Zero)
            {
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@pEDNormID", aEDNormID),
                        new SqlParameter("@pUserID", SessionUser.UserID)
                };

                entities.Database.ExecuteSqlCommand(DbHelper.GenerateCommandText("[KTQT_Data].[dbo].[PrcInitDepreNormDetail]", parameters), parameters);
            }
            LoadDepreNormDetail(aEDNormID);
        }
    }
    protected void DepreCostDetailGrid_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            var aEDNormID = this.GetCallbackKeyDecimalValue("EDNormID");

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aDetailID = Convert.ToDecimal(updValues.Keys["DetailID"]);
                var entity = entities.DM_EquipmentDepreNormDetails.SingleOrDefault(x => x.DetailID == aDetailID);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["ForMonth"] != null)
                    {
                        int aForMonth = Convert.ToInt32(updValues.NewValues["ForMonth"]);
                        entity.ForMonth = aForMonth;
                    }

                    if (updValues.NewValues["PlanAmount"] != null)
                    {
                        decimal aAmount = Convert.ToDecimal(updValues.NewValues["PlanAmount"]);
                        entity.PlanAmount = aAmount;
                    }

                    if (updValues.NewValues["EstimateAmount"] != null)
                    {
                        decimal aAmount = Convert.ToDecimal(updValues.NewValues["EstimateAmount"]);
                        entity.EstimateAmount = aAmount;
                    }

                    if (updValues.NewValues["ActualAmount"] != null)
                    {
                        decimal aAmount = Convert.ToDecimal(updValues.NewValues["ActualAmount"]);
                        entity.ActualAmount = aAmount;
                    }


                }
            }
            entities.SaveChanges();

            LoadDepreNormDetail(aEDNormID);
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
}