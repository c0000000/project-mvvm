using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_utenti.Models
{
public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string HashPassword { get; set; }
    }
}
