using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public partial class User
    {
        public UserRoleType Role
        {
            get { return (UserRoleType)UserRole; }
            set { UserRole = (int)value; }
        }


    }
}
