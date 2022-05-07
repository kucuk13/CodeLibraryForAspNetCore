using Microsoft.AspNetCore.Mvc;
using AutoMapperExample.Models;
using AutoMapper;

namespace AutoMapperExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;

        public EmployeeController(ILogger<EmployeeController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public List<EmployeeDto> GetAll()
        {
            List<EmployeeDao> list = new List<EmployeeDao>()
            {
                new EmployeeDao()
                {
                    Name = "Burhan",
                    Surname = "Küçük",
                    EmailAddress = "burhan_test@email.com",
                    PhoneNumber = "+90**********",
                    SocialNumber = "***********",
                    BirthDate = new DateTime(1992, 1, 1)
                },
                new EmployeeDao()
                {
                    Name = "Kaan",
                    Surname = "Küçük",
                    EmailAddress = "kaan_test@email.com",
                    PhoneNumber = "+90**********",
                    SocialNumber = "***********",
                    BirthDate = new DateTime(1995, 1, 1)
                }
            };

            return _mapper.Map<List<EmployeeDto>>(list);
        }
    }
}