using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB;
using System.Drawing;



namespace IImages
{
    class bookmark
    {
        public ObjectId Id { get; set; }
        public int rating { get; set; }
        public bool above {get; set;}
        public List<string> tags { get; set; }
        public List<string> personnes { get; set; }
        public string name { get; set; }

        public bookmark()
        {
            this.tags = new List<string>();
            this.personnes = new List<string>();
        }

        public bookmark(int r, bool c)
        {
            this.rating = r;
            this.above = c;
            this.tags = new List<string>();
            this.personnes = new List<string>();
        }

        public bookmark(int r, bool c, List<string> t)
        {
            this.rating = r;
            this.above = c;
            this.tags = t;
        }

        public BsonDocument getDocument()
        {
            BsonArray _tags = new BsonArray(tags);
            BsonArray _personnes = new BsonArray(personnes);
            var tmp = new BsonDocument
            {
                { "rating", rating },
                { "above", above },
                { "tags", _tags},
                { "nom", name },
                { "personnes", _personnes }
            };
            return tmp;
        }
    }
}
