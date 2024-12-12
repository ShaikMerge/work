using EmployeeApplicationSolution.Interfaces;
using EmployeeApplicationSolution.Models;
using EmployeeApplicationSolution.Models.DTO;

namespace EmployeeApplicationSolution.Services
{
    public class EmployeeSupplierService : IEmployeeSuplierService
    {
        private readonly IRepository<Employee, int> _employeeRepo;
        
        public EmployeeSupplierService (IRepository<Employee, int> employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public Employee AddEmployee(Employee employee)
        {
            if (employee == null) throw new Exception("Unable to Add Employee, Employee cant be null");
            if (employee.EmployeeId < 0) throw new Exception("Unable to Add Employee, Employee ID cant be negative ");
            return _employeeRepo.Add(employee);
        }

        public List<Employee> GetEmployees()
        {
            var employees = _employeeRepo.Get().OrderBy(p => p.Age);
            return employees.ToList();
        }

        public Employee UpdateEmployeePhoneNumber(EmployeePhoneNumberUpdateRequestDTO employeedto)
        {
            if (employeedto == null) throw new Exception("Unable to Add Employee, Employee cant be null");
            var employee = _employeeRepo.Get(employeedto.EmployeeId);
            if (employee == null) throw new Exception("Unable to Update Employee,  Employee not found " );
            employee.EmployeePhoneNumber = employeedto.EmployeePhoneNumber;
            employee = _employeeRepo.Update(employeedto.EmployeeId, employee);
            return employee;

        }

        public Employee UpdateEmployeeSalary(EmployeeSalaryUpdateRequestDTO employeedto)
        {
            if (employeedto == null) throw new Exception("Unable to Add Employee, Employee cant be null");
            var employee = _employeeRepo.Get(employeedto.EmployeeId);
            if (employee == null) throw new Exception("Unable to Update Employee,  Employee not found ");
            employee.EmployeeSalary = employeedto.EmployeeSalary;
            employee = _employeeRepo.Update(employeedto.EmployeeId, employee);
            return employee;
        }
    }
}
