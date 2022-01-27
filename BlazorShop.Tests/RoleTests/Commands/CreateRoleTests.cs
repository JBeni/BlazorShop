namespace BlazorShop.Tests.RoleTests.Commands
{
    using static Testing;

    public class CreateRoleTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateRoleCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateRole()
        {
            var command = new CreateRoleCommand
            {
                Name = "Admin"
            };

            var result = await SendAsync(command);

            var item = await FindAsync<RoleResponse>(result.EntityId);

            item.Should().NotBeNull();
            item.Name.Should().Be(command.Name);
        }
    }
}
