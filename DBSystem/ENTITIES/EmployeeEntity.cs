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
    [Table("Employees")]
    public class EmployeeEntity
    {
        [Key]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateHired { get; set; }
        public string ReleaseDate { get; set; }
        public int PositionID { get; set; }
        public int ProgramID { get; set; }
        public string LoginID { get; set; }
    }
}
