using System;
using System.Collections.Generic;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        List<MovieCardModel> GetTop30GrossingMovies();
    }
}

