<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DM_StationeryUnitPrices.aspx.cs" Inherits="Configs_DM_StationeryUnitPrices" %>

<%@ Register Src="~/Configs/PopupControl/StationeryLOV.ascx" TagPrefix="dx" TagName="StationeryLOV" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/PageModuleBase.js"></script>
    <script src="../Scripts/StationeryUnitPrice.js"></script>
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
                                <asp:Literal ID="Literal1" runat="server" Text="ĐƠN GIÁ VĂN PHÒNG PHẨM" />
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
                                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" ShowStatusBar="Visible" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                    <Paddings Padding="0px" />
                                    <Border BorderWidth="1px" />
                                    <BorderBottom BorderWidth="0px" />
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <SettingsPager PageSize="100" Mode="ShowAllRecords" />
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
                                    <ClientSideEvents FocusedRowChanged="RevCost.ClientNormYearGrid_FocusedRowChanged" />
                                </dx:ASPxGridView>
                            </dx:SplitterContentControl>
                        </ContentCollection>
                        <PaneStyle Border-BorderWidth="0">
                            <BorderTop BorderWidth="0px"></BorderTop>
                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                        </PaneStyle>
                    </dx:SplitterPane>
                    <dx:SplitterPane>
                        <Panes>
                            <dx:SplitterPane Name="MasterPane" Size="250">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="MasterGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientMasterGrid" Width="100%" KeyFieldName="UnitPriceID"
                                            OnCustomCallback="MasterGrid_CustomCallback"
                                            OnBatchUpdate="MasterGrid_BatchUpdate"
                                            Caption="THÔNG TIN CHUNG">
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
                                                <dx:GridViewDataComboBoxColumn FieldName="AreaCode" VisibleIndex="1" Caption="Chi nhánh" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                                                <dx:GridViewDataColumn FieldName="ContractNo" VisibleIndex="2" Caption="Số HĐ" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataDateColumn FieldName="SignDate" VisibleIndex="3" Caption="Ngày ký" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                                </dx:GridViewDataDateColumn>
                                                <dx:GridViewDataColumn FieldName="SupplierName" VisibleIndex="4" Caption="Nhà cung cấp" Width="400" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="SupplierAddress" VisibleIndex="5" Caption="Địa chỉ NCC" Width="400" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="SupplierTaxCode" VisibleIndex="6" Caption="Mã số thuế" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="Description" VisibleIndex="7" Caption="Diễn giải" Width="500" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
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
                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientMasterGrid_FocusedRowChanged"
                                                EndCallback="RevCost.ClientMasterGrid_EndCallback"
                                                CustomButtonClick="RevCost.ClientMasterGrid_CustomButtonClick" />
                                        </dx:ASPxGridView>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                                <PaneStyle Border-BorderWidth="0px">
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                </PaneStyle>
                            </dx:SplitterPane>

                            <dx:SplitterPane Name="DetailPane">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="DetailGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientDetailGrid" Width="100%" KeyFieldName="UnitPriceDetailID"
                                            OnCustomCallback="DetailGrid_CustomCallback"
                                            OnBatchUpdate="DetailGrid_BatchUpdate"
                                            OnCustomColumnDisplayText="DetailGrid_CustomColumnDisplayText"
                                            Caption="THÔNG TIN CHI TIẾT">
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
                                                <dx:GridViewDataComboBoxColumn FieldName="StationeryID" VisibleIndex="1" Caption="Tên hàng hóa" Width="300" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesComboBox ValueField="StationeryID" TextField="StationeryName" ValueType="System.Int32"></PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>

                                                <dx:GridViewDataSpinEditColumn FieldName="Quantity" VisibleIndex="3" Caption="Số lượng" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                     <GroupFooterCellStyle Font-Bold="true"></GroupFooterCellStyle>
                                                    <FooterTemplate>
                                                        <dx:ASPxLabel ID="lbQuantitySum" runat="server" Font-Size="Small" ClientInstanceName="labelQuantity" Text='<%# GetSummaryValue((Container.Column as GridViewDataColumn).FieldName) %>'>
                                                        </dx:ASPxLabel>
                                                    </FooterTemplate>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataColumn FieldName="UnitOfMeasure" VisibleIndex="4" Caption="ĐVT" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="UnitPrice" VisibleIndex="5" Caption="Đơn giá" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Amount" VisibleIndex="6" Caption="Thành tiền" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                                    <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                                    <GroupFooterCellStyle Font-Bold="true"></GroupFooterCellStyle>
                                                    <Settings ShowEditorInBatchEditMode="false" />
                                                    <FooterTemplate>
                                                        <dx:ASPxLabel ID="lbAmountSum" runat="server" Font-Size="Small" ClientInstanceName="labelAmount" Text='<%# GetSummaryValue((Container.Column as GridViewDataColumn).FieldName) %>'>
                                                        </dx:ASPxLabel>
                                                    </FooterTemplate>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataColumn FieldName="StationeryType" VisibleIndex="7" Caption="Nhóm VPP" Width="350" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="Description" VisibleIndex="8" Caption="Diễn giải" Width="700" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                            </Columns>
                                            <Styles>
                                                <AlternatingRow Enabled="true" />
                                            </Styles>
                                            <Settings GroupFormat="{1}" ShowGroupPanel="false" ShowGroupFooter="VisibleAlways" ShowFooter="true" ShowFilterRow="true" ShowStatusBar="Hidden" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                            <Paddings Padding="0px" />
                                            <Border BorderWidth="1px" />
                                            <BorderBottom BorderWidth="0px" />
                                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                            <SettingsCommandButton RenderMode="Button"></SettingsCommandButton>
                                            <SettingsPager Visible="true" PageSize="100" Mode="ShowAllRecords" />
                                            <SettingsEditing Mode="Batch">
                                                <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                                            </SettingsEditing>
                                            <GroupSummary>
                                                <dx:ASPxSummaryItem FieldName="Quantity" ShowInGroupFooterColumn="Quantity" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                                <dx:ASPxSummaryItem FieldName="Amount" ShowInGroupFooterColumn="Amount" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" />
                                            </GroupSummary>
                                            <TotalSummary>
                                                <dx:ASPxSummaryItem FieldName="Quantity" ShowInColumn="Quantity" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" Tag="Quantity_Sum" />
                                                <dx:ASPxSummaryItem FieldName="Amount" ShowInColumn="Amount" SummaryType="Sum" DisplayFormat="{0:N0}" ValueDisplayFormat="{0:N0}" Tag="Amount_Sum" />
                                            </TotalSummary>
                                            <ClientSideEvents
                                                BatchEditChangesCanceling="RevCost.ClientDetailGrid_OnChangesCanceling"
                                                BatchEditRowDeleting="RevCost.ClientDetailGrid_OnBatchEditRowDeleting"
                                                BatchEditStartEditing="RevCost.ClientDetailGrid_OnBatchEditStartEditing"
                                                EndCallback="RevCost.ClientDetailGrid_EndCallback"
                                                BatchEditEndEditing="RevCost.ClientDetailGrid_OnBatchEditEndEditing" 
                                                CustomButtonClick="RevCost.ClientDetailGrid_CustomButtonClick"/>
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
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>

    <dx:ASPxPopupControl ID="StationeryPopup" runat="server" ClientInstanceName="ClientStationeryPopup" Width="650px" Height="500px" HeaderText=""
        Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ShowFooter="true">
        <HeaderStyle Font-Bold="True" Font-Size="Medium">
            <Paddings PaddingBottom="5px" PaddingTop="5px" />
        </HeaderStyle>
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:StationeryLOV runat="server" ID="StationeryLOV" />
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" runat="server" Text="Đóng" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientStationeryPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" runat="server" Text="Chấp nhận" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientAddStationeryButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>
</asp:Content>

