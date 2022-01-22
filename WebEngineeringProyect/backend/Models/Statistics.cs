using System.ComponentModel.DataAnnotations;
using backend.ApiModels;

namespace backend.Models;

public class Statistics
{
    public float mean { get;}
    public int median { get;}
    public float standardDerivation { get;}

    public Statistics(<IAsyncEnumerable<ApiModels.Property>){
    //TODO: functions that calculate the stadistics with the given properties
    }

}