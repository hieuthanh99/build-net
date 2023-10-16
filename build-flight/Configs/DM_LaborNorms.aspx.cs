using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using System.Data.SqlClient;

public partial class Configs_DM_LaborNorms : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsCallback || this.NormYearGrid.IsCallback)
            LoadNormYears();

        if (!this.IsCallback || this.ACConfigGrid.IsCallback)
            LoadACConfigs();

        if (!this.IsCallback || this.LaborNormGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackIntKeyValue("NormYearID");
            var aACConfigID = this.GetCallbackIntKeyValue("ACConfigID");
            LoadLaborNorms(aNormYearID, aACConfigID);
        }

        this.LaborNormGrid.GroupBy(this.LaborNormGrid.Columns["ItemGroup"]);
        this.LaborNormGrid.ExpandAll();
    }

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

    #region Load dữ liệu
    private void LoadACConfigs()
    {
        var list = entities.DM_ACConfigs
            .Where(x => x.Inactive == false)
            .OrderByDescending(x => x.AreaCode)
            .ThenBy(x => x.Carrier)
            .ThenBy(x => x.Network)
            .ThenBy(x => x.AcID)
            .ToList();

        this.ACConfigGrid.DataSource = list;
        this.ACConfigGrid.DataBind();
    }

    private void LoadNormYears()
    {
        var list = entities.DM_NormYears
            .OrderByDescending(x => x.ForYear)
            .ToList();

        this.NormYearGrid.DataSource = list;
        this.NormYearGrid.DataBind();
    }

    private void LoadLaborNorms(int NormYearID, int ACConfigID)
    {
        var lLaborNorms = entities.DM_LaborNorms
            .Where(x => x.NormYearID == NormYearID && x.ACConfigID == ACConfigID && x.Inactive == false)
            .ToList();

        this.LaborNormGrid.DataSource = lLaborNorms;
        this.LaborNormGrid.DataBind();
    }


    #endregion


    #region Lấy giá trị từ user control
    private Control LaborNormDetailForm()
    {
        return this.LaborNormDetailAddOrEdit.FindControl("LaborNormForm");
    }

    private object GetDetailEditorValue(string controlName)
    {
        return ((ASPxEditBase)this.LaborNormDetailForm().FindControl(controlName)).Value;
    }

    #endregion

    protected void LaborNormGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        decimal key;

        if (args[0] == "LOAD_LABOR_NORM")
        {
            this.LaborNormGrid.ExpandAll();
        }

        if (args[0] == "DELETE_LABOR_NORM")
        {
            if (!decimal.TryParse(args[1], out key))
                return;

            var entity = entities.DM_LaborNorms.SingleOrDefault(x => x.LaborNormID == key);
            if (entity != null)
            {
                var aNormYearID = entity.NormYearID;
                var aACConfigID = entity.ACConfigID;
                entities.DM_LaborNorms.Remove(entity);
                entities.SaveChanges();

                LoadLaborNorms(aNormYearID, aACConfigID.Value);
            }
        }

        if (args[0] == "COPY_NORM")
        {
            int aNormYearID = Convert.ToInt32(args[1]);
            int aACConfigID = Convert.ToInt32(args[2]);

            var aFromNormYearID = ((ASPxEditBase)CopyNormCtrl.FindControl("cboFromNormYear")).Value;
            var aToNormYearID = ((ASPxEditBase)CopyNormCtrl.FindControl("cboToNormYear")).Value;

            if (aFromNormYearID != null && aToNormYearID != null)
            {
                SqlParameter[] parameters = new SqlParameter[] {
                                new SqlParameter("@pNormYearIDFrom", Convert.ToInt32(aFromNormYearID)),
                                new SqlParameter("@pNormYearIDTo", Convert.ToInt32(aToNormYearID)),
                                new SqlParameter("@pUserID", SessionUser.UserID)                 
                            };

                entities.Database.ExecuteSqlCommand(DbHelper.GenerateCommandText("[KTQT_Data].[dbo].[PrcCopyLaborNorm]", parameters), parameters);
            }

            LoadLaborNorms(aNormYearID, aACConfigID);
        }


    }
    protected void LaborNormGrid_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e)
    {

    }
    protected void LaborNormGrid_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
    {
        var Grid = (sender as ASPxGridView);

        if (e.Column.FieldName == "ItemName")
        {
            var entity = Grid.GetRow(e.VisibleIndex) as DM_LaborNorms;
            if (entity == null) return;
            var aItem = entity.ITEM.Trim();
            var item = entities.ItemMasters.Where(x => x.ITEM == aItem).SingleOrDefault();
            if (item != null)
            {
                e.EncodeHtml = false;
                e.DisplayText = item.Name;
            }
        }
    }
    protected void LaborNormGrid_CustomGroupDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
    {
        if (e.Column.FieldName == "ItemGroup")
        {
            var group = entities.DecTableValues.Where(x => x.Tables == "ITEMMASTER" && x.Field == "GROUPITEM" && x.DefValue == e.Value).SingleOrDefault();
            if (group != null)
            {
                e.EncodeHtml = false;
                e.DisplayText = String.Format("<span style='font-weight:bold;'>{0}</span>", group.Description);

            }
        }
    }



    private string GetItemName(string item)
    {
        var name = entities.ItemMasters.Where(x => x.ITEM == item).Select(x => x.Name).FirstOrDefault();
        return name;
    }
    protected void LaborNormGrid_CustomDataCallback(object sender, ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "LaborNormForm" && args.Length == 3)
        {
            decimal key;
            if (!decimal.TryParse(args[2], out key))
                return;

            var item = entities.DM_LaborNorms.SingleOrDefault(x => x.LaborNormID == key);
            if (item == null)
                return;

            var result = new Dictionary<string, string>();
            result["ItemGroup"] = item.ItemGroup;
            result["ItemID"] = item.ItemID.HasValue ? item.ItemID.ToString() : "0";
            result["ITEM"] = item.ITEM;
            result["ItemName"] = GetItemName(item.ITEM);
            result["PreparationTime"] = (item.PreparationTime ?? decimal.Zero).ToString();
            result["OperatingTime"] = (item.OperatingTime ?? decimal.Zero).ToString();
            result["NumberOfPeople"] = (item.NumberOfPeople ?? decimal.Zero).ToString();
            result["CoefficientK"] = (item.CoefficientK ?? decimal.Zero).ToString();
            result["NormInMinutes"] = (item.NormInMinutes ?? decimal.Zero).ToString();
            result["NormInHours"] = (item.NormInHours ?? decimal.Zero).ToString();
            result["Description"] = item.Description;
            result["Inactive"] = item.Inactive.HasValue ? item.Inactive.Value.ToString() : "False";

            e.Result = result;
        }
    }

    private int? GetItemIDByCode(string code)
    {
        var item = entities.ItemMasters.SingleOrDefault(x => x.ITEM == code);

        if (item != null)
            return item.ItemID;

        return null;
    }

    private string GetCodeByItemID(int itemID)
    {
        var item = entities.ItemMasters.SingleOrDefault(x => x.ItemID == itemID);

        if (item != null)
            return item.ITEM;

        return null;
    }



    protected void LaborNormCallback_Callback(object source, CallbackEventArgs e)
    {
        var args = e.Parameter.Split('|');
        decimal key;

        if (args[0] == "SAVE_LABOR_NORM")
        {
            var command = args[1];
            try
            {
                var aGroup = GetDetailEditorValue("GroupEditor");
                var aItemID = GetDetailEditorValue("CodeEditor");
                var aPrepareTime = GetDetailEditorValue("PrepareTimeEditor");
                var aOperatingTime = GetDetailEditorValue("OperatingTimeEditor");
                var aPeople = GetDetailEditorValue("PeopleEditor");
                var aCoefficientK = GetDetailEditorValue("CoefficientKEditor");
                var aNormInMinutes = GetDetailEditorValue("ExpendMinutesEditor");
                var aNormInHours = GetDetailEditorValue("ExpendHoursEditor");
                var aDescription = GetDetailEditorValue("LaborNormDetailDescriptionEditor");
                var aInactive = GetDetailEditorValue("LaborNormDetailInactiveEditor");


                if (object.Equals(command, "EDIT_LABOR_NORM"))
                {
                    if (!decimal.TryParse(args[2], out key))
                        return;

                    var entity = entities.DM_LaborNorms.Where(x => x.LaborNormID == key).SingleOrDefault();
                    if (entity != null)
                    {
                        entity.ItemID = aItemID != null ? Convert.ToInt32(aItemID) : 0;
                        entity.ITEM = aItemID != null ? GetCodeByItemID(Convert.ToInt32(aItemID)) : string.Empty;
                        entity.ItemGroup = aGroup != null ? aGroup.ToString() : string.Empty;
                        entity.PreparationTime = aPrepareTime != null ? Convert.ToDecimal(aPrepareTime) : decimal.Zero;
                        entity.OperatingTime = aOperatingTime != null ? Convert.ToDecimal(aOperatingTime) : decimal.Zero;
                        entity.NumberOfPeople = aPeople != null ? Convert.ToDecimal(aPeople) : decimal.Zero;
                        entity.CoefficientK = aCoefficientK != null ? Convert.ToDecimal(aCoefficientK) : decimal.Zero;
                        entity.NormInMinutes = aNormInMinutes != null ? Convert.ToDecimal(aNormInMinutes) : decimal.Zero;
                        entity.NormInHours = aNormInHours != null ? Convert.ToDecimal(aNormInHours) : decimal.Zero;
                        entity.Description = aDescription != null ? aDescription.ToString() : string.Empty;
                        entity.Inactive = aInactive != null ? (bool)aInactive : false;

                        entity.LastUpdateDate = DateTime.Now;
                        entity.LastUpdatedBy = (int)SessionUser.UserID;
                        entities.SaveChanges();
                    }
                }
                else if (object.Equals(command, "EDIT_LABOR_NORM"))
                {
                    var aNormYearID = this.GetCallbackIntKeyValue("NormYearID");
                    var aACConfigID = this.GetCallbackIntKeyValue("ACConfigID");

                    var entity = new DM_LaborNorms();

                    entity.ACConfigID = aACConfigID;
                    entity.NormYearID = aNormYearID;
                    entity.ItemID = aItemID != null ? Convert.ToInt32(aItemID) : 0;
                    entity.ITEM = aItemID != null ? GetCodeByItemID(Convert.ToInt32(aItemID)) : string.Empty;
                    entity.ItemGroup = aGroup != null ? aGroup.ToString() : string.Empty;
                    entity.PreparationTime = aPrepareTime != null ? Convert.ToDecimal(aPrepareTime) : decimal.Zero;
                    entity.OperatingTime = aOperatingTime != null ? Convert.ToDecimal(aOperatingTime) : decimal.Zero;
                    entity.NumberOfPeople = aPeople != null ? Convert.ToDecimal(aPeople) : decimal.Zero;
                    entity.CoefficientK = aCoefficientK != null ? Convert.ToDecimal(aCoefficientK) : decimal.Zero;
                    entity.NormInMinutes = aNormInMinutes != null ? Convert.ToDecimal(aNormInMinutes) : decimal.Zero;
                    entity.NormInHours = aNormInHours != null ? Convert.ToDecimal(aNormInHours) : decimal.Zero;
                    entity.Description = aDescription != null ? aDescription.ToString() : string.Empty;
                    entity.Inactive = aInactive != null ? (bool)aInactive : false;

                    entity.CreateDate = DateTime.Now;
                    entity.CreatedBy = (int)SessionUser.UserID;

                    entities.DM_LaborNorms.Add(entity);
                    entities.SaveChanges();


                }


                e.Result = args[0] + "|SUCCESS";
            }
            catch (Exception ex)
            {
                e.Result = args[0] + "|" + ex.Message;
            }
        }
    }
}