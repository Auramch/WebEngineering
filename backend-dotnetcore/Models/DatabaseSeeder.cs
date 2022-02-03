using System.Buffers;
using System.Buffers.Text;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace RUG.WebEng.Properties.Models;
public class DatabaseSeeder{
    private class JsonPropertyModel
{
    public string? City { get;set;}
    public string? PropertyType {get;set;}
    public int? Rent {get;set;}
    [JsonPropertyName("url")] public string? Url {get;set;}
    public int? AreaSqm {get;set;}
    public string? Title {get;set;}
    public string? Latitude{get;set;}
    public string? Longitude {get;set;}
    public string? Furnish{get;set;}
    public string? PostalCode {get;set;}
    public string? EnergyLabel{get;set;}
    public int? Deposit {get;set;}
    public int? AdditionalCosts{get;set;}
    public string? NonTranslatedDescription{get;set;}
    public string? TranslatedDescription{get;set;}
    public string? Gender{get;set;}
    public string? Internet{get;set;}
    public string? Kitchen{get;set;}
    public string? Living{get;set;}
    public string? Shower{get;set;}
    public string? Toilet{get;set;}
    public string? IsRoomActive{get;set;}
    public string? Roommates{get;set;}
    public string? Pets{get;set;}
    public string? SmokingInside{get;set;}
    public string? PostedAgo{get;set;}
    public string? Availabilty{get;set;}





}

public static async Task InitializeAsync(DatabaseContext context)
{
    await context.Database.EnsureCreatedAsync();

    if(await context.Properties.AnyAsync())
    {
        return;
    }

    var dataFile= File.OpenRead("../data/properties.json");
    var results = await JsonSerializer.DeserializeAsync<List<JsonPropertyModel>>(dataFile, new JsonSerializerOptions
    {
        AllowTrailingCommas = true,
        PropertyNameCaseInsensitive = true,
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    });


    foreach (var item in results)
    {
        if(item.Url== null) continue;

        var property = new Property
        {
            PostedAgo=item.PostedAgo,
            Roommates=item.Roommates,
            IsRoomActive=item.IsRoomActive,
            Gender=item.Gender,
            Availabilty=item.Availabilty,
            Url=item.Url,
            Title=item.Title,
            Location = new Location{
                City= item.City,
                Latitude = item.Latitude,
                Longitude = item.Longitude,
                PostalCode = item.PostalCode
            },
            RoomInfo = new RoomInfo{
                AreaSqm= item.AreaSqm,
                Furnish= item.Furnish,
                PropertyType= item.PropertyType,
                EnergyLabel=item.EnergyLabel
            },
            Costs= new Costs{
                Rent=item.Rent,
                AdditionalCosts=item.AdditionalCosts,
                Deposit=item.Deposit
            },
            Description=new Description{
                NonTranslatedDescription=item.NonTranslatedDescription,
                TranslatedDescription=item.TranslatedDescription
            },
            Allowances= new Allowances{
                Pets=item.Pets,
                SmokingInside=item.SmokingInside
            },
            Commodities= new Commodities{
                Internet=item.Internet,
                Kitchen=item.Kitchen,
                Shower=item.Shower,
                Living=item.Living,
                Toilet=item.Toilet
            }
        };

        context.Properties.Add(property);
    }
    

    await context.SaveChangesAsync();
}
}
