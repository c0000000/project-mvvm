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
    public sealed partial class DashboardTodos : Page
    {

        public DashboardTodos()
        {
            this.InitializeComponent();
            _ = GetTodosAsync();
            _ = GetCommentsAsync();
        }

        private async Task GetTodosAsync()
        {
            HttpClient httpClient = new HttpClient();
            string url = "https://dummyjson.com/todos";
            TodoResponse todoResponse = await httpClient.GetFromJsonAsync<TodoResponse>(url);
            List<TodoItemModel> todos = todoResponse.Todos;
            TodosList.ItemsSource = todos;

        }

        private async Task GetCommentsAsync()
        {
            HttpClient httpClient = new HttpClient();
            string url = "https://dummyjson.com/comments";
            CommentResponse commentResponse = await httpClient.GetFromJsonAsync<CommentResponse>(url);
            List<CommentModel> todos = commentResponse.Comments;
            CommentsListView.ItemsSource = todos;

        }

        private void mostraTodos(object sender, RoutedEventArgs e)
        {
            CommentsListView.Visibility = Visibility.Collapsed;
            TodosList.Visibility = Visibility.Visible;
        }

        private void mostraComments(object sender, RoutedEventArgs e)
        {
            CommentsListView.Visibility = Visibility.Visible;
            TodosList.Visibility = Visibility.Collapsed;
        }
    }
}
