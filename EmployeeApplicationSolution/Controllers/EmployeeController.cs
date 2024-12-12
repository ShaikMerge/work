    using EmployeeApplicationSolution.Interfaces;
    using EmployeeApplicationSolution.Models;
    using EmployeeApplicationSolution.Models.DTO;
    using EmployeeApplicationSolution.Services;
    using Microsoft.AspNetCore.Mvc;

    namespace EmployeeApplicationSolution.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class EmployeeController : ControllerBase
        {
            private readonly IEmployeeSuplierService _employeeSuplierService;
            public EmployeeController(IEmployeeSuplierService employeeSuplierService)
            {
                _employeeSuplierService = employeeSuplierService;
            }
            [HttpGet]
            public IActionResult GetEmployees()
            {
                var employees = _employeeSuplierService.GetEmployees();
                return Ok(employees);
            }

            [HttpPost]
            [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
            [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
            public ActionResult<Employee> AddProduct(Employee employee)
            {
                try
                {
                    var newProduct = _employeeSuplierService.AddEmployee(employee);
                    return Created("", newProduct);
                }
                catch (Exception e)
                {

                    return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = e.Message });
                }
            }
            [HttpPut]
            [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
            public ActionResult<Employee> UpdateProduct(EmployeeUpdateDTO productDto)
            {
                string message = "";
                try
                {
                    if (productDto.SalaryChange != null)
                    {
                        var updatedProduct = _employeeSuplierService.UpdateEmployeeSalary(productDto.SalaryChange);
                        return Ok(updatedProduct);
                    }
                    else if (productDto.PhoneNumberChange != null)
                    {
                        var updatedProduct = _employeeSuplierService.UpdateEmployeePhoneNumber(productDto.PhoneNumberChange);
                        return Ok(updatedProduct);
                    }
                }
                catch (Exception e)
                {
                    message = e.Message;
                }
                return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = message });
            }




        }
    }

