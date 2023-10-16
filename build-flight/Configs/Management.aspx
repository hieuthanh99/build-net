<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Management.aspx.cs" Inherits="Pages_Management" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/Common.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../signalr/hubs"></script>
    <script type="text/javascript">

        function ClientSplitter_PaneResized(s, e) {
            if (e.pane.name == "GridPane") {
                ClientDataGrid.SetHeight(e.pane.GetClientHeight());
            }
        }


        function ClientMenu_ItemClick(e) {
            var name = e.item.name;
            if (name.toUpperCase() == "DELETE") {
                var cf = confirm("<%= GetMessage("MSG-0015") %>");
                if (cf) {
                    var key = ClientDataGrid.GetFocusedNodeKey();
                    DoCallback(ClientDataGrid, function () {
                        ClientDataGrid.PerformCallback('DELETE|' + key);
                    });
                }
                e.processOnServer = false;
                return;
            } else if (name.toUpperCase() == "NEW") {
                ChangeState("EditForm", name.toUpperCase(), "");
                ClientEditPopupControl.SetHeaderText("Thêm mới");
                var state = State;
                ShowEditForm(state.Command, state.Key);
            } else if (name.toUpperCase() == "EDIT") {
                var key = ClientDataGrid.GetFocusedNodeKey();
                ChangeState("EditForm", name.toUpperCase(), key);
                ClientEditPopupControl.SetHeaderText("Cập nhật");
                var state = State;
                ShowEditForm(state.Command, state.Key);
            } else if (name.toUpperCase() == "SYNCDATA") {
                var cf = confirm("Bạn chắc chắn muốn đồng bộ dữ liệu từ PMS không?");
                if (cf) {
                    DoCallback(ClientDataGrid, function () {
                        ClientDataGrid.PerformCallback('SYNC_DATA');
                    });
                }
                e.processOnServer = false;
                return;
            }
            e.processOnServer = false;
        }

        function ClientDataGrid_NodeDblClick(s, e) {
            var key = ClientDataGrid.GetFocusedNodeKey();
            ChangeState("EditForm", "EDIT", key);
            ClientEditPopupControl.SetHeaderText("Cập nhật");
            var state = State;
            ShowEditForm(state.Command, state.Key);
        }

        function ShowEditForm(command, key) {
            ClientParentEditor.SetValue(null);
            ClientShortNameEditor.SetValue("");
            ClientNameVNEditor.SetValue("");
            ClientNameENEditor.SetValue("");
            ClientValidFromEditor.SetValue(null);
            ClientValidToEditor.SetValue(null);
            ClientActivityEditor.SetValue(null);
            ClientSeqEditor.SetValue(0);
            ClientNoteEditor.SetValue("");

            ShowLoadingPanel(ClientSplitter.GetMainElement());
            DoCallback(ClientParentEditor, function () {
                ClientParentEditor.PerformCallback('');
            });

        }

        function ClientParentEditor_EndCallback(s, e) {
            var command = State.Command;
            if (command == "NEW") {
                HideLoadingPanel();
                ClientShortNameEditor.Focus();
                if (!ClientEditPopupControl.IsVisible())
                    ClientEditPopupControl.Show();
            }
            else if (command == "EDIT") {
                var key = State.Key;
                ClientDataGrid.PerformCustomDataCallback(key);
            }
        }

        function ClientDataGrid_CustomDataCallback(s, e) {
            HideLoadingPanel();
            var values = e.result;
            if (!values)
                return;

            ClientParentEditor.SetValue(values["ParentID"]);
            ClientShortNameEditor.SetValue(values["ShortName"]);
            ClientNameVNEditor.SetValue(values["NameV"]);
            ClientNameENEditor.SetValue(values["NameE"]);

            if (values["ValidFrom"] != "") {
                var validFrom = values["ValidFrom"].split("-");
                ClientValidFromEditor.SetDate(new Date(validFrom[0], validFrom[1] - 1, validFrom[2]));
            }
            if (values["ValidTo"] != "") {
                var validTo = values["ValidTo"].split("-");
                ClientValidToEditor.SetDate(new Date(validTo[0], validTo[1] - 1, validTo[2]));
            }
            ClientActivityEditor.SetValue(values["ActivityID"]);
            ClientSeqEditor.SetValue(parseInt(values["Seq"]));
            ClientNoteEditor.SetValue(values["Note"]);

            ClientShortNameEditor.Focus();
            ClientEditPopupControl.Show();
        }

        function ClientSaveButton_Click(s, e) {
            if (window.ClientShortNameEditor && !ASPxClientEdit.ValidateEditorsInContainerById("EditForm"))
                return;

            var state = State;
            var args = "SaveForm|" + state.Command + "|" + state.Key;
            ChangeState("SaveForm", state.Command, state.Key);
            DoCallback(ClientDataGrid, function () {
                ClientDataGrid.PerformCallback(args);
            });
        }

        function ClientDataGrid_EndCallback(s, e) {
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
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" SeparatorVisible="false" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Name="Menu" Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="padding: 10px 10px 10px; font-size: 1.5em; font-weight: bold; margin: 0px 4px 4px; float: right;">
                            <asp:Literal ID="Literal1" runat="server" Text="Management" />
                        </div>
                        <div style="float: left">
                            <dx:ASPxMenu ID="mMain" runat="server" CssClass="main-menu" Theme="Moderno">
                                <ClientSideEvents ItemClick="function(s, e) { ClientMenu_ItemClick(e);}" />
                                <Items>
                                    <dx:MenuItem Name="New" Text="<%$Resources:Language, Add %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/add.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Edit" Text="<%$Resources:Language, Edit %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/edit.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Delete" Text="<%$Resources:Language, Delete %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/delete.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="SyncData" Text="Đồng bộ PMS" ItemStyle-CssClass="menu-item" Image-Url="../Content/images/execute.png" Image-Height="16px" Image-Width="16px">
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
                        <dx:ASPxTreeList ID="DataGrid" runat="server" Width="100%" ClientInstanceName="ClientDataGrid" KeyFieldName="DivisionID" ParentFieldName="ParentID"
                            OnCustomCallback="DataGrid_CustomCallback" OnCustomDataCallback="DataGrid_CustomDataCallback">
                            <Columns>
                                <dx:TreeListTextColumn FieldName="ShortName" VisibleIndex="1" Caption="Short Name" Width="100"></dx:TreeListTextColumn>
                                <dx:TreeListTextColumn FieldName="NameV" VisibleIndex="2" Caption="Name VN" Width="300"></dx:TreeListTextColumn>
                                <dx:TreeListTextColumn FieldName="NameE" VisibleIndex="3" Caption="Name EN" Width="300"></dx:TreeListTextColumn>
                                <dx:TreeListDateTimeColumn FieldName="ValidFrom" VisibleIndex="4" Caption="Valid From"></dx:TreeListDateTimeColumn>
                                <dx:TreeListDateTimeColumn FieldName="ValidTo" VisibleIndex="5" Caption="Valid To"></dx:TreeListDateTimeColumn>
                                <dx:TreeListTextColumn FieldName="Note" VisibleIndex="8" Caption="Note" Width="300"></dx:TreeListTextColumn>
                                <dx:TreeListTextColumn FieldName="Seq" VisibleIndex="8" Caption="Seq"></dx:TreeListTextColumn>
                            </Columns>
                            <Styles>
                                <AlternatingNode Enabled="True"></AlternatingNode>
                            </Styles>
                            <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" HorizontalScrollBarMode="Auto" ScrollableHeight="500" />
                            <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="ShortName;NameV;NameE;Note" />
                            <Paddings Padding="0px" />
                            <Border BorderWidth="1px" />
                            <BorderBottom BorderWidth="1px" />
                            <SettingsBehavior AllowFocusedNode="true" />
                            <SettingsResizing ColumnResizeMode="NextColumn" />
                            <SettingsPager Visible="true" PageSize="30" Mode="ShowAllNodes" />
                            <ClientSideEvents NodeDblClick="ClientDataGrid_NodeDblClick"
                                CustomDataCallback="ClientDataGrid_CustomDataCallback"
                                EndCallback="ClientDataGrid_EndCallback" />
                        </dx:ASPxTreeList>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="DataGrid"></dx:ASPxGridViewExporter>


    <dx:ASPxPopupControl ID="EditPopupControl" runat="server" Width="350" Height="250" AllowDragging="True" HeaderText="" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientEditPopupControl" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditForm" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientEditForm"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="Parent">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="ParentEditor" Width="250" ClientInstanceName="ClientParentEditor" OnCallback="ParentEditor_Callback">
                                        <ClientSideEvents EndCallback="ClientParentEditor_EndCallback" />
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Short Name">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="ShortNameEditor" Width="250" ClientInstanceName="ClientShortNameEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" ErrorText="Short Name is required" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Name VN">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="NameVNEditor" Width="250" ClientInstanceName="ClientNameVNEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Name EN">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="NameENEditor" Width="250" ClientInstanceName="ClientNameENEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Valid From">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit runat="server" ID="ValidFromEditor" Width="100" ClientInstanceName="ClientValidFromEditor" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Valid To">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit runat="server" ID="ValidToEditor" Width="100" ClientInstanceName="ClientValidToEditor" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Activity">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="ActivityEditor" Width="250" ValueType="System.Int32" ClientInstanceName="ClientActivityEditor" OnInit="ActivityEditor_Init">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Seq">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="SeqEditor" Width="100" ClientInstanceName="ClientSeqEditor">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Note">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxMemo runat="server" ID="NoteEditor" Width="250" Rows="3" ClientInstanceName="ClientNoteEditor">
                                    </dx:ASPxMemo>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Đóng" AutoPostBack="false" ClientInstanceName="ClientCancelButton">
                <ClientSideEvents Click="function(s, e) {{ ASPxClientEdit.ClearEditorsInContainerById('EditForm'); ChangeState('List', '', '');  ClientEditPopupControl.Hide();}}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnSave" runat="server" Text="Lưu" AutoPostBack="false" ClientInstanceName="ClientSaveButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="ClientSaveButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Closing="ClientEditPopupControl_Closing" />
    </dx:ASPxPopupControl>
</asp:Content>

