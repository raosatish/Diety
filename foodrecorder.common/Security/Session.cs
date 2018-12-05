using System;
namespace FoodRecorder.Common{

public class Session{
    public Guid ID{ get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }

    public Guid User { get; set; }

        //META Data
    public DateTime CreatedOn {get; set;}

    public Session(User user)
    {
        ID = Guid.NewGuid();
        FirstName = user.FirstName;
        LastName = user.LastName;
        UserName = user.UserName;
        CreatedOn = DateTime.UtcNow;
        User = user.ID;
    }
}
}