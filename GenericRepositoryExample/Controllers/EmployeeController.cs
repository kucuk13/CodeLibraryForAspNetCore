using Microsoft.AspNetCore.Mvc;
using GenericRepositoryExample.Models;
using GenericRepositoryExample.Repositories;

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
        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }
    }
}