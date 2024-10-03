using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Keeps property names as-is
        // Add more options if necessary, like ignoring null values or reference loop handling
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Show detailed error page in development
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Custom error page in production
    app.UseHsts(); // HTTP Strict Transport Security
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
app.UseRouting(); // Enable routing
app.UseAuthorization(); // Enable authorization middleware
app.MapControllers(); // Map attribute-routed controllers

app.Run(); // Start the application
