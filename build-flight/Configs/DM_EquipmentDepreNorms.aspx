<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DM_EquipmentDepreNorms.aspx.cs" Inherits="Configs_DM_EquipmentDepreNorms" %>

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
    <script src="../Scripts/EDepreciationNorms.js"></script>
    <dx:ASPxSplitter ID="ASPxSplitter1" runat="server" Orientation="Vertical" Width="100%" Height="100%" FullscreenMode="true">
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
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" Width="100%" Height="100%" ClientInstanceName="ClientPageControl">
                            <ClientSideEvents ActiveTabChanged="RevCost.ClientPageControl_ActiveTabChanged" />
                            <TabPages>
                                <dx:TabPage Text="THEO HÃNG VẬN CHUYỂN">
                                    <ContentCollection>
                                        <dx:ContentControl>
                                            <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Horizontal" Width="100%" Height="100%">
                                                <Styles>
                                                    <Separator>
                                                        <BorderTop BorderStyle="None" />
                                                        <BorderBottom BorderStyle="None" />
                                                    </Separator>
                                                </Styles>
                                                <ClientSideEvents PaneResized="RevCost.ClientSplitter_PaneResized" />
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
                                                                                <dx:GridViewDataColumn FieldName="FltType" VisibleIndex="5" Caption="Nhiệm vụ bay" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                                                    <dx:SplitterPane Name="UnitPricePane">
                                                        <ContentCollection>
                                                            <dx:SplitterContentControl>
                                                                <dx:ASPxGridView ID="EDNormGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                                    ClientInstanceName="ClientEDNormGrid" Width="100%" KeyFieldName="EDNormID"
                                                                    OnCustomCallback="EDNormGrid_CustomCallback"
                                                                    OnBatchUpdate="EDNormGrid_BatchUpdate">
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
                                                                        <dx:GridViewDataComboBoxColumn FieldName="ItemID" VisibleIndex="2" Caption="Loại trang TB" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <CellStyle Wrap="True"></CellStyle>
                                                                            <PropertiesComboBox>
                                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                                    <RequiredField IsRequired="true" ErrorText="Loại trang TB định mức khấu hao bắt buộc nhập giá trị" />
                                                                                </ValidationSettings>
                                                                            </PropertiesComboBox>
                                                                        </dx:GridViewDataComboBoxColumn>
                                                                        <%--  <dx:GridViewDataComboBoxColumn FieldName="EDNormType" VisibleIndex="3" Caption="Loại định mức" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                <CellStyle Wrap="True"></CellStyle>
                                                                <PropertiesComboBox>
                                                                    <Items>
                                                                        <dx:ListEditItem Value="C" Text="Theo hãng" />
                                                                        <dx:ListEditItem Value="N" Text="Không theo hãng" />
                                                                    </Items>
                                                                    <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                        <RequiredField IsRequired="true" ErrorText="Loại định mức khấu hao bắt buộc nhập giá trị" />
                                                                    </ValidationSettings>
                                                                </PropertiesComboBox>
                                                            </dx:GridViewDataComboBoxColumn>--%>
                                                                        <dx:GridViewDataSpinEditColumn FieldName="ForMonth" VisibleIndex="4" Caption="Tháng" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <CellStyle Wrap="True"></CellStyle>
                                                                            <PropertiesSpinEdit DisplayFormatString="N0">
                                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                                    <RequiredField IsRequired="true" ErrorText="Tháng khấu hao bắt buộc nhập giá trị" />
                                                                                </ValidationSettings>
                                                                            </PropertiesSpinEdit>
                                                                        </dx:GridViewDataSpinEditColumn>
                                                                        <dx:GridViewDataSpinEditColumn FieldName="Amount" VisibleIndex="5" Caption="Chi phí khấu hao" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <CellStyle Wrap="True"></CellStyle>
                                                                            <PropertiesSpinEdit DisplayFormatString="N2">
                                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                                    <RequiredField IsRequired="true" ErrorText="Chi phí khấu hao bắt buộc nhập giá trị" />
                                                                                </ValidationSettings>
                                                                            </PropertiesSpinEdit>
                                                                        </dx:GridViewDataSpinEditColumn>
                                                                        <dx:GridViewDataComboBoxColumn FieldName="CurrencyCode" VisibleIndex="6" Caption="Loại tiền" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <CellStyle Wrap="True"></CellStyle>
                                                                            <PropertiesComboBox>
                                                                                <Items>
                                                                                    <dx:ListEditItem Value="VND" Text="VND" />
                                                                                    <dx:ListEditItem Value="USD" Text="USD" />
                                                                                </Items>
                                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                                    <RequiredField IsRequired="true" ErrorText="Loại tiền bắt buộc nhập" />
                                                                                </ValidationSettings>
                                                                            </PropertiesComboBox>
                                                                        </dx:GridViewDataComboBoxColumn>
                                                                        <dx:GridViewDataColumn FieldName="Description" VisibleIndex="7" Caption="Diễn giải" Width="60%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <CellStyle Wrap="True"></CellStyle>
                                                                        </dx:GridViewDataColumn>
                                                                        <%--   <dx:GridViewDataCheckColumn FieldName="Inactive" VisibleIndex="8" Caption="Bỏ theo dõi" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            </dx:GridViewDataCheckColumn>--%>
                                                                    </Columns>
                                                                    <Styles>
                                                                        <AlternatingRow Enabled="true" />
                                                                    </Styles>
                                                                    <Settings GroupFormat="{1}" ShowGroupPanel="false" ShowFilterRow="true" ShowFooter="true" ShowStatusBar="Visible" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                                                    <Paddings Padding="0px" />
                                                                    <Border BorderWidth="1px" />
                                                                    <BorderBottom BorderWidth="0px" />
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
                                                                            </div>
                                                                        </StatusBar>
                                                                    </Templates>
                                                                    <ClientSideEvents CustomButtonClick="RevCost.ClientEDNormGrid_CustomButtonClick"
                                                                        EndCallback="RevCost.ClientEDNormGrid_EndCallback" />
                                                                </dx:ASPxGridView>
                                                            </dx:SplitterContentControl>
                                                        </ContentCollection>
                                                        <PaneStyle Border-BorderWidth="0px">
                                                            <BorderTop BorderWidth="0px"></BorderTop>
                                                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                                        </PaneStyle>
                                                    </dx:SplitterPane>

                                                </Panes>
                                            </dx:ASPxSplitter>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:TabPage>
                                <dx:TabPage Text="CÁC TRANG THIẾT BỊ CÒN LẠI (KHÔNG THEO HÃNG)">
                                    <ContentCollection>
                                        <dx:ContentControl>
                                            <dx:ASPxSplitter ID="ASPxSplitter2" runat="server" ClientInstanceName="ClientSplitter2" Orientation="Horizontal" Width="100%" Height="100%">
                                                <Styles>
                                                    <Separator>
                                                        <BorderTop BorderStyle="None" />
                                                        <BorderBottom BorderStyle="None" />
                                                    </Separator>
                                                </Styles>
                                                <ClientSideEvents PaneResized="RevCost.ClientSplitter_PaneResized" />
                                                <Panes>
                                                    <dx:SplitterPane Size="420" Name="NormYearPane2">
                                                        <ContentCollection>
                                                            <dx:SplitterContentControl>
                                                                <dx:ASPxGridView ID="NormYearGrid2" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                                    ClientInstanceName="ClientNormYearGrid2" Width="100%" KeyFieldName="NormYearID">
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
                                                                    <ClientSideEvents FocusedRowChanged="RevCost.ClientNormYearGrid2_FocusedRowChanged" />
                                                                </dx:ASPxGridView>
                                                            </dx:SplitterContentControl>
                                                        </ContentCollection>
                                                        <PaneStyle Border-BorderWidth="0px">
                                                            <BorderTop BorderWidth="0px"></BorderTop>
                                                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                                        </PaneStyle>
                                                    </dx:SplitterPane>
                                                    <dx:SplitterPane Name="EDNormPane2">
                                                        <ContentCollection>
                                                            <dx:SplitterContentControl>
                                                                <dx:ASPxGridView ID="EDNormGrid2" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                                    ClientInstanceName="ClientEDNormGrid2" Width="100%" KeyFieldName="EDNormID"
                                                                    OnBatchUpdate="EDNormGrid2_BatchUpdate"
                                                                    OnCustomCallback="EDNormGrid2_CustomCallback">
                                                                    <Columns>
                                                                        <dx:GridViewCommandColumn VisibleIndex="0" Width="100" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                                                            <HeaderTemplate>
                                                                                <dx:ASPxButton runat="server" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                                                                    <Image Url="../Content/images/action/add.gif"></Image>
                                                                                    <ClientSideEvents Click="RevCost.ClientEDNormGrid2_AddNewButtonClick" />
                                                                                </dx:ASPxButton>
                                                                            </HeaderTemplate>
                                                                            <CustomButtons>
                                                                                <dx:GridViewCommandColumnCustomButton ID="EDNormGrid2Delete" Text="Xóa" Image-Url="../Content/images/action/delete.gif">
                                                                                    <Styles>
                                                                                        <Style Paddings-PaddingLeft="1px"></Style>
                                                                                    </Styles>
                                                                                </dx:GridViewCommandColumnCustomButton>
                                                                            </CustomButtons>
                                                                        </dx:GridViewCommandColumn>
                                                                        <dx:GridViewDataComboBoxColumn FieldName="ItemID" VisibleIndex="2" Caption="Loại trang TB" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <CellStyle Wrap="True"></CellStyle>
                                                                            <PropertiesComboBox>
                                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                                    <RequiredField IsRequired="true" ErrorText="Loại trang TB định mức khấu hao bắt buộc nhập giá trị" />
                                                                                </ValidationSettings>
                                                                            </PropertiesComboBox>
                                                                        </dx:GridViewDataComboBoxColumn>
                                                                        <dx:GridViewDataSpinEditColumn FieldName="ForMonth" VisibleIndex="4" Caption="Tháng" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <CellStyle Wrap="True"></CellStyle>
                                                                            <PropertiesSpinEdit DisplayFormatString="N0">
                                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                                    <RequiredField IsRequired="true" ErrorText="Tháng khấu hao bắt buộc nhập giá trị" />
                                                                                </ValidationSettings>
                                                                            </PropertiesSpinEdit>
                                                                        </dx:GridViewDataSpinEditColumn>
                                                                        <dx:GridViewDataSpinEditColumn FieldName="Amount" VisibleIndex="5" Caption="Chi phí khấu hao" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <CellStyle Wrap="True"></CellStyle>
                                                                            <PropertiesSpinEdit DisplayFormatString="N2">
                                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                                    <RequiredField IsRequired="true" ErrorText="Chi phí khấu hao bắt buộc nhập giá trị" />
                                                                                </ValidationSettings>
                                                                            </PropertiesSpinEdit>
                                                                        </dx:GridViewDataSpinEditColumn>
                                                                        <dx:GridViewDataComboBoxColumn FieldName="CurrencyCode" VisibleIndex="6" Caption="Loại tiền" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <CellStyle Wrap="True"></CellStyle>
                                                                            <PropertiesComboBox>
                                                                                <Items>
                                                                                    <dx:ListEditItem Value="VND" Text="VND" />
                                                                                    <dx:ListEditItem Value="USD" Text="USD" />
                                                                                </Items>
                                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                                    <RequiredField IsRequired="true" ErrorText="Loại tiền bắt buộc nhập" />
                                                                                </ValidationSettings>
                                                                            </PropertiesComboBox>
                                                                        </dx:GridViewDataComboBoxColumn>
                                                                        <dx:GridViewDataColumn FieldName="Description" VisibleIndex="7" Caption="Diễn giải" Width="60%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <CellStyle Wrap="True"></CellStyle>
                                                                        </dx:GridViewDataColumn>
                                                                    </Columns>
                                                                    <Styles>
                                                                        <AlternatingRow Enabled="true" />
                                                                    </Styles>
                                                                    <Settings GroupFormat="{1}" ShowGroupPanel="false" ShowFilterRow="true" ShowFooter="true" ShowStatusBar="Visible" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                                                    <Paddings Padding="0px" />
                                                                    <Border BorderWidth="1px" />
                                                                    <BorderBottom BorderWidth="0px" />
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
                                                                            <div style="float: right">
                                                                                <dx:ASPxButton runat="server" Text="LƯU THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                                                    <ClientSideEvents Click="RevCost.ClientSaveDataGridButton2_Click" />
                                                                                    <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                                                                </dx:ASPxButton>
                                                                                &nbsp;
                                                                                    <dx:ASPxButton runat="server" Text="HỦY THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                                                        <ClientSideEvents Click="RevCost.ClientCancelDataGridButton2_Click" />
                                                                                        <Image Url="../Content/images/action/undo.png" Height="16"></Image>
                                                                                    </dx:ASPxButton>
                                                                            </div>
                                                                        </StatusBar>
                                                                    </Templates>
                                                                    <ClientSideEvents CustomButtonClick="RevCost.ClientEDNormGrid2_CustomButtonClick"
                                                                        EndCallback="RevCost.ClientEDNormGrid2_EndCallback" />
                                                                </dx:ASPxGridView>
                                                            </dx:SplitterContentControl>
                                                        </ContentCollection>
                                                        <PaneStyle Border-BorderWidth="0px">
                                                            <BorderTop BorderWidth="0px"></BorderTop>
                                                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                                        </PaneStyle>
                                                    </dx:SplitterPane>
                                                </Panes>
                                            </dx:ASPxSplitter>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:TabPage>
                            </TabPages>
                        </dx:ASPxPageControl>
                    </dx:SplitterContentControl>
                </ContentCollection>
            </dx:SplitterPane>
        </Panes>

    </dx:ASPxSplitter>


</asp:Content>

