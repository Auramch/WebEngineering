using System.ComponentModel.DataAnnotations;

namespace RUG.WebEng.Properties.Models;

public class City{
    [Key]
    public int Id{ get; init;}

    [Required]
    public string Name{get;set;}

    public ICollection<Property> Properties{get;set;} = new List<Property>();
}