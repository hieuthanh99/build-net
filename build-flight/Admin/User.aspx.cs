using DevExpress.Data.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using DevExpress.Web;
using APPData;
using KTQTData;
using DevExpress.Web.ASPxTreeList;

public partial class Admin_User : BasePage
{
    QLKHAppEntities entities = new QLKHAppEntities();
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

        }
        LoadCompany();
        LoadData();

        if (CompanyTreeGrid.IsCallback)
        {
            if (this.UserHiddenField.Contains("UserID"))
            {
                var userID = Convert.ToInt32(UserHiddenField.Get("UserID"));
                ClearSelectedNodes();
                SetTreeNodeSelected(userID);
            }
        }
    }

    private void ClearSelectedNodes()
    {
        List<TreeListNode> nodes = this.CompanyTreeGrid.GetSelectedNodes();
        foreach (TreeListNode node in nodes)
        {
            node.Selected = false;
        }
    }
    List<string> GetSelectedNodesKeys()
    {
        List<TreeListNode> list = CompanyTreeGrid.GetSelectedNodes();
        return list.Select(node => node.Key).ToList();
    }


    private void SetTreeNodeSelected(int UserID)
    {
        var checkedNodes = (from x in entities.UserCompanies where x.UserID == UserID select x).ToList();
        foreach (var check in checkedNodes)
        {
            TreeListNode node = this.CompanyTreeGrid.FindNodeByKeyValue(check.CompanyID.ToString());
            if (node != null)
                node.Selected = true;
        }

    }


    private void LoadData()
    {
        EntityServerModeSource esms = new EntityServerModeSource();
        esms.QueryableSource = entities.Users.Where(x => x.IsDeleted == false);
        esms.KeyExpression = "UserID";
        esms.DefaultSorting = "Username";
        gridUsers.DataSource = esms;
        gridUsers.DataBind();
    }

    private void LoadCompany()
    {
        using (KTQTData.KTQTDataEntities ktqt = new KTQTDataEntities())
        {
            var companies = ktqt.DecCompanies.Where(x => x.Active == true).OrderBy(x => x.Seq).ToList();
            CompanyTreeGrid.DataSource = companies;
            CompanyTreeGrid.DataBind();

            CompanyTreeGrid.ExpandAll();
        }
    }

    private void LoadRolesAvaliable(int UserID)
    {
        var roles = (from x in entities.Roles
                     where !(from t in entities.UserRoles
                             where t.UserID == UserID
                             select t.RoleID).Contains(x.RoleID)
                     select x).ToList();
        cbRole.DataSource = roles;
        cbRole.DataBind();
    }

    private void LoadRolesChoosen(int UserID)
    {
        var roles = (from x in entities.Roles
                     join t in entities.UserRoles on x.RoleID equals t.RoleID
                     where t.UserID == UserID
                     select x).ToList();
        GridRoles.DataSource = roles;
        GridRoles.DataBind();
    }

    private void LoadAvaiableGroup(int UserID)
    {
        var groups = (from x in entities.GroupUsers
                      where !(from t in entities.UserGroupUsers
                              where t.UserID == UserID && t.Used == true
                              select t.GroupID).Contains(x.GroupID)
                      select x).ToList();
        lbAvailable.Items.Clear();
        foreach (var group in groups)
        {
            ListEditItem lei = new ListEditItem();
            lei.Value = group.GroupID;
            lei.Text = HttpUtility.HtmlEncode(group.GroupName);
            lbAvailable.Items.Add(lei);
        }
    }

    private void LoadChosenGroup(int UserID)
    {
        var groups = (from x in entities.GroupUsers
                      join t in entities.UserGroupUsers
                      on x.GroupID equals t.GroupID
                      where t.UserID == UserID && t.Used == true
                      select x).ToList();
        lbChoosen.Items.Clear();
        foreach (var group in groups)
        {
            ListEditItem lei = new ListEditItem();
            lei.Value = group.GroupID;
            lei.Text = HttpUtility.HtmlEncode(group.GroupName);
            lbChoosen.Items.Add(lei);
        }

    }

    protected void mMain_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
    {
        string strParams = string.Empty;
        string url = string.Empty;
        switch (e.Item.Name.ToUpper())
        {
            case Action.NEW:
                strParams = "Act=" + Action.NEW;
                url = "~/Admin/UserEdit.aspx?" + strParams;
                Response.Redirect(url);
                break;

            case Action.EDIT:
                User user = (User)gridUsers.GetRow(gridUsers.FocusedRowIndex);
                strParams = "Act=" + Action.EDIT + "&UserID=" + user.UserID;
                url = "~/Admin/UserEdit.aspx?" + strParams;
                Response.Redirect(url);
                break;

            case Action.DELETE:

                break;

            case Action.REFRESH:
                //LoadData();
                break;

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
            case "CSV":
                GridViewExporter.WriteCsvToResponse();
                break;


        }


    }


    protected void CallbackPanel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        string[] args = e.Parameter.Split('|');
        int aRoleID;
        int aUserID;
        switch (args[0])
        {
            case "LOAD":
                CallbackPanel.JSProperties["cp_action"] = "LOAD";
                cbRole.Value = string.Empty;
                if (!int.TryParse(args[1], out aUserID)) return;

                LoadRolesAvaliable(aUserID);
                LoadRolesChoosen(aUserID);
                break;

            case "DELETE_ROLE":
                CallbackPanel.JSProperties["cp_action"] = "DELETE_ROLE";

                cbRole.Value = string.Empty;
                if (!int.TryParse(args[1], out aUserID)) return;
                if (!int.TryParse(args[2], out aRoleID)) return;
                Delete_Role(aUserID, aRoleID);
                LoadRolesAvaliable(aUserID);
                LoadRolesChoosen(aUserID);
                break;
            case Action.REFRESH:
                CallbackPanel.JSProperties["cp_action"] = Action.REFRESH;
                break;
            case "ADD_ROLE":
                CallbackPanel.JSProperties["cp_action"] = "ADD_ROLE";
                cbRole.Value = string.Empty;
                if (!int.TryParse(args[1], out aUserID)) return;
                if (!int.TryParse(args[2], out aRoleID)) return;

                Add_Role(aUserID, aRoleID);
                LoadRolesAvaliable(aUserID);
                LoadRolesChoosen(aUserID);
                break;
        }
    }

    private void Delete_Role(int UserID, int RoleID)
    {
        var roleUser = (from x in entities.UserRoles where x.RoleID == RoleID && x.UserID == UserID select x).FirstOrDefault();
        if (roleUser != null)
        {
            entities.UserRoles.Remove(roleUser);
        }
        entities.SaveChanges();
    }

    private bool AddSelectedGroupUser(int GroupID, int UserID)
    {

        var usergroup = (from x in entities.UserGroupUsers where x.GroupID == GroupID && x.UserID == UserID select x).FirstOrDefault();
        if (usergroup != null)
            usergroup.Used = true;
        else
        {
            var aUserGroupUser = new UserGroupUser();
            aUserGroupUser.UserID = UserID;
            aUserGroupUser.GroupID = GroupID;
            aUserGroupUser.Used = true;
            entities.UserGroupUsers.Add(aUserGroupUser);
        }
        entities.SaveChanges();
        return true;

    }

    private bool RemoveSelectedGroupUser(int GroupID, int UserID)
    {

        var usergroup = (from x in entities.UserGroupUsers where x.GroupID == GroupID && x.UserID == UserID select x).FirstOrDefault();
        if (usergroup != null)
        {
            usergroup.Used = false;
            entities.SaveChanges();
        }
        return true;

    }

    private void Add_Role(int UserID, int RoleID)
    {
        var roleUser = (from x in entities.UserRoles where x.RoleID == RoleID && x.UserID == UserID select x).FirstOrDefault();
        if (roleUser != null)
        {
            return;
        }
        else
        {
            var ru = new UserRole();
            ru.UserID = UserID;
            ru.RoleID = RoleID;
            // ru.Used = true;
            entities.UserRoles.Add(ru);
        }
        entities.SaveChanges();
    }

    protected void gridUsers_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        int aUserID;
        switch (args[0])
        {
            case Action.REFRESH:
                s.JSProperties["cpResult"] = Action.REFRESH;
                LoadData();
                break;
            case Action.DELETE:
                s.JSProperties["cpResult"] = Action.DELETE;
                if (!int.TryParse(args[1], out aUserID)) return;
                var user = (from x in entities.Users where x.UserID == aUserID select x).FirstOrDefault();
                if (user != null)
                {
                    user.IsDeleted = true;
                    entities.SaveChanges();
                    LoadData();
                    if (s.VisibleRowCount > 0)
                    {
                        s.FocusedRowIndex = 0;
                    }
                }
                break;
            case "ADDCOMPANY":
                s.JSProperties["cpResult"] = "ADDCOMPANY";
                if (!int.TryParse(args[1], out aUserID)) return;
                var CurrentSelectedKeys = GetSelectedNodesKeys();

                entities.UserCompanies.RemoveRange(entities.UserCompanies.Where(x => x.UserID == aUserID));

                foreach (string key in CurrentSelectedKeys)
                {
                    int keyLong = Convert.ToInt32(key);

                    var entity = new UserCompany();
                    entity.UserID = aUserID;
                    entity.CompanyID = keyLong;
                    entity.CreateDate = DateTime.Now;
                    entity.CreatedBy = SessionUser.UserID;
                    entities.UserCompanies.Add(entity);
                }
                entities.SaveChanges();
                SetTreeNodeSelected(aUserID);
                break;

            case "SaveForm":
                if (args.Length > 1)
                {
                    try
                    {
                        var command = args[1];
                        var aUserName = userNameTextBox.Text.Trim();
                        var aFirstName = firstNameTextBox.Text.Trim();
                        var aLastName = lastNameTextBox.Text.Trim();
                        var aDisplayName = firstNameTextBox.Text.Trim() + " " + lastNameTextBox.Text.Trim();
                        var aEmail = eMailTextBox.Text;
                        var aUpdatePassword = checkChangePass.Checked;
                        var aIsSuperUser = checkIsSystem.Checked;
                        var aIsDeleted = checkLocked.Checked;
                        var aGender = genderRadioButtonList.Value != null ? Convert.ToInt32(genderRadioButtonList.Value) : 0;
                        var aCountry = countryComboBox.Value != null ? countryComboBox.Value.ToString() : "VN";
                        var aAddress = address.Text;
                        var aTelephone = telephone.Text;
                        var aMobile = mobile.Text;
                        var aCompanyID = CompanyComboBox.Value;

                        if (command.ToUpper() == "EDIT")
                        {
                            int key;
                            if (!int.TryParse(args[2], out key))
                                return;

                            var entity = entities.Users.Where(x => x.UserID == key).SingleOrDefault();
                            if (entity != null)
                            {
                                entity.Username = aUserName;
                                entity.FirstName = aFirstName;
                                entity.LastName = aLastName;
                                entity.DisplayName = aDisplayName;
                                entity.Email = aEmail;
                                entity.UpdatePassword = aUpdatePassword;
                                entity.IsSuperUser = aIsSuperUser;
                                entity.IsDeleted = aIsDeleted;
                                entity.Gender = aGender;
                                entity.Country = aCountry;
                                entity.Address = aAddress;
                                entity.Telephone = aTelephone;
                                entity.Mobile = aMobile;
                                if (aCompanyID != null)
                                    entity.CompanyID = Convert.ToInt32(aCompanyID);

                                entity.LastModifiedOnDate = DateTime.Now;
                                entity.LastModifiedByUserID = (int)SessionUser.UserID;
                                entities.SaveChanges();
                            }
                        }
                        else if (command.ToUpper() == "NEW")
                        {
                            var entity = new APPData.User();
                            entity.Username = aUserName;
                            entity.FirstName = aFirstName;
                            entity.LastName = aLastName;
                            entity.DisplayName = aDisplayName;
                            entity.Email = aEmail;
                            entity.UpdatePassword = aUpdatePassword;
                            entity.IsSuperUser = aIsSuperUser;
                            entity.IsDeleted = aIsDeleted;
                            entity.Gender = aGender;
                            entity.Country = aCountry;
                            entity.Address = aAddress;
                            entity.Telephone = aTelephone;
                            entity.Mobile = aMobile;
                            if (aCompanyID != null)
                                entity.CompanyID = Convert.ToInt32(aCompanyID);

                            entity.CreatedOnDate = DateTime.Now;
                            entity.CreatedByUserID = (int)SessionUser.UserID;

                            entities.Users.Add(entity);
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
                break;
        }
    }

    private void LoadData(int UserID)
    {
        var avaiableGroups = (from x in entities.GroupUsers
                              where !(from t in entities.UserGroupUsers
                                      where t.UserID == UserID && t.Used == true
                                      select t.GroupID).Contains(x.GroupID) && (x.IsDeleted ?? false) == false
                              select new { GroupID = x.GroupID, GroupName = x.GroupName }).ToList();

        lbAvailable.Items.Clear();
        foreach (var group in avaiableGroups)
        {
            lbAvailable.Items.Add(group.GroupName, group.GroupID);
        }

        var choosenGroups = (from x in entities.GroupUsers
                             join t in entities.UserGroupUsers
                             on x.GroupID equals t.GroupID
                             where t.UserID == UserID && t.Used == true && (x.IsDeleted ?? false) == false
                             select new { GroupID = x.GroupID, GroupName = x.GroupName }).ToList();

        lbChoosen.Items.Clear();
        foreach (var group in choosenGroups)
        {
            lbChoosen.Items.Add(group.GroupName, group.GroupID);
        }
    }


    protected void ShutterCallbackPanel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        string[] args = e.Parameter.Split('|');
        string[] aGroupIDs;
        int aGroupID;
        int aUserID;
        switch (args[0])
        {
            case "LOAD":
                if (!int.TryParse(args[1], out aUserID)) return;
                LoadData(aUserID);
                break;

            case "ADD":
                if (!int.TryParse(args[1], out aUserID)) return;
                aGroupIDs = args[2].Split(',');
                if (aGroupIDs != null && aGroupIDs.Length > 0)
                {
                    for (int i = 0; i < aGroupIDs.Length; i++)
                    {
                        if (!int.TryParse(aGroupIDs[i], out aGroupID)) continue;
                        var addGroupUser = (from x in entities.UserGroupUsers where x.GroupID == aGroupID && x.UserID == aUserID select x).FirstOrDefault();
                        if (addGroupUser != null)
                            addGroupUser.Used = true;
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
                    LoadData(aUserID);
                }
                break;

            case "REMOVE":
                if (!int.TryParse(args[1], out aUserID)) return;
                aGroupIDs = args[2].Split(',');
                if (aGroupIDs != null && aGroupIDs.Length > 0)
                {
                    for (int i = 0; i < aGroupIDs.Length; i++)
                    {
                        if (!int.TryParse(aGroupIDs[i], out aGroupID)) continue;
                        var removeGroupUser = (from x in entities.UserGroupUsers where x.GroupID == aGroupID && x.UserID == aUserID select x).FirstOrDefault();
                        if (removeGroupUser != null)
                            removeGroupUser.Used = false;
                    }
                    entities.SaveChanges();
                    LoadData(aUserID);
                }
                break;
        }
    }

    protected void SetPasswordPanelPanel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        if (string.IsNullOrEmpty(e.Parameter))
            return;
        var args = e.Parameter.Split('|');
        if (args[0] == "SETPASSWORD")
        {
            var password = PasswordEditor.Text;
            int UserID;
            if (!int.TryParse(args[1], out UserID)) return;
            var user = entities.Users.SingleOrDefault(u => u.UserID == UserID);
            if (user != null)
            {
                user.Password = Common.EncryptText(password);
                entities.SaveChanges();
            }
        }
    }

    protected void countryComboBox_Init(object sender, EventArgs e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        var list = entities.Lists.Where(x => x.ListName == "Country").ToList();

        cbo.DataSource = list;
        cbo.ValueField = "Value";
        cbo.TextField = "Text";
        cbo.DataBind();
    }
    protected void gridUsers_CustomDataCallback(object sender, ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "EditForm" && args.Length == 3)
        {
            int key;
            if (!int.TryParse(args[2], out key))
                return;

            var user = entities.Users.SingleOrDefault(x => x.UserID == key);
            if (user == null)
                return;

            var result = new Dictionary<string, string>();
            result["FirstName"] = user.FirstName;
            result["LastName"] = user.LastName;
            result["IsSuperUser"] = user.IsSuperUser ? "TRUE" : "FALSE";
            result["IsDeleted"] = user.IsDeleted ? "TRUE" : "FALSE";
            result["UpdatePassword"] = user.UpdatePassword ? "TRUE" : "FALSE";
            result["Email"] = user.Email;
            result["DisplayName"] = user.DisplayName;
            result["CompanyID"] = user.CompanyID.HasValue ? user.CompanyID.Value.ToString() : string.Empty;
            result["Username"] = user.Username;
            result["Address"] = user.Address;
            result["Telephone"] = user.Telephone;
            result["Mobile"] = user.Mobile;
            result["Country"] = user.Country;
            result["Gender"] = (user.Gender.HasValue ? (int)user.Gender : 0).ToString();

            e.Result = result;
        }
    }
    protected void CompanyComboBox_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        using (KTQTDataEntities entities = new KTQTDataEntities())
        {
            var list = entities.DecCompanies
                .Select(x => new { CompanyID = x.CompanyID, NameV = x.ShortName + "-" + x.NameV, Seq = x.Seq })
                .OrderBy(x => x.NameV).ToList();
            s.DataSource = list;
            s.ValueField = "CompanyID";
            s.TextField = "NameV";
            s.DataBind();
        }
    }
    protected void gridUsers_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        if (e.Column.FieldName == "CompanyName")
        {
            var user = grid.GetRow(e.VisibleIndex) as APPData.User;
            if (user == null) return;
            var key = user.CompanyID;
            string companyName = string.Empty;

            if (key != null)
            {
                using (KTQTData.KTQTDataEntities ktqt = new KTQTDataEntities())
                {
                    var company = ktqt.DecCompanies.SingleOrDefault(x => x.CompanyID == key);
                    if (company != null)
                        companyName = company.AreaCode + "-" + company.NameV;
                }
            }

            e.DisplayText = companyName;
        }
    }
    protected void CompanyTreeGrid_HtmlRowPrepared(object sender, DevExpress.Web.ASPxTreeList.TreeListHtmlRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("CompanyType"), "K"))
        {
            e.Row.Font.Bold = true;
        }
    }
    protected void CompanyTreeGrid_CustomCallback(object sender, TreeListCustomCallbackEventArgs e)
    {
        string[] args = e.Argument.Split('|');
        int UserID;
        switch (args[0])
        {
            case "LoadTree":

                if (!int.TryParse(args[1], out UserID))
                    return;
                UserHiddenField.Set("UserID", UserID);
                LoadCompany();
                CompanyTreeGrid.ExpandAll();
                ClearSelectedNodes();
                SetTreeNodeSelected(UserID);
                break;
        }
    }
}
