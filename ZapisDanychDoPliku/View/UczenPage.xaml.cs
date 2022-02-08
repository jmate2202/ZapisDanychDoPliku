using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZapisDanychDoPliku.Models;
using ZapisDanychDoPliku.Services;

namespace ZapisDanychDoPliku.View
{
    /// <summary>
    /// Logika interakcji dla klasy UczenPage.xaml
    /// </summary>
    public partial class UczenPage : Page
    {
        private readonly IUczenService _uczenService;
        public UczenPage(IUczenService uczenService)
        {
            InitializeComponent();
            _uczenService = uczenService;
            ZaladujDane();            
        }

        private void ZaladujDane()
        {
            DG_dane.ItemsSource = null;
            DG_dane.ItemsSource = _uczenService.GetUczniow();
        }

        private void WyczcyscFormularz()
        {
            TB_Imie.Text = string.Empty;
            TB_Nazwisko.Text = string.Empty;
            TB_Klasa.Text = string.Empty;
        }

        private UczenDTO PobierzDaneZFormularza()
        {
            try
            {
                var o = new UczenDTO()
                {
                    Imie=TB_Imie.Text,
                    Nazwisko=TB_Nazwisko.Text,
                    Klasa=TB_Klasa.Text,
                };
               
                return o;
            }
            catch (Exception)
            {
                MessageBox.Show("bledne dane");
            }
            return null;

        }

        private void BT_Restet_Click(object sender, RoutedEventArgs e)
        {
            _uczenService.ResetDanych();
            WyczcyscFormularz();
            ZaladujDane();
        }

        private void BT_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            UczenDTO uczen = PobierzDaneZFormularza();
            if (uczen != null)
            {
                _uczenService.StworzUcznia(uczen);
                WyczcyscFormularz();
                ZaladujDane();
            }
        }
        private void BT_Usun_Click(object sender, RoutedEventArgs e)
        {
            var osoba = DG_dane.SelectedItem as UczenDTO;
            var rezultat = _uczenService.UsunOsobe(osoba.Id);
            if (!rezultat) MessageBox.Show("blad usuniecia");
            ZaladujDane();
        }

        int _id;
        private void BT_Edycja_Click(object sender, RoutedEventArgs e)
        {
            var uczen = DG_dane.SelectedItem as UczenDTO;
            _id = uczen.Id;
            EdycjaDanych(uczen);
        }
        private void EdycjaDanych(UczenDTO uczen)
        {
            WyczcyscFormularz();
            TB_Imie.Text = uczen.Imie;
            TB_Nazwisko.Text = uczen.Nazwisko;
            TB_Klasa.Text = uczen.Klasa;
            BT_Akcja.Content = "Edytuj";
            L_NazwaAkcji.Content = "Edytuj";
            BT_Akcja.Click -= BT_Dodaj_Click;
            BT_Akcja.Click += EdytujDoPliku;
        }

        private void EdytujDoPliku(object sender, RoutedEventArgs e)
        {
            var osoba = PobierzDaneZFormularza();
            var rezultat = _uczenService.AktualizujUcznia(_id, osoba);
            if (!rezultat) MessageBox.Show("blad edycji");
            ZaladujDane();
            WyczcyscFormularz();
            BT_Akcja.Content = "Dodaj";
            L_NazwaAkcji.Content = "Dodaj";
            BT_Akcja.Click -= EdytujDoPliku;
            BT_Akcja.Click += BT_Dodaj_Click;
        }


    }
}
