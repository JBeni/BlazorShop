// <copyright file="CreateCartCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Handlers.Commands.CartHandler;
using BlazorShop.Infrastructure.Persistence;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using Newtonsoft.Json;
using Stripe;
using System.Xml.Linq;
using Xunit;

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.CartHandler
{
    /// <summary>
    /// Tests for <see cref="CreateCartCommandHandler"/> class.
    /// </summary>
    public class CreateCartCommandHandlerTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCartCommandHandlerTests"/> class.
        /// </summary>
        public CreateCartCommandHandlerTests()
        {
            this.ApplicationDbContext = new ApplicationDbContext(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: $"ApplicationDbContext-Core")
                    .Options);

            var userStore = Mock.Of<IUserStore<User>>();
            this.UserManager = new UserManager<User>(userStore, null, null, null, null, null, null, null, null);

            // Create a UserManager<User> instance
            //this.UserManager = new UserManager<User>(mockUserStore.Object, options, new PasswordHasher<User>(),
            //    new IUserValidator<User>[] { new UserValidator<User>() },
            //    new IPasswordValidator<User>[] { new PasswordValidator<User>() },
            //    new UpperInvariantLookupNormalizer(),
            //    new IdentityErrorDescriber(),
            //    null,
            //    new Mock<ILogger<UserManager<User>>>().Object);

            this.SUT = new CreateCartCommandHandler(
                this.ApplicationDbContext,
                this.Logger,
                this.UserManager);
        }

        /// <summary>
        /// Gets the <see cref="CreateCartCommandHandler"/> instance to use.
        /// </summary>
        private CreateCartCommandHandler SUT { get; }

        /// <summary>
        /// Gets the <see cref="IApplicationDbContext"/> under test.
        /// </summary>
        private IApplicationDbContext ApplicationDbContext { get; }

        /// <summary>
        /// Gets the <see cref="UserManager{User}"/> under test.
        /// </summary>
        private UserManager<User> UserManager { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IAccountService"/> to use.
        /// </summary>
        private IAccountService AccountService { get; } = Mock.Of<IAccountService>();

        /// <summary>
        /// Gets the <see cref="ILogger{CreateCartCommandHandler}"/> under test.
        /// </summary>
        private ILogger<CreateCartCommandHandler> Logger { get; } = Mock.Of<ILogger<CreateCartCommandHandler>>();

        /// <summary>
        /// Ensure context garbage collector.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Ensure the context is reset between tests.
        /// </summary>
        /// <param name="disposing">A value indicating whether the class is disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            // this.ApplicationDbContext.Database.EnsureDeleted();
        }

        /// <summary>
        /// A test for <see cref="CreateCartCommandHandler.Handle(CreateCartCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        [Fact]
        public async Task Handle()
        {
            var createCartCommand = Mock.Of<CreateCartCommand>(x =>
                x.UserId == new Random().Next() &&
                x.ClotheId == new Random().Next() &&
                x.Name == "test" &&
                x.Price == new decimal(new Random().NextDouble()) &&
                x.Amount == new Random().Next());
            var clotheEntity = Mock.Of<Clothe>(q =>
                q.Id == createCartCommand.ClotheId &&
                q.Description == string.Empty &&
                q.ImageName == string.Empty &&
                q.ImagePath == string.Empty &&
                q.Name == string.Empty &&
                q.Price == new decimal(new Random().NextDouble()) &&
                q.IsActive == true);
            var userEntity = Mock.Of<User>(q =>
                q.Id == createCartCommand.UserId &&
                q.IsActive == true &&
                q.UserName == "TestNorth" &&
                q.Email == "test@gmail.com" &&
                q.FirstName == "Test" &&
                q.LastName == "Last" &&
                q.NormalizedEmail == "TEST@gmail.com" &&
                q.NormalizedUserName == "TESTNORTH");

            //Mock.Get(this.UserManager)
            //    .Setup(x => x.FindByIdAsync(createCartCommand.UserId.ToString()))
            //    .ReturnsAsync(userEntity);

            var cartEntity = Mock.Of<Cart>(w =>
                w.Name == createCartCommand.Name &&
                w.Price == createCartCommand.Price &&
                w.Amount == createCartCommand.Amount &&
                w.User == userEntity &&
                w.Clothe == clotheEntity);

            this.ApplicationDbContext.Clothes.Add(clotheEntity);
            // this.ApplicationDbContext.Carts.Add(cartEntity);
            await this.ApplicationDbContext.SaveChangesAsync(default);

            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == true &&
                x.Error == string.Empty &&
                x.EntityId == 0);

            //var result = await this.SUT.Handle(createCartCommand, default);

            //Assert.Equal(result.Successful, response.Successful);
            //Assert.Equal(result.Error, response.Error);
            //Assert.Equal(result.EntityId, response.EntityId);

            //Assert.Equal(appointment.Object.Title, result.Title);
            //Assert.Equal(appointment.Object.StartDateTime, result.StartDateTime);
            //Assert.Equal(appointment.Object.EndDateTime, result.EndDateTime);
            //Assert.Equal(appointment.Object.IsOpenAppointment, result.IsOpenAppointment);
            //Assert.Equal(appointment.Object.LocalAuthority, result.LocalAuthority);
            //Assert.Equal(appointment.Object.SearcherActiveDirectoryId, result.SearcherActiveDirectoryId);
            //Assert.Equal(appointment.Object.TypeName, result.TypeName);
            //Assert.Equal(appointment.Object.Status, result.Status);
        }

        /// <summary>
        /// A test for <see cref="ResetPasswordCommandHandler.Handle(CreateCartCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == false &&
                x.Error == ErrorsManager.CreateCartCommand &&
                x.EntityId == 0);

            //Mock.Get(this.AccountService)
            //    .Setup(x => x.ResetPasswordUserAsync(It.IsAny<CreateCartCommand>()))
            //    .ThrowsAsync(new Exception());

            var result = await this.SUT.Handle(It.IsAny<CreateCartCommand>(), default);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Contains(response.Error, result.Error);
            Assert.Equal(result.EntityId, response.EntityId);
        }


        /*

                private void SetupIndexDbSets()
                {
                    this.MockCoreContext.SetupDbSet(
                        x => x.EventCategoryIndex,
                        (this.MockCoreContext.Object.SearchEvent ?? Enumerable.Empty<SearchEvent>())
                            .ToList()
                            .SelectMany(e => e.Type.EventCategories.Select(c => new
                            {
                                EventId = e.Id,
                                SearchId = e.SearchId,
                                CreatedAt = e.CreatedAt,
                                EventType = e.Type.Name,
                                Category = c.EventCategory.Name,
                            }))
                            .GroupBy(e => new { e.SearchId, e.Category })
                            .Select(g => g.OrderByDescending(x => x.CreatedAt).First())
                            .Select(x => new EventCategoryIndex(x.SearchId, x.EventId, x.Category, x.EventType))
                            .ToList());

                    this.MockCoreContext.SetupDbSet(
                        x => x.AppointmentIndex,
                        (this.MockCoreContext.Object.Appointments ?? Enumerable.Empty<Appointment>()).ToList()
                            .Select(a => new AppointmentIndex(a.History.OrderByDescending(h => h.CreatedAt).First()))
                            .ToList());
                }


                /// <summary>
        /// Ensures that the <see cref="IAppointmentsRepository.CreateAppointment(IAppointment)"/> method
        /// saves the provided <see cref="Appointment"/> entity to the database and returns a business object
        /// representation of the appointment.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreateAppointment()
        {
            var appointment = new Mock<IAppointment>();
            appointment.SetupGet(x => x.Title).Returns("Title");
            appointment.SetupGet(x => x.StartDateTime).Returns(DateTimeOffset.UtcNow);
            appointment.SetupGet(x => x.EndDateTime).Returns(DateTimeOffset.UtcNow);
            appointment.SetupGet(x => x.IsOpenAppointment).Returns(false);
            appointment.SetupGet(x => x.LocalAuthority).Returns("Local Authority");
            appointment.SetupGet(x => x.SearcherActiveDirectoryId).Returns("Searcher ID");
            appointment.SetupGet(x => x.TypeName).Returns("LA Appointment");
            appointment.SetupGet(x => x.Status).Returns(Core.Models.Scheduling.AppointmentStatuses.Initial);

            var appointmentTypeEntity = new Entities.Scheduling.AppointmentType(
                "LA Appointment",
                "LA Appointment description",
                DateTimeOffset.UtcNow,
                "System");
            this.CoreContext.AppointmentTypes.Add(appointmentTypeEntity);

            this.CoreContext.Authorities.Add(new Authority
            {
                Name = appointment.Object.LocalAuthority,
                AuthorityTypeName = "LocalAuthority",
                Code = "TEST",
            });

            this.CoreContext.SaveChanges();

            EventHandler<EntityTrackedEventArgs> handler = (source, e) =>
            {
                if (e.Entry.Entity is AppointmentHistory)
                {
                    var entity = e.Entry.Entity as AppointmentHistory;
                    this.CoreContext.AppointmentIndex.Add(new AppointmentIndex(
                        entity.AppointmentId,
                        entity.Id,
                        entity.StartDateTime,
                        entity.EndDateTime,
                        entity.Authority.Name,
                        entity.Department,
                        entity.SearcherActiveDirectoryId,
                        entity.Status));
                    this.CoreContext.SaveChanges();
                }
            };

            this.CoreContext.ChangeTracker.Tracked += handler;

            var result = await this.AlternateAppointmentsRepository.CreateAppointment(appointment.Object);

            this.CoreContext.ChangeTracker.Tracked -= handler;

            Assert.Equal(appointment.Object.Title, result.Title);
            Assert.Equal(appointment.Object.StartDateTime, result.StartDateTime);
            Assert.Equal(appointment.Object.EndDateTime, result.EndDateTime);
            Assert.Equal(appointment.Object.IsOpenAppointment, result.IsOpenAppointment);
            Assert.Equal(appointment.Object.LocalAuthority, result.LocalAuthority);
            Assert.Equal(appointment.Object.SearcherActiveDirectoryId, result.SearcherActiveDirectoryId);
            Assert.Equal(appointment.Object.TypeName, result.TypeName);
            Assert.Equal(appointment.Object.Status, result.Status);
        }



        */







    }
}
