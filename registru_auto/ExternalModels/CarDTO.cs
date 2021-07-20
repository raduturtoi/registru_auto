using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace registru_auto.ExternalModels
{
    public class CarDTO
    {
        public Guid ChassisSeries { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int EngineSize { get; set; }

        public int Power { get; set; }

        public int FabricationYear { get; set; }

        public Guid OwnerID { get; set; }

        public  OwnerDTO Owner { get; set; }
    }
}
