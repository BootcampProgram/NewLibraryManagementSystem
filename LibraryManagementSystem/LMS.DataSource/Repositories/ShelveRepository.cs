using LMS.DataSource.Entities;
using LMS.DataSource.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.DataSource.Repositories
{
    public class ShelveRepository : IShelveInterface
    {
        AppDbContext _appDbContext;

        public ShelveRepository(AppDbContext dbcontext)
        {
            _appDbContext = dbcontext;
        }
        public void CreateShelve(Shelve ShelveObject)
        {
            _appDbContext.Shelve.Add(ShelveObject);
            _appDbContext.SaveChanges();
        }

        public void DeleteShelve(int id)
        {
            var shelve = _appDbContext.Shelve.Where(c => c.ShelveID == id).SingleOrDefault();
            _appDbContext.Shelve.Remove(shelve);
            _appDbContext.SaveChanges();
        }

        public ICollection<Shelve> GetAllShelve()
        {
            var shelve = _appDbContext.Shelve.ToList();
            return shelve;
        }

        public Shelve GetByShelveId(int id)
        {
            var shelve = _appDbContext.Shelve.Where(c => c.ShelveID == id).SingleOrDefault();
            return shelve;
        }

        public int UpdateShelve(int id, Shelve ShelveObject)
        {
            var shelve = _appDbContext.Shelve.Where(c => c.ShelveID == id).SingleOrDefault();
            if (shelve == null)
            {
                return 0; //if Fails return 0
            }
            else
            {
                shelve.Code = ShelveObject.Code;
               


                _appDbContext.SaveChanges();
                return 1; //if success return 1

            }
        }
    }
}
