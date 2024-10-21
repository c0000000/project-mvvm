using Dashboard_utenti.Models;
using Dashboard_utenti.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
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
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        const string NAME_FILES = "credentials.json";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = txtBoxUsername.Text;
            string password = txtBoxPassword.Password;

            UserModel ueserLogin = new UserModel()
            {
                Username = username,
                HashPassword = GenerateHashPasword(password)
            };

            if (CheckCredaintiali(ueserLogin))
            {
                Frame.Navigate(typeof(DashboardUtenti), null, new DrillInNavigationTransitionInfo());
            }
            else
            {
                txtBlockMessaggio.Text = "Attenzioen: Credenziali Errate!!";
                txtBoxUsername.Text = "";
                txtBoxPassword.Password = "";
                txtBlockMessaggio.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private bool CheckCredaintiali(UserModel userLogin)
        {
            if (userLogin == null)
            {
                throw new ArgumentNullException(nameof(userLogin));
            }

            StorageFile file;
            try
            {
                file = ApplicationData.Current.LocalFolder.GetFileAsync(NAME_FILES).GetAwaiter().GetResult();
            }
            catch (FileNotFoundException)
            {
                file = ApplicationData.Current.LocalFolder.CreateFileAsync(NAME_FILES, CreationCollisionOption.OpenIfExists).GetAwaiter().GetResult();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
            string contenuto = FileIO.ReadTextAsync(file).GetAwaiter().GetResult();

            if (string.IsNullOrEmpty(contenuto))
            {
                Debug.WriteLine("Contenuto del file è vuoto.");
                return false;
            }
            try
            {
                List<UserModel> users = JsonConvert.DeserializeObject<List<UserModel>>(contenuto);
                if (users == null || users.Count == 0)
                {
                    Debug.WriteLine("Nessun utente trovato nel file.");
                    return false;
                }

                foreach (UserModel user in users)
                {
                    if (userLogin.Username == user.Username && userLogin.HashPassword == user.HashPassword)
                    {
                        Debug.WriteLine("Credenziali valide.");
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                FileIO.WriteTextAsync(file, "").GetAwaiter().GetResult();
            }


            Debug.WriteLine("Credenziali non valide.");
            return false;
        }


        private string GenerateHashPasword(string password)
        {
            string hashPassword = "";
            SHA256 sha = SHA256.Create();
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

            foreach (byte b in bytes)
            {
                hashPassword += b.ToString("X2");
            }


            return hashPassword;
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegistroView));
        }
    }
}
