using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RUG.WebEng.Properties.Models;

[Owned]
public class Statistics{
    [Key]
    public int Id {get;init;}
    public string? City{get;set;}
    public float? RentMean{get;set;}
    public float? DepositMedian{get;set;}
    public float? RentSd{get;set;}
    public float? RentMedian{get;set;}
    public float? DepositMean{get;set;}
    public float? DepositSd{get;set;}
    public ICollection<Property> Properties { get; set; } = new List<Property>();

}