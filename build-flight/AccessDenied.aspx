<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AccessDenied.aspx.cs" Inherits="AccessDenied" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <div class="title">
       <asp:Literal ID="Literal1" runat="server" Text="You have no permissions to access this page. Please contact your administrator for more information."  />
    </div>
</asp:Content>

