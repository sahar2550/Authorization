using AuthorizationWebApi.Models;

namespace AuthorizationWebApi.Services.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        User GetById(int id);
    }
}
