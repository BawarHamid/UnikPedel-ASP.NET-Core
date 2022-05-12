using Microsoft.EntityFrameworkCore;
using UnikPedel.Contract.IServiceRekvisition;
using UnikPedel.Infrastructure.Database;
using UnikPedel.Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddHttpClient<IServiceRekvisition, RekvisitionServiceProxy>
    (client =>
    {
        client.BaseAddress =
            new Uri("https://localhost:7071");
    });

//builder.Services.AddDbContext<UnikPedelContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), x =>
//    {
//        x.MigrationsAssembly("UnikPedel.Infrastructure");
//    }));

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
