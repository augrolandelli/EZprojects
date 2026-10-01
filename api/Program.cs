using api.Common;
using api.Data;
using api.Data.Interceptors;
using api.Tenancy;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddSerilog((services, lc) => lc
    .ReadFrom.Configuration(builder.Configuration)
    .ReadFrom.Services(services)
);

builder.Services.AddDbContext<AppDbContext>((sp, options) =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
        .AddInterceptors(sp.GetRequiredService<FechasInterceptor>())
        .AddInterceptors(sp.GetRequiredService<EspacioInterceptor>())
    );

builder.Services.AddScoped<ITenancyContext, TenancyContext>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddHealthChecks();

builder.Services.AddScoped<FechasInterceptor>();
builder.Services.AddScoped<EspacioInterceptor>();

var app = builder.Build();

app.UseSerilogRequestLogging();
app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();
