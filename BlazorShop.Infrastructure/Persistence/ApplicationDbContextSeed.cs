namespace BlazorShop.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedAdminUserAsync(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            SeedDataModel seedData)
        {
            var adminRole = new AppRole
            {
                Name = seedData.AdminRoleName,
                NormalizedName = seedData.AdminRoleNormalized
            };

            var defaultRole = new AppRole
            {
                Name = seedData.DefaultRoleName,
                NormalizedName = seedData.DefaultRoleNormalized
            };

            if (roleManager.Roles.All(r => r.Name != adminRole.Name))
            {
                await roleManager.CreateAsync(adminRole);
            }
            if (roleManager.Roles.All(r => r.Name != defaultRole.Name))
            {
                await roleManager.CreateAsync(defaultRole);
            }

            var admin = new AppUser { UserName = seedData.Email, Email = seedData.Email, FirstName = seedData.FirstName, LastName = seedData.LastName };
            if (userManager.Users.All(u => u.UserName != admin.UserName))
            {
                await userManager.CreateAsync(admin, seedData.AdminPassword);
                await userManager.AddToRoleAsync(admin, adminRole.Name);
            }
        }

        public static async Task SeedBrandsDataAsync(ApplicationDbContext context)
        {
            if (!context.Brands.Any())
            {
                context.Brands.Add(new Brand { Name = "Nike" });
                context.Brands.Add(new Brand { Name = "Puma" });
                context.Brands.Add(new Brand { Name = "Adidas" });
                context.Brands.Add(new Brand { Name = "Lacoste" });
                context.Brands.Add(new Brand { Name = "Reebok" });
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedColorsDataAsync(ApplicationDbContext context)
        {
            if (!context.Colors.Any())
            {
                context.Colors.Add(new Color { Name = "red" });
                context.Colors.Add(new Color { Name = "green" });
                context.Colors.Add(new Color { Name = "yellow" });
                context.Colors.Add(new Color { Name = "blue" });
                context.Colors.Add(new Color { Name = "white" });
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedSizesDataAsync(ApplicationDbContext context)
        {
            if (!context.Sizes.Any())
            {
                context.Sizes.Add(new Size { Name = "small" });
                context.Sizes.Add(new Size { Name = "medium" });
                context.Sizes.Add(new Size { Name = "large" });
                context.Sizes.Add(new Size { Name = "extra-large" });
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedProductPhotosDataAsync(ApplicationDbContext context)
        {
            if (!context.ProductPhotos.Any())
            {
                context.ProductPhotos.Add(new ProductPhoto {
                    RelativePathImage = "assets/images/black.png",
                    Product = context.Products.FirstOrDefault(x => x.Id == 1)
                });
                context.ProductPhotos.Add(new ProductPhoto {
                    RelativePathImage = "assets/images/blue.png",
                    Product = context.Products.FirstOrDefault(x => x.Id == 2)
                });
                context.ProductPhotos.Add(new ProductPhoto {
                    RelativePathImage = "assets/images/green.png",
                    Product = context.Products.FirstOrDefault(x => x.Id == 3)
                });
                context.ProductPhotos.Add(new ProductPhoto {
                    RelativePathImage = "assets/images/img.png",
                    Product = context.Products.FirstOrDefault(x => x.Id == 4)
                });
                context.ProductPhotos.Add(new ProductPhoto {
                    RelativePathImage = "assets/images/img1.png",
                    Product = context.Products.FirstOrDefault(x => x.Id == 5)
                });
                context.ProductPhotos.Add(new ProductPhoto {
                    RelativePathImage = "assets/images/img2.png",
                    Product = context.Products.FirstOrDefault(x => x.Id == 6)
                });
                context.ProductPhotos.Add(new ProductPhoto {
                    RelativePathImage = "assets/images/img3.png",
                    Product = context.Products.FirstOrDefault(x => x.Id == 7)
                });
                context.ProductPhotos.Add(new ProductPhoto {
                    RelativePathImage = "assets/images/img4.png",
                    Product = context.Products.FirstOrDefault(x => x.Id == 8)
                });
                context.ProductPhotos.Add(new ProductPhoto {
                    RelativePathImage = "assets/images/NikeAirMax Motion2black.png",
                    Product = context.Products.FirstOrDefault(x => x.Id == 9)
                });
                context.ProductPhotos.Add(new ProductPhoto {
                    RelativePathImage = "assets/images/NikeAirMaxMotion2.png",
                    Product = context.Products.FirstOrDefault(x => x.Id == 10)
                });
                context.ProductPhotos.Add(new ProductPhoto {
                    RelativePathImage = "assets/images/orange.png",
                    Product = context.Products.FirstOrDefault(x => x.Id == 11)
                });
                context.ProductPhotos.Add(new ProductPhoto {
                    RelativePathImage = "assets/images/re.png",
                    Product = context.Products.FirstOrDefault(x => x.Id == 12)
                });
                await context.SaveChangesAsync();
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
                    Brand = context.Brands.FirstOrDefault(x => x.Id == 1)
                });
                context.Products.Add(new Product
                {
                    Name = "Puma lower",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(230.99),
                    Brand = context.Brands.FirstOrDefault(x => x.Id == 2)
                });
                context.Products.Add(new Product
                {
                    Name = "Dickson Extra",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(130.99),
                    Brand = context.Brands.FirstOrDefault(x => x.Id == 3)
                });
                context.Products.Add(new Product
                {
                    Name = "Shoes",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(850.99),
                    Brand = context.Brands.FirstOrDefault(x => x.Id == 4)
                });
                context.Products.Add(new Product
                {
                    Name = "Adidas",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(150.99),
                    Brand = context.Brands.FirstOrDefault(x => x.Id == 5)
                });
                context.Products.Add(new Product
                {
                    Name = "Reebok version 3",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(458.99),
                    Brand = context.Brands.FirstOrDefault(x => x.Id == 2)
                });
                context.Products.Add(new Product
                {
                    Name = "Extra Nike",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(450.99),
                    Brand = context.Brands.FirstOrDefault(x => x.Id == 1)
                });
                context.Products.Add(new Product
                {
                    Name = "Double size",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(40.99),
                    Brand = context.Brands.FirstOrDefault(x => x.Id == 3)
                });
                context.Products.Add(new Product
                {
                    Name = "Third Puma",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(341),
                    Brand = context.Brands.FirstOrDefault(x => x.Id == 1)
                });
                context.Products.Add(new Product
                {
                    Name = "Undoubtable",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(234),
                    Brand = context.Brands.FirstOrDefault(x => x.Id == 4)
                });
                context.Products.Add(new Product
                {
                    Name = "Nike air max v11",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(250),
                    Brand = context.Brands.FirstOrDefault(x => x.Id == 1)
                });
                context.Products.Add(new Product
                {
                    Name = "Nike sneakers",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque laborum optio natus quibusdam ea nam odit vitae id unde officia.",
                    Price = new decimal(120.99),
                    Brand = context.Brands.FirstOrDefault(x => x.Id == 1)
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
