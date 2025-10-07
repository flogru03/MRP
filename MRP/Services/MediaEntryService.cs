using MRP.Business;
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

        public MediaEntry CreateMediaEntry<T>() where T : MediaEntry
        {
            throw new NotImplementedException();
        }
        public void updateMedia(MediaEntry entry)
        {
            throw new NotImplementedException();
        }
        public void deleteMedia(MediaEntry entry)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<MediaEntry> getAllMediaEntries() 
        { 
            throw new NotImplementedException(); 
        }
        public IEnumerable<MediaEntry> searchMediaEntries(MediaFilter? filter, MediaEntry entryPattern)
        {
            throw new NotImplementedException();
        }
        public MediaEntry getMediaEntry(int id)
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
