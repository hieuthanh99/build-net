<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DM_DepreCostNorms.aspx.cs" Inherits="Configs_DM_DepreCostNorms" %>

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
    <script src="../Scripts/DepreCostNorms.js"></script>

    <dx:ASPxSplitter ID="ASPxSplitter1" runat="server" Orientation="Vertical" Width="100%" Height="100%" ClientInstanceName="ClientSplitter">
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
                                <asp:Literal ID="Literal2" runat="server" Text="CHI PHÍ KHẤU HAO/CHI PHÍ THUÊ TRANG THIẾT BỊ" />
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
                    <dx:SplitterPane Size="800">
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
                                <PaneStyle Border-BorderWidth="1px">
                                    <BorderTop BorderWidth="1px"></BorderTop>
                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                </PaneStyle>
                            </dx:SplitterPane>

                            <dx:SplitterPane Name="ItemPane">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="DepreCostGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientDepreCostGrid" Width="100%" KeyFieldName="DepreCostID"
                                            OnCustomColumnDisplayText="DepreCostGrid_CustomColumnDisplayText"
                                            OnCustomCallback="DepreCostGrid_CustomCallback"
                                            OnBatchUpdate="DepreCostGrid_BatchUpdate" Caption="CHI PHÍ TRANG THIẾT BỊ">
                                            <Columns>
                                                <%-- <dx:GridViewDataColumn FieldName="AreaCode" VisibleIndex="1" Caption="Chi nhánh" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataColumn>--%>
                                                <dx:GridViewDataComboBoxColumn FieldName="AreaCode" VisibleIndex="1" Caption="Chi nhánh" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesComboBox>
                                                        <Items>
                                                            <dx:ListEditItem Value="SGN" Text="SGN" />
                                                            <dx:ListEditItem Value="HAN" Text="HAN" />
                                                            <dx:ListEditItem Value="DAD" Text="DAD" />
                                                        </Items>
                                                    </PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>
                                                <dx:GridViewDataComboBoxColumn FieldName="ItemType" VisibleIndex="2" Caption="Loại tài sản" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesComboBox>
                                                        <Items>
                                                            <dx:ListEditItem Value="Owned" Text="Tự mua" />
                                                            <dx:ListEditItem Value="Hired" Text="Thuê ngoài" />
                                                        </Items>
                                                    </PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>
                                                <dx:GridViewDataColumn FieldName="ItemName" VisibleIndex="3" Caption="Tên loại TTB" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataColumn>

                                                <dx:GridViewDataSpinEditColumn FieldName="Amount" Visible="false" VisibleIndex="4" Caption="Số tiền" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataComboBoxColumn FieldName="DepreCostType" Visible="false" VisibleIndex="5" Caption="Loại phân bổ" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesComboBox>
                                                        <Items>
                                                            <dx:ListEditItem Value="Y" Text="Theo năm" />
                                                            <dx:ListEditItem Value="M" Text="Theo tháng" />
                                                        </Items>
                                                    </PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>
                                                <dx:GridViewDataColumn FieldName="GroupItemName" UnboundType="String" VisibleIndex="6" Caption="Nhóm TTB" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="Description" VisibleIndex="7" Caption="Diễn giải" Width="400" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                            </Columns>
                                            <Styles>
                                                <AlternatingRow Enabled="true" />
                                            </Styles>
                                            <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" ShowStatusBar="Visible" ShowFooter="false" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                            <Paddings Padding="0px" />
                                            <Border BorderWidth="1px" />
                                            <BorderBottom BorderWidth="0px" />
                                            <SettingsResizing ColumnResizeMode="Control" />
                                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                            <SettingsCommandButton RenderMode="Button"></SettingsCommandButton>
                                            <SettingsPager PageSize="50" Mode="ShowAllRecords" />
                                            <SettingsEditing Mode="Batch">
                                                <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                                            </SettingsEditing>
                                            <Templates>
                                                <StatusBar>
                                                    <div style="float: right">
                                                        <dx:ASPxButton runat="server" Text="LƯU THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16" Font-Bold="true">
                                                            <ClientSideEvents Click="RevCost.ClientSaveDataGridButton_Click" />
                                                            <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                                        </dx:ASPxButton>
                                                        &nbsp;
                                                        <dx:ASPxButton runat="server" Text="HỦY THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16" Font-Bold="true">
                                                            <ClientSideEvents Click="RevCost.ClientCancelDataGridButton_Click" />
                                                            <Image Url="../Content/images/action/undo.png" Height="16"></Image>
                                                        </dx:ASPxButton>
                                                    </div>
                                                </StatusBar>
                                            </Templates>
                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientDepreCostGrid_FocusedRowChanged"
                                                EndCallback="RevCost.ClientDepreCostGrid_EndCallback" />
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
                            <dx:SplitterPane Size="430">
                                <Panes>
                                    <dx:SplitterPane>
                                        <Panes>
                                            <dx:SplitterPane Size="50" Separator-Visible="False">
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
                                                        &nbsp;
                                                        <dx:ASPxComboBox ID="cboQuantityVersion" runat="server" ValueType="System.Int32" Width="350px" ClientInstanceName="ClientQuantityVersion" Font-Bold="true" Caption="Version sản lượng" OnCallback="cboQuantityVersion_Callback">
                                                            <ClientSideEvents ValueChanged="RevCost.ClientQuantityVersion_ValueChanged" EndCallback="RevCost.ClientQuantityVersion_EndCallback" />
                                                        </dx:ASPxComboBox>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                                <PaneStyle Border-BorderWidth="1px">
                                                    <BorderTop BorderWidth="1px"></BorderTop>
                                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                                </PaneStyle>
                                            </dx:SplitterPane>
                                            <dx:SplitterPane Separator-Visible="False">
                                                <Panes>
                                                    <dx:SplitterPane Size="500" Name="CostDetailPane">
                                                        <ContentCollection>
                                                            <dx:SplitterContentControl>

                                                                <dx:ASPxGridView ID="CostDetailGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                                    ClientInstanceName="ClientCostDetailGrid" Width="100%" KeyFieldName="DepreCostDetailID"
                                                                    OnCustomCallback="CostDetailGrid_CustomCallback"
                                                                    OnBatchUpdate="CostDetailGrid_BatchUpdate"
                                                                    Caption="CHI TIẾT THÁNG">
                                                                    <Columns>
                                                                        <dx:GridViewDataTextColumn FieldName="ForMonth" VisibleIndex="2" Caption="Tháng" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <CellStyle Wrap="True"></CellStyle>

                                                                            <EditFormSettings Visible="False" />
                                                                        </dx:GridViewDataTextColumn>
                                                                        <%-- <dx:GridViewDataSpinEditColumn FieldName="PlanAmount" VisibleIndex="3" Caption="Chi phí KH" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                                                                        </dx:GridViewDataSpinEditColumn>--%>

                                                                        <%--   <dx:GridViewDataSpinEditColumn FieldName="ActualAmount" VisibleIndex="3" Caption="Chi phí TH" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <CellStyle Wrap="True"></CellStyle>
                                                                            <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                                            <PropertiesSpinEdit DisplayFormatString="N2">
                                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                                                </ValidationSettings>
                                                                            </PropertiesSpinEdit>
                                                                        </dx:GridViewDataSpinEditColumn>--%>
                                                                        <dx:GridViewDataSpinEditColumn FieldName="Amount" VisibleIndex="3" Caption="Chi phí" Width="380" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                                                                    <Settings GroupFormat="{1}" ShowGroupPanel="false" ShowFilterRow="false" ShowStatusBar="Visible" ShowFooter="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
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
                                                                        <%--  <dx:ASPxSummaryItem FieldName="PlanAmount" ShowInColumn="PlanAmount" SummaryType="Sum" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                                        <dx:ASPxSummaryItem FieldName="EstimateAmount" ShowInColumn="EstimateAmount" SummaryType="Sum" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                                        <dx:ASPxSummaryItem FieldName="ActualAmount" ShowInColumn="ActualAmount" SummaryType="Sum" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />--%>
                                                                        <dx:ASPxSummaryItem FieldName="Amount" ShowInColumn="Amount" SummaryType="Sum" DisplayFormat="{0:N2}" ValueDisplayFormat="{0:N2}" />
                                                                    </TotalSummary>
                                                                    <Templates>
                                                                        <StatusBar>
                                                                            <div style="float: right">
                                                                                <dx:ASPxButton runat="server" Text="PHÂN BỔ CHI PHÍ" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16" Font-Bold="true">
                                                                                    <ClientSideEvents Click="RevCost.ClientCalculateUnitPriceButton_Click" />
                                                                                    <Image Url="../Content/images/configs.png" Height="16"></Image>
                                                                                </dx:ASPxButton>
                                                                            </div>
                                                                        </StatusBar>
                                                                    </Templates>
                                                                    <ClientSideEvents BeginCallback="RevCost.ClientCostDetailGrid_BeginCallback"
                                                                        EndCallback="RevCost.ClientCostDetailGrid_EndCallback" />
                                                                </dx:ASPxGridView>
                                                            </dx:SplitterContentControl>
                                                        </ContentCollection>
                                                        <PaneStyle Border-BorderWidth="0px">
                                                            <BorderTop BorderWidth="0px"></BorderTop>
                                                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                                        </PaneStyle>
                                                    </dx:SplitterPane>
                                                    <dx:SplitterPane Name="CarrierPane">
                                                        <ContentCollection>
                                                            <dx:SplitterContentControl>
                                                                <dx:ASPxGridView ID="CarrierGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                                    ClientInstanceName="ClientCarrierGrid" Width="100%" KeyFieldName="DepreCostCarrierID"
                                                                    OnCustomCallback="CarrierGrid_CustomCallback"
                                                                    OnBatchUpdate="CarrierGrid_BatchUpdate"
                                                                    Caption="DANH SÁCH CÁC HÃNG SỬ DỤNG TRANG THIẾT BỊ">
                                                                    <Columns>
                                                                        <dx:GridViewCommandColumn ShowSelectCheckbox="true" VisibleIndex="0" Width="55" SelectAllCheckboxMode="AllPages"></dx:GridViewCommandColumn>
                                                                        <dx:GridViewCommandColumn VisibleIndex="1" Width="100" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                                                            <HeaderTemplate>
                                                                                <dx:ASPxButton runat="server" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                                                                    <Image Url="../Content/images/action/add.gif"></Image>
                                                                                    <ClientSideEvents Click="RevCost.ClientCarrierGrid_AddNewButtonClick" />
                                                                                </dx:ASPxButton>
                                                                            </HeaderTemplate>
                                                                            <CustomButtons>
                                                                                <dx:GridViewCommandColumnCustomButton ID="CarrierDelete" Text="Xóa bỏ" Image-Url="../Content/images/action/delete.gif">
                                                                                    <Styles>
                                                                                        <Style Paddings-PaddingLeft="1px"></Style>
                                                                                    </Styles>
                                                                                </dx:GridViewCommandColumnCustomButton>
                                                                            </CustomButtons>
                                                                        </dx:GridViewCommandColumn>
                                                                        <dx:GridViewDataTextColumn FieldName="AreaCode" VisibleIndex="2" Caption="Chi nhánh" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <CellStyle Wrap="True"></CellStyle>
                                                                            <PropertiesTextEdit>
                                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                                                </ValidationSettings>
                                                                            </PropertiesTextEdit>
                                                                            <EditFormSettings Visible="False" />
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn FieldName="Carrier" VisibleIndex="3" Caption="Hãng" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <CellStyle Wrap="True"></CellStyle>
                                                                            <PropertiesTextEdit>
                                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                                                </ValidationSettings>
                                                                            </PropertiesTextEdit>
                                                                            <EditFormSettings Visible="False" />
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataColumn FieldName="Description" VisibleIndex="5" Caption="Diễn giải" Width="500" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <CellStyle Wrap="True"></CellStyle>
                                                                        </dx:GridViewDataColumn>
                                                                    </Columns>
                                                                    <Styles>
                                                                        <AlternatingRow Enabled="true" />
                                                                    </Styles>
                                                                    <Settings GroupFormat="{1}" ShowGroupPanel="false" ShowFilterRow="true" ShowStatusBar="Hidden" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
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
                                                                    <ClientSideEvents FocusedRowChanged="RevCost.ClientCarrierGrid_FocusedRowChanged"
                                                                        CustomButtonClick="RevCost.ClientCarrierGrid_CustomButtonClick"
                                                                        EndCallback="RevCost.ClientCarrierGrid_EndCallback" />
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
                                        <PaneStyle Border-BorderWidth="1px">
                                            <BorderTop BorderWidth="1px"></BorderTop>
                                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                        </PaneStyle>
                                    </dx:SplitterPane>
                                </Panes>
                            </dx:SplitterPane>
                            <dx:SplitterPane Name="UnitPricePane">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="UnitPriceGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientUnitPriceGrid" Width="100%" KeyFieldName="UnitPriceID"
                                            OnCustomCallback="UnitPriceGrid_CustomCallback"
                                            OnCustomColumnDisplayText="UnitPriceGrid_CustomColumnDisplayText"
                                            Caption="CHI PHÍ KHẤU HAO CHO MỘT CHUYẾN BAY THEO HÃNG">
                                            <Columns>
                                                <%-- <dx:GridViewCommandColumn ShowSelectCheckbox="true" VisibleIndex="0" Width="55" SelectAllCheckboxMode="AllPages"></dx:GridViewCommandColumn>--%>

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
                                                <%-- <dx:GridViewDataSpinEditColumn FieldName="EquipmentNbr" VisibleIndex="8" Caption="Số lượng TTB" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>--%>
                                                <dx:GridViewDataSpinEditColumn FieldName="Quantity" VisibleIndex="9" Caption="Sản lượng" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="UnitPrice" VisibleIndex="10" Caption="Đơn giá" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>

                                                <dx:GridViewDataColumn FieldName="Description" VisibleIndex="11" Caption="Diễn giải" Width="700" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
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

                                            <TotalSummary>
                                                <dx:ASPxSummaryItem FieldName="Quantity" ShowInColumn="Quantity" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                            </TotalSummary>
                                            <ClientSideEvents CustomButtonClick="RevCost.ClientUnitPriceGrid_CustomButtonClick"
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
                        <PaneStyle Border-BorderWidth="0px">
                            <BorderTop BorderWidth="0px"></BorderTop>
                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                        </PaneStyle>
                    </dx:SplitterPane>

                </Panes>

            </dx:SplitterPane>
        </Panes>

    </dx:ASPxSplitter>

    <dx:ASPxPopupControl ID="CarrierPopup" runat="server" ClientInstanceName="ClientCarrierPopup" Width="400px" Height="450px"
        HeaderText="Thêm hãng" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ShowFooter="true">
        <HeaderStyle Font-Bold="True" Font-Size="Medium">
            <Paddings PaddingBottom="5px" PaddingTop="5px" />
        </HeaderStyle>
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                <dx:ASPxGridView ID="LOVCarrierGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientLOVCarrierGrid" Width="100%" KeyFieldName="AreaCode;Carrier"
                    OnCustomCallback="LOVCarrierGrid_CustomCallback">
                    <Columns>
                        <dx:GridViewCommandColumn ShowSelectCheckbox="true" Width="55" SelectAllCheckboxMode="AllPages"></dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="AreaCode" VisibleIndex="1" Caption="Chi nhánh" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Carrier" VisibleIndex="2" Caption="Hãng" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Styles>
                        <AlternatingRow Enabled="true" />
                        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                    </Styles>
                    <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" />
                    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="AreaCode;Carrier" />
                    <Paddings Padding="0px" />
                    <Border BorderWidth="0px" BorderStyle="None" />
                    <BorderBottom BorderWidth="1px" />
                    <SettingsBehavior AllowFocusedRow="True" />
                    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
                </dx:ASPxGridView>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Đóng" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientCarrierPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApply" runat="server" Text="Chấp nhận" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientAddCarrierButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientCarrierPopup_Shown" />
    </dx:ASPxPopupControl>

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
                                    <dx:ASPxComboBox ID="cboCalcUnitPriceVersion" runat="server" ClientInstanceName="ClientCalcUnitPriceVersion" ValueType="System.Int32" Width="100%" AutoResizeWithContainer="true"
                                        OnCallback="cboCalcUnitPriceVersion_Callback" ClientEnabled="false">
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
                        <dx:LayoutItem Caption="Đến tháng">
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCalcUnitPriceCancel" runat="server" Text="Đóng" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientCalcUnitPricePopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCalcUnitPriceApply" runat="server" Text="Chấp nhận" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientCalcUnitPriceButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientCalcUnitPricePopup_Shown" />
    </dx:ASPxPopupControl>
</asp:Content>

