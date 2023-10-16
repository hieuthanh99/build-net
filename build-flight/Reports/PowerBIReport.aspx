<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PowerBIReport.aspx.cs" Inherits="Reports_PowerBIReport"
    EnableViewState="False" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <% if (SessionUser.IsInRole(PermissionConstant.VIEW_POWER_BI))
       { %>
    <iframe width="100%" height="100%" src="https://app.powerbi.com/reportEmbed?reportId=5a9d0367-dc4e-4891-b0de-49661c1359e9&groupId=1c65de76-e90e-41f2-9b70-b2f65525a3de&autoAuth=true&ctid=444afa81-acf8-4f90-9d26-0ef1c1d14a7b&config=eyJjbHVzdGVyVXJsIjoiaHR0cHM6Ly93YWJpLWVhc3QtYXNpYS1hLXByaW1hcnktcmVkaXJlY3QuYW5hbHlzaXMud2luZG93cy5uZXQvIn0%3D" frameborder="0" allowFullScreen="true"></iframe>
    <% }
       else
       { %>
        <div class="title">
       <asp:Literal ID="Literal1" runat="server" Text="You have no permissions to view this report. Please contact your administrator for more information."  />
    </div>
    <% } %>
</asp:Content>

