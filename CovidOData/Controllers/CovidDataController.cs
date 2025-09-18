using CovidOData.Data;
using CovidOData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CovidDataController : ControllerBase
{
	//private readonly List<CovidRecord> _data;

	//public CovidDataController(List<CovidRecord> data)
	//{
	//    _data = data;
	//}

	//[EnableQuery]
	//public IQueryable<CovidRecord> Get()
	//{
	//    return _data.AsQueryable();
	//}
	private readonly AppDbContext _context;

	public CovidDataController(AppDbContext context)
	{
		_context = context;
	}

	[HttpGet]
	[EnableQuery]
	public async Task<IActionResult> Get()
	{
		var list = await _context.CovidRecords.ToListAsync();
		return Ok(list);
	}
}
