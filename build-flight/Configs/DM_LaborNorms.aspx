<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DM_LaborNorms.aspx.cs" Inherits="Configs_DM_LaborNorms" %>

<%@ Register Src="~/Configs/PopupControl/LaborNormDetailAddOrEdit.ascx" TagPrefix="dx" TagName="LaborNormDetailAddOrEdit" %>
<%@ Register Src="~/UserControls/CopyNormCtrl.ascx" TagPrefix="dx" TagName="CopyNormCtrl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/PageModuleBase.js"></script>
    <script src="../Scripts/LaborNorms.js"></script>
    <style>
        .dxtlControl_MaterialCompact caption, .dxgvTitlePanel_MaterialCompact, .dxgvTable_MaterialCompact caption {
            font-size: 1.25em;
            font-weight: normal;
            padding: 3px 3px 5px;
            text-align: center;
            color: #999999;
            text-align: left;
        }

        .dxgvTitlePanel_Office2010Blue, .dxgvTable_Office2010Blue caption {
            font-weight: bold;
            padding: 3px 3px 5px;
            text-align: left;
            background: #bdd0e7 url(/DXR.axd?r=0_3969-ttc8i) repeat-x left top;
            color: #1e395b;
            border-bottom: 1px solid #8ba0bc;
        }

        caption {
            display: table-caption;
            text-align: -webkit-center;
        }
    </style>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Vertical" Width="100%" Height="100%">
        <Styles>
            <Separator>
                <BorderTop BorderStyle="None" />
                <BorderBottom BorderStyle="None" />
            </Separator>
        </Styles>
        <ClientSideEvents PaneResized="RevCost.ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Name="Menu" Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="float: right">
                            <dx:ASPxButton ID="btnCopy" runat="server" Text="Sao chép định mức" Image-Url="../Content/images/if_simpline_4_2305586.png" AutoPostBack="false">
                                <ClientSideEvents Click="RevCost.ClientCopyButton_Click" />
                            </dx:ASPxButton>
                        </div>
                        <div style="float: left">
                            <div class="title">
                                <asp:Literal ID="Literal1" runat="server" Text="ĐỊNH MỨC HAO PHÍ LAO ĐỘNG THEO SẢN PHẨM" />
                            </div>
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
            <dx:SplitterPane Separator-Visible="False">
                <Panes>
                    <dx:SplitterPane Size="420">
                        <Panes>
                            <dx:SplitterPane Name="GridNormYearPane" Size="200">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="NormYearGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientNormYearGrid" Width="100%" KeyFieldName="NormYearID">
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="ForYear" VisibleIndex="1" Caption="Năm" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2" Caption="Diễn giải" Width="100%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="3" Caption="Trạng thái" Width="90" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <Styles>
                                                <AlternatingRow Enabled="true" />
                                            </Styles>
                                            <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                            <Paddings Padding="0px" />
                                            <Border BorderWidth="1px" />
                                            <BorderBottom BorderWidth="0px" />
                                            <SettingsBehavior AllowFocusedRow="True" />
                                            <SettingsPager PageSize="100" Mode="ShowAllRecords" />
                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientNormYearGrid_FocusedRowChanged" />
                                        </dx:ASPxGridView>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                                <PaneStyle Border-BorderWidth="0">
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                </PaneStyle>
                            </dx:SplitterPane>
                            <dx:SplitterPane Name="ACConfigPane">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="ACConfigGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientACConfigGrid" Width="100%" KeyFieldName="ACConfigID">
                                            <Columns>
                                                <dx:GridViewDataColumn FieldName="AreaCode" VisibleIndex="1" Caption="Chi nhánh" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="Carrier" VisibleIndex="2" Caption="Hãng" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="Network" VisibleIndex="3" Caption="Đường bay" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="AcID" VisibleIndex="4" Caption="Loại tàu bay" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="FltType" VisibleIndex="5" Caption="Nhiệm vụ bay" Width="100%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                            </Columns>
                                            <Styles>
                                                <AlternatingRow Enabled="true" />
                                            </Styles>
                                            <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                            <Paddings Padding="0px" />
                                            <Border BorderWidth="1px" />
                                            <BorderBottom BorderWidth="0px" />
                                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                            <SettingsCommandButton RenderMode="Button"></SettingsCommandButton>
                                            <SettingsPager PageSize="50" Mode="EndlessPaging" />
                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientACConfigGrid_FocusedRowChanged" />
                                        </dx:ASPxGridView>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                                <PaneStyle Border-BorderWidth="0px">
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                </PaneStyle>
                            </dx:SplitterPane>
                        </Panes>
                    </dx:SplitterPane>
                    <dx:SplitterPane Name="GridLaborNormPane">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxGridView ID="LaborNormGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                    ClientInstanceName="ClientLaborNormGrid" Width="100%" KeyFieldName="LaborNormID"
                                    OnCustomCallback="LaborNormGrid_CustomCallback"
                                    OnCustomDataCallback="LaborNormGrid_CustomDataCallback"
                                    OnCustomUnboundColumnData="LaborNormGrid_CustomUnboundColumnData"
                                    OnCustomColumnDisplayText="LaborNormGrid_CustomColumnDisplayText"
                                    OnCustomGroupDisplayText="LaborNormGrid_CustomGroupDisplayText">
                                    <Columns>
                                        <dx:GridViewCommandColumn VisibleIndex="0" Width="150" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                            <HeaderTemplate>
                                                <dx:ASPxButton runat="server" Text="Thêm mới" RenderMode="Link" AutoPostBack="false">
                                                    <Image Url="../Content/images/action/add.gif"></Image>
                                                    <ClientSideEvents Click="RevCost.ClientLaborNormGrid_AddNewButtonClick" />
                                                </dx:ASPxButton>
                                            </HeaderTemplate>

                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="DetailEdit" Text="Edit" Image-Url="../Content/images/action/edit.gif">
                                                    <Styles>
                                                        <Style Paddings-PaddingRight="1px"></Style>
                                                    </Styles>
                                                </dx:GridViewCommandColumnCustomButton>
                                                <dx:GridViewCommandColumnCustomButton ID="DetailDelete" Text="Delete" Image-Url="../Content/images/action/delete.gif">
                                                    <Styles>
                                                        <Style Paddings-PaddingLeft="1px"></Style>
                                                    </Styles>
                                                </dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="ITEM" VisibleIndex="1" Caption="Mã sản phẩm" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ItemName" UnboundType="String" VisibleIndex="2" Caption="Tên sản phẩm" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="PreparationTime" VisibleIndex="3" Caption="TG chuẩn bị kết thúc" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="OperatingTime" VisibleIndex="4" Caption="TG tác nghiệp" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="NumberOfPeople" VisibleIndex="5" Caption="Số người thực hiện" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="CoefficientK" VisibleIndex="6" Caption="Hệ số K" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="NormInMinutes" VisibleIndex="7" Caption="Tổng TG hao phí (phút)" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="NormInHours" VisibleIndex="8" Caption="Tổng TG hao phí (giờ)" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataTextColumn FieldName="ItemGroup" VisibleIndex="9" Caption="Nhóm dịch vụ" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <%--  <dx:GridViewDataTextColumn FieldName="GroupItemName" UnboundType="String" VisibleIndex="10" Caption="Group Name" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>--%>
                                        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="11" Caption="Diễn giải" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                        </dx:GridViewDataTextColumn>

                                        <dx:GridViewDataCheckColumn FieldName="Inactive" VisibleIndex="12" Caption="Ngừng theo dõi" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataCheckColumn>
                                    </Columns>
                                    <Styles>
                                        <AlternatingRow Enabled="true" />
                                    </Styles>
                                    <Settings GroupFormat="{1}" ShowGroupPanel="false" ShowFilterRow="true" ShowFooter="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                    <Paddings Padding="0px" />
                                    <Border BorderWidth="1px" />
                                    <BorderBottom BorderWidth="0px" />
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <SettingsCommandButton RenderMode="Button"></SettingsCommandButton>
                                    <SettingsPager Visible="true" PageSize="100" Mode="ShowPager" />
                                    <TotalSummary>
                                        <dx:ASPxSummaryItem FieldName="PreparationTime" ShowInColumn="PreparationTime" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                        <dx:ASPxSummaryItem FieldName="OperatingTime" ShowInColumn="OperatingTime" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                        <dx:ASPxSummaryItem FieldName="NumberOfPeople" ShowInColumn="NumberOfPeople" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                        <dx:ASPxSummaryItem FieldName="NormInMinutes" ShowInColumn="NormInMinutes" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                        <dx:ASPxSummaryItem FieldName="NormInHours" ShowInColumn="NormInHours" SummaryType="Sum" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                    </TotalSummary>
                                    <ClientSideEvents CustomButtonClick="RevCost.ClientLaborNormGrid_CustomButtonClick"
                                        EndCallback="RevCost.ClientLaborNormGrid_EndCallback" />
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
    </dx:ASPxSplitter>
    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="DataGrid"></dx:ASPxGridViewExporter>

    <dx:ASPxPopupControl ID="LaborNormDetailAddOrEditPopup" runat="server" ClientInstanceName="ClientLaborNormDetailAddOrEditPopup" Width="500px" Height="300px" HeaderText="" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
        <HeaderStyle Font-Bold="True" Font-Size="Medium">
            <Paddings PaddingBottom="5px" PaddingTop="5px" />
        </HeaderStyle>
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                <dx:LaborNormDetailAddOrEdit runat="server" ID="LaborNormDetailAddOrEdit" />
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

     <dx:ASPxPopupControl ID="CopyNormPopup" runat="server" ClientInstanceName="ClientCopyNormPopup" Width="600px" Height="100px"
        HeaderText="Sao chép định mức" ShowFooter="true" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
        <HeaderStyle Font-Bold="True" Font-Size="Medium">
            <Paddings PaddingBottom="5px" PaddingTop="5px" />
        </HeaderStyle>
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:CopyNormCtrl runat="server" ID="CopyNormCtrl" />
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Đóng" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e){{ ClientCopyNormPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApply" runat="server" Text="Chấp nhận" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientApplyCopyButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>

    <dx:ASPxCallback ID="LaborNormCallback" runat="server" ClientInstanceName="ClientLaborNormCallback" OnCallback="LaborNormCallback_Callback">
        <ClientSideEvents CallbackComplete="RevCost.ClientLaborNormCallback_CallbackComplete" />
    </dx:ASPxCallback>
</asp:Content>

