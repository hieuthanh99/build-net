<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DM_Stationeries.aspx.cs" Inherits="Configs_DM_Stationeries" %>

<%@ Register Src="~/Configs/PopupControl/CommonStationeryLOV.ascx" TagPrefix="dx" TagName="CommonStationeryLOV" %>
<%@ Register Src="~/Configs/PopupControl/PositionStationeryLOV.ascx" TagPrefix="dx" TagName="PositionStationeryLOV" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/PageModuleBase.js"></script>
    <script src="../Scripts/StationeryNorms.js"></script>
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

        .dxtlControl_Office2010Blue caption {
            font-weight: bold;
            color: #1e395b;
            padding: 3px 3px 5px;
            text-align: left;
            background: #bdd0e7 url(/DXR.axd?r=0_4030-ttc8i) repeat-x left top;
            border-bottom: 0 solid #8ba0bc;
            border: 1px solid #8ba0bc;
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
                                <asp:Literal ID="Literal1" runat="server" Text="ĐỊNH MỨC VĂN PHÒNG PHẨM" />
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
                    <dx:SplitterPane Size="420px">
                        <Panes>
                            <dx:SplitterPane Name="GridNormYearPane" Size="250">
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
                                <PaneStyle Border-BorderWidth="0">
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                </PaneStyle>
                            </dx:SplitterPane>
                            <dx:SplitterPane Name="GridCompanyPane">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxTreeList ID="CompanyGrid" runat="server" Width="100%" ClientInstanceName="ClientCompanyGrid" KeyFieldName="CompanyID"
                                            ParentFieldName="ParentID" Caption="ĐƠN VỊ">
                                            <Columns>
                                                <dx:TreeListTextColumn FieldName="NameV" VisibleIndex="1" Caption="Tên đơn vị" Width="100%">
                                                    <DataCellTemplate>
                                                        <asp:Label runat="server" Text='<%# Eval("CompanyID").ToString().Trim() +"-"+ Eval("NameV") %>'></asp:Label>
                                                    </DataCellTemplate>
                                                </dx:TreeListTextColumn>
                                            </Columns>
                                            <Styles>
                                                <AlternatingNode Enabled="True"></AlternatingNode>
                                            </Styles>
                                            <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" HorizontalScrollBarMode="Auto" ScrollableHeight="500" />
                                            <Paddings Padding="0px" />
                                            <Border BorderWidth="1px" />
                                            <BorderBottom BorderWidth="0px" />
                                            <SettingsBehavior AllowFocusedNode="true" AllowSort="false" />
                                            <SettingsResizing ColumnResizeMode="NextColumn" />
                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowAllNodes" />
                                            <ClientSideEvents FocusedNodeChanged="RevCost.ClientCompanyGrid_FocusedNodeChanged" />
                                        </dx:ASPxTreeList>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                                <PaneStyle Border-BorderWidth="1px">
                                    <BorderTop BorderWidth="1px"></BorderTop>
                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                </PaneStyle>
                            </dx:SplitterPane>
                        </Panes>
                    </dx:SplitterPane>
                    <dx:SplitterPane>
                        <Panes>
                            <dx:SplitterPane Size="45%">
                                <Panes>
                                    <dx:SplitterPane Size="450" Name="PositionPane" MinSize="450">
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxGridView ID="PositionGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                    ClientInstanceName="ClientPositionGrid" Width="100%" KeyFieldName="PositionCompanyID"
                                                    OnCustomCallback="PositionGrid_CustomCallback"
                                                    OnBatchUpdate="PositionGrid_BatchUpdate"
                                                    Caption="CHỨC DANH">
                                                    <Columns>
                                                        <dx:GridViewCommandColumn VisibleIndex="0" Width="100" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                                            <HeaderTemplate>
                                                                <dx:ASPxButton runat="server" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                                                    <Image Url="../Content/images/action/add.gif"></Image>
                                                                    <ClientSideEvents Click="RevCost.ClientPositionGrid_AddNewButtonClick" />
                                                                </dx:ASPxButton>
                                                            </HeaderTemplate>
                                                            <CustomButtons>
                                                                <dx:GridViewCommandColumnCustomButton ID="PositionGridDelete" Text="Delete" Image-Url="../Content/images/action/delete.gif">
                                                                    <Styles>
                                                                        <Style Paddings-PaddingLeft="1px"></Style>
                                                                    </Styles>
                                                                </dx:GridViewCommandColumnCustomButton>
                                                            </CustomButtons>
                                                        </dx:GridViewCommandColumn>
                                                        <dx:GridViewDataComboBoxColumn FieldName="PositionTypeID" VisibleIndex="1" Caption="Nội dung" Width="215" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <CellStyle Wrap="True"></CellStyle>
                                                            <PropertiesComboBox ValueField="PositionTypeID" TextField="PositionTypeName" ValueType="System.Int32"></PropertiesComboBox>
                                                        </dx:GridViewDataComboBoxColumn>
                                                        <dx:GridViewDataSpinEditColumn FieldName="Quantity" VisibleIndex="2" Caption="Số lượng" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
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
                                                    <%--  <Templates>
                                                        <StatusBar>
                                                            <dx:ASPxButton runat="server" Text="LƯU THAY ĐỔI" RenderMode="Button"  AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                                <ClientSideEvents Click="RevCost.ClientSavePositionGridButton_Click" />
                                                                <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                                            </dx:ASPxButton>
                                                            &nbsp;
                                                    <dx:ASPxButton runat="server" Text="HỦY THAY ĐỔI" RenderMode="Button"  AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                        <ClientSideEvents Click="RevCost.ClientCancelPositionGridButton_Click" />
                                                        <Image Url="../Content/images/action/undo.png" Height="16"></Image>
                                                    </dx:ASPxButton>
                                                        </StatusBar>
                                                    </Templates>--%>
                                                    <ClientSideEvents FocusedRowChanged="RevCost.ClientPositionGrid_FocusedRowChanged"
                                                        CustomButtonClick="RevCost.ClientPositionGrid_CustomButtonClick"
                                                        EndCallback="RevCost.ClientPositionGrid_EndCallback" />
                                                </dx:ASPxGridView>
                                            </dx:SplitterContentControl>
                                        </ContentCollection>
                                        <PaneStyle Border-BorderWidth="0px">
                                            <BorderTop BorderWidth="0px"></BorderTop>
                                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                        </PaneStyle>
                                    </dx:SplitterPane>
                                    <dx:SplitterPane Name="PositionNormGridPane">
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxGridView ID="PositionNormGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                    ClientInstanceName="ClientPositionNormGrid" Width="100%" KeyFieldName="PositionStationeryID"
                                                    OnCustomCallback="PositionNormGrid_CustomCallback"
                                                    OnCustomColumnDisplayText="PositionNormGrid_CustomColumnDisplayText"
                                                    OnBatchUpdate="PositionNormGrid_BatchUpdate"
                                                    Caption="ĐỊNH MỨC VĂN PHÒNG PHẨM THEO CHỨC DANH">
                                                    <Columns>
                                                        <dx:GridViewCommandColumn VisibleIndex="0" Width="100" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                                            <HeaderTemplate>
                                                                <dx:ASPxButton runat="server" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                                                    <Image Url="../Content/images/action/add.gif"></Image>
                                                                    <ClientSideEvents Click="RevCost.ClientPositionNormGrid_AddNewButtonClick" />
                                                                </dx:ASPxButton>
                                                            </HeaderTemplate>

                                                            <CustomButtons>
                                                                <%--<dx:GridViewCommandColumnCustomButton ID="PositionEdit" Text="Edit" Image-Url="../Content/images/action/edit.gif">
                                                                    <Styles>
                                                                        <Style Paddings-PaddingRight="1px"></Style>
                                                                    </Styles>
                                                                </dx:GridViewCommandColumnCustomButton>--%>
                                                                <dx:GridViewCommandColumnCustomButton ID="PositionNormGridDelete" Text="Delete" Image-Url="../Content/images/action/delete.gif">
                                                                    <Styles>
                                                                        <Style Paddings-PaddingLeft="1px"></Style>
                                                                    </Styles>
                                                                </dx:GridViewCommandColumnCustomButton>
                                                            </CustomButtons>
                                                        </dx:GridViewCommandColumn>
                                                        <dx:GridViewDataTextColumn FieldName="StationeryName" UnboundType="String" VisibleIndex="2" Caption="Nội dung" Width="350" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <CellStyle Wrap="True"></CellStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="UnitOfMeasure" VisibleIndex="3" Caption="ĐVT" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataSpinEditColumn FieldName="Quantity" VisibleIndex="4" Caption="Số lượng" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="5" Caption="Diễn giải" Width="350" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <CellStyle Wrap="True"></CellStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataCheckColumn FieldName="Inactive" VisibleIndex="6" Caption="Bỏ theo dõi" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataCheckColumn>
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
                                                    <%--  <Templates>
                                                        <StatusBar>
                                                            <dx:ASPxButton runat="server" Text="LƯU THAY ĐỔI" RenderMode="Button"  AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                                <ClientSideEvents Click="RevCost.ClientSavePositionStationeryButton_Click" />
                                                                <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                                            </dx:ASPxButton>
                                                            &nbsp;
                                                    <dx:ASPxButton runat="server" Text="HỦY THAY ĐỔI" RenderMode="Button"  AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                        <ClientSideEvents Click="RevCost.ClientCancelPositionStationeryButton_Click" />
                                                        <Image Url="../Content/images/action/undo.png" Height="16"></Image>
                                                    </dx:ASPxButton>
                                                        </StatusBar>
                                                    </Templates>--%>
                                                    <ClientSideEvents CustomButtonClick="RevCost.ClientPositionNormGrid_CustomButtonClick" />
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
                            <dx:SplitterPane Name="CommonNormGridPane">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="CommonNormGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientCommonNormGrid" Width="100%" KeyFieldName="CommonStationeryID"
                                            OnCustomCallback="CommonNormGrid_CustomCallback"
                                            OnCustomColumnDisplayText="CommonNormGrid_CustomColumnDisplayText"
                                            OnBatchUpdate="CommonNormGrid_BatchUpdate"
                                            Caption="ĐỊNH MỨC VĂN PHÒNG PHẨM DÙNG CHUNG">
                                            <Columns>
                                                <dx:GridViewCommandColumn VisibleIndex="0" Width="100" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                                    <HeaderTemplate>
                                                        <dx:ASPxButton runat="server" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                                            <Image Url="../Content/images/action/add.gif"></Image>
                                                            <ClientSideEvents Click="RevCost.ClientClientCommonNormGrid_AddNewButtonClick" />
                                                        </dx:ASPxButton>
                                                    </HeaderTemplate>
                                                    <CustomButtons>
                                                        <%--  <dx:GridViewCommandColumnCustomButton ID="CommonNormEdit" Text="Edit" Image-Url="../Content/images/action/edit.gif">
                                                            <Styles>
                                                                <Style Paddings-PaddingRight="1px"></Style>
                                                            </Styles>
                                                        </dx:GridViewCommandColumnCustomButton>--%>
                                                        <dx:GridViewCommandColumnCustomButton ID="CommonNormGridDelete" Text="Delete" Image-Url="../Content/images/action/delete.gif">
                                                            <Styles>
                                                                <Style Paddings-PaddingLeft="1px"></Style>
                                                            </Styles>
                                                        </dx:GridViewCommandColumnCustomButton>
                                                    </CustomButtons>
                                                </dx:GridViewCommandColumn>
                                                <%--   <dx:GridViewDataTextColumn FieldName="ForYear" VisibleIndex="1" Caption="Năm" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>--%>
                                                <dx:GridViewDataTextColumn FieldName="StationeryName" UnboundType="String" VisibleIndex="2" Caption="Nội dung" Width="350" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="UnitOfMeasure" VisibleIndex="3" Caption="ĐVT" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Quantity" VisibleIndex="4" Caption="Số lượng" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="5" Caption="Diễn giải" Width="50%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataCheckColumn FieldName="Inactive" VisibleIndex="6" Caption="Bỏ theo dõi" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataCheckColumn>
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
                                                    <dx:ASPxButton runat="server" Text="LƯU THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                        <ClientSideEvents Click="RevCost.ClientSaveCommonStationeryButton_Click" />
                                                        <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                                    </dx:ASPxButton>
                                                    &nbsp;
                                                    <dx:ASPxButton runat="server" Text="HỦY THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                        <ClientSideEvents Click="RevCost.ClientCancelCommonStationeryButton_Click" />
                                                        <Image Url="../Content/images/action/undo.png" Height="16"></Image>
                                                    </dx:ASPxButton>
                                                </StatusBar>
                                            </Templates>
                                            <ClientSideEvents CustomButtonClick="RevCost.ClientCommonNormGrid_CustomButtonClick"
                                                EndCallback="RevCost.ClientCommonNormGrid_EndCallback" />
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

    <dx:ASPxPopupControl ID="CommonStationeryPopup" runat="server" ClientInstanceName="ClientCommonStationeryPopup" Width="550px" Height="300px" HeaderText=""
        Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ShowFooter="true">
        <HeaderStyle Font-Bold="True" Font-Size="Medium">
            <Paddings PaddingBottom="5px" PaddingTop="5px" />
        </HeaderStyle>
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                <dx:CommonStationeryLOV runat="server" ID="CommonStationeryLOV" />
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" runat="server" Text="Đóng" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientCommonStationeryPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" runat="server" Text="Chấp nhận" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientAddCommonStationeryButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="PositionStationeryPopup" runat="server" ClientInstanceName="ClientPositionStationeryPopup" Width="550px" Height="300px" HeaderText=""
        Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ShowFooter="true">
        <HeaderStyle Font-Bold="True" Font-Size="Medium">
            <Paddings PaddingBottom="5px" PaddingTop="5px" />
        </HeaderStyle>
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:PositionStationeryLOV runat="server" ID="PositionStationeryLOV" />
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" runat="server" Text="Đóng" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientPositionStationeryPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" runat="server" Text="Chấp nhận" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientAddPositionStationeryButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>
</asp:Content>

