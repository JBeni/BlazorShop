namespace BlazorShop.Tests.ClotheTests.Commands
{
    using static Testing;

    public class DeleteClotheTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateMusicCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateMusic()
        {
            var command = new CreateMusicCommand
            {
                Id = 0,
                Title = "Eu vara nu dorm",
                Description = "The description of a music player song",
                Author = "Connect-R",
                DateRelease = new DateTime(2015, 11, 12),
                ImageName = "music-song",
                ImagePath = "music-song.png",
                AccessLevel = 1
            };

            var result = await SendAsync(command);
            var item = await FindAsync<MusicResponse>(result.EntityId);

            item.Should().NotBeNull();
            item.Title.Should().Be(command.Title);
        }
    }
}
