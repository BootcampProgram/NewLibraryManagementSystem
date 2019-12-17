using LMS.DataSource.Entities;
using LMS.DataSource.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.DataSource.Repositories
{
    public class GenreRepository : IGenreInterface
    {
        AppDbContext _appDbContext;

        public GenreRepository(AppDbContext repo)
        {
            _appDbContext = repo;
        }

        public void CreateGenre(Genre newGenre)
        {
            _appDbContext.Genre.Add(newGenre);
            _appDbContext.SaveChanges();
        }

        public void DeleteGenre(int genreID)
        {
            var genre = _appDbContext.Genre.Where(c => c.GenreID == genreID).SingleOrDefault();

            _appDbContext.Genre.Remove(genre);
            _appDbContext.SaveChanges();
        }

        public ICollection<Genre> GetAllGenres()
        {
            var genres = _appDbContext.Genre.ToList();
            return genres;
        }

        public Genre GetGenreByID(int genreID)
        {
            var genre = _appDbContext.Genre.Where(c => c.GenreID == genreID).SingleOrDefault();
            return genre;
        }

        public int UpdateGenre(int genreID, Genre genreObject)
        {

            var genre = _appDbContext.Genre.Where(c => c.GenreID == genreID).SingleOrDefault();

            if (genreID == 0)
            {
                return 0;
            }
            else
            {
                genre.Name = genreObject.Name;

                _appDbContext.SaveChanges();
                return 1;
            }
        }
    }
}
