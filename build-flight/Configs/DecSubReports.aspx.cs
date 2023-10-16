using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Configs_DecSubReports : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Remove(SessionConstant.COMPANIES_SESSION);
            ForYearEditor.Value = DateTime.Now.Year;
        }

        if (!IsPostBack || CompaniesGrid.IsCallback || SubReportsGrid.IsCallback)
        {
            LoadCompaniesToGrid();
            this.CompaniesGrid.ExpandAll();
        }

        if (!IsPostBack || SubReportsGrid.IsCallback)
        {
            if (this.CompaniesGrid.Nodes.Count > 0)
            {
                var subaccountID = this.CompaniesGrid.FocusedNode.Key;
                var year = Convert.ToInt32(ForYearEditor.Value);
                var reportName = ListReportEditor.Value.ToString();
                if (!StringUtils.isEmpty(subaccountID))
                    LoadSubReports(Convert.ToInt32(subaccountID), year, reportName);
            }
        }

        SetActionRights();
    }

    private void SetActionRights()
    {
        this.SubReportsGrid.SettingsDataSecurity.AllowEdit = IsGranted("Pages.KHTC.Configs.DecSubReports.Edit");
    }

    #region Load data

    private void LoadCompaniesToGrid()
    {
        if (Session[SessionConstant.COMPANIES_SESSION] != null)
        {
            this.CompaniesGrid.DataSource = (List<DecCompany>)Session[SessionConstant.COMPANIES_SESSION];
        }
        else
        {
            //if (SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR))
            //{
            //    //string areaCode = SessionUser.AreaCode;
            //    var list = entities.DecCompanies.OrderBy(x => x.Seq).ToList();
            //    this.CompaniesGrid.DataSource = list;
            //    Session[SessionConstant.COMPANIES_SESSION] = list;
            //}
            //else
            //{
            List<int> companies = new List<int>();
            using (APPData.QLKHAppEntities app = new APPData.QLKHAppEntities())
            {
                companies = app.UserCompanies.Where(x => x.UserID == SessionUser.UserID).Select(x => x.CompanyID).ToList();
            }

            DateTime validDate = DateTime.Now.Date;

            var list = entities.DecCompanies.Where(x => companies.Contains(x.CompanyID) && x.Section == "LVTM" && (x.Active ?? false) == true && ((x.ValidFrom ?? validDate) <= validDate && validDate <= (x.ValidTo ?? validDate))).OrderBy(x => x.Seq).ToList();
            this.CompaniesGrid.DataSource = list;
            Session[SessionConstant.COMPANIES_SESSION] = list;
            //}

        }
        this.CompaniesGrid.DataBind();
    }

    private void LoadSubReports(int companyID, int year, string reportName)
    {
        var list = (from x in entities.DecSubReports
                    join y in entities.DecSubaccounts on x.SubaccountID equals y.SubaccountID
                    select new
                    {
                        x.Id,
                        x.CompanyID,
                        x.SubaccountID,
                        y.Seq,
                        y.Sorting,
                        y.Calculation,
                        y.Description,
                        x.ForYear,
                        x.ReportName,
                        x.ShowReport,
                        y.AccountGroup
                    })
                .Where(x => x.CompanyID == companyID && x.ForYear == year && x.ReportName == reportName)
                .OrderBy(x => x.Seq)
                .ToList();

        this.SubReportsGrid.DataSource = list;
        this.SubReportsGrid.DataBind();
    }

    #endregion

    protected void SubReportsGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');

        if (args[0] == "Refresh")
        {
            int companyId;
            if (!int.TryParse(args[1], out companyId))
                return;

            if (ForYearEditor.Value != null && ListReportEditor.Value != null)
            {
                var year = Convert.ToInt32(ForYearEditor.Value);
                var reportName = ListReportEditor.Value.ToString();
                InitData(companyId, year, reportName);
                LoadSubReports(companyId, year, reportName);
            }
            SetActionRights();
        }
        else if (args[0] == "DoCopy")
        {
            int fromYear = Convert.ToInt32(FromYearEditor.Number);
            int toYear = Convert.ToInt32(ToYearEditor.Number);

            var fromReportName = FromReportEditor.Value.ToString();
            var toReportName = ToReportEditor.Value.ToString();

            //var list = entities.DecCompanies
            //    .Where(x => x.Section == "LVTM" && (x.Active ?? false) && x.CompanyType == "D")
            //    .Select(x=>x.CompanyID)
            //    .ToList();

            //foreach(var id in list)
            //{
            //    InitData(id, toYear, toReportName);
            //}

            entities.CopySubReports(fromYear, toYear, fromReportName, toReportName, SessionUser.UserID);

            int companyId;
            if (!int.TryParse(args[1], out companyId))
                return;
            LoadSubReports(companyId, Convert.ToInt32(ForYearEditor.Value), ListReportEditor.Value.ToString());
        }

        else if (args[0] == "ShowReport")
        {
            int key;
            if (!int.TryParse(args[1], out key))
                return;

            var showReport = args[2];

            var entity = entities.DecSubReports.SingleOrDefault(x => x.Id == key);
            if (entity == null) return;
            entity.ShowReport = Convert.ToBoolean(showReport);

            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = SessionUser.UserID;

            entities.SaveChangesWithAuditLogs();
        }
        else if (args[0] == "CheckAll")
        {
            int year;
            if (!int.TryParse(args[1], out year))
                return;
            var reportName = args[2];
            int companyId;
            if (!int.TryParse(args[3], out companyId))
                return;

            var listCheck = entities.DecSubReports
                .Where(x => x.ForYear == year && x.ReportName == reportName && x.CompanyID == companyId)
                .ToList();

            foreach (var rep in listCheck)
            {
                rep.ShowReport = true;
                rep.LastUpdateDate = DateTime.Now;
                rep.LastUpdatedBy = SessionUser.UserID;
            }
            entities.SaveChangesWithAuditLogs();

            if (ForYearEditor.Value != null && ListReportEditor.Value != null)
            {
                year = Convert.ToInt32(ForYearEditor.Value);
                reportName = ListReportEditor.Value.ToString();
                LoadSubReports(companyId, year, reportName);
            }
        }
        else if (args[0] == "UncheckAll")
        {
            int year;
            if (!int.TryParse(args[1], out year))
                return;
            var reportName = args[2];
            int companyId;
            if (!int.TryParse(args[3], out companyId))
                return;

            var listUncheck = entities.DecSubReports
                .Where(x => x.ForYear == year && x.ReportName == reportName && x.CompanyID == companyId)
                .ToList();

            foreach (var rep in listUncheck)
            {
                rep.ShowReport = false;
                rep.LastUpdateDate = DateTime.Now;
                rep.LastUpdatedBy = SessionUser.UserID;
            }

            entities.SaveChangesWithAuditLogs();

            if (ForYearEditor.Value != null && ListReportEditor.Value != null)
            {
                year = Convert.ToInt32(ForYearEditor.Value);
                reportName = ListReportEditor.Value.ToString();
                LoadSubReports(companyId, year, reportName);
            }
        }
        else if (args[0] == "CopyNode")
        {
            int copyCompanyId;
            int copyYear;
            int pasteCompanyId;
            int pasteYear;

            if (!int.TryParse(args[1], out copyCompanyId))
                return;

            if (!int.TryParse(args[2], out copyYear))
                return;

            if (!int.TryParse(args[4], out pasteCompanyId))
                return;

            if (!int.TryParse(args[5], out pasteYear))
                return;

            var copyReportName = args[3];
            var pasteReportName = args[6];

            var copyList = entities.DecSubReports
                .Where(x => x.ForYear == copyYear && x.ReportName == copyReportName && x.CompanyID == copyCompanyId)
                .Select(x => new
                {
                    x.SubaccountID,
                    x.ShowReport
                })
                .ToList();

            InitData(pasteCompanyId, pasteYear, pasteReportName);

            var pasteList = entities.DecSubReports
                .Where(x => x.CompanyID == pasteCompanyId && x.ReportName == pasteReportName && x.ForYear == pasteYear)
                .ToList();

            foreach (var paste in pasteList)
            {
                var showReport = copyList.Where(x => x.SubaccountID == paste.SubaccountID)
                                .Select(x => x.ShowReport).FirstOrDefault();

                if (showReport.HasValue)
                {
                    paste.ShowReport = showReport.Value;
                    paste.LastUpdateDate = DateTime.Now;
                    paste.LastUpdatedBy = SessionUser.UserID;
                }
            }

            entities.SaveChangesWithAuditLogs();

            if (ForYearEditor.Value != null && ListReportEditor.Value != null)
            {
                var year = Convert.ToInt32(ForYearEditor.Value);
                var reportName = ListReportEditor.Value.ToString();
                LoadSubReports(pasteCompanyId, year, reportName);
            }
        }
    }

    private void InitData(int companyId, int forYear, string reportName)
    {
        var companyType = entities.DecCompanies.Where(x => x.CompanyID == companyId)
            .Select(x => x.CompanyType).FirstOrDefault();

        if (!string.IsNullOrEmpty(companyType) && companyType == "D")
        {
            var subIds = entities.DecSubReports
                   .Where(x => x.CompanyID == companyId && x.ForYear == forYear && x.ReportName == reportName)
                   .Select(x => x.SubaccountID).ToList();

            var subcountIds = entities.DecSubaccounts.
                Where(x => !subIds.Contains(x.SubaccountID) && x.Active == true && x.IsCommercial == true)
                 .OrderBy(x => x.Seq)
                .Select(x => x.SubaccountID)
                .ToList();

            foreach (var subcountId in subcountIds)
            {
                entities.DecSubReports.Add(new DecSubReport
                {
                    ForYear = forYear,
                    CompanyID = companyId,
                    SubaccountID = subcountId,
                    ReportName = reportName,
                    ShowReport = true,
                    CreateDate = DateTime.Now,
                    CreatedBy = SessionUser.UserID
                });
            }

            entities.SaveChanges();
        }
    }

    protected void CompaniesGrid_HtmlRowPrepared(object sender, TreeListHtmlRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("CompanyType"), "K"))
        {
            e.Row.Font.Bold = true;
        }
    }

    protected void SubReportsGrid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("Calculation"), "SUM"))
        {
            e.Row.Font.Bold = true;
        }
    }

    protected bool TryParseKeyValues(IEnumerable<string> stringKeys, out decimal[] resultKeys)
    {
        resultKeys = null;
        var list = new List<decimal>();
        foreach (var sKey in stringKeys)
        {
            decimal key;
            if (!decimal.TryParse(sKey, out key))
                return false;
            list.Add(key);
        }
        resultKeys = list.ToArray();
        return true;
    }



    protected void SubReportsGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal vId = Convert.ToInt32(updValues.Keys["Id"]);
                var entity = entities.DecSubReports.SingleOrDefault(x => x.Id == vId);
                if (entity != null)
                {

                    if (updValues.NewValues["ShowReport"] != null)
                    {
                        var aShowReport = Convert.ToBoolean(updValues.NewValues["ShowReport"]);
                        entity.ShowReport = aShowReport;
                        entity.LastUpdateDate = DateTime.Now;
                        entity.LastUpdatedBy = SessionUser.UserID;

                        entities.SaveChangesWithAuditLogs();
                    }
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            e.Handled = true;
        }
    }

    protected void ShowReportEditor_Init(object sender, EventArgs e)
    {
        ASPxCheckBox chk = sender as ASPxCheckBox;
        GridViewDataItemTemplateContainer container = chk.NamingContainer as GridViewDataItemTemplateContainer;
        if (container.KeyValue != null)
            chk.ClientSideEvents.ValueChanged = String.Format("function(s, e) {{ ClientShowReportEditor_ValueChanged({0}, s.GetChecked());}}", container.KeyValue);

    }

    protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
    {
        string[] args = e.Parameter.Split('|');
        switch (args[0])
        {
            case "ShowReport":
                int key;
                if (!int.TryParse(args[1], out key))
                    return;

                var showReport = args[2];

                var entity = entities.DecSubReports.SingleOrDefault(x => x.Id == key);
                if (entity == null) return;
                entity.ShowReport = Convert.ToBoolean(showReport);

                entity.LastUpdateDate = DateTime.Now;
                entity.LastUpdatedBy = SessionUser.UserID;

                entities.SaveChangesWithAuditLogs();

                e.Result = "OK";
                break;
        }
    }

    protected void ListReportEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DecTableValues
          .Where(x => x.Tables == "KHTCReports" && x.Field == "REPORTS")
          .OrderBy(x => x.Sort)
          .ToList();
        s.DataSource = list;
        s.ValueField = "DefValue";
        s.TextField = "Description";
        s.DataBind();
        if (s.Items.Count > 0)
            s.SelectedItem = s.Items[0];
    }

    protected void CompaniesGrid_DataBound(object sender, EventArgs e)
    {
        SetNodeSelectionSettings();
    }

    void SetNodeSelectionSettings()
    {
        TreeListNodeIterator iterator = CompaniesGrid.CreateNodeIterator();
        TreeListNode node;
        while (true)
        {
            node = iterator.GetNext();
            if (node == null) break;
            node.AllowSelect = !node.HasChildren;
        }
    }


    protected void FromReportEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DecTableValues
          .Where(x => x.Tables == "KHTCReports" && x.Field == "REPORTS")
          .OrderBy(x => x.Sort)
          .ToList();

        ListEditItem le = new ListEditItem();
        le = new ListEditItem();
        le.Value = "ALL";
        le.Text = "---ALL---";
        s.Items.Add(le);

        foreach (var item in list)
        {
            le = new ListEditItem();
            le.Value = item.DefValue;
            le.Text = item.Description;
            s.Items.Add(le);
        }
        if (s.Items.Count > 0)
        {
            s.SelectedItem = s.Items[0];
        }
    }
}