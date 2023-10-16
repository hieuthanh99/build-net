<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RevCostReport.aspx.cs" Inherits="Reports_RevCostReport" %>

<%@ Register Assembly="DevExpress.Web.ASPxSpreadsheet.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpreadsheet" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../Scripts/PageModuleBase.js"></script>
    <script>
        function ClientReport_ValueChanged(s, e) {
            var value = s.GetValue();
            if (value == "DTKhongChuyenbay" || value == "CTDTKhongTheoCB") {
                ClientVersion.SetValue(null);
                ClientVersion.SetEnabled(false);
            }
            else {
                ClientVersion.SetEnabled(true);
            }
        }

        function ClientPrintReportButton_Click(s, e) {
            var value = ClientReport.GetValue();
            if (value != "DTKhongChuyenbay" && value != "CTDTKhongTheoCB") {
                if (ClientVersion.GetValue() == null) {
                    ClientVersion.Focus();

                    alert("Bạn phải chọn một version.");
                    return;
                }
            }

            DoCallback(ClientViewReportPanel, function () {
                ClientViewReportPanel.PerformCallback('GenerateExcel');
            });
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
                                                            <dx:ListEditItem Value="DTChuyenbay" Text="1. Sản lượng, doanh thu theo chuyến bay" Selected="true" />
                                                            <dx:ListEditItem Value="ChitietDTChuyenbay" Text="2. Chi tiết Sản lượng, doanh thu theo chuyến bay" />
                                                            <dx:ListEditItem Value="ChiphiBinhquan" Text="3. Chi phí bình quân của 1 loại máy bay" />
                                                            <dx:ListEditItem Value="TonDTChiphi" Text="4. Tổng DT, CP của 1 loại máy bay theo Hãng" />
                                                            <%--<dx:ListEditItem Value="PhanLoaiChiphi" Text="Chi phí theo dòng phân loại chi phí (theo chuyến bay)" />
                                                            <dx:ListEditItem Value="PhanNhomChiphi" Text="Phân loại Chi phí theo nhóm chi phí (theo chuyến bay)" />--%>
                                                            <dx:ListEditItem Value="PhanLoaiChiphi2" Text="5. Chi phí theo dòng phân loại(TT, SXC, QL, BH)" />
                                                            <dx:ListEditItem Value="PhanNhomChiphi2" Text="6. Phân loại Chi phí theo nhóm(8 loại chi phí lớn)" />
                                                            <dx:ListEditItem Value="PhanNhomDoanhThu" Text="7. Doanh thu, chi phí theo 8 nhóm yếu tố" />
                                                            <dx:ListEditItem Value="DTKhongChuyenbay" Text="8. Doanh thu không theo chuyến bay" />
                                                            <dx:ListEditItem Value="CTDTKhongTheoCB" Text="9. Chi tiết doanh thu không theo chuyến bay" />
                                                        </Items>
                                                        <Border BorderStyle="None" />
                                                        <ClientSideEvents ValueChanged="ClientReport_ValueChanged" />
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
                                                    <dx:ASPxComboBox ID="cboVersion" runat="server" ClientInstanceName="ClientVersion" ValueType="System.Int32" Width="100%" OnInit="cboVersion_Init">
                                                        <%-- <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="Version is required" />
                                                        </ValidationSettings>--%>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Area">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cboAreaCode" runat="server" ValueType="System.String" Width="100%" OnInit="cboAreaCode_Init">
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
                                        <dx:LayoutItem Caption="Carrier">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTokenBox ID="cboCarrier" runat="server" Width="100%" OnInit="cboCarrier_Init">
                                                    </dx:ASPxTokenBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Network">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cboNetwork" runat="server" ValueType="System.String" Width="100%">
                                                        <Items>
                                                            <dx:ListEditItem Value="ALL" Text="--ALL--" />
                                                            <dx:ListEditItem Value="INT" Text="Quốc tế" />
                                                            <dx:ListEditItem Value="DOM" Text="Quốc nội" />
                                                        </Items>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Pax Type">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTokenBox ID="cboFltType" runat="server" Width="100%" OnInit="cboFltType_Init">
                                                    </dx:ASPxTokenBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Cost Type">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cboCostType" runat="server" ValueType="System.String" Width="100%">
                                                        <Items>
                                                            <dx:ListEditItem Value="ALL" Text="--ALL--" />
                                                            <dx:ListEditItem Value="ALLOCATED" Text="ALLOCATED" />
                                                            <dx:ListEditItem Value="NONE" Text="NONE" />
                                                        </Items>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption=" ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxCheckBox ID="chkNotProfitable" runat="server" Checked="false" ValueType="System.String" ValueChecked="Y" ValueUnchecked="N" AllowGrayed="false" Text="The flight is not profitable(Rev-Cost<0)"></dx:ASPxCheckBox>
                                                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="(Apply with reports 1, 2, 4)"></dx:ASPxLabel>
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

