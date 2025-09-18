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
using Microsoft.EntityFrameworkCore;
using CovidOData.Models;

namespace CovidOData.Data
{
	public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
	{
		public DbSet<CovidRecord> CovidRecords { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CovidRecord>(entity =>
			{
				entity.ToTable("daily_us_reports");
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Id).HasColumnName("id");
				entity.Property(e => e.Country).HasColumnName("country");
				entity.Property(e => e.Province).HasColumnName("province");
				entity.Property(e => e.Confirmed).HasColumnName("confirmed");
				entity.Property(e => e.Deaths).HasColumnName("deaths");
				entity.Property(e => e.Recovered).HasColumnName("recovered");
				entity.Property(e => e.Active).HasColumnName("active");
				entity.Property(e => e.Date).HasColumnName("date");
			});
		}
	}
}