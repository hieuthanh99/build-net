<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DM_EquipmentDepreNormsNew.aspx.cs" Inherits="Configs_DM_EquipmentDepreNormsNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <style>
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

        .dxtcLite_Office2010Blue > .dxtc-content {
            background: White none;
            border: 1px solid #859ebf;
            float: left;
            clear: left;
            overflow: hidden;
            padding: 5px 0px 0px 0px;
        }

        .dxsplControl_Office2010Blue .dxsplLCC {
            padding: 0px;
        }
    </style>

    <script src="../Scripts/PageModuleBase.js"></script>
    <script src="../Scripts/EDepreciationNormsNew.js"></script>
    <dx:ASPxSplitter ID="ASPxSplitter1" runat="server" Orientation="Vertical" Width="100%" Height="100%" FullscreenMode="true" ClientInstanceName="ClientSplitter">
        <ClientSideEvents PaneResized="RevCost.ClientSplitter_PaneResized" />
        <Styles>
            <Separator>
                <BorderTop BorderStyle="None" />
                <BorderBottom BorderStyle="None" />
            </Separator>
        </Styles>
        <Panes>
            <dx:SplitterPane Name="Menu" Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="float: right">
                        </div>
                        <div style="float: left">
                            <div class="title">
                                <asp:Literal ID="Literal2" runat="server" Text="CHI PHÍ KHẤU HAO TRANG THIẾT BỊ" />
                            </div>
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
            <dx:SplitterPane Separator-Visible="False" Name="PageControlPane">
                <Panes>
                    <dx:SplitterPane Size="700">
                        <Panes>
                            <dx:SplitterPane Name="GridNormYearPane" Size="200">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="NormYearGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientNormYearGrid" Width="100%" KeyFieldName="NormYearID"
                                            Caption="NĂM ĐỊNH MỨC">
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
                                            <SettingsResizing ColumnResizeMode="Control" />
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
                            <dx:SplitterPane Name="ItemPane">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="ItemGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientItemGrid" Width="100%" KeyFieldName="ItemID"
                                            OnCustomColumnDisplayText="ItemGrid_CustomColumnDisplayText"
                                            Caption="TRANG THIẾT BỊ">
                                            <Columns>
                                                <dx:GridViewDataColumn FieldName="ITEM" VisibleIndex="1" Caption="Mã loại TTB" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="Name" VisibleIndex="2" Caption="Tên loại TTB" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="FuelType" VisibleIndex="3" Caption="Loại NL" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="GroupItemName" UnboundType="String" VisibleIndex="4" Caption="Nhóm TTB" Width="50%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                                            <SettingsResizing ColumnResizeMode="Control" />
                                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                            <SettingsCommandButton RenderMode="Button"></SettingsCommandButton>
                                            <SettingsPager PageSize="50" Mode="EndlessPaging" />
                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientItemGrid_FocusedRowChanged" />
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
                    <dx:SplitterPane>
                        <Panes>
                            <dx:SplitterPane>
                                <Panes>
                                    <dx:SplitterPane Name="EDNormPane">
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxGridView ID="EDNormGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                    ClientInstanceName="ClientEDNormGrid" Width="100%" KeyFieldName="EDNormID"
                                                    OnCustomCallback="EDNormGrid_CustomCallback"
                                                    OnBatchUpdate="EDNormGrid_BatchUpdate"
                                                    Caption="HÃNG VẬN CHUYỂN">
                                                    <Columns>
                                                        <dx:GridViewCommandColumn VisibleIndex="0" Width="100" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                                            <HeaderTemplate>
                                                                <dx:ASPxButton runat="server" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                                                    <Image Url="../Content/images/action/add.gif"></Image>
                                                                    <ClientSideEvents Click="RevCost.ClientEDNormGrid_AddNewButtonClick" />
                                                                </dx:ASPxButton>
                                                            </HeaderTemplate>
                                                            <CustomButtons>
                                                                <dx:GridViewCommandColumnCustomButton ID="EDNormGridDelete" Text="Xóa" Image-Url="../Content/images/action/delete.gif">
                                                                    <Styles>
                                                                        <Style Paddings-PaddingLeft="1px"></Style>
                                                                    </Styles>
                                                                </dx:GridViewCommandColumnCustomButton>
                                                            </CustomButtons>
                                                        </dx:GridViewCommandColumn>
                                                        <dx:GridViewDataComboBoxColumn FieldName="AreaCode" VisibleIndex="2" Caption="Chi nhánh" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <CellStyle Wrap="True"></CellStyle>
                                                            <PropertiesComboBox>
                                                                <Items>
                                                                    <dx:ListEditItem Value="SGN" Text="SGN" />
                                                                    <dx:ListEditItem Value="HAN" Text="HAN" />
                                                                    <dx:ListEditItem Value="DAD" Text="DAD" />
                                                                </Items>
                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                    <RequiredField IsRequired="true" ErrorText="Chi nhánh bắt buộc nhập giá trị" />
                                                                </ValidationSettings>
                                                            </PropertiesComboBox>
                                                        </dx:GridViewDataComboBoxColumn>

                                                        <dx:GridViewDataComboBoxColumn FieldName="Carrier" VisibleIndex="3" Caption="Hãng" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <CellStyle Wrap="True"></CellStyle>

                                                        </dx:GridViewDataComboBoxColumn>

                                                        <%--  <dx:GridViewDataSpinEditColumn FieldName="Amount" VisibleIndex="5" Caption="Chi phí khấu hao/(năm)" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <CellStyle Wrap="True"></CellStyle>
                                                            <EditFormSettings Visible="False" />
                                                            <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                            <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                        </dx:GridViewDataSpinEditColumn>--%>
                                                        <dx:GridViewDataComboBoxColumn FieldName="CurrencyCode" VisibleIndex="6" Caption="Loại tiền" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <CellStyle Wrap="True"></CellStyle>
                                                            <PropertiesComboBox>
                                                                <Items>
                                                                    <dx:ListEditItem Value="VND" Text="VND" />
                                                                    <dx:ListEditItem Value="USD" Text="USD" />
                                                                </Items>
                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                    <RequiredField IsRequired="true" ErrorText="Loại tiền bắt buộc nhập giá trị" />
                                                                </ValidationSettings>
                                                            </PropertiesComboBox>
                                                        </dx:GridViewDataComboBoxColumn>
                                                        <dx:GridViewDataSpinEditColumn FieldName="Frequency" VisibleIndex="7" Caption="Tần suất sử dụng (%)" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <CellStyle Wrap="True"></CellStyle>
                                                            <PropertiesSpinEdit DisplayFormatString="N2">
                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                    <RequiredField IsRequired="true" ErrorText="Tần suất sử dụng bắt buộc nhập giá trị" />
                                                                </ValidationSettings>
                                                            </PropertiesSpinEdit>
                                                            <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                        </dx:GridViewDataSpinEditColumn>

                                                        <dx:GridViewDataColumn FieldName="Description" VisibleIndex="9" Caption="Diễn giải" Width="500" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <CellStyle Wrap="True"></CellStyle>
                                                        </dx:GridViewDataColumn>
                                                    </Columns>
                                                    <Styles>
                                                        <AlternatingRow Enabled="true" />
                                                    </Styles>
                                                    <Settings GroupFormat="{1}" ShowGroupPanel="false" ShowFilterRow="true" ShowFooter="false" ShowStatusBar="Visible" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                                    <Paddings Padding="0px" />
                                                    <Border BorderWidth="1px" />
                                                    <BorderBottom BorderWidth="0px" />
                                                    <SettingsResizing ColumnResizeMode="Control" />
                                                    <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                                    <SettingsCommandButton RenderMode="Button"></SettingsCommandButton>
                                                    <SettingsPager Visible="true" PageSize="100" Mode="ShowAllRecords" />
                                                    <SettingsEditing Mode="Batch">
                                                        <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                                                    </SettingsEditing>
                                                    <TotalSummary>
                                                        <dx:ASPxSummaryItem FieldName="Amount" ShowInColumn="Amount" SummaryType="Sum" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                    </TotalSummary>
                                                    <Templates>
                                                        <StatusBar>
                                                            <div style="float: left">
                                                                <dx:ASPxButton runat="server" Text="LUU THAY ÐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                                    <ClientSideEvents Click="RevCost.ClientSaveDataGridButton_Click" />
                                                                    <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                                                </dx:ASPxButton>
                                                                &nbsp;
                                                                <dx:ASPxButton runat="server" Text="HỦY THAY ÐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                                    <ClientSideEvents Click="RevCost.ClientCancelDataGridButton_Click" />
                                                                    <Image Url="../Content/images/action/undo.png" Height="16"></Image>
                                                                </dx:ASPxButton>
                                                            </div>
                                                            <div style="float: right">
                                                                <dx:ASPxButton runat="server" Text="PHÂN BỔ CHI PHÍ" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                                    <ClientSideEvents Click="RevCost.ClientCalculateUnitPriceButton_Click" />
                                                                    <Image Url="../Content/images/configs.png" Height="16"></Image>
                                                                </dx:ASPxButton>
                                                            </div>
                                                        </StatusBar>
                                                    </Templates>
                                                    <ClientSideEvents
                                                        FocusedRowChanged="RevCost.ClientEDNormGrid_FocusedRowChanged"
                                                        CustomButtonClick="RevCost.ClientEDNormGrid_CustomButtonClick"
                                                        EndCallback="RevCost.ClientEDNormGrid_EndCallback" />
                                                </dx:ASPxGridView>
                                            </dx:SplitterContentControl>
                                        </ContentCollection>
                                        <PaneStyle Border-BorderWidth="0px">
                                            <BorderTop BorderWidth="0px"></BorderTop>
                                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                        </PaneStyle>
                                    </dx:SplitterPane>
                                    <dx:SplitterPane Size="500" Name="CostDetailPane">
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxGridView ID="DepreCostDetailGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                    ClientInstanceName="ClientDepreCostDetailGrid" Width="100%" KeyFieldName="DetailID"
                                                    OnCustomCallback="DepreCostDetailGrid_CustomCallback"
                                                    OnBatchUpdate="DepreCostDetailGrid_BatchUpdate"
                                                    Caption="CHI TIẾT THÁNG">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="ForMonth" VisibleIndex="2" Caption="Tháng" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <CellStyle Wrap="True"></CellStyle>

                                                            <EditFormSettings Visible="False" />
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataSpinEditColumn FieldName="PlanAmount" VisibleIndex="3" Caption="Chi phí KH" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <CellStyle Wrap="True"></CellStyle>
                                                            <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                            <PropertiesSpinEdit DisplayFormatString="N2">
                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                                </ValidationSettings>
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
                                                        <dx:GridViewDataSpinEditColumn FieldName="EstimateAmount" VisibleIndex="3" Caption="Chi phí ước" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <CellStyle Wrap="True"></CellStyle>
                                                            <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                            <PropertiesSpinEdit DisplayFormatString="N2">
                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                                </ValidationSettings>
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>

                                                        <dx:GridViewDataSpinEditColumn FieldName="ActualAmount" VisibleIndex="3" Caption="Chi phí TH" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <CellStyle Wrap="True"></CellStyle>
                                                            <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                            <PropertiesSpinEdit DisplayFormatString="N2">
                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                                </ValidationSettings>
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
                                                    </Columns>
                                                    <Styles>
                                                        <AlternatingRow Enabled="true" />
                                                    </Styles>
                                                    <Settings GroupFormat="{1}" ShowGroupPanel="false" ShowFilterRow="true" ShowStatusBar="Hidden" ShowFooter="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                                    <Paddings Padding="0px" />
                                                    <Border BorderWidth="1px" />
                                                    <BorderBottom BorderWidth="0px" />
                                                    <SettingsResizing ColumnResizeMode="Control" />
                                                    <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                                    <SettingsCommandButton RenderMode="Button"></SettingsCommandButton>
                                                    <SettingsPager Visible="true" PageSize="100" Mode="ShowAllRecords" />
                                                    <SettingsEditing Mode="Batch">
                                                        <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                                                    </SettingsEditing>
                                                    <TotalSummary>
                                                        <dx:ASPxSummaryItem FieldName="PlanAmount" ShowInColumn="PlanAmount" SummaryType="Sum" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                        <dx:ASPxSummaryItem FieldName="EstimateAmount" ShowInColumn="EstimateAmount" SummaryType="Sum" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                        <dx:ASPxSummaryItem FieldName="ActualAmount" ShowInColumn="ActualAmount" SummaryType="Sum" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                    </TotalSummary>
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

                            <dx:SplitterPane Name="UnitPricePane" Size="350">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="UnitPriceGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientUnitPriceGrid" Width="100%" KeyFieldName="UnitPriceID"
                                            OnCustomCallback="UnitPriceGrid_CustomCallback"
                                            OnCustomColumnDisplayText="UnitPriceGrid_CustomColumnDisplayText"
                                            Caption="CHI PHÍ KHẤU HAO CHO MỘT CHUYẾN BAY THEO HÃNG">
                                            <Columns>
                                                <%--<dx:GridViewCommandColumn ShowSelectCheckbox="true" VisibleIndex="0" Width="55" SelectAllCheckboxMode="AllPages"></dx:GridViewCommandColumn>--%>

                                                <dx:GridViewDataComboBoxColumn FieldName="VersionID" VisibleIndex="1" Caption="Version sản lượng" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataComboBoxColumn>

                                                <dx:GridViewDataSpinEditColumn FieldName="ForMonth" VisibleIndex="3" Caption="Tháng" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataColumn FieldName="AreaCode" VisibleIndex="4" Caption="Chi nhánh" Width="85" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="Carrier" VisibleIndex="5" Caption="Hãng" Width="85" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="Network" VisibleIndex="6" Caption="Mạng bay" Width="85" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="Aircraft" VisibleIndex="7" Caption="Loại tàu" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="EquipmentNbr" VisibleIndex="8" Caption="Số lượng TTB" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Quantity" VisibleIndex="9" Caption="Sản lượng" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="UnitPrice" VisibleIndex="10" Caption="Ðơn giá" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>

                                                <dx:GridViewDataColumn FieldName="Description" VisibleIndex="11" Caption="Diễn giải" Width="800" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                            </Columns>
                                            <Styles>
                                                <AlternatingRow Enabled="true" />
                                            </Styles>
                                            <Settings GroupFormat="{1}" ShowGroupPanel="false" ShowFilterRow="true" ShowStatusBar="Hidden" ShowFooter="false" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                            <Paddings Padding="0px" />
                                            <Border BorderWidth="1px" />
                                            <BorderBottom BorderWidth="0px" />
                                            <SettingsResizing ColumnResizeMode="Control" />
                                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                            <SettingsCommandButton RenderMode="Button"></SettingsCommandButton>
                                            <SettingsPager Visible="true" PageSize="100" Mode="ShowAllRecords" />

                                            <TotalSummary>
                                                <dx:ASPxSummaryItem FieldName="Quantity" ShowInColumn="Quantity" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                            </TotalSummary>
                                            <ClientSideEvents
                                                EndCallback="RevCost.ClientUnitPriceGrid_EndCallback" />
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
                </Panes>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
    <dx:ASPxPopupControl ID="CalcUnitPricePopup" runat="server" ClientInstanceName="ClientCalcUnitPricePopup" Width="500px" Height="150px"
        HeaderText="Tham số phân bổ chi phí khấu hao trang thiết bị" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ShowFooter="true">
        <HeaderStyle Font-Bold="True" Font-Size="Medium">
            <Paddings PaddingBottom="5px" PaddingTop="5px" />
        </HeaderStyle>
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:ASPxFormLayout ID="CalcUnitPriceForm" runat="server" ColCount="2" RequiredMarkDisplayMode="None" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientMasterNormForm"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="Version sản lượng" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cboCalcUnitPriceVersion" runat="server" ClientInstanceName="ClientCalcUnitPriceVersion" Width="100%" AutoResizeWithContainer="true" OnCallback="cboCalcUnitPriceVersion_Callback">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="true" ErrorText="*" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Chi nhánh" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cboCalcUnitPriceArea" runat="server" ClientInstanceName="ClientCalcUnitPriceArea" Width="100%" AutoResizeWithContainer="true" OnInit="cboCalcUnitPriceArea_Init">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="true" ErrorText="*" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Từ tháng">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit ID="seCalcUnitPriceFromMonth" runat="server" ClientInstanceName="ClientCalcUnitPriceFromMonth" MinValue="1" MaxValue="12" Width="120" AutoResizeWithContainer="true">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="true" ErrorText="*" />
                                        </ValidationSettings>
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Ðến tháng">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit ID="seCalcUnitPriceToMonth" runat="server" ClientInstanceName="ClientCalcUnitPriceToMonth" MinValue="1" MaxValue="12" Width="120" AutoResizeWithContainer="true">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="true" ErrorText="*" />
                                        </ValidationSettings>
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:ASPxFormLayout>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCalcUnitPriceCancel" runat="server" Text="ĐÓNG" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientCalcUnitPricePopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCalcUnitPriceApply" runat="server" Text="CHẤP NHẬN" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientCalcUnitPriceButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientCalcUnitPricePopup_Shown" />
    </dx:ASPxPopupControl>
</asp:Content>

