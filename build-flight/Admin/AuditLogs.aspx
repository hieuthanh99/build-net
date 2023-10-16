<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AuditLogs.aspx.cs" Inherits="Admin_AuditLogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link href="../../Content/RevCost.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../Scripts/AuditLogs.js"></script>
    <script src="../../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../../signalr/hubs"></script>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="RevCost.ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="padding: 10px 10px 10px; font-size: 1.5em; font-weight: bold; margin: 0px 4px 4px; float: right;">
                            <asp:Literal ID="Literal2" runat="server" Text="Audit Logs" />
                        </div>
                        <div style="float: left; display: flex; flex-direction: row;">
                            <dx:ASPxDateEdit ID="FromDateEditor" runat="server" UseMaskBehavior="true" AllowNull="false" Width="120" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
                            &nbsp;&nbsp;
                            <dx:ASPxDateEdit ID="ToDateEditor" runat="server" UseMaskBehavior="true" AllowNull="false" Width="120" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
                            &nbsp;&nbsp;
                           <dx:ASPxComboBox ID="UserEditor" runat="server" AllowNull="true" ClearButton-DisplayMode="OnHover" NullText="--Select--" Width="200" OnInit="UserEditor_Init" ValueType="System.Int32"></dx:ASPxComboBox>
                            &nbsp;&nbsp;
                          <dx:ASPxButton ID="btnQuery" runat="server" ClientInstanceName="ClientQueryButton" Text="Query" AutoPostBack="false" UseSubmitBehavior="true">
                              <ClientSideEvents Click="RevCost.ClientQueryButton_Click" />
                          </dx:ASPxButton>
                            &nbsp;&nbsp;
                          
                            <dx:ASPxButton ID="btnExport" runat="server" ClientInstanceName="ClientExportButton" Text="Export Excel" UseSubmitBehavior="true" OnClick="btnExport_Click">
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
            <dx:SplitterPane Name="AuditLogs" ScrollBars="None" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <dx:ASPxGridView ID="AuditLogGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                            ClientInstanceName="ClientAuditLogGrid" Width="100%" KeyFieldName="Id"
                            OnCustomCallback="AuditLogGrid_CustomCallback">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="0" Caption="Id" Visible="false" SortOrder="Ascending" SortIndex="1" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="Date" VisibleIndex="1" Caption="Date" Width="170" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm:ss"></PropertiesDateEdit>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="TableName" VisibleIndex="2" Caption="Table Name" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>

                                <dx:GridViewDataComboBoxColumn FieldName="Action" VisibleIndex="5" Caption="Action" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesComboBox>
                                        <Items>
                                            <dx:ListEditItem Value="I" Text="Create New" />
                                            <dx:ListEditItem Value="M" Text="Edit" />
                                            <dx:ListEditItem Value="D" Text="Delete" />
                                        </Items>
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>

                                <dx:GridViewDataTextColumn FieldName="PrimaryKey" VisibleIndex="7" Caption="Primary Key" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="OldValue" VisibleIndex="8" Caption="Old Value" Width="400" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NewValue" VisibleIndex="9" Caption="New Value" Width="400" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="UserId" VisibleIndex="10" Caption="User" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesComboBox
                                        ValueType="System.Int32" DropDownStyle="DropDownList">
                                        <ClearButton DisplayMode="OnHover" />
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>

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
                            <Templates>
                                <DetailRow>
                                    <dx:ASPxLabel runat="server" Width="100%" Text='<%# "Old Value: " + Eval("OldValue") %>' Font-Bold="false" Wrap="True" />
                                    <br />
                                    <dx:ASPxLabel runat="server" Width="100%" Text='<%# "New Value: " + Eval("NewValue") %>' Font-Bold="false" Wrap="True" />
                                    <br />

                                </DetailRow>
                            </Templates>
                            <SettingsDetail ShowDetailRow="true" />
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
    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="AuditLogGrid"></dx:ASPxGridViewExporter>
</asp:Content>

