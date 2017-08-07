using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AHomeOfSelfDiscipline.Models;
using AlumniPlatform;
using DllLibrary.AES;
using PagedList;

namespace AHomeOfSelfDiscipline.Controllers
{
    //[Authorize(Roles ="SuperAdmin")]
    public class SuperAdminController : CommonController
    {
        // GET: SuperAdmin
        public ActionResult Index()
        {
           
            return View();
        }

        /// <summary>
        ///  添加用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        /// <summary>
        /// 添加用户后台
        /// </summary>
        [HttpPost]
        public ActionResult AddUser(BriefUserInfoes addUser)
        {
            if (addUser != null)
            {
                var verificationResult=Models.BriefUserInfoes.VerificationUserInfo(addUser);
                if (verificationResult == CommonStatusCodes.StatusCode.Success.ToString())
                {
                    if (db.Users.SingleOrDefault(m => m.StudentNumber == addUser.StudentNumber)==null)
                    {
                        Models.User user=new Models.User();
                        user.StudentNumber = addUser.StudentNumber;
                        user.Name = addUser.Name;
                        user.Password = AES.Encrypt(addUser.Password);
                        user.Authority = addUser.Authority;
                        user.GroupPost = addUser.GroupPost;
                        user.Post = addUser.Post;
                        user.SecondPost = addUser.SecondPost;
                        user.Photo= @"http://jiaowu.sicau.edu.cn/photo" + user.StudentNumber + ".jpg";
                        db.Users.Add(user);
                        db.SaveChanges();
                        return Content(Security.SweetAlert("成功", "该成员成功的加入到自律部"));
                    }
                    else
                    {
                        return Content(Security.SweetAlert("已存在", "该成员已经属于我们自律部了"));
                    }
                
                }
                else
                {
                    return Content(Security.SweetAlert("格式错误", verificationResult));
                }
            }
                return Content(Security.SweetAlert("空", "用户提交的信息为空"));
        }

        /// <summary>
        /// 用户管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UserManage(string content,string groupInfo= "AllGroup",int pageNumber=1)
        {
            int pageCont = 1;
            if (content == null && groupInfo == "AllGroup")
            {
                return View(db.Users.Where(m => m.Authority != CommonStatusCodes.Authority.SuperAdmin.ToString()).ToList().ToPagedList(pageNumber, pageCont));
            }
            IQueryable<Models.User> querayInfoes = null;
            if (content == "")
            {
                querayInfoes = db.Users.Where(m => m.GroupPost == groupInfo.Trim());
                if (!querayInfoes.Any())
                {
                    return Content(Security.SweetAlert("空", "未找到任何信息"));
                }
                return View(querayInfoes.ToList().ToPagedList(pageNumber, pageCont));
            }
            if (groupInfo == "AllGroup")
            {
                querayInfoes = db.Users.Where(m => m.StudentNumber.Contains(content.Trim()));
            }
            else
            {
                querayInfoes = from t in db.Users
                    where t.GroupPost == groupInfo.Trim() && t.StudentNumber.Contains(content.Trim())
                    select t;
            }
           
            if (!querayInfoes.Any())
            {
                return Content(Security.SweetAlert("空", "未找到任何信息"));
            }
            return View(querayInfoes.ToList().ToPagedList(pageNumber, pageCont));
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ActionResult ResetPassword(int? userId=0)
        {
            var currentUser = db.Users.SingleOrDefault(m => m.Id == userId);
            if (currentUser==null)
            {
                return Content(Security.SweetAlert("空", "没有找到该用户的信息"));
            }
            currentUser.Password = AES.Encrypt(currentUser.StudentNumber);
            db.SaveChanges();
            return Content(Security.SweetAlert("成功", "重置密码成功"));
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ActionResult DeleteUser(int? userId = 0)
        {
            var currentUser = db.Users.SingleOrDefault(m => m.Id == userId);
            if (currentUser == null)
            {
                return Content(Security.SweetAlert("空", "没有找到该用户的信息"));
            }
            db.Users.Remove(currentUser);
            db.SaveChanges();
            return Content(Security.SweetAlert("成功", "删除用户成功"));
        }
    }
    }
