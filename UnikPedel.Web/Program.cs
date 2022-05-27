using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UnikPedel.Contract.IServiceBooking;
using UnikPedel.Contract.IServiceEjendomAnsvarlig;
using UnikPedel.Contract.IServiceLejer;
using UnikPedel.Contract.IServiceRekvisition;
using UnikPedel.Contract.IServiceTidRegistrering;
using UnikPedel.Contract.IServiceVicev�rt;
using UnikPedel.Infrastructure.Database;
using UnikPedel.Web.Infrastructure;
using UnikPedel.Web.Policies;
using UnikPedel.Web.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection"), x =>
{
    x.MigrationsAssembly("UnikPedel.Web");
}));
builder.Services.AddDefaultIdentity<IdentityUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 4;
}).AddRoles<IdentityRole>()
  .AddEntityFrameworkStores<IdentityDbContext>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(PolicyEnum.AdminOnly, policyBuilder => policyBuilder.RequireClaim(UserClaimTypeEnum.IsAdmin));
});

builder.Services.AddHttpClient<IVicev�rtService, Vicev�rtServiceProxy>
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

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
