using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using KTQTData;

public partial class Pages_Carriers : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.mMain.Items.FindByName("New").Visible = IsGranted("Pages.KHTC.Configs.Carriers.Create");
        this.mMain.Items.FindByName("Edit").Visible = IsGranted("Pages.KHTC.Configs.Carriers.Edit");
        this.mMain.Items.FindByName("Delete").Visible = IsGranted("Pages.KHTC.Configs.Carriers.Delete");
       
        if (!IsPostBack || CarriersGrid.IsCallback)
        {
            LoadCarriers();
        }
    }

    #region Load data
    private void LoadCarriers()
    {
        var list = entities.Carriers.OrderBy(x => x.NumberCode).ToList();
        this.CarriersGrid.DataSource = list;
        this.CarriersGrid.DataBind();
    }
    #endregion

    protected void CarriersGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        if (args[0].Equals(Action.REFRESH))
        {
            s.JSProperties["cpResult"] = Action.REFRESH;
            LoadCarriers();
        }
        else if (args[0].Equals(Action.DELETE))
        {
            s.JSProperties["cpResult"] = Action.DELETE;
            decimal key;
            if (!decimal.TryParse(args[1], out key))
                return;

            var area = (from x in entities.Carriers where x.CarrierID == key select x).FirstOrDefault();
            if (area != null)
            {
                entities.Carriers.Remove(area);
                entities.SaveChangesWithAuditLogs();
                LoadCarriers();
            }
        }

        else if (args[0].Equals("SaveForm"))
        {
            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];
                    var aNumberCode = NumberCodeEditor.Text;
                    var aIATACode = IATACodeEditor.Text;
                    var aICAOCode = ICAOCodeEditor.Text;
                    var aName = NameEditor.Text;
                    DateTime? NullDate = null;
                    var aValidFrom = ValidFromEditor.Value != null ? ValidFromEditor.Date : NullDate;
                    var aExpireDate = ExpiryDateEditor.Value != null ? ExpiryDateEditor.Date : NullDate;
                    var aCountry = CountryEditor.Value != null ? CountryEditor.Value.ToString() : string.Empty;
                    var aVNAgreement = VNAgreementEditor.Text;
                    var aNote = NoteEditor.Text;

                    if (command.ToUpper() == "EDIT")
                    {
                        decimal key;
                        if (!decimal.TryParse(args[2], out key))
                            return;

                        var entity = entities.Carriers.Where(x => x.CarrierID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            entity.NumberCode = aNumberCode;
                            entity.IATACode = aIATACode;
                            entity.ICAOCode = aICAOCode;
                            entity.Name = aName;
                            entity.ValidFrom = aValidFrom;
                            entity.ExpireDate = aExpireDate;
                            entity.Country = aCountry;
                            entity.VNAgreement = aVNAgreement;
                            entity.Note = aNote;

                            entity.LastUpdateDate = DateTime.Now;
                            entity.LastUpdatedBy = (int)SessionUser.UserID;
                            entities.SaveChangesWithAuditLogs();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new Carrier();
                        entity.NumberCode = aNumberCode;
                        entity.IATACode = aIATACode;
                        entity.ICAOCode = aICAOCode;
                        entity.Name = aName;
                        entity.ValidFrom = aValidFrom;
                        entity.ExpireDate = aExpireDate;
                        entity.Country = aCountry;
                        entity.VNAgreement = aVNAgreement;
                        entity.Note = aNote;

                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.Carriers.Add(entity);
                        entities.SaveChangesWithAuditLogs();
                    }
                    LoadCarriers();

                    s.JSProperties["cpResult"] = "Success";
                }
                catch (Exception ex)
                {
                    s.JSProperties["cpResult"] = ex.Message;
                }
            }
        }
    }
    protected void CarriersGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "EditForm" && args.Length == 3)
        {
            decimal key;
            if (!decimal.TryParse(args[2], out key))
                return;

            var carrier = entities.Carriers.SingleOrDefault(x => x.CarrierID == key);
            if (carrier == null)
                return;

            var result = new Dictionary<string, string>();
            result["NumberCode"] = carrier.NumberCode;
            result["IATACode"] = carrier.IATACode;
            result["ICAOCode"] = carrier.ICAOCode;
            result["Name"] = carrier.Name;
            result["ValidFrom"] = carrier.ValidFrom.HasValue ? carrier.ValidFrom.Value.ToString("yyyy-MM-dd") : "";
            result["ExpireDate"] = carrier.ExpireDate.HasValue ? carrier.ExpireDate.Value.ToString("yyyy-MM-dd") : "";
            result["VNAgreement"] = carrier.VNAgreement;
            result["Country"] = carrier.Country;
            result["Note"] = carrier.Note;

            e.Result = result;
        }
    }
    protected void CountryEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var countries = entities.Countries.OrderBy(x => x.NameE).ToList();
        s.DataSource = countries;
        s.ValueField = "CountryCode";
        s.TextField = "NameE";
        s.DataBind();
    }
}