using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace webAPI_NaverMusic
{

    //GET ARTIST MAP
    public class ArtistResponse
    {
        public long id { get; set; }

        public string name { get; set; }

        public string link { get; set; }

        public string picture { get; set; }

        public string picture_small { get; set; }

        public string picture_medium { get; set; }

        public string picture_big { get; set; }

        public string picture_xl { get; set; }

        public string type { get; set; }

    }


    // GET TOP TRACKS FOR ARTIST BY ID MAP
    public class ArtistTopTracksResponse
    { 
    public List<DataTop> data { get; set; }
    }

    public class DataTop
    { 
       public long id { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string preview { get; set; }
        public AlbumTop album { get; set; }
       

    }

    public class AlbumTop
    { 
        public long id { get; set; }
        public string title { get; set; }
        public string cover_small { get; set; }
        public string cover_medium { get; set; }
        public string cover_big { get; set; }
        public string cover_xl { get; set; }
        public string type { get; set; }
    }



    //SEARCH QUERY MAP
    public class SearchResponse
    {
        public List<DataSearch> data { get; set; }
    }

    public class DataSearch
    {
        public long id { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string preview { get; set; }
        public ArtistSearch artist { get; set; }
        public AlbumSearch album { get; set; }


    }

    public class ArtistSearch
    {
        public long id { get; set; }
        public string name { get; set; }
        public string picture_small { get; set; }
        public string picture_medium { get; set; }
        public string picture_big { get; set; }
        public string picture_xl { get; set; }
        public string type { get; set; }
    }

    public class AlbumSearch
    {
        public long id { get; set; }
        public string title { get; set; }
        public string cover_small { get; set; }
        public string cover_medium { get; set; }
        public string cover_big { get; set; }
        public string cover_xl { get; set; }
        public string type { get; set; }
    }




}
