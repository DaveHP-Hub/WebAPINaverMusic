using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI_NaverMusic.Models;

namespace webAPI_NaverMusic.IServices
{
    public interface IFavorite
    {
        IEnumerable<Favorite> GetFavorites();
        Favorite AddFavorite(Favorite fav);
        Favorite DeleteFavorite(int id);
        IEnumerable<Favorite>  GetFavotiresByIdUser(int idUser_, string _type);
        IEnumerable<Favorite> GetFavotiresByIdUserS(int idUser_, string type_);
        IEnumerable<Vote> GetVotesD(string type, string apiname);




    }
}
