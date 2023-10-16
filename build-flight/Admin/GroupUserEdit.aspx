<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GroupUserEdit.aspx.cs" Inherits="Admin_GroupUserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <style type="text/css">
        .formLayoutContainer {
            width: 100%;
            margin: auto;
        }

        .layoutGroupBoxCaption {
            font-size: 16px;
        }
    </style>
    <script>
        function MenuItemClick(e) {
            var name = e.item.name;
            if (name.toUpperCase() == "SAVE") {
                var areEditorsValid = ASPxClientEdit.ValidateEditorsInContainerById(editGroupUserFormLayout.name);
                if (areEditorsValid) {
                    e.processOnServer = true;
                }
                else {
                    e.processOnServer = false;
                }
            }
            else {
                e.processOnServer = true;
            }
        }
    </script>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="splitter" SeparatorVisible="false" Orientation="Vertical" Width="100%" Height="100%">
        <Panes>
            <dx:SplitterPane Size="35" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="float: left">
                            <dx:ASPxMenu ID="mMain" runat="server" CssClass="main-menu" Theme="Moderno" OnItemClick="mMain_ItemClick">
                                <ClientSideEvents ItemClick="function(s, e) { MenuItemClick(e);}" />
                                <Items>
                                    <dx:MenuItem Name="Save" Text="<%$Resources:Language, Save %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/save.png">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Cancel" Text="<%$Resources:Language, Cancel %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/undo.png">
                                    </dx:MenuItem>
                                </Items>
                            </dx:ASPxMenu>
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
            <dx:SplitterPane>
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div class="alert-danger">
                            <asp:Literal ID="lbNotice" runat="server"></asp:Literal>
                        </div>
                        <div class="formLayoutContainer">
                            <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="editGroupUserFormLayout"
                                AlignItemCaptionsInAllGroups="true" Width="100%">
                                <Items>
                                    <dx:LayoutGroup Caption="<%$Resources:Language, frmGroupUserEdit_Caption %>" GroupBoxDecoration="HeadingLine" SettingsItemCaptions-HorizontalAlign="Right" ColCount="2">
                                        <Items>
                                            <dx:LayoutItem Caption="<%$Resources:Language, frmGroupUser_colGroupNumber %>" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox runat="server" ID="groupNumberTextBox" Width="170">
                                                            <ValidationSettings ErrorDisplayMode="None" ValidateOnLeave="true" SetFocusOnError="true">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="<%$Resources:Language, frmGroupUser_colGroupName %>">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="groupNameTextBox" runat="server" ClientInstanceName="groupNameTextBox" Width="170" ViewStateMode="Disabled">
                                                            <ValidationSettings ErrorDisplayMode="None" ValidateOnLeave="true" SetFocusOnError="true">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>

                                            <dx:LayoutItem Caption="<%$Resources:Language, frmGroupUser_colIsSystem %>" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxCheckBox ID="checkIsSystem" runat="server" ValueType="System.Boolean"></dx:ASPxCheckBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="<%$Resources:Language, frmGroupUser_colIsLocked %>" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxCheckBox ID="checkLocked" runat="server" ValueType="System.Boolean"></dx:ASPxCheckBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="Default">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxCheckBox ID="chkIsDefault" runat="server" ValueType="System.String" ValueChecked="Y" ValueUnchecked="N"></dx:ASPxCheckBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="<%$Resources:Language, frmGroupUser_colDescription %>" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox runat="server" ID="textboxDescription" Width="350">
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                        </Items>
                                    </dx:LayoutGroup>

                                </Items>
                            </dx:ASPxFormLayout>
                        </div>
                        <dx:ASPxPanel ID="dxpError" ClientInstanceName="dxpError" runat="server" CssClass="errorPanel"
                            ClientVisible="false">
                            <PanelCollection>
                                <dx:PanelContent>
                                    Please complete or correct the fields highlighted in red.
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxPanel>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
</asp:Content>

