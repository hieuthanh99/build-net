<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="KHFlightDate.aspx.cs" Inherits="Business_KTQT_KHFlightDate" %>

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
                                            ClientInstanceName="ClientHistoryGrid" Width="100%" KeyFieldName="HistoryID"
                                            OnCustomCallback="HistoryGrid_CustomCallback">
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="HistoryID" VisibleIndex="1" Caption="ID" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>

                                                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2" Caption="Description" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="AreaCode" VisibleIndex="3" Caption="Area" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="PlanYear" VisibleIndex="4" Caption="Year" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataDateColumn FieldName="SyncDate" VisibleIndex="5" Caption="Sync Date" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                                </dx:GridViewDataDateColumn>
                                                <dx:GridViewDataDateColumn FieldName="StartTime" VisibleIndex="6" Caption="Start Time" Width="170" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm:ss"></PropertiesDateEdit>
                                                </dx:GridViewDataDateColumn>
                                                <dx:GridViewDataDateColumn FieldName="EndTime" VisibleIndex="7" Caption="End Time" Width="170" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm:ss"></PropertiesDateEdit>
                                                </dx:GridViewDataDateColumn>
                                                <dx:GridViewDataTextColumn FieldName="SyncStatus" VisibleIndex="8" Caption="Sync Status" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="TransStatus" VisibleIndex="9" Caption="Transfer Status" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Remark" VisibleIndex="10" Caption="Remark" Width="50%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                            ClientInstanceName="ClientDataGrid" Width="100%" KeyFieldName="TableID;HistotyID"
                            OnCustomCallback="DataGrid_CustomCallback">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="TableID" VisibleIndex="0" Caption="TableID" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <%-- <dx:GridViewDataTextColumn FieldName="KHFlightID" VisibleIndex="1" Caption="KHFlightID" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="KHFlightWID" VisibleIndex="2" Caption="KHFlightWID" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>--%>
                                <dx:GridViewDataTextColumn FieldName="AreaCode" VisibleIndex="3" Caption="Area" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Year" VisibleIndex="4" Caption="Year" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Version" VisibleIndex="5" Caption="Version" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="6" Caption="Description" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AirlinesID" VisibleIndex="7" Caption="AirlinesID" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Aircraft" VisibleIndex="8" Caption="Aircraft" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Routing" VisibleIndex="9" Caption="Routing" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="RouteType" VisibleIndex="10" Caption="RouteType" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="Date" VisibleIndex="11" Caption="Date" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="GHID" VisibleIndex="12" Caption="GHID" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NatureID" VisibleIndex="13" Caption="NatureID" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CarryID" VisibleIndex="14" Caption="CarryID" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Pax_FC" VisibleIndex="15" Caption="Pax_FC" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Pax_Y" VisibleIndex="16" Caption="Pax_Y" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="RecDate" VisibleIndex="17" Caption="RecDate" HeaderStyle-HorizontalAlign="Center" Width="150" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm:ss"></PropertiesDateEdit>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="18" Caption="Status" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="Qty" VisibleIndex="19" Caption="Quantity" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="DoanhThu" VisibleIndex="20" Caption="Revenue" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="DoanhThuRR" VisibleIndex="21" Caption="Revenue RR" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="ChietKhau" VisibleIndex="22" Caption="Discount" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataTextColumn FieldName="Transit" VisibleIndex="23" Caption="Transit" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="MTOW" VisibleIndex="24" Caption="MTOW" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Config" VisibleIndex="25" Caption="Config" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="GroundTime" VisibleIndex="26" Caption="GroundTime" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ContractID" VisibleIndex="27" Caption="ContractID" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <Styles>
                                <AlternatingRow Enabled="true" />
                                <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                            </Styles>
                            <Settings ShowFooter="true" ShowTitlePanel="true" ShowStatusBar="Hidden" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
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
                            <TotalSummary>
                                <dx:ASPxSummaryItem FieldName="Qty" SummaryType="Sum" ShowInColumn="Qty" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                <dx:ASPxSummaryItem FieldName="DoanhThu" SummaryType="Sum" ShowInColumn="DoanhThu" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                <dx:ASPxSummaryItem FieldName="DoanhThuRR" SummaryType="Sum" ShowInColumn="DoanhThuRR" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                <dx:ASPxSummaryItem FieldName="ChietKhau" SummaryType="Sum" ShowInColumn="ChietKhau" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                            </TotalSummary>
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

    <dx:ASPxPopupControl ID="ApplyVersionPopup" runat="server" Width="500" Height="300" AllowDragging="True" HeaderText="Apply To Version" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientApplyVersionPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="ApplyVersionForm" runat="server" ColCount="2" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                    AlignItemCaptionsInAllGroups="true" Width="100%" OptionalMark="">
                    <Items>
                        <dx:LayoutItem Caption="From Month">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="FromMonthEditor" Width="100" ClientInstanceName="ClientFromMonthEditor" MinValue="1" MaxValue="12">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="To Month">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="ToMonthEditor" Width="100" ClientInstanceName="ClientToMonthEditor" MinValue="1" MaxValue="12">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxSpinEdit>
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
                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="200" VerticalScrollBarStyle="Standard" />
                    <Paddings Padding="0px" />
                    <Border BorderWidth="1px" />
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


    <dx:ASPxPopupControl ID="KHFlightVersionPopup" runat="server" Width="500" Height="400" AllowDragging="True" HeaderText="Select Version" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientKHFlightVersionPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>

                <dx:ASPxGridView ID="KHFlightGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientKHFlightGrid" Width="100%" KeyFieldName="KHFlightID"
                    OnCustomCallback="KHFlightGrid_CustomCallback">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="AreaCode" VisibleIndex="1" Caption="Area" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Year" VisibleIndex="2" Caption="Year" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Version" VisibleIndex="3" Caption="Version" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="4" Caption="Description" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                <ClientSideEvents Click="function(s, e) {{ ClientKHFlightVersionPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnSync" runat="server" Text="Sync" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientSyncButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientKHFlightVersionPopup_Shown"
            CloseUp="RevCost.ClientKHFlightVersionPopup_CloseUp" />
    </dx:ASPxPopupControl>

</asp:Content>

