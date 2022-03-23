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
    public interface ISWPersonLogic
    {
        public Task Setup();

        public  Task<dynamic> GetWPeople(string page);

        public Task<List<SWPerson>> GetItems();


        public dynamic Search(string query);


    }
}
