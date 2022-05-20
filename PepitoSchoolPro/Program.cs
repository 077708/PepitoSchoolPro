using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PepitoSchoolPro.AppCore.Contracts;
using PepitoSchoolPro.AppCore.Services;
using PepitoSchoolPro.DataAccess.Repository;
using PepitoSchoolPro.Domain.Contracts;
using PepitoSchoolPro.Domain.PepitoContext;
using PepitoSchoolPro.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PepitoSchoolPro
{
    internal static class Program
    {
        public static IConfiguration? Configuration; 
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables().Build();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            services.AddDbContext<PepitoSchoolContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            services.AddScoped<IPepitoSchoolContext, PepitoSchoolContext>();
            services.AddScoped<IEstudianteRepository, PepitoSchoolRepository>();
            services.AddScoped<IEstudianteServices, EstudianteServices>();

            services.AddScoped<FrmStudents>();

            using (var serivceScope = services.BuildServiceProvider())
            {
                var main = serivceScope.GetRequiredService<FrmStudents>();
                Application.Run(main);
            }
        }
    }
}
