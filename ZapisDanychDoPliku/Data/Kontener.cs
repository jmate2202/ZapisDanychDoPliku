using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZapisDanychDoPliku.Data
{
    class Kontener<Z>  where Z : class
    {

        public List<Z> Dane { get; set; }

        private readonly string _pathFile;

        public Kontener(string pathFile)
        {
            if (!File.Exists(pathFile))
            {
                FileStream fs = File.Create(pathFile);
                fs.Close();
            }
            Dane = new List<Z>();
            _pathFile = pathFile;
            CzytajDaneZPliku();
        }


        private void CzytajDaneZPliku()
        {
            Dane = Helper.CzytajZPliku<Z>(_pathFile);
        }
        public void ZapiszZmiany()
        {
            Helper.ZapiszDoPliku(_pathFile, Dane);
        }

    }
}
