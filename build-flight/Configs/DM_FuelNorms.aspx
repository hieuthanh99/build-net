<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DM_FuelNorms.aspx.cs" Inherits="Configs_DM_FuelNorms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/PageModuleBase.js"></script>
    <script src="../Scripts/FuelNorms.js"></script>
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

        .dxtcLite_Office2010Blue > .dxtc-content {
            background: White none;
            border: 1px solid #859ebf;
            float: left;
            clear: left;
            overflow: hidden;
            padding: 1px;
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
                                <asp:Literal ID="Literal1" runat="server" Text="ĐỊNH MỨC TIÊU HAO NHIÊU LIỆU/ĐƠN GIÁ NHIÊN LIỆU" />
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
                    <dx:SplitterPane Name="GridNormYearPane" Size="420">
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
                    <dx:SplitterPane Separator-Visible="False">
                        <Panes>
                            <dx:SplitterPane Name="NormPane">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" Width="100%" Height="100%">
                                            <Paddings Padding="0" />
                                            <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                                            <TabPages>
                                                <dx:TabPage Text="ĐỊNH MỨC TIÊU HAO NHIÊU LIỆU BÌNH QUÂN">
                                                    <ContentCollection>
                                                        <dx:ContentControl>
                                                            <dx:ASPxGridView ID="MasterGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                                ClientInstanceName="ClientMasterGrid" Width="100%" KeyFieldName="FuelNormsID"
                                                                OnCustomCallback="MasterGrid_CustomCallback"
                                                                OnBatchUpdate="MasterGrid_BatchUpdate"
                                                                OnRowValidating="MasterGrid_RowValidating"
                                                                OnStartRowEditing="MasterGrid_StartRowEditing"
                                                                OnHtmlRowPrepared="MasterGrid_HtmlRowPrepared">
                                                                <Columns>
                                                                    <dx:GridViewCommandColumn VisibleIndex="0" Width="100" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                                                        <HeaderTemplate>
                                                                            <dx:ASPxButton runat="server" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                                                                <Image Url="../Content/images/action/add.gif"></Image>
                                                                                <ClientSideEvents Click="RevCost.ClientMasterGrid_AddNewButtonClick" />
                                                                            </dx:ASPxButton>
                                                                        </HeaderTemplate>
                                                                        <CustomButtons>
                                                                            <dx:GridViewCommandColumnCustomButton ID="MasterGridDelete" Text="Delete" Image-Url="../Content/images/action/delete.gif">
                                                                                <Styles>
                                                                                    <Style Paddings-PaddingLeft="1px"></Style>
                                                                                </Styles>
                                                                            </dx:GridViewCommandColumnCustomButton>
                                                                        </CustomButtons>
                                                                    </dx:GridViewCommandColumn>
                                                                    <dx:GridViewDataComboBoxColumn FieldName="AreaCode" VisibleIndex="1" Caption="Chi nhánh" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                                                                    <dx:GridViewDataComboBoxColumn FieldName="ItemID" VisibleIndex="2" Caption="Trang thiết bị" Width="400" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                        <CellStyle Wrap="True"></CellStyle>
                                                                        <PropertiesComboBox>
                                                                            <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                                <RequiredField IsRequired="true" ErrorText="*" />
                                                                            </ValidationSettings>
                                                                        </PropertiesComboBox>
                                                                    </dx:GridViewDataComboBoxColumn>
                                                                    <dx:GridViewDataComboBoxColumn FieldName="FuelType" VisibleIndex="3" Caption="Loại NL" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                        <CellStyle Wrap="True"></CellStyle>
                                                                        <PropertiesComboBox>
                                                                            <Items>
                                                                                <dx:ListEditItem Value="X" Text="Xăng" />
                                                                                <dx:ListEditItem Value="D" Text="Dầu" />
                                                                                <dx:ListEditItem Value="N" Text="Nhớt" />
                                                                            </Items>
                                                                            <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                                <RequiredField IsRequired="true" ErrorText="*" />
                                                                            </ValidationSettings>
                                                                        </PropertiesComboBox>
                                                                    </dx:GridViewDataComboBoxColumn>
                                                                    <dx:GridViewDataSpinEditColumn FieldName="UsageRate" VisibleIndex="4" Caption="Tỷ lệ sử dụng NL" Width="130" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                        <CellStyle Wrap="True"></CellStyle>
                                                                        <PropertiesSpinEdit DisplayFormatString="{0:N2} %">
                                                                            <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                                <RequiredField IsRequired="true" ErrorText="*" />
                                                                            </ValidationSettings>
                                                                        </PropertiesSpinEdit>
                                                                    </dx:GridViewDataSpinEditColumn>
                                                                    <dx:GridViewDataComboBoxColumn FieldName="CurrencyCode" VisibleIndex="5" Caption="Loại tiền" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                                                                    <dx:GridViewDataSpinEditColumn FieldName="Quantity" VisibleIndex="6" Caption="ĐM NL bình quân (lít/giờ)" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                        <CellStyle Wrap="True"></CellStyle>
                                                                        <PropertiesSpinEdit DisplayFormatString="{0:N2}">
                                                                            <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                                <RequiredField IsRequired="true" ErrorText="*" />
                                                                            </ValidationSettings>
                                                                        </PropertiesSpinEdit>
                                                                    </dx:GridViewDataSpinEditColumn>
                                                                    <dx:GridViewDataColumn FieldName="UnitOfMeasure" VisibleIndex="7" Caption="ĐVT" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                        <CellStyle Wrap="True"></CellStyle>
                                                                    </dx:GridViewDataColumn>
                                                                    <dx:GridViewDataColumn FieldName="Description" VisibleIndex="8" Caption="Diễn giải" Width="500" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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

                                                                <ClientSideEvents CustomButtonClick="RevCost.ClientMasterGrid_CustomButtonClick" />
                                                            </dx:ASPxGridView>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:TabPage>
                                                <dx:TabPage Text="ĐƠN GIÁ NHIÊN LIỆU">
                                                    <ContentCollection>
                                                        <dx:ContentControl>
                                                            <dx:ASPxGridView ID="DetailGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                                ClientInstanceName="ClientDetailGrid" Width="100%" KeyFieldName="UnitPriceID"
                                                                OnCustomCallback="DetailGrid_CustomCallback"
                                                                OnBatchUpdate="DetailGrid_BatchUpdate"
                                                                OnRowValidating="DetailGrid_RowValidating"
                                                                OnHtmlRowPrepared="DetailGrid_HtmlRowPrepared"
                                                                OnStartRowEditing="DetailGrid_StartRowEditing">
                                                                <Columns>
                                                                    <dx:GridViewCommandColumn VisibleIndex="0" Width="100" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                                                        <HeaderTemplate>
                                                                            <dx:ASPxButton runat="server" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                                                                <Image Url="../Content/images/action/add.gif"></Image>
                                                                                <ClientSideEvents Click="RevCost.ClientDetailGrid_AddNewButtonClick" />
                                                                            </dx:ASPxButton>
                                                                        </HeaderTemplate>
                                                                        <CustomButtons>
                                                                            <dx:GridViewCommandColumnCustomButton ID="DetailGridDelete" Text="Delete" Image-Url="../Content/images/action/delete.gif">
                                                                                <Styles>
                                                                                    <Style Paddings-PaddingLeft="1px"></Style>
                                                                                </Styles>
                                                                            </dx:GridViewCommandColumnCustomButton>
                                                                        </CustomButtons>
                                                                    </dx:GridViewCommandColumn>
                                                                    <dx:GridViewDataComboBoxColumn FieldName="AreaCode" VisibleIndex="1" Caption="Chi nhánh" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                                                                    <dx:GridViewDataComboBoxColumn FieldName="VersionID" VisibleIndex="1" Caption="Version sản lượng" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                        <CellStyle Wrap="True"></CellStyle>
                                                                        <PropertiesComboBox>
                                                                            <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                                <RequiredField IsRequired="true" ErrorText="*" />
                                                                            </ValidationSettings>
                                                                        </PropertiesComboBox>
                                                                    </dx:GridViewDataComboBoxColumn>
                                                                    <dx:GridViewDataDateColumn FieldName="EffectiveDateFrom" VisibleIndex="2" Caption="Hiệu lực từ" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                        <CellStyle Wrap="True"></CellStyle>
                                                                        <PropertiesDateEdit>
                                                                            <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                                <RequiredField IsRequired="true" ErrorText="*" />
                                                                            </ValidationSettings>
                                                                        </PropertiesDateEdit>
                                                                    </dx:GridViewDataDateColumn>
                                                                    <dx:GridViewDataDateColumn FieldName="EffectiveDateTo" VisibleIndex="3" Caption="Hiệu lực đến" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                        <CellStyle Wrap="True"></CellStyle>
                                                                        <PropertiesDateEdit>
                                                                            <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                                <RequiredField IsRequired="true" ErrorText="*" />
                                                                            </ValidationSettings>
                                                                        </PropertiesDateEdit>
                                                                    </dx:GridViewDataDateColumn>
                                                                    <dx:GridViewDataComboBoxColumn FieldName="FuelType" VisibleIndex="4" Caption="Loại NL" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                        <CellStyle Wrap="True"></CellStyle>
                                                                        <PropertiesComboBox>
                                                                            <Items>
                                                                                <dx:ListEditItem Value="X" Text="Xăng" />
                                                                                <dx:ListEditItem Value="D" Text="Dầu" />
                                                                                <dx:ListEditItem Value="N" Text="Nhớt" />
                                                                            </Items>

                                                                            <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                                <RequiredField IsRequired="true" ErrorText="*" />
                                                                            </ValidationSettings>

                                                                        </PropertiesComboBox>
                                                                    </dx:GridViewDataComboBoxColumn>
                                                                    <dx:GridViewDataSpinEditColumn FieldName="UnitPrice" VisibleIndex="5" Caption="Đơn giá" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                                                        <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                                        <PropertiesSpinEdit>
                                                                            <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                                <RequiredField IsRequired="true" ErrorText="*" />
                                                                            </ValidationSettings>
                                                                        </PropertiesSpinEdit>
                                                                    </dx:GridViewDataSpinEditColumn>
                                                                    <dx:GridViewDataColumn FieldName="UnitOfMeasure" VisibleIndex="6" Caption="ĐVT" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                        <CellStyle Wrap="True"></CellStyle>
                                                                    </dx:GridViewDataColumn>
                                                                    <dx:GridViewDataColumn FieldName="Description" VisibleIndex="7" Caption="Diễn giải" Width="900" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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

                                                                <ClientSideEvents CustomButtonClick="RevCost.ClientDetailGrid_CustomButtonClick"
                                                                    EndCallback="RevCost.ClientDetailGrid_EndCallback" />
                                                            </dx:ASPxGridView>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:TabPage>
                                            </TabPages>
                                        </dx:ASPxPageControl>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                                <PaneStyle Border-BorderWidth="0px">
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                </PaneStyle>
                            </dx:SplitterPane>
                            <dx:SplitterPane Separator-Visible="False" Size="40">
                                <ContentCollection>
                                    <dx:SplitterContentControl>                                       
                                        <dx:ASPxButton runat="server" ID="btnSaveChanges" Text="LƯU THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16" Font-Bold="true">
                                            <ClientSideEvents Click="RevCost.ClientSaveDataGridButton_Click" />
                                            <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                        </dx:ASPxButton>
                                        &nbsp;
                                        <dx:ASPxButton runat="server" ID="btnCancel" Text="HỦY THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16" Font-Bold="true">
                                            <ClientSideEvents Click="RevCost.ClientCancelDataGridButton_Click" />
                                            <Image Url="../Content/images/action/undo.png" Height="16"></Image>
                                        </dx:ASPxButton>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                                <PaneStyle Border-BorderWidth="0px">
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                    <Paddings PaddingLeft="5" PaddingRight="1" PaddingBottom="1" PaddingTop="5" />
                                </PaneStyle>
                            </dx:SplitterPane>
                        </Panes>
                    </dx:SplitterPane>
                </Panes>
                <PaneStyle Border-BorderWidth="0px">
                    <BorderTop BorderWidth="0px"></BorderTop>
                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                </PaneStyle>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
</asp:Content>

