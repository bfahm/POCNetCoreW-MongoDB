using AuthenticatedMongoDb.Models;

namespace AuthenticatedMongoDb.Services
{
    public interface IAuthenticationService
    {
        public string GenerateBearerToken(User user);
    }
}
