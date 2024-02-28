namespace FoodTruckFinderApp.Models
{
    public class FoodTruck
    {
        // int
        public int Id { get; set; }
        public int CNN { get; set; }

        // double
        public double X { get; set; }
        public double Y { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        // bool
        public bool PriorPermit { get; set; }

        // string
        public string? Applicant { get; set; }
        public string? FacilityType { get; set; }
        public string? LocationDescription { get; set; }
        public string? Address { get; set; }
        public string? blocklot { get; set; }
        public string? block { get; set; }
        public string? lot { get; set; }
        public string? permit { get; set; }
        public string? Status { get; set; }
        public string? FoodItems { get; set; }
        public string? Schedule { get; set; }
        public string? dayshours { get; set; }
        public string? NOISent { get; set; }
        public string? Location { get; set; }

        // datetime
        public DateTime Approved { get; set; }
        public DateTime Received { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
