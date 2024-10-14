using System.ComponentModel.DataAnnotations;

namespace TP4.ViewModel
{
    public class EmployeeVM
    {
        [Key]
        public int EmployeeId { get; set; }

        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? Designation { get; set; }

        public decimal Salary { get; set; }

        public DateTime JoiningDate { get; set; }
        public string NomDepartement { get; set; }
    }
}
