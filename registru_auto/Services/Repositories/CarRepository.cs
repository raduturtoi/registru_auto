using Microsoft.EntityFrameworkCore;
using registru_auto.Contexts;
using registru_auto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace registru_auto.Services.Repositories
{
    public class CarRepository : Repository<Cars>, ICarRepository
    {
        private readonly CarsContexts _context;

        public CarRepository(CarsContexts context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Cars GetBookDetails(Guid carId)
        {
            return _context.Cars
                .Where(b => b.ChassisSeries == carId && (b.Deleted == false || b.Deleted == null))
                .Include(b => b.Owner)
                .FirstOrDefault();
        }

        public Cars GetCarDetails(Guid carId)
        {
            throw new NotImplementedException();
        }
    }
}
