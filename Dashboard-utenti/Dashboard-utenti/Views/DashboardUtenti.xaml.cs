using Dashboard_utenti.MODELS;
using Dashboard_utenti.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Dashboard_utenti.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DashboardUtenti : Page
    {
        private ViewModelPeronsa ViewModelPeronsa { get; set; } = new ViewModelPeronsa();
        public DashboardUtenti()
        {
            this.InitializeComponent();
            DataContext = ViewModelPeronsa;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Persona p = ViewModelPeronsa.Persona;
            string nome = p.Name;
            string cognome = p.Cognome;

            if (nome == null || nome == string.Empty || cognome == null || cognome == string.Empty)
            {
                txtBlcokMessage.Text = "Attenzione: Il campo Nome e Cognome sono obbligatori!!!";
                txtBlcokMessage.Foreground = new SolidColorBrush(Colors.Red);
                return;
            }

            ViewModelPeronsa.ListaPersone.Add(ViewModelPeronsa.Persona);
            ViewModelPeronsa.Persona = new MODELS.Persona();
            txtBlcokMessage.Text = "";

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
