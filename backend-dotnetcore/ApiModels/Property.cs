using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.Annotations;

namespace RUG.WebEng.Properties.ApiModels;

public class Property
{
    [BindNever]
    [SwaggerSchema(ReadOnly = true)]
    public int Id { get; init; }
    [BindRequired]
    public string? Title { get; set; }
    public string? PostedAgo{get;set;}
    public string? IsRoomActive{get;set;}
    public string? Roommates{get;set;}
    public string? Gender{get;set;}
    public string? Availabilty{get;set;}
    public DescriptionSummary Description { get; set; } = new();
    public LocationSummary Location{get;set;}=new();
    public RoomInfoSummary RoomInfo{get;set;}=new();
    public CostsSummary Costs{get;set;}=new();
    public AllowancesSummary Allowances{get;set;}=new();
    public CommoditiesSummary Commodities{get;set;}=new();

    [BindRequired, JsonPropertyName("url")]
    public string? Url { get; set; }

    public static Property FromDatabase(Models.Property property) =>
        new()
        {
            Id = property.Id,
            Title = property.Title,
            Url = property.Url,
            PostedAgo=property.PostedAgo,
            IsRoomActive=property.IsRoomActive,
            Roommates=property.Roommates,
            Gender=property.Gender,
            Availabilty=property.Availabilty,
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
            },
            Description={
                NonTranslatedDescription=property.Description.NonTranslatedDescription,
                TranslatedDescription=property.Description.NonTranslatedDescription
            },
            Allowances={
                Pets=property.Allowances.Pets,
                SmokingInside=property.Allowances.SmokingInside
            },
            Commodities={
                Internet=property.Commodities.Internet,
                Kitchen=property.Commodities.Kitchen,
                Living=property.Commodities.Living,
                Shower=property.Commodities.Shower,
                Toilet=property.Commodities.Toilet
            }
        };
        public class LocationSummary{
            public string? City { get;set;}
            public string? Latitude{get;set;}
            public string? Longitude {get;set;}
            public string? PostalCode {get;set;}
        }
        public class RoomInfoSummary{
            public int? AreaSqm {get;set;}
            public string? PropertyType {get;set;}
            public string? Furnish{get;set;}
            public string? EnergyLabel{get;set;}
        }
        public class CostsSummary{
            public int? Rent {get;set;}
            public int? Deposit {get;set;}
            public int? AdditionalCosts{get;set;}
        }

        public class DescriptionSummary{
            public string? NonTranslatedDescription{get;set;}
            public string? TranslatedDescription{get;set;}
        }
        public class AllowancesSummary{
            public string? Pets{get;set;}
            public string? SmokingInside{get;set;}
        }
        public class CommoditiesSummary{
            public string? Internet{get;set;}
            public string? Kitchen{get;set;}
            public string? Living{get;set;}
            public string? Shower{get;set;}
            public string? Toilet{get;set;}
        }

}