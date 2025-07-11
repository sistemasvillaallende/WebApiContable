using Web_Api_Contable.Entities.FOP;

namespace Web_Api_Contable.Services.FOP

{
    public class ProveedoresService : IProveedoresService
    {
        public Proveedores getByPk(int cod_proveedor)
        {
            try
            {
                return Proveedores.getByPk(cod_proveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Proveedores> read()
        {
            try
            {
                return Proveedores.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Proveedores obj)
        {
            try
            {
                return Proveedores.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Proveedores obj)
        {
            try
            {
                Proveedores.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Proveedores obj)
        {
            try
            {
                Proveedores.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

