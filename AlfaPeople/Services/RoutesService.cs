using System;
using System.Threading.Tasks;
using AlfaPeople.Models;
using Microsoft.Extensions.Configuration;

namespace AlfaPeople
{
    public class RoutesService : IRoutesService
    {
        private readonly IExceptionsService logger;
        private readonly IConfiguration configuration;
        public RoutesService(IConfiguration _configuration,
            IExceptionsService _logger)
        {
            logger = _logger;
            configuration = _configuration;
        }
        /// <summary>
        /// Lee las rutas de entrada y salida del archivo appsettings.json
        /// </summary>
        /// <returns></returns>
        public async Task<Routes> loadRoutes()
        {
            Routes routes = null;
            try
            {
                var input = configuration["Routes:Input"];
                var output = configuration["Routes:Output"];
                if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(output))
                {
                    await logger.LogToLogger(this.GetType().Name,
                        new InvalidOperationException("No se encontró" +
                        " la ruta de entrada y/ó salida en el archivo appsetings.json." +
                        "Por favor revise la configuración"));
                    return routes;
                }
                routes = new Routes
                {
                    Input=input,
                    Output=output
                };
            }
            catch (Exception ex)
            {
                await logger.LogToLogger(this.GetType().Name, ex);
            }

            return routes;
        }
    }
}

