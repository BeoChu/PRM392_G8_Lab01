//using CovidOData.Models;
//using Microsoft.AspNetCore.OData;
//using Microsoft.OData.ModelBuilder;

//var builder = WebApplication.CreateBuilder(args);

//// Load data once at startup
//var covidData = await CovidDataLoader.LoadDataAsync();
//builder.Services.AddSingleton(covidData);

//// OData model
//var odataBuilder = new ODataConventionModelBuilder();
//odataBuilder.EntitySet<CovidRecord>("CovidData").EntityType.HasKey(c => c.Id);

//builder.Services.AddControllers().AddOData(opt =>
//    opt.Filter().Select().OrderBy().Expand().Count().SetMaxTop(100)
//       .AddRouteComponents("odata", odataBuilder.GetEdmModel()));

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//app.UseSwagger();
//app.UseSwaggerUI();

//app.MapControllers();
//app.Run();

// Program.cs
using CovidOData.Data;
using CovidOData.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

var connStr = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure the DbContext for PostgreSQL
builder.Services.AddDbContext<AppDbContext>(opt =>
	opt.UseNpgsql(connStr, o => o.CommandTimeout(180))
);

// Build the OData model
var odataBuilder = new ODataConventionModelBuilder();
odataBuilder.EntitySet<CovidRecord>("CovidRecord");

// Add OData services and enable query options
builder.Services.AddControllers().AddOData(opt =>
	opt.Filter().Select().OrderBy().Expand().Count().SetMaxTop(1000)
	   .AddRouteComponents("odata", odataBuilder.GetEdmModel()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Define CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseCors("AllowAngularDev");

// This maps the OData controller routes
app.MapControllers();

app.Run();