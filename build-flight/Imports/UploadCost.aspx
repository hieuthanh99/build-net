<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UploadCost.aspx.cs" Inherits="Imports_UploadCost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../Scripts/PageModuleBase.js"></script>
    <script src="../Scripts/UploadCost.js"></script>
    <dx:ASPxSplitter ID="contentSplitter" runat="server" ClientInstanceName="ClientContentSplitter" Orientation="Vertical" Width="100%" Height="100%" ResizingMode="Live">
        <ClientSideEvents PaneResized="RevCost.ClientContentSplitter_PaneResized" />
        <Border BorderStyle="None" />
        <Panes>
            <dx:SplitterPane Size="260">
                <Panes>
                    <dx:SplitterPane>
                        <Panes>
                            <dx:SplitterPane Size="50">
                                <Separator Visible="False"></Separator>
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <div style="float: right;">
                                            <div class="title">
                                                <asp:Literal ID="Literal1" runat="server" Text="IMPORT DATA" />
                                            </div>
                                        </div>
                                        <div style="float: left;">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="padding-left: 5px;">
                                                        <dx:ASPxComboBox ID="cboFileType" runat="server" DropDownStyle="DropDownList" ClientInstanceName="ClientFileType" Width="200px" ValueType="System.String" Caption="File Type" OnInit="cboFileType_Init">
                                                            <ClientSideEvents ValueChanged="RevCost.ClientFileType_ValueChanged" />
                                                        </dx:ASPxComboBox>
                                                    </td>
                                                    <td style="padding-left: 5px;">
                                                        <dx:ASPxButton ID="btnDownloadTemplate" runat="server" Text="Template" AutoPostBack="false">
                                                            <ClientSideEvents Click="function(s, e){ ClientParamsPopup.Show(); }" />
                                                        </dx:ASPxButton>
                                                    </td>
                                                    <td style="padding-left: 5px;">
                                                        <dx:ASPxUploadControl ID="UploadControl" runat="server" ClientInstanceName="ClientUploadControl" ShowProgressPanel="true" NullText="Browse file here"
                                                            Width="280px" FileUploadMode="OnPageLoad" UploadMode="Advanced" OnFilesUploadComplete="UploadControl_FilesUploadComplete" BrowseButton-Text="Duyệt file">
                                                            <ProgressBarSettings ShowPosition="false" DisplayMode="Percentage" />
                                                            <ClientSideEvents FileUploadStart="RevCost.FileUploadStart"
                                                                UploadingProgressChanged="RevCost.UploadingProgressChanged"
                                                                FilesUploadComplete="RevCost.FilesUploadComplete" />
                                                            <ValidationSettings MaxFileSize="10000000" AllowedFileExtensions=".xlsx" ShowErrors="true"></ValidationSettings>
                                                        </dx:ASPxUploadControl>
                                                    </td>
                                                    <td style="padding-left: 5px;">
                                                        <dx:ASPxButton ID="btnUploadFile" runat="server" Text="Upload File" AutoPostBack="false">
                                                            <ClientSideEvents Click="RevCost.ClientFilesUploadButton_Click" />
                                                        </dx:ASPxButton>

                                                        <%--<dx:ASPxButton ID="btnValidateData" runat="server" Text="Validate Data" AutoPostBack="false"></dx:ASPxButton>--%>
                                                        <%--<dx:ASPxButton ID="btnApply" runat="server" Text="Apply To Version" AutoPostBack="false">
                                                            <ClientSideEvents Click="RevCost.ClientApply_Click" />
                                                        </dx:ASPxButton>--%>
                                                        <dx:ASPxButton ID="btnShowVersion" runat="server" ClientInstanceName="ClientShowVersionButton" Text="Apply To Version" UseSubmitBehavior="true" AutoPostBack="false">
                                                            <ClientSideEvents Click="RevCost.ClientShowVersionButton_Click" />
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                            </dx:SplitterPane>
                            <dx:SplitterPane Name="FileHistory">
                                <Separator Visible="False"></Separator>
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="FileHistoryGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientFileHistoryGrid" Width="100%" KeyFieldName="HistoryID"
                                            OnCustomCallback="FileHistoryGrid_CustomCallback">
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="HistoryID" VisibleIndex="1" Caption="ID" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataCheckColumn FieldName="StatusDL" VisibleIndex="2" Caption="UL?" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataCheckColumn>
                                                <dx:GridViewDataCheckColumn FieldName="StatusTR" VisibleIndex="3" Caption="TR?" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataCheckColumn>
                                                <dx:GridViewDataTextColumn FieldName="FileName" VisibleIndex="4" Caption="File Name" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="SizeOfFile" VisibleIndex="5" Caption="File Size" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N0"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="SumRC" VisibleIndex="6" Caption="Rows" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N0"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="SumCol" VisibleIndex="6" Caption="Columns" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N0"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataDateColumn FieldName="IssueDate" VisibleIndex="7" Caption="Issue Date" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                                </dx:GridViewDataDateColumn>
                                                <dx:GridViewDataTextColumn FieldName="Remark" VisibleIndex="8" Caption="Remark" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Note" VisibleIndex="9" Caption="Note" Width="350" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                                            <SettingsResizing ColumnResizeMode="NextColumn" />
                                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                                            <Templates>
                                                <TitlePanel>
                                                    <div style="float: left">
                                                        <dx:ASPxLabel runat="server" Font-Bold="true" Text="History"></dx:ASPxLabel>
                                                    </div>
                                                </TitlePanel>
                                            </Templates>
                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientFileHistoryGrid_FocusedRowChanged"
                                                BeginCallback="RevCost.ClientFileHistoryGrid_BeginCallback"
                                                EndCallback="RevCost.ClientFileHistoryGrid_EndCallback" />
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
                        <dx:ASPxGridView ID="DataHistoryGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                            ClientInstanceName="ClientDataHistoryGrid" Width="100%" KeyFieldName="DataHistoryID"
                            OnCustomCallback="DataHistoryGrid_CustomCallback">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="Seq" VisibleIndex="0" Caption="Seq" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT0" VisibleIndex="1" Caption="Col 1" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT1" VisibleIndex="2" Caption="Col 2" Width="250" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT2" VisibleIndex="3" Caption="Col 3" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT3" VisibleIndex="4" Caption="Col 4" Width="350" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT4" VisibleIndex="5" Caption="Col 5" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT5" VisibleIndex="6" Caption="Col 6" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT6" VisibleIndex="7" Caption="Col 7" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT7" VisibleIndex="8" Caption="Col 8" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT8" VisibleIndex="9" Caption="Col 9" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT9" VisibleIndex="10" Caption="Col 10" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT10" VisibleIndex="11" Caption="Col 11" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT11" VisibleIndex="12" Caption="Col 12" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT12" VisibleIndex="13" Caption="Col 13" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT13" VisibleIndex="14" Caption="Col 14" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT14" VisibleIndex="15" Caption="Col 15" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT15" VisibleIndex="16" Caption="Col 16" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT16" VisibleIndex="17" Caption="Col 17" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT17" VisibleIndex="18" Caption="Col 18" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT18" VisibleIndex="19" Caption="Col 19" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT19" VisibleIndex="20" Caption="Col 20" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT20" VisibleIndex="21" Caption="Col 21" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT21" VisibleIndex="22" Caption="Col 22" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT22" VisibleIndex="23" Caption="Col 23" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT23" VisibleIndex="24" Caption="Col 24" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT24" VisibleIndex="25" Caption="Col 25" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT25" VisibleIndex="26" Caption="Col 26" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT26" VisibleIndex="27" Caption="Col 27" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT27" VisibleIndex="28" Caption="Col 28" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT28" VisibleIndex="29" Caption="Col 29" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT29" VisibleIndex="30" Caption="Col 30" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT30" VisibleIndex="31" Caption="Col 31" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT31" VisibleIndex="32" Caption="Col 32" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT32" VisibleIndex="33" Caption="Col 33" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT33" VisibleIndex="34" Caption="Col 34" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT34" VisibleIndex="35" Caption="Col 35" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT35" VisibleIndex="36" Caption="Col 36" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT36" VisibleIndex="25" Caption="Col 37" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT37" VisibleIndex="26" Caption="Col 38" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT38" VisibleIndex="27" Caption="Col 39" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT39" VisibleIndex="28" Caption="Col 40" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT40" VisibleIndex="29" Caption="Col 41" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT41" VisibleIndex="30" Caption="Col 42" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT42" VisibleIndex="31" Caption="Col 43" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT43" VisibleIndex="32" Caption="Col 44" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT44" VisibleIndex="33" Caption="Col 45" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT45" VisibleIndex="34" Caption="Col 46" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT46" VisibleIndex="35" Caption="Col 47" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT47" VisibleIndex="36" Caption="Col 48" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT48" VisibleIndex="11" Caption="Col 11" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT49" VisibleIndex="12" Caption="Col 12" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT50" VisibleIndex="13" Caption="Col 13" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT51" VisibleIndex="14" Caption="Col 14" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT52" VisibleIndex="15" Caption="Col 15" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT53" VisibleIndex="16" Caption="Col 16" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT54" VisibleIndex="17" Caption="Col 17" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT55" VisibleIndex="18" Caption="Col 18" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT56" VisibleIndex="19" Caption="Col 19" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT57" VisibleIndex="20" Caption="Col 20" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT58" VisibleIndex="21" Caption="Col 21" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT59" VisibleIndex="22" Caption="Col 22" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT60" VisibleIndex="23" Caption="Col 23" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT61" VisibleIndex="24" Caption="Col 24" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT62" VisibleIndex="25" Caption="Col 25" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT63" VisibleIndex="26" Caption="Col 26" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT64" VisibleIndex="27" Caption="Col 27" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT65" VisibleIndex="28" Caption="Col 28" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT66" VisibleIndex="29" Caption="Col 29" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT67" VisibleIndex="30" Caption="Col 30" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT68" VisibleIndex="31" Caption="Col 31" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT69" VisibleIndex="32" Caption="Col 32" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT70" VisibleIndex="33" Caption="Col 33" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT71" VisibleIndex="34" Caption="Col 34" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT72" VisibleIndex="35" Caption="Col 35" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT73" VisibleIndex="36" Caption="Col 36" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT74" VisibleIndex="25" Caption="Col 37" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT75" VisibleIndex="26" Caption="Col 38" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT76" VisibleIndex="27" Caption="Col 39" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT77" VisibleIndex="28" Caption="Col 40" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT78" VisibleIndex="29" Caption="Col 41" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT79" VisibleIndex="30" Caption="Col 42" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT80" VisibleIndex="31" Caption="Col 43" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT81" VisibleIndex="32" Caption="Col 44" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT82" VisibleIndex="33" Caption="Col 45" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT83" VisibleIndex="34" Caption="Col 46" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT84" VisibleIndex="35" Caption="Col 47" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ATT85" VisibleIndex="36" Caption="Col 48" Visible="false" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
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
                            <SettingsResizing ColumnResizeMode="Control" />
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

    <dx:ASPxPopupControl ID="PopupSelectExcelSheet" runat="server" ClientInstanceName="ClientPopupSelectExcelSheet"
        Modal="True" CloseAction="None" Width="400px" PopupHorizontalAlign="WindowCenter" ShowFooter="true"
        PopupVerticalAlign="WindowCenter" AllowDragging="True" PopupAnimationType="None"
        HeaderText="Select Sheet" ShowCloseButton="False">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                <dx:ASPxListBox ID="SheetListBox" runat="server" ClientInstanceName="ClientSheetListBox" Width="100%" ValueType="System.String" SelectionMode="Single" OnCallback="SheetListBox_Callback">
                    <ClientSideEvents EndCallback="RevCost.ClientSheetListBox_EndCallback" />
                </dx:ASPxListBox>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ClientSideEvents Shown="RevCost.ClientPopupSelectExcelSheet_Shown" />
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Close" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientPopupSelectExcelSheet.Hide();}}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnUpload" runat="server" Text="Upload Data" AutoPostBack="false" ClientInstanceName="ClientUploadDataButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientUploadDataButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="PopupProgressingPanel" runat="server" ClientInstanceName="PopupProgressingPanel"
        Modal="True" CloseAction="None" Width="400px" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter" AllowDragging="True" PopupAnimationType="None"
        HeaderText="Uploading Info" ShowCloseButton="False" ShowPageScrollbarWhenModal="true">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 100%;">
                            <dx:ASPxProgressBar ID="pbProgressing" ClientInstanceName="pbProgressing" runat="server"
                                Width="100%">
                            </dx:ASPxProgressBar>
                        </td>
                    </tr>
                </table>
                <dx:ASPxPanel ID="pnlProgressingInfo" ClientInstanceName="pnlProgressingInfo" runat="server"
                    Width="100%">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent2" runat="server">
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

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

    <dx:ASPxPopupControl ID="ParamsPopup" runat="server" Width="150" Height="100" AllowDragging="True" HeaderText="Download Template" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientParamsPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="ParamsForm" runat="server" ColCount="4" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                    AlignItemCaptionsInAllGroups="true" Width="100%" OptionalMark="">
                    <Items>

                        <dx:LayoutItem Caption="Area">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cboArea1" runat="server" ClientInstanceName="ClientAreaCode" Width="120px" OnInit="cboArea1_Init">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" runat="server" Text="Download" AutoPostBack="false">
                 <ClientSideEvents Click="RevCost.ClientDownloadTemplateButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>
</asp:Content>

