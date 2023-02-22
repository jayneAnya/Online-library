using Microsoft.AspNetCore.Mvc;
using PioneerOnlineLibrary.API.ViewModels;
using PioneerOnlineLibrary.Domain.Model;

namespace PioneerOnlineLibrary.MVC.Interface
{
    public interface IAuthenticationService
    {
        Task<RegisterModel>RegisterAsync(RegisterModel registerModel);
        Task<RegisterModel> RegisterAdminAsync(RegisterModel model);
        Task<LoginModel> Login(LoginModel model);

        Task<AppUser> DeleteUser(AppUser user);
        Task<AppUser> UpdateUser(AppUser user);
    }
}
