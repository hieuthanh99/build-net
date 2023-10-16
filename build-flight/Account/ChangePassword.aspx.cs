
using APPData;
using System;
using System.Linq;


public partial class Account_ChangePassword : BasePage
{
    QLKHAppEntities entities = new QLKHAppEntities();

    //protected void Page_PreInit(object sender, EventArgs e)
    //{
    //    Utils.ApplyTheme(this);
    //}
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private bool ValidateUser(User user, string OldPassowrd)
    {
        //string password = OldPassowrd;
        //string encrytPass = Common.EncryptText(password);

        if (!OldPassowrd.Equals(Common.DecryptText(user.Password)))
            return false;


        return true;
    }

    private bool ChangePass(User user, string Password, string NewPassword)
    {
        if (NewPassword.Length < 6)
        {
            lbNotice.Text = "Mật khẩu mới yêu cầu phải ít nhất 6 ký tự.";
            return false;
        }
        if (NewPassword.Equals(Password))
        {
            lbNotice.Text = "Mật khẩu mới không được trùng với mật khẩu cũ.";
            return false;
        }
        user.Password2 = user.Password1;
        user.Password1 = user.Password;
        user.Password = Common.EncryptText(NewPassword);
        user.UpdatePassword = false;
        entities.SaveChanges();
        return true;
    }
    private User GetUser(string User_Name)
    {
        var user = (from x in entities.Users where x.Username == User_Name select x).FirstOrDefault();
        return user;
    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        User user = GetUser(User.Identity.Name);
        if (!ValidateUser(user, tbCurrentPassword.Text))
        {
            lbNotice.Text = "Mật khẩu cũ không đúng.";
        }
        else if (!ChangePass(user, tbCurrentPassword.Text, tbPassword.Text))
        {
            lbNotice.Text = "Thay đổi mật khẩu thành công.";
        }
        else
            Response.Redirect("~/");
    }
}