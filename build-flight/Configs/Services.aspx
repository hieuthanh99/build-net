<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Services.aspx.cs" Inherits="Configs_Services" %>

<%@ Register Src="~/Configs/PopupControl/CompanyLOV.ascx" TagPrefix="dx" TagName="CompanyLOV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/Common.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../signalr/hubs"></script>
    <script type="text/javascript">

        function ClientSplitter_PaneResized(s, e) {
            if (e.pane.name == "ServiceGridPane") {
                ClientDataGrid.SetHeight(e.pane.GetClientHeight());
            }

            if (e.pane.name == "CompanyGridPane") {
                ClientCompanyGrid.SetHeight(e.pane.GetClientHeight());
            }
        }


        function ClientDataGrid_AddNewButtonClick(s, e) {
            ChangeState("EditForm", "NEW", "");
            ClientEditPopupControl.SetHeaderText("Thêm mới");
            var state = State;
            ShowEditForm(state.Command, state.Key);
        }

        function ClientDataGrid_CustomButtonClick(s, e) {
            if (!s.IsDataRow(s.GetFocusedRowIndex()))
                return;
            var key = s.GetRowKey(s.GetFocusedRowIndex());

            if (e.buttonID == "DataGridEdit") {
                if (!ClientDataGrid.IsDataRow(ClientDataGrid.GetFocusedRowIndex()))
                    return;
                var key = ClientDataGrid.GetRowKey(ClientDataGrid.GetFocusedRowIndex());
                ChangeState("EditForm", "EDIT", key);
                ClientEditPopupControl.SetHeaderText("Cập nhật");
                var state = State;
                ShowEditForm(state.Command, state.Key);
            }

            if (e.buttonID == "DataGridDelete") {
                var cf = confirm("<%= GetMessage("MSG-0015") %>");
                if (cf) {
                    if (!ClientDataGrid.IsDataRow(ClientDataGrid.GetFocusedRowIndex()))
                        return;
                    var key = ClientDataGrid.GetRowKey(ClientDataGrid.GetFocusedRowIndex());
                    DoCallback(ClientDataGrid, function () {
                        ClientDataGrid.PerformCallback('DELETE|' + key);
                    });
                }
            }
        }

        function ClientDataGrid_FocusedRowChanged(s, e) {
            if (!s.IsDataRow(s.GetFocusedRowIndex()))
                return;
            var key = s.GetRowKey(s.GetFocusedRowIndex());

            DoCallback(ClientCompanyGrid, function () {
                ClientCompanyGrid.PerformCallback('LOAD_COMPANY|' + key);
            });
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

            ClientCodeEditor.SetValue("");
            ClientNameEditor.SetValue("");
            ClientFuelTypeEditor.SetValue("");
            ClientFuelEditor.SetValue(0);
            ClientGroupEditor.SetValue(null);
            ClientOwnedEditor.SetValue(true);
            ClientHiredEditor.SetValue(false);
            ClientHiredEditor.SetVisible(false);

            var aOwned = ClientEditForm.GetItemByName("Owned");
            var aHired = ClientEditForm.GetItemByName("Hired");
            aOwned.SetVisible(false);
            aHired.SetVisible(false);

            if (command == "NEW") {
                ClientCodeEditor.Focus();
                ClientEditPopupControl.Show();
            }
            else if (command == "EDIT") {
                ClientDataGrid.GetValuesOnCustomCallback("EditForm|" + command + "|" + key, function (values) {
                    var setValuesFunc = function () {
                        HideLoadingPanel();
                        if (!values)
                            return;

                        ClientCodeEditor.SetValue(values["Item"]);
                        ClientNameEditor.SetValue(values["Name"]);
                        ClientFuelTypeEditor.SetValue(values["FuelType"]);
                        ClientFuelEditor.SetValue(values["Fuel"]);
                        ClientGroupEditor.SetValue(values["GroupItem"]);
                        ClientOwnedEditor.SetValue(values["Owned"] == "True" ? true : false);
                        ClientHiredEditor.SetValue(values["Hired"] == "True" ? true : false);
                        ClientActiveEditor.SetValue(values["Active"] == "True" ? true : false);


                        var aOwned = ClientEditForm.GetItemByName("Owned");
                        var aHired = ClientEditForm.GetItemByName("Hired");
                        if (values["GroupItem"] == "TTBTX" || values["GroupItem"] == "TTBKTX" || values["GroupItem"] == "TTBKHAC") {
                            aOwned.SetVisible(true);
                            aHired.SetVisible(true);
                            ClientOwnedEditor.SetVisible(true);
                            ClientHiredEditor.SetVisible(true);
                        }
                        else {
                            aOwned.SetVisible(false);
                            aHired.SetVisible(false);
                        }

                        ClientCodeEditor.Focus();
                        ClientEditPopupControl.Show();
                    };
                    PostponeAction(setValuesFunc, function () { return !!window.ClientCodeEditor });
                });
                ShowLoadingPanel(ClientSplitter.GetMainElement());
            }
        }

        function ClientGroupEditor_ValueChanged(s, e) {
            var aGroupItem = s.GetValue();
            var aOwned = ClientEditForm.GetItemByName("Owned");
            var aHired = ClientEditForm.GetItemByName("Hired");
            if (aGroupItem == "TTBTX" || aGroupItem == "TTBKTX" || aGroupItem == "TTBKHAC") {
                aOwned.SetVisible(true);
                aHired.SetVisible(true);
                ClientOwnedEditor.SetVisible(true);
                ClientHiredEditor.SetVisible(true);
            }
            else {
                aOwned.SetVisible(false);
                aHired.SetVisible(false);
            }

        }

        function ClientSaveButton_Click(s, e) {
            if (window.ClientCodeEditor && !ASPxClientEdit.ValidateEditorsInContainerById("EditForm"))
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

        function ClientCountryCodeEditor_ValueChanged(s, e) {
            ShowLoadingPanel(ClientCityEditor.GetMainElement());
            var args = s.GetValue();
            DoCallback(ClientCityEditor, function () {
                ClientCityEditor.PerformCallback(args);
            });
        }

        function ClientCityEditor_EndCallback(s, e) {
            HideLoadingPanel();
        }

        function ClientCompanyGrid_AddNewButtonClick(s, e) {
            if (!ClientDataGrid.IsDataRow(ClientDataGrid.GetFocusedRowIndex()))
                return;

            ClientCompanyPopup.Show();
        }

        function ClientAddCompanyButton_Click(s, e) {
            if (!ClientDataGrid.IsDataRow(ClientDataGrid.GetFocusedRowIndex()))
                return;
            var itemKey = ClientDataGrid.GetRowKey(ClientDataGrid.GetFocusedRowIndex());

            var keys = [];
            keys = ClientLOVCompanyGrid.GetSelectedKeysOnPage();
            if (keys.length == 0) {
                alert("Bạn phải chọn ít nhất một đơn vị.");
                return;
            }
            if (keys.length > 0) {
                DoCallback(ClientCompanyGrid, function () {
                    ClientCompanyGrid.PerformCallback("ADD_COMPANY|" + itemKey + "|" + keys.join("|"));
                });
            }

            ClientLOVCompanyGrid.UnselectAllRowsOnPage();
        }

        function ClientCompanyGrid_CustomButtonClick(s, e) {
            if (e.buttonID == "CompanyGridDelete") {
                if (!s.IsDataRow(s.GetFocusedRowIndex()))
                    return;
                var key = s.GetRowKey(s.GetFocusedRowIndex());

                var cf = confirm("<%= GetMessage("MSG-0015") %>");
                if (cf) {
                    DoCallback(ClientCompanyGrid, function () {
                        ClientCompanyGrid.PerformCallback('DELETE_COMPANY|' + key);
                    });
                }

            }
        }

    </script>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" SeparatorVisible="false" Orientation="Vertical" Width="100%" Height="100%">
        <Styles>
            <Separator>
                <BorderTop BorderStyle="None" />
                <BorderBottom BorderStyle="None" />
            </Separator>
        </Styles>
        <ClientSideEvents PaneResized="ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Name="Menu" Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="float: right">
                        </div>
                        <div style="float: left">
                            <div class="title">
                                <asp:Literal ID="Literal1" runat="server" Text="SẢN PHẨM, DỊCH VỤ" />
                            </div>
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
            <dx:SplitterPane>
                <Panes>
                    <dx:SplitterPane Name="ServiceGridPane" Size="65%" Separator-Visible="False">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxGridView ID="DataGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                    ClientInstanceName="ClientDataGrid" Width="100%" KeyFieldName="ItemID"
                                    OnCustomCallback="DataGrid_CustomCallback"
                                    OnCustomDataCallback="DataGrid_CustomDataCallback"
                                    OnCustomUnboundColumnData="DataGrid_CustomUnboundColumnData"
                                    OnCustomColumnDisplayText="DataGrid_CustomColumnDisplayText"
                                    OnHtmlDataCellPrepared="DataGrid_HtmlDataCellPrepared">
                                    <Columns>
                                        <dx:GridViewCommandColumn VisibleIndex="0" Width="150" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                            <HeaderTemplate>
                                                <dx:ASPxButton runat="server" Text="Thêm mới" RenderMode="Link" AutoPostBack="false">
                                                    <Image Url="../Content/images/action/add.gif"></Image>
                                                    <ClientSideEvents Click="ClientDataGrid_AddNewButtonClick" />
                                                </dx:ASPxButton>
                                            </HeaderTemplate>
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="DataGridEdit" Text="Edit" Image-Url="../Content/images/action/edit.gif">
                                                    <Styles>
                                                        <Style Paddings-PaddingRight="1px"></Style>
                                                    </Styles>
                                                </dx:GridViewCommandColumnCustomButton>
                                                <dx:GridViewCommandColumnCustomButton ID="DataGridDelete" Text="Delete" Image-Url="../Content/images/action/delete.gif">
                                                    <Styles>
                                                        <Style Paddings-PaddingLeft="1px"></Style>
                                                    </Styles>
                                                </dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="ITEM" VisibleIndex="1" Caption="Mã sản phẩm" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2" Caption="Tên sản phẩm" Width="300" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="FuelType" VisibleIndex="3" Caption="Loại NL" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="Fuel" VisibleIndex="4" Caption="Nhiên liệu" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataTextColumn FieldName="GroupItem" VisibleIndex="5" Caption="Nhóm sản phẩm" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="GroupItemName" UnboundType="String" VisibleIndex="6" Caption="Tên nhóm sản phẩm" Width="270" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataCheckColumn FieldName="Owned" VisibleIndex="7" Caption="Tự mua?" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataCheckColumn>
                                        <dx:GridViewDataCheckColumn FieldName="Hired" VisibleIndex="8" Caption="Có thuê ngoài?" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataCheckColumn>
                                        <dx:GridViewDataCheckColumn FieldName="Active" VisibleIndex="9" Caption="Sử dụng" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataCheckColumn>
                                        <dx:GridViewDataColumn UnboundType="String" VisibleIndex="10" Width="40%">
                                            <Settings AllowAutoFilter="False" AllowSort="False" />
                                        </dx:GridViewDataColumn>
                                    </Columns>
                                    <Styles>
                                        <AlternatingRow Enabled="true" />
                                    </Styles>
                                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                    <SettingsSearchPanel Visible="false" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="ITEM;Name;FuelType;GroupItem" />
                                    <Paddings Padding="0px" />
                                    <Border BorderWidth="1px" />
                                    <BorderBottom BorderWidth="0px" />
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <SettingsPager Visible="true" PageSize="100" Mode="ShowPager" />
                                    <ClientSideEvents EndCallback="ClientDataGrid_EndCallback"
                                        FocusedRowChanged="ClientDataGrid_FocusedRowChanged"
                                        RowDblClick="ClientDataGrid_RowDblClick"
                                        CustomButtonClick="ClientDataGrid_CustomButtonClick" />
                                </dx:ASPxGridView>
                            </dx:SplitterContentControl>
                        </ContentCollection>
                        <PaneStyle Border-BorderWidth="0">
                            <BorderTop BorderWidth="0px"></BorderTop>
                        </PaneStyle>
                    </dx:SplitterPane>
                    <dx:SplitterPane Name="CompanyGridPane" Size="35%" Separator-Visible="False">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxGridView ID="CompanyGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                    ClientInstanceName="ClientCompanyGrid" Width="100%" KeyFieldName="ID"
                                    OnCustomCallback="CompanyGrid_CustomCallback">
                                    <Columns>
                                        <dx:GridViewCommandColumn VisibleIndex="0" Width="150" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                            <HeaderTemplate>
                                                <dx:ASPxButton runat="server" Text="Thêm mới" RenderMode="Link" AutoPostBack="false">
                                                    <Image Url="../Content/images/action/add.gif"></Image>
                                                    <ClientSideEvents Click="ClientCompanyGrid_AddNewButtonClick" />
                                                </dx:ASPxButton>
                                            </HeaderTemplate>
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="CompanyGridDelete" Text="Delete" Image-Url="../Content/images/action/delete.gif">
                                                    <Styles>
                                                        <Style Paddings-PaddingLeft="1px"></Style>
                                                    </Styles>
                                                </dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="AreaCode" VisibleIndex="1" Caption="Khu vực" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ShortName" VisibleIndex="2" Caption="Mã đơn vị" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="NameV" VisibleIndex="3" Caption="Tên đơn vi" Width="450" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <Styles>
                                        <AlternatingRow Enabled="true" />
                                    </Styles>
                                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />

                                    <Paddings Padding="0px" />
                                    <Border BorderWidth="1px" />
                                    <BorderBottom BorderWidth="0px" />
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <SettingsPager Visible="true" PageSize="100" Mode="ShowPager" />
                                    <ClientSideEvents CustomButtonClick="ClientCompanyGrid_CustomButtonClick" />
                                </dx:ASPxGridView>
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
    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="DataGrid"></dx:ASPxGridViewExporter>


    <dx:ASPxPopupControl ID="EditPopupControl" runat="server" Width="350" Height="150" AllowDragging="True" HeaderText="" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientEditPopupControl" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditForm" runat="server" RequiredMarkDisplayMode="None" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientEditForm"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="Mã Loại TTB">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="CodeEditor" Width="255" ClientInstanceName="ClientCodeEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Tên loại TTB">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="NameEditor" Width="255" ClientInstanceName="ClientNameEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Loại NL">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="FuelTypeEditor" runat="server" Width="255" ClientInstanceName="ClientFuelTypeEditor">
                                        <Items>
                                            <dx:ListEditItem Value="" Text="" />
                                            <dx:ListEditItem Value="X" Text="Xăng" />
                                            <dx:ListEditItem Value="D" Text="Dầu" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="ĐM tiêu hao NL">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="FuelEditor" Width="255" ClientInstanceName="ClientFuelEditor">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Nhóm dịch vụ">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="GroupEditor" runat="server" Width="255" ClientInstanceName="ClientGroupEditor" OnInit="GroupEditor_Init">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                        <ClientSideEvents ValueChanged="ClientGroupEditor_ValueChanged" />
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Tự mua" Name="Owned">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox ID="OwnedEditor" runat="server" ClientInstanceName="ClientOwnedEditor"></dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Thuê ngoài" Name="Hired">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox ID="HiredEditor" runat="server" ClientInstanceName="ClientHiredEditor"></dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Theo dõi">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox ID="ActiveEditor" runat="server" ClientInstanceName="ClientActiveEditor"></dx:ASPxCheckBox>
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


    <dx:ASPxPopupControl ID="CompanyPopup" runat="server" ClientInstanceName="ClientCompanyPopup" Width="550px" Height="300px" HeaderText=""
        Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ShowFooter="true">
        <HeaderStyle Font-Bold="True" Font-Size="Medium">
            <Paddings PaddingBottom="5px" PaddingTop="5px" />
        </HeaderStyle>
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                <dx:CompanyLOV runat="server" ID="CompanyLOV" />
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Đóng" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientCompanyPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApply" runat="server" Text="Chấp nhận" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="ClientAddCompanyButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>

</asp:Content>

