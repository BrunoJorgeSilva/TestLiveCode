using AutoMapper;
using TestLiveCode.Business;
using TestLiveCode.Model;
using TestLiveCode.ViewModel;

namespace TestLiveCode.Service
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserLoginBusiness _userLoginBusiness;
        private readonly IMapper _map;
        public UserLoginService(IUserLoginBusiness userLoginBusiness, IMapper map) 
        {
            _userLoginBusiness = userLoginBusiness;
            _map = map;
        }
        public bool ValidateLogin(string user, string password)
        {
            return _userLoginBusiness.ValidateLogin(user, password);
        }
        public UserLoginViewModel PostNewUser(UserLoginViewModel userLogin)
        {
            return _map.Map<UserLoginViewModel> (_userLoginBusiness.PostNewUser(userLogin));
        }
        public UserLoginViewModel EditUser(UserLoginViewModel userToEdit)
        {
            return _map.Map<UserLoginViewModel> (_userLoginBusiness.EditUser(userToEdit));
        }
        public bool DeleteUser(UserLoginViewModel user)
        {
            return _userLoginBusiness.DeleteUser(user);
        }
    }
}
