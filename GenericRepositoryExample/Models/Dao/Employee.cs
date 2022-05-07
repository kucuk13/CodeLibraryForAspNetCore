using System.ComponentModel.DataAnnotations.Schema;

namespace GenericRepositoryExample.Models
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalEmailAddress { get; set; }
        public string CorporateEmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string SocialNumber { get; set; }
        public int DepartmentId { get; set; }
        public DateTime BirthDate { get; set; }


        [ForeignKey("DepartmentId")]
        public virtual Departmant Departmant { get; set; }
    }
}
