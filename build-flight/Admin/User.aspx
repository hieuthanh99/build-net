<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="Admin_User" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script type="text/javascript">

        var PendingCallbacks = {};
        var loadingPanelTimer;
        var State = { View: "List" };

        function ChangeState(view, command, key) {
            var prev = State;
            var current = { View: view, Command: command, Key: key };

            State = current;
        }

        function DoCallback(sender, callback) {
            if (sender.InCallback()) {
                PendingCallbacks[sender.name] = callback;
                sender.EndCallback.RemoveHandler(DoEndCallback);
                sender.EndCallback.AddHandler(DoEndCallback);
            } else {
                callback();
            }
        }

        function DoEndCallback(s, e) {
            var pendingCallback = PendingCallbacks[s.name];
            if (pendingCallback) {
                pendingCallback();
                delete PendingCallbacks[s.name];
            }
        }

        function ShowLoadingPanel(element) {
            loadingPanelTimer = window.setTimeout(function () {
                ClientLoadingPanel.ShowInElement(element);
            }, 500);
        }

        function HideLoadingPanel() {
            if (loadingPanelTimer > -1) {
                window.clearTimeout(loadingPanelTimer);
                loadingPanelTimer = -1;
            }
            ClientLoadingPanel.Hide();
        }

        function PostponeAction(action, canExecute) {
            var f = function () {
                if (!canExecute())
                    window.setTimeout(f, 50);
                else
                    action();
            };
            f();
        }

        function OnInit(s, e) {
            AdjustSize();
        }

        function OnEndCallback(s, e) {
            AdjustSize();
        }

        function OnControlsInitialized(s, e) {
            ASPxClientUtils.AttachEventToElement(window, "resize", function (evt) {
                AdjustSize();
            });
            UpdateButtonState();
        }

        function AdjustSize() {
            var height = Math.max(0, document.documentElement.clientHeight);
        }

        function Splitter_PaneResized(s, e) {
            if (e.pane.name == 'GridPane') {
                ClientGridUsers.SetHeight(e.pane.GetClientHeight());
            }
            if (e.pane.name == 'CompanyGrid') {
                ClientCompanyTreeGrid.SetHeight(e.pane.GetClientHeight());
            }
        }

        function MenuItemClick(e) {
            var name = e.item.name;
            if (name.toUpperCase() == "DELETE") {
                var cf = confirm("<%= GetMessage("MSG-0015") %>");
                if (cf) {
                    var key = ClientGridUsers.GetRowKey(ClientGridUsers.GetFocusedRowIndex());
                    DoCallback(ClientGridUsers, function () {
                        ClientGridUsers.PerformCallback('DELETE|' + key);
                    });
                }
                e.processOnServer = false;
                return;
            }
            else if (name.toUpperCase() == "REFRESH") {
                //var key = ClientGridUsers.GetRowKey(ClientGridUsers.GetFocusedRowIndex());
                DoCallback(ClientGridUsers, function () {
                    ClientGridUsers.PerformCallback('REFRESH');
                });
                e.processOnServer = false;
                return;
            } else if (name.toUpperCase() == "EXPORT") {
                e.processOnServer = false;
                return;
            } else if (name.toUpperCase() == "NEW") {

                ChangeState("EditForm", name.toUpperCase(), "");
                ClientEditPopupControl.SetHeaderText("Add New User");
                //ClientEditPopupControl.Show();
                var state = State;
                ShowEditForm(state.Command, state.Key);
            } else if (name.toUpperCase() == "EDIT") {
                if (!ClientGridUsers.IsDataRow(ClientGridUsers.GetFocusedRowIndex()))
                    return;
                var key = ClientGridUsers.GetRowKey(ClientGridUsers.GetFocusedRowIndex());
                ChangeState("EditForm", name.toUpperCase(), key);
                ClientEditPopupControl.SetHeaderText("Edit User");
                //ClientEditPopupControl.Show();
                var state = State;
                ShowEditForm(state.Command, state.Key);
            }
            e.processOnServer = false;
        }


        function AddSelectedItems() {
            if (!ClientGridUsers.IsDataRow(ClientGridUsers.GetFocusedRowIndex()))
                return;
            var UserID = ClientGridUsers.GetRowKey(ClientGridUsers.GetFocusedRowIndex());
            var items = lbAvailable.GetSelectedItems();
            var valueStr = "";
            for (var i = items.length - 1; i >= 0; i = i - 1) {
                if (valueStr != null && valueStr != "")
                    valueStr = valueStr + ",";
                valueStr = valueStr + items[i].value;
            }

            DoCallback(ShutterCallbackPanel, function () {
                ShutterCallbackPanel.PerformCallback('ADD|' + UserID + '|' + valueStr);
            });

            MoveSelectedItems(lbAvailable, lbChoosen);
            UpdateButtonState();
        }

        function RemoveSelectedItems() {
            if (!ClientGridUsers.IsDataRow(ClientGridUsers.GetFocusedRowIndex()))
                return;
            var UserID = ClientGridUsers.GetRowKey(ClientGridUsers.GetFocusedRowIndex());
            var items = lbChoosen.GetSelectedItems();
            var valueStr = "";
            for (var i = items.length - 1; i >= 0; i = i - 1) {
                if (valueStr != null && valueStr != "")
                    valueStr = valueStr + ",";
                valueStr = valueStr + items[i].value;
            }

            DoCallback(ShutterCallbackPanel, function () {
                ShutterCallbackPanel.PerformCallback('REMOVE|' + UserID + '|' + valueStr);
            });

            MoveSelectedItems(lbChoosen, lbAvailable);
            UpdateButtonState();
        }

        function AddAllItems() {
            MoveAllItems(lbAvailable, lbChoosen);
            UpdateButtonState();
        }

        function RemoveAllItems() {
            MoveAllItems(lbChoosen, lbAvailable);
            UpdateButtonState();
        }


        function MoveSelectedItems(srcListBox, dstListBox) {
            srcListBox.BeginUpdate();
            dstListBox.BeginUpdate();
            var items = srcListBox.GetSelectedItems();
            for (var i = items.length - 1; i >= 0; i = i - 1) {
                dstListBox.AddItem(items[i].text, items[i].value);
                srcListBox.RemoveItem(items[i].index);
            }
            srcListBox.EndUpdate();
            dstListBox.EndUpdate();
        }
        function MoveAllItems(srcListBox, dstListBox) {
            srcListBox.BeginUpdate();
            var count = srcListBox.GetItemCount();
            for (var i = 0; i < count; i++) {
                var item = srcListBox.GetItem(i);
                dstListBox.AddItem(item.text, item.value);
            }
            srcListBox.EndUpdate();
            srcListBox.ClearItems();
        }
        function UpdateButtonState() {
            btnMoveSelectedItemsToRight.SetEnabled(lbAvailable.GetSelectedItems().length > 0);
            btnMoveSelectedItemsToLeft.SetEnabled(lbChoosen.GetSelectedItems().length > 0);
        }


        function LoadData(UserID) {

            ClientUserHiddenField.Set("UserID", UserID);
            LoadAvaialbleChosenGroup(UserID);

            DoCallback(CallbackPanel, function () {
                CallbackPanel.PerformCallback('LOAD|' + UserID);
            });

            ClientCompanyTreeGrid.PerformCustomCallback("LoadTree|" + UserID)
        }

        function btAdd_Click(s, e) {
            var role = Roles.GetValue();
            var UserID = ClientGridUsers.GetRowKey(ClientGridUsers.GetFocusedRowIndex());

            DoCallback(CallbackPanel, function () {
                CallbackPanel.PerformCallback('ADD_ROLE|' + UserID + "|" + role);
            });
        }

        function LoadAvaialbleChosenGroup(UserID) {
            if (UserID == null) return;

            DoCallback(ShutterCallbackPanel, function () {
                ShutterCallbackPanel.PerformCallback('LOAD|' + UserID);
            });
        }

        function GridRoles_CustomButtonClick(s, e) {
            if (e.buttonID != "cbDelete") return;
            var cf = confirm("<%= GetMessage("MSG-0015") %>");
            if (cf) {
                var role = s.GetRowKey(s.GetFocusedRowIndex());
                var UserID = ClientGridUsers.GetRowKey(ClientGridUsers.GetFocusedRowIndex());

                DoCallback(CallbackPanel, function () {
                    CallbackPanel.PerformCallback('DELETE_ROLE|' + UserID + "|" + role);
                });
            }
        }


        function btnSetPassword_Click(s, e) {
            if (!ClientGridUsers.IsDataRow(ClientGridUsers.GetFocusedRowIndex()))
                return;
            ClientPasswordEditor.SetValue("");
            ClientSetPasswrodPopup.Show();
        }

        function ClientSetPasswordPopupOkButton_Click(s, e) {
            if (!ClientGridUsers.IsDataRow(ClientGridUsers.GetFocusedRowIndex()))
                return;
            var key = ClientGridUsers.GetRowKey(ClientGridUsers.GetFocusedRowIndex());
            var args = "SETPASSWORD|" + key;

            DoCallback(ClientSetPasswordPanel, function () {
                ClientSetPasswordPanel.PerformCallback(args);
            });

        }

        function ClientSetPasswordPanel_EndCallback(s, e) {
            ClientSetPasswrodPopup.Hide();
        }

        function ClientSetPasswordCancelButton_Click(s, e) {
            ClientSetPasswrodPopup.Hide();
        }

        function ShowEditForm(command, key) {

            ClientFirstNameTextBox.SetValue("");
            ClientLastNameTextBox.SetValue("");
            ClientGenderRadioButtonList.SetValue(null);
            ClientCountryComboBox.SetValue("VN");
            ClientAddress.SetValue("");
            ClientTelephone.SetValue("");
            ClientMobile.SetValue("");
            ClientEmailTextBox.SetValue("");
            ClientCompanyComboBox.SetValue(null);
            ClientUserNameTextBox.SetValue("");
            ClientCheckChangePass.SetValue(false);
            ClientCheckIsSystem.SetValue(false);
            ClientCheckLocked.SetValue(false);

            if (command == "NEW") {
                ClientUserNameTextBox.GetInputElement().readOnly = false;
                ClientFirstNameTextBox.Focus();
                ClientEditPopupControl.Show();
            }
            else if (command == "EDIT") {
                ClientUserNameTextBox.GetInputElement().readOnly = true;
                ClientGridUsers.GetValuesOnCustomCallback("EditForm|" + command + "|" + key, function (values) {
                    var setValuesFunc = function () {
                        HideLoadingPanel();
                        if (!values)
                            return;

                        ClientFirstNameTextBox.SetValue(values["FirstName"]);
                        ClientLastNameTextBox.SetValue(values["LastName"]);
                        ClientGenderRadioButtonList.SetValue(values["Gender"]);
                        ClientCountryComboBox.SetValue(values["Country"]);
                        ClientAddress.SetValue(values["Address"]);
                        ClientTelephone.SetValue(values["Telephone"]);
                        ClientMobile.SetValue(values["Mobile"]);
                        ClientEmailTextBox.SetValue(values["Email"]);
                        ClientCompanyComboBox.SetValue(values["CompanyID"]);
                        ClientUserNameTextBox.SetValue(values["Username"]);
                        ClientCheckChangePass.SetValue(values["UpdatePassword"] == "TRUE" ? true : false);
                        ClientCheckIsSystem.SetValue(values["IsSuperUser"] == "TRUE" ? true : false);
                        ClientCheckLocked.SetValue(values["IsDeleted"] == "TRUE" ? true : false);

                        ClientFirstNameTextBox.Focus();
                        ClientEditPopupControl.Show();
                    };
                    PostponeAction(setValuesFunc, function () { return !!window.ClientFirstNameTextBox });
                });
                ShowLoadingPanel(splitter.GetMainElement());
            }
        }

        function ClientEditPopupControl_Shown(s, e) {


        }

        function ClientSaveButton_Click(s, e) {
            if (window.ClientFirstNameTextBox && !ASPxClientEdit.ValidateEditorsInContainerById("EditUserForm"))
                return;

            var state = State;
            var args = "SaveForm|" + state.Command + "|" + state.Key;
            ChangeState("SaveForm", state.Command, state.Key);
            DoCallback(ClientGridUsers, function () {
                ClientGridUsers.PerformCallback(args);
            });


        }

        function ClientGridUsers_EndCallback(s, e) {
            var state = State;
            if (state.View == "SaveForm" && (state.Command == "NEW" || state.Command == "EDIT")) {
                if (s.cpResult == "Success") {
                    ClientEditPopupControl.Hide();
                    ChangeState("List", "", "");
                }
                else {
                    alert(s.cpResult);
                }
            }
        }

        function ClientEditPopupControl_Closing(s, e) {
            ChangeState("List", "", "");
        }


        function btAddCompanyToUser_Click(s, e) {
            if (!ClientGridUsers.IsDataRow(ClientGridUsers.GetFocusedRowIndex()))
                return;
            var key = ClientGridUsers.GetRowKey(ClientGridUsers.GetFocusedRowIndex());
            var args = "ADDCOMPANY|" + key;

            DoCallback(ClientGridUsers, function () {
                ClientGridUsers.PerformCallback(args);
            });
        }
    </script>

    <dx:ASPxGlobalEvents ID="ge" runat="server">
        <ClientSideEvents ControlsInitialized="OnControlsInitialized" />
    </dx:ASPxGlobalEvents>

    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="splitter" SeparatorVisible="false" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="Splitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="100" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="float: left">
                            <div class="title">
                                <asp:Literal ID="Literal1" runat="server" Text="Declare User" />
                            </div>
                            <dx:ASPxMenu ID="mMain" runat="server" CssClass="main-menu" Theme="Moderno">
                                <ClientSideEvents ItemClick="function(s, e) { MenuItemClick(e);}" />
                                <Items>
                                    <dx:MenuItem Name="New" Text="<%$Resources:Language, Add %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/add.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Edit" Text="<%$Resources:Language, Edit %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/edit.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Delete" Text="<%$Resources:Language, Delete %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/delete.gif">
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
                <Panes>
                    <dx:SplitterPane>
                        <Panes>
                            <dx:SplitterPane>
                                <Panes>
                                    <dx:SplitterPane Name="GridPane">
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxGridView ID="gridUsers" runat="server" AutoGenerateColumns="False" EnableCallBacks="true"
                                                    OnCustomCallback="gridUsers_CustomCallback"
                                                    OnCustomDataCallback="gridUsers_CustomDataCallback"
                                                    OnCustomColumnDisplayText="gridUsers_CustomColumnDisplayText"
                                                    ClientInstanceName="ClientGridUsers" Width="100%" KeyFieldName="UserID">
                                                    <SettingsPager Visible="true" Mode="ShowPager" PageSize="50" />
                                                    <Settings VerticalScrollBarMode="Auto" HorizontalScrollBarMode="Auto" VerticalScrollBarStyle="Standard" ShowFilterRow="true" />
                                                    <Paddings Padding="0px" />
                                                    <Border BorderWidth="1px" />
                                                    <BorderBottom BorderWidth="1px" />
                                                    <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                                    <SettingsResizing ColumnResizeMode="Control" />
                                                    <ClientSideEvents FocusedRowChanged="function(s, e) { s.GetRowValues(s.GetFocusedRowIndex(), 'UserID', LoadData);}" EndCallback="ClientGridUsers_EndCallback" />
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="Username" VisibleIndex="1" Caption="<%$Resources:Language, frmUser_colUserName %>" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="FirstName" VisibleIndex="3" Caption="First Name" Width="120" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="LastName" VisibleIndex="4" Caption="Last Name" Width="120" HeaderStyle-HorizontalAlign="Center">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Email" VisibleIndex="5" Caption="Email" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="DisplayName" VisibleIndex="6" Caption="Display Name" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="CompanyName" VisibleIndex="7" Caption="Company" UnboundType="String" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataCheckColumn FieldName="UpdatePassword" VisibleIndex="8" Caption="Update Password" Width="120" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataCheckColumn>
                                                        <dx:GridViewDataCheckColumn FieldName="IsDeleted" VisibleIndex="9" Caption="<%$Resources:Language, frmUser_colIsLocked %>" Width="100" HeaderStyle-HorizontalAlign="Center">
                                                        </dx:GridViewDataCheckColumn>

                                                        <dx:GridViewDataColumn VisibleIndex="10" Width="110" HeaderStyle-HorizontalAlign="Center">
                                                            <DataItemTemplate>
                                                                <dx:ASPxButton ID="btnSetPassword" runat="server" Text="Set Password" AutoPostBack="false" CausesValidation="false" UseSubmitBehavior="false">
                                                                    <ClientSideEvents Click="btnSetPassword_Click" />
                                                                </dx:ASPxButton>
                                                            </DataItemTemplate>
                                                        </dx:GridViewDataColumn>
                                                    </Columns>
                                                    <Styles>
                                                        <AlternatingRow Enabled="true" />
                                                    </Styles>
                                                </dx:ASPxGridView>

                                            </dx:SplitterContentControl>
                                        </ContentCollection>
                                        <PaneStyle Border-BorderWidth="0">
                                            <BorderTop BorderWidth="0px"></BorderTop>
                                        </PaneStyle>
                                    </dx:SplitterPane>
                                    <dx:SplitterPane Size="400" Name="CompanyGrid" ScrollBars="Auto">
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxTreeList ID="CompanyTreeGrid" runat="server" ClientInstanceName="ClientCompanyTreeGrid" KeyFieldName="CompanyID" ParentFieldName="ParentID"
                                                    Settings-ShowColumnHeaders="true" Width="100%" Height="100%" OnHtmlRowPrepared="CompanyTreeGrid_HtmlRowPrepared" OnCustomCallback="CompanyTreeGrid_CustomCallback">
                                                    <SettingsSelection Enabled="true" AllowSelectAll="true" Recursive="true" />
                                                    <SettingsBehavior AllowFocusedNode="true" />
                                                    <Settings ScrollableHeight="500" VerticalScrollBarMode="Auto" />
                                                    <Columns>
                                                        <dx:TreeListTextColumn Name="NameV" FieldName="NameV" VisibleIndex="1" ReadOnly="true" Caption="Company">
                                                            <DataCellTemplate>
                                                                <asp:Label runat="server" Text='<%# Eval("AreaCode") +"-"+ Eval("NameV") %>'></asp:Label>
                                                            </DataCellTemplate>
                                                        </dx:TreeListTextColumn>
                                                        <dx:TreeListTextColumn Name="NameE" FieldName="NameE" VisibleIndex="2" ReadOnly="true" Caption=" " Visible="false"></dx:TreeListTextColumn>
                                                    </Columns>
                                                </dx:ASPxTreeList>
                                            </dx:SplitterContentControl>
                                        </ContentCollection>
                                        <PaneStyle Border-BorderWidth="0">
                                            <BorderTop BorderWidth="0px"></BorderTop>
                                        </PaneStyle>
                                    </dx:SplitterPane>
                                </Panes>
                            </dx:SplitterPane>

                            <dx:SplitterPane Size="250px">
                                <Panes>
                                    <dx:SplitterPane>
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxCallbackPanel runat="server" ID="ShutterCallbackPanel" ClientInstanceName="ShutterCallbackPanel" SettingsLoadingPanel-Enabled="false" RenderMode="Div" OnCallback="ShutterCallbackPanel_Callback">
                                                    <PanelCollection>
                                                        <dx:PanelContent ID="PanelContent2" runat="server">
                                                            <div style="text-align: center; width: 530px">
                                                                <table style="width: 100%" title="">
                                                                    <tr>
                                                                        <td style="width: 35%">
                                                                            <dx:ASPxListBox ID="lbAvailable" runat="server" ClientInstanceName="lbAvailable"
                                                                                Width="250px" Height="210px" SelectionMode="CheckColumn" Caption="<%$Resources:Language, frmUser_AvaiableGroup %>">
                                                                                <CaptionSettings Position="Top" />
                                                                                <ClientSideEvents SelectedIndexChanged="function(s, e) { UpdateButtonState(); }" />
                                                                            </dx:ASPxListBox>
                                                                        </td>
                                                                        <td style="padding: 60px 20px; width: 100px">
                                                                            <div>
                                                                                <dx:ASPxButton ID="btnMoveSelectedItemsToRight" runat="server" ClientInstanceName="btnMoveSelectedItemsToRight"
                                                                                    AutoPostBack="False" Text="<%$Resources:Language, MoveToRight %>" Width="130px" ClientEnabled="False"
                                                                                    ToolTip="Add selected items">
                                                                                    <ClientSideEvents Click="function(s, e) { AddSelectedItems(); }" />
                                                                                </dx:ASPxButton>
                                                                            </div>

                                                                            <div style="height: 32px">
                                                                            </div>
                                                                            <div>
                                                                                <dx:ASPxButton ID="btnMoveSelectedItemsToLeft" runat="server" ClientInstanceName="btnMoveSelectedItemsToLeft"
                                                                                    AutoPostBack="False" Text="<%$Resources:Language, MoveToLeft %>" Width="130px" ClientEnabled="False"
                                                                                    ToolTip="Remove selected items">
                                                                                    <ClientSideEvents Click="function(s, e) { RemoveSelectedItems(); }" />
                                                                                </dx:ASPxButton>
                                                                            </div>

                                                                        </td>
                                                                        <td style="width: 35%">
                                                                            <dx:ASPxListBox ID="lbChoosen" runat="server" ClientInstanceName="lbChoosen" Width="250px"
                                                                                Height="210px" SelectionMode="CheckColumn" Caption="<%$Resources:Language, frmUser_ChosenGroup %>">
                                                                                <CaptionSettings Position="Top" />
                                                                                <ClientSideEvents SelectedIndexChanged="function(s, e) { UpdateButtonState(); }"></ClientSideEvents>
                                                                            </dx:ASPxListBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </dx:PanelContent>
                                                    </PanelCollection>
                                                </dx:ASPxCallbackPanel>
                                            </dx:SplitterContentControl>
                                        </ContentCollection>
                                        <PaneStyle Border-BorderWidth="0">
                                            <BorderTop BorderWidth="0px"></BorderTop>
                                        </PaneStyle>
                                    </dx:SplitterPane>
                                    <dx:SplitterPane ScrollBars="Auto">
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxCallbackPanel runat="server" ID="CallbackPanel" Width="100%" ClientInstanceName="CallbackPanel" SettingsLoadingPanel-Enabled="false" RenderMode="Table" OnCallback="CallbackPanel_Callback">
                                                    <PanelCollection>
                                                        <dx:PanelContent ID="PanelContent1" runat="server">
                                                            <table style="width: 100%">
                                                                <tr>
                                                                    <td style="width: 50%">
                                                                        <dx:ASPxComboBox ID="cbRole" runat="server" Width="100%" ClientInstanceName="Roles" Caption="<%$Resources:Language, frmRoles_Roles%>" ValueField="RoleID" TextField="DESCRIPTION"></dx:ASPxComboBox>
                                                                    </td>
                                                                    <td>
                                                                        <div style="float: left; padding-top: 5px; padding-left: 5px;">
                                                                            <dx:ASPxButton ID="btAdd" runat="server" RenderMode="Link" Image-Url="~/Content/Images/action/add.gif" Text="<%$Resources:Language, btnAddRoleToUser%>" AutoPostBack="false">
                                                                                <ClientSideEvents Click="btAdd_Click" />
                                                                            </dx:ASPxButton>
                                                                        </div>
                                                                        <div style="float: right">
                                                                            <dx:ASPxButton ID="ASPxButton1" runat="server" RenderMode="Button" Text="Save Company To User" AutoPostBack="false">
                                                                                <ClientSideEvents Click="btAddCompanyToUser_Click" />
                                                                            </dx:ASPxButton>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <br />
                                                            <dx:ASPxGridView ID="GridRoles" runat="server" AutoGenerateColumns="False" ClientInstanceName="GridRoles" Width="100%" KeyFieldName="RoleID">
                                                                <SettingsPager Visible="true" PageSize="15" />
                                                                <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="165" VerticalScrollBarStyle="Standard" ShowFilterRow="false" />
                                                                <Paddings Padding="0px" />
                                                                <Border BorderWidth="1px" />
                                                                <BorderBottom BorderWidth="1px" />
                                                                <SettingsBehavior AllowFocusedRow="True" ColumnResizeMode="Control" AllowSelectSingleRowOnly="True" />
                                                                <ClientSideEvents CustomButtonClick="GridRoles_CustomButtonClick" />
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn FieldName="RoleName" VisibleIndex="1" Caption="<%$Resources:Language, frmRoles_RoleName%>" Width="20%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2" Caption="<%$Resources:Language, frmRoles_Description%>" Width="65%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewCommandColumn VisibleIndex="3" Width="15%" ButtonType="Image" ShowSelectCheckbox="false" ShowEditButton="false" ShowNewButton="false" ShowUpdateButton="false" Caption="Delete" HeaderStyle-HorizontalAlign="Center">
                                                                        <CustomButtons>
                                                                            <dx:GridViewCommandColumnCustomButton ID="cbDelete" Text="<%$Resources:Language, Delete %>">
                                                                                <Image Url="../Content/Images/action/delete.gif"></Image>
                                                                            </dx:GridViewCommandColumnCustomButton>
                                                                        </CustomButtons>
                                                                    </dx:GridViewCommandColumn>
                                                                </Columns>
                                                                <Styles>
                                                                    <AlternatingRow Enabled="true" />
                                                                </Styles>
                                                            </dx:ASPxGridView>
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
                            </dx:SplitterPane>
                        </Panes>
                    </dx:SplitterPane>
                </Panes>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="gridUsers"></dx:ASPxGridViewExporter>
    <dx:ASPxCallbackPanel ID="SetPasswordPanelPanel" runat="server" RenderMode="Div" Height="100%" CssClass="MailPreviewPanel" ClientInstanceName="ClientSetPasswordPanel"
        OnCallback="SetPasswordPanelPanel_Callback" SettingsLoadingPanel-Enabled="true">
        <ClientSideEvents EndCallback="ClientSetPasswordPanel_EndCallback" />
        <PanelCollection>
            <dx:PanelContent>
                <dx:ASPxPopupControl runat="server" ID="SetPasswrodPopup" ClientInstanceName="ClientSetPasswrodPopup"
                    Width="300" Height="150" AllowDragging="True" HeaderText="Set password" ShowFooter="True"
                    Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
                    PopupAnimationType="Fade">
                    <ContentCollection>
                        <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                            <div>
                                <table style="width: 100%; border-spacing: 0">
                                    <tr>
                                        <td style="height: 12px" colspan="2"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%; text-align: right;">
                                            <dx:ASPxLabel ID="PasswordLabel" runat="server" Text="Password: " AssociatedControlID="PasswordEditor" />
                                        </td>
                                        <td style="width: 75%; text-align: left; padding-left: 8px;">
                                            <dx:ASPxTextBox ID="PasswordEditor" runat="server" Width="90%" Height="25" Password="true" ClientInstanceName="ClientPasswordEditor">
                                                <ValidationSettings SetFocusOnError="True" ValidateOnLeave="true" Display="Dynamic">
                                                    <RequiredField IsRequired="True" ErrorText="Password is required" />
                                                </ValidationSettings>
                                                <Paddings PaddingTop="2" PaddingLeft="8" PaddingRight="8" />
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>

                                </table>
                            </div>
                        </dx:PopupControlContentControl>
                    </ContentCollection>
                    <ContentStyle>
                        <Paddings Padding="0" />
                    </ContentStyle>
                    <FooterTemplate>
                        <dx:ASPxButton runat="server" ID="SetPasswordCancelButton" CssClass="AddressBookPopupButton" AutoPostBack="False" Text="Cancel" CausesValidation="false" UseSubmitBehavior="false">
                            <ClientSideEvents Click="ClientSetPasswordCancelButton_Click" />
                        </dx:ASPxButton>
                        <dx:ASPxButton runat="server" ID="SetPasswordPopupOkButton" CssClass="AddressBookPopupButton" AutoPostBack="False" Text="Ok" CausesValidation="false" UseSubmitBehavior="false">
                            <ClientSideEvents Click="ClientSetPasswordPopupOkButton_Click" />
                        </dx:ASPxButton>
                        <div class="clear"></div>
                    </FooterTemplate>
                </dx:ASPxPopupControl>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
    <dx:ASPxPopupControl ID="EditPopupControl" runat="server" Width="400" Height="300" AllowDragging="True" HeaderText="" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientEditPopupControl" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditUserForm" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientEditUserForm"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutGroup Caption="<%$Resources:Language, frmUserEdit_Registration %>" GroupBoxDecoration="HeadingLine" SettingsItemCaptions-HorizontalAlign="Right" ColCount="2">
                            <Items>
                                <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_Name %>" ColSpan="2" HelpTextSettings-HorizontalAlign="Right">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <table>
                                                <tr>
                                                    <td style="padding-right: 5px;">
                                                        <dx:ASPxTextBox ID="firstNameTextBox" runat="server" NullText="First Name" Width="170" ClientInstanceName="ClientFirstNameTextBox">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                    <td>
                                                        <dx:ASPxTextBox ID="lastNameTextBox" runat="server" NullText="Last Name" Width="170" ClientInstanceName="ClientLastNameTextBox">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_Gender %>" ColSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxRadioButtonList ID="genderRadioButtonList" runat="server" RepeatDirection="Horizontal" ClientInstanceName="ClientGenderRadioButtonList">
                                                <Items>
                                                    <dx:ListEditItem Text="<%$Resources:Language, frmUserEdit_GenderMale %>" Value="1" />
                                                    <dx:ListEditItem Text="<%$Resources:Language, frmUserEdit_GenderFemale %>" Value="2" />
                                                </Items>
                                                <Border BorderStyle="None" />
                                            </dx:ASPxRadioButtonList>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_Country %>" ColSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox runat="server" ID="countryComboBox" DropDownStyle="DropDownList" IncrementalFilteringMode="StartsWith"
                                                TextField="CountryName" ValueField="CountryName" ClientInstanceName="ClientCountryComboBox" OnInit="countryComboBox_Init" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_Address %>" ColSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox runat="server" ID="address" NullText="Address" Width="375" ClientInstanceName="ClientAddress" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_Telephone %>" ColSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox runat="server" ID="telephone" NullText="Telephone" Width="170" ClientInstanceName="ClientTelephone" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_Mobile %>" ColSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox runat="server" ID="mobile" NullText="Mobile" Width="170" ClientInstanceName="ClientMobile" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_Email %>" ColSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox runat="server" ID="eMailTextBox" Width="100%" ClientInstanceName="ClientEmailTextBox">
                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                    <RegularExpression ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>

                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>

                        </dx:LayoutGroup>
                        <dx:LayoutGroup Caption="<%$Resources:Language, frmUserEdit_Authorization %>" GroupBoxDecoration="HeadingLine" SettingsItemCaptions-HorizontalAlign="Right" ColCount="2">
                            <Items>
                                <dx:LayoutItem Caption="Company" ColSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox runat="server" ID="CompanyComboBox" Width="100%" ClientInstanceName="ClientCompanyComboBox" OnInit="CompanyComboBox_Init">
                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_UserName %>" ColSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox runat="server" ID="userNameTextBox" Width="100%" ClientInstanceName="ClientUserNameTextBox">
                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <%--<dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_Password %>">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="passwordTextBox" runat="server" ClientInstanceName="passwordTextBox" Password="true" Width="170" ViewStateMode="Disabled" AutoCompleteType="Disabled">
                                                            <ValidationSettings ErrorDisplayMode="None" ValidateOnLeave="true" SetFocusOnError="true">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                            <ClientSideEvents Init="OnPasswordTextBoxInit" KeyUp="OnPassChanged" Validation="OnPassValidation" />
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>--%>

                                <%--   <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_StartDate %>" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxDateEdit ID="dateStartDate" runat="server" Width="100">
                                                            <ValidationSettings ErrorDisplayMode="None" ValidateOnLeave="true" SetFocusOnError="true">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                        </dx:ASPxDateEdit>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_ExpiryDate %>" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxDateEdit ID="dateExpiryDate" runat="server" Width="100"></dx:ASPxDateEdit>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>--%>
                                <dx:LayoutItem Caption="Update Password" ColSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="checkChangePass" runat="server" ClientInstanceName="ClientCheckChangePass" ValueType="System.String" ValueChecked="Y" ValueUnchecked="N">
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_HostUser %>" ColSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="checkIsSystem" runat="server" ClientInstanceName="ClientCheckIsSystem" ValueType="System.String" ValueChecked="Y" ValueUnchecked="N"></dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_IsLocked %>" ColSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="checkLocked" runat="server" ClientInstanceName="ClientCheckLocked" ValueType="System.String" ValueChecked="Y" ValueUnchecked="N"></dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                            <SettingsItemCaptions HorizontalAlign="Right"></SettingsItemCaptions>
                        </dx:LayoutGroup>
                    </Items>
                    <Styles>
                        <LayoutGroupBox>
                            <Caption CssClass="layoutGroupBoxCaption"></Caption>
                        </LayoutGroupBox>
                    </Styles>
                </dx:ASPxFormLayout>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Hủy bỏ" AutoPostBack="false" ClientInstanceName="ClientCancelButton">
                <ClientSideEvents Click="function(s, e) {{ ASPxClientEdit.ClearEditorsInContainerById('EditUserForm'); ChangeState('List', '', '');  ClientEditPopupControl.Hide();}}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnSave" runat="server" Text="Lưu" AutoPostBack="false" ClientInstanceName="ClientSaveButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="ClientSaveButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="ClientEditPopupControl_Shown" Closing="ClientEditPopupControl_Closing" />
    </dx:ASPxPopupControl>


    <dx:ASPxHiddenField ID="UserHiddenField" runat="server" ClientInstanceName="ClientUserHiddenField"></dx:ASPxHiddenField>
</asp:Content>

