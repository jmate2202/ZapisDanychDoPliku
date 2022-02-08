using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ZapisDanychDoPliku.Data;
using ZapisDanychDoPliku.Services;

namespace ZapisDanychDoPliku
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        //private readonly ServiceProvider serviceProvider;
        //public App()
        //{
        //    ServiceCollection services = new ServiceCollection();
        //    ConfigureServices(services);
        //    serviceProvider = services.BuildServiceProvider();
        //}
        //private void ConfigureServices(ServiceCollection services)
        //{
        //    services.AddSingleton<DaneContext>();
        //    services.AddScoped<IOsobaService, OsobaService>();
        //    services.AddScoped<IUczenService, UczenService>();
        //    services.AddSingleton<MainWindow>();
        //}
        //private void OnStartup(object sender, StartupEventArgs e)
        //{
        //    var mainWindow = serviceProvider.GetService<MainWindow>();
        //    mainWindow.Show();
        //}

    }
}
