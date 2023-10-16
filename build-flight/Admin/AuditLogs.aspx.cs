using DevExpress.Web;
using KTQTData;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Admin_AuditLogs : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadUser(AuditLogGrid);
        if (!IsPostBack)
        {
            this.FromDateEditor.Date = DateTime.Now.Date;
            this.ToDateEditor.Date = DateTime.Now.Date;

        }

        LoadAuditLogs();
    }


    #region Load data

    private void LoadAuditLogs()
    {
        var fromDate = this.FromDateEditor.Date;
        var toDate = this.ToDateEditor.Date.AddHours(23).AddMinutes(59).AddHours(59);

        var query = entities.AuditLogs.Where(x => x.Date >= fromDate && x.Date <= toDate);
        if (UserEditor.Value != null)
        {
            var userId = Convert.ToInt32(UserEditor.Value);
            query = query.Where(x => x.UserId == userId);
        }
        var list = query.OrderByDescending(x => x.Date).ToList();

        this.AuditLogGrid.DataSource = list;
        this.AuditLogGrid.DataBind();
    }

    private void LoadUser(ASPxGridView Grid)
    {
        GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)Grid.Columns["UserId"];

        using (APPData.QLKHAppEntities context = new APPData.QLKHAppEntities())
        {
            var list = context.Users.Where(x => x.IsDeleted == false).ToList();
            aCombo.PropertiesComboBox.DataSource = list;
            aCombo.PropertiesComboBox.ValueField = "UserID";
            aCombo.PropertiesComboBox.TextField = "DisplayName";

        }
    }
    #endregion
    protected void AuditLogGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        if (args[0] == "LoadData")
        {
            LoadAuditLogs();
        }


    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExporter.FileName = "AuditLogs.xlsx";
        DevExpress.XtraPrinting.XlsxExportOptionsEx options = new DevExpress.XtraPrinting.XlsxExportOptionsEx() { ExportType = DevExpress.Export.ExportType.WYSIWYG };
        options.SheetName = "AuditLogs";
        GridViewExporter.WriteXlsxToResponse(options);
    }


    protected void UserEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        using (APPData.QLKHAppEntities context = new APPData.QLKHAppEntities())
        {
            var list = context.Users.Where(x => x.IsDeleted == false).ToList();
            s.DataSource = list;
            s.ValueField = "UserID";
            s.TextField = "DisplayName";
            s.DataBind();
        }
    }
}