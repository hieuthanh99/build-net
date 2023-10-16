<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MailToolbar.ascx.cs" Inherits="UserControls_MailToolbar" %>
<table class="ActionToolbar">
    <tr class="LayoutTable">
        <td style="width:20px">
            <div style="float: left">
                <dx:ASPxMenu ID="MainActionMenu" runat="server" DataSourceID="MainActionMenuDataSource" Theme="Moderno"
                    ShowAsToolbar="true" ClientInstanceName="ClientMainActionMenu" CssClass="ActionMenu" SeparatorWidth="0"
                    OnItemDataBound="ActionMenu_ItemDataBound">
                    <ClientSideEvents ItemClick="MailClient.ClientActionMenu_ItemClick" />
                    <Border BorderWidth="0" />
                    <SubMenuStyle CssClass="SubMenu" />
                </dx:ASPxMenu>
            </div>
        </td>
        <td id="SearchBoxSpacer" class="Spacer" runat="server"><b></b></td>
        <td>
             <div style="float: left">
            <dx:ASPxButtonEdit runat="server" ID="SearchBox" Width="250" Height="25" NullText="Type to Search..." CssClass="SearchBox"
                ClientInstanceName="ClientSearchBox" Font-Size="12px">
                <ClientSideEvents
                    TextChanged="MailClient.ClientSearchBox_TextChanged"
                    KeyDown="MailClient.ClientSearchBox_KeyDown"
                    KeyPress="MailClient.ClientSearchBox_KeyPress" />
                <Buttons>
                    <dx:EditButton>
                        <Image>
                            <SpriteProperties CssClass="Sprite_Search"
                                HottrackedCssClass="Sprite_Search_Hover"
                                PressedCssClass="Sprite_Search_Pressed" />
                        </Image>
                    </dx:EditButton>
                </Buttons>
                <ButtonStyle CssClass="SearchBoxButton" />
                <NullTextStyle Font-Italic="true" />
            </dx:ASPxButtonEdit>
                 </div>
        </td>        
    </tr>
</table>
<asp:XmlDataSource ID="MainActionMenuDataSource" runat="server" DataFile="~/App_Data/MainActions.xml" />
<%--<asp:XmlDataSource ID="InfoMenuDataSource" runat="server" DataFile="~/App_Data/InfoLayout.xml" XPath="Items/Item" />--%>
