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
    public abstract class LogicBase<T>
    {
        protected string Path;
        protected string Base;
        static HttpClient Client = new HttpClient();
        public static List<T> Items;

        public async Task Setup()
        {
            try
            {
                Client.BaseAddress = new Uri(Base);
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            catch { }
        }

        public async Task<List<T>> GetItems()
        {
            if (Items == null)
            {
                HttpResponseMessage response = await Client.GetAsync(Path);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<T>>(result);

                    return Items;
                }
            }
            return Items;
        }

        public async Task<dynamic> GetDynamicItem(string path)
        {
            HttpResponseMessage response = await Client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<dynamic>(res);
            }
            return null;
        }

        public async Task<List<Z>> GetItems<Z>(string path)
        {
            List<Z> result = new List<Z>();
            HttpResponseMessage response = await Client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<List<Z>>(res);
            }
            return result;
        }
        public async Task<Z> GetItem<Z>(string path)
        {
            HttpResponseMessage response = await Client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Z>(res);
            }
            return default(Z);
        }

        public List<T> Search(string query)
        {
            return SearchExtension.Search(Items, query);
        }

    }
}
