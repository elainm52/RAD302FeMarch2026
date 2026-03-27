using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using DataModel;

namespace ApplicationDb.DataModel
{
  public class ApplicationDbSeeder
  {
    private readonly ApplicationDbContext _ctx;

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationDbSeeder(ApplicationDbContext ctx, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _ctx = ctx;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task Seed()
        {
         // Seed your application user and role here
        }
    }
}

