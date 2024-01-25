using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace flightapp.Models;

public partial class Suhasinicustomer
{
    public int Customerid { get; set; }

    [Display(Name ="Enter Your Email")]
    [Required(ErrorMessage ="Required")]
    [EmailAddress(ErrorMessage ="Invalid email")]
    public string? Customeremail { get; set; }
[Display(Name ="Enter Your password")]
[Required(ErrorMessage ="Required")]
[MinLength(5,ErrorMessage ="Too short")]
    public string? Customerpw { get; set; }

[Required(ErrorMessage ="Required")]
[Display(Name ="Enter Your username")]
    public string? Customerusername { get; set; }
    [Required(ErrorMessage ="Required")]
[Display(Name ="Enter Your Location")]
    public string? Customerlocation { get; set; }

    public virtual ICollection<Suhasinibooking> Suhasinibookings { get; set; } = new List<Suhasinibooking>();
}
