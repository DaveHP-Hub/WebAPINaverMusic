using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI_NaverMusic.IServices;
using webAPI_NaverMusic.Models;

namespace webAPI_NaverMusic.Services
{
    public class VotesService: IVotes
    {
        BDNaverMusicContext dbContext;
        public VotesService(BDNaverMusicContext _db)
        {
            dbContext = _db;
        }

        public IQueryable<Tuple<string, int, string>> GetTuples(string typeVote, string nameapi)
        {
            string sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            string month_ = datevalue.Month.ToString();
            string year_ = datevalue.Year.ToString();


            var dataVote = dbContext.Votes.Where(group => group.TypeVote == typeVote && group.Apiname == nameapi && group.DateVote.Value.Year == Convert.ToInt32(year_) && group.DateVote.Value.Month == Convert.ToInt32(month_))
                          .GroupBy(voteInfo => voteInfo.NameVote)
                          .OrderByDescending(group => group.Count())
                          .Select(group => Tuple.Create(group.Key, group.Count(), typeVote));

            return (IQueryable<Tuple<string, int, string>>)dataVote;

        }



    }
}
