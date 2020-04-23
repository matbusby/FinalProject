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
    [Table("Programs")]
    class ProgramEntity
    {
        public int ProgramID { get; set; }
        public string ProgramName { get; set; }
        public string DiplomaName { get; set; }
        public int SchoolCode { get; set; }
        public double Tuition { get; set; }
        public double InternationalTuition { get; set; }
    }
}
