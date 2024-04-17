using TestLiveCode.ViewModel;

namespace TestLiveCode.Service
{
    public interface IUserLoginService
    {
        public bool ValidateLogin(string user, string password);
        public UserLoginViewModel PostNewUser(UserLoginViewModel userLogin);
        public UserLoginViewModel EditUser(UserLoginViewModel userToEdit);
        public bool DeleteUser(UserLoginViewModel user);



    }
}
