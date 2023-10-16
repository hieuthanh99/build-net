<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="KTQTCompanyStores.aspx.cs" Inherits="Configs_KTQTCompanyStores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/Common.js"></script>
    <script src="../../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../../signalr/hubs"></script>
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
                ClientFleetTypeEditor.SetValue("");
                //ClientRouteEditor.SetValue("");
                ClientRoute2WEditor.SetValue("");
                ClientCountryEditor.SetValue("");
                ClientOriEditor.SetValue("");
                ClientDesEditor.SetValue("");
                ClientACIDEditor.SetValue("");
                ClientDirectionEditor.SetValue("X");
                ClientNetworkEditor.SetValue("XXX");
                ClientDivisionEditor.SetValue(null);
                ClientCostGroupEditor.SetValue(null);
                ClientAccLevel1Editor.SetValue("");
                ClientAccLevel2Editor.SetValue("");
                ClientAccLevel3Editor.SetValue("");
                ClientAccLevel4Editor.SetValue("");
                ClientAccLevel5Editor.SetValue("");
                ClientMaBoPhanEditor.SetValue("");
                ClientManagermentCodeEditor.SetValue("");
                ClientACCodeEditor.SetValue("");
                ClientOriCountryEditor.SetValue("");
                ClientDesCountryEditor.SetValue("");
                ClientReportGroupEditor.SetValue("");

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
                        ClientFleetTypeEditor.SetValue(values["FleetType"]);
                        //ClientRouteEditor.SetValue(values["AllocatedRT"]);
                        ClientRoute2WEditor.SetValue(values["Route2W"]);
                        ClientCountryEditor.SetValue(values["Country"]);
                        ClientOriEditor.SetValue(values["Ori"]);
                        ClientDesEditor.SetValue(values["Des"]);
                        ClientDirectionEditor.SetValue(values["Direction"]);
                        ClientNetworkEditor.SetValue(values["Network"]);
                        ClientDivisionEditor.SetValue(values["Division"]);
                        ClientCostGroupEditor.SetValue(values["CostGroup"]);
                        //ClientCostTypeEditor.SetValue(values["CostType"]);
                        ClientAccLevel1Editor.SetValue(values["AccLevel1"]);
                        ClientAccLevel2Editor.SetValue(values["AccLevel2"]);
                        ClientAccLevel3Editor.SetValue(values["AccLevel3"]);
                        ClientAccLevel4Editor.SetValue(values["AccLevel4"]);
                        ClientAccLevel5Editor.SetValue(values["AccLevel5"]);
                        ClientMaBoPhanEditor.SetValue(values["MaBoPhan"]);
                        ClientManagermentCodeEditor.SetValue(values["ManagermentCode"]);
                        ClientACCodeEditor.SetValue(values["ACCode"]);
                        ClientOriCountryEditor.SetValue(values["OriCountry"]);
                        ClientDesCountryEditor.SetValue(values["DesCountry"]);
                        ClientReportGroupEditor.SetValue(values["ReportGroup"]);
                        ClientAllocateKEditor.SetValue(values["AllocateK"] == "True" ? true : false);

                        var value = ClientFltTypeEditor.GetValue();
                        DoCallback(ClientACIDEditor, function () {
                            ClientACIDEditor.PerformCallback('Refresh|' + value);
                        });
                        ClientACIDEditor.SetValue(values["ACID"]);

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
                    var key = ClientCompaniesGrid.GetFocusedNodeKey();
                    DoCallback(ClientCompanyStoresGrid, function () {
                        ClientCompanyStoresGrid.PerformCallback('Refresh|' + key);
                    });
                }
                else {
                    alert(s.cpResult);
                }
            }
        }

        function ClientEditPopupControl_Closing(s, e) {
            ChangeState("List", "", "");
        }

        function ClientApplyToVersion_Click(s, e) {
            ClientApplyVersionPopup.Show();
        }

        function ClientSyncData_Click(s, e) {
            var cf = confirm("Bạn chắc chắn muốn đồng bộ dữ liệu từ PMS không?");
            if (cf) {
                var key = ClientCompaniesGrid.GetFocusedNodeKey();
                DoCallback(ClientCompanyStoresGrid, function () {
                    ClientCompanyStoresGrid.PerformCallback("SYNC_DATA|" + key);
                });
            }
        }

        function ClientApplyVersionPopup_Shown(s, e) {
            var key = ClientCompaniesGrid.GetFocusedNodeKey();
            if (key == null) return;
            DoCallback(ClientVersionGrid, function () {
                ClientVersionGrid.PerformCallback('LoadAllVersion');
            });
        }

        function ClientApplyVersionPopup_CloseUp(s, e) {

        }

        function ClientApplyToVersionButton_Click(s, e) {
            //if (!ClientVersionGrid.IsDataRow(ClientVersionGrid.GetFocusedRowIndex()))
            //    return;
            //var versionID = ClientVersionGrid.GetRowKey(ClientVersionGrid.GetFocusedRowIndex());
            //var companyID = ClientCompaniesGrid.GetFocusedNodeKey();

            //var cf = confirm("Confirm apply the changes to selected version?");
            //if (cf) {
            //    DoCallback(ClientVersionGrid, function () {
            //        ClientVersionGrid.PerformCallback('ApplyToVersion|' + versionID + "|" + companyID);
            //    });
            //}

            var verKeys = [];
            verKeys = ClientVersionGrid.GetSelectedKeysOnPage();

            if (verKeys.length > 0) {
                var cf = confirm("Confirm apply the changes to selected version?");
                if (cf) {
                    var companyID = ClientCompaniesGrid.GetFocusedNodeKey();
                    var args = "ApplyToVersion|" + companyID + "|" + verKeys.join("|")
                    DoCallback(ClientVersionGrid, function () {
                        ClientVersionGrid.PerformCallback(args);
                    });
                }
            }
            else {
                alert("Please select a version.");
            }

        }

        function ClientVersionGrid_EndCallback(s, e) {
            if (s.cpCommand == "ApplyToVersion") {
                if (s.cpResult == "Success") {
                    ClientApplyVersionPopup.Hide();
                }
                else {
                    alert(s.cpResult);
                }
            }

        }

        function ClientFltTypeEditor_ValueChanged(s, e) {
            var value = s.GetValue();
            DoCallback(ClientACIDEditor, function () {
                ClientACIDEditor.PerformCallback('Refresh|' + value);
            });
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
                                        <dx:TreeListTextColumn FieldName="NameV" VisibleIndex="1" Caption="Company Name" CellStyle-Wrap="True">
                                            <DataCellTemplate>
                                                <asp:Label runat="server" Text='<%# Eval("CompanyID").ToString().Trim() +"-"+ Eval("NameV") %>'></asp:Label>
                                            </DataCellTemplate>
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="ShortName" VisibleIndex="2" Caption="Short Name" Width="80"></dx:TreeListTextColumn>
                                    </Columns>
                                    <Styles>
                                        <AlternatingNode Enabled="True"></AlternatingNode>
                                    </Styles>
                                    <SettingsSelection AllowSelectAll="true" Enabled="true" Recursive="true" />
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
                                        <dx:GridViewCommandColumn VisibleIndex="0" Width="180">
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="Edit" Text="Edit" Image-Url="../Content/images/action/edit.gif"></dx:GridViewCommandColumnCustomButton>
                                                <dx:GridViewCommandColumnCustomButton ID="Delete" Text="Remove" Image-Url="../Content/images/action/delete.gif"></dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="Seq" VisibleIndex="1" Caption="Seq" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Sorting" VisibleIndex="2" Caption="Sorting" Width="90" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="3" Caption="Description" Width="350" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Calculation" VisibleIndex="4" Caption="Calc" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Curr" VisibleIndex="5" Caption="Curr" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="AllocatedDriver" VisibleIndex="6" Caption="Driver" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Carrier" VisibleIndex="7" Caption="Carrier" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="AllocatedFLT" VisibleIndex="8" Caption="Flt Type" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Fleet_Type" VisibleIndex="8" Caption="Fleet Type" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="AllocatedRT" VisibleIndex="9" Caption="Route" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Airports" VisibleIndex="10" Caption="Airports" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ACID" VisibleIndex="11" Caption="AC ID" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="AllocateFltDirection" VisibleIndex="12" Caption="Direction" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Network" VisibleIndex="13" Caption="Network" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Ori" VisibleIndex="15" Caption="Ori" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Des" VisibleIndex="16" Caption="Des" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="OriCountry" VisibleIndex="17" Caption="Ori Country" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="DesCountry" VisibleIndex="18" Caption="Des Country" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Division" VisibleIndex="19" Caption="Division" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="CostGroup" VisibleIndex="20" Caption="Cost Group" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="CostType" VisibleIndex="21" Caption="Cost Type" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="AccLevel1" VisibleIndex="22" Caption="AccLevel1" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="AccLevel1" VisibleIndex="23" Caption="AccLevel1" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="AccLevel2" VisibleIndex="24" Caption="AccLevel2" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="AccLevel3" VisibleIndex="25" Caption="AccLevel3" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="AccLevel4" VisibleIndex="26" Caption="AccLevel4" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="AccLevel5" VisibleIndex="27" Caption="AccLevel5" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="MaBoPhan" VisibleIndex="28" Caption="MaBoPhan" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ManagermentCode" VisibleIndex="29" Caption="ManagermentCode" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ACCode" VisibleIndex="30" Caption="ACCode" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataCheckColumn FieldName="AllocateK" VisibleIndex="31" Caption="Allocate K" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataCheckColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="RepID" VisibleIndex="32" Caption="Cost Structure" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesComboBox
                                                ValueType="System.Int32" DropDownStyle="DropDownList">
                                                <ClearButton DisplayMode="OnHover" />
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="ReportGroup" VisibleIndex="28" Caption="Report Group" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesComboBox
                                                ValueType="System.String" DropDownStyle="DropDownList">
                                                <ClearButton DisplayMode="OnHover" />
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
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
                                    <SettingsResizing ColumnResizeMode="Control" />
                                    <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
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
                                            &nbsp;&nbsp;                                                                                                          
                                            <dx:ASPxButton ID="btnApplyVersion" runat="server" Text="Apply To Version" RenderMode="Button" AutoPostBack="false">
                                                <ClientSideEvents Click="ClientApplyToVersion_Click" />
                                            </dx:ASPxButton>
                                            &nbsp;&nbsp;                                                                                                          
                                            <dx:ASPxButton ID="btnSyncData" runat="server" Text="Sync PMS" RenderMode="Button" AutoPostBack="false">
                                                <ClientSideEvents Click="ClientSyncData_Click" />
                                                <Image Url="../Content/images/execute.png" Height="16"></Image>
                                            </dx:ASPxButton>
                                            <%--  &nbsp;&nbsp;                                                                                                          
                                            <dx:ASPxButton ID="btnExport" runat="server" Text="Export Excel" RenderMode="Button" AutoPostBack="false">
                                                <ClientSideEvents Click="function(s, e) {{ ClientParamsPopup.Show(); }}" />
                                                <Image Url="../Content/images/action/export.png" Height="16"></Image>
                                            </dx:ASPxButton>--%>
                                        </StatusBar>
                                    </Templates>
                                    <ClientSideEvents CustomButtonClick="ClientCompanyStoresGrid_CustomButtonClick"
                                        EndCallback="ClientCompanyStoresGrid_EndCallback" />
                                </dx:ASPxGridView>
                                <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="CompanyStoresGrid"></dx:ASPxGridViewExporter>
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
    <dx:ASPxPopupControl ID="ApplyVersionPopup" runat="server" Width="550" Height="450" AllowDragging="True" HeaderText="Select Version" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientApplyVersionPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxGridView ID="VersionGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientVersionGrid" Width="100%" KeyFieldName="VersionID"
                    OnCustomCallback="VersionGrid_CustomCallback">
                    <Columns>
                        <dx:GridViewCommandColumn Name="Checkbox" ShowSelectCheckbox="true" Width="30" VisibleIndex="1" SelectCheckBoxPosition="Left" SelectAllCheckboxMode="AllPages">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="VersionYear" VisibleIndex="2" Caption="Year" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="VersionType" VisibleIndex="3" Caption="Type" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="4" Caption="Description" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="5" Caption="Status" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Styles>
                        <AlternatingRow Enabled="true" />
                        <TitlePanel HorizontalAlign="Left"></TitlePanel>
                        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                    </Styles>
                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="300" VerticalScrollBarStyle="Standard" />
                    <Paddings Padding="0px" />
                    <Border BorderWidth="0px" />
                    <SettingsBehavior AllowFocusedRow="True" />
                    <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                    <ClientSideEvents EndCallback="ClientVersionGrid_EndCallback" />
                </dx:ASPxGridView>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Cancel" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientApplyVersionPopup.Hide(); }}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApplyToVersion" runat="server" Text="Apply" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="ClientApplyToVersionButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="ClientApplyVersionPopup_Shown" CloseUp="ClientApplyVersionPopup_CloseUp" />
    </dx:ASPxPopupControl>

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
                        <%--   <dx:TreeListDataColumn FieldName="Sorting" VisibleIndex="2" Caption="Sorting" Width="90" HeaderStyle-HorizontalAlign="Center">
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
                <dx:ASPxFormLayout ID="EditForm" runat="server" RequiredMarkDisplayMode="Auto" ColCount="2" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientEditForm"
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
                                    <dx:ASPxTokenBox runat="server" ID="CarrierEditor" Width="255" ClientInstanceName="ClientCarrierEditor" OnInit="CarrierEditor_Init">
                                    </dx:ASPxTokenBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Flt Type">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTokenBox runat="server" ID="FltTypeEditor" Width="255" ClientInstanceName="ClientFltTypeEditor" OnInit="FltTypeEditor_Init">
                                        <%--<ClientSideEvents ValueChanged="ClientFltTypeEditor_ValueChanged" />--%>
                                    </dx:ASPxTokenBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Fleet Type">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTokenBox runat="server" ID="FleetTypeEditor" Width="250" ClientInstanceName="ClientFleetTypeEditor" OnInit="FleetTypeEditor_Init">
                                    </dx:ASPxTokenBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <%--<dx:LayoutItem Caption="Route">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="RouteEditor" Width="255" ClientInstanceName="ClientRouteEditor" OnInit="RouteEditor_Init">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                        <dx:LayoutItem Caption="Route2W">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTokenBox runat="server" ID="Route2WEditor" Width="255" ClientInstanceName="ClientRoute2WEditor" OnInit="Route2WEditor_Init">
                                    </dx:ASPxTokenBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Country">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTokenBox runat="server" ID="CountryEditor" Width="255" ClientInstanceName="ClientCountryEditor" OnInit="CountryEditor_Init">
                                    </dx:ASPxTokenBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Ori">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTokenBox runat="server" ID="OriEditor" Width="255" ClientInstanceName="ClientOriEditor" OnInit="AirportsEditor_Init">
                                    </dx:ASPxTokenBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Des">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTokenBox runat="server" ID="DesEditor" Width="255" ClientInstanceName="ClientDesEditor" OnInit="AirportsEditor_Init">
                                    </dx:ASPxTokenBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Aircraft">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTokenBox runat="server" ID="ACIDEditor" Width="255" ClientInstanceName="ClientACIDEditor" OnInit="ACIDEditor_Init">
                                        <%--  OnCallback="ACIDEditor_Callback"--%>
                                        <%--  <ClientSideEvents GotFocus="ClientACIDEditor_GotFocus" />--%>
                                    </dx:ASPxTokenBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Direction">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="DirectionEditor" Width="255" ClientInstanceName="ClientDirectionEditor">
                                        <Items>
                                            <dx:ListEditItem Value="A" Text="A-Chuyến bay đến" />
                                            <dx:ListEditItem Value="D" Text="D-Chuyến bay đi" />
                                            <dx:ListEditItem Value="X" Text="X-Tất cả" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Network">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="NetworkEditor" Width="255" ClientInstanceName="ClientNetworkEditor">
                                        <Items>
                                            <dx:ListEditItem Value="INT" Text="INT-Quốc tế" />
                                            <dx:ListEditItem Value="DOM" Text="DOM-Quốc nội" />
                                            <dx:ListEditItem Value="XXX" Text="XXX-Tất cả" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Ori Country">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTokenBox runat="server" ID="OriCountryEditor" Width="250" ClientInstanceName="ClientOriCountryEditor" OnInit="CountryEditor_Init">
                                    </dx:ASPxTokenBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Des Country">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTokenBox runat="server" ID="DesCountryEditor" Width="250" ClientInstanceName="ClientDesCountryEditor" OnInit="CountryEditor_Init">
                                    </dx:ASPxTokenBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Division">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="DivisionEditor" Width="255" ValueType="System.String" ClientInstanceName="ClientDivisionEditor" OnInit="DivisionEditor_Init">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Cost Group">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="CostGroupEditor" Width="255" ValueType="System.String" ClientInstanceName="ClientCostGroupEditor" OnInit="CostGroupEditor_Init">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="AccLevel1">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="AccLevel1Editor" Width="250" ClientInstanceName="ClientAccLevel1Editor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="AccLevel2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="AccLevel2Editor" Width="250" ClientInstanceName="ClientAccLevel2Editor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="AccLevel3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="AccLevel3Editor" Width="250" ClientInstanceName="ClientAccLevel3Editor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="AccLevel4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="AccLevel4Editor" Width="250" ClientInstanceName="ClientAccLevel4Editor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="AccLevel5">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="AccLevel5Editor" Width="250" ClientInstanceName="ClientAccLevel5Editor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="MaBoPhan">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="MaBoPhanEditor" Width="250" ClientInstanceName="ClientMaBoPhanEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="ManagermentCode">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="ManagermentCodeEditor" Width="250" ClientInstanceName="ClientManagermentCodeEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="ACCode">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="ACCodeEditor" Width="250" ClientInstanceName="ClientACCodeEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Report Group">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="ReportGroupEditor" Width="255" ClientInstanceName="ClientReportGroupEditor" OnInit="ReportGroupEditor_Init">

                                        <%--   <ValidationSettings>
                                            <RequiredField IsRequired="true" ErrorText="This field is required" />
                                        </ValidationSettings>--%>
                                    </dx:ASPxComboBox>
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

    <dx:ASPxPopupControl ID="ParamsPopup" runat="server" Width="150" Height="100" AllowDragging="True" HeaderText="Download Company Stores" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientParamsPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="ParamsForm" runat="server" ColCount="4" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                    AlignItemCaptionsInAllGroups="true" Width="100%" OptionalMark="">
                    <Items>

                        <dx:LayoutItem Caption="Area">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <%--<dx:ASPxComboBox ID="cboArea1" runat="server" Width="120px" OnInit="cboArea1_Init">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>--%>
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" runat="server" Text="Cancel" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientParamsPopup.Hide(); }}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" runat="server" Text="Download" UseSubmitBehavior="true" OnClick="btnExport_Click">
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>


</asp:Content>

