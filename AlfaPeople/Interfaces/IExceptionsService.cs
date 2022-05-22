using System;
using System.Threading.Tasks;

namespace AlfaPeople
{
    public interface IExceptionsService
    {
        Task LogToLogger(string msj, Exception exception = null);
    }
}