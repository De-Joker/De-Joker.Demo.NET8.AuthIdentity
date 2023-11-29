using De_Joker.Demo.NET8.AuthIdentity.Repository.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De_Joker.Demo.NET8.AuthIdentity.Repository
{
    public class DemoDbContext : IdentityDbContext<User>
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {

        }
    }
}
