using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZapisDanychDoPliku.Models;

namespace ZapisDanychDoPliku.Services
{
    public interface IOsobaService
    {
        List<OsobaDTO> GetOsoby();
        void StworzOsobe(OsobaDTO osobaDTO);
        bool AktualizujOsobe(int id,OsobaDTO osoba);
        bool UsunOsobe(int id);
        OsobaDTO GetOsoba(int id);
        public void ResetDanych();
        
    }
}
