using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieAppLibrary
{
    public class DeserializSerializ
    {
        public static void SerializeData(List<Movie> movie)
        {
            File.WriteAllText("MovieData.json", JsonConvert.SerializeObject(movie));
        }

        public static List<Movie> DeserializeData()
        {
            List<Movie> list = new List<Movie>();
            string fileName = "MovieData.json";
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                return JsonConvert.DeserializeObject<List<Movie>>(json);
            }
            return list;
        }

    }
}
