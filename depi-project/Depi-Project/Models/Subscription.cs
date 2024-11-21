namespace Depi_Project.Models{
    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class Subscription
{
     [Key]
    public int?Subscription_Id { get; set; }
    
    public string? Name {get ;set;}

    public int ? price {get ; set ;}

    public string? Description {get ; set;}
}
}


    

 
