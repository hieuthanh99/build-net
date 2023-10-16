using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using KTQTData;

public partial class Pages_Airport : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.mMain.Items.FindByName("New").Visible = IsGranted("Pages.KHTC.Configs.Airport.Create");
        this.mMain.Items.FindByName("Edit").Visible = IsGranted("Pages.KHTC.Configs.Airport.Edit");
        this.mMain.Items.FindByName("Delete").Visible = IsGranted("Pages.KHTC.Configs.Airport.Delete");
        this.mMain.Items.FindByName("SyncData").Visible = IsGranted("Pages.KHTC.Configs.Airport.SyncData");

        if (!IsPostBack || DataGrid.IsCallback)
        {
            LoadAirports();
        }
    }

    #region Load data
    private void LoadAirports()
    {
        var list = entities.AIRPORTS1.OrderBy(x => x.CODE).ToList();
        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }
    #endregion
    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        if (args[0].Equals(Action.REFRESH))
        {
            s.JSProperties["cpResult"] = Action.REFRESH;
            LoadAirports();
        }
        else if (args[0].Equals(Action.DELETE))
        {
            s.JSProperties["cpResult"] = Action.DELETE;
            string key = args[1];

            var area = (from x in entities.AIRPORTS1 where x.CODE == key select x).FirstOrDefault();
            if (area != null)
            {
                entities.AIRPORTS1.Remove(area);
                entities.SaveChangesWithAuditLogs();
                LoadAirports();
            }
        }
        else if (args[0].Equals(Action.SYNC_DATA))
        {
            s.JSProperties["cpResult"] = Action.SYNC_DATA;
            entities.Sync_PMSAirports();

            LoadAirports();
        }

        else if (args[0].Equals("SaveForm"))
        {
            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];
                    var vCode = CodeEditor.Text;
                    var vNameV = NameVEditor.Text;
                    var vNameE = NameEEditor.Text;
                    var vVNDestination = VNDestinationEditor.Checked;
                    var vUTCSummer = UTCSummerEditor.Number;
                    var vUTCWinter = UTCWinterEditor.Number;
                    var vCity = CityEditor.Value;
                    var vCountry = CountryCodeEditor.Value;
                    var vIsCity = IsCityEditor.Checked;

                    if (command.ToUpper() == "EDIT")
                    {
                        string key = args[2];

                        var entity = entities.AIRPORTS1.Where(x => x.CODE == key).SingleOrDefault();
                        if (entity != null)
                        {
                            entity.CODE = vCode;
                            entity.NAME_VN = vNameV;
                            entity.NAME_E = vNameE;
                            entity.VN_DES = vVNDestination ? 1 : 0;
                            entity.UTC_SUMMER = (int?)vUTCSummer;
                            entity.UTC_WINTER = (int?)vUTCWinter;
                            entity.CITY = vCity != null ? vCity.ToString() : string.Empty;
                            entity.COUNTRY = vCountry != null ? vCountry.ToString() : string.Empty;
                            entity.IS_CITY = vIsCity ? 1 : 0;

                            entity.UPDATED_DATE = DateTime.Now;
                            entity.UPDATED_BY = SessionUser.UserName;
                            entities.SaveChangesWithAuditLogs();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new AIRPORT1();
                        entity.CODE = vCode;
                        entity.NAME_VN = vNameV;
                        entity.NAME_E = vNameE;
                        entity.VN_DES = vVNDestination ? 1 : 0;
                        entity.UTC_SUMMER = (int?)vUTCSummer;
                        entity.UTC_WINTER = (int?)vUTCWinter;
                        entity.CITY = vCity != null ? vCity.ToString() : string.Empty;
                        entity.COUNTRY = vCountry != null ? vCountry.ToString() : string.Empty;
                        entity.IS_CITY = vIsCity ? 1 : 0;

                        entity.CREATED_DATE = DateTime.Now;
                        entity.CREATED_BY = SessionUser.UserName;

                        entities.AIRPORTS1.Add(entity);
                        entities.SaveChangesWithAuditLogs();
                    }
                    LoadAirports();

                    s.JSProperties["cpResult"] = "Success";
                }
                catch (Exception ex)
                {
                    s.JSProperties["cpResult"] = ex.Message;
                }
            }
        }
    }
    protected void DataGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "EditForm" && args.Length == 3)
        {
            string key = args[2];

            var area = entities.AIRPORTS1.SingleOrDefault(x => x.CODE == key);
            if (area == null)
                return;

            var result = new Dictionary<string, string>();
            result["Code"] = area.CODE;
            result["NameV"] = area.NAME_VN;
            result["NameE"] = area.NAME_E;
            result["VNDestination"] = area.VN_DES == 1 ? "True" : "False";
            result["UTCSummer"] = (area.UTC_SUMMER ?? decimal.Zero).ToString();
            result["UTCWinter"] = (area.UTC_WINTER ?? decimal.Zero).ToString();
            result["City"] = area.CITY;
            result["CountryCode"] = area.COUNTRY;
            result["IsCity"] = area.IS_CITY == 1 ? "True" : "False";

            e.Result = result;
        }
    }
    protected void CountryCodeEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var countries = entities.Countries.ToList();
        s.DataSource = countries;
        s.ValueField = "CountryCode";
        s.TextField = "NameE";
        s.DataBind();

    }
    protected void CityEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var cities = entities.Cities.ToList();
        s.DataSource = cities;
        s.ValueField = "CityCode";
        s.TextField = "NameE";
        s.DataBind();

    }
    protected void CityEditor_Callback(object sender, CallbackEventArgsBase e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        s.Items.Clear();
        var countryCode = e.Parameter;
        if (!StringUtils.isEmpty(countryCode))
        {
            var cities = entities.Cities.Where(x => x.CountryCode == countryCode).ToList();
            s.DataSource = cities;
            s.ValueField = "CityCode";
            s.TextField = "NameE";
            s.DataBind();
        }
    }
}