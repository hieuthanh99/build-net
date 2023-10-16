using DevExpress.Web;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Pages_AircraftType : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.mMain.Items.FindByName("New").Visible = IsGranted("Pages.KHTC.Configs.AircraftType.Create");
        this.mMain.Items.FindByName("Edit").Visible = IsGranted("Pages.KHTC.Configs.AircraftType.Edit");
        this.mMain.Items.FindByName("Delete").Visible = IsGranted("Pages.KHTC.Configs.AircraftType.Delete");

        if (!IsPostBack || AircraftTypeGrid.IsCallback)
        {
            LoadAircraftType();
        }
    }

    #region Load data
    private void LoadAircraftType()
    {
        var list = entities.AircraftTypes.ToList();
        this.AircraftTypeGrid.DataSource = list;
        this.AircraftTypeGrid.DataBind();
    }
    #endregion

    protected void AircraftTypeGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        if (args[0].Equals(Action.REFRESH))
        {
            s.JSProperties["cpResult"] = Action.REFRESH;
            LoadAircraftType();
        }
        else if (args[0].Equals(Action.DELETE))
        {
            s.JSProperties["cpResult"] = Action.DELETE;
            string key = args[1];

            var aircraftType = (from x in entities.AircraftTypes where x.AircraftTypeCode == key select x).FirstOrDefault();
            if (aircraftType != null)
            {
                entities.AircraftTypes.Remove(aircraftType);
                entities.SaveChangesWithAuditLogs();
                LoadAircraftType();
            }
        }

        else if (args[0].Equals("SaveForm"))
        {
            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];
                    var aAircraftTypeCode = AirCraftTypeCodeEditor.Text;
                    var aAircraftTypeName = AirCraftTypeNameEditor.Text;                   

                    if (command.ToUpper() == "EDIT")
                    {                      
                        string key = args[2];

                        var entity = entities.AircraftTypes.Where(x => x.AircraftTypeCode == key).SingleOrDefault();
                        if (entity != null)
                        {
                            entity.AircraftTypeCode = aAircraftTypeCode;
                            entity.AircraftTypeName = aAircraftTypeName;
                        
                            entity.LastUpdateDate = DateTime.Now;
                            entity.LastUpdatedBy = (int)SessionUser.UserID;
                            entities.SaveChangesWithAuditLogs();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new AircraftType();
                        entity.AircraftTypeCode = aAircraftTypeCode;
                        entity.AircraftTypeName = aAircraftTypeName;
                       

                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.AircraftTypes.Add(entity);
                        entities.SaveChangesWithAuditLogs();
                    }
                    LoadAircraftType();

                    s.JSProperties["cpResult"] = "Success";
                }
                catch (Exception ex)
                {
                    s.JSProperties["cpResult"] = ex.Message;
                }
            }
        }
    }
    protected void AircraftTypeGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "EditForm" && args.Length == 3)
        {
            string key = args[2];           

            var aircraftType = entities.AircraftTypes.SingleOrDefault(x => x.AircraftTypeCode == key);
            if (aircraftType == null)
                return;

            var result = new Dictionary<string, string>();
            result["AircraftTypeCode"] = aircraftType.AircraftTypeCode;
            result["AircraftTypeName"] = aircraftType.AircraftTypeName;


            e.Result = result;
        }
    }
}