using CovidOData.Data;
using CovidOData.Models;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

public static class CovidDataLoader
{
    public static async Task<List<CovidRecord>> LoadDataAsync(AppDbContext db)
    {
		//var confirmedUrl = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";
		//var deathsUrl = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_deaths_global.csv";
		//var recoveredUrl = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_recovered_global.csv";

		//using var http = new HttpClient();

		//var confirmedCsv = await http.GetStringAsync(confirmedUrl);
		//var deathsCsv = await http.GetStringAsync(deathsUrl);
		//var recoveredCsv = await http.GetStringAsync(recoveredUrl);

		//// Simplified parser: pick the last column (latest date)
		//var confirmedLines = confirmedCsv.Split('\n').Skip(1).Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
		//var deathsLines = deathsCsv.Split('\n').Skip(1).Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
		//var recoveredLines = recoveredCsv.Split('\n').Skip(1).Where(l => !string.IsNullOrWhiteSpace(l)).ToList();

		//var records = new List<CovidRecord>();

		//for (int i = 0; i < confirmedLines.Count; i++)
		//{
		//    var c = confirmedLines[i].Split(',');
		//    var d = deathsLines[i].Split(',');

		//    string[] r = Array.Empty<string>();
		//    if (i < recoveredLines.Count)
		//        r = recoveredLines[i].Split(',');

		//    var latestConfirmed = int.Parse(c.Last());
		//    var latestDeaths = int.Parse(d.Last());
		//    var latestRecovered = (r.Length > 0) ? int.Parse(r.Last()) : 0;

		//    var header = confirmedCsv.Split('\n')[0].Split(',');
		//    var latestDateStr = header.Last();
		//    var latestDate = DateTime.Parse(latestDateStr, CultureInfo.InvariantCulture);

		//    records.Add(new CovidRecord
		//    {
		//        Country = c[1],
		//        Province = c[0],
		//        Confirmed = latestConfirmed,
		//        Deaths = latestDeaths,
		//        Recovered = latestRecovered,
		//        Active = latestConfirmed - latestDeaths - latestRecovered,
		//        Date = latestDate
		//    });
		//}

		//return records;

		return await db.CovidRecords
			   .OrderByDescending(r => r.Date) 
			   .ToListAsync();
	}
}
