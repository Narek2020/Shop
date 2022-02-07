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
        UserRepository UserRepos = new UserRepository();
        public List<UserModel> GetUsers()
        {
            
            var users = UserRepos.GetUsers();

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
            UserRepos.SetUser(user);
        }

        public bool CheckUser(string userEmail)
         {
            
            var users = UserRepos.GetUsers();
            var existUser = users.Any(u => u.email == userEmail);

            return existUser;
        }

        public int GetUserId()
        {

            return 1;
        }

        public bool GetUsersForLogin(string userEmail, string userPassword)
        {
            
            bool result = false;
            var users = GetUsers();
            var existuser = users.Where(u => u.Email == userEmail && u.Password == userPassword).FirstOrDefault();


            if (existuser != null)
            {
                var user = (existuser.Id, userEmail, existuser.Status);

                var encodedTicket = FormsAuthentication.Encrypt(
                   new FormsAuthenticationTicket(
                      1,
                      user.userEmail,
                      DateTime.Now,
                      DateTime.UtcNow.Add(FormsAuthentication.Timeout),
                      true,
                      user.Id.ToString()+"/"+ user.Status.ToString()));

                var httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encodedTicket);
                HttpContext.Current.Response.Cookies.Add(httpCookie);
               
                 result = true;
            }

            return result;
        }
    }
}
