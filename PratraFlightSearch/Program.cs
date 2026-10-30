using Microsoft.EntityFrameworkCore;
using PratraFlightSearch.Data;
using PratraFlightSearch.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FlightDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("FlightConnection")));
// Add services to the container.
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Global exception handling
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exceptionFeature =
            context.Features.Get<IExceptionHandlerFeature>();

        if (exceptionFeature?.Error != null)
        {
            app.Logger.LogError(
                exceptionFeature.Error,
                "An unexpected error occurred.");
        }

        context.Response.StatusCode = 500;

        var problemDetails = new ProblemDetails
        {
            Status = 500,
            Title = "Internal Server Error",
            Detail = "An unexpected error occurred. Please try again later.",
            Instance = context.Request.Path
        };

        problemDetails.Extensions["traceId"] =
            context.TraceIdentifier;

        await context.Response.WriteAsJsonAsync(problemDetails);
    });
});
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
