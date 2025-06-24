using OcelotAuthentication.Models;

namespace OcelotAuthentication.Services
{
    public interface IJwtTokenService
    {
        AuthToken GenereateAuthToken(LoginModel loginModel);
    }
}
