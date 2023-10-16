<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="JobSchedule.aspx.cs" Inherits="Business_JobSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link href="../Content/RevCost.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../Scripts/PageModuleBase.js"></script>
    <script src="../Scripts/JobSchedule.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../signalr/hubs"></script>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="RevCost.ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="padding: 10px 10px 10px; font-size: 1.5em; font-weight: bold; margin: 0px 4px 4px; float: left;">
                            <asp:Literal ID="Literal1" runat="server" Text="Background Jobs" />
                        </div>
                        <div style="float: right;">
                            <dx:ASPxButton ID="btnRefresh" runat="server" Text="Refresh" RenderMode="Button" AutoPostBack="false">
                                <Image Url="../Content/images/refresh.png" Height="16"></Image>
                                <ClientSideEvents Click="RevCost.ClientRefreshButtonClick" />
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="btnCreateJob" runat="server" Text="Create Job" RenderMode="Button"  AutoPostBack="false">
                                <Image Url="../Content/images/SpinEditPlus.png"></Image>
                                <ClientSideEvents Click="function(s, e) {{ 
                                    var d = new Date(); 
                                    d.setMinutes(d.getMinutes() + 30);
                                    ClientExecuteAtEditor.SetValue(d); 
                                    ClientEditPopup.Show(); }}" />
                            </dx:ASPxButton>
                            &nbsp;&nbsp;&nbsp;
                            <dx:ASPxButton ID="btnDelete" runat="server" Text="Stop Job" RenderMode="Button"  AutoPostBack="false">
                                <Image Url="../Content/images/delete.gif"></Image>
                                <ClientSideEvents Click="RevCost.ClientStopJobButtonClick" />
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

                                    <dx:SplitterPane Size="520" Name="Versions" Separator-Visible="False">
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
                                                        <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="4" Caption="Status" Width="85" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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

                                    <dx:SplitterPane>
                                        <Panes>
                                            <dx:SplitterPane Size="300" Name="Jobs">
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
                                                        <dx:ASPxGridView ID="JobGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                            ClientInstanceName="ClientJobGrid" Width="100%" KeyFieldName="Id" OnCustomCallback="JobGrid_CustomCallback">
                                                            <Columns> 
                                                                <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Caption="Job Id" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="JobType" VisibleIndex="1" Caption="Job Type" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientJobGrid_FocusedRowChanged"
                                                                EndCallback="RevCost.ClientJobGrid_EndCallback" />
                                                        </dx:ASPxGridView>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                                <PaneStyle>
                                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                                </PaneStyle>
                                            </dx:SplitterPane>
                                            <dx:SplitterPane Name="JobDetail">
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
                                                        <dx:ASPxGridView ID="JobDetailGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                            ClientInstanceName="ClientJobDetailGrid" Width="100%" KeyFieldName="Id" OnCustomCallback="JobDetailGrid_CustomCallback">
                                                            <Columns>
                                                                <%-- <dx:GridViewDataTextColumn FieldName="AreaCode" VisibleIndex="1" Caption="Area" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                </dx:GridViewDataTextColumn>--%>
                                                                <dx:GridViewDataTextColumn FieldName="VersionID" VisibleIndex="1" Caption="VersionID" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                </dx:GridViewDataTextColumn>

                                                                <%--    <dx:GridViewDataTextColumn FieldName="VersionType" VisibleIndex="2" Caption="Version Type" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                </dx:GridViewDataTextColumn>--%>
                                                                <dx:GridViewDataTextColumn FieldName="VersionYear" VisibleIndex="3" Caption="Version Year" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="CompanyID" VisibleIndex="4" Caption="CompanyID" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="FromMonth" VisibleIndex="5" Caption="FromMonth" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="ToMonth" VisibleIndex="6" Caption="ToMonth" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataDateColumn FieldName="RunDate" VisibleIndex="7" Caption="RunAt" Width="140" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm"></PropertiesDateEdit>
                                                                </dx:GridViewDataDateColumn>
                                                                <dx:GridViewDataDateColumn FieldName="FinishDate" VisibleIndex="8" Caption="FinishAt" Width="140" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm"></PropertiesDateEdit>
                                                                </dx:GridViewDataDateColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="9" Caption="Status" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Message" VisibleIndex="10" Caption="Remark" Width="350" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                                                            <SettingsPager Visible="true" Mode="ShowAllRecords" />
                                                        </dx:ASPxGridView>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                                <PaneStyle>
                                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                                </PaneStyle>
                                            </dx:SplitterPane>
                                        </Panes>

                                        <PaneStyle>
                                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                        </PaneStyle>
                                    </dx:SplitterPane>
                                </Panes>
                                <PaneStyle Border-BorderWidth="0">
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                </PaneStyle>
                            </dx:SplitterPane>

                        </Panes>
                    </dx:SplitterPane>
                </Panes>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>

    <dx:ASPxPopupControl ID="EditPopup" runat="server" Width="500" Height="150" AllowDragging="True" HeaderText="Create Job" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientEditPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditForm" ColCount="2" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="Job Type" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="JobTypeEditor" Width="100%" ClientInstanceName="ClientJobTypeEditor">
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
                        <dx:LayoutItem Caption="" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxRadioButtonList runat="server" ID="ExecuteTypeEditor" Width="100%" Border-BorderStyle="None" RepeatDirection="Horizontal" ClientInstanceName="ClientExecuteTypeEditor">
                                        <Items>
                                            <dx:ListEditItem Value="Schedule" Text="Schedule" Selected="true" />
                                            <dx:ListEditItem Value="Enqueue" Text="Enqueue" />
                                        </Items>
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                        <ClientSideEvents ValueChanged="RevCost.ClientExecuteTypeEditor_ValueChanged" />
                                    </dx:ASPxRadioButtonList>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Execute At" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit runat="server" ID="ExecuteAtEditor" Width="100%" DisplayFormatString="dd/MM/yyyy HH:mm" EditFormatString="dd/MM/yyyy HH:mm" ClientInstanceName="ClientExecuteAtEditor">
                                        <TimeSectionProperties Visible="true"></TimeSectionProperties>
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="From Month">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="FromMonthEditor" MaxValue="12" MinValue="1" Width="100%" ClientInstanceName="ClientFromMonthEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="To Month">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="ToMonthEditor" MaxValue="12" MinValue="1" Width="100%" ClientInstanceName="ClientToMonthEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxSpinEdit>
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
                <dx:ASPxGridView ID="CompanyGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientCompanyGrid" Width="100%" KeyFieldName="CompanyID">
                    <Columns>
                        <dx:GridViewCommandColumn ShowSelectCheckbox="true" Width="40" SelectAllCheckboxMode="AllPages" />
                        <dx:GridViewDataTextColumn FieldName="OriArea" VisibleIndex="1" Caption="Area" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ShortName" VisibleIndex="2" Caption="Code" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="NameV" VisibleIndex="3" Caption="Name VN" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <DataItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("AreaCode") +"-"+ Eval("NameV") %>'></asp:Label>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Styles>
                        <AlternatingRow Enabled="true" />
                        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                    </Styles>
                    <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="350" VerticalScrollBarStyle="Standard" />
                    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="OriArea;ShortName;NameV" />
                    <Paddings Padding="0px" />
                    <Border BorderWidth="0px" BorderStyle="None" />
                    <BorderBottom BorderWidth="1px" />
                    <SettingsBehavior AllowFocusedRow="True" />
                    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />

                </dx:ASPxGridView>
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

    <dx:ASPxHiddenField ID="JobScheduleHiddenField" runat="server" ClientInstanceName="ClientJobScheduleHiddenField"></dx:ASPxHiddenField>

</asp:Content>

