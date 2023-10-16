<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Aircraft.aspx.cs" Inherits="Pages_Aircraft" %>

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
            } else if (name.toUpperCase() == "NEW") {
                ChangeState("EditForm", name.toUpperCase(), "");
                ClientEditPopupControl.SetHeaderText("Thêm mới");
                var state = State;
                ShowEditForm(state.Command, state.Key);
            } else if (name.toUpperCase() == "EDIT") {
                if (!ClientDataGrid.IsDataRow(ClientDataGrid.GetFocusedRowIndex()))
                    return;
                var key = ClientDataGrid.GetRowKey(ClientDataGrid.GetFocusedRowIndex());
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

        function ClientDataGrid_RowDblClick(s, e) {
            if (!ClientDataGrid.IsDataRow(ClientDataGrid.GetFocusedRowIndex()))
                return;
            var key = ClientDataGrid.GetRowKey(ClientDataGrid.GetFocusedRowIndex());
            ChangeState("EditForm", "EDIT", key);
            ClientEditPopupControl.SetHeaderText("Cập nhật");
            var state = State;
            ShowEditForm(state.Command, state.Key);
        }

        function ShowEditForm(command, key) {

            ClientACIDEditor.SetValue("");
            ClientMZFWEditor.SetValue(0);
            ClientPayloadEditor.SetValue(0);
            ClientMLWEditor.SetValue(0);
            ClientMTOWEditor.SetValue(0);
            ClientFEditor.SetValue(0);
            ClientCEditor.SetValue(0);
            ClientZEditor.SetValue(0);
            ClientYEditor.SetValue(0);
            ClientAFTEditor.SetValue(0);
            ClientFuelFHEditor.SetValue(0);
            ClientFuelBHEditor.SetValue(0);
            ClientAvgSpeedKMEditor.SetValue(0);
            ClientPilotsEditor.SetValue(0);
            ClientCabinCrewEditor.SetValue(0);
            ClientSeatEditor.SetValue(0);
            ClientConvertTo321Editor.SetValue(0);
            ClientFuelULBHEditor.SetValue(0);
            ClientOilBHEditor.SetValue(0);
            ClientAPUBurnEditor.SetValue(0);
            ClientTAXIBurnEditor.SetValue(0);
            ClientACGroupEditor.SetValue(0);
            ClientActiveEditor.SetValue(0);
            ClientNoteEditor.SetValue(0);

            if (command == "NEW") {
                ClientACIDEditor.GetInputElement().readOnly = false;
                ClientACIDEditor.Focus();
                ClientEditPopupControl.Show();
            }
            else if (command == "EDIT") {
                ClientACIDEditor.GetInputElement().readOnly = true;
                ClientDataGrid.GetValuesOnCustomCallback("EditForm|" + command + "|" + key, function (values) {
                    var setValuesFunc = function () {
                        HideLoadingPanel();
                        if (!values)
                            return;

                        ClientACIDEditor.SetValue(values["ACID"]);
                        ClientMZFWEditor.SetValue(values["MZFW"]);
                        ClientPayloadEditor.SetValue(values["Payload"]);
                        ClientMLWEditor.SetValue(values["MLW"]);
                        ClientMTOWEditor.SetValue(values["MTOW"]);
                        ClientFEditor.SetValue(values["F"]);
                        ClientCEditor.SetValue(values["C"]);
                        ClientZEditor.SetValue(values["Z"]);
                        ClientYEditor.SetValue(values["Y"]);
                        ClientAFTEditor.SetValue(values["AFT"]);
                        ClientFuelFHEditor.SetValue(values["FuelFH"]);
                        ClientFuelBHEditor.SetValue(values["FuelBH"]);
                        ClientAvgSpeedKMEditor.SetValue(values["AvgSpeedKM"]);
                        ClientPilotsEditor.SetValue(values["Pilots"]);
                        ClientCabinCrewEditor.SetValue(values["CabinCrew"]);
                        ClientSeatEditor.SetValue(values["Seat"]);
                        ClientConvertTo321Editor.SetValue(values["ConvertTo321"]);
                        ClientFuelULBHEditor.SetValue(values["FuelULBH"]);
                        ClientOilBHEditor.SetValue(values["OilBH"]);
                        ClientAPUBurnEditor.SetValue(values["APUBurn"]);
                        ClientTAXIBurnEditor.SetValue(values["TAXIBurn"]);
                        ClientACGroupEditor.SetValue(values["ACGroup"]);
                        ClientActiveEditor.SetValue(values["Active"] == "True" ? true : false);
                        ClientNoteEditor.SetValue(values["Note"]);

                        ClientACIDEditor.Focus();
                        ClientEditPopupControl.Show();
                    };
                    PostponeAction(setValuesFunc, function () { return !!window.ClientACIDEditor });
                });
                ShowLoadingPanel(ClientSplitter.GetMainElement());
            }
        }

        function ClientSaveButton_Click(s, e) {
            if (window.ClientACIDEditor && !ASPxClientEdit.ValidateEditorsInContainerById("EditForm"))
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
                            <asp:Literal ID="Literal1" runat="server" Text="Aircrafts" />
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
                        <dx:ASPxGridView ID="DataGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true" OnCustomCallback="DataGrid_CustomCallback" OnCustomDataCallback="DataGrid_CustomDataCallback"
                            ClientInstanceName="ClientDataGrid" Width="100%" KeyFieldName="ACID">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="ACID" VisibleIndex="1" Caption="AC ID" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="MZFW" VisibleIndex="2" Caption="MZFW" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Payload" VisibleIndex="3" Caption="Payload" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="MTOW" VisibleIndex="4" Caption="MTOW" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="MLW" VisibleIndex="5" Caption="MLW" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="F" VisibleIndex="6" Caption="F" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="C" VisibleIndex="7" Caption="C" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Z" VisibleIndex="8" Caption="Z" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Y" VisibleIndex="9" Caption="Y" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AFT" VisibleIndex="10" Caption="AFT" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="FuelFH" VisibleIndex="11" Caption="Fuel FH" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="FuelBH" VisibleIndex="12" Caption="Fuel BH" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AvgSpeedKM" VisibleIndex="13" Caption="Avg Speed KM" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Pilots" VisibleIndex="14" Caption="Pilots" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CabinCrew" VisibleIndex="15" Caption="Cabin Crew" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Seat" VisibleIndex="16" Caption="Seat" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ConvertTo321" VisibleIndex="17" Caption="Convert To 321" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="FuelULBH" VisibleIndex="18" Caption="Fuel UL BH" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="OilBH" VisibleIndex="19" Caption="Oil BH" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="APUBurn" VisibleIndex="20" Caption="APU Burn" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="TAXIBurn" VisibleIndex="21" Caption="TAXI Burn" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ACGroup" VisibleIndex="22" Caption="AC Group" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataCheckColumn FieldName="Active" VisibleIndex="23" Caption="Active" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataTextColumn FieldName="Note" VisibleIndex="24" Caption="Note" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
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
                            <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
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


    <dx:ASPxPopupControl ID="EditPopupControl" runat="server" Width="550" Height="100" AllowDragging="True" HeaderText="" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientEditPopupControl" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditForm" runat="server" ColCount="2" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientEditForm"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="AC ID">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="ACIDEditor" Width="170" ClientInstanceName="ClientACIDEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="MZFW">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="MZFWEditor" Width="170" ClientInstanceName="ClientMZFWEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Payload">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="PayloadEditor" Width="170" ClientInstanceName="ClientPayloadEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="MTOW">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="MTOWEditor" Width="170" ClientInstanceName="ClientMTOWEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="MLW">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="MLWEditor" Width="170" ClientInstanceName="ClientMLWEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="F">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="FEditor" Width="170" ClientInstanceName="ClientFEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="C">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="CEditor" Width="170" ClientInstanceName="ClientCEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Z">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="Zditor" Width="170" ClientInstanceName="ClientZEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Y">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="YEditor" Width="170" ClientInstanceName="ClientYEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="AFT">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="AFTEditor" Width="170" ClientInstanceName="ClientAFTEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Fuel FH">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="FuelFHEditor" Width="170" ClientInstanceName="ClientFuelFHEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Fuel BH">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="FuelBHEditor" Width="170" ClientInstanceName="ClientFuelBHEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Avg Speed KM">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="AvgSpeedKMEditor" Width="170" ClientInstanceName="ClientAvgSpeedKMEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Pilots">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="PilotsEditor" Width="170" ClientInstanceName="ClientPilotsEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Cabin Crew">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="CabinCrewEditor" Width="170" ClientInstanceName="ClientCabinCrewEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Seat">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="SeatEditor" Width="170" ClientInstanceName="ClientSeatEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Convert To 321">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="ConvertTo321Editor" Width="170" ClientInstanceName="ClientConvertTo321Editor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Fuel UL BH">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="FuelULBHEditor" Width="170" ClientInstanceName="ClientFuelULBHEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Oil BH">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="OilBHEditor" Width="170" ClientInstanceName="ClientOilBHEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="APU Burn">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="APUBurnEditor" Width="170" ClientInstanceName="ClientAPUBurnEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="TAXI Burn">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="TAXIBurnEditor" Width="170" ClientInstanceName="ClientTAXIBurnEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="AC Group">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="ACGroupEditor" Width="170" ClientInstanceName="ClientACGroupEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Note" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxMemo runat="server" ID="NoteEditor" Width="455" Rows="3" ClientInstanceName="ClientNoteEditor">
                                    </dx:ASPxMemo>
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

