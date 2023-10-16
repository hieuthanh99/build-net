using DevExpress.Web;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_Position : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadPositionType();
        LoadPositions();
    }

    private void LoadPositions()
    {
        var list = entities.DecPositions.ToList();

        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }

    private void LoadPositionType()
    {
        GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn) this.DataGrid.Columns["PositionTypeID"];

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

    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        int aPositionID;

        if (args[0] == "DELETE_POSITION")
        {
            if (!int.TryParse(args[1], out aPositionID))
                return;

            var entity = entities.DecPositions.SingleOrDefault(x => x.PositionID == aPositionID);
            if (entity != null)
            {
                entities.DecPositions.Remove(entity);


                entities.SaveChanges();
                LoadPositions();
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
                var entity = new DecPosition();
                entity.Inactive = false;
                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;

                if (insValues.NewValues["PostionName"] != null)
                {
                    string aPostionName = insValues.NewValues["PostionName"].ToString();
                    entity.PostionName = aPostionName;
                }

                if (insValues.NewValues["PositionTypeID"] != null)
                {
                    int aPositionTypeID = Convert.ToInt32(insValues.NewValues["PositionTypeID"]);
                    entity.PositionTypeID = aPositionTypeID;
                }

                if (insValues.NewValues["Description"] != null)
                {
                    string aDescription = insValues.NewValues["Description"].ToString();
                    entity.Description = aDescription;
                }

                entities.DecPositions.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                int aPositionID = Convert.ToInt32(updValues.Keys["PositionID"]);
                var entity = entities.DecPositions.SingleOrDefault(x => x.PositionID == aPositionID);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["PostionName"] != null)
                    {
                        string aPostionName = updValues.NewValues["PostionName"].ToString();
                        entity.PostionName = aPostionName;
                    }

                    if (updValues.NewValues["PositionTypeID"] != null)
                    {
                        int aPositionTypeID = Convert.ToInt32(updValues.NewValues["PositionTypeID"]);
                        entity.PositionTypeID = aPositionTypeID;
                    }

                    if (updValues.NewValues["Description"] != null)
                    {
                        string aDescription = updValues.NewValues["Description"].ToString();
                        entity.Description = aDescription;
                    }
                }
            }
            entities.SaveChanges();

            LoadPositions();
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
}