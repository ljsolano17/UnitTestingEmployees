using UnitTestCase.Models;

namespace UnitTestCase.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees;
        public EmployeeService() 
        {
            _employees = new List<Employee>() {
            new Employee() { 
                Id = 101,
                Name = "Luis Solano",
                PhoneNo = "86566262",
                EmailId = "ljsolanomk12@gmail.com"
            },
            new Employee()
            {
                Id = 102,
                Name = "Pedro Sotro",
                PhoneNo = "88566542",
                EmailId = "lpedro@gmail.com"
            },
            new Employee()
            {
                Id = 103,
                Name = "Roger Perez",
                PhoneNo = "82566969",
                EmailId = "rogermk33@hotmail.com"
            }
            };
        }
        public Employee Add(Employee employee)
        {
            int newId = _employees.Max(x => x.Id)+1; 
            employee.Id = newId;
            _employees.Add(employee);
            return employee;
        }

        public bool Delete(int id)
        {
            var existing = _employees.Find(x => x.Id == id);
            if (existing != null)
            {
                _employees.Remove(existing);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Employee> GetAll()
        {
            return _employees;
        }

        public Employee GetById(int id)
        {
            return _employees.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
