using registru_auto.Contexts;
using registru_auto.Entities;
using registru_auto.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace registru_auto.Services.UnitsOfWork
{
    public class CarUnitOfWork : ICarUnitOfWork
    {
        private readonly CarsContexts _context;

        public CarUnitOfWork(CarsContexts context, ICarRepository cars,
            IOwnerRepository owners)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Cars = cars ?? throw new ArgumentNullException(nameof(context));
            Owners = owners ?? throw new ArgumentNullException(nameof(context));
        }

        public ICarRepository Cars { get; }

        public IOwnerRepository Owners { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
