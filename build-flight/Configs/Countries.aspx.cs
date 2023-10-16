using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using KTQTData;

public partial class Pages_Countries : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.mMain.Items.FindByName("New").Visible = IsGranted("Pages.KHTC.Configs.Countries.Create");
        this.mMain.Items.FindByName("Edit").Visible = IsGranted("Pages.KHTC.Configs.Countries.Edit");
        this.mMain.Items.FindByName("Delete").Visible = IsGranted("Pages.KHTC.Configs.Countries.Delete");
        this.mMain.Items.FindByName("SyncData").Visible = IsGranted("Pages.KHTC.Configs.Countries.SyncData");

        if (!IsPostBack || CountriesGrid.IsCallback)
        {
            LoadCountries();
        }
    }

    #region Load data
    private void LoadCountries()
    {
        var list = entities.Countries.OrderBy(x => x.Sort).ToList();
        this.CountriesGrid.DataSource = list;
        this.CountriesGrid.DataBind();
    }
    #endregion

    protected void CountriesGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        if (args[0].Equals(Action.REFRESH))
        {
            s.JSProperties["cpResult"] = Action.REFRESH;
            LoadCountries();
        }
        else if (args[0].Equals(Action.DELETE))
        {
            s.JSProperties["cpResult"] = Action.DELETE;
            string key = args[1];

            var country = (from x in entities.Countries where x.CountryCode == key select x).FirstOrDefault();
            if (country != null)
            {
                entities.Countries.Remove(country);
                entities.SaveChangesWithAuditLogs();
                LoadCountries();
            }
        }
        else if (args[0].Equals(Action.SYNC_DATA))
        {
            s.JSProperties["cpResult"] = Action.SYNC_DATA;
            entities.Sync_PMSCountry();

            LoadCountries();
        }

        else if (args[0].Equals("SaveForm"))
        {
            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];
                    var aCountryCode = CountryCodeEditor.Text;
                    var aNameE = NameEEditor.Text;
                    var aNameV = NameVEditor.Text;
                    var aAreaCode = AreaCodeEditor.Value != null ? AreaCodeEditor.Value.ToString() : string.Empty;
                    var aContinents = ContinentsEditor.Text;
                    var aRegionIATA = RegionIATAEditor.Value != null ? Convert.ToInt32(RegionIATAEditor.Value) : 0;
                    var aVNDestination = VNDestinationEditor.Checked ? 1 : 0;
                    var aCapital = CapitalEditor.Text;
                    var aLanguage = LanguageEditor.Text;
                    var aSort = SortEditor.Value != null ? Convert.ToInt32(SortEditor.Value) : 0;

                    if (command.ToUpper() == "EDIT")
                    {
                        string key = args[2];

                        var entity = entities.Countries.Where(x => x.CountryCode == key).SingleOrDefault();
                        if (entity != null)
                        {
                            entity.CountryCode = aCountryCode;
                            entity.NameE = aNameE;
                            entity.NameV = aNameV;
                            entity.AreaCode = aAreaCode;
                            entity.Continents = aContinents;
                            entity.RegionIATA = aRegionIATA;
                            entity.VNDestination = aVNDestination;
                            entity.Capital = aCapital;
                            entity.Language = aLanguage;
                            entity.Sort = aSort;

                            entity.LastUpdateDate = DateTime.Now;
                            entity.LastUpdatedBy = (int)SessionUser.UserID;
                            entities.SaveChangesWithAuditLogs();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new Country();
                        entity.CountryCode = aCountryCode;
                        entity.NameE = aNameE;
                        entity.NameV = aNameV;
                        entity.AreaCode = aAreaCode;
                        entity.Continents = aContinents;
                        entity.RegionIATA = aRegionIATA;
                        entity.VNDestination = aVNDestination;
                        entity.Capital = aCapital;
                        entity.Language = aLanguage;
                        entity.Sort = aSort;

                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.Countries.Add(entity);
                        entities.SaveChangesWithAuditLogs();
                    }
                    LoadCountries();

                    s.JSProperties["cpResult"] = "Success";
                }
                catch (Exception ex)
                {
                    s.JSProperties["cpResult"] = ex.Message;
                }
            }
        }
    }
    protected void CountriesGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "EditForm" && args.Length == 3)
        {
            string key = args[2];

            var country = entities.Countries.SingleOrDefault(x => x.CountryCode == key);
            if (country == null)
                return;

            var result = new Dictionary<string, string>();
            result["CountryCode"] = country.CountryCode;
            result["NameE"] = country.NameE;
            result["NameV"] = country.NameV;
            result["AreaCode"] = country.AreaCode;

            result["Continents"] = country.Continents;
            result["RegionIATA"] = country.RegionIATA.HasValue ? country.RegionIATA.ToString() : "0";
            result["VNDestination"] = (country.VNDestination ?? 0) == 1 ? "TRUE" : "FALSE";
            result["Capital"] = country.Capital;
            result["Language"] = country.Language;
            result["Sort"] = country.Sort.HasValue ? country.Sort.Value.ToString() : "0";

            e.Result = result;
        }
    }
    protected void AreaCodeEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var areas = entities.Areas.OrderBy(x => x.NameE).ToList();
        s.DataSource = areas;
        s.ValueField = "AreaCode";
        s.TextField = "NameE";
        s.DataBind();
    }
}