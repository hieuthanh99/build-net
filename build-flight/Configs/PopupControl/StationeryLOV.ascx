<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StationeryLOV.ascx.cs" Inherits="Configs_PopupControl_StationeryLOV" %>

<dx:ASPxGridView ID="LOVStationeryGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
    ClientInstanceName="ClientLOVStationeryGrid" Width="100%" KeyFieldName="StationeryID">
    <Columns>
        <dx:GridViewCommandColumn ShowSelectCheckbox="true" Width="55" SelectAllCheckboxMode="AllPages"></dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn FieldName="StationeryName" VisibleIndex="1" Caption="Tên văn phòng phẩm" Width="350" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataComboBoxColumn FieldName="StationeryType" VisibleIndex="2" Caption="Loại VPP" Width="140" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
            <PropertiesComboBox ValueType="System.String">
                <Items>
                    <dx:ListEditItem Value="CD" Text="Theo chức danh" />
                    <dx:ListEditItem Value="DC" Text="Dùng chung" />
                </Items>
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>
        <dx:GridViewDataTextColumn FieldName="UnitOfMeasure" VisibleIndex="3" Caption="Đơn vị tính" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
        </dx:GridViewDataTextColumn>
    </Columns>
    <Styles>
        <AlternatingRow Enabled="true" />
        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
    </Styles>
    <SettingsResizing ColumnResizeMode="Control" />
    <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="600" VerticalScrollBarStyle="Standard" />
    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="StationeryName;StationeryType;UnitOfMeasure" />
    <Paddings Padding="0px" />
    <Border BorderWidth="0px" BorderStyle="None" />
    <BorderBottom BorderWidth="1px" />
    <SettingsBehavior AllowFocusedRow="True" />
    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
</dx:ASPxGridView>
