using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IImages
{
    class requete
    {
        public int id { get; set; }
        public DateTime date_recherche { get; set; }
        public DateTime date { get; set; }
        public ICollection<string> tags { get; set; }
        public ICollection<string> personnes { get; set; }
        public ICollection<string> couleurs { get; set; }


        public string get_request()
        {
            string res = "";


            return res;
        }

    }
}
