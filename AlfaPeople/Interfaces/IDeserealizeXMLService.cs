using System.Collections.Generic;
using System.Threading.Tasks;
using AlfaPeople.Models;

namespace AlfaPeople
{
    public interface IDeserealizeXMLService
    {
        Task<List<IPedidoBase>> deserealize(List<Folders> folders);
    }
}