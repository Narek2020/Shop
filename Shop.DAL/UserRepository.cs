using Shop.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL
{
    public class UserRepository
    {
        public List<User> GetUsers()
        {
            var users = new List<User>();
            using (var context = new OnlineShopEntities())
            {
                users = context.Users.AsNoTracking().ToList();
            }

            return users;
        }

        public void SetUser(UserModel user)
        {
            using (var context = new OnlineShopEntities())
            {
                context.Users.Add(new User
                {
                    password = user.Password,
                    email = user.Email,
                });
                context.SaveChanges();
            }
        }
        
    }
}
