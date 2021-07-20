using registru_auto.Contexts;
using registru_auto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace registru_auto.Services.Repositories
{
    public class OwnerRepository : Repository<Owners>, IOwnerRepository
    {
        private readonly CarsContexts _context;

        public OwnerRepository(CarsContexts context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
