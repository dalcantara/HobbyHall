using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using HobbyHall.Api.Controllers;
using HobbyHall.Api.Models;
using HobbyHall.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace HobbyHall.Api.Tests.Controllers
{

    public class UserControllerTests
    {
        private static readonly User user1 = new User { UserName = "user1" };
        private static readonly User user2 = new User { UserName = "user2" };
        QueryUserController _sut;
        Mock<IReadOnlyUserRepository> _mockUserRepository = new Mock<IReadOnlyUserRepository>();
        public UserControllerTests()
        {
            _mockUserRepository = new Mock<IReadOnlyUserRepository>(MockBehavior.Strict);
            _sut = new QueryUserController(_mockUserRepository.Object);
        }

        [Fact]
        public void List_ShouldReturnExistingUserList_WhenUsersExist()
        {

            //arrange
            var userList = new List<User>() {user1, user2};
            var storedUserList = Task.FromResult(userList.AsEnumerable());
            _mockUserRepository.Setup(r => r.GetAllAsync()).Returns(storedUserList);
            
            //act
            var actualResult = _sut.List().Result as OkObjectResult;

            //assert
            actualResult.StatusCode.Should().Be(200);
            actualResult.Value.Should().BeEquivalentTo(userList);
        }

        [Fact]
        public void GetById_ShouldReturnUser_WhenUserWithGivenIdExists()
        {

            //arrange
            var storedUser = Task.FromResult(user1);

            _mockUserRepository.Setup(r => r.GetByUsernameAsync(user1.UserName)).Returns(storedUser);

            //act
            var actualResult = _sut.GetByUsername(user1.UserName).Result as OkObjectResult;

            //assert
            actualResult.StatusCode.Should().Be(200);
            actualResult.Value.Should().BeEquivalentTo(user1);
        }

        [Fact]
        public void GetById_ShouldReturnNotFound_WhenUserDoesNotExist()
        {
            //arrange
            var storedUser = Task.FromResult((User) null);

            _mockUserRepository.Setup(r => r.GetByUsernameAsync(user1.UserName)).Returns(storedUser);

            //act
            var actualResult =  _sut.GetByUsername(user1.UserName).Result as NotFoundObjectResult;

            //assert
            actualResult.StatusCode.Should().Be(404);
            actualResult.Value.Should().BeAssignableTo<EmptyResult>();
        }
    }
}
