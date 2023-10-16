<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="VMSExternalRev.aspx.cs" Inherits="Business_KTQT_VMSExternalRev" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link href="../../Content/RevCost.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../../Scripts/KTQTExternalRev.js"></script>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="RevCost.ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div class="title">
                            <asp:Literal ID="Literal1" runat="server" Text="EXTERNAL REVENUE" />
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
                <Panes>
                    <dx:SplitterPane>
                        <Panes>
                            <dx:SplitterPane Size="50" Separator-Visible="False">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxFormLayout runat="server" ColCount="9">
                                            <Items>
                                                <dx:LayoutItem Caption="Area">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxComboBox ID="cboArea" runat="server" Width="120px" OnInit="AirportsEditor_Init" ClientInstanceName="ClientAirport"></dx:ASPxComboBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Year">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxSpinEdit ID="QueryYearEditor" runat="server" ClientInstanceName="ClientQueryYearEditor" Width="100"></dx:ASPxSpinEdit>
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
                                                            <dx:ASPxButton ID="btnSyncDTNCB" runat="server" ClientInstanceName="ClientSyncButton" Text="Sync External Rev" UseSubmitBehavior="true" AutoPostBack="false">
                                                                <ClientSideEvents Click="RevCost.ClientSyncDTNCBButton_Click" />
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
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                            </dx:SplitterPane>
                            <dx:SplitterPane Name="DataGrid" ScrollBars="Auto" Separator-Visible="False">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="DataGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientDataGrid" Width="100%" KeyFieldName="ExternalRevID"
                                            OnCustomCallback="DataGrid_CustomCallback">
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="Code" VisibleIndex="0" Caption="Code" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="1" Caption="Description" Width="280" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <%-- <dx:GridViewDataTextColumn FieldName="PlansItemID" VisibleIndex="2" Caption="PlansItemID" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>--%>
                                                <dx:GridViewDataTextColumn FieldName="AreaCode" VisibleIndex="3" Caption="AreaCode" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ForYear" VisibleIndex="4" Caption="ForYear" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Month_01" VisibleIndex="6" Caption="KH_01" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="TH_01" VisibleIndex="7" Caption="TH_01" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Month_02" VisibleIndex="8" Caption="KH_02" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="TH_02" VisibleIndex="9" Caption="TH_02" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Month_03" VisibleIndex="10" Caption="KH_03" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="TH_03" VisibleIndex="11" Caption="TH_03" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Month_04" VisibleIndex="12" Caption="KH_04" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="TH_04" VisibleIndex="13" Caption="TH_04" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Month_05" VisibleIndex="14" Caption="KH_05" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="TH_05" VisibleIndex="15" Caption="TH_05" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Month_06" VisibleIndex="16" Caption="KH_06" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="TH_06" VisibleIndex="17" Caption="TH_06" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Month_07" VisibleIndex="18" Caption="KH_07" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="TH_07" VisibleIndex="19" Caption="TH_07" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Month_08" VisibleIndex="20" Caption="KH_08" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="TH_08" VisibleIndex="21" Caption="TH_08" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Month_09" VisibleIndex="22" Caption="KH_09" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="TH_09" VisibleIndex="23" Caption="TH_09" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Month_10" VisibleIndex="24" Caption="KH_10" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="TH_10" VisibleIndex="25" Caption="TH_10" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Month_11" VisibleIndex="26" Caption="KH_11" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="TH_11" VisibleIndex="27" Caption="TH_11" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Month_12" VisibleIndex="28" Caption="KH_12" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="TH_12" VisibleIndex="29" Caption="TH_12" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="KH_TOTAL" UnboundType="Decimal" UnboundExpression="[Month_01]+[Month_02]+[Month_03]+[Month_04]+[Month_05]+[Month_06]+[Month_07]+[Month_08]+[Month_09]+[Month_10]+[Month_11]+[Month_12]"
                                                    VisibleIndex="30" Caption="KH_TOTAL" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <CellStyle Font-Bold="true"></CellStyle>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="TH_TOTAL" UnboundType="Decimal" UnboundExpression="[TH_01]+[TH_02]+[TH_03]+[TH_04]+[TH_05]+[TH_06]+[TH_07]+[TH_08]+[TH_09]+[TH_10]+[TH_11]+[TH_12]"
                                                    VisibleIndex="31" Caption="TH_TOTAL" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <CellStyle Font-Bold="true"></CellStyle>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                            </Columns>
                                            <Styles>
                                                <AlternatingRow Enabled="true" />
                                            </Styles>
                                            <Settings ShowFooter="true" ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                            <SettingsResizing ColumnResizeMode="Control" />
                                            <Paddings Padding="0px" />
                                            <Border BorderWidth="1px" />
                                            <BorderBottom BorderWidth="1px" />
                                            <SettingsBehavior AllowFocusedRow="True" />
                                            <SettingsPager Visible="true" PageSize="50" Mode="ShowPager" />
                                            <TotalSummary>
                                                <dx:ASPxSummaryItem FieldName="Month_01" SummaryType="Sum" ShowInColumn="Month_01" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="TH_01" SummaryType="Sum" ShowInColumn="TH_01" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="Month_02" SummaryType="Sum" ShowInColumn="Month_02" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="TH_02" SummaryType="Sum" ShowInColumn="TH_02" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="Month_03" SummaryType="Sum" ShowInColumn="Month_03" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="TH_03" SummaryType="Sum" ShowInColumn="TH_03" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="Month_04" SummaryType="Sum" ShowInColumn="Month_04" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="TH_04" SummaryType="Sum" ShowInColumn="TH_04" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="Month_05" SummaryType="Sum" ShowInColumn="Month_05" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="TH_05" SummaryType="Sum" ShowInColumn="TH_05" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="Month_06" SummaryType="Sum" ShowInColumn="Month_06" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="TH_06" SummaryType="Sum" ShowInColumn="TH_06" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="Month_07" SummaryType="Sum" ShowInColumn="Month_07" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="TH_07" SummaryType="Sum" ShowInColumn="TH_07" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="Month_08" SummaryType="Sum" ShowInColumn="Month_08" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="TH_08" SummaryType="Sum" ShowInColumn="TH_08" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="Month_09" SummaryType="Sum" ShowInColumn="Month_09" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="TH_09" SummaryType="Sum" ShowInColumn="TH_09" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="Month_10" SummaryType="Sum" ShowInColumn="Month_10" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="TH_10" SummaryType="Sum" ShowInColumn="TH_10" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="Month_11" SummaryType="Sum" ShowInColumn="Month_11" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="TH_11" SummaryType="Sum" ShowInColumn="TH_11" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="Month_12" SummaryType="Sum" ShowInColumn="Month_12" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="TH_12" SummaryType="Sum" ShowInColumn="TH_12" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="KH_TOTAL" SummaryType="Sum" ShowInColumn="KH_TOTAL" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="TH_TOTAL" SummaryType="Sum" ShowInColumn="TH_TOTAL" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                            </TotalSummary>
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
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="DataGrid"></dx:ASPxGridViewExporter>

    <dx:ASPxPopupControl ID="ApplyVersionPopup" runat="server" Width="500" Height="400" AllowDragging="True" HeaderText="Apply To Version" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientApplyVersionPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxSplitter ID="ASPxSplitter1" runat="server" Orientation="Vertical" FullscreenMode="true" Width="100%" Height="100%" ResizingMode="Live">
                    <ClientSideEvents PaneResized="RevCost.ClientApplyToVersionSplliter_PaneResized" />
                    <Panes>
                        <dx:SplitterPane Size="80" Separator-Visible="False">
                            <ContentCollection>
                                <dx:SplitterContentControl>
                                    <dx:ASPxFormLayout ID="AllocateParamsForm" runat="server" ColCount="2" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
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
                                </dx:SplitterContentControl>
                            </ContentCollection>
                            <PaneStyle>
                                <BorderTop BorderStyle="None" />
                                <BorderLeft BorderStyle="None" />
                                <BorderRight BorderStyle="None" />
                            </PaneStyle>
                        </dx:SplitterPane>
                        <dx:SplitterPane Separator-Visible="False" Name="VersionGrid">
                            <ContentCollection>
                                <dx:SplitterContentControl>
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
                                </dx:SplitterContentControl>
                            </ContentCollection>
                            <PaneStyle>
                                <Paddings Padding="0" />
                                <BorderBottom BorderStyle="None" />
                                <BorderLeft BorderStyle="None" />
                                <BorderRight BorderStyle="None" />
                            </PaneStyle>
                        </dx:SplitterPane>
                    </Panes>
                </dx:ASPxSplitter>
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

