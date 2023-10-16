using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APPData;

public partial class Admin_Roles : BasePage
{
    QLKHAppEntities entity = new QLKHAppEntities();

    //protected void Page_PreInit(object sender, EventArgs e)
    //{
    //    Utils.ApplyTheme(this);
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        this.mMain.Items.FindByName("New").Visible = SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR);
        this.mMain.Items.FindByName("Edit").Visible = SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR);
        //this.mMain.Items.FindByName("Delete").Visible = IsGranted("Pages.ADMIN.Admin.Roles.Delete");
    }


    protected void RolesDataSource_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
    {
        e.QueryableSource = entity.Roles;
        e.KeyExpression = "RoleID";
        e.DefaultSorting = "RoleName";
    }

    protected void mMain_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
    {
        string strParams = string.Empty;
        string url = string.Empty;
        DevExpress.XtraPrinting.XlsxExportOptionsEx options = new DevExpress.XtraPrinting.XlsxExportOptionsEx() { ExportType = DevExpress.Export.ExportType.WYSIWYG };

        switch (e.Item.Name.ToUpper())
        {
            case Action.NEW:
                break;

            case Action.EDIT:
                break;

            case Action.DELETE:
                break;

            case Action.REFRESH:
                break;

            case "PDF":
                GridViewExporter.WritePdfToResponse();
                break;
            case "XLS":
                GridViewExporter.WriteXlsToResponse();
                break;
            case "XLSX":
                GridViewExporter.WriteXlsxToResponse(options);
                break;
            case "RTF":
                GridViewExporter.WriteRtfToResponse();
                break;
            case "CSV":
                GridViewExporter.WriteCsvToResponse();
                break;
        }
    }

    protected void CallbackPanel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        string[] args = e.Parameter.Split('|');
        long RoleId;
        switch (args[0])
        {
            case Action.DELETE:
                if (!long.TryParse(args[1], out RoleId)) return;
                try
                {
                    var role = (from x in entity.Roles where x.RoleID == RoleId select x).FirstOrDefault();
                    if (role != null)
                    {
                        entity.Roles.Remove(role);
                        entity.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw ex.InnerException.InnerException;
                }
                break;
            case Action.REFRESH:
                break;
        }
    }

    protected void RoleCallbackPanel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        string[] args = e.Parameter.Split('|');
        long RoleId;
        switch (args[0])
        {
            case Action.EDIT:
                RoleCallbackPanel.JSProperties["cp_action"] = Action.EDIT;
                if (!long.TryParse(args[1], out RoleId)) return;
                try
                {
                    var role = (from x in entity.Roles where x.RoleID == RoleId select x).FirstOrDefault();
                    if (role != null)
                    {
                        hfRoleId.Set("VALUE", role.RoleID);
                        textboxRoleName.Value = role.RoleName;
                        textboxDescription.Value = role.Description;
                    }
                }
                catch { }
                break;
            case Action.SAVE:
                RoleCallbackPanel.JSProperties["cp_action"] = Action.SAVE;
                string action = args[1];
                if (action.Equals(Action.NEW))
                {
                    var role = new APPData.Role();
                    role.RoleName = textboxRoleName.Text;
                    role.Description = textboxDescription.Text;
                    role.CreatedOnDate = DateTime.Now;
                    role.CreatedByUserID =(int) SessionUser.UserID;
                    entity.Roles.Add(role);
                    entity.SaveChanges();
                }
                else
                {
                    if (!long.TryParse(hfRoleId.Get("VALUE") != null ? hfRoleId.Get("VALUE").ToString() : string.Empty, out RoleId)) return;
                    try
                    {
                        var role = (from x in entity.Roles where x.RoleID == RoleId select x).FirstOrDefault();
                        if (role != null)
                        {
                            role.RoleName = textboxRoleName.Text;
                            role.Description = textboxDescription.Text;
                            role.LastModifiedOnDate = DateTime.Now;
                            role.LastModifiedByUserID = (int)SessionUser.UserID;
                            entity.SaveChanges();
                        }
                    }
                    catch { }
                }
                break;
        }
    }
}