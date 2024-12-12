using System.Collections.Immutable;
using EmployeeApplicationSolution.Exceptions;
using EmployeeApplicationSolution.Interfaces;
using EmployeeApplicationSolution.Models;

namespace EmployeeApplicationSolution.Repositories
{
    public class EmployeeRepository : IRepository<Employee, int>
    {
        static IDictionary<int, Employee> employees = new Dictionary<int, Employee>()
        {
            {101, new Employee{EmployeeId = 7111, Age  = 24, Name = "Shaik shajahan"} },
            {102, new Employee{EmployeeId = 7110, Age  = 20, Name = "Raj"} },
            {103, new Employee{EmployeeId = 7186, Age  = 30, Name = "Srinu"}
            }
        };

        public Employee Add(Employee entity)
        {
            if (employees.Values.Contains(entity))
            {
                throw new Exception("Employee already exists in the repository");
            }
            int pid = GenerateProdcutID();
            entity.EmployeeId = pid;
            employees.Add(pid, entity);
            return entity;
        }
        private int GenerateProdcutID()
        {
            if (employees.Count == 0)
            {
                return 101;
            }
            return employees.Keys.Max() + 1;
        }

        public Employee Delete(int key)
        {
            throw new NotImplementedException();
        }

        public ICollection<Employee> Get()
        {
            if(employees.Count == 0)
            {
                throw new NoEmployeesFOundException();
            }
            return employees.Values;
        }

        public Employee Get(int key)
        {
            Employee? employee = employees.Keys.Contains(key) ? employees[key] : null;
            if (employee == null)
            {
                throw new Exception("Employee not found in the repository");
            }
            return employee;
        }

        public Employee Update(int key, Employee entity)
        {
            var product = Get(key);
            if (product == null)
            {
                throw new Exception("Employee not found in the repository");
            }
            employees[key] = entity;
            return entity;
        }
    }
}
