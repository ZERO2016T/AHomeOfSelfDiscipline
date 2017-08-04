using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AHomeOfSelfDiscipline.Models
{
    public class AHomeDbContext:DbContext
    {
        /// <summary>
        /// 用户表
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// 公告表
        /// </summary>
        public virtual  DbSet<Notice> Notices { get; set; }

        /// <summary>
        /// 赛事表
        /// </summary>
        public virtual  DbSet<Match> Matches { get; set; }
    }
}