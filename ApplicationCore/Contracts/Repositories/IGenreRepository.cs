using System;
using ApplicationCore.Entities;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAllGenres();
    }
}

