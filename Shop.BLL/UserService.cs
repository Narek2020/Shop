using Shop.Common.Models;
using Shop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;



namespace Shop.BLL
{
    public class UserService
    {
        private readonly UserRepository _UserRepository;

        public UserService()
        {
            _UserRepository = new UserRepository();
        }
        public List<UserModel> GetUsers()
        {
            
            var users = _UserRepository.GetUsers();

            return users.Select(u => new UserModel
            {

                Id = u.id,
                Email = u.email,
                Password = u.password,
                Status = u.status

            }).ToList();
        }

        public void SetUsers(UserModel user)
        {
            _UserRepository.SetUser(user);
        }

        public bool CheckUser(string userEmail)
         {
            
            var users = _UserRepository.GetUsers();
            var existUser = users.Any(u => u.email == userEmail);

            return existUser;
        }


        public bool GetUsersForLogin(UserModel user)
        {
            
            bool result = false;
            var users = GetUsers();
            var existuser = users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();

            if (existuser != null)
            {
                

                var encodedTicket = FormsAuthentication.Encrypt(
                   new FormsAuthenticationTicket(
                      1,
                      existuser.Email,
                      DateTime.Now,
                      DateTime.UtcNow.Add(FormsAuthentication.Timeout),
                      user.Checked,
                      existuser.Id.ToString()+"/"+ existuser.Status.ToString()));

                var httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encodedTicket);
                HttpContext.Current.Response.Cookies.Add(httpCookie);
               
                 result = true;
            }

            return result;
        }
    }
}
