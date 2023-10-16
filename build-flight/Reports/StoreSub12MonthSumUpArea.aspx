<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="StoreSub12MonthSumUpArea.aspx.cs" Inherits="Reports_StoreSub12MonthSumUpArea" %>

<%@ Register Assembly="DevExpress.XtraReports.v20.2.Web.WebForms, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
       <dx:ASPxWebDocumentViewer ID="ReportViewer" runat="server" Width="100%" Height="100%"
        ClientInstanceName="ReportViewer" ReportTypeName="ChitietOTPChuyenDen" StylesSplitter-SidePaneWidth="208">
       
        
    </dx:ASPxWebDocumentViewer>
</asp:Content>

