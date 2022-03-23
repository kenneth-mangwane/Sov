using Sov.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sov.Logic
{
    public class ChuckLogic : LogicBase<ChuckCategory>, IChuckLogic
    {

        public ChuckLogic()
        {
            Base = "https://api.chucknorris.io/jokes/";
            Path = "categories";
            Setup().Wait();

        }

        public Task<List<string>> GetChuckCategories()
        {
            return this.GetItems<string>("categories");

        }



        public Task<ChuckJoke> GetJoke(string category)
        {
            return this.GetItem<ChuckJoke>("random?category=" + category);
        }

        public dynamic Search(string query)
        {
            return this.GetDynamicItem("search?query=" + query);
        }
    }
}
