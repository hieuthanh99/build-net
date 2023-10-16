<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FolderToolbar.ascx.cs" Inherits="UserControls_FolderToolbar" %>
<table class="NavigationToolbar">
    <tr>
        <td style="width: 100%">
            <div style="float: left">
                <dx:ASPxMenu ID="FolderMenu" runat="server" DataSourceID="ActionMenuDataSource" Theme="Moderno"
                    ShowAsToolbar="true" ClientInstanceName="ClientFolderMenu" CssClass="ActionMenu" SeparatorWidth="0"
                    OnItemDataBound="FolderMenu_ItemDataBound">
                    <ClientSideEvents ItemClick="MailClient.ClientActionMenu_ItemClick" />
                    <Border BorderWidth="0" />
                    <SubMenuStyle CssClass="SubMenu" />
                </dx:ASPxMenu>
            </div>
            <b class="clear"></b>
        </td>       
    </tr>
</table>
<asp:XmlDataSource ID="ActionMenuDataSource" runat="server" DataFile="~/App_Data/FolderActions.xml" XPath="Items/Item"/>
