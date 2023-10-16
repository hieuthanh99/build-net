<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SLDoanhthuChiphiCB.aspx.cs" Inherits="Reports_SLDoanhthuChiphiCB" %>

<%@ Register Assembly="DevExpress.XtraReports.v20.2.Web.WebForms, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script>
        function ClientReport_ValueChanged(s, e) {
            var value = s.GetValue();
            if (value == "ChiphiBinhquan") {
                ClientVersion.SetEnabled(true);
            }
            else {
                ClientVersion.SetEnabled(false);
            }
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
                                                            <dx:ListEditItem Value="DTChuyenbay" Text="Sản lượng, doanh thu theo chuyến bay" Selected="true" />
                                                            <dx:ListEditItem Value="ChitietDTChuyenbay" Text="Chi tiết Sản lượng, doanh thu theo chuyến bay" />
                                                            <dx:ListEditItem Value="ChiphiBinhquan" Text="Chi phí bình quân của 1 loại máy bay" />
                                                            <dx:ListEditItem Value="TonDTChiphi" Text="Tổng doanh thu, chi phí của 1 loại máy bay theo Hãng" />
                                                            <dx:ListEditItem Value="PhanLoaiChiphi" Text="Chi phí theo dòng phân loại chi phí (theo chuyến bay)" />
                                                            <dx:ListEditItem Value="PhanNhomChiphi" Text="Phân loại Chi phí theo nhóm chi phí (theo chuyến bay)" />
                                                            <dx:ListEditItem Value="PhanLoaiChiphi2" Text="Chi phí theo dòng phân loại chi phí (theo mục chi)" />
                                                            <dx:ListEditItem Value="PhanNhomChiphi2" Text="Phân loại Chi phí theo nhóm chi phí (theo mục chi)" />
                                                            <dx:ListEditItem Value="DTKhongChuyenbay" Text="Doanh thu không theo chuyến bay" />
                                                        </Items>
                                                        <Border BorderStyle="None" />
                                                        <%--<ClientSideEvents ValueChanged="ClientReport_ValueChanged" />--%>
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
                                                    <dx:ASPxComboBox ID="cboVersion" runat="server" ClientInstanceName="ClientVersion" ValueType="System.Int32" Width="150px" OnInit="cboVersion_Init">
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
                                                    <dx:ASPxComboBox ID="cboAreaCode" runat="server" ValueType="System.String" Width="100px">
                                                        <Items>
                                                            <dx:ListEditItem Value="ALL" Text="--ALL--" />
                                                            <dx:ListEditItem Value="SGN" Text="SGN" />
                                                            <dx:ListEditItem Value="HAN" Text="HAN" />
                                                            <dx:ListEditItem Value="DAD" Text="DAD" />
                                                        </Items>
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
                                                    <dx:ASPxTokenBox ID="cboCarrier" runat="server" Width="150px" OnInit="cboCarrier_Init">
                                                    </dx:ASPxTokenBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Network">
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
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Pax Type">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTokenBox ID="cboFltType" runat="server" Width="150px" OnInit="cboFltType_Init">
                                                    </dx:ASPxTokenBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Cost Type">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cboCostType" runat="server" ValueType="System.String" Width="150px">
                                                        <Items>
                                                            <dx:ListEditItem Value="ALL" Text="--ALL--" />
                                                            <dx:ListEditItem Value="ALLOCATED" Text="ALLOCATED" />
                                                            <dx:ListEditItem Value="NONE" Text="NONE" />
                                                        </Items>
                                                    </dx:ASPxComboBox>
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
                                                <ClientSideEvents Click="function(s, e) {{ 
                                                    var value = ClientReport.GetValue();
                                                    if (value == 'ChiphiBinhquan' && ClientVersion.GetValue() == null) {
                                                       alert('Version must be entered!');
                                                        return;
                                                    }
                                                    ClientReportViewer.Refresh(); }}" />
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
                        <dx:ASPxWebDocumentViewer ID="ReportViewer" runat="server" Width="100%" Height="100%"
                            ClientInstanceName="ReportViewer" ReportTypeName="ChitietOTPChuyenDen" StylesSplitter-SidePaneWidth="208">
                         

                        </dx:ASPxWebDocumentViewer>
                    </dx:SplitterContentControl>
                </ContentCollection>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
</asp:Content>

