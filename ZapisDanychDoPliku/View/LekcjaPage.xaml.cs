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

namespace ZapisDanychDoPliku.View
{
    /// <summary>
    /// Logika interakcji dla klasy LekcjaPage.xaml
    /// </summary>
    public partial class LekcjaPage : Page
    {
        public LekcjaPage()
        {
            InitializeComponent();
        }

        private void BT_DodajLekcje_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BT_Restet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BT_Obecnosc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CB_KlasaWybor_Click(object sender, RoutedEventArgs e)
        {
            if (CB_klasa.SelectedItem != null)
            {
                var item = CB_klasa.SelectedItem as ComboBoxItem;
                var klasa = item.Content.ToString();
                MessageBox.Show(klasa);
            }
        }
    }
}
