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
        public string path_tb { get; set; }
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

            generate_thumb();
            generate_document();
        }

        public image(ObjectId i, string p, string tb, DateTime d, int r, List<string> t, List<string> per, List<string> c)
        {
            this.id = i;
            this.path = p;
            generate_thumb();
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
                { "path", path },
                { "path_tb", path_tb },
                { "rating", rating },
                { "date", date },
                { "tags" , _tags },
                { "personnes", _personnes },
                { "couleurs", _couleurs }
            };
        }

        private void generate_thumb()
        {
            Image img = new Bitmap(path);
            Size newSize = GetDimensions(img.Width, img.Height, 100);
            this.thumb = img.GetThumbnailImage(newSize.Height, newSize.Width, null, IntPtr.Zero);
            //thumb.Save(Path.GetFileNameWithoutExtension(this.path) + "_tb.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            this.path_tb = Path.GetDirectoryName(this.path) + "\\" + Path.GetFileNameWithoutExtension(this.path + "_tb.jpg");
            img.Dispose();
        }

        public void load_thumb()
        {
            this.thumb = new Bitmap(path_tb);
        }
        
        public void Save_thumb()
        {
            this.thumb.Save(Path.GetDirectoryName(this.path) +"\\" +  Path.GetFileNameWithoutExtension(this.path) + "_tb.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        static Size GetDimensions(int h, int w, int max)
        {
            double factor;

            if (w > h)
            {
                factor = (double)max / w;
            }
            else
            {
                factor = (double)max / h;
            }
            return new Size((int)(w * factor), (int)(h * factor));
        }

        

        
    }
}
