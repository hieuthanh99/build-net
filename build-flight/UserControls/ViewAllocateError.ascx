<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewAllocateError.ascx.cs" Inherits="UserControls_ViewAllocateError" %>

<dx:ASPxGridView ID="StoreAllocateErrorGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
    ClientInstanceName="ClientStoreAllocateErrorGrid" Width="100%" KeyFieldName="LogID">
    <Columns>
        <dx:GridViewDataTextColumn FieldName="ErrMsg" VisibleIndex="1" Caption="ErrMsg" Width="350" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="FltMonth" VisibleIndex="2" Caption="FltMonth" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ACID" VisibleIndex="3" Caption="ACID" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Airport" VisibleIndex="4" Caption="Airport" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="FltType" VisibleIndex="5" Caption="FltType" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="RouteID" VisibleIndex="6" Caption="RouteID" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Driver" VisibleIndex="7" Caption="Driver" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Carrier" VisibleIndex="8" Caption="Carrier" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="RepID" VisibleIndex="9" Caption="RepID" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Sector" VisibleIndex="10" Caption="Sector" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn FieldName="FltDate" VisibleIndex="11" Caption="FltDate" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
        </dx:GridViewDataDateColumn>
    </Columns>
    <Styles>
        <AlternatingRow Enabled="true" />
    </Styles>
    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
    <SettingsResizing ColumnResizeMode="Control" />
    <Paddings Padding="0px" />
    <Border BorderWidth="1px" />
    <BorderBottom BorderWidth="1px" />
    <SettingsBehavior AllowFocusedRow="True" />
    <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
</dx:ASPxGridView>
