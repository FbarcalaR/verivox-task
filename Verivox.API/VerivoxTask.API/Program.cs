using Carter;
using VerivoxTask.Application;
using VerivoxTask.ExternalTariffProvider;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExternalTariffProvider();
builder.Services.AddApplicationLayer();

builder.Services.AddCors(options =>
{
       options.AddDefaultPolicy(policy =>
       {
              policy
                     .AllowAnyOrigin()
                     .AllowAnyHeader()
                     .AllowAnyMethod();
       });
});

builder.Services
       .AddCarter()
       .AddEndpointsApiExplorer();

builder.Services.AddOpenApiDocument(settings => { settings.Title = "Verivox Task"; });

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUi();

app.MapCarter();
app.UseCors();

app.Run();
