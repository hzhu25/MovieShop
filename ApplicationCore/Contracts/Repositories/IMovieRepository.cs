using System;
using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetTop30GrossingMovies();
        Task<Movie> GetById(int id);
        Task<PaginatedResultSet<Movie>> GetMovieByGenrePagination(int genreId, int pageSize = 30, int page = 1);
    }
}

