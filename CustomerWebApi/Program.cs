using Microsoft.AspNetCore.HttpLogging; // To use HttpLoggingFields.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// when not using controllers 
// builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// GET https://localhost:7137/openapi/v2.json
builder.Services.AddOpenApi(documentName: "v2");

builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.All;
    options.RequestBodyLogLimit = 4096; // Default is 32k.
    options.ResponseBodyLogLimit = 4096; // Default is 32k.
});


// --------------------------------------------------------------------------------------------------------------
WebApplication app = builder.Build();
// --------------------------------------------------------------------------------------------------------------

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// app.UseAuthorization();

// add controllers as endpoints
app.MapControllers();


// Apps_and_Services_with_NET_7.pdf  has more information about the verbs, Results, parameter mapping that can be used

// add endpoint by hand
app.MapGet("/hello", () => "Hello World");

// an alternative way to map endpoints
app.MapGet("/weatherforecast/{days:int?}",
  (int days = 5) => GetWeather(days))
  .WithName("GetWeatherForecast");

// an alternative way to map endpoints
app.MapCustomers();


// --------------------------------------------------------------------------------------------------------------
app.Run();