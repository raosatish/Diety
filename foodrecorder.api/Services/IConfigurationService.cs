namespace FoodRecorder.API.Services{
public interface IConfigurationService{
    string GetDBConnectionString();
    int GetTimeoutInMinutes();
}
}