using DevExpress.Web;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_DM_Stationeries : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsCallback || this.NormYearGrid.IsCallback)
            LoadNormYears();

        if (!this.IsCallback || this.CompanyGrid.IsCallback)
            LoadCompanies();

        LoadPositionType();

        if (!IsPostBack)
        {

            this.CompanyGrid.ExpandAll();
        }
        if (this.CommonNormGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");
            var aCompanyID = this.GetCallbackKeyValue("CompanyID");
            this.LoadCommonStationeries(aNormYearID, aCompanyID);
        }

        if (this.PositionGrid.IsCallback)
        {
            var aCompanyID = this.GetCallbackKeyValue("CompanyID");

            this.LoadSTAPositionCompany(aCompanyID);
        }

        if (this.PositionNormGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");
            var aPostionCompanyID = this.GetCallbackKeyValue("PostionCompanyID");

            this.LoadPositionStationeries(aNormYearID, aPostionCompanyID);
        }


    }

    #region Load Data
    private void LoadNormYears()
    {
        var list = entities.DM_NormYears
            .OrderByDescending(x => x.ForYear)
            .ToList();

        this.NormYearGrid.DataSource = list;
        this.NormYearGrid.DataBind();
    }
    private void LoadPositionType()
    {
        GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)PositionGrid.Columns["PositionTypeID"];

        if (Session[SessionConstant.POSITION_TYPE] != null)
            aCombo.PropertiesComboBox.DataSource = Session[SessionConstant.POSITION_TYPE];
        else
        {
            var list = entities.DecPositionTypes.OrderBy(x => x.Seq).ToList();
            Session[SessionConstant.POSITION_TYPE] = list;
            aCombo.PropertiesComboBox.DataSource = list;
        }

        aCombo.PropertiesComboBox.ValueField = "PositionTypeID";
        aCombo.PropertiesComboBox.TextField = "PositionTypeName";
    }

    private void LoadCompanies()
    {
        var list = entities.DecCompanies
            .Where(x => (x.IsExternalCost ?? false) == false && x.IsOnBehalfOf == "NO" && x.Active == true)
            .Select(x => new
            {
                CompanyID = x.CompanyID,
                ParentID = x.ParentID,
                NameV = x.NameV
            })
            .ToList();

        this.CompanyGrid.DataSource = list;
        this.CompanyGrid.DataBind();
    }

    private void LoadCommonStationeries(int pNormYearID, int pCompanyID)
    {
        var list = entities.DM_CommonStationeries
            .Where(x => x.NormYearID == pNormYearID && x.CompanyID == pCompanyID).ToList();

        this.CommonNormGrid.DataSource = list;
        this.CommonNormGrid.DataBind();
    }

    private void LoadSTAPositionCompany(int pCompanyID)
    {
        var list = entities.DM_STAPositionCompany
            .Where(x => x.CompanyID == pCompanyID).ToList();

        this.PositionGrid.DataSource = list;
        this.PositionGrid.DataBind();
    }


    private void LoadPositionStationeries(int pNormYearID, decimal pPositionCompanyID)
    {
        var list = entities.DM_PositionStationeries.Where(x => x.PositionCompanyID == pPositionCompanyID).ToList();

        this.PositionNormGrid.DataSource = list;
        this.PositionNormGrid.DataBind();
    }


    private int GetCallbackKeyValue(string keyStr)
    {
        string result = null;
        if (Utils.TryGetClientStateValue<string>(this, keyStr, out result))
            return Convert.ToInt32(result);
        return 0;
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

    private string GetUnitOfMeasure(int pStationeryID)
    {
        var entity = entities.DecStationeries.SingleOrDefault(x => x.StationeryID == pStationeryID);
        if (entity != null)
            return entity.UnitOfMeasure;

        return string.Empty;
    }
    #endregion
    protected void CommonNormGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        int aCompanyID = 0;
        decimal aCommonStationeryID;

        var aNormYearID = this.GetCallbackKeyValue("NormYearID");

        if (args[0] == "LOAD_COMMON_STATIONERY")
        {
            //Do nothing
        }

        if (args[0] == "ADD_STATIONERY")
        {
            int[] stationeryKeys = null;

            if (!int.TryParse(args[1], out aCompanyID))
                return;

            if (!TryParseKeyValues(args.Skip(2), out stationeryKeys))
                return;

            foreach (int stationeryKey in stationeryKeys)
            {
                var entity = new DM_CommonStationeries()
                {
                    CompanyID = aCompanyID,
                    NormYearID = aNormYearID,
                    StationeryID = stationeryKey,
                    UnitOfMeasure = GetUnitOfMeasure(stationeryKey),
                    Quantity = 0,
                    Inactive = false,
                    CreateDate = DateTime.Now,
                    CreatedBy = (int)SessionUser.UserID
                };

                entities.DM_CommonStationeries.Add(entity);
            }
            entities.SaveChanges();

            this.LoadCommonStationeries(aNormYearID, aCompanyID);
        }

        if (args[0] == "DELETE_COMMON_STATIONERY")
        {
            if (!decimal.TryParse(args[1], out aCommonStationeryID))
                return;

            var entity = entities.DM_CommonStationeries.SingleOrDefault(x => x.CommonStationeryID == aCommonStationeryID);
            if (entity != null)
            {
                aCompanyID = entity.CompanyID;
                aNormYearID = entity.NormYearID;
                entities.DM_CommonStationeries.Remove(entity);

                entities.SaveChanges();
            }

            this.LoadCommonStationeries(aNormYearID, aCompanyID);
        }
    }
    protected void CommonNormGrid_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
    {
        var Grid = (sender as ASPxGridView);
        if (e.Column.FieldName == "StationeryName")
        {
            var entity = Grid.GetRow(e.VisibleIndex) as DM_CommonStationeries;
            if (entity == null) return;
            var aStationeryID = entity.StationeryID;
            var aStationery = entities.DecStationeries.Where(x => x.StationeryID == aStationeryID).SingleOrDefault();
            if (aStationery != null)
            {
                e.EncodeHtml = false;
                e.DisplayText = aStationery.StationeryName;
            }
        }
    }
    protected void PositionNormGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        decimal aPositionCompanyID = 0;
        var aNormYearID = this.GetCallbackKeyValue("NormYearID");

        if (args[0] == "LOAD_POSITION_STATIONERY")
        {
            //Do nothing
        }

        if (args[0] == "ADD_STATIONERY")
        {
            int[] stationeryKeys = null;

            if (!decimal.TryParse(args[1], out aPositionCompanyID))
                return;

            if (!TryParseKeyValues(args.Skip(2), out stationeryKeys))
                return;

            foreach (int stationeryKey in stationeryKeys)
            {
                var entity = new DM_PositionStationeries()
                {
                    PositionCompanyID = aPositionCompanyID,
                    NormYearID = aNormYearID,
                    StationeryID = stationeryKey,
                    UnitOfMeasure = GetUnitOfMeasure(stationeryKey),
                    Quantity = 0,
                    Inactive = false,
                    CreateDate = DateTime.Now,
                    CreatedBy = (int)SessionUser.UserID
                };

                entities.DM_PositionStationeries.Add(entity);
            }
            entities.SaveChanges();

            this.LoadPositionStationeries(aNormYearID, aPositionCompanyID);
        }

        if (args[0] == "DELETE_POSITION_STATIONERY")
        {

            if (!decimal.TryParse(args[1], out aPositionCompanyID))
                return;
        }
    }
    protected void PositionNormGrid_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
    {
        var Grid = (sender as ASPxGridView);
        if (e.Column.FieldName == "StationeryName")
        {
            var entity = Grid.GetRow(e.VisibleIndex) as DM_PositionStationeries;
            if (entity == null) return;
            var aStationeryID = entity.StationeryID;
            var aStationery = entities.DecStationeries.Where(x => x.StationeryID == aStationeryID).SingleOrDefault();
            if (aStationery != null)
            {
                e.EncodeHtml = false;
                e.DisplayText = aStationery.StationeryName;
            }
        }
    }
    protected void CommonNormGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        int aCompanyID = 0;
        try
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");
            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aCommonStationeryID = Convert.ToDecimal(updValues.Keys["CommonStationeryID"]);
                var entity = entities.DM_CommonStationeries.SingleOrDefault(x => x.CommonStationeryID == aCommonStationeryID);
                if (entity != null)
                {
                    if (updValues.NewValues["Quantity"] != null)
                    {
                        decimal aQuantity = Convert.ToDecimal(updValues.NewValues["Quantity"].ToString());
                        entity.Quantity = aQuantity;
                    }

                    if (updValues.NewValues["Description"] != null)
                    {
                        string aDescription = updValues.NewValues["Description"].ToString();
                        entity.Description = aDescription;
                    }

                    if (updValues.NewValues["Inactive"] != null)
                    {
                        bool aInactive = (bool)updValues.NewValues["Inactive"];
                        entity.Inactive = aInactive;
                    }

                    if (aCompanyID == 0)
                        aCompanyID = entity.CompanyID;
                }
            }
            entities.SaveChanges();
            LoadCommonStationeries(aNormYearID, aCompanyID);
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
    protected void PositionGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        decimal aPositionCompanyID;

        if (args[0] == "DELETE_POSITION_STATIONERY")
        {

            if (!decimal.TryParse(args[1], out aPositionCompanyID))
                return;
        }
    }
    protected void PositionGrid_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;

        try
        {
            var aCompanyID = this.GetCallbackKeyValue("CompanyID");
            if (aCompanyID != null)
            {
                foreach (ASPxDataInsertValues insValues in e.InsertValues)
                {
                    var entity = new DM_STAPositionCompany();
                    entity.CompanyID = aCompanyID;
                    //entity.ForYear = DateTime.Now.Year;
                    entity.Inactive = false;
                    entity.CreateDate = DateTime.Now;
                    entity.CreatedBy = (int)SessionUser.UserID;

                    if (insValues.NewValues["Quantity"] != null)
                    {
                        int aQuantity = Convert.ToInt32(insValues.NewValues["Quantity"].ToString());
                        entity.Quantity = aQuantity;
                    }

                    if (insValues.NewValues["PositionTypeID"] != null)
                    {
                        int aPositionTypeID = Convert.ToInt32(insValues.NewValues["PositionTypeID"]);
                        entity.PositionTypeID = aPositionTypeID;
                    }

                    entities.DM_STAPositionCompany.Add(entity);
                }

                foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
                {
                    decimal aPositionCompanyID = Convert.ToDecimal(updValues.Keys["PositionCompanyID"]);
                    var entity = entities.DM_STAPositionCompany.SingleOrDefault(x => x.PositionCompanyID == aPositionCompanyID);
                    if (entity != null)
                    {
                        if (updValues.NewValues["Quantity"] != null)
                        {
                            int aQuantity = Convert.ToInt32(updValues.NewValues["Quantity"].ToString());
                            entity.Quantity = aQuantity;
                        }

                        if (updValues.NewValues["PositionTypeID"] != null)
                        {
                            int aPositionTypeID = Convert.ToInt32(updValues.NewValues["PositionTypeID"]);
                            entity.PositionTypeID = aPositionTypeID;
                        }

                        if (aCompanyID == 0)
                            aCompanyID = entity.CompanyID;
                    }
                }
                entities.SaveChanges();

            }
            LoadSTAPositionCompany(aCompanyID);
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }

    protected void PositionNormGrid_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;

        try
        {
            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aPositionStationeryID = Convert.ToDecimal(updValues.Keys["PositionStationeryID"]);
                var entity = entities.DM_PositionStationeries.SingleOrDefault(x => x.PositionStationeryID == aPositionStationeryID);
                if (entity != null)
                {
                    if (updValues.NewValues["Quantity"] != null)
                    {
                        int aQuantity = Convert.ToInt32(updValues.NewValues["Quantity"].ToString());
                        entity.Quantity = aQuantity;
                    }

                    if (updValues.NewValues["Description"] != null)
                    {
                        string aDescription = updValues.NewValues["Description"].ToString();
                        entity.Description = aDescription;
                    }

                    if (updValues.NewValues["Inactive"] != null)
                    {
                        bool aInactive = (bool)updValues.NewValues["Inactive"];
                        entity.Inactive = aInactive;
                    }
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