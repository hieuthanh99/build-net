<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ActualQuantity.aspx.cs" Inherits="Business_RevenueCost_ActualQuantity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link href="../../Content/RevCost.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../../Scripts/KTQTQuantity.js"></script>
    <script src="../../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../../signalr/hubs"></script>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="RevCost.ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="padding: 10px 10px 10px; font-size: 1.5em; font-weight: bold; margin: 0px 4px 4px; float: right;">
                            <asp:Literal ID="Literal1" runat="server" Text="Quantity" />
                        </div>
                        <div style="float: left; display: flex; flex-direction: row;">
                            <dx:ASPxSpinEdit runat="server" ID="FilterYearEditor" Width="80" ClientEnabled="true" Caption="Version">
                                <ClientSideEvents ValueChanged="RevCost.ClientFilterYearEditor_ValueChanged" />
                            </dx:ASPxSpinEdit>
                            &nbsp;&nbsp;
                            <dx:ASPxComboBox runat="server" ID="VersionEditor" Width="200" ClientInstanceName="ClientVersionEditor" ClientEnabled="true" OnCallback="VersionEditor_Callback">
                                <ClientSideEvents ValueChanged="RevCost.ClientQueryButton_Click" />
                            </dx:ASPxComboBox>
                            &nbsp;&nbsp;
                            <dx:ASPxButton ID="btnQuery" runat="server" Text="Query" AutoPostBack="false" UseSubmitBehavior="true">
                                <ClientSideEvents Click="RevCost.ClientQueryButton_Click" />
                            </dx:ASPxButton>
                            &nbsp;&nbsp;
                            <dx:ASPxButton ID="btnSyncData" runat="server" Text="Đồng bộ PMS" AutoPostBack="false" UseSubmitBehavior="true">
                                <ClientSideEvents Click="RevCost.ClientSyncDataButton_Click" />
                            </dx:ASPxButton>
                            &nbsp;&nbsp;
                            <dx:ASPxButton ID="btnExport" runat="server" Text="Export Excel" UseSubmitBehavior="true" OnClick="btnExport_Click">
                            </dx:ASPxButton>
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle>
                    <BorderTop BorderWidth="0px" />
                    <BorderLeft BorderWidth="0px" />
                    <BorderRight BorderWidth="0px" />
                </PaneStyle>
            </dx:SplitterPane>

            <dx:SplitterPane Name="FltOps" ScrollBars="None" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <dx:ASPxGridView ID="FltOpsGrid" runat="server" AutoGenerateColumns="true" EnableCallBacks="true"
                            ClientInstanceName="ClientFltOpsGrid" Width="100%" KeyFieldName="ID"
                            OnCustomCallback="FltOpsGrid_CustomCallback">
                            <Columns>
                                <%--  <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="0" Caption="Id" Visible="false" SortOrder="Ascending" SortIndex="1" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Direction" VisibleIndex="1" Caption="Direction" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Area" VisibleIndex="2" Caption="Area" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                             
                                                <dx:GridViewDataDateColumn FieldName="Flt_Date" VisibleIndex="4" Caption="Flt Date" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                                </dx:GridViewDataDateColumn>
                                                <dx:GridViewDataTextColumn FieldName="AC_ID" VisibleIndex="5" Caption="Aircraft" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                                                <dx:GridViewDataTextColumn FieldName="Fleet_Type" VisibleIndex="12" Caption="Fleet Type" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Network" VisibleIndex="13" Caption="Network" Width="65" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="AC_Group" VisibleIndex="14" Caption="AC Group" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                  </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Fls" VisibleIndex="15" Caption="Fls" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                                                <dx:GridViewDataSpinEditColumn FieldName="PAX_Y" VisibleIndex="23" Caption="Pax Y" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="YQ" VisibleIndex="24" Caption="YQ" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                 <dx:GridViewDataSpinEditColumn FieldName="PAX_REV" VisibleIndex="25" Caption="PAX REV" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="REVUNIT" VisibleIndex="26" Caption="REVUNIT" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="REV" VisibleIndex="27" Caption="REV" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="RPK" VisibleIndex="28" Caption="RPK" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="ASK" VisibleIndex="29" Caption="ASK" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="LF_C" VisibleIndex="30" Caption="LF_C" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="PAX_C" VisibleIndex="31" Caption="PAX_C" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="REV_C" VisibleIndex="32" Caption="C_REV" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="REV_Y" VisibleIndex="33" Caption="Y_REV" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="REV_NO_YQ" VisibleIndex="34" Caption="REV_NO_YQ" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="REV_YQ" VisibleIndex="35" Caption="REV_YQ" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="PAXPOS" VisibleIndex="36" Caption="PAXPOS" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="CARGO_LF" VisibleIndex="37" Caption="CARGO_LF" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="CARGO_CAP" VisibleIndex="38" Caption="CARGO_CAP" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="CARGO_UNIT" VisibleIndex="39" Caption="CARGO_UNIT_PRICE" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="CARGO_REV" VisibleIndex="40" Caption="CARGO_REV" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="ANCI_REVUNIT" VisibleIndex="41" Caption="ANCI_REVUNIT" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="ANCI_REV" VisibleIndex="42" Caption="ANCI_REV" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="FBS" VisibleIndex="43" Caption="FBS" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N3"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="FUEL" VisibleIndex="44" Caption="FUEL" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N3"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="BH_NORM" VisibleIndex="45" Caption="BH_NORM" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N3"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="PILOT_NORM" VisibleIndex="46" Caption="PILOT_NORM" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N3"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="PILOT" VisibleIndex="47" Caption="PILOT" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N3"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="CREW_NORM" VisibleIndex="48" Caption="CREW_NORM" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N3"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="CREW" VisibleIndex="49" Caption="CREW" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N3"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="PAX_G1" VisibleIndex="50" Caption="PAX_G1" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="PAX_G2" VisibleIndex="51" Caption="PAX_G2" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="PAX_G3" VisibleIndex="53" Caption="PAX_G3" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="PAX_G4" VisibleIndex="53" Caption="PAX_G4" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="PAX_G5" VisibleIndex="54" Caption="PAX_G5" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>--%>
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
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                </PaneStyle>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="FltOpsGrid"></dx:ASPxGridViewExporter>

    <dx:ASPxPopupControl ID="ParamsPopup" runat="server" Width="150" Height="100" AllowDragging="True" HeaderText="Sync VMS Quantity" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientParamsPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="ParamsForm" runat="server" ColCount="4" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                    AlignItemCaptionsInAllGroups="true" Width="100%" OptionalMark="">
                    <Items>
                        <dx:LayoutItem Caption="Month">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="MonthEditor" Width="50" ClientInstanceName="ClientMonthEditor" MinValue="1" MaxValue="12">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Year">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="YearEditor" Width="70" ClientInstanceName="ClientYearEditor" MinValue="2010" MaxValue="9999">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:EmptyLayoutItem ColSpan="2"></dx:EmptyLayoutItem>
                        <dx:LayoutItem Caption="Data" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBoxList ID="SyncDataListBox" runat="server" ValueType="System.String" RepeatColumns="2" Width="400">
                                        <Items>
                                            <dx:ListEditItem Value="FLI" Text="Sync Flight Departure" Selected="true" />
                                            <dx:ListEditItem Value="INV" Text="Sync Invoices" Selected="true" />
                                            <dx:ListEditItem Value="VOU" Text="Sync Vouchers" Selected="true" />
                                            <dx:ListEditItem Value="CGH" Text="Sync Code Ground Handling" />
                                            <dx:ListEditItem Value="SER" Text="Sync Services" />
                                            <dx:ListEditItem Value="XRA" Text="Sync Exchange Rate" />
                                        </Items>
                                    </dx:ASPxCheckBoxList>
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" runat="server" Text="Sync Data" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientSyncVMSQuantity_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>
</asp:Content>

