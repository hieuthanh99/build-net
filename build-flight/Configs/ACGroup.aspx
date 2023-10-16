<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ACGroup.aspx.cs" Inherits="Pages_ACGroup" %>

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
                    if (!ClientDataGrid.IsDataRow(ClientDataGrid.GetFocusedRowIndex()))
                        return;
                    var key = ClientDataGrid.GetRowKey(ClientDataGrid.GetFocusedRowIndex());
                    DoCallback(ClientDataGrid, function () {
                        ClientDataGrid.PerformCallback('DELETE|' + key);
                    });
                }
                e.processOnServer = false;
                return;
            } else if (name.toUpperCase() === "ADDNEW") {
                ChangeState("EditForm", name.toUpperCase(), "");
                ClientEditPopupControl.SetHeaderText("New");
                var state = State;
                ShowEditForm(state.Command, state.Key);
                e.processOnServer = false;
                return;
            } else if (name.toUpperCase() == "EDIT") {
                if (!ClientDataGrid.IsDataRow(ClientDataGrid.GetFocusedRowIndex()))
                    return;
                var key = ClientDataGrid.GetRowKey(ClientDataGrid.GetFocusedRowIndex());
                ChangeState("EditForm", name.toUpperCase(), key);
                ClientEditPopupControl.SetHeaderText("Update");
                var state = State;
                ShowEditForm(state.Command, state.Key);
                e.processOnServer = false;
                return;
            }
            else if (e.item.name.toUpperCase() == "EXPORT") {
                e.processOnServer = false;
                return;
            }
            e.processOnServer = true;
        }

        function ClientDataGrid_RowDblClick(s, e) {
            if (!ClientDataGrid.IsDataRow(ClientDataGrid.GetFocusedRowIndex()))
                return;
            var key = ClientDataGrid.GetRowKey(ClientDataGrid.GetFocusedRowIndex());
            ChangeState("EditForm", "EDIT", key);
            ClientEditPopupControl.SetHeaderText("Update");
            var state = State;
            ShowEditForm(state.Command, state.Key);
        }

        function ShowEditForm(command, key) {

            ClientAcIataCodeEditor.SetValue("");
            ClientAcICAOCodeEditor.SetValue("");
            ClientACGroupEditor.SetValue("");
            ClientAcNameEditor.SetValue("");
            ClientRemarkEditor.SetValue("");
            ClientConvert_321Editor.SetValue(1);

            if (command == "ADDNEW") {
                ClientAcIataCodeEditor.Focus();
                ClientEditPopupControl.Show();
            }
            else if (command == "EDIT") {
                ClientDataGrid.GetValuesOnCustomCallback("EditForm|" + command + "|" + key, function (values) {
                    var setValuesFunc = function () {
                        HideLoadingPanel();
                        if (!values)
                            return;

                        ClientAcIataCodeEditor.SetValue(values["AcIataCode"]);
                        ClientAcICAOCodeEditor.SetValue(values["AcICAOCode"]);
                        ClientACGroupEditor.SetValue(values["AcGroup"]);
                        ClientAcNameEditor.SetValue(values["AcName"]);
                        ClientRemarkEditor.SetValue(values["Remarks"]);
                        ClientConvert_321Editor.SetValue(values["Convert_321"]);

                        ClientAcIataCodeEditor.Focus();
                        ClientEditPopupControl.Show();
                    };
                    PostponeAction(setValuesFunc, function () { return !!window.ClientAcIataCodeEditor });
                });
                ShowLoadingPanel(ClientSplitter.GetMainElement());
            }
        }

        function ClientSaveButton_Click(s, e) {
            if (window.ClientAcIataCodeEditor && !ASPxClientEdit.ValidateEditorsInContainerById("EditForm"))
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
                            <asp:Literal ID="Literal1" runat="server" Text="Aircraft Group Convert to A321" />
                        </div>
                        <div style="float: left">
                            <dx:ASPxMenu ID="mMain" runat="server" CssClass="main-menu" Theme="Moderno" OnItemClick="mMain_ItemClick">
                                <ClientSideEvents ItemClick="function(s, e) { ClientMenu_ItemClick(e);}" />
                                <Items>
                                    <dx:MenuItem Name="New" Text="<%$Resources:Language, Add %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/add.gif">
                                        <Items>
                                            <dx:MenuItem Name="AddNew" Text="Add New"></dx:MenuItem>
                                            <dx:MenuItem Name="AddNewFromAircraft" Text="Add From Aircraft"></dx:MenuItem>
                                        </Items>
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Edit" Text="<%$Resources:Language, Edit %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/edit.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Delete" Text="<%$Resources:Language, Delete %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/delete.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="EXPORT" Text="Export" ItemStyle-CssClass="menu-item" Image-Url="../Content/images/action/export.png">
                                        <Items>
                                            <dx:MenuItem Name="PDF" Text="PDF" />
                                            <dx:MenuItem Name="XLSX" Text="XLSX" />
                                            <dx:MenuItem Name="RTF" Text="RTF" />
                                        </Items>
                                    </dx:MenuItem>
                                </Items>
                            </dx:ASPxMenu>
                        </div>

                        <div style="float: right">
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="" Font-Bold="true" ForeColor="Red" ClientInstanceName="ClientMissAircraft"></dx:ASPxLabel>
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
                        <dx:ASPxGridView ID="DataGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true" OnCustomCallback="DataGrid_CustomCallback" OnCustomDataCallback="DataGrid_CustomDataCallback"
                            ClientInstanceName="ClientDataGrid" Width="100%" KeyFieldName="ID">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="AcIataCode" VisibleIndex="1" Caption="IATA Code" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AcICAOCode" VisibleIndex="2" Caption="ICAO Code" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AcGroup" VisibleIndex="3" Caption="Aircraft Group" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AcName" VisibleIndex="4" Caption="Aircraft Name" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Remarks" VisibleIndex="5" Caption="Remarks" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="Convert_321" VisibleIndex="6" Caption="Convert 321" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N5"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                            </Columns>
                            <Styles>
                                <AlternatingRow Enabled="true" />
                            </Styles>
                            <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                            <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="ACID;ACGroup;Note" />
                            <Paddings Padding="0px" />
                            <Border BorderWidth="1px" />
                            <BorderBottom BorderWidth="1px" />
                            <SettingsBehavior AllowFocusedRow="True" />
                            <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
                            <ClientSideEvents EndCallback="ClientDataGrid_EndCallback"
                                RowDblClick="ClientDataGrid_RowDblClick" />
                        </dx:ASPxGridView>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="DataGrid"></dx:ASPxGridViewExporter>


    <dx:ASPxPopupControl ID="EditPopupControl" runat="server" Width="450" Height="100" AllowDragging="True" HeaderText="" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientEditPopupControl" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditForm" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientEditForm"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="IATA Code">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="AcIataCodeEditor" Width="170" ClientInstanceName="ClientAcIataCodeEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="ICAO Code">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="AcICAOCodeEditor" Width="170" ClientInstanceName="ClientAcICAOCodeEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Group">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="ACGroupEditor" Width="170" ClientInstanceName="ClientACGroupEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Aircraft Name">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="AcNameEditor" Width="400" ClientInstanceName="ClientAcNameEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Remark">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxMemo runat="server" ID="RemarkEditor" Width="400" Rows="3" ClientInstanceName="ClientRemarkEditor">
                                    </dx:ASPxMemo>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Convert 321">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="Convert_321Editor" ClientInstanceName="ClientConvert_321Editor" DisplayFormatString="N5">
                                    </dx:ASPxSpinEdit>
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Close" AutoPostBack="false" ClientInstanceName="ClientCancelButton">
                <ClientSideEvents Click="function(s, e) {{ ASPxClientEdit.ClearEditorsInContainerById('EditForm'); ChangeState('List', '', '');  ClientEditPopupControl.Hide();}}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnSave" runat="server" Text="Save" AutoPostBack="false" ClientInstanceName="ClientSaveButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="ClientSaveButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Closing="ClientEditPopupControl_Closing" />
    </dx:ASPxPopupControl>
</asp:Content>

