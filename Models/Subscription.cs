using System;
using System.Collections.Generic;

#nullable disable

namespace webAPI_NaverMusic.Models
{
    public partial class Subscription
    {
        public int IdSubs { get; set; }
        public string Status { get; set; }
        public decimal? PayUser { get; set; }
        public int? IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
