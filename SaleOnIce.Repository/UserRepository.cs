using SaleOnIce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOnIce.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SaleOnIceContext context) : base(context)
        {
        }
    }
}
