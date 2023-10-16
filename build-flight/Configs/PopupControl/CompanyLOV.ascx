<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CompanyLOV.ascx.cs" Inherits="Configs_PopupControl_CompanyLOV" %>

<dx:ASPxGridView ID="LOVCompanyGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
    ClientInstanceName="ClientLOVCompanyGrid" Width="100%" KeyFieldName="CompanyID" >
    <Columns>
        <dx:GridViewCommandColumn ShowSelectCheckbox="true" Width="55"></dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn FieldName="ShortName" VisibleIndex="1" Caption="Mã đơn vị" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="NameV" VisibleIndex="2" Caption="Tên đơn vị" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
            <DataItemTemplate>
                <asp:Label runat="server" Text='<%# Eval("AreaCode") +"-"+ Eval("NameV") %>'></asp:Label>
            </DataItemTemplate>
        </dx:GridViewDataTextColumn>
    </Columns>
    <Styles>
        <AlternatingRow Enabled="true" />
        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
    </Styles>
    <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" />
    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="ShortName;NameV" />
    <Paddings Padding="0px" />
    <Border BorderWidth="0px" BorderStyle="None" />
    <BorderBottom BorderWidth="1px" />
    <SettingsBehavior AllowFocusedRow="True" />
    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
</dx:ASPxGridView>
