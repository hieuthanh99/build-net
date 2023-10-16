using System;
using System.Linq;
using DevExpress.Utils;
using DevExpress.Web;
using APPData;


public partial class UserControls_NavigationToolbar : System.Web.UI.UserControl
{
    QLKHAppEntities entities = new QLKHAppEntities();
    protected void Page_Init(object sender, EventArgs e)
    {        
        BuildNavBarGroups();
    }

    private void BuildNavBarGroups()
    {
        this.NavBar.Groups.Clear();
        int? aUserID = SessionUser.UserID;
        var navbars = (from n in entities.NavBarGroups
                       join m in entities.NavBarMenus on n.NavBarGroupID equals m.NavBarGroupID
                       join x in entities.Menus on m.MenuID equals x.MenuID
                       join y in entities.GroupUserMenus on x.MenuID equals y.MenuID
                       join z in entities.UserGroupUsers on y.GroupID equals z.GroupID
                       where x.Active == true && z.UserID == aUserID && (y.Used ?? false) == true && z.Used == true && (x.IsDefault ?? false) == false
                       select n).Distinct().OrderBy(n => n.Seq).ToList();

        foreach (var navbar in navbars)
        {
            DevExpress.Web.NavBarGroup groups = new DevExpress.Web.NavBarGroup();
            groups.Name = navbar.NavBarGroupName;
            groups.Text = navbar.NavBarGroupText;
            //groups.HeaderImage.Url = navbar.ImageUrl;
            this.NavBar.Groups.Add(groups);

            BuildMenus(groups, navbar.NavBarGroupID);
        }
    }

    private void BuildMenus(DevExpress.Web.NavBarGroup subItem, int ParentID)
    {
        int? aUserID = SessionUser.UserID;

        var menus = (from x in entities.Menus
                     join m in entities.NavBarMenus on x.MenuID equals m.MenuID
                     join y in entities.GroupUserMenus on x.MenuID equals y.MenuID
                     join z in entities.UserGroupUsers on y.GroupID equals z.GroupID
                     where m.NavBarGroupID == ParentID && x.Active == true && z.UserID == aUserID && (y.Used ?? false) == true && z.Used == true && (x.IsDefault ?? false) == false
                     select x).OrderBy(x => x.Seq).Distinct().ToList();

        foreach (var menu in menus)
        {
            NavBarItem item = new NavBarItem();
            item.Text = menu.NameVN;
            item.Name = menu.MenuID.ToString();
            item.Image.Url = menu.ImagePath;
            item.NavigateUrl = menu.FileName;
            subItem.Items.Add(item);
        }
    }
}
