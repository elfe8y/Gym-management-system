namespace Depi_Project.Models{
    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Equipment
{
    [Key]
    public int Equipment_Id { get; set; }
    
    public string? Equipment_Name {get ;set;}

    public string? Maintainance_Date {get ; set;}

    public string ? Status {get ; set ;}
}
}

