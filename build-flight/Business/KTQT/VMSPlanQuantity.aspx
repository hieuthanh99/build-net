<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="VMSPlanQuantity.aspx.cs" Inherits="Business_KTQT_VMSPlanQuantity" %>

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
                            ClientInstanceName="ClientDataGrid" Width="100%" KeyFieldName="TmpFlsID"
                            OnCustomCallback="DataGrid_CustomCallback">
                            <Columns>
                                <%-- <dx:GridViewDataTextColumn FieldName="Seq" VisibleIndex="0" Caption="Seq" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>--%>
                                <dx:GridViewDataTextColumn FieldName="SLAirlinesID" VisibleIndex="0" Caption="ID" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AREA" VisibleIndex="1" Caption="Area" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Flt_Month" VisibleIndex="2" Caption="Month" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Flt_Year" VisibleIndex="3" Caption="Year" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AC_ID" VisibleIndex="4" Caption="Aircraft" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AC_GROUP" VisibleIndex="5" Caption="AC Group" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CARRIER" VisibleIndex="6" Caption="Carrier" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="FLT_TYPE" VisibleIndex="7" Caption="Type" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NETWORK" VisibleIndex="8" Caption="Network" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ContractID" VisibleIndex="9" Caption="Contract" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="FLS" VisibleIndex="10" Caption="Quantity" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="REV" VisibleIndex="11" Caption="Revenue" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="REDUCE" VisibleIndex="12" Caption="Reduce" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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

