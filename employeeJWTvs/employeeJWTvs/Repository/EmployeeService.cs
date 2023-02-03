using employeeJWTvs.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace employeeDirectory.Repository
{
    public class EmployeeService<T> : IRepository<T> where T : class
    {
        public readonly EmployeeJwtContext context;
        public readonly DbSet<T> dbset;
        public EmployeeService() 
        {
            context= new EmployeeJwtContext(); 
            dbset = context.Set<T>();
        }

        IEnumerable<T> IRepository<T>.GetAll()
        {
        return dbset.AsEnumerable();
        }
        
        public T ADD(T ID)
        {
            dbset.Add(ID);
            Save();
            return ID;
        }
        public T UPDATE(T obj)
        {
            dbset.Attach(obj);
            context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
            return obj;
        }

        public void Delete(int id)
        {
            T emp = dbset.Find(id);
            dbset.Remove(emp);
             Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public T GetByID(int id)
        {
            return dbset.Find(id);
        }

    }
}
