using System;

public class Eaten{
    public Guid ID { get; set; }
    public Guid Food { get; set; }
    public int Servings { get; set; }
    public int Calories { get; set; }
    public string Message { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
}