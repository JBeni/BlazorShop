// <copyright file="ApplicationDbContextSeed.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Persistence
{
    /// <summary>
    /// The database seed data to run at runtime.
    /// </summary>
    public static class ApplicationDbContextSeed
    {
        /// <summary>
        /// Adding the custom claims data when the app is deploy the first time.
        /// </summary>
        /// <param name="context">The instance of <see cref="IApplicationDbContext"/> to use.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task SeedCustomClaimsAsync(ApplicationDbContext context)
        {
            if (!context.CustomClaims.Any())
            {
                context.CustomClaims.AddRange(new List<CustomClaim>
                {
                    new CustomClaim
                    {
                        ClaimType = ClaimTypes.Role,
                        ClaimValue = "BASIC",
                    },
                    new CustomClaim
                    {
                        ClaimType = ClaimTypes.Role,
                        ClaimValue = "PRO",
                    },
                    new CustomClaim
                    {
                        ClaimType = ClaimTypes.Role,
                        ClaimValue = "ENTERPRISE",
                    },
                });

                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Adding the roles data when the app is deploy the first time.
        /// </summary>
        /// <param name="roleManager">The instance of <see cref="RoleManager{Role}"/> to use.</param>
        /// <param name="seedData">The seed data.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task SeedRolesAsync(RoleManager<Role> roleManager, RolesSeedModel seedData)
        {
            var adminRole = new Role
            {
                Name = seedData.AdminRoleName,
                NormalizedName = seedData.AdminRoleNormalizedName,
            };
            var defaultRole = new Role
            {
                Name = seedData.DefaultRoleName,
                NormalizedName = seedData.DefaultRoleNormalizedName,
            };
            var userRole = new Role
            {
                Name = seedData.UserRoleName,
                NormalizedName = seedData.UserRoleNormalizedName,
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

        /// <summary>
        /// Adding the admin data when the app is deploy the first time.
        /// </summary>
        /// <param name="userManager">The instance of <see cref="UserManager{User}"/> to use.</param>
        /// <param name="roleManager">The instance of <see cref="RoleManager{Role}"/> to use.</param>
        /// <param name="seedData">The seed data.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task SeedAdminUserAsync(UserManager<User> userManager, RoleManager<Role> roleManager, AdminSeedModel seedData)
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
            if (adminRole == null)
            {
                throw new Exception("The selected role does not exists.");
            }

            if (userManager.Users.All(u => u.Email != admin.Email))
            {
                await userManager.CreateAsync(admin, seedData.Password);
                await userManager.AddToRoleAsync(admin, adminRole.Name);
            }
        }

        /// <summary>
        /// Adding the clothes data when the app is deploy the first time.
        /// </summary>
        /// <param name="context">The instance of <see cref="IApplicationDbContext"/> to use.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
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
                    IsActive = true,
                });
                context.Clothes.Add(new Clothe
                {
                    Name = "Shoes 1",
                    Description = "sadf adas das dasdasd",
                    Price = new decimal(412.00),
                    Amount = 3,
                    ImageName = "category-1",
                    ImagePath = "category-1.jpg",
                    IsActive = true,
                });
                context.Clothes.Add(new Clothe
                {
                    Name = "Shoes 3",
                    Description = "as asd asd asdsa d asdas asda sdasd",
                    Price = new decimal(702.00),
                    Amount = 16,
                    ImageName = "category-2",
                    ImagePath = "category-2.jpg",
                    IsActive = true,
                });
                context.Clothes.Add(new Clothe
                {
                    Name = "Shoes 4",
                    Description = "adsa sdas das das das dasdasd asdasdasd",
                    Price = new decimal(353.00),
                    Amount = 6,
                    ImageName = "product-2",
                    ImagePath = "product-2.jpg",
                    IsActive = true,
                });
                context.Clothes.Add(new Clothe
                {
                    Name = "Jeans 2",
                    Description = "dasd asd asdas dasdasdasdasd asdasdasdasd",
                    Price = new decimal(1243.00),
                    Amount = 13,
                    ImageName = "product-3",
                    ImagePath = "product-3.jpg",
                    IsActive = true,
                });
                context.Clothes.Add(new Clothe
                {
                    Name = "T-shirt 1",
                    Description = "fdg dfgdfgdf gdf gdfgdfdfg df",
                    Price = new decimal(223.00),
                    Amount = 10,
                    ImageName = "product-4",
                    ImagePath = "product-4.jpg",
                    IsActive = true,
                });
                context.Clothes.Add(new Clothe
                {
                    Name = "Shoes 5",
                    Description = "as asd as  sadas sad sa sd asdas",
                    Price = new decimal(456.00),
                    Amount = 3,
                    ImageName = "product-5",
                    ImagePath = "product-5.jpg",
                    IsActive = true,
                });
                context.Clothes.Add(new Clothe
                {
                    Name = "T-shirt 2",
                    Description = "sdf sdfsd sd dsf sdf sd fsdfds",
                    Price = new decimal(324.00),
                    Amount = 4,
                    ImageName = "product-6",
                    ImagePath = "product-6.jpg",
                    IsActive = true,
                });
                context.Clothes.Add(new Clothe
                {
                    Name = "Socks",
                    Description = "df fdg fdg dfg dfgdfgdfgfdgdfg",
                    Price = new decimal(106.00),
                    Amount = 8,
                    ImageName = "product-7",
                    ImagePath = "product-7.jpg",
                    IsActive = true,
                });
                context.Clothes.Add(new Clothe
                {
                    Name = "Shoes 6",
                    Description = "fdsf sdf sdfsdfsd sd sdf sdf sdfsd fsdf d  dfd fd d fd",
                    Price = new decimal(353.00),
                    Amount = 5,
                    ImageName = "product-10",
                    ImagePath = "product-10.jpg",
                    IsActive = true,
                });
                context.Clothes.Add(new Clothe
                {
                    Name = "Shoes 7",
                    Description = "asd asd asdf fg  hsd sdfs fdsg fg hsd",
                    Price = new decimal(765.00),
                    Amount = 8,
                    ImageName = "product-11",
                    ImagePath = "product-11.jpg",
                    IsActive = true,
                });
                context.Clothes.Add(new Clothe
                {
                    Name = "Jeans 3",
                    Description = "as  asd asd fgf ds sd fds sdf sfsd sdfsdf",
                    Price = new decimal(867.00),
                    Amount = 17,
                    ImageName = "product-12",
                    ImagePath = "product-12.jpg",
                    IsActive = true,
                });

                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Adding the musics data when the app is deploy the first time.
        /// </summary>
        /// <param name="context">The instance of <see cref="IApplicationDbContext"/> to use.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task SeedMusicsDataAsync(ApplicationDbContext context)
        {
            if (!context.Musics.Any())
            {
                context.Musics.Add(new Music
                {
                    Title = "Green Day: American Idiot",
                    Description = "Green Day were a defining band for a whole generation of kids in the 00s, and their seventh studio album American Idiot became the rebellious punk-rock bible for many. The concept album featured a punk-rock adolescent folk hero of sorts and was packed with hit singles like Wake Me Up When September Ends, Holiday and Boulevard of Broken Dreams, but none captured the boisterous energy of Billie Joe Armstrongs vocals and deep-seated political scorn like the title track. With a Clash-like spirit and contemporary pop-punk framework, Armstrong points to the conservative medias (Fox News) normalization of war and fear-mongering that led to the proliferation of American hysteria, idiocy and the empowerment of redneck, right-wing America.",
                    Author = "Lizzie Manno",
                    DateRelease = new DateTime(2020, 12, 25),
                    ImageName = "music-1",
                    ImagePath = "music-1.jpg",
                });
                context.Musics.Add(new Music
                {
                    Title = "Supergrass: In It For The Money",
                    Description = "Though Britpop stalwarts Supergrass were unfairly overshadowed by Oasis, Blur and Pulp in the press and became largely associated with their kooky debut album I Should Coco (featuring their 1995 hit Alright), the bands second album, In It For The Money proves they were just as capable and exciting as their peers. The albums title track is one of their most memorable songs with frontman Gaz Coombes hearty, infectious lead vocals, bassist Mick Quinns ever-underrated backing vocals and the alt-rock rapture created by triumphant horns and Danny Goffeys spirited drum assault. After hearing the opening vocals on this track, you wont find yourself absorbed by Coombes distinct sideburns or their wacko Alright video—they were a serious band capable of earworm melodies and frequent pop/rock genius.",
                    Author = "Lizzie Manno",
                    DateRelease = new DateTime(2022, 1, 15),
                    ImageName = "music-2",
                    ImagePath = "music-2.jpg",
                });
                context.Musics.Add(new Music
                {
                    Title = "Joni Mitchell: Blue",
                    Description = "The first side of Joni Mitchells fourth studio album Blue ends with its title track, a piano and vocal only lament that floats from the inside of a particularly troubled relationship. Mitchell knows those well having famously struggled to maintain normalcy as shes dated some equally famous men during the fallout of the idealistic 60s. Who she is singing about in this heartrending tune is up for debate, but what is never in doubt is her tortured feelings at watching this person fall prey to the allure of acid, booze and ass, needles, guns and grass. Mitchell knows such delights are a zero-sum game and that she has to let this person float free lest they drag her down with them. She leaves them with this song, a foggy lullaby thats devastating in its simplicity and poetic charge.",
                    Author = "Robert Ham",
                    DateRelease = new DateTime(2019, 8, 30),
                    ImageName = "music-3",
                    ImagePath = "music-3.jpg",
                });
                context.Musics.Add(new Music
                {
                    Title = "Brandi Carlile: The Story",
                    Description = "Brandi Carlile doesnt just tell The Story, she releases it. The title track from her striking 2007 sophomore LP is an explosion of feeling, perhaps Carliles strongest emotional effort in a catalogue well-stocked with pathos. And all of my friends who think that Im blessed, she sings. They dont know my head is a mess. Carliles raspy vocal delivery intensifies as the track does, Carlile declaring that her stories dont mean anything when youve got no one to tell them to and promptly yanking at your heartstrings. In the end, theres just one person with whom Carlile can reveal her stories, a.k.a. her secrets: They dont know what Ive been through like you do / And I was made for you.",
                    Author = "Ellen Johnson",
                    DateRelease = new DateTime(2011, 11, 11),
                    ImageName = "music-4",
                    ImagePath = "music-4.jpg",
                });
                context.Musics.Add(new Music
                {
                    Title = "Cher: Believe",
                    Description = "Cher is an icon. Since the 1970s, shes been flawlessly transforming herself with every decade. In all that storied career, though, Believe stands out as her most popular song by far—on Spotify alone its been listened to more than 112 million times. Cher diehards know that this was the title track and opener of her 1998 album. Weve been listening to the song for 20 years now, and I dont think well ever tire of singing along emphatically.",
                    Author = "Annie Black",
                    DateRelease = new DateTime(2022, 1, 19),
                    ImageName = "music-5",
                    ImagePath = "music-5.jpg",
                });
                context.Musics.Add(new Music
                {
                    Title = "Kevin Morby: City Music",
                    Description = "Kevin Morbys fourth solo album is a dusky ode to urban life, and its core is its seven-minute-long title track, which perfectly captures a carefree wander down a city street on a warm summer night. City Music travels at a walking pace atop a pulsing bass line, as Morby coolly sings a love song to downtown sounds. But its his army of guitars that make this tune truly soar. Theyre squirrelly and skyscraping and seductive, like Television plucked out of a New York City punk dive and plunked down in front of some sweeping L.A. vista at sunset. That vibe? Thats the vibe that carried City Music to the top of our list of 2017s best songs.",
                    Author = "Ben Salmon",
                    DateRelease = new DateTime(2015, 5, 15),
                    ImageName = "music-6",
                    ImagePath = "music-6.jpg",
                });
                context.Musics.Add(new Music
                {
                    Title = "Mitski, 'The Only Heartbreaker'",
                    Description = "Mitski couldn’t let 2021 end without dropping by to say hello, igniting an Eighties firecracker to signal the arrival of an album next year that (if her previous track record is any indication) will most likely emotionally destroy us. The Only Heartbreaker was written with Dan Wilson — the first-ever co-write in her catalogue — and it shows the indie rocker flipping the narrative of a love song on its head. This time, she’s the Bad Guy. “I wanted to depict something sadder beneath the surface, that maybe the reason you’re always the one making mistakes is because you’re the only one trying,",
                    Author = "Ben Salmon",
                    DateRelease = new DateTime(2013, 9, 15),
                    ImageName = "music-2",
                    ImagePath = "music-2.jpg",
                });
                context.Musics.Add(new Music
                {
                    Title = "Kevin: City Music English",
                    Description = "Kevin Morbys fourth solo album is a dusky ode to urban life, and its core is its seven-minute-long title track, which perfectly captures a carefree wander down a city street on a warm summer night. City Music travels at a walking pace atop a pulsing bass line, as Morby coolly sings a love song to downtown sounds. But its his army of guitars that make this tune truly soar. Theyre squirrelly and skyscraping and seductive, like Television plucked out of a New York City punk dive and plunked down in front of some sweeping L.A. vista at sunset. That vibe? Thats the vibe that carried City Music to the top of our list of 2017s best songs.",
                    Author = "Martin Salmon",
                    DateRelease = new DateTime(2019, 5, 15),
                    ImageName = "music-6",
                    ImagePath = "music-6.jpg",
                });

                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Adding the subscription data when the app is deploy the first time.
        /// </summary>
        /// <param name="context">The instance of <see cref="IApplicationDbContext"/> to use.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task SeedSubscriptionsDataAsync(ApplicationDbContext context)
        {
            if (!context.Subscriptions.Any())
            {
                context.Subscriptions.Add(new Subscription
                {
                    Name = "Basic",
                    Price = 10,
                    Currency = "usd",
                    CurrencySymbol = "$",
                    ChargeType = "month",
                    Options = "3 music songs included, Email support, 25% discount",
                    StripeSubscriptionId = "price_1KKjybAtLEfG8Jr34XNaPOQ7",
                    ImageName = "Basic Subscription",
                    ImagePath = "basic_subscription.png",
                });
                context.Subscriptions.Add(new Subscription
                {
                    Name = "Pro",
                    Price = 25,
                    Currency = "usd",
                    CurrencySymbol = "$",
                    ChargeType = "month",
                    Options = "5 music songs included, Priority Email support, 40% discount",
                    StripeSubscriptionId = "price_1KKk3pAtLEfG8Jr3bF6j5iC4",
                    ImageName = "Pro Subscription",
                    ImagePath = "pro_subscription.png",
                });
                context.Subscriptions.Add(new Subscription
                {
                    Name = "Enterprise",
                    Price = 50,
                    Currency = "usd",
                    CurrencySymbol = "$",
                    ChargeType = "month",
                    Options = "all music songs included, Phone and email support, Help center access",
                    StripeSubscriptionId = "price_1KKk4AAtLEfG8Jr3HmFEpJkm",
                    ImageName = "Enterprise Subscription",
                    ImagePath = "enterprise_subscription.jpg",
                });

                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Adding the todos data when the app is deploy the first time.
        /// </summary>
        /// <param name="context">The instance of <see cref="IApplicationDbContext"/> to use.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task SeedTodosDataAsync(ApplicationDbContext context)
        {
            if (!context.TodoLists.Any())
            {
                context.TodoLists.Add(new TodoList { Title = "Todo List" });
                await context.SaveChangesAsync();
            }

            if (!context.TodoItems.Any())
            {
                var list = context.TodoLists.FirstOrDefault(x => x.Id == 1);

                context.TodoItems.Add(new TodoItem { List = list, Title = "Make a todo list" });
                context.TodoItems.Add(new TodoItem { List = list, Title = "Check off the first item" });
                context.TodoItems.Add(new TodoItem { List = list, Title = "Realise you've already done two things on the list!" });
                context.TodoItems.Add(new TodoItem { List = list, Title = "Reward yourself with a nice, long nap" });

                await context.SaveChangesAsync();
            }
        }
    }
}
