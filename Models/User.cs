using System;
using System.Collections.Generic;

#nullable disable

namespace webAPI_NaverMusic.Models
{
    public partial class User
    {
        public User()
        {
            Favorites = new HashSet<Favorite>();
            Subscriptions = new HashSet<Subscription>();
            Votes = new HashSet<Vote>();
        }

        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
        public string Gender { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; }
        public string Nationality { get; set; }
        public string Numberphone { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
