using DogusTeknoloji.SibelCaliskan.Models.Services.ViewModels;

namespace DogusTeknoloji.SibelCaliskan.Models.Services
{
    public interface IUserService
    {
        bool CreateUser(CreateUserViewModel model);
        bool SignIn(SignInViewModel model);

        void SignOut();
    }
}
