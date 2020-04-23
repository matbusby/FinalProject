using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity; //inheritance of DbContext from EntityFramework
using DBSystem.ENTITIES;

namespace DBSystem.DAL
{
    internal class Context : DbContext
    {
        public Context() : base("StarTEDDB") { }
        //public Context() : base("FSIS_db") { }
        //public Context() : base("StarTEDDB") { }
        public DbSet<EmployeeEntity> EmployeeEntitys { get; set; }
        public DbSet<PositionEntity> PositionEntities { get; set; }
        public DbSet<ProgramEntity> ProgramEntities { get; set; }
    }
}
