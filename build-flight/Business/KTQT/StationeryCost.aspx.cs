using DevExpress.Web;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Business_KTQT_StationeryCost : BasePageNotCheckURL
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCompany(cboAreaCode.Value == null ? "ALL" : cboAreaCode.Value.ToString());

            if (cboCompany.Items.Count > 0)
                cboCompany.SelectedItem = cboCompany.Items[0];
        }

        this.PositionGrid.GroupBy(this.PositionGrid.Columns["PositionTypeID"]);
        if (!IsPostBack || this.PositionGrid.IsCallback)
        {
            decimal aVersionID = cboVersion.Value == null ? 0 : Convert.ToDecimal(cboVersion.Value);
            int aCompanyID = cboCompany.Value == null ? 0 : Convert.ToInt32(cboCompany.Value);
            var aNormYearID = cboNormYear.Value == null ? 0 : Convert.ToInt32(cboNormYear.Value);

            LoadPositionStationeryCost(aVersionID, aCompanyID, aNormYearID);
        }
        if (!IsPostBack || this.CommonGrid.IsCallback)
        {
            decimal aVersionID = cboVersion.Value == null ? 0 : Convert.ToDecimal(cboVersion.Value);
            int aCompanyID = cboCompany.Value == null ? 0 : Convert.ToInt32(cboCompany.Value);
            var aNormYearID = cboNormYear.Value == null ? 0 : Convert.ToInt32(cboNormYear.Value);

            LoadCommonStationeryCost(aVersionID, aCompanyID, aNormYearID);
        }
        this.PositionGrid.ExpandAll();
    }

    private void LoadCompany(string pAreaCode)
    {
        var list = entities.DecCompanies
            .Where(x => (x.OriArea == pAreaCode || pAreaCode == "ALL") && x.CompanyType == "D" && x.IsExternalCost == false && x.IsOnBehalfOf == "NO" && x.Active == true)
            .Select(x => new
            {
                CompanyID = x.CompanyID,
                OriArea = x.OriArea,
                NameV = x.OriArea + "-" + x.NameV
            })
            .OrderBy(x => x.OriArea)
            .ToList();
        cboCompany.DataSource = list;
        cboCompany.ValueField = "CompanyID";
        cboCompany.TextField = "NameV";
        cboCompany.DataBind();
    }
    private void LoadPositionStationeryCost(decimal pVersionID, int pCompanyID, int pNormYearID)
    {
        var list = (from x in entities.DM_StationeryCost
                    join y in entities.DecStationeries on x.StationeryID equals y.StationeryID
                    where x.VersionID == pVersionID && x.NormYearID == pNormYearID && y.StationeryType == "CD" && x.CompanyID == pCompanyID
                    select x).ToList(); ;
        this.PositionGrid.DataSource = list;
        this.PositionGrid.DataBind();
    }

    private void LoadCommonStationeryCost(decimal pVersionID, int pCompanyID, int pNormYearID)
    {
        var list = (from x in entities.DM_StationeryCost
                    join y in entities.DecStationeries on x.StationeryID equals y.StationeryID
                    where x.VersionID == pVersionID && x.NormYearID == pNormYearID && y.StationeryType == "DC" && x.CompanyID == pCompanyID
                    select x).ToList(); ;
        this.CommonGrid.DataSource = list;
        this.CommonGrid.DataBind();
    }

    protected void Grid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {

    }
    protected void cboAreaCode_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Airports.Where(x => x.Code != "CTY").ToList();

        ListEditItem le = new ListEditItem();
        le.Value = "ALL";
        le.Text = "--ALL--";
        s.Items.Add(le);
        foreach (var item in list)
        {
            le = new ListEditItem();
            le.Value = item.Code;
            le.Text = item.NameE;
            s.Items.Add(le);
        }

        if (s.Items.Count > 0)
            s.Value = SessionUser.AreaCode != "KCQ" ? SessionUser.AreaCode : "ALL";
    }
    protected void cboVersion_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        if (Session[SessionConstant.VERSION_LIST] != null)
        {
            s.DataSource = (List<KTQTData.Version>)Session[SessionConstant.VERSION_LIST];
            s.ValueField = "VersionID";
            s.TextField = "Description";
            s.DataBind();
        }
        else
        {
            using (APPData.QLKHAppEntities context = new APPData.QLKHAppEntities())
            {
                var param = context.SystemParas.Where(x => x.SysCode == "EST_YEAR").SingleOrDefault();

                var year = Convert.ToInt32(StringUtils.isEmpty(param.SysValue) ? DateTime.Now.Year.ToString() : param.SysValue);

                var list = entities.Versions
                    .Where(x => x.VersionYear == year && (x.Active ?? false) == true)
                    .OrderBy(x => x.VersionType).ToList();

                Session[SessionConstant.VERSION_LIST] = list;

                s.DataSource = list;
                s.ValueField = "VersionID";
                s.TextField = "Description";
                s.DataBind();
            }
        }

        if (s.Value == null && s.Items.Count > 0)
            s.SelectedItem = s.Items[0];
    }
    protected void Grid_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
    {
        var Grid = (sender as ASPxGridView);
        if (e.Column.FieldName == "CompanyName")
        {
            var entity = Grid.GetRow(e.VisibleIndex) as DM_StationeryCost;
            if (entity == null) return;
            var aCompanyID = entity.CompanyID;
            var aCompany = entities.DecCompanies.Where(x => x.CompanyID == aCompanyID).SingleOrDefault();
            if (aCompany != null)
            {
                e.EncodeHtml = false;
                e.DisplayText = aCompany.NameV;
            }
        }

        if (e.Column.FieldName == "StationeryName")
        {
            var entity = Grid.GetRow(e.VisibleIndex) as DM_StationeryCost;
            if (entity == null) return;
            var aStationeryID = entity.StationeryID;
            var aStationery = entities.DecStationeries.Where(x => x.StationeryID == aStationeryID).SingleOrDefault();
            if (aStationery != null)
            {
                e.EncodeHtml = false;
                e.DisplayText = aStationery.StationeryName;
            }
        }

        if (e.Column.FieldName == "PositionTypeID")
        {
            var entity = Grid.GetRow(e.VisibleIndex) as DM_StationeryCost;
            if (entity == null) return;
            var aPositionTypeID = entity.PositionTypeID;
            var aPositionType = entities.DecPositionTypes.Where(x => x.PositionTypeID == aPositionTypeID).SingleOrDefault();
            if (aPositionType != null)
            {
                e.EncodeHtml = false;
                e.DisplayText = aPositionType.PositionTypeName;
            }
        }
    }
    protected void CommonGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {

    }

    protected void cboCompany_Callback(object sender, CallbackEventArgsBase e)
    {
        var aAreaCode = e.Parameter;

        LoadCompany(aAreaCode);

        if (cboCompany.Items.Count > 0)
            cboCompany.SelectedItem = cboCompany.Items[0];
    }
    protected void CalcStationeryCallback_Callback(object source, CallbackEventArgs e)
    {
        var args = e.Parameter.Split('|');

        try
        {
            if (args[0] == "CALC_STATIONERY_COST")
            {
                var aAreaCode = cboAreaCode.Value.ToString();
                var aVersionID = Convert.ToDecimal(cboVersion.Value);
                var aNormYearID = Convert.ToInt32(cboNormYear.Value);
                //var aVersionYear = entities.Versions.SingleOrDefault(x => x.VersionID == aVersionID).VersionYear;

                entities.PrcStationeryCost(aVersionID, aAreaCode, aNormYearID, SessionUser.UserID);
            }
            e.Result = "Success";
        }
        catch (Exception ex)
        {
            e.Result = ex.Message;
        }
    }
    protected void cboNormYear_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        if (Session[SessionConstant.NORMYEAR_LIST] != null)
        {
            s.DataSource = (List<KTQTData.DM_NormYears>)Session[SessionConstant.NORMYEAR_LIST];
            s.ValueField = "NormYearID";
            s.TextField = "Description";
            s.DataBind();
        }
        else
        {

            var list = entities.DM_NormYears
                .OrderByDescending(x => x.ForYear).ToList();

            Session[SessionConstant.NORMYEAR_LIST] = list;

            s.DataSource = list;
            s.ValueField = "NormYearID";
            s.TextField = "Description";
            s.DataBind();

        }

        if (s.Value == null && s.Items.Count > 0)
            s.SelectedItem = s.Items[0];
    }
}