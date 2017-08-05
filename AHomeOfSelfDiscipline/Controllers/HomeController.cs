using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AHomeOfSelfDiscipline.Models;

namespace AHomeOfSelfDiscipline.Controllers
{
    public class HomeController : Controller
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
        /// 登录
        /// </summary>
        [HttpGet]
        public ActionResult Login(LoginUser loginUser)
        {
            return View();
        }

    }
}