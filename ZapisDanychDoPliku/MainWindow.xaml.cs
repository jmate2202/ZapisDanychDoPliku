using System.Windows;
using ZapisDanychDoPliku.Data;
using ZapisDanychDoPliku.Services;
using ZapisDanychDoPliku.View;

namespace ZapisDanychDoPliku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     
        private readonly DaneContext daneContext;
        public MainWindow()
        {
            InitializeComponent();
            daneContext = new DaneContext();
            Okno.Content = new MainPage();
        }

     

        private void BT_ZmienWidokOsoby(object sender, RoutedEventArgs e)
        {
            var nowaStrona = new OsobaPage(new OsobaService(daneContext));
            Okno.Content = nowaStrona.Content;
        }

        private void BT_ZmienWidokUczniowie(object sender, RoutedEventArgs e)
        {
            var nowaStrona = new UczenPage(new UczenService(daneContext));
            Okno.Content = nowaStrona.Content;
        }

        private void BT_ZmienWidokLekcja(object sender, RoutedEventArgs e)
        {
            var nowaStrona = new LekcjaPage();
            Okno.Content = nowaStrona.Content;
        }
    }
}
