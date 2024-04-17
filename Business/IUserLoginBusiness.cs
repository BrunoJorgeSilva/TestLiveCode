using TestLiveCode.Model;
using TestLiveCode.ViewModel;

namespace TestLiveCode.Business
{
    public interface IUserLoginBusiness
    {
        public bool ValidateLogin(string user, string password);
        public UserLogin PostNewUser(UserLoginViewModel userLogin);
        public UserLogin EditUser(UserLoginViewModel userToEdit);
        public bool DeleteUser(UserLoginViewModel user);
    }
}
