using Dashboard_utenti.Models;
using Dashboard_utenti.MODELS;
using Dashboard_utenti.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
            RecuperaListaPersone();
            DataContext = ViewModelPeronsa;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PersonaModel p = ViewModelPeronsa.Persona;
            string nome = p.Name;
            string cognome = p.Cognome;

            if (nome == null || nome == string.Empty || cognome == null || cognome == string.Empty)
            {
                txtBlcokMessage.Text = "Attenzione: Il campo Nome e Cognome sono obbligatori!!!";
                txtBlcokMessage.Foreground = new SolidColorBrush(Colors.Red);
                return;
            }

            ViewModelPeronsa.ListaPersone.Add(ViewModelPeronsa.Persona);
            ViewModelPeronsa.Persona = new MODELS.PersonaModel();
            txtBlcokMessage.Text = "";

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SalvaListaPersone();
        }
        private void SalvaListaPersone()
        {

            try
            {

                StorageFile fileJson = ApplicationData.Current.LocalFolder.CreateFileAsync("lista-persone.json", CreationCollisionOption.OpenIfExists).GetAwaiter().GetResult();

                string json = FileIO.ReadTextAsync(fileJson).GetAwaiter().GetResult();


                List<PersonaModel> persone = ViewModelPeronsa.ListaPersone.ToList();

                FileIO.AppendTextAsync(file: fileJson, contents: JsonConvert.SerializeObject(persone));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }


        }
        private void RecuperaListaPersone()
        {

            try
            {

                StorageFile fileJson = ApplicationData.Current.LocalFolder.GetFileAsync("lista-persone.json").GetAwaiter().GetResult();

                string json = FileIO.ReadTextAsync(fileJson).GetAwaiter().GetResult();

                List<PersonaModel> persone = JsonConvert.DeserializeObject<List<PersonaModel>>(json.ToString());
                // Convertiamo la List in un'ObservableCollection
                ObservableCollection<PersonaModel> observablePersone= new ObservableCollection<PersonaModel>(persone);

                ViewModelPeronsa.ListaPersone = observablePersone;

                FileIO.AppendTextAsync(file: fileJson, contents: JsonConvert.SerializeObject(persone));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }


        }

    }
}
