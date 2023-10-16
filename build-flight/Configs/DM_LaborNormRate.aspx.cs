using DevExpress.Web;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_DM_LaborNormRate : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadNormYear();
        LoadAreaCode();
        LoadExpendRate();
    }

    private void LoadExpendRate()
    {
        var list = entities.DM_LaborNormRates.ToList();

        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }

    private void LoadNormYear()
    {
        GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)DataGrid.Columns["NormYearID"];

        if (Session[SessionConstant.NORMYEAR_LIST] != null)
            aCombo.PropertiesComboBox.DataSource = Session[SessionConstant.NORMYEAR_LIST];
        else
        {
            var list = entities.DM_NormYears.Where(x => (x.DeleteFlag ?? false) == false).ToList();
            Session[SessionConstant.NORMYEAR_LIST] = list;
            aCombo.PropertiesComboBox.DataSource = list;
        }

        aCombo.PropertiesComboBox.ValueField = "NormYearID";
        aCombo.PropertiesComboBox.TextField = "Description";
    }

    private void LoadAreaCode()
    {
        GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)DataGrid.Columns["AreaCode"];

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

    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        int aExpendRateID;

        if (args[0] == "DELETE")
        {
            if (!int.TryParse(args[1], out aExpendRateID))
                return;

            var entity = entities.DM_LaborNormRates.SingleOrDefault(x => x.ExpendRateID == aExpendRateID);
            if (entity != null)
            {
                entities.DM_LaborNormRates.Remove(entity);


                entities.SaveChanges();
                LoadExpendRate();
            }
        }
    }
    protected void DataGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
    {

    }
    protected void DataGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;

        try
        {
            foreach (ASPxDataInsertValues insValues in e.InsertValues)
            {
                var entity = new DM_LaborNormRates();
                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;

                if (insValues.NewValues["NormYearID"] != null)
                {
                    int aNormYearID = Convert.ToInt32(insValues.NewValues["NormYearID"]);
                    entity.NormYearID = aNormYearID;
                }

                if (insValues.NewValues["AreaCode"] != null)
                {
                    string aAreaCode = insValues.NewValues["AreaCode"].ToString();
                    entity.AreaCode = aAreaCode;
                }

                if (insValues.NewValues["ExpendType"] != null)
                {
                    string aExpendType = insValues.NewValues["ExpendType"].ToString();
                    entity.ExpendType = aExpendType;
                }

                if (insValues.NewValues["ForPax"] != null)
                {
                    decimal aForPax = Convert.ToDecimal(insValues.NewValues["ForPax"]);
                    entity.ForPax = aForPax;
                }

                if (insValues.NewValues["ForCargo"] != null)
                {
                    decimal aForCargo = Convert.ToDecimal(insValues.NewValues["ForCargo"]);
                    entity.ForCargo = aForCargo;
                }

                if (insValues.NewValues["CommonRate"] != null)
                {
                    decimal aCommonRate = Convert.ToDecimal(insValues.NewValues["CommonRate"]);
                    entity.CommonRate = aCommonRate;
                }

                if (insValues.NewValues["Description"] != null)
                {
                    string aDescription = insValues.NewValues["Description"].ToString();
                    entity.Description = aDescription;
                }

                entities.DM_LaborNormRates.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                int aExpendRateID = Convert.ToInt32(updValues.Keys["ExpendRateID"]);
                var entity = entities.DM_LaborNormRates.SingleOrDefault(x => x.ExpendRateID == aExpendRateID);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["NormYearID"] != null)
                    {
                        int aNormYearID = Convert.ToInt32(updValues.NewValues["NormYearID"]);
                        entity.NormYearID = aNormYearID;
                    }

                    if (updValues.NewValues["AreaCode"] != null)
                    {
                        string aAreaCode = updValues.NewValues["AreaCode"].ToString();
                        entity.AreaCode = aAreaCode;
                    }

                    if (updValues.NewValues["ExpendType"] != null)
                    {
                        string aExpendType = updValues.NewValues["ExpendType"].ToString();
                        entity.ExpendType = aExpendType;
                    }

                    if (updValues.NewValues["ForPax"] != null)
                    {
                        decimal aForPax = Convert.ToDecimal(updValues.NewValues["ForPax"]);
                        entity.ForPax = aForPax;
                    }

                    if (updValues.NewValues["ForCargo"] != null)
                    {
                        decimal aForCargo = Convert.ToDecimal(updValues.NewValues["ForCargo"]);
                        entity.ForCargo = aForCargo;
                    }

                    if (updValues.NewValues["CommonRate"] != null)
                    {
                        decimal aCommonRate = Convert.ToDecimal(updValues.NewValues["CommonRate"]);
                        entity.CommonRate = aCommonRate;
                    }

                    if (updValues.NewValues["Description"] != null)
                    {
                        string aDescription = updValues.NewValues["Description"].ToString();
                        entity.Description = aDescription;
                    }
                }
            }
            entities.SaveChanges();

            LoadExpendRate();
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
}