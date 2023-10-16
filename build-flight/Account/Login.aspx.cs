using APPData;
using KTQTData;
using System;
using System.Configuration;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
public partial class Account_Login : System.Web.UI.Page
{
    QLKHAppEntities entities = new QLKHAppEntities();

    protected void Page_PreInit(object sender, EventArgs e)
    {
        Utils.ApplyTheme(this);
    }


    protected void Page_Load(object sender, EventArgs e)
    {
    }

    private bool LDAP_Authentication(string _UserName, string _Password, ref string _Name)
    {
        DirectoryEntry dEntry;
        string strLDAP = ConfigurationManager.AppSettings["LDAPServer"];
        try
        {
            dEntry = new DirectoryEntry(strLDAP, _UserName, _Password);
            var searcher = new DirectorySearcher(dEntry);

            searcher.PropertiesToLoad.Add("cn");
            searcher.PropertiesToLoad.Add("mail");

            //would also work and saves you some code
            searcher.Filter = "((sAMAccountName=" + _UserName + "))";

            SearchResult result = searcher.FindOne();

            //neu get duoc thong tin co nghia la check thanh cong
            _Name = result.Properties["cn"][0].ToString();

            dEntry.RefreshCache();
            dEntry.Close();
            dEntry = null;

            return true;
        }
        catch
        {
            return false;
        }
    }

    private APPData.User CreateUser(string _UserName, string _Password, string _Name)
    {
        try
        {
            var user = new User();
            user.Username = _UserName;
            user.Password = "";
            user.FirstName = _Name;
            user.LastName = _Name;
            user.DisplayName = _Name;
            user.Email = String.Format("{0}@{1}", _UserName, ConfigurationManager.AppSettings["LDAPDomain"]);
            user.UpdatePassword = false;
            user.IsSuperUser = false;
            user.IsDeleted = false;
            user.CreatedOnDate = DateTime.Now;
            user.CreatedByUserID = SessionUser.UserID;
            entities.Users.Add(user);
            entities.SaveChanges();

            var groups = entities.GroupUsers.Where(x => x.IsDefault == true && (x.IsDeleted ?? false) == false);
            foreach (var group in groups)
            {
                var newUserGroup = new UserGroupUser
                {
                    UserID = user.UserID,
                    GroupID = group.GroupID,
                    Used = true
                };

                entities.UserGroupUsers.Add(newUserGroup);
            }
            entities.SaveChanges();

            return user;
        }
        catch
        {
            //Do nothing
        }
        return null;
    }

    private int ValidateUser(string _UserName, string _Password, ref User refUser)
    {
        try
        {
            if (_UserName != "pmsdev" && ConfigurationManager.AppSettings["LDAPConnect"].ToUpper() == "TRUE")
            {
                string _Name = string.Empty;
                if (LDAP_Authentication(_UserName, _Password, ref _Name))
                {
                    var user = (from x in entities.Users where x.Username.Equals(_UserName) && !x.IsDeleted select x).FirstOrDefault();
                    if (user == null)
                        user = CreateUser(_UserName, _Password, _Name);

                    if (user != null)
                    {
                        refUser = user;
                        return 1;
                    }
                }
                return 0;
            }
            else
            {
                try
                {
                    var user = (from x in entities.Users
                                where x.Username.Equals(_UserName) && x.IsDeleted == false
                                select x)
                                .FirstOrDefault();

                    if (user != null && _Password == Common.DecryptText(user.Password))
                    {
                        refUser = user;
                        return 1;
                    }
                    return 0;

                }
                catch (Exception ex)
                {

                    lbNotice.Text = ex.Message;
                    return -1;
                }
            }
        }
        catch (Exception ex)
        {
            lbNotice.Text = ex.Message;
            return -1;
        }
    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        string appCode = ConfigurationManager.AppSettings["AppCode"];
        if (StringUtils.isEmpty(appCode))
        {
            lbNotice.Text = "App Code is not avaiable. Please contact Administrator for help.";
            return;
        }

        string _UserName = tbUserName.Text.Trim();
        string _Password = tbPassword.Text.Trim();

        if (string.IsNullOrEmpty(_UserName))
        {
            lbNotice.Text = "Tên đăng nhập không được để trống";
            tbUserName.Focus();
            return;
        }
        if (string.IsNullOrEmpty(_Password))
        {
            lbNotice.Text = "Mật khẩu đăng nhập không được để trống";
            tbPassword.Focus();
            return;
        }

        User user = null;
        int flag = ValidateUser(_UserName, _Password, ref user);
        if (flag == 1)
        {
            if (user.IsDeleted)
            {
                lbNotice.Text = "Account is deleted. Please contact Administrator for help.";
                return;
            }

            LoginUser loginUser = GetLoginUser(appCode, user);

            SessionUser.SetLoginUser(loginUser);

            var ckUserName = new HttpCookie("UserName")
            {
                Value = loginUser.UserName,
                Expires = DateTime.Now.AddDays(1)
            };
            Response.Cookies.Add(ckUserName);
            FormsAuthentication.SetAuthCookie(user.Username, true);

            decimal LogID = InsertLog(user.Username, user.UserID, "Success", "");

            Session[SessionConstant.LOGID] = LogID;

            if (user.UpdatePassword)
            {
                Response.Redirect("~/Account/ChangePassword.aspx");
            }
            else
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) && IsCorrectURL(Request.QueryString["ReturnUrl"]))
                    Response.Redirect(HttpUtility.UrlDecode(Request.QueryString["ReturnUrl"]));
                else
                    Response.Redirect("~/Default.aspx");
            }
        }
        else if (flag == 0)
        {
            decimal LogID = InsertLog(_UserName, null, "Fail", "Sai tên đăng nhập hoặc mật khẩu.");
            lbNotice.Text = "Account is incorrect. Please try again";
        }
    }

    private LoginUser GetLoginUser(string appCode, User user)
    {
        //Lay cac nhom quyen gan cho user
        var aGroups = (from x in entities.GroupUsers
                       join y in entities.UserGroupUsers on x.GroupID equals y.GroupID
                       where x.AppCode == appCode && y.UserID == user.UserID && y.Used == true
                       select x.GroupNumber).ToArray();
        //Lay cac quyen gan cho user
        var aRoles = (from x in entities.Roles
                      join y in entities.UserRoles on x.RoleID equals y.RoleID
                      where y.UserID == user.UserID
                      select x.RoleName).ToArray();

        //Lấy các quyền của người dùng
        var aGroupIDs = (from x in entities.GroupUsers
                        join y in entities.UserGroupUsers on x.GroupID equals y.GroupID
                         where x.AppCode == appCode && y.UserID == user.UserID && y.Used == true
                         select y.GroupID)
                    .ToList();

        var aActionRights = (from x in entities.GroupUserMenus
                             where aGroupIDs.Contains(x.GroupID) && x.Used == true && x.ActionRight != null && x.ActionRight != ""
                             select x.ActionRight).Distinct().ToArray();

        LoginUser loginUser = new LoginUser();
        loginUser.UserID = user.UserID;
        loginUser.UserName = user.Username;
        loginUser.UserEmail = user.Email;
        loginUser.DisplayName = user.DisplayName;
        loginUser.CompanyID = user.CompanyID;
        loginUser.Groups = aGroups; //Cac nhom quyen 
        loginUser.Roles = aRoles;   //Cac role
        loginUser.ActionRights = aActionRights;
        loginUser.Application = appCode;//cboApplication.SelectedValue;
        loginUser.SessionID = Guid.NewGuid().ToString();

        if (user.CompanyID.HasValue)
        {
            using (KTQTDataEntities kTQTDataEntities = new KTQTDataEntities())
            {
                var companyID = user.CompanyID.Value;
                var company = kTQTDataEntities.DecCompanies.SingleOrDefault(x => x.CompanyID == companyID);
                if (company != null)
                {
                    loginUser.CompanyType = company.CompanyType;
                    loginUser.AreaCode = company.OriArea;
                }
            }
        }

        return loginUser;
    }

    private bool IsCorrectURL(string ReturnURL)
    {
        var menus = entities.Menus.Where(x => x.FileName != null && x.FileName != "").ToList();
        foreach (var menu in menus)
        {
            string fileName = menu.FileName.Replace("~/", "");
            if (ReturnURL.Contains(fileName))
                return true;
        }
        return false;
    }
    protected void cbo_Init(object sender, EventArgs e)
    {
        DropDownList cbo = sender as DropDownList;
        var list = entities.Applications.OrderBy(x => x.Seq).ToList();
        cbo.DataSource = list;
        cbo.DataValueField = "AppCode";
        cbo.DataTextField = "AppName";
        cbo.DataBind();
    }

    private decimal InsertLog(string UserName, int? UserID, string status, string message)
    {
        try
        {
            var log = new UserLoginAttempt();
            log.UserName = UserName;
            log.LoginAt = DateTime.Now;
            log.UserID = UserID;
            log.IPAddress = GetVisitorIPAddress(false);
            log.OS = GetUserPlatform(HttpContext.Current.Request);
            log.Browser = HttpContext.Current.Request.Browser.Browser + "[" + HttpContext.Current.Request.Browser.Version + "]";
            log.Status = status;
            log.ErrorMessage = message;

            entities.UserLoginAttempts.Add(log);
            entities.SaveChanges();

            return log.Id;
        }
        catch
        {

        }
        return 0;
    }


    /// <summary>
    /// method to get Client ip address
    /// </summary>
    /// <param name="GetLan"> set to true if want to get local(LAN) Connected ip address</param>
    /// <returns></returns>
    public static string GetVisitorIPAddress(bool GetLan = false)
    {
        string visitorIPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (String.IsNullOrEmpty(visitorIPAddress))
            visitorIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

        if (string.IsNullOrEmpty(visitorIPAddress))
            visitorIPAddress = HttpContext.Current.Request.UserHostAddress;

        if (string.IsNullOrEmpty(visitorIPAddress) || visitorIPAddress.Trim() == "::1")
        {
            GetLan = true;
            visitorIPAddress = string.Empty;
        }

        if (GetLan)
        {
            if (string.IsNullOrEmpty(visitorIPAddress))
            {
                //This is for Local(LAN) Connected ID Address
                string stringHostName = Dns.GetHostName();
                //Get Ip Host Entry
                IPHostEntry ipHostEntries = Dns.GetHostEntry(stringHostName);
                //Get Ip Address From The Ip Host Entry Address List
                IPAddress[] arrIpAddress = ipHostEntries.AddressList;

                try
                {
                    visitorIPAddress = arrIpAddress[arrIpAddress.Length - 2].ToString();
                }
                catch
                {
                    try
                    {
                        visitorIPAddress = arrIpAddress[0].ToString();
                    }
                    catch
                    {
                        try
                        {
                            arrIpAddress = Dns.GetHostAddresses(stringHostName);
                            visitorIPAddress = arrIpAddress[0].ToString();
                        }
                        catch
                        {
                            visitorIPAddress = "127.0.0.1";
                        }
                    }
                }
            }
        }
        return visitorIPAddress;
    }

    public String GetUserEnvironment(HttpRequest request)
    {
        var browser = request.Browser;
        var platform = GetUserPlatform(request);
        return string.Format("{0} {1} / {2}", browser.Browser, browser.Version, platform);
    }

    public String GetMobileVersion(string userAgent, string device)
    {
        var temp = userAgent.Substring(userAgent.IndexOf(device) + device.Length).TrimStart();
        var version = string.Empty;

        foreach (var character in temp)
        {
            var validCharacter = false;
            int test = 0;

            if (Int32.TryParse(character.ToString(), out test))
            {
                version += character;
                validCharacter = true;
            }

            if (character == '.' || character == '_')
            {
                version += '.';
                validCharacter = true;
            }

            if (validCharacter == false)
                break;
        }

        return version;
    }

    public String GetUserPlatform(HttpRequest request)
    {
        var ua = request.UserAgent;

        if (ua.Contains("Android"))
            return string.Format("Android {0}", GetMobileVersion(ua, "Android"));

        if (ua.Contains("iPad"))
            return string.Format("iPad OS {0}", GetMobileVersion(ua, "OS"));

        if (ua.Contains("iPhone"))
            return string.Format("iPhone OS {0}", GetMobileVersion(ua, "OS"));

        if (ua.Contains("Linux") && ua.Contains("KFAPWI"))
            return "Kindle Fire";

        if (ua.Contains("RIM Tablet") || (ua.Contains("BB") && ua.Contains("Mobile")))
            return "Black Berry";

        if (ua.Contains("Windows Phone"))
            return string.Format("Windows Phone {0}", GetMobileVersion(ua, "Windows Phone"));

        if (ua.Contains("Mac OS"))
            return "Mac OS";

        if (ua.Contains("Windows NT 5.1") || ua.Contains("Windows NT 5.2"))
            return "Windows XP";

        if (ua.Contains("Windows NT 6.0"))
            return "Windows Vista";

        if (ua.Contains("Windows NT 6.1"))
            return "Windows 7";

        if (ua.Contains("Windows NT 6.2"))
            return "Windows 8";

        if (ua.Contains("Windows NT 6.3"))
            return "Windows 8.1";

        if (ua.Contains("Windows NT 10"))
            return "Windows 10";

        //fallback to basic platform:
        return request.Browser.Platform + (ua.Contains("Mobile") ? " Mobile " : "");
    }

}