
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using APPData;
public partial class Account_UserProfile : BasePage
{
    QLKHAppEntities entities = new QLKHAppEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FormTitleLabel.Text = "Edit Profile: " + SessionUser.UserName;
            LoadUserProfile();
        }
    }


    private void LoadUserProfile()
    {
        var userProfiles = entities.vw_HDUsersProfile
                          .Where(x => x.UserID == SessionUser.UserID)
                          .Select(x => new { x.PropertyName, x.PropertyValue })
                          .ToDictionary(x => x.PropertyName, x => x.PropertyValue);

        if (userProfiles != null)
        {
            TitleEditor.Text = userProfiles.Where(x => x.Key == "Tittle").Select(x => x.Value).FirstOrDefault();// string.Empty;
            FirstNameEditor.Text = userProfiles.Where(x => x.Key == "FirstName").Select(x => x.Value).FirstOrDefault(); //user.FirstName;
            MiddleNameEditor.Text = userProfiles.Where(x => x.Key == "MiddleName").Select(x => x.Value).FirstOrDefault(); //user.FirstName;
            LastNameEditor.Text = userProfiles.Where(x => x.Key == "LastName").Select(x => x.Value).FirstOrDefault(); // user.LastName;
            TelephoneEditor.Text = userProfiles.Where(x => x.Key == "Telephone").Select(x => x.Value).FirstOrDefault();
            OrganizationEditor.Text = userProfiles.Where(x => x.Key == "Organization").Select(x => x.Value).FirstOrDefault();
            //var Signature = userProfiles.Where(x => x.Key == "Signature").Select(x => x.Value).FirstOrDefault();
            //EmailSignatureEditor.Html = StringUtils.isEmpty(Signature) ? "" : HttpUtility.HtmlDecode(Signature); // user.Signature;
            //var IsIncludeSignature = userProfiles.Where(x => x.Key == "IsIncludeSignature").Select(x => x.Value).FirstOrDefault();
            //IncludeCheckboxEditor.Checked = StringUtils.isEmpty(IsIncludeSignature) ? false : Convert.ToBoolean(IsIncludeSignature);//(user.IsIncludeSignature ?? false);
        }
        var user = entities.Users.SingleOrDefault(x => x.UserID == SessionUser.UserID);
        if (user != null)
        {
            EmailSignatureEditor.Html = StringUtils.isEmpty(user.Signature) ? "" : HttpUtility.HtmlDecode(user.Signature);
            IncludeCheckboxEditor.Checked = !user.IsIncludeSignature.HasValue ? false : (bool)user.IsIncludeSignature;
        }
    }
    protected void SettingsPanel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        var args = e.Parameter.Split('|');
        if (args[0] == "SAVE")
        {
            try
            {
                var userProfiles = entities.UserProfiles.Where(x => x.UserID == SessionUser.UserID).ToList();
                foreach (var userProfile in userProfiles)
                {
                    if (userProfile.ProfilePropertyDefinition != null && userProfile.ProfilePropertyDefinition.PropertyName.Equals("Tittle"))
                        userProfile.PropertyValue = TitleEditor.Text;
                    if (userProfile.ProfilePropertyDefinition != null && userProfile.ProfilePropertyDefinition.PropertyName.Equals("FirstName"))
                        userProfile.PropertyValue = FirstNameEditor.Text;
                    if (userProfile.ProfilePropertyDefinition != null && userProfile.ProfilePropertyDefinition.PropertyName.Equals("MiddleName"))
                        userProfile.PropertyValue = MiddleNameEditor.Text;
                    if (userProfile.ProfilePropertyDefinition != null && userProfile.ProfilePropertyDefinition.PropertyName.Equals("LastName"))
                        userProfile.PropertyValue = LastNameEditor.Text;
                    if (userProfile.ProfilePropertyDefinition != null && userProfile.ProfilePropertyDefinition.PropertyName.Equals("Telephone"))
                        userProfile.PropertyValue = TelephoneEditor.Text;
                    //if (userProfile.ProfilePropertyDefinition != null && userProfile.ProfilePropertyDefinition.PropertyName.Equals("Signature"))
                    //    userProfile.PropertyValue = HttpUtility.HtmlEncode(EmailSignatureEditor.Html);
                    //if (userProfile.ProfilePropertyDefinition != null && userProfile.ProfilePropertyDefinition.PropertyName.Equals("IsIncludeSignature"))
                    //    userProfile.PropertyValue = IncludeCheckboxEditor.Checked.ToString();
                }

                var user = entities.Users.SingleOrDefault(x => x.UserID == SessionUser.UserID);
                if (user != null)
                {
                    user.FirstName = FirstNameEditor.Text;
                    user.LastName = LastNameEditor.Text;
                    user.Signature = EmailSignatureEditor.Html;
                    user.IsIncludeSignature = IncludeCheckboxEditor.Checked;
                }
                entities.SaveChanges();

                MessageLabel.Text = "Update success.";
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }

    }
}