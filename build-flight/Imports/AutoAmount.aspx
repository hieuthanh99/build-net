<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AutoAmount.aspx.cs" Inherits="Imports_AutoAmount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link href="../Content/RevCost.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../Scripts/PageModuleBase.js"></script>
    <script src="../Scripts/AutoAmount.js"></script>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="RevCost.ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="padding: 10px 10px 10px; font-size: 1.5em; font-weight: bold; margin: 0px 4px 4px; float: left;">
                            <asp:Literal ID="Literal1" runat="server" Text="Auto Amount" />
                        </div>
                        <div style="float: right;">
                            <dx:ASPxButton ID="btnRefresh" runat="server" Text="Refresh" RenderMode="Button" AutoPostBack="false">
                                <Image Url="../Content/images/refresh.png" Height="16"></Image>
                                <ClientSideEvents Click="RevCost.ClientRefreshButtonClick" />
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Create Job" RenderMode="Button" AutoPostBack="false">
                                <Image Url="../Content/images/SpinEditPlus.png"></Image>
                                <ClientSideEvents Click="function(s, e) {{ 
                                    var d = new Date(); 
                                    d.setMinutes(d.getMinutes() + 30);
                                    ClientExecuteAtEditor.SetValue(d); 
                                    ClientEditPopup.Show(); }}" />
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

                                    <dx:SplitterPane Size="600" Name="Versions" Separator-Visible="False">
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
                                                    <SettingsResizing ColumnResizeMode="Control" />
                                                    <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                                                    <ClientSideEvents FocusedRowChanged="RevCost.ClientVersionGrid_FocusedRowChanged" />
                                                </dx:ASPxGridView>
                                            </dx:SplitterContentControl>
                                        </ContentCollection>
                                        <PaneStyle>
                                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                        </PaneStyle>
                                    </dx:SplitterPane>

                                    <dx:SplitterPane Name="Jobs">
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxGridView ID="JobGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                    ClientInstanceName="ClientJobGrid" Width="100%" KeyFieldName="Id" OnCustomCallback="JobGrid_CustomCallback">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="JobType" VisibleIndex="1" Caption="Job Type" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataDateColumn FieldName="IssueDate" VisibleIndex="2" Caption="Issue Date" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm"></PropertiesDateEdit>
                                                        </dx:GridViewDataDateColumn>
                                                        <dx:GridViewDataDateColumn FieldName="StartTime" VisibleIndex="3" Caption="Start Time" Width="140" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm"></PropertiesDateEdit>
                                                        </dx:GridViewDataDateColumn>
                                                        <dx:GridViewDataDateColumn FieldName="EndTime" VisibleIndex="4" Caption="End Time" Width="140" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm"></PropertiesDateEdit>
                                                        </dx:GridViewDataDateColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="5" Caption="Status" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Remark" VisibleIndex="6" Caption="Remark" Width="350" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <Styles>
                                                        <AlternatingRow Enabled="true" />
                                                    </Styles>
                                                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                                    <%--<SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="AreaCode;NameV;NameE" />--%>
                                                    <Paddings Padding="0px" />
                                                    <Border BorderWidth="1px" />
                                                    <BorderBottom BorderWidth="1px" />
                                                    <SettingsBehavior AllowFocusedRow="True" />
                                                    <SettingsResizing ColumnResizeMode="Control" />
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
                            <%-- <dx:SplitterPane Name="VersionCompany" ScrollBars="Auto">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="VersionCompanyGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientVersionCompanyGrid" Width="100%" KeyFieldName="VerCompanyID">
                                            <Columns>
                                                <dx:GridViewCommandColumn VisibleIndex="0" Width="35" ShowSelectCheckbox="true" ShowClearFilterButton="true" SelectAllCheckboxMode="AllPages"></dx:GridViewCommandColumn>
                                                <dx:GridViewDataTextColumn FieldName="Seq" VisibleIndex="1" Caption="Seq" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="VersionName" VisibleIndex="2" Caption="Version Name" Width="300" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ShortName" VisibleIndex="3" Caption="Short Name" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="CompanyName" VisibleIndex="4" Caption="Company Name" Width="300" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="CompanyType" VisibleIndex="5" Caption="Company Type" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="RtAllocatedSelection" VisibleIndex="6" Caption="Rt Allocate Selection" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="RunStatus" VisibleIndex="7" Caption="Run Status" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
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
                                                    <dx:ASPxButton ID="btnRunAllocate" runat="server" Text="Run Allocate" RenderMode="Button" AutoPostBack="false">
                                                    </dx:ASPxButton>
                                                    &nbsp;&nbsp;                                                                                                          
                                                    <dx:ASPxButton ID="btnStatistic" runat="server" Text="Statistic" RenderMode="Button" AutoPostBack="false">
                                                    </dx:ASPxButton>
                                                    &nbsp;&nbsp;                                                                                                          
                                                    <dx:ASPxButton ID="btnPrint" runat="server" Text="Print" RenderMode="Button" AutoPostBack="false">
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
                            </dx:SplitterPane>--%>
                        </Panes>
                    </dx:SplitterPane>
                </Panes>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>

    <dx:ASPxPopupControl ID="EditPopup" runat="server" Width="250" Height="150" AllowDragging="True" HeaderText="Create Job" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientEditPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditForm" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>

                        <dx:LayoutItem Caption="Job Type">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="JobTypeEditor" Width="250" ClientInstanceName="ClientJobTypeEditor">
                                        <Items>
                                            <dx:ListEditItem Value="AUTOITEM" Text="Auto Item" Selected="true" />
                                            <dx:ListEditItem Value="ALLOCATE" Text="Cost allocation" />
                                        </Items>
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Execute At">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit runat="server" ID="ExecuteAtEditor" Width="250" DisplayFormatString="dd/MM/yyyy HH:mm" EditFormatString="dd/MM/yyyy HH:mm" ClientInstanceName="ClientExecuteAtEditor">
                                        <TimeSectionProperties Visible="true"></TimeSectionProperties>
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnACancel" runat="server" Text="Cancel" AutoPostBack="false" ClientInstanceName="ClientCancelButton">
                <ClientSideEvents Click="function(s, e) {{ ClientEditPopup.Hide();}}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnASave" runat="server" Text="Create Job" AutoPostBack="false" ClientInstanceName="ClientSaveButton" UseSubmitBehavior="true">
                 <Image Url="../Content/images/SpinEditPlus.png"></Image>
                <ClientSideEvents Click="RevCost.ClientSaveButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>
</asp:Content>

