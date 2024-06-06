using Dapper;
using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi91.Context;

namespace WebApi91.Services
{
    public class AutorServices : IAutorServices
    {
        private readonly ApplicationDbContext _context;

        public AutorServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> response = new List<Autor>();

                var result = await _context.Database.GetDbConnection()
                    .QueryAsync<Autor>(
                        "spGetAutores",
                        new { },
                        commandType: CommandType.StoredProcedure
                    );

                response = result.ToList();

                return new Response<List<Autor>>(response);


            } catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Response<Autor>> CreateAutor(AutorDto i)
        {
            try
            {

                Autor result = new Autor();

                result = (await _context.Database.GetDbConnection().
                    QueryAsync<Autor>(
                        "SpCrearAutor", 
                        new {i.Nombre, i.Nacionalidad}, 
                        commandType: CommandType.StoredProcedure
                    )).FirstOrDefault();

                return new Response<Autor>(result);

            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Response<Autor>> UpdateAutor(int id, Autor autor)
        {
            try
            {
                if (id == null)
                {
                    throw new ArgumentNullException("id");
                }

                Autor result = (await _context.Database.GetDbConnection()
                    .QueryAsync<Autor>(
                        "SpUpdateAutor",
                        new { autor.idAutor, autor.Nombre, autor.Nacionalidad },
                        commandType: CommandType.StoredProcedure
                    )).FirstOrDefault(x => x.idAutor == id);

                return new Response<Autor>(result);

            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Response<Autor>> DeleteAutor(int idAutor)
        {
            try
            {
                if (idAutor == null)
                {
                    throw new ArgumentNullException("id");
                }

                Autor result = (await _context.Database.GetDbConnection()
                    .QueryAsync<Autor>(
                        "SpDeleteAutor",
                        new { idAutor },
                        commandType: CommandType.StoredProcedure
                    )).FirstOrDefault(x => x.idAutor == idAutor);

                return new Response<Autor>(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
