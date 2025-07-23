using Web_Api_Contable.Entities.FOP;

namespace Web_Api_Contable.Services.FOP
{
    public class DireccionesServices: IDireccionService
    {
        public List<Direcciones> getListDirecciones(int id_secretaria)
        {
            try
            {
                return Direcciones.getListDirecciones(id_secretaria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Direcciones> getDireccionesByNombre(int ejercicio, string nombre)
        {
            try
            {
                return Direcciones.getDireccionesByNombre(ejercicio,nombre);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
     
}
