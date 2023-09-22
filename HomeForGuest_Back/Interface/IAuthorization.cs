using HomeForGuest_Back.Models;

namespace HomeForGuest_Back.Interface
{
    public interface IAuthorization
    {
        Task<UserResponse> ReturnToken(User userAuthorization);
    }
}
