using EmployeeK8sDemo.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeK8sDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>();



        static EmployeesController()
        {



            employees.Add(new Employee { Id = 1, FirstName = "Robert", LastName = "Warner", Salary = 20000 });
            employees.Add(new Employee { Id = 2, FirstName = "Lily", LastName = "Petter", Salary = 50000 });
        }



        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employees;
        }
        [HttpGet("{id}", Name = "Get")]
        public Employee Get(int id)
        {
            return employees.Find(e => e.Id == id);
        }
        [HttpPost]
        public string Post([FromBody] Employee Employee)
        {
            if (Employee == null)
            {
                throw new ArgumentNullException("Employee");
            }
            employees.Add(Employee);
            return "Employee added ";
        }
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Employee Employee)
        {
            if (Employee == null)
            {
                throw new ArgumentNullException("Employee");
            }
            int Index = employees.FindIndex(p => p.Id == Employee.Id);
            if (Index == -1)
            {
                return false;
            }
            employees.RemoveAt(Index);
            employees.Add(Employee);
            return true;





        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {



            var emp = employees.Find(e => e.Id == id);
            employees.Remove(emp);



        }





    }
}