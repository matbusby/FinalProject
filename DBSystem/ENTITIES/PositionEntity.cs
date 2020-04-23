using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace DBSystem.ENTITIES
{
    [Table("Positions")]
    class PositionEntity
    {
        public int PositionID { get; set; }
        public string Description { get; set; }
        public int? ReportsTo { get; set; }

    }
}
