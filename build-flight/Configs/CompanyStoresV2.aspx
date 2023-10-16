<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CompanyStoresV2.aspx.cs" Inherits="Configs_CompanyStoresV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/Common.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../signalr/hubs"></script>
    <script type="text/javascript">
        var IsApplied = false;

        function ClientSplitter_PaneResized(s, e) {
            if (e.pane.name == "Companies") {
                ClientCompaniesGrid.SetHeight(e.pane.GetClientHeight());
            }
            else if (e.pane.name == "CompanyStores") {
                ClientCompanyStoresGrid.SetHeight(e.pane.GetClientHeight());
            }
        }

        function ClientCompaniesGrid_FocusedNodeChanged(s, e) {
            var key = s.GetFocusedNodeKey();
            DoCallback(ClientCompanyStoresGrid, function () {
                ClientCompanyStoresGrid.PerformCallback('Refresh|' + key);
            });
        }

        function ClientAddSubaccount_Click(s, e) {
            ClientSubaccountListPopup.Show();
        }

        function ClientSubaccountListPopup_Shown(s, e) {
            var key = ClientCompaniesGrid.GetFocusedNodeKey();
            DoCallback(ClientSubaccountGrid, function () {
                ClientSubaccountGrid.PerformCallback('Refresh|' + key);
            });
        }

        function ClientApplyButton_Click(s, e) {
            if (ClientSubaccountGrid.GetSelectedRowCount > 0)
                IsApplied = true;

            var key = ClientCompaniesGrid.GetFocusedNodeKey();
            DoCallback(ClientSubaccountGrid, function () {
                ClientSubaccountGrid.PerformCallback('Apply|' + key);
            });
        }

        function ClientSubaccountListPopup_Closing(s, e) {
            //if (!IsApplied) return;
            IsApplied = false;
            var key = ClientCompaniesGrid.GetFocusedNodeKey();
            DoCallback(ClientCompanyStoresGrid, function () {
                ClientCompanyStoresGrid.PerformCallback('Refresh|' + key);
            });
        }

        function ClientRemoveSubaccount_Click(s, e) {
            if (!ClientCompanyStoresGrid.IsDataRow(ClientCompanyStoresGrid.GetFocusedRowIndex()))
                return;
            var cf = confirm("<%= GetMessage("MSG-0015") %>");
            if (cf) {
                var key = ClientCompanyStoresGrid.GetRowKey(ClientCompanyStoresGrid.GetFocusedRowIndex());
                DoCallback(ClientCompanyStoresGrid, function () {
                    ClientCompanyStoresGrid.PerformCallback('Remove|' + key);
                });
            }
        }

        function ClientCompanyStoresGrid_CustomButtonClick(s, e) {
            if (e.buttonID == "Edit") {

                ClientCompanyEditor.SetValue(null);
                ClientSubaccountEditor.SetValue(null);
                ClientCurrEditor.SetValue("");
                ClientDriverEditor.SetValue("");
                ClientCarrierEditor.SetValue("");
                ClientFltTypeEditor.SetValue("");
                ClientRouteEditor.SetValue("");
                ClientAirportsEditor.SetValue("");
                ClientACIDEditor.SetValue("");
                ClientAllocateKEditor.SetValue(false);

                if (!ClientCompanyStoresGrid.IsDataRow(ClientCompanyStoresGrid.GetFocusedRowIndex()))
                    return;
                var key = ClientCompanyStoresGrid.GetRowKey(ClientCompanyStoresGrid.GetFocusedRowIndex());
                ChangeState("EditForm", e.buttonID, key);
                ClientCompanyStoresGrid.GetValuesOnCustomCallback("EditForm|" + e.buttonID + "|" + key, function (values) {
                    var setValuesFunc = function () {
                        HideLoadingPanel();
                        if (!values)
                            return;

                        ClientCompanyEditor.SetValue(values["CompanyID"]);
                        ClientSubaccountEditor.SetValue(values["SubaccountID"]);
                        ClientCurrEditor.SetValue(values["Curr"]);
                        ClientDriverEditor.SetValue(values["AllocatedDriver"]);
                        ClientCarrierEditor.SetValue(values["Carrier"]);
                        ClientFltTypeEditor.SetValue(values["AllocatedFLT"]);
                        ClientRouteEditor.SetValue(values["AllocatedRT"]);
                        ClientAirportsEditor.SetValue(values["Airports"]);
                        ClientACIDEditor.SetValue(values["ACID"]);
                        ClientAllocateKEditor.SetValue(values["AllocateK"] == "True" ? true : false);

                        ClientCompanyEditor.Focus();
                        ClientEditPopupControl.Show();
                    };
                    PostponeAction(setValuesFunc, function () { return !!window.ClientCompanyEditor });
                });
                ShowLoadingPanel(ClientSplitter.GetMainElement());
            }
            else if (e.buttonID == "Delete") {
                ClientRemoveSubaccount_Click(null, null);
            }
        }

        function ClientSaveButton_Click(s, e) {
            if (window.ClientCompanyEditor && !ASPxClientEdit.ValidateEditorsInContainerById("EditForm"))
                return;

            var state = State;
            var args = "SaveForm|" + state.Command + "|" + state.Key;
            ChangeState("SaveForm", state.Command, state.Key);
            DoCallback(ClientCompanyStoresGrid, function () {
                ClientCompanyStoresGrid.PerformCallback(args);
            });
        }

        function ClientCompanyStoresGrid_EndCallback(s, e) {
            var state = State;
            if (state.View == "SaveForm" && (state.Command == "New" || state.Command == "Edit")) {
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

    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div class="title">
                            <asp:Literal ID="Literal1" runat="server" Text="Company Stores" />
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle>
                    <BorderTop BorderWidth="0px" />
                    <BorderLeft BorderWidth="0px" />
                    <BorderRight BorderWidth="0px" />
                </PaneStyle>
            </dx:SplitterPane>
            <dx:SplitterPane Separator-Visible="False">
                <PaneStyle>
                    <BorderBottom BorderWidth="0px" />
                    <BorderLeft BorderWidth="0px" />
                    <BorderRight BorderWidth="0px" />
                </PaneStyle>
                <Panes>
                    <dx:SplitterPane Name="Companies" Size="400">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxTreeList ID="CompaniesGrid" runat="server" Width="100%" ClientInstanceName="ClientCompaniesGrid"
                                    KeyFieldName="CompanyID" ParentFieldName="ParentID"
                                    OnHtmlRowPrepared="CompaniesGrid_HtmlRowPrepared">
                                    <Columns>
                                        <dx:TreeListTextColumn FieldName="NameV" VisibleIndex="1" Caption="Company Name" CellStyle-Wrap="True"></dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="ShortName" VisibleIndex="2" Caption="Short Name" Width="80"></dx:TreeListTextColumn>
                                    </Columns>
                                    <Styles>
                                        <AlternatingNode Enabled="True"></AlternatingNode>
                                    </Styles>
                                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" ScrollableHeight="500" />
                                    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="Description" />
                                    <Paddings Padding="0px" />
                                    <Border BorderWidth="1px" />
                                    <BorderBottom BorderWidth="1px" />
                                    <SettingsBehavior AllowFocusedNode="true" />
                                    <SettingsResizing ColumnResizeMode="NextColumn" />
                                    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllNodes" />
                                    <ClientSideEvents FocusedNodeChanged="ClientCompaniesGrid_FocusedNodeChanged" />
                                </dx:ASPxTreeList>
                            </dx:SplitterContentControl>
                        </ContentCollection>
                        <PaneStyle Border-BorderWidth="0">
                            <BorderTop BorderWidth="0px"></BorderTop>
                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                        </PaneStyle>
                    </dx:SplitterPane>
                    <dx:SplitterPane Name="CompanyStores">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxGridView ID="CompanyStoresGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                    ClientInstanceName="ClientCompanyStoresGrid" Width="100%" KeyFieldName="CompanyStoreID"
                                    OnCustomCallback="CompanyStoresGrid_CustomCallback"
                                    OnCustomDataCallback="CompanyStoresGrid_CustomDataCallback"
                                    OnHtmlRowPrepared="CompanyStoresGrid_HtmlRowPrepared">
                                    <Columns>
                                         <dx:GridViewCommandColumn VisibleIndex="0" Width="150">
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="Edit" Text="Edit" Image-Url="../Content/images/action/edit.gif"></dx:GridViewCommandColumnCustomButton>
                                                <dx:GridViewCommandColumnCustomButton ID="Delete" Text="Remove" Image-Url="../Content/images/action/delete.gif"></dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="Sorting" VisibleIndex="1" Caption="Sorting" Width="90" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="1" Caption="Description" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Calculation" VisibleIndex="2" Caption="Calc" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Curr" VisibleIndex="3" Caption="Curr" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="AllocatedDriver" VisibleIndex="4" Caption="Driver" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Carrier" VisibleIndex="5" Caption="Carrier" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="AllocatedFLT" VisibleIndex="6" Caption="Flt Type" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="AllocatedRT" VisibleIndex="7" Caption="Route" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Airports" VisibleIndex="8" Caption="Airports" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ACID" VisibleIndex="9" Caption="AC ID" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="AllocateFltDirection" VisibleIndex="10" Caption="Direction" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Network" VisibleIndex="11" Caption="Network" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataCheckColumn FieldName="AllocateK" VisibleIndex="12" Caption="Allocate K" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataCheckColumn>
                                        <dx:GridViewDataTextColumn FieldName="RepID" VisibleIndex="13" Caption="Report Group" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <Styles>
                                        <AlternatingRow Enabled="true" />
                                        <CommandColumn Spacing="10px" Wrap="False" />
                                    </Styles>
                                    <Settings ShowStatusBar="Visible" ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="ShortName;NameV" />
                                    <Paddings Padding="0px" />
                                    <Border BorderWidth="1px" />
                                    <BorderBottom BorderWidth="1px" />
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
                                    <Templates>
                                        <StatusBar>
                                            <dx:ASPxButton ID="btnAddSubaccount" runat="server" Text="Add Subaccount" RenderMode="Button" AutoPostBack="false" Image-Url="~/Content/images/action/add.gif">
                                                <ClientSideEvents Click="ClientAddSubaccount_Click" />
                                            </dx:ASPxButton>
                                            &nbsp;&nbsp;                                                                                                          
                                    <dx:ASPxButton ID="btnRemoveSubaccount" runat="server" Text="Remove Subaccount" RenderMode="Button" AutoPostBack="false" Image-Url="~/Content/images/action/reject.png">
                                        <ClientSideEvents Click="ClientRemoveSubaccount_Click" />
                                    </dx:ASPxButton>
                                        </StatusBar>
                                    </Templates>
                                    <ClientSideEvents CustomButtonClick="ClientCompanyStoresGrid_CustomButtonClick" EndCallback="ClientCompanyStoresGrid_EndCallback" />
                                </dx:ASPxGridView>
                            </dx:SplitterContentControl>
                        </ContentCollection>
                        <PaneStyle Border-BorderWidth="0">
                            <BorderTop BorderWidth="0px"></BorderTop>
                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                        </PaneStyle>
                    </dx:SplitterPane>
                </Panes>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>


    <dx:ASPxPopupControl ID="SubaccountListPopup" runat="server" Width="450" Height="450" AllowDragging="True" HeaderText="Add Subaccount" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientSubaccountListPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxTreeList ID="SubaccountGrid" runat="server" AutoGenerateColumns="false" EnableCallbacks="true"
                    ClientInstanceName="ClientSubaccountGrid" Width="100%" KeyFieldName="SubaccountID" ParentFieldName="SubaccountParentID"
                    OnCustomCallback="SubaccountGrid_CustomCallback"
                    OnHtmlRowPrepared="SubaccountGrid_HtmlRowPrepared">
                    <Columns>
                        <dx:TreeListDataColumn FieldName="Description" VisibleIndex="1" Caption="Description" HeaderStyle-HorizontalAlign="Center">
                        </dx:TreeListDataColumn>
                        <%--  <dx:TreeListDataColumn FieldName="Sorting" VisibleIndex="2" Caption="Sorting" Width="90" HeaderStyle-HorizontalAlign="Center">
                        </dx:TreeListDataColumn>--%>
                    </Columns>
                    <Styles>
                        <AlternatingNode Enabled="true" />
                    </Styles>
                    <SettingsSelection AllowSelectAll="true" Enabled="true" Recursive="true" />
                    <Settings VerticalScrollBarMode="Visible" ScrollableHeight="450" />
                    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="Description" />
                    <Paddings Padding="0px" />
                    <Border BorderWidth="0px" BorderStyle="None" />
                    <BorderBottom BorderWidth="1px" />
                    <SettingsBehavior AllowFocusedNode="True" />
                    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllNodes" />
                </dx:ASPxTreeList>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Cancel" AutoPostBack="false" ClientInstanceName="ClientCancelButton">
                <ClientSideEvents Click="function(s, e) {{ ClientSubaccountListPopup.Hide(); }}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApply" runat="server" Text="Apply" AutoPostBack="false" ClientInstanceName="ClientSaveButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="ClientApplyButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="ClientSubaccountListPopup_Shown" Closing="ClientSubaccountListPopup_Closing" />
    </dx:ASPxPopupControl>


    <dx:ASPxPopupControl ID="EditPopupControl" runat="server" Width="350" Height="200" AllowDragging="True" HeaderText="" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientEditPopupControl" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditForm" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientEditForm"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="Company">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="CompanyEditor" Width="255" ReadOnly="true" ClientInstanceName="ClientCompanyEditor" OnInit="CompanyEditor_Init">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" ErrorText="Company is required" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Subaccount">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="SubaccountEditor" Width="255" ReadOnly="true" ClientInstanceName="ClientSubaccountEditor" OnInit="SubaccountEditor_Init">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" ErrorText="Subaccount is required" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Currency">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="CurrEditor" Width="50" ClientInstanceName="ClientCurrEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" ErrorText="Currency Code is required" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Driver">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="DriverEditor" Width="255" ClientInstanceName="ClientDriverEditor" OnInit="DriverEditor_Init">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Carrier">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="CarrierEditor" Width="255" ClientInstanceName="ClientCarrierEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Flt Type">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTokenBox runat="server" ID="FltTypeEditor" Width="255" ClientInstanceName="ClientFltTypeEditor" OnInit="FltTypeEditor_Init">
                                    </dx:ASPxTokenBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Route">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTokenBox runat="server" ID="RouteEditor" Width="255" ClientInstanceName="ClientRouteEditor" OnInit="RouteEditor_Init">
                                    </dx:ASPxTokenBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Airports">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTokenBox runat="server" ID="AirportsEditor" Width="255" ClientInstanceName="ClientAirportsEditor" OnInit="AirportsEditor_Init">
                                    </dx:ASPxTokenBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="AC ID">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTokenBox runat="server" ID="ACIDEditor" Width="255" ClientInstanceName="ClientACIDEditor" OnInit="ACIDEditor_Init">
                                    </dx:ASPxTokenBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Allocate K">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox runat="server" ID="AllocateKEditor" ClientInstanceName="ClientAllocateKEditor">
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Close" AutoPostBack="false" ClientInstanceName="ClientCancelButton">
                <ClientSideEvents Click="function(s, e) {{ ASPxClientEdit.ClearEditorsInContainerById('EditForm'); ClientEditPopupControl.Hide();}}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnSave" runat="server" Text="Save" AutoPostBack="false" ClientInstanceName="ClientSaveButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="ClientSaveButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Closing="ClientEditPopupControl_Closing" />
    </dx:ASPxPopupControl>
</asp:Content>

