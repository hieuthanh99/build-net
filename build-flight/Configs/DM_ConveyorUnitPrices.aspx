<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DM_ConveyorUnitPrices.aspx.cs" Inherits="Configs_DM_ConveyorUnitPrices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
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

    <script src="../Scripts/PageModuleBase.js"></script>
    <script src="../Scripts/ConveyorUnitPrices.js"></script>

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
                                <asp:Literal ID="Literal1" runat="server" Text="ĐƠN GIÁ BĂNG CHUYỀN" />
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
                                            ClientInstanceName="ClientACConfigGrid" Width="100%" KeyFieldName="ACConfigID"
                                            OnCustomCallback="ACConfigGrid_CustomCallback">
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
                                <dx:ASPxGridView ID="UnitPriceGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                    ClientInstanceName="ClientUnitPriceGrid" Width="100%" KeyFieldName="ConveyorUnitPriceID"
                                    OnCustomCallback="UnitPriceGrid_CustomCallback"
                                    OnBatchUpdate="UnitPriceGrid_BatchUpdate">
                                    <Columns>
                                        <dx:GridViewCommandColumn VisibleIndex="0" Width="100" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                            <HeaderTemplate>
                                                <dx:ASPxButton runat="server" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                                    <Image Url="../Content/images/action/add.gif"></Image>
                                                    <ClientSideEvents Click="RevCost.ClientUnitPriceGrid_AddNewButtonClick" />
                                                </dx:ASPxButton>
                                            </HeaderTemplate>
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="UnitDelete" Text="Xóa" Image-Url="../Content/images/action/delete.gif">
                                                    <Styles>
                                                        <Style Paddings-PaddingLeft="1px"></Style>
                                                    </Styles>
                                                </dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataDateColumn FieldName="EffectiveDateFrom" VisibleIndex="2" Caption="Hiệu lực từ" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                    <RequiredField IsRequired="true" ErrorText="Năm bắt buộc nhập giá trị" />
                                                </ValidationSettings>
                                            </PropertiesDateEdit>
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="EffectiveDateTo" VisibleIndex="3" Caption="Hiệu lực đến" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                    <RequiredField IsRequired="true" ErrorText="Năm bắt buộc nhập giá trị" />
                                                </ValidationSettings>
                                            </PropertiesDateEdit>
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="UnitPrice" VisibleIndex="6" Caption="Đơn giá" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesSpinEdit DisplayFormatString="N2">
                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                    <RequiredField IsRequired="true" ErrorText="Đơn giá bắt buộc nhập giá trị" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="CurrencyCode" VisibleIndex="7" Caption="Loại tiền" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                                        <dx:GridViewDataSpinEditColumn FieldName="DiscountPercent" VisibleIndex="8" Caption="Giảm giá/CK (%)" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesSpinEdit DisplayFormatString="{0:N2}">
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataColumn FieldName="Description" VisibleIndex="9" Caption="Diễn giải" Width="60%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                                            </div>
                                        </StatusBar>
                                    </Templates>
                                    <ClientSideEvents CustomButtonClick="RevCost.ClientUnitPriceGrid_CustomButtonClick" />
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
    </dx:ASPxSplitter>
</asp:Content>

