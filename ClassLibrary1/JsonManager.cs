using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClassLibrary1
{

    public static class JsonManager
    {
        private static JsonSerializerSettings jset = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
        public static string temp;
        public static void Serialize(List <Suchestvo> suchestvos)
        {
            using (StreamWriter fs = new StreamWriter("bestiariy.json", false))
            {
                temp = JsonConvert.SerializeObject(suchestvos, jset);
                fs.WriteLine(temp);
            }
        }
        public static List<Suchestvo> Deserialize()
        {
            using (StreamReader reader = new StreamReader("bestiariy.json"))
            {
                List<Suchestvo> restored = (List<Suchestvo>)JsonConvert.DeserializeObject(reader.ReadToEnd(), jset);
                return restored;
            }
        }
    }
   
}
