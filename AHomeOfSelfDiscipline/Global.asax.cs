using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace AHomeOfSelfDiscipline
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }


        public MvcApplication()
        {
            AuthorizeRequest += new EventHandler(MvcApplication_AuthorizeRequest);
        }

        protected void MvcApplication_AuthorizeRequest(object sender, EventArgs e)
        {
            // 取得认证Check的Cookie
            HttpCookie cookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (cookie == null) return;

            // 解密
            FormsAuthenticationTicket ticket = null;
            try
            {
                ticket = FormsAuthentication.Decrypt(cookie.Value);
            }
            catch (Exception)
            {
                return;
            }
            if (ticket == null) return;

            // 取得ticket.UserData中设定的角色
            string[] roles = ticket.UserData.Split(new char[] { ',' });

            // From认证中，使用IPrincipal对象中的GenericPrincipal类。
            // 该类由表示资格情报的FormsIdentity类和角色信息(string[]对象)组成。
            FormsIdentity identity = new FormsIdentity(ticket);
            GenericPrincipal principal = new GenericPrincipal(identity, roles);

            // 把FormsIdentity赋值到Context.User中
            // 可以从Page.User中取得该值
            Context.User = principal;

        }
    }
}
