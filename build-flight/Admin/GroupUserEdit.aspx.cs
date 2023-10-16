using APPData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_GroupUserEdit : BasePage
{
    private const string sRequestUrl = "1804E1BF-4F9F-4A52-8A77-A172AFD3EA0F";
    private const string sAction = "DBE26F4D-3B60-4E61-9004-233D0F961089";
    private const string sGroupID = "146681E5-AD37-4486-9B7C-B98F69C069EE";

    QLKHAppEntities entity = new QLKHAppEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.UrlReferrer != null)
                ViewState[sRequestUrl] = Request.UrlReferrer.ToString();

            string strAction = Request.QueryString["Act"] != null ? Request.QueryString["Act"].ToString() : "";
            string strGroupId = Request.QueryString["GroupID"] != null ? Request.QueryString["GroupID"].ToString() : "";
            ViewState[sAction] = strAction;

            if (strAction.Equals(Action.EDIT) && !StringUtils.isEmpty(strGroupId))
            {
                this.groupNumberTextBox.ReadOnly = true;
                LoadGroup(Convert.ToInt32(strGroupId));
                ViewState[sGroupID] = strGroupId;
            }
        }
    }
    private void LoadGroup(int GroupId)
    {
        var aGroupUser = (from x in entity.GroupUsers where x.GroupID == GroupId select x).FirstOrDefault();
        if (aGroupUser != null)
        {
            groupNumberTextBox.Value = aGroupUser.GroupNumber;
            groupNameTextBox.Value = aGroupUser.GroupName;            
            checkIsSystem.Value = aGroupUser.IsSystem;
            checkLocked.Value = aGroupUser.IsLocked;
            chkIsDefault.Checked = aGroupUser.IsDefault;
            textboxDescription.Value = aGroupUser.Description;
        }
    }
    private bool CheckExistsGroup(int GroupId, string GroupNumber)
    {
        var chk = (from x in entity.GroupUsers
                   where !x.GroupID.Equals(GroupId) && x.GroupNumber.Equals(GroupNumber)
                   select x).Any();
        return chk;
    }

    private bool Is_Valid()
    {
        if (StringUtils.isEmpty(groupNumberTextBox.Text))
        {
            //lbNotice.Text = GetMessage("MSG-0006");
            Response.Write("<script type='text/javascript'>alert('" + GetMessage("MSG-0006") + "');</script>");
            return false;
        }

        if (CheckExistsGroup(ViewState[sGroupID] != null ? Convert.ToInt32(ViewState[sGroupID]) : 0, groupNumberTextBox.Text))
        {
            //lbNotice.Text = GetMessage("MSG-0007");
            Response.Write("<script type='text/javascript'>alert('" + GetMessage("MSG-0007") + "');</script>");
            return false;
        }

        if (StringUtils.isEmpty(groupNameTextBox.Text))
        {
            //lbNotice.Text = GetMessage("MSG-0006");
            Response.Write("<script type='text/javascript'>alert('" + GetMessage("MSG-0008") + "');</script>");
            return false;
        }

        return true;
    }

    private void CreateGroupUser()
    {
        var aGroupUser = new GroupUser();
        aGroupUser.GroupNumber = groupNumberTextBox.Text;
        aGroupUser.GroupName = groupNameTextBox.Text;
        aGroupUser.IsSystem = checkIsSystem.Checked;
        aGroupUser.IsLocked = checkLocked.Checked;
        aGroupUser.IsDefault = chkIsDefault.Checked;
        aGroupUser.Description = textboxDescription.Text;
        aGroupUser.CreateOnDate = DateTime.Now;
        aGroupUser.CreatedByUserID = (int)SessionUser.UserID;
        entity.GroupUsers.Add(aGroupUser);
        entity.SaveChanges();

    }

    private void UpdateGroupUser(int GroupId)
    {
        var group = (from x in entity.GroupUsers where x.GroupID == GroupId select x).FirstOrDefault();
        if (group != null)
        {
            group.GroupNumber = groupNumberTextBox.Text;
            group.GroupName = groupNameTextBox.Text;
            group.IsSystem = checkIsSystem.Checked;
            group.IsLocked = checkLocked.Checked;
            group.IsDefault = chkIsDefault.Checked;
            group.Description = textboxDescription.Text;
            group.LastModifiedOnDate = DateTime.Now;
            group.LastModifiedByUserID = (int)SessionUser.UserID;
            entity.SaveChanges();
        }

    }

    protected void mMain_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
    {
        if (e.Item.Name.ToUpper().Equals(Action.CANCEL))
        {
            if (ViewState[sRequestUrl] != null)
            {
                string Url = ViewState[sRequestUrl].ToString();
                Response.Redirect(Url);
            }
            else
                Response.Redirect("~/");
        }
        else if (e.Item.Name.ToUpper().Equals(Action.SAVE))
        {

            string strAction = Action.NEW;
            if (ViewState[sAction] != null)
                strAction = ViewState[sAction].ToString();

            if (strAction.Equals(Action.EDIT))
            {
                if (ViewState[sGroupID] != null)
                {
                    if (!Is_Valid()) return;
                    int aGroupId;
                    if (int.TryParse(ViewState[sGroupID].ToString(), out aGroupId))
                    {
                        UpdateGroupUser(aGroupId);
                        if (ViewState[sRequestUrl] != null)
                        {
                            string Url = ViewState[sRequestUrl].ToString();
                            Response.Redirect(Url);
                        }
                    }
                }
            }
            else
            {
                if (!Is_Valid()) return;
                CreateGroupUser();
                if (ViewState[sRequestUrl] != null)
                {
                    string Url = ViewState[sRequestUrl].ToString();
                    Response.Redirect(Url);
                }
            }

        }
    }
}