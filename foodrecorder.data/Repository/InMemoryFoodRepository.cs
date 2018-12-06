using System;
using System.Collections.Generic;
using System.Linq;
using FoodRecorder.Common;

namespace FoodRecorder.Data{
    public class InMemoryFoodRepository : IFoodRepository
    {
        FoodDB _db;
        public InMemoryFoodRepository()
        {
            _db = new FoodDB();
        }

        public Guid AddFood(Session sess, Food food)
        {
            List<Food> foods=null;
            ValidateCreatableFood(food);
            if(!_db.UserFoods.ContainsKey(sess.User)){

                foods = new List<Food>();
                _db.UserFoods.Add(sess.User, foods);
            }
            else{
                foods = _db.UserFoods[sess.User];
            }
            food.CreatedOn = DateTime.UtcNow;
            food.ModifiedOn = DateTime.UtcNow;
            food.ID = Guid.NewGuid();
            foods.Add(food);
            return food.ID;
        }

        private void ValidateCreatableFood(Food food)
        {
            if(food == null)throw new Exception("Invalid Food.");
            if(string.IsNullOrWhiteSpace(food.Name)) throw new Exception("Food name is not available.");
        }

        public List<Food> GetAllFoods(Session sess)
        {
            List<Food> result=null;
            if(_db.UserFoods.ContainsKey(sess.User)){
                result = _db.UserFoods[sess.User];
            }
            return result;
        }


        public Session Login(string userName, string password)
        {
            User loggedUser = _db.Users.FirstOrDefault(c=>string.Equals(c.UserName , userName) 
                                    && string.Equals(c.Password, password, StringComparison.InvariantCultureIgnoreCase));
            if(loggedUser == null) throw new Exception("Access Denied.");
            if(IsSessionAvailable(loggedUser)){
                Session newSession = new Session(loggedUser);
                _db.UserSessions.Add(loggedUser.ID, newSession);
                return newSession;
            }
            else{
                throw new Exception("Session not available.");
            }
        }


        public User Register(string firstName, string lastName, string userName, string password, string confirmPassword, string emailId, string secretQuestion, string secretAnswer)
        {
            User user;
            if(!IsAlreadyRegistered(emailId)){
                user = new User(){
                    ID = Guid.NewGuid(),
                    FirstName = firstName,
                    LastName = lastName,
                    UserName = userName,
                    Password = password,
                    EmailID = emailId,
                    SecretQuestion = secretQuestion,
                    SecretAnswer = secretAnswer,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn = DateTime.UtcNow
                };
                _db.Users.Add(user);
                return user;
            }
            throw new Exception($"Unable to register {firstName}, {lastName}");
        }

        private bool IsAlreadyRegistered(string emailId)
        {
            return _db.Users.Any(c=>string.Equals(c.EmailID, emailId, StringComparison.InvariantCultureIgnoreCase));
        }

        private bool IsSessionAvailable(User loggedUser)
        {
            return _db?.UserSessions?.Any(c=>c.Key == loggedUser.ID)==false;
        }
        private Session ValidateToken(Guid token){
            if(_db?.UserSessions?.Any() == false) throw new Exception("Access denied to resource.");
            foreach(var usess in _db.UserSessions){
                if(usess.Value.ID == token) return usess.Value;
            }
            throw new Exception("Access denied to resource.");
        }
    }
}