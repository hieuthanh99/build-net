<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GroupUser.aspx.cs" Inherits="Admin_GroupUser" %>


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
        }

        function AdjustSize() {
            var height = Math.max(0, document.documentElement.clientHeight);
        }

        function Splitter_PaneResized(s, e) {
            if (e.pane.name == 'GridPane') {
                ClientGroupUsers.SetHeight(e.pane.GetClientHeight());
            }
        }

        function MenuItemClick(e) {
            var name = e.item.name;
            if (name.toUpperCase() == "DELETE") {
                var cf = confirm("<%= GetMessage("MSG-0015") %>");
                if (!cf) {
                    return;
                }
                var GroupId = ClientGroupUsers.GetRowKey(ClientGroupUsers.GetFocusedRowIndex());

                DoCallback(ClientGroupUsers, function () {
                    ClientGroupUsers.PerformCallback(name.toUpperCase() + "|" + GroupId);
                });
                return;
            } else if (name.toUpperCase() == "REFRESH") {
                DoCallback(ClientGroupUsers, function () {
                    ClientGroupUsers.PerformCallback(name.toUpperCase());
                });
                return;
            } else if (name.toUpperCase() == "EXPORT") {
                return;
            } else if (name.toUpperCase() == "NEW") {
                ChangeState("EditForm", name.toUpperCase(), "");
                ClientEditPopupControl.SetHeaderText("Add New Group");
                var state = State;
                ShowEditForm(state.Command, state.Key);
            } else if (name.toUpperCase() == "EDIT") {
                var key = ClientGroupUsers.GetRowKey(ClientGroupUsers.GetFocusedRowIndex());
                ChangeState("EditForm", name.toUpperCase(), key);
                ClientEditPopupControl.SetHeaderText("Edit Group");
                var state = State;
                ShowEditForm(state.Command, state.Key);
            }
            e.processOnServer = false;
        }

        function AddSelectedItems() {
            if (!ClientGroupUsers.IsDataRow(ClientGroupUsers.GetFocusedRowIndex()))
                return;
            var GroupId = ClientGroupUsers.GetRowKey(ClientGroupUsers.GetFocusedRowIndex());
            var items = lbAvailable.GetSelectedItems();
            var valueStr = "";
            for (var i = items.length - 1; i >= 0; i = i - 1) {
                if (valueStr != null && valueStr != "")
                    valueStr = valueStr + ",";
                valueStr = valueStr + items[i].value;
            }

            DoCallback(ShutterCallbackPanel, function () {
                ShutterCallbackPanel.PerformCallback('ADD|' + GroupId + '|' + valueStr);
            });

            MoveSelectedItems(lbAvailable, lbChoosen);
            UpdateButtonState();
        }

        function RemoveSelectedItems() {
            if (!ClientGroupUsers.IsDataRow(ClientGroupUsers.GetFocusedRowIndex()))
                return;
            var GroupId = ClientGroupUsers.GetRowKey(ClientGroupUsers.GetFocusedRowIndex());
            var items = lbChoosen.GetSelectedItems();
            var valueStr = "";
            for (var i = items.length - 1; i >= 0; i = i - 1) {
                if (valueStr != null && valueStr != "")
                    valueStr = valueStr + ",";
                valueStr = valueStr + items[i].value;
            }

            DoCallback(ShutterCallbackPanel, function () {
                ShutterCallbackPanel.PerformCallback('REMOVE|' + GroupId + '|' + valueStr);
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

        function LoadAvaialbleChosenUser(pGroupId) {

            if (pGroupId == null) return;

            ClientGroupHiddenField.Set("GroupID", pGroupId);
            DoCallback(ShutterCallbackPanel, function () {
                ShutterCallbackPanel.PerformCallback('LOAD|' + pGroupId);
            });

            //DoCallback(CallbackPanel, function () {
            //    CallbackPanel.PerformCallback(pGroupId);
            //});

            treeList.PerformCustomCallback("LoadTree|" + pGroupId)

        }

        function ClientApply_Click(s, e) {
            treeList.PerformCustomCallback("SaveTree")
        }

        function ShowEditForm(command, key) {

            ClientApplication.SetValue(null);
            ClientGroupNumberTextBox.SetValue("");
            ClientGroupNameTextBox.SetValue("");
            ClientDescriptionTextBox.SetValue("");
            ClientCheckIsSystem.SetValue(false);
            ClientCheckLocked.SetValue(false);
            ClientIsDefault.SetValue(false);

            if (command == "NEW") {
                ClientGroupNumberTextBox.GetInputElement().readOnly = false;
                ClientGroupNumberTextBox.Focus();
                ClientEditPopupControl.Show();
            }
            else if (command == "EDIT") {
                ClientGroupNumberTextBox.GetInputElement().readOnly = true;
                ClientGroupUsers.GetValuesOnCustomCallback("EditForm|" + command + "|" + key, function (values) {
                    var setValuesFunc = function () {
                        HideLoadingPanel();
                        if (!values)
                            return;

                        ClientGroupNumberTextBox.SetValue(values["GroupNumber"]);
                        ClientApplication.SetValue(values["AppCode"]);
                        ClientGroupNameTextBox.SetValue(values["GroupName"]);
                        ClientDescriptionTextBox.SetValue(values["Description"]);
                        ClientCheckIsSystem.SetValue(values["IsSystem"] == "TRUE" ? true : false);
                        ClientCheckLocked.SetValue(values["IsLocked"] == "TRUE" ? true : false);
                        ClientIsDefault.SetValue(values["IsDefault"] == "TRUE" ? true : false);
                        ClientGroupNameTextBox.Focus();
                        ClientEditPopupControl.Show();
                    };
                    PostponeAction(setValuesFunc, function () { return !!window.ClientGroupNumberTextBox });
                });
                ShowLoadingPanel(splitter.GetMainElement());
            }
        }

        function ClientEditPopupControl_Shown(s, e) {

        }

        function ClientSaveButton_Click(s, e) {
            if (window.ClientGroupNumberTextBox && !ASPxClientEdit.ValidateEditorsInContainerById("EditGroupUserForm"))
                return;

            var state = State;
            var args = "SaveForm|" + state.Command + "|" + state.Key;
            var key = state.Key;
            ChangeState("SaveForm", state.Command, state.Key);
            DoCallback(ClientGroupUsers, function () {
                ClientGroupUsers.PerformCallback(args);
            });

        }

        function ClientGroupUsers_EndCallback(s, e) {
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

    </script>

    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="splitter" SeparatorVisible="false" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="Splitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="100" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="float: left">
                            <div class="title">
                                <asp:Literal ID="Literal1" runat="server" Text="Declare Group User" />
                            </div>
                            <dx:ASPxMenu ID="mMain" runat="server" Theme="Moderno" CssClass="main-menu">
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
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <dx:ASPxSplitter ID="ASPxSplitter1" runat="server" Orientation="Horizontal" ClientInstanceName="groupSplitter" ResizingMode="Live" Width="100%" Height="100%">
                            <ClientSideEvents PaneResized="Splitter_PaneResized" />
                            <Panes>
                                <dx:SplitterPane>
                                    <Panes>
                                        <dx:SplitterPane Name="GridPane">
                                            <ContentCollection>
                                                <dx:SplitterContentControl>

                                                    <dx:ASPxGridView ID="gridGroupUsers" runat="server" AutoGenerateColumns="False"
                                                        ClientInstanceName="ClientGroupUsers" Width="100%" KeyFieldName="GroupID" EnableCallBacks="true" OnCustomCallback="gridGroupUsers_CustomCallback" OnCustomDataCallback="gridGroupUsers_CustomDataCallback">
                                                        <SettingsPager Visible="true" PageSize="15" />
                                                        <Settings VerticalScrollBarMode="Auto" HorizontalScrollBarMode="Auto" VerticalScrollBarStyle="Standard" ShowFilterRow="true" />
                                                        <Paddings Padding="0px" />
                                                        <Border BorderWidth="1px" />
                                                        <BorderBottom BorderWidth="1px" />
                                                        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                                        <SettingsResizing ColumnResizeMode="Control" />
                                                        <SettingsBehavior AllowFocusedRow="True" ColumnResizeMode="Control" AllowSelectSingleRowOnly="True" />

                                                        <ClientSideEvents FocusedRowChanged="function(s, e) { 
                                                             s.GetRowValues(s.GetFocusedRowIndex(), 'GroupID', LoadAvaialbleChosenUser);  
                                                         }"
                                                            EndCallback="ClientGroupUsers_EndCallback" />
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn FieldName="GroupNumber" VisibleIndex="0" Caption="<%$Resources:Language, frmGroupUser_colGroupNumber%>" Width="15%" Settings-AutoFilterCondition="Contains">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="AppCode" VisibleIndex="1" Caption="Application" Width="10%" Settings-AutoFilterCondition="Contains">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="GroupName" VisibleIndex="2" Caption="<%$Resources:Language, frmGroupUser_colGroupName%>" Width="20%" Settings-AutoFilterCondition="Contains">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="3" Caption="<%$Resources:Language, frmGroupUser_colDescription%>" Width="35%" Settings-AutoFilterCondition="Contains">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataCheckColumn FieldName="IsSystem" VisibleIndex="7" Caption="<%$Resources:Language, frmGroupUser_colIsSystem%>" Width="10%" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                                                <PropertiesCheckEdit ValueChecked="Y" ValueUnchecked="N" ValueGrayed="" ValueType="System.String"></PropertiesCheckEdit>
                                                            </dx:GridViewDataCheckColumn>
                                                            <dx:GridViewDataCheckColumn FieldName="IsLocked" VisibleIndex="8" Caption="<%$Resources:Language, frmGroupUser_colIsLocked%>" Width="10%" HeaderStyle-HorizontalAlign="Center">
                                                                <PropertiesCheckEdit ValueChecked="Y" ValueUnchecked="N" ValueGrayed="" ValueType="System.String"></PropertiesCheckEdit>
                                                            </dx:GridViewDataCheckColumn>
                                                            <dx:GridViewDataCheckColumn FieldName="IsDefault" VisibleIndex="9" Caption="Default" Width="100" HeaderStyle-HorizontalAlign="Center">
                                                            </dx:GridViewDataCheckColumn>
                                                        </Columns>
                                                        <Styles>
                                                            <AlternatingRow Enabled="true" />
                                                        </Styles>
                                                    </dx:ASPxGridView>
                                                    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="gridGroupUsers"></dx:ASPxGridViewExporter>

                                                </dx:SplitterContentControl>
                                            </ContentCollection>
                                        </dx:SplitterPane>
                                        <dx:SplitterPane Size="250px">
                                            <ContentCollection>
                                                <dx:SplitterContentControl>
                                                    <div style="text-align: center; width: 100%">
                                                        <dx:ASPxCallbackPanel runat="server" ID="ShutterCallbackPanel" ClientInstanceName="ShutterCallbackPanel" RenderMode="Div" OnCallback="ShutterCallbackPanel_Callback">
                                                            <PanelCollection>
                                                                <dx:PanelContent ID="PanelContent2" runat="server">
                                                                    <table style="width: 100%" title="">
                                                                        <tr>
                                                                            <td style="width: 35%">
                                                                                <dx:ASPxListBox ID="lbAvailable" runat="server" ClientInstanceName="lbAvailable"
                                                                                    Width="100%" Height="200px" SelectionMode="CheckColumn" Caption="<%$Resources:Language, frmGroupUser_AvaiableUser%>">
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
                                                                                <dx:ASPxListBox ID="lbChoosen" runat="server" ClientInstanceName="lbChoosen" Width="100%"
                                                                                    Height="200px" SelectionMode="CheckColumn" Caption="<%$Resources:Language, frmGroupUser_ChosenUser%>">
                                                                                    <CaptionSettings Position="Top" />
                                                                                    <ClientSideEvents SelectedIndexChanged="function(s, e) { UpdateButtonState(); }"></ClientSideEvents>
                                                                                </dx:ASPxListBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </dx:PanelContent>
                                                            </PanelCollection>
                                                        </dx:ASPxCallbackPanel>
                                                    </div>
                                                </dx:SplitterContentControl>
                                            </ContentCollection>
                                        </dx:SplitterPane>
                                    </Panes>
                                </dx:SplitterPane>
                                <dx:SplitterPane Size="350px" ScrollBars="Auto" Name="MenuPane">
                                    <ContentCollection>
                                        <dx:SplitterContentControl>
                                            <%-- <dx:ASPxCallbackPanel runat="server" ID="ASPxCallbackPanel1" ClientInstanceName="CallbackPanel" RenderMode="Table" OnCallback="ASPxCallbackPanel1_Callback">
                                                <PanelCollection>
                                                    <dx:PanelContent ID="PanelContent3" runat="server">--%>
                                            <dx:ASPxTreeList ID="treeList" ClientInstanceName="treeList" runat="server" KeyFieldName="MenuID" ParentFieldName="ParentMenuID"
                                                OnDataBound="treeList_DataBound" Settings-ShowColumnHeaders="true"
                                                OnCustomCallback="treeList_CustomCallback">
                                                <SettingsSelection Enabled="true" AllowSelectAll="true" />
                                                <SettingsBehavior AllowFocusedNode="true" />
                                                <Columns>
                                                    <dx:TreeListTextColumn Name="NameVN" FieldName="NameVN" VisibleIndex="1" ReadOnly="true" Caption=" "></dx:TreeListTextColumn>
                                                    <dx:TreeListTextColumn Name="NameEN" FieldName="NameEN" VisibleIndex="2" ReadOnly="true" Caption=" " Visible="false"></dx:TreeListTextColumn>
                                                </Columns>
                                            </dx:ASPxTreeList>
                                            <div style="height: 5px">
                                            </div>
                                            <dx:ASPxButton ID="btnApply" runat="server" Text="<%$Resources:Language, frmGroupUser_btnApply%>" AutoPostBack="false" UseSubmitBehavior="true">
                                                <ClientSideEvents Click="ClientApply_Click" />
                                            </dx:ASPxButton>
                                            <%--  </dx:PanelContent>
                                                </PanelCollection>
                                            </dx:ASPxCallbackPanel>--%>
                                        </dx:SplitterContentControl>
                                    </ContentCollection>
                                </dx:SplitterPane>
                            </Panes>
                        </dx:ASPxSplitter>

                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>

    <dx:ASPxPopupControl ID="EditPopupControl" runat="server" Width="400" Height="300" AllowDragging="True" HeaderText="" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientEditPopupControl" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditGroupUserForm" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientEditGroupUserForm"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutGroup Caption="<%$Resources:Language, frmGroupUserEdit_Caption %>" ShowCaption="False" GroupBoxDecoration="HeadingLine" SettingsItemCaptions-HorizontalAlign="Right" ColCount="2">
                            <Items>
                                <dx:LayoutItem Caption="<%$Resources:Language, frmGroupUser_colGroupNumber %>" ColSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox runat="server" ID="groupNumberTextBox" Width="170" ClientInstanceName="ClientGroupNumberTextBox">
                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="<%$Resources:Language, frmGroupUser_colGroupName %>">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="groupNameTextBox" runat="server" ClientInstanceName="ClientGroupNameTextBox" Width="170" ViewStateMode="Disabled">
                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Application" ColSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox ID="cboApplication" runat="server" ClientInstanceName="ClientApplication" Width="170" OnInit="cboApplication_Init">
                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="<%$Resources:Language, frmGroupUser_colIsSystem %>" ColSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="checkIsSystem" runat="server" ValueType="System.Boolean" ClientInstanceName="ClientCheckIsSystem"></dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="<%$Resources:Language, frmGroupUser_colIsLocked %>" ColSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="checkLocked" runat="server" ValueType="System.Boolean" ClientInstanceName="ClientCheckLocked"></dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Default">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chkIsDefault" runat="server" ValueType="System.Boolean" ClientInstanceName="ClientIsDefault"></dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="<%$Resources:Language, frmGroupUser_colDescription %>" ColSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox runat="server" ID="textboxDescription" Width="350" ClientInstanceName="ClientDescriptionTextBox">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                </dx:ASPxFormLayout>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Hủy bỏ" AutoPostBack="false" ClientInstanceName="ClientCancelButton">
                <ClientSideEvents Click="function(s, e) {{ ASPxClientEdit.ClearEditorsInContainerById('EditGroupUserForm');  ChangeState('List', '', '');  ClientEditPopupControl.Hide();}}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnSave" runat="server" Text="Lưu" AutoPostBack="false" ClientInstanceName="ClientSaveButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="ClientSaveButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="ClientEditPopupControl_Shown" Closing="ClientEditPopupControl_Closing" />
    </dx:ASPxPopupControl>
    <dx:ASPxHiddenField ID="GroupHiddenField" runat="server" ClientInstanceName="ClientGroupHiddenField"></dx:ASPxHiddenField>
    <dx:ASPxLoadingPanel ID="LoadingPanel" ContainerElementID="gridGroupUsers" runat="server" ClientInstanceName="LoadingPanel" Modal="false">
    </dx:ASPxLoadingPanel>
</asp:Content>

