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

public partial class Configs_DM_FuelNorms : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsCallback || this.NormYearGrid.IsCallback)
            LoadNormYears();

        LoadItems();
        if (!IsCallback || this.MasterGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackIntKeyValue("NormYearID");
            LoadFuelNorms(aNormYearID);
        }
        if (!IsCallback || this.DetailGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackIntKeyValue("NormYearID");
            LoadVersions(aNormYearID);
            LoadFuelUnitPrices(aNormYearID);
        }
    }

    private int GetCallbackIntKeyValue(string keyStr)
    {
        string result = null;
        if (Utils.TryGetClientStateValue<string>(this, keyStr, out result))
            return Convert.ToInt32(result);
        return 0;
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

    private void LoadFuelNorms(int NormYearID)
    {
        string aAreaCode = SessionUser.AreaCode;

        if (Object.Equals(aAreaCode, "KCQ"))
            aAreaCode = "ALL";

        var list = entities.DM_FuelNorms
            .Where(x => x.NormYearID == NormYearID && ((x.AreaCode == aAreaCode) || aAreaCode == "ALL"))
            .OrderByDescending(x => x.AreaCode)
            .ThenBy(x => x.ItemID)
            .ToList();

        this.MasterGrid.DataSource = list;
        this.MasterGrid.DataBind();
    }

    private void LoadFuelUnitPrices(int NormYearID)
    {
        string aAreaCode = SessionUser.AreaCode;

        if (Object.Equals(aAreaCode, "KCQ"))
            aAreaCode = "ALL";

        var list = entities.DM_FuelUnitPrices
            .Where(x => x.NormYearID == NormYearID && ((x.AreaCode == aAreaCode) || aAreaCode == "ALL"))
            .OrderByDescending(x => x.AreaCode)
            .ThenBy(x => x.EffectiveDateFrom)
            .ToList();

        this.DetailGrid.DataSource = list;
        this.DetailGrid.DataBind();
    }


    private void LoadItems()
    {
        GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)MasterGrid.Columns["ItemID"];

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

    private void LoadVersions(int aNormYearID)
    {
        try
        {
            GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)DetailGrid.Columns["VersionID"];

            if (Session[SessionConstant.VERSION_LIST] != null)
                aCombo.PropertiesComboBox.DataSource = Session[SessionConstant.VERSION_LIST];
            else
            {
                var aNormYear = entities.DM_NormYears.SingleOrDefault(x => x.NormYearID == aNormYearID).ForYear;

                var list = entities.Versions.Where(x => x.VersionYear == aNormYear).OrderByDescending(x => x.VersionYear).ToList();
                Session[SessionConstant.VERSION_LIST] = list;
                aCombo.PropertiesComboBox.DataSource = list;
            }

            aCombo.PropertiesComboBox.ValueField = "VersionID";
            aCombo.PropertiesComboBox.TextField = "Description";
        }
        catch { }
    }


    #endregion
    protected void MasterGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        decimal aFuelNormsID;
        var aNormYearID = this.GetCallbackIntKeyValue("NormYearID");

        if (Object.Equals(args[0], "LOAD_MASTER"))
        {
            if (!int.TryParse(args[1], out aNormYearID))
                return;
            string aAreaCode = SessionUser.AreaCode;

            if (Object.Equals(aAreaCode, "SGN") || Object.Equals(aAreaCode, "HAN") || Object.Equals(aAreaCode, "DAD"))
            {
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@pNormYearID", aNormYearID),
                        new SqlParameter("@pAreaCode", aAreaCode),
                        new SqlParameter("@pUserID", SessionUser.UserID)
                };

                entities.Database.ExecuteSqlCommand(DbHelper.GenerateCommandText("[KTQT_Data].[dbo].[PrcInitFuelNorms]", parameters), parameters);
            }

            LoadFuelNorms(aNormYearID);
        }
        if (Object.Equals(args[0], "DELETE_MASTER_ROW"))
        {
            if (decimal.TryParse(args[1], out aFuelNormsID))
            {
                var entity = entities.DM_FuelNorms.SingleOrDefault(x => x.FuelNormsID == aFuelNormsID);
                if (entity != null)
                {
                    aNormYearID = entity.NormYearID;
                    entities.DM_FuelNorms.Remove(entity);

                    entities.SaveChanges();
                }
            }

            LoadFuelNorms(aNormYearID);
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
                var entity = new DM_FuelNorms();
                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;

                entity.NormYearID = aNormYearID;

                if (insValues.NewValues["AreaCode"] != null)
                {
                    string aAreaCode = insValues.NewValues["AreaCode"].ToString();
                    entity.AreaCode = aAreaCode;
                }

                if (insValues.NewValues["ItemID"] != null)
                {
                    int aItemID = Convert.ToInt32(insValues.NewValues["ItemID"]);
                    entity.ItemID = aItemID;
                }

                if (insValues.NewValues["FuelType"] != null)
                {
                    string aFuelType = insValues.NewValues["FuelType"].ToString();
                    entity.FuelType = aFuelType;
                }

                if (insValues.NewValues["CurrencyCode"] != null)
                {
                    string aCurrencyCode = insValues.NewValues["CurrencyCode"].ToString();
                    entity.CurrencyCode = aCurrencyCode;
                }

                if (insValues.NewValues["Quantity"] != null)
                {
                    decimal aQuantity = Convert.ToDecimal(insValues.NewValues["Quantity"]);
                    entity.Quantity = aQuantity;
                }

                if (insValues.NewValues["UsageRate"] != null)
                {
                    decimal aUsageRate = Convert.ToDecimal(insValues.NewValues["UsageRate"]);
                    entity.UsageRate = aUsageRate;
                }

                if (insValues.NewValues["UnitOfMeasure"] != null)
                {
                    string aUnitOfMeasure = insValues.NewValues["UnitOfMeasure"].ToString();
                    entity.UnitOfMeasure = aUnitOfMeasure;
                }

                if (insValues.NewValues["Description"] != null)
                {
                    string aDescription = insValues.NewValues["Description"].ToString();
                    entity.Description = aDescription;
                }

                entities.DM_FuelNorms.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aFuelNormsID = Convert.ToDecimal(updValues.Keys["FuelNormsID"]);
                var entity = entities.DM_FuelNorms.SingleOrDefault(x => x.FuelNormsID == aFuelNormsID);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["AreaCode"] != null)
                    {
                        string aAreaCode = updValues.NewValues["AreaCode"].ToString();
                        entity.AreaCode = aAreaCode;
                    }

                    if (updValues.NewValues["ItemID"] != null)
                    {
                        int aItemID = Convert.ToInt32(updValues.NewValues["ItemID"]);
                        entity.ItemID = aItemID;
                    }

                    if (updValues.NewValues["FuelType"] != null)
                    {
                        string aFuelType = updValues.NewValues["FuelType"].ToString();
                        entity.FuelType = aFuelType;
                    }

                    if (updValues.NewValues["CurrencyCode"] != null)
                    {
                        string aCurrencyCode = updValues.NewValues["CurrencyCode"].ToString();
                        entity.CurrencyCode = aCurrencyCode;
                    }

                    if (updValues.NewValues["Quantity"] != null)
                    {
                        decimal aQuantity = Convert.ToDecimal(updValues.NewValues["Quantity"]);
                        entity.Quantity = aQuantity;
                    }

                    if (updValues.NewValues["UsageRate"] != null)
                    {
                        decimal aUsageRate = Convert.ToDecimal(updValues.NewValues["UsageRate"]);
                        entity.UsageRate = aUsageRate;
                    }

                    if (updValues.NewValues["UnitOfMeasure"] != null)
                    {
                        string aUnitOfMeasure = updValues.NewValues["UnitOfMeasure"].ToString();
                        entity.UnitOfMeasure = aUnitOfMeasure;
                    }

                    if (updValues.NewValues["Description"] != null)
                    {
                        string aDescription = updValues.NewValues["Description"].ToString();
                        entity.Description = aDescription;
                    }

                }
            }
            entities.SaveChanges();

            LoadFuelNorms(aNormYearID);
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
    protected void DetailGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        decimal aUnitPriceID;
        var aNormYearID = this.GetCallbackIntKeyValue("NormYearID");

        if (args[0] == "DELETE_DETAIL_ROW")
        {
            if (!decimal.TryParse(args[1], out aUnitPriceID))
            {
                var entity = entities.DM_FuelUnitPrices.SingleOrDefault(x => x.UnitPriceID == aUnitPriceID);
                if (entity != null)
                {
                    aNormYearID = entity.NormYearID;

                    entities.DM_FuelUnitPrices.Remove(entity);

                    entities.SaveChanges();
                }
            }

            LoadFuelUnitPrices(aNormYearID);
        }

    }
    protected void DetailGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            var aNormYearID = this.GetCallbackIntKeyValue("NormYearID");

            foreach (ASPxDataInsertValues insValues in e.InsertValues)
            {
                var entity = new DM_FuelUnitPrices();
                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;

                entity.NormYearID = aNormYearID;

                if (insValues.NewValues["VersionID"] != null)
                {
                    decimal aVersionID = Convert.ToDecimal(insValues.NewValues["VersionID"]);
                    entity.VersionID = aVersionID;
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

                if (insValues.NewValues["FuelType"] != null)
                {
                    string aFuelType = insValues.NewValues["FuelType"].ToString();
                    entity.FuelType = aFuelType;
                }

                if (insValues.NewValues["Description"] != null)
                {
                    string aDescription = insValues.NewValues["Description"].ToString();
                    entity.Description = aDescription;
                }

                if (insValues.NewValues["UnitPrice"] != null)
                {
                    decimal aUnitPrice = Convert.ToDecimal(insValues.NewValues["UnitPrice"]);
                    entity.UnitPrice = aUnitPrice;
                }

                if (insValues.NewValues["UnitOfMeasure"] != null)
                {
                    string aUnitOfMeasure = insValues.NewValues["UnitOfMeasure"].ToString();
                    entity.UnitOfMeasure = aUnitOfMeasure;
                }

                entities.DM_FuelUnitPrices.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aUnitPriceID = Convert.ToDecimal(updValues.Keys["UnitPriceID"]);
                var entity = entities.DM_FuelUnitPrices.SingleOrDefault(x => x.UnitPriceID == aUnitPriceID);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["VersionID"] != null)
                    {
                        decimal aVersionID = Convert.ToDecimal(updValues.NewValues["VersionID"]);
                        entity.VersionID = aVersionID;
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

                    if (updValues.NewValues["FuelType"] != null)
                    {
                        string aFuelType = updValues.NewValues["FuelType"].ToString();
                        entity.FuelType = aFuelType;
                    }

                    if (updValues.NewValues["Description"] != null)
                    {
                        string aDescription = updValues.NewValues["Description"].ToString();
                        entity.Description = aDescription;
                    }

                    if (updValues.NewValues["UnitPrice"] != null)
                    {
                        decimal aUnitPrice = Convert.ToDecimal(updValues.NewValues["UnitPrice"]);
                        entity.UnitPrice = aUnitPrice;
                    }

                    if (updValues.NewValues["UnitOfMeasure"] != null)
                    {
                        string aUnitOfMeasure = updValues.NewValues["UnitOfMeasure"].ToString();
                        entity.UnitOfMeasure = aUnitOfMeasure;
                    }

                }
            }
            entities.SaveChanges();

            LoadFuelUnitPrices(aNormYearID);
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
    protected void MasterGrid_RowValidating(object sender, ASPxDataValidationEventArgs e)
    {
        ASPxGridView aGridView = sender as ASPxGridView;
        foreach (GridViewColumn column in aGridView.Columns)
        {
            if (e.NewValues["AreaCode"] == null)
                AddError(e.Errors, aGridView.Columns["AreaCode"], "Chi nhánh bắt buộc nhập.");
            else if (e.NewValues["ItemID"] == null)
                AddError(e.Errors, aGridView.Columns["ItemID"], "Loại trang thiết bị bắt buộc nhập.");
            else if (e.NewValues["FuelType"] == null)
                AddError(e.Errors, aGridView.Columns["FuelType"], "Loại nhiên liệu trang thiết bị bắt buộc nhập.");
            else if (e.NewValues["UsageRate"] == null)
                AddError(e.Errors, aGridView.Columns["UsageRate"], "Tỷ lệ sử dụng nhiên liệu trang thiết bị bắt buộc nhập.");
            else if (e.NewValues["CurrencyCode"] == null)
                AddError(e.Errors, aGridView.Columns["CurrencyCode"], "Loại tiền bắt buộc nhập.");
            else if (e.NewValues["Quantity"] == null)
                AddError(e.Errors, aGridView.Columns["Quantity"], "Định mức nhiên liệu bình quân của TTB bắt buộc nhập.");
            else if (e.NewValues["UsageRate"] != null && !CheckUsageRate(e))
                AddError(e.Errors, aGridView.Columns["UsageRate"], "Tỷ lệ sử dụng nhiên liệu không được vượt quá 100%.");
        }

        if (string.IsNullOrEmpty(e.RowError) && e.Errors.Count > 0)
            e.RowError = "Không thể lưu thông tin!";
    }

    void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
    {
        if (errors.ContainsKey(column)) return;
        errors[column] = errorText;
    }

    private bool CheckUsageRate(ASPxDataValidationEventArgs e)
    {

        decimal aFuelNormsID = 0;
        int aNormYearID = 0;
        string aAreaCode = e.NewValues["AreaCode"].ToString();
        int aItemID = Convert.ToInt32(e.NewValues["ItemID"]);
        decimal aInputValue = Convert.ToDecimal(e.NewValues["UsageRate"]);
        decimal? aUsageRate;

        if (e.IsNewRow)
        {
            aNormYearID = this.GetCallbackIntKeyValue("NormYearID");

            aUsageRate = entities.DM_FuelNorms.Where(x => x.NormYearID == aNormYearID
            && x.AreaCode == aAreaCode && x.ItemID == aItemID)
            .Sum(x => x.UsageRate).Value;
        }
        else
        {
            aNormYearID = this.GetCallbackIntKeyValue("NormYearID");
            aFuelNormsID = Convert.ToDecimal(e.Keys["FuelNormsID"]);

            aUsageRate = entities.DM_FuelNorms.Where(x => x.NormYearID == aNormYearID
                       && x.AreaCode == aAreaCode && x.ItemID == aItemID && x.FuelNormsID != aFuelNormsID)
                       .Sum(x => x.UsageRate);
        }


        if (decimal.Add(aUsageRate.HasValue ? aUsageRate.Value : decimal.Zero, aInputValue) > 100)
            return false;


        return true;
    }
    protected void MasterGrid_StartRowEditing(object sender, ASPxStartRowEditingEventArgs e)
    {
        if (!MasterGrid.IsNewRowEditing)
        {
            MasterGrid.DoRowValidation();
        }
    }
    protected void MasterGrid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
    {
        if (!object.Equals(e.RowType, GridViewRowType.Data)) return;

        bool hasError = (e.GetValue("AreaCode") == null || string.IsNullOrEmpty(e.GetValue("AreaCode").ToString()));
        hasError = hasError || (e.GetValue("ItemID") == null || string.IsNullOrEmpty(e.GetValue("ItemID").ToString()));
        hasError = hasError || (e.GetValue("FuelType") == null || string.IsNullOrEmpty(e.GetValue("FuelType").ToString()));
        hasError = hasError || (e.GetValue("UsageRate") == null || string.IsNullOrEmpty(e.GetValue("UsageRate").ToString()));
        hasError = hasError || (e.GetValue("CurrencyCode") == null || string.IsNullOrEmpty(e.GetValue("CurrencyCode").ToString()));
        hasError = hasError || (e.GetValue("Quantity") == null || string.IsNullOrEmpty(e.GetValue("Quantity").ToString()));
        hasError = hasError || CheckUsageRate(e);

        if (hasError)
        {
            e.Row.ForeColor = System.Drawing.Color.Red;
        }
    }

    private bool CheckUsageRate(ASPxGridViewTableRowEventArgs e)
    {

        decimal aFuelNormsID = 0;
        int aNormYearID = 0;
        string aAreaCode = e.GetValue("AreaCode").ToString();
        int aItemID = Convert.ToInt32(e.GetValue("ItemID"));
        decimal aInputValue = Convert.ToDecimal(e.GetValue("UsageRate"));
        decimal? aUsageRate;

        aNormYearID = Convert.ToInt32(e.GetValue("NormYearID"));
        aFuelNormsID = Convert.ToDecimal(e.KeyValue);

        aUsageRate = entities.DM_FuelNorms.Where(x => x.NormYearID == aNormYearID
                   && x.AreaCode == aAreaCode && x.ItemID == aItemID && x.FuelNormsID != aFuelNormsID)
                   .Sum(x => x.UsageRate);


        if (decimal.Add(aUsageRate.HasValue ? aUsageRate.Value : decimal.Zero, aInputValue) > 100)
            return true;


        return false;
    }
    protected void DetailGrid_RowValidating(object sender, ASPxDataValidationEventArgs e)
    {
        ASPxGridView aGridView = sender as ASPxGridView;
        foreach (GridViewColumn column in aGridView.Columns)
        {
            if (e.NewValues["AreaCode"] == null)
                AddError(e.Errors, aGridView.Columns["AreaCode"], "Chi nhánh bắt buộc nhập.");
            else if (e.NewValues["VersionID"] == null)
                AddError(e.Errors, aGridView.Columns["VersionID"], "Version sản lượng bắt buộc nhập.");
            else if (e.NewValues["EffectiveDateFrom"] == null)
                AddError(e.Errors, aGridView.Columns["EffectiveDateFrom"], "Ngày bắt đầu hiệu lực bắt buộc nhập.");
            else if (e.NewValues["EffectiveDateTo"] == null)
                AddError(e.Errors, aGridView.Columns["EffectiveDateTo"], "Ngày kết thúc hiệu lực bắt buộc nhập.");
            else if (e.NewValues["FuelType"] == null)
                AddError(e.Errors, aGridView.Columns["FuelType"], "Loại nhiên liệu bắt buộc nhập.");
            else if (e.NewValues["UnitPrice"] == null)
                AddError(e.Errors, aGridView.Columns["UnitPrice"], "Đơn giá nhiên liệu bắt buộc nhập.");
            else if (!CheckEffectiveDate(e))
            {
                AddError(e.Errors, aGridView.Columns["EffectiveDateFrom"], "Khoảng ngày hiệu lực không được lồng nhau.");
                AddError(e.Errors, aGridView.Columns["EffectiveDateTo"], "Khoảng ngày hiệu lực không được lồng nhau.");
            }
        }

        if (string.IsNullOrEmpty(e.RowError) && e.Errors.Count > 0)
            e.RowError = "Không thể lưu thông tin!";
    }

    private bool CheckEffectiveDate(ASPxDataValidationEventArgs e)
    {

        decimal aUnitPriceID = 0;
        int aNormYearID = 0;
        string aAreaCode = e.NewValues["AreaCode"].ToString();
        decimal aVersionID = Convert.ToDecimal(e.NewValues["VersionID"]);
        DateTime aEffectiveDateFrom = Convert.ToDateTime(e.NewValues["EffectiveDateFrom"]);
        DateTime aEffectiveDateTo = Convert.ToDateTime(e.NewValues["EffectiveDateTo"]);
        string aFuelType = e.NewValues["FuelType"].ToString();

        if (e.IsNewRow)
        {
            aNormYearID = this.GetCallbackIntKeyValue("NormYearID");

            var aFuelUnitPrices = entities.DM_FuelUnitPrices.Where(x => x.NormYearID == aNormYearID
               && x.AreaCode == aAreaCode && x.VersionID == aVersionID && x.FuelType == aFuelType).ToList();

            if (aFuelUnitPrices == null) return true;

            foreach (var aFuelUnitPrice in aFuelUnitPrices)
            {
                if (aFuelUnitPrice.EffectiveDateFrom >= aEffectiveDateFrom && aFuelUnitPrice.EffectiveDateFrom <= aEffectiveDateTo)
                    return false;

                if (aFuelUnitPrice.EffectiveDateTo >= aEffectiveDateFrom && aFuelUnitPrice.EffectiveDateTo <= aEffectiveDateTo)
                    return false;

                if (aFuelUnitPrice.EffectiveDateFrom <= aEffectiveDateFrom && aFuelUnitPrice.EffectiveDateTo >= aEffectiveDateTo)
                    return false;
            }
        }
        else
        {
            aNormYearID = Convert.ToInt32(e.NewValues["NormYearID"]);
            aUnitPriceID = Convert.ToDecimal(e.Keys["UnitPriceID"]);

            var aFuelUnitPrices = entities.DM_FuelUnitPrices.Where(x => x.NormYearID == aNormYearID
                && x.AreaCode == aAreaCode && x.VersionID == aVersionID && x.FuelType == aFuelType && x.UnitPriceID != aUnitPriceID)
                      .ToList();

            if (aFuelUnitPrices == null) return true;

            foreach (var aFuelUnitPrice in aFuelUnitPrices)
            {
                if (aFuelUnitPrice.EffectiveDateFrom >= aEffectiveDateFrom && aFuelUnitPrice.EffectiveDateFrom <= aEffectiveDateTo)
                    return false;

                if (aFuelUnitPrice.EffectiveDateTo >= aEffectiveDateFrom && aFuelUnitPrice.EffectiveDateTo <= aEffectiveDateTo)
                    return false;

                if (aFuelUnitPrice.EffectiveDateFrom <= aEffectiveDateFrom && aFuelUnitPrice.EffectiveDateTo >= aEffectiveDateTo)
                    return false;
            }
        }

        return true;

    }

    private bool CheckEffectiveDate(ASPxGridViewTableRowEventArgs e)
    {

        decimal aUnitPriceID = 0;
        int aNormYearID = 0;
        string aAreaCode = e.GetValue("AreaCode").ToString();
        decimal aVersionID = Convert.ToDecimal(e.GetValue("VersionID"));
        DateTime aEffectiveDateFrom = Convert.ToDateTime(e.GetValue("EffectiveDateFrom"));
        DateTime aEffectiveDateTo = Convert.ToDateTime(e.GetValue("EffectiveDateTo"));
        string aFuelType = e.GetValue("FuelType").ToString();


        aNormYearID = Convert.ToInt32(e.GetValue("NormYearID"));
        aUnitPriceID = Convert.ToDecimal(e.KeyValue);

        var aFuelUnitPrices = entities.DM_FuelUnitPrices.Where(x => x.NormYearID == aNormYearID
            && x.AreaCode == aAreaCode && x.VersionID == aVersionID && x.FuelType == aFuelType && x.UnitPriceID != aUnitPriceID)
                  .ToList();

        if (aFuelUnitPrices == null) return false;

        foreach (var aFuelUnitPrice in aFuelUnitPrices)
        {
            if (aFuelUnitPrice.EffectiveDateFrom >= aEffectiveDateFrom && aFuelUnitPrice.EffectiveDateFrom <= aEffectiveDateTo)
                return true;

            if (aFuelUnitPrice.EffectiveDateTo >= aEffectiveDateFrom && aFuelUnitPrice.EffectiveDateTo <= aEffectiveDateTo)
                return true;

            if (aFuelUnitPrice.EffectiveDateFrom <= aEffectiveDateFrom && aFuelUnitPrice.EffectiveDateTo >= aEffectiveDateTo)
                return true;
        }

        return false;
    }

    protected void DetailGrid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
    {
        if (!object.Equals(e.RowType, GridViewRowType.Data)) return;

        bool hasError = (e.GetValue("AreaCode") == null || string.IsNullOrEmpty(e.GetValue("AreaCode").ToString()));
        hasError = hasError || (e.GetValue("VersionID") == null || string.IsNullOrEmpty(e.GetValue("VersionID").ToString()));
        hasError = hasError || e.GetValue("EffectiveDateFrom") == null;
        hasError = hasError || e.GetValue("EffectiveDateTo") == null;
        hasError = hasError || (e.GetValue("FuelType") == null || string.IsNullOrEmpty(e.GetValue("FuelType").ToString()));
        hasError = hasError || (e.GetValue("UnitPrice") == null || string.IsNullOrEmpty(e.GetValue("UnitPrice").ToString()));
        hasError = hasError || CheckEffectiveDate(e);

        if (hasError)
        {
            e.Row.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void DetailGrid_StartRowEditing(object sender, ASPxStartRowEditingEventArgs e)
    {
        if (!DetailGrid.IsNewRowEditing)
        {
            DetailGrid.DoRowValidation();
        }
    }
}