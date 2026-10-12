
var builder = WebApplication.CreateBuilder(args);

// 1. Register services
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Configure CORS before builder.Build()
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy.WithOrigins("https://campuseats-web-eight.vercel.app")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// 3. Build the application
var app = builder.Build();

// 4. Enable Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 5. Configure HTTP middleware
// HTTPS is handled by Render's reverse proxy.
if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

// Enable CORS before authorization and controllers
app.UseCors("Frontend");

app.UseAuthorization();

// 6. Map API controllers
app.MapControllers();

// 7. Start the application
app.Run();
