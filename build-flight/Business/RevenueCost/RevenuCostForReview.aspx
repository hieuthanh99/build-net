<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RevenuCostForReview.aspx.cs" Inherits="Business_RevenueCost_RevenuCostForReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link href="../../Content/RevCost.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../../Scripts/RevCostForReview.js"></script>
    <dx:ASPxSplitter ID="contentSplitter" runat="server" ClientInstanceName="ClientContentSplitter" Orientation="Vertical" Width="100%" Height="100%" ResizingMode="Live">
        <ClientSideEvents PaneResized="RevCost.ClientContentSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="30" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div class="powered-text">
                            <asp:Literal ID="Literal1" runat="server" Text="Revenue Cost for Review" />
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderStyle="None">
                </PaneStyle>
            </dx:SplitterPane>
            <dx:SplitterPane Separator-Visible="False">
                <Panes>
                    <dx:SplitterPane Size="450">
                        <Panes>
                            <dx:SplitterPane Size="200">
                                <Panes>
                                    <dx:SplitterPane>
                                        <Panes>
                                            <dx:SplitterPane Size="70">
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <dx:ASPxSpinEdit ID="VersionYearEditor" Caption="Year" MinValue="2000" MaxValue="9999" runat="server" Width="60px"></dx:ASPxSpinEdit>
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
                                                                    </dx:ASPxRadioButtonList>
                                                                </td>
                                                                <td rowspan="2" style="padding-left: 5px; vertical-align: middle;">
                                                                    <dx:ASPxButton ID="btnQuery" runat="server" Text="Query" AutoPostBack="false" UseSubmitBehavior="true">
                                                                        <ClientSideEvents Click="RevCost.ClientQuery_Click" />
                                                                    </dx:ASPxButton>
                                                                </td>
                                                            </tr>
                                                            <tr class="Separator">
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <dx:ASPxComboBox ID="cboCompanies" ClientInstanceName="ClientCompanies" Caption="Company" runat="server" ValueType="System.Int32" AutoResizeWithContainer="true" Width="100%" OnInit="cboCompanies_Init">
                                                                        <ClientSideEvents ValueChanged="RevCost.ClientCompanies_ValueChanged" />
                                                                    </dx:ASPxComboBox>
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
                                                            OnCustomCallback="VersionGrid_CustomCallback">
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
                                                                </TitlePanel>
                                                            </Templates>
                                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientVersionGrid_FocusedRowChanged"
                                                                BeginCallback="RevCost.ClientVersionGrid_BeginCallback"
                                                                EndCallback="RevCost.ClientVersionGrid_EndCallback" />
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
                            <dx:SplitterPane Name="VersionCompanyPane" Separator-Visible="False">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="VersionCompanyGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientVersionCompanyGrid" Width="100%" KeyFieldName="VerCompanyID"
                                            OnCustomCallback="VersionCompanyGrid_CustomCallback">
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="VersionName" VisibleIndex="1" Caption="Version Name" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="VersionNumber" VisibleIndex="2" Caption="Number" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="VerLevel" VisibleIndex="3" Caption="Level" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ReportType" VisibleIndex="4" Caption="Type" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
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
                                            <Settings ShowTitlePanel="true" ShowFooter="false" VerticalScrollBarMode="Visible" VerticalScrollableHeight="400" VerticalScrollBarStyle="Standard" />
                                            <Paddings Padding="0px" />
                                            <Border BorderWidth="1px" />
                                            <BorderBottom BorderWidth="1px" />
                                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
                                            <Templates>
                                                <TitlePanel>
                                                    <div style="float: left">
                                                        <dx:ASPxLabel runat="server" Font-Bold="true" Text="Version Company"></dx:ASPxLabel>
                                                    </div>
                                                </TitlePanel>
                                            </Templates>
                                            <ClientSideEvents BeginCallback="RevCost.ClientVersionCompanyGrid_BeginCallback"
                                                EndCallback="RevCost.ClientVersionCompanyGrid_EndCallback"
                                                FocusedRowChanged="RevCost.ClientVersionCompanyGrid_FocusedRowChanged" />
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
                    <dx:SplitterPane>
                        <Panes>
                            <dx:SplitterPane Name="CompanyStores" Separator-Visible="False">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="StoresGrid" runat="server" Width="100%" ClientInstanceName="ClientStoresGrid" EnableCallBacks="true"
                                            KeyFieldName="StoreID" Styles-Header-HorizontalAlign="Center"
                                            OnCustomCallback="StoresGrid_CustomCallback"
                                            OnHtmlRowPrepared="StoresGrid_HtmlRowPrepared">
                                            <Columns>
                                                <dx:GridViewDataColumn FieldName="Sorting" VisibleIndex="0" Caption="Sorting <br/>(1)" Width="80" FixedStyle="Left" HeaderStyle-Wrap="True"></dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="Description" VisibleIndex="1" Width="300" Caption="Description <br/>(2)" FixedStyle="Left" CellStyle-Wrap="True" HeaderStyle-Wrap="True"></dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="Calculation" VisibleIndex="2" Caption="Calc <br/>(3)" FixedStyle="Left" Width="50" HeaderStyle-Wrap="True"></dx:GridViewDataColumn>
                                                <dx:GridViewDataTextColumn FieldName="AmountAuto" VisibleIndex="4" Caption="Auto Amount <br/>(5)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Amount" VisibleIndex="5" Caption="Amount <br/>(6)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="InStandardsPer" VisibleIndex="6" UnboundType="Decimal" UnboundExpression="[InStandards]/[Amount]*100" Caption="%(8/6)<br/>(7)" Width="85" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="InStandards" VisibleIndex="7" Caption="Instandard <br/>(8)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="OutStandardsPer" VisibleIndex="8" UnboundType="Decimal" UnboundExpression="[OutStandards]/[Amount]*100" Caption="%(10/6)<br/>(9)" Width="85" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="OutStandards" VisibleIndex="9" Caption="Outstandard <br/>(10)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DecentralizationPer" VisibleIndex="10" UnboundType="Decimal" UnboundExpression="[Decentralization]/[Amount]*100" Caption="%(12/6)<br/>(11)" Width="85" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Decentralization" VisibleIndex="11" Caption="Decentralization <br/>(12)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Adjust" VisibleIndex="12" Caption="Adjust <br/>(13)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="InAdjustPer" VisibleIndex="13" UnboundType="Decimal" UnboundExpression="[InAdjust]/[Adjust]*100" Caption="%(15/13)<br/>(14)" Width="85" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="InAdjust" VisibleIndex="14" Caption="Instandard <br/>(15)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="OutAdjustPer" VisibleIndex="15" UnboundType="Decimal" UnboundExpression="[OutAdjust]/[Adjust]*100" Caption="%(17/13)<br/>(16)" Width="85" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="OutAdjust" VisibleIndex="16" Caption="Outstandard <br/>(17)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DecAdjustPer" VisibleIndex="17" UnboundType="Decimal" UnboundExpression="[DecAdjust]/[Adjust]*100" Caption="%(19/13)<br/>(18)" Width="85" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DecAdjust" VisibleIndex="18" Caption="Decentralization <br/>(19)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Saving" VisibleIndex="19" Caption="Saving <br/>(20)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="InSavingPer" VisibleIndex="20" UnboundType="Decimal" UnboundExpression="[InSaving]/[Saving]*100" Caption="%(22/20)<br/>(21)" Width="85" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="InSaving" VisibleIndex="21" Caption="Instandard <br/>(22)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="OutSavingPer" VisibleIndex="22" UnboundType="Decimal" UnboundExpression="[OutSaving]/[Saving]*100" Caption="%(24/20)<br/>(23)" Width="85" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="OutSaving" VisibleIndex="23" Caption="Outstandard <br/>(24)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DecSavingPer" VisibleIndex="24" UnboundType="Decimal" UnboundExpression="[DecSaving]/[Saving]*100" Caption="%(26/20)<br/>(25)" Width="85" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DecSaving" VisibleIndex="25" Caption="Decentralization <br/>(26)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="AfterSaving" VisibleIndex="26" Caption="After Saving <br/>(27)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="InAfterSavingPer" VisibleIndex="27" UnboundType="Decimal" UnboundExpression="[InAfterSaving]/[AfterSaving]*100" Caption="%(29/27)<br/>(28)" Width="85" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="InAfterSaving" VisibleIndex="28" Caption="Instandard <br/>(29)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="OutAfterSavingPer" VisibleIndex="29" UnboundType="Decimal" UnboundExpression="[OutAfterSaving]/[AfterSaving]*100" Caption="%(31/27)<br/>(30)" Width="85" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="OutAfterSaving" VisibleIndex="30" Caption="Outstandard <br/>(31)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DecAfterSavingPer" VisibleIndex="31" UnboundType="Decimal" UnboundExpression="[DecAfterSaving]/[AfterSaving]*100" Caption="%(33/27)<br/>(31)" Width="85" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DecAfterSaving" VisibleIndex="32" Caption="Decentralization <br/>(33)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <Styles>
                                                <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                            </Styles>
                                            <Settings ShowTitlePanel="true" VerticalScrollBarMode="Auto" VerticalScrollableHeight="500" HorizontalScrollBarMode="Auto" />
                                            <Paddings Padding="0px" />
                                            <Border BorderWidth="1px" />
                                            <BorderBottom BorderWidth="1px" />
                                            <SettingsBehavior AllowFocusedRow="true" AllowSort="false" />
                                            <SettingsResizing ColumnResizeMode="Control" />
                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
                                            <Border BorderStyle="None" />
                                            <Templates>
                                                <TitlePanel>
                                                    <div style="float: left">
                                                        <dx:ASPxLabel runat="server" Font-Bold="true" Text="Stores"></dx:ASPxLabel>
                                                    </div>
                                                </TitlePanel>
                                            </Templates>
                                        </dx:ASPxGridView>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                                <PaneStyle>
                                    <BorderTop BorderWidth="1px"></BorderTop>
                                    <BorderLeft BorderWidth="1px"></BorderLeft>
                                    <BorderRight BorderWidth="1px"></BorderRight>
                                    <BorderBottom BorderWidth="1px"></BorderBottom>
                                    <Paddings PaddingLeft="0" PaddingRight="1" PaddingBottom="0" PaddingTop="0" />
                                </PaneStyle>
                            </dx:SplitterPane>
                            <dx:SplitterPane Size="200">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                            </dx:SplitterPane>
                        </Panes>
                    </dx:SplitterPane>
                </Panes>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
    <dx:ASPxHiddenField ID="RevCostHiddenField" runat="server" ClientInstanceName="ClientRevCostHiddenField"></dx:ASPxHiddenField>
</asp:Content>

