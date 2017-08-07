using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AHomeOfSelfDiscipline.Models;
using AlumniPlatform;
using DllLibrary.AES;

namespace AHomeOfSelfDiscipline.Controllers
{
    public class HomeController : CommonController
    {
       /// <summary>
       /// 首页
       /// </summary>
       /// <returns></returns>
       [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 登录前台
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登录后台
        /// </summary>
        [HttpPost]
        public ActionResult Login(LoginUser loginUser)
        {
            if (loginUser==null||!Security.CheckLogin(loginUser.Account,loginUser.Password))
            {
                return Content(Security.SweetAlert("错误提示", "用户名或者密码不正确"));
            }
            string role = CommonStatusCodes.Authority.User.ToString();
            var account = loginUser.Account.Trim();
            var password = loginUser.Password.Trim();
            var loginedUser = (from t in db.Users where t.StudentNumber==account||t.NickName==account select t).FirstOrDefault();
            if (loginedUser != null&&loginedUser.Authority!=CommonStatusCodes.Authority.User.ToString())
            {
                if (loginedUser.Authority == CommonStatusCodes.Authority.Admin.ToString())
                {
                    role = CommonStatusCodes.Authority.Admin.ToString();
                }
                else if(loginedUser.Authority==CommonStatusCodes.Authority.SuperAdmin.ToString())
                {
                    role = CommonStatusCodes.Authority.SuperAdmin.ToString();
                }
            }
            else if(loginedUser==null)
            {
                return Content(Security.SweetAlert("错误提示", "用户名不存在"));
            }
            if (!string.IsNullOrWhiteSpace(password) || loginedUser.Password == AES.Encrypt(password))
            {
                FormsAuthenticationTicket authentication = new FormsAuthenticationTicket
                    (
                     1,
                     loginedUser.Id.ToString(),
                     DateTime.Now,
                     DateTime.Now.AddMinutes(120),
                     false,
                     role
                    );
                string encrytedTicket = FormsAuthentication.Encrypt(authentication);

                HttpCookie authCookie=new HttpCookie(FormsAuthentication.FormsCookieName,encrytedTicket);

                Response.Cookies.Add(authCookie);
                if (role == CommonStatusCodes.Authority.User.ToString())
                {
                    return RedirectToAction("", "");
                }
                else if(role==CommonStatusCodes.Authority.Admin.ToString())
                {
                    return RedirectToAction("", "");
                }
                else
                {
                    return RedirectToAction("Index", "SuperAdmin");
                }
            }
            else
            {
                return Content(Security.SweetAlert("错误提示", "密码错误"));
            }
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult LoginOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}