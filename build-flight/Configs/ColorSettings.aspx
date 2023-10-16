<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ColorSettings.aspx.cs" Inherits="Pages_ColorSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/Common.js"></script>
    <script type="text/javascript">

        function FileUploadStart(s, e) {
            uploadCompleteFlag = false;
            window.setTimeout("ShowPopupProgressingPanel()", 500);
        }

        function ShowPopupProgressingPanel() {
            if (!uploadCompleteFlag) {
                PopupProgressingPanel.Show();
                pbProgressing.SetPosition(0);
                pnlProgressingInfo.SetContentHtml("");
            }
        }

        function UploadingProgressChanged(s, e) {
            pbProgressing.SetPosition(e.progress);
            var info = e.currentFileName + "&emsp;[" + GetKBytes(e.uploadedContentLength) + " / " + GetKBytes(e.totalContentLength) + "] KBytes";
            pnlProgressingInfo.SetContentHtml(info);
        }

        function GetKBytes(bytes) {
            return Math.floor(bytes / 1024);
        }

        function FilesUploadComplete(s, e) {
            uploadCompleteFlag = true;
            PopupProgressingPanel.Hide();
            var verId = ClientSelectedVerID.GetValue();
            DoCallback(ClientDataGrid, function () {
                ClientDataGrid.PerformCallback("REFRESH|" + verId);
            });
            if (e.callbackData == "error") {
                ShowMessage(e.errorText);
            }
            else if (e.callbackData == "success") {
                ShowMessage("Upload Roe VN success!");
            }
        }

        function ShowMessage(message) {
            window.setTimeout("alert('" + message + "')", 0);
        }

        function FilesUpload(s, e) {
            if (ClientUploadControl.GetText() == "")
                return;
            ClientUploadControl.Upload();
        }

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
            var edit = ClientMenu.GetItemByName("Edit");
            if (edit.GetVisible()) {
                if (!ClientDataGrid.IsDataRow(ClientDataGrid.GetFocusedRowIndex()))
                    return;
                var key = ClientDataGrid.GetRowKey(ClientDataGrid.GetFocusedRowIndex());
                ChangeState("EditForm", "EDIT", key);
                ClientEditPopupControl.SetHeaderText("Cập nhật");
                var state = State;
                ShowEditForm(state.Command, state.Key);
            }
        }

        function ShowEditForm(command, key) {

            ClientMinPercentEditor.SetValue(0);
            ClientMaxPercentEditor.SetValue(0);
            ClientColorEditor.SetValue("");

            if (command == "NEW") {
                ClientMinPercentEditor.Focus();
                ClientEditPopupControl.Show();
            }
            else if (command == "EDIT") {
                ClientDataGrid.GetValuesOnCustomCallback("EditForm|" + command + "|" + key, function (values) {
                    var setValuesFunc = function () {
                        HideLoadingPanel();
                        if (!values)
                            return;
                        ClientMinPercentEditor.SetValue(values["MinPecent"]);
                        ClientMaxPercentEditor.SetValue(values["MaxPecent"]);
                        ClientColorEditor.SetValue(values["Color"]);

                        ClientMinPercentEditor.Focus();
                        ClientEditPopupControl.Show();
                    };
                    PostponeAction(setValuesFunc, function () { return !!window.ClientMinPercentEditor });
                });
                ShowLoadingPanel(ClientSplitter.GetMainElement());
            }
        }

        function ClientSaveButton_Click(s, e) {
            if (window.ClientVerIDEditor && !ASPxClientEdit.ValidateEditorsInContainerById("EditForm"))
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


        function ClientFilterYearEditor_ValueChanged(s, e) {
            DoCallback(ClientDataGrid, function () {
                ClientDataGrid.PerformCallback("REFRESH|" + s.GetValue());
            });
        }

    </script>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" SeparatorVisible="false" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Name="Menu" Size="115" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div class="title">
                            <asp:Literal ID="Literal1" runat="server" Text="Color Settings" />
                        </div>
                        <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                            AlignItemCaptionsInAllGroups="true" Width="100%">
                            <Items>
                                <dx:LayoutGroup ShowCaption="False" GroupBoxDecoration="HeadingLine" SettingsItemCaptions-HorizontalAlign="Right" ColCount="1">
                                    <Items>
                                        <dx:LayoutItem ShowCaption="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td style="width: 100%">
                                                                <div style="float: left">
                                                                    <dx:ASPxMenu ID="mMain" runat="server" ClientInstanceName="ClientMenu" CssClass="main-menu" Theme="Moderno">
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
                                                                <div style="float: left; width: 750px;">
                                                                    <table style="width: 100%">
                                                                        <tr>
                                                                            <td style="text-align: left; vertical-align: bottom; display: flex; flex-direction: row;">
                                                                                <dx:ASPxSpinEdit runat="server" ID="FilterYearEditor" Width="80" ClientEnabled="true" Caption="Year">
                                                                                    <ClientSideEvents ValueChanged="ClientFilterYearEditor_ValueChanged" />
                                                                                </dx:ASPxSpinEdit>

                                                                            </td>

                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                    <SettingsItemCaptions HorizontalAlign="Right"></SettingsItemCaptions>
                                </dx:LayoutGroup>
                            </Items>
                            <Styles>
                                <LayoutGroupBox>
                                    <Caption CssClass="layoutGroupBoxCaption"></Caption>
                                </LayoutGroupBox>
                            </Styles>
                        </dx:ASPxFormLayout>
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
                            ClientInstanceName="ClientDataGrid" Width="100%" KeyFieldName="Id">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="ForYear" VisibleIndex="2" Caption="Year" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="MinPecent" VisibleIndex="3" Caption="Min Value (%)" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="MaxPecent" VisibleIndex="4" Caption="Max Value (%)" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataColorEditColumn FieldName="Color" VisibleIndex="4" Caption="Color" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataColorEditColumn>
                            </Columns>
                            <Styles>
                                <AlternatingRow Enabled="true" />
                            </Styles>
                            <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                            <%-- <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="ACID;ACGroup;Note" />--%>
                            <Paddings Padding="0px" />
                            <Border BorderWidth="1px" />
                            <BorderBottom BorderWidth="1px" />
                            <SettingsBehavior AllowFocusedRow="True" />
                            <SettingsResizing ColumnResizeMode="Control" />
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
                        <dx:LayoutItem Caption="Min Value (%)">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="MinPercentEditor" MinValue="0" Width="170" ClientInstanceName="ClientMinPercentEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Max Value (%)">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="MaxPercentEditor" MinValue="0" Width="170" AllowNull="true" ClearButton-DisplayMode="OnHover" ClientInstanceName="ClientMaxPercentEditor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Color">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxColorEdit runat="server" ID="ColorEditor" Width="170" ClientInstanceName="ClientColorEditor">
                                    </dx:ASPxColorEdit>
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

