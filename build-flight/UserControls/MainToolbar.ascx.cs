using APPData;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Xml;


public partial class UserControls_MainToolbar : System.Web.UI.UserControl
{
    QLKHAppEntities entities = new QLKHAppEntities();
    public string AppName = "QUẢN LÝ KẾ HOẠCH THU-CHI LĨNH VỰC THƯƠNG MẠI";
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Remove(SessionConstant.PARENT_MENUS);
            Session.Remove(SessionConstant.ALL_MENUS);
        }

        BuildParentMenus();
        var application = entities.Applications.SingleOrDefault(x => x.AppCode == SessionUser.Application);
        if (application != null)
            AppName = application.AppName;

    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private List<Menu> ParentMenus()
    {
        if (Session[SessionConstant.PARENT_MENUS] != null)
            return (List<Menu>)Session[SessionConstant.PARENT_MENUS];
        else
        {
            int? aUserID = SessionUser.UserID;
            string appCode = SessionUser.Application;

            var menus = (from x in entities.Menus
                         join y in entities.GroupUserMenus on x.MenuID equals y.MenuID
                         join z in entities.UserGroupUsers on y.GroupID equals z.GroupID
                         where x.AppCode == appCode && x.MenuType == "MENU" && (x.ParentMenuID ?? 0) == 0 && x.Active == true && z.UserID == aUserID && (y.Used ?? false) == true && z.Used == true && (x.IsDefault ?? false) == false
                         select x).Distinct().OrderBy(x => x.Seq).ToList();

            Session[SessionConstant.PARENT_MENUS] = menus;
            return menus;
        }
    }


    private List<Menu> AllMenus()
    {
        if (Session[SessionConstant.ALL_MENUS] != null)
            return (List<Menu>)Session[SessionConstant.ALL_MENUS];
        else
        {
            int? aUserID = SessionUser.UserID;
            string appCode = SessionUser.Application;

            var menus = (from x in entities.Menus
                         join y in entities.GroupUserMenus on x.MenuID equals y.MenuID
                         join z in entities.UserGroupUsers on y.GroupID equals z.GroupID
                         where x.AppCode == appCode && x.MenuType == "MENU" && x.Active == true && z.UserID == aUserID && (y.Used ?? false) == true && z.Used == true && (x.IsDefault ?? false) == false
                         select x).Distinct().OrderBy(x => x.Seq).ToList();

            Session[SessionConstant.ALL_MENUS] = menus;
            return menus;
        }
    }

    private void BuildParentMenus()
    {
        this.AppMenu.Items.Clear();

        //int? aUserID = SessionUser.UserID;
        //string appCode = SessionUser.Application;
        //var menus = (from x in entities.Menus
        //             join y in entities.GroupUserMenus on x.MenuID equals y.MenuID
        //             join z in entities.UserGroupUsers on y.GroupID equals z.GroupID
        //             where x.AppCode == appCode && x.MenuType == "MENU" && (x.ParentMenuID ?? 0) == 0 && x.Active == true && z.UserID == aUserID && (y.Used ?? false) == true && z.Used == true && (x.IsDefault ?? false) == false
        //             select x).Distinct().OrderBy(x => x.Seq).ToList();

        //foreach (var menu in menus)

        foreach (var menu in ParentMenus())
        {
            MenuItem item = new MenuItem();
            item.Text = menu.NameVN;
            item.Name = menu.MenuID.ToString();
            //item.Image.SpriteProperties.CssClass = menu.CssClass;
            item.Image.Url = menu.ImagePath;
            item.Image.Width = 16;
            //item.Image.Height = 16;
            item.NavigateUrl = menu.FileName;
            this.AppMenu.Items.Add(item);
            BuildMenus(item, menu.MenuID);
        }
    }

    private void BuildMenus(MenuItem subItem, int ParentID)
    {
        //int? aUserID = SessionUser.UserID;
        //string appCode = SessionUser.Application;
        //var menus = (from x in entities.Menus
        //             join y in entities.GroupUserMenus on x.MenuID equals y.MenuID
        //             join z in entities.UserGroupUsers on y.GroupID equals z.GroupID
        //             where x.AppCode == appCode && x.MenuType == "MENU" && x.ParentMenuID == ParentID && x.Active == true && z.UserID == aUserID && (y.Used ?? false) == true && z.Used == true && (x.IsDefault ?? false) == false
        //             select x).Distinct().OrderBy(x => x.Seq).ToList();

        var menus = (from x in AllMenus()
                     where x.ParentMenuID == ParentID
                     select x).ToList();

        foreach (var menu in menus)
        {
            MenuItem item = new MenuItem();
            item.Text = menu.NameVN;
            item.Name = menu.MenuID.ToString();
            //item.Image.SpriteProperties.CssClass = menu.CssClass;
            item.Image.Url = menu.ImagePath;
            item.Image.Width = 16;
            //item.Image.Height = 16;
            item.NavigateUrl = menu.FileName;
            subItem.Items.Add(item);
            BuildMenus(item, menu.MenuID);
        }
    }
    protected void ActionMenu_ItemDataBound(object sender, MenuItemEventArgs e)
    {
        IHierarchyData itemHierarchyData = (IHierarchyData)e.Item.DataItem;
        var element = (XmlElement)itemHierarchyData.Item;

        var classAttr = element.Attributes["SpriteClassName"];
        if (classAttr != null)
            e.Item.Image.SpriteProperties.CssClass = classAttr.Value;

        //if (e.Item.Parent == e.Item.Menu.RootItem)
        //    e.Item.ClientVisible = false;
    }

    protected void InfoMenu_OnItemDataBound(object sender, MenuItemEventArgs e)
    {
        IHierarchyData itemHierarchyData = (IHierarchyData)e.Item.DataItem;
        var element = (XmlElement)itemHierarchyData.Item;

        var classAttr = element.Attributes["SpriteClassName"];
        if (classAttr != null)
            e.Item.Image.SpriteProperties.CssClass = classAttr.Value;

        //if (e.Item.Parent.Name == "theme" && e.Item.Name == Utils.CurrentTheme)
        //    e.Item.Selected = true;

        if (e.Item.Name == "Parameters" || e.Item.Name == "BIParameters" || e.Item.Name == "OtherParameters")
        {
            //if (SessionUser.IsInRole(PermissionConstant.SETUP_PARAMETER))
            //    e.Item.Visible = true;
            //else
            e.Item.Visible = false;
        }
        if (e.Item.Name == "SwitchApp")
        {
            if (SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR))
                e.Item.Visible = true;
            else
                e.Item.Visible = false;
        }

    }
    protected void ApplicationGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        if (args[0] == "LOAD")
        {
            int userID = (int)SessionUser.UserID;
            var appCodes = (from x in entities.GroupUsers
                            join t in entities.UserGroupUsers on x.GroupID equals t.GroupID
                            where t.UserID == userID && t.Used == true //&& x.AppCode != "KHNN"
                            select x.AppCode).ToList();

            var list = entities.Applications.Where(x => x.AppCode != SessionUser.Application && appCodes.Contains(x.AppCode)).ToList();
            s.DataSource = list;
            s.DataBind();

        }
        else if (args[0] == "SWITCHAPP")
        {
            Session.Remove(SessionConstant.PARENT_MENUS);
            Session.Remove(SessionConstant.ALL_MENUS);

            string appCode = args[1];
            LoginUser log = SessionUser.GetLoginUser();
            log.Application = appCode;
            SessionUser.SetLoginUser(log);

            DevExpress.Web.ASPxWebControl.RedirectOnCallback("~/Default.aspx");
        }
    }

    protected void BIParamsCallbackPanel_Callback(object sender, CallbackEventArgsBase e)
    {
        ASPxCallbackPanel callback = sender as ASPxCallbackPanel;
        string[] args = e.Parameter.Split('|');

        callback.JSProperties["cpCommand"] = args[0];

        if (args[0] == "LOAD_PARAMS")
        {
            using (KTQTData.KTQTDataEntities context = new KTQTData.KTQTDataEntities())
            {
                var rows = context.BIParameters.ToList();
                foreach (var row in rows)
                {
                    if (row.DataType == "A")
                    {
                        this.dtpADateOfFAST.Value = row.DateOfFAST;
                        //this.dtpADatePreviousWeek.Value = row.DatePreviousWeek;
                    }
                    if (row.DataType == "E")
                    {
                        this.dtpEDateOfFAST.Value = row.DateOfFAST;
                        //this.dtpEDatePreviousWeek.Value = row.DatePreviousWeek;
                    }
                }

                string[] sysCodes = new string[] { "EST_MONTH", "EST_YEAR", "EST_RATE", "VMS_SYNC_DATE", "DASHBOARD_VERSIONID", "DASHBOARD_FROM_DATE", "DASHBOARD_TO_DATE" };

                var paramList = entities.SystemParas.Where(x => sysCodes.Contains(x.SysCode)).ToList();
                foreach (var param in paramList)
                {
                    if (param.SysCode == "EST_MONTH")
                        this.spEstMonth.Value = Convert.ToInt32(StringUtils.isEmpty(param.SysValue) ? "1" : param.SysValue);
                    if (param.SysCode == "EST_YEAR")
                        this.spEstYear.Value = Convert.ToInt32(StringUtils.isEmpty(param.SysValue) ? DateTime.Now.Year.ToString() : param.SysValue);
                    if (param.SysCode == "EST_RATE")
                        this.spEstRate.Value = Convert.ToDouble(StringUtils.isEmpty(param.SysValue) ? "12" : param.SysValue);
                    if (param.SysCode == "VMS_SYNC_DATE")
                        this.dtpSyncFromDate.Value = StringUtils.isEmpty(param.SysValue) ? DateTime.Now.AddMonths(-1) : Convert.ToDateTime(param.SysValue);
                    if (param.SysCode == "DASHBOARD_VERSIONID")
                        this.cboDBVersion.Value = Convert.ToInt32(StringUtils.isEmpty(param.SysValue) ? "0" : param.SysValue);
                    if (param.SysCode == "DASHBOARD_FROM_DATE")
                        this.dtpDBFromDate.Value = StringUtils.isEmpty(param.SysValue) ? DateTime.Now.AddMonths(-1) : Convert.ToDateTime(param.SysValue);
                    if (param.SysCode == "DASHBOARD_TO_DATE")
                        this.dtpDBToDate.Value = StringUtils.isEmpty(param.SysValue) ? DateTime.Now.AddMonths(-1) : Convert.ToDateTime(param.SysValue);
                }
            }
        }

        if (args[0] == "SAVE_PARAMS")
        {
            try
            {
                using (KTQTData.KTQTDataEntities context = new KTQTData.KTQTDataEntities())
                {
                    var rows = context.BIParameters.ToList();
                    foreach (var row in rows)
                    {
                        if (row.DataType == "A")
                        {
                            row.DateOfFAST = this.dtpADateOfFAST.Date;
                            //row.DatePreviousWeek = this.dtpADatePreviousWeek.Date;
                        }
                        if (row.DataType == "E")
                        {
                            row.DateOfFAST = this.dtpEDateOfFAST.Date;
                            //row.DatePreviousWeek = this.dtpEDatePreviousWeek.Date;
                        }
                    }
                    string[] sysCodes = new string[] { "EST_MONTH", "EST_YEAR", "EST_RATE", "VMS_SYNC_DATE", "DASHBOARD_VERSIONID", "DASHBOARD_FROM_DATE", "DASHBOARD_TO_DATE" };

                    var paramList = entities.SystemParas.Where(x => sysCodes.Contains(x.SysCode)).ToList();
                    foreach (var param in paramList)
                    {
                        if (param.SysCode == "EST_MONTH")
                            param.SysValue = this.spEstMonth.Number.ToString();
                        if (param.SysCode == "EST_YEAR")
                            param.SysValue = this.spEstYear.Number.ToString();
                        if (param.SysCode == "EST_RATE")
                            param.SysValue = this.spEstRate.Number.ToString();
                        if (param.SysCode == "VMS_SYNC_DATE")
                            param.SysValue = this.dtpSyncFromDate.Date.ToString("yyyy-MM-dd");
                        if (param.SysCode == "DASHBOARD_VERSIONID")
                            param.SysValue = this.cboDBVersion.Value.ToString();
                        if (param.SysCode == "DASHBOARD_FROM_DATE")
                            param.SysValue = this.dtpDBFromDate.Date.ToString("yyyy-MM-dd");
                        if (param.SysCode == "DASHBOARD_TO_DATE")
                            param.SysValue = this.dtpDBToDate.Date.ToString("yyyy-MM-dd");
                    }

                    entities.SaveChanges();
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                callback.JSProperties["cpCommand"] = ex.Message;
            }
        }
    }
    protected void SystemParameterCallbackPanel_Callback(object sender, CallbackEventArgsBase e)
    {
        ASPxCallbackPanel callback = sender as ASPxCallbackPanel;
        string[] args = e.Parameter.Split('|');

        callback.JSProperties["cpCommand"] = args[0];

        if (args[0] == "LOAD_PARAMS")
        {
            string[] sysCodes = new string[] { "VMS_SERVER", "VMS_DATABASE", "VMS_DB_UID", "VMS_DB_PWD",
                "FAST_SERVER", "FAST_DATABASE", "FAST_DB_UID", "FAST_DB_PWD", "BAMBOO_SERVER", "BAMBOO_DB_SYS",
                "BAMBOO_UID", "BAMBOO_PWD", "MA_VUVIEC", "SGN", "HAN", "DAD", "CTY", "ALLOCATE_METHOD" };


            var paramList = entities.SystemParas.Where(x => sysCodes.Contains(x.SysCode)).ToList();
            foreach (var param in paramList)
            {
                if (param.SysCode == "VMS_SERVER")
                    this.VMSIPAddressEditor.Value = param.SysValue;
                if (param.SysCode == "VMS_DATABASE")
                    this.VMSDatabaseNameEditor.Value = param.SysValue;
                if (param.SysCode == "VMS_DB_UID")
                    this.VMSDatabaseUIDEditor.Value = param.SysValue;
                if (param.SysCode == "VMS_DB_PWD")
                    this.VMSDatabasePwdEditor.Value = param.SysValue;

                if (param.SysCode == "FAST_SERVER")
                    this.FASTIPAddressEditor.Value = param.SysValue;
                if (param.SysCode == "FAST_DATABASE")
                    this.FASTDatabaseNameEditor.Value = param.SysValue;
                if (param.SysCode == "FAST_DB_UID")
                    this.FASTDatabaseUIDEditor.Value = param.SysValue;
                if (param.SysCode == "FAST_DB_PWD")
                    this.FASTDatabasePwdEditor.Value = param.SysValue;

                if (param.SysCode == "BAMBOO_SERVER")
                    this.BAMBOOIPAddressEditor.Value = param.SysValue;
                if (param.SysCode == "BAMBOO_DB_SYS")
                    this.BAMBOODatabaseNameEditor.Value = param.SysValue;
                if (param.SysCode == "BAMBOO_UID")
                    this.BAMBOODatabaseUIDEditor.Value = param.SysValue;
                if (param.SysCode == "BAMBOO_PWD")
                    this.BAMBOODatabasePwdEditor.Value = param.SysValue;

                if (param.SysCode == "MA_VUVIEC")
                    this.ListFASTCodeEditor.Value = param.SysValue;
                if (param.SysCode == "SGN")
                    this.DVCSTsnEditor.Value = param.SysValue;
                if (param.SysCode == "HAN")
                    this.DVCSNbaEditor.Value = param.SysValue;
                if (param.SysCode == "DAD")
                    this.DVCSDadEditor.Value = param.SysValue;
                if (param.SysCode == "CTY")
                    this.DVCSBAMBOOEditor.Value = param.SysValue;
                if (param.SysCode == "ALLOCATE_METHOD")
                    this.AllocateMethodEditor.Value = param.SysValue;
            }

        }
        if (args[0] == "SAVE_PARAMS")
        {
            try
            {
                string[] sysCodes = new string[] { "VMS_SERVER", "VMS_DATABASE", "VMS_DB_UID", "VMS_DB_PWD",
                    "FAST_SERVER", "FAST_DATABASE", "FAST_DB_UID", "FAST_DB_PWD", "BAMBOO_SERVER", "BAMBOO_DB_SYS",
                    "BAMBOO_UID", "BAMBOO_PWD", "MA_VUVIEC", "SGN", "HAN", "DAD", "CTY", "ALLOCATE_METHOD" };

                var paramList = entities.SystemParas.Where(x => sysCodes.Contains(x.SysCode)).ToList();
                foreach (var param in paramList)
                {
                    if (param.SysCode == "VMS_SERVER")
                        param.SysValue = this.VMSIPAddressEditor.Text.Trim();
                    if (param.SysCode == "VMS_DATABASE")
                        param.SysValue = this.VMSDatabaseNameEditor.Text.Trim();
                    if (param.SysCode == "VMS_DB_UID")
                        param.SysValue = this.VMSDatabaseUIDEditor.Text.Trim();
                    if (param.SysCode == "VMS_DB_PWD" && !StringUtils.isEmpty(this.VMSDatabasePwdEditor.Text.Trim()))
                        param.SysValue = this.VMSDatabasePwdEditor.Text.Trim();

                    if (param.SysCode == "FAST_SERVER")
                        param.SysValue = this.FASTIPAddressEditor.Text.Trim();
                    if (param.SysCode == "FAST_DATABASE")
                        param.SysValue = this.FASTDatabaseNameEditor.Text.Trim();
                    if (param.SysCode == "FAST_DB_UID")
                        param.SysValue = this.FASTDatabaseUIDEditor.Text.Trim();
                    if (param.SysCode == "FAST_DB_PWD" && !StringUtils.isEmpty(this.FASTDatabasePwdEditor.Text.Trim()))
                        param.SysValue = this.FASTDatabasePwdEditor.Text.Trim();

                    if (param.SysCode == "BAMBOO_SERVER")
                        param.SysValue = this.BAMBOOIPAddressEditor.Text.Trim();
                    if (param.SysCode == "BAMBOO_DB_SYS")
                        param.SysValue = this.BAMBOODatabaseNameEditor.Text.Trim();
                    if (param.SysCode == "BAMBOO_UID")
                        param.SysValue = this.BAMBOODatabaseUIDEditor.Text.Trim();
                    if (param.SysCode == "BAMBOO_PWD" && !StringUtils.isEmpty(this.BAMBOODatabasePwdEditor.Text.Trim()))
                        param.SysValue = this.BAMBOODatabasePwdEditor.Text.Trim();

                    if (param.SysCode == "MA_VUVIEC")
                        param.SysValue = this.ListFASTCodeEditor.Text.Trim();
                    if (param.SysCode == "SGN")
                        param.SysValue = this.DVCSTsnEditor.Text.Trim();
                    if (param.SysCode == "HAN")
                        param.SysValue = this.DVCSNbaEditor.Text.Trim();
                    if (param.SysCode == "DAD")
                        param.SysValue = this.DVCSDadEditor.Text.Trim();
                    if (param.SysCode == "CTY")
                        param.SysValue = this.DVCSBAMBOOEditor.Text.Trim();
                    if (param.SysCode == "ALLOCATE_METHOD")
                        param.SysValue = this.AllocateMethodEditor.Value.ToString().Trim();

                }
                entities.SaveChanges();

            }
            catch (Exception ex)
            {
                callback.JSProperties["cpCommand"] = ex.Message;
            }
        }
    }
    protected void cboDBVersion_Init(object sender, EventArgs e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        using (KTQTData.KTQTDataEntities context = new KTQTData.KTQTDataEntities())
        {
            var list = context.Versions
                .Where(x => x.VersionType == "A" && x.Active == true && x.Status != "APPROVED")
                .Select(x => new { VersionID = x.VersionID, Description = x.Description })
                .ToList();

            cbo.DataSource = list;
            cbo.ValueField = "VersionID";
            cbo.TextField = "Description";
            cbo.DataBind();
        }
    }
}