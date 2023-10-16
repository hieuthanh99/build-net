<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>QUẢN LÝ KẾ HOẠCH THU-CHI LĨNH VỰC THƯƠNG MẠI</title>
    <link href="../Content/css/loginstyle.css" rel="stylesheet" />
    <link href="../Content/css/free.min.css" rel="stylesheet" />
    <link href="../Content/css/loginfont.css" rel="stylesheet" />
    <script src="../Scripts/a81368914c.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script>
        function beforeLogin(s, e) {
            if (document.getElementById('tbUserName').value == '') {
                alert('User name must be enterd!');
                return false;
            }
            if (document.getElementById('tbPassword').value == '') {
                alert('Password must be enterd!');
                return false;
            }
        }
    </script>
</head>
<body>
    <%--<img class="wave" src="../Content/images/wave.png" />--%>
    <div class="container">
        <div class="img">
            <%--<img src="../Content/images/1banner.jpg" />--%>
        </div>
        <div class="login-content">
            <form runat="server" id="form1">
                <img src="../Content/images/background-sprite.png" />
                <h2 class="title">QUẢN LÝ KẾ HOẠCH THU-CHI LĨNH VỰC THƯƠNG MẠI</h2>
                <div class="input-div one">
                    <div class="i">
                        <i class="fas fa-user"></i>
                    </div>
                    <div class="div">
                        <h5>Tên đăng nhập</h5>
                        <asp:TextBox ID="tbUserName" CssClass="input" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </div>
                <div class="input-div pass">
                    <div class="i">
                        <i class="fas fa-lock"></i>
                    </div>
                    <div class="div">
                        <h5>Mật khẩu</h5>
                        <asp:TextBox ID="tbPassword" TextMode="Password" CssClass="input" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </div>
                <span class="error_message_css">
                    <asp:Literal ID="lbNotice" runat="server"></asp:Literal></span>
                <asp:Button ID="btnSignIn" CssClass="btn" Text="Đăng nhập" OnClick="btnSignIn_Click" runat="server" OnClientClick="beforeLogin"></asp:Button>
            </form>
        </div>
    </div>
    <script src="../Scripts/login-main.js"></script>
</body>
</html>
