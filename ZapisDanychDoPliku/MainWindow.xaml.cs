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
        }

        private void BT_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Osoba osoba=PobierzDaneZFormularza();
            if(osoba != null)
            {
                DodajDoPliku(osoba, "dane1.txt");
                WyczcyscFormularz();
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

        private void DodajDoPliku(Osoba dane,string sciezkaDoPliku)
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
        public class Osoba
        {
            public string ImieNazwisko { get; set; }
            public int Wiek { get; set; }
        }
    }
}
