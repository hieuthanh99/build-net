<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ImportQuantiy.aspx.cs" Inherits="Imports_ImportQuantiy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../Scripts/PageModuleBase.js"></script>
    <script src="../Scripts/ImportQuantity.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../signalr/hubs"></script>
    <dx:ASPxSplitter ID="contentSplitter" runat="server" ClientInstanceName="ClientContentSplitter" Orientation="Vertical" Width="100%" Height="100%" ResizingMode="Live">
        <ClientSideEvents PaneResized="RevCost.ClientContentSplitter_PaneResized" />
        <Border BorderStyle="None" />
        <Panes>
            <dx:SplitterPane Size="260">
                <Panes>
                    <dx:SplitterPane>
                        <Panes>
                            <dx:SplitterPane Size="70">
                                <Separator Visible="False"></Separator>
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <div style="float: right;">
                                            <div class="title">
                                                <asp:Literal ID="Literal1" runat="server" Text="ĐỔ DỮ LIỆU" />
                                            </div>
                                        </div>
                                        <div style="float: left;">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="padding-left: 5px;">
                                                        <dx:ASPxComboBox ID="cboFileType" runat="server" DropDownStyle="DropDownList" ClientInstanceName="ClientFileType" Width="180px" ValueType="System.String" Caption="Tên mẫu" OnInit="cboFileType_Init">
                                                            <ClientSideEvents ValueChanged="RevCost.ClientFileType_ValueChanged" />
                                                        </dx:ASPxComboBox>
                                                    </td>
                                                    <td style="padding-left: 5px;">
                                                        <dx:ASPxComboBox ID="cboCompany" runat="server" DropDownStyle="DropDownList" ClientVisible="false" ClientInstanceName="ClientCompany" Width="180px" ValueType="System.String" Caption="Đơn vị" OnInit="cboCompany_Init">
                                                        </dx:ASPxComboBox>
                                                    </td>
                                                    <td style="padding-left: 5px;">
                                                        <dx:ASPxButton ID="btnDownloadTemplate" runat="server" Text="Tải mẫu" AutoPostBack="false">
                                                            <ClientSideEvents Click="RevCost.ClientDownloadTemplateButton_Click" />
                                                        </dx:ASPxButton>
                                                    </td>
                                                    <td style="padding-left: 5px;">
                                                        <dx:ASPxUploadControl ID="UploadControl" runat="server" ClientInstanceName="ClientUploadControl" ShowProgressPanel="true" NullText="Chọn file"
                                                            Width="200px" FileUploadMode="OnPageLoad" UploadMode="Advanced" OnFilesUploadComplete="UploadControl_FilesUploadComplete" BrowseButton-Text="Duyệt file">
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
                                                        <dx:ASPxButton ID="btnApply" runat="server" Text="Apply Data" AutoPostBack="false">
                                                            <ClientSideEvents Click="RevCost.ClientApplyToVersion_Click" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnImportError" runat="server" Text="Import Logs" AutoPostBack="false">
                                                            <ClientSideEvents Click="RevCost.ClientImportError_Click" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnTransferDataHistory" runat="server" Text="Apply History" AutoPostBack="false">
                                                            <ClientSideEvents Click="RevCost.ClientTransferDataHistory_Click" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnRefresh" runat="server" Text="Refresh" AutoPostBack="false">
                                                            <ClientSideEvents Click="RevCost.ClientButtonRefresh_Click" />
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
                                            ClientInstanceName="ClientFileHistoryGrid" Width="100%" KeyFieldName="HistoryID" EnableViewState="false" EnableRowsCache="false"
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
                                                <dx:GridViewDataDateColumn FieldName="IssueDate" VisibleIndex="7" Caption="Issue Date" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm"></PropertiesDateEdit>
                                                </dx:GridViewDataDateColumn>
                                                <dx:GridViewDataTextColumn FieldName="Remark" VisibleIndex="8" Caption="Remark" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Note" VisibleIndex="9" Caption="Note" Width="60%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                                            <SettingsResizing ColumnResizeMode="Control" />
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
                            ClientInstanceName="ClientDataHistoryGrid" Width="100%" KeyFieldName="DataHistoryID" EnableViewState="false" EnableRowsCache="false"
                            OnCustomCallback="DataHistoryGrid_CustomCallback">

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
                            <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                            <Templates>
                                <TitlePanel>
                                    <div style="float: left">
                                        <dx:ASPxLabel runat="server" Font-Bold="true" Text="Data history (Data temp)"></dx:ASPxLabel>
                                    </div>
                                </TitlePanel>
                            </Templates>
                            <ClientSideEvents CallbackError="RevCost.ClientDataHistoryGrid_CallbackError" />
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
    <dx:ASPxPopupControl ID="ApplyVersionPopup" runat="server" Width="550" Height="450" AllowDragging="True" HeaderText="Select Version" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientApplyVersionPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxGridView ID="VersionGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientVersionGrid" Width="100%" KeyFieldName="VersionID"
                    OnCustomCallback="VersionGrid_CustomCallback">
                    <Columns>
                        <%--  <dx:GridViewCommandColumn Name="Checkbox" ShowSelectCheckbox="true" Width="30" VisibleIndex="1" SelectCheckBoxPosition="Left" SelectAllCheckboxMode="AllPages">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </dx:GridViewCommandColumn>--%>
                        <dx:GridViewDataTextColumn FieldName="VersionYear" VisibleIndex="2" Caption="Year" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="VersionType" VisibleIndex="3" Caption="Type" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="4" Caption="Description" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="5" Caption="Status" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                    <ClientSideEvents EndCallback="RevCost.ClientVersionGrid_EndCallback" />
                </dx:ASPxGridView>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Cancel" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientApplyVersionPopup.Hide(); }}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApplyToVersion" runat="server" Text="Apply" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientApplyToVersionButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientApplyVersionPopup_Shown" CloseUp="RevCost.ClientApplyVersionPopup_CloseUp" />
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" Width="850" Height="450" AllowDragging="True" HeaderText="Import Logs" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientImportErrorPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxGridView ID="ImportErrorGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientImportErrorGrid" Width="100%" KeyFieldName="Id"
                    OnCustomCallback="ImportErrorGrid_CustomCallback">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="HistoryID" VisibleIndex="2" Caption="History" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="VersionID" VisibleIndex="3" Caption="Version" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesComboBox
                                ValueType="System.Int32" DropDownStyle="DropDownList">
                                <ClearButton DisplayMode="OnHover" />
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn FieldName="LogText" VisibleIndex="4" Caption="Log" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True" CellStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="CreateDate" VisibleIndex="5" Caption="Date" Width="170" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm:ss"></PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="CreateBy" VisibleIndex="10" Caption="User" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesComboBox
                                ValueType="System.Int32" DropDownStyle="DropDownList">
                                <ClearButton DisplayMode="OnHover" />
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
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
                    <SettingsResizing ColumnResizeMode="Control" />
                    <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />

                </dx:ASPxGridView>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnClose" runat="server" Text="Close" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientImportErrorPopup.Hide(); }}" />
            </dx:ASPxButton>

            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientImportErrorPopup_Shown" CloseUp="RevCost.ClientImportErrorPopup_CloseUp" />
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="TransferDataHistory" runat="server" Width="900" Height="450" AllowDragging="True" HeaderText="Apply Data History" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientTransferDataHistory" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxGridView ID="TransferDataHistoryGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientTransferDataHistoryGrid" Width="100%" KeyFieldName="Id"
                    OnCustomCallback="TransferDataHistoryGrid_CustomCallback">
                    <Columns>
                        <dx:GridViewDataDateColumn FieldName="IssueDate" VisibleIndex="1" Caption="Date" Width="170" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm:ss"></PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="HistoryID" VisibleIndex="2" Caption="History" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="VersionID" VisibleIndex="3" Caption="Version" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesComboBox
                                ValueType="System.Int32" DropDownStyle="DropDownList">
                                <ClearButton DisplayMode="OnHover" />
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="CompanyID" VisibleIndex="4" Caption="Company" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesComboBox
                                ValueType="System.Int32" DropDownStyle="DropDownList">
                                <ClearButton DisplayMode="OnHover" />
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="UserID" VisibleIndex="5" Caption="Apply User" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesComboBox
                                ValueType="System.Int32" DropDownStyle="DropDownList">
                                <ClearButton DisplayMode="OnHover" />
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataDateColumn FieldName="CreateDate" VisibleIndex="6" Caption="Create Date" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="CreateBy" VisibleIndex="10" Caption="Create By" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesComboBox
                                ValueType="System.Int32" DropDownStyle="DropDownList">
                                <ClearButton DisplayMode="OnHover" />
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
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
                    <SettingsResizing ColumnResizeMode="Control" />
                    <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />

                </dx:ASPxGridView>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnClose" runat="server" Text="Close" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientTransferDataHistory.Hide(); }}" />
            </dx:ASPxButton>

            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientTransferDataHistory_Shown" CloseUp="RevCost.ClientTransferDataHistory_CloseUp" />
    </dx:ASPxPopupControl>
    <dx:ASPxCallback ID="Callback" runat="server" ClientInstanceName="ClientCallback" OnCallback="Callback_Callback">
        <ClientSideEvents BeginCallback="RevCost.ClientCallback_BeginCallback"
            CallbackComplete="RevCost.ClientCallback_CallbackComplete"
            EndCallback="RevCost.ClientCallback_EndCallback" />
    </dx:ASPxCallback>
</asp:Content>



