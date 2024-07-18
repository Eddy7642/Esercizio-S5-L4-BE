using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GestioneSpedizioni.Data;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Questo metodo viene chiamato dal runtime. Usa questo metodo per aggiungere servizi al contenitore.
    public void ConfigureServices(IServiceCollection services)
    {
        // Configura il DbContext per l'utilizzo di SQL Server
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // Configura Identity
        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();

        // Aggiungi servizi per controller e viste
        services.AddControllersWithViews();

        // Aggiungi supporto per Razor Pages
        services.AddRazorPages();
    }

    // Questo metodo viene chiamato dal runtime. Usa questo metodo per configurare la pipeline delle richieste HTTP.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
        }
        else
        {
