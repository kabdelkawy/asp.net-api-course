using WebAPICourse.Models;

namespace WebAPICourse.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
}
