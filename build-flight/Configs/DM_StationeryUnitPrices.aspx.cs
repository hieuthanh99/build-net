using DevExpress.Web;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_DM_StationeryUnitPrices : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsCallback || this.NormYearGrid.IsCallback)
            LoadNormYears();


        if (!this.IsCallback || this.MasterGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");
            if (aNormYearID != null)
                LoadMasterUnitPrice(aNormYearID);
        }

        this.DetailGrid.GroupBy(this.DetailGrid.Columns["StationeryType"]);
        LoadStationeries();

        if (!this.IsCallback || this.DetailGrid.IsCallback)
        {
            var aUnitPriceID = this.GetCallbackKeyValue("UnitPriceID");
            if (aUnitPriceID != null)
                this.LoadDetailUnitPrice(aUnitPriceID);
        }

        this.DetailGrid.ExpandAll();
    }

    #region Load dữ liệu
    private decimal GetCallbackDecimalKeyValue(string keyStr)
    {
        string result = null;
        if (Utils.TryGetClientStateValue<string>(this, keyStr, out result))
            return Convert.ToDecimal(result);
        return decimal.Zero;
    }
    private int GetCallbackIntKeyValue(string keyStr)
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

    private void LoadStationeries()
    {
        GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)this.DetailGrid.Columns["StationeryID"];

        if (Session[SessionConstant.STATIONERY_LIST] != null)
            aCombo.PropertiesComboBox.DataSource = Session[SessionConstant.STATIONERY_LIST];
        else
        {
            var list = entities.DecStationeries.OrderBy(x => x.StationeryID).ToList();
            Session[SessionConstant.STATIONERY_LIST] = list;
            aCombo.PropertiesComboBox.DataSource = list;
        }

        aCombo.PropertiesComboBox.ValueField = "StationeryID";
        aCombo.PropertiesComboBox.TextField = "StationeryName";
    }

    private int GetCallbackKeyValue(string keyStr)
    {
        string result = null;
        if (Utils.TryGetClientStateValue<string>(this, keyStr, out result))
            return Convert.ToInt32(result);
        return 0;
    }

    private void LoadMasterUnitPrice(int NormYearID)
    {
        string aAreaCode = SessionUser.AreaCode;

        if (Object.Equals(aAreaCode, "KCQ"))
            aAreaCode = "ALL";

        var list = entities.DM_StationeryUnitPrices
            .Where(x => x.NormYearID == NormYearID && ((x.AreaCode == aAreaCode) || aAreaCode == "ALL"))
            .OrderByDescending(x => x.SignDate).ToList();

        this.MasterGrid.DataSource = list;
        this.MasterGrid.DataBind();
    }

    private void LoadDetailUnitPrice(int UnitPriceID)
    {
        var list = entities.DM_StationeryUnitPriceDetails
            .Where(x => x.UnitPriceID == UnitPriceID)
            .Select(x => new StationeryUnitPrice
            {
                UnitPriceDetailID = x.UnitPriceDetailID,
                UnitPriceID = x.UnitPriceID,
                StationeryID = x.StationeryID,
                Description = x.Description,
                Quantity = x.Quantity,
                UnitOfMeasure = x.UnitOfMeasure,
                UnitPrice = x.UnitPrice,
                Amount = x.Amount,
                CreateDate = x.CreateDate,
                CreatedBy = x.CreatedBy,
                LastUpdateDate = x.LastUpdateDate,
                LastUpdatedBy = x.LastUpdatedBy,
                StationeryType = x.DecStationery.StationeryType
            })
            .OrderBy(x => x.StationeryID).ToList();
        this.DetailGrid.DataSource = list;
        this.DetailGrid.DataBind();
    }


    protected string GetSummaryValue(string fieldName)
    {
        ASPxSummaryItem summaryItem = DetailGrid.TotalSummary.First(i => i.Tag == fieldName + "_Sum");
        return Convert.ToDecimal(DetailGrid.GetTotalSummaryValue(summaryItem)).ToString("N0");
    }
    #endregion
    protected void MasterGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        var aNormYearID = this.GetCallbackKeyValue("NormYearID");
        int aUnitPriceID;

        if (args[0] == "DELETE_MASTER_ROW")
        {
            if (!int.TryParse(args[1], out aUnitPriceID))
                return;


            var entity = entities.DM_StationeryUnitPrices.SingleOrDefault(x => x.UnitPriceID == aUnitPriceID);
            if (entity != null)
            {
                entities.DM_StationeryUnitPriceDetails.RemoveRange(entities.DM_StationeryUnitPriceDetails.Where(x => x.UnitPriceID == aUnitPriceID));

                entities.DM_StationeryUnitPrices.Remove(entity);

                entities.SaveChanges();
            }

            LoadMasterUnitPrice(aNormYearID);
        }
    }
    protected void MasterGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");
            foreach (ASPxDataInsertValues insValues in e.InsertValues)
            {
                var entity = new DM_StationeryUnitPrices();
                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;

                entity.NormYearID = aNormYearID;

                if (insValues.NewValues["AreaCode"] != null)
                {
                    string aAreaCode = insValues.NewValues["AreaCode"].ToString();
                    entity.AreaCode = aAreaCode;
                }

                if (insValues.NewValues["ContractNo"] != null)
                {
                    string aContractNo = insValues.NewValues["ContractNo"].ToString();
                    entity.ContractNo = aContractNo;
                }

                if (insValues.NewValues["SignDate"] != null)
                {
                    DateTime aSignDate = Convert.ToDateTime(insValues.NewValues["SignDate"]);
                    entity.SignDate = aSignDate;
                }

                if (insValues.NewValues["SupplierName"] != null)
                {
                    string aSupplierName = insValues.NewValues["SupplierName"].ToString();
                    entity.SupplierName = aSupplierName;
                }

                if (insValues.NewValues["SupplierAddress"] != null)
                {
                    string aSupplierAddress = insValues.NewValues["SupplierAddress"].ToString();
                    entity.SupplierAddress = aSupplierAddress;
                }

                if (insValues.NewValues["SupplierTaxCode"] != null)
                {
                    string aSupplierTaxCode = insValues.NewValues["SupplierTaxCode"].ToString();
                    entity.SupplierTaxCode = aSupplierTaxCode;
                }

                if (insValues.NewValues["Description"] != null)
                {
                    string aDescription = insValues.NewValues["Description"].ToString();
                    entity.Description = aDescription;
                }

                entities.DM_StationeryUnitPrices.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aUnitPriceID = Convert.ToDecimal(updValues.Keys["UnitPriceID"]);
                var entity = entities.DM_StationeryUnitPrices.SingleOrDefault(x => x.UnitPriceID == aUnitPriceID);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["AreaCode"] != null)
                    {
                        string aAreaCode = updValues.NewValues["AreaCode"].ToString();
                        entity.AreaCode = aAreaCode;
                    }


                    if (updValues.NewValues["ContractNo"] != null)
                    {
                        string aContractNo = updValues.NewValues["ContractNo"].ToString();
                        entity.ContractNo = aContractNo;
                    }

                    if (updValues.NewValues["SignDate"] != null)
                    {
                        DateTime aSignDate = Convert.ToDateTime(updValues.NewValues["SignDate"]);
                        entity.SignDate = aSignDate;
                    }

                    if (updValues.NewValues["SupplierName"] != null)
                    {
                        string aSupplierName = updValues.NewValues["SupplierName"].ToString();
                        entity.SupplierName = aSupplierName;
                    }

                    if (updValues.NewValues["SupplierAddress"] != null)
                    {
                        string aSupplierAddress = updValues.NewValues["SupplierAddress"].ToString();
                        entity.SupplierAddress = aSupplierAddress;
                    }

                    if (updValues.NewValues["SupplierTaxCode"] != null)
                    {
                        string aSupplierTaxCode = updValues.NewValues["SupplierTaxCode"].ToString();
                        entity.SupplierTaxCode = aSupplierTaxCode;
                    }

                    if (updValues.NewValues["Description"] != null)
                    {
                        string aDescription = updValues.NewValues["Description"].ToString();
                        entity.Description = aDescription;
                    }

                }
            }
            entities.SaveChanges();

            LoadMasterUnitPrice(aNormYearID);
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
        int aUnitPriceID = this.GetCallbackKeyValue("UnitPriceID");

        if (args[0] == "LOAD_DETAIL")
        {

        }

        if (args[0] == "DELETE_DETAIL_ROW")
        {
            decimal aUnitPriceDetailID;
            if (!decimal.TryParse(args[1], out aUnitPriceDetailID))
                return;

            var entity = entities.DM_StationeryUnitPriceDetails.SingleOrDefault(x => x.UnitPriceDetailID == aUnitPriceDetailID);
            if (entity != null)
            {
                aUnitPriceID = entity.UnitPriceID;
                entities.DM_StationeryUnitPriceDetails.Remove(entity);

                entities.SaveChanges();
            }

            this.LoadDetailUnitPrice(aUnitPriceID);
        }

        if (args[0] == "ADD_STATIONERY")
        {
            int[] stationeryKeys = null;

            if (!int.TryParse(args[1], out aUnitPriceID))
                return;

            if (!TryParseKeyValues(args.Skip(2), out stationeryKeys))
                return;

            foreach (int stationeryKey in stationeryKeys)
            {
                var entity = new DM_StationeryUnitPriceDetails()
                {
                    StationeryID = stationeryKey,
                    UnitPriceID = aUnitPriceID,
                    UnitOfMeasure = GetUnitOfMeasure(stationeryKey),
                    Quantity = 0,
                    UnitPrice = 0,
                    CreateDate = DateTime.Now,
                    CreatedBy = (int)SessionUser.UserID
                };

                entities.DM_StationeryUnitPriceDetails.Add(entity);
            }
            entities.SaveChanges();

            this.LoadDetailUnitPrice(aUnitPriceID);
        }

        this.DetailGrid.ExpandAll();
    }
    protected void DetailGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        var aUnitPriceID = 0;
        try
        {
            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aUnitPriceDetailID = Convert.ToDecimal(updValues.Keys["UnitPriceDetailID"]);
                var entity = entities.DM_StationeryUnitPriceDetails.SingleOrDefault(x => x.UnitPriceDetailID == aUnitPriceDetailID);
                if (entity != null)
                {
                    if (aUnitPriceID != null)
                        aUnitPriceID = entity.UnitPriceID;

                    if (updValues.NewValues["StationeryID"] != null)
                    {
                        int aStationeryID = Convert.ToInt32(updValues.NewValues["StationeryID"].ToString());
                        entity.StationeryID = aStationeryID;
                    }

                    if (updValues.NewValues["Description"] != null)
                    {
                        string aDescription = updValues.NewValues["Description"].ToString();
                        entity.Description = aDescription;
                    }

                    if (updValues.NewValues["Quantity"] != null)
                    {
                        decimal aQuantity = Convert.ToDecimal(updValues.NewValues["Quantity"].ToString());
                        entity.Quantity = aQuantity;
                    }

                    if (updValues.NewValues["UnitOfMeasure"] != null)
                    {
                        string aUnitOfMeasure = updValues.NewValues["UnitOfMeasure"].ToString();
                        entity.UnitOfMeasure = aUnitOfMeasure;
                    }

                    if (updValues.NewValues["UnitPrice"] != null)
                    {
                        decimal aUnitPrice = Convert.ToDecimal(updValues.NewValues["UnitPrice"].ToString());
                        entity.UnitPrice = aUnitPrice;
                    }

                    if (updValues.NewValues["Amount"] != null)
                    {
                        decimal aAmount = Convert.ToDecimal(updValues.NewValues["Amount"].ToString());
                        entity.Amount = aAmount;
                    }
                }
            }
            entities.SaveChanges();

            LoadDetailUnitPrice(aUnitPriceID);
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
    protected void DetailGrid_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
    {
        var Grid = (sender as ASPxGridView);

        if (e.Column.FieldName == "StationeryType")
        {
            var entity = Grid.GetRow(e.VisibleIndex) as StationeryUnitPrice;
            if (entity == null) return;

            e.EncodeHtml = false;
            e.DisplayText = String.Format("<span style='font-weight:bold;'>{0}</span>", entity.StationeryType.Equals("DC") ? "DANH MỤC DÙNG CHUNG" : "DANH MỤC THEO CHỨC DANH");

        }
    }

    private string GetUnitOfMeasure(int pStationeryID)
    {
        var entity = entities.DecStationeries.SingleOrDefault(x => x.StationeryID == pStationeryID);
        if (entity != null)
            return entity.UnitOfMeasure;

        return string.Empty;
    }

    protected bool TryParseKeyValues(IEnumerable<string> stringKeys, out int[] resultKeys)
    {
        resultKeys = null;
        var list = new List<int>();
        foreach (var sKey in stringKeys)
        {
            int key;
            if (!int.TryParse(sKey, out key))
                return false;
            list.Add(key);
        }
        resultKeys = list.ToArray();
        return true;
    }
}
