using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace webAPI_NaverMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeezerController : ControllerBase
    {

        Chart client = new Chart();
        TopAlbums _res = new TopAlbums();


        //GET CHARTS OF THE MOMENT
        [HttpGet]
        [Route("getCharts")]
        public Task<Response> getResult()
        {

            Task<Response> response = client.getChart();
            return response;
        }



        //GET ARTISTA
        [HttpGet]
        [Route("getArtistId")]
        public Task<ArtistResponse> getArtist(string id_)
        {
            Task<ArtistResponse> response = client.getArtist(id_);
            return response;
        }



        //GET TOP TRACKS FOR ARTIST
        [HttpGet]
        [Route("getArtistTop")]
        public Task<ArtistTopTracksResponse> getTopArtist(string id_)
        {
            Task<ArtistTopTracksResponse> response = client.getTopArtist(id_);
            return response;
        }




        //QUERY SEARCH ALL
        [HttpGet]
        [Route("search")]
        public Task<SearchResponse> getSearch(string q)
        {
            Task<SearchResponse> response = client.searchQuery(q);
            return response;
        }

        [HttpGet]
        [Route("getAlbums")]
        public Task<ResponseAlbum> getAlbums()
        {
            Task<ResponseAlbum> albums = _res.getAlbums();
            return albums;

        }




    }
}
