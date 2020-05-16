using DBQWebsite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBQWebsite.Data
{
    public class DBQContext : IdentityDbContext
    {
        public DBQContext(DbContextOptions<DBQContext> options)
            : base(options)
        {

        }

        public DbSet<Tier> Tier { get; set; }
        //public DbSet<User> User { get; set; }
        public DbSet<PolicyDog> PolicyDog { get; set; }
        public DbSet<PolicyDogQuestionAnswer> PolicyDogQuestionAnswer { get; set; }

    }
}
