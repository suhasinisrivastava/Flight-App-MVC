using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace flightapp.Models;

public partial class Suhasiniflight
{
    public string Flightid { get; set; } = null!;

    public string? Flightname { get; set; }

    [Display(Name ="Select Flight Source")]
    [Required(ErrorMessage ="Required")]

    public string? Flightsource { get; set; }
    [Display(Name ="Select Flight destination")]
    [Required(ErrorMessage ="Required")]

    public string? Flightdestination { get; set; }
    [Display(Name ="Select date")]
    [Required(ErrorMessage ="Required")]

    public DateOnly? Flightdate { get; set; }

    public TimeOnly? Flightsourcetime { get; set; }

    public int? Flightprice { get; set; }

    public TimeOnly? Flightdestinationtime { get; set; }

    public virtual ICollection<Suhasinibooking> Suhasinibookings { get; set; } = new List<Suhasinibooking>();
}
