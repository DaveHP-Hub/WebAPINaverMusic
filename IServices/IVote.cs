using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI_NaverMusic.Models;

namespace webAPI_NaverMusic.IServices
{
    public interface IVote
    {

       
        IQueryable<Tuple<string,int, string>> GetVotes(string type_, string apiname);
        Vote AddVote(Vote vote_);
        IQueryable<Tuple<string, int, string>> DeleteVote(string type, string apiname);
      
        
        //Vote SPMonthVote();

    }
}
