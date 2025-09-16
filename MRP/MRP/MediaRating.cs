using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP
{
    internal class MediaRating
    {
        public User Creator { get; private set; }
        public MediaEntry Entry { get; private set; }
        public uint Value { get; private set; }
        public bool IsPublic { get; private set; }
        public string Comment { get; private set; } 
        public DateTime CreatedAt {  get; private set; }
        public uint Likes { get; private set; }
        public MediaRating(MediaEntry entry, User user)
        {
            Entry = entry;
            Creator = user;

            Value = 0;
            IsPublic = false;
            Comment = string.Empty;
            CreatedAt = DateTime.Now;
            Likes = 0;
        }
        public void SetPublic(bool isPublic)
        {
            if (isPublic == IsPublic)
            {
                Console.WriteLine("No Changes made...");
                return;
            }
            IsPublic = isPublic;
        }
    }
}
