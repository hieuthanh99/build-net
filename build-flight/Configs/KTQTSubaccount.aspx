<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="KTQTSubaccount.aspx.cs" Inherits="Pages_KTQTSubaccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/Common.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../signalr/hubs"></script>
    <script type="text/javascript">

        function ClientSplitter_PaneResized(s, e) {
            if (e.pane.name == "GridPane") {
                ClientDataGrid.SetHeight(e.pane.GetClientHeight());
            }
            if (e.pane.name == "FastCode") {
                ClientFastCodeGrid.SetHeight(e.pane.GetClientHeight());
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
                ShowEditForm(state.Command, State.Key);

                e.processOnServer = false;
                return;
            } else if (name.toUpperCase() == "EDIT") {
                var key = ClientDataGrid.GetFocusedNodeKey();
                ChangeState("EditForm", name.toUpperCase(), key);
                ClientEditPopupControl.SetHeaderText("Cập nhật");
                var state = State;
                ShowEditForm(state.Command, State.Key);

                e.processOnServer = false;
                return;
            } else if (name.toUpperCase() == "UPDATESEQ") {
                var cf = confirm("Confirm update subaccount seq?");
                if (cf) {
                    DoCallback(ClientDataGrid, function () {
                        ClientDataGrid.PerformCallback('UPDATESEQ');
                    });
                }

                e.processOnServer = false;
                return;
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
            e.processOnServer = true;
        }

        function ClientUpdateSeqButton_Click(s, e) {
            var cf = confirm("Confirm update subaccount seq?");
            if (cf) {
                DoCallback(ClientDataGrid, function () {
                    ClientDataGrid.PerformCallback('UPDATESEQ');
                });
            }
        }

        function ClientDataGrid_NodeDblClick(s, e) {
            var key = ClientDataGrid.GetFocusedNodeKey();
            ChangeState("EditForm", "EDIT", key);
            //ClientEditPopupControl.SetHeaderText("Cập nhật");
            //var state = State;
            //ShowEditForm(state.Command, state.Key);
        }

        function ShowEditForm(command, key) {

            ClientParentEditor.SetValue(key);
            ClientDescriptionEditor.SetValue("");
            ClientCalculationEditor.SetValue("");
            ClientActiveEditor.SetValue(true);
            ClientAccountGroupEditor.SetValue(null);
            //ClientAccountTypeEditor.SetValue(null);
            //ClientActivityEditor.SetValue(null);
            ClientSeqEditor.SetValue(0);
            ClientSortingEditor.SetValue("");
            ClientNoteEditor.SetValue("");
            //ClientDriverEditor.SetValue("");
            //ClientCarrierEditor.SetValue("");
            //ClientFltTypeEditor.SetValue("");
            //ClientFleetTypeEditor.SetValue("");
            //ClientRouteEditor.SetValue("");
            //ClientRoute2WEditor.SetValue("");
            //ClientCountryEditor.SetValue("");
            //ClientAirportsEditor.SetValue("");
            //ClientOriEditor.SetValue("");
            //ClientDesEditor.SetValue("");
            //ClientACIDEditor.SetValue("");
            //ClientDirectionEditor.SetValue("X");
            //ClientNetworkEditor.SetValue("XXX");
            //ClientProfitEditor.SetValue(null);
            //ClientCostTypeEditor.SetValue("");
            //ClientCostGroupEditor.SetValue("");
            ClientDivisionEditor.SetValue("");
            //ClientAccLevel1Editor.SetValue("");
            //ClientAccLevel2Editor.SetValue("");
            //ClientAccLevel3Editor.SetValue("");
            //ClientAccLevel4Editor.SetValue("");
            //ClientAccLevel5Editor.SetValue("");
            //ClientMaBoPhanEditor.SetValue("");
            //ClientManagermentCodeEditor.SetValue("");
            //ClientACCodeEditor.SetValue("");
            //ClientOriCountryEditor.SetValue("");
            //ClientDesCountryEditor.SetValue("");
            //ClientDirectIndirectEditor.SetValue("");
            ClientIsCommercialEditor.SetValue(false);
            ClientOutAllowUpdateEditor.SetValue(false);
            ClientDecAllowUpdateEditor.SetValue(false);

            ShowLoadingPanel(ClientSplitter.GetMainElement());
            DoCallback(ClientParentEditor, function () {
                ClientParentEditor.PerformCallback('');
            });

        }

        function ClientParentEditor_EndCallback(s, e) {
            var command = State.Command;
            if (command == "NEW") {
                HideLoadingPanel();
                var key = ClientDataGrid.GetFocusedNodeKey();
                ClientParentEditor.SetValue(key);
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

            ClientParentEditor.SetValue(values["ParentID"]);
            ClientDescriptionEditor.SetValue(values["Description"]);
            ClientCalculationEditor.SetValue(values["Calculation"]);
            ClientAccountGroupEditor.SetValue(values["AccountGroup"]);
            //ClientAccountTypeEditor.SetValue(parseInt(values["AccountType"]));
            //ClientActivityEditor.SetValue(values["ActivityID"]);
            //ClientDriverEditor.SetValue(values["AllocatedDriver"]);
            //ClientCarrierEditor.SetValue(values["Carrier"]);
            //ClientFltTypeEditor.SetValue(values["AllocatedFLT"]);
            //ClientFleetTypeEditor.SetValue(values["FleetType"]);
            //ClientRouteEditor.SetValue(values["AllocatedRT"]);
            //ClientRoute2WEditor.SetValue(values["Route2W"]);
            //ClientCountryEditor.SetValue(values["Country"]);
            //ClientOriEditor.SetValue(values["Ori"]);
            //ClientDesEditor.SetValue(values["Des"]);
            //ClientAirportsEditor.SetValue(values["Airports"]);
            //ClientACIDEditor.SetValue(values["ACID"]);
            //ClientDirectionEditor.SetValue(values["Direction"]);
            //ClientNetworkEditor.SetValue(values["Network"]);
            //ClientProfitEditor.SetValue(values["RouteProfitID"]);
            //ClientCostTypeEditor.SetValue(values["CostType"]);
            //ClientCostGroupEditor.SetValue(values["CostGroup"]);
            ClientActiveEditor.SetValue(values["Active"] == "True" ? true : false);
            ClientSeqEditor.SetValue(parseInt(values["Seq"]));
            ClientSortingEditor.SetValue(values["Sorting"]);
            ClientNoteEditor.SetValue(values["Note"]);
            ClientDivisionEditor.SetValue(values["Division"]);
            //ClientAccLevel1Editor.SetValue(values["AccLevel1"]);
            //ClientAccLevel2Editor.SetValue(values["AccLevel2"]);
            //ClientAccLevel3Editor.SetValue(values["AccLevel3"]);
            //ClientAccLevel4Editor.SetValue(values["AccLevel4"]);
            //ClientAccLevel5Editor.SetValue(values["AccLevel5"]);
            //ClientMaBoPhanEditor.SetValue(values["MaBoPhan"]);
            //ClientManagermentCodeEditor.SetValue(values["ManagermentCode"]);
            //ClientACCodeEditor.SetValue(values["ACCode"]);
            //ClientOriCountryEditor.SetValue(values["OriCountry"]);
            //ClientDesCountryEditor.SetValue(values["DesCountry"]);
            //ClientDirectIndirectEditor.SetValue(values["DirectIndirect"]);
            ClientIsCommercialEditor.SetValue(values["IsCommercial"] == "True" ? true : false);
            ClientOutAllowUpdateEditor.SetValue(values["OutAllowUpdate"] == "True" ? true : false);
            ClientDecAllowUpdateEditor.SetValue(values["DecAllowUpdate"] == "True" ? true : false);

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

        function ClientDataGrid_NodeClick(s, e) {

            ClientMenu.GetItemByName('Edit').SetEnabled(false);
            ClientMenu.GetItemByName('Delete').SetEnabled(false);
            ClientMenu.GetItemByName('UpdateSeq').SetEnabled(false);
            ClientMenu.GetItemByName('SyncData').SetEnabled(false);

            var key = s.GetFocusedNodeKey();
            ChangeState("List", "", key);
            var args = "LoadFastCode|" + key;
            DoCallback(ClientSubaccountCallback, function () {
                ClientSubaccountCallback.PerformCallback('CheckPermistion|' + key);
            });
        }

        function ClientSubaccountCallback_CallbackComplete(s, e) {
            ClientMenu.GetItemByName('Edit').SetEnabled(true);
            ClientMenu.GetItemByName('Delete').SetEnabled(true);
            ClientMenu.GetItemByName('UpdateSeq').SetEnabled(true);
            ClientMenu.GetItemByName('SyncData').SetEnabled(true);

            ClientMenu.GetItemByName('Edit').SetVisible(e.result === 'OK');
            ClientMenu.GetItemByName('Delete').SetVisible(e.result === 'OK');
            ClientMenu.GetItemByName('UpdateSeq').SetVisible(e.result === 'OK');
            ClientMenu.GetItemByName('SyncData').SetVisible(e.result === 'OK');
        }

    </script>
     <style>
         .dxtlControl_Office2010Blue caption {
             font-weight: bold;
             color: #1e395b;
             padding: 3px 3px 5px;
             text-align: left;
             background: #bdd0e7 url(/DXR.axd?r=0_4030-86T5g) repeat-x left top;
             border-bottom: 0 solid #8ba0bc;
             border: 1px solid #8ba0bc;
         }

         caption {
             display: table-caption;
             text-align: -webkit-center;
         }

         .dxtlNode_Office2010Blue td.dxtl, .dxtlAltNode_Office2010Blue td.dxtl, .dxtlSelectedNode_Office2010Blue td.dxtl, .dxtlFocusedNode_Office2010Blue td.dxtl, .dxtlEditFormDisplayNode_Office2010Blue td.dxtl, .dxtlCommandCell_Office2010Blue {
             padding: 4px 6px;
             border-width: 0;
             border: 1px solid #C2D4DA;
             white-space: nowrap;
             overflow: hidden;
         }

         .dxtl__B0 {
             border-top-style: none !important;
             border-left-style: none !important;
             border-right-style: solid !important;
             border-bottom-style: none !important;
         }

         /*.dxtl__B1 {
            border-top-style: none !important;
            border-right-style: none !important;
            border-bottom-style: solid !important;
        }*/
     </style>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" SeparatorVisible="false" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Name="Menu" Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                         <div style="padding: 10px 10px 10px; font-size: 1.5em; font-weight: bold; margin: 0px 4px 4px; float: right;">
                            <asp:Literal ID="Literal1" runat="server" Text="Subaccount" />
                        </div>
                        <div style="float: left">
                            <dx:ASPxMenu ID="mMain" runat="server" ClientInstanceName="ClientMenu" CssClass="main-menu" Theme="Moderno" OnItemClick="mMain_ItemClick">
                                <ClientSideEvents ItemClick="function(s, e) { ClientMenu_ItemClick(e);}" />
                                <Items>
                                    <dx:MenuItem Name="New" Text="<%$Resources:Language, Add %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/add.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Edit" ClientVisible="false" Text="<%$Resources:Language, Edit %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/edit.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Delete" ClientVisible="false" Text="<%$Resources:Language, Delete %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/delete.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="UpdateSeq" ClientVisible="false" Text="Update Seq" ItemStyle-CssClass="menu-item" Image-Url="../Content/images/if_Calculator_669940.png" Image-Height="16px" Image-Width="16px">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="SyncData" ClientVisible="false" Text="Đồng bộ PMS" ItemStyle-CssClass="menu-item" Image-Url="../Content/images/execute.png" Image-Height="16px" Image-Width="16px">
                                    </dx:MenuItem>
                                     <dx:MenuItem Name="EXPORT" Text="Export Excel" ItemStyle-CssClass="menu-item" Image-Url="../Content/images/action/export.png">                                                          
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
            <dx:SplitterPane>
                <Panes>
                    <dx:SplitterPane Name="GridPane">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxTreeList ID="DataGrid" runat="server" Width="100%" ClientInstanceName="ClientDataGrid" KeyFieldName="SubaccountID" ParentFieldName="SubaccountParentID"
                                    OnCustomCallback="DataGrid_CustomCallback" OnCustomDataCallback="DataGrid_CustomDataCallback"
                                    OnHtmlRowPrepared="DataGrid_HtmlRowPrepared">
                                    <Columns>
                                        <dx:TreeListTextColumn FieldName="Description" VisibleIndex="1" Caption="Description" Width="300">
                                            <DataCellTemplate>
                                                <asp:Label runat="server" Text='<%# Eval("SubaccountID").ToString().Trim() +"-"+ Eval("Description") %>'></asp:Label>
                                            </DataCellTemplate>
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="Seq" VisibleIndex="2" Caption="Seq" Width="50"></dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="Sorting" VisibleIndex="3" Caption="Sorting" Width="100"></dx:TreeListTextColumn>
                                       <%-- <dx:TreeListTextColumn FieldName="AccLevel1" VisibleIndex="18" Caption="AccLevel1" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="AccLevel1" VisibleIndex="18" Caption="AccLevel1" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="AccLevel2" VisibleIndex="18" Caption="AccLevel2" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="AccLevel3" VisibleIndex="18" Caption="AccLevel3" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="AccLevel4" VisibleIndex="18" Caption="AccLevel4" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="AccLevel5" VisibleIndex="18" Caption="AccLevel5" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                          <dx:TreeListTextColumn FieldName="MaBoPhan" VisibleIndex="18" Caption="MaBoPhan" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="ManagermentCode" VisibleIndex="18" Caption="ManagermentCode" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="ACCode" VisibleIndex="18" Caption="ACCode" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>--%>
                                        <%-- <dx:TreeListTextColumn FieldName="AccountType" VisibleIndex="4" Caption="AccountType" Width="100"></dx:TreeListTextColumn>--%>
                                        <dx:TreeListTextColumn FieldName="Calculation" VisibleIndex="5" Caption="Calculation" Width="100"></dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="AccountGroup" VisibleIndex="6" Caption="AccountGroup" Width="100"></dx:TreeListTextColumn>
                                       <%-- <dx:TreeListTextColumn FieldName="AllocatedDriver" VisibleIndex="7" Caption="Driver" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="Carrier" VisibleIndex="8" Caption="Carrier" Width="60" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="AllocatedFLT" VisibleIndex="9" Caption="Flt Type" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="Fleet_Type" VisibleIndex="8" Caption="Fleet Type" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="AllocatedRT" VisibleIndex="10" Caption="Route" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="Airports" VisibleIndex="11" Caption="Airports" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="ACID" VisibleIndex="12" Caption="AC ID" Width="60" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="AllocateFltDirection" VisibleIndex="13" Caption="Direction" Width="70" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="Network" VisibleIndex="14" Caption="Network" Width="60" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                         <dx:TreeListTextColumn FieldName="Ori" VisibleIndex="15" Caption="Ori" Width="80" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="Des" VisibleIndex="16" Caption="Des" Width="80" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="OriCountry" VisibleIndex="17" Caption="Ori Country" Width="80" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="DesCountry" VisibleIndex="18" Caption="Des Country" Width="80" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="DirectIndirect" VisibleIndex="19" Caption="DirectIndirect" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>--%>
                                      <%--  <dx:TreeListTextColumn FieldName="CostGroup" VisibleIndex="20" Caption="Cost Group" Width="80" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>--%>
                                        <dx:TreeListTextColumn FieldName="Division" VisibleIndex="19" Caption="Division" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>
                                     <%--   <dx:TreeListTextColumn FieldName="MaVuViec" VisibleIndex="19" Caption="Fee Code" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                        </dx:TreeListTextColumn>--%>
                                          <dx:TreeListCheckColumn FieldName="IsCommercial" VisibleIndex="20" Caption="Commercial?" Width="100"></dx:TreeListCheckColumn>
                                          <dx:TreeListCheckColumn FieldName="OutAllowUpdate" VisibleIndex="21" Caption="OutStandards?" Width="100"></dx:TreeListCheckColumn>
                                          <dx:TreeListCheckColumn FieldName="DecAllowUpdate" VisibleIndex="22" Caption="Decentralization?" Width="110"></dx:TreeListCheckColumn>
                                        <dx:TreeListCheckColumn FieldName="Active" VisibleIndex="23" Caption="Active" Width="60"></dx:TreeListCheckColumn>
                                        <dx:TreeListTextColumn FieldName="Note" VisibleIndex="24" Caption="Note" Width="400"></dx:TreeListTextColumn>
                                    </Columns>
                                    <Styles>
                                        <AlternatingNode Enabled="True"></AlternatingNode>
                                    </Styles>
                                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" HorizontalScrollBarMode="Auto" ScrollableHeight="500" />
                                    <SettingsSearchPanel Visible="false" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="Description;Note" />
                                    <Paddings Padding="0px" />
                                    <Border BorderWidth="1px" />
                                    <BorderBottom BorderWidth="1px" />
                                    <SettingsBehavior AllowFocusedNode="true" />
                                    <SettingsResizing ColumnResizeMode="Control" />
                                    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllNodes" />
                                    <ClientSideEvents NodeDblClick="ClientDataGrid_NodeDblClick"
                                        FocusedNodeChanged="ClientDataGrid_NodeClick"
                                        CustomDataCallback="ClientDataGrid_CustomDataCallback"
                                        EndCallback="ClientDataGrid_EndCallback" />
                                </dx:ASPxTreeList>
                                 <dx:ASPxTreeListExporter ID="TreeListExporter" runat="server" TreeListID="DataGrid"></dx:ASPxTreeListExporter>
                               <%-- <br />
                                <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Update Seq" AutoPostBack="false">
                                    <Image Url="../Content/images/if_Calculator_669940.png" Width="16px"></Image>
                                    <ClientSideEvents Click="ClientUpdateSeqButton_Click" />
                                </dx:ASPxButton>

                                  <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Export Excel" AutoPostBack="false" OnClick="ASPxButton2_Click">
                                    <Image Url="../Content/images/action/export.png"></Image>
                                </dx:ASPxButton>--%>
                            </dx:SplitterContentControl>
                        </ContentCollection>
                        <PaneStyle Border-BorderWidth="0">
                            <BorderTop BorderWidth="0px"></BorderTop>
                        </PaneStyle>
                    </dx:SplitterPane>
                    <dx:SplitterPane Name="FastCode" Size="600" Visible="false">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxGridView ID="FastCodeGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                    ClientInstanceName="ClientFastCodeGrid" Width="100%" KeyFieldName="SubFastCodeID"
                                    OnCustomCallback="FastCodeGrid_CustomCallback"
                                    OnBatchUpdate="FastCodeGrid_BatchUpdate">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="AreaCode" VisibleIndex="1" Caption="Area" Width="60" FixedStyle="Left" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="FastCode" VisibleIndex="2" Caption="Fast Code" Width="140" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="SubCode" VisibleIndex="2" Caption="Sub Code" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <Styles>
                                        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                    </Styles>
                                    <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" />
                                    <SettingsEditing Mode="Batch">
                                        <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                                    </SettingsEditing>
                                    <SettingsResizing ColumnResizeMode="Control" />
                                    <Paddings Padding="0px" />
                                    <Border BorderWidth="1px" />
                                    <BorderBottom BorderWidth="1px" />
                                    <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                    <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
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
   <%-- <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="DataGrid"></dx:ASPxGridViewExporter>--%>


    <dx:ASPxPopupControl ID="EditPopupControl" runat="server" Width="350" Height="250" AllowDragging="True" HeaderText="" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientEditPopupControl" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditForm" runat="server" RequiredMarkDisplayMode="Auto" ColCount="2" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientEditForm"
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
                        <dx:LayoutItem Caption="Calculation">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="CalculationEditor" Width="100" ValueType="System.String" ClientInstanceName="ClientCalculationEditor">
                                        <Items>
                                            <dx:ListEditItem Value="DATA" Text="DATA" />
                                            <dx:ListEditItem Value="AUTO" Text="AUTO" />
                                            <dx:ListEditItem Value="SUM" Text="SUM" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <%--<dx:LayoutItem Caption="Account Type">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="AccountTypeEditor" Width="250" ValueType="System.Int32" ClientInstanceName="ClientAccountTypeEditor">
                                        <Items>
                                            <dx:ListEditItem Value="1" Text="Thu-Chi" />
                                            <dx:ListEditItem Value="2" Text="Dùng chung cho Thu-Chi" />
                                            <dx:ListEditItem Value="3" Text="Ngân sách" />
                                            <dx:ListEditItem Value="5" Text="Phân tích hiệu quả đường bay" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                        <dx:LayoutItem Caption="Account Group">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="AccountGroupEditor" Width="250" ValueType="System.String" ClientInstanceName="ClientAccountGroupEditor">
                                        <Items>
                                            <dx:ListEditItem Value="T" Text="Chỉ tiêu nhóm doanh thu A" />
                                            <dx:ListEditItem Value="C" Text="Chỉ tiêu nhóm chi phí B" />
                                            <dx:ListEditItem Value="S" Text="Chỉ tiêu nhóm tổng hợp" />
                                            <dx:ListEditItem Value="M" Text="Chi tiêu điều hành" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <%-- <dx:LayoutItem Caption="Activity">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="ActivityEditor" Width="250" ValueType="System.String" ClientInstanceName="ClientActivityEditor" OnInit="ActivityEditor_Init">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                       <%-- <dx:LayoutItem Caption="Driver">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="DriverEditor" Width="250" ClientInstanceName="ClientDriverEditor" OnInit="DriverEditor_Init">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Carrier">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTokenBox runat="server" ID="CarrierEditor" Width="250" ClientInstanceName="ClientCarrierEditor" OnInit="CarrierEditor_Init">
                                    </dx:ASPxTokenBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Flt Type">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTokenBox runat="server" ID="FltTypeEditor" Width="250" ClientInstanceName="ClientFltTypeEditor" OnInit="FltTypeEditor_Init">
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
                        </dx:LayoutItem>--%>
                        <%--<dx:LayoutItem Caption="Route">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="RouteEditor" Width="250" ClientInstanceName="ClientRouteEditor" OnInit="RouteEditor_Init">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                        <%--<dx:LayoutItem Caption="Route2W">
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
                        </dx:LayoutItem>--%>
                        <%--<dx:LayoutItem Caption="Airports">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTokenBox runat="server" ID="AirportsEditor" Width="250" ClientInstanceName="ClientAirportsEditor" OnInit="AirportsEditor_Init">
                                    </dx:ASPxTokenBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                        <%--<dx:LayoutItem Caption="Aircraft">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTokenBox runat="server" ID="ACIDEditor" Width="250" ClientInstanceName="ClientACIDEditor" OnInit="ACIDEditor_Init">
                                    </dx:ASPxTokenBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Direction">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="DirectionEditor" Width="250" ClientInstanceName="ClientDirectionEditor">
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
                                    <dx:ASPxComboBox runat="server" ID="NetworkEditor" Width="250" ClientInstanceName="ClientNetworkEditor">
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
                                    <dx:ASPxTokenBox runat="server" ID="DesCountryEditor" Width="250" ClientInstanceName="ClientDesCountryEditor"  OnInit="CountryEditor_Init">
                                        
                                    </dx:ASPxTokenBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                      <%--  <dx:LayoutItem Caption="Cost Type">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="ProfitEditor" Width="250" ClientInstanceName="ClientProfitEditor" OnInit="cboProfit_Init">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                       <%-- <dx:LayoutItem Caption="Cost Type">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="CostTypeEditor" Width="250" ClientInstanceName="ClientCostTypeEditor">
                                        <Items>
                                            <dx:ListEditItem Value="ALLOCATED" Text="ALLOCATED" />
                                            <dx:ListEditItem Value="TNDN" Text="TNDN" />
                                            <dx:ListEditItem Value="HÐ_BT" Text="HĐ BT" />
                                            <dx:ListEditItem Value="HÐ_TC" Text="HĐ TC" />
                                            <dx:ListEditItem Value="REV" Text="REV" />
                                            <dx:ListEditItem Value="EXT_REV" Text="EXT_REV" />
                                            <dx:ListEditItem Value="INC_REV" Text="INC_REV" />
                                            <dx:ListEditItem Value="FAD_REV" Text="FAD_REV" />
                                            <dx:ListEditItem Value="NONE" Text="NONE" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                        <%--<dx:LayoutItem Caption="Cost Group">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="CostGroupEditor" Width="250" ClientInstanceName="ClientCostGroupEditor" OnInit="CostGroupEditor_Init">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                       <dx:LayoutItem Caption="Division">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="DivisionEditor" Width="250" ValueType="System.String" ClientInstanceName="ClientDivisionEditor" OnInit="DivisionEditor_Init">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                         <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                        <dx:LayoutItem Caption="Seq">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="SeqEditor" Width="100" ClientInstanceName="ClientSeqEditor">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Sorting">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="SortingEditor" Width="100" ClientInstanceName="ClientSortingEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        
                         <%--<dx:LayoutItem Caption="AccLevel1">
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
                         <dx:LayoutItem Caption="DirectIndirect">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="DirectIndirectEditor" ValueType="System.String" Width="250" ClientInstanceName="ClientDirectIndirectEditor">
                                        <Items>
                                            <dx:ListEditItem Value="D" Text="D-Direct" />
                                            <dx:ListEditItem Value="I" Text="I-Indirect" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                        <dx:LayoutItem Caption="Commercial?">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox runat="server" ID="IsCommercialEditor" ClientInstanceName="ClientIsCommercialEditor">
                                    </dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                        <dx:LayoutItem Caption="OutStandards?">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox runat="server" ID="OutAllowUpdateEditor" ClientInstanceName="ClientOutAllowUpdateEditor">
                                    </dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Decentralization?">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox runat="server" ID="DecAllowUpdateEditor" ClientInstanceName="ClientDecAllowUpdateEditor">
                                    </dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                          
                        <dx:LayoutItem Caption="Note" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxMemo runat="server" ID="NoteEditor" Width="100%" Rows="3" ClientInstanceName="ClientNoteEditor">
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
    <dx:ASPxCallback ID="SubaccountCallback" runat="server" ClientInstanceName="ClientSubaccountCallback" OnCallback="Callback_Callback">
        <ClientSideEvents CallbackComplete="ClientSubaccountCallback_CallbackComplete" />
    </dx:ASPxCallback>
</asp:Content>

