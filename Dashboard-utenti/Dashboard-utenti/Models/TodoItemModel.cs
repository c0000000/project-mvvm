using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_utenti.Models
{
    public class TodoItemModel
    {
        public int Id { get; set; }
        public string Todo { get; set; }
        public bool Completed { get; set; }
        public int UserId { get; set; }
    }
    public class TodoResponse
    {
        public List<TodoItemModel> Todos { get; set; }
    }
}
