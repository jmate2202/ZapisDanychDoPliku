using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZapisDanychDoPliku.Models;

namespace ZapisDanychDoPliku.Data
{
    static class Helper
    {
        public static string KonwertujObiektDoCSV<T>(object obiekt, string separator)
        {
            Type t = typeof(T);
            PropertyInfo[] wlasciwosciKlasy = t.GetProperties();
            StringBuilder liniaCsv = new StringBuilder();
            foreach (var wlasciwosc in wlasciwosciKlasy)
            {
                if (liniaCsv.Length > 0)
                    liniaCsv.Append(separator);
                var wartoscPola = wlasciwosc.GetValue(obiekt);
                if (wartoscPola != null)
                    liniaCsv.Append(wartoscPola.ToString());

            }
            return liniaCsv.ToString();
        }
        public static void ZapiszDoPliku<T>(string pathFile, List<T> listaObject)
        {
            File.WriteAllText(pathFile, string.Empty);
            StreamWriter sw = File.AppendText(pathFile);
            sw.WriteLine(string.Join(",", typeof(T).GetProperties().Select(x => x.Name).ToArray()));
            listaObject.ForEach(x => { sw.WriteLine(KonwertujObiektDoCSV<T>(x, ",")); });
            sw.Close();
        }

        public static List<T> CzytajZPliku<T>(string pathFile)
        {
            var wynik = typeof(T);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };
            StreamReader sr = new StreamReader(pathFile);
            var csv = new CsvReader(sr,config);
            var lista = csv.GetRecords<T>().ToList();
            sr.Close();
            return lista;
        }
       
     
    }
}
