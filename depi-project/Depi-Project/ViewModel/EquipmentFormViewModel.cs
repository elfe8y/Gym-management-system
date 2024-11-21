using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Depi_Project.ViewModel
{
    public class EquipmentFormViewModel
    {
        public int Equipment_Id { get; set; } 

        [Required, MaxLength(150)]
        public string? Equipment_Name { get; set; }

        [Required, Display(Name = "Maintenance Date")]
        public string? Maintainance_Date { get; set; }

        [Required, Display(Name = "Status")]
        public string? Status { get; set; }

        
        public List<string> StatusOptions { get; set; } = new List<string> { "Available", "In Maintenance", "Out of Service" };
    }
}
