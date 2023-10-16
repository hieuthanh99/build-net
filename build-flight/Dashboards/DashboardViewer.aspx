<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DashboardViewer.aspx.cs" Inherits="Dashboards_DashboardViewer" %>

<%@ Register Assembly="DevExpress.Dashboard.v20.2.Web.WebForms, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <dx:ASPxDashboard ID="ASPxDashboard1" runat="server" ClientInstanceName="ClientDashboard" Width="100%" Height="100%" DashboardStorageFolder="~/App_Data/Dashboards" WorkingMode="Viewer" IncludeDashboardIdToUrl="True"
        IncludeDashboardStateToUrl="False" AllowExportDashboardItems="true"  OnCustomParameters="ASPxDashboard1_CustomParameters">
    </dx:ASPxDashboard>
</asp:Content>

