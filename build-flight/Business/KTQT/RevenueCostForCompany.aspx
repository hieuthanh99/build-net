<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RevenueCostForCompany.aspx.cs" Inherits="Business_RevenueCost_RevenueCostForCompany" %>

<%@ Register Src="~/UserControls/FlsOpsStoreView.ascx" TagPrefix="dx" TagName="FlsOpsStoreView" %>
<%@ Register Src="~/UserControls/ViewAllocateError.ascx" TagPrefix="dx" TagName="ViewAllocateError" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link href="../../Content/RevCost.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../../Scripts/KTQTRevCostForCompany.js"></script>
    <script src="../../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../../signalr/hubs"></script>
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
    </style>

    <dx:ASPxPanel runat="server" ID="MainPanel" ClientInstanceName="ClientMainPanel" CssClass="main-container" EnableCallbackAnimation="true" Width="100%">
        <PanelCollection>
            <dx:PanelContent>
                <div class="content-pane">
                    <dx:ASPxSplitter ID="contentSplitter" runat="server" ClientInstanceName="ClientContentSplitter" Orientation="Vertical" Width="100%" Height="100%" ResizingMode="Live">
                        <ClientSideEvents PaneResized="RevCost.ClientContentSplitter_PaneResized" />
                        <Panes>
                            <dx:SplitterPane Size="30" Separator-Visible="False">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxButton ID="MenuButton" ClientInstanceName="MenuButton" AllowFocus="false" runat="server" AutoPostBack="False" CssClass="button"
                                            Height="40px" GroupName="Menu">
                                            <ClientSideEvents Click="RevCost.ClientShowMenuButton_Click" />
                                            <Image Url="../../Content/images/SpringboardMenu.png"></Image>
                                        </dx:ASPxButton>
                                        <div class="powered-text">
                                            <asp:Literal ID="Literal1" runat="server" Text="Revenue Cost" />
                                        </div>
                                        <div style="float: right; padding-right: 10px; padding-top: 10px;">
                                            <dx:ASPxLabel ID="ComapnyName" runat="server" ClientInstanceName="ClientCompanyName" Font-Bold="true" Font-Size="Large"></dx:ASPxLabel>
                                        </div>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                                <PaneStyle>
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                    <BorderLeft BorderWidth="0px"></BorderLeft>
                                    <BorderRight BorderWidth="0px"></BorderRight>
                                    <BorderBottom BorderWidth="0px"></BorderBottom>
                                    <Paddings PaddingLeft="0" PaddingRight="1" PaddingBottom="0" PaddingTop="0" />
                                </PaneStyle>
                            </dx:SplitterPane>
                            <dx:SplitterPane Separator-Visible="False">
                                <Panes>
                                    <dx:SplitterPane>
                                        <Panes>
                                            <dx:SplitterPane>
                                                <Panes>
                                                    <dx:SplitterPane Name="CompanyStores" Separator-Visible="False">
                                                        <ContentCollection>
                                                            <dx:SplitterContentControl>
                                                                <dx:ASPxTreeList ID="StoresGrid" runat="server" Width="100%" ClientInstanceName="ClientStoresGrid" EnableCallbacks="true"
                                                                    KeyFieldName="StoreID" ParentFieldName="ParentStoreID" Caption="Stores" Styles-Header-HorizontalAlign="Center"
                                                                    OnHtmlRowPrepared="StoresGrid_HtmlRowPrepared"
                                                                    OnCustomCallback="StoresGrid_CustomCallback"
                                                                    OnCustomColumnDisplayText="StoresGrid_CustomColumnDisplayText">
                                                                    <Columns>
                                                                        <%-- <dx:TreeListDataColumn FieldName="Sorting" VisibleIndex="0" Caption="Sorting" Width="80" HeaderStyle-Wrap="True"></dx:TreeListDataColumn>--%>
                                                                        <dx:TreeListDataColumn FieldName="Description" VisibleIndex="0" Width="300" Caption="Description" HeaderStyle-Wrap="True">
                                                                            <DataCellTemplate>
                                                                                <asp:Label runat="server" Font-Bold='<%# Eval("Calculation").ToString().Equals("SUM")? true: false%>' Text='<%# Eval("Sorting").ToString().Trim() +". "+ Eval("Description") %>'></asp:Label>
                                                                            </DataCellTemplate>
                                                                        </dx:TreeListDataColumn>
                                                                        <dx:TreeListDataColumn FieldName="Calculation" VisibleIndex="1" Caption="Calc" Width="50" HeaderStyle-Wrap="True"></dx:TreeListDataColumn>
                                                                        <dx:TreeListDataColumn FieldName="Curr" VisibleIndex="2" Caption="Curr" Width="50" HeaderStyle-Wrap="True"></dx:TreeListDataColumn>
                                                                        <dx:TreeListTextColumn FieldName="Amount" VisibleIndex="4" Caption="Amount" Width="150" HeaderStyle-Wrap="True">
                                                                            <PropertiesTextEdit DisplayFormatString="N2" />
                                                                        </dx:TreeListTextColumn>
                                                                        <%-- <dx:TreeListTextColumn FieldName="M01" VisibleIndex="4" Visible="false" Caption="M01" Width="150" HeaderStyle-Wrap="True">
                                                                            <PropertiesTextEdit DisplayFormatString="N2" />
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="M02" VisibleIndex="5" Visible="false" Caption="M02" Width="150" HeaderStyle-Wrap="True">
                                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="M03" VisibleIndex="7" Visible="false" Caption="M03" Width="150" HeaderStyle-Wrap="True">
                                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="M04" VisibleIndex="9" Visible="false" Caption="M04" Width="150" HeaderStyle-Wrap="True">
                                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="M05" VisibleIndex="11" Visible="false" Caption="M05" Width="150" HeaderStyle-Wrap="True">
                                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="M06" VisibleIndex="12" Visible="false" Caption="M06" Width="150" HeaderStyle-Wrap="True">
                                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="M07" VisibleIndex="14" Visible="false" Caption="M07" Width="150" HeaderStyle-Wrap="True">
                                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="M08" VisibleIndex="16" Visible="false" Caption="M08" Width="150" HeaderStyle-Wrap="True">
                                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="M09" VisibleIndex="18" Visible="false" Caption="M09" Width="150" HeaderStyle-Wrap="True">
                                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="M10" VisibleIndex="19" Visible="false" Caption="M10" Width="150" HeaderStyle-Wrap="True">
                                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="M11" VisibleIndex="21" Visible="false" Caption="M11" Width="150" HeaderStyle-Wrap="True">
                                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="M12" VisibleIndex="23" Visible="false" Caption="M12" Width="150" HeaderStyle-Wrap="True">
                                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                                        </dx:TreeListTextColumn>--%>
                                                                        <dx:TreeListTextColumn FieldName="AllocatedDriver" VisibleIndex="23" Caption="Allocated Driver" Width="140" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="ACID" VisibleIndex="25" Caption="AC" Width="60" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="AllocatedRT" VisibleIndex="26" Caption="AllocatedRT" Width="100" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="Airports" VisibleIndex="27" Caption="Airports" Width="100" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="AllocatedFLT" VisibleIndex="28" Caption="AllocatedFLT" Width="100" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="AllocateFltDirection" VisibleIndex="29" Caption="Direction" Width="70" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="Network" VisibleIndex="30" Caption="Network" Width="65" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="Carrier" VisibleIndex="31" Caption="Carrier" Width="80" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="Fields" VisibleIndex="32" Caption="Fields" Width="80" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="Division" VisibleIndex="33" Caption="Division" Width="80" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="CostType" VisibleIndex="34" Caption="Cost Type" Width="80" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="CostGroup" VisibleIndex="35" Caption="Cost Group" Width="90" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="DirectIndirect" VisibleIndex="36" Caption="Direct Indirect" Width="110" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                         <dx:TreeListTextColumn FieldName="AccLevel1" VisibleIndex="35" Caption="AccLevel1" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="AccLevel1" VisibleIndex="36" Caption="AccLevel1" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="AccLevel2" VisibleIndex="37" Caption="AccLevel2" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="AccLevel3" VisibleIndex="38" Caption="AccLevel3" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="AccLevel4" VisibleIndex="39" Caption="AccLevel4" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="AccLevel5" VisibleIndex="40" Caption="AccLevel5" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                          <dx:TreeListTextColumn FieldName="MaBoPhan" VisibleIndex="41" Caption="MaBoPhan" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="ManagermentCode" VisibleIndex="42" Caption="ManagermentCode" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                        <dx:TreeListTextColumn FieldName="ACCode" VisibleIndex="43" Caption="ACCode" Width="100" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                                                        </dx:TreeListTextColumn>
                                                                    </Columns>
                                                                    <Styles>
                                                                        <AlternatingNode Enabled="True"></AlternatingNode>
                                                                        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                                                    </Styles>
                                                                    <Settings ShowTreeLines="true" GridLines="Both" VerticalScrollBarMode="Auto" ScrollableHeight="300" HorizontalScrollBarMode="Auto" />
                                                                    <Paddings Padding="0px" />
                                                                    <Border BorderWidth="1px" />
                                                                    <BorderBottom BorderWidth="1px" />
                                                                    <SettingsBehavior AllowFocusedNode="true" AllowSort="false" AutoExpandAllNodes="true" />
                                                                    <SettingsResizing ColumnResizeMode="Control" />
                                                                    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllNodes" />
                                                                    <Border BorderStyle="None" />
                                                                    <ClientSideEvents FocusedNodeChanged="RevCost.ClientStoresGrid_FocusedNodeChanged"
                                                                        BeginCallback="RevCost.ClientStoresGrid_BeginCallback"
                                                                        EndCallback="RevCost.ClientStoresGrid_EndCallback" />
                                                                </dx:ASPxTreeList>
                                                                <dx:ASPxTreeListExporter ID="ASPxTreeListExporter1" runat="server" TreeListID="StoresGrid"></dx:ASPxTreeListExporter>
                                                            </dx:SplitterContentControl>
                                                        </ContentCollection>
                                                        <PaneStyle>
                                                            <BorderTop BorderWidth="0px"></BorderTop>
                                                            <BorderLeft BorderWidth="1px"></BorderLeft>
                                                            <BorderRight BorderWidth="1px"></BorderRight>
                                                            <BorderBottom BorderWidth="1px"></BorderBottom>
                                                            <Paddings PaddingLeft="0" PaddingRight="1" PaddingBottom="0" PaddingTop="0" />
                                                        </PaneStyle>
                                                    </dx:SplitterPane>
                                                    <dx:SplitterPane Size="300" Name="StoreDetail" Separator-Visible="False">
                                                        <ContentCollection>
                                                            <dx:SplitterContentControl>
                                                                <dx:ASPxGridView ID="StoreDetailsGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                                    ClientInstanceName="ClientStoreDetailsGrid" Width="100%" KeyFieldName="StoreDetailID"
                                                                    OnCustomCallback="StoreDetailsGrid_CustomCallback"
                                                                    OnBatchUpdate="StoreDetailsGrid_BatchUpdate"
                                                                    OnRowValidating="StoreDetailsGrid_RowValidating"
                                                                    OnCellEditorInitialize="StoreDetailsGrid_CellEditorInitialize">
                                                                    <Columns>
                                                                        <dx:GridViewDataTextColumn FieldName="RevCostMonth" VisibleIndex="0" Caption="Month" Width="60" FixedStyle="Left" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <EditFormSettings Visible="False" />
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataSpinEditColumn FieldName="Amount" VisibleIndex="2" Caption="Amount" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <PropertiesSpinEdit DisplayFormatString="N2" DisplayFormatInEditMode="true" MinValue="0">
                                                                                <SpinButtons ShowIncrementButtons="false" ShowLargeIncrementButtons="false"></SpinButtons>
                                                                                <Style HorizontalAlign="Right"></Style>
                                                                            </PropertiesSpinEdit>
                                                                            <EditCellStyle HorizontalAlign="Right"></EditCellStyle>
                                                                            <CellStyle HorizontalAlign="Right"></CellStyle>
                                                                            <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                                        </dx:GridViewDataSpinEditColumn>
                                                                        <dx:GridViewDataCheckColumn FieldName="Posted" VisibleIndex="14" Caption="Post?" Width="45" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                        </dx:GridViewDataCheckColumn>
                                                                    </Columns>
                                                                    <Styles>
                                                                        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                                                    </Styles>
                                                                    <Settings ShowFooter="true" ShowTitlePanel="true" ShowStatusBar="Visible" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" />
                                                                    <SettingsEditing Mode="Batch">
                                                                        <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                                                                    </SettingsEditing>
                                                                    <Paddings Padding="0px" />
                                                                    <Border BorderWidth="1px" />
                                                                    <BorderBottom BorderWidth="1px" />
                                                                    <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                                                    <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                                                                    <TotalSummary>
                                                                        <dx:ASPxSummaryItem FieldName="Amount" SummaryType="Sum" ShowInColumn="Amount" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                                    </TotalSummary>
                                                                    <Templates>
                                                                        <StatusBar>
                                                                            <dx:ASPxButton ID="btnSaveStoreDetail" runat="server" Text="Save Changes" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                                                <ClientSideEvents Click="RevCost.ClientSaveStoreDetail_Click" />
                                                                                <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                                                            </dx:ASPxButton>
                                                                        </StatusBar>
                                                                        <TitlePanel>
                                                                            <div style="float: left">
                                                                                <dx:ASPxLabel runat="server" Font-Bold="true" Text="Store Details"></dx:ASPxLabel>
                                                                            </div>
                                                                            <dx:ASPxRoundPanel ID="AllocateRoundPanel" runat="server" HeaderStyle-HorizontalAlign="Left" Collapsed="true" HeaderText="Allocate by Quarter/Year" ShowCollapseButton="true" Width="100%">
                                                                                <ClientSideEvents CollapsedChanged="RevCost.ClientAllocate_CollapsedChanged" />
                                                                                <ContentPaddings Padding="0" />
                                                                                <PanelCollection>
                                                                                    <dx:PanelContent>
                                                                                        <dx:ASPxFormLayout ID="AllocateForm" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                                                                                            AlignItemCaptionsInAllGroups="true" Width="100%">
                                                                                            <Paddings Padding="0" />
                                                                                            <Styles>
                                                                                                <LayoutItem>
                                                                                                    <Paddings PaddingLeft="0px" PaddingTop="1px" PaddingBottom="1px" />
                                                                                                </LayoutItem>
                                                                                            </Styles>
                                                                                            <Items>
                                                                                                <dx:LayoutItem Caption="Q1">
                                                                                                    <LayoutItemNestedControlCollection>
                                                                                                        <dx:LayoutItemNestedControlContainer>
                                                                                                            <dx:ASPxSpinEdit runat="server" ID="Q1AmountEditor" Width="200" AutoResizeWithContainer="true" DisplayFormatString="N2" HorizontalAlign="Right">
                                                                                                                <SpinButtons ShowIncrementButtons="false" ShowLargeIncrementButtons="false"></SpinButtons>
                                                                                                            </dx:ASPxSpinEdit>
                                                                                                        </dx:LayoutItemNestedControlContainer>
                                                                                                    </LayoutItemNestedControlCollection>
                                                                                                </dx:LayoutItem>
                                                                                                <dx:LayoutItem Caption="Q2">
                                                                                                    <LayoutItemNestedControlCollection>
                                                                                                        <dx:LayoutItemNestedControlContainer>
                                                                                                            <dx:ASPxSpinEdit runat="server" ID="Q2AmountEditor" Width="200" DisplayFormatString="N2" HorizontalAlign="Right">
                                                                                                                <SpinButtons ShowIncrementButtons="false" ShowLargeIncrementButtons="false"></SpinButtons>
                                                                                                            </dx:ASPxSpinEdit>
                                                                                                        </dx:LayoutItemNestedControlContainer>
                                                                                                    </LayoutItemNestedControlCollection>
                                                                                                </dx:LayoutItem>
                                                                                                <dx:LayoutItem Caption="Q3">
                                                                                                    <LayoutItemNestedControlCollection>
                                                                                                        <dx:LayoutItemNestedControlContainer>
                                                                                                            <dx:ASPxSpinEdit runat="server" ID="Q3AmountEditor" Width="200" DisplayFormatString="N2" HorizontalAlign="Right">
                                                                                                                <SpinButtons ShowIncrementButtons="false" ShowLargeIncrementButtons="false"></SpinButtons>
                                                                                                            </dx:ASPxSpinEdit>
                                                                                                        </dx:LayoutItemNestedControlContainer>
                                                                                                    </LayoutItemNestedControlCollection>
                                                                                                </dx:LayoutItem>
                                                                                                <dx:LayoutItem Caption="Q4">
                                                                                                    <LayoutItemNestedControlCollection>
                                                                                                        <dx:LayoutItemNestedControlContainer>
                                                                                                            <dx:ASPxSpinEdit runat="server" ID="Q4AmountEditor" Width="200" DisplayFormatString="N2" HorizontalAlign="Right">
                                                                                                                <SpinButtons ShowIncrementButtons="false" ShowLargeIncrementButtons="false"></SpinButtons>
                                                                                                            </dx:ASPxSpinEdit>
                                                                                                        </dx:LayoutItemNestedControlContainer>
                                                                                                    </LayoutItemNestedControlCollection>
                                                                                                </dx:LayoutItem>
                                                                                                <dx:LayoutItem Caption="Year">
                                                                                                    <LayoutItemNestedControlCollection>
                                                                                                        <dx:LayoutItemNestedControlContainer>
                                                                                                            <dx:ASPxSpinEdit runat="server" ID="YearAmountEditor" Width="200" DisplayFormatString="N2" HorizontalAlign="Right">
                                                                                                                <SpinButtons ShowIncrementButtons="false" ShowLargeIncrementButtons="false"></SpinButtons>
                                                                                                            </dx:ASPxSpinEdit>
                                                                                                        </dx:LayoutItemNestedControlContainer>
                                                                                                    </LayoutItemNestedControlCollection>
                                                                                                </dx:LayoutItem>
                                                                                                <dx:LayoutItem ShowCaption="False" VerticalAlign="Middle" HorizontalAlign="Center" Paddings-PaddingTop="5">
                                                                                                    <LayoutItemNestedControlCollection>
                                                                                                        <dx:LayoutItemNestedControlContainer>
                                                                                                            <dx:ASPxButton ID="btnAllocateApply" ClientInstanceName="ClientAllocateApply" runat="server" Text="Apply" AutoPostBack="false">
                                                                                                                <ClientSideEvents Click="RevCost.ClientAllocateApply_Click" />
                                                                                                            </dx:ASPxButton>
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
                                                                                    </dx:PanelContent>
                                                                                </PanelCollection>
                                                                            </dx:ASPxRoundPanel>
                                                                        </TitlePanel>
                                                                    </Templates>
                                                                    <ClientSideEvents
                                                                        BeginCallback="RevCost.ClientStoreDetailsGrid_BeginCallback"
                                                                        EndCallback="RevCost.ClientStoreDetailsGrid_EndCallback"
                                                                        BatchEditStartEditing="RevCost.ClientStoreDetailsGrid_BatchEditStartEditing" />
                                                                </dx:ASPxGridView>
                                                            </dx:SplitterContentControl>
                                                        </ContentCollection>
                                                        <PaneStyle>
                                                            <BorderTop BorderWidth="0px"></BorderTop>
                                                            <BorderLeft BorderWidth="0px"></BorderLeft>
                                                            <BorderRight BorderWidth="0px"></BorderRight>
                                                            <BorderBottom BorderWidth="0px"></BorderBottom>
                                                            <Paddings PaddingLeft="2" PaddingRight="0" PaddingBottom="0" PaddingTop="0" />
                                                        </PaneStyle>
                                                    </dx:SplitterPane>
                                                </Panes>
                                            </dx:SplitterPane>
                                            <dx:SplitterPane Size="45" Separator-Visible="False">
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
                                                        <dx:ASPxButton ID="btnRefreshSrore" runat="server" Text="Refresh" RenderMode="Button" AutoPostBack="false">
                                                            <ClientSideEvents Click="RevCost.ClientRefreshSrore_Click" />
                                                            <Image Url="../../Content/images/action/action_refresh.gif" Height="16"></Image>
                                                        </dx:ASPxButton>

                                                        <dx:ASPxButton ID="btnCalculateStore" runat="server" Text="Calculate" ClientInstanceName="ClientCalculateButton" RenderMode="Button" AutoPostBack="false">
                                                            <ClientSideEvents Click="RevCost.ClientCalculateStore_Click" />
                                                            <Image Url="../../Content/images/if_Calculator_669940.png" Height="16"></Image>
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnQuantity" runat="server" Text="Quantity" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                            <Image Url="../../Content/images/if_growth_1312842.png"></Image>
                                                            <ClientSideEvents Click="RevCost.ClientDirectToQuantity_Click" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnAllocateStore" runat="server" Text="Allocate Store" ClientInstanceName="ClientAllocateStoreButton" RenderMode="Button" AutoPostBack="false">
                                                            <ClientSideEvents Click="RevCost.ClientRunAllocateOneStore_Click" />
                                                            <%--  <Image Url="../../Content/images/action/save.png" Height="16"></Image>--%>
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnViewData" runat="server" Text="Allocated Data" RenderMode="Button" AutoPostBack="false">
                                                            <ClientSideEvents Click="RevCost.ClientViewAllocateData_Click" />
                                                            <%--<Image Url="~/Content/images/if_simpline_5_2305642.png" Height="16"></Image>--%>
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnViewAllocateError" runat="server" Text="Allocate Errors" RenderMode="Button" AutoPostBack="false">
                                                            <ClientSideEvents Click="RevCost.ClientViewAllocateError_Click" />
                                                            <%--<Image Url="~/Content/images/if_simpline_5_2305642.png" Height="16"></Image>--%>
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnChangeCompany2" runat="server" ClientInstanceName="ClientChangeCompanyButton2" Text="Change Company" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                            <ClientSideEvents Click="RevCost.ClientChangeCompanyButton_Click" />
                                                            <Image Url="../../Content/images/relationship.png"></Image>
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnPrintStore" runat="server" Text="Print" RenderMode="Button" AutoPostBack="false" Visible="false">
                                                            <Image Url="~/Content/images/if_simpline_5_2305642.png" Height="16"></Image>
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnExportExcel" runat="server" Text="Export To Excel" RenderMode="Button" OnClick="btnExportExcel_Click">
                                                            <Image Url="../../Content/images/action/export.png" Height="16"></Image>
                                                        </dx:ASPxButton>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                            </dx:SplitterPane>

                                        </Panes>
                                    </dx:SplitterPane>
                                </Panes>
                            </dx:SplitterPane>
                        </Panes>
                    </dx:ASPxSplitter>
                </div>
                <div class="left-pane">
                    <dx:ASPxSplitter ID="splitterVersion" runat="server" CssClass="main-menu" ClientInstanceName="ClientSplitterVersion" Orientation="Vertical" Width="695" Height="100%">
                        <ClientSideEvents PaneResized="RevCost.ClientSplitterVersion_PaneResized" />
                        <Panes>
                            <dx:SplitterPane Size="45%" Separator-Visible="False">
                                <Panes>
                                    <dx:SplitterPane Separator-Visible="False">
                                        <Panes>
                                            <dx:SplitterPane Size="40" Separator-Visible="False">
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <dx:ASPxSpinEdit ID="VersionYearEditor" ClientInstanceName="ClientVersionYearEditor" Caption="Year" MinValue="2000" MaxValue="9999" runat="server" Width="60px"></dx:ASPxSpinEdit>
                                                                </td>
                                                                <td style="width: 230px;">
                                                                    <dx:ASPxRadioButtonList ID="rdoVersionType" runat="server" RepeatDirection="Horizontal" ValueType="System.String">
                                                                        <Border BorderWidth="0" BorderStyle="None" />
                                                                        <Paddings Padding="0" />
                                                                        <Items>
                                                                            <dx:ListEditItem Value="P" Text="Planning" Selected="true" />
                                                                            <dx:ListEditItem Value="E" Text="Estimate" />
                                                                            <dx:ListEditItem Value="A" Text="Actual" />
                                                                        </Items>
                                                                        <ClientSideEvents ValueChanged="RevCost.ClientVersionYearEditor_ValueChanged" />
                                                                    </dx:ASPxRadioButtonList>
                                                                </td>
                                                                <td>
                                                                    <dx:ASPxButton ID="btnQuery" runat="server" Text="Query" AutoPostBack="false" UseSubmitBehavior="true">
                                                                        <ClientSideEvents Click="RevCost.ClientQuery_Click" />
                                                                    </dx:ASPxButton>
                                                                </td>
                                                                  <td style="width: 50px;">
                                                                    <dx:ASPxButton ID="HideMenuButton" ClientInstanceName="MenuButton" RenderMode="Link" Text="Hide" ImagePosition="Top" runat="server" AutoPostBack="False"
                                                                        Height="30px" GroupName="Menu">
                                                                        <ClientSideEvents Click="RevCost.ClientHideMenuButton_Click" />
                                                                        <Image Url="../../Content/images/action/go_back.png"></Image>
                                                                    </dx:ASPxButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                            </dx:SplitterPane>
                                            <dx:SplitterPane Name="VersionsPane" Separator-Visible="False">
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
                                                        <dx:ASPxGridView ID="VersionGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                            ClientInstanceName="ClientVersionGrid" Width="100%" KeyFieldName="VersionID"
                                                            OnCustomCallback="VersionGrid_CustomCallback"
                                                            OnFillContextMenuItems="VersionGrid_FillContextMenuItems">
                                                            <Columns>
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
                                                            <Settings ShowTitlePanel="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="300" VerticalScrollBarStyle="Standard" />
                                                            <SettingsContextMenu Enabled="true" EnableColumnMenu="False" EnableFooterMenu="False" EnableGroupFooterMenu="False" EnableGroupPanelMenu="False">
                                                                <RowMenuItemVisibility NewRow="false" EditRow="false" DeleteRow="false" Refresh="false"></RowMenuItemVisibility>
                                                            </SettingsContextMenu>
                                                            <Paddings Padding="0px" />
                                                            <Border BorderWidth="1px" />
                                                            <BorderBottom BorderWidth="1px" />
                                                            <SettingsBehavior AllowFocusedRow="True" />
                                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                                                            <Templates>
                                                                <TitlePanel>
                                                                    <div style="float: left">
                                                                        <dx:ASPxLabel runat="server" Font-Bold="true" Text="Version Type"></dx:ASPxLabel>
                                                                    </div>
                                                                    <div style="float: right; padding-right: 10px">
                                                                        <%--<dx:ASPxButton ID="btnNewVersion" runat="server" ClientInstanceName="ClientNewVersionButton" Text="New" Visible="false" RenderMode="Link" ImagePosition="Left" AutoPostBack="false">
                                                                            <Image Height="16" Url="../../Content/images/SpinEditPlus.png"></Image>
                                                                            <ClientSideEvents Click="RevCost.ClientNewVersionButton_Click" />
                                                                        </dx:ASPxButton>--%>
                                                                        <%-- &nbsp;--%>
                                                                        <dx:ASPxButton ID="btnCopyVersion" runat="server" ClientInstanceName="ClientCopyVersionButton" Text="Copy" RenderMode="Link" ImagePosition="Left" AutoPostBack="false">
                                                                            <Image Url="../../Content/images/if_simpline_4_2305586.png" Height="16"></Image>
                                                                            <ClientSideEvents Click="RevCost.ClientCopyVersionButton_Click" />
                                                                        </dx:ASPxButton>
                                                                    </div>
                                                                </TitlePanel>
                                                            </Templates>
                                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientVersionGrid_FocusedRowChanged"
                                                                BeginCallback="RevCost.ClientVersionGrid_BeginCallback"
                                                                EndCallback="RevCost.ClientVersionGrid_EndCallback"
                                                                ContextMenuItemClick="RevCost.ClientVersionGrid_ContextMenuItemClick" />
                                                        </dx:ASPxGridView>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                            </dx:SplitterPane>
                                        </Panes>
                                    </dx:SplitterPane>
                                </Panes>
                                <PaneStyle>
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                    <BorderLeft BorderWidth="0px"></BorderLeft>
                                    <BorderRight BorderWidth="0px"></BorderRight>
                                    <BorderBottom BorderWidth="0px"></BorderBottom>
                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                </PaneStyle>
                            </dx:SplitterPane>
                            <dx:SplitterPane Separator-Visible="False">
                                <Panes>
                                    <dx:SplitterPane Separator-Visible="False">
                                        <Panes>
                                            <dx:SplitterPane Name="VersionCompanyPane" Separator-Visible="False">
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
                                                        <dx:ASPxGridView ID="VersionCompanyGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                            ClientInstanceName="ClientVersionCompanyGrid" Width="100%" KeyFieldName="VerCompanyID"
                                                            OnCustomCallback="VersionCompanyGrid_CustomCallback"
                                                            OnCustomDataCallback="VersionCompanyGrid_CustomDataCallback"
                                                            OnFillContextMenuItems="VersionCompanyGrid_FillContextMenuItems">
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn FieldName="VersionName" VisibleIndex="1" Caption="Version Name" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="VersionNumber" VisibleIndex="2" Caption="Number" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="VerLevel" VisibleIndex="3" Caption="Level" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataCheckColumn FieldName="HotData" VisibleIndex="4" Caption="Active" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                </dx:GridViewDataCheckColumn>
                                                                <dx:GridViewCommandColumn VisibleIndex="5" Width="30">
                                                                    <CustomButtons>
                                                                        <dx:GridViewCommandColumnCustomButton ID="btnVersionFiles" Text="">
                                                                            <Image Url="../../Content/images/more-detail-glyph.png" Height="16"></Image>
                                                                        </dx:GridViewCommandColumnCustomButton>
                                                                    </CustomButtons>
                                                                </dx:GridViewCommandColumn>
                                                            </Columns>
                                                            <Styles>
                                                                <AlternatingRow Enabled="true" />
                                                                <TitlePanel HorizontalAlign="Left"></TitlePanel>
                                                                <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                                            </Styles>
                                                            <Settings ShowTitlePanel="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="400" VerticalScrollBarStyle="Standard" />
                                                            <SettingsContextMenu Enabled="true" EnableColumnMenu="False" EnableFooterMenu="False" EnableGroupFooterMenu="False" EnableGroupPanelMenu="False">
                                                                <RowMenuItemVisibility NewRow="false" EditRow="false" DeleteRow="false" Refresh="false"></RowMenuItemVisibility>
                                                            </SettingsContextMenu>
                                                            <Paddings Padding="0px" />
                                                            <Border BorderWidth="1px" />
                                                            <BorderBottom BorderWidth="1px" />
                                                            <SettingsResizing ColumnResizeMode="NextColumn" />
                                                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
                                                            <Templates>
                                                                <%--   <FooterRow>
                                                                </FooterRow>
                                                                <StatusBar>
                                                                </StatusBar>--%>
                                                                <TitlePanel>
                                                                    <div style="float: left">
                                                                        <dx:ASPxLabel runat="server" Font-Bold="true" Text="Version Company"></dx:ASPxLabel>
                                                                    </div>

                                                                    <div style="float: right; padding-right: 10px">
                                                                        <dx:ASPxButton ID="btnNewVersionCompany" runat="server" ClientInstanceName="ClientNewVersionCompanyButton" Text="New" RenderMode="Link" ImagePosition="Left" AutoPostBack="false">
                                                                            <Image Height="16" Url="../../Content/images/SpinEditPlus.png"></Image>
                                                                            <ClientSideEvents Click="RevCost.ClientNewVersionCompanyButton_Click" />
                                                                        </dx:ASPxButton>
                                                                     <%--   &nbsp;
                                                                        <dx:ASPxButton ID="btnCopyVersionCompany" runat="server" ClientInstanceName="ClientCopyVersionCompanyButton" Text="Copy" RenderMode="Link" ImagePosition="Left" AutoPostBack="false">
                                                                            <Image Url="../../Content/images/if_simpline_4_2305586.png" Height="16"></Image>
                                                                            <ClientSideEvents Click="RevCost.ClientCopyVersionCompanyButton_Click" />
                                                                        </dx:ASPxButton>--%>
                                                                        &nbsp;
                                                                        <dx:ASPxButton ID="btnDuplicateVersionCompany" runat="server" ClientInstanceName="ClientDuplicateVersionCompany" Text="Duplicate" RenderMode="Link" ImagePosition="Left" AutoPostBack="false">
                                                                            <Image Url="../../Content/images/duplicate.png" Height="16"></Image>
                                                                            <ClientSideEvents Click="RevCost.ClientClientDuplicateVersionCompanyButton_Click" />
                                                                        </dx:ASPxButton>
                                                                    </div>
                                                                </TitlePanel>
                                                            </Templates>
                                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientVersionCompanyGrid_FocusedRowChanged"
                                                                BeginCallback="RevCost.ClientVersionCompanyGrid_BeginCallback"
                                                                EndCallback="RevCost.ClientVersionCompanyGrid_EndCallback"
                                                                CustomButtonClick="RevCost.ClientVersionCompanyGrid_CustomButtonClick"
                                                                ContextMenuItemClick="RevCost.ClientVersionCompanyGrid_ContextMenuItemClick" />
                                                        </dx:ASPxGridView>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                            </dx:SplitterPane>
                                            <dx:SplitterPane Size="45" Separator-Visible="False">
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
                                                        <dx:ASPxButton ID="btnApprove" runat="server" Text="Approve" ClientInstanceName="ClientApproveButton" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                            <Image Url="../../Content/images/action/Appr.gif"></Image>
                                                            <ClientSideEvents Click="RevCost.ClientShowApproveNoteButton_Click" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnUnApprove" runat="server" Text="Unapprove" RenderMode="Button" ClientInstanceName="ClientUnapprovedButton" AutoPostBack="false" Image-Width="16">
                                                            <Paddings Padding="2px" />
                                                            <Image Url="../../Content/images/action/UnAppr.gif"></Image>
                                                            <ClientSideEvents Click="RevCost.ClientUnaprovedButton_Click" />
                                                        </dx:ASPxButton>

                                                        <dx:ASPxButton ID="btnRunAllocate" runat="server" ClientInstanceName="ClientRunAllocateButton" Text="Allocate" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                            <ClientSideEvents Click="RevCost.ClientRunAllocateButton_Click" />
                                                        </dx:ASPxButton>
                                                        <%-- <dx:ASPxButton ID="btnRunAllocateAll" runat="server" ClientInstanceName="ClientRunAllocateAllButton" Text="Allocate All" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                                        <ClientSideEvents Click="RevCost.ClientRunAllocateAllButton_Click" />
                                                                    </dx:ASPxButton>--%>
                                                        <%--<dx:ASPxButton ID="btnSummaryData" runat="server" Text="Summary Data" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                            <ClientSideEvents Click="RevCost.ClientSummaryData_Click" />

                                                        </dx:ASPxButton>--%>
                                                        <dx:ASPxButton ID="btnChangeCompany" runat="server" ClientInstanceName="ClientChangeCompanyButton" Text="Change Company" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                            <ClientSideEvents Click="RevCost.ClientChangeCompanyButton_Click" />
                                                            <Image Url="../../Content/images/relationship.png"></Image>
                                                        </dx:ASPxButton>
                                                        <%--  <dx:ASPxButton ID="btnPrint" runat="server" Text="Print" RenderMode="Button" AutoPostBack="false" Image-Width="16" Image-Url="~/Content/images/if_simpline_5_2305642.png">
                                                        </dx:ASPxButton>--%>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                                <PaneStyle>
                                                    <BorderTop BorderWidth="0px"></BorderTop>
                                                    <BorderLeft BorderWidth="0px"></BorderLeft>
                                                    <BorderRight BorderWidth="0px"></BorderRight>
                                                    <BorderBottom BorderWidth="0px"></BorderBottom>
                                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="2" PaddingTop="5" />
                                                </PaneStyle>
                                            </dx:SplitterPane>
                                        </Panes>
                                    </dx:SplitterPane>
                                </Panes>
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
                </div>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>

    <dx:ASPxPopupControl ID="ApproveNotePopup" runat="server" Width="500" Height="200" AllowDragging="True" HeaderText="Approve Note" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientApproveNotePopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxMemo ID="ApproveNoteEditor" runat="server" ClientInstanceName="ClientApproveNoteEditor" Height="100%" Width="100%" Rows="10"></dx:ASPxMemo>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Cancel" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientApproveNotePopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApproveOK" runat="server" Text="Approve" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClienApproveButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="CompanyListPopup" runat="server" Width="500" Height="500" AllowDragging="True" HeaderText="Change Company" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientCompanyListPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxGridView ID="CompanyGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientCompanyGrid" Width="100%" KeyFieldName="CompanyID"
                    OnCustomCallback="CompanyGrid_CustomCallback">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="OriArea" VisibleIndex="1" Caption="Area" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ShortName" VisibleIndex="2" Caption="Code" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="NameV" VisibleIndex="3" Caption="Name VN" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <DataItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("AreaCode") +"-"+ Eval("NameV") %>'></asp:Label>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Styles>
                        <AlternatingRow Enabled="true" />
                        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                    </Styles>
                    <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" />
                    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="OriArea;ShortName;NameV" />
                    <Paddings Padding="0px" />
                    <Border BorderWidth="0px" BorderStyle="None" />
                    <BorderBottom BorderWidth="1px" />
                    <SettingsBehavior AllowFocusedRow="True" />
                    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
                    <ClientSideEvents RowDblClick="RevCost.ClientCompanyGrid_RowDblClick" />
                </dx:ASPxGridView>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Cancel" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientCompanyListPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApply" runat="server" Text="Apply" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientApplyButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientCompanyListPopup_Shown" />
    </dx:ASPxPopupControl>


    <dx:ASPxPopupControl ID="VersionCompanyFilesPopup" runat="server" Width="800" Height="600" AllowDragging="True" HeaderText="Version Detail" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientVersionCompanyFilesPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxRoundPanel ID="VersionDetailRoundPanel" runat="server" HeaderStyle-HorizontalAlign="Left" Collapsed="false" HeaderText="Version Detail" ShowCollapseButton="true" Width="100%">
                    <ContentPaddings Padding="5px" />
                    <PanelCollection>
                        <dx:PanelContent>
                            <dx:ASPxMemo ID="VerCompanyDescriptionEditor" ClientInstanceName="ClientVerCompanyDescriptionEditor" runat="server" Caption="Description" Height="71px" Width="100%" AutoResizeWithContainer="true" Rows="3">
                                <CaptionSettings Position="Top" />
                            </dx:ASPxMemo>
                            <dx:ASPxMemo ID="VerCompanyApproveNoteEditor" ClientInstanceName="ClientVerCompanyApproveNoteEditor" runat="server" Caption="Approved Note" Height="71px" Width="100%" AutoResizeWithContainer="true" Rows="3">
                                <CaptionSettings Position="Top" />
                            </dx:ASPxMemo>
                            <dx:ASPxMemo ID="VerCompanyReviewNoteEditor" ClientInstanceName="ClientVerCompanyReviewNoteEditor" runat="server" Caption="Review Note" Height="71px" Width="100%" AutoResizeWithContainer="true" Rows="3">
                                <CaptionSettings Position="Top" />
                            </dx:ASPxMemo>
                            <dx:ASPxMemo ID="VerCompanyCreateNoteEditor" ClientInstanceName="ClientVerCompanyCreateNoteEditor" runat="server" Caption="Create Note" Height="71px" Width="100%" AutoResizeWithContainer="true" Rows="3">
                                <CaptionSettings Position="Top" />
                            </dx:ASPxMemo>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
                <br />
                <dx:ASPxRoundPanel ID="VersionCompanyFilesRoundPanel" runat="server" HeaderStyle-HorizontalAlign="Left" Collapsed="false" HeaderText="Version Files" ShowCollapseButton="true" Width="100%">
                    <ContentPaddings Padding="0" />
                    <PanelCollection>
                        <dx:PanelContent>
                            <dx:ASPxGridView ID="VersionCompanyFilesGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                ClientInstanceName="ClientVersionCompanyFilesGrid" Width="100%" KeyFieldName="VerCompanyFileID"
                                OnCustomCallback="VersionCompanyFilesGrid_CustomCallback"
                                OnCellEditorInitialize="VersionCompanyFilesGrid_CellEditorInitialize"
                                OnBatchUpdate="VersionCompanyFilesGrid_BatchUpdate">
                                <Columns>
                                    <dx:GridViewCommandColumn VisibleIndex="0" Caption="" Width="80">
                                        <CustomButtons>
                                            <dx:GridViewCommandColumnCustomButton Text="Download" ID="DownloadFile"></dx:GridViewCommandColumnCustomButton>
                                        </CustomButtons>
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn FieldName="FileName" VisibleIndex="1" Caption="File Name" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2" Caption="Description" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                <Styles>
                                    <AlternatingRow Enabled="true" />
                                    <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                </Styles>
                                <Settings ShowStatusBar="Hidden" VerticalScrollBarMode="Visible" VerticalScrollableHeight="120" VerticalScrollBarStyle="Standard" />
                                <SettingsEditing Mode="Batch">
                                    <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                                </SettingsEditing>
                                <Paddings Padding="0px" />
                                <Border BorderWidth="0px" />
                                <BorderBottom BorderWidth="0px" />
                                <SettingsResizing ColumnResizeMode="NextColumn" />
                                <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                                <ClientSideEvents CustomButtonClick="RevCost.ClientVersionCompanyFilesGrid_CustomButtonClick" />
                            </dx:ASPxGridView>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
                <div style="float: left; padding-left: 5px; padding-top: 4px">
                    <dx:ASPxCheckBox ID="chkHotData" runat="server" Text="Set working version" ClientInstanceName="ClientHotDataEditor"></dx:ASPxCheckBox>
                </div>
                <div style="float: right; padding-right: 5px; padding-top: 4px">
                    <table>
                        <tr>
                            <td>
                                <dx:ASPxUploadControl ID="VerCompanyFilesUC" runat="server" ClientInstanceName="ClientVerCompanyFilesUC" ShowProgressPanel="true" NullText="Browse file here"
                                    Width="280px" FileUploadMode="OnPageLoad" UploadMode="Advanced" OnFilesUploadComplete="VerCompanyFilesUC_FilesUploadComplete" BrowseButton-Text="Browse File">
                                    <ClientSideEvents FilesUploadComplete="RevCost.ClientVerCompanyFilesUC_FilesUploadComplete" />
                                    <ValidationSettings MaxFileSize="10000000" AllowedFileExtensions=".jpg,.jpeg,.gif,.doc,.docx,.xls,.xlsx,.pdf,.txt,.png" ShowErrors="true"></ValidationSettings>
                                </dx:ASPxUploadControl>
                            </td>
                            <td style="padding-left: 5px;">
                                <dx:ASPxButton ID="btnVerCompanyFileUpload" runat="server" Text="Upload" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                    <ClientSideEvents Click="RevCost.ClientUploadVerCompanyFile_Click" />
                                    <Image Url="../../Content/images/if_icon-98-folder-upload_314782.png"></Image>
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="3px" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Close" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientVersionCompanyFilesPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApply" runat="server" Text="Save" AutoPostBack="false" ClientInstanceName="ClientApplyVersionCompanyFilesButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientApplyVersionCompanyFilesButton_Click" />
                <Image Url="../../Content/images/action/save.png" Height="16"></Image>
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientVersionCompanyFilesPopup_Shown" />
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="CopyVersionCompanyPopup" runat="server" Width="500" Height="300" AllowDragging="True" HeaderText="Copy Version" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientCopyVersionCompanyPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxGridView ID="VersionCopyGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientVersionCopyGrid" Width="100%" KeyFieldName="VersionID"
                    OnCustomCallback="VersionCopyGrid_CustomCallback">
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancelCopy" runat="server" Text="Cancel" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientCopyVersionCompanyPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApplyCopy" runat="server" Text="Apply" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientApplyCopyVersionCompanyButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientCopyVersionCompanyPopup_Shown"
            CloseUp="RevCost.ClientCopyVersionCompanyPopup_CloseUp" />
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="AllocateParamsPopup" runat="server" Width="200" Height="100" AllowDragging="True" HeaderText="Run Allocate" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientAllocateParamsPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="AllocateParamsForm" runat="server" ColCount="2" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="From Month">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="FromMonthEditor" Width="50" ClientInstanceName="ClientFromMonthEditor" MinValue="1" MaxValue="12">
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
                                    <dx:ASPxSpinEdit runat="server" ID="ToMonthEditor" Width="50" ClientInstanceName="ClientToMonthEditor" MinValue="1" MaxValue="12">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption=" " ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox ID="chkAllocateOnByOne" runat="server" Text="Allocate Monthly one by one?" ClientInstanceName="ClientAllocateOnByOne" Checked="true"></dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption=" " ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox ID="chkRunAggregate" runat="server" Text="Run the aggregate after the allocation is complete?" ClientInstanceName="ClientRunAggregate" Checked="true"></dx:ASPxCheckBox>
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancelAllocate" runat="server" Text="Cancel" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientAllocateParamsPopup.Hide(); }}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApplyAllocate" runat="server" Text="Allocate" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientApplyAllocate_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="VersionCompanyPopup" runat="server" Width="580" Height="300" AllowDragging="True" HeaderText="Select Version" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientVersionCompanyPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxGridView ID="VersionCompanyBaseGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientVersionCompanyBaseGrid" Width="100%" KeyFieldName="VerCompanyID"
                    OnCustomCallback="VersionCompanyBaseGrid_CustomCallback">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="VersionName" VisibleIndex="1" Caption="Version Name" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="CreateStatus" VisibleIndex="2" Caption="Create Status" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ReviewStatus" VisibleIndex="3" Caption="Review Status" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ApproveStatus" VisibleIndex="4" Caption="Approve Status" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="5" Caption="Status" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewCommandColumn VisibleIndex="6" Width="35" ShowSelectCheckbox="true" ShowClearFilterButton="true"></dx:GridViewCommandColumn>
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancelCopy" runat="server" Text="Cancel" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientVersionCompanyPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApplyVersioBase" runat="server" Text="Apply" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientApplyVersionBase_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientVersionCompanyBaseGrid_Shown"
            CloseUp="RevCost.ClientVersionCompanyBaseGrid_CloseUp" />
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="ViewDataPopup" runat="server" AllowDragging="True" Modal="True"
        CloseAction="CloseButton"
        EnableViewState="False" PopupElementID="popupArea" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter" ShowMaximizeButton="false" ShowCloseButton="true"
        Width="800px" Height="600px" MinWidth="310px" MinHeight="280px"
        ClientInstanceName="ClientViewDataPopupControl" EnableHierarchyRecreation="True">
        <ContentStyle>
            <Paddings Padding="1px" />
        </ContentStyle>
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:FlsOpsStoreView runat="server" ID="FlsOpsStoreView" />
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ClientSideEvents Shown="RevCost.ClientViewDataPopupControl_Show" CloseUp="RevCost.ClientViewDataPopupControl_CloseUp" />
    </dx:ASPxPopupControl>


    <dx:ASPxPopupControl ID="ViewAllocateError" runat="server" AllowDragging="True" Modal="True"
        CloseAction="CloseButton"
        EnableViewState="False" PopupElementID="popupArea" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter" ShowMaximizeButton="false" ShowCloseButton="true"
        Width="600px" Height="400px" MinWidth="310px" MinHeight="280px"
        ClientInstanceName="ClientViewAllocateErrorPopup" EnableHierarchyRecreation="True">
        <ContentStyle>
            <Paddings Padding="1px" />
        </ContentStyle>
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ViewAllocateError runat="server" ID="ViewAllocateError1" />
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ClientSideEvents Shown="RevCost.ClientViewAllocateErrorPopup_Show" CloseUp="RevCost.ClientViewAllocateErrorPopup_CloseUp" />
    </dx:ASPxPopupControl>


    <dx:ASPxCallback ID="RevCostCallback" runat="server" ClientInstanceName="ClientRevCostCallback" OnCallback="RevCostCallback_Callback">
        <ClientSideEvents CallbackComplete="RevCost.ClientRevCostCallback_CallbackComplete" />
    </dx:ASPxCallback>



    <dx:ASPxGlobalEvents runat="server">
        <ClientSideEvents ControlsInitialized="RevCost.OnPageInit" />
    </dx:ASPxGlobalEvents>
</asp:Content>

