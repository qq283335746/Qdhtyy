using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using System.Web.SessionState;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TygaSoft.CustomProvider;
using TygaSoft.WebHelper;
using TygaSoft.BLL;
using TygaSoft.Model;
using TygaSoft.SysHelper;

namespace TygaSoft.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var logCfg = new System.IO.FileInfo(HttpContext.Current.Server.MapPath("~/Log4net.config"));
            log4net.Config.XmlConfigurator.ConfigureAndWatch(logCfg);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected void Profile_OnMigrateAnonymous(object sender, ProfileMigrateEventArgs args)
        {
            AnonymousIdentificationModule.ClearAnonymousIdentifier();

            try
            {
                var userId = WebCommon.GetUserId();
                var menuBll = new SiteMenus();
                var accessIds = new List<string>();
                accessIds.Add(userId.ToString());
                Task[] tasks = new Task[3];
                tasks[0] = Task.Factory.StartNew(() =>
                {
                    var roleIds = new SiteRoles().GetAspnetRoleIds(Roles.GetRolesForUser());
                    foreach(var item in roleIds)
                    {
                        accessIds.Add(item.ToString());
                    }
                });
                var userProfileInfo = new UserProfileInfo();
                tasks[1] = Task.Factory.StartNew(() =>
                {
                    var fuInfo = new FeatureUser().GetModel(userId, "UserProfile");
                    if (fuInfo != null)
                    {
                        userProfileInfo.SiteCode = fuInfo.SiteCode;
                        userProfileInfo.SiteTitle = fuInfo.SiteTitle;
                        userProfileInfo.SiteLogo = string.IsNullOrWhiteSpace(fuInfo.SiteLogo) ? "" : WebCommon.GetSiteAppName() + fuInfo.SiteLogo;
                        userProfileInfo.CultureName = fuInfo.CultureName;
                    }
                });
                IList<SiteMenusInfo> maList = new List<SiteMenusInfo>();
                tasks[2] = Task.Factory.StartNew(() =>
                {
                    maList = menuBll.GetMenusAccess(Membership.ApplicationName, accessIds.ToArray(), User.IsInRole("Administrators"));
                });
                Task.WaitAll(tasks);
                
                var Profile = new CustomProfileCommon();
                Profile.UserMenus = JsonConvert.SerializeObject(maList);
                Profile.UserInfo = JsonConvert.SerializeObject(userProfileInfo);

                Profile.Save();
            }
            catch { }
        }
    }
}