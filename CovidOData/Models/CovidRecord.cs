using Supabase.Postgrest.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CovidOData.Models
{
	[Table("daily_us_reports")]
	public class CovidRecord
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }
		[Column("country")]
		public string Country { get; set; } = string.Empty;
		[Column("province")]
		public string Province { get; set; } = string.Empty;
		[Column("confirmed")]
		public double Confirmed { get; set; }
		[Column("deaths")]
		public double Deaths { get; set; }
		[Column("recovered")]
		public double? Recovered { get; set; }
		[Column("active")]
		public double? Active { get; set; }
		[Column("date")]
		public DateTime Date { get; set; }
	}
}