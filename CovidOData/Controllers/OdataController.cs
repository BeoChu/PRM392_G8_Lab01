using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;

public class CovidDataController : ODataController
{
    private readonly List<CovidRecord> _data;

    public CovidDataController(List<CovidRecord> data)
    {
        _data = data;
    }

    [EnableQuery]
    public IQueryable<CovidRecord> Get()
    {
        return _data.AsQueryable();
    }
}
