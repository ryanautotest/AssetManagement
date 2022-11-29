using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework.Utilities
{
    public class ReadData
    {
        public static List<T> GetListDataFromJsonFile<T>(string pathFile) where T : class
        {
            using (StreamReader r = new StreamReader(pathFile))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
        }
    }
}
