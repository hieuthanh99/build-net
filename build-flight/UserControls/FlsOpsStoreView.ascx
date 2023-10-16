<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FlsOpsStoreView.ascx.cs" Inherits="UserControls_FlsOpsStoreView" %>

<dx:ASPxPageControl ID="ASPxPageControl1" runat="server" Width="100%" Height="100%" ClientInstanceName="ClientFlsOpsStoreView"
    CssClass="dxtcFixed dxtcAligned horizontal-center-aligned" TabAlign="Justify" ActiveTabIndex="0" Theme="Office365" EnableTabScrolling="true">
    <TabStyle Paddings-PaddingLeft="50px" Paddings-PaddingRight="50px" />
    <ContentStyle>
        <Paddings PaddingTop="10px" PaddingLeft="0px" PaddingRight="0px" />
    </ContentStyle>
    <ClientSideEvents ActiveTabChanged="RevCost.ClientFlsOpsStoreView_ActiveTabChanged" />
    <TabPages>
        <dx:TabPage Text="Flt Ops Store" Name="FltOpsStore">
            <ContentCollection>
                <dx:ContentControl ID="ContentControl1" runat="server">
                    <dx:ASPxGridView ID="FltOpsGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                        ClientInstanceName="ClientFltOpsGrid" Width="100%" KeyFieldName="FlsOpsStoreID"
                        OnCustomCallback="FltOpsGrid_CustomCallback">
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="Direction" VisibleIndex="1" Caption="Direction" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Area" VisibleIndex="2" Caption="Area" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="Flt_Date" VisibleIndex="3" Caption="Flt_Date" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="Flt_Month" VisibleIndex="4" Caption="Month" Width="30" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Flt_Year" VisibleIndex="5" Caption="Year" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Flt_No" VisibleIndex="6" Caption="Flt_No" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="AC_ID" VisibleIndex="7" Caption="AC_ID" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Ac_Reg" VisibleIndex="8" Caption="Ac_Reg" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="MTOW" VisibleIndex="9" Caption="MTOW" Width="90" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Sector" VisibleIndex="10" Caption="Sector" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ORI" VisibleIndex="11" Caption="ORI" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="DES" VisibleIndex="12" Caption="DES" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="CARRIER" VisibleIndex="13" Caption="CARRIER" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Flt_Type" VisibleIndex="14" Caption="Flt_Type" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Network" VisibleIndex="15" Caption="NW" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Fls" VisibleIndex="16" Caption="Fls" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Fls_321" VisibleIndex="17" Caption="Fls_321" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Item" VisibleIndex="18" Caption="Item" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Curr" VisibleIndex="19" Caption="Curr" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="RoeVN" VisibleIndex="20" Caption="RoeVN" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <%--<dx:GridViewDataTextColumn FieldName="RoeUS" VisibleIndex="20" Caption="RoeUSD" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>--%>
                            <dx:GridViewDataTextColumn FieldName="Quantity" VisibleIndex="21" Caption="Quantity" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataSpinEditColumn FieldName="Price" VisibleIndex="22" Caption="Price" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn FieldName="Cost" VisibleIndex="23" Caption="Cost" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                            </dx:GridViewDataSpinEditColumn>
                            <%--    <dx:GridViewDataSpinEditColumn FieldName="Rev" VisibleIndex="24" Caption="Rev" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn FieldName="Diff" VisibleIndex="25" Caption="Diff" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>--%>
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
                            <dx:ASPxSummaryItem FieldName="Fls" ShowInColumn="Fls" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                            <dx:ASPxSummaryItem FieldName="Cost" ShowInColumn="Cost" SummaryType="Sum" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                        </TotalSummary>
                    </dx:ASPxGridView>
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="FltOpsGrid"></dx:ASPxGridViewExporter>
                </dx:ContentControl>
            </ContentCollection>
        </dx:TabPage>
        <dx:TabPage Text="Store Allocate Log" Name="StoreAllocateLog">
            <ContentCollection>
                <dx:ContentControl ID="ContentControl2" runat="server">
                    <dx:ASPxGridView ID="StoreAllocateLogGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                        ClientInstanceName="ClientStoreAllocateLogGrid" Width="100%" KeyFieldName="LogID">
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="ErrMsg" VisibleIndex="1" Caption="ErrMsg" Width="350" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="FltMonth" VisibleIndex="2" Caption="FltMonth" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ACID" VisibleIndex="3" Caption="ACID" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Airport" VisibleIndex="4" Caption="Airport" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="FltType" VisibleIndex="5" Caption="FltType" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="RouteID" VisibleIndex="6" Caption="RouteID" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Driver" VisibleIndex="7" Caption="Driver" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Carrier" VisibleIndex="8" Caption="Carrier" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="RepID" VisibleIndex="9" Caption="RepID" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Sector" VisibleIndex="10" Caption="Sector" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="FltDate" VisibleIndex="11" Caption="FltDate" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                            </dx:GridViewDataDateColumn>
                        </Columns>
                        <Styles>
                            <AlternatingRow Enabled="true" />
                        </Styles>
                        <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                        <SettingsResizing ColumnResizeMode="Control" />
                        <Paddings Padding="0px" />
                        <Border BorderWidth="1px" />
                        <BorderBottom BorderWidth="1px" />
                        <SettingsBehavior AllowFocusedRow="True" />
                        <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                    </dx:ASPxGridView>
                </dx:ContentControl>
            </ContentCollection>
        </dx:TabPage>
        <dx:TabPage Text="Store Error List" Name="StoreErrorList">
            <ContentCollection>
                <dx:ContentControl ID="ContentControl3" runat="server">
                    <dx:ASPxGridView ID="StoreErrorListGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                        ClientInstanceName="ClientStoreErrorListGrid" Width="100%" KeyFieldName="StoreErrorID">
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="ErrCode" VisibleIndex="1" Caption="ErrCode" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ErrMessage" VisibleIndex="2" Caption="ErrMessage" Width="350" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Fatal" VisibleIndex="3" Caption="Fatal" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Ignore" VisibleIndex="4" Caption="Ignore" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="IgnoreBy" VisibleIndex="5" Caption="IgnoreBy" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="IgnoreDate" VisibleIndex="6" Caption="IgnoreDate" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="ErrorType" VisibleIndex="7" Caption="ErrorType" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="FltMonth" VisibleIndex="8" Caption="FltMonth" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <Styles>
                            <AlternatingRow Enabled="true" />
                        </Styles>
                        <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                        <SettingsResizing ColumnResizeMode="Control" />
                        <Paddings Padding="0px" />
                        <Border BorderWidth="1px" />
                        <BorderBottom BorderWidth="1px" />
                        <SettingsBehavior AllowFocusedRow="True" />
                        <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                    </dx:ASPxGridView>
                </dx:ContentControl>
            </ContentCollection>
        </dx:TabPage>
    </TabPages>
</dx:ASPxPageControl>
