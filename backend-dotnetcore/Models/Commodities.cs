using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RUG.WebEng.Properties.Models;

[Owned]
public class Commodities {
    public string? Internet{get;set;}
    public string? Kitchen{get;set;}
    public string? Living{get;set;}
    public string? Shower{get;set;}
    public string? Toilet{get;set;}
    public ICollection<Property> Properties { get; set; } = new List<Property>();
}