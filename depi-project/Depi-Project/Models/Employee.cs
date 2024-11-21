namespace Depi_Project.Models{
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
    public class Employee
{
     [Key]
    public int?Employee_Id { get; set; }
    
    public string? Name {get ;set;}

    public int? Age {get ;set;}

    public string? PhoneNumber {get ; set;}

     public string? Address {get ;set;}

     
    public int? OverTime {get ;set;}
   
    public int? Salary {get ;set;}

    public int? Department_Id {get ; set ; }

    [ForeignKey("Department_Id")]

    public virtual Department? department {get ; set;}
   
}
}

