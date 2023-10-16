using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APPData;

public partial class Admin_SystemParas : BasePage
{
    QLKHAppEntities entity = new QLKHAppEntities();

    //protected void Page_PreInit(object sender, EventArgs e)
    //{
    //    Utils.ApplyTheme(this);
    //}
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void DataSource_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
    {
        e.QueryableSource = entity.SystemParas;
        e.KeyExpression = "SysParaID";
        e.DefaultSorting = "SysParaID";
    }

    protected void mMain_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
    {
        string strParams = string.Empty;
        string url = string.Empty;
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
                DevExpress.XtraPrinting.XlsxExportOptionsEx options = new DevExpress.XtraPrinting.XlsxExportOptionsEx() { ExportType = DevExpress.Export.ExportType.WYSIWYG };
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
        int aSysParaID;
        switch (args[0])
        {
            case Action.DELETE:
                if (!int.TryParse(args[1], out aSysParaID)) return;
                try
                {
                    var sysPara = (from x in entity.SystemParas where x.SysParaID == aSysParaID select x).FirstOrDefault();
                    if (sysPara != null)
                    {
                        entity.SystemParas.Remove(sysPara);
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
        int aSysParaID;
        switch (args[0])
        {
            case Action.EDIT:
                RoleCallbackPanel.JSProperties["cp_action"] = Action.EDIT;
                if (!int.TryParse(args[1], out aSysParaID)) return;
                try
                {
                    var sysPara = (from x in entity.SystemParas where x.SysParaID == aSysParaID select x).FirstOrDefault();
                    if (sysPara != null)
                    {
                        hfRoleId.Set("VALUE", sysPara.SysParaID);
                        textboxSysCode.Value = sysPara.SysCode;
                        textBoxSysValue.Value = sysPara.SysValue;
                        textboxDescription.Value = sysPara.Description;
                    }
                }
                catch { }
                break;
            case Action.SAVE:
                RoleCallbackPanel.JSProperties["cp_action"] = Action.SAVE;
                string action = args[1];
                if (action.Equals(Action.NEW))
                {
                    var sysPara = new APPData.SystemPara();
                    sysPara.SysCode = textboxSysCode.Text;
                    sysPara.SysValue = textBoxSysValue.Text;
                    sysPara.Description = textboxDescription.Text;
                    sysPara.CreateDate = DateTime.Now;
                    sysPara.CreatedBy =(int) SessionUser.UserID;
                    entity.SystemParas.Add(sysPara);
                    entity.SaveChanges();
                }
                else
                {
                    if (!int.TryParse(hfRoleId.Get("VALUE") != null ? hfRoleId.Get("VALUE").ToString() : string.Empty, out aSysParaID)) return;
                    try
                    {
                        var sysPara = (from x in entity.SystemParas where x.SysParaID == aSysParaID select x).FirstOrDefault();
                        if (sysPara != null)
                        {
                            sysPara.SysCode = textboxSysCode.Text;
                            sysPara.SysValue = textBoxSysValue.Text;
                            sysPara.Description = textboxDescription.Text;
                            sysPara.LastUpdateDate = DateTime.Now;
                            sysPara.LastUpdatedBy = (int)SessionUser.UserID;
                            entity.SaveChanges();
                        }
                    }
                    catch { }
                }
                break;
        }
    }
}