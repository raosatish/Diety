using System;
using System.Security;

namespace FoodRecorder.Common{
public class User{
    public Guid ID{ get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string EmailID { get; set; }

    public string SecretQuestion {get;set;}
    public string SecretAnswer {get;set;}

        //META Data
    public DateTime CreatedOn {get; set;}
    public DateTime ModifiedOn { get; set; }

    public bool IsEqual(User user){
        if(string.Equals(EmailID, user.EmailID)){
            if(string.Equals(FirstName, user.FirstName)){
                if(string.Equals(LastName, user.LastName)){
                    if(string.Equals(UserName, user.UserName)){
                        return true;
                    }
                }
            }
        }    
       return false;
    }
}
}