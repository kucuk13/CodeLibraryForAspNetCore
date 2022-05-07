using Microsoft.AspNetCore.Mvc;
using GenericRepositoryExample.Models;
using GenericRepositoryExample.Repositories;

namespace GenericRepositoryExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        private IGenericRepository<Departmant> _departmentRepository;

        public DepartmentController(ILogger<DepartmentController> logger, IGenericRepository<Departmant> departmentRepository)
        {
            _logger = logger;
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Departmant> GetAll()
        {
            return _departmentRepository.GetAll();
        }
    }
}