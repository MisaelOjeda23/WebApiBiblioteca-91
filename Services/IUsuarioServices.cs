using Domain.DTO;
using Domain.Entities;

namespace WebApi91.Services
{
    public interface IUsuarioServices
    {
        public Task<Response<List<Usuario>>> ObtenerUsuarios();
        public Task<Response<Usuario>> ObtenerUsuario(int id);
        public Task<Response<Usuario>> CrearUsuario(UsuarioDto request);
        public Task<Response<Usuario>> ActualizarUsuario(int id, UsuarioDto usuario);
        public Task<Response<Usuario>> BorrarUsuario(int id);
    }
}
