using Hospital.Data;
using Hospital.Models;

namespace Hospital
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

            AplicationDbContext DbContext = new AplicationDbContext();
            List<Doctor> doctors = new List<Doctor>();
            doctors.Add(new Doctor { Name = "Dr. John Smith", Specialization = "Cardiology", Img = "doctor1.jpg" });
            doctors.Add(new Doctor { Name = "Dr. Sarah Johnson", Specialization = "Pediatrics", Img = "doctor2.jpg" });
            doctors.Add(new Doctor { Name = "Dr. Emily Davis", Specialization = "Dermatology", Img = "doctor3.jpg" });
            doctors.Add(new Doctor { Name = "Dr. Michael Lee", Specialization = "Orthopedics", Img = "doctor4.jpg" });
            doctors.Add(new Doctor { Name = "Dr. William Clark", Specialization = "Neurology", Img = "doctor5.jpg" });

            DbContext.Doctors.AddRange(doctors);
            DbContext.SaveChanges();
        }
    }
}
