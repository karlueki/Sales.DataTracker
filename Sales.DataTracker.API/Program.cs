using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Sales.DataTracker.API.Interface;
using Sales.DataTracker.API.Services;
using Sales.DataTracker.DataAccess.DB.Repositories;
using Sales.DataTracker.DataCore.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = "ApiKey";
        options.DefaultChallengeScheme = "ApiKey";
    })
    .AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>("ApiKey", null);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiKeyPolicy", policy =>
    {
        policy.AuthenticationSchemes.Add("ApiKey");
        policy.RequireAuthenticatedUser();
    });
});

builder.Services.AddSingleton<ISalesUpload, SalesUpload>();
builder.Services.AddSingleton<ISalesTrackerDBHandler, SalesTrackerDBHandler>();
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
// Add services to the container.
builder.Services.Configure<FormOptions>(options =>
{
    options.MemoryBufferThreshold = Int32.MaxValue;
});
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 5242880000; // Set the limit to 50 MB (52428800 bytes)
});


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
