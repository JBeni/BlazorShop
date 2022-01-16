namespace BlazorShop.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedRolesAsync(
            RoleManager<Role> roleManager,
            RolesSeedModel seedData)
        {
            var adminRole = new Role
            {
                Name = seedData.AdminRoleName,
                NormalizedName = seedData.AdminRoleNormalizedName
            };
            var defaultRole = new Role
            {
                Name = seedData.DefaultRoleName,
                NormalizedName = seedData.DefaultRoleNormalizedName
            };
            var userRole = new Role
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
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            AdminSeedModel seedData)
        {
            var admin = new User
            {
                UserName = seedData.FirstName + "@" + seedData.LastName,
                Email = seedData.Email,
                FirstName = seedData.FirstName,
                LastName = seedData.LastName,
                IsActive = true,
            };
            var adminRole = roleManager.Roles.Where(x => x.Name == seedData.RoleName).FirstOrDefault();
            if (adminRole == null) throw new Exception("The selected role does not exists.");

            if (userManager.Users.All(u => u.Email != admin.Email))
            {
                await userManager.CreateAsync(admin, seedData.Password);
                await userManager.AddToRoleAsync(admin, adminRole.Name);
            }
        }

        public static async Task SeedClothesDataAsync(ApplicationDbContext context)
        {
            if (!context.Clothes.Any())
            {
                context.Clothes.Add(new Clothe
                {
                    Name = "Jeans 1",
                    Description = "asdsad sdasd sad asd dsa",
                    Price = new decimal(344.00), Amount = 12,
                    ImageName = "buy-3",
                    ImagePath = "buy-3.jpg",
                    IsActive = true
                });
                context.Clothes.Add(new Clothe
                {
                    Name = "Shoes 1",
                    Description = "sadf adas das dasdasd",
                    Price = new decimal(412.00),
                    Amount = 3,
                    ImageName = "category-1",
                    ImagePath = "category-1.jpg",
                    IsActive = true
                });
                context.Clothes.Add(new Clothe
                {
                    Name = "Shoes 3",
                    Description = "as asd asd asdsa d asdas asda sdasd",
                    Price = new decimal(702.00),
                    Amount = 16,
                    ImageName = "category-2",
                    ImagePath = "category-2.jpg",
                    IsActive = true
                });
                context.Clothes.Add(new Clothe
                {
                    Name = "Shoes 4",
                    Description = "adsa sdas das das das dasdasd asdasdasd",
                    Price = new decimal(353.00),
                    Amount = 6,
                    ImageName = "product-2",
                    ImagePath = "product-2.jpg",
                    IsActive = true
                });
                context.Clothes.Add(new Clothe
                {
                    Name = "Jeans 2",
                    Description = "dasd asd asdas dasdasdasdasd asdasdasdasd",
                    Price = new decimal(1243.00),
                    Amount = 13,
                    ImageName = "product-3",
                    ImagePath = "product-3.jpg",
                    IsActive = true
                });
                context.Clothes.Add(new Clothe
                {
                    Name = "T-shirt 1",
                    Description = "fdg dfgdfgdf gdf gdfgdfdfg df",
                    Price = new decimal(223.00),
                    Amount = 10,
                    ImageName = "product-4",
                    ImagePath = "product-4.jpg",
                    IsActive = true
                });
                context.Clothes.Add(new Clothe 
                {
                    Name = "Shoes 5",
                    Description = "as asd as  sadas sad sa sd asdas",
                    Price = new decimal(456.00),
                    Amount = 3,
                    ImageName = "product-5",
                    ImagePath = "product-5.jpg",
                    IsActive = true
                });
                context.Clothes.Add(new Clothe
                {
                    Name = "T-shirt 2",
                    Description = "sdf sdfsd sd dsf sdf sd fsdfds",
                    Price = new decimal(324.00),
                    Amount = 4,
                    ImageName = "product-6",
                    ImagePath = "product-6.jpg",
                    IsActive = true
                });
                context.Clothes.Add(new Clothe 
                {
                    Name = "Socks",
                    Description = "df fdg fdg dfg dfgdfgdfgfdgdfg",
                    Price = new decimal(106.00),
                    Amount = 8,
                    ImageName = "product-7",
                    ImagePath = "product-7.jpg",
                    IsActive = true
                });
                context.Clothes.Add(new Clothe
                {
                    Name = "Shoes 6",
                    Description = "fdsf sdf sdfsdfsd sd sdf sdf sdfsd fsdf d  dfd fd d fd",
                    Price = new decimal(353.00),
                    Amount = 5,
                    ImageName = "product-10",
                    ImagePath = "product-10.jpg",
                    IsActive = true
                });
                context.Clothes.Add(new Clothe
                {
                    Name = "Shoes 7",
                    Description = "asd asd asdf fg  hsd sdfs fdsg fg hsd",
                    Price = new decimal(765.00),
                    Amount = 8,
                    ImageName = "product-11",
                    ImagePath = "product-11.jpg",
                    IsActive = true
                });
                context.Clothes.Add(new Clothe
                {
                    Name = "Jeans 3",
                    Description = "as  asd asd fgf ds sd fds sdf sfsd sdfsdf",
                    Price = new decimal(867.00),
                    Amount = 17,
                    ImageName = "product-12",
                    ImagePath = "  product-12.jpg",
                    IsActive = true
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
