using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;
using System.Net;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AlumniPlatform
{
    /// <summary>
    /// 安全检查类
    /// </summary>
    public class Security
    {

        #region 检查数据合法性
        /// <summary>
        /// 检查登录
        /// </summary>
        /// <param name="account">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        static public bool CheckLogin(string account, string password)
        {
            if (account == null || password == null)
            {
                return false;
            }
            if ((Regex.IsMatch(account, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4})$") || Regex.IsMatch(account, @"^[a-zA-Z0-9]{6,16}$")) && Regex.IsMatch(password, @"^[0-9a-zA-Z]{6,16}$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 自定义前台显示信息
        /// </summary>
        /// <param name="title">主题</param>
        /// <param name="content">内容</param>
        /// <param name="func">附加执行语句</param>
        /// <returns>组合成的页面</returns>
        static public string SweetAlert(string title, string content, string func = null)
        {
            if (func == null)
            {
                return "<html><head><link href='/Content/Shared/sweetalert.css' rel='stylesheet'/><script src='/scripts/sweetalert-dev.js'></script></head><body><script>try{swal({title:'" + title + "', text:'" + content + "'},function(){location.href=document.referrer;});}catch(e){alert('" + title + ":" + content + "');location.href=document.referrer;}</script></body></html>";
            }
            else
            {
                return "<html><head><link href='/Content/Shared/sweetalert.css' rel='stylesheet'/><script src='/scripts/sweetalert-dev.js'></script></head><body><script>try{swal({title:'" + title + "', text:'" + content + "'},function(){" + func + "});}catch(e){alert('" + title + ":" + content + "');" + func + "}</script></body></html>";
            }
        }
        #endregion

    }
}