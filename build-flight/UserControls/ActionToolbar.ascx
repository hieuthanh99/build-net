<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ActionToolbar.ascx.cs" Inherits="UserControls_ActionToolbar" %>
<table class="ActionToolbar">
    <tr>
        <td class="Strut">
            <div style="float: left">
                <dx:ASPxMenu ID="ActionMenu" runat="server" DataSourceID="ActionMenuDataSource" Theme="Moderno"
                    ShowAsToolbar="true" ClientInstanceName="ClientActionMenu" CssClass="ActionMenu" SeparatorWidth="0"
                    OnItemDataBound="ActionMenu_ItemDataBound">
                    <ClientSideEvents ItemClick="MailClient.ClientActionMenu_ItemClick" />
                    <Border BorderWidth="0" />
                    <SubMenuStyle CssClass="SubMenu" />
                </dx:ASPxMenu>
            </div>
            <div style="float: right">
                <%--<dx:ASPxRatingControl ID="RatingControl" runat="server" ClientInstanceName="ClientRatingControl" ItemCount="5" ItemWidth="5" ItemHeight="5"></dx:ASPxRatingControl>--%>
            </div>
            <b class="clear"></b>
        </td>

    </tr>
</table>
<asp:XmlDataSource ID="ActionMenuDataSource" runat="server" DataFile="~/App_Data/Actions.xml" />
