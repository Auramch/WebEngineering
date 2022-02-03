using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RUG.WebEng.Properties.Models;

[Owned]
public class Allowances{
    public string? Pets{get;set;}
    public string? SmokingInside{get;set;}
    public ICollection<Property> Properties { get; set; } = new List<Property>();
}