using PioneerOnlineLibrary.API.ViewModels;
using PioneerOnlineLibrary.Domain.Model;
using PioneerOnlineLibrary.Helpers.Helpers;
using PioneerOnlineLibrary.MVC.Interface;

namespace PioneerOnlineLibrary.MVC.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly HttpClient _client;
        public const string BasePath = "/api/Authentication/";
        

        public AuthenticationService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }



        public async Task<AppUser> DeleteUser(AppUser user)
        {
            var response = await _client.DeleteAsync(BasePath + user.ToString());
            return await response.ReadContentAsync<AppUser>();
        }

        public async Task<LoginModel> Login(LoginModel model)

        {
            var fileContent = new ByteArrayContent(File.ReadAllBytes("DefaultDataBase"));
            var response = await _client.PostAsync(BasePath + model.ToString(), fileContent);
            return await response.ReadContentAsync<LoginModel>();
        }

    

        public async Task<RegisterModel> RegisterAdminAsync(RegisterModel model)
        {
            var fileContent = new ByteArrayContent(File.ReadAllBytes("DefaultDataBase"));
            var response = await _client.PostAsync(BasePath + model.ToString(), fileContent);
            return await response.ReadContentAsync<RegisterModel>();
        }

        public async Task<RegisterModel> RegisterAsync(RegisterModel registerModel)
        {
            var fileContent = new ByteArrayContent(File.ReadAllBytes("DefaultDataBase"));
            var response = await _client.PostAsync(BasePath + registerModel.ToString(), fileContent);
            return await response.ReadContentAsync<RegisterModel>();
        }

        public async Task<AppUser> UpdateUser(AppUser user)
        {
            var fileContent = new ByteArrayContent(File.ReadAllBytes("DefaultDataBase"));
            var response = await _client.PutAsync(BasePath + user.ToString(), fileContent);
            return await response.ReadContentAsync<AppUser>();
        }
    }
}
