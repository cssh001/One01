using ONE01.Context;
using ONE01.Repositories;
using ONE01.Repositories.Interfaces;
using ONE01.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DapperContext>();

// Service repository
builder.Services.AddCustomRepositories();
//builder.AddScoped<ITestRepository, TestRepository>();

// This is checking for return json data with PascalCase
/*builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // This line ensures that the existing JSON serialization options are not applied
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
    }); */
builder.Services.ConfigureJsonOptions();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// This for allow to call api
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
