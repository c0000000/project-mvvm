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
            NavView.ItemInvoked += NavView_ItemInvoked;
            ContentFrame.Navigate(typeof(DashboardUtenti)); // Naviga alla pagina Home
        }
        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            string tag = args.InvokedItemContainer.Tag.ToString();

            switch (tag)
            {
                case "home":
                    ContentFrame.Navigate(typeof(DashboardUtenti));
                    break;
                case "Gestione Utenti":
                    ContentFrame.Navigate(typeof(DashboardUtenti));
                    break;
                case "Todos":
                    ContentFrame.Navigate(typeof(DashboardTodosComments));
                    break;
                case "Logout":
                    Frame.Navigate(typeof(Login));
                    break;
                case "Chiudi Applicazione":
                    Application.Current.Exit();
                    break;
            }
        }

    }
}
