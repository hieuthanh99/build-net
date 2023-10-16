using DevExpress.Web;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_FuelPrice : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadVersionID(DataGrid);
        LoadData();
    }

    private void LoadData()
    {
        var list = entities.FuelPrices.ToList();

        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }

    private void LoadVersionID(ASPxGridView Grid)
    {
        GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)Grid.Columns["VersionID"];

        var list = entities.Versions.Where(x => x.Active == true).OrderBy(x => x.VersionYear).ToList();
        aCombo.PropertiesComboBox.DataSource = list;
        aCombo.PropertiesComboBox.ValueField = "VersionID";
        aCombo.PropertiesComboBox.TextField = "VersionName";
    }

    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        long key;

        if (args[0] == "DELETE")
        {
            if (!long.TryParse(args[1], out key))
                return;

            var entity = entities.FuelPrices.SingleOrDefault(x => x.Id == key);
            if (entity != null)
            {
                entities.FuelPrices.Remove(entity);

                entities.SaveChanges();
                LoadData();
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
                var entity = new FuelPrice();
                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;

                if (insValues.NewValues["VersionID"] != null)
                {
                    decimal aVersionID = Convert.ToDecimal(insValues.NewValues["VersionID"]);
                    entity.VersionID = aVersionID;
                }

                if (insValues.NewValues["ForYear"] != null)
                {
                    int aForYear = Convert.ToInt32(insValues.NewValues["ForYear"]);
                    entity.ForYear = aForYear;
                }

                decimal aMonth = decimal.Zero;
                if (insValues.NewValues["M01"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M01"]);
                    entity.M01 = aMonth;
                }

                if (insValues.NewValues["M02"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M02"]);
                    entity.M02 = aMonth;
                }

                if (insValues.NewValues["M03"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M03"]);
                    entity.M03 = aMonth;
                }

                if (insValues.NewValues["M04"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M04"]);
                    entity.M04 = aMonth;
                }

                if (insValues.NewValues["M05"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M05"]);
                    entity.M05 = aMonth;
                }

                if (insValues.NewValues["M06"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M06"]);
                    entity.M06 = aMonth;
                }

                if (insValues.NewValues["M07"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M07"]);
                    entity.M07 = aMonth;
                }

                if (insValues.NewValues["M08"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M08"]);
                    entity.M08 = aMonth;
                }

                if (insValues.NewValues["M09"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M09"]);
                    entity.M09 = aMonth;
                }

                if (insValues.NewValues["M10"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M10"]);
                    entity.M10 = aMonth;
                }

                if (insValues.NewValues["M11"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M11"]);
                    entity.M11 = aMonth;
                }

                if (insValues.NewValues["M12"] != null)
                {
                    aMonth = Convert.ToDecimal(insValues.NewValues["M12"]);
                    entity.M12 = aMonth;
                }

                if (insValues.NewValues["Remark"] != null)
                {
                    string aRemark = insValues.NewValues["Remark"].ToString();
                    entity.Remark = aRemark;
                }

                entities.FuelPrices.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                long key = Convert.ToInt64(updValues.Keys["Id"]);
                var entity = entities.FuelPrices.SingleOrDefault(x => x.Id == key);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["VersionID"] != null)
                    {
                        decimal aVersionID = Convert.ToDecimal(updValues.NewValues["VersionID"]);
                        entity.VersionID = aVersionID;
                    }

                    if (updValues.NewValues["ForYear"] != null)
                    {
                        int aForYear = Convert.ToInt32(updValues.NewValues["ForYear"]);
                        entity.ForYear = aForYear;
                    }


                    decimal aMonth = decimal.Zero;
                    if (updValues.NewValues["M01"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M01"]);
                        entity.M01 = aMonth;
                    }
                    else
                        entity.M01 = decimal.Zero;

                    if (updValues.NewValues["M02"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M02"]);
                        entity.M02 = aMonth;
                    }
                    else
                        entity.M02 = decimal.Zero;

                    if (updValues.NewValues["M03"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M03"]);
                        entity.M03 = aMonth;
                    }
                    else
                        entity.M03 = decimal.Zero;

                    if (updValues.NewValues["M04"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M04"]);
                        entity.M04 = aMonth;
                    }
                    else
                        entity.M04 = decimal.Zero;

                    if (updValues.NewValues["M05"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M05"]);
                        entity.M05 = aMonth;
                    }
                    else
                        entity.M05 = decimal.Zero;

                    if (updValues.NewValues["M06"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M06"]);
                        entity.M06 = aMonth;
                    }
                    else
                        entity.M06 = decimal.Zero;

                    if (updValues.NewValues["M07"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M07"]);
                        entity.M07 = aMonth;
                    }
                    else
                        entity.M07 = decimal.Zero;

                    if (updValues.NewValues["M08"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M08"]);
                        entity.M08 = aMonth;
                    }
                    else
                        entity.M08 = decimal.Zero;

                    if (updValues.NewValues["M09"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M09"]);
                        entity.M09 = aMonth;
                    }
                    else
                        entity.M09 = decimal.Zero;

                    if (updValues.NewValues["M10"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M10"]);
                        entity.M10 = aMonth;
                    }
                    else
                        entity.M10 = decimal.Zero;

                    if (updValues.NewValues["M11"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M11"]);
                        entity.M11 = aMonth;
                    }
                    else
                        entity.M11 = decimal.Zero;

                    if (updValues.NewValues["M12"] != null)
                    {
                        aMonth = Convert.ToDecimal(updValues.NewValues["M12"]);
                        entity.M12 = aMonth;
                    }
                    else
                        entity.M12 = decimal.Zero;

                    if (updValues.NewValues["Remark"] != null)
                    {
                        string aRemark = updValues.NewValues["Remark"].ToString();
                        entity.Remark = aRemark;
                    }
                    else
                        entity.Remark = string.Empty;
                }
            }
            entities.SaveChanges();

            LoadData();
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }

    protected void DataGrid_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
    {
        ASPxEdit editor = (ASPxEdit)e.Editor;
        editor.ValidationSettings.Display = Display.None;
    }

    protected void Callback_Callback(object source, CallbackEventArgs e)
    {
        var args = e.Parameter.Split('|');
        if(args[0]== "GETYEAR")
        {
            decimal versionId;
            if (!decimal.TryParse(args[1], out versionId))
                return;

            var version = entities.Versions.Where(x => x.VersionID == versionId).FirstOrDefault();
            if (version != null)
                e.Result = version.VersionYear.ToString();
            else
                e.Result = DateTime.Now.Year.ToString();
            
                
        }
    }
}