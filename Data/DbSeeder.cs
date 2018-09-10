using System;
using System.Linq;
using System.Threading.Tasks;
using JobberApp.Data.Models;
using JobberApp.Data.Models.Employee;
using Microsoft.AspNetCore.Identity;

namespace JobberApp.Data
{
    public class DbSeeder
    {
        #region Public Methods
        public static void Seed(
            ApplicationDbContext dbContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager
            )
        {
            // Create default Users (if there are none)
            if (!dbContext.Users.Any())
            {
                CreateUsers(dbContext, roleManager, userManager)
                    .GetAwaiter()
                    .GetResult();
            }

            if(!dbContext.Employers.Any())
            {
                CreateEmployersEmployees(dbContext).GetAwaiter().GetResult();
            }

            if(!dbContext.Locations.Any())
            {
                CreateTables(dbContext).GetAwaiter().GetResult();
            }        
        }
        #endregion

        #region Seed Methods

        private static async Task CreateEmployersEmployees(ApplicationDbContext dbContext){   

                
            dbContext.Employers.AddRange(
                new Employer { User = dbContext.Users.Single(s => s.UserName == "Ryan"), FullName = "Ryan Gearing", CompanyName = "Aliantz Tehnology", CompanyEmail = "someemail@aliantz.com", CompanyNumber = "123", VatNumber = "1234", HqCity = "Ploiesti", HqBuilding = "Bl. 12A", HqStreet = "Emil Racovita", HqPostalCode = "123567" },
                new Employer { User = dbContext.Users.Single(s => s.UserName == "Solice"), FullName = "Solice Johnson", CompanyName = "Softwin Group", CompanyEmail = "bibi@aliantz.com", CompanyNumber = "123", VatNumber = "1234", HqCity = "Brasov", HqBuilding = "A12", HqStreet = "George Bacovia", HqPostalCode = "45646" }  
            );

            dbContext.Employees.AddRange(
                new Employee { User = dbContext.Users.Single(s => s.UserName == "David"), FullName = "David White" },
                new Employee { User = dbContext.Users.Single(s => s.UserName == "Aurelian"), FullName = "Aurelian Moore" }
            ); 

            await dbContext.SaveChangesAsync();
        }      

        private static async Task CreateTables(ApplicationDbContext dbContext){ 

            dbContext.Locations.AddRange(
                new Location { Name = "Restaurant", Building = "A5", Street = "Some Street", City = "Bucharest", PostalCode = "123", Latitude = 134, Longitude = 234, Employer = dbContext.Employers.Single(s => s.FullName == "Ryan Gearing") },
                new Location { Name = "Bar", Building = "A6", Street = "Some Other Street", City = "Brasov", PostalCode = "1243", Latitude = 1344, Longitude = 2364, Employer = dbContext.Employers.Single(s => s.FullName == "Ryan Gearing") },
                new Location { Name = "Washing", Building = "R6", Street = "Some Other Street", City = "Ploiesti", PostalCode = "1243", Latitude = 1344, Longitude = 2364, Employer = dbContext.Employers.Single(s => s.FullName == "Solice Johnson") }
            );

            dbContext.Skills.AddRange(
                new Skill { Name = "Bartender" },
                new Skill { Name = "Washing Operator" }
            );            
      
            // dbContext.Messages.AddRange(
            //     new Message { Conversation = dbContext.Conversations.Single(s => s.Employee.FullName == "David Saracu"), Text = "Some sent message", SentAt = new DateTime(2017, 05, 02), User = dbContext.Users.Single(s => s.UserName == "Ryan") },
            //     new Message { Conversation = dbContext.Conversations.Single(s => s.Employee.FullName == "David Saracu"), Text = "Some Other message", SentAt = new DateTime(2016, 05, 04), User = dbContext.Users.Single(s => s.UserName == "David") },
            //     new Message { Conversation = dbContext.Conversations.Single(s => s.Employee.FullName == "David Saracu"), Text = "Some bla bla message", SentAt = new DateTime(2015, 05, 02), User = dbContext.Users.Single(s => s.UserName == "David") },
            //     new Message { Conversation = dbContext.Conversations.Single(s => s.Employee.FullName == "David Saracu"), Text = "Some sent message", SentAt = new DateTime(2017, 05, 01), User = dbContext.Users.Single(s => s.UserName == "David") },
            //     new Message { Conversation = dbContext.Conversations.Single(s => s.Employee.FullName == "David Saracu"), Text = "Some sent message", SentAt = new DateTime(2017, 04, 07), User = dbContext.Users.Single(s => s.UserName == "David") },
            //     new Message { Conversation = dbContext.Conversations.Single(s => s.Employee.FullName == "Aurelian Saracu"), Text = "Some Other message", SentAt = new DateTime(2013, 02, 11), User = dbContext.Users.Single(s => s.UserName == "Ryan") },
            //     new Message { Conversation = dbContext.Conversations.Single(s => s.Employee.FullName == "Aurelian Saracu"), Text = "Some bla bla message", SentAt = new DateTime(2014, 01, 12), User = dbContext.Users.Single(s => s.UserName == "Aurelian") },
            //     new Message { Conversation = dbContext.Conversations.Single(s => s.Employee.FullName == "Aurelian Saracu"), Text = "Some sent message", SentAt = new DateTime(2017, 08, 03), User = dbContext.Users.Single(s => s.UserName == "Aurelian") }
            // );

            dbContext.Cards.AddRange(
                new Card { NameOnCard = "Ryan Gearing", CVC = "123", Employer = dbContext.Employers.Single(s => s.FullName == "Ryan Gearing"), CardNumber = "1234567890123456", CardType = "Visa", ExpMonth = 5, ExpYear = 2019, ModifiedDate = new DateTime(2019, 05, 04)},
                new Card { NameOnCard = "Solice Johnson", CVC = "143", Employer = dbContext.Employers.Single(s => s.FullName == "Solice Johnson"), CardNumber = "1234567890234562", CardType = "Maestro", ExpMonth = 2, ExpYear = 2018, ModifiedDate = new DateTime(2020, 04, 05) }
            );

            await dbContext.SaveChangesAsync();

        }
        private static async Task CreateUsers(
            ApplicationDbContext dbContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            // local variables
            DateTime createdDate = new DateTime(2016, 03, 01, 12, 30, 00);
            DateTime lastModifiedDate = DateTime.Now;

            string role_Administrator = "Administrator";
            string role_Employer = "Employer";
            string role_Employee = "Employee";

            //Create Roles (if they doesn't exist yet)
            if (!await roleManager.RoleExistsAsync(role_Administrator))
            {
                await roleManager.CreateAsync(new IdentityRole(role_Administrator));
            }
            if (!await roleManager.RoleExistsAsync(role_Employer))
            {
                await roleManager.CreateAsync(new IdentityRole(role_Employer));
            }
            if (!await roleManager.RoleExistsAsync(role_Employee))
            {
                await roleManager.CreateAsync(new IdentityRole(role_Employee));
            }

            // Create the "Admin" ApplicationUser account
            var user_Admin = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "Admin",
                Email = "admin@testmakerfree.com",
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate,
                DisplayName = "Admin"
            };
            // Insert "Admin" into the Database and assign the "Administrator" and "Registered" roles to him.
            if (await userManager.FindByIdAsync(user_Admin.Id) == null)
            {
                await userManager.CreateAsync(user_Admin, "Pass4Admin");
                await userManager.AddToRoleAsync(user_Admin, role_Employer);
                await userManager.AddToRoleAsync(user_Admin, role_Administrator);
                await userManager.AddToRoleAsync(user_Admin, role_Employee);
                // Remove Lockout and E-Mail confirmation.
                user_Admin.EmailConfirmed = true;
                user_Admin.LockoutEnabled = false;
            }


            #if DEBUG
            // Create some sample registered user accounts Employers
            var user_Ryan = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "Ryan",
                Email = "ryan@testmakerfree.com",
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate,
                DisplayName = "Ryan Gearyng"
            };
            var user_Solice = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "Solice",
                Email = "solice@testmakerfree.com",
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate,
                DisplayName = "Solice Johnson"
            };
            var user_Vodan = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "Vodan",
                Email = "vodan@testmakerfree.com",
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate,
                DisplayName = "Vodan Black"
            };


            // Create some sample registered user accounts Employees
            var user_Aurelian = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "Aurelian",
                Email = "aurelian@testmakerfree.com",
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate,
                DisplayName = "Aurelian Moore"
            };
            var user_David = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "David",
                Email = "david@testmakerfree.com",
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate,
                DisplayName = "David White"
            };


            // Insert sample registered users into the Database and also assign the "Registered" role to him.
            if (await userManager.FindByIdAsync(user_Ryan.Id) == null)
            {
                await userManager.CreateAsync(user_Ryan, "Pass4Ryan");
                await userManager.AddToRoleAsync(user_Ryan, role_Employer);
                // Remove Lockout and E-Mail confirmation.
                user_Ryan.EmailConfirmed = true;
                user_Ryan.LockoutEnabled = false;
            }
            if (await userManager.FindByIdAsync(user_Solice.Id) == null)
            {
                await userManager.CreateAsync(user_Solice, "Pass4Solice");
                await userManager.AddToRoleAsync(user_Solice, role_Employer);
                // Remove Lockout and E-Mail confirmation.
                user_Solice.EmailConfirmed = true;
                user_Solice.LockoutEnabled = false;
            }
            if (await userManager.FindByIdAsync(user_Vodan.Id) == null)
            {
                await userManager.CreateAsync(user_Vodan, "Pass4Vodan");
                await userManager.AddToRoleAsync(user_Vodan, role_Employer);
                // Remove Lockout and E-Mail confirmation.
                user_Vodan.EmailConfirmed = true;
                user_Vodan.LockoutEnabled = false;
            }
            if (await userManager.FindByIdAsync(user_Aurelian.Id) == null)
            {
                await userManager.CreateAsync(user_Aurelian, "Pass4Aurelian");
                await userManager.AddToRoleAsync(user_Aurelian, role_Employee);
                // Remove Lockout and E-Mail confirmation.
                user_Aurelian.EmailConfirmed = true;
                user_Aurelian.LockoutEnabled = false;
            }
            if (await userManager.FindByIdAsync(user_David.Id) == null)
            {
                await userManager.CreateAsync(user_David, "Pass4David");
                await userManager.AddToRoleAsync(user_David, role_Employee);
                // Remove Lockout and E-Mail confirmation.
                user_David.EmailConfirmed = true;
                user_David.LockoutEnabled = false;
            }
           

        #endif  
            await dbContext.SaveChangesAsync();
        }


        
        #endregion
    }
}