using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHomeOfSelfDiscipline.Models
{
    /// <summary>
    /// 常用状态码
    /// </summary>
    public class CommonStatusCodes
    {
        /// <summary>
        /// 赛事类别
        /// </summary>
        public enum MatchClassCode
        { 
            /// <summary>
            /// 最美寝室
            /// </summary>
            MostBeautifulBedroom,

            /// <summary>
            /// 新生手册大赛
            /// </summary>
            FreshmanManual
        }

        /// <summary>
        /// 公告类别
        /// </summary>
        public enum NoticeClassCode
        {
            /// <summary>
            /// 长期
            /// </summary>
            LongTerm,

            /// <summary>
            /// 最新
            /// </summary>
            Update
        }

        /// <summary>
        /// 状态码
        /// </summary>
        public enum StatusCode
        {
            /// <summary>
            /// 成功
            /// </summary>
            Success,

            /// <summary>
            /// 失败
            /// </summary>
            Error
        }
    }
}