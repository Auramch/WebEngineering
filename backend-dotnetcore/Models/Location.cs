using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RUG.WebEng.Properties.Models;

[Owned]
public class Location{
    [Key]
    public int Id {get;init;}
    public string? Latitude{get;set;}
    public string? Longitude {get;set;}
    public string? PostalCode {get;set;}
    public string? City { get;set;}
    public ICollection<Property> Properties { get; set; } = new List<Property>();

}