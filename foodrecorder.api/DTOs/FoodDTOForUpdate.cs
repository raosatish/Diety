namespace FoodRecorder.API.DTOs{
    public class FoodDTOForUpdate{
        public string Name { get; set; }
        public Serving Serving {get; set;}
        public int CaloriesPerServing {get; set;}
    
    }
}