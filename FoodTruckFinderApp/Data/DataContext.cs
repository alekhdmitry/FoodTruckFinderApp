namespace FoodTruckFinderApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\;Database=foodTruckDb;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<FoodTruck> FoodTrucks { get; set; }
    }
}
