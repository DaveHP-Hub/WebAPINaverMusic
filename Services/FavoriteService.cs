using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI_NaverMusic.IServices;
using webAPI_NaverMusic.Models;

namespace webAPI_NaverMusic.Services
{
    public class FavoriteService: IFavorite
    {
        BDNaverMusicContext dbContext;

        public FavoriteService(BDNaverMusicContext _db)
        {
            dbContext = _db;
        }

        //GET ALL FAVORITES
        public IEnumerable<Favorite> GetFavorites()
        {
            var favorite_ = dbContext.Favorites.ToList();
            return favorite_;
        }

        //ADD OR CREATE NEW FAVORITE 
        public Favorite AddFavorite(Favorite _fav)
        {
            if (_fav != null)
            {
                dbContext.Favorites.Add(_fav);
                dbContext.SaveChanges();
                return _fav;
            }

            return null;
        }

        public Favorite DeleteFavorite(int id)
        {
            var fav = dbContext.Favorites.FirstOrDefault(x => x.IdFavorite == id);
            if (fav != null)
            {
                dbContext.Entry(fav).State = EntityState.Deleted;
                dbContext.SaveChanges();
                return fav;
            }

            return null;
        
        }

        public IEnumerable<Favorite> GetFavotiresByIdUser(int _idUser, string _type)
        {
            var fav = dbContext.Favorites.Where(x => x.IdUser == _idUser && x.Apiname== "deezer" && x.TypeFav == _type).ToList();
            if (fav != null)
            {
                return fav;
            }
            return null;
        }

        public IEnumerable<Favorite> GetFavotiresByIdUserS(int _idUser, string type_)
        {
            var fav = dbContext.Favorites.Where(x => x.IdUser == _idUser && x.Apiname == "spotify" && x.TypeFav == type_ ).ToList();
            if (fav != null)
            {
                return fav;
            }
            return null;
        }

        public IEnumerable<Vote> GetVotesD(string typeVote, string nameapi)
        {

            DateTime _day = new DateTime();
            DateTime _year = new DateTime();
            int day_ = 6;
            int year_ = 2020;
            var dataVote = dbContext.Votes.Where(group => group.TypeVote == typeVote && group.Apiname == nameapi && group.DateVote.Value.Year == year_ && group.DateVote.Value.Day == day_)
                           .GroupBy(voteInfo => voteInfo.NameVote)
                           .OrderByDescending(group => group.Key)
                           .Select(group => Tuple.Create(group.Key, group.Count())).ToList();

            return (IEnumerable<Vote>)dataVote.ToList();

        }



    }
}
