using API.Data.Auth0;

namespace API.User.Interfaces;

public interface IUserManager
{
    Task<Auth0User?> GetCurrentUserAsync(CancellationToken cancellationToken);
}
