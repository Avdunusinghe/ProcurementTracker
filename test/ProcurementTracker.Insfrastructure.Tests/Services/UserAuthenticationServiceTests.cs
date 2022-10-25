using MediatR;
using Microsoft.Extensions.Configuration;
using Moq;
using ProcurementTracker.Application.Common.Response.AuthenticationDTOs;
using ProcurementTracker.Application.Users.Query;
using ProcurementTracker.Domain.Entities;

namespace ProcurementTracker.Infrastructure.Services.Tests
{
    [TestClass()]
    public class UserAuthenticationServiceTests
    {
        [TestMethod()]
        public async Task LoginTest_Success()
        {
            //Arrage
            var cancellationToken = new CancellationTokenSource();
            var password = "password";

            var request = new AuthenticationDTO()
            {
                UserName = "admin@system.com",
                Password = password
            };

            var mediator = new Mock<IMediator>();
            var user = new User()
            {
                Id = 1,
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@system.com",
                RoleId = 1,
                Role = new Role()
                {
                    Id = 1,
                    Name = "admin",
                },
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
            };

            mediator.Setup(x => x.Send(new GetUserByEmailQuery(request.UserName), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<User>(user));

            
            var inMemoryAppSettings = new Dictionary<string, string> { 
                {"Tokens:Key", "b/zrOGyO28foMLaGBjjRHjGHYWWzb7/eEIfvjso9PQU="},
                {"Tokens:Issuer", "https://procurementCSSE.com/"}
            };

            
            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemoryAppSettings)
                .Build();

            //Act
            var userAuthenticationService = new UserAuthenticationService(mediator.Object, configuration);
            var response = await userAuthenticationService.Login(request, cancellationToken.Token);

            //Assert
            Assert.IsTrue(response.IsLoginSuccess);
            Assert.AreEqual(user.Email, response.Email);
            Assert.AreNotEqual(string.Empty, response.Token);
        }

        [TestMethod()]
        public async Task LoginTest_NotSuccess_InvalidPassword()
        {
            //Arrage
            var password = "password";
            var cancellationToken = new CancellationTokenSource();
            var request = new AuthenticationDTO()
            {
                UserName = "admin@system.com",
                Password = "admin"
            };
            var mediator = new Mock<IMediator>();
            var user = new User()
            {
                Id = 1,
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@system.com",
                RoleId = 1,
                Role = new Role()
                {
                    Id = 1,
                    Name = "admin",
                },
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
            };

            mediator.Setup(x => x.Send(new GetUserByEmailQuery(request.UserName), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<User>(user));


            var inMemoryAppSettings = new Dictionary<string, string> {
                {"Tokens:Key", "b/zrOGyO28foMLaGBjjRHjGHYWWzb7/eEIfvjso9PQU="},
                {"Tokens:Issuer", "https://procurementCSSE.com/"}
            };


            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemoryAppSettings)
                .Build();

            //Act

            var userAuthenticationService = new UserAuthenticationService(mediator.Object, configuration);
            var response = await userAuthenticationService.Login(request, cancellationToken.Token);

            //Assert
            Assert.IsFalse(response.IsLoginSuccess);
            Assert.AreEqual(string.Empty, response.Token);
        }

        [TestMethod()]
        public async Task LoginTest_NotSuccess_InvalidUsername()
        {
            //Arrage
            var password = "password";
            var cancellationToken = new CancellationTokenSource();
            var request = new AuthenticationDTO()
            {
                UserName = "adminwrong@system.com",
                Password = password
            };
            var mediator = new Mock<IMediator>();
            var user = new User()
            {
                Id = 1,
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@system.com",
                RoleId = 1,
                Role = new Role()
                {
                    Id = 1,
                    Name = "admin",
                },
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
            };

            mediator.Setup(x => x.Send(new GetUserByEmailQuery(request.UserName), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<User>(null));


            var inMemoryAppSettings = new Dictionary<string, string> {
                {"Tokens:Key", "b/zrOGyO28foMLaGBjjRHjGHYWWzb7/eEIfvjso9PQU="},
                {"Tokens:Issuer", "https://procurementCSSE.com/"}
            };


            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemoryAppSettings)
                .Build();

            //Act

            var userAuthenticationService = new UserAuthenticationService(mediator.Object, configuration);
            var response = await userAuthenticationService.Login(request, cancellationToken.Token);

            //Assert
            Assert.IsFalse(response.IsLoginSuccess);
            Assert.AreNotEqual(user.Email, response.Email);
            Assert.AreEqual(string.Empty, response.Token);
        }

        [TestMethod()]
        public async Task LoginTest_NotSuccess_InvalidUsername_InvalidPassword()
        {
            //Arrage
            var password = "password";
            var cancellationToken = new CancellationTokenSource();
            var request = new AuthenticationDTO()
            {
                UserName = "adminwrong@system.com",
                Password = "wrongpassword"
            };
            var mediator = new Mock<IMediator>();
            var user = new User()
            {
                Id = 1,
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@system.com",
                RoleId = 1,
                Role = new Role()
                {
                    Id = 1,
                    Name = "admin",
                },
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
            };

            mediator.Setup(x => x.Send(new GetUserByEmailQuery(request.UserName), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<User>(null));


            var inMemoryAppSettings = new Dictionary<string, string> {
                {"Tokens:Key", "b/zrOGyO28foMLaGBjjRHjGHYWWzb7/eEIfvjso9PQU="},
                {"Tokens:Issuer", "https://procurementCSSE.com/"}
            };


            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemoryAppSettings)
                .Build();

            //Act

            var userAuthenticationService = new UserAuthenticationService(mediator.Object, configuration);
            var response = await userAuthenticationService.Login(request, cancellationToken.Token);

            //Assert
            Assert.IsFalse(response.IsLoginSuccess);
            Assert.AreNotEqual(user.Email, response.Email);
            Assert.AreEqual(string.Empty, response.Token);
        }
    }
}
