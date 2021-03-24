using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Rohham.Data.Context;
using Rohham.Data.Repository;
using Rohham.Web.Site.Models.Component;

namespace Rohham.Web.Site
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")
                                .Replace("|DataDirectory|", Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "app_data")),
                    serverDbContextOptionsBuilder =>
                    {
                        var minutes = (int)TimeSpan.FromMinutes(3).TotalSeconds;
                        serverDbContextOptionsBuilder.CommandTimeout(minutes);
                        serverDbContextOptionsBuilder.EnableRetryOnFailure();
                    });
            });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region Navbar
            List<NavbarItemVM> navbarItems = new List<NavbarItemVM>();
            NavbarItemVM navbarItem_HomePage = new NavbarItemVM { Id = 1, Active = true, Name = "صفحه اصلی", Link = "#" };
            List<NavbarItemVM> navbarItems1 = new List<NavbarItemVM>();

            NavbarItemVM navbarItem_AboutPage = new NavbarItemVM { Id = 10, Active = true, Name = "درباره ما", Link = "#" };
            List<NavbarItemVM> navbarItems2 = new List<NavbarItemVM>();

            navbarItems1.Add(new NavbarItemVM { Id = 2, Active = true, Name = "صفحه اصلی1", Link = "#", ParentId = 1 });
            navbarItems1.Add(new NavbarItemVM { Id = 3, Active = true, Name = "صفحه اصلی2", Link = "#", ParentId = 1 });
            navbarItems1.Add(new NavbarItemVM { Id = 4, Active = true, Name = "3صفحه اصلی", Link = "#", ParentId = 1 });
            navbarItems1.Add(new NavbarItemVM { Id = 5, Active = true, Name = "4صفحه اصلی", Link = "#", ParentId = 1 });
            navbarItem_HomePage.Childs = navbarItems1;

            navbarItems2.Add(new NavbarItemVM { Id = 11, Active = true, Name = "درباره ما 1", Link = "#", ParentId = 10 });
            navbarItems2.Add(new NavbarItemVM { Id = 12, Active = true, Name = "درباره ما 2", Link = "#", ParentId = 10 });
            navbarItems2.Add(new NavbarItemVM { Id = 13, Active = true, Name = "درباره ما 3", Link = "#", ParentId = 10 });
            navbarItems2.Add(new NavbarItemVM { Id = 14, Active = true, Name = "درباره ما 4", Link = "#", ParentId = 10 });
            navbarItem_AboutPage.Childs = navbarItems2;

            navbarItems.Add(navbarItem_HomePage);
            navbarItems.Add(navbarItem_AboutPage);

            NavbarVM.NavbarItems = navbarItems;
            NavbarVM.Icon = "/img/white-logo.png";
            #endregion

            #region Footer
            List<FooterColumnVM> columns = new List<FooterColumnVM>();
            columns.Add(new FooterColumnVM
            {
                Id = 101,
                Title = "خدمات",
                Link = new Dictionary<string, string>
                {
                    {"اطلاعات بزرگ", "#" },
                    {"طراحی رابط کاربری", "#" },
                    {"برنامه کامپیوتر", "#" },
                    {"برنامه موبایل", "#" },
                    {"محصول مهندسی", "#" },
                    {"یادگیری ماشین", "#" }
                }
            });
            columns.Add(new FooterColumnVM
            {
                Id = 102,
                Title = "لینکهای مفید",
                Link = new Dictionary<string, string>
                {
                    {"موتور جستجوگر", "#" },
                    {"پشتیبانی زنده", "#" },
                    {"توسعه دهنده", "#" },
                    {"پرداخت کلیکی", "#" },
                    {"پشتیبانی", "#" },
                    {"برنامه", "#" }
                }
            });
            FooterVM.FooterColumns = columns;
            FooterVM.Address = "ایران ، استان تهران ، میدان دارآباد";
            FooterVM.Email = "hello@Rohham.com";
            FooterVM.FB = "#";
            FooterVM.Linkedin = "#";
            FooterVM.PN = "#";
            FooterVM.TW = "#";
            FooterVM.Youtube = "#";
            FooterVM.FooterIconUrl = "/img/white-logo.png";
            FooterVM.PrivacyPolicy = "#";
            FooterVM.Tel = new List<string>();
            FooterVM.Tel.Add("021-66643284");
            FooterVM.ShortDescription = "فرهیختگان هوشمند به سادگی ساختار چاپ و متن را در بر می گیرد. لورم ایپسوم به مدت 40 سال استاندارد صنعت بوده است. لورم ایپسوم به سادگی ساختار چاپ و متن را در بر می گیرد. لورم ایپسوم به مدت 40 سال استاندارد صنعت بوده است.";
            FooterVM.TermsConditions = "Link";
            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
