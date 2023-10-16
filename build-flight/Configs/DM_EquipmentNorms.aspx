<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DM_EquipmentNorms.aspx.cs" Inherits="Configs_DM_EquipmentNorms" %>

<%@ Register Src="~/Configs/PopupControl/EquipmentTimeDetailNormAddOrEdit.ascx" TagPrefix="dx" TagName="EquipmentTimeDetailNormAddOrEdit" %>
<%@ Register Src="~/UserControls/CopyNormCtrl.ascx" TagPrefix="dx" TagName="CopyNormCtrl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/PageModuleBase.js"></script>
    <script src="../Scripts/EquipmentNorm.js"></script>
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
                                <asp:Literal ID="Literal1" runat="server" Text="ĐỊNH MỨC THỜI GIAN SỬ DỤNG TTB PHỤC VỤ" />
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
                    <dx:SplitterPane Name="GridEquipmentNormPane">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxGridView ID="EquipmentNormGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                    ClientInstanceName="ClientEquipmentNormGrid" Width="100%" KeyFieldName="EquipmentNormID"
                                    OnCustomCallback="EquipmentNormGrid_CustomCallback"
                                    OnCustomDataCallback="EquipmentNormGrid_CustomDataCallback"
                                    OnCustomUnboundColumnData="EquipmentNormGrid_CustomUnboundColumnData"
                                    OnCustomColumnDisplayText="EquipmentNormGrid_CustomColumnDisplayText"
                                    OnCustomGroupDisplayText="EquipmentNormGrid_CustomGroupDisplayText">
                                    <Columns>
                                        <dx:GridViewCommandColumn VisibleIndex="0" Width="150" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                            <HeaderTemplate>
                                                <dx:ASPxButton runat="server" Text="Thêm mới" RenderMode="Link" AutoPostBack="false">
                                                    <Image Url="../Content/images/action/add.gif"></Image>
                                                    <ClientSideEvents Click="RevCost.ClientEquipmentNormGrid_AddNewButtonClick" />
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
                                        <dx:GridViewDataTextColumn FieldName="ITEM" VisibleIndex="1" Caption="Mã thiết bị" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ItemName" UnboundType="String" VisibleIndex="2" Caption="Tên thiết bị" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="NumberOfEquipment" VisibleIndex="3" Caption="Số lượng TTB" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="PreparationTime" VisibleIndex="4" Caption="TG chuẩn bị" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                            <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="MovingTime" VisibleIndex="5" Caption="TG di chuyển" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                            <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="WaitingTime" VisibleIndex="6" Caption="TG chờ" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                            <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="ApproachTime" VisibleIndex="7" Caption="TG tiếp cận" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                            <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="TimeServedAtPlane" VisibleIndex="8" Caption="TG p/v trên MB" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                            <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="TimeServedAtStore" VisibleIndex="9" Caption="TG p/v tại kho" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                            <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="TimeServedAtBC" VisibleIndex="10" Caption="TG p/v tại BC" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                            <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="NightServedTime" VisibleIndex="11" Caption="TG p/v đêm" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                            <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="CleaningTime" VisibleIndex="12" Caption="TG thu dọn" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                            <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="TotalTime" VisibleIndex="13" Caption="Tổng TG" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                            <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="Frequency" VisibleIndex="14" Caption="Tần suất" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                            <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataTextColumn FieldName="GroupItem" VisibleIndex="15" Caption="Nhóm dịch vụ" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <%--  <dx:GridViewDataTextColumn FieldName="GroupItemName" UnboundType="String" VisibleIndex="10" Caption="Group Name" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>--%>
                                        <%--  <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="11" Caption="Diễn giải" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>

                                        <dx:GridViewDataCheckColumn FieldName="Inactive" VisibleIndex="12" Caption="Ngừng theo dõi" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataCheckColumn>--%>
                                    </Columns>
                                    <Styles>
                                        <AlternatingRow Enabled="true" />
                                    </Styles>
                                    <Settings GroupFormat="{1}" ShowGroupPanel="false" ShowFooter="true" ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                    <Paddings Padding="0px" />
                                    <Border BorderWidth="1px" />
                                    <BorderBottom BorderWidth="0px" />
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <SettingsCommandButton RenderMode="Button"></SettingsCommandButton>
                                    <SettingsPager Visible="true" PageSize="100" Mode="ShowPager" />
                                    <TotalSummary>
                                        <dx:ASPxSummaryItem FieldName="NumberOfEquipment" ShowInColumn="NumberOfEquipment" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                        <dx:ASPxSummaryItem FieldName="PreparationTime" ShowInColumn="PreparationTime" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                        <dx:ASPxSummaryItem FieldName="MovingTime" ShowInColumn="MovingTime" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                        <dx:ASPxSummaryItem FieldName="WaitingTime" ShowInColumn="WaitingTime" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                        <dx:ASPxSummaryItem FieldName="ApproachTime" ShowInColumn="ApproachTime" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                        <dx:ASPxSummaryItem FieldName="TimeServedAtPlane" ShowInColumn="TimeServedAtPlane" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                        <dx:ASPxSummaryItem FieldName="TimeServedAtStore" ShowInColumn="TimeServedAtStore" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                        <dx:ASPxSummaryItem FieldName="TimeServedAtBC" ShowInColumn="TimeServedAtBC" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                        <dx:ASPxSummaryItem FieldName="NightServedTime" ShowInColumn="NightServedTime" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                        <dx:ASPxSummaryItem FieldName="CleaningTime" ShowInColumn="CleaningTime" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                        <dx:ASPxSummaryItem FieldName="TotalTime" ShowInColumn="TotalTime" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                    </TotalSummary>
                                    <ClientSideEvents CustomButtonClick="RevCost.ClientEquipmentNormGrid_CustomButtonClick"
                                        EndCallback="RevCost.ClientEquipmentNormGrid_EndCallback" />
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

    <dx:ASPxPopupControl ID="DetailNormAddOrEditPopup" runat="server" ClientInstanceName="ClientDetailNormAddOrEditPopup" Width="600px" Height="250px" HeaderText="" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
        <HeaderStyle Font-Bold="True" Font-Size="Medium">
            <Paddings PaddingBottom="5px" PaddingTop="5px" />
        </HeaderStyle>
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                <dx:EquipmentTimeDetailNormAddOrEdit runat="server" ID="EquipmentTimeDetailNormAddOrEdit" />
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

    <dx:ASPxCallback ID="EquipmentNormCallback" runat="server" ClientInstanceName="ClientEquipmentNormCallback" OnCallback="EquipmentNormCallback_Callback">
        <ClientSideEvents CallbackComplete="RevCost.ClientEquipmentNormCallback_CallbackComplete" />
    </dx:ASPxCallback>
</asp:Content>

