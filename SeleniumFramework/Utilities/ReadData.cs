using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace SeleniumFramework.Utilities
{
    public static class ReadData
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
