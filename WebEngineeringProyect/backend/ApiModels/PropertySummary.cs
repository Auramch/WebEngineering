using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.Annotations;

namespace RUG.WebEng.Properties.ApiModels;

public class PropertySummary
{
    [BindNever]
    [SwaggerSchema(ReadOnly = true)]
    public int Id { get; set; }
    public string? Title{get;set;}
    public Location Location{get;set;}
    public string? Availabilty{get;set;}
    public Costs Costs{get;set;}
    public Allowances Allowances{get;set;}

    public static PropertySummary FromDatabase(Models.Property Property) =>
        new()
        {
            Id = Property.Id,
            Title = Property.Title,
            Location = Property.Location,
            Availabilty = Property.Availabilty,
            Costs = Property.Costs,
            Allowances = Property.Allowances
        };
}