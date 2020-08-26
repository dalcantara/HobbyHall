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
            var userList = new List<User>() { new User { Id = 1 }, new User { Id = 2 } };
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
            var expectedUser = new User { Id = 1 };
            var storedUser = Task.FromResult(expectedUser);

            _mockUserRepository.Setup(r => r.GetByIdAsync(1)).Returns(storedUser);

            //act
            var actualResult = _sut.GetById(1).Result as OkObjectResult;

            //assert
            actualResult.StatusCode.Should().Be(200);
            actualResult.Value.Should().BeEquivalentTo(expectedUser);
        }

        [Fact]
        public void GetById_ShouldReturnNotFound_WhenUserDoesNotExist()
        {
            //arrange
            var user = new User();
            var storedUser = Task.FromResult((User) null);

            _mockUserRepository.Setup(r => r.GetByIdAsync(1)).Returns(storedUser);

            //act
            var actualResult = _sut.GetById(1).Result as NotFoundObjectResult;

            //assert
            actualResult.StatusCode.Should().Be(404);
            actualResult.Value.Should().BeAssignableTo<EmptyResult>();
        }
    }
}
