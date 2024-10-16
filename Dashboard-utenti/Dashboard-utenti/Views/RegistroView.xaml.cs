using Dashboard_utenti.Models;
using Dashboard_utenti.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using Windows.Data.Json;
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

namespace Dashboard_utenti.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistroView : Page
    {
        private const string NAME_FILES = "credentials.json";

        public RegistroView()
        {
            this.InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = txtBoxUsername.Text;
            string password = txtBoxPassword.Password;
            if (!string.IsNullOrEmpty(username) && (!string.IsNullOrEmpty(password)))
            {
                string hashPassword = GenerateHashPasword(password);
                UserModel newUser = new UserModel()
                {
                    Username = username,
                    HashPassword = hashPassword
                };

                SalvaUser(newUser);
                Frame.Navigate(typeof(Login));
            }
            else
            {
                txtBlockMessaggio.Text = "Attenzioen: Credenziali Errate!!";
                txtBoxUsername.Text = "";
                txtBoxPassword.Password = "";
                txtBlockMessaggio.Foreground = new SolidColorBrush(Colors.Red);
            }
        }


        private void SalvaUser(UserModel newUser)
        {
            if (newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser));
            }
            try
            {

                StorageFile fileJson = ApplicationData.Current.LocalFolder.CreateFileAsync(NAME_FILES, CreationCollisionOption.OpenIfExists).GetAwaiter().GetResult();

                string json = FileIO.ReadTextAsync(fileJson).GetAwaiter().GetResult();


                List<UserModel> users;
                if (string.IsNullOrEmpty(json))
                {
                    users = new List<UserModel>();
                }
                else
                {
                    users = JsonConvert.DeserializeObject<List<UserModel>>(json);
                }

                if (!users.Any(u => u.Username == newUser.Username))
                {
                    users.Add(newUser);
                    _ = FileIO.AppendTextAsync(file: fileJson, contents: JsonConvert.SerializeObject(users));
                }
                else
                {
                    txtBlockMessaggio.Text = "Account già registrato.";
                    txtBlockMessaggio.Foreground = new SolidColorBrush(Colors.Red);

                }

}
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

            }


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
            Frame.Navigate(typeof(Login));

        }
    }
}
