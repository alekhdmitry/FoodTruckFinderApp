using FoodTruckFinderApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FoodTruckFinderApp.Services.FoodTruckService
{
    public class FoodTruckService : IFoodTruckService
    {
        private readonly DataContext _context;

        public FoodTruckService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<FoodTruck>> FindFoodTrucks(double latitude, double longitude, string preferredFood, int amount)
        {
            // Get all food trucks from the repository or database
            var allFoodTrucks = await _context.FoodTrucks.ToListAsync();

            // Calculate distances and filter by location
            var nearbyFoodTrucks = allFoodTrucks
                .Select(foodTruck => new
                {
                    FoodTruck = foodTruck,
                    Distance = CalculateDistance(latitude, longitude, foodTruck.Latitude, foodTruck.Longitude)
                })
                .Where(ft => ft.Distance <= 100) // Limited area for 100 km
                .OrderBy(ft => ft.Distance)
                .Select(ft => ft.FoodTruck)
                .ToList();

            // Filter by facility type
            if (!string.IsNullOrEmpty(preferredFood))
            {
                nearbyFoodTrucks = nearbyFoodTrucks.Where(ft => ft.FacilityType.Equals("Truck")).ToList();
            }

            // Filter by preferred food
            if (!string.IsNullOrEmpty(preferredFood))
            {
                nearbyFoodTrucks = nearbyFoodTrucks.Where(ft => ft.FoodItems.Contains(preferredFood, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Return specified amount of results
            return nearbyFoodTrucks.Take(amount).ToList();
            // return allFoodTrucks;
        }

        private const double EarthRadiusKm = 6371.0; // Earth radius in kilometers

        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            // Convert latitude and longitude from degrees to radians
            double dLat = ConvertToRadians(lat2 - lat1);
            double dLon = ConvertToRadians(lon2 - lon1);

            // Convert latitude and longitude to radians
            lat1 = ConvertToRadians(lat1);
            lat2 = ConvertToRadians(lat2);

            // Apply Haversine formula
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = EarthRadiusKm * c;

            return distance;
        }

        private double ConvertToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public async Task<List<FoodTruck>?> UpdateFoodTruck(int id, FoodTruck request)
        {
            var foodTruck = await _context.FoodTrucks.FindAsync(id);
            if (foodTruck is null)
                return null;

            foodTruck.Applicant = request.Applicant;
            foodTruck.FacilityType = request.FacilityType;
            foodTruck.CNN = request.CNN;
            foodTruck.LocationDescription = request.LocationDescription;
            foodTruck.Address = request.Address;
            foodTruck.blocklot = request.blocklot;
            foodTruck.block = request.block;
            foodTruck.lot = request.lot;
            foodTruck.permit = request.permit;
            foodTruck.Status = request.Status;
            foodTruck.FoodItems = request.FoodItems;
            foodTruck.X = request.X;
            foodTruck.Y = request.Y;
            foodTruck.Latitude = request.Latitude;
            foodTruck.Longitude = request.Longitude;
            foodTruck.Schedule = request.Schedule;
            foodTruck.dayshours = request.dayshours;
            foodTruck.NOISent = request.NOISent;
            foodTruck.Approved = request.Approved;
            foodTruck.Received = request.Received;
            foodTruck.PriorPermit = request.PriorPermit;
            foodTruck.ExpirationDate = request.ExpirationDate;
            foodTruck.Location = request.Location;

            await _context.SaveChangesAsync();

            return await _context.FoodTrucks.ToListAsync();
        }
    }
}
