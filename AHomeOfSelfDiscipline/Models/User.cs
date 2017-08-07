using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

namespace AHomeOfSelfDiscipline.Models
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class User
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Required]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 学号
        /// </summary>
        [Required]
        [MaxLength(11,ErrorMessage = "学号的最大长度为11个字符")]
        public string StudentNumber { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [MaxLength(11,ErrorMessage = "姓名的最大长度为11个字符")]
        public string Name { get; set; }


        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }


        /// <summary>
        /// 头像
        /// </summary>
        [Required]
        public string Photo { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 主题颜色
        /// </summary>
        public string ThemColor { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactPhoneNumber { get; set; }

        /// <summary>
        /// QQ号
        /// </summary>
        public string QQ { get; set; }


        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string MailAddress { get; set; }

        /// <summary>
        /// 座右铭
        /// </summary>
        public string Motto { get; set; }

       /// <summary>
       /// 班级
       /// </summary>
       public string Grade { get; set; }

      /// <summary>
      /// 专业
      /// </summary>
       public string Major { get; set; }

       /// <summary>
       /// 在校地址
       /// </summary>
       public string Address { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
       public string Post { get; set; }

        /// <summary>
        /// 第二职务
        /// </summary>
       public string SecondPost { get; set; }

       /// <summary>
       /// 权限
       /// </summary>
       public string Authority { get; set; }

       /// <summary>
       /// 职务组
       /// </summary>
       public string GroupPost { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
       public DateTime? CreateTime { get; set; }=DateTime.Now;

        /// <summary>
        /// 验证用户信息
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>字符串</returns>
        public static string VerificationUserInfo(User user)
        {
            //验证学号信息
            if (user.StudentNumber != null)
            {
                if (user.StudentNumber.Length < 6 || user.StudentNumber.Length > 11)
                {
                    return "学号的长度为[6,11]个字符";
                }
                else
                {
                    if (!new Regex(@"^[A-Za-z0-9]+$").IsMatch(user.StudentNumber))
                    {
                        return "学号只能由[6,11]个数字和字符构成";
                    }
                }
            }
            else
            {
                return "学号为空";
            }

           //验证姓名
            if (user.Name!=null)
            {
                if (user.Name.Length<2||user.Name.Length>11)
                {
                    return "姓名的长度为[2,11]个字符";
                }
            }
            else
            {
                return "姓名为空";
            }

            //验证密码
            if (user.Password != null)
            {
                if (user.Password.Length < 6 || user.Password.Length > 16)
                {
                    return "密码的长度为[6,16]个字符";
                }
                else
                {
                    if (!new Regex(@"^[A-Za-z0-9]+$").IsMatch(user.Password))
                    {
                        return "密码只能由[6,16]个数字和字符构成";
                    }
                }
            }
            else
            {
                return "密码为空";
            }

            //验证昵称
            if (user.NickName != null)
            {
                if (user.NickName.Length < 2 || user.NickName.Length > 10)
                {
                    return "昵称的长度为[2,10]个字符";
                }
            }
            else
            {
                return "昵称为空";
            }

            //验证性别
            if (user.Sex != null)
            {
                if (!(user.Sex == "男" || user.Sex == "女"))
                {
                    return "性别只能为男或女";
                }
            }
            else
            {
                return "性别为空";
            }

            //验证邮箱
            if (user.MailAddress != null)
            {
                if (user.MailAddress.Length < 3 || user.MailAddress.Length > 20)
                {
                    return "邮箱的地址长度为[3,20]";
                }
                else
                {
                    if (!(new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$").IsMatch(user.MailAddress)))
                    {
                        return "邮箱地址格式错误";
                    }
                }
               
            }
            else
            {
                return "邮箱地址为空";
            }

            //验证班级
            if (user.Grade != null)
            {
                if (user.Grade.Length < 6 || user.Grade.Length >6)
                {
                    return "班级的长度为6个字符";
                }
                {
                    if (!(new Regex(@"^\d{6}$").IsMatch(user.Grade)))
                    {
                        return "班级只能由六位数字构成,如201501";
                    }
                }
            }
            else
            {
                return "班级为空";
            }

            //验证专业
            if (user.Major != null)
            {
                if (user.Major.Length < 3 || user.Major.Length > 20)
                {
                    return "专业的长度为[3,20]个字符";
                }
            }
            else
            {
                return "专业为空";
            }

            ////验证出生日期
            //if (DateOfBirth != null)
            //{
            //    try
            //    {

            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e);
            //        throw;
            //    }
            //}

            //验证手机号码
            if (user.ContactPhoneNumber != null)
            {
                if (!(new Regex(@"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$").IsMatch(user
                    .ContactPhoneNumber)))
                {
                    return "电话号码格式不正确";
                }
            }

            //验证QQ
            if (user.QQ != null)
            {
                if (!(new Regex(@"^[1-9][0-9]{4,9}$").IsMatch(user.QQ)))
                {
                    return "QQ号码格式错误";
                }
            }
            
            //验证座右铭
            if (user.Motto!=null)
            {
                if (user.Motto.Length<3||user.Motto.Length>50)
                {
                    return "座右铭的长度为[3,50]";
                }
            }

            //验证在校地址
            if (user.Address != null)
            {
                if (user.Address.Length < 3 || user.Address.Length > 20)
                {
                    return "在校地址的长度为[3,20]";
                }
            }

            //验证权限
            if (user.Authority != null)
            {
                if (user.Authority!=CommonStatusCodes.Authority.SuperAdmin.ToString()||user.Authority!=CommonStatusCodes.Authority.Admin.ToString()||user.Authority!=CommonStatusCodes.Authority.User.ToString())
                {
                    return "用户角色只能为管理员或者普通用户";
                }
            }
            else
            {
                return "用户角色为空";
            }
            //验证用户的职务组
            if (user.GroupPost != null)
            {
                if (user.GroupPost != CommonStatusCodes.GroupCode.GangsterGroup.ToString() ||
                    user.GroupPost != CommonStatusCodes.GroupCode.OutreachGroup.ToString() ||
                    user.GroupPost != CommonStatusCodes.GroupCode.PersonnelSection.ToString() ||
                    user.GroupPost != CommonStatusCodes.GroupCode.PropagandaGroup.ToString() || user.GroupPost !=
                    CommonStatusCodes.GroupCode.SupervisionTeam.ToString())
                {
                    return "用户的职务中只能为人事组、监察组、外联组、宣传组、大佬组";
                }
            }
            else
            {
                return "用户职务组为空";
            }

            //验证用户第一职务
            if (user.Post != null)
            {
                if (user.Post != CommonStatusCodes.PostCode.Mohamed.ToString() ||
                    user.Post != CommonStatusCodes.PostCode.CommitteeMember.ToString() ||
                    user.Post != CommonStatusCodes.PostCode.Minister.ToString() ||
                    user.Post != CommonStatusCodes.PostCode.ViceMinister.ToString())
                {
                    return "用户的第一职务只能为部长、副部长、委员、干事";
                }
            }
            else
            {
                return "用户的第一职务为空";
            }

            //验证用户第二职务
            if (user.SecondPost != null)
            {
                if (user.SecondPost != CommonStatusCodes.PostCode.Empty.ToString() ||
                    user.SecondPost != CommonStatusCodes.PostCode.GroupLeader.ToString() || user.SecondPost !=
                    CommonStatusCodes.PostCode.DeputyTeamLeader.ToString())
                {
                    
                }
            }
            else
            {
                return "用户的第二职务为空";
            }
            return CommonStatusCodes.StatusCode.Success.ToString();
        }
    }

}