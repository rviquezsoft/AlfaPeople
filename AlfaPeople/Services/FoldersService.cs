using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlfaPeople.Models;
using Microsoft.Extensions.Configuration;

namespace AlfaPeople
{
    public class FoldersService : IFoldersService
    {
        private readonly IExceptionsService logger;
        private readonly IConfiguration configuration;
        public FoldersService(IConfiguration _configuration,
            IExceptionsService _logger)
        {
            logger = _logger;
            configuration = _configuration;
        }
        /// <summary>
        /// Carga el mapeo de folders del archivo appsettings.json y lo
        /// devuelve como una lista
        /// </summary>
        /// <returns></returns>
        public async Task<List<Folders>> loadFolders()
        {
            List<Folders> folders = null;
            try
            {
                Folders[] filesFromJSON = configuration.GetSection("Folders").
                     Get<Folders[]>();
                if (filesFromJSON == null || filesFromJSON.Length < 1)
                {
                    await logger.LogToLogger(this.GetType().Name,
                        new InvalidOperationException("No se encontró" +
                        " la lista de carpetas que se deben procesar (Folders)" +
                        "en el archivo appsetings.json." +
                        "Por favor revise la configuración"));
                    return folders;
                }

                folders = filesFromJSON.ToList();
            }
            catch (Exception ex)
            {
                await logger.LogToLogger(this.GetType().Name, ex);
            }

            return folders;
        }
    }
}

