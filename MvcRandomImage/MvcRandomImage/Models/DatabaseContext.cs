using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcRandomImage.Models
{
    /// <summary>
    /// Contains information for a database and its server
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// returns user model entity set
        /// </summary>
        public DbSet<User> user { get; set; }

    }
} 