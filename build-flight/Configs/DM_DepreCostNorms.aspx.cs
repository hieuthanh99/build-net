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

public partial class Configs_DM_DepreCostNorms : BasePageNotCheckURL
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

        if (!this.IsCallback || this.DepreCostGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackKeyIntValue("NormYearID");
            LoadDrepreCostNorm(aNormYearID);
        }


        if (!this.IsCallback || this.CarrierGrid.IsCallback)
        {
            var aDepreCostID = this.GetCallbackKeyDecimalValue("DepreCostID");

            LoadCarrier(aDepreCostID);
        }


        if (!this.IsCallback || this.CostDetailGrid.IsCallback)
        {
            var aDepreCostID = this.GetCallbackKeyDecimalValue("DepreCostID");
            var aVersionID = this.GetCallbackKeyDecimalValue("VersionID");

            LoadDepreCostDetail(aDepreCostID, aVersionID);
        }



        if (!this.IsCallback || this.UnitPriceGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackKeyIntValue("NormYearID");
            LoadLOVVersion(aNormYearID);

            var aDepreCostCarrierID = this.GetCallbackKeyDecimalValue("DepreCostCarrierID");
            var aVersionID = this.GetCallbackKeyDecimalValue("VersionID");

            if (aDepreCostCarrierID != null)
                LoadUnitPrice(aDepreCostCarrierID, aVersionID);

        }


        if (!this.IsCallback || this.LOVCarrierGrid.IsCallback)
        {
            int aNormYearID = this.GetCallbackKeyIntValue("NormYearID");
            decimal aDepreCostID = this.GetCallbackKeyDecimalValue("DepreCostID");
            if (aDepreCostID != null)
                LoadLOVCarrier(aNormYearID, aDepreCostID);
        }

    }

    #region Load Data
    private int GetCallbackKeyIntValue(string keyStr)
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


    private void LoadDepreCostDetail(decimal pDepreCostID, decimal pVersionID)
    {
        var list = entities.DM_DepreCostDetails
            .Where(x => x.DepreCostID == pDepreCostID && x.VersionID == pVersionID)
            .OrderBy(x => x.ForMonth)
            .ToList();

        this.CostDetailGrid.DataSource = list;
        this.CostDetailGrid.DataBind();

    }

    private void LoadCarrier(decimal pDepreCostID)
    {
        var list = entities.DM_DepreCostCarriers
            .Where(x => x.DepreCostID == pDepreCostID)
            .OrderByDescending(x => x.AreaCode)
            .ThenBy(x => x.Carrier)
            .ToList();

        this.CarrierGrid.DataSource = list;
        this.CarrierGrid.DataBind();

    }

    private void LoadLOVCarrier(int pNormYearID, decimal pDepreCostID)
    {
        var aAreaCode = "ALL";
        var aDepreCost = entities.DM_DepreCostNorms.SingleOrDefault(x => x.DepreCostID == pDepreCostID);

        if (aDepreCost != null)
            aAreaCode = aDepreCost.AreaCode;

        var list = entities.DM_ACConfigs
            .Where(x => x.AreaCode == aAreaCode && !entities.DM_DepreCostCarriers
                                .Where(c => c.NormYearID == pNormYearID && c.DepreCostID == pDepreCostID)
                                .Select(c => c.AreaCode + c.Carrier)
                                .Contains(x.AreaCode + x.Carrier))

            .Select(x => new { AreaCode = x.AreaCode, Carrier = x.Carrier })
            .Distinct()
            .OrderBy(x => x.AreaCode).ThenBy(x => x.Carrier)
            .ToList();

        this.LOVCarrierGrid.DataSource = list;
        this.LOVCarrierGrid.DataBind();
    }

    private void LoadNormYears()
    {
        var list = entities.DM_NormYears
            .OrderByDescending(x => x.ForYear)
            .ToList();

        this.NormYearGrid.DataSource = list;
        this.NormYearGrid.DataBind();
    }

    private void LoadDrepreCostNorm(int NormYearID)
    {
        string aAreaCode = SessionUser.AreaCode;

        if (Object.Equals(aAreaCode, "KCQ"))
            aAreaCode = "ALL";

        var list = (from x in entities.DM_DepreCostNorms
                    join y in entities.ItemMasters on x.ItemID equals y.ItemID
                    where x.NormYearID == NormYearID && ((x.AreaCode == aAreaCode) || aAreaCode == "ALL")
                    select new DepreCostItem
                    {
                        DepreCostID = x.DepreCostID,
                        NormYearID = x.NormYearID,
                        AreaCode = x.AreaCode,
                        ItemID = x.ItemID,
                        ItemType = x.ItemType,
                        Amount = x.Amount,
                        DepreCostType = x.DepreCostType,
                        Description = x.Description,
                        ItemName = y.Name,
                        GroupItem = y.GroupItem,
                    }).OrderByDescending(x => x.AreaCode)
                     .ThenByDescending(x => x.ItemType)
                    .ThenByDescending(x => x.GroupItem)
                    .ThenBy(x => x.ItemID)
            .ToList();

        this.DepreCostGrid.DataSource = list;
        this.DepreCostGrid.DataBind();
    }


    private void LoadUnitPrice(decimal pDepreCostCarrierID, decimal pVersionID)
    {
        var list = entities.DM_DepreUnitPrices
            .Where(x => x.VersionID == pVersionID && x.DepreCostCarrierID == pDepreCostCarrierID)
            .OrderBy(x => x.VersionID)
            .ThenBy(x => x.ForMonth)
            .ThenBy(x => x.Network)
            .ThenBy(x => x.Aircraft)
            .ToList();

        this.UnitPriceGrid.DataSource = list;
        this.UnitPriceGrid.DataBind();

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

    protected void DepreCostGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        int aNormYearID;
        if (Object.Equals(args[0], "LOAD_DEPRE_COST"))
        {
            if (!int.TryParse(args[1], out aNormYearID))
                return;

            SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@pNormYearID", aNormYearID),              
                        new SqlParameter("@pUserID", SessionUser.UserID)
                };

            entities.Database.ExecuteSqlCommand(DbHelper.GenerateCommandText("[KTQT_Data].[dbo].[InitDepreCostNorms]", parameters), parameters);

            LoadDrepreCostNorm(aNormYearID);
        }
    }



    protected void DepreCostGrid_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            var aNormYearID = this.GetCallbackKeyIntValue("NormYearID");

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aDepreCostID = Convert.ToDecimal(updValues.Keys["DepreCostID"]);
                var entity = entities.DM_DepreCostNorms.SingleOrDefault(x => x.DepreCostID == aDepreCostID);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["Amount"] != null)
                    {
                        decimal aAmount = Convert.ToDecimal(updValues.NewValues["Amount"]);
                        entity.Amount = aAmount;
                    }

                    if (updValues.NewValues["DepreCostType"] != null)
                    {
                        string aDepreCostType = updValues.NewValues["DepreCostType"].ToString();
                        entity.DepreCostType = aDepreCostType;
                    }

                    if (updValues.NewValues["Description"] != null)
                    {
                        string aDescription = updValues.NewValues["Description"].ToString();
                        entity.Description = aDescription;
                    }

                }
            }
            entities.SaveChanges();

            LoadDrepreCostNorm(aNormYearID);
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }


    protected void DepreCostGrid_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
    {
        var Grid = (sender as ASPxGridView);

        if (e.Column.FieldName == "GroupItemName")
        {
            var entity = Grid.GetRow(e.VisibleIndex) as DepreCostItem;
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


    protected void CarrierGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split(';');

        decimal aDepreCostID = decimal.Zero;
        var aNormYearID = this.GetCallbackKeyIntValue("NormYearID");

        if (args[0] == "LOAD_CARRIER")
        {
            if (!decimal.TryParse(args[1], out aDepreCostID))
                return;

            SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@pNormYearID", aNormYearID), 
                        new SqlParameter("@pDepreCostID", aDepreCostID),   
                        new SqlParameter("@pUserID", SessionUser.UserID)
                };

            entities.Database.ExecuteSqlCommand(DbHelper.GenerateCommandText("[KTQT_Data].[dbo].[PrcInitDepreCostCarrier]", parameters), parameters);

            LoadCarrier(aDepreCostID);
        }

        if (args[0] == "ADD_CARRIER")
        {
            string[] carrierKeys = null;

            if (!decimal.TryParse(args[1], out aDepreCostID))
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

                var entity = new DM_DepreCostCarriers()
                {
                    DepreCostID = aDepreCostID,
                    NormYearID = aNormYearID,
                    Carrier = aCarrier,
                    AreaCode = aAreaCode,
                    UsageRate = 100,
                    Description = string.Empty,
                    CreateDate = DateTime.Now,
                    CreatedBy = (int)SessionUser.UserID
                };

                entities.DM_DepreCostCarriers.Add(entity);
            }
            entities.SaveChanges();


            LoadCarrier(aDepreCostID);
        }


        if (args[0] == "REMOVE_CARRIER")
        {
            aDepreCostID = this.GetCallbackKeyIntValue("DepreCostID");

            decimal[] aDepreCostCarrierKeys;

            if (!TryParseKeyValues(args.Skip(1), out aDepreCostCarrierKeys))
                return;

            entities.DM_DepreCostCarriers.RemoveRange(entities.DM_DepreCostCarriers.Where(c => aDepreCostCarrierKeys.Contains(c.DepreCostCarrierID)));

            entities.SaveChanges();

            LoadCarrier(aDepreCostID);
        }
    }
    protected void CarrierGrid_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
    {

    }
    protected void UnitPriceGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        var aDepreCostCarrierID = this.GetCallbackKeyIntValue("DepreCostCarrierID");


        decimal aUnitPriceID;

        if (args[0] == "DELETE_UNIT_PRICE")
        {
            if (!decimal.TryParse(args[1], out aUnitPriceID))
                return;

            var aVersionID = this.GetCallbackKeyDecimalValue("VersionID");

            var entity = entities.DM_DepreUnitPrices.SingleOrDefault(x => x.UnitPriceID == aUnitPriceID);
            if (entity != null)
            {

                entities.DM_DepreUnitPrices.Remove(entity);

                entities.SaveChanges();
            }

            LoadUnitPrice(aDepreCostCarrierID, aVersionID);
        }

        if (args[0] == "CALC_UNIT")
        {
            int aNormYearID;
            if (!int.TryParse(args[1], out aNormYearID))
                return;

            decimal aVersionID = Convert.ToDecimal(cboCalcUnitPriceVersion.Value);

            try
            {
             
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

                entities.Database.ExecuteSqlCommand(DbHelper.GenerateCommandText("[KTQT_Data].[dbo].[PrcCalcDepreUnitPrice]", parameters), parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            LoadUnitPrice(aDepreCostCarrierID, aVersionID);
        }
    }
    protected void UnitPriceGrid_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
    {

    }
    protected void LOVCarrierGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
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
                    cbo.SelectedItem = cbo.Items.FindByValue(Convert.ToInt32(cboQuantityVersion.Value));
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
    protected void CostDetailGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        decimal aDepreCostID = decimal.Zero;
        decimal aVersionID = decimal.Zero;
        if (args[0] == "LOAD_DETAIL")
        {
            if (!decimal.TryParse(args[1], out aDepreCostID))
                return;

            if (!decimal.TryParse(args[2], out aVersionID))
                return;

            SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@pDepreCostID", aDepreCostID),
                        new SqlParameter("@pVersionID", aVersionID),
                        new SqlParameter("@pUserID", SessionUser.UserID)
                };

            entities.Database.ExecuteSqlCommand(DbHelper.GenerateCommandText("[KTQT_Data].[dbo].[InitDepreCostDetail]", parameters), parameters);


            LoadDepreCostDetail(aDepreCostID, aVersionID);
        }
    }
    protected void CostDetailGrid_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            var aDepreCostID = this.GetCallbackKeyDecimalValue("DepreCostID");
            var aVersionID = this.GetCallbackKeyDecimalValue("VersionID");

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aDepreCostDetailID = Convert.ToDecimal(updValues.Keys["DepreCostDetailID"]);
                var entity = entities.DM_DepreCostDetails.SingleOrDefault(x => x.DepreCostDetailID == aDepreCostDetailID);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

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

                    if (updValues.NewValues["Amount"] != null)
                    {
                        decimal aAmount = Convert.ToDecimal(updValues.NewValues["Amount"]);
                        entity.Amount = aAmount;
                    }
                }
            }
            entities.SaveChanges();
            if (aDepreCostID != null && aDepreCostID != decimal.Zero)
            {
                UpdateDepreCost(aDepreCostID);
                LoadDepreCostDetail(aDepreCostID, aVersionID);
            }
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }

    private void UpdateDepreCost(decimal pDepreCostID)
    {
        var sum = entities.DM_DepreCostDetails
                          .Where(x => x.DepreCostID == pDepreCostID)
                          .GroupBy(x => x.DepreCostID)
                          .Select(g => new
                          {
                              DepreCostID = g.Key,
                              PlanAmount = g.Sum(c => c.PlanAmount),
                              EstimateAmount = g.Sum(c => c.EstimateAmount),
                              ActualAmount = g.Sum(c => c.ActualAmount)
                          }).SingleOrDefault();

        if (sum != null)
        {
            var aDepreCost = entities.DM_DepreCostNorms.SingleOrDefault(x => x.DepreCostID == pDepreCostID);
            if (aDepreCost != null)
            {
                aDepreCost.Amount = sum.PlanAmount;
                entities.SaveChanges();
            }
        }
    }
    protected void cboQuantityVersion_Callback(object sender, CallbackEventArgsBase e)
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
}


public class DepreCostItem
{
    public decimal DepreCostID { get; set; }
    public int NormYearID { get; set; }
    public string AreaCode { get; set; }
    public int ItemID { get; set; }
    public string ItemType { get; set; }
    public decimal Amount { get; set; }
    public string DepreCostType { get; set; }
    public string Description { get; set; }
    public string ItemName { get; set; }
    public string GroupItem { get; set; }
}