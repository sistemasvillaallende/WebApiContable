using Web_Api_Contable.Entities.FOP;
using Web_Api_Contable.Models;

namespace Web_Api_Contable.Services.FOP
{
    public interface IOrdenesCompraService
    {
        public Ordenes_compra getByPk(int nroOrdenCompra);
    }
}
