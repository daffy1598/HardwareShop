using HardwareShopRole.Data;
using HardwareShopRole.Models.Account;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HardwareShopRole
{
    public class HardwareShopRole
    {
        public void ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection services)

        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<HardwareShopUser, HardwareShopRole>(options => options =>
            {
                options.Password.RequiereDigit = false;
                options.Password.ReguiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequieredUniqueChar = 0;
                options.Password.ReguireLowercase = false;
                options.Password.RequireUppercase = false;
                options.SingIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }
    }
}