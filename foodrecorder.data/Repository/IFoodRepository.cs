using System;
using System.Collections.Generic;
using System.Security;
using FoodRecorder.Common;

namespace FoodRecorder.Data{
    public interface IFoodRepository{
        
    Session Login(string userName, string password);
    User Register(string firstName, string lastName, string userName, string password, string confirmPassword,
                    string emailId, string secretQuestion, string secretAnswer);
    List<Food> GetAllFoods(Guid token);
    Guid AddFood(Guid token, Food food);
    }
}