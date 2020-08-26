using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using HobbyHall.Api.Controllers;
using HobbyHall.Api.Models;
using HobbyHall.Api.Repositories;
using Moq;
using Xunit;

namespace HobbyHall.Api.Tests.Controllers
{

    public class UserControllerTests
    {
        UserController _sut;
        Mock<IUserRepository> _mockUserRepository = new Mock<IUserRepository>();
        public UserControllerTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _sut = new UserController(_mockUserRepository.Object);

        }

        [Fact]
        public void List_ShouldReturnUserList_FromUserRepository()
        {

            //arrange
            var userList = new List<User>() { new User { Id = 1 }, new User { Id = 2 } };
            var expectedResult = Task.FromResult(userList.AsEnumerable<User>());
            _mockUserRepository.Setup(r => r.GetAllAsync()).Returns(expectedResult);

            //act
            var actualResult = _sut.List();

            //assert
            actualResult.Should().BeSameAs(expectedResult);
        }
    }
}
