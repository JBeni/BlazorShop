namespace BlazorShop.Tests.RoleTests.Queries
{
    using static Testing;

    public class GetMusicsTests : TestBase
    {
        [Test]
        public async Task ShouldReturnRoleNames()
        {
            var query = new GetRolesQuery();
            var result = await SendAsync(query);

            //result.Select(x => x.Name).Should().NotBeEmpty().Should().NotBeNull();
        }

        [Test]
        public async Task ShouldReturnAllRolesWithAllDetails()
        {
            await AddAsync(new Role
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            });
            await AddAsync(new Role
            {
                Name = "User"
            });
            await AddAsync(new Role
            {
                Name = "Manager"
            });

            var query = new GetRolesQuery();
            var result = await SendAsync(query);

            //result.Should().NotBeEmpty().Should().NotBeNull();
            //result.Capacity.Should().Be(3);
            //result.First().Name.Should().Equals("Admin");
        }
    }
}
