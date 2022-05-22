using System.Collections.Generic;
using System.Threading.Tasks;
using AlfaPeople.Models;

namespace AlfaPeople
{
    public interface IReaderXML
    {
        Task<List<Folders>> read(Routes routes, List<Folders> folders);
    }
}