<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ChitietChiphiTheoMucChi.aspx.cs" Inherits="Reports_ChitietChiphiTheoMucChi" %>

<%@ Register Assembly="DevExpress.Web.ASPxSpreadsheet.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpreadsheet" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../Scripts/PageModuleBase.js"></script>
    <script type="text/javascript">
        function ClientAreaCode_ValueChanged(s, e) {
            DoCallback(ClientCompany, function () {
                ClientCompany.PerformCallback(s.GetValue());
            });
        }

        function ClientPrintReportButton_Click(s, e) {
            DoCallback(ClientViewReportPanel, function () {
                ClientViewReportPanel.PerformCallback('GenerateExcel');
            });
        }
    </script>
    <dx:ASPxSplitter ID="ASPxSplitter1" runat="server" Orientation="Horizontal" Width="100%" Height="100%" SeparatorVisible="false">
        <Panes>
            <dx:SplitterPane Size="310" ScrollBars="Auto">
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
                                                    <dx:ASPxRadioButtonList ID="rdReport" runat="server" ValueType="System.String">
                                                        <Items>
                                                            <dx:ListEditItem Value="GiathanhChuyenbay" Text="So sánh giá thành các chuyến bay" Selected="true" />
                                                            <dx:ListEditItem Value="ChiphiBinhquan" Text="Chi phí bình quân của một loại MB theo hãng" />
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
                                        <dx:LayoutItem Caption="Version">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cboVersion" runat="server" ValueType="System.Int32" Width="150px" OnInit="cboVersion_Init">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="Version is required" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Area">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cboAreaCode" runat="server" ValueType="System.String" Width="100px" OnInit="cboAreaCode_Init">
                                                        
                                                        <ClientSideEvents ValueChanged="ClientAreaCode_ValueChanged" />
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="From Date">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxDateEdit ID="dtFromDate" runat="server" EditFormatString="dd/MM/yyyy" DisplayFormatString="dd/MM/yyyy" Width="100px">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="From Date is required" />
                                                        </ValidationSettings>
                                                    </dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="To Date">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxDateEdit ID="dtToDate" runat="server" EditFormatString="dd/MM/yyyy" DisplayFormatString="dd/MM/yyyy" Width="100px">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="To Date is required" />
                                                        </ValidationSettings>
                                                    </dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                      <%--  <dx:LayoutItem Caption="Company">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cboCompany" runat="server" ClientInstanceName="ClientCompany" ValueType="System.Int32" Width="150px" OnCallback="cboCompany_Callback">
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>--%>
                                        <dx:LayoutItem Caption="Carrier">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="txtCarrier" runat="server" Width="100px">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Aircraft">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="txtAircraft" runat="server" Width="100px">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:EmptyLayoutItem></dx:EmptyLayoutItem>

                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
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
                                    <dx:ASPxSpreadsheet ID="ASPxSpreadsheet1" runat="server" WorkDirectory="~/App_Data/WorkDirectory" Width="100%" Height="100%" ReadOnly="true" ShowConfirmOnLosingChanges="false" RibbonMode="OneLineRibbon">
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

