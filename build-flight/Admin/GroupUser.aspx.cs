using DevExpress.Data.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxTreeList;
using APPData;
using DevExpress.Web;

public partial class Admin_GroupUser : BasePage
{
    QLKHAppEntities entities = new QLKHAppEntities();

    List<string> CurrentSelectedKeys;
    string ChangedSelectionNodeKey;
    List<string> afterRecursiveSelectionKeys;
    List<APPData.Menu> treeMenu;
    private const string sTreeData = "C1147C01-D51B-408A-B2A7-E9DE215285F9";

    protected List<string> AfterRecursiveSelectionKeys
    {
        get
        {
            if (afterRecursiveSelectionKeys == null)
                afterRecursiveSelectionKeys = Session["after"] as List<string>;
            return afterRecursiveSelectionKeys;
        }
        set { Session["after"] = afterRecursiveSelectionKeys = value; }
    }

    //protected void Page_PreInit(object sender, EventArgs e)
    //{
    //    Utils.ApplyTheme(this);
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        this.mMain.Items.FindByName("New").Visible = SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR);
        this.mMain.Items.FindByName("Edit").Visible = SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR);
        this.mMain.Items.FindByName("Delete").Visible = SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR);

        if (!IsPostBack)
        {
            Session.Remove(HelpDeskConstant.CURRENT_GROUP_ID);
            Session.Remove("after");
        }

        if (gridGroupUsers.IsCallback)
        {
            //Thread.Sleep(500);
        }
        else
        {
            LoadData();
            //LoadMenu();
            //treeList.ExpandToLevel(1);
        }
        if (treeList.IsCallback)
        {
            if (this.GroupHiddenField.Contains("GroupID"))
            {
                var groupID = Convert.ToInt32(GroupHiddenField.Get("GroupID"));
                this.LoadMenu(groupID);
                treeList.ExpandAll();
                ClearSelectedNodes();
                SetTreeNodeSelected(groupID);
            }
        }
    }
    private void LoadData()
    {
        EntityServerModeSource esms = new EntityServerModeSource();
        esms.QueryableSource = entities.GroupUsers.Where(x => (x.IsDeleted ?? false) == false);
        esms.KeyExpression = "GroupID";
        esms.DefaultSorting = "GroupNumber";
        gridGroupUsers.DataSource = esms;
        gridGroupUsers.DataBind();
    }
    private void LoadMenu(int pGroupId)
    {
        //if (Session[sTreeData] == null)
        //{

        var menus = (from x in entities.Menus
                     join t in entities.Applications on x.AppCode equals t.AppCode
                     join v in entities.GroupUsers on t.AppCode equals v.AppCode
                     where (x.Active ?? false) == true && v.GroupID == pGroupId
                     select x).OrderBy(x => x.Seq).ToList();

        treeMenu = menus;
        //Session[sTreeData] = menus;
        //}
        //else
        //treeMenu = (List<APPData.Menu>)Session[sTreeData];

        treeList.DataSource = treeMenu;
        treeList.DataBind();

    }

    private void SetTreeNodeSelected(int GroupId)
    {
        var checkedNodes = (from x in entities.GroupUserMenus where x.GroupID == GroupId && x.Used == true select x).ToList();
        foreach (var check in checkedNodes)
        {
            TreeListNode node = treeList.FindNodeByKeyValue(check.MenuID.ToString());
            if (node != null)
                node.Selected = true;
        }

    }

    private void ClearSelectedNodes()
    {
        List<TreeListNode> nodes = treeList.GetSelectedNodes();
        foreach (TreeListNode node in nodes)
        {
            node.Selected = false;
        }
    }

    protected void treeList_DataBound(object sender, EventArgs e)
    {
        if (!IsPostBack) treeList.ExpandToLevel(1);
    }

    List<string> GetSelectedNodesKeys()
    {
        List<TreeListNode> list = treeList.GetSelectedNodes();
        return list.Select(node => node.Key).ToList();
    }

    protected void mMain_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
    {
        string strParams = string.Empty;
        string url = string.Empty;
        DevExpress.XtraPrinting.XlsxExportOptionsEx options = new DevExpress.XtraPrinting.XlsxExportOptionsEx() { ExportType = DevExpress.Export.ExportType.WYSIWYG };
        switch (e.Item.Name.ToUpper())
        {
            case Action.NEW:
                strParams = "Act=" + Action.NEW;
                url = "~/Admin/GroupUserEdit.aspx?" + strParams;
                Response.Redirect(url);
                break;
            case Action.EDIT:
                GroupUser groupUser = (GroupUser)gridGroupUsers.GetRow(gridGroupUsers.FocusedRowIndex);
                strParams = "Act=" + Action.EDIT + "&GroupID=" + groupUser.GroupID;
                url = "~/Admin/GroupUserEdit.aspx?" + strParams;
                Response.Redirect(url);
                break;

            case Action.DELETE:
                groupUser = (GroupUser)gridGroupUsers.GetRow(gridGroupUsers.FocusedRowIndex);
                if (groupUser != null)
                {
                    groupUser.IsDeleted = true;
                    entities.SaveChanges();
                    LoadData();
                }
                break;

            case Action.REFRESH:
                LoadData();
                break;

            case "PDF":
                GridViewExporter.Landscape = true;
                GridViewExporter.WritePdfToResponse();
                break;
            case "XLS":
                GridViewExporter.WriteXlsToResponse();
                break;
            case "XLSX":
                GridViewExporter.WriteXlsxToResponse(options);
                break;
            case "RTF":
                GridViewExporter.Landscape = true;
                GridViewExporter.WriteRtfToResponse();
                break;
            case "CSV":
                GridViewExporter.WriteCsvToResponse();
                break;

        }
    }

    private bool HasSelectedChildren(long ParentKeyId)
    {
        //var flag= (from x in entity.
        return false;
    }

    private string GetActionRight(int key)
    {
        var menu = entities.Menus.Where(x => x.MenuID == key).FirstOrDefault();
        if (menu != null)
            return menu.ActionRight;

        return string.Empty;
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        GroupUser GroupUser = (GroupUser)gridGroupUsers.GetRow(gridGroupUsers.FocusedRowIndex);
        if (GroupUser != null)
        {
            int GroupId = GroupUser.GroupID;
            CurrentSelectedKeys = GetSelectedNodesKeys();

            //Cap nhat tat ca ve khong su dung USED = 'N'
            var GroupUserMenus = (from x in entities.GroupUserMenus where x.GroupID == GroupId select x).ToList();
            foreach (var gum in GroupUserMenus)
            {
                gum.Used = false;
            }

            foreach (string key in CurrentSelectedKeys)
            {
                //Kiem tra co Parent Menu chua
                int keyLong = Convert.ToInt32(key);
                int? ParentMenuID = (from x in entities.Menus where x.MenuID == keyLong select x.ParentMenuID).FirstOrDefault();
                if (ParentMenuID != null && ParentMenuID != 0)
                {
                    int lParentMenuID = (int)ParentMenuID;
                    UpdateParentMenu(keyLong, GroupId, lParentMenuID);
                }
                var oldGroupUserMenu = (from x in entities.GroupUserMenus where x.GroupID == GroupId && x.MenuID == keyLong select x).FirstOrDefault();
                if (oldGroupUserMenu != null)
                {
                    oldGroupUserMenu.Used = true;
                }
                else
                {
                    var newGroupUserMenu = new GroupUserMenu();
                    newGroupUserMenu.MenuID = keyLong;
                    newGroupUserMenu.GroupID = GroupId;
                    newGroupUserMenu.ActionRight = GetActionRight(keyLong);
                    newGroupUserMenu.Used = true;
                    entities.GroupUserMenus.Add(newGroupUserMenu);
                }
                entities.SaveChanges();
            }

            SetTreeNodeSelected(GroupId);
        }
    }

    private void UpdateParentMenu(int key, int GroupId, int lParentMenuID)
    {
        var aParent = (from t in entities.GroupUserMenus where t.GroupID == GroupId && t.MenuID == lParentMenuID select t).FirstOrDefault();
        if (aParent != null)
        {
            aParent.ActionRight = GetActionRight(key);
            aParent.Used = true;
        }
        else
        {
            var newGroupUserMenu = new GroupUserMenu();
            newGroupUserMenu.MenuID = lParentMenuID;
            newGroupUserMenu.GroupID = GroupId;
            newGroupUserMenu.ActionRight = GetActionRight(key);
            newGroupUserMenu.Used = true;
            entities.GroupUserMenus.Add(newGroupUserMenu);
        }
        entities.SaveChanges();
        var ParentMenuID = (from t in entities.Menus where t.MenuID == lParentMenuID select t.ParentMenuID).FirstOrDefault();

        if (ParentMenuID != null)
            UpdateParentMenu(key, GroupId, (int)ParentMenuID);
    }

    protected void ASPxCallbackPanel1_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        int GroupId;
        if (!int.TryParse(e.Parameter, out GroupId))
            return;
        LoadMenu(GroupId);
        treeList.ExpandAll();
        ClearSelectedNodes();
        SetTreeNodeSelected(GroupId);
    }

    protected void gridGroupUsers_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        if (args[0].Equals(Action.REFRESH))
        {
            s.JSProperties["cpResult"] = Action.REFRESH;
            LoadData();
        }
        else if (args[0].Equals(Action.DELETE))
        {
            s.JSProperties["cpResult"] = Action.DELETE;
            long GroupId;
            if (!long.TryParse(args[1], out GroupId)) return;

            var groupUser = (from x in entities.GroupUsers where x.GroupID == GroupId select x).FirstOrDefault();
            if (groupUser != null)
            {
                groupUser.IsDeleted = true;
                entities.SaveChanges();
                LoadData();
            }
        }

        else if (args[0].Equals("SaveForm"))
        {
            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];

                    var aAppCode = cboApplication.Value.ToString();
                    var aGroupNumber = groupNumberTextBox.Text;
                    var aGroupName = groupNameTextBox.Text;
                    var aIsSystem = checkIsSystem.Checked;
                    var aIsLocked = checkLocked.Checked;
                    var aIsDefault = chkIsDefault.Checked;
                    var aDesciption = textboxDescription.Text;

                    if (command.ToUpper() == "EDIT")
                    {
                        int key;
                        if (!int.TryParse(args[2], out key))
                            return;

                        var entity = entities.GroupUsers.Where(x => x.GroupID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            entity.AppCode = aAppCode;
                            entity.GroupNumber = aGroupNumber;
                            entity.GroupName = aGroupName;
                            entity.Description = aDesciption;
                            entity.IsSystem = aIsSystem;
                            entity.IsLocked = aIsLocked;
                            entity.IsDefault = aIsDefault;

                            entity.LastModifiedOnDate = DateTime.Now;
                            entity.LastModifiedByUserID = (int)SessionUser.UserID;
                            entities.SaveChanges();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new GroupUser();
                        entity.AppCode = aAppCode;
                        entity.GroupNumber = aGroupNumber;
                        entity.GroupName = aGroupName;
                        entity.Description = aDesciption;
                        entity.IsSystem = aIsSystem;
                        entity.IsLocked = aIsLocked;
                        entity.IsDefault = aIsDefault;

                        entity.CreateOnDate = DateTime.Now;
                        entity.CreatedByUserID = (int)SessionUser.UserID;

                        entities.GroupUsers.Add(entity);
                        entities.SaveChanges();
                    }
                    LoadData();

                    s.JSProperties["cpResult"] = "Success";
                }
                catch (Exception ex)
                {
                    s.JSProperties["cpResult"] = ex.Message;
                }
            }
        }
    }

    private void LoadAvaialbleChosenUser(int GroupID)
    {
        var avaiableUsers = (from x in entities.Users
                             where !(from t in entities.UserGroupUsers where t.GroupID == GroupID && t.Used == true select t.UserID).Contains(x.UserID) && x.IsDeleted == false
                             select new { UserID = x.UserID, UserName = x.DisplayName + "(" + x.Username + ")" }).ToList();

        lbAvailable.Items.Clear();
        foreach (var user in avaiableUsers)
        {
            lbAvailable.Items.Add(user.UserName, user.UserID);
        }

        var choosenUsers = (from x in entities.Users
                            join t in entities.UserGroupUsers
                            on x.UserID equals t.UserID
                            where t.GroupID == GroupID && t.Used == true && x.IsDeleted == false
                            select new { UserID = x.UserID, UserName = x.DisplayName + "(" + x.Username + ")" }).ToList();

        lbChoosen.Items.Clear();
        foreach (var user in choosenUsers)
        {
            lbChoosen.Items.Add(user.UserName, user.UserID);
        }
    }

    protected void ShutterCallbackPanel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        string[] args = e.Parameter.Split('|');
        int aGroupID;
        int aUserID;
        string[] aUserIDs;
        switch (args[0])
        {
            case "LOAD":
                if (!int.TryParse(args[1], out aGroupID)) return;
                LoadAvaialbleChosenUser(aGroupID);
                break;

            case "ADD":
                if (!int.TryParse(args[1], out aGroupID)) return;
                aUserIDs = args[2].Split(',');
                if (aUserIDs != null && aUserIDs.Length > 0)
                {
                    for (int i = 0; i < aUserIDs.Length; i++)
                    {
                        if (!int.TryParse(aUserIDs[i], out aUserID)) continue;
                        var addUser = (from x in entities.UserGroupUsers where x.GroupID == aGroupID && x.UserID == aUserID select x).FirstOrDefault();
                        if (addUser != null)
                            addUser.Used = true;
                        else
                        {
                            var aUserGroupUser = new UserGroupUser();
                            aUserGroupUser.UserID = aUserID;
                            aUserGroupUser.GroupID = aGroupID;
                            aUserGroupUser.Used = true;
                            entities.UserGroupUsers.Add(aUserGroupUser);
                        }
                    }

                    entities.SaveChanges();
                    LoadAvaialbleChosenUser(aGroupID);
                }
                break;

            case "REMOVE":
                if (!int.TryParse(args[1], out aGroupID)) return;
                aUserIDs = args[2].Split(',');
                if (aUserIDs != null && aUserIDs.Length > 0)
                {
                    for (int i = 0; i < aUserIDs.Length; i++)
                    {
                        if (!int.TryParse(aUserIDs[i], out aUserID)) continue;
                        var removeUser = (from x in entities.UserGroupUsers where x.GroupID == aGroupID && x.UserID == aUserID select x).FirstOrDefault();
                        if (removeUser != null)
                            removeUser.Used = false;
                    }
                    entities.SaveChanges();
                    LoadAvaialbleChosenUser(aGroupID);
                }
                break;
        }
    }
    protected void gridGroupUsers_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "EditForm" && args.Length == 3)
        {
            int key;
            if (!int.TryParse(args[2], out key))
                return;

            var group = entities.GroupUsers.SingleOrDefault(x => x.GroupID == key);
            if (group == null)
                return;

            var result = new Dictionary<string, string>();
            result["GroupNumber"] = group.GroupNumber;
            result["GroupName"] = group.GroupName;
            result["AppCode"] = group.AppCode;
            result["IsSystem"] = (group.IsSystem ?? false) ? "TRUE" : "FALSE";
            result["IsLocked"] = (group.IsLocked ?? false) ? "TRUE" : "FALSE";
            result["IsDefault"] = group.IsDefault ? "TRUE" : "FALSE";
            result["Description"] = group.Description;


            e.Result = result;
        }
    }
    protected void cboApplication_Init(object sender, EventArgs e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        var list = entities.Applications.OrderBy(x => x.Seq).ToList();
        cbo.DataSource = list;
        cbo.ValueField = "AppCode";
        cbo.TextField = "AppName";
        cbo.DataBind();
    }
    protected void treeList_CustomCallback(object sender, TreeListCustomCallbackEventArgs e)
    {
        string[] args = e.Argument.Split('|');
        int GroupId;
        switch (args[0])
        {
            case "LoadTree":

                if (!int.TryParse(args[1], out GroupId))
                    return;
                GroupHiddenField.Set("GroupID", GroupId);
                LoadMenu(GroupId);
                treeList.ExpandAll();
                ClearSelectedNodes();
                SetTreeNodeSelected(GroupId);
                break;

            case "SaveTree":
                GroupUser GroupUser = (GroupUser)gridGroupUsers.GetRow(gridGroupUsers.FocusedRowIndex);
                if (GroupUser != null)
                {
                    GroupId = GroupUser.GroupID;
                    CurrentSelectedKeys = GetSelectedNodesKeys();

                    //Cap nhat tat ca ve khong su dung USED = 'N'
                    var GroupUserMenus = (from x in entities.GroupUserMenus where x.GroupID == GroupId select x).ToList();
                    foreach (var gum in GroupUserMenus)
                    {
                        gum.Used = false;
                    }

                    foreach (string key in CurrentSelectedKeys)
                    {
                        //Kiem tra co Parent Menu chua
                        int keyLong = Convert.ToInt32(key);
                        int? ParentMenuID = (from x in entities.Menus where x.MenuID == keyLong select x.ParentMenuID).FirstOrDefault();
                        if (ParentMenuID != null && ParentMenuID != 0)
                        {
                            int lParentMenuID = (int)ParentMenuID;
                            UpdateParentMenu(keyLong, GroupId, lParentMenuID);
                        }
                        var oldGroupUserMenu = (from x in entities.GroupUserMenus where x.GroupID == GroupId && x.MenuID == keyLong select x).FirstOrDefault();
                        if (oldGroupUserMenu != null)
                        {
                            oldGroupUserMenu.ActionRight = GetActionRight(keyLong);
                            oldGroupUserMenu.Used = true;
                        }
                        else
                        {
                            var newGroupUserMenu = new GroupUserMenu();
                            newGroupUserMenu.MenuID = keyLong;
                            newGroupUserMenu.GroupID = GroupId;
                            newGroupUserMenu.ActionRight = GetActionRight(keyLong);
                            newGroupUserMenu.Used = true;
                            entities.GroupUserMenus.Add(newGroupUserMenu);
                        }
                        entities.SaveChanges();
                    }

                    SetTreeNodeSelected(GroupId);

                }
                break;
        }
    }
}
