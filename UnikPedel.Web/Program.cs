using Microsoft.EntityFrameworkCore;
using UnikPedel.Contract.IServiceBooking;
using UnikPedel.Contract.IServiceEjendomAnsvarlig;
using UnikPedel.Contract.IServiceLejer;
using UnikPedel.Contract.IServiceRekvisition;
using UnikPedel.Contract.IServiceTidRegistrering;
using UnikPedel.Contract.IServiceVicevært;
using UnikPedel.Infrastructure.Database;
using UnikPedel.Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddHttpClient<IViceværtService, ViceværtServiceProxy>
    (client =>
    {
        client.BaseAddress =
            new Uri("https://localhost:7094");
    });

builder.Services.AddHttpClient<IServiceRekvisition, RekvisitionServiceProxy>
    (client =>
    {
        client.BaseAddress =
            new Uri("https://localhost:7094");
    });

builder.Services.AddHttpClient<IServiceTidRegistrering, TidRegistreringServiceProxy>
    (client =>
    {
        client.BaseAddress =
            new Uri("https://localhost:7094");
    });
builder.Services.AddHttpClient<IServiceEjendomAnsvarlig, EjendomAnsvarligServiceProxy>
    (client =>
    {
        client.BaseAddress =
            new Uri("https://localhost:7094");
    });
builder.Services.AddHttpClient<IServiceBooking, BookingServiceProxy>
    (client =>
    {
        client.BaseAddress =
            new Uri("https://localhost:7094");
    });
//builder.Services.AddHttpClient<ILejerService, LejerServiceProxy>
//    (client =>
//    {
//        client.BaseAddress =
//            new Uri("https://localhost:7094");
//    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
