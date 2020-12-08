using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI_NaverMusic.IServices
{
   public interface IVotes
    {
        IQueryable<Tuple<string, int, string>> GetTuples(string type, string apiname);

    }
}
