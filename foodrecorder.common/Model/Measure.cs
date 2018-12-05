using System;
using System.Collections.Generic;
using FoodRecorder.Common.ExtensionMethods;

public static class MeasureList{
    public static List<Measure> Measures {get;}
    static MeasureList()
    {
        Measures = new List<Measure>();
        foreach (UnitOfMeasure measureEnum in Enum.GetValues(typeof(UnitOfMeasure)))
            {
                if(!string.Equals(measureEnum.GetDescription(),"none", StringComparison.InvariantCultureIgnoreCase)){
                    Measures.Add(new Measure(measureEnum.GetDescription()));
                }
            }
    }
}

public class Measure{
    public string Name { get; set; }
    public List<string> AllowedValues { get; set; }

    public Measure(string description)
    {
        if(string.IsNullOrWhiteSpace(description)) throw new Exception("Unknown description of measure.");
        string[] values = description.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
        Name = values[0];
        
        AllowedValues = new List<string>();
        for(int i=0;i<values.Length;i++){
                AllowedValues.Add(values[i]);
        }
    }
}