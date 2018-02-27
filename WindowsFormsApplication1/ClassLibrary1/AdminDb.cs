using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class AdminDb
    {
        public User Login(string userName, string password)
        {
            using (DbEntities ctx = new DbEntities())
            {
                if (ctx.User.Any(x => x.UserName == userName && x.Password == password && x.UserRole == (int)UserRoleType.Admin))
                {
                    return ctx.User.SingleOrDefault(x => x.UserName == userName && x.Password == password);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}

