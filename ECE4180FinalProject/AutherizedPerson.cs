using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Windows.Media.Imaging;


namespace ECE4180FinalProject
{
    class AutherizedPerson
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int AccessLevel { get; set; }
        public List<string> VisitHistory { get; set;}
        public BitmapSource Pic { get; set; }
    }
}
