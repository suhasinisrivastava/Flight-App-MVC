using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace flightapp.Models;

public partial class Suhasinibooking
{
    [Display(Name ="Booking id")]
    
    public string Bookingid { get; set; } = null!;

    [Display(Name ="Customer id")]
    

    public int? Customerid { get; set; }
    [Display(Name ="Enter your name")]
    [Required(ErrorMessage ="Required")]

    public string? Bookingname { get; set; }

    [Display(Name ="Flight ID")]
    

    public string? Flightid { get; set; }

    [Display(Name ="Booking date and time")]
    

    public DateTime? Bookingdate { get; set; }

    [Display(Name ="Enter your phone number")]
    [Required(ErrorMessage ="Required")]
    

    public int? Bookingphone { get; set; }

    [Display(Name ="Enter address")]
    [Required(ErrorMessage ="Required")]

    public string? Bookingaddress { get; set; }

    public int? Bookingtotalcost { get; set; }

    [Display(Name ="Enter no of passengers")]
    [Required(ErrorMessage ="Required")]

    public int? Bookingtotalmembers { get; set; }

    public virtual Suhasinicustomer? Customer { get; set; }

    public virtual Suhasiniflight? Flight { get; set; }
}
