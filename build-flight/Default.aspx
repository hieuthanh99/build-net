<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"
    EnableViewState="False" %>

<%@ Register Assembly="DevExpress.Dashboard.v20.2.Web.WebForms, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="signalr/hubs"></script>
    
    <% if (SessionUser.IsInRole(PermissionConstant.VIEW_DASHBOARD))
        { %>
    <dx:ASPxDashboard ID="ASPxDashboard1" runat="server" ClientInstanceName="ClientDashboard" Width="100%" Height="100%" DashboardStorageFolder="~/App_Data/Dashboards" WorkingMode="Viewer" IncludeDashboardIdToUrl="True"
        IncludeDashboardStateToUrl="False" AllowExportDashboardItems="true" InitialDashboardId="dashboard3" OnCustomParameters="ASPxDashboard1_CustomParameters">
    </dx:ASPxDashboard>
    <% } %>
</asp:Content>

