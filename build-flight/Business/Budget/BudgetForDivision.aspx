<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BudgetForDivision.aspx.cs" Inherits="Business_Budget_BudgetForDivision" %>

<%@ Register Assembly="DevExpress.XtraReports.v20.2.Web.WebForms, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link href="../../Content/RevCost.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../../Scripts/BudgetForDivision.js"></script>

    <dx:ASPxPanel runat="server" ID="MainPanel" ClientInstanceName="ClientMainPanel" CssClass="main-container" EnableCallbackAnimation="true" Width="100%">
        <PanelCollection>
            <dx:PanelContent>
                <dx:ASPxSplitter ID="contentSplitter" runat="server" ClientInstanceName="contentSplitter" Orientation="Vertical" Width="100%" Height="100%" ResizingMode="Live">
                    <ClientSideEvents PaneResized="RevCost.ClientContentSplitter_PaneResized" />
                    <Panes>
                        <dx:SplitterPane Separator-Visible="false">
                            <Panes>
                                <dx:SplitterPane Size="25%" Separator-Visible="False">
                                    <Panes>
                                        <dx:SplitterPane Size="70" Separator-Visible="False">
                                            <ContentCollection>
                                                <dx:SplitterContentControl>
                                                    <div>
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <%--<td>
                                                        <dx:ASPxLabel ID="lblYear" Text="Year" runat="server"></dx:ASPxLabel>
                                                    </td>--%>
                                                                <td style="padding-left: 5px">
                                                                    <%--<dx:ASPxTextBox ID="txtYear" Width="50" runat="server" AutoPostBack="false"></dx:ASPxTextBox>--%>
                                                                    <dx:ASPxSpinEdit ID="VersionYearEditor" Caption="Year" MinValue="2000" MaxValue="9999" runat="server" Width="60px"></dx:ASPxSpinEdit>
                                                                </td>
                                                                <td>
                                                                    <dx:ASPxRadioButtonList ID="rdoVersionType" runat="server" RepeatDirection="Horizontal" ValueType="System.String">
                                                                        <Border BorderWidth="0" BorderStyle="None" />
                                                                        <Paddings Padding="5" />
                                                                        <Items>
                                                                            <dx:ListEditItem Value="P" Text="Planning" Selected="true" />
                                                                            <dx:ListEditItem Value="A" Text="Actual" />
                                                                        </Items>
                                                                    </dx:ASPxRadioButtonList>
                                                                </td>
                                                                <td style="text-align: right">
                                                                    <dx:ASPxButton ID="btnView" runat="server" Text="View" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true">
                                                                        <ClientSideEvents Click="RevCost.ClientView_Click" />
                                                                    </dx:ASPxButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div>
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td>
                                                                    <dx:ASPxLabel ID="lblDivision" Text="Division" runat="server"></dx:ASPxLabel>
                                                                </td>
                                                                <td style="padding-left: 5px">
                                                                    <dx:ASPxGridLookup ID="gluDivision" runat="server" KeyFieldName="CompanyID" ClientInstanceName="gluDivision" TextFormatString="{0} - {1}"
                                                                        SelectionMode="Single" DataSourceID="DivisionDatasource" Width="100%">
                                                                        <ClientSideEvents ValueChanged="RevCost.ClientDivisionFocusedRowChanged" />
                                                                        <Border BorderWidth="1px" />
                                                                        <Columns>
                                                                            <dx:GridViewDataColumn FieldName="ShortName" Caption="Code">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Settings AutoFilterCondition="Contains" />
                                                                            </dx:GridViewDataColumn>
                                                                            <dx:GridViewDataColumn FieldName="NameV" Caption="Name">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <Settings AutoFilterCondition="Contains" />
                                                                            </dx:GridViewDataColumn>
                                                                        </Columns>
                                                                        <GridViewProperties>
                                                                            <Settings ShowFilterRow="true" />
                                                                            <Settings ShowColumnHeaders="true" />
                                                                            <SettingsPager Mode="ShowPager" />
                                                                            <SettingsBehavior EnableRowHotTrack="True" />
                                                                        </GridViewProperties>
                                                                        <ValidationSettings ErrorDisplayMode="None" ValidateOnLeave="true">
                                                                            <RequiredField IsRequired="true" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxGridLookup>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </dx:SplitterContentControl>
                                            </ContentCollection>
                                        </dx:SplitterPane>
                                        <dx:SplitterPane Name="pnPlanning" Size="130" Separator-Visible="False">
                                            <ContentCollection>
                                                <dx:SplitterContentControl>
                                                    <dx:ASPxGridView ID="grdVersion" runat="server" Width="100%" ClientInstanceName="grdVersion" EnableCallBacks="true" AutoGenerateColumns="False"
                                                        KeyFieldName="VersionID" Styles-Header-HorizontalAlign="Center" Settings-VerticalScrollBarMode="Visible" Caption="Plannings"
                                                        OnCustomCallback="grdVersion_CustomCallback">
                                                        <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                                        <SettingsResizing ColumnResizeMode="Control" Visualization="Live" />
                                                        <SettingsBehavior AllowFocusedRow="true" AllowSort="false" />
                                                        <ClientSideEvents FocusedRowChanged="RevCost.ClientVersion_FocusedRowChanged" EndCallback="RevCost.grdVersion_EndCallback" />
                                                        <Columns>
                                                            <dx:GridViewDataColumn FieldName="VersionName" Width="40%" VisibleIndex="0" Caption="Name"></dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn FieldName="Description" Width="40%" VisibleIndex="1" Caption="Description"></dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn FieldName="Status" Width="20%" VisibleIndex="2" Caption="Status" CellStyle-HorizontalAlign="Center"></dx:GridViewDataColumn>
                                                        </Columns>
                                                    </dx:ASPxGridView>
                                                </dx:SplitterContentControl>
                                            </ContentCollection>
                                        </dx:SplitterPane>
                                        <dx:SplitterPane Name="pnVersion" Size="130" Separator-Visible="False">
                                            <ContentCollection>
                                                <dx:SplitterContentControl>
                                                    <dx:ASPxGridView ID="grdVersionCompany" runat="server" Width="100%" ClientInstanceName="grdVersionCompany" EnableCallBacks="true"
                                                        KeyFieldName="VerCompanyID" Styles-Header-HorizontalAlign="Center" Settings-VerticalScrollBarMode="Visible" Caption="Versions"
                                                        OnCustomCallback="grdVersionCompany_CustomCallback">
                                                        <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                                        <SettingsResizing ColumnResizeMode="Control" Visualization="Live" />
                                                        <SettingsBehavior AllowFocusedRow="true" AllowSort="false" />
                                                        <ClientSideEvents FocusedRowChanged="RevCost.ClientVersionCompany_FocusedRowChanged" EndCallback="RevCost.ClientVersionCompany_EndCallback"
                                                            CustomButtonClick="RevCost.ClientVersionCompany_General" />
                                                        <Columns>
                                                            <dx:GridViewDataColumn FieldName="VersionName" VisibleIndex="0" Caption="Ver Name" Width="60%"></dx:GridViewDataColumn>
                                                            <dx:GridViewDataComboBoxColumn FieldName="VerLevel" VisibleIndex="1" Caption="Level" Width="20%">
                                                                <PropertiesComboBox DropDownStyle="DropDownList">
                                                                    <Items>
                                                                        <dx:ListEditItem Value="1" Text="HDTV" />
                                                                        <dx:ListEditItem Value="2" Text="TGD" />
                                                                        <dx:ListEditItem Value="3" Text="PTGD Khoi" />
                                                                        <dx:ListEditItem Value="4" Text="VPCN/Don Vi" />
                                                                        <dx:ListEditItem Value="5" Text="Don vi" />
                                                                        <dx:ListEditItem Value="6" Text="VPDD" />
                                                                    </Items>
                                                                </PropertiesComboBox>
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataColumn FieldName="Status" VisibleIndex="2" Caption="Status" Width="20%"></dx:GridViewDataColumn>
                                                            <dx:GridViewCommandColumn VisibleIndex="3" CellStyle-Font-Size="XX-Small" Width="10%" CellStyle-Font-Bold="true">
                                                                <CustomButtons>
                                                                    <dx:GridViewCommandColumnCustomButton Text="=>" ID="btnExecute"></dx:GridViewCommandColumnCustomButton>
                                                                </CustomButtons>
                                                            </dx:GridViewCommandColumn>
                                                        </Columns>
                                                    </dx:ASPxGridView>
                                                </dx:SplitterContentControl>
                                            </ContentCollection>
                                        </dx:SplitterPane>
                                        <dx:SplitterPane Name="pnTree" Separator-Visible="False">
                                            <ContentCollection>
                                                <dx:SplitterContentControl>
                                                    <dx:ASPxTreeList ID="tltVersion" ClientInstanceName="tltVersion" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        OnCustomCallback="tltVersion_CustomCallback" KeyFieldName="VerCompanyID" ParentFieldName="VerCompanyParentID"
                                                        Settings-HorizontalScrollBarMode="Visible" Settings-VerticalScrollBarMode="Visible">
                                                        <ClientSideEvents NodeDblClick="RevCost.ClientTreeVersion_NodeDbClick" />
                                                        <SettingsBehavior AllowSort="false" AllowFocusedNode="true" />
                                                        <Columns>
                                                            <dx:TreeListDataColumn FieldName="Name" Width="1000px" Caption="#"></dx:TreeListDataColumn>
                                                        </Columns>
                                                    </dx:ASPxTreeList>
                                                </dx:SplitterContentControl>
                                            </ContentCollection>
                                        </dx:SplitterPane>
                                    </Panes>
                                </dx:SplitterPane>
                                <dx:SplitterPane Name="pnStore" Separator-Visible="False">
                                    <ContentCollection>
                                        <dx:SplitterContentControl>
                                            <dx:ASPxGridView ID="grdStore" runat="server" Width="100%" ClientInstanceName="grdStore" EnableCallBacks="true"
                                                KeyFieldName="" Styles-Header-HorizontalAlign="Center" Settings-VerticalScrollBarMode="Visible" Settings-HorizontalScrollBarMode="Visible"
                                                OnCustomCallback="grdStore_CustomCallback" OnHtmlRowPrepared="StoresGrid_HtmlRowPrepared">
                                                <SettingsResizing ColumnResizeMode="Control" Visualization="Live" />
                                                <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                                <SettingsBehavior AllowFocusedRow="true" AllowSort="false" />
                                                <Columns>
                                                    <dx:GridViewDataColumn FieldName="SORTING" Width="100" VisibleIndex="0" Caption="Sorting<br/>(1)" HeaderStyle-Wrap="True" FixedStyle="Left">
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn FieldName="DESCRIPTION" Width="350" VisibleIndex="1" Caption="Description<br/>(2)" HeaderStyle-Wrap="True" FixedStyle="Left">
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataTextColumn FieldName="REV_COST" Width="120" VisibleIndex="2" Caption="Rev Cost<br/>(3)" HeaderStyle-Wrap="True">
                                                        <PropertiesTextEdit DisplayFormatString="N0"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="AMOUNT" Width="120" VisibleIndex="3" Caption="Amount<br/>(4)" HeaderStyle-Wrap="True">
                                                        <PropertiesTextEdit DisplayFormatString="N0"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="BEGIN_BALANCE" Width="120" VisibleIndex="4" Caption="Begin Blance<br/>(5)" HeaderStyle-Wrap="True">
                                                        <PropertiesTextEdit DisplayFormatString="N0"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="END_BALANCE" Width="120" VisibleIndex="5" Caption="End Balance<br/>(6)" HeaderStyle-Wrap="True">
                                                        <PropertiesTextEdit DisplayFormatString="N0"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="VAT" Width="120" VisibleIndex="6" Caption="Vat<br/>(7)" HeaderStyle-Wrap="True">
                                                        <PropertiesTextEdit DisplayFormatString="N0"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="BUDGET_CHANGE" Width="120" VisibleIndex="7" Caption="Budget Change<br/>(8)" HeaderStyle-Wrap="True">
                                                        <PropertiesTextEdit DisplayFormatString="N0"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="BUDGET" Width="120" VisibleIndex="8" Caption="Budget<br/>(9=4+5+7+8)" HeaderStyle-Wrap="True">
                                                        <PropertiesTextEdit DisplayFormatString="N0"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Width="120" VisibleIndex="9" Caption="Total<br/>(10=6+9)" HeaderStyle-Wrap="True">
                                                        <DataItemTemplate>
                                                            <%#Convert.ToDecimal(Eval("END_BALANCE")) + Convert.ToDecimal(Eval("BUDGET")) %>
                                                        </DataItemTemplate>
                                                        <PropertiesTextEdit DisplayFormatString="N0"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                            </dx:ASPxGridView>
                                        </dx:SplitterContentControl>
                                    </ContentCollection>
                                </dx:SplitterPane>
                            </Panes>
                        </dx:SplitterPane>
                        <dx:SplitterPane Size="45" Separator-Visible="False">
                            <ContentCollection>
                                <dx:SplitterContentControl>
                                    <div>
                                        <table>
                                            <tr>
                                                <td>
                                                    <dx:ASPxButton ID="btnPrint" ClientInstanceName="ClientbtnPrint" runat="server" Text="Report" RenderMode="Button" AutoPostBack="false">
                                                        <ClientSideEvents Click="RevCost.ClientbtnPrint_Click" />
                                                    </dx:ASPxButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </dx:SplitterContentControl>
                            </ContentCollection>
                        </dx:SplitterPane>
                    </Panes>
                </dx:ASPxSplitter>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>

    <dx:ASPxPopupControl ID="ReportPopup" runat="server" Maximized="true" AllowDragging="True" HeaderText="Báo cáo"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientReportPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" HeaderStyle-HorizontalAlign="Left" HeaderText="" Collapsed="false" ShowCollapseButton="true" Width="100%" Height="100%">
                    <ContentPaddings Padding="0" />
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <PanelCollection>
                        <dx:PanelContent>
                            <dx:ASPxSplitter ID="ASPxSplitter1" runat="server" Orientation="Horizontal" Width="100%" Height="100%" SeparatorVisible="false">
                                <Panes>
                                    <dx:SplitterPane Size="295" ScrollBars="Auto">
                                        <PaneStyle>
                                            <BorderTop BorderWidth="0" />
                                            <Paddings PaddingBottom="0" PaddingRight="0" PaddingTop="0" PaddingLeft="0" />
                                        </PaneStyle>
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxFormLayout ID="ParameterForm" runat="server" Width="100%" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientParameterForm"
                                                    AlignItemCaptionsInAllGroups="true">
                                                    <Items>
                                                        <dx:LayoutGroup Caption="Danh sách báo cáo">
                                                            <Items>
                                                                <dx:LayoutItem ShowCaption="False">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxRadioButtonList ID="rdReport" runat="server" ValueType="System.String" ClientInstanceName="rdReport">
                                                                                <Items>
                                                                                    <dx:ListEditItem Value="1" Text="Báo cáo kế hoạch ngân sách phân kỳ" Selected="true" />
                                                                                    <dx:ListEditItem Value="2" Text="Báo cáo kế hoạch ngân sách" />
                                                                                </Items>
                                                                                <Border BorderStyle="None" />
                                                                                <ClientSideEvents SelectedIndexChanged="RevCost.rdReport_SelectedIndexChanged" Init="RevCost.rdReport_Init" />
                                                                            </dx:ASPxRadioButtonList>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                            </Items>
                                                        </dx:LayoutGroup>

                                                        <dx:LayoutGroup Caption="Giai đoạn">
                                                            <Items>
                                                                <dx:LayoutItem ShowCaption="False">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxDateEdit ID="dedFromDate" runat="server" ClientInstanceName="dedFromDate" NullText="Từ ngày">
                                                                            </dx:ASPxDateEdit>
                                                                            <dx:ASPxDateEdit ID="dedToDate" runat="server" ClientInstanceName="dedToDate" NullText="Đến ngày">
                                                                            </dx:ASPxDateEdit>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                            </Items>
                                                        </dx:LayoutGroup>

                                                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>

                                                        <dx:LayoutItem Caption="">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxButton ID="btnPrintReport" runat="server" Text="Xem báo cáo" AutoPostBack="false" ClientInstanceName="ClientPrintReportButton" UseSubmitBehavior="true">
                                                                        <ClientSideEvents Click="RevCost.btnPrintReport_Click" />
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
                                            </dx:SplitterContentControl>
                                        </ContentCollection>
                                    </dx:SplitterPane>
                                    <dx:SplitterPane ScrollBars="Auto">
                                        <PaneStyle>
                                            <BorderTop BorderWidth="0" />
                                            <Paddings PaddingBottom="0" PaddingRight="0" PaddingTop="0" PaddingLeft="0" />
                                        </PaneStyle>
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                
                                                 <dx:ASPxWebDocumentViewer ID="ReportViewer" runat="server"  Width="100%" Height="100%"></dx:ASPxWebDocumentViewer>
                                               
                                              
                                            </dx:SplitterContentControl>
                                        </ContentCollection>
                                    </dx:SplitterPane>
                                </Panes>
                            </dx:ASPxSplitter>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxHiddenField ID="RevCostHiddenField" runat="server" ClientInstanceName="ClientRevCostHiddenField"></dx:ASPxHiddenField>

    <dx:EntityServerModeDataSource ID="DivisionDatasource" runat="server" OnSelecting="DivisionDatasource_Selecting" />
</asp:Content>

