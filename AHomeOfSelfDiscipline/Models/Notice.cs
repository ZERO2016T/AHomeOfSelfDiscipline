using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AHomeOfSelfDiscipline.Models
{
    public class Notice
    {
        /// <summary>
        /// 公告表主键
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 发布者Id
        /// </summary>
        public int PulisherId { get; set; }

        /// <summary>
        /// 发布者姓名
        /// </summary>
        public int PulisherName { get; set; }

        /// <summary>
        /// 公告主题
        /// </summary>
        public string NoticeSubject { get; set; }

        /// <summary>
        /// 公告内容
        /// </summary>
        public string NoticeContent { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public string PublishTime { get; set; }

        /// <summary>
        /// 发布类别
        /// </summary>
        public string PublcationCategory { get; set; }

        public string VerificationMatch(Notice notice)
        {
            //验证赛事主题
            if (notice.NoticeSubject != null)
            {
                if (notice.NoticeSubject.Length < 6 || notice.NoticeSubject.Length > 30)
                {
                    return "公告主题的长度为[6,30]个字符";
                }
            }
            else
            {
                return "公告主题为空";
            }

            //验证发布类别
            if (notice.PublcationCategory != CommonStatusCodes.MatchClassCode.MostBeautifulBedroom.ToString() || notice.PublcationCategory != CommonStatusCodes.MatchClassCode.FreshmanManual.ToString())
            {
                return "公告类别只能为最新公告或者长期公告";
            }

            return CommonStatusCodes.StatusCode.Success.ToString();
        }
    }
}