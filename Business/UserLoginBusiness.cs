using AutoMapper;
using TestLiveCode.Context;
using TestLiveCode.Model;
using TestLiveCode.ViewModel;

namespace TestLiveCode.Business
{ 
    public class UserLoginBusiness : IUserLoginBusiness
    {
        private readonly DbContextExample _context;
        private readonly IMapper _map;
        public UserLoginBusiness(DbContextExample context, IMapper map) 
        {
            _context = context;
            _map = map;
        }
        public bool ValidateLogin(string userName, string password)
        {
            UserLogin user = _context.UserLogin.Where(x => x.User == userName &&
                                                x.Password == password &&
                                                x.Active == true)?.FirstOrDefault();
            if (user is not null)
                return true;
            else
                return false;
        }
        public UserLogin PostNewUser(UserLoginViewModel userLogin)
        {
            
            if (_context.UserLogin.Where(x => x.User == userLogin.User).Any())
            {
                return null;
            }
            UserLogin newUser = _map.Map<UserLogin>(userLogin);
            newUser.Id = Guid.NewGuid();
            try
            {
                _context.UserLogin.Add(newUser);
                _context.SaveChanges();
                return newUser;
            }
            catch 
            {
                return null;
            }
        }
        public UserLogin EditUser(UserLoginViewModel userToEdit)
        {
            UserLogin userToBeEdited = _context.UserLogin.Where(x => x.User == userToEdit.User).FirstOrDefault(); 
            userToBeEdited.User = userToEdit.User;
            userToBeEdited.Password = userToEdit.Password;
            userToBeEdited.Active = Convert.ToBoolean(userToEdit.Active);
            userToBeEdited.DateAdded = DateTime.Now;
            try 
            {
                _context.Update(userToBeEdited);
                _context.SaveChanges();
                return userToBeEdited;
            }
            catch
            {
                return null;
            }
        }
        public bool DeleteUser(UserLoginViewModel user)
        {
            UserLogin? userToBeEdited = _context.UserLogin.Where(x => x.User == user.User).FirstOrDefault();
            if(userToBeEdited != null)
            {
                userToBeEdited.Active = false;
            }
            else
                return false;

            _context.UserLogin.Update(userToBeEdited);
            _context.SaveChanges();


            return true;
        }
    }
}
