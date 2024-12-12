using EmployeeApplicationSolution.Interfaces;
using EmployeeApplicationSolution.Models;

namespace EmployeeApplicationSolution.Services
{
    public class EmployeeGeneralService : IEmployeeGeneralService
    {
        private readonly IRepository<Employee, int> _employeeService;
        public EmployeeGeneralService(IRepository<Employee, int> employeeService)
        {
            _employeeService = employeeService;
        }

        public List<Employee> GetEmployees()
        {
            var employees = _employeeService.Get().OrderBy(p => p.Age);
            return employees.ToList();
        }
    }
}
