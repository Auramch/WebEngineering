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
    public string? PostedAgo{get;set;}
    public string? Roommates{get;set;}
    public string? IsRoomActive{get;set;}
    public string? Gender{get;set;}
    public string? Availabilty{get;set;}
    public string? Url{get;set;}
    public int? budget{get;set;}
    public int? square{get;set;}
    public string? Title{get;set;}
    public Location Location{get;set;}
    public RoomInfo RoomInfo{get;set;}
    public Costs Costs{get;set;}
    public Description Description{get;set;}
    public Allowances Allowances{get;set;}
    public Commodities Commodities{get;set;}

    public static Property FromDatabase(Models.Property property) =>
        new()
        {
            Id = property.Id,
            PostedAgo = property.PostedAgo,
            Roommates = property.Roommates,
            IsRoomActive = property.IsRoomActive,
            Gender = property.Gender,
            Availabilty = property.Availabilty
            Url = property.Url,
            budget = property.budget,
            square = property.square,
            Title = property.Title,
            Location = property.Location,
            RoomInfo = property.RoomInfo,
            Costs = property.Costs,
            Description = property.Description,
            Allowances = property.Allowances,
            Commodities = property.Commodities
        };

    public class Costs
    {
        [Range(1, 10)]
        public int? deposit { get; set; }
        public int rent { get; set; }

        [Range(1, 100)]
        public int? additionalCosts { get; set; }
    }
}