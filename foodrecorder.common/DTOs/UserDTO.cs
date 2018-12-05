using System;
using FoodRecorder.Common;

public class UserDTO{

    public Guid ID{ get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string EmailID { get; set; }

    //META Data
    public DateTime CreatedOn {get; set;}

    public UserDTO(User user)
    {
        if(user !=null){
            ID = user.ID;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
            EmailID = user.EmailID;
            CreatedOn = user.CreatedOn;
        }
    }
}
