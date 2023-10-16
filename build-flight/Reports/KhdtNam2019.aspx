<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="KhdtNam2019.aspx.cs" Inherits="Reports_KhdtNam2019" %>

<%@ Register Assembly="DevExpress.Web.ASPxSpreadsheet.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpreadsheet" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxSpreadsheet.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpreadsheet" tagprefix="dx" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder">
    <dx:ASPxSpreadsheet ID="ASPxSpreadsheet1" runat="server" RibbonMode="OneLineRibbon"  Width="100%" Height="100%" WorkDirectory="~/App_Data/WorkDirectory" ShowConfirmOnLosingChanges="False"  ReadOnly="True" EncodeHtml="True"></dx:ASPxSpreadsheet>
</asp:Content>


