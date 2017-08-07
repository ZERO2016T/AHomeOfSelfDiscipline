using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AHomeOfSelfDiscipline.Models
{
    public class BriefUserInfoes
    {
      
        /// <summary>
        /// 学号
        /// </summary>
        [Required]
        [MaxLength(11, ErrorMessage = "学号的最大长度为11个字符")]
        public string StudentNumber { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [MaxLength(11, ErrorMessage = "姓名的最大长度为11个字符")]
        public string Name { get; set; }


        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }


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
        public DateTime? CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 验证用户信息
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>字符串</returns>
        public static string VerificationUserInfo(BriefUserInfoes user)
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
            if (user.Name != null)
            {
                if (user.Name.Length < 2 || user.Name.Length > 11)
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

            //验证权限
            if (user.Authority != null)
            {
                if (user.Authority != CommonStatusCodes.Authority.SuperAdmin.ToString()&&user.Authority != CommonStatusCodes.Authority.Admin.ToString()&&user.Authority != CommonStatusCodes.Authority.User.ToString())
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
                if (user.GroupPost != CommonStatusCodes.GroupCode.GangsterGroup.ToString() &&
                    user.GroupPost != CommonStatusCodes.GroupCode.OutreachGroup.ToString() &&
                    user.GroupPost != CommonStatusCodes.GroupCode.PersonnelSection.ToString() &&
                    user.GroupPost != CommonStatusCodes.GroupCode.PropagandaGroup.ToString() &&user.GroupPost !=
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
                if (user.Post != CommonStatusCodes.PostCode.Mohamed.ToString() &&
                    user.Post != CommonStatusCodes.PostCode.CommitteeMember.ToString() &&
                    user.Post != CommonStatusCodes.PostCode.Minister.ToString() &&
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
                if (user.SecondPost != CommonStatusCodes.PostCode.Empty.ToString() &&
                    user.SecondPost != CommonStatusCodes.PostCode.GroupLeader.ToString() && user.SecondPost !=
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