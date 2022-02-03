using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RUG.WebEng.Properties.Models;

[Owned]
public class RoomInfo{
    public string? Furnish{get;set;}
    public string? PropertyType {get;set;}
    public string? EnergyLabel{get;set;}
    public int? AreaSqm {get;set;}
    public ICollection<Property> Properties { get; set; } = new List<Property>();
}