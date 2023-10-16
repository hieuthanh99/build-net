using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class UserControls_FolderToolbar : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void FolderMenu_ItemDataBound(object source, DevExpress.Web.MenuItemEventArgs e)
    {
        IHierarchyData itemHierarchyData = (IHierarchyData)e.Item.DataItem;
        var element = (XmlElement)itemHierarchyData.Item;

        var classAttr = element.Attributes["SpriteClassName"];
        if (classAttr != null)
            e.Item.Image.SpriteProperties.CssClass = classAttr.Value;

        var navigateUrl = element.Attributes["NavigateUrl"];
        if (navigateUrl != null)
            e.Item.NavigateUrl= navigateUrl.Value;

        if (e.Item.Parent == e.Item.Menu.RootItem)
            e.Item.ClientVisible = true;
    }
}