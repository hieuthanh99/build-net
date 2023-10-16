<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Account_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link href="../Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Content/css/default.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />

    <div class="wrapper-login">
        <div class="panel panel-primary text-center login-form">
            <div class="panel-heading">
                <h2 class="panel-title">
                    <asp:Literal ID="Literal1" runat="server" Text="THAY ĐỔI MẬT KHẨU: " /><%=User.Identity.Name %>
                </h2>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="alert-danger">
                        <asp:Literal ID="lbNotice" runat="server"></asp:Literal>
                    </div>
                    <br />
                    <div class="input-group col-md-10 col-md-offset-1">
                        <div class="input-group-addon" style="width: 150px">
                            <dx:ASPxLabel ID="lblCurrentPassword" runat="server" Text="Mật khẩu cũ" />
                        </div>
                        <asp:TextBox ID="tbCurrentPassword" ClientIDMode="Static" TextMode="Password" CssClass="form-control" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                    <br />
                    <div class="input-group col-md-10 col-md-offset-1">
                        <span class="input-group-addon" style="width: 150px">
                            <dx:ASPxLabel ID="lblPassword" runat="server" AssociatedControlID="tbPassword" Text="Mật khẩu mới" />
                        </span>
                        <asp:TextBox ID="tbPassword" ClientIDMode="Static" TextMode="Password" CssClass="form-control" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                    <br />
                    <div class="input-group col-md-10 col-md-offset-1">
                        <span class="input-group-addon" style="width: 150px">
                            <dx:ASPxLabel ID="lblConfirmPassword" runat="server" AssociatedControlID="tbConfirmPassword" Text="Xác nhận mật khẩu" AutoCompleteType="Disabled" />
                        </span>
                        <asp:TextBox ID="tbConfirmPassword" ClientIDMode="Static" TextMode="Password" CssClass="form-control" runat="server">
                        </asp:TextBox>
                    </div>
                    <br />
                    <br />
                    <dx:ASPxButton ID="btnChangePassword" ClientIDMode="Static" CssClass="btn btn-success" Text="Thay đổi mật khẩu" OnClick="btnChangePassword_Click" runat="server">
                        <ClientSideEvents Click="function(s, e) {
                                var originalPasswd = document.getElementById('tbPassword').value;
                                var currentPasswd = document.getElementById('tbConfirmPassword').value;                            
                                var isValid = (originalPasswd  == currentPasswd );                                
                                if(!isValid){
                                    alert('The Password and Confirmation Password must match.');
                                    return false;
                                }
                            }" />
                    </dx:ASPxButton>
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
