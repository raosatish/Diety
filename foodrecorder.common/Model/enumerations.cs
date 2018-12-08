using System.ComponentModel;

public enum UnitOfMeasure{
    None=1, 
//Mass - Weight
    [Description("Kilograms, Kilogram, Kgs, Kg")]
    Kilogram=1000, 
    [Description("Grams, Gram, g")]
    Gram=1001, 
    [Description("Milligrams, Milligram, Mg, Mgs")]
    Milligram=1002,
    [Description("Grain")]
    Grain=1003, 
    [Description("Dram")]
    Dram=1004, 
    [Description("Ounce")]
    Ounce=1005, 
    [Description("Pound,lb,lbs")]
    Pound=1006,  

//Capacity - Volume
    [Description("Liter, L, lt, lts")]
    Liter=2001,
    [Description("Milliliter, Milliliters, Ml, mls")]
    Milliliter=2002,
    [Description("Deciliter")]
    DeciLiter=2003,
    [Description("Teaspoon")]
    Teaspoon=2004, 
    [Description("Tablespoon")]
    Tablespoon=2005, 
    [Description("Fluid Ounce")]
    FluidOunce=2006, 
    [Description("Cup")]
    Cup=2007, 
    [Description("Gill")]
    Gill=2008, 
    [Description("Pint")]
    Pint=2009, 
    [Description("Quart")]
    Quart=2010, 
    [Description("Gallon")]
    Gallon=2011,
    [Description("Pinch")]
    Pinch=2012,

//Length - Distance
    [Description("Meter")]
    Meter=3001,
    [Description("Centimeter")]
    Centimeter=3002,
    [Description("Millimeter")]
    Millimeter=3003,
    [Description("Foot")]
    Foot=3004,
    [Description("Inch")]
    Inch=3005,
}