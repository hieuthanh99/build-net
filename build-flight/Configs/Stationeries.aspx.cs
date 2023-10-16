using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_Stationeries : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadStationeries();
    }

    private void LoadStationeries()
    {
        var list = entities.DecStationeries
            .OrderBy(x=>x.StationeryType)
            .ToList();

        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }
    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        int aStationeryID;

        if (args[0] == "SAVE_STATIONERY")
        {
            var aCommand = args[1];

            var aStationeryName = StationeryNameEditor.Text.Trim();
            var aUnitOfMeasure = UnitOfMeasureEditor.Text.Trim();
            var aStationeryType = StationeryTypeEditor.Value.ToString();
            var aDescription = DescriptionEditor.Text.Trim();
            var aInactive = InactiveEditor.Checked;

            if (aCommand == "Add")
            {
                var entity = new DecStationery();

                entity.StationeryName = aStationeryName;
                entity.UnitOfMeasure = aUnitOfMeasure;
                entity.StationeryType = aStationeryType;
                entity.Description = aDescription != null ? aDescription.ToString() : string.Empty;
                entity.Inactive = aInactive != null ? (bool)aInactive : false;

                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;

                entities.DecStationeries.Add(entity);
                entities.SaveChanges();
            }
            else if (aCommand == "Edit")
            {
                if (!int.TryParse(args[2], out aStationeryID))
                    return;

                var entity = entities.DecStationeries.SingleOrDefault(x => x.StationeryID == aStationeryID);
                if (entity != null)
                {
                    entity.StationeryName = aStationeryName;
                    entity.UnitOfMeasure = aUnitOfMeasure;
                    entity.StationeryType = aStationeryType;
                    entity.Description = aDescription != null ? aDescription.ToString() : string.Empty;
                    entity.Inactive = aInactive != null ? (bool)aInactive : false;

                    entity.Description = aDescription != null ? aDescription.ToString() : string.Empty;
                    entity.Inactive = aInactive != null ? (bool)aInactive : false;

                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    entities.SaveChanges();
                }
            }

            LoadStationeries();

        }
        if (args[0] == "DELETE_STATIONERY")
        {
            if (!int.TryParse(args[2], out aStationeryID))
                return;

            var entity = entities.DecStationeries.SingleOrDefault(x => x.StationeryID == aStationeryID);
            if (entity != null)
            {
                entities.DecStationeries.Remove(entity);

                entities.SaveChanges();
            }

            LoadStationeries();
        }
    }
    protected void DataGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "EditForm" && args.Length == 2)
        {
            int key;
            if (!int.TryParse(args[1], out key)) return;

            var entity = entities.DecStationeries.SingleOrDefault(x => x.StationeryID == key);
            if (entity == null)
                return;

            var result = new Dictionary<string, string>();

            result["StationeryName"] = entity.StationeryName;
            result["UnitOfMeasure"] = entity.UnitOfMeasure;
            result["StationeryType"] = entity.StationeryType;
            result["Inactive"] = entity.Inactive ? "True" : "False";
            result["Description"] = entity.Description;

            e.Result = result;
        }
    }
}