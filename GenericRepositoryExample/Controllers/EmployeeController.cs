using Microsoft.AspNetCore.Mvc;
using GenericRepositoryExample.Models;
using GenericRepositoryExample.Repositories;
using GenericRepositoryExample.Extensions;

namespace GenericRepositoryExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private IGenericRepository<Employee> _employeeRepository;

        public EmployeeController(ILogger<EmployeeController> logger, IGenericRepository<Employee> employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<Employee>> GetAll()
        {
            var employees = new List<Employee>() { 
                new Employee()
                {
                    Name = "Kaan",
                    Surname = "Küçük"
                },
                new Employee()
                {
                    Name = "Tolga",
                    Surname = "Küçük"
                },
                new Employee()
                {
                    Name = "Burhan",
                    Surname = "Küçük"
                },

            }.AsEnumerable();

            return employees.ContainsIgnoreCase(nameof(Employee.Surname), "kÜ").Where(x => !x.IsDeleted);
        }
    }
}