using System;
using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetTop30GrossingMovies();
        Task<Movie> GetById(int id);
    }
}

