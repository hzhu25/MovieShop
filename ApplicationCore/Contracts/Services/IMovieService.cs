using System;
using System.Collections.Generic;
using ApplicationCore.Models;


namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        Task<List<MovieCardModel>> GetTopRevenueMovies();
        Task<MovieDetailsModel> GetMovieDetails(int movieId);
        Task<PaginatedResultSet<MovieCardModel>> GetMoviesByPagination(int genreId, int pageSize = 30, int page = 1);
    }
}

