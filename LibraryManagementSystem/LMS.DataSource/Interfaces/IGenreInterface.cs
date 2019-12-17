using LMS.DataSource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.Interfaces
{
    public interface IGenreInterface
    {
        ICollection<Genre> GetAllGenres();

        Genre GetGenreByID(int genreID);

        void CreateGenre(Genre newGenre);

        int UpdateGenre(int genreID, Genre genreObject);

        void DeleteGenre(int genreID);
    }
}
