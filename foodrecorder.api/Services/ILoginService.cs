using System;
using FoodRecorder.Common;

namespace FoodRecorder.API.Services{
public interface ILoginService{
    void AddUserContext(Session uinfo);
    Session ValidateUserContext(Guid token);
    void RemoveUserContext(Session uinfo);
}
}