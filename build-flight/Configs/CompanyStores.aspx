<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CompanyStores.aspx.cs" Inherits="Configs_CompanyStores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/Common.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../signalr/hubs"></script>
    <script type="text/javascript">
        var IsApplied = false;

        function ClientSplitter_PaneResized(s, e) {
            if (e.pane.name == "Subaccounts") {
                ClientSubacountsGrid.SetHeight(e.pane.GetClientHeight());
            }
            else if (e.pane.name == "CompanyStores") {
                ClientCompanyStoresGrid.SetHeight(e.pane.GetClientHeight());
            }
        }

        function ClientSubacountsGrid_FocusedNodeChanged(s, e) {
            var key = s.GetFocusedNodeKey();
            DoCallback(ClientCompanyStoresGrid, function () {
                ClientCompanyStoresGrid.PerformCallback('Refresh|' + key);
            });
        }

        function ClientAddCompany_Click(s, e) {
            ClientCompanyListPopup.Show();
        }

        function ClientCompanyListPopup_Shown(s, e) {
            var key = ClientSubacountsGrid.GetFocusedNodeKey();
            DoCallback(ClientCompanyGrid, function () {
                ClientCompanyGrid.PerformCallback('Refresh|' + key);
            });
        }

        function ClientApplyButton_Click(s, e) {
            if (ClientCompanyGrid.GetSelectedRowCount > 0)
                IsApplied = true;

            var key = ClientSubacountsGrid.GetFocusedNodeKey();
            DoCallback(ClientCompanyGrid, function () {
                ClientCompanyGrid.PerformCallback('Apply|' + key);
            });
        }

        function ClientCompanyListPopup_Closing(s, e) {
            //if (!IsApplied) return;
            IsApplied = false;
            var key = ClientSubacountsGrid.GetFocusedNodeKey();
            DoCallback(ClientCompanyStoresGrid, function () {
                ClientCompanyStoresGrid.PerformCallback('Refresh|' + key);
            });
        }

        function ClientRemoveCompany_Click(s, e) {
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

            ClientCompanyEditor.SetValue(null);
            ClientCurrEditor.SetValue("");
            ClientDriverEditor.SetValue("");
            ClientCarrierEditor.SetValue("");
            ClientFltTypeEditor.SetValue("");
            ClientRouteEditor.SetValue("");
            ClientAirportsEditor.SetValue("");
            ClientACIDEditor.SetValue("");
            ClientAllocateKEditor.SetValue(false);

            if (e.buttonID == "Edit") {
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
                ClientRemoveCompany_Click(null, null);
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
                    <dx:SplitterPane Name="Subaccounts" Size="400">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxTreeList ID="SubacountsGrid" runat="server" Width="100%" ClientInstanceName="ClientSubacountsGrid"
                                    KeyFieldName="SubaccountID" ParentFieldName="SubaccountParentID"
                                    OnHtmlRowPrepared="SubacountsGrid_HtmlRowPrepared">
                                    <Columns>
                                        <dx:TreeListTextColumn FieldName="Description" VisibleIndex="1" Caption="Description" CellStyle-Wrap="True"></dx:TreeListTextColumn>
                                        <%--<dx:TreeListTextColumn FieldName="Sorting" VisibleIndex="2" Caption="Sorting" Width="50"></dx:TreeListTextColumn>--%>
                                        <dx:TreeListTextColumn FieldName="Calculation" VisibleIndex="3" Caption="Calc" Width="50"></dx:TreeListTextColumn>
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
                                    <ClientSideEvents FocusedNodeChanged="ClientSubacountsGrid_FocusedNodeChanged" />
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
                                <dx:ASPxGridView ID="CompanyStoresGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true" OnCustomCallback="CompanyStoresGrid_CustomCallback" OnCustomDataCallback="CompanyStoresGrid_CustomDataCallback"
                                    ClientInstanceName="ClientCompanyStoresGrid" Width="100%" KeyFieldName="CompanyStoreID">
                                    <Columns>
                                        <dx:GridViewCommandColumn VisibleIndex="0" Width="150">
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="Edit" Text="Edit" Image-Url="../Content/images/action/edit.gif"></dx:GridViewCommandColumnCustomButton>
                                                <dx:GridViewCommandColumnCustomButton ID="Delete" Text="Delete" Image-Url="../Content/images/action/delete.gif"></dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="ShortName" VisibleIndex="1" Caption="Short Name" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="NameV" VisibleIndex="2" Caption="Name VN" Width="300" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                                        <dx:GridViewDataCheckColumn FieldName="AllocateK" VisibleIndex="10" Caption="Allocate K" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataCheckColumn>
                                        <dx:GridViewDataTextColumn FieldName="RepID" VisibleIndex="11" Caption="Report Group" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                                            <dx:ASPxButton ID="btnAddCompany" runat="server" Text="Add company" RenderMode="Button" AutoPostBack="false" Image-Url="~/Content/images/action/add.gif">
                                                <ClientSideEvents Click="ClientAddCompany_Click" />
                                            </dx:ASPxButton>
                                            &nbsp;&nbsp;                                                                                                          
                                    <dx:ASPxButton ID="btnRemoveCompany" runat="server" Text="Remove Company" RenderMode="Button" AutoPostBack="false" Image-Url="~/Content/images/action/reject.png">
                                        <ClientSideEvents Click="ClientRemoveCompany_Click" />
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


    <dx:ASPxPopupControl ID="CompanyListPopup" runat="server" Width="400" Height="400" AllowDragging="True" HeaderText="Add Company" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientCompanyListPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxGridView ID="CompanyGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientCompanyGrid" Width="100%" KeyFieldName="CompanyID"
                    OnCustomCallback="CompanyGrid_CustomCallback">
                    <Columns>
                        <dx:GridViewCommandColumn VisibleIndex="3" Width="35" ShowSelectCheckbox="true" ShowClearFilterButton="true" SelectAllCheckboxMode="AllPages"></dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="ShortName" VisibleIndex="1" Caption="Short Name" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="NameV" VisibleIndex="2" Caption="Name VN" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Styles>
                        <AlternatingRow Enabled="true" />
                    </Styles>
                    <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="400" VerticalScrollBarStyle="Standard" />
                    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="ShortName;NameV" />
                    <Paddings Padding="0px" />
                    <Border BorderWidth="1px" />
                    <Border BorderWidth="0px" BorderStyle="None" />
                    <SettingsBehavior AllowFocusedRow="True" />
                    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
                </dx:ASPxGridView>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Cancel" AutoPostBack="false" ClientInstanceName="ClientCancelButton">
                <ClientSideEvents Click="function(s, e) {{ ClientCompanyGrid.UnselectRows(); ClientCompanyListPopup.Hide(); }}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApply" runat="server" Text="Apply" AutoPostBack="false" ClientInstanceName="ClientSaveButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="ClientApplyButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="ClientCompanyListPopup_Shown" Closing="ClientCompanyListPopup_Closing" />
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
                                            <RequiredField IsRequired="True" ErrorText="Currency Code is required" />
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
                                    <dx:ASPxTextBox runat="server" ID="DriverEditor" Width="255" ClientInstanceName="ClientDriverEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Carrier">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="CarrierEditor" Width="50" ClientInstanceName="ClientCarrierEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Flt Type">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="FltTypeEditor" Width="255" ClientInstanceName="ClientFltTypeEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Route">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="RouteEditor" Width="255" ClientInstanceName="ClientRouteEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Airports">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="AirportsEditor" Width="255" ClientInstanceName="ClientAirportsEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="AC ID">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="ACIDEditor" Width="50" ClientInstanceName="ClientACIDEditor">
                                    </dx:ASPxTextBox>
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

