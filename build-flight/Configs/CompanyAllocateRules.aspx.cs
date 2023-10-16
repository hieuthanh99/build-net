using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using KHNNData;

public partial class Configs_CompanyAllocateRules : BasePage
{
    QLKHDataEntities entities = new QLKHDataEntities();
    const string COMPANIES_SESSION = "5F964954-27EE-4CA0-A9BD-9D9192B0E169";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack || CompaniesGrid.IsCallback || AllocateRulesGrid.IsCallback || ActivityGrid.IsCallback)
        {
            LoadCompaniesToGrid();
            this.CompaniesGrid.ExpandAll();
        }

        if (!IsPostBack || AllocateRulesGrid.IsCallback)
        {
            if (this.CompaniesGrid.FocusedNode != null)
            {
                var companyID = this.CompaniesGrid.FocusedNode.Key;
                if (!StringUtils.isEmpty(companyID))
                    LoadCompanyAllocateRules(Convert.ToDecimal(companyID));
            }
        }

        if (!IsPostBack || ActivityGrid.IsCallback)
        {
            var companyID = this.CompaniesGrid.FocusedNode.Key;
            if (!StringUtils.isEmpty(companyID))
                LoadActivityGrid(Convert.ToDecimal(companyID));
        }
    }

    #region Load data
    private void LoadCompaniesToGrid()
    {
        if (Session[COMPANIES_SESSION] != null)
        {
            this.CompaniesGrid.DataSource = (List<Company>)Session[COMPANIES_SESSION];
        }
        else
        {
            var list = entities.Companies.OrderBy(x => x.Seq).ToList();
            this.CompaniesGrid.DataSource = list;
            Session[COMPANIES_SESSION] = list;
        }
        this.CompaniesGrid.DataBind();
    }

    private void LoadCompanyAllocateRules(decimal companyID)
    {
        var list = entities.CompanyAllocatedRules.Where(x => x.CompanyID == companyID).OrderBy(x => x.Seq).ToList();
        this.AllocateRulesGrid.DataSource = list;
        this.AllocateRulesGrid.DataBind();
    }

    private void LoadActivityGrid(decimal companyID)
    {
        var activityIDs = entities.CompanyAllocatedRules.Where(x => x.CompanyID == companyID).Select(x => x.ActivityID).ToList();
        var list = entities.Activities.Where(x => !activityIDs.Contains(x.ActivityID)).OrderBy(x => x.Seq).ToList(); // && !(entities.Activities.Where(t => t.ParentID == x.ActivityID).Any())
        this.ActivityGrid.DataSource = list;
        this.ActivityGrid.DataBind();
    }
    #endregion

    protected void CompaniesGrid_HtmlRowPrepared(object sender, DevExpress.Web.ASPxTreeList.TreeListHtmlRowEventArgs e)
    {
        //if (!Object.Equals(e.GetValue("CompanyType"), "D"))
        //{
        //    e.Row.Font.Bold = true;
        //}
    }
    protected void AllocateRulesGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        decimal companyID;
        decimal companyAllocateRuleID;
        switch (args[0])
        {
            case "Refresh":
                if (!decimal.TryParse(args[1], out companyID))
                    return;

                LoadCompanyAllocateRules(companyID);
                break;
            case "Remove":
                decimal companyAllocatedRuleID;
                if (decimal.TryParse(args[1], out companyAllocatedRuleID))
                {
                    var entity = entities.CompanyAllocatedRules.SingleOrDefault(x => x.CompanyAllocatedRuleID == companyAllocatedRuleID);
                    if (entity != null)
                    {
                        companyID = entity.CompanyID.Value;
                        entities.CompanyAllocatedRules.Remove(entity);
                        entities.SaveChanges();

                        LoadCompanyAllocateRules(companyID);
                    }
                }
                break;

            case "SaveForm":
                try
                {
                    var command = args[1];
                    if (command.ToUpper() == "EDIT")
                    {
                        if (decimal.TryParse(args[2], out companyAllocateRuleID))
                        {
                            var entity = entities.CompanyAllocatedRules.Where(x => x.CompanyAllocatedRuleID == companyAllocateRuleID).SingleOrDefault();
                            if (entity == null)
                                return;

                            entity.ActivityID = Convert.ToInt32(ActivityEditor.Value);
                            if (AllocateKEditor.Value != null)
                                entity.AllocateK = AllocateKEditor.Number;
                            if (StaffEditor.Value != null)
                                entity.Staff = StaffEditor.Number;
                            if (SalaryEditor.Value != null)
                                entity.Salary = SalaryEditor.Number;
                            if (CostEditor.Value != null)
                                entity.Cost = CostEditor.Number;
                            if (RevenueEditor.Value != null)
                                entity.Revenue = RevenueEditor.Number;
                            if (Option1Editor.Value != null)
                                entity.Option1 = Option1Editor.Number;
                            if (Option2Editor.Value != null)
                                entity.Option2 = Option2Editor.Number;
                            if (Option3Editor.Value != null)
                                entity.Option3 = Option3Editor.Number;

                            entity.LastUpdateDate = DateTime.Now;
                            entity.LastUpdatedBy = (int)SessionUser.UserID;
                            entities.SaveChanges();


                            LoadCompanyAllocateRules((decimal)entity.CompanyID);
                        }
                    }

                    s.JSProperties["cpResult"] = "Success";
                }
                catch (Exception ex)
                {
                    s.JSProperties["cpResult"] = ex.Message;
                }

                break;
        }
    }
    protected void AllocateRulesGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "EditForm" && args.Length == 3)
        {
            decimal key;
            if (!decimal.TryParse(args[2], out key))
                return;


            var entity = entities.CompanyAllocatedRules.SingleOrDefault(x => x.CompanyAllocatedRuleID == key);
            if (entity == null)
                return;

            var result = new Dictionary<string, object>();
            result["ActivityID"] = entity.ActivityID.ToString();
            result["AllocateK"] = entity.AllocateK.HasValue ? entity.AllocateK.ToString() : string.Empty;
            result["Staff"] = entity.Staff;
            result["Salary"] = entity.Salary;
            result["Cost"] = entity.Cost;
            result["Revenue"] = entity.Revenue;
            result["Option1"] = entity.Option1;
            result["Option2"] = entity.Option2;
            result["Option3"] = entity.Option3;

            e.Result = result;
        }
    }
    protected void ActivityGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        decimal companyId;
        switch (args[0])
        {
            case "Refresh":
                if (!decimal.TryParse(args[1], out companyId))
                    return;

                LoadActivityGrid(companyId);

                break;
            case "Apply":

                if (!decimal.TryParse(args[1], out companyId))
                    return;

                var company = entities.Companies.SingleOrDefault(x => x.CompanyID == companyId);
                if (company == null)
                    return;

                List<object> fieldValues = s.GetSelectedFieldValues(new string[] { "ActivityID", "ActivityName" });
                if (fieldValues.Count == 0)
                    return;
                else
                {
                    foreach (object[] item in fieldValues)
                    {
                        var entity = new CompanyAllocatedRule();
                        entity.CompanyID = companyId;
                        entity.ActivityID = Convert.ToInt32(item[0]);
                        entity.Description = item[1] != null ? item[1].ToString() : string.Empty;

                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.CompanyAllocatedRules.Add(entity);
                        entities.SaveChanges();
                    }
                    s.Selection.UnselectAll();
                    LoadActivityGrid(company.CompanyID);
                }
                break;

        }
    }
    protected void ActivityEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var activities = entities.Activities.OrderBy(x => x.Seq).ToList();
        s.DataSource = activities;
        s.ValueField = "ActivityID";
        s.TextField = "ActivityName";
        s.DataBind();
    }
    protected void ActivityGrid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("Calculation"), "SUM"))
        {
            e.Row.Font.Bold = true;
        }
    }
    protected void AllocateRulesGrid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
    {

    }
}