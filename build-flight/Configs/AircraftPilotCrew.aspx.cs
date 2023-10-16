using DevExpress.Web;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_AircraftPilotCrew : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadVersionID(DataGrid);
        LoadData();
    }

    private void LoadData()
    {
        var list = entities.AircraftPilotCrews.ToList();

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

            var entity = entities.AircraftPilotCrews.SingleOrDefault(x => x.Id == key);
            if (entity != null)
            {
                entities.AircraftPilotCrews.Remove(entity);

                entities.SaveChangesWithAuditLogs();
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
                var entity = new AircraftPilotCrew();
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
                    entity.Year = aForYear;
                }

                int aMonth;
                if (insValues.NewValues["M01"] != null)
                {
                    aMonth = Convert.ToInt32(insValues.NewValues["M01"]);
                    entity.M01 = aMonth;
                }

                if (insValues.NewValues["M02"] != null)
                {
                    aMonth = Convert.ToInt32(insValues.NewValues["M02"]);
                    entity.M02 = aMonth;
                }

                if (insValues.NewValues["M03"] != null)
                {
                    aMonth = Convert.ToInt32(insValues.NewValues["M03"]);
                    entity.M03 = aMonth;
                }

                if (insValues.NewValues["M04"] != null)
                {
                    aMonth = Convert.ToInt32(insValues.NewValues["M04"]);
                    entity.M04 = aMonth;
                }

                if (insValues.NewValues["M05"] != null)
                {
                    aMonth = Convert.ToInt32(insValues.NewValues["M05"]);
                    entity.M05 = aMonth;
                }

                if (insValues.NewValues["M06"] != null)
                {
                    aMonth = Convert.ToInt32(insValues.NewValues["M06"]);
                    entity.M06 = aMonth;
                }

                if (insValues.NewValues["M07"] != null)
                {
                    aMonth = Convert.ToInt32(insValues.NewValues["M07"]);
                    entity.M07 = aMonth;
                }

                if (insValues.NewValues["M08"] != null)
                {
                    aMonth = Convert.ToInt32(insValues.NewValues["M08"]);
                    entity.M08 = aMonth;
                }

                if (insValues.NewValues["M09"] != null)
                {
                    aMonth = Convert.ToInt32(insValues.NewValues["M09"]);
                    entity.M09 = aMonth;
                }

                if (insValues.NewValues["M10"] != null)
                {
                    aMonth = Convert.ToInt32(insValues.NewValues["M10"]);
                    entity.M10 = aMonth;
                }

                if (insValues.NewValues["M11"] != null)
                {
                    aMonth = Convert.ToInt32(insValues.NewValues["M11"]);
                    entity.M11 = aMonth;
                }

                if (insValues.NewValues["M12"] != null)
                {
                    aMonth = Convert.ToInt32(insValues.NewValues["M12"]);
                    entity.M12 = aMonth;
                }

                entities.AircraftPilotCrews.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                long key = Convert.ToInt64(updValues.Keys["Id"]);
                var entity = entities.AircraftPilotCrews.SingleOrDefault(x => x.Id == key);
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
                        entity.Year = aForYear;
                    }


                    int aMonth = 0;
                    if (updValues.NewValues["M01"] != null)
                    {
                        aMonth = Convert.ToInt32(updValues.NewValues["M01"]);
                        entity.M01 = aMonth;
                    }
                    else
                        entity.M01 = 0;

                    if (updValues.NewValues["M02"] != null)
                    {
                        aMonth = Convert.ToInt32(updValues.NewValues["M02"]);
                        entity.M02 = aMonth;
                    }
                    else
                        entity.M02 = 0;

                    if (updValues.NewValues["M03"] != null)
                    {
                        aMonth = Convert.ToInt32(updValues.NewValues["M03"]);
                        entity.M03 = aMonth;
                    }
                    else
                        entity.M03 = 0;

                    if (updValues.NewValues["M04"] != null)
                    {
                        aMonth = Convert.ToInt32(updValues.NewValues["M04"]);
                        entity.M04 = aMonth;
                    }
                    else
                        entity.M04 = 0;

                    if (updValues.NewValues["M05"] != null)
                    {
                        aMonth = Convert.ToInt32(updValues.NewValues["M05"]);
                        entity.M05 = aMonth;
                    }
                    else
                        entity.M05 = 0;

                    if (updValues.NewValues["M06"] != null)
                    {
                        aMonth = Convert.ToInt32(updValues.NewValues["M06"]);
                        entity.M06 = aMonth;
                    }
                    else
                        entity.M06 = 0;

                    if (updValues.NewValues["M07"] != null)
                    {
                        aMonth = Convert.ToInt32(updValues.NewValues["M07"]);
                        entity.M07 = aMonth;
                    }
                    else
                        entity.M07 = 0;

                    if (updValues.NewValues["M08"] != null)
                    {
                        aMonth = Convert.ToInt32(updValues.NewValues["M08"]);
                        entity.M08 = aMonth;
                    }
                    else
                        entity.M08 = 0;

                    if (updValues.NewValues["M09"] != null)
                    {
                        aMonth = Convert.ToInt32(updValues.NewValues["M09"]);
                        entity.M09 = aMonth;
                    }
                    else
                        entity.M09 = 0;

                    if (updValues.NewValues["M10"] != null)
                    {
                        aMonth = Convert.ToInt32(updValues.NewValues["M10"]);
                        entity.M10 = aMonth;
                    }
                    else
                        entity.M10 = 0;

                    if (updValues.NewValues["M11"] != null)
                    {
                        aMonth = Convert.ToInt32(updValues.NewValues["M11"]);
                        entity.M11 = aMonth;
                    }
                    else
                        entity.M11 = 0;

                    if (updValues.NewValues["M12"] != null)
                    {
                        aMonth = Convert.ToInt32(updValues.NewValues["M12"]);
                        entity.M12 = aMonth;
                    }
                    else
                        entity.M12 = 0;

                }
            }
            entities.SaveChangesWithAuditLogs();

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
        if (args[0] == "GETYEAR")
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