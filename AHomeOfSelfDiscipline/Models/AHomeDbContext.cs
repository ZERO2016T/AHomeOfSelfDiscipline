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
    }
}