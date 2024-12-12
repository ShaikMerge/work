using EmployeeApplicationSolution.Models;
using EmployeeApplicationSolution.Models.DTO;

namespace EmployeeApplicationSolution.Interfaces
{
    public interface IEmployeeSuplierService : IEmployeeGeneralService
    {
        public Employee AddEmployee(Employee employee);
        public Employee UpdateEmployeeSalary(EmployeeSalaryUpdateRequestDTO employee);
        public Employee UpdateEmployeePhoneNumber(EmployeePhoneNumberUpdateRequestDTO employee);

    }
}
