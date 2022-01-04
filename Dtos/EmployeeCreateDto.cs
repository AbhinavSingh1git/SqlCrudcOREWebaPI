using System.ComponentModel.DataAnnotations;

namespace EmployeeWebApi.Dtos
{
   public class EmployeeCreatedto
    {
        // public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        public string Description { get; set; }
    }


}