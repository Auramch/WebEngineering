using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RUG.WebEng.Properties.Models;

[Owned]
public class Costs{
    public int? Deposit {get;set;}
    public int? AdditionalCosts{get;set;}
    public int? Rent {get;set;}
    public ICollection<Property> Properties { get; set; } = new List<Property>();
}