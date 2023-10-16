<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommonStationeryLOV.ascx.cs" Inherits="Configs_PopupControl_CommonStationeryLOV" %>

<dx:ASPxGridView ID="LOVCommonStationeryGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
    ClientInstanceName="ClientLOVCommonStationeryGrid" Width="100%" KeyFieldName="StationeryID" >
    <Columns>
        <dx:GridViewCommandColumn ShowSelectCheckbox="true" Width="55" SelectAllCheckboxMode="AllPages"></dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn FieldName="StationeryName" VisibleIndex="1" Caption="Tên văn phòng phẩm" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="UnitOfMeasure" VisibleIndex="2" Caption="Đơn vị tính" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
        </dx:GridViewDataTextColumn>
    </Columns>
    <Styles>
        <AlternatingRow Enabled="true" />
        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
    </Styles>
    <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" />
    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="StationeryName;UnitOfMeasure" />
    <Paddings Padding="0px" />
    <Border BorderWidth="0px" BorderStyle="None" />
    <BorderBottom BorderWidth="1px" />
    <SettingsBehavior AllowFocusedRow="True" />
    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
</dx:ASPxGridView>
