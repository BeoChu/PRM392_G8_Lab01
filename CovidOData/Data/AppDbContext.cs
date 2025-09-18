//using CovidOData.Models;
//using Microsoft.EntityFrameworkCore;

//public class AppDbContext : DbContext
//{
//    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

//    public DbSet<CovidData> CovidData { get; set; }
//    public DbSet<CovidData> CovidRecords { get; set; }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<CovidData>().ToTable("covid_data"); // match Supabase table name
//    }
//}
