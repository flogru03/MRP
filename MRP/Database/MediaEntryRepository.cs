using MRP.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRP.DTO;

namespace MRP.Database
{
    internal class MediaEntryRepository : IRepository<MediaEntryDTO>
    {
        // TODO: implement media entry repository

        // ########## METHODS ##########
        public void Add(MediaEntryDTO entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MediaEntryDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public MediaEntryDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(MediaEntryDTO entity)
        {
            throw new NotImplementedException();
        }

        // ########## CONSTRUCTORS ##########
        public MediaEntryRepository(string connectionString)
        {
            _conn = connectionString;
        }

        // ########## MEMBERS ##########
        private string _conn;
    }
}
