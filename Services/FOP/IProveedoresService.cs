using Web_Api_Contable.Entities.FOP;

namespace Web_Api_Contable.Services.FOP

{
    public interface IProveedoresService
    {
        public List<Proveedores> read();
        public Proveedores getByPk(int cod_proveedor);
        public int insert(Proveedores obj);
        public void update(Proveedores obj);
        public void delete(Proveedores obj);
    }
}

