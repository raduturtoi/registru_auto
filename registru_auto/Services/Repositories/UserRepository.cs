using registru_auto.Contexts;
using registru_auto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace registru_auto.Services.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly CarsContexts _context;

        public UserRepository(CarsContexts context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<User> GetAdminUsers()
        {
            return _context.Users
                .Where(u => u.IsAdmin && (u.Deleted == false || u.Deleted == null))
                .ToList();
        }
    }
}
