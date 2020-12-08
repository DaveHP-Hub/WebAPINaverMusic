using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace webAPI_NaverMusic
{
    public class TopAlbums
    {
        public HttpClient client;
        private readonly string url = "https://api.deezer.com/";
        private readonly string token = "myToken";

        public TopAlbums()
        {
            client = new HttpClient {
            BaseAddress = new Uri(url)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("access_token", token);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        
        }

        public async Task<ResponseAlbum> getAlbums()
        {
            ResponseAlbum response = new ResponseAlbum();
            try
            {
                response = await client.GetFromJsonAsync<ResponseAlbum>("playlist/3155776842?limit=8");
            }
            catch (Exception err)
            {
                Console.Out.WriteLine($"Error: {err.Message}");
            }
            return response;
        
        }

    }


    public class ResponseAlbum
    {
        public Tracks tracks { get; set; }
    }



}
