using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZapisDanychDoPliku.Data;
using ZapisDanychDoPliku.Models;

namespace ZapisDanychDoPliku.Services
{
    class UczenService : IUczenService
    {
        private readonly DaneContext _daneContext;
        private int _id;

        public UczenService(DaneContext daneContext)
        {
            _daneContext = daneContext;
            _id = GetId();
        }
        private int GetId()
        {
            if (_daneContext.Uczniowie.Dane.Count == 0) return 0;
            else return _daneContext.Osoby.Dane.Last().Id + 1;
        }

        public bool AktualizujUcznia(int id, UczenDTO uczenDTO)
        {
            var uczen = _daneContext.Uczniowie.Dane.FirstOrDefault(x => x.Id == id);
            if (uczen == null) return false;
            uczenDTO.Id = uczen.Id;
            _daneContext.Uczniowie.Dane.Remove(uczen);
            _daneContext.Uczniowie.Dane.Add(uczenDTO);
            _daneContext.Uczniowie.ZapiszZmiany();
            return true;
        }

        public UczenDTO GetUczen(int id) => _daneContext.Uczniowie.Dane.FirstOrDefault(x => x.Id == id);

        public List<UczenDTO> GetUczniow() => _daneContext.Uczniowie.Dane;


        public void ResetDanych()
        {
            _daneContext.Uczniowie.Dane.Clear();
            List<UczenDTO> uczniowie = new List<UczenDTO>()
            {
                new UczenDTO(){Imie="Jan",Nazwisko="Nowak",Klasa="2BT"},
                new UczenDTO(){Imie="Piotr",Nazwisko="Prank",Klasa="2BT"},
                new UczenDTO(){Imie="Adam",Nazwisko="Klan",Klasa="1BT"},
                new UczenDTO(){Imie="Jan",Nazwisko="Nowak",Klasa="2BT"},
                new UczenDTO(){Imie="Stefan",Nazwisko="Por",Klasa="2BT"},
                new UczenDTO(){Imie="Bolesław",Nazwisko="Akor",Klasa="1BT"},
                new UczenDTO(){Imie="Stanisław",Nazwisko="Kopara",Klasa="1BT"},
                new UczenDTO(){Imie="Adam",Nazwisko="Stan",Klasa="2BT"}                
            };
            uczniowie.ForEach(x => StworzUcznia(x));
        }

        public void StworzUcznia(UczenDTO uczenDTO)
        {
            uczenDTO.Id = _id++;
            _daneContext.Uczniowie.Dane.Add(uczenDTO);
            _daneContext.Uczniowie.ZapiszZmiany();
        }

        public bool UsunOsobe(int id)
        {
            var uczen = _daneContext.Uczniowie.Dane.FirstOrDefault(x => x.Id == id);
            if (uczen == null) return false;
            _daneContext.Uczniowie.Dane.Remove(uczen);
            _daneContext.Uczniowie.ZapiszZmiany();
            return true;
        }
    }
}
