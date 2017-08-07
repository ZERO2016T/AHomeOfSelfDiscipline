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

        /// <summary>
        /// 权限码
        /// </summary>
        public enum Authority
        {
            /// <summary>
            /// 超级管理员
            /// </summary>
            SuperAdmin,

            /// <summary>
            ///管理员 
            /// </summary>
            Admin,

            /// <summary>
            /// 用户
            /// </summary>
            User
        }

        /// <summary>
        /// 职务码
        /// </summary>
        public enum PostCode
        {
            /// <summary>
            /// 部长
            /// </summary>
            Minister,

            /// <summary>
            /// 副部长
            /// </summary>
            ViceMinister,

            /// <summary>
            /// 委员
            /// </summary>
            CommitteeMember,

            /// <summary>
            /// 干事
            /// </summary>
            Mohamed,

            /// <summary>
            /// 组长
            /// </summary>
            GroupLeader,

            /// <summary>
            /// 副组长
            /// </summary>
            DeputyTeamLeader,

            /// <summary>
            /// 暂无
            /// </summary>
            Empty
        }
        
        /// <summary>
        /// 组别码
        /// </summary>
        public enum GroupCode
        {
            /// <summary>
            /// 人事组
            /// </summary>
            PersonnelSection,

            /// <summary>
            /// 监察组
            /// </summary>
            SupervisionTeam,

            /// <summary>
            /// 外联组
            /// </summary>
            OutreachGroup,

            /// <summary>
            /// 宣传组
            /// </summary>
            PropagandaGroup,

            /// <summary>
            /// 大佬组
            /// </summary>
            GangsterGroup ,
            
            /// <summary>
            /// 所有组
            /// </summary>
            AllGroup
        }
    }
}