using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AHomeOfSelfDiscipline.Models
{
    public class Match
    {
        /// <summary>
        /// 赛事表主键
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 发布者Id
        /// </summary>
        public int? PulisherId { get; set; }

        /// <summary>
        /// 发布者姓名
        /// </summary>
        public int PulisherName { get; set; }

        /// <summary>
        ///赛事主题
        /// </summary>
        public string MatchSubject { get; set; }

        /// <summary>
        /// 赛事内容
        /// </summary>
        public string MatchContent { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PublishTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 发布类别
        /// </summary>
        public string PublcationCategory { get; set; }

        /// <summary>
        /// 验证赛事类对象
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public static string VerificationMatch(Match match)
        {
            //验证赛事主题
            if (match.MatchSubject != null)
            {
                if (match.MatchSubject.Length < 6 || match.MatchSubject.Length > 30)
                {
                    return "赛事主题的长度为[6,30]个字符";
                }
            }
            else
            {
                return "赛事主题为空";
            }

            //验证发布类别
            if (match.PublcationCategory !=CommonStatusCodes.MatchClassCode.MostBeautifulBedroom.ToString() || match.PublcationCategory !=CommonStatusCodes.MatchClassCode.FreshmanManual.ToString())
            {
                return "赛事类别只能为最美寝室或者新生手册";
            }

            return CommonStatusCodes.StatusCode.Success.ToString();
        }
         
    }
}