<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="VersionType.aspx.cs" Inherits="Business_KTQT_VersionType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link href="../../Content/RevCost.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../../Scripts/KTQTVersionType.js"></script>
    <script src="../../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../../signalr/hubs"></script>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="RevCost.ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div class="title">
                            <asp:Literal ID="Literal1" runat="server" Text="Version" />
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle>
                    <BorderTop BorderWidth="0px" />
                    <BorderLeft BorderWidth="0px" />
                    <BorderRight BorderWidth="0px" />
                </PaneStyle>
            </dx:SplitterPane>
            <dx:SplitterPane Size="40" Separator-Visible="False">
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
                                        <ClientSideEvents ValueChanged="RevCost.ClientVersionType_ValueChanged" />
                                    </dx:ASPxRadioButtonList>
                                </td>
                                <td style="width: 150px;">
                                    <dx:ASPxButton ID="btnQuery" runat="server" Text="Query" AutoPostBack="false" UseSubmitBehavior="true">
                                        <ClientSideEvents Click="RevCost.ClientQuery_Click" />
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="btnSyncData" runat="server" Text="Đồng bộ version PMS" AutoPostBack="false" UseSubmitBehavior="true">
                                        <ClientSideEvents Click="RevCost.ClientSyncData_Click" />
                                    </dx:ASPxButton>
                                </td>

                            </tr>
                        </table>
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
                            OnCustomCallback="VersionGrid_CustomCallback"
                            OnCustomDataCallback="VersionGrid_CustomDataCallback">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="VersionID" VisibleIndex="0" Caption="Id" Width="50" FixedStyle="Left" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="VersionYear" VisibleIndex="1" Caption="Year" Width="50" FixedStyle="Left" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="VersionType" VisibleIndex="2" Caption="Type" Width="50" FixedStyle="Left" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="VersionName" VisibleIndex="3" Caption="Name" Width="250" FixedStyle="Left" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="VersionQuantityName" VisibleIndex="4" Caption="Version" FixedStyle="Left" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="VersionLevel" VisibleIndex="5" Caption="Level" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Calculation" VisibleIndex="6" Caption="Calculation" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="VerIDBase" VisibleIndex="6" Caption="Version Base 1" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="VerIDBase1" VisibleIndex="6" Caption="Version Base 2" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="VerIDBase2" VisibleIndex="6" Caption="Version Base 3" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="VerIDBase3" VisibleIndex="6" Caption="Version Base 4" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="VerIDBase4" VisibleIndex="6" Caption="Version 9 Month" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataComboBoxColumn>
                                <%-- <dx:GridViewDataTextColumn FieldName="CPI" VisibleIndex="6" Caption="CPI" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>--%>
                                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="7" Caption="Description" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="8" Caption="Status" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Creator" VisibleIndex="9" Caption="Creator" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CreateNote" VisibleIndex="10" Caption="Create Note" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="CreatedDate" VisibleIndex="11" Caption="Created Date" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesDateEdit EditFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="Reviewer" VisibleIndex="12" Caption="Reviewer" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ReviewedNote" VisibleIndex="13" Caption="Reviewe Note" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="ReviewedDate" VisibleIndex="14" Caption="Reviewed Date" Width="90" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesDateEdit EditFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="Approver" VisibleIndex="15" Caption="Approver" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ApprovedNote" VisibleIndex="16" Caption="Approve Note" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="ApprovedDate" VisibleIndex="17" Caption="Approved Date" Width="90" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesDateEdit EditFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataCheckColumn FieldName="Active" VisibleIndex="18" Caption="Active" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataTextColumn FieldName="UsedStatus" VisibleIndex="19" Caption="Used?" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <Styles>
                                <AlternatingRow Enabled="true" />
                            </Styles>
                            <Settings ShowFilterRow="true" ShowTitlePanel="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                            <%--<SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="AreaCode;NameV;NameE" />--%>
                            <Paddings Padding="0px" />
                            <Border BorderWidth="1px" />
                            <BorderBottom BorderWidth="1px" />
                            <SettingsBehavior AllowFocusedRow="True" />
                            <SettingsResizing ColumnResizeMode="Control" />
                            <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                            <Templates>
                                <TitlePanel>
                                    <div style="float: left">
                                        <dx:ASPxLabel runat="server" Font-Bold="true" Text="Version Type"></dx:ASPxLabel>
                                    </div>
                                    <div style="float: right; padding-right: 10px">
                                        <dx:ASPxButton ID="btnNew" runat="server" ClientInstanceName="ClientNewButton" Text="New" RenderMode="Link" ImagePosition="Left" AutoPostBack="false">
                                            <Image Height="16" Url="../../Content/images/SpinEditPlus.png"></Image>
                                            <ClientSideEvents Click="RevCost.ClientNewVersionButton_Click" />
                                        </dx:ASPxButton>
                                        &nbsp;
                                        <dx:ASPxButton ID="btnEdit" runat="server" ClientInstanceName="ClientEditButton" Text="Edit" RenderMode="Link" ImagePosition="Left" AutoPostBack="false">
                                            <Image Url="../../Content/images/action/edit.gif" Height="16"></Image>
                                            <ClientSideEvents Click="RevCost.ClientEditVersionButton_Click" />
                                        </dx:ASPxButton>
                                        &nbsp;
                                        <dx:ASPxButton ID="btnDelete" runat="server" ClientInstanceName="ClientDeleteButton" Text="Delete" RenderMode="Link" ImagePosition="Left" AutoPostBack="false">
                                            <Image Url="../../Content/images/action/delete.gif" Height="16"></Image>
                                            <ClientSideEvents Click="RevCost.ClientDeleteVersionButton_Click" />
                                        </dx:ASPxButton>

                                    </div>
                                </TitlePanel>

                            </Templates>
                            <ClientSideEvents BeginCallback="RevCost.ClientVersionGrid_BeginCallback"
                                EndCallback="RevCost.ClientVersionGrid_EndCallback"
                                FocusedRowChanged="RevCost.ClientVersionGrid_FocusedRowChanged" />
                        </dx:ASPxGridView>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle>
                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                </PaneStyle>
            </dx:SplitterPane>
            <dx:SplitterPane Size="45" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <dx:ASPxButton ID="btnCopy" runat="server" Text="Copy To" ClientInstanceName="ClientCopyButton" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                            <Image Url="../../Content/images/if_simpline_4_2305586.png" Height="16"></Image>
                            <ClientSideEvents Click="RevCost.ClientCopyVersionButton_Click" />
                        </dx:ASPxButton>
                        <%-- <dx:ASPxButton ID="btnCopyDataFromKHNH" runat="server" Text="Copy from Plan Data" ClientInstanceName="ClientCopyPlanData" RenderMode="Button" AutoPostBack="false" Image-Width="18" Image-Url="~/Content/images/if_simpline_4_2305586.png">
                            <ClientSideEvents Click="RevCost.ClientCopyPlanData_Click" />
                        </dx:ASPxButton>--%>
                        <dx:ASPxButton ID="btnApprove" runat="server" Text="Approve" ClientInstanceName="ClientApproveButton" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                            <Image Url="../../Content/images/action/Appr.gif"></Image>
                            <ClientSideEvents Click="RevCost.ClientShowApproveNoteButton_Click" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnUnApprove" runat="server" Text="Unapprove" RenderMode="Button" ClientInstanceName="ClientUnapprovedButton" AutoPostBack="false" Image-Width="16">
                            <Paddings Padding="2px" />
                            <Image Url="../../Content/images/action/UnAppr.gif"></Image>
                            <ClientSideEvents Click="RevCost.ClientUnaprovedButton_Click" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnApplyToDepartment" runat="server" Text="Apply Version" ClientInstanceName="ClientApplyToDepartment" RenderMode="Button" AutoPostBack="false" Image-Width="18" Image-Url="~/Content/images/action/approve.png">
                            <ClientSideEvents Click="RevCost.ClientApplyToDepartment_Click" />
                        </dx:ASPxButton>

                        <dx:ASPxButton ID="btnUsedStatus" runat="server" ClientInstanceName="ClientUsedStatusButton" Text="Set used status" ImagePosition="Left" AutoPostBack="false">

                            <ClientSideEvents Click="RevCost.ClientUsedStatusButton_Click" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnSyncPMSData" runat="server" Text="Syn PMS Data" ClientInstanceName="ClientPMSData" RenderMode="Button" AutoPostBack="false" Image-Width="18" Image-Url="~/Content/images/execute.png">
                            <ClientSideEvents Click="RevCost.ClientPMSData_Click" />
                        </dx:ASPxButton>
                    </dx:SplitterContentControl>
                </ContentCollection>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>


    <dx:ASPxCallback ID="RevCostCallback" runat="server" ClientInstanceName="ClientRevCostCallback" OnCallback="RevCostCallback_Callback">
        <ClientSideEvents CallbackComplete="RevCost.ClientRevCostCallback_CallbackComplete" />
    </dx:ASPxCallback>

    <dx:ASPxPopupControl ID="ApproveNotePopup" runat="server" Width="500" Height="200" AllowDragging="True" HeaderText="Approve Note" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientApproveNotePopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxMemo ID="ApproveNoteEditor" runat="server" ClientInstanceName="ClientApproveNoteEditor" Height="100%" Width="100%" Rows="10"></dx:ASPxMemo>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Cancel" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientApproveNotePopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApproveOK" runat="server" Text="Approve" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClienApproveButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="EditPopupControl" runat="server" Width="400" Height="100" AllowDragging="True" HeaderText="" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientEditPopupControl" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditForm" runat="server" ColCount="2" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientEditForm"
                    AlignItemCaptionsInAllGroups="true" Width="100%" ShowItemCaptionColon="false" OptionalMark="">
                    <Items>
                        <dx:LayoutItem Caption="Year" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="ForYearEditor" Width="100" ClientInstanceName="ClientYearEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Type" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="TypeEditor" Width="100" ClientInstanceName="ClientTypeEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                        <Items>
                                            <dx:ListEditItem Value="P" Text="Planning" Selected="true" />
                                            <dx:ListEditItem Value="E" Text="Estimate" />
                                            <dx:ListEditItem Value="A" Text="Actual" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Name" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="NameEditor" Width="300" AutoResizeWithContainer="true" ClientInstanceName="ClientNameEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Version" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="VersionEditor" Width="300" AutoResizeWithContainer="true" ClientInstanceName="ClientVersionEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Level" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="LevelEditor" Width="100" ClientInstanceName="ClientLevelEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Calculation" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="CalculationEditor" Width="100" ClientInstanceName="ClientCalculationEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                        <Items>
                                            <dx:ListEditItem Value="BOTTOMUP" Text="BOTTOMUP" Selected="true" />
                                            <dx:ListEditItem Value="TOPDOWN" Text="TOPDOWN" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <%--<dx:LayoutItem Caption="CPI" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="CPIEditor" Width="100" ClientInstanceName="ClientCPIEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                        <dx:LayoutItem Caption="Description" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxMemo runat="server" ID="DescriptionEditor" Width="300" ClientInstanceName="ClientDescriptionEditor" Rows="3">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxMemo>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Note" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxMemo runat="server" ID="CreateNoteEditor" Width="300" ClientInstanceName="ClientCreateNoteEditor" Rows="3">
                                    </dx:ASPxMemo>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <%-- <dx:LayoutItem ShowCaption="False" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxRadioButtonList ID="rblActualType" runat="server" ValueType="System.Int32" ClientInstanceName="ClientActualTypeEditor" RepeatDirection="Vertical">
                                        <Border BorderStyle="None" />
                                        <Items>
                                            <dx:ListEditItem Value="1" Text="Thực hiện theo ngày chi phí" />
                                            <dx:ListEditItem Value="0" Text="Thực hiện theo ngày chứng từ" />
                                        </Items>
                                    </dx:ASPxRadioButtonList>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                        <dx:LayoutItem Caption="Version Base 1" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <table style="width: 380px; border: none;">
                                        <tr>
                                            <td style="width: 70px">
                                                <dx:ASPxTextBox runat="server" ID="YearBase1Editor" Width="70" ClientInstanceName="ClientYearBase1Editor">
                                                    <ClientSideEvents ValueChanged="RevCost.ClientYearBase1Editor_ValueChanged" />
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td style="width: 200px; float: left; margin: 2px">
                                                <dx:ASPxComboBox runat="server" ID="Verbase01Editor" Width="230" AllowNull="true" ValueType="System.Int32" ClientInstanceName="ClientVerbase01Editor" OnInit="Verbase01Editor_Init"
                                                    OnCallback="Verbase05Editor_Callback">
                                                </dx:ASPxComboBox>
                                            </td>
                                        </tr>
                                    </table>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Version Base 2" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <table style="width: 380px; border: none;">
                                        <tr>
                                            <td style="width: 70px">
                                                <dx:ASPxTextBox runat="server" ID="YearBase2Editor" Width="70" ClientInstanceName="ClientYearBase2Editor">
                                                    <ClientSideEvents ValueChanged="RevCost.ClientYearBase2Editor_ValueChanged" />
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td style="width: 200px; float: left; margin: 2px">
                                                <dx:ASPxComboBox runat="server" ID="Verbase02Editor" Width="230" AllowNull="true" ValueType="System.Int32" ClientInstanceName="ClientVerbase02Editor" OnInit="Verbase01Editor_Init"
                                                    OnCallback="Verbase05Editor_Callback">
                                                </dx:ASPxComboBox>
                                            </td>

                                        </tr>
                                    </table>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Version Base 3" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <table style="width: 380px; border: none;">
                                        <tr>
                                            <td style="width: 70px">
                                                <dx:ASPxTextBox runat="server" ID="YearBase3Editor" Width="70" ClientInstanceName="ClientYearBase3Editor">
                                                    <ClientSideEvents ValueChanged="RevCost.ClientYearBase3Editor_ValueChanged" />
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td style="width: 200px; float: left; margin: 2px">
                                                <dx:ASPxComboBox runat="server" ID="Verbase03Editor" Width="230" AllowNull="true" ValueType="System.Int32" ClientInstanceName="ClientVerbase03Editor" OnInit="Verbase01Editor_Init"
                                                    OnCallback="Verbase05Editor_Callback">
                                                </dx:ASPxComboBox>
                                            </td>

                                        </tr>
                                    </table>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Version Base 4" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <table style="width: 380px; border: none;">
                                        <tr>
                                            <td style="width: 70px">
                                                <dx:ASPxTextBox runat="server" ID="YearBase4Editor" Width="70" ClientInstanceName="ClientYearBase4Editor">
                                                    <ClientSideEvents ValueChanged="RevCost.ClientYearBase4Editor_ValueChanged" />
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td style="width: 200px; float: left; margin: 2px">
                                                <dx:ASPxComboBox runat="server" ID="Verbase04Editor" Width="230" AllowNull="true" ValueType="System.Int32" ClientInstanceName="ClientVerbase04Editor" OnInit="Verbase01Editor_Init"
                                                    OnCallback="Verbase05Editor_Callback">
                                                </dx:ASPxComboBox>
                                            </td>

                                        </tr>
                                    </table>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Version 9 Month" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <table style="width: 380px; border: none;">
                                        <tr>
                                            <td style="width: 70px">
                                                <dx:ASPxTextBox runat="server" ID="YearBase5Editor" Width="70" ClientInstanceName="ClientYearBase5Editor">
                                                    <ClientSideEvents ValueChanged="RevCost.ClientYearBase5Editor_ValueChanged" />
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td style="width: 200px; float: left; margin: 2px">
                                                <dx:ASPxComboBox runat="server" ID="Verbase05Editor" Width="230" AllowNull="true" ValueType="System.Int32" ClientInstanceName="ClientVerbase05Editor"
                                                    OnInit="Verbase01Editor_Init" OnCallback="Verbase05Editor_Callback">
                                                </dx:ASPxComboBox>
                                            </td>

                                        </tr>
                                    </table>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Active">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox runat="server" ID="ActiveEditor" Width="300" ClientInstanceName="ClientActiveEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxCheckBox>
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Đóng" AutoPostBack="false" ClientInstanceName="ClientCancelButton">
                <ClientSideEvents Click="function(s, e) {{ ASPxClientEdit.ClearEditorsInContainerById('EditForm'); ClientEditPopupControl.Hide();}}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnSave" runat="server" Text="Lưu" AutoPostBack="false" ClientInstanceName="ClientSaveButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientSaveButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Closing="RevCost.ClientEditPopupControl_Closing" />
    </dx:ASPxPopupControl>


    <dx:ASPxPopupControl ID="ParamsPopup" runat="server" Width="150" Height="100" AllowDragging="True" HeaderText="Sync FAST Data" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientParamsPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="ParamsForm" runat="server" ColCount="2" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="From Month">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="FromMonthEditor" Width="50" ClientInstanceName="ClientFromMonthEditor" MinValue="1" MaxValue="12">
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
                                    <dx:ASPxSpinEdit runat="server" ID="ToMonthEditor" Width="50" ClientInstanceName="ClientToMonthEditor" MinValue="1" MaxValue="12">
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
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" runat="server" Text="Cancel" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientParamsPopup.Hide(); }}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" runat="server" Text="Sync Data" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientSyncFASTData_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="CopyVersionPopup" runat="server" Width="500" Height="250" AllowDragging="True" HeaderText="Copy Data To Version" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientCopyVersionCompanyPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxGridView ID="VersionCopyGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientVersionCopyGrid" Width="100%" KeyFieldName="VersionID"
                    OnCustomCallback="VersionCopyGrid_CustomCallback">
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
                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="250" VerticalScrollBarStyle="Standard" />
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancelCopy" runat="server" Text="Cancel" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientCopyVersionCompanyPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApplyCopy" runat="server" Text="Apply" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientApplyCopyVersionCompanyButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientCopyVersionCompanyPopup_Shown" />
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="PlanVersion" runat="server" Width="500" Height="400" AllowDragging="True" HeaderText="Copy From Plan Version" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientPlanVersionPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxSplitter ID="ASPxSplitter1" runat="server" Orientation="Vertical" FullscreenMode="true" Width="100%" Height="100%" ResizingMode="Live">
                    <ClientSideEvents PaneResized="RevCost.ClientCopyPlanVersionSplliter_PaneResized" />
                    <Panes>
                        <dx:SplitterPane Size="50" Separator-Visible="False">
                            <ContentCollection>
                                <dx:SplitterContentControl>
                                    <dx:ASPxFormLayout ID="AllocateParamsForm" runat="server" ColCount="2" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                                        AlignItemCaptionsInAllGroups="true" Width="100%" OptionalMark="">
                                        <Items>
                                            <dx:LayoutItem Caption="From Month">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxSpinEdit runat="server" ID="ApplyFromMonthEditor" Width="100" ClientInstanceName="ClientApplyFromMonthEditor" MinValue="1" MaxValue="12">
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
                                                        <dx:ASPxSpinEdit runat="server" ID="ApplyToMonthEditor" Width="100" ClientInstanceName="ClientApplyToMonthEditor" MinValue="1" MaxValue="12">
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
                                </dx:SplitterContentControl>
                            </ContentCollection>
                            <PaneStyle>
                                <BorderTop BorderStyle="None" />
                                <BorderLeft BorderStyle="None" />
                                <BorderRight BorderStyle="None" />
                            </PaneStyle>
                        </dx:SplitterPane>
                        <dx:SplitterPane Separator-Visible="False" Name="VersionGrid">
                            <ContentCollection>
                                <dx:SplitterContentControl>
                                    <dx:ASPxGridView ID="PlanVersionGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                        ClientInstanceName="ClientPlanVersionCopyGrid" Width="100%" KeyFieldName="VersionID"
                                        OnCustomCallback="PlanVersionGrid_CustomCallback">
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
                                        <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="250" VerticalScrollBarStyle="Standard" />
                                        <Paddings Padding="0px" />
                                        <Border BorderWidth="0px" />
                                        <SettingsBehavior AllowFocusedRow="True" />
                                        <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                                    </dx:ASPxGridView>
                                </dx:SplitterContentControl>
                            </ContentCollection>
                            <PaneStyle>
                                <Paddings Padding="0" />
                                <BorderBottom BorderStyle="None" />
                                <BorderLeft BorderStyle="None" />
                                <BorderRight BorderStyle="None" />
                            </PaneStyle>
                        </dx:SplitterPane>
                    </Panes>
                </dx:ASPxSplitter>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancelPlanCopy" runat="server" Text="Cancel" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientPlanVersionPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApplyCopy" runat="server" Text="Apply" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientApplyCopyPlanVersionButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientCopyPlanVersionPopup_Shown" />
    </dx:ASPxPopupControl>

</asp:Content>

