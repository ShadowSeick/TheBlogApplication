using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBlogApplication.Data;
using TheBlogApplication.Enums;
using TheBlogApplication.Models;

namespace TheBlogApplication.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;

        public DataService(ApplicationDbContext dbContext, 
                           RoleManager<IdentityRole> roleManager, 
                           UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {
            //Task 1: Seed a few Roles into the system
            await SeedRolesAsync();

            //Task 2: Seed a few users into the system
            await SeedUsersAsync();
        }

        private async Task SeedRolesAsync()
        {
            //If there are already Roles in the system, do nothing.
            if (_dbContext.Roles.Any())
            {
                return;
            }

            //Otherwise we want to create a few Roles
            foreach(var role in Enum.GetNames(typeof(BlogRole)))
            {
                //I need to use the Role Manager to create roles
                await _roleManager.CreateAsync(new IdentityRole(role));
            }

        }

        private async Task SeedUsersAsync()
        {
            //If there are already Users in the system, do nothing.
            if (_dbContext.Users.Any())
            {
                return;
            }

            //Step 1: Creates a new instance of BlogUser
            var adminUser = new BlogUser()
            {
                Email = "alcolka@gmail.com",
                UserName = "alcolka@gmail.com",
                FirstName = "Adrián",
                LastName = "Muñoz",
                PhoneNumber = "901283049",
                EmailConfirmed = true
            };

            //Step 2: Use the UserManager to create a new user that is defined by the adminUser
            await _userManager.CreateAsync(adminUser, "ASDF!1234");

            //Step 3: Add this new user to the Adminsitrator role
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

            //Step 1: Creates a new instance of BlogUser
            var modUser = new BlogUser()
            {
                Email = "adrian.munoz.gonza@gmail.com",
                UserName = "adrian.munoz.gonza@gmail.com",
                FirstName = "Adrián",
                LastName = "Muñoz",
                PhoneNumber = "90128304",
                EmailConfirmed = true
            };

            //Step 2: Use the UserManager to create a new user that is defined by the adminUser
            await _userManager.CreateAsync(modUser, "ASDF!1234");

            //Step 3: Add this new user to the Adminsitrator role
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());
        }







    }
}
