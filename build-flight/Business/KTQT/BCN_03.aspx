<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BCN_03.aspx.cs" Inherits="Business_KTQT_BCN_03" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../../Scripts/BCN.js"></script>
    <dx:ASPxSplitter ID="contentSplitter" runat="server" ClientInstanceName="ClientContentSplitter" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="RevCost.ClientContentSplitter_PaneResized" />
        <Border BorderStyle="None" />
        <Panes>
            <dx:SplitterPane Size="50">
                <Separator Visible="False"></Separator>
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="float: right;">
                            <div class="title">
                                <asp:Literal ID="Literal1" runat="server" Text="TỔNG HỢP BÁO CÁO NHANH" />
                            </div>
                        </div>
                        <div style="float: left;">
                            <dx:ASPxFormLayout runat="server" ID="FormParams" ColCount="7" Width="100%">
                                <Items>
                                    <dx:LayoutItem ShowCaption="False">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxButton ID="btnCreate" runat="server" ClientInstanceName="ClientCreateButton" Text="Create" AutoPostBack="false" UseSubmitBehavior="true" OnClick="btnCreate_Click">
                                                    <ClientSideEvents Click="RevCost.ClientQueryButton_Click" />
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Month">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxSpinEdit ID="QueryMonthEditor" runat="server" Width="50" MinValue="1" MaxValue="12"></dx:ASPxSpinEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Year">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxSpinEdit ID="QueryYearEditor" runat="server" Width="100"></dx:ASPxSpinEdit>
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
                                                <dx:ASPxButton ID="btnCalculate" runat="server" ClientInstanceName="ClientCalculateButton" Text="Calculate Data" UseSubmitBehavior="true" AutoPostBack="false">
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                </Items>
                            </dx:ASPxFormLayout>
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
            </dx:SplitterPane>
            <dx:SplitterPane Name="DataHistory">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <dx:ASPxGridView ID="DataGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                            ClientInstanceName="ClientDataGrid" Width="100%" KeyFieldName="ID"
                            OnCustomCallback="DataGrid_CustomCallback" OnBatchUpdate="DataGrid_BatchUpdate"
                            OnHtmlRowPrepared="DataGrid_HtmlRowPrepared">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="Sorting" VisibleIndex="1" Caption="STT" Width="70" FixedStyle="Left" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2" Caption="KẾT QUẢ SXKD" FixedStyle="Left" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewBandColumn Caption="Tháng 08" Name="Last_Year" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true">
                                    <Columns>
                                        <dx:GridViewDataSpinEditColumn FieldName="Act_Thi_Mon_Las_Yea" VisibleIndex="3" Caption="2017" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>                              
                                    </Columns>
                                </dx:GridViewBandColumn>
                                <dx:GridViewBandColumn Caption="Tháng 08/2018" Name="This_Year" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true">
                                    <Columns>
                                        <dx:GridViewDataSpinEditColumn FieldName="Pla_Thi_Mon" VisibleIndex="6" Caption="KH" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="Est_Thi_Mon" VisibleIndex="7" Caption="UTH" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                    </Columns>
                                </dx:GridViewBandColumn>
                                <dx:GridViewBandColumn Caption="So sánh" Name="Compare" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true">
                                    <Columns>
                                        <dx:GridViewDataSpinEditColumn FieldName="Com_Thi_Mon_Las_Yea" VisibleIndex="10" Caption="So với tháng báo cáo năm trước" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="Com_Acm_Las_Yea" VisibleIndex="9" Caption="So với lũy kế cùng kỳ năm trước" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                    </Columns>
                                </dx:GridViewBandColumn>
                            </Columns>
                            <Styles>
                                <AlternatingRow Enabled="true" />
                                <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                            </Styles>
                            <Settings ShowTitlePanel="true" ShowStatusBar="Visible" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                            <SettingsEditing Mode="Batch">
                                <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                            </SettingsEditing>
                            <Paddings Padding="0px" />
                            <Border BorderWidth="1px" />
                            <BorderBottom BorderWidth="1px" />
                            <SettingsResizing ColumnResizeMode="Control" />
                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                            <SettingsPager Visible="true" PageSize="50" Mode="ShowAllRecords" />
                            <Templates>
                                <StatusBar>
                                    <dx:ASPxButton ID="btnSaveBcnTotal" runat="server" Text="Save Changes" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                        <ClientSideEvents Click="RevCost.ClientSaveBcnTotal_Click" />
                                        <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                    </dx:ASPxButton>
                                </StatusBar>
                                <TitlePanel>
                                    <div style="float: left">
                                        <dx:ASPxLabel runat="server" Font-Bold="true" Text="Data"></dx:ASPxLabel>
                                    </div>
                                </TitlePanel>
                            </Templates>
                        </dx:ASPxGridView>
                        <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="DataGrid"></dx:ASPxGridViewExporter>
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
</asp:Content>

