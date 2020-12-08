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
    public class VoteController : ControllerBase
    {
        private readonly IVote voteService;

        public VoteController(IVote vote_)
        {
            voteService = vote_;
        }
 

        [HttpGet]
        [Route("[action]")]
        [Route("api/Vote/GetVotes")]
        public IQueryable<Tuple<string,int,string>> GetVotes(string typeVote, string apiname)
        {
            return voteService.GetVotes(typeVote, apiname);
        }

      

        [HttpPost]
        [Route("[action]")]
        [Route("api/Vote/AddVote")]
        public Vote AddVote(Vote vote)
        {
            return voteService.AddVote(vote);
        }


        [HttpDelete]
        [Route("[action]")]
        [Route("api/Vote/DeleteVote")]
        public IQueryable<Tuple<string, int, string>> GetVotesMo(string typeVote, string apiname)
        {
            return voteService.DeleteVote(typeVote, apiname);
        }


       


    }
}
