using System;
using System.Linq;
using APPData;
public partial class Admin_UserEdit : BasePage
{

    private const string sRequestUrl = "37F101A4-7288-48AA-A924-D96F3D68DA5E";
    private const string sAction = "64D318AE-572C-4F48-AC7A-69B3C2A71A02";
    private const string sUserID = "9CE99785-3F5B-4347-92C9-91C3D6890829";
    private const string sCountry = "2B6D514C-1EB2-4BCE-A89D-AD910889660F";

    QLKHAppEntities entity = new QLKHAppEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.UrlReferrer != null)
                ViewState[sRequestUrl] = Request.UrlReferrer.ToString();

            //LoadCountry();         
            string strAction = Request.QueryString["Act"] != null ? Request.QueryString["Act"].ToString() : "";
            int UserID = Request.QueryString["UserID"] != null ? Convert.ToInt32(Request.QueryString["UserID"]) : 0;
            ViewState[sAction] = strAction;

            if (strAction.Equals(Action.EDIT) && UserID != 0)
            {
                userNameTextBox.ReadOnly = true;
                LoadUserProfile(UserID);
                ViewState[sUserID] = UserID;
            }
        }
    }
    //private void LoadCountry()
    //{
    //    var countries = (from x in entity.TBL_CG_REF_CODES where x.RV_DOMAIN == "COUNTRY" select x).ToList();
    //    countryComboBox.DataSource = countries;
    //    countryComboBox.ValueField = "RV_LOW_VALUE";
    //    countryComboBox.TextField = "RV_MEANING";
    //    countryComboBox.DataBind();
    //}


    private void LoadUserProfile(int UserID)
    {
        var user = (from x in entity.Users where x.UserID == UserID select x).FirstOrDefault();
        if (user != null)
        {
            //dateStartDate.Value = user.START_DATE;
            //dateExpiryDate.Value = user.EXPIRY_DATE;
            userNameTextBox.Value = user.Username;
            //passwordTextBox.Value = user.Password;
            lastNameTextBox.Value = user.LastName;
            firstNameTextBox.Value = user.FirstName;
            eMailTextBox.Value = user.Email;
            checkChangePass.Checked = user.UpdatePassword;
            checkIsSystem.Checked = user.IsSuperUser;
            checkLocked.Checked = user.IsDeleted;
          
            //textboxDescription.Value = "";

        }
        var userProfile = (from x in entity.UserProfiles where x.UserID == UserID select x).FirstOrDefault();
        if (userProfile != null)
        {
            //lastNameTextBox.Value = userProfile.LastName;
            //firstNameTextBox.Value = userProfile.FirstName;
            //genderRadioButtonList.Value = userProfile.Gender;
            //countryComboBox.Value = userProfile.Country;
            //address.Value = userProfile.Address;
            //telephone.Value = userProfile.Telephone;
            //mobile.Value = userProfile.Mobile;
            //eMailTextBox.Value = userProfile.Email_Address;
        }

    }

    private void UpdateUser(int UserID)
    {
        try
        {
            var userProfile = (from x in entity.UserProfiles where x.UserID == UserID select x).FirstOrDefault();
            //userProfile.LastName = lastNameTextBox.Text;
            //userProfile.FirstName = firstNameTextBox.Text;
            //userProfile.Gender = genderRadioButtonList.Value != null ? genderRadioButtonList.Value.ToString() : "";
            //userProfile.Country = countryComboBox.Value != null ? countryComboBox.Value.ToString() : "";
            //userProfile.Address = address.Text; ;
            //userProfile.Telephone = telephone.Text; ;
            //userProfile.Mobile = mobile.Text;
            //userProfile.Email_Address = eMailTextBox.Text;
            //userProfile.LastModifiedOnDate = DateTime.Now;
            //userProfile.LastModifiedByUserID = SessionUser.UserID;

            var user = (from u in entity.Users where u.UserID == UserID select u).FirstOrDefault();
          
            //if (dateStartDate.Value != null)
            //    user.START_DATE = dateStartDate.Date;
            //else
            //    user.START_DATE = null;

            //if (dateExpiryDate.Value != null)
            //    user.EXPIRY_DATE = dateExpiryDate.Date;
            //else
            //    user.EXPIRY_DATE = null;
            user.FirstName = firstNameTextBox.Text.Trim();
            user.LastName = lastNameTextBox.Text.Trim();
            user.DisplayName = firstNameTextBox.Text.Trim() + " " + lastNameTextBox.Text.Trim();
            user.Email = eMailTextBox.Text;
            user.UpdatePassword = checkChangePass.Checked ;
            user.IsSuperUser = checkIsSystem.Checked;
            user.IsDeleted = checkLocked.Checked ;
            //user.DESCRIPTION = textboxDescription.Text;
            //if (passwordTextBox.Value != null)
            //{
            //    user.Password2 = user.Password2;
            //    user.Password1 = user.Password1;
            //    user.Password = Common.EncryptPassword(passwordTextBox.Value.ToString());
            //}
            user.LastModifiedOnDate = DateTime.Now;
            user.LastModifiedByUserID = SessionUser.UserID;
            entity.SaveChanges();
            lbNotice.Text = "Save Successful!";
        }
        catch (Exception ex)
        {
            lbNotice.Text = ex.Message;
        }
    }

    private bool CheckExistsUserName(string  UserName)
    {
        var chk = (from x in entity.Users where x.Username == UserName select x).Any();
        return chk;
    }

    private bool CheckExistsEmailEmail(string UserName, string Email)
    {
        var chk = (from x in entity.Users where !(x.Username.Equals(UserName)) && x.Email.ToLower().Equals(Email) select x).Any();
        return chk;
    }

    private bool ValidateCreateUser()
    {
        if (StringUtils.isEmpty(userNameTextBox.Text))
        {
            //lbNotice.Text = GetMessage("MSG-0003");
            Response.Write("<script type='text/javascript'>alert('" + GetMessage("MSG-0003") + "');</script>");
            return false;
        }

        if (CheckExistsUserName(userNameTextBox.Text))
        {
            //lbNotice.Text = GetMessage("MSG-0004");
            Response.Write("<script type='text/javascript'>alert('" + GetMessage("MSG-0004") + "');</script>");
            return false;
        }

        if (CheckExistsEmailEmail(userNameTextBox.Text, eMailTextBox.Text))
        {

            //lbNotice.Text = GetMessage("MSG-0005");
            Response.Write("<script type='text/javascript'>alert('" + GetMessage("MSG-0005") + "');</script>");
            return false;
        }

        return true;
    }

    private bool ValidateEditUser()
    {
        if (CheckExistsEmailEmail(userNameTextBox.Text, eMailTextBox.Text))
        {
            lbNotice.Text = GetMessage("MSG-0005");
            return false;
        }

        return true;
    }

    private void CreateUser()
    {
        var user = new APPData.User();
        user.Username = userNameTextBox.Value.ToString();
        user.Password = Common.EncryptText("sabretn@12345");
      

        //if (dateStartDate.Value != null)
        //    user.START_DATE = dateStartDate.Date;
        //else
        //    user.START_DATE = null;

        //if (dateExpiryDate.Value != null)
        //    user.EXPIRY_DATE = dateExpiryDate.Date;
        //else
        //    user.EXPIRY_DATE = null;
        user.FirstName = firstNameTextBox.Text.Trim();
        user.LastName = lastNameTextBox.Text.Trim();
        user.DisplayName = firstNameTextBox.Text.Trim() + " " + lastNameTextBox.Text.Trim();
        user.Email = eMailTextBox.Text;
        user.UpdatePassword = checkChangePass.Checked;
        user.IsSuperUser = checkIsSystem.Checked;
        user.IsDeleted = checkLocked.Checked;
        //user.DESCRIPTION = textboxDescription.Text;
        user.CreatedOnDate = DateTime.Now;
        user.CreatedByUserID = SessionUser.UserID;
        entity.Users.Add(user);
        entity.SaveChanges();

        APPData.UserProfile userProfile = new APPData.UserProfile();
        userProfile.UserID = user.UserID;
        //userProfile.USER_NAME = userNameTextBox.Value.ToString();
        //userProfile.LastName = lastNameTextBox.Text;
        //userProfile.FirstName = firstNameTextBox.Text;
        //userProfile.Gender = genderRadioButtonList.Value != null ? genderRadioButtonList.Value.ToString() : "";
        //userProfile.Country = countryComboBox.Value != null ? countryComboBox.Value.ToString() : "";
        //userProfile.Address = address.Text; ;
        //userProfile.Telephone = telephone.Text; ;
        //userProfile.Mobile = mobile.Text;
        //userProfile.Email_Address = eMailTextBox.Text;
        //userProfile.CreatedOnDate = DateTime.Now;
        //userProfile.CreatedByUserID = SessionUser.UserID;
        entity.UserProfiles.Add(userProfile);
        entity.SaveChanges();
    }

    protected void mMain_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
    {
        if (e.Item.Name.ToUpper().Equals(Action.CANCEL))
        {
            if (ViewState[sRequestUrl] != null)
            {
                string Url = ViewState[sRequestUrl].ToString();
                Response.Redirect(Url);
            }
            else
                Response.Redirect("~/");
        }
        else if (e.Item.Name.ToUpper().Equals(Action.SAVE))
        {

            string strAction = Action.NEW;
            if (ViewState[sAction] != null)
                strAction = ViewState[sAction].ToString();

            if (strAction.Equals(Action.EDIT))
            {
                if (ViewState[sUserID] != null)
                {
                    int UserID = Convert.ToInt32(ViewState[sUserID]);
                    if (!ValidateEditUser()) return;
                    UpdateUser(UserID);
                    if (ViewState[sRequestUrl] != null)
                    {
                        string Url = ViewState[sRequestUrl].ToString();
                        Response.Redirect(Url);
                    }
                }
            }
            else
            {
                if (!ValidateCreateUser()) return;
                CreateUser();
                if (ViewState[sRequestUrl] != null)
                {
                    string Url = ViewState[sRequestUrl].ToString();
                    Response.Redirect(Url);
                }
            }
        }

    }

    protected void countryComboBox_Init(object sender, EventArgs e)
    {
        //ASPxComboBox cbo = sender as ASPxComboBox;
        //var list = entity.Lists.Where(x => x.ListName == "Country").ToList();

        //cbo.DataSource = list;
        //cbo.ValueField = "Value";
        //cbo.TextField = "Text";
        //cbo.DataBind();
    }
}