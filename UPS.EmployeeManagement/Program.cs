using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UPS.EmployeeManagement.Command;
using UPS.EmployeeManagement.Logging;
using UPS.EmployeeManagement.Query;
using static System.Net.WebRequestMethods;

namespace UPS.EmployeeManagement
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var baseUrl = configuration["AppSettings:BaseUrl"];
            var token = configuration["AppSettings:Token"];

            var serviceProvider = new ServiceCollection()
                .AddTransient<ILogger, ConsoleLogger>()
                .AddTransient<IEmployeeCommand>(_ => new EmployeeCommandService(baseUrl!, token!))
                .AddTransient<IEmployeeQuery>(_ => new EmployeeQueryService(baseUrl!, token!))
                .BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            Application.Run(new Form1(serviceProvider.GetService<IEmployeeCommand>()!,
                serviceProvider.GetService<IEmployeeQuery>()!));

        }
    }
}