using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;
using System.Data.SqlTypes;

namespace DBSystem.ENTITIES
{
    [Table("Programs")]
    public class ProgramEntity
    {
        [Key]
        public int? ProgramID { get; set; }
        public string ProgramName { get; set; }
        public string DiplomaName { get; set; }
        public string SchoolCode { get; set; }
        public SqlMoney Tuition { get; set; }
        public SqlMoney InternationalTuition { get; set; }
    }
}
