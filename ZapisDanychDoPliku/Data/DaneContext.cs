using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZapisDanychDoPliku.Models;

namespace ZapisDanychDoPliku.Data
{
    class DaneContext
    {

        public Kontener<OsobaDTO> Osoby { get; set; }
        public Kontener<UczenDTO> Uczniowie { get; set; }

        public DaneContext()
        {
            Osoby = new Kontener<OsobaDTO>("dane1.txt");
            Uczniowie = new Kontener<UczenDTO>("uczniowie.txt");
        }
       
      

    }
}
