<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PlanQuantity.aspx.cs" Inherits="Business_RevenueCost_PlanQuantity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../../Scripts/VMSPlanQuantity.js"></script>
    <dx:ASPxSplitter ID="contentSplitter" runat="server" ClientInstanceName="ClientContentSplitter" Orientation="Vertical" Width="100%" Height="100%" ResizingMode="Live">
        <ClientSideEvents PaneResized="RevCost.ClientContentSplitter_PaneResized" />
        <Border BorderStyle="None" />
        <Panes>
            <dx:SplitterPane Size="300">
                <Panes>
                    <dx:SplitterPane>
                        <Panes>
                            <dx:SplitterPane Size="50">
                                <Separator Visible="False"></Separator>
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <div style="float: right;">
                                            <div class="title">
                                                <asp:Literal ID="Literal1" runat="server" Text="PLAN QUANTITY DATA" />
                                            </div>
                                        </div>
                                        <div style="float: left;">
                                            <dx:ASPxFormLayout ID="FormParams" runat="server" ColCount="7">
                                                <Items>
                                                    <dx:LayoutItem Caption="Area">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxComboBox ID="cboArea" runat="server" Width="120px" OnInit="cboArea_Init" ClientInstanceName="ClientAirport"></dx:ASPxComboBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Month">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxSpinEdit ID="QueryMonthEditor" runat="server" Width="50" MinValue="0" MaxValue="12"></dx:ASPxSpinEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Year">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxSpinEdit ID="QueryYearEditor" runat="server" Width="100"></dx:ASPxSpinEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem ShowCaption="False">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxButton ID="btnQuery" runat="server" ClientInstanceName="ClientQueryButton" Text="Query" AutoPostBack="false" UseSubmitBehavior="true">
                                                                    <ClientSideEvents Click="RevCost.ClientQueryButton_Click" />
                                                                </dx:ASPxButton>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem ShowCaption="False">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxButton ID="btnExport" runat="server" ClientInstanceName="ClientExportButton" Text="Export Excel" UseSubmitBehavior="true" OnClick="btnExport_Click">
                                                                </dx:ASPxButton>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem ShowCaption="False">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxButton ID="btnSync" runat="server" ClientInstanceName="ClientSyncButton" Text="Sync Data" UseSubmitBehavior="true" AutoPostBack="false">
                                                                    <ClientSideEvents Click="RevCost.ClientSyncDataButton_Click" />
                                                                </dx:ASPxButton>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem ShowCaption="False">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxButton ID="btnShowVersion" runat="server" ClientInstanceName="ClientShowVersionButton" Text="Apply To Version" UseSubmitBehavior="true" AutoPostBack="false">
                                                                    <ClientSideEvents Click="RevCost.ClientShowVersionButton_Click" />
                                                                </dx:ASPxButton>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                </Items>
                                            </dx:ASPxFormLayout>
                                        </div>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                            </dx:SplitterPane>
                            <dx:SplitterPane Name="History">
                                <Separator Visible="False"></Separator>
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="HistoryGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientHistoryGrid" Width="100%" KeyFieldName="HisID"
                                            OnCustomCallback="HistoryGrid_CustomCallback">
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="HisID" VisibleIndex="1" Caption="ID" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>

                                                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2" Caption="Description" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="AreaCode" VisibleIndex="3" Caption="Area" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="FltYear" VisibleIndex="4" Caption="Year" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataDateColumn FieldName="SyncDate" VisibleIndex="5" Caption="Sync Date" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                                </dx:GridViewDataDateColumn>
                                                <dx:GridViewDataDateColumn FieldName="StartTime" VisibleIndex="6" Caption="Start Time" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm:ss"></PropertiesDateEdit>
                                                </dx:GridViewDataDateColumn>
                                                <dx:GridViewDataDateColumn FieldName="EndTime" VisibleIndex="7" Caption="End Time" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm:ss"></PropertiesDateEdit>
                                                </dx:GridViewDataDateColumn>
                                                <dx:GridViewDataTextColumn FieldName="SyncStatus" VisibleIndex="8" Caption="Sync Status" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="TransferStatus" VisibleIndex="9" Caption="Transfer Status" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Remark" VisibleIndex="10" Caption="Remark" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <Styles>
                                                <AlternatingRow Enabled="true" />
                                                <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                            </Styles>
                                            <Settings ShowTitlePanel="true" ShowStatusBar="Hidden" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                            <Paddings Padding="0px" />
                                            <Border BorderWidth="1px" />
                                            <BorderBottom BorderWidth="1px" />
                                            <SettingsResizing ColumnResizeMode="Control" />
                                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                                            <Templates>
                                                <TitlePanel>
                                                    <div style="float: left">
                                                        <dx:ASPxLabel runat="server" Font-Bold="true" Text="History"></dx:ASPxLabel>
                                                    </div>
                                                </TitlePanel>
                                            </Templates>
                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientHistoryGrid_FocusedRowChanged"
                                                BeginCallback="RevCost.ClientHistoryGrid_BeginCallback"
                                                EndCallback="RevCost.ClientHistoryGrid_EndCallback" />
                                        </dx:ASPxGridView>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                                <PaneStyle>
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                    <BorderLeft BorderWidth="0px"></BorderLeft>
                                    <BorderRight BorderWidth="0px"></BorderRight>
                                    <BorderBottom BorderWidth="0px"></BorderBottom>
                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                </PaneStyle>
                            </dx:SplitterPane>
                        </Panes>

                    </dx:SplitterPane>
                </Panes>
            </dx:SplitterPane>
            <dx:SplitterPane Name="DataHistory">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <dx:ASPxGridView ID="DataGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                            ClientInstanceName="ClientDataGrid" Width="100%" KeyFieldName="ID"
                            OnCustomCallback="DataGrid_CustomCallback">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="Area" VisibleIndex="2" Caption="Area" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Flt_No" VisibleIndex="3" Caption="Flt No" Width="90" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="Flt_Date" VisibleIndex="4" Caption="Flt Date" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="AC_ID" VisibleIndex="5" Caption="Aircraft" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Ac_Reg" VisibleIndex="6" Caption="Ac Reg" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Sector" VisibleIndex="7" Caption="Sector" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ORI" VisibleIndex="8" Caption="ORI" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DES" VisibleIndex="9" Caption="DES" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CARRIER" VisibleIndex="10" Caption="Opt" Width="40" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Flt_Type" VisibleIndex="11" Caption="Flt Type" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Network" VisibleIndex="12" Caption="Network" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="Fls" VisibleIndex="13" Caption="Fls" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <%--  <dx:GridViewDataSpinEditColumn FieldName="Fls_321" VisibleIndex="14" Caption="Fls 321" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>--%>
                                <dx:GridViewDataSpinEditColumn FieldName="AC_Group" VisibleIndex="15" Caption="AC Group" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="Fre" VisibleIndex="16" Caption="Fre" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="BH" VisibleIndex="17" Caption="BH" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="LF" VisibleIndex="18" Caption="LF" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="CAP" VisibleIndex="19" Caption="CAP" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="PAX" VisibleIndex="20" Caption="PAX" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="SEAT_C" VisibleIndex="21" Caption="SEAT C" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="YIED_C" VisibleIndex="22" Caption="YIED C" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="Y_PAX" VisibleIndex="23" Caption="Pax Y" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="YQ" VisibleIndex="24" Caption="YQ" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="REVUNIT" VisibleIndex="25" Caption="REVUNIT" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="REV" VisibleIndex="32" Caption="REV" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="RPK" VisibleIndex="33" Caption="RPK" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="ASK" VisibleIndex="34" Caption="ASK" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="LF_C" VisibleIndex="35" Caption="LF_C" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="PAX_C" VisibleIndex="36" Caption="PAX_C" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="C_REV" VisibleIndex="36" Caption="C_REV" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="Y_REV" VisibleIndex="36" Caption="Y_REV" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="REV_NO_YQ" VisibleIndex="36" Caption="REV_NO_YQ" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="REV_YQ" VisibleIndex="36" Caption="REV_YQ" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="PAXPOS" VisibleIndex="36" Caption="PAXPOS" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                            </Columns>
                            <Styles>
                                <AlternatingRow Enabled="true" />
                                <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                            </Styles>
                            <Settings ShowTitlePanel="true" ShowStatusBar="Hidden" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                            <%--  <SettingsEditing Mode="Batch">
                                <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                            </SettingsEditing>--%>
                            <Paddings Padding="0px" />
                            <Border BorderWidth="1px" />
                            <BorderBottom BorderWidth="1px" />
                            <SettingsResizing ColumnResizeMode="NextColumn" />
                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                            <SettingsPager Visible="true" PageSize="30" Mode="EndlessPaging" />
                            <Templates>
                                <TitlePanel>
                                    <div style="float: left">
                                        <dx:ASPxLabel runat="server" Font-Bold="true" Text="Data history (Data temp)"></dx:ASPxLabel>
                                    </div>
                                </TitlePanel>
                            </Templates>
                        </dx:ASPxGridView>
                        <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="DataGrid"></dx:ASPxGridViewExporter>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle>
                    <BorderTop BorderWidth="0px"></BorderTop>
                    <BorderLeft BorderWidth="0px"></BorderLeft>
                    <BorderRight BorderWidth="0px"></BorderRight>
                    <BorderBottom BorderWidth="0px"></BorderBottom>
                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                </PaneStyle>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>

    <dx:ASPxPopupControl ID="ApplyVersionPopup" runat="server" Width="500" Height="400" AllowDragging="True" HeaderText="Apply To Version" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientApplyVersionPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>

                <dx:ASPxGridView ID="VersionGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientVersionGrid" Width="100%" KeyFieldName="VersionID"
                    OnCustomCallback="VersionGrid_CustomCallback">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="VersionYear" VisibleIndex="1" Caption="Year" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="VersionType" VisibleIndex="2" Caption="Type" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="3" Caption="Description" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="4" Caption="Status" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                </dx:ASPxGridView>

            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Cancel" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientApplyVersionPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApply" runat="server" Text="Apply" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientApplyToVersionButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientApplyVersionPopup_Shown"
            CloseUp="RevCost.ClientApplyVersionPopup_CloseUp" />
    </dx:ASPxPopupControl>
</asp:Content>

