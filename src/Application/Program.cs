using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddSingleton<IDoctorRepository, DoctorRepository>();
// builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();

builder.Services.AddScoped<IDoctorService, DoctorService>();

// Add services to the container.
builder.Services.AddMvc(options =>
{
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapGet("/pesho", () =>
{
    return Results.Ok("Pesho's endpoint");
});

app.MapControllers();

app.Run();