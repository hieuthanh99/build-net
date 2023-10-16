using DevExpress.Web;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_FerryFlightConfigs : BasePageNotCheckURL
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDataToGrid();
    }
    private void LoadDataToGrid()
    {
        var list = entities.FerryFlightConfigs.ToList();

        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }

    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        int aFerryFlightConfigID;

        if (args[0] == "DELETE")
        {
            if (!int.TryParse(args[1], out aFerryFlightConfigID))
                return;

            var entity = entities.FerryFlightConfigs.SingleOrDefault(x => x.FerryFlightConfigID == aFerryFlightConfigID);
            if (entity != null)
            {
                entities.FerryFlightConfigs.Remove(entity);


                entities.SaveChanges();
                LoadDataToGrid();
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
                var entity = new FerryFlightConfig();
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

                if (insValues.NewValues["MTOW"] != null)
                {
                    int aMTOW = Convert.ToInt32(insValues.NewValues["MTOW"]);
                    entity.MTOW = aMTOW;
                }

                if (insValues.NewValues["InOut"] != null)
                {
                    string aInOut = insValues.NewValues["InOut"].ToString();
                    entity.InOut = aInOut;
                }

                if (insValues.NewValues["Coefficient"] != null)
                {
                    decimal aCoefficient = Convert.ToDecimal(insValues.NewValues["Coefficient"]);
                    entity.Coefficient = aCoefficient;
                }
                
                if (insValues.NewValues["Description"] != null)
                {
                    string aDescription = insValues.NewValues["Description"].ToString();
                    entity.Description = aDescription;
                }

                entities.FerryFlightConfigs.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                int aFerryFlightConfigID = Convert.ToInt32(updValues.Keys["FerryFlightConfigID"]);
                var entity = entities.FerryFlightConfigs.SingleOrDefault(x => x.FerryFlightConfigID == aFerryFlightConfigID);
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

                    if (updValues.NewValues["MTOW"] != null)
                    {
                        int aMTOW = Convert.ToInt32(updValues.NewValues["MTOW"]);
                        entity.MTOW = aMTOW;
                    }

                    if (updValues.NewValues["InOut"] != null)
                    {
                        string aInOut = updValues.NewValues["InOut"].ToString();
                        entity.InOut = aInOut;
                    }

                    if (updValues.NewValues["Coefficient"] != null)
                    {
                        decimal aCoefficient = Convert.ToDecimal(updValues.NewValues["Coefficient"]);
                        entity.Coefficient = aCoefficient;
                    }

                    if (updValues.NewValues["Description"] != null)
                    {
                        string aDescription = updValues.NewValues["Description"].ToString();
                        entity.Description = aDescription;
                    }
                }
            }
            entities.SaveChanges();

            LoadDataToGrid();
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
}