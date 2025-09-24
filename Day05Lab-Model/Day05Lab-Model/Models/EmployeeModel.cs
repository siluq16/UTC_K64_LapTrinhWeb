using System.ComponentModel.DataAnnotations;

namespace Day05Lab_Model.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        public bool Status { get; set; }  
    }
}
