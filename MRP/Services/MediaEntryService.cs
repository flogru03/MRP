using MRP.Business;
using MRP.Business.Models;
using MRP.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP.Services
{
    internal class MediaEntryService
    {
        // ########## METHODS ##########

        // TODO: Implement MediaEntryService

        public MediaEntryBase CreateMediaEntry<T>() where T : MediaEntryBase
        {
            throw new NotImplementedException();
        }
        public void updateMedia(MediaEntryBase entry)
        {
            throw new NotImplementedException();
        }
        public void deleteMedia(MediaEntryBase entry)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<MediaEntryBase> getAllMediaEntries() 
        { 
            throw new NotImplementedException(); 
        }
        public IEnumerable<MediaEntryBase> searchMediaEntries(MediaFilter? filter, MediaEntryBase entryPattern)
        {
            throw new NotImplementedException();
        }
        public MediaEntryBase getMediaEntry(int id)
        {
            throw new NotImplementedException();
        }

        // ########## CONSTRUCTORS ##########
        public MediaEntryService(MediaEntryRepository mediaEntryRepo)
        { 
            _mediaRepo = mediaEntryRepo;
        }

        // ########## MEMBERS ##########
        private MediaEntryRepository _mediaRepo;
    }
}
