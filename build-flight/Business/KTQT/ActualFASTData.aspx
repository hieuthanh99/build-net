<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ActualFASTData.aspx.cs" Inherits="Business_KTQT_ActualFASTData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link href="../../Content/RevCost.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../../Scripts/KTQTActualFASTData.js"></script>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="RevCost.ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div class="title">
                            <asp:Literal ID="Literal1" runat="server" Text="(FAST) Chi phí thực hiện" />
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle>
                    <BorderTop BorderWidth="0px" />
                    <BorderLeft BorderWidth="0px" />
                    <BorderRight BorderWidth="0px" />
                    <BorderBottom BorderWidth="0px" />
                </PaneStyle>
            </dx:SplitterPane>
            <dx:SplitterPane Separator-Visible="False">
                <Panes>
                    <dx:SplitterPane>
                        <Panes>
                            <dx:SplitterPane Size="100" Separator-Visible="False">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxFormLayout runat="server" ColCount="9">
                                            <Items>
                                                <dx:LayoutItem Caption="Hiển thị theo" ColSpan="9">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxRadioButtonList ID="rblActualType" runat="server" ValueType="System.String" ClientInstanceName="ClientActualTypeEditor" RepeatDirection="Horizontal">
                                                                <Border BorderStyle="None" />
                                                                <Items>
                                                                    <dx:ListEditItem Value="CT" Text="Theo tháng chứng từ" Selected="true" />
                                                                    <dx:ListEditItem Value="CP" Text="Theo tháng chi phí" />
                                                                </Items>
                                                            </dx:ASPxRadioButtonList>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Area">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxComboBox ID="cboArea" runat="server" Width="120px" OnInit="AirportsEditor_Init" ClientInstanceName="ClientAirport"></dx:ASPxComboBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="From Month">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxSpinEdit ID="QueryFromMonthEditor" runat="server" ClientInstanceName="ClientQueryFromMonthEditor" Width="50" MinValue="1" MaxValue="12"></dx:ASPxSpinEdit>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="To Month">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxSpinEdit ID="QueryToMonthEditor" runat="server" ClientInstanceName="ClientQueryToMonthEditor" Width="50" MinValue="1" MaxValue="12"></dx:ASPxSpinEdit>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Year">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxSpinEdit ID="QueryYearEditor" runat="server" ClientInstanceName="ClientQueryYearEditor" Width="100"></dx:ASPxSpinEdit>
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
                                                            <dx:ASPxButton ID="btnSyncFAST" runat="server" ClientInstanceName="ClientSyncFASTButton" Text="Sync FAST Data (Ngày chứng từ)" UseSubmitBehavior="true" AutoPostBack="false">
                                                                <ClientSideEvents Click="RevCost.ClientSyncFASTButton_Click" />
                                                            </dx:ASPxButton>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem ShowCaption="False">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxButton ID="btnShowVersion" runat="server" ClientInstanceName="ClientShowVersionButton" Text="Apply To Version" UseSubmitBehavior="true" AutoPostBack="false">
                                                                <ClientSideEvents Click="RevCost.ClientShowVersionButton_Click" />
                                                            </dx:ASPxButton>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem ShowCaption="False">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxButton ID="btnExportTemplate" runat="server" ClientInstanceName="ClientExportTemplateButton" Text="Export Template" UseSubmitBehavior="true" AutoPostBack="false">
                                                                <ClientSideEvents Click="RevCost.ClientExportTemplateButton_Click" />
                                                            </dx:ASPxButton>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <%-- <dx:LayoutItem ShowCaption="False">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxButton ID="btnImportData" runat="server" ClientInstanceName="ClientImportDataButton" Text="Import" UseSubmitBehavior="true" AutoPostBack="false">
                                                                <ClientSideEvents Click="RevCost.ClientImportDataButton_Click" />
                                                            </dx:ASPxButton>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>--%>
                                            </Items>
                                        </dx:ASPxFormLayout>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                            </dx:SplitterPane>
                            <dx:SplitterPane Name="DataGrid" ScrollBars="Auto" Separator-Visible="False">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="DataGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientDataGrid" Width="100%" KeyFieldName="ActualFASTDataID"
                                            OnCustomCallback="DataGrid_CustomCallback"
                                            OnCustomColumnDisplayText="DataGrid_CustomColumnDisplayText">
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="AreaCode" VisibleIndex="0" Caption="Chi nhánh" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="MaVuViec" VisibleIndex="1" Caption="Mã vụ việc" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Month" VisibleIndex="2" Caption="Tháng CT" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Year" VisibleIndex="3" Caption="Năm CT" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="mcp" VisibleIndex="4" Caption="Tháng CP" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ycp" VisibleIndex="5" Caption="Năm CP" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ShortName" VisibleIndex="6" Caption="Mã bộ phận" Width="90" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="SubCode" VisibleIndex="7" Caption="Mã chỉ tiêu" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="PS_Trong_Ky" VisibleIndex="8" Caption="PS trong kỳ" Width="190" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Adjust" VisibleIndex="9" Caption="Điều chỉnh" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewCommandColumn VisibleIndex="10" Width="40" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                                    <CustomButtons>
                                                        <dx:GridViewCommandColumnCustomButton ID="btAdjust" Text=" " Image-Url="../../Content/images/action/edit.gif"></dx:GridViewCommandColumnCustomButton>
                                                    </CustomButtons>
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Total_PS_TK" VisibleIndex="11" Caption="Tổng PS trong kỳ" Width="190" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                </dx:GridViewDataSpinEditColumn>
                                              <%--  <dx:GridViewDataSpinEditColumn FieldName="LK_Dau_Nam" VisibleIndex="12" Caption="Lũy kế từ đầu năm" Width="170" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>--%>
                                                <dx:GridViewDataTextColumn FieldName="STT" VisibleIndex="13" Caption="STT" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="chi_tieu" VisibleIndex="14" Caption="Chỉ tiêu" Width="400" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="chi_tieu2" VisibleIndex="15" Caption="chi_tieu2" Visible="false" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="bo_phan" VisibleIndex="16" Caption="bo_phan" Visible="false" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="tk" VisibleIndex="17" Caption="Tài khoản" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ma_phi" VisibleIndex="18" Caption="Mã phí" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="vu_viec" VisibleIndex="19" Caption="Vụ việc" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="tk2" VisibleIndex="20" Caption="tk2" Visible="false" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="khong_am" VisibleIndex="21" Caption="khong_am" Visible="false" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="bp_loai_tru" VisibleIndex="22" Caption="bp_loai_tru" Visible="false" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <Styles>
                                                <AlternatingRow Enabled="true" />
                                            </Styles>
                                            <Settings ShowFooter="true" ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                            <SettingsResizing ColumnResizeMode="Control" />
                                            <Paddings Padding="0px" />
                                            <Border BorderWidth="1px" />
                                            <BorderBottom BorderWidth="1px" />
                                            <SettingsBehavior AllowFocusedRow="True" SummariesIgnoreNullValues="true" />
                                            <SettingsPager Visible="true" PageSize="50" Mode="EndlessPaging" Summary-Visible="true" />
                                            <ClientSideEvents CustomButtonClick="RevCost.ClientDataGrid_CustomButtonClick" />
                                            <TotalSummary>
                                                <dx:ASPxSummaryItem FieldName="PS_Trong_Ky" SummaryType="Sum" ShowInColumn="PS_Trong_Ky" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                <dx:ASPxSummaryItem FieldName="Total_PS_TK" SummaryType="Sum" ShowInColumn="Total_PS_TK" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                            </TotalSummary>
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
    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="DataGrid"></dx:ASPxGridViewExporter>

    <dx:ASPxPopupControl ID="AdjustPopup" runat="server" Width="150" Height="100" AllowDragging="True" HeaderText="Adjust" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientAdjustPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="1" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                    AlignItemCaptionsInAllGroups="true" Width="100%" OptionalMark="">
                    <Items>
                        <dx:LayoutItem Caption="Điều chỉnh">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit ID="txtAdjust" runat="server" Number="0" DisplayFormatString="N2" ClientInstanceName="ClientAdjustCost">
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
                <ClientSideEvents Click="function(s, e) {{ ClientAdjustPopup.Hide(); }}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" runat="server" Text="Save" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientSaveData_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientAdjustPopup_Shown" />
    </dx:ASPxPopupControl>

    <dx:ASPxCallback ID="FASTDataCallback" runat="server" ClientInstanceName="ClientFASTDataCallback" OnCallback="FASTDataCallback_Callback">
        <ClientSideEvents CallbackComplete="RevCost.ClientFASTDataCallback_CallbackComplete" />
    </dx:ASPxCallback>

    <dx:ASPxPopupControl ID="ParamsPopup" runat="server" Width="150" Height="100" AllowDragging="True" HeaderText="Sync FAST Data (Ngày chứng từ)" ShowFooter="True"
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
                                    <dx:ASPxComboBox ID="cboArea1" runat="server" Width="120px" OnInit="cboArea1_Init">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="From Month">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="SyncFromMonthEditor" Width="50" ClientInstanceName="ClientSyncFromMonthEditor" MinValue="1" MaxValue="12">
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
                                    <dx:ASPxSpinEdit runat="server" ID="SyncToMonthEditor" Width="50" ClientInstanceName="ClientSyncToMonthEditor" MinValue="1" MaxValue="12">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Year">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="YearEditor" Width="70" ClientInstanceName="ClientYearEditor" MinValue="2010" MaxValue="9999">
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
                <ClientSideEvents Click="RevCost.ClientApplySyncFASTData_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="ApplyVersionPopup" runat="server" Width="500" Height="400" AllowDragging="True" HeaderText="Apply To Version" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientApplyVersionPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxSplitter ID="ASPxSplitter1" runat="server" Orientation="Vertical" FullscreenMode="true" Width="100%" Height="100%" ResizingMode="Live">
                    <ClientSideEvents PaneResized="RevCost.ClientApplyToVersionSplliter_PaneResized" />
                    <Panes>
                        <dx:SplitterPane Size="50" Separator-Visible="False">
                            <ContentCollection>
                                <dx:SplitterContentControl>
                                    <dx:ASPxFormLayout ID="AllocateParamsForm" runat="server" ColCount="2" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                                        AlignItemCaptionsInAllGroups="true" Width="100%" OptionalMark="">
                                        <Items>
                                            <%-- <dx:LayoutItem Caption="Company" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox ID="cboApplyCompany" runat="server" Width="320px" ClientInstanceName="ClientApplyCompany" OnCallback="cboApplyCompany_Callback"></dx:ASPxComboBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>--%>
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
</asp:Content>

