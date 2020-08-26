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
            _mockUserRepository = new Mock<IReadOnlyUserRepository>();
            _sut = new QueryUserController(_mockUserRepository.Object);

        }

        [Fact]
        public void List_ShouldReturnUserList_FromUserRepository()
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
    }
}
