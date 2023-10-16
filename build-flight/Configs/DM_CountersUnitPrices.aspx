<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DM_CountersUnitPrices.aspx.cs" Inherits="Configs_DM_CountersUnitPrices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/PageModuleBase.js"></script>
    <script src="../Scripts/CountersUnitPrices.js"></script>
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
                        </div>
                        <div style="float: left">
                            <div class="title">
                                <asp:Literal ID="Literal1" runat="server" Text="ĐƠN GIÁ THUÊ QUẦY THỦ TỤC" />
                            </div>
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
            <dx:SplitterPane Separator-Visible="false">
                <Panes>
                    <dx:SplitterPane Size="920">
                        <Panes>
                            <dx:SplitterPane Name="GridNormYearPane" Size="200">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="NormYearGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientNormYearGrid" Width="100%" KeyFieldName="NormYearID"
                                            Caption="NĂM ĐỊNH MỨC KTKT">
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
                            <dx:SplitterPane Name="MasterPane">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="MasterGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientMasterGrid" Width="100%" KeyFieldName="CounterTypeID"
                                            OnCustomCallback="MasterGrid_CustomCallback"
                                            OnBatchUpdate="MasterGrid_BatchUpdate"
                                            Caption="DANH SÁCH ĐƠN GIÁ THUÊ QUẦY">
                                            <Columns>
                                                <dx:GridViewCommandColumn VisibleIndex="0" Width="90" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                                    <HeaderTemplate>
                                                        <dx:ASPxButton runat="server" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                                            <Image Url="../Content/images/action/add.gif"></Image>
                                                            <ClientSideEvents Click="RevCost.ClientMasterGrid_AddNewButtonClick" />
                                                        </dx:ASPxButton>
                                                    </HeaderTemplate>
                                                    <CustomButtons>
                                                        <dx:GridViewCommandColumnCustomButton ID="MasterGridDelete" Text="Xóa bỏ" Image-Url="../Content/images/action/delete.gif">
                                                            <Styles>
                                                                <Style Paddings-PaddingLeft="1px"></Style>
                                                            </Styles>
                                                        </dx:GridViewCommandColumnCustomButton>
                                                    </CustomButtons>
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataComboBoxColumn FieldName="AreaCode" VisibleIndex="4" Caption="Chi nhánh" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesComboBox>
                                                        <Items>
                                                            <dx:ListEditItem Value="SGN" Text="SGN" />
                                                            <dx:ListEditItem Value="HAN" Text="HAN" />
                                                            <dx:ListEditItem Value="DAD" Text="DAD" />
                                                        </Items>
                                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                            <RequiredField IsRequired="true" ErrorText="*" />
                                                        </ValidationSettings>
                                                    </PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>
                                                <dx:GridViewDataComboBoxColumn FieldName="CountersType" VisibleIndex="5" Caption="Loại quầy" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesComboBox ValueType="System.String" ValueField="DefValue" TextField="Description">
                                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                            <RequiredField IsRequired="true" ErrorText="*" />
                                                        </ValidationSettings>
                                                    </PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>
                                                <dx:GridViewDataComboBoxColumn FieldName="RentalType" VisibleIndex="6" Caption="Loại thuê quầy" Width="130" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesComboBox>
                                                        <Items>
                                                            <dx:ListEditItem Value="CHUYEN" Text="Chuyến bay" />
                                                            <dx:ListEditItem Value="THUEBAO" Text="Thuê bao tháng" />
                                                        </Items>
                                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                            <RequiredField IsRequired="true" ErrorText="*" />
                                                        </ValidationSettings>
                                                    </PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>

                                                <dx:GridViewDataComboBoxColumn FieldName="Network" VisibleIndex="7" Caption="Mạng bay" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesComboBox>
                                                        <Items>
                                                            <dx:ListEditItem Value="INT" Text="Quốc tế" />
                                                            <dx:ListEditItem Value="DOM" Text="Quốc nội" />
                                                        </Items>
                                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                            <RequiredField IsRequired="true" ErrorText="*" />
                                                        </ValidationSettings>
                                                    </PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>

                                                <dx:GridViewDataSpinEditColumn FieldName="Quantity" VisibleIndex="8" Caption="Số lượng" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesSpinEdit DisplayFormatString="N0">
                                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                            <RequiredField IsRequired="true" ErrorText="*" />
                                                        </ValidationSettings>
                                                    </PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataTextColumn FieldName="UnitOfMeasure" VisibleIndex="9" Caption="ĐVT" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                            <RequiredField IsRequired="true" ErrorText="*" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Amount" VisibleIndex="10" Caption="Đơn giá" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesSpinEdit DisplayFormatString="N2">
                                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                            <RequiredField IsRequired="true" ErrorText="*" />
                                                        </ValidationSettings>
                                                    </PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataComboBoxColumn FieldName="CurrencyCode" VisibleIndex="11" Caption="Loại tiền" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesComboBox>
                                                        <Items>
                                                            <dx:ListEditItem Value="VND" Text="VND" />
                                                            <dx:ListEditItem Value="USD" Text="USD" />
                                                        </Items>
                                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                            <RequiredField IsRequired="true" ErrorText="*" />
                                                        </ValidationSettings>
                                                    </PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>
                                                <dx:GridViewDataColumn FieldName="Description" VisibleIndex="12" Caption="Diễn giải" Width="350" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                            </Columns>
                                            <Styles>
                                                <AlternatingRow Enabled="true" />
                                            </Styles>
                                            <Settings GroupFormat="{1}" ShowGroupPanel="false" ShowFilterRow="true" ShowStatusBar="Visible" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                            <Paddings Padding="0px" />
                                            <Border BorderWidth="1px" />
                                            <BorderBottom BorderWidth="0px" />
                                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                            <SettingsCommandButton RenderMode="Button"></SettingsCommandButton>
                                            <SettingsPager Visible="true" PageSize="100" Mode="ShowAllRecords" />
                                            <SettingsEditing Mode="Batch">
                                                <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                                            </SettingsEditing>
                                            <Templates>
                                                <StatusBar>
                                                    <div style="float: right">
                                                        <dx:ASPxButton runat="server" Text="LƯU THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                            <ClientSideEvents Click="RevCost.ClientSaveDataGridButton_Click" />
                                                            <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                                        </dx:ASPxButton>
                                                        &nbsp;
                                                        <dx:ASPxButton runat="server" Text="HỦY THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                            <ClientSideEvents Click="RevCost.ClientCancelDataGridButton_Click" />
                                                            <Image Url="../Content/images/action/undo.png" Height="16"></Image>
                                                        </dx:ASPxButton>

                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <dx:ASPxButton runat="server" Text="PHÂN BỔ ĐƠN GIÁ" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                            <ClientSideEvents Click="RevCost.ClientCalculateUnitPriceButton_Click" />
                                                            <Image Url="../Content/images/configs.png" Height="16"></Image>
                                                        </dx:ASPxButton>

                                                    </div>
                                                </StatusBar>
                                            </Templates>
                                            <ClientSideEvents CustomButtonClick="RevCost.ClientMasterGrid_CustomButtonClick"
                                                EndCallback="RevCost.ClientMasterGrid_EndCallback"
                                                FocusedRowChanged="RevCost.ClientMasterGrid_FocusedRowChanged" />
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
                            <dx:SplitterPane Name="CarrierPane" Size="400">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="CarrierGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientCarrierGrid" Width="100%" KeyFieldName="CarrierCounterID"
                                            OnCustomCallback="CarrierGrid_CustomCallback"
                                            OnBatchUpdate="CarrierGrid_BatchUpdate"
                                            Caption="DANH SÁCH CÁC HÃNG SỬ DỤNG QUẦY">
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
                                                <dx:GridViewDataSpinEditColumn FieldName="UsageRate" VisibleIndex="4" Caption="Tỷ lệ sử dụng quầy(%)" Width="160" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="{0:N2} %">
                                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                            <RequiredField IsRequired="true" ErrorText="*" />
                                                        </ValidationSettings>
                                                    </PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataColumn FieldName="Description" VisibleIndex="5" Caption="Diễn giải" Width="80%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                            <dx:SplitterPane Name="UnitPricePane">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <%--OnBatchUpdate="UnitPriceGrid_BatchUpdate"--%>
                                        <dx:ASPxGridView ID="UnitPriceGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientUnitPriceGrid" Width="100%" KeyFieldName="UnitPriceID"
                                            OnCustomCallback="UnitPriceGrid_CustomCallback"
                                            OnCustomColumnDisplayText="UnitPriceGrid_CustomColumnDisplayText"
                                            Caption="ĐƠN GIÁ THUÊ QUẦY CHO MỘT CHUYẾN BAY">
                                            <Columns>
                                                <dx:GridViewCommandColumn ShowSelectCheckbox="true" VisibleIndex="0" Width="55" SelectAllCheckboxMode="AllPages"></dx:GridViewCommandColumn>
                                                <%--<dx:GridViewCommandColumn VisibleIndex="1" Width="100" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                                    <HeaderTemplate>
                                                        <dx:ASPxButton runat="server" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                                            <Image Url="../Content/images/action/add.gif"></Image>
                                                            <ClientSideEvents Click="RevCost.ClientUnitPriceGrid_AddNewButtonClick" />
                                                        </dx:ASPxButton>
                                                    </HeaderTemplate>
                                                    <CustomButtons>
                                                        <dx:GridViewCommandColumnCustomButton ID="UnitDelete" Text="Xóa bỏ" Image-Url="../Content/images/action/delete.gif">
                                                            <Styles>
                                                                <Style Paddings-PaddingLeft="1px"></Style>
                                                            </Styles>
                                                        </dx:GridViewCommandColumnCustomButton>
                                                    </CustomButtons>
                                                </dx:GridViewCommandColumn>--%>
                                                <dx:GridViewDataComboBoxColumn FieldName="VersionID" VisibleIndex="1" Caption="Version sản lượng" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataComboBoxColumn>
                                                <%-- <dx:GridViewDataColumn FieldName="VersionName" UnboundType="String" VisibleIndex="2" Caption="Version" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>--%>
                                                <dx:GridViewDataSpinEditColumn FieldName="ForMonth" VisibleIndex="2" Caption="Tháng" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <%--<dx:GridViewDataDateColumn FieldName="EffectiveDateFrom" VisibleIndex="3" Caption="Hiệu lực từ" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                                </dx:GridViewDataDateColumn>
                                                <dx:GridViewDataDateColumn FieldName="EffectiveDateTo" VisibleIndex="4" Caption="Hiệu lực đến" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                                </dx:GridViewDataDateColumn>--%>
                                                <%-- <dx:GridViewDataColumn FieldName="Aircraft" VisibleIndex="3" Caption="Loại tàu" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>--%>
                                                <dx:GridViewDataSpinEditColumn FieldName="Quantity" VisibleIndex="4" Caption="Sản lượng" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                               <%--  <dx:GridViewDataSpinEditColumn FieldName="CountersNbr" VisibleIndex="5" Caption="Số quầy" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>--%>
                                                <dx:GridViewDataSpinEditColumn FieldName="UnitPrice" VisibleIndex="6" Caption="Đơn giá" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataComboBoxColumn FieldName="CurrencyCode" VisibleIndex="7" Caption="Loại tiền" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesComboBox>
                                                        <Items>
                                                            <dx:ListEditItem Value="VND" Text="VND" />
                                                            <dx:ListEditItem Value="USD" Text="USD" />
                                                        </Items>
                                                    </PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="DiscountPercent" VisibleIndex="8" Caption="Giảm giá/CK (%)" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesSpinEdit DisplayFormatString="{0:N2} %">
                                                    </PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataColumn FieldName="Description" VisibleIndex="9" Caption="Diễn giải" Width="400" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                            <SettingsCommandButton RenderMode="Button"></SettingsCommandButton>
                                            <SettingsPager Visible="true" PageSize="100" Mode="ShowAllRecords" />
                                            <%--<SettingsEditing Mode="Batch">
                                                <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                                            </SettingsEditing>--%>
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
                <PaneStyle Border-BorderWidth="0px">
                    <BorderTop BorderWidth="0px"></BorderTop>
                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                </PaneStyle>
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
        HeaderText="Tham số tính đơn giá quầy" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ShowFooter="true">
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

