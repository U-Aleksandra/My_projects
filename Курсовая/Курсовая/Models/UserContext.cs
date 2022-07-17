using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Курсовая.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base("Оргкомитет_конференцииEntities")
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
    
}
