<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RevenueCostForDivision.aspx.cs" Inherits="Business_RevenueCost_RevenueCostForDivision" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link href="../../Content/RevCost.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../../Scripts/RevCostForDivision.js"></script>
    <script src="../../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../../signalr/hubs"></script>
    <dx:ASPxSplitter ID="contentSplitter" runat="server" ClientInstanceName="contentSplitter" Orientation="Vertical" Width="100%" Height="100%" ResizingMode="Live">
        <ClientSideEvents PaneResized="RevCost.ClientContentSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane>
                <Panes>
                    <dx:SplitterPane Size="450px">
                        <Panes>
                            <dx:SplitterPane Size="70">
                                <ContentCollection>
                                    <dx:SplitterContentControl Style="padding: 0px">
                                        <div style="padding: 0px">
                                            <table style="width: 100%; padding: 0px">
                                                <tr>
                                                    <%--<td>
                                                        <dx:ASPxLabel ID="lblYear" Text="Year" runat="server"></dx:ASPxLabel>
                                                    </td>--%>
                                                    <td style="padding-left: 5px">
                                                        <%--<dx:ASPxTextBox ID="txtYear" Width="50" runat="server" AutoPostBack="false"></dx:ASPxTextBox>--%>
                                                        <dx:ASPxSpinEdit ID="txtYear" Caption="Year" MinValue="2000" MaxValue="9999" runat="server" Width="60px"></dx:ASPxSpinEdit>
                                                    </td>
                                                    <td>
                                                        <dx:ASPxRadioButtonList ID="rdoVersionType" runat="server" RepeatDirection="Horizontal" ValueType="System.String">
                                                            <Border BorderWidth="0" BorderStyle="None" />
                                                            <Paddings Padding="5" />
                                                            <Items>
                                                                <dx:ListEditItem Value="P" Text="Planning" Selected="true" />
                                                                <dx:ListEditItem Value="E" Text="Estimate" />
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
                                                    <%--         <td>
                                                        <dx:ASPxLabel ID="lblDivision" Text="Division" runat="server"></dx:ASPxLabel>
                                                    </td>--%>
                                                    <td style="padding-left: 5px">
                                                        <dx:ASPxGridLookup ID="gluDivision" runat="server" KeyFieldName="CompanyID" ClientInstanceName="gluDivision" TextFormatString="{0} - {1}"
                                                            SelectionMode="Single" DataSourceID="DivisionDatasource" Width="100%" Caption="Division" CaptionSettings-RequiredMarkDisplayMode="Auto">
                                                            <ClientSideEvents ValueChanged="RevCost.ClientDivisionFocusedRowChanged" />
                                                            <Border BorderWidth="1px" />
                                                            <Columns>
                                                                <dx:GridViewDataColumn FieldName="ShortName" Caption="Code" Width="100">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <Settings AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataColumn>
                                                                <dx:GridViewDataColumn FieldName="NameV" Caption="Name" Width="300">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <Settings AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataColumn>
                                                            </Columns>
                                                            <GridViewProperties>
                                                                <Settings ShowFilterRow="true" ShowColumnHeaders="false" VerticalScrollBarMode="Visible" VerticalScrollableHeight="300" VerticalScrollBarStyle="Standard" />
                                                                <SettingsPager Mode="ShowAllRecords" />
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
                            <dx:SplitterPane Name="pnPlanning" Size="130" PaneStyle-Paddings-Padding="1">
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
                            <dx:SplitterPane Name="pnVersion" Size="130" PaneStyle-Paddings-Padding="1">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="grdVersionCompany" runat="server" Width="100%" ClientInstanceName="grdVersionCompany" EnableCallBacks="true"
                                            KeyFieldName="VerCompanyID" Styles-Header-HorizontalAlign="Center" Settings-VerticalScrollBarMode="Visible" Caption="Versions"
                                            OnCustomCallback="grdVersionCompany_CustomCallback">
                                            <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                            <SettingsResizing ColumnResizeMode="Control" Visualization="Live" />
                                            <SettingsBehavior AllowFocusedRow="true" AllowSort="false" />
                                            <ClientSideEvents EndCallback="RevCost.ClientVersionCompany_EndCallback"
                                                CustomButtonClick="RevCost.ClientVersionCompany_General"
                                                FocusedRowChanged="RevCost.ClientVersionCompany_FocusedRowChanged" />

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
                            <dx:SplitterPane Name="pnTree" PaneStyle-Paddings-Padding="1">
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
                    <dx:SplitterPane Name="pnStore" PaneStyle-Paddings-Padding="1">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxTreeList ID="grdStore" runat="server" Width="100%" ClientInstanceName="grdStore" EnableCallbacks="true"
                                    KeyFieldName="SUBACCOUNT_ID" ParentFieldName="SUBACCOUNT_PARENT_ID" Styles-Header-HorizontalAlign="Center" Settings-VerticalScrollBarMode="Visible" Settings-HorizontalScrollBarMode="Visible"
                                    OnCustomCallback="grdStore_CustomCallback" OnHtmlRowPrepared="StoresGrid_HtmlRowPrepared">
                                    <SettingsResizing ColumnResizeMode="Control" Visualization="Live" />
                                    <SettingsPager Mode="ShowAllNodes"></SettingsPager>
                                    <SettingsBehavior AllowFocusedNode="true" AllowSort="false" AutoExpandAllNodes="true" />
                                    <Columns>

                                        <dx:TreeListDataColumn FieldName="DESCRIPTION" Width="300" VisibleIndex="0" Caption="Description" HeaderStyle-Wrap="True">
                                        </dx:TreeListDataColumn>
                                        <dx:TreeListDataColumn FieldName="SORTING" Width="80" VisibleIndex="1" Caption="Sorting" HeaderStyle-Wrap="True">
                                        </dx:TreeListDataColumn>
                                        <dx:TreeListDataColumn FieldName="CALCULATION" Width="60" VisibleIndex="1" Caption="Type" HeaderStyle-Wrap="True">
                                        </dx:TreeListDataColumn>
                                        <dx:TreeListSpinEditColumn FieldName="AMOUNT" Width="150" VisibleIndex="3" Caption="Final Amount" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:TreeListSpinEditColumn>
                                        <dx:TreeListSpinEditColumn FieldName="M1" Width="120" VisibleIndex="3" Caption="Jan" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:TreeListSpinEditColumn>
                                        <dx:TreeListSpinEditColumn FieldName="M2" Width="120" VisibleIndex="3" Caption="Feb" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:TreeListSpinEditColumn>
                                        <dx:TreeListSpinEditColumn FieldName="M3" Width="120" VisibleIndex="3" Caption="Mar" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:TreeListSpinEditColumn>
                                        <dx:TreeListSpinEditColumn FieldName="M4" Width="120" VisibleIndex="3" Caption="Apr" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:TreeListSpinEditColumn>
                                        <dx:TreeListSpinEditColumn FieldName="M5" Width="120" VisibleIndex="3" Caption="May" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:TreeListSpinEditColumn>
                                        <dx:TreeListSpinEditColumn FieldName="M6" Width="120" VisibleIndex="3" Caption="Jun" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:TreeListSpinEditColumn>
                                        <dx:TreeListSpinEditColumn FieldName="M7" Width="120" VisibleIndex="3" Caption="Jul" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:TreeListSpinEditColumn>
                                        <dx:TreeListSpinEditColumn FieldName="M8" Width="120" VisibleIndex="3" Caption="Aug" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:TreeListSpinEditColumn>
                                        <dx:TreeListSpinEditColumn FieldName="M9" Width="120" VisibleIndex="3" Caption="Sep" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:TreeListSpinEditColumn>
                                        <dx:TreeListSpinEditColumn FieldName="M10" Width="120" VisibleIndex="3" Caption="Oct" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:TreeListSpinEditColumn>
                                        <dx:TreeListSpinEditColumn FieldName="M11" Width="120" VisibleIndex="3" Caption="Nov" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:TreeListSpinEditColumn>
                                        <dx:TreeListSpinEditColumn FieldName="M12" Width="120" VisibleIndex="3" Caption="Dec" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:TreeListSpinEditColumn>

                                        <dx:TreeListDataColumn Caption="" VisibleIndex="9" Width="10%"></dx:TreeListDataColumn>
                                    </Columns>
                                </dx:ASPxTreeList>
                                <%--Export Excel--%>
                                <dx:ASPxTreeListExporter ID="GridViewExporter" runat="server" TreeListID="grdStore"></dx:ASPxTreeListExporter>
                                <%--<dx:ASPxTreeListExporter ID="ASPxTreeListExporter1" runat="server" TreeListID="grdStore"></dx:ASPxTreeListExporter>--%>
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
                                        <dx:ASPxButton ID="btnReport" runat="server" Text="Report" RenderMode="Button" AutoPostBack="false">
                                            <ClientSideEvents Click="RevCost.ClientbtnPrintStoreButton_Click" />
                                        </dx:ASPxButton>
                                        <dx:ASPxButton ID="btnExport" runat="server" Text="Export Excel" RenderMode="Button" AutoPostBack="false" OnClick="btnExport_Click">
                                            <Image Url="../../Content/images/action/export.png" Height="16"></Image>
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
    <dx:EntityServerModeDataSource ID="DivisionDatasource" runat="server" OnSelecting="DivisionDatasource_Selecting" />
</asp:Content>

