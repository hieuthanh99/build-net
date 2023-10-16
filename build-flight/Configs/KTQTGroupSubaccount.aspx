<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="KTQTGroupSubaccount.aspx.cs" Inherits="Pages_KTQTGroupSubaccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/Common.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../signalr/hubs"></script>
    <script type="text/javascript">

        function ClientSplitter_PaneResized(s, e) {
            if (e.pane.name == "GridPane") {
                ClientDataGrid.SetHeight(e.pane.GetClientHeight() - 50);
            }
            if (e.pane.name == "FastCode") {
                ClientFastCodeGrid.SetHeight(e.pane.GetClientHeight());
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

                e.processOnServer = false;
                return;
            } else if (name.toUpperCase() == "EDIT") {
                var key = ClientDataGrid.GetFocusedNodeKey();
                ChangeState("EditForm", name.toUpperCase(), key);
                ClientEditPopupControl.SetHeaderText("Cập nhật");
                var state = State;
                ShowEditForm(state.Command, state.Key);

                e.processOnServer = false;
                return;
            } else if (name.toUpperCase() == "UPDATESEQ") {
                var cf = confirm("Confirm update subaccount seq?");
                if (cf) {
                    DoCallback(ClientDataGrid, function () {
                        ClientDataGrid.PerformCallback('UPDATESEQ');
                    });
                }

                e.processOnServer = false;
                return;
            }
            e.processOnServer = true;
        }

        function ClientUpdateSeqButton_Click(s, e) {
            var cf = confirm("Confirm update subaccount seq?");
            if (cf) {
                DoCallback(ClientDataGrid, function () {
                    ClientDataGrid.PerformCallback('UPDATESEQ');
                });
            }
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
            ClientDescriptionVNEditor.SetValue("");
            ClientDescriptionENEditor.SetValue("");
            ClientCalculationEditor.SetValue("");
            ClientActiveEditor.SetValue(true);

            ClientAccountTypeEditor.SetValue(null);
            ClientManagementCodeEditor.SetValue("");
            ClientUnitEditor.SetValue("");
            ClientSeqEditor.SetValue(0);
            ClientSortingEditor.SetValue("");
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
                ClientDescriptionVNEditor.Focus();
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
            ClientDescriptionVNEditor.SetValue(values["DescriptionVN"]);
            ClientDescriptionENEditor.SetValue(values["DescriptionEN"]);
            ClientCalculationEditor.SetValue(values["Calculation"]);

            ClientAccountTypeEditor.SetValue(values["AccountType"]);
            ClientManagementCodeEditor.SetValue(values["ManagementCode"]);
            ClientUnitEditor.SetValue(values["Unit"]);
            ClientActiveEditor.SetValue(values["Active"] == "True" ? true : false);
            ClientSeqEditor.SetValue(parseInt(values["Seq"]));
            ClientSortingEditor.SetValue(values["Sorting"]);
            ClientNoteEditor.SetValue(values["Note"]);


            ClientDescriptionVNEditor.Focus();
            ClientEditPopupControl.Show();
        }

        function ClientSaveButton_Click(s, e) {
            if (window.ClientDescriptionVNEditor && !ASPxClientEdit.ValidateEditorsInContainerById("EditForm"))
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

        function ClientDataGrid_NodeClick(s, e) {
            var key = s.GetFocusedNodeKey();
            ChangeState("List", "", key);
            var args = "LoadFastCode|" + key;

        }


    </script>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" SeparatorVisible="false" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Name="Menu" Size="100" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="float: left">
                            <div class="title">
                                <asp:Literal ID="Literal1" runat="server" Text="Management Code" />
                            </div>
                            <dx:ASPxMenu ID="mMain" runat="server" CssClass="main-menu" Theme="Moderno" OnItemClick="mMain_ItemClick">
                                <ClientSideEvents ItemClick="function(s, e) { ClientMenu_ItemClick(e);}" />
                                <Items>
                                    <dx:MenuItem Name="New" Text="<%$Resources:Language, Add %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/add.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Edit" Text="<%$Resources:Language, Edit %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/edit.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Delete" Text="<%$Resources:Language, Delete %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/delete.gif">
                                    </dx:MenuItem>
                                    <%--   <dx:MenuItem Name="UpdateSeq" Text="Update Seq" ItemStyle-CssClass="menu-item" Image-Url="../Content/images/if_Calculator_669940.png">
                                    </dx:MenuItem>--%>
                                    <dx:MenuItem Name="EXPORT" Text="Export Excel" ItemStyle-CssClass="menu-item" Image-Url="../Content/images/action/export.png">
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
                    <dx:SplitterPane Name="GridPane">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxTreeList ID="DataGrid" runat="server" Width="100%" ClientInstanceName="ClientDataGrid" KeyFieldName="GroupSubaccountID" ParentFieldName="GroupSubaccountParentID"
                                    OnCustomCallback="DataGrid_CustomCallback" OnCustomDataCallback="DataGrid_CustomDataCallback"
                                    OnHtmlRowPrepared="DataGrid_HtmlRowPrepared">
                                    <Columns>
                                        <dx:TreeListTextColumn FieldName="DescriptionVN" VisibleIndex="1" Caption="Description" Width="300">
                                            <DataCellTemplate>
                                                <asp:Label runat="server" Text='<%# Eval("GroupSubaccountID").ToString().Trim() +"-"+ Eval("DescriptionVN") %>'></asp:Label>
                                            </DataCellTemplate>
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="ManagementCode" VisibleIndex="2" Caption="ManagementCode" Width="120"></dx:TreeListTextColumn>

                                        <dx:TreeListTextColumn FieldName="Seq" VisibleIndex="3" Caption="Seq" Width="100"></dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="Sorting" VisibleIndex="4" Caption="Sorting" Width="100"></dx:TreeListTextColumn>
                                        <dx:TreeListComboBoxColumn FieldName="AccountType" VisibleIndex="5" Caption="AccountType" Width="150">
                                            <PropertiesComboBox>
                                                <Items>
                                                    <dx:ListEditItem Value="SL" Text="Chỉ tiêu sản lượng" />
                                                    <dx:ListEditItem Value="DT" Text="Chỉ tiêu doanh thu" />
                                                    <dx:ListEditItem Value="PT" Text="Chỉ tiêu phân tích" />
                                                    <dx:ListEditItem Value="CP" Text="Chỉ tiêu chi phí" />
                                                    <dx:ListEditItem Value="OT" Text="Chỉ tiêu khác" />
                                                </Items>
                                            </PropertiesComboBox>
                                        </dx:TreeListComboBoxColumn>

                                        <dx:TreeListTextColumn FieldName="Calculation" VisibleIndex="6" Caption="Calculation" Width="100"></dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="Unit" VisibleIndex="7" Caption="Unit" Width="100"></dx:TreeListTextColumn>

                                        <dx:TreeListCheckColumn FieldName="Active" VisibleIndex="8" Caption="Active" Width="60"></dx:TreeListCheckColumn>
                                        <dx:TreeListTextColumn FieldName="Note" VisibleIndex="9" Caption="Note" Width="300"></dx:TreeListTextColumn>
                                    </Columns>
                                    <Styles>
                                        <AlternatingNode Enabled="True"></AlternatingNode>
                                    </Styles>
                                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" HorizontalScrollBarMode="Auto" ScrollableHeight="500" />
                                    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="Description;Note" />
                                    <Paddings Padding="0px" />
                                    <Border BorderWidth="1px" />
                                    <BorderBottom BorderWidth="1px" />
                                    <SettingsBehavior AllowFocusedNode="true" />
                                    <SettingsResizing ColumnResizeMode="NextColumn" />
                                    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllNodes" />
                                    <ClientSideEvents NodeDblClick="ClientDataGrid_NodeDblClick"
                                        FocusedNodeChanged="ClientDataGrid_NodeClick"
                                        CustomDataCallback="ClientDataGrid_CustomDataCallback"
                                        EndCallback="ClientDataGrid_EndCallback" />
                                </dx:ASPxTreeList>
                                <dx:ASPxTreeListExporter ID="TreeListExporter" runat="server" TreeListID="DataGrid"></dx:ASPxTreeListExporter>
                                <br />
                                <%--  <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Update Seq" AutoPostBack="false">
                                    <Image Url="../Content/images/if_Calculator_669940.png" Width="16px"></Image>
                                    <ClientSideEvents Click="ClientUpdateSeqButton_Click" />
                                </dx:ASPxButton>--%>

                                <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Export Excel" AutoPostBack="false" OnClick="ASPxButton2_Click">
                                    <Image Url="../Content/images/action/export.png"></Image>
                                </dx:ASPxButton>
                            </dx:SplitterContentControl>
                        </ContentCollection>
                        <PaneStyle Border-BorderWidth="0">
                            <BorderTop BorderWidth="0px"></BorderTop>
                        </PaneStyle>
                    </dx:SplitterPane>

                </Panes>
            </dx:SplitterPane>

        </Panes>
    </dx:ASPxSplitter>

    <dx:ASPxPopupControl ID="EditPopupControl" runat="server" Width="350" Height="250" AllowDragging="True" HeaderText="" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientEditPopupControl" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditForm" runat="server" RequiredMarkDisplayMode="Auto" ColCount="2" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientEditForm"
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
                        <dx:LayoutItem Caption="DescriptionVN">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="DescriptionVNEditor" Width="250" ClientInstanceName="ClientDescriptionVNEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="DescriptionEN">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="DescriptionENEditor" Width="250" ClientInstanceName="ClientDescriptionENEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Calculation">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="CalculationEditor" Width="100" ValueType="System.String" ClientInstanceName="ClientCalculationEditor">
                                        <Items>
                                            <dx:ListEditItem Value="DATA" Text="DATA" />
                                            <dx:ListEditItem Value="AUTO" Text="AUTO" />
                                            <dx:ListEditItem Value="SUM" Text="SUM" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Account Type">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="AccountTypeEditor" Width="250" ValueType="System.String" ClientInstanceName="ClientAccountTypeEditor">
                                        <Items>
                                            <dx:ListEditItem Value="SL" Text="Chỉ tiêu sản lượng" />
                                            <dx:ListEditItem Value="DT" Text="Chỉ tiêu doanh thu" />
                                            <dx:ListEditItem Value="PT" Text="Chỉ tiêu phân tích" />
                                            <dx:ListEditItem Value="CP" Text="Chỉ tiêu chi phí" />
                                            <dx:ListEditItem Value="OT" Text="Chỉ tiêu khác" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="ManagementCode">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="ManagementCodeEditor" Width="250" ClientInstanceName="ClientManagementCodeEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Unit">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="UnitEditor" Width="250" ClientInstanceName="ClientUnitEditor">
                                    </dx:ASPxTextBox>
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
                        <dx:LayoutItem Caption="Sorting">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="SortingEditor" Width="100" ClientInstanceName="ClientSortingEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Note">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="NoteEditor" Width="250" ClientInstanceName="ClientNoteEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Active">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox runat="server" ID="ActiveEditor" ClientInstanceName="ClientActiveEditor">
                                    </dx:ASPxCheckBox>
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

