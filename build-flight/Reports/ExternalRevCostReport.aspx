<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ExternalRevCostReport.aspx.cs" Inherits="Reports_ExternalRevCostReport" %>

<%@ Register Assembly="DevExpress.Web.ASPxSpreadsheet.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpreadsheet" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../Scripts/PageModuleBase.js"></script>
    <script>
        function ClientPrintReportButton_Click(s, e) {
            DoCallback(ClientViewReportPanel, function () {
                ClientViewReportPanel.PerformCallback('GenerateExcel');
            });
        }

        function ClientConfigReportButton_Click(s, e) {
            var URL = "";
            var report = ClientReport.GetValue();
            if (report == "ExternalRevCostM2") {
                URL = window.location.protocol + "//" + window.location.host + "/Reports/ConfigExtRevCostReportM2.aspx";
            }
            else {
                URL = window.location.protocol + "//" + window.location.host + "/Reports/ConfigExtRevCostReport.aspx";
            }

            window.open(URL, "_blank");
        }
    </script>
    <dx:ASPxSplitter ID="ASPxSplitter1" runat="server" Orientation="Horizontal" Width="100%" Height="100%" SeparatorVisible="false">
        <Panes>
            <dx:SplitterPane Size="400" ScrollBars="Auto">
                <PaneStyle>
                    <BorderTop BorderWidth="0" />
                    <Paddings PaddingBottom="0" PaddingRight="0" PaddingTop="0" PaddingLeft="0" />
                </PaneStyle>
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <dx:ASPxFormLayout ID="ParameterForm" runat="server" Width="100%" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientParameterForm"
                            AlignItemCaptionsInAllGroups="true">
                            <Items>
                                <dx:LayoutGroup Caption="List of reports">
                                    <Items>
                                        <dx:LayoutItem ShowCaption="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxRadioButtonList ID="rdReport" runat="server" ValueType="System.String" ClientInstanceName="ClientReport">
                                                        <Items>
                                                            <dx:ListEditItem Value="ExternalRevCost" Text="Báo cáo doanh thu - chi phí ngoài cơ bản" Selected="true" />
                                                            <dx:ListEditItem Value="ExternalRevCostM2" Text="Báo cáo doanh thu - chi phí thu nhập khác và HĐTC" />
                                                            <dx:ListEditItem Value="BCTTNDN" Text="Báo cáo thuế TNDN" />
                                                            <dx:ListEditItem Value="ExtRevCostDetail" Text="Chi tiết chi phí ngoài cơ bản" />
                                                            <dx:ListEditItem Value="ExtRevCostDetailM2" Text="Chi tiết chi phí thu nhập khác và HĐTC" />
                                                            <dx:ListEditItem Value="TTNDNDetail" Text="Chi tiết chi phí thuế TNDN" />
                                                        </Items>
                                                        <Border BorderStyle="None" />
                                                    </dx:ASPxRadioButtonList>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="Report Parameters">
                                    <Items>
                                        <dx:LayoutItem Caption="Area">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cboAreaCode" runat="server" ValueType="System.String" Width="100px" OnInit="cboAreaCode_Init">
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="From Month">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxSpinEdit ID="dtFromMonth" runat="server" MinValue="1" MaxValue="12" Width="100px">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="From Month is required" />
                                                        </ValidationSettings>
                                                    </dx:ASPxSpinEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="To Month">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxSpinEdit ID="dtToMonth" runat="server" MinValue="1" MaxValue="12" Width="100px">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="To Month is required" />
                                                        </ValidationSettings>
                                                    </dx:ASPxSpinEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Year">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxSpinEdit ID="dtYear" runat="server" MinValue="2018" MaxValue="9999" Width="100px">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="Year is required" />
                                                        </ValidationSettings>
                                                    </dx:ASPxSpinEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:EmptyLayoutItem></dx:EmptyLayoutItem>

                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxButton ID="btnConfig" runat="server" Text="Config" AutoPostBack="false" UseSubmitBehavior="true">
                                                <ClientSideEvents Click="ClientConfigReportButton_Click" />
                                            </dx:ASPxButton>
                                            &nbsp; &nbsp; &nbsp;
                                            <dx:ASPxButton ID="btnPrintReport" runat="server" Text="View Report" AutoPostBack="false" ClientInstanceName="ClientPrintReportButton" UseSubmitBehavior="true">
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

