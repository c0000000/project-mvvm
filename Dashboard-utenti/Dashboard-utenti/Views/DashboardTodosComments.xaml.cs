using Dashboard_utenti.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace Dashboard_utenti.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DashboardTodosComments : Page
    {

        public DashboardTodosComments()
        {
            this.InitializeComponent();
            _ = GetTodosAsync();
            _ = GetCommentsAsync();
        }

        private List<TodoItemModel> GetTodosAsync()
        {
            HttpClient httpClient = new HttpClient();
            string url = "https://dummyjson.com/todos";
            TodoResponse todoResponse = httpClient.GetFromJsonAsync<TodoResponse>(url).GetAwaiter().GetResult();
            return todoResponse.Todos;

        }

        private List<CommentModel> GetCommentsAsync()
        {
            HttpClient httpClient = new HttpClient();
            string url = "https://dummyjson.com/comments";
            CommentResponse commentResponse = httpClient.GetFromJsonAsync<CommentResponse>(url).GetAwaiter().GetResult();
            return commentResponse.Comments;
        }

        private void MostraTodos()
        {
            TodosList.Visibility = Visibility.Visible;
            CommentsListView.Visibility = Visibility.Collapsed;
            CommentsListView.ItemsSource = new List<CommentModel>();
            TodosList.ItemsSource = GetTodosAsync();
        }

        private void MostraComments()
        {

            CommentsListView.Visibility = Visibility.Visible;
            TodosList.Visibility = Visibility.Collapsed;
            TodosList.ItemsSource = new List<TodoItemModel>();
            CommentsListView.ItemsSource = GetCommentsAsync();

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton selectedRadioButton = sender as RadioButton;

            if (selectedRadioButton != null)
            {
                if (selectedRadioButton.Content.Equals("Todos"))
                {
                    MostraTodos();
                }
                else
                {
                    MostraComments();
                }
            }
        }
    }
}
