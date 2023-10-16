<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CopyNormCtrl.ascx.cs" Inherits="UserControls_CopyNormCtrl" %>
<dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="2" RequiredMarkDisplayMode="None" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
    AlignItemCaptionsInAllGroups="true" Width="100%">
    <Items>
        <dx:LayoutItem Caption="Từ">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxComboBox ID="cboFromNormYear" runat="server" Width="100%" ClientInstanceName="ClientCopyFromNormYear" ValueType="System.Int32" OnInit="cboFromNormYear_Init">
                        <ClientSideEvents ValueChanged="RevCost.ClientFromNormYear_ValueChanged" />
                    </dx:ASPxComboBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="Đến">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxComboBox ID="cboToNormYear" runat="server" Width="100%" ClientInstanceName="ClientCopyToNormYear" ValueType="System.Int32" OnCallback="cboToNormYear_Callback"></dx:ASPxComboBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
    </Items>
</dx:ASPxFormLayout>
