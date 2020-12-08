using System;
using System.Collections.Generic;

#nullable disable

namespace webAPI_NaverMusic.Models
{
    public partial class Favorite
    {
        public int IdFavorite { get; set; }
        public string TypeFav { get; set; }
        public string IdGetFav { get; set; }
        public int? IdUser { get; set; }
        public string SongFav { get; set; }
        public string PictureFav { get; set; }
        public string NameFav { get; set; }
        public string Apiname { get; set; }
        public string Uri { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
