<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DecPurchaseForm.aspx.cs" Inherits="Pages_DecPurchaseForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../../Scripts/Common.js"></script>
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
            ClientDescriptionEditor.SetValue("");
            ClientActiveEditor.SetValue(true);
            ClientSortingEditor.SetValue("");
            ShowLoadingPanel(ClientSplitter.GetMainElement());
            DoCallback(ClientParentEditor, function () {
                ClientParentEditor.PerformCallback('');
            });

        }

        function ClientParentEditor_EndCallback(s, e) {
            var command = State.Command;
            if (command == "NEW") {
                HideLoadingPanel();
                ClientDescriptionEditor.Focus();
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

            ClientParentEditor.SetValue(values["PARENT_ID"]);
            ClientDescriptionEditor.SetValue(values["DESCRIPTION"]);
            ClientIS_PARENTEditor.SetValue(values["IS_PARENT"]);
            //ClientActiveEditor.SetValue(values["Active"] == "True" ? true : false);            
            ClientSortingEditor.SetValue(values["SORTING"]);


            ClientDescriptionEditor.Focus();
            ClientEditPopupControl.Show();
        }

        function ClientSaveButton_Click(s, e) {
            if (window.ClientDescriptionEditor && !ASPxClientEdit.ValidateEditorsInContainerById("EditForm"))
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
            <dx:SplitterPane Name="Menu" Size="100" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="float: left">
                            <div class="title">
                                <asp:Literal ID="Literal1" runat="server" Text="Declare Purchase Form" />
                            </div>
                            <dx:ASPxMenu ID="mMain" runat="server" CssClass="main-menu" Theme="Moderno">
                                <ClientSideEvents ItemClick="function(s, e) { ClientMenu_ItemClick(e);}" />
                                <Items>
                                    <dx:MenuItem Name="New" Text="<%$Resources:Language, Add %>" ItemStyle-CssClass="menu-item" Image-Url="../../Content/Images/action/add.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Edit" Text="<%$Resources:Language, Edit %>" ItemStyle-CssClass="menu-item" Image-Url="../../Content/Images/action/edit.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Delete" Text="<%$Resources:Language, Delete %>" ItemStyle-CssClass="menu-item" Image-Url="../../Content/Images/action/delete.gif">
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
                        <dx:ASPxTreeList ID="DataGrid" runat="server" Width="100%" ClientInstanceName="ClientDataGrid" KeyFieldName="ID" ParentFieldName="PARENT_ID"
                            OnCustomCallback="DataGrid_CustomCallback" OnCustomDataCallback="DataGrid_CustomDataCallback">
                            <Columns>
                                <dx:TreeListTextColumn FieldName="Description" VisibleIndex="1" Caption="Description" Width="300">
                                    <DataCellTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("ID").ToString().Trim() +"-"+ Eval("Description") %>'></asp:Label>
                                    </DataCellTemplate>
                                </dx:TreeListTextColumn>
                                <dx:TreeListTextColumn FieldName="Seq" VisibleIndex="2" Caption="Seq" Width="100"></dx:TreeListTextColumn>
                                <dx:TreeListTextColumn FieldName="Sorting" VisibleIndex="3" Caption="Sorting" Width="100"></dx:TreeListTextColumn>
                                <dx:TreeListTextColumn FieldName="Calculation" VisibleIndex="5" Caption="Calculation" Width="100"></dx:TreeListTextColumn>
                                <%--<dx:TreeListCheckColumn FieldName="Active" VisibleIndex="15" Caption="Active" Width="60"></dx:TreeListCheckColumn>--%>
                            </Columns>
                            <Styles>
                                <AlternatingNode Enabled="True"></AlternatingNode>
                            </Styles>
                            <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" HorizontalScrollBarMode="Auto" ScrollableHeight="500" />
                            <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="Description" />
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
                        <dx:LayoutItem Caption="Sorting">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="SortingEditor" Width="250" ClientInstanceName="ClientSortingEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Description">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="DescriptionEditor" Width="250" ClientInstanceName="ClientDescriptionEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" ErrorText="Activity Name is required" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Is parent?">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="IS_PARENTEditor" Width="100" ValueType="System.String" ClientInstanceName="ClientIS_PARENTEditor">
                                        <Items>
                                            <dx:ListEditItem Value="Y" Text="Yes" />
                                            <dx:ListEditItem Value="N" Text="No" />
                                        </Items>
                                    </dx:ASPxComboBox>
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

