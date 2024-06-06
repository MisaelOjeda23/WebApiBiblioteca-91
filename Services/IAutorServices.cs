using Domain.DTO;
using Domain.Entities;

namespace WebApi91.Services
{
    public interface IAutorServices
    {
        public Task<Response<List<Autor>>> GetAutores();
        public Task<Response<Autor>> CreateAutor(AutorDto autor);

        public Task<Response<Autor>> UpdateAutor(int id, Autor autor);
        public Task<Response<Autor>> DeleteAutor(int idAutor);


    }
}
