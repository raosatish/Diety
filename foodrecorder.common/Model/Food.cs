using System;

public class Food{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public Serving Serving {get; set;}
    public int CaloriesPerServing {get; set;}

    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
    
}