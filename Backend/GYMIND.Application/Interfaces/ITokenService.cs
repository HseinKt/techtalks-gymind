using GYMIND.API.Entities;

namespace GYMIND.API.GYMIND.Application.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(User user, IEnumerable<UserRole> userRoles);
    }
}
