using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using System.Data.SqlClient;

public partial class Configs_DM_EquipmentNorms : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsCallback || this.NormYearGrid.IsCallback)
            LoadNormYears();

        if (!this.IsCallback || this.ACConfigGrid.IsCallback)
            LoadACConfigs();

        if (!this.IsCallback || this.EquipmentNormGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackIntKeyValue("NormYearID");
            var aACConfigID = this.GetCallbackIntKeyValue("ACConfigID");
            LoadEquipmentNorm(aNormYearID, aACConfigID);
        }

        this.EquipmentNormGrid.GroupBy(this.EquipmentNormGrid.Columns["GroupItem"]);
        this.EquipmentNormGrid.ExpandAll();
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


    private void LoadEquipmentNorm(int NormYearID, int ACConfigID)
    {
        var list = entities.DM_EquipmentNorms
            .Where(x => x.NormYearID == NormYearID && x.ACConfigID == ACConfigID)
            .OrderBy(x => x.GroupItem)
            .ToList();

        this.EquipmentNormGrid.DataSource = list;
        this.EquipmentNormGrid.DataBind();
    }
    #endregion


    #region Lấy giá trị từ user control

    private Control DetailNormForm()
    {
        return this.EquipmentTimeDetailNormAddOrEdit.FindControl("DetailNormForm");
    }

    private object GetDetailEditorValue(string controlName)
    {
        return ((ASPxEditBase)this.DetailNormForm().FindControl(controlName)).Value;
    }

    #endregion

    protected void EquipmentNormGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        decimal key;
        if (args[0] == "LOAD_DETAIL_NORM")
        {
            this.EquipmentNormGrid.ExpandAll();
        }

        if (args[0] == "DELETE_DETAIL_NORM")
        {
            if (!decimal.TryParse(args[1], out key))
                return;

            var entity = entities.DM_EquipmentNorms.SingleOrDefault(x => x.EquipmentNormID == key);
            if (entity != null)
            {
                var aNormYearID = entity.NormYearID.Value;
                var aACConfigID = entity.ACConfigID.Value;
                entities.DM_EquipmentNorms.Remove(entity);
                entities.SaveChanges();

                LoadEquipmentNorm(aNormYearID, aACConfigID);
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

                entities.Database.ExecuteSqlCommand(DbHelper.GenerateCommandText("[KTQT_Data].[dbo].[PrcCopyEquipmentNorm]", parameters), parameters);
            }

            LoadEquipmentNorm(aNormYearID, aACConfigID);
        }


    }
    protected void EquipmentNormGrid_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e)
    {

    }
    protected void EquipmentNormGrid_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
    {
        var Grid = (sender as ASPxGridView);

        if (e.Column.FieldName == "ItemName")
        {
            var entity = Grid.GetRow(e.VisibleIndex) as DM_EquipmentNorms;
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
    protected void EquipmentNormGrid_CustomGroupDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
    {
        if (e.Column.FieldName == "GroupItem")
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
    protected void EquipmentNormGrid_CustomDataCallback(object sender, ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "DetailNormForm" && args.Length == 3)
        {
            decimal key;
            if (!decimal.TryParse(args[2], out key))
                return;

            var item = entities.DM_EquipmentNorms.SingleOrDefault(x => x.EquipmentNormID == key);
            if (item == null)
                return;

            var result = new Dictionary<string, string>();
            result["GroupItem"] = item.GroupItem;
            result["ItemID"] = item.ItemID.HasValue ? item.ItemID.ToString() : "0";
            result["ITEM"] = item.ITEM;
            result["ItemName"] = GetItemName(item.ITEM);
            result["NumberOfEquipment"] = (item.NumberOfEquipment ?? decimal.Zero).ToString();
            result["PreparationTime"] = (item.PreparationTime ?? decimal.Zero).ToString();
            result["MovingTime"] = (item.MovingTime ?? decimal.Zero).ToString();
            result["WaitingTime"] = (item.WaitingTime ?? decimal.Zero).ToString();
            result["ApproachTime"] = (item.ApproachTime ?? decimal.Zero).ToString();
            result["TimeServedAtPlane"] = (item.TimeServedAtPlane ?? decimal.Zero).ToString();
            result["TimeServedAtStore"] = (item.TimeServedAtStore ?? decimal.Zero).ToString();
            result["TimeServedAtBC"] = (item.TimeServedAtBC ?? decimal.Zero).ToString();
            result["NightServedTime"] = (item.NightServedTime ?? decimal.Zero).ToString();
            result["CleaningTime"] = (item.CleaningTime ?? decimal.Zero).ToString();
            result["TotalTime"] = (item.TotalTime ?? decimal.Zero).ToString();
            result["Frequency"] = (item.Frequency ?? decimal.Zero).ToString();

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

    protected void EquipmentNormCallback_Callback(object source, CallbackEventArgs e)
    {
        var args = e.Parameter.Split('|');
        decimal key;

        if (args[0] == "SAVE_DETAIL_NORM")
        {
            var command = args[1];
            try
            {
                var aGroup = GetDetailEditorValue("GroupEditor");
                var aItemID = GetDetailEditorValue("CodeEditor");
                var aSoluongTTB = GetDetailEditorValue("SoluongTTBEditor");
                var aPrepareTime = GetDetailEditorValue("PrepareTimeEditor");
                var aMovingTime = GetDetailEditorValue("MovingTimeEditor");
                var aWaitingTime = GetDetailEditorValue("WaitingTimeEditor");
                var aApproachTime = GetDetailEditorValue("ApproachTimeEditor");
                var aTimeServedAtPlane = GetDetailEditorValue("TimeServedAtPlaneEditor");
                var aTimeServedAtStore = GetDetailEditorValue("TimeServedAtStoreEditor");
                var aTimeServedAtBC = GetDetailEditorValue("TimeServedAtBCEditor");
                var aNightServedTime = GetDetailEditorValue("NightServedTimeEditor");
                var aCleaningTime = GetDetailEditorValue("CleaningTimeEditor");
                var aTotalTime = GetDetailEditorValue("TotalTimeEditor");
                var aFrequency = GetDetailEditorValue("FrequencyEditor");


                if (object.Equals(command, "EDIT_DETAIL_NORM"))
                {
                    if (!decimal.TryParse(args[2], out key))
                        return;

                    var entity = entities.DM_EquipmentNorms.Where(x => x.EquipmentNormID == key).SingleOrDefault();
                    if (entity != null)
                    {
                        entity.ItemID = aItemID != null ? Convert.ToInt32(aItemID) : 0;
                        entity.ITEM = aItemID != null ? GetCodeByItemID(Convert.ToInt32(aItemID)) : string.Empty;
                        entity.GroupItem = aGroup != null ? aGroup.ToString() : string.Empty;
                        entity.NumberOfEquipment = aSoluongTTB != null ? Convert.ToDecimal(aSoluongTTB) : decimal.Zero;
                        entity.PreparationTime = aPrepareTime != null ? Convert.ToDecimal(aPrepareTime) : decimal.Zero;
                        entity.MovingTime = aMovingTime != null ? Convert.ToDecimal(aMovingTime) : decimal.Zero;
                        entity.WaitingTime = aWaitingTime != null ? Convert.ToDecimal(aWaitingTime) : decimal.Zero;
                        entity.ApproachTime = aApproachTime != null ? Convert.ToDecimal(aApproachTime) : decimal.Zero;
                        entity.TimeServedAtPlane = aTimeServedAtPlane != null ? Convert.ToDecimal(aTimeServedAtPlane) : decimal.Zero;
                        entity.TimeServedAtStore = aTimeServedAtStore != null ? Convert.ToDecimal(aTimeServedAtStore) : decimal.Zero;
                        entity.TimeServedAtBC = aTimeServedAtBC != null ? Convert.ToDecimal(aTimeServedAtBC) : decimal.Zero;
                        entity.NightServedTime = aNightServedTime != null ? Convert.ToDecimal(aNightServedTime) : decimal.Zero;
                        entity.CleaningTime = aCleaningTime != null ? Convert.ToDecimal(aCleaningTime) : decimal.Zero;
                        entity.TotalTime = aTotalTime != null ? Convert.ToDecimal(aTotalTime) : decimal.Zero;
                        entity.Frequency = aFrequency != null ? Convert.ToDecimal(aFrequency) : decimal.Zero;

                        entity.LastUpdateDate = DateTime.Now;
                        entity.LastUpdatedBy = (int)SessionUser.UserID;
                        entities.SaveChanges();
                    }
                }
                else if (object.Equals(command, "ADD_DETAIL_NORM"))
                {
                    var aNormYearID = this.GetCallbackIntKeyValue("NormYearID");
                    var aACConfigID = this.GetCallbackIntKeyValue("ACConfigID");

                    var entity = new DM_EquipmentNorms();

                    entity.NormYearID = aNormYearID;
                    entity.ACConfigID = aACConfigID;
                    entity.ItemID = aItemID != null ? Convert.ToInt32(aItemID) : 0;
                    entity.ITEM = aItemID != null ? GetCodeByItemID(Convert.ToInt32(aItemID)) : string.Empty;
                    entity.GroupItem = aGroup != null ? aGroup.ToString() : string.Empty;
                    entity.NumberOfEquipment = aSoluongTTB != null ? Convert.ToDecimal(aSoluongTTB) : decimal.Zero;
                    entity.PreparationTime = aPrepareTime != null ? Convert.ToDecimal(aPrepareTime) : decimal.Zero;
                    entity.MovingTime = aMovingTime != null ? Convert.ToDecimal(aMovingTime) : decimal.Zero;
                    entity.WaitingTime = aWaitingTime != null ? Convert.ToDecimal(aWaitingTime) : decimal.Zero;
                    entity.ApproachTime = aApproachTime != null ? Convert.ToDecimal(aApproachTime) : decimal.Zero;
                    entity.TimeServedAtPlane = aTimeServedAtPlane != null ? Convert.ToDecimal(aTimeServedAtPlane) : decimal.Zero;
                    entity.TimeServedAtStore = aTimeServedAtStore != null ? Convert.ToDecimal(aTimeServedAtStore) : decimal.Zero;
                    entity.TimeServedAtBC = aTimeServedAtBC != null ? Convert.ToDecimal(aTimeServedAtBC) : decimal.Zero;
                    entity.NightServedTime = aNightServedTime != null ? Convert.ToDecimal(aNightServedTime) : decimal.Zero;
                    entity.CleaningTime = aCleaningTime != null ? Convert.ToDecimal(aCleaningTime) : decimal.Zero;
                    entity.TotalTime = aTotalTime != null ? Convert.ToDecimal(aTotalTime) : decimal.Zero;
                    entity.Frequency = aFrequency != null ? Convert.ToDecimal(aFrequency) : decimal.Zero;

                    entity.CreateDate = DateTime.Now;
                    entity.CreatedBy = (int)SessionUser.UserID;

                    entities.DM_EquipmentNorms.Add(entity);
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