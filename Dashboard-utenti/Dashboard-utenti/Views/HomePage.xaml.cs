using Dashboard_utenti.Pages;
using Dashboard_utenti.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Dashboard_utenti
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(DashboardUtenti)); // Naviga alla pagina Home
        }
        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            // Ottieni il tag dell'elemento selezionato
            string tag = args.InvokedItemContainer.Tag.ToString();

            // Naviga alla pagina corrispondente in base al tag
            switch (tag)
            {
                case "home":
                    ContentFrame.Navigate(typeof(DashboardUtenti)); // Naviga alla pagina Home
                    break;
                case "Gestione Utenti":
                    ContentFrame.Navigate(typeof(DashboardUtenti)); // Naviga alla pagina di gestione utenti
                    break;
                case "Todos":
                    ContentFrame.Navigate(typeof(DashboardTodos)); // Naviga alla pagina Todos
                    break;
                case "Logout":
                    Frame.Navigate(typeof(Login)); // Naviga alla pagina Todos
                    break;
            }
        }

    }
}
