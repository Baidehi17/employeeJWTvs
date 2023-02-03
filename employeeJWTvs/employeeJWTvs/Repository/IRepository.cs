using employeeJWTvs.Models;

namespace employeeDirectory.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        T ADD(T ID);
        T UPDATE(T obj);
        void Delete(int id);
        //EmployeeDetail del(int id); 
        void Save();
        //void Deletes(int id);

    }
}
