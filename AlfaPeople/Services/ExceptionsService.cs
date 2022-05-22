using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AlfaPeople
{
    /// <summary>
    /// 
    /// </summary>
    public class ExceptionsService : IExceptionsService
    {
        private readonly ILogger<ExceptionsService> logger;
        public ExceptionsService(ILogger<ExceptionsService> _logger)
        {
            logger = _logger;
        }

        /// <summary>
        /// Si no recibe un Exception muestra el mensaje enviado por parámetro,
        /// si lo recibe muestra el mensaje y la excepción
        /// </summary>
        /// <param name="msj"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public Task LogToLogger(string msj, Exception exception = null)
        {
            try
            {
                if (exception != null)
                {
                    logger.LogError(
                        msj + "--" +
                        exception.ToString());
                }
                else
                {
                    logger.LogInformation(msj);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
            }

            return Task.FromResult(true);
        }
    }
}

