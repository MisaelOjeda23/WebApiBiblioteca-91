using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi91.Context;

namespace WebApi91.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDbContext _context;
        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;

        }

        //Lista de usuarios
        public async Task<Response<List<Usuario>>> ObtenerUsuarios()
        {
            try
            {
                List<Usuario> response = await _context.Usuarios.Include(x => x.Roles).ToListAsync();

                return new Response<List<Usuario>>(response, "Lista");

            } catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
        public async Task<Response<Usuario>> ObtenerUsuario(int id)
        {
            try
            {
                Usuario res = await _context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == id);

                return new Response<Usuario>(res);

            } catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

        }

        public async Task<Response<Usuario>> CrearUsuario(UsuarioDto request)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = request.Nombre,
                    Username = request.Username,
                    Password = request.Password,
                    FkRol = request.FkRol,
                };

                //usuario.Nombre = request.Nombre;
                //usuario.Username = request.Username;
                //usuario.Password = request.Password;
                //usuario.FkRol = request.FkRol;

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();


                return new Response<Usuario>(usuario);

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

        }

        public async Task<Response<Usuario>> ActualizarUsuario(int id, UsuarioDto request)
        {
            try
            {
                if (id == null)
                {
                    throw new ArgumentNullException("id");
                }
                    var usuario = await _context.Usuarios.FindAsync(id);

                    usuario.Nombre = request.Nombre;
                    usuario.Username = request.Username;   
                    usuario.Password = request.Password;
                    usuario.FkRol = request.FkRol;

                    await _context.SaveChangesAsync();

                    return new Response<Usuario>(usuario);


            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Response<Usuario>> BorrarUsuario(int id)
        {
            try
            {
                if (id == null)
                {
                    throw new ArgumentNullException("id");
                }
                var usuario = await _context.Usuarios.FindAsync(id);

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
