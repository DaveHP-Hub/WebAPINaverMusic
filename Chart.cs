using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace webAPI_NaverMusic
{
    public class Chart
    {
       public HttpClient client;
        private readonly string _url = "https://api.deezer.com/";
        private readonly string _token = "myToken";

        public Chart() {        
            client = new HttpClient
            {
                BaseAddress = new Uri(_url)
            };
         client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("access_token", _token);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }





        public async Task<Response> getChart()
        {
            Response response = new Response();
            try
            {

                response = await client.GetFromJsonAsync<Response>("chart?limit=8");

            }
            catch (Exception er)
            {
                Console.Out.WriteLine($"Error: {er.Message}");
            }
            return response;
        }


        public async Task<ArtistResponse> getArtist(string _id)
        {
            ArtistResponse response = new ArtistResponse();
            try
            {
                response = await client.GetFromJsonAsync<ArtistResponse>($"artist/{_id}");
            }
            catch (Exception er)
            {
                Console.Out.WriteLine($"Error: {er.Message}");
            }

            return response;
        }


        public async Task<ArtistTopTracksResponse> getTopArtist(string _id)
        {
            ArtistTopTracksResponse response = new ArtistTopTracksResponse();
            try
            {
                response = await client.GetFromJsonAsync<ArtistTopTracksResponse>($"artist/{_id}/top");
            }
            catch (Exception er)
            {
                Console.Out.WriteLine($"Error: {er.Message}");
            }

            return response;
        }


        public async Task<SearchResponse> searchQuery(string queryString)
        {
            SearchResponse response = new SearchResponse();
            try
            {
                response = await client.GetFromJsonAsync<SearchResponse>($"search?q={queryString}");
            }
            catch (Exception er)
            {
                Console.Out.WriteLine($"Error: {er.Message}");
            }

            return response;
        }



    }


    public class Response 
    {
    public Tracks tracks { get; set; }
    
    }

    public class Tracks
    { 
    public List<Data> data { get; set; }
    }

    public class Data
    {

        public long id { get; set; }

        public string title { get; set; }

        public int position { get; set; }

        public Artist artist {get; set;}

        public Album album { get; set; }
      

    }

    public class Artist 
    {
        public long id { get; set; }
       
        public string name { get; set; }
       
        public string picture { get; set; }

        public string picture_small { get; set; }

        public string picture_medium { get; set; }

        public string picture_big { get; set; }

        public string picture_xl { get; set; }

        public string type { get; set; }
    }

    public class Album
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
