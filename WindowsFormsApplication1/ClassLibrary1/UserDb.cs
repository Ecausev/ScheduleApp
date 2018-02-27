using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class UserDb
    {
        public static int LoggedUserId { get; private set; }
        public static string passHash { get; private set; }
        public int UserRole { get; private set; }

        private int UserId { get; set; }
        /// <summary>
        /// Dohvaća korisnika pomoću korisnickog imena, 
        /// Ako nije pronađen, vraća NULL
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User getName(string userName)
        {
            User user = new User();

            user.UserName = userName;

            using (DbEntities ctx = new DbEntities())
            {
                if (ctx.User.Any(x => x.UserName == userName))
                {
                    return null;
                }
                else
                {
                    return user;
                }
            }
        }

        /// <summary>
        /// Provjerava korisničke kredencije, te ako su dobre i korisnik omogućen, vratit će informacije o korisniku.
        /// U suprotnom, ako korisnik nije pronađen, vraća null
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Login(string userName, string password)
        {
            User user = new User();
            user.UserName = userName;
            user.Password = password;

            /// TODO: password se ne smije koristiti kao običan string, nego njegov hash...
            /// 
            using (DbEntities ctx = new DbEntities())
            {
                int? userId = ctx.User.Where(x => x.UserName == userName)
                                .Select(x => x.UserId)
                                .SingleOrDefault();

                if (userId.HasValue && userId != 0)
                {
                    var bytes = new UTF8Encoding().GetBytes(password);
                    var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
                    passHash = $"{userId};" + Convert.ToBase64String(hashBytes);
                    user.Password = ctx.User.Where(x => x.UserId == userId).Select(x => x.Password).SingleOrDefault();
                    if(passHash == user.Password)
                    {
                        LoggedUserId = (int)userId;
                        UserRole = ctx.User.Where(x => x.UserId == userId).Select(x => x.UserRole).SingleOrDefault();
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    LoggedUserId = -1;
                    return null;
                }
            }
        }
        /// <summary>
        /// Kreira i ubacuje u bazu novog korisnika ukoliko je moguce.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public User Register(string userName, UserRoleType role)
        {
            User user = new User();

            user.Role = role;
            user.UserName = userName;
            user.Password = null;
            user.Enabled = true;
            
            using (DbEntities ctx = new DbEntities()) //spajanje na bazu
            {
                user = ctx.User.Add(user);
                ctx.SaveChanges();
                UserId = ctx.User.Where(x => x.UserName == userName).Select(x => x.UserId).SingleOrDefault();
            }

            return user;
        }
        public string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            passHash = $"{UserId};" + Convert.ToBase64String(hashBytes);
            
            using (DbEntities ctx = new DbEntities())
            {
                var user = ctx.User.Where(x => x.UserId == UserId).SingleOrDefault();
                user.Password = passHash;

                ctx.SaveChanges();
            }
                return passHash = Convert.ToBase64String(hashBytes);
        }

    }
}
