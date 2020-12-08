using System;
using System.Collections.Generic;

#nullable disable

namespace webAPI_NaverMusic.Models
{
    public partial class Vote
    {
        public int IdVote { get; set; }
        public int? IdUser { get; set; }
        public string TypeVote { get; set; }
        public string IdGetVote { get; set; }
        public string NameVote { get; set; }
        public string PictureVote { get; set; }
        public DateTime? DateVote { get; set; }
        public string Apiname { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
