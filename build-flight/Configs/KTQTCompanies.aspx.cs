using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using KTQTData;

public partial class Pages_KTQTCompanies : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.mMain.Items.FindByName("New").Visible = IsGranted("Pages.KHTC.Configs.KTQTCompanies.Create");
        this.mMain.Items.FindByName("Edit").Visible = IsGranted("Pages.KHTC.Configs.KTQTCompanies.Edit");
        this.mMain.Items.FindByName("Delete").Visible = IsGranted("Pages.KHTC.Configs.KTQTCompanies.Delete");
        this.mMain.Items.FindByName("SyncData").Visible = IsGranted("Pages.KHTC.Configs.KTQTCompanies.SyncData");

        if (!IsPostBack || DataGrid.IsCallback)
        {
            LoadDataToGrid();
            DataGrid.ExpandAll();
        }
    }

    #region Load data
    private void LoadDataToGrid()
    {
        var list = entities.DecCompanies.OrderBy(x => x.Seq).ToList();
        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }
    #endregion

    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomCallbackEventArgs e)
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
            int key;
            if (!int.TryParse(args[1], out key))
                return;

            var entity = (from x in entities.DecCompanies where x.CompanyID == key select x).FirstOrDefault();
            if (entity != null)
            {
                entities.DecCompanies.Remove(entity);
                entities.SaveChanges();
                LoadDataToGrid();
            }
        }
        else if (args[0].Equals(Action.SYNC_DATA))
        {
            s.JSProperties["cpResult"] = Action.SYNC_DATA;
            entities.Sync_PMSDecCompany();

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
                        int key;
                        if (!int.TryParse(args[2], out key))
                            return;


                        var entity = entities.DecCompanies.Where(x => x.CompanyID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            if (ParentEditor.Value != null)
                                entity.ParentID = Convert.ToInt32(ParentEditor.Value);
                            else
                                entity.ParentID = null;
                            entity.AreaCode = AreaEditor.Value != null ? AreaEditor.Value.ToString() : string.Empty;
                            //entity.OriArea = OriAreaEditor.Value != null ? OriAreaEditor.Value.ToString() : string.Empty;
                            entity.ShortName = ShortNameEditor.Text;
                            entity.NameE = NameENEditor.Text;
                            entity.NameV = NameVNEditor.Text;
                            //entity.FASTCode = txtFASTCodeEditor.Text;
                            if (ValidFromEditor.Value != null)
                                entity.ValidFrom = ValidFromEditor.Date;
                            else
                                entity.ValidFrom = null;
                            if (ValidToEditor.Value != null)
                                entity.ValidTo = ValidToEditor.Date;
                            else
                                entity.ValidTo = null;

                            //if (DivisionEditor.Value != null)
                            //    entity.DivisionID = Convert.ToInt32(DivisionEditor.Value);
                            //else
                            //    entity.DivisionID = null;

                            if (CompanyGroupEditor.Value != null)
                                entity.CompanyGroup = CompanyGroupEditor.Value.ToString();
                            else
                                entity.CompanyGroup = null;

                            if (CompanyTypeEditor.Value != null)
                                entity.CompanyType = CompanyTypeEditor.Value.ToString();
                            else
                                entity.CompanyType = null;
                            entity.Seq = (int)SeqEditor.Number;
                            entity.Note = NoteEditor.Text;
                            entity.Curr = CurrencyEditor.Text.ToUpper();
                            entity.Section = SectionEditor.Value != null ? SectionEditor.Value.ToString() : string.Empty;
                            //entity.IsOnBehalfOfBRA = ckOnBehalfOfBRA.Checked;
                            //entity.IsOnBehalfOfCTY = ckOnBehalfOfCTY.Checked;
                            //entity.IsOnBehalfOf = cboOnBehalfOf.Value != null ? cboOnBehalfOf.Value.ToString() : "NO";
                            //entity.IsExternalCost = ckIsExternalCost.Checked;
                            entity.Active = ckActive.Checked;
                            if (DivisionCodeEditor.Value != null)
                                entity.DivisionCode = Convert.ToInt32(DivisionCodeEditor.Value.ToString());
                            else
                                entity.DivisionCode = null;

                            entity.DepartmentCode = DepartmentCodeEditor.Value != null ? DepartmentCodeEditor.Value.ToString() : string.Empty;

                            entity.LastUpdateDate = DateTime.Now;
                            entity.LastUpdatedBy = (int)SessionUser.UserID;
                            entities.SaveChanges();

                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new DecCompany();
                        if (ParentEditor.Value != null)
                            entity.ParentID = Convert.ToInt32(ParentEditor.Value);
                        else
                            entity.ParentID = null;
                        entity.AreaCode = AreaEditor.Value != null ? AreaEditor.Value.ToString() : string.Empty;
                        //entity.OriArea = OriAreaEditor.Value != null ? OriAreaEditor.Value.ToString() : string.Empty;
                        entity.ShortName = ShortNameEditor.Text;
                        entity.NameE = NameENEditor.Text;
                        entity.NameV = NameVNEditor.Text;
                        //entity.FASTCode = txtFASTCodeEditor.Text;
                        if (ValidFromEditor.Value != null)
                            entity.ValidFrom = ValidFromEditor.Date;
                        if (ValidToEditor.Value != null)
                            entity.ValidTo = ValidToEditor.Date;
                        //if (DivisionEditor.Value != null)
                        //    entity.DivisionID = Convert.ToInt32(DivisionEditor.Value);
                        //else
                        //    entity.DivisionID = null;
                        if (CompanyGroupEditor.Value != null)
                            entity.CompanyGroup = CompanyGroupEditor.Value.ToString();
                        else
                            entity.CompanyGroup = null;

                        if (CompanyTypeEditor.Value != null)
                            entity.CompanyType = CompanyTypeEditor.Value.ToString();
                        else
                            entity.CompanyType = null;
                        entity.Seq = (int)SeqEditor.Number;
                        entity.Note = NoteEditor.Text;
                        entity.Curr = CurrencyEditor.Text.ToUpper();
                        entity.Section = SectionEditor.Value != null ? SectionEditor.Value.ToString() : string.Empty;
                        //entity.IsOnBehalfOfBRA = ckOnBehalfOfBRA.Checked;
                        //entity.IsOnBehalfOfCTY = ckOnBehalfOfCTY.Checked;
                        //entity.IsOnBehalfOf = cboOnBehalfOf.Value != null ? cboOnBehalfOf.Value.ToString() : "NO";
                        //entity.IsExternalCost = ckIsExternalCost.Checked;
                        entity.Active = ckActive.Checked;

                        if (DivisionCodeEditor.Value != null)
                            entity.DivisionCode = Convert.ToInt32(DivisionCodeEditor.Value.ToString());
                        else
                            entity.DivisionCode = null;

                        entity.DepartmentCode = DepartmentCodeEditor.Value != null ? DepartmentCodeEditor.Value.ToString() : string.Empty;

                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.DecCompanies.Add(entity);
                        entities.SaveChanges();


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
    protected void DataGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
    {
        int key;
        if (!int.TryParse(e.Argument, out key))
            return;

        var company = entities.DecCompanies.SingleOrDefault(x => x.CompanyID == key);
        if (company == null)
            return;

        var result = new Dictionary<string, string>();
        result["ParentID"] = company.ParentID.HasValue ? company.ParentID.ToString() : null;
        //result["DivisionID"] = (company.DivisionID ?? 0).ToString();
        result["AreaCode"] = company.AreaCode;
        result["OriArea"] = company.OriArea;
        result["ShortName"] = company.ShortName;
        //result["FASTCode"] = company.FASTCode;
        result["NameV"] = company.NameV;
        result["NameE"] = company.NameE;
        result["CompanyGroup"] = company.CompanyGroup;
        result["CompanyType"] = company.CompanyType;
        result["DivisionCode"] = company.DivisionCode.HasValue ? company.DivisionCode.ToString() : string.Empty;
        result["DepartmentCode"] = company.DepartmentCode;
        result["ValidFrom"] = company.ValidFrom.HasValue ? company.ValidFrom.Value.ToString("yyyy-MM-dd") : string.Empty;
        result["ValidTo"] = company.ValidTo.HasValue ? company.ValidTo.Value.ToString("yyyy-MM-dd") : string.Empty;
        result["Seq"] = (company.Seq ?? 0).ToString();
        result["Note"] = company.Note;
        result["Curr"] = company.Curr;
        result["Section"] = company.Section;
        //result["IsOnBehalfOfBRA"] = company.IsOnBehalfOfBRA.HasValue && company.IsOnBehalfOfBRA.Value == true ? "True" : "False";
        //result["IsOnBehalfOfCTY"] = company.IsOnBehalfOfCTY.HasValue && company.IsOnBehalfOfCTY.Value == true ? "True" : "False";
        //result["IsOnBehalfOf"] = company.IsOnBehalfOf;
        //result["IsExternalCost"] = company.IsExternalCost.HasValue && company.IsExternalCost.Value == true ? "True" : "False";
        result["Active"] = company.Active.HasValue && company.Active.Value == true ? "True" : "False";

        e.Result = result;
    }
    protected void ParentEditor_Callback(object sender, CallbackEventArgsBase e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DecCompanies
                .Select(x => new { CompanyID = x.CompanyID, NameV = x.AreaCode + "-" + x.NameV, Seq = x.Seq })
                .OrderBy(x => x.Seq).ToList();
        s.DataSource = list;
        s.ValueField = "CompanyID";
        s.TextField = "NameV";
        s.DataBind();
    }
    protected void DivisionEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DecManagements.OrderBy(x => x.Seq).ToList();
        s.DataSource = list;
        s.ValueField = "DivisionID";
        s.TextField = "NameV";
        s.DataBind();
    }
    protected void ShortNameEditor_Validation(object sender, ValidationEventArgs e)
    {
        if (e.Value == null)
        {
            e.ErrorText = "Short Name is required";
            e.IsValid = false;
            return;
        }
        //string value = e.Value.ToString();
        //var exists = entities.Companies.Where(x => x.ShortName == value).Any();
    }
    protected void DataGrid_HtmlRowPrepared(object sender, TreeListHtmlRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("CompanyType"), "K"))
        {
            e.Row.Font.Bold = true;
        }
    }
    protected void CompanyGroupEditor_Init(object sender, EventArgs e)
    {
        LoadCompanyGroup(sender);
    }

    private void LoadCompanyGroup(object sender)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        if (Session[SessionConstant.COMPANY_GROUP] != null)
        {
            var list = Session[SessionConstant.COMPANY_GROUP];
            s.DataSource = list;
        }
        else
        {
            var list = entities.DecTableValues
                .Where(x => x.Tables == "DEC_COMPANY" && x.Field == "COMPANY_GROUP")
                .Select(x => new { DefValue = x.DefValue, Description = x.DefValue + "-" + x.Description })
                .ToList();
            Session[SessionConstant.COMPANY_GROUP] = list;
            s.DataSource = list;
        }
        s.ValueField = "DefValue";
        s.TextField = "Description";
        s.DataBind();
    }
    protected void CompanyGroupEditor_Callback(object sender, CallbackEventArgsBase e)
    {
        var args = e.Parameter.Split('|');
        if (args[0] == "AddCompanyGroup")
        {
            var table = new DecTableValue();
            table.Tables = "DEC_COMPANY";
            table.Field = "COMPANY_GROUP";
            table.DefValue = CGCodeEditor.Text;
            table.Description = CGNameEditor.Text;
            table.CreateDate = DateTime.Now;
            table.CreatedBy = (int)SessionUser.UserID;

            entities.DecTableValues.Add(table);
            entities.SaveChanges();

            Session[SessionConstant.COMPANY_GROUP] = null;
            LoadCompanyGroup(sender);

        }
    }
    protected void AreaEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DecTableValues
                       .Where(x => x.Tables == "DEC_COMPANY" && x.Field == "AREA")
                       .OrderBy(x => x.Sort)
                       .ToList();
        ListEditItem le = new ListEditItem();

        foreach (var item in list)
        {
            le = new ListEditItem();
            le.Value = item.DefValue;
            le.Text = item.Description;
            s.Items.Add(le);
        }
        if (s.Items.Count > 0)
        {
            var curCompany = entities.DecCompanies.SingleOrDefault(x => x.CompanyID == SessionUser.CompanyID);
            if (curCompany != null)
                s.Value = curCompany.AreaCode;
        }
    }
    protected void DataGrid_CustomUnboundColumnData(object sender, TreeListCustomUnboundColumnDataEventArgs e)
    {
        if (e.Column.FieldName == "OnBehalfOf")
        {
            if (!Object.Equals(e.Node.GetValue("CompanyType"), "K"))
            {
                //int key = Convert.ToInt32(e.Node.Key);
                List<DecTableValue> list = null;
                if (Session[SessionConstant.ON_BEHALF_OF] != null)
                {
                    list = (List<DecTableValue>)Session[SessionConstant.ON_BEHALF_OF];
                }
                else
                {
                    list = entities.DecTableValues
                       .Where(x => x.Tables == "DEC_COMPANY" && x.Field == "ISONBEHALFOF")
                       .OrderBy(x => x.Sort)
                       .ToList();
                    Session[SessionConstant.ON_BEHALF_OF] = list;
                }

                var isOnBehalfOf = e.Node.GetValue("IsOnBehalfOf") != null ? e.Node.GetValue("IsOnBehalfOf").ToString().Trim() : "NO";
                e.Value = list.Find(x => x.DefValue == isOnBehalfOf).Description;
            }
        }
    }
    protected void cboOnBehalfOf_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        if (Session[SessionConstant.ON_BEHALF_OF] != null)
        {
            var list = Session[SessionConstant.ON_BEHALF_OF];
            s.DataSource = list;
        }
        else
        {
            var list = entities.DecTableValues
                .Where(x => x.Tables == "DEC_COMPANY" && x.Field == "ISONBEHALFOF")
                .OrderBy(x => x.Sort)
                .ToList();
            Session[SessionConstant.ON_BEHALF_OF] = list;
            s.DataSource = list;
        }
        s.ValueField = "DefValue";
        s.TextField = "Description";
        s.DataBind();
    }
}