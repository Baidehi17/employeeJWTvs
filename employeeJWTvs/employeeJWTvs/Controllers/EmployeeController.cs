using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using employeeJWTvs.Models;
using employeeDirectory.Repository;
using Microsoft.AspNetCore.Authorization;

namespace employeeDirectory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private IRepository<EmployeedetailJwt> _employee;
       
        public EmployeeController()
        {
            _employee = new EmployeeService<EmployeedetailJwt>();
        }

        [HttpGet]
        public IEnumerable<EmployeedetailJwt> GetDetails()
        {
            return _employee.GetAll();
        }
        [HttpGet("{id}")]
        public EmployeedetailJwt GetDetail(int id) 
        {
            var result =_employee.GetByID(id);
            return result;
        }
        [HttpPost]
        public EmployeedetailJwt Insert(EmployeedetailJwt employeeDetail)
        {
            var result = _employee.ADD(employeeDetail);
            return result;
        }
        [HttpPut("{id}")]
        public EmployeedetailJwt Update(EmployeedetailJwt obj)
        {
            var result = _employee.UPDATE(obj);
            return result;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           _employee.Delete(id);
           
        }
    }
}
