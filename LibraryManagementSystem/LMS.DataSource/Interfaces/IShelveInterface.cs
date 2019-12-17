using LMS.DataSource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource.Interfaces
{
    public interface IShelveInterface
    {
        ICollection<Shelve> GetAllShelve();

        Shelve GetByShelveId(int id);

        void CreateShelve(Shelve ShelveObject);

        int UpdateShelve(int id, Shelve ShelveObject);

        void DeleteShelve(int id);

    }
}
