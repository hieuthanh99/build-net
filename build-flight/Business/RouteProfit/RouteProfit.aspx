<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RouteProfit.aspx.cs" Inherits="Business_RouteProfit_RouteProfit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../../Scripts/RouteProfit.js"></script>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="RevCost.ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div class="title">
                            <asp:Literal ID="Literal1" runat="server" Text="Route Profit" />
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
                <PaneStyle>
                    <BorderBottom BorderWidth="0px" />
                    <BorderLeft BorderWidth="0px" />
                    <BorderRight BorderWidth="0px" />
                </PaneStyle>
                <Panes>
                    <dx:SplitterPane>
                        <Panes>
                            <dx:SplitterPane Size="250" ScrollBars="Auto">
                                <Panes>
                                    <dx:SplitterPane>
                                        <Panes>
                                            <dx:SplitterPane Size="40" Separator-Visible="False">
                                                <PaneStyle>
                                                    <BorderBottom BorderWidth="0px" />
                                                    <BorderLeft BorderWidth="0px" />
                                                    <BorderRight BorderWidth="0px" />
                                                </PaneStyle>
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
                                                        <dx:ASPxRadioButtonList ID="rdoVersionType" runat="server" RepeatDirection="Horizontal" ValueType="System.String">
                                                            <Border BorderWidth="0" BorderStyle="None" />
                                                            <Paddings Padding="0" />
                                                            <Items>
                                                                <dx:ListEditItem Value="P" Text="Planning" Selected="true" />
                                                                <dx:ListEditItem Value="E" Text="Estimate" />
                                                                <dx:ListEditItem Value="A" Text="Actual" />
                                                            </Items>
                                                            <ClientSideEvents ValueChanged="RevCost.ClientVersionType_ValueChanged" />
                                                        </dx:ASPxRadioButtonList>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                            </dx:SplitterPane>
                                            <dx:SplitterPane Name="Versions" Separator-Visible="False">
                                                <PaneStyle>
                                                    <BorderBottom BorderWidth="0px" />
                                                    <BorderLeft BorderWidth="0px" />
                                                    <BorderRight BorderWidth="0px" />
                                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                                </PaneStyle>
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
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
                                                            </Styles>
                                                            <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" />
                                                            <%--<SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="AreaCode;NameV;NameE" />--%>
                                                            <Paddings Padding="0px" />
                                                            <Border BorderWidth="1px" />
                                                            <BorderBottom BorderWidth="1px" />
                                                            <SettingsBehavior AllowFocusedRow="True" />
                                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientVersionGrid_FocusedRowChanged" />
                                                        </dx:ASPxGridView>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                                <PaneStyle>
                                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                                </PaneStyle>
                                            </dx:SplitterPane>
                                        </Panes>
                                    </dx:SplitterPane>

                                    <dx:SplitterPane Name="AllocateHis">
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxGridView ID="AllocateHisGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                    ClientInstanceName="ClientAllocateHisGrid" Width="100%" KeyFieldName="HisID">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="FileType" VisibleIndex="1" Caption="File Type" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="IssueDate" VisibleIndex="2" Caption="Issue Date" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="StartTime" VisibleIndex="3" Caption="Start Time" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="EndTime" VisibleIndex="4" Caption="End Time" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="5" Caption="Status" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Remark" VisibleIndex="6" Caption="Remark" Width="350" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <Styles>
                                                        <AlternatingRow Enabled="true" />
                                                    </Styles>
                                                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                                    <Paddings Padding="0px" />
                                                    <Border BorderWidth="1px" />
                                                    <BorderBottom BorderWidth="1px" />
                                                    <SettingsBehavior AllowFocusedRow="True" />
                                                    <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                                                </dx:ASPxGridView>
                                            </dx:SplitterContentControl>
                                        </ContentCollection>
                                        <PaneStyle>
                                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                        </PaneStyle>
                                    </dx:SplitterPane>
                                </Panes>
                                <PaneStyle Border-BorderWidth="0">
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                </PaneStyle>
                            </dx:SplitterPane>
                            <dx:SplitterPane Name="VersionCompany" ScrollBars="Auto">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="VersionCompanyGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientVersionCompanyGrid" Width="100%" KeyFieldName="VerCompanyID"
                                            OnCustomCallback="VersionCompanyGrid_CustomCallback">
                                            <Columns>
                                                <dx:GridViewCommandColumn VisibleIndex="0" Width="35" ShowSelectCheckbox="true" ShowClearFilterButton="true" SelectAllCheckboxMode="AllPages"></dx:GridViewCommandColumn>
                                              <%--  <dx:GridViewDataTextColumn FieldName="Seq" VisibleIndex="1" Caption="Seq" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>--%>
                                                <dx:GridViewDataTextColumn FieldName="VersionName" VisibleIndex="2" Caption="Version Name" Width="300" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ShortName" VisibleIndex="3" Caption="Short Name" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="NameV" VisibleIndex="4" Caption="Company Name" Width="300" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="CompanyType" VisibleIndex="5" Caption="Company Type" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="RtAllocatedSelection" VisibleIndex="6" Caption="Rt Allocate Selection" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                               <%-- <dx:GridViewDataTextColumn FieldName="RunStatus" VisibleIndex="7" Caption="Run Status" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>--%>
                                                <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="8" Caption="Status" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ReviewStatus" VisibleIndex="9" Caption="Review Status" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ApproveStatus" VisibleIndex="10" Caption="Approve Status" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <Styles>
                                                <AlternatingRow Enabled="true" />
                                            </Styles>
                                            <Settings ShowStatusBar="Visible" ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                            <Paddings Padding="0px" />
                                            <Border BorderWidth="1px" />
                                            <BorderBottom BorderWidth="1px" />
                                            <SettingsBehavior AllowFocusedRow="True" />
                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                                            <Templates>
                                                <StatusBar>
                                                    <dx:ASPxButton ID="btnRunAllocate" runat="server" Text="Run Allocate" RenderMode="Button" AutoPostBack="false" Image-Width="18" Image-Url="~/Content/images/if_gtk-execute_23314.png">
                                                    </dx:ASPxButton>
                                                    &nbsp;&nbsp;                                                                                                          
                                                    <dx:ASPxButton ID="btnStatistic" runat="server" Text="Statistic" RenderMode="Button" AutoPostBack="false" Image-Width="18" Image-Url="~/Content/images/IMG_0119.PNG">
                                                    </dx:ASPxButton>
                                                    &nbsp;&nbsp;                                                                                                          
                                                    <dx:ASPxButton ID="btnPrint" runat="server" Text="Print" RenderMode="Button" AutoPostBack="false" Image-Width="18" Image-Url="~/Content/images/if_simpline_5_2305642.png">
                                                    </dx:ASPxButton>
                                                    &nbsp;&nbsp;                                                                                                          
                                                    <dx:ASPxButton ID="btnViewErrors" runat="server" Text="View Errors" RenderMode="Button" AutoPostBack="false"  Image-Width="18" Image-Url="~/Content/images/error.png">
                                                    </dx:ASPxButton>
                                                    &nbsp;&nbsp;                                                                                                          
                                                    <dx:ASPxButton ID="btnViewDiff" runat="server" Text="View Diff" RenderMode="Button" AutoPostBack="false" Image-Width="18" Image-Url="~/Content/images/if_eye_1814102.png">
                                                    </dx:ASPxButton>
                                                  <%--  &nbsp;&nbsp;                                                                                                          
                                                    <dx:ASPxButton ID="btnViewDiffHQDB" runat="server" Text="View Diff HQDB" RenderMode="Button" AutoPostBack="false" Image-Width="18" Image-Url="~/Content/images/if_eye_1814102.png">
                                                    </dx:ASPxButton>--%>
                                                    &nbsp;&nbsp;                                                                                                          
                                                    <dx:ASPxButton ID="btnExport" runat="server" Text="Export Subaccount & Profit" RenderMode="Button" AutoPostBack="false" Image-Width="18" Image-Url="~/Content/images/action/export.png">
                                                    </dx:ASPxButton>
                                                </StatusBar>
                                            </Templates>
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
</asp:Content>

