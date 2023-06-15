using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using ToyRobotSimulation.BusinessLogics;
using ToyRobotSimulation.Interfaces;
using ToyRobotSimulation.Models.Constants;
using ToyRobotSimulation.Models.Enums;
using ToyRobotSimulation.Models.Models;

namespace ToyRobotSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    IConfigurationRoot config = new ConfigurationBuilder()
                    .SetBasePath(context.HostingEnvironment.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                    var tableTopSettings = config.GetSection("TableTopSettings").Get<TableTop>();

                    services.AddSingleton(tableTopSettings);

                    services.AddTransient<IManager, Manager>();
                })
                .Build();

            var svc = ActivatorUtilities.CreateInstance<Manager>(host.Services);
            svc.Run();
        }
    }
}