<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AircraftType.aspx.cs" Inherits="Pages_AircraftType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/Common.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../signalr/hubs"></script>
    <script type="text/javascript">

        function ClientSplitter_PaneResized(s, e) {
            if (e.pane.name == "GridPane") {
                ClientAircraftTypeGrid.SetHeight(e.pane.GetClientHeight());
            }
        }


        function ClientMenu_ItemClick(e) {
            var name = e.item.name;
            if (name.toUpperCase() == "DELETE") {
                var cf = confirm("<%= GetMessage("MSG-0015") %>");
                if (cf) {
                    if (!ClientAircraftTypeGrid.IsDataRow(ClientAircraftTypeGrid.GetFocusedRowIndex()))
                        return;
                    var key = ClientAircraftTypeGrid.GetRowKey(ClientAircraftTypeGrid.GetFocusedRowIndex());
                    DoCallback(ClientAircraftTypeGrid, function () {
                        ClientAircraftTypeGrid.PerformCallback('DELETE|' + key);
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
                if (!ClientAircraftTypeGrid.IsDataRow(ClientAircraftTypeGrid.GetFocusedRowIndex()))
                    return;
                var key = ClientAircraftTypeGrid.GetRowKey(ClientAircraftTypeGrid.GetFocusedRowIndex());
                ChangeState("EditForm", name.toUpperCase(), key);
                ClientEditPopupControl.SetHeaderText("Cập nhật");
                var state = State;
                ShowEditForm(state.Command, state.Key);
            }
            e.processOnServer = false;
        }

        function ClientAircraftTypeGrid_RowDblClick(s, e) {
            if (!ClientAircraftTypeGrid.IsDataRow(ClientAircraftTypeGrid.GetFocusedRowIndex()))
                return;
            var key = ClientAircraftTypeGrid.GetRowKey(ClientAircraftTypeGrid.GetFocusedRowIndex());
            ChangeState("EditForm", "EDIT", key);
            ClientEditPopupControl.SetHeaderText("Cập nhật");
            var state = State;
            ShowEditForm(state.Command, state.Key);
        }

        function ShowEditForm(command, key) {

            ClientAirCraftTypeCodeEditor.SetValue("");
            ClientAirCraftTypeNameEditor.SetValue("");

            if (command == "NEW") {
                ClientAirCraftTypeCodeEditor.GetInputElement().readOnly = false;
                ClientAirCraftTypeCodeEditor.Focus();
                ClientEditPopupControl.Show();
            }
            else if (command == "EDIT") {
                ClientAirCraftTypeCodeEditor.GetInputElement().readOnly = true;
                ClientAircraftTypeGrid.GetValuesOnCustomCallback("EditForm|" + command + "|" + key, function (values) {
                    var setValuesFunc = function () {
                        HideLoadingPanel();
                        if (!values)
                            return;

                        ClientAirCraftTypeCodeEditor.SetValue(values["AircraftTypeCode"]);
                        ClientAirCraftTypeNameEditor.SetValue(values["AircraftTypeName"]);
                        ClientAirCraftTypeNameEditor.Focus();
                        ClientEditPopupControl.Show();
                    };
                    PostponeAction(setValuesFunc, function () { return !!window.ClientAirCraftTypeCodeEditor });
                });
                ShowLoadingPanel(ClientSplitter.GetMainElement());
            }
        }

        function ClientSaveButton_Click(s, e) {
            if (window.ClientAirCraftTypeCodeEditor && !ASPxClientEdit.ValidateEditorsInContainerById("EditAirCraftTypeForm"))
                return;

            var state = State;
            var args = "SaveForm|" + state.Command + "|" + state.Key;
            ChangeState("SaveForm", state.Command, state.Key);
            DoCallback(ClientAircraftTypeGrid, function () {
                ClientAircraftTypeGrid.PerformCallback(args);
            });


        }

        function ClientAircraftTypeGrid_EndCallback(s, e) {
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
                           <asp:Literal ID="Literal1" runat="server" Text="Aircraft Types" />
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
                        <dx:ASPxGridView ID="AircraftTypeGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true" OnCustomCallback="AircraftTypeGrid_CustomCallback" OnCustomDataCallback="AircraftTypeGrid_CustomDataCallback"
                            ClientInstanceName="ClientAircraftTypeGrid" Width="100%" KeyFieldName="AircraftTypeCode">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="AircraftTypeCode" VisibleIndex="1" Caption="Aircraft Type Code" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AircraftTypeName" VisibleIndex="2" Caption="Aircraft Type Name" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                   <dx:GridViewDataTextColumn FieldName="Payload" VisibleIndex="3" Caption="Payload" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                   <dx:GridViewDataTextColumn FieldName="MTOW" VisibleIndex="4" Caption="MTOW" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <Styles>
                                <AlternatingRow Enabled="true" />
                            </Styles>
                            <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto"/>
                            <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="AircraftTypeCode;AircraftTypeName" />
                            <Paddings Padding="0px" />
                            <Border BorderWidth="1px" />
                            <BorderBottom BorderWidth="1px" />
                            <SettingsBehavior AllowFocusedRow="True" />
                            <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                            <ClientSideEvents EndCallback="ClientAircraftTypeGrid_EndCallback"
                                RowDblClick="ClientAircraftTypeGrid_RowDblClick" />
                        </dx:ASPxGridView>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="AircraftTypeGrid"></dx:ASPxGridViewExporter>


    <dx:ASPxPopupControl ID="EditPopupControl" runat="server" Width="350" Height="100" AllowDragging="True" HeaderText="" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientEditPopupControl" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditAirCraftTypeForm" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientEditAirCraftTypeForm"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="Aircraft Type Code">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="AirCraftTypeCodeEditor" Width="170" ClientInstanceName="ClientAirCraftTypeCodeEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Aircraft Type Name">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="AirCraftTypeNameEditor" Width="170" ClientInstanceName="ClientAirCraftTypeNameEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
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
                <ClientSideEvents Click="function(s, e) {{ ASPxClientEdit.ClearEditorsInContainerById('EditAirCraftTypeForm'); ChangeState('List', '', '');  ClientEditPopupControl.Hide();}}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnSave" runat="server" Text="Lưu" AutoPostBack="false" ClientInstanceName="ClientSaveButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="ClientSaveButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Closing="ClientEditPopupControl_Closing" />
    </dx:ASPxPopupControl>
</asp:Content>

