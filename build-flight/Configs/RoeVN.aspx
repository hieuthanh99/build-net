<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RoeVN.aspx.cs" Inherits="Pages_RoeVN" %>

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
                var versionId = ClientSelectedVerID.GetValue();
                if (versionId == null || versionId == undefined) {
                    ShowMessage("Bạn phải chọn Version trước khi thêm mới.");
                    return;
                }

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

            //ClientVerIDEditor.SetValue(null);
            ClientCurrEditor.SetValue("");
            ClientM01Editor.SetValue(0);
            ClientM02Editor.SetValue(0);
            ClientM03Editor.SetValue(0);
            ClientM04Editor.SetValue(0);
            ClientM05Editor.SetValue(0);
            ClientM06Editor.SetValue(0);
            ClientM07Editor.SetValue(0);
            ClientM08Editor.SetValue(0);
            ClientM09Editor.SetValue(0);
            ClientM10Editor.SetValue(0);
            ClientM11Editor.SetValue(0);
            ClientM12Editor.SetValue(0);
            ClientNoteEditor.SetValue("");

            if (command == "NEW") {
                ClientCurrEditor.Focus();
                ClientEditPopupControl.Show();
            }
            else if (command == "EDIT") {
                ClientDataGrid.GetValuesOnCustomCallback("EditForm|" + command + "|" + key, function (values) {
                    var setValuesFunc = function () {
                        HideLoadingPanel();
                        if (!values)
                            return;

                        //ClientVerIDEditor.SetValue(values["Ver_ID"]);
                        ClientCurrEditor.SetValue(values["Curr"]);
                        ClientM01Editor.SetValue(values["M01"]);
                        ClientM02Editor.SetValue(values["M02"]);
                        ClientM03Editor.SetValue(values["M03"]);
                        ClientM04Editor.SetValue(values["M04"]);
                        ClientM05Editor.SetValue(values["M05"]);
                        ClientM06Editor.SetValue(values["M06"]);
                        ClientM07Editor.SetValue(values["M07"]);
                        ClientM08Editor.SetValue(values["M08"]);
                        ClientM09Editor.SetValue(values["M09"]);
                        ClientM10Editor.SetValue(values["M10"]);
                        ClientM11Editor.SetValue(values["M11"]);
                        ClientM12Editor.SetValue(values["M12"]);
                        ClientNoteEditor.SetValue(values["Note"]);

                        ClientCurrEditor.Focus();
                        ClientEditPopupControl.Show();
                    };
                    PostponeAction(setValuesFunc, function () { return !!window.ClientCurrEditor });
                });
                ShowLoadingPanel(ClientSplitter.GetMainElement());
            }
        }

        function ClientSaveButton_Click(s, e) {
            if (window.ClientCurrEditor && !ASPxClientEdit.ValidateEditorsInContainerById("EditForm"))
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

        function ClientSelectedVerID_ValueChanged(s, e) {
            var versionId = s.GetValue();
            if (versionId == null) versionId = 0;
            DoCallback(ClientDataGrid, function () {
                ClientDataGrid.PerformCallback("REFRESH|" + versionId);
            });
        }

        function ClientFilterYearEditor_ValueChanged(s, e) {
            DoCallback(ClientSelectedVerID, function () {
                ClientSelectedVerID.PerformCallback();
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
                            <asp:Literal ID="Literal1" runat="server" Text="Roe VN" />
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
                                                                            <dx:MenuItem Name="SyncData" Text="Đồng bộ PMS" ItemStyle-CssClass="menu-item" Image-Url="../Content/images/execute.png" Image-Height="16px" Image-Width="16px">
                                                                            </dx:MenuItem>
                                                                        </Items>
                                                                    </dx:ASPxMenu>
                                                                </div>
                                                                <div style="float: right; width: 750px;">
                                                                    <table style="width: 100%">
                                                                        <tr>
                                                                            <td style="text-align: left; vertical-align: bottom; display: flex; flex-direction: row;">
                                                                                <dx:ASPxSpinEdit runat="server" ID="FilterYearEditor" Width="80" ClientEnabled="true" Caption="Version">
                                                                                    <ClientSideEvents ValueChanged="ClientFilterYearEditor_ValueChanged" />
                                                                                </dx:ASPxSpinEdit>
                                                                                &nbsp;
                                                                                <dx:ASPxComboBox runat="server" ID="cboSelectedVerID" Height="23" Width="170" ClientInstanceName="ClientSelectedVerID" OnCallback="cboSelectedVerID_Callback">
                                                                                    <ClientSideEvents ValueChanged="ClientSelectedVerID_ValueChanged" />
                                                                                </dx:ASPxComboBox>
                                                                            </td>
                                                                            <td style="text-align: right; vertical-align: bottom">
                                                                                <dx:ASPxUploadControl ID="UploadControl" runat="server" ClientInstanceName="ClientUploadControl" ShowProgressPanel="true" NullText="Browse file here"
                                                                                    Width="280px" FileUploadMode="OnPageLoad" UploadMode="Advanced" OnFilesUploadComplete="UploadControl_FilesUploadComplete" BrowseButton-Text="Duyệt file">
                                                                                    <ClientSideEvents FileUploadStart="FileUploadStart"
                                                                                        UploadingProgressChanged="UploadingProgressChanged"
                                                                                        FilesUploadComplete="FilesUploadComplete" />
                                                                                    <ValidationSettings MaxFileSize="10000000" AllowedFileExtensions=".xlsx" ShowErrors="true"></ValidationSettings>
                                                                                </dx:ASPxUploadControl>
                                                                            </td>
                                                                            <td>
                                                                                <dx:ASPxButton ID="btnUpload" ClientInstanceName="ClientUploadButton" runat="server" Text="Đổ dữ liệu" AutoPostBack="false" UseSubmitBehavior="false" CausesValidation="false">
                                                                                    <ClientSideEvents Click="function(s,e){
                                                                                                                FilesUpload(s, e);
                                                                                                            }" />
                                                                                </dx:ASPxButton>
                                                                            </td>
                                                                            <td>
                                                                                <dx:ASPxHyperLink ID="lTemplate" runat="server" Text="Template" NavigateUrl="~/Handler/DownloadTemplate.ashx?id=RoeVN" Cursor="pointer">
                                                                                </dx:ASPxHyperLink>
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
                            ClientInstanceName="ClientDataGrid" Width="100%" KeyFieldName="RoeID">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="Ver_ID" VisibleIndex="1" Caption="Version ID" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Curr" VisibleIndex="2" Caption="Curr" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="M01" VisibleIndex="3" Caption="M01" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="M02" VisibleIndex="4" Caption="M02" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="M03" VisibleIndex="5" Caption="M03" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="M04" VisibleIndex="6" Caption="M04" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="M05" VisibleIndex="7" Caption="M05" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="M06" VisibleIndex="8" Caption="M06" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="M07" VisibleIndex="9" Caption="M07" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="M08" VisibleIndex="10" Caption="M08" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="M09" VisibleIndex="11" Caption="M09" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="M10" VisibleIndex="12" Caption="M10" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="M11" VisibleIndex="13" Caption="M11" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="M12" VisibleIndex="14" Caption="M12" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Note" VisibleIndex="24" Caption="Note" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
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
                        <%-- <dx:LayoutItem Caption="Version">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="VerIDEditor" Width="170" ClientInstanceName="ClientVerIDEditor" OnInit="cboVerID_Init">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                        <dx:LayoutItem Caption="Curr">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="CurrEditor" Width="170" ClientInstanceName="ClientCurrEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                        <dx:LayoutItem Caption="M01">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="M01Editor" Width="170" ClientInstanceName="ClientM01Editor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="M02">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="M02Editor" Width="170" ClientInstanceName="ClientM02Editor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="M03">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="M03Editor" Width="170" ClientInstanceName="ClientM03Editor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="M04">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="M04Editor" Width="170" ClientInstanceName="ClientM04Editor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="M05">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="M05Editor" Width="170" ClientInstanceName="ClientM05Editor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="M06">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="M06Editor" Width="170" ClientInstanceName="ClientM06Editor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="M07">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="M07Editor" Width="170" ClientInstanceName="ClientM07Editor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="M08">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="M08Editor" Width="170" ClientInstanceName="ClientM08Editor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="M09">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="M09Editor" Width="170" ClientInstanceName="ClientM09Editor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="M10">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="M10Editor" Width="170" ClientInstanceName="ClientM10Editor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="M11">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="M11Editor" Width="170" ClientInstanceName="ClientM11Editor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="M12">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="M12Editor" Width="170" ClientInstanceName="ClientM12Editor" DisplayFormatString="N2">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Note" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxMemo runat="server" ID="NoteEditor" Width="420" Rows="3" ClientInstanceName="ClientNoteEditor">
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

    <dx:ASPxPopupControl ID="PopupProgressingPanel" runat="server" ClientInstanceName="PopupProgressingPanel"
        Modal="True" CloseAction="None" Width="400px" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter" AllowDragging="True" PopupAnimationType="None"
        HeaderText="Uploading Info" ShowCloseButton="False" ShowPageScrollbarWhenModal="true">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 100%;">
                            <dx:ASPxProgressBar ID="pbProgressing" ClientInstanceName="pbProgressing" runat="server"
                                Width="100%">
                            </dx:ASPxProgressBar>
                        </td>
                    </tr>
                </table>
                <dx:ASPxPanel ID="pnlProgressingInfo" ClientInstanceName="pnlProgressingInfo" runat="server"
                    Width="100%">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent2" runat="server">
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

</asp:Content>

