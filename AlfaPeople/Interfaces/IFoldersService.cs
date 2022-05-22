using System.Collections.Generic;
using System.Threading.Tasks;
using AlfaPeople.Models;

namespace AlfaPeople
{
    public interface IFoldersService
    {
        Task<List<Folders>> loadFolders();
    }
}