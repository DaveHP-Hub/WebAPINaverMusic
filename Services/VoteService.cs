using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI_NaverMusic.IServices;
using webAPI_NaverMusic.Models;

namespace webAPI_NaverMusic.Services
{
    public class VoteService: IVote
    {
        BDNaverMusicContext dbContext;

        public VoteService(BDNaverMusicContext _db)
        {
            dbContext = _db;
        }

        public IQueryable<Tuple<string, int, string>> GetVotes(string typeVote, string nameapi)
        {
            string sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            string day_ = datevalue.Day.ToString();
            string year_ = datevalue.Year.ToString();
        
           
             var dataVote = dbContext.Votes.Where(group => group.TypeVote == typeVote && group.Apiname == nameapi && group.DateVote.Value.Year == Convert.ToInt32(year_) && group.DateVote.Value.Day == Convert.ToInt32(day_))
                           .GroupBy(voteInfo => voteInfo.NameVote)
                           .OrderByDescending(group => group.Count())
                           .Select(group => Tuple.Create(group.Key, group.Count(), typeVote));

            return (IQueryable<Tuple<string,int, string>>)dataVote;
        }

        public IQueryable<Tuple<string, int, string>> GetVotesM(string typeVote, string nameapi)
        {
            string sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            string month_ = datevalue.Month.ToString();
            string year_ = datevalue.Year.ToString();


            var dataVote = dbContext.Votes.Where(group => group.TypeVote == typeVote && group.Apiname == nameapi && group.DateVote.Value.Year == Convert.ToInt32(year_) && group.DateVote.Value.Month == Convert.ToInt32(month_))
                          .GroupBy(voteInfo => voteInfo.NameVote)
                          .OrderByDescending(group => group.Key)
                          .Select(group => Tuple.Create(group.Key, group.Count(), typeVote));

            return (IQueryable<Tuple<string, int, string>>)dataVote;
        }

        public Vote AddVote(Vote vote_)
        {
            if (vote_ != null)
            {
                dbContext.Votes.Add(vote_);
                dbContext.SaveChanges();
                return vote_;
            }
            return null;

        }

      public  IQueryable<Tuple<string, int, string>> DeleteVote(string typeVote, string nameapi)
        {
            string sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            string month_ = datevalue.Month.ToString();
            string year_ = datevalue.Year.ToString();


            var dataVote = dbContext.Votes.Where(group => group.TypeVote == typeVote && group.Apiname == nameapi && group.DateVote.Value.Year == Convert.ToInt32(year_) && group.DateVote.Value.Month == Convert.ToInt32(month_))
                          .GroupBy(voteInfo => voteInfo.NameVote)
                          .OrderByDescending(group => group.Key)
                          .Select(group => Tuple.Create(group.Key, group.Count(), typeVote));

            return (IQueryable<Tuple<string, int, string>>)dataVote;
        }


     
        public IEnumerable<Vote> GetVotesDay(string typeVote, string nameapi)
        {

            DateTime _day = new DateTime();
            DateTime _year = new DateTime();
            int day_ = _day.Day;
            int year_ = _year.Year;
            var dataVote = dbContext.Votes.Where(group => group.TypeVote == typeVote && group.Apiname == nameapi && group.DateVote.Value.Year == year_ && group.DateVote.Value.Day == day_)
                           .GroupBy(voteInfo => voteInfo.NameVote)
                           .OrderByDescending(group => group.Key)
                           .Select(group => Tuple.Create(group.Key, group.Count())).ToList();

              return (IEnumerable<Vote>)dataVote;

        }

    }
}
