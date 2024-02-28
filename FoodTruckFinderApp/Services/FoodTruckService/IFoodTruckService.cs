namespace FoodTruckFinderApp.Services.FoodTruckService
{
    public interface IFoodTruckService
    {
        Task<List<FoodTruck>> FindFoodTrucks(double latitude, double longitude, string preferredFood, int amount);

        Task<List<FoodTruck>?> UpdateFoodTruck(int id, FoodTruck foodTruck);
    }
}
