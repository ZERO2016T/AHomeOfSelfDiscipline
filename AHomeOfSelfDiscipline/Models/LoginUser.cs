using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHomeOfSelfDiscipline.Models
{
    public class LoginUser
    {
        /// <summary>
        /// 学号
        /// </summary>
        public string StudentNumber { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}