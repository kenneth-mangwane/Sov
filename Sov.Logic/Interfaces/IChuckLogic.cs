using Sov.Common;
using Sov.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sov.Logic
{
    public interface IChuckLogic
    {
        public Task Setup();


        public Task<List<string>> GetChuckCategories();
        public Task<ChuckJoke> GetJoke(string category);

        public dynamic Search(string query);


    }
}
