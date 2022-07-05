using EFCore_DBLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCore_Activity0201
{
    class Program
    {
        private static IConfigurationRoot _configuration;
        private static DbContextOptionsBuilder<CmdAPIContext> _optionsBuilder;

        static void Main(string[] args)
        {
            BuildConfiguration();
            BuildOptions();
            ListCommands();
        }

        static void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }

        static void BuildOptions()
        {
            _optionsBuilder = new DbContextOptionsBuilder<CmdAPIContext>();
            _optionsBuilder.UseNpgsql(_configuration.GetConnectionString("CommandsConnection"));
        }

        static void ListCommands()
        {
            using (var db = new CmdAPIContext(_optionsBuilder.Options))
            {
                var commands = db.Commands.OrderByDescending(x => x.HowTo).Take(20).ToList();
                foreach (var command in commands)
                {
                    Console.WriteLine($"{command.HowTo} {command.Platform}");
                }
            }
        }
    }
}