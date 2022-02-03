using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.Annotations;

namespace RUG.WebEng.Properties.ApiModels;

public class PropertySummary
{
    [BindNever]
    [SwaggerSchema(ReadOnly = true)]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Availability {get;set;}
    public CostsSummary Costs{get;set;}
    public RoomInfoSummary RoomInfo{get;set;}
    public LocationSummary Location{get;set;}

     

    public static PropertySummary FromDatabase(Models.Property property) =>
        new()
        {
            Id = property.Id,
            Title = property.Title,
            Availability = property.Availabilty,
            Location={
                City=property.Location.City,
                Latitude=property.Location.Latitude,
                Longitude=property.Location.Longitude,
                PostalCode=property.Location.PostalCode
            },
            RoomInfo={
                AreaSqm=property.RoomInfo.AreaSqm,
                PropertyType=property.RoomInfo.PropertyType,
                Furnish=property.RoomInfo.Furnish,
                EnergyLabel=property.RoomInfo.Furnish
            },
            Costs={
                Rent=property.Costs.Rent,
                Deposit=property.Costs.Deposit,
                AdditionalCosts=property.Costs.AdditionalCosts    
            }
        };
        public class CostsSummary{
            public int? Rent {get;set;}
            public int? Deposit {get;set;}
            public int? AdditionalCosts{get;set;}
        }
        public class RoomInfoSummary{
            public int? AreaSqm {get;set;}
            public string? PropertyType {get;set;}
            public string? Furnish{get;set;}
            public string? EnergyLabel{get;set;}
        }
        public class LocationSummary{
            public string? City { get;set;}
            public string? Latitude{get;set;}
            public string? Longitude {get;set;}
            public string? PostalCode {get;set;}
        }
}