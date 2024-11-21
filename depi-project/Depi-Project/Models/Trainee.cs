namespace Depi_Project.Models{


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Trainee
{
    [Key]
    public int?Trainee_Id { get; set; }
    public string? Name {get ;set;}

    public int? Age {get ;set;}

    public string? PhoneNumber {get ; set;}

     public string? Address {get ;set;}

    public DateTime? Start_Of_Subscription { get; set; }
    
    public DateTime? End_Of_Subscription { get; set; }

    public int? type_Of_Subscription { get; set; }

    [ForeignKey("type_Of_Subscription")]

    public virtual Subscription? subscription {get ; set; }



}
}
