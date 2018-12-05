using System;
using System.Collections.Generic;
using FoodRecorder.Common;

namespace FoodRecorder.Data{
    public class FoodDB{
        public List<User> Users;
        public Dictionary<Guid, Session> UserSessions;
        public Dictionary<Guid, List<Food>> UserFoods;
        public Dictionary<Guid, List<Eaten>> UserEatenFoods;

        public FoodDB()
        {
            Users = new List<User>();
            UserEatenFoods = new Dictionary<Guid, List<Eaten>>();
            UserFoods = new Dictionary<Guid, List<Food>>();
            UserSessions = new Dictionary<Guid, Session>();
        }
    }
}
