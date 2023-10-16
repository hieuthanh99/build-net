using DevExpress.Web;
using KTQTData;
using System;
using System.Linq;
using Hangfire;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using System.IO;
using System.Web;
using DevExpress.Web.Data;

public partial class Business_RevenueCost_AutoPricing : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadAutoItemID(this.AutoPricingGrid);

        LoadAutoPricings();

        if (this.AutoPricingGrid.IsCallback)
        {
            if (this.GetGridCallbackType() != ASPxGridViewCallbackType.Custom)
            {
                if (this.AutoPricingHiddenField.Contains("AutoPricingID"))
                {
                    var aAutoPricingID = Convert.ToDecimal(AutoPricingHiddenField.Get("AutoPricingID"));
                    this.LoadAutoPricingDetail(aAutoPricingID);

                }
            }

        }
    }
    #region Callback Type
    enum ASPxGridViewCallbackType
    {
        None, Custom, Sorting, ApplyFilter, FilterEditing, StartEdit, UpdateEdit,
        CancelEdit, AddNewRow, DeleteRow, FocusRow, GotoPage, ColumnMoved, ExpandGroup, CollapseGroup, Unknown
    };
    ASPxGridViewCallbackType GetGridCallbackType()
    {
        const string GridCallbackSuffix = "GB|";
        const string ActionSorting = "SORT";
        const string ActionEdit = "STARTEDIT";
        const string ActionUpdate = "UPDATEEDIT";
        const string ActionCancel = "CANCELEDIT";
        const string ActionAddNewRow = "ADDNEWROW";
        const string ActionDeleteRow = "DELETEROW";
        const string ActionFocusRow = "FOCUSEDROW";
        const string ActionGotoPage = "PAGERONCLICK";
        const string ActionCustom = "CUSTOMCALLBACK";
        const string ActionFilterShowMenu = "FILTERROWMENU";
        const string ActionFilterPopup = "FILTERPOPUP";
        const string ActionShowFilterControl = "SHOWFILTERCONTROL";
        const string ActionCloseFilterControl = "CLOSEFILTERCONTROL";
        const string ActionApplyFilter = "APPLYFILTER";
        const string ActionApplyColumnFilter = "APPLYHEADERCOLUMNFILTER";
        const string ActionColumnMoved = "COLUMNMOVE";
        const string ActionExpandGroup = "EXPANDROW";
        const string ActionCollapseGroup = "COLLAPSEROW";

        string callbackParam = Request.Params["__CALLBACKPARAM"];
        if (string.IsNullOrEmpty(callbackParam)) return ASPxGridViewCallbackType.None;
        if (!callbackParam.Contains(GridCallbackSuffix)) return ASPxGridViewCallbackType.None;
        string action = callbackParam.Substring(callbackParam.IndexOf(GridCallbackSuffix));
        if (action.Contains(ActionCustom)) return ASPxGridViewCallbackType.Custom;
        if (action.Contains(ActionSorting)) return ASPxGridViewCallbackType.Sorting;
        if (action.Contains(ActionEdit)) return ASPxGridViewCallbackType.StartEdit;
        if (action.Contains(ActionUpdate)) return ASPxGridViewCallbackType.UpdateEdit;
        if (action.Contains(ActionCancel)) return ASPxGridViewCallbackType.CancelEdit;
        if (action.Contains(ActionAddNewRow)) return ASPxGridViewCallbackType.AddNewRow;
        if (action.Contains(ActionDeleteRow)) return ASPxGridViewCallbackType.DeleteRow;
        if (action.Contains(ActionFocusRow)) return ASPxGridViewCallbackType.FocusRow;
        if (action.Contains(ActionGotoPage)) return ASPxGridViewCallbackType.GotoPage;
        if (action.Contains(ActionFilterShowMenu) || action.Contains(ActionFilterPopup) || action.Contains(ActionShowFilterControl)
        || action.Contains(ActionCloseFilterControl)) return ASPxGridViewCallbackType.FilterEditing;
        if (action.Contains(ActionApplyFilter) || action.Contains(ActionApplyColumnFilter)) return ASPxGridViewCallbackType.ApplyFilter;
        if (action.Contains(ActionColumnMoved)) return ASPxGridViewCallbackType.ColumnMoved;
        if (action.Contains(ActionExpandGroup)) return ASPxGridViewCallbackType.ExpandGroup;
        if (action.Contains(ActionCollapseGroup)) return ASPxGridViewCallbackType.CollapseGroup;
        return ASPxGridViewCallbackType.Unknown;
    }

    #endregion

    #region Load data

    private void LoadAutoPricings()
    {
        var versionId = VersionEditor.Value != null ? Convert.ToDecimal(VersionEditor.Value) : 0;

        var list = entities.AutoPricings.Where(x => x.VersionID == versionId).ToList();
        this.AutoPricingGrid.DataSource = list;
        this.AutoPricingGrid.DataBind();
    }

    private void LoadAutoPricingDetail(decimal autoPricingID)
    {
        var list = entities.AutoPricingDetails.Where(x => x.AutoPricingID == autoPricingID).OrderBy(x => x.ForMonth).ToList();
        this.AutoPricingDetailGrid.DataSource = list;
        this.AutoPricingDetailGrid.DataBind();
    }


    private void LoadAutoItemID(ASPxGridView Grid)
    {
        GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)Grid.Columns["AutoItemID"];

        var list = entities.AutoItems
            //.Where(x => entities.DecSubaccounts.Where(s => s.AccountGroup == "C" && (s.Active ?? false) == true).Select(s => s.SubaccountID).Contains((x.SubaccountID ?? 0)))
            .OrderBy(x => x.Seq).ToList();
        aCombo.PropertiesComboBox.DataSource = list;
        aCombo.PropertiesComboBox.ValueField = "AutoItemID";
        aCombo.PropertiesComboBox.TextField = "Item";
    }

    #endregion


    protected void AutoPricingDetailGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        if (args[0] == "LoadAutoPricingDetail")
        {
            decimal aAutoPricingID;
            if (!decimal.TryParse(args[1], out aAutoPricingID))
                return;

            if (aAutoPricingID != decimal.Zero)
                GenerateDetail(aAutoPricingID);

            LoadAutoPricingDetail(aAutoPricingID);
        }

        if (args[0] == "RefreshDetail")
        {
            decimal aAutoPricingID;
            if (!decimal.TryParse(args[1], out aAutoPricingID))
                return;

            LoadAmount(aAutoPricingID);

        }



    }
    protected void VersionEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Versions.Where(x => x.Active == true).ToList();
        s.DataSource = list;
        s.ValueField = "VersionID";
        s.TextField = "Description";
        s.DataBind();
        if (s.Items.Count > 0)
            s.Value = s.Items[0].Value;
    }

    private string GetErrorMessage(Exception ex)
    {
        if (ex.InnerException != null)
            return ex.InnerException.Message;

        return ex.Message;
    }

    protected void AutoPricingGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        if (args[0] == "LoadData")
        {
            LoadAutoPricings();
        }

        if (args[0] == "CalUnit")
        {
            try
            {
                int[] keys = null;
                if (!TryParseKeyValues(args.Skip(1), out keys))
                    return;

                foreach (var key in keys)
                {
                    entities.GenerateCostUnit(key, SessionUser.UserID);
                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Có lỗi: (" + GetErrorMessage(ex) + ")", SessionUser.UserName);
            }
        }

        if (Object.Equals(args[0], "CopyData"))
        {
            var fromVer = CopyVersionEditor.Value != null ? Convert.ToDecimal(CopyVersionEditor.Value) : decimal.Zero;
            var toVer = VersionEditor.Value != null ? Convert.ToDecimal(VersionEditor.Value) : decimal.Zero;

            if (fromVer != decimal.Zero && toVer != decimal.Zero)
            {
                entities.CopyAutoPricing(fromVer, toVer, SessionUser.UserID);

                var autoPricingIDs = entities.AutoPricings
                    .Where(x => x.VersionID == toVer)
                    .Select(x => x.AutoPricingID)
                    .ToList();

                foreach (var aAutoPricingID in autoPricingIDs)
                {
                    if (aAutoPricingID != decimal.Zero)
                    {
                        GenerateDetail(aAutoPricingID);

                        LoadAmount(aAutoPricingID);
                    }
                }
            }
            LoadAutoPricings();

        }

        if (Object.Equals(args[0], "DELETE"))
        {
            int aAutoPricingID;
            if (!int.TryParse(args[1], out aAutoPricingID))
                return;

            var entity = entities.AutoPricings.SingleOrDefault(x => x.AutoPricingID == aAutoPricingID);
            if (entity != null)
            {
                entities.AutoPricingDetails.RemoveRange(entities.AutoPricingDetails.Where(x => x.AutoPricingID == aAutoPricingID));

                entities.AutoPricings.Remove(entity);

                entities.SaveChangesWithAuditLogs();
            }
            LoadAutoPricings();
        }
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

    private void GenerateDetail(decimal autoPricingID)
    {
        for (int i = 1; i <= 12; i++)
        {
            var check = entities.AutoPricingDetails
                .Where(x => x.AutoPricingID == autoPricingID && x.ForMonth == i)
                .Any();

            if (!check)
            {
                entities.AutoPricingDetails.Add(new AutoPricingDetail
                {
                    AutoPricingID = autoPricingID,
                    ForMonth = i,
                    Curr = "VND",
                    Amount = 0,
                    K = 1
                });
            }

            entities.SaveChanges();
        }
    }

    private decimal GetAmount(decimal? versionID, int? subaccountId, int? companyId, int? month)
    {
        var amount = (from sd in entities.StoreDetails
                      join st in entities.Stores on sd.StoreID equals st.StoreID
                      where st.VersionID == versionID
                      && st.SubaccountID == subaccountId
                      && st.CompanyID == companyId
                      && sd.RevCostMonth == month
                      select sd.OutAfterSaving).SingleOrDefault();

        return (amount ?? 0);
    }

    private void LoadAmount(decimal autoPricingID)
    {
        var autoPricing = entities.AutoPricings
            .Where(x => x.AutoPricingID == autoPricingID).FirstOrDefault();
        if (autoPricing != null)
        {
            var list = entities.AutoPricingDetails.Where(x => x.AutoPricingID == autoPricingID).ToList();
            foreach (var detail in list)
            {
                detail.Amount = GetAmount(autoPricing.VersionID, autoPricing.AutoItem.SubaccountID, autoPricing.AutoItem.CompanyID, detail.ForMonth);
            }

            entities.SaveChanges();
        }
    }

    protected void AutoPricingGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            foreach (ASPxDataInsertValues insValues in e.InsertValues)
            {
                var entity = new AutoPricing();

                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;

                entity.VersionID = Convert.ToDecimal(VersionEditor.Value);

                if (insValues.NewValues["AutoItemID"] != null)
                {
                    int aAutoItemID = Convert.ToInt32(insValues.NewValues["AutoItemID"]);
                    entity.AutoItemID = aAutoItemID;
                }

                if (insValues.NewValues["Driver"] != null)
                {
                    string aDriver = insValues.NewValues["Driver"].ToString();
                    entity.Driver = aDriver;
                }

                if (insValues.NewValues["Carrier"] != null)
                {
                    string aCarrier = insValues.NewValues["Carrier"].ToString();
                    entity.Carrier = aCarrier;
                }

                if (insValues.NewValues["FleetType"] != null)
                {
                    string aFleetType = insValues.NewValues["FleetType"].ToString();
                    entity.FleetType = aFleetType;
                }

                if (insValues.NewValues["Network"] != null)
                {
                    string aNetwork = insValues.NewValues["Network"].ToString();
                    entity.Network = aNetwork;
                }

                if (insValues.NewValues["ACID"] != null)
                {
                    string aAcID = insValues.NewValues["ACID"].ToString();
                    entity.ACID = aAcID;
                }

                if (insValues.NewValues["FltType"] != null)
                {
                    string aFltType = insValues.NewValues["FltType"].ToString();
                    entity.FltType = aFltType;
                }

                if (insValues.NewValues["Airports"] != null)
                {
                    string aAirports = insValues.NewValues["Airports"].ToString();
                    entity.Airports = aAirports;
                }

                if (insValues.NewValues["Direction"] != null)
                {
                    string aDirection = insValues.NewValues["Direction"].ToString();
                    entity.Direction = aDirection;
                }

                if (insValues.NewValues["OriCountry"] != null)
                {
                    string aOriCountry = insValues.NewValues["OriCountry"].ToString();
                    entity.OriCountry = aOriCountry;
                }

                if (insValues.NewValues["DesCountry"] != null)
                {
                    string aDesCountry = insValues.NewValues["DesCountry"].ToString();
                    entity.DesCountry = aDesCountry;
                }

                if (insValues.NewValues["Remark"] != null)
                {
                    string aRemark = insValues.NewValues["Remark"].ToString();
                    entity.Remark = aRemark;
                }

                entities.AutoPricings.Add(entity);

                entities.SaveChangesWithAuditLogs();

                if (entity.AutoPricingID != decimal.Zero)
                {
                    GenerateDetail(entity.AutoPricingID);

                    LoadAmount(entity.AutoPricingID);
                }
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aAutoPricingID = Convert.ToDecimal(updValues.Keys["AutoPricingID"]);
                var entity = entities.AutoPricings.SingleOrDefault(x => x.AutoPricingID == aAutoPricingID);
                if (entity != null)
                {
                    entity.ModifyDate = DateTime.Now;
                    entity.ModifiedBy = (int)SessionUser.UserID;

                    entity.VersionID = Convert.ToDecimal(VersionEditor.Value);

                    if (updValues.NewValues["AutoItemID"] != null)
                    {
                        int aAutoItemID = Convert.ToInt32(updValues.NewValues["AutoItemID"]);
                        entity.AutoItemID = aAutoItemID;
                    }
                    else entity.AutoItemID = null;

                    if (updValues.NewValues["Driver"] != null)
                    {
                        string aDriver = updValues.NewValues["Driver"].ToString();
                        entity.Driver = aDriver;
                    }
                    else entity.Driver = null;

                    if (updValues.NewValues["Carrier"] != null)
                    {
                        string aCarrier = updValues.NewValues["Carrier"].ToString();
                        entity.Carrier = aCarrier;
                    }
                    else entity.Carrier = null;

                    if (updValues.NewValues["FleetType"] != null)
                    {
                        string aFleetType = updValues.NewValues["FleetType"].ToString();
                        entity.FleetType = aFleetType;
                    }
                    else entity.FleetType = null;

                    if (updValues.NewValues["Network"] != null)
                    {
                        string aNetwork = updValues.NewValues["Network"].ToString();
                        entity.Network = aNetwork;
                    }
                    else entity.Network = null;

                    if (updValues.NewValues["ACID"] != null)
                    {
                        string aAcID = updValues.NewValues["ACID"].ToString();
                        entity.ACID = aAcID;
                    }
                    else entity.ACID = null;

                    if (updValues.NewValues["FltType"] != null)
                    {
                        string aFltType = updValues.NewValues["FltType"].ToString();
                        entity.FltType = aFltType;
                    }
                    else entity.FltType = null;

                    if (updValues.NewValues["Airports"] != null)
                    {
                        string aAirports = updValues.NewValues["Airports"].ToString();
                        entity.Airports = aAirports;
                    }
                    else entity.Airports = null;

                    if (updValues.NewValues["Direction"] != null)
                    {
                        string aDirection = updValues.NewValues["Direction"].ToString();
                        entity.Direction = aDirection;
                    }
                    else entity.Direction = null;

                    if (updValues.NewValues["OriCountry"] != null)
                    {
                        string aOriCountry = updValues.NewValues["OriCountry"].ToString();
                        entity.OriCountry = aOriCountry;
                    }
                    else entity.OriCountry = null;

                    if (updValues.NewValues["DesCountry"] != null)
                    {
                        string aDesCountry = updValues.NewValues["DesCountry"].ToString();
                        entity.DesCountry = aDesCountry;
                    }
                    else entity.DesCountry = null;

                    if (updValues.NewValues["Remark"] != null)
                    {
                        string aRemark = updValues.NewValues["Remark"].ToString();
                        entity.Remark = aRemark;
                    }
                    else entity.Remark = null;

                }
                entities.SaveChangesWithAuditLogs();
            }


            LoadAutoPricings();
        }
        catch (Exception ex)
        {
            throw new UserFriendlyException(ex.Message, ex, SessionUser.UserName);
        }
        finally
        {
            e.Handled = true;
        }
    }

    private AutoItem GetAutoItem(int autoItemID)
    {
        var autoItem = entities.AutoItems.Where(x => x.AutoItemID == autoItemID).FirstOrDefault();
        return autoItem;
    }

    //private AutoItem GetAutoItem(int autoItemID)
    //{
    //    var autoItem = entities.AutoItems.Where(x => x.AutoItemID == autoItemID).FirstOrDefault();
    //    return autoItem;
    //}

    protected void AutoPricingGrid_CustomUnboundColumnData(object sender, ASPxGridViewColumnDataEventArgs e)
    {
        int aAutoItemID = e.GetListSourceFieldValue("AutoItemID") != null ? Convert.ToInt32(e.GetListSourceFieldValue("AutoItemID")) : 0;
        var autoItem = GetAutoItem(aAutoItemID);

        if (e.Column.FieldName == "Description")
        {
            if (autoItem != null)
                e.Value = autoItem.Description;
        }
        if (e.Column.FieldName == "AccLevel5")
        {
            if (autoItem != null)
                e.Value = autoItem.ViewName;
        }
        if (e.Column.FieldName == "SQL_P1")
        {
            if (autoItem != null)
                e.Value = autoItem.SQL_P1;
        }
    }

    protected void AutoPricingDetailGrid_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            decimal aAutoPricingID = decimal.Zero;
            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aAutoPricingDetailID = Convert.ToDecimal(updValues.Keys["AutoPricingDetailID"]);
                var entity = entities.AutoPricingDetails.SingleOrDefault(x => x.AutoPricingDetailID == aAutoPricingDetailID);
                if (entity != null)
                {
                    if (entity.AutoPricingID.HasValue)
                        aAutoPricingID = entity.AutoPricingID.Value;

                    entity.ModifyDate = DateTime.Now;
                    entity.ModifiedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["Curr"] != null)
                    {
                        string aCurr = updValues.NewValues["Curr"].ToString();
                        entity.Curr = aCurr;
                    }
                    else entity.Curr = null;

                    if (updValues.NewValues["Amount"] != null)
                    {
                        decimal aAmount = Convert.ToDecimal(updValues.NewValues["Amount"].ToString());
                        entity.Amount = aAmount;
                    }
                    else entity.Amount = null;

                    if (updValues.NewValues["K"] != null)
                    {
                        decimal aK = Convert.ToDecimal(updValues.NewValues["K"].ToString());
                        entity.K = aK;
                    }
                    else entity.K = null;

                }
                entities.SaveChangesWithAuditLogs();
            }


            LoadAutoPricingDetail(aAutoPricingID);
        }
        catch (Exception ex)
        {
            throw new UserFriendlyException(ex.Message, ex, SessionUser.UserName);
        }
        finally
        {
            e.Handled = true;
        }
    }

    protected void CopyVersionEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        LoadCopyVersion(s);
    }

    private void LoadCopyVersion(ASPxComboBox s)
    {
        var versionId = VersionEditor.Value != null ? Convert.ToDecimal(VersionEditor.Value) : 0;

        var list = entities.Versions.Where(x => x.VersionID != versionId && x.Active == true).ToList();
        s.DataSource = list;
        s.ValueField = "VersionID";
        s.TextField = "Description";
        s.DataBind();
        if (s.Items.Count > 0)
            s.Value = s.Items[0].Value;
    }

    protected void CopyVersionEditor_Callback(object sender, CallbackEventArgsBase e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        LoadCopyVersion(s);
    }

    protected void AutoPricingGrid_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
    {
        ASPxEdit editor = (ASPxEdit)e.Editor;
        editor.ValidationSettings.Display = Display.None;
    }
}


