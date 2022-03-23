using Sov.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sov.Logic
{
    public class SWPersonLogic : LogicBase<SWPerson>, ISWPersonLogic
    {
        public SWPersonLogic()
        {
            Base = "https://swapi.dev/api/";
            Path = "people/";
            Setup().Wait();

        }

        public async Task<dynamic> GetWPeople(string page = "1")
        {
            return await this.GetDynamicItem("people/?page=" + page);

        }
        public dynamic Search(string query)
        {
            return this.GetDynamicItem("people/?search=" + query);
        }
    }
}
