using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZapisDanychDoPliku.Models;

namespace ZapisDanychDoPliku.Services
{
    public interface IUczenService
    {
        public List<UczenDTO> GetUczniow();
        public void StworzUcznia(UczenDTO uczenDTO);
        public bool AktualizujUcznia(int id, UczenDTO uczenDTO);
        public bool UsunOsobe(int id);
        public UczenDTO GetUczen(int id);
        public void ResetDanych();
    }
}
