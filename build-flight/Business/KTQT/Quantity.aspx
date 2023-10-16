<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Quantity.aspx.cs" Inherits="Business_KTQT_Quantity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link href="../../Content/RevCost.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../../Scripts/KTQTQuantity.js"></script>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="RevCost.ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div class="title">
                            <asp:Literal ID="Literal1" runat="server" Text="Quantity" />
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
                            <dx:SplitterPane Size="70" Separator-Visible="False">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxFormLayout runat="server" ColCount="7">
                                            <Items>
                                                <dx:LayoutItem Caption="Airport">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxComboBox runat="server" ID="AirportsEditor" Width="100" OnInit="AirportsEditor_Init">
                                                            </dx:ASPxComboBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="From">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxDateEdit ID="FromDateEditor" runat="server" Width="100" DisplayFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="To">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxDateEdit ID="ToDateEditor" runat="server" Width="100" DisplayFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
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
                                                            <dx:ASPxButton ID="btnSyncVMS" runat="server" ClientInstanceName="ClientSyncVMSButton" Text="Sync VMS Quantity" UseSubmitBehavior="true" AutoPostBack="false">
                                                                <ClientSideEvents Click="RevCost.ClientSyncVMSButton_Click" />
                                                            </dx:ASPxButton>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem ShowCaption="False">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxButton ID="btnAllocateOthRev" runat="server" ClientInstanceName="ClientAllocateOthRevButton" Text="Allocate Revenue(Not Flight)" UseSubmitBehavior="true" AutoPostBack="false">
                                                                <ClientSideEvents Click="RevCost.ClientAllocateOthRevButton_Click" />
                                                            </dx:ASPxButton>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>

                                                <dx:LayoutItem ShowCaption="False" ColSpan="7">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="" Font-Bold="true" ForeColor="Red" ClientInstanceName="ClientMissAircraft"></dx:ASPxLabel>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                            </Items>
                                        </dx:ASPxFormLayout>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                            </dx:SplitterPane>
                            <dx:SplitterPane Name="FltOps" ScrollBars="Auto" Separator-Visible="False">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="FltOpsGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientFltOpsGrid" Width="100%" KeyFieldName="ID"
                                            OnCustomCallback="FltOpsGrid_CustomCallback"
                                            OnHtmlDataCellPrepared="FltOpsGrid_HtmlDataCellPrepared">
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="Direction" VisibleIndex="1" Caption="Direction" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Area" VisibleIndex="2" Caption="Area" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Flt_No" VisibleIndex="3" Caption="Flt No" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataDateColumn FieldName="Flt_Date" VisibleIndex="4" Caption="Flt Date" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                                </dx:GridViewDataDateColumn>
                                                <dx:GridViewDataTextColumn FieldName="AC_ID" VisibleIndex="5" Caption="Aircraft" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Ac_Reg" VisibleIndex="6" Caption="Ac Reg" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Sector" VisibleIndex="7" Caption="Sector" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ORI" VisibleIndex="8" Caption="ORI" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DES" VisibleIndex="9" Caption="DES" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="CARRIER" VisibleIndex="10" Caption="Opt" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Flt_Type" VisibleIndex="11" Caption="Flt Type" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ArrCarryCode" VisibleIndex="12" Caption="Arr Carry" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DepCarryCode" VisibleIndex="13" Caption="Dep Carry" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Network" VisibleIndex="14" Caption="Network" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Fls" VisibleIndex="15" Caption="Fls" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                    <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Fls_321" VisibleIndex="16" Caption="Fls 321" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataTextColumn FieldName="AC_Group" VisibleIndex="17" Caption="AC Group" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Bag_pcs" VisibleIndex="18" Caption="Bag pcs" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Bag_weight" VisibleIndex="19" Caption="Bag weight" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Cargo" VisibleIndex="20" Caption="Cargo" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Mail" VisibleIndex="21" Caption="Mail" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Pax_F" VisibleIndex="22" Caption="Pax F" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Pax_C" VisibleIndex="23" Caption="Pax C" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Pax_Y" VisibleIndex="24" Caption="Pax Y" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Pax_Inf" VisibleIndex="25" Caption="Pax Inf" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Pax_Vip" VisibleIndex="26" Caption="Pax Vip" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Pax_Wchr" VisibleIndex="27" Caption="Pax Wchr" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Pax_JumpSeat" VisibleIndex="28" Caption="Pax JumpSeat" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Pax_UM" VisibleIndex="29" Caption="Pax_UM" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Pax_CHD" VisibleIndex="30" Caption="Pax_CHD" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Pax_WB" VisibleIndex="31" Caption="Pax_WB" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Pax_MC" VisibleIndex="32" Caption="Pax_MC" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Pax_KIOS" VisibleIndex="33" Caption="Pax_KIOS" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="BASIC_REV" VisibleIndex="34" Caption="BASIC REV" Width="170" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="SUR_REV" VisibleIndex="35" Caption="SUR REV" Width="170" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="RR_REV" VisibleIndex="36" Caption="RR REV" Width="170" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="OTH_REV" VisibleIndex="37" Caption="OTH REV" Width="170" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="ALLOCATE_OTH_REV" VisibleIndex="38" Caption="REV (Not Flight)" Width="170" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="DISCOUNT" VisibleIndex="39" Caption="DISCOUNT" Width="170" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="REV" VisibleIndex="40" Caption="REV" Width="170" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
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
                                            <SettingsPager Visible="true" PageSize="30" Mode="EndlessPaging" />
                                            <TotalSummary>
                                                <dx:ASPxSummaryItem FieldName="Fls" SummaryType="Sum" ShowInColumn="Fls" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                                <dx:ASPxSummaryItem FieldName="BASIC_REV" SummaryType="Sum" ShowInColumn="BASIC_REV" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="SUR_REV" SummaryType="Sum" ShowInColumn="SUR_REV" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="RR_REV" SummaryType="Sum" ShowInColumn="RR_REV" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="OTH_REV" SummaryType="Sum" ShowInColumn="OTH_REV" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="ALLOCATE_OTH_REV" SummaryType="Sum" ShowInColumn="ALLOCATE_OTH_REV" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="DISCOUNT" SummaryType="Sum" ShowInColumn="DISCOUNT" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="REV" SummaryType="Sum" ShowInColumn="REV" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                            </TotalSummary>
                                            <ClientSideEvents EndCallback="RevCost.ClientFltOpsGrid_EndCallback" />
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
    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="FltOpsGrid" OnRenderBrick="GridViewExporter_RenderBrick"></dx:ASPxGridViewExporter>

    <dx:ASPxPopupControl ID="ParamsPopup" runat="server" Width="150" Height="100" AllowDragging="True" HeaderText="Sync VMS Quantity" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientParamsPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="ParamsForm" runat="server" ColCount="4" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                    AlignItemCaptionsInAllGroups="true" Width="100%" OptionalMark="">
                    <Items>
                        <dx:LayoutItem Caption="From Date">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit runat="server" ID="SyncFromDateEditor" Width="100" ClientInstanceName="ClientSyncFromDateEditor" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="To Date">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit runat="server" ID="SyncToDateEditor" Width="100" ClientInstanceName="ClientSyncToDateEditor" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:EmptyLayoutItem ColSpan="2"></dx:EmptyLayoutItem>
                        <dx:LayoutItem Caption="Data" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBoxList ID="SyncDataListBox" runat="server" ValueType="System.String" RepeatColumns="2" Width="400">
                                        <Items>
                                            <dx:ListEditItem Value="INV" Text="Sync Invoices" Selected="true" />
                                            <dx:ListEditItem Value="VOU" Text="Sync Vouchers" Selected="true" />
                                            <dx:ListEditItem Value="FLI" Text="Sync Flight Departure" Selected="true" />
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

    <dx:ASPxPopupControl ID="AllocateOthRevPopup" runat="server" Width="150" Height="100" AllowDragging="True" HeaderText="Run Allocate Revenue(Not Flight)" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientAllocateOthRevPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="AllocateParamsForm" runat="server" ColCount="2" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="From Date">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit runat="server" ID="dtpFromDateEditor" Width="100" ClientInstanceName="ClientFromDateEditor" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="To Date">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit runat="server" ID="dtpToDateEditor" Width="100" ClientInstanceName="ClientToDateEditor" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxDateEdit>
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
                <ClientSideEvents Click="function(s, e) {{ ClientAllocateOthRevPopup.Hide(); }}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApplyAllocate" runat="server" Text="Allocate" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientApplyAllocate_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>
</asp:Content>

