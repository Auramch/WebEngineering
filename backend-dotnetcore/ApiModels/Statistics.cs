using System.ComponentModel.DataAnnotations;
using RUG.WebEng.Properties.ApiModels;

namespace RUG.WebEng.Properties.ApiModels;

public class Statistics
{
    public float mean { get;}
    public int median { get;}
    public float standardDerivation { get;}

    public Statistics(ApiModels.Property property){
    //TODO: functions that calculate the stadistics with the given properties
    }

}

