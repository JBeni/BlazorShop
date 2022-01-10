namespace BlazorShop.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedRolesAsync(
            RoleManager<AppRole> roleManager,
            RolesSeedModel seedData)
        {
            var adminRole = new AppRole
            {
                Name = seedData.AdminRoleName,
                NormalizedName = seedData.AdminRoleNormalizedName
            };
            var defaultRole = new AppRole
            {
                Name = seedData.DefaultRoleName,
                NormalizedName = seedData.DefaultRoleNormalizedName
            };
            var userRole = new AppRole
            {
                Name = seedData.UserRoleName,
                NormalizedName = seedData.UserRoleNormalizedName
            };

            if (roleManager.Roles.All(r => r.Name != adminRole.Name))
            {
                await roleManager.CreateAsync(adminRole);
            }
            if (roleManager.Roles.All(r => r.Name != defaultRole.Name))
            {
                await roleManager.CreateAsync(defaultRole);
            }
            if (roleManager.Roles.All(r => r.Name != userRole.Name))
            {
                await roleManager.CreateAsync(userRole);
            }
        }

        public static async Task SeedAdminUserAsync(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            AdminSeedModel seedData)
        {
            var admin = new AppUser
            {
                UserName = seedData.FirstName + " " + seedData.LastName,
                Email = seedData.Email,
                FirstName = seedData.FirstName,
                LastName = seedData.LastName
            };
            var adminRole = roleManager.Roles.Where(x => x.Name == seedData.RoleName).FirstOrDefault();
            if (adminRole == null) throw new Exception("The selected role does not exists.");

            if (userManager.Users.All(u => u.UserName != admin.UserName))
            {
                await userManager.CreateAsync(admin, seedData.Password);
                await userManager.AddToRoleAsync(admin, adminRole.Name);
            }
        }

        public static async Task SeedProductDataAsync(ApplicationDbContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.Add(new Product {
                    Name = "Nike Air",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(900.99),
                });
                context.Products.Add(new Product
                {
                    Name = "Puma lower",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(230.99),
                });
                context.Products.Add(new Product
                {
                    Name = "Dickson Extra",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(130.99),
                });
                context.Products.Add(new Product
                {
                    Name = "Shoes",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(850.99),
                });
                context.Products.Add(new Product
                {
                    Name = "Adidas",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(150.99),
                });
                context.Products.Add(new Product
                {
                    Name = "Reebok version 3",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(458.99),
                });
                context.Products.Add(new Product
                {
                    Name = "Extra Nike",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(450.99),
                });
                context.Products.Add(new Product
                {
                    Name = "Double size",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(40.99),
                });
                context.Products.Add(new Product
                {
                    Name = "Third Puma",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(341),
                });
                context.Products.Add(new Product
                {
                    Name = "Undoubtable",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(234),
                });
                context.Products.Add(new Product
                {
                    Name = "Nike air max v11",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(250),
                });
                context.Products.Add(new Product
                {
                    Name = "Nike sneakers",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(120.99),
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
