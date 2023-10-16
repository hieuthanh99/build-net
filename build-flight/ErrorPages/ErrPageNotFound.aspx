<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrPageNotFound.aspx.cs" Inherits="ErrorPages_ErrPageNotFound" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">

    <div>
        <h2>Page Not Found</h2>
        <p>
            An unexpected error occurred on our website. The website administrator has been
            notified.
        </p>
        <ul>
            <li>
                <asp:HyperLink ID="lnkHome" runat="server" NavigateUrl="~/Default.aspx">Return to the homepage</asp:HyperLink>
            </li>
        </ul>
    </div>

</asp:Content>
