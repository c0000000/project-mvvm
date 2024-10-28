using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_utenti.Models
{
    using System.Collections.Generic;

    public class CommentResponse
    {
        public List<CommentModel> Comments { get; set; }
        public int Total { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
    }

    public class CommentModel
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int PostId { get; set; }
        public int Likes { get; set; }
        public User User { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
    }

}
