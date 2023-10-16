<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RunSQLScript.aspx.cs" Inherits="Admin_RunSQLScript" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link href="../Content/RevCost.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../Scripts/PageModuleBase.js"></script>
    <script src="../Scripts/RunSQL.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../signalr/hubs"></script>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="RevCost.ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="300" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <dx:ASPxMemo ID="SqlEditor" runat="server" Width="100%" Height="230" Font-Bold="true" ClientInstanceName="ClientSqlEditor"></dx:ASPxMemo>
                        <br />
                        <dx:ASPxButton ID="RunSQL" runat="server" Text="Execute" AutoPostBack="false" UseSubmitBehavior="true">
                            <ClientSideEvents Click="RevCost.ExecuteSQL" />
                        </dx:ASPxButton>
                        &nbsp;&nbsp;
                          <dx:ASPxButton ID="btnExport" runat="server" Text="Export" AutoPostBack="true" UseSubmitBehavior="true" OnClick="btnExport_Click">
                          </dx:ASPxButton>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle>
                    <BorderTop BorderWidth="0px" />
                    <BorderLeft BorderWidth="0px" />
                    <BorderRight BorderWidth="0px" />
                </PaneStyle>
            </dx:SplitterPane>
            <dx:SplitterPane Name="DataResult" Separator-Visible="False">
                <PaneStyle>
                    <BorderBottom BorderWidth="0px" />
                    <BorderLeft BorderWidth="0px" />
                    <BorderRight BorderWidth="0px" />
                </PaneStyle>
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <dx:ASPxGridView ID="DataGrid" runat="server" AutoGenerateColumns="true" EnableCallBacks="true"
                            ClientInstanceName="ClientDataGrid" Width="100%" EnableViewState="false" EnableRowsCache="false"
                            OnCustomCallback="DataGrid_CustomCallback">
                            <Styles>
                                <AlternatingRow Enabled="true" />
                                <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                            </Styles>
                            <Settings ShowTitlePanel="true" ShowStatusBar="Hidden" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                            <Paddings Padding="0px" />
                            <Border BorderWidth="1px" />
                            <BorderBottom BorderWidth="1px" />
                            <SettingsResizing ColumnResizeMode="Control" Visualization="Live" />
                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                            <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                            <Templates>
                                <TitlePanel>
                                    <div style="float: left">
                                        <dx:ASPxLabel runat="server" Font-Bold="true" Text="Data result"></dx:ASPxLabel>
                                    </div>
                                </TitlePanel>
                            </Templates>
                        </dx:ASPxGridView>
                    </dx:SplitterContentControl>
                </ContentCollection>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="DataGrid"></dx:ASPxGridViewExporter>

</asp:Content>

