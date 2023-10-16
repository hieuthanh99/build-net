<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Roles.aspx.cs" Inherits="Admin_Roles" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script type="text/javascript">
        var postponedCallbackRequired = false;

        function ShowGrid() {
            CallbackPanel.SetVisible(true);
            GridRoles.SetVisible(true);
            MainMenu.SetVisible(true);
        }

        function HideGrid() {
            GridRoles.SetVisible(false);
            MainMenu.SetVisible(false);
            CallbackPanel.SetVisible(false);
        }

        function ShowEditForm() {
            RoleCallbackPanel.SetVisible(true);
            EditMenu.SetVisible(true);
        }

        function HideEditForm() {
            RoleCallbackPanel.SetVisible(false);
            EditMenu.SetVisible(false);
        }

        function OnInit(s, e) {
            AdjustSize();
        }
        function OnEndCallback(s, e) {
            AdjustSize();
        }

        function OnControlsInitialized(s, e) {
            HideEditForm();
            ShowGrid();
            ASPxClientUtils.AttachEventToElement(window, "resize", function (evt) {
                AdjustSize();
            });
        }
        function AdjustSize() {
            var height = Math.max(0, document.documentElement.clientHeight);
            //CallbackPanel.SetHeight(height);
            //GridRoles.SetHeight(height);
        }

        function Splitter_PaneResized(s, e) {
            if (e.pane.name == 'GridPane') {
                CallbackPanel.SetHeight(e.pane.GetClientHeight());
                GridRoles.SetHeight(e.pane.GetClientHeight());
            }
        }

        function RoleCallbackPanel_EndCallback(s, e) {
            var action = s.cp_action;
            if (action == "EDIT") {
                HideGrid();
                ShowEditForm();
                RoleName.GetInputElement().readOnly = true;
                RoleName.SetIsValid(true);
                RoleName.Focus();
            }
            else if (action == "SAVE") {
                HideEditForm();
                ShowGrid();
                GridRoles.Refresh();
            }
        }

        function MenuItemClick(e) {
            var name = e.item.name;
            if (name.toUpperCase() == "NEW") {
                RoleName.SetValue("");
                RoleName.SetIsValid(true);
                RoleName.GetInputElement().readOnly = false;
                Description.SetValue("");
                RoleName.Focus();
                HideGrid();
                ShowEditForm();
                hfAction.Set("ACTION", "NEW");
                e.processOnServer = false;
                return;
            }
            else if (name.toUpperCase() == "EDIT") {
                if (RoleCallbackPanel.InCallback()) {
                    e.processOnServer = false;
                    return;
                }
                else {
                    if (!GridRoles.IsDataRow(GridRoles.GetFocusedRowIndex())) {
                        e.processOnServer = false;
                        return;
                    }
                    var key = GridRoles.GetRowKey(GridRoles.GetFocusedRowIndex());
                    hfAction.Set("ACTION", "EDIT");
                    RoleCallbackPanel.PerformCallback('EDIT|' + key);
                }
                e.processOnServer = false;
                return;
            }
            else if (name.toUpperCase() == "DELETE") {
                var cf = confirm("<%= GetMessage("MSG-0015") %>");
                    if (cf) {
                        if (CallbackPanel.InCallback())
                            postponedCallbackRequired = true;
                        else {
                            if (!GridRoles.IsDataRow(GridRoles.GetFocusedRowIndex()))
                                return;
                            var key = GridRoles.GetRowKey(GridRoles.GetFocusedRowIndex());
                            CallbackPanel.PerformCallback('DELETE|' + key);
                        }
                    }
                    e.processOnServer = false;
                    return;
                }
                else if (name.toUpperCase() == "REFRESH") {
                    GridRoles.Refresh();
                    e.processOnServer = false;
                    return;
                } else if (name.toUpperCase() == "EXPORT") {
                    e.processOnServer = false;
                    return;
                }
        e.processOnServer = true;
    }

    function editMenuItemClick(e) {
        var name = e.item.name;
        if (name.toUpperCase() == "SAVE") {
            if (!ASPxClientEdit.ValidateEditorsInContainerById(roleFormLayout.name)) {
                e.processOnServer = false;
                return;
            }
            if (RoleCallbackPanel.InCallback()) {
                e.processOnServer = false;
                return;
            }
            else {
                RoleCallbackPanel.PerformCallback('SAVE|' + hfAction.Get("ACTION"));
            }
            e.processOnServer = false;
            return;
        }
        else if (name.toUpperCase() == "CANCEL") {
            HideEditForm();
            ShowGrid();
            e.processOnServer = false;
            return;
        }
        e.processOnServer = false;
    }

    function CallbackPanel_OnEndCallback(s, e) {
        if (postponedCallbackRequired) {
            postponedCallbackRequired = false;
        }
        GridRoles.Refresh();
    }
    </script>

    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="splitter" SeparatorVisible="false" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="Splitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="100" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="float: left">
                            <div class="title">
                                <asp:Literal ID="Literal1" runat="server" Text="Declare Role" />
                            </div>

                            <dx:ASPxMenu ID="mMain" runat="server" CssClass="main-menu" Theme="Moderno" OnItemClick="mMain_ItemClick" ClientVisible="false" ClientInstanceName="MainMenu">
                                <ClientSideEvents ItemClick="function(s, e) { MenuItemClick(e);}" />
                                <Items>
                                    <dx:MenuItem Name="New" Text="<%$Resources:Language, Add %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/add.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Edit" Text="<%$Resources:Language, Edit %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/edit.gif">
                                    </dx:MenuItem>
                                    <%-- <dx:MenuItem Name="EXPORT" Text="Export" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/export.png">
                                                <dx:MenuItem Name="Refresh" Text="<%$Resources:Language, Refresh %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/action_refresh.gif">
                                                </dx:MenuItem>
                                                    <Items>
                                                        <dx:MenuItem Name="PDF" Text="PDF" />
                                                        <dx:MenuItem Name="XLS" Text="XLS" />
                                                        <dx:MenuItem Name="XLSX" Text="XLSX" />
                                                        <dx:MenuItem Name="RTF" Text="RTF" />
                                                        <dx:MenuItem Name="CSV" Text="CSV" />
                                                    </Items>
                                                </dx:MenuItem>--%>
                                </Items>
                            </dx:ASPxMenu>

                            <dx:ASPxMenu ID="ASPxMenu2" runat="server" CssClass="main-menu" Theme="Moderno" ClientVisible="false" ClientInstanceName="EditMenu">
                                <ClientSideEvents ItemClick="function(s, e) { editMenuItemClick(e);}" />
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
            <dx:SplitterPane Name="GridPane">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <dx:ASPxGlobalEvents ID="ge" runat="server">
                            <ClientSideEvents ControlsInitialized="OnControlsInitialized" />
                        </dx:ASPxGlobalEvents>
                        <dx:ASPxCallbackPanel runat="server" ID="CallbackPanel" Height="100%" Width="100%" ClientInstanceName="CallbackPanel" RenderMode="Table" OnCallback="CallbackPanel_Callback">
                            <ClientSideEvents EndCallback="CallbackPanel_OnEndCallback"></ClientSideEvents>
                            <PanelCollection>
                                <dx:PanelContent ID="PanelContent1" runat="server">
                                    <dx:ASPxGridView ID="GridRoles" runat="server" AutoGenerateColumns="False" ClientInstanceName="GridRoles" Width="100%" KeyFieldName="RoleID" DataSourceID="RolesDataSource">
                                        <SettingsPager Visible="true" PageSize="50" />
                                        <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" ShowFilterRow="true" />
                                        <Paddings Padding="0px" />
                                        <Border BorderWidth="1px" />
                                        <BorderBottom BorderWidth="1px" />
                                        <SettingsBehavior AllowFocusedRow="True" ColumnResizeMode="Control" AllowSelectSingleRowOnly="True" />
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="RoleName" VisibleIndex="1" Caption="<%$Resources:Language, frmRoles_RoleName%>" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2" Caption="<%$Resources:Language, frmRoles_Description%>" Width="500" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <Styles>
                                            <AlternatingRow Enabled="true" />
                                        </Styles>
                                    </dx:ASPxGridView>
                                    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="GridRoles"></dx:ASPxGridViewExporter>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxCallbackPanel>
                        <dx:ASPxCallbackPanel ID="RoleCallbackPanel" runat="server" RenderMode="Div" Height="100%" ClientVisible="false" ClientInstanceName="RoleCallbackPanel" OnCallback="RoleCallbackPanel_Callback">
                            <ClientSideEvents EndCallback="RoleCallbackPanel_EndCallback" />
                            <PanelCollection>
                                <dx:PanelContent>
                                    <div class="formLayoutContainer">
                                        <dx:ASPxFormLayout ID="RoleFormLayout" runat="server" RequiredMarkDisplayMode="RequiredOnly" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="roleFormLayout"
                                            AlignItemCaptionsInAllGroups="true" Width="100%">
                                            <Items>
                                                <dx:LayoutGroup ShowCaption="False" GroupBoxDecoration="HeadingLine" SettingsItemCaptions-HorizontalAlign="Right" ColCount="2">
                                                    <Items>
                                                        <dx:LayoutItem Caption="<%$Resources:Language, frmRoles_RoleName%>" ColSpan="2">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxHiddenField ID="hfAction" runat="server" ClientInstanceName="hfAction"></dx:ASPxHiddenField>
                                                                    <dx:ASPxHiddenField ID="hfRoleId" runat="server"></dx:ASPxHiddenField>
                                                                    <dx:ASPxTextBox runat="server" ID="textboxRoleName" Width="170" ClientInstanceName="RoleName" MaxLength="255">
                                                                        <ValidationSettings ErrorDisplayMode="None" ValidateOnLeave="true" SetFocusOnError="true">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxTextBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="<%$Resources:Language, frmRoles_Description%>" ColSpan="2">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxMemo runat="server" ID="textboxDescription" Width="350" ClientInstanceName="Description" MaxLength="500" Rows="5">
                                                                    </dx:ASPxMemo>
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
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxCallbackPanel>

                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
    <dx:EntityServerModeDataSource ID="RolesDataSource" runat="server" OnSelecting="RolesDataSource_Selecting" />
</asp:Content>

