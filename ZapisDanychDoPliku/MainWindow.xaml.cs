using System;
using System.Collections.Generic;
using System.IO;
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

namespace ZapisDanychDoPliku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ZaladujDane();
        }

        private void BT_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Osoba osoba = PobierzDaneZFormularza();
            if (osoba != null)
            {
                DodajDoPliku(osoba, "dane1.txt");
                WyczcyscFormularz();
                ZaladujDane();
            }

        }

        private void WyczcyscFormularz()
        {
            TB_ImieNazwisko.Text = string.Empty;
            TB_Wiek.Text = string.Empty;
        }

        private Osoba PobierzDaneZFormularza()
        {
            try
            {
                string imieNazwisko = TB_ImieNazwisko.Text;
                int wiek = int.Parse(TB_Wiek.Text);
                Osoba o = new Osoba
                {
                    ImieNazwisko = imieNazwisko,
                    Wiek = wiek
                };
                return o;
            }
            catch (Exception)
            {
                MessageBox.Show("bledne dane");
            }
            return null;

        }

        private void DodajDoPliku(Osoba dane, string sciezkaDoPliku)
        {
            StreamWriter sw = File.AppendText(sciezkaDoPliku);
            string liniaDanych = KonwertujDaneDoCSV(dane);
            sw.WriteLine(liniaDanych);
            sw.Close();
        }

        private string KonwertujDaneDoCSV(Osoba osoba)
        {
            return $"{osoba.ImieNazwisko},{osoba.Wiek}";
        }
        private string KonwertujDaneDoMojegoFormatu(Osoba osoba)
        {
            return $"start\n{osoba.ImieNazwisko}\n{osoba.Wiek}\nend";
        }

        private List<Osoba> WczytajDaneZPliku(string pathFile)
        {
            StreamReader sr = new StreamReader(pathFile);
            List<Osoba> osoby = new List<Osoba>();
            var text = sr.ReadToEnd();
            var linie = text.Split("\r\n");
            foreach (var x in linie)
            {
                if (x != string.Empty)
                {
                    var dane = x.Split(",");
                    osoby.Add(new Osoba() { ImieNazwisko = dane[0], Wiek = int.Parse(dane[1]) });
                }
            }
            sr.Close();
            return osoby;

        }
        private void ZaladujDane()
        {            
            var dane = WczytajDaneZPliku("dane1.txt");
            DG_dane.ItemsSource = dane;

        }
        public class Osoba
        {
            public string ImieNazwisko { get; set; }
            public int Wiek { get; set; }
        }

        private void BT_Restet_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("dane1.txt", string.Empty);
            List<Osoba> osoby = new List<Osoba>()
            {
                new Osoba()
                {
                    ImieNazwisko="Jan Kowalski",
                    Wiek=30
                },
                new Osoba()
                {
                    ImieNazwisko="Adam Nowak",
                    Wiek=20
                },
                new Osoba()
                {
                    ImieNazwisko="Piotr Prank",
                    Wiek=35
                },
                new Osoba()
                {
                    ImieNazwisko="Dorian Kran",
                    Wiek=27
                },
                new Osoba()
                {
                    ImieNazwisko="Aldona Zbieg",
                    Wiek=33
                },
                new Osoba()
                {
                    ImieNazwisko="Krystian Klon",
                    Wiek=39
                },
            };
            osoby.ForEach(x=> DodajDoPliku(x, "dane1.txt"));
            WyczcyscFormularz();
            ZaladujDane();
        }

        private void BT_Usun_Click(object sender, RoutedEventArgs e)
        {
            var osoba = DG_dane.SelectedItem as Osoba;           
            UsunDaneZPliku(osoba);
        }

        private void UsunDaneZPliku(Osoba osoba)
        {
            var osoby = WczytajDaneZPliku("dane1.txt");            
            osoby.RemoveAll(a => a.ImieNazwisko == osoba.ImieNazwisko && a.Wiek == osoba.Wiek);
            File.WriteAllText("dane1.txt", string.Empty);
            osoby.ForEach(x => DodajDoPliku(x, "dane1.txt"));            
            ZaladujDane();
        }

        private void BT_Edycja_Click(object sender, RoutedEventArgs e)
        {
            var osoba = DG_dane.SelectedItem as Osoba;
            EdycjaDanych(osoba);
        }

        private void EdycjaDanych(Osoba osoba)
        {
            WyczcyscFormularz();
            TB_ImieNazwisko.Text = osoba.ImieNazwisko;
            TB_Wiek.Text = osoba.Wiek.ToString();
            UsunDaneZPliku(osoba);
            BT_Akcja.Content = "Edytuj";
            BT_Akcja.Click -= BT_Dodaj_Click;
            BT_Akcja.Click += EdytujDoPliku;
        }

        private void EdytujDoPliku(object sender, RoutedEventArgs e)
        {
            var osoba = PobierzDaneZFormularza();            
            DodajDoPliku(osoba, "dane1.txt");
            ZaladujDane();
            WyczcyscFormularz();
            BT_Akcja.Content = "Dodaj";
            BT_Akcja.Click -= EdytujDoPliku;
            BT_Akcja.Click += BT_Dodaj_Click;

        }
    }
}
