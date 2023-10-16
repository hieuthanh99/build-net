using DevExpress.Web;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Business_KTQT_VersionType : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        SetPermistion();
        if (!IsPostBack)
        {
            this.VersionYearEditor.Value = DateTime.Now.Year;
            this.FromMonthEditor.Value = DateTime.Now.Month;
            this.ToMonthEditor.Value = DateTime.Now.Month;

            this.ApplyFromMonthEditor.Value = DateTime.Now.Month;
            this.ApplyToMonthEditor.Value = DateTime.Now.Month;
        }

        if (!IsPostBack || this.VersionGrid.IsCallback)
        {
            if (rdoVersionType.Value != null && this.VersionYearEditor.Value != null)
            {
                string versionType = rdoVersionType.Value.ToString();
                int versionYear = Convert.ToInt32(this.VersionYearEditor.Value);
                this.LoadVersions(versionType, versionYear);
            }
        }

        if (this.VersionCopyGrid.IsCallback)
            this.LoadCopyVersions();


        if (this.PlanVersionGrid.IsCallback)
            this.LoadCopyPlanVersions();
    }
    private void SetPermistion()
    {
        if (!(SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR)))
        {
            //btnSynchronizeFASTData.Visible = (SessionUser.IsInRole(PermissionConstant.SYNC_FAST_DATA));
            btnApprove.Visible = (SessionUser.IsInRole(PermissionConstant.APPROVE_VERSION));
            btnUnApprove.Visible = (SessionUser.IsInRole(PermissionConstant.APPROVE_VERSION));
        }
        else
        {
            //btnSynchronizeFASTData.Visible = true;
            btnApprove.Visible = true;
            btnUnApprove.Visible = true;
        }
    }

    #region Load data
    private decimal GetCallbackKeyValue(string keyStr)
    {
        string result = null;
        if (Utils.TryGetClientStateValue<string>(this, keyStr, out result))
            return Convert.ToDecimal(result);
        return decimal.Zero;
    }
    private void LoadVersions(string versionType, int versionYear)
    {
        var list = entities.Versions.Where(x => x.VersionType == versionType && x.VersionYear == versionYear).OrderByDescending(x => x.VersionYear).OrderBy(x => x.Sorting).ToList();
        this.VersionGrid.DataSource = list;
        this.VersionGrid.DataBind();
    }

    private void LoadCopyVersions()
    {
        var list = entities.Versions.OrderByDescending(x => x.VersionYear).OrderBy(x => x.Sorting).ToList();
        this.VersionCopyGrid.DataSource = list;
        this.VersionCopyGrid.DataBind();
    }

    private void LoadCopyPlanVersions()
    {

        var list = entities.V_QLKH_VERSION.OrderByDescending(x => x.VersionYear).OrderBy(x => x.Sorting).ToList();
        this.PlanVersionGrid.DataSource = list;
        this.PlanVersionGrid.DataBind();

    }
    #endregion
    protected void VersionGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');

        s.JSProperties["cpCommand"] = args[0];

        if (args[0] == "DELETE")
        {
            try
            {
                decimal key;
                if (!decimal.TryParse(args[1], out key)) return;

                var check = entities.VersionCompanies.Where(x => x.VersionID == key).Any();
                if (check)
                {
                    s.JSProperties["cpResult"] = "This version is in use. Unable to delete this version.";
                    return;
                }

                var entity = (from x in entities.Versions where x.VersionID == key select x).FirstOrDefault();
                if (entity != null)
                {
                    entities.Versions.Remove(entity);
                    entities.SaveChanges();

                    if (rdoVersionType.Value != null && this.VersionYearEditor.Value != null)
                    {
                        string versionType = rdoVersionType.Value.ToString();
                        int versionYear = Convert.ToInt32(this.VersionYearEditor.Value);
                        this.LoadVersions(versionType, versionYear);
                    }
                }
                s.JSProperties["cpResult"] = "Success";
            }
            catch (Exception ex)
            {
                s.JSProperties["cpResult"] = ex.Message;
            }
        }

        if (args[0] == "SaveForm")
        {
            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];
                    if (command.ToUpper() == "EDIT")
                    {
                        decimal key;
                        if (!decimal.TryParse(args[2], out key)) return;

                        var entity = entities.Versions.Where(x => x.VersionID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            entity.VersionYear = Convert.ToInt32(YearEditor.Number);
                            entity.VersionType = TypeEditor.Value.ToString();
                            entity.VersionName = NameEditor.Text;
                            entity.VersionQuantityName = VersionEditor.Text;
                            entity.VersionLevel = LevelEditor.Text;
                            entity.Calculation = CalculationEditor.Value.ToString();
                            entity.CPI = CPIEditor.Number;
                            entity.Description = DescriptionEditor.Text;
                            entity.OnTop = Convert.ToInt32(rblActualType.Value);
                            entity.Active = ActiveEditor.Checked;

                            entity.CreateNote = CreateNoteEditor.Text;
                            entities.SaveChanges();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new KTQTData.Version();
                        entity.VersionYear = Convert.ToInt32(YearEditor.Number);
                        entity.VersionType = TypeEditor.Value.ToString();
                        entity.VersionName = NameEditor.Text;
                        entity.VersionQuantityName = VersionEditor.Text;
                        entity.VersionLevel = LevelEditor.Text;
                        entity.Calculation = CalculationEditor.Value.ToString();
                        entity.CPI = CPIEditor.Number;
                        entity.Description = DescriptionEditor.Text;
                        entity.OnTop = Convert.ToInt32(rblActualType.Value);
                        entity.Active = ActiveEditor.Checked;


                        entity.CreatedDate = DateTime.Now;
                        entity.CreateNote = CreateNoteEditor.Text;
                        entity.Creator = (int)SessionUser.UserID;

                        entities.Versions.Add(entity);
                        entities.SaveChanges();
                    }

                    if (rdoVersionType.Value != null && this.VersionYearEditor.Value != null)
                    {
                        string versionType = rdoVersionType.Value.ToString();
                        int versionYear = Convert.ToInt32(this.VersionYearEditor.Value);
                        this.LoadVersions(versionType, versionYear);
                    }

                    s.JSProperties["cpResult"] = "Success";
                }
                catch (Exception ex)
                {
                    s.JSProperties["cpResult"] = ex.Message;
                }
            }
        }
        if (args[0] == "ApplyVersion")
        {
            decimal key;
            if (!decimal.TryParse(args[1], out key)) return;

            var entity = (from x in entities.Versions where x.VersionID == key select x).FirstOrDefault();
            if (entity != null)
            {
                var companieIDs = entities.DecCompanies.Where(x => x.CompanyType == "D").Select(x => x.CompanyID).ToList();
                foreach (int companyID in companieIDs)
                {
                    var check = entities.VersionCompanies.Where(x => x.VersionID == key && x.CompanyID == companyID).Any();
                    if (!check)
                    {
                        try
                        {
                            entities.CreateVersionCompany(entity.VersionID, companyID, SessionUser.UserID);
                        }
                        catch { }
                    }

                }

            }
        }

        if (args[0] == "ApproveUnApproved")
        {
            decimal verID;
            if (!decimal.TryParse(args[1], out verID))
                return;

            var verCompany = entities.Versions.SingleOrDefault(x => x.VersionID == verID);
            if (verCompany != null)
            {
                verCompany.Status = verCompany.Status == "APPROVED" ? "UNAPPROVED" : "APPROVED";
                //verCompany.ApproveStatus = verCompany.ApproveStatus == "APPROVED" ? "UNAPPROVED" : "APPROVED";
                verCompany.ApprovedDate = DateTime.Now;
                verCompany.Approver = SessionUser.UserID;
                verCompany.ApprovedNote = ApproveNoteEditor.Text;

                entities.SaveChanges();

                if (rdoVersionType.Value != null && this.VersionYearEditor.Value != null)
                {
                    string versionType = rdoVersionType.Value.ToString();
                    int versionYear = Convert.ToInt32(this.VersionYearEditor.Value);
                    this.LoadVersions(versionType, versionYear);
                }
            }
        }

        if (args[0] == "SynchronizeFASTData")
        {
            decimal verID;
            int fMonth;
            int tMonth;

            if (!decimal.TryParse(args[1], out verID))
                return;

            if (!int.TryParse(args[2], out fMonth))
                return;

            if (!int.TryParse(args[3], out tMonth))
                return;

            var version = entities.Versions.SingleOrDefault(x => x.VersionID == verID);
            if (version != null)
            {
                string areaCode = string.Empty;
                var curCompany = entities.DecCompanies.SingleOrDefault(x => x.CompanyID == SessionUser.CompanyID);
                if (curCompany != null)
                    areaCode = curCompany.AreaCode;
                for (int i = fMonth; i <= tMonth; i++)
                {
                    entities.SynchronizeFASTData(verID, i, version.VersionYear, areaCode);
                }
            }
        }
    }
    protected void VersionGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "EditForm" && args.Length == 3)
        {
            decimal key;
            if (!decimal.TryParse(args[2], out key))
            {
                e.Result = null;
                return;
            }
            var version = entities.Versions.SingleOrDefault(x => x.VersionID == key);
            if (version == null)
                return;

            var result = new Dictionary<string, string>();
            result["VersionYear"] = (version.VersionYear ?? 0).ToString();
            result["VersionType"] = version.VersionType;
            result["VersionName"] = version.VersionName;
            result["VersionQuantityName"] = version.VersionQuantityName;
            result["VersionLevel"] = version.VersionLevel;
            result["Calculation"] = version.Calculation;
            result["CPI"] = version.CPI.HasValue ? version.CPI.ToString() : "0";
            result["Description"] = version.Description;
            result["OnTop"] = version.OnTop.HasValue ? version.OnTop.Value.ToString() : "0";
            result["CreateNote"] = version.CreateNote;
            result["Active"] = (version.Active ?? false) ? "True" : "False";

            e.Result = result;
        }
    }
    protected void RevCostCallback_Callback(object source, CallbackEventArgs e)
    {
        var args = e.Parameter.Split('|');
        if (args[0] == "CheckVerStatus")
        {
            decimal verID;
            if (!decimal.TryParse(args[1], out verID))
                return;

            var ver = entities.Versions.SingleOrDefault(v => v.VersionID == verID);
            if (ver == null)
            {
                e.Result = "FAIL";
                return;
            }
            e.Result = ver.Status;
        }
    }
    protected void VersionCopyGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');

        if (args[0] == "CopyVersion")
        {
            int srcVerID;
            if (!int.TryParse(args[1], out srcVerID))
                return;

            decimal desVerID;
            if (!decimal.TryParse(args[2], out desVerID))
                return;

            entities.CopyVersion(srcVerID, desVerID, SessionUser.UserID);

        }
    }
    protected void PlanVersionGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');

        if (args[0] == "CopyPlanVersion")
        {
            int srcVerID;
            if (!int.TryParse(args[1], out srcVerID))
                return;

            decimal desVerID;
            if (!decimal.TryParse(args[2], out desVerID))
                return;

            int fromMonth = Convert.ToInt32(ApplyFromMonthEditor.Number);
            int toMonth = Convert.ToInt32(ApplyToMonthEditor.Number);

            entities.CopyVersionDataFromKHNH(srcVerID, desVerID, "T", fromMonth, toMonth, SessionUser.UserID);
            entities.CopyVersionDataFromKHNH(srcVerID, desVerID, "C", fromMonth, toMonth, SessionUser.UserID);
        }
    }
}