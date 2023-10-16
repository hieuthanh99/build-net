using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using KTQTData;
using DevExpress.Web.Data;

public partial class Pages_KTQTGroupSubaccount : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDataToGrid();
        
        if (!IsPostBack || DataGrid.IsCallback)
        {
            this.DataGrid.ExpandAll();
        }
      
    }

    #region Load data
    private void LoadDataToGrid()
    {
        var list = entities.DecGroupSubaccounts.OrderBy(x => x.Seq).ToList();
        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }
    #endregion
    protected void ParentEditor_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DecGroupSubaccounts.OrderBy(x => x.Seq).ToList();
        s.DataSource = list;
        s.ValueField = "GroupSubaccountID";
        s.TextField = "DescriptionVN";
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

            var entity = (from x in entities.DecGroupSubaccounts where x.GroupSubaccountID == key select x).FirstOrDefault();
            if (entity != null)
            {
                entities.DecGroupSubaccounts.Remove(entity);
                entities.SaveChangesWithAuditLogs();
                LoadDataToGrid();
            }
        }
        else if (args[0].Equals("UPDATESEQ"))
        {
            //entities.UpdateSubaccountSeq();
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


                        var entity = entities.DecGroupSubaccounts.Where(x => x.GroupSubaccountID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            if (ParentEditor.Value != null)
                                entity.GroupSubaccountParentID = Convert.ToInt32(ParentEditor.Value);
                            else
                                entity.GroupSubaccountParentID = null;
                            entity.DescriptionVN = DescriptionVNEditor.Text;
                            entity.DescriptionEN = DescriptionENEditor.Text;
                            entity.Calculation = CalculationEditor.Text;
                            if (AccountTypeEditor.Value != null)
                                entity.AccountType = AccountTypeEditor.Value.ToString();
                            else
                                entity.AccountType = null;
  
                           
                            entity.Seq = (int)SeqEditor.Number;
                            entity.Sorting = SortingEditor.Text;
                            entity.Note = NoteEditor.Text;
                            entity.Active = ActiveEditor.Checked;
                            entity.ManagementCode = ManagementCodeEditor.Text;
                            entity.Unit = UnitEditor.Text;

                            entity.ModifyDate = DateTime.Now;
                            entity.ModifiedBy = (int)SessionUser.UserID;
                            entities.SaveChangesWithAuditLogs();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new DecGroupSubaccount();
                        if (ParentEditor.Value != null)
                            entity.GroupSubaccountParentID = Convert.ToInt32(ParentEditor.Value);
                        else
                            entity.GroupSubaccountParentID = null;
                        entity.DescriptionVN = DescriptionVNEditor.Text;
                        entity.DescriptionEN = DescriptionENEditor.Text;
                        entity.Calculation = CalculationEditor.Text;
                        if (AccountTypeEditor.Value != null)
                            entity.AccountType = AccountTypeEditor.Value.ToString();
                        else
                            entity.AccountType = null;
                       
                        entity.Seq = (int)SeqEditor.Number;
                        entity.Sorting = SortingEditor.Text;
                        entity.Note = NoteEditor.Text;
                        entity.Active = ActiveEditor.Checked;
                        entity.ManagementCode = ManagementCodeEditor.Text;
                        entity.Unit = UnitEditor.Text;

                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.DecGroupSubaccounts.Add(entity);
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

        var subaccount = entities.DecGroupSubaccounts.SingleOrDefault(x => x.GroupSubaccountID == key);
        if (subaccount == null)
            return;

        var result = new Dictionary<string, string>();
        result["ParentID"] = (subaccount.GroupSubaccountParentID ?? decimal.Zero).ToString();
        result["DescriptionVN"] = subaccount.DescriptionVN;
        result["DescriptionEN"] = subaccount.DescriptionEN;
        result["Calculation"] = subaccount.Calculation;
        result["AccountType"] = subaccount.AccountType;
        result["ManagementCode"] = subaccount.ManagementCode;
        result["Unit"] = subaccount.Unit;
        result["Seq"] = (subaccount.Seq ?? 0).ToString();
        result["Sorting"] = subaccount.Sorting;
        result["Note"] = subaccount.Note;
        result["Active"] = (subaccount.Active ?? false) ? "True" : "False";

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
        //using (KHNNData.QLKHDataEntities khnn = new KHNNData.QLKHDataEntities())
        //{
        var list = entities.Airports
            .Select(x => new { Code = x.Code, NameE = x.NameE })
            .ToList();
        s.DataSource = list;
        s.ValueField = "Code";
        s.TextField = "NameE";
        s.DataBind();
        // }
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
}