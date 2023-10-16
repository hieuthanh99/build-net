using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using KTQTData;

public partial class Pages_Companies : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
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
                            entity.ShortName = ShortNameEditor.Text;
                            entity.NameE = NameENEditor.Text;
                            entity.NameV = NameVNEditor.Text;
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
                            entity.Seq = (int)SeqEditor.Number;
                            entity.Note = NoteEditor.Text;

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
                        entity.ShortName = ShortNameEditor.Text;
                        entity.NameE = NameENEditor.Text;
                        entity.NameV = NameVNEditor.Text;
                        if (ValidFromEditor.Value != null)
                            entity.ValidFrom = ValidFromEditor.Date;
                        if (ValidToEditor.Value != null)
                            entity.ValidTo = ValidToEditor.Date;
                        //if (DivisionEditor.Value != null)
                        //    entity.DivisionID = Convert.ToInt32(DivisionEditor.Value);
                        entity.Seq = (int)SeqEditor.Number;
                        entity.Note = NoteEditor.Text;

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
        result["ParentID"] = (company.ParentID ?? decimal.Zero).ToString();
        //result["DivisionID"] = (company.DivisionID ?? 0).ToString();
        result["ShortName"] = company.ShortName;
        result["NameV"] = company.NameV;
        result["NameE"] = company.NameE;
        result["CompanyGroup"] = company.CompanyGroup;
        result["CompanyType"] = company.CompanyType;
        result["ValidFrom"] = company.ValidFrom.HasValue ? company.ValidFrom.Value.ToString("yyyy-MM-dd") : string.Empty;
        result["ValidTo"] = company.ValidTo.HasValue ? company.ValidTo.Value.ToString("yyyy-MM-dd") : string.Empty;
        result["Seq"] = (company.Seq ?? 0).ToString();
        result["Note"] = company.Note;

        e.Result = result;
    }
    protected void ParentEditor_Callback(object sender, CallbackEventArgsBase e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DecCompanies.OrderBy(x => x.Seq).ToList();
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
}