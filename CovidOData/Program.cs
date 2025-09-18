using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Load data once at startup
var covidData = await CovidDataLoader.LoadDataAsync();
builder.Services.AddSingleton(covidData);

// OData model
var odataBuilder = new ODataConventionModelBuilder();
odataBuilder.EntitySet<CovidRecord>("CovidData").EntityType.HasKey(c => c.Id);

builder.Services.AddControllers().AddOData(opt =>
    opt.Filter().Select().OrderBy().Expand().Count().SetMaxTop(100)
       .AddRouteComponents("odata", odataBuilder.GetEdmModel()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
