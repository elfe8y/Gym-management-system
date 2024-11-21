namespace Depi_Project.Models{

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Department
{
    [Key]
    public int?Department_Id { get; set; }
    
    public string? Department_Name {get ;set;}

}
}
