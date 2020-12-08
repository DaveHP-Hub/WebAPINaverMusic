using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI_NaverMusic.IServices;

namespace webAPI_NaverMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {

        private readonly IVotes voteService;

        public VotesController(IVotes vote_)
        {
            voteService = vote_;
        }


        [HttpGet]
        [Route("[action]")]
        [Route("api/Votes/GetTuples")]
        public IQueryable<Tuple<string, int, string>> GetTuples(string typeVote, string apiname)
        {
            return voteService.GetTuples(typeVote, apiname);
        }



    }
}
