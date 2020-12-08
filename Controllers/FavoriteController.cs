using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI_NaverMusic.IServices;
using webAPI_NaverMusic.Models;

namespace webAPI_NaverMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavorite favoriteService;
    
        public FavoriteController(IFavorite fav_)
        {
            favoriteService = fav_;
        }

        //GET ALL FAVORITES
        [HttpGet]
        [Route("[action]")]
        [Route("api/Favorite/GetFavorites")]
        public IEnumerable<Favorite> GetFavorites()
        {
            return favoriteService.GetFavorites();
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Favorite/GetFavoritesById")]
        public IEnumerable<Favorite> GetFavoritesById(int id, string _type)
        {
            return favoriteService.GetFavotiresByIdUser(id, _type);
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Favorite/GetFavoritesByIdS")]
        public IEnumerable<Favorite> GetFavoritesByIdS(int id, string type_)
        {
            return favoriteService.GetFavotiresByIdUserS(id, type_);
        }




        //ADD FAVORITE
        [HttpPost]
        [Route("[action]")]
        [Route("api/Favorite/AddFavorite")]
        public Favorite AddFavorite(Favorite _fv)
        {
            return favoriteService.AddFavorite(_fv);
        }


        //DELETE FAVORITE
        [HttpDelete]
        [Route("[action]")]
        [Route("api/Favorite/DeleteFavorite")]
        public Favorite DeleteFavorite(int id_)
        {
            return favoriteService.DeleteFavorite(id_);
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Favorite/GetVotes")]
        public IEnumerable<Vote> GetDayVotes(string type, string apiname)
        {

            return favoriteService.GetVotesD(type, apiname);
        }


    }
}
