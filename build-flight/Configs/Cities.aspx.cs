using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using KTQTData;

public partial class Pages_Cities : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.mMain.Items.FindByName("New").Visible = IsGranted("Pages.KHTC.Configs.Cities.Create");
        this.mMain.Items.FindByName("Edit").Visible = IsGranted("Pages.KHTC.Configs.Cities.Edit");
        this.mMain.Items.FindByName("Delete").Visible = IsGranted("Pages.KHTC.Configs.Cities.Delete");
        this.mMain.Items.FindByName("SyncData").Visible = IsGranted("Pages.KHTC.Configs.Cities.SyncData");

        if (!IsPostBack || CitiesGrid.IsCallback)
        {
            LoadCities();
        }
    }

    #region Load data
    private void LoadCities()
    {
        var list = entities.Cities.OrderBy(x => x.CityCode).ToList();
        this.CitiesGrid.DataSource = list;
        this.CitiesGrid.DataBind();
    }
    #endregion

    protected void CitiesGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        if (args[0].Equals(Action.REFRESH))
        {
            s.JSProperties["cpResult"] = Action.REFRESH;
            LoadCities();
        }
        else if (args[0].Equals(Action.DELETE))
        {
            s.JSProperties["cpResult"] = Action.DELETE;
            string key = args[1];

            var city = (from x in entities.Cities where x.CityCode == key select x).FirstOrDefault();
            if (city != null)
            {
                entities.Cities.Remove(city);
                entities.SaveChangesWithAuditLogs();
                LoadCities();
            }
        }
        else if (args[0].Equals(Action.SYNC_DATA))
        {
            s.JSProperties["cpResult"] = Action.SYNC_DATA;
            entities.Sync_PMSCity();

            LoadCities();
        }

        else if (args[0].Equals("SaveForm"))
        {
            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];
                    var aCityCode = CityCodeEditor.Text;
                    var aNameE = NameEEditor.Text;
                    var aNameV = NameVEditor.Text;
                    var aCountryCode = CountryCodeEditor.Value != null ? CountryCodeEditor.Value.ToString() : string.Empty;
                    var aActive = ActiveEditor.Checked;

                    if (command.ToUpper() == "EDIT")
                    {
                        string key = args[2];

                        var entity = entities.Cities.Where(x => x.CityCode == key).SingleOrDefault();
                        if (entity != null)
                        {
                            entity.CityCode = aCityCode;
                            entity.NameE = aNameE;
                            entity.NameV = aNameV;
                            entity.CountryCode = aCountryCode;
                            entity.Active = aActive;

                            entity.LastUpdateDate = DateTime.Now;
                            entity.LastUpdatedBy = (int)SessionUser.UserID;
                            entities.SaveChangesWithAuditLogs();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new City();
                        entity.CityCode = aCityCode;
                        entity.NameE = aNameE;
                        entity.NameV = aNameV;
                        entity.CountryCode = aCountryCode;
                        entity.Active = aActive;

                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.Cities.Add(entity);
                        entities.SaveChangesWithAuditLogs();
                    }
                    LoadCities();

                    s.JSProperties["cpResult"] = "Success";
                }
                catch (Exception ex)
                {
                    s.JSProperties["cpResult"] = ex.Message;
                }
            }
        }
    }
    protected void CitiesGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "EditForm" && args.Length == 3)
        {
            string key = args[2];

            var city = entities.Cities.SingleOrDefault(x => x.CityCode == key);
            if (city == null)
                return;

            var result = new Dictionary<string, string>();
            result["CityCode"] = city.CityCode;
            result["NameE"] = city.NameE;
            result["NameV"] = city.NameV;
            result["CountryCode"] = city.CountryCode;
            result["Active"] = (city.Active ?? false) ? "TRUE" : "FALSE";

            e.Result = result;
        }
    }
    protected void CountryCodeEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var countries = entities.Countries.OrderBy(x => x.NameE).ToList();
        s.DataSource = countries;
        s.ValueField = "CountryCode";
        s.TextField = "NameE";
        s.DataBind();
    }
}

