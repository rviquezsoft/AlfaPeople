using System.Threading.Tasks;
using AlfaPeople.Models;

namespace AlfaPeople.Services
{
    public interface IWriteJSONService
    {
        Task<string> write(Routes route, string payload);
    }
}