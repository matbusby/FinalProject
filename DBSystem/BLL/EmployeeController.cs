using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using DBSystem.DAL;
using DBSystem.ENTITIES;

namespace DBSystem.BLL
{
    public class EmployeeController
    {
        public EmployeeEntity FindByPKID(int id)
        {
            using (var context = new Context())
            {
                return context.EmployeeEntitys.Find(id);
            }
        }
        public List<EmployeeEntity> List()
        {
            using (var context = new Context())
            {
                return context.EmployeeEntitys.ToList();
            }
        }
        //public List<EmployeeEntity> FindByID(int id)
        //{
        //    using (var context = new Context())
        //    {
        //        IEnumerable<EmployeeEntity> results =
        //            context.Database.SqlQuery<EmployeeEntity>("Products_GetByCategories @ID"
        //                , new SqlParameter("ID", id));
        //        return results.ToList();
        //    }
        //}
        public List<EmployeeEntity> FindByPartialName(string partialname)
        {
            using (var context = new Context())
            {
                IEnumerable<EmployeeEntity> results =
                    context.Database.SqlQuery<EmployeeEntity>("Employees_FindByPartialName @PartialName",
                         new SqlParameter("PartialName", partialname));
                return results.ToList();
            }
        }
        public int Add(EmployeeEntity item)
        {
            using (var context = new Context())
            {
                context.EmployeeEntitys.Add(item);
                context.SaveChanges();
                return item.EmployeeID;

            }
        }
        public int Update(EmployeeEntity item)
        {
            using (var context = new Context())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges();
            }
        }
        public int Delete(int employeeid)
        {
            using (var context = new Context())
            {
                var existing = context.EmployeeEntitys.Find(employeeid);
                if (existing == null)
                {
                    throw new Exception("Record has been removed from database");
                }
                context.EmployeeEntitys.Remove(existing);
                return context.SaveChanges();
            }
        }
    }
}

