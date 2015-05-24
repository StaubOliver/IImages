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
    class image
    {
        public ObjectId id { get; set; }
        public string path { get; set; }
        public DateTime date { get; set; }
        public int rating { get; set; }
        public List<string> tags { get; set; }
        public List<string> personnes { get; set; }
        public List<string> couleurs { get; set; }

        public BsonDocument doc { get; set; }

        public Image thumb {get; set;}


        public image(string p)
        {
            this.path = p;
            this.date = DateTime.Now;
            tags = new List<string>();
            personnes = new List<string>();
            couleurs = new List<string>();
            rating = 0;

            generate_document();
        }

        public image(ObjectId i, string p, DateTime d, int r, List<string> t, List<string> per, List<string> c)
        {
            this.id = i;
            this.path = p;
            this.date = d;
            this.rating = r;
            this.tags = t;
            this.personnes = per;
            this.couleurs = c;
            generate_document();
        }

        public void generate_document()
        {
            BsonArray _tags = new BsonArray(tags);
            BsonArray _personnes = new BsonArray(personnes);
            BsonArray _couleurs = new BsonArray(couleurs);

            doc = new BsonDocument
            {
                { "path" , path },
                { "rating", rating },
                { "tags" , _tags },
                { "personnes", _personnes },
                { "couleurs", _couleurs }
            };
        }

        public void generate_thumb()
        {
            Image img = new Bitmap(path);
            this.thumb = img.GetThumbnailImage(100, 100, null, IntPtr.Zero);
            img.Dispose();
        }

        

        
    }
}
