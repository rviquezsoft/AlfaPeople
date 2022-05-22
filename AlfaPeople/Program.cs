using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AlfaPeople.Models;
using AlfaPeople.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AlfaPeople
{
    class Program
    {

        public static async Task Main(string[] args)
        {
            string line = "=====================================================================================";
            Console.ForegroundColor = ConsoleColor.Blue;
            var host = await init();
            var reader = host.Services.GetRequiredService<IReaderXML>();
            var deserealizer = host.Services.GetRequiredService<IDeserealizeXMLService>();
            var serializer = host.Services.GetRequiredService<ISerializeListToJSON>();
            var routes = host.Services.GetRequiredService<IRoutesService>();
            var folders = host.Services.GetRequiredService<IFoldersService>();
            var writer = host.Services.GetRequiredService<IWriteJSONService>();

            var route=await routes.loadRoutes();
            var folderList =await folders.loadFolders();
            if (route==null||folderList==null)
            {
                Environment.Exit(0);
            }
            var directories =await reader.read(route,folderList);
            if (directories == null)
            {
                Environment.Exit(0);
            }
            List<IPedidoBase> list =await deserealizer.deserealize(directories);
            if (list==null)
            {
                Environment.Exit(0);
            }
            var payload =await serializer.serialize(list);

            if (string.IsNullOrWhiteSpace(payload))
            {
                Environment.Exit(0);
            }
            Console.WriteLine(line);
            Console.WriteLine("A continuación se mostrará la lista de Pedidos " +
                "como un " +
                "archivo JSON y posteriormente se guardará el archivo " +
                "en la carpeta de " +
                "salida configurada en el appsettings.json (Output)\n");
            Console.WriteLine(line);
            Console.WriteLine(payload);
            Console.WriteLine(line);
            var saved =await writer.write(route,payload);
            Console.WriteLine(line);
            Console.WriteLine(saved);
            Console.WriteLine(line);
        }

        /// <summary>
        /// Necesario para poder hacer uso del appsettings.json y las inyecciones de
        /// dependencias 
        /// </summary>
        /// <returns></returns>
        static Task<IHost> init()
        {
            IHost host = null;
            try
            {
                string internalRoute =
                        Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);


                var builder = new HostBuilder()
                    .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        config.SetBasePath(internalRoute);
                        config.AddJsonFile("appsettings.json")
                        .AddEnvironmentVariables();
                    })
                    .ConfigureServices((hostingContext, services) =>
                    {
                        services.AddTransient<IReaderXML, ReaderXML>();
                        services.AddTransient<IExceptionsService, ExceptionsService>();
                        services.AddTransient<IDeserealizeXMLService, DeserealizeXMLService>();
                        services.AddTransient<ISerializeListToJSON,SerializeListToJSON>();
                        services.AddSingleton<IRoutesService, RoutesService>();
                        services.AddSingleton<IFoldersService,FoldersService>();
                        services.AddTransient<IWriteJSONService,WriteJSONService>();
                    })
                    .ConfigureLogging((hostingContext, logging) =>
                    {
                        
                        logging.AddConfiguration(hostingContext.Configuration);
                        logging.AddConsole();
                    });

                host = builder.Build();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return Task.FromResult(host);
        }
    }


}

