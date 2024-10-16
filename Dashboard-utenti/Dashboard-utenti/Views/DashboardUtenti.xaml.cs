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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Dashboard_utenti.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DashboardUtenti : Page
    {
        private const string NAME_FILES = "lista-persone.json";

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
                StorageFile fileJson = ApplicationData.Current.LocalFolder.CreateFileAsync(NAME_FILES, CreationCollisionOption.OpenIfExists).GetAwaiter().GetResult();

                string json = FileIO.ReadTextAsync(fileJson).GetAwaiter().GetResult();

                List<PersonaModel> persone = ViewModelPeronsa.ListaPersone.ToList();

                string jsonPersone = JsonConvert.SerializeObject(persone);

                FileIO.WriteTextAsync(fileJson, jsonPersone).GetAwaiter().GetResult();

                txtBlcokMessage.Text = $"Salvataggio completato nel percorso: \n{fileJson.Path}";
                txtBlcokMessage.Foreground = new SolidColorBrush(Colors.White);

            }
            catch (Exception e)
            {
                Debug.WriteLine($"Errore nel salvataggio del file: {e.Message}");
                txtBlcokMessage.Text = "Errore nel salvataggio del file. Riprovare.";
                txtBlcokMessage.Foreground = new SolidColorBrush(Colors.Red);

            }


        }
        private void RecuperaListaPersone()
        {

            try
            {

                StorageFile fileJson = ApplicationData.Current.LocalFolder.CreateFileAsync(NAME_FILES, CreationCollisionOption.OpenIfExists).GetAwaiter().GetResult();

                string json = FileIO.ReadTextAsync(fileJson).GetAwaiter().GetResult();

                if (string.IsNullOrEmpty(json))
                {
                    return;
                }
                List<PersonaModel> persone = JsonConvert.DeserializeObject<List<PersonaModel>>(json.ToString());

                ViewModelPeronsa.ListaPersone = new ObservableCollection<PersonaModel>(persone);

                if (persone.Count > 0)
                {
                    txtBlcokMessage.Text = $"Recupero dei dati avvenuto con successo: numero di persone recuperate:\n - numero persone: {persone.Count} .";

                    int idCountMax = persone.Max(p => p.ID);

                    PersonaModel.IDCount = idCountMax + 1;

                }
                else
                {
                    txtBlcokMessage.Text = "Recupero dei dati avvenuto con successo, ma non sono state trovate persone.";
                }
                txtBlcokMessage.Foreground = new SolidColorBrush(Colors.White);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                txtBlcokMessage.Text = "Errore nel recupero dei dati.\nControllare la formattazione del file JSON.";
                txtBlcokMessage.Foreground = new SolidColorBrush(Colors.Red);

            }


        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModelPeronsa.Persona = new PersonaModel();
            ViewModelPeronsa.ListaPersone = new ObservableCollection<PersonaModel> { new PersonaModel() };

            Frame.Navigate(typeof(Login), null, new DrillInNavigationTransitionInfo());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            EliminazioneListaPersoneFileJson();
        }

        private void EliminazioneListaPersoneFileJson()
        {
            try
            {
                StorageFile fileJson = ApplicationData.Current.LocalFolder.GetFileAsync(NAME_FILES).GetAwaiter().GetResult();

                FileIO.WriteTextAsync(fileJson, "[]").GetAwaiter().GetResult();

                txtBlcokMessage.Text = $"Cancellazione lista completato nel percorso: \n{fileJson.Path}";
                txtBlcokMessage.Foreground = new SolidColorBrush(Colors.Green);
                ViewModelPeronsa.ListaPersone = new ObservableCollection<PersonaModel>();
                PersonaModel.IDCount = 0;
            }
            catch (FileNotFoundException)
            {
                txtBlcokMessage.Text = "Il file non è stato trovato. Assicurati che esista.";
                txtBlcokMessage.Foreground = new SolidColorBrush(Colors.Red);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Errore nel elimanzione dei contenuti del file: {ex.Message}");
                txtBlcokMessage.Text = "Errore nel salvataggio del file. Riprovare.";
                txtBlcokMessage.Foreground = new SolidColorBrush(Colors.Red);

            }
        }
    }
}
