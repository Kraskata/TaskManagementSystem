using Microsoft.AspNetCore.Identity;
using Moq;
using TaskManagementSystem.Infrastructure.Data.Models;

namespace TaskManagementSystem.Tests.Mocks
{
    public static class UserManagerMock
    {
        public static Mock<UserManager<ApplicationUser>> Instance
        {
            get
            {
                var userStoreMock = new Mock<IUserStore<ApplicationUser>>();

                return new Mock<UserManager<ApplicationUser>>(
                    userStoreMock.Object,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null);
            }
        }
    }
}