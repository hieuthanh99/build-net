<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="StationeryCost.aspx.cs" Inherits="Business_KTQT_StationeryCost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../../Scripts/CalcStationeryCost.js"></script>
    <style>
        .dxtlControl_MaterialCompact caption, .dxgvTitlePanel_MaterialCompact, .dxgvTable_MaterialCompact caption {
            font-size: 1.25em;
            font-weight: normal;
            padding: 3px 3px 5px;
            text-align: center;
            color: #999999;
            text-align: left;
        }
    </style>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="RevCost.ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Name="Menu" Size="120" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="float: left">
                            <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="5">
                                <Items>
                                    <dx:LayoutItem Caption="Chi nhánh">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cboAreaCode" runat="server" ClientInstanceName="ClientAreaCode" Width="150px" OnInit="cboAreaCode_Init">
                                                    <ClientSideEvents ValueChanged="RevCost.ClientAreaCode_ValueChanged" />
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Đơn vị" ColSpan="2">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cboCompany" runat="server" ClientInstanceName="ClientCompany" AutoPostBack="false" Width="250px" OnCallback="cboCompany_Callback">
                                                    <ClientSideEvents EndCallback="RevCost.ClientCompany_EndCallback" />
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Định mức KTKT" ColSpan="2">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cboNormYear" runat="server" ClientInstanceName="ClientNormYear" AutoPostBack="false" Width="250px" OnInit="cboNormYear_Init"></dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Version">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cboVersion" runat="server" ClientInstanceName="ClientVersion" AutoPostBack="false" Width="150px" OnInit="cboVersion_Init"></dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                                    <dx:LayoutItem ShowCaption="False">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxButton ID="btnFilter" runat="server" Text="Hiển thị" AutoPostBack="false" UseSubmitBehavior="true">
                                                    <ClientSideEvents Click="RevCost.ClientFilterButton_Click" />
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem ShowCaption="False">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxButton ID="btnCalcStationeryCost" runat="server" Text="Tính chi phí VPP" AutoPostBack="false" UseSubmitBehavior="true">
                                                    <ClientSideEvents Click="RevCost.ClientCalcStationeryCostButton_Click" />
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem ShowCaption="False">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxButton ID="btnApplyToVersion" runat="server" Text="Chuyển sang KTQT" AutoPostBack="false" UseSubmitBehavior="true">
                                                    <ClientSideEvents Click="RevCost.ClientApplyToVersionButton_Click" />
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                </Items>
                            </dx:ASPxFormLayout>
                        </div>

                        <div style="float: right">
                            <div class="title">
                                <asp:Literal ID="Literal1" runat="server" Text="TÍNH CHI PHÍ VĂN PHÒNG PHẨM" />
                            </div>
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
            <dx:SplitterPane Separator-Visible="False">
                <Panes>
                    <dx:SplitterPane Name="PositionGridPane">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxGridView ID="PositionGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                    ClientInstanceName="ClientPositionGrid" Width="100%" KeyFieldName="StationeryCostID"
                                    OnCustomCallback="Grid_CustomCallback"
                                    OnCustomColumnDisplayText="Grid_CustomColumnDisplayText"
                                    Caption="CHI PHÍ VĂN PHÒNG PHẨM THEO CHỨC DANH">
                                    <Columns>
                                        <dx:GridViewDataColumn FieldName="CompanyName" UnboundType="String" VisibleIndex="1" Caption="Đơn vị" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn FieldName="StationeryName" UnboundType="String" VisibleIndex="2" Caption="Văn phòng phẩm" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn FieldName="PositionTypeID" UnboundType="String" VisibleIndex="3" Caption="Chức danh" Width="170" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="Quantity" VisibleIndex="4" Caption="Số lượng" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="UnitPrice" VisibleIndex="5" Caption="Đơn giá" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="Amount" VisibleIndex="6" Caption="Thành tiền" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataColumn UnboundType="String" VisibleIndex="7" Width="50%"></dx:GridViewDataColumn>
                                    </Columns>
                                    <Styles>
                                        <AlternatingRow Enabled="true" />
                                    </Styles>
                                    <Settings GroupFormat="{1}" ShowGroupPanel="false" ShowFilterRow="true" ShowFooter="true" ShowStatusBar="Hidden" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                    <Paddings Padding="0px" />
                                    <Border BorderWidth="1px" />
                                    <BorderBottom BorderWidth="0px" />
                                    <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                    <SettingsCommandButton RenderMode="Button"></SettingsCommandButton>
                                    <SettingsPager Visible="true" PageSize="100" Mode="EndlessPaging" />
                                    <TotalSummary>
                                        <dx:ASPxSummaryItem FieldName="Quantity" ShowInColumn="Quantity" SummaryType="Sum" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                        <dx:ASPxSummaryItem FieldName="UnitPrice" ShowInColumn="UnitPrice" SummaryType="Sum" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                        <dx:ASPxSummaryItem FieldName="Amount" ShowInColumn="Amount" SummaryType="Sum" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                    </TotalSummary>
                                </dx:ASPxGridView>
                            </dx:SplitterContentControl>
                        </ContentCollection>
                        <PaneStyle Border-BorderWidth="0px">
                            <BorderTop BorderWidth="0px"></BorderTop>
                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                        </PaneStyle>
                    </dx:SplitterPane>
                    <dx:SplitterPane Name="CommonGridPane">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxGridView ID="CommonGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                    ClientInstanceName="ClientCommonGrid" Width="100%" KeyFieldName="StationeryCostID"
                                    OnCustomCallback="CommonGrid_CustomCallback"
                                    OnCustomColumnDisplayText="Grid_CustomColumnDisplayText"
                                    Caption="CHI PHÍ VĂN PHÒNG PHẨM DÙNG CHUNG">
                                    <Columns>
                                        <dx:GridViewDataColumn FieldName="CompanyName" UnboundType="String" VisibleIndex="1" Caption="Đơn vị" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn FieldName="StationeryName" UnboundType="String" VisibleIndex="2" Caption="Văn phòng phẩm" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="Quantity" VisibleIndex="4" Caption="Số lượng" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="UnitPrice" VisibleIndex="5" Caption="Đơn giá" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="Amount" VisibleIndex="6" Caption="Thành tiền" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataColumn UnboundType="String" VisibleIndex="7" Width="50%">
                                            <Settings AllowAutoFilter="False" AllowSort="False" />
                                        </dx:GridViewDataColumn>
                                    </Columns>
                                    <Styles>
                                        <AlternatingRow Enabled="true" />
                                    </Styles>
                                    <Settings GroupFormat="{1}" ShowGroupPanel="false" ShowFilterRow="true" ShowFooter="true" ShowStatusBar="Hidden" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                    <Paddings Padding="0px" />
                                    <Border BorderWidth="0px" />
                                    <BorderBottom BorderWidth="0px" />
                                    <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                    <SettingsCommandButton RenderMode="Button"></SettingsCommandButton>
                                    <SettingsPager Visible="true" PageSize="100" Mode="EndlessPaging" />
                                    <TotalSummary>
                                        <dx:ASPxSummaryItem FieldName="Quantity" ShowInColumn="Quantity" SummaryType="Sum" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                        <dx:ASPxSummaryItem FieldName="UnitPrice" ShowInColumn="UnitPrice" SummaryType="Sum" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                        <dx:ASPxSummaryItem FieldName="Amount" ShowInColumn="Amount" SummaryType="Sum" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                    </TotalSummary>
                                </dx:ASPxGridView>
                            </dx:SplitterContentControl>
                        </ContentCollection>
                        <PaneStyle Border-BorderWidth="0px">
                            <BorderTop BorderWidth="0px"></BorderTop>
                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                        </PaneStyle>
                    </dx:SplitterPane>
                </Panes>
                <PaneStyle Border-BorderWidth="0px">
                    <BorderTop BorderWidth="0px"></BorderTop>
                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                </PaneStyle>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
    <dx:ASPxCallback ID="CalcStationeryCallback" runat="server" ClientInstanceName="ClientCalcStationeryCallback" OnCallback="CalcStationeryCallback_Callback">
        <ClientSideEvents CallbackComplete="RevCost.ClientCalcStationeryCallback_CallbackComplete" />
    </dx:ASPxCallback>
</asp:Content>

