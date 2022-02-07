using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using ZapisDanychDoPliku.View;

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

     

        private void BT_ZmienWidokOsoby(object sender, RoutedEventArgs e)
        {
            var nowaStrona = new OsobaPage();
            Okno.Content = nowaStrona.Content;
        }

        private void BT_ZmienWidokUczniowie(object sender, RoutedEventArgs e)
        {
            var nowaStrona = new UczenPage();
            Okno.Content = nowaStrona.Content;
        }
    }
}
