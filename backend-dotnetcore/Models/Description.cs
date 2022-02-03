using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RUG.WebEng.Properties.Models;
[Owned]
public class Description{
    public string? NonTranslatedDescription{get;set;}
    public string? TranslatedDescription{get;set;}
    public ICollection<Property> Properties { get; set; } = new List<Property>();
}