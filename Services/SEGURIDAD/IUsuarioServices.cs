using Web_Api_Contable.Entities.SEGURIDAD;

namespace Web_Api_Contable.Services.SEGURIDAD
{
    public interface IUsuarioServices
    {
        public Task<Usuario> ReadUser(string user);
        public Task<bool> ValidaUsuario(string user, string password);
        public Task<bool> ValidaPermiso(string user, string proceso);
    }

}
