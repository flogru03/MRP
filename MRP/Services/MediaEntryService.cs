using MRP.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP.Services
{
    internal class MediaEntryService
    {
        private User _user;
        public MediaEntryService(User user)
        {
            _user = user;
        }
        public MediaEntry createMedia(Type mediaType)
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
    }
}
