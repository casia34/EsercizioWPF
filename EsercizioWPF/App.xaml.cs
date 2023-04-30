using EsercizioWPF.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EsercizioWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
           Models.PersonaServices personaServices =  new Models.PersonaServices();
            MainWindowViewModels mainWindowViewModels = new MainWindowViewModels(personaServices);


            MainWindow window = new MainWindow(mainWindowViewModels);
            window.Show();
        }
    }
}
