using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using KTQTData;

public partial class Pages_Areas : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.mMain.Items.FindByName("New").Visible = IsGranted("Pages.KHTC.Configs.Areas.Create");
        this.mMain.Items.FindByName("Edit").Visible = IsGranted("Pages.KHTC.Configs.Areas.Edit");
        this.mMain.Items.FindByName("Delete").Visible = IsGranted("Pages.KHTC.Configs.Areas.Delete");
        this.mMain.Items.FindByName("SyncData").Visible = IsGranted("Pages.KHTC.Configs.Areas.SyncData");

        if (!IsPostBack || AreasGrid.IsCallback)
        {
            LoadAreas();
        }
    }

    #region Load data
    private void LoadAreas()
    {
        var list = entities.Areas.OrderBy(x => x.Seq).ToList();
        this.AreasGrid.DataSource = list;
        this.AreasGrid.DataBind();
    }
    #endregion

    protected void AreasGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        if (args[0].Equals(Action.REFRESH))
        {
            s.JSProperties["cpResult"] = Action.REFRESH;
            LoadAreas();
        }
        else if (args[0].Equals(Action.DELETE))
        {
            s.JSProperties["cpResult"] = Action.DELETE;
            string key = args[1];

            var area = (from x in entities.Areas where x.AreaCode == key select x).FirstOrDefault();
            if (area != null)
            {
                entities.Areas.Remove(area);
                entities.SaveChangesWithAuditLogs();
                LoadAreas();
            }
        }
        else if (args[0].Equals(Action.SYNC_DATA))
        {
            s.JSProperties["cpResult"] = Action.SYNC_DATA;
            entities.Sync_PMSArea();

            LoadAreas();
        }

        else if (args[0].Equals("SaveForm"))
        {

            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];
                    var aAreaCode = AreaCodeEditor.Text;
                    var aNameV = NameVEditor.Text;
                    var aNameE = NameEEditor.Text;
                    var aVNDestination = VNDestinationEditor.Checked;
                    var aNote = NoteEditor.Text;
                    var aSeq = SeqEditor.Number;

                    if (command.ToUpper() == "EDIT")
                    {
                        string key = args[2];

                        var entity = entities.Areas.Where(x => x.AreaCode == key).SingleOrDefault();
                        if (entity != null)
                        {
                            entity.AreaCode = aAreaCode;
                            entity.NameV = aNameV;
                            entity.NameE = aNameE;
                            entity.VNDestination = aVNDestination;
                            entity.Note = aNote;
                            entity.Seq = Convert.ToInt32(aSeq);

                            entity.LastUpdateDate = DateTime.Now;
                            entity.LastUpdatedBy = (int)SessionUser.UserID;
                            entities.SaveChangesWithAuditLogs();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new Area();
                        entity.AreaCode = aAreaCode;
                        entity.NameV = aNameV;
                        entity.NameE = aNameE;
                        entity.VNDestination = aVNDestination;
                        entity.Note = aNote;
                        entity.Seq = Convert.ToInt32(aSeq);

                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.Areas.Add(entity);
                        entities.SaveChangesWithAuditLogs();
                    }
                    LoadAreas();

                    s.JSProperties["cpResult"] = "Success";
                }
                catch (Exception ex)
                {
                    throw new UserFriendlyException(ex.Message, ex, SessionUser.UserName);
                    s.JSProperties["cpResult"] = ex.Message;
                }
            }
        }
    }
    protected void AreasGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "EditForm" && args.Length == 3)
        {
            string key = args[2];

            var area = entities.Areas.SingleOrDefault(x => x.AreaCode == key);
            if (area == null)
                return;

            var result = new Dictionary<string, string>();
            result["AreaCode"] = area.AreaCode;
            result["NameV"] = area.NameV;
            result["NameE"] = area.NameE;
            result["VNDestination"] = (area.VNDestination ?? false) ? "TRUE" : "FALSE";
            result["Note"] = area.Note;
            result["Seq"] = area.Seq.HasValue ? area.Seq.ToString() : "0";

            e.Result = result;
        }
    }
}