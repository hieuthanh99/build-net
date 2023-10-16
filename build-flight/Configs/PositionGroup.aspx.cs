using DevExpress.Web.ASPxTreeList;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_PositionGroup : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadParentGroup();
        //LoadPositionType();
        LoadDMPositionGroup();

        if (!IsPostBack)
            this.GroupGrid.ExpandAll();
    }

    private void LoadDMPositionGroup()
    {
        var list = entities.DM_PositionGroup.ToList();

        this.GroupGrid.DataSource = list;
        this.GroupGrid.DataBind();
    }

    //private void LoadPositionType()
    //{
    //    TreeListComboBoxColumn aCombo = (TreeListComboBoxColumn)GroupGrid.Columns["PositionTypeID"];

    //    if (Session[SessionConstant.POSITION_TYPE] != null)
    //        aCombo.PropertiesComboBox.DataSource = Session[SessionConstant.POSITION_TYPE];
    //    else
    //    {
    //        var list = entities.DecPositionTypes.OrderBy(x => x.Seq).ToList();
    //        Session[SessionConstant.POSITION_TYPE] = list;
    //        aCombo.PropertiesComboBox.DataSource = list;
    //    }

    //    aCombo.PropertiesComboBox.ValueField = "PositionTypeID";
    //    aCombo.PropertiesComboBox.TextField = "PositionTypeName";
    //}

    private void LoadParentGroup()
    {
        TreeListComboBoxColumn aCombo = (TreeListComboBoxColumn)GroupGrid.Columns["ParentGroupID"];


        var list = entities.DM_PositionGroup.ToList();
        aCombo.PropertiesComboBox.DataSource = list;


        aCombo.PropertiesComboBox.ValueField = "DMGroupID";
        aCombo.PropertiesComboBox.TextField = "GroupName";
    }

    //protected void GroupGrid_NodeUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    //{
    //    try
    //    {
    //        int key = Convert.ToInt32(e.Keys["DMGroupID"]);
    //        var entity = entities.DM_PositionGroup.SingleOrDefault(x => x.DMGroupID == key);
    //        if (entity != null)
    //        {
    //            if (e.NewValues["GroupName"] != null)
    //            {
    //                string aGroupName = e.NewValues["GroupName"].ToString();
    //                entity.GroupName = aGroupName;
    //            }

    //            if (e.NewValues["PositionTypeID"] != null)
    //            {
    //                int aPositionTypeID = Convert.ToInt32(e.NewValues["PositionTypeID"]);
    //                entity.PositionTypeID = aPositionTypeID;
    //            }

    //            if (e.NewValues["Description"] != null)
    //            {
    //                string aDescription = e.NewValues["Description"].ToString();
    //                entity.Description = aDescription;
    //            }

    //            entity.LastUpdateDate = DateTime.Now;
    //            entity.LastUpdatedBy = SessionUser.UserID;

    //            entities.SaveChanges();
    //        }

    //        LoadParentGroup();

    //    }
    //    catch (Exception ex) { }
    //    finally
    //    {
    //        e.Cancel = true;
    //    }
    //}
    protected void GroupGrid_NodeUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
    {
        try
        {
            int key = Convert.ToInt32(e.Keys["DMGroupID"]);
            var entity = entities.DM_PositionGroup.SingleOrDefault(x => x.DMGroupID == key);
            if (entity != null)
            {
                if (e.NewValues["GroupName"] != null)
                {
                    string aGroupName = e.NewValues["GroupName"].ToString();
                    entity.GroupName = aGroupName;
                }

                if (e.NewValues["PositionGroupType"] != null)
                {
                    string aPositionGroupType = e.NewValues["PositionGroupType"].ToString();
                    entity.PositionGroupType = aPositionGroupType;
                }

                if (e.NewValues["PositionTypeID"] != null)
                {
                    int aPositionTypeID = Convert.ToInt32(e.NewValues["PositionTypeID"]);
                    entity.PositionTypeID = aPositionTypeID;
                }

                if (e.NewValues["Description"] != null)
                {
                    string aDescription = e.NewValues["Description"].ToString();
                    entity.Description = aDescription;
                }

                entity.LastUpdateDate = DateTime.Now;
                entity.LastUpdatedBy = SessionUser.UserID;

                entities.SaveChanges();
            }

            LoadParentGroup();
        }
        catch (Exception ex) { }
        finally
        {
            e.ExceptionHandled = true;
        }
    }
}