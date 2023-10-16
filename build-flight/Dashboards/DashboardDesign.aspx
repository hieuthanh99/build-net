<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DashboardDesign.aspx.cs" Inherits="Dashboards_DashboardDesign" %>

<%@ Register Assembly="DevExpress.Dashboard.v20.2.Web.WebForms, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <dx:ASPxDashboard ID="ASPxDashboard1" runat="server" Width="100%" Height="100%" DashboardStorageFolder="~/App_Data/Dashboards" EnableCustomSql="True"></dx:ASPxDashboard>
</asp:Content>

