using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using KTQTData;
using DevExpress.Web.Data;

public partial class Pages_KTQTSubaccount : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDataToGrid();
        this.mMain.Items.FindByName("New").Visible = IsGranted("Pages.KHTC.Configs.KTQTSubaccount.Create");
        this.mMain.Items.FindByName("Edit").Visible = IsGranted("Pages.KHTC.Configs.KTQTSubaccount.Edit");
        this.mMain.Items.FindByName("Delete").Visible = IsGranted("Pages.KHTC.Configs.KTQTSubaccount.Delete");
        this.mMain.Items.FindByName("UpdateSeq").Visible = SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR);
        this.mMain.Items.FindByName("SyncData").Visible = IsGranted("Pages.KHTC.Configs.KTQTSubaccount.SyncData");

        if (!IsPostBack || DataGrid.IsCallback)
        {
            this.DataGrid.ExpandAll();
        }

    }

    #region Load data
    private void LoadDataToGrid()
    {
        var list = entities.DecSubaccounts
            .Where(x => x.CompanyID == SessionUser.CompanyID || x.CompanyID == null)
            .OrderByDescending(x => x.AccountGroup).ThenBy(x => x.Seq).ToList();

        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }
    #endregion
    protected void ParentEditor_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DecSubaccounts
            .Where(x => x.CompanyID == SessionUser.CompanyID || x.CompanyID == null)
             .Where(x => x.Description != null && x.Description != "")
             .OrderBy(x => x.AccountGroup).ThenBy(x => x.Seq).ToList();

        s.DataSource = list;
        s.ValueField = "SubaccountID";
        s.TextField = "Description";
        s.DataBind();

    }
    protected void DataGrid_CustomCallback(object sender, TreeListCustomCallbackEventArgs e)
    {
        ASPxTreeList s = sender as ASPxTreeList;
        string[] args = e.Argument.Split('|');
        if (args[0].Equals(Action.REFRESH))
        {
            s.JSProperties["cpResult"] = Action.REFRESH;
            LoadDataToGrid();
        }
        else if (args[0].Equals(Action.DELETE))
        {
            s.JSProperties["cpResult"] = Action.DELETE;
            decimal key;
            if (!decimal.TryParse(args[1], out key))
                return;

            var entity = (from x in entities.DecSubaccounts where x.SubaccountID == key select x).FirstOrDefault();
            if (entity != null)
            {
                //Chỉ tiêu dùng chung thì không được xóa nếu người dùng không phải ADMIN;
                if (entity.CompanyID == null && !SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR))
                {
                    new UserFriendlyMessage("Bạn không có quyền thực hiện hành động này.", SessionUser.UserName, UserFriendlyMessage.MessageType.WARN);
                    return;
                }
                if (entity.CompanyID.HasValue && entity.CompanyID.Value != SessionUser.CompanyID)
                {
                    new UserFriendlyMessage("Bạn không có quyền thực hiện hành động này.", SessionUser.UserName, UserFriendlyMessage.MessageType.WARN);
                    return;
                }

                entities.DecSubaccounts.Remove(entity);
                entities.SaveChangesWithAuditLogs();
                LoadDataToGrid();
            }
        }
        else if (args[0].Equals(Action.SYNC_DATA))
        {
            s.JSProperties["cpResult"] = Action.SYNC_DATA;
            entities.Sync_PMSDecSubaccount();

            LoadDataToGrid();
        }
        else if (args[0].Equals("UPDATESEQ"))
        {
            entities.UpdateSubaccountSeq();
            LoadDataToGrid();
        }
        else if (args[0].Equals("SaveForm"))
        {
            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];

                    if (command.ToUpper() == "EDIT")
                    {
                        decimal key;
                        if (!decimal.TryParse(args[2], out key))
                            return;


                        var entity = entities.DecSubaccounts.Where(x => x.SubaccountID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            if (ParentEditor.Value != null)
                                entity.SubaccountParentID = Convert.ToInt32(ParentEditor.Value);
                            else
                                entity.SubaccountParentID = null;
                            entity.Description = DescriptionEditor.Text;
                            entity.Calculation = CalculationEditor.Text;
                            //if (AccountTypeEditor.Value != null)
                            //    entity.AccountType = (int)AccountTypeEditor.Value;
                            //else
                            //    entity.AccountType = null;
                            if (AccountGroupEditor.Value != null)
                                entity.AccountGroup = AccountGroupEditor.Value.ToString();
                            else
                                entity.AccountGroup = string.Empty;

                            if (DivisionEditor.Value != null)
                                entity.Division = DivisionEditor.Value.ToString();
                            else
                                entity.Division = string.Empty;
                            //if (ActivityEditor.Value != null)
                            //    entity.ActivityID = Convert.ToDecimal(ActivityEditor.Value);
                            //else
                            //    entity.ActivityID = null;

                            //entity.AllocatedDriver = DriverEditor.Value != null ? DriverEditor.Value.ToString() : string.Empty;
                            //entity.Carrier = CarrierEditor.Text;
                            //entity.AllocatedFLT = FltTypeEditor.Value != null ? FltTypeEditor.Value.ToString() : string.Empty;
                            //entity.Fleet_Type = FleetTypeEditor.Value != null ? FleetTypeEditor.Value.ToString() : string.Empty;
                            ////entity.AllocatedRT = RouteEditor.Value != null ? RouteEditor.Value.ToString() : string.Empty;
                            //entity.Route2W = Route2WEditor.Value != null ? Route2WEditor.Value.ToString() : string.Empty;
                            //entity.Country = CountryEditor.Value != null ? CountryEditor.Value.ToString() : string.Empty;

                            //entity.Ori = OriEditor.Value != null ? OriEditor.Value.ToString() : string.Empty;
                            //entity.Des = DesEditor.Value != null ? DesEditor.Value.ToString() : string.Empty;
                            //entity.ACID = ACIDEditor.Value != null ? ACIDEditor.Value.ToString() : string.Empty;
                            //entity.AllocateFltDirection = DirectionEditor.Value != null ? DirectionEditor.Value.ToString() : string.Empty;
                            //if (ProfitEditor.Value != null)
                            //    entity.RouteProfitID = Convert.ToInt32(ProfitEditor.Value.ToString());
                            //else
                            //    entity.RouteProfitID = null;
                            //entity.Network = NetworkEditor.Value != null ? NetworkEditor.Value.ToString() : string.Empty;
                            //entity.CostGroup = CostGroupEditor.Value != null ? CostGroupEditor.Value.ToString() : string.Empty;

                            //entity.CostType = CostTypeEditor.Value != null ? CostTypeEditor.Value.ToString() : string.Empty;
                            //entity.FASTCode = FASTCodeEditor.Text;
                            //entity.MaVuViec = MaVuViecEditor.Text;
                            entity.IsCommercial = IsCommercialEditor.Checked;
                            entity.OutAllowUpdate = OutAllowUpdateEditor.Checked;
                            entity.DecAllowUpdate = DecAllowUpdateEditor.Checked;
                            entity.Active = ActiveEditor.Checked;
                            entity.Seq = (int)SeqEditor.Number;
                            entity.Sorting = SortingEditor.Text;
                            entity.Note = NoteEditor.Text;

                            //entity.AccLevel1 = AccLevel1Editor.Text;
                            //entity.AccLevel2 = AccLevel2Editor.Text;
                            //entity.AccLevel3 = AccLevel3Editor.Text;
                            //entity.AccLevel4 = AccLevel4Editor.Text;
                            //entity.AccLevel5 = AccLevel5Editor.Text;
                            //entity.MaBoPhan = MaBoPhanEditor.Text;
                            //entity.ManagermentCode = ManagermentCodeEditor.Text;
                            //entity.ACCode = ACCodeEditor.Text;
                            //entity.OriCountry = OriCountryEditor.Text;
                            //entity.DesCountry = DesCountryEditor.Text;
                            //entity.DirectIndirect = DirectIndirectEditor.Value != null ? DirectIndirectEditor.Value.ToString() : string.Empty;


                            entity.LastUpdateDate = DateTime.Now;
                            entity.LastUpdatedBy = (int)SessionUser.UserID;
                            entities.SaveChangesWithAuditLogs();


                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new DecSubaccount();
                        if (ParentEditor.Value != null)
                            entity.SubaccountParentID = Convert.ToInt32(ParentEditor.Value);
                        else
                            entity.SubaccountParentID = null;
                        entity.Description = DescriptionEditor.Text;
                        entity.Calculation = CalculationEditor.Text;
                        //if (AccountTypeEditor.Value != null)
                        //    entity.AccountType = (int)AccountTypeEditor.Value;
                        //else
                        //    entity.AccountType = null;
                        if (AccountGroupEditor.Value != null)
                            entity.AccountGroup = AccountGroupEditor.Value.ToString();
                        else
                            entity.AccountGroup = string.Empty;
                        if (DivisionEditor.Value != null)
                            entity.Division = DivisionEditor.Value.ToString();
                        else
                            entity.Division = string.Empty;
                        //if (ActivityEditor.Value != null)
                        //    entity.ActivityID = Convert.ToDecimal(ActivityEditor.Value);
                        //else
                        //    entity.ActivityID = null;

                        //entity.AllocatedDriver = DriverEditor.Value != null ? DriverEditor.Value.ToString() : string.Empty;
                        //entity.Carrier = CarrierEditor.Text;
                        //entity.AllocatedFLT = FltTypeEditor.Value != null ? FltTypeEditor.Value.ToString() : string.Empty;
                        //entity.Fleet_Type = FleetTypeEditor.Value != null ? FleetTypeEditor.Value.ToString() : string.Empty;
                        ////entity.AllocatedRT = RouteEditor.Value != null ? RouteEditor.Value.ToString() : string.Empty;
                        //entity.Route2W = Route2WEditor.Value != null ? Route2WEditor.Value.ToString() : string.Empty;
                        //entity.Country = CountryEditor.Value != null ? CountryEditor.Value.ToString() : string.Empty;

                        //entity.Airports = AirportsEditor.Value != null ? AirportsEditor.Value.ToString() : string.Empty;
                        //entity.Ori = OriEditor.Value != null ? OriEditor.Value.ToString() : string.Empty;
                        //entity.Des = DesEditor.Value != null ? DesEditor.Value.ToString() : string.Empty;
                        //entity.ACID = ACIDEditor.Value != null ? ACIDEditor.Value.ToString() : string.Empty;
                        //entity.AllocateFltDirection = DirectionEditor.Value != null ? DirectionEditor.Value.ToString() : string.Empty;
                        //entity.Network = NetworkEditor.Value != null ? NetworkEditor.Value.ToString() : string.Empty;
                        //if (ProfitEditor.Value != null)
                        //    entity.RouteProfitID = Convert.ToInt32(ProfitEditor.Value.ToString());
                        //else
                        //    entity.RouteProfitID = null;

                        //entity.CostType = CostTypeEditor.Value != null ? CostTypeEditor.Value.ToString() : string.Empty;
                        //entity.CostGroup = CostGroupEditor.Value != null ? CostGroupEditor.Value.ToString() : string.Empty;
                        //entity.FASTCode = FASTCodeEditor.Text;
                        //entity.MaVuViec = MaVuViecEditor.Text;
                        entity.IsCommercial = IsCommercialEditor.Checked;
                        entity.OutAllowUpdate = OutAllowUpdateEditor.Checked;
                        entity.DecAllowUpdate = DecAllowUpdateEditor.Checked;
                        entity.Active = ActiveEditor.Checked;
                        entity.Seq = (int)SeqEditor.Number;
                        entity.Sorting = SortingEditor.Text;
                        entity.Note = NoteEditor.Text;

                        //entity.AccLevel1 = AccLevel1Editor.Text;
                        //entity.AccLevel2 = AccLevel2Editor.Text;
                        //entity.AccLevel3 = AccLevel3Editor.Text;
                        //entity.AccLevel4 = AccLevel4Editor.Text;
                        //entity.AccLevel5 = AccLevel5Editor.Text;
                        //entity.MaBoPhan = MaBoPhanEditor.Text;
                        //entity.ManagermentCode = ManagermentCodeEditor.Text;
                        //entity.ACCode = ACCodeEditor.Text;
                        //entity.OriCountry = OriCountryEditor.Text;
                        //entity.DesCountry = DesCountryEditor.Text;
                        //entity.DirectIndirect = DirectIndirectEditor.Value != null ? DirectIndirectEditor.Value.ToString() : string.Empty;

                        if (!SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR))
                            entity.CompanyID = SessionUser.CompanyID;

                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.DecSubaccounts.Add(entity);
                        entities.SaveChangesWithAuditLogs();

                    }
                    LoadDataToGrid();

                    s.JSProperties["cpResult"] = "Success";
                }
                catch (Exception ex)
                {
                    s.JSProperties["cpResult"] = ex.Message;
                }
            }
        }
    }
    protected void DataGrid_CustomDataCallback(object sender, TreeListCustomDataCallbackEventArgs e)
    {
        decimal key;
        if (!decimal.TryParse(e.Argument, out key))
            return;

        var subaccount = entities.DecSubaccounts.SingleOrDefault(x => x.SubaccountID == key);
        if (subaccount == null)
            return;

        var result = new Dictionary<string, string>();
        result["ParentID"] = (subaccount.SubaccountParentID ?? decimal.Zero).ToString();
        result["Description"] = subaccount.Description;
        result["Calculation"] = subaccount.Calculation;
        result["AccountGroup"] = subaccount.AccountGroup;
        //result["AccountType"] = (subaccount.AccountType ?? 0).ToString();
        //result["ActivityID"] = (subaccount.ActivityID ?? decimal.Zero).ToString();
        //result["AllocatedDriver"] = subaccount.AllocatedDriver;
        //result["Carrier"] = subaccount.Carrier;
        //result["AllocatedFLT"] = subaccount.AllocatedFLT;
        //result["FleetType"] = subaccount.Fleet_Type;
        //result["AllocatedRT"] = subaccount.AllocatedRT;
        //result["Route2W"] = subaccount.Route2W;
        //result["Country"] = subaccount.Country;
        //result["Airports"] = subaccount.Airports;
        //result["Ori"] = subaccount.Ori;
        //result["Des"] = subaccount.Des;
        //result["ACID"] = subaccount.ACID;
        //result["Direction"] = subaccount.AllocateFltDirection;
        //result["Network"] = subaccount.Network;
        //result["RouteProfitID"] = (subaccount.RouteProfitID ?? 0).ToString();
        //result["CostType"] = subaccount.CostType;
        //result["CostGroup"] = subaccount.CostGroup;
        result["IsCommercial"] = (subaccount.IsCommercial ?? false) ? "True" : "False";
        result["OutAllowUpdate"] = (subaccount.OutAllowUpdate ?? false) ? "True" : "False";
        result["DecAllowUpdate"] = (subaccount.DecAllowUpdate ?? false) ? "True" : "False";
        result["Active"] = (subaccount.Active ?? false) ? "True" : "False";
        result["Seq"] = (subaccount.Seq ?? 0).ToString();
        result["Sorting"] = subaccount.Sorting;
        result["Note"] = subaccount.Note;
        //result["FASTCode"] = subaccount.FASTCode;
        //result["MaVuViec"] = subaccount.MaVuViec;

        //result["AccLevel1"] = subaccount.AccLevel1;
        //result["AccLevel2"] = subaccount.AccLevel2;
        //result["AccLevel3"] = subaccount.AccLevel3;
        //result["AccLevel4"] = subaccount.AccLevel4;
        //result["AccLevel5"] = subaccount.AccLevel5;
        //result["MaBoPhan"] = subaccount.MaBoPhan;
        //result["ManagermentCode"] = subaccount.ManagermentCode;
        //result["ACCode"] = subaccount.ACCode;
        //result["OriCountry"] = subaccount.OriCountry;
        //result["DesCountry"] = subaccount.DesCountry;
        //result["DirectIndirect"] = subaccount.DirectIndirect;
        result["Division"] = subaccount.Division;
        e.Result = result;
    }
    protected void ActivityEditor_Init(object sender, EventArgs e)
    {
        //ASPxComboBox s = sender as ASPxComboBox;
        //var list = entities.Activities.OrderBy(x => x.Seq).ToList();
        //s.DataSource = list;
        //s.ValueField = "ActivityID";
        //s.TextField = "ActivityName";
        //s.DataBind();
    }
    protected void ACIDEditor_Init(object sender, EventArgs e)
    {
        ASPxTokenBox s = sender as ASPxTokenBox;
        var acs = entities.DecAircrafts
            .Select(x => new { Aircraft_Iata = x.Aircraft_Iata })
            .ToList();
        s.DataSource = acs;
        s.ValueField = "Aircraft_Iata";
        s.TextField = "Aircraft_Iata";
        s.DataBind();
    }
    protected void DriverEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DecTableValues
            .Where(x => x.Tables == "DEC_COMPANY" && x.Field == "ALLOCATE_DRIVER")
            .Select(x => new { DefValue = x.DefValue, Description = x.Description })
            .ToList();
        s.DataSource = list;
        s.ValueField = "DefValue";
        s.TextField = "Description";
        s.DataBind();
    }
    protected void CarrierEditor_Init(object sender, EventArgs e)
    {
        ASPxTokenBox s = sender as ASPxTokenBox;
        var list = entities.Code_Airlines.Select(x => new { AirlinesCode = x.AirlinesCode }).ToList();
        s.DataSource = list;
        s.ValueField = "AirlinesCode";
        s.TextField = "AirlinesCode";
        s.DataBind();
    }
    protected void FltTypeEditor_Init(object sender, EventArgs e)
    {
        ASPxTokenBox s = sender as ASPxTokenBox;
        var list = entities.DecTableValues
            .Where(x => x.Tables == "FLT_OPS" && x.Field == "FLT_TYPE")
            .Select(x => new { DefValue = x.DefValue, Description = x.Description })
            .ToList();
        s.DataSource = list;
        s.ValueField = "DefValue";
        s.TextField = "Description";
        s.DataBind();
    }
    protected void AirportsEditor_Init(object sender, EventArgs e)
    {
        ASPxTokenBox s = sender as ASPxTokenBox;
        if (Session[SessionConstant.AIRPORT] != null)
        {
            var list = Session[SessionConstant.AIRPORT];
            s.DataSource = list;
        }
        else
        {
            var list = entities.AIRPORTS1
                .Select(x => new { Code = x.CODE, NameE = x.CODE })
                .ToList();
            Session[SessionConstant.AIRPORT] = list;
            s.DataSource = list;
        }
        s.ValueField = "Code";
        s.TextField = "NameE";
        s.DataBind();
    }

    protected void RouteEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DecTableValues
            .Where(x => x.Tables == "DEC_COMPANY" && x.Field == "ALLOCATED_RT")
            .Select(x => new { DefValue = x.DefValue, Description = x.Description })
            .ToList();
        s.DataSource = list;
        s.ValueField = "DefValue";
        s.TextField = "Description";
        s.DataBind();
    }


    protected void DataGrid_HtmlRowPrepared(object sender, TreeListHtmlRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("Calculation"), "SUM"))
        {
            e.Row.Font.Bold = true;
        }
    }

    private void LoadCostGroup(object sender)
    {
        ASPxComboBox s = sender as ASPxComboBox;

        var list = entities.DecTableValues
            .Where(x => x.Tables == "DEC_COMPANY" && x.Field == "COST_GROUP")
            .Select(x => new { DefValue = x.DefValue, Description = x.DefValue + "-" + x.Description })
            .ToList();

        s.DataSource = list;

        s.ValueField = "DefValue";
        s.TextField = "Description";
        s.DataBind();
    }
    protected void CostGroupEditor_Init(object sender, EventArgs e)
    {

        LoadCostGroup(sender);
    }
    protected void cboProfit_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;

        var list = entities.RepRouteProfits.Where(x => x.Calculation == "DATA").ToList();


        s.DataSource = list;

        s.ValueField = "RouteProfitID";
        s.TextField = "Description";
        s.DataBind();
    }

    private void LoadFastCode(int key)
    {
        if (SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR))
        {
            var list = entities.DecSubFastCodes.Where(x => x.SubacountID == key).ToList();
            FastCodeGrid.DataSource = list;
        }
        else
        {
            string areaCode = SessionUser.AreaCode;
            var list = entities.DecSubFastCodes.Where(x => x.SubacountID == key && x.AreaCode == areaCode).ToList();
            FastCodeGrid.DataSource = list;
        }
        FastCodeGrid.DataBind();
    }
    protected void FastCodeGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "LoadFastCode")
        {
            int key;
            if (!int.TryParse(args[1], out key))
                return;

            LoadFastCode(key);
        }
    }
    protected void FastCodeGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        int subaccountID = 0;
        try
        {
            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {

                int vSubFastCodeID = Convert.ToInt32(updValues.Keys["SubFastCodeID"]);
                var entity = entities.DecSubFastCodes.SingleOrDefault(x => x.SubFastCodeID == vSubFastCodeID);
                if (entity != null)
                {
                    if (updValues.NewValues["FastCode"] != null)
                        entity.FastCode = updValues.NewValues["FastCode"].ToString().Replace(" ", "").Trim();

                    if (updValues.NewValues["SubCode"] != null)
                        entity.SubCode = updValues.NewValues["SubCode"].ToString().Replace(" ", "").Trim();

                    if (subaccountID == 0)
                        subaccountID = (int)entity.SubacountID;

                    entities.SaveChangesWithAuditLogs();
                }
            }
            if (subaccountID != decimal.Zero)
            {
                LoadFastCode(subaccountID);
            }
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
    protected void mMain_ItemClick(object source, MenuItemEventArgs e)
    {
        string strParams = string.Empty;
        string url = string.Empty;

        TreeListExporter.WriteXlsxToResponse();

    }
    protected void ASPxButton2_Click(object sender, EventArgs e)
    {
        TreeListExporter.WriteXlsxToResponse();
    }

    protected void FleetTypeEditor_Init(object sender, EventArgs e)
    {
        ASPxTokenBox s = sender as ASPxTokenBox;

        if (Session[SessionConstant.FLEETTYPE] != null)
        {
            var list = Session[SessionConstant.FLEETTYPE];
            s.DataSource = list;
        }
        else
        {
            var list = entities.DecTableValues
                 .Where(x => x.Tables == "DEC_SUBACCOUNT" && x.Field == "FLEETTYPE")
                 .Select(x => new { DefValue = x.DefValue, Description = x.Description })
                 .ToList();

            Session[SessionConstant.FLEETTYPE] = list;
            s.DataSource = list;
        }

        s.ValueField = "DefValue";
        s.TextField = "Description";
        s.DataBind();
    }

    protected void CountryEditor_Init(object sender, EventArgs e)
    {

        ASPxTokenBox s = sender as ASPxTokenBox;

        if (Session[SessionConstant.COUNTRY] != null)
        {
            var list = Session[SessionConstant.COUNTRY];
            s.DataSource = list;
        }
        else
        {
            var list = entities.Countries.Where(x => x.CountryCode != "**")
              .Select(x => new { CountryCode = x.CountryCode })
              .ToList();
            Session[SessionConstant.COUNTRY] = list;
            s.DataSource = list;
        }

        s.ValueField = "CountryCode";
        s.TextField = "CountryCode";
        s.DataBind();
    }

    protected void Route2WEditor_Init(object sender, EventArgs e)
    {
        ASPxTokenBox s = sender as ASPxTokenBox;

        if (Session[SessionConstant.Route2W] != null)
        {
            var list = Session[SessionConstant.Route2W];
            s.DataSource = list;
        }
        else
        {
            var list = entities.DecRoutes.Select(x => new { Route = x.Route2W })
            .ToList();

            Session[SessionConstant.Route2W] = list;
            s.DataSource = list;
        }

        s.ValueField = "Route";
        s.TextField = "Route";
        s.DataBind();
    }

    protected void Callback_Callback(object source, CallbackEventArgs e)
    {
        var args = e.Parameter.Split('|');

        if (args[0] == "CheckPermistion")
        {
            int subaccountId;
            if (!int.TryParse(args[1], out subaccountId))
                return;

            var entity = entities.DecSubaccounts.SingleOrDefault(v => v.SubaccountID == subaccountId);
            if (entity == null)
            {
                e.Result = "FAIL";
                return;
            }
            if (SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR))
            {
                e.Result = "OK";
                return;
            }

            if (entity.CompanyID == null)
            {
                e.Result = "NOT_OK";
                return;
            }

            if (entity.CompanyID.Value != SessionUser.CompanyID)
            {
                e.Result = "NOT_OK";
                return;
            }
        }
    }

    protected void DivisionEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;

        var list = entities.DecTableValues
                 .Where(x => x.Tables == "DEC_SUBACCOUNT" && x.Field == "DIVISION")
                 .Select(x => new { DefValue = x.DefValue, Description = x.Description })
                 .ToList();


        s.DataSource = list;
        s.ValueField = "DefValue";
        s.TextField = "Description";
        s.DataBind();
    }
}