using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Abstractions.DataAccess;
using Web.Application.Abstractions.Services;
using Web.Application.Models;
using Web.Application.Services;
using Web.Domain.Entities;

namespace Web.Application.Test.Services
{
    public class UserServiceTests
    {
        private Mock<IUserDao> _userDao = null!;

        private IUserService _service = null!;

        [SetUp]
        public void SetUp() 
        {
            _userDao = new Mock<IUserDao>();

            _service = new UserService(_userDao.Object);
        }

        public void TearDown() 
        { 
            _userDao.VerifyNoOtherCalls();
        }

        [Test]
        public async Task GetAll_IsEmptyTest() 
        { 
            _userDao.Setup(x => x.GetAll()).ReturnsAsync([]).Verifiable();

            List<UserModel> result = await _service.GetAll();

            Assert.That(result, Is.Empty);

            _userDao.Verify();
        }

        [Test]
        public async Task GetAll_IsNotEmptyTest()
        {
            _userDao.Setup(x => x.GetAll()).ReturnsAsync(MockedUserList).Verifiable();

            List<UserModel> result = await _service.GetAll();

            Assert.That(result, Is.Not.Empty);
            Assert.That(result[0].Email, Is.EqualTo("TestEmail"));

            _userDao.Verify();
        }

        private static List<User> MockedUserList =>
        [
            new()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                Email = "TestEmail",
                PhoneNumber = "1234567890",

            }
        ];

    }
}
