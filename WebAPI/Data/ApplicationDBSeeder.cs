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
            // Seed Roles
            await SeedRoles();

            // Seed Application Users
            await SeedApplicationUsers();
        }

        private async Task SeedRoles()
        {
            string[] roleNames = { "Head Librarian", "Librarian", "Member" };

            foreach (var roleName in roleNames)
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        private async Task SeedApplicationUsers()
        {
            // Check if Margaret Millan already exists
            var existingUser = await _userManager.FindByEmailAsync("mmilan@itsligo.ie");
            if (existingUser == null)
            {
                var margaretMillan = new ApplicationUser
                {
                    UserName = "mmilan@itsligo.ie",
                    Email = "mmilan@itsligo.ie",
                    Firstname = "Margaret",
                    Lastname = "Millan",
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(margaretMillan, "LibAdmin$1");

                if (result.Succeeded)
                {
                    // Add user to Head Librarian role
                    await _userManager.AddToRoleAsync(margaretMillan, "Head Librarian");
                }
            }
        }
    }
}

