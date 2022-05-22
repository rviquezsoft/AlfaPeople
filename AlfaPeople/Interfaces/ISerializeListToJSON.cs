using System.Collections.Generic;
using System.Threading.Tasks;
using AlfaPeople.Models;

namespace AlfaPeople
{
    public interface ISerializeListToJSON
    {
        Task<string> serialize(List<IPedidoBase> pedidos);
    }
}