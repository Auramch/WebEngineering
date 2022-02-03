using System.ComponentModel.DataAnnotations;

namespace RUG.WebEng.Properties.Models;

public class Property{
    [Key]
    public int Id{get;set;}

    [Required]
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

    


}