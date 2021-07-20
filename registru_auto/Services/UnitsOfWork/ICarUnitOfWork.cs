using registru_auto.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace registru_auto.Services.UnitsOfWork
{
    public interface ICarUnitOfWork : IDisposable
    {
        ICarRepository Cars { get; }

        IOwnerRepository Owners { get; }

        int Complete();
    }
}
