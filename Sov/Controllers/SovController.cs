using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sov.Common;
using Sov.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sov.Controllers
{
    [ApiController]
    [Route("api")]
    public class SovController : ControllerBase
    {
        
        private readonly IChuckLogic _chuckLogic;
        private readonly ISWPersonLogic _swPersonLogic;

        public SovController(IChuckLogic chuckLogic, ISWPersonLogic swPersonLogic)
        {
            _chuckLogic = chuckLogic;
            _swPersonLogic = swPersonLogic;
        }

        [HttpGet("/chuck/categories")]
        public async Task<ActionResult<ChuckCategory>> GetChuckCategories()
        {
            return Ok(await _chuckLogic.GetChuckCategories());
        }

        [HttpGet("/chuck")]
        public async Task<ActionResult<ChuckCategory>> GetChuckJoke(string category)
        {
            return Ok(await _chuckLogic.GetJoke(category));
        }

        [HttpGet("/swapi/people")]
        public async Task<ActionResult<SWPerson>> Swapi(string page = "1")
        {
            return Ok(await _swPersonLogic.GetWPeople(page));
        }

        [HttpGet("/search")]
        public async Task<ActionResult<SWPerson>> Search(string query )
        {
            var result = new
            {
                jokes = await _chuckLogic.Search(query),
                people = await _swPersonLogic.Search(query)
            };
            return Ok(result);
        }

    }
}
