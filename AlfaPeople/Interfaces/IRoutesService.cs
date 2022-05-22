using System.Threading.Tasks;
using AlfaPeople.Models;

namespace AlfaPeople
{
    public interface IRoutesService
    {
        Task<Routes> loadRoutes();
    }
}