<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ChiphiThueQuayReport.aspx.cs" Inherits="Reports_ChiphiThueQuayReport" %>

<%@ Register Assembly="DevExpress.Web.ASPxSpreadsheet.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpreadsheet" TagPrefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../Scripts/PageModuleBase.js"></script>
    <script>
        function ClientPrintReportButton_Click(s, e) {
            DoCallback(ClientViewReportPanel, function () {
                ClientViewReportPanel.PerformCallback('GenerateExcel');
            });
        }
    </script>

    <dx:ASPxSplitter ID="ASPxSplitter1" runat="server" Orientation="Horizontal" Width="100%" Height="100%" SeparatorVisible="false">
        <Panes>
            <dx:SplitterPane Size="500" ScrollBars="Auto">
                <PaneStyle>
                    <BorderTop BorderWidth="0" />
                    <Paddings PaddingBottom="0" PaddingRight="0" PaddingTop="0" PaddingLeft="0" />
                </PaneStyle>
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <dx:ASPxFormLayout ID="ParameterForm" runat="server" Width="100%" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientParameterForm"
                            AlignItemCaptionsInAllGroups="true">
                            <Items>
                                <dx:LayoutGroup Caption="Danh sách báo cáo">
                                    <Items>
                                        <dx:LayoutItem ShowCaption="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxRadioButtonList ID="rdReport" runat="server" ValueType="System.String" ClientInstanceName="ClientReport">
                                                        <Items>
                                                            <dx:ListEditItem Value="ChiTietChiPhiThueQuay" Text="1. Chi tiết chi phí thuê quầy theo chi nhánh" Selected="true" />
                                                            <dx:ListEditItem Value="TongHopChiPhiThueQuay" Text="2. Tổng hợp chi phí thuê quầy theo hãng" />
                                                            <dx:ListEditItem Value="CountersCostDetail" Text="3. Chi phí thuê quầy bình quân của 1 máy bay theo hãng" />
                                                            <dx:ListEditItem Value="CountersCostTotal" Text="4. Chi phí thuê quầy bình quân theo hãng" />
                                                        </Items>
                                                        <Border BorderStyle="None" />
                                                    </dx:ASPxRadioButtonList>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="Tham số báo cáo" ColCount="2">
                                    <Items>
                                        <dx:LayoutItem Caption="Version">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cboVersion" runat="server" ClientInstanceName="ClientVersion" ValueType="System.Int32" Width="100%" OnInit="cboVersion_Init">
                                                        <ValidationSettings ErrorDisplayMode="None" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="Version is required" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Chi nhánh">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cboAreaCode" runat="server" Width="100%" ValueType="System.String" OnInit="cboAreaCode_Init">
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Từ tháng">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxSpinEdit ID="dtFromMonth" runat="server" MinValue="1" MaxValue="12" Width="100%">
                                                        <ValidationSettings ErrorDisplayMode="None" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="From Month is required" />
                                                        </ValidationSettings>
                                                    </dx:ASPxSpinEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Đến tháng">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxSpinEdit ID="dtToMonth" runat="server" MinValue="1" MaxValue="12" Width="100%">
                                                        <ValidationSettings ErrorDisplayMode="None" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="To Month is required" />
                                                        </ValidationSettings>
                                                    </dx:ASPxSpinEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Hãng" ColSpan="2">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTokenBox ID="cboCarrier" runat="server" Width="100%" OnInit="cboCarrier_Init">
                                                    </dx:ASPxTokenBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <%--<dx:LayoutItem Caption="Network">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cboNetwork" runat="server" ValueType="System.String" Width="150px">
                                                        <Items>
                                                            <dx:ListEditItem Value="ALL" Text="--ALL--" />
                                                            <dx:ListEditItem Value="INT" Text="Quốc tế" />
                                                            <dx:ListEditItem Value="DOM" Text="Quốc nội" />
                                                        </Items>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>--%>
                                        <dx:LayoutItem Caption="Loại tàu" ColSpan="2">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTokenBox ID="cboAcGroup" runat="server" Width="100%" OnInit="cboAcGroup_Init">
                                                    </dx:ASPxTokenBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>

                                    </Items>
                                </dx:LayoutGroup>
                                <dx:EmptyLayoutItem></dx:EmptyLayoutItem>

                                <dx:LayoutItem Caption="" HorizontalAlign="Right">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxButton ID="btnPrintReport" runat="server" Text="Xem báo cáo =>" AutoPostBack="false" ClientInstanceName="ClientPrintReportButton" UseSubmitBehavior="true">
                                                <ClientSideEvents Click="ClientPrintReportButton_Click" />
                                            </dx:ASPxButton>
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
            </dx:SplitterPane>
            <dx:SplitterPane ScrollBars="Auto">
                <PaneStyle>
                    <BorderTop BorderWidth="0" />
                    <Paddings PaddingBottom="0" PaddingRight="0" PaddingTop="0" PaddingLeft="0" />
                </PaneStyle>
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Width="100%" Height="100%" ClientInstanceName="ClientViewReportPanel" RenderMode="Div" OnCallback="ASPxCallbackPanel1_Callback">
                            <PanelCollection>
                                <dx:PanelContent>
                                    <dx:ASPxSpreadsheet ID="ASPxSpreadsheet1" runat="server" WorkDirectory="~/App_Data/WorkDirectory" Width="100%" Height="100%" ShowConfirmOnLosingChanges="false" ShowSheetTabs="false" RibbonMode="OneLineRibbon">
                                        <Border BorderWidth="0" />
                                    </dx:ASPxSpreadsheet>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxCallbackPanel>
                    </dx:SplitterContentControl>
                </ContentCollection>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
</asp:Content>

