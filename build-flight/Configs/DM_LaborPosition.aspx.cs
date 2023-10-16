using DevExpress.Web;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_DM_LaborPosition : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadAreas();

        if (!this.IsCallback || this.NormYearGrid.IsCallback)
            LoadNormYears();

        if (!this.IsCallback || this.GroupGrid.IsCallback)
            LoadDMPositionGroup();

        if (!this.IsCallback || this.PositionGrid.IsCallback)
        {
            var aDMGroupID = this.GetCallbackKeyValue("DMGroupID");
            if (aDMGroupID != null)
                this.LoadDMPosition(aDMGroupID);
        }

        if (!this.IsCallback || this.CompanyGrid.IsCallback)
        {
            var aDMGroupID = this.GetCallbackKeyValue("DMGroupID");
            if (aDMGroupID != null)
                this.LoadCompany(aDMGroupID);
        }

        if (!this.IsCallback || this.CompanyGrid.IsCallback)
        {
            var aDMPositionID = this.GetCallbackKeyValue("DMPositionID");
            if (aDMPositionID != null)
                this.LoadCompany(aDMPositionID);
        }

        if (!this.IsCallback || this.LaborNormGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");
            var aDMPositionID = this.GetCallbackKeyValue("DMPositionID");
            if (aNormYearID != null && aDMPositionID != null)
                this.LoadDMLaborPositionNorm(aNormYearID, aDMPositionID);
        }

        if (!IsPostBack)
            this.GroupGrid.ExpandAll();
    }
    private void LoadNormYears()
    {
        var list = entities.DM_NormYears
            .OrderByDescending(x => x.ForYear)
            .ToList();

        this.NormYearGrid.DataSource = list;
        this.NormYearGrid.DataBind();
    }

    private void LoadDMPositionGroup()
    {
        var list = entities.DM_PositionGroup.ToList();

        this.GroupGrid.DataSource = list;
        this.GroupGrid.DataBind();
    }

    private void LoadDMPosition(int pGroupID)
    {
        var list = entities.DM_LaborPosition.Where(x => x.DMGroupID == pGroupID).OrderBy(x => x.Sip).ToList();

        this.PositionGrid.DataSource = list;
        this.PositionGrid.DataBind();
    }

    private void LoadCompany(int pDMPositionID)
    {
        var list = entities.DM_PositionCompany.Where(x => x.DMPositionID == pDMPositionID).ToList();

        this.CompanyGrid.DataSource = list;
        this.CompanyGrid.DataBind();

    }

    private void LoadDMLaborPositionNorm(int pNormYearID, int pDMPositionID)
    {
        var list = entities.DM_LaborPositionNorms
            .Where(x => x.NormYearID == pNormYearID && x.DMPositionID == pDMPositionID)
            .OrderBy(x => x.Area).ToList();

        this.LaborNormGrid.DataSource = list;
        this.LaborNormGrid.DataBind();
    }



    private int GetCallbackKeyValue(string keyStr)
    {
        string result = null;
        if (Utils.TryGetClientStateValue<string>(this, keyStr, out result))
            return Convert.ToInt32(result);
        return 0;
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

    private string GetPositionName(int pPositionID)
    {
        var aPosition = entities.DecPositions.SingleOrDefault(x => x.PositionID == pPositionID);
        if (aPosition != null)
            return aPosition.PostionName;

        return string.Empty;
    }

    private void LoadAreas()
    {
        GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)LaborNormGrid.Columns["Area"];

        var list = entities.Airports.Where(x => (x.VNDes ?? false) == true).OrderByDescending(x => x.Code).ToList();

        aCombo.PropertiesComboBox.DataSource = list;
        aCombo.PropertiesComboBox.ValueField = "Code";
        aCombo.PropertiesComboBox.TextField = "Code";
    }

    protected void PositionGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        int aGroupID;
        if (args[0] == "LOAD_POSITION")
        {
            if (!int.TryParse(args[1], out aGroupID))
                return;


            //LoadDMPosition(aGroupID);
        }

        if (args[0] == "ADD_POSITION")
        {
            int[] posKeys = null;
            if (!int.TryParse(args[1], out aGroupID))
                return;

            if (!TryParseKeyValues(args.Skip(2), out posKeys))
                return;

            int? maxSip = entities.DM_LaborPosition.Where(x => x.DMGroupID == aGroupID).Select(x => x.Sip).Max();

            foreach (int posKey in posKeys)
            {
                maxSip = ((maxSip ?? 0) + 1);
                string aPositionName = GetPositionName(posKey);
                var entity = new DM_LaborPosition()
                {
                    PositionID = posKey,
                    DMGroupID = aGroupID,
                    PostionName = aPositionName,
                    Sip = maxSip,
                    Inactive = false,
                    CreateDate = DateTime.Now,
                    CreatedBy = (int)SessionUser.UserID
                };

                entities.DM_LaborPosition.Add(entity);
            }
            entities.SaveChanges();

            LoadDMPosition(aGroupID);

        }
    }

    private string GetAreaCode(int pCompanyID)
    {
        var entity = entities.DecCompanies.SingleOrDefault(x => x.CompanyID == pCompanyID);
        if (entity != null)
            return entity.OriArea;

        return string.Empty;
    }
    protected void CompanyGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        int aDMGroupID;
        int aDMPositionID;
        if (args[0] == "LOAD_COMPANY")
        {
            if (!int.TryParse(args[1], out aDMGroupID))
                return;


            //LoadCompany(aGroupID);
        }
        if (args[0] == "ADD_COMPANY")
        {
            int[] companyKeys = null;

            if (!int.TryParse(args[1], out aDMPositionID))
                return;

            if (!TryParseKeyValues(args.Skip(2), out companyKeys))
                return;

            foreach (int companyKey in companyKeys)
            {
                var entity = new DM_PositionCompany()
                {
                    DMPositionID = aDMPositionID,
                    CompanyID = companyKey,
                    Area = GetAreaCode(companyKey),
                    CreateDate = DateTime.Now,
                    CreatedBy = (int)SessionUser.UserID
                };

                entities.DM_PositionCompany.Add(entity);
            }
            entities.SaveChanges();

            LoadCompany(aDMPositionID);
        }

        if (args[0] == "DELETE_COMPANY")
        {
            int key;
            if (!int.TryParse(args[1], out key))
                return;

            var entity = entities.DM_PositionCompany.Where(x => x.PositionCompanyID == key).SingleOrDefault();
            if (entity != null)
            {
                aDMPositionID = entity.DMPositionID;
                entities.DM_PositionCompany.Remove(entity);

                entities.SaveChanges();

                LoadCompany(aDMPositionID);
            }

        }
    }

    private Control LaborNormForm()
    {
        return this.LaborPositionNormAddOrEdit.FindControl("LaborNormForm");
    }

    private object GetEditorValue(string controlName)
    {
        return ((ASPxEditBase)this.LaborNormForm().FindControl(controlName)).Value;
    }

    protected void LaborNormGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;

        var args = e.Parameters.Split('|');
        int aPositionKey;
        int aNormKey;

        if (args[0] == "LOAD_LABOR_NORM")
        {
            //if (!int.TryParse(args[1], out aPositionKey))
            //    return;

            var aDMPositionID = this.GetCallbackKeyValue("DMPositionID");

            var entity = entities.DM_LaborPosition
                .Include("DM_PositionGroup")
                .Where(x => x.DMPositionID == aDMPositionID)
                .SingleOrDefault();

            if (entity != null)
            {
                var aPositionGroupType = entity.DM_PositionGroup.PositionGroupType;

                if (Object.Equals(aPositionGroupType, "DB"))
                {
                    var colShiftNbr = (GridViewDataSpinEditColumn)grid.Columns["ShiftNbr"];
                    colShiftNbr.Visible = true;
                    colShiftNbr.PropertiesSpinEdit.ValidationSettings.ValidateOnLeave = true;
                    colShiftNbr.PropertiesSpinEdit.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None;
                    colShiftNbr.PropertiesSpinEdit.ValidationSettings.RequiredField.IsRequired = true;
                    colShiftNbr.PropertiesSpinEdit.ValidationSettings.RequiredField.ErrorText = "*";

                    var colWorkTotal = (GridViewDataSpinEditColumn)grid.Columns["WorkTotal"];
                    colWorkTotal.Visible = true;
                    colWorkTotal.PropertiesSpinEdit.ValidationSettings.ValidateOnLeave = true;
                    colWorkTotal.PropertiesSpinEdit.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None;
                    colWorkTotal.PropertiesSpinEdit.ValidationSettings.RequiredField.IsRequired = true;
                    colWorkTotal.PropertiesSpinEdit.ValidationSettings.RequiredField.ErrorText = "*";
                }
                else
                {
                    var colShiftNbr = (GridViewDataSpinEditColumn)grid.Columns["ShiftNbr"];
                    colShiftNbr.Visible = false;
                    colShiftNbr.PropertiesSpinEdit.ValidationSettings.RequiredField.IsRequired = false;

                    var colWorkTotal = (GridViewDataSpinEditColumn)grid.Columns["WorkTotal"];
                    colWorkTotal.Visible = false;
                    colWorkTotal.PropertiesSpinEdit.ValidationSettings.RequiredField.IsRequired = false;
                }
            }
        }
        else if (args[0] == "SAVE_LABOR_NORM")
        {
            var aCommand = args[1];

            if (!int.TryParse(args[2], out aPositionKey))
                return;

            var aNormYearID = this.GetCallbackKeyValue("NormYearID");
            var aAreaCode = GetEditorValue("AreaCodeEditor");
            var aPeopleNbr = GetEditorValue("PeopleNbrEditor");
            var aShiftNbr = GetEditorValue("ShiftNbrEditor");
            var aWorkTotal = GetEditorValue("WorkTotalEditor");
            var aDescription = GetEditorValue("DescriptionEditor");
            var aInactive = GetEditorValue("InactiveEditor");

            if (aCommand == "ADD_LABOR_NORM")
            {
                var entity = new DM_LaborPositionNorms();

                entity.DMPositionID = aPositionKey;
                entity.NormYearID = aNormYearID;
                //entity.ForYear = aForYear != null ? Convert.ToInt32(aForYear.ToString()) : DateTime.Now.Year;
                entity.Area = aAreaCode != null ? aAreaCode.ToString() : string.Empty;
                entity.PeopleNbr = Convert.ToInt32(aPeopleNbr);
                entity.ShiftNbr = Convert.ToInt32(aShiftNbr);
                entity.WorkTotal = Convert.ToInt32(aWorkTotal);
                entity.Description = aDescription != null ? aDescription.ToString() : string.Empty;
                entity.Inactive = aInactive != null ? (bool)aInactive : false;

                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;

                entities.DM_LaborPositionNorms.Add(entity);
                entities.SaveChanges();
            }
            else if (aCommand == "EDIT_LABOR_NORM")
            {
                if (!int.TryParse(args[3], out aNormKey))
                    return;

                var entity = entities.DM_LaborPositionNorms.SingleOrDefault(x => x.NormID == aNormKey);
                if (entity != null)
                {
                    //entity.ForYear = aForYear != null ? (int)aForYear : DateTime.Now.Year;
                    entity.Area = aAreaCode != null ? aAreaCode.ToString() : string.Empty;
                    entity.PeopleNbr = (int)aPeopleNbr;
                    entity.ShiftNbr = (int)aShiftNbr;
                    entity.WorkTotal = (int)aWorkTotal;
                    entity.Description = aDescription != null ? aDescription.ToString() : string.Empty;
                    entity.Inactive = aInactive != null ? (bool)aInactive : false;

                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    entities.SaveChanges();
                }
            }

            //Load

            LoadDMLaborPositionNorm(aNormYearID, aPositionKey);
        }
    }
    protected void CompanyGrid_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
    {
        var Grid = (sender as ASPxGridView);
        if (e.Column.FieldName == "CompanyName")
        {
            var entity = Grid.GetRow(e.VisibleIndex) as DM_PositionCompany;
            if (entity == null) return;
            var aCompanyID = entity.CompanyID;
            var aCompany = entities.DecCompanies.Where(x => x.CompanyID == aCompanyID).SingleOrDefault();
            if (aCompany != null)
            {
                e.EncodeHtml = false;
                e.DisplayText = aCompany.NameV;
            }
        }
    }
    protected void LaborNormGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            var aNormYearID = this.GetCallbackKeyValue("NormYearID");
            var aDMPositionID = this.GetCallbackKeyValue("DMPositionID");

            foreach (ASPxDataInsertValues insValues in e.InsertValues)
            {
                var entity = new DM_LaborPositionNorms();
                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;

                entity.NormYearID = aNormYearID;
                entity.DMPositionID = aDMPositionID;


                if (insValues.NewValues["Area"] != null)
                {
                    string aArea = insValues.NewValues["Area"].ToString();
                    entity.Area = aArea;
                }

                if (insValues.NewValues["PeopleNbr"] != null)
                {
                    int aPeopleNbr = Convert.ToInt32(insValues.NewValues["PeopleNbr"]);
                    entity.PeopleNbr = aPeopleNbr;
                }

                if (insValues.NewValues["ShiftNbr"] != null)
                {
                    decimal aShiftNbr = Convert.ToDecimal(insValues.NewValues["ShiftNbr"]);
                    entity.ShiftNbr = aShiftNbr;
                }


                entity.WorkTotal = entity.PeopleNbr * entity.ShiftNbr;


                if (insValues.NewValues["Description"] != null)
                {
                    string aDescription = insValues.NewValues["Description"].ToString();
                    entity.Description = aDescription;
                }

                if (insValues.NewValues["Inactive"] != null)
                {
                    bool aInactive = Convert.ToBoolean(insValues.NewValues["Inactive"]);
                    entity.Inactive = aInactive;
                }

                entities.DM_LaborPositionNorms.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aNormID = Convert.ToDecimal(updValues.Keys["NormID"]);
                var entity = entities.DM_LaborPositionNorms.SingleOrDefault(x => x.NormID == aNormID);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["Area"] != null)
                    {
                        string aArea = updValues.NewValues["Area"].ToString();
                        entity.Area = aArea;
                    }

                    if (updValues.NewValues["PeopleNbr"] != null)
                    {
                        int aPeopleNbr = Convert.ToInt32(updValues.NewValues["PeopleNbr"]);
                        entity.PeopleNbr = aPeopleNbr;
                    }

                    if (updValues.NewValues["ShiftNbr"] != null)
                    {
                        decimal aShiftNbr = Convert.ToDecimal(updValues.NewValues["ShiftNbr"]);
                        entity.ShiftNbr = aShiftNbr;
                    }


                    entity.WorkTotal = entity.PeopleNbr * entity.ShiftNbr;


                    if (updValues.NewValues["Description"] != null)
                    {
                        string aDescription = updValues.NewValues["Description"].ToString();
                        entity.Description = aDescription;
                    }

                    if (updValues.NewValues["Inactive"] != null)
                    {
                        bool aInactive = Convert.ToBoolean(updValues.NewValues["Inactive"]);
                        entity.Inactive = aInactive;
                    }

                }
            }
            entities.SaveChanges();

            if (aNormYearID != null && aDMPositionID != null)
                this.LoadDMLaborPositionNorm(aNormYearID, aDMPositionID);
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
}