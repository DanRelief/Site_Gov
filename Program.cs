namespace MCMV
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Registra a conexão e os serviços para o ASP.NET saber como criá-los
            builder.Services.AddScoped<MCMV.Data.Database>();
            builder.Services.AddScoped<MCMV.Logical.LoginService>();
            builder.Services.AddScoped<MCMV.Logical.RegisterService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Login}/{id?}")
                .WithStaticAssets();

            app.Run();
            app.UseStaticFiles();
        }
    }
}
