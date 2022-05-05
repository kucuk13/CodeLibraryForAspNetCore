using MigrationExample.Models;

namespace MigrationExample.Helpers
{
    public class SeedDataHelper
    {
        public static List<Departmant> GetInitialDepartmantData()
        {
            return new List<Departmant>
            {
                new Departmant
                {
                    Id = 1,
                    Name = "Information Techonolgy"
                },
                new Departmant
                {
                    Id = 2,
                    Name = "Human Resources"
                }
            };
        }

        public static List<Employee> GetInitialEmployeeData()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Kaan",
                    Surname = "Küçük",
                    PersonalEmailAddress = "test@email.com",
                    CorporateEmailAddress = "test@email.com",
                    PhoneNumber = "+90**********",
                    Password = "******",
                    SocialNumber = "***********",
                    DepartmentId = 1,
                    BirthDate = DateTime.SpecifyKind(new DateTime(1995, 1, 1), DateTimeKind.Utc)
                }
            };
        }
    }
}
