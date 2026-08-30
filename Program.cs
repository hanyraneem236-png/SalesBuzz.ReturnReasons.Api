using SalesBuzz.ReturnReasons.Api.Data;
using SalesBuzz.Shared.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMemoryCache();

builder.Services.AddSalesBuzzCurrentBU();

builder.Services.AddSalesBuzzDb<ReturnReasonsDbContext>(
    builder.Configuration
);

// Allow the Angular development server to call this API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularApp", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AngularApp");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();