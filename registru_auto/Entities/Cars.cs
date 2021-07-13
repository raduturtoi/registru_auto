using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace registru_auto.Entities
{
    public class Cars
    {
        [Key]
        public Guid ChassisSeries { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [MaxLength(4)]
        public int EngineSize { get; set; }

        [MaxLength(3)]
        public int Power { get; set; }

        [MaxLength(4)]
        public int FabricationYear { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [ForeignKey("OwnerID")]
        public virtual Owners  Owner { get; set; }

        public bool? Deleted { get; set; }
    }
}
