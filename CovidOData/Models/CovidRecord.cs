public class CovidRecord
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string Province { get; set; }
    public int Confirmed { get; set; }
    public int Deaths { get; set; }
    public int Recovered { get; set; }
    public int Active { get; set; }
    public DateTime Date { get; set; }
}
