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
        public int PulisherId { get; set; }

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
        public string PublishTime { get; set; }

        /// <summary>
        /// 发布类别
        /// </summary>
        public string PublcationCategory { get; set; }
    }
}