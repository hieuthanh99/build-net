using DevExpress.Web;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;


public partial class Pages_Aircraft : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.mMain.Items.FindByName("New").Visible = IsGranted("Pages.KHTC.Configs.Aircraft.Create");
        this.mMain.Items.FindByName("Edit").Visible = IsGranted("Pages.KHTC.Configs.Aircraft.Edit");
        this.mMain.Items.FindByName("Delete").Visible = IsGranted("Pages.KHTC.Configs.Aircraft.Delete");
        this.mMain.Items.FindByName("SyncData").Visible = IsGranted("Pages.KHTC.Configs.Aircraft.SyncData");

        if (!IsPostBack || DataGrid.IsCallback)
        {
            LoadAircafts();
        }
    }

    #region Load data
    private void LoadAircafts()
    {
        var list = entities.Aircraft.OrderBy(x => x.ACID).ToList();
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
            LoadAircafts();
        }
        else if (args[0].Equals(Action.DELETE))
        {
            s.JSProperties["cpResult"] = Action.DELETE;
            string key = args[1];

            var entity = (from x in entities.Aircraft where x.ACID == key select x).FirstOrDefault();
            if (entity != null)
            {
                entities.Aircraft.Remove(entity);
                entities.SaveChangesWithAuditLogs();
                LoadAircafts();
            }
        }
        else if (args[0].Equals(Action.SYNC_DATA))
        {
            s.JSProperties["cpResult"] = Action.SYNC_DATA;
            entities.Sync_PMSAircraft();

            LoadAircafts();
        }

        else if (args[0].Equals("SaveForm"))
        {
            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];
                    var aACID = ACIDEditor.Text;
                    var aMZFW = MZFWEditor.Number;
                    var aPayload = PayloadEditor.Number;
                    var aMLW = MLWEditor.Number;
                    var aMTOW = MTOWEditor.Number;
                    var aF = FEditor.Number;
                    var aC = CEditor.Number;
                    var aZ = Zditor.Number;
                    var aY = YEditor.Number;
                    var aAFT = AFTEditor.Number;
                    var aFuelFH = FuelFHEditor.Number;
                    var aFuelBH = FuelBHEditor.Number;
                    var aAvgSpeedKM = AvgSpeedKMEditor.Number;
                    var aPilots = PilotsEditor.Number;
                    var aCabinCrew = CabinCrewEditor.Number;
                    var aSeat = SeatEditor.Number;
                    var aConvertTo321 = ConvertTo321Editor.Number;
                    var aFuelULBH = FuelULBHEditor.Number;
                    var aOilBH = OilBHEditor.Number;
                    var aAPUBurn = APUBurnEditor.Number;
                    var aTAXIBurn = TAXIBurnEditor.Number;
                    var aACGroup = ACGroupEditor.Text;
                    var aActive = ActiveEditor.Checked;
                    var aNote = NoteEditor.Text;

                    if (command.ToUpper() == "EDIT")
                    {
                        string key = args[2];

                        var entity = entities.Aircraft.Where(x => x.ACID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            entity.MZFW = aMZFW;
                            entity.Payload = aPayload;
                            entity.MLW = aMLW;
                            entity.MTOW = aMTOW;
                            entity.F = aF;
                            entity.C = aC;
                            entity.Z = aZ;
                            entity.Y = aY;
                            entity.AFT = aAFT;
                            entity.FuelFH = aFuelFH;
                            entity.FuelBH = aFuelBH;
                            entity.AvgSpeedKM = aAvgSpeedKM;
                            entity.Pilots = aPilots;
                            entity.CabinCrew = aCabinCrew;
                            entity.Seat = aSeat;
                            entity.ConvertTo321 = aConvertTo321;
                            entity.FuelULBH = aFuelULBH;
                            entity.OilBH = aOilBH;
                            entity.APUBurn = aAPUBurn;
                            entity.TAXIBurn = aTAXIBurn;
                            entity.ACGroup = aACGroup;
                            entity.Active = aActive;
                            entity.Note = aNote;

                            entity.LastUpdateDate = DateTime.Now;
                            entity.LastUpdatedBy = (int)SessionUser.UserID;
                            entities.SaveChangesWithAuditLogs();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new Aircraft();
                        entity.ACID = aACID;
                        entity.MZFW = aMZFW;
                        entity.Payload = aPayload;
                        entity.MLW = aMLW;
                        entity.MTOW = aMTOW;
                        entity.F = aF;
                        entity.C = aC;
                        entity.Z = aZ;
                        entity.Y = aY;
                        entity.AFT = aAFT;
                        entity.FuelFH = aFuelFH;
                        entity.FuelBH = aFuelBH;
                        entity.AvgSpeedKM = aAvgSpeedKM;
                        entity.Pilots = aPilots;
                        entity.CabinCrew = aCabinCrew;
                        entity.Seat = aSeat;
                        entity.ConvertTo321 = aConvertTo321;
                        entity.FuelULBH = aFuelULBH;
                        entity.OilBH = aOilBH;
                        entity.APUBurn = aAPUBurn;
                        entity.TAXIBurn = aTAXIBurn;
                        entity.ACGroup = aACGroup;
                        entity.Active = aActive;
                        entity.Note = aNote;

                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.Aircraft.Add(entity);
                        entities.SaveChangesWithAuditLogs();
                    }
                    LoadAircafts();

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

            var area = entities.Aircraft.SingleOrDefault(x => x.ACID == key);
            if (area == null)
                return;

            var result = new Dictionary<string, string>();
            result["ACID"] = area.ACID;
            result["MZFW"] = (area.MZFW ?? decimal.Zero).ToString();
            result["Payload"] = (area.Payload ?? decimal.Zero).ToString();
            result["MLW"] = (area.MLW ?? decimal.Zero).ToString();
            result["MTOW"] = (area.MTOW ?? decimal.Zero).ToString();
            result["F"] = (area.F ?? decimal.Zero).ToString();
            result["C"] = (area.C ?? decimal.Zero).ToString();
            result["Z"] = (area.Z ?? decimal.Zero).ToString();
            result["Y"] = (area.Y ?? decimal.Zero).ToString();
            result["AFT"] = (area.AFT ?? decimal.Zero).ToString();
            result["FuelFH"] = (area.FuelFH ?? decimal.Zero).ToString();
            result["FuelBH"] = (area.FuelBH ?? decimal.Zero).ToString();
            result["AvgSpeedKM"] = (area.AvgSpeedKM ?? decimal.Zero).ToString();
            result["Pilots"] = (area.Pilots ?? decimal.Zero).ToString();
            result["CabinCrew"] = (area.CabinCrew ?? decimal.Zero).ToString();
            result["Seat"] = (area.Seat ?? decimal.Zero).ToString();
            result["ConvertTo321"] = (area.ConvertTo321 ?? decimal.Zero).ToString();
            result["FuelULBH"] = (area.FuelULBH ?? decimal.Zero).ToString();
            result["OilBH"] = (area.OilBH ?? decimal.Zero).ToString();
            result["APUBurn"] = (area.APUBurn ?? decimal.Zero).ToString();
            result["TAXIBurn"] = (area.TAXIBurn ?? decimal.Zero).ToString();
            result["ACGroup"] = area.ACGroup;
            result["Active"] = (area.Active ?? false) ? "True" : "False";
            result["Note"] = area.Note;

            e.Result = result;
        }
    }
}