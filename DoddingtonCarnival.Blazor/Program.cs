using DoddingtonCarnival.Blazor.Services;
using Syncfusion.Blazor;

namespace DoddingtonCarnival.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddSingleton<CalendarService>();
            builder.Services.AddSingleton<LocationsService>();
            builder.Services.AddSingleton<ScarecrowsService>();
            builder.Services.AddSingleton<FloatsService>();
            builder.Services.AddSingleton<PrinceAndPrincessService>();
            builder.Services.AddSingleton<FancyDressService>();

            builder.Services.AddSyncfusionBlazor();

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

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}