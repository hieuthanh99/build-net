<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PositionLOV.ascx.cs" Inherits="Configs_PopupControl_PositionLOV" %>


<dx:ASPxGridView ID="LOVPositionGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
    ClientInstanceName="ClientLOVPositionGrid" Width="100%" KeyFieldName="PositionID" >
    <Columns>
        <dx:GridViewCommandColumn ShowSelectCheckbox="true" Width="55"></dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn FieldName="PostionName" VisibleIndex="1" Caption="Tên chức danh"  HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
        </dx:GridViewDataTextColumn>
    </Columns>
    <Styles>
        <AlternatingRow Enabled="true" />
        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
    </Styles>
    <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" />
    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="PostionName" />
    <Paddings Padding="0px" />
    <Border BorderWidth="0px" BorderStyle="None" />
    <BorderBottom BorderWidth="1px" />
    <SettingsBehavior AllowFocusedRow="True" />
    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
</dx:ASPxGridView>