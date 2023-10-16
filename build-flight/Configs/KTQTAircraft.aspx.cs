using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using KTQTData;

public partial class Pages_KTQTAircraft : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.mMain.Items.FindByName("New").Visible = IsGranted("Pages.KHTC.Configs.KTQTAircraft.Create");
        this.mMain.Items.FindByName("Edit").Visible = IsGranted("Pages.KHTC.Configs.KTQTAircraft.Edit");
        this.mMain.Items.FindByName("Delete").Visible = IsGranted("Pages.KHTC.Configs.KTQTAircraft.Delete");
        this.mMain.Items.FindByName("SyncData").Visible = IsGranted("Pages.KHTC.Configs.KTQTAircraft.SyncData");

        LoadAircafts();

    }

    #region Load data
    private void LoadAircafts()
    {
        var list = entities.DecAircrafts.OrderBy(x => x.Aircraft).ThenBy(x => x.Aircraft_Iata).ToList();
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
            int key;
            if (!int.TryParse(args[1], out key)) return;

            var entity = (from x in entities.DecAircrafts where x.AircraftID == key select x).FirstOrDefault();
            if (entity != null)
            {
                entities.DecAircrafts.Remove(entity);
                entities.SaveChanges();
                LoadAircafts();
            }
        }
        else if (args[0].Equals(Action.SYNC_DATA))
        {
            s.JSProperties["cpResult"] = Action.SYNC_DATA;
            entities.Sync_PMSAircraft();

            LoadAircafts();
        }
        else if (args[0].Equals("SyncVMS"))
        {
            entities.Sync_DM_Aircraft();
            entities.SaveChanges();
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
                    var aAircraftIata = AircraftIataEditor.Text;
                    var aAircraftVN = AircraftVNEditor.Text;
                    var aAircraftName = AircraftNameEditor.Text;
                    var aMTOWMin = MTOWMinEditor.Number;
                    var aMTOWMax = MTOWMaxEditor.Number;
                    var aCarrier = CarrierEditor.Text;
                    var aPaxMin = PaxMinEditor.Number;
                    var aPaxMax = PaxMaxEditor.Number;
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
                        int key;
                        if (!int.TryParse(args[2], out key)) return;

                        var entity = entities.DecAircrafts.Where(x => x.AircraftID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            entity.Aircraft = aACID;
                            entity.Aircraft_Iata = aAircraftIata;
                            entity.Aircraft_VN = aAircraftVN;
                            entity.AircraftName = aAircraftName;
                            entity.MTOW_Min = (int)aMTOWMin;
                            entity.MTOW_Max = (int)aMTOWMax;
                            entity.Carrier = aCarrier;
                            entity.Pax_Min = (int)aPaxMin;
                            entity.Pax_Max = (int)aPaxMax;
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
                            entities.SaveChanges();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new DecAircraft();
                        entity.Aircraft = aACID;
                        entity.Aircraft_Iata = aAircraftIata;
                        entity.Aircraft_VN = aAircraftVN;
                        entity.AircraftName = aAircraftName;
                        entity.MTOW_Min = (int)aMTOWMin;
                        entity.MTOW_Max = (int)aMTOWMax;
                        entity.Carrier = aCarrier;
                        entity.Pax_Min = (int)aPaxMin;
                        entity.Pax_Max = (int)aPaxMax;
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

                        entities.DecAircrafts.Add(entity);
                        entities.SaveChanges();
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
            int key;
            if (!int.TryParse(args[2], out key)) return;

            var aircraft = entities.DecAircrafts.SingleOrDefault(x => x.AircraftID == key);
            if (aircraft == null)
                return;

            var result = new Dictionary<string, string>();
            result["Aircraft"] = aircraft.Aircraft;
            result["Aircraft_Iata"] = aircraft.Aircraft_Iata;
            result["Aircraft_VN"] = aircraft.Aircraft_VN;
            result["AircraftName"] = aircraft.AircraftName;
            result["MTOW_Min"] = (aircraft.MTOW_Min ?? 0).ToString();
            result["MTOW_Max"] = (aircraft.MTOW_Max ?? 0).ToString();
            result["Carrier"] = aircraft.Carrier;
            result["Pax_Min"] = (aircraft.Pax_Min ?? 0).ToString();
            result["Pax_Max"] = (aircraft.Pax_Max ?? 0).ToString();
            result["MZFW"] = (aircraft.MZFW ?? decimal.Zero).ToString();
            result["Payload"] = (aircraft.Payload ?? decimal.Zero).ToString();
            result["MLW"] = (aircraft.MLW ?? decimal.Zero).ToString();
            result["MTOW"] = (aircraft.MTOW ?? decimal.Zero).ToString();
            result["F"] = (aircraft.F ?? decimal.Zero).ToString();
            result["C"] = (aircraft.C ?? decimal.Zero).ToString();
            result["Z"] = (aircraft.Z ?? decimal.Zero).ToString();
            result["Y"] = (aircraft.Y ?? decimal.Zero).ToString();
            result["AFT"] = (aircraft.AFT ?? decimal.Zero).ToString();
            result["FuelFH"] = (aircraft.FuelFH ?? decimal.Zero).ToString();
            result["FuelBH"] = (aircraft.FuelBH ?? decimal.Zero).ToString();
            result["AvgSpeedKM"] = (aircraft.AvgSpeedKM ?? decimal.Zero).ToString();
            result["Pilots"] = (aircraft.Pilots ?? decimal.Zero).ToString();
            result["CabinCrew"] = (aircraft.CabinCrew ?? decimal.Zero).ToString();
            result["Seat"] = (aircraft.Seat ?? decimal.Zero).ToString();
            result["ConvertTo321"] = (aircraft.ConvertTo321 ?? decimal.Zero).ToString();
            result["FuelULBH"] = (aircraft.FuelULBH ?? decimal.Zero).ToString();
            result["OilBH"] = (aircraft.OilBH ?? decimal.Zero).ToString();
            result["APUBurn"] = (aircraft.APUBurn ?? decimal.Zero).ToString();
            result["TAXIBurn"] = (aircraft.TAXIBurn ?? decimal.Zero).ToString();
            result["ACGroup"] = aircraft.ACGroup;
            result["Active"] = (aircraft.Active ?? false) ? "True" : "False";
            result["Note"] = aircraft.Note;

            e.Result = result;
        }
    }
    protected void mMain_ItemClick(object source, MenuItemEventArgs e)
    {
        switch (e.Item.Name.ToUpper())
        {
            case "PDF":
                GridViewExporter.Landscape = true;
                GridViewExporter.WritePdfToResponse();
                break;
            case "XLS":
                GridViewExporter.WriteXlsToResponse();
                break;
            case "XLSX":
                DevExpress.XtraPrinting.XlsxExportOptionsEx options = new DevExpress.XtraPrinting.XlsxExportOptionsEx() { ExportType = DevExpress.Export.ExportType.WYSIWYG };
                GridViewExporter.WriteXlsxToResponse(options);
                break;
            case "RTF":
                GridViewExporter.Landscape = true;
                GridViewExporter.WriteRtfToResponse();
                break;
        }
    }
}