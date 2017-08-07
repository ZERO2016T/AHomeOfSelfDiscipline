using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AHomeOfSelfDiscipline.Models;

namespace AHomeOfSelfDiscipline.Controllers
{
    public class CommonController : Controller
    {
        /// <summary>
        /// 数据库
        /// </summary>
       public static AHomeDbContext db=new AHomeDbContext();
    }
}