using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sov.Common.Extensions
{
    public class SearchExtension
    {
        public static List<T> Search<T>(List<T> _objects, string SearchString = null)
        {

            try
            {

                try
                {
                    //Deep Search - 1 level in
                    _objects = (!string.IsNullOrEmpty(SearchString)) ? _objects.Where(_object => _object.GetType().GetProperties().Any(s => SearchExtension.DeepSearch(s.GetValue(_object), SearchString))).ToList() : _objects;
                }
                catch (Exception)
                {
                    try
                    {
                        _objects = (!string.IsNullOrEmpty(SearchString)) ? _objects.Where(_object => SearchExtension.AltSearch(_object, SearchString)).ToList() : _objects;
                    }
                    catch { }
                }


                return _objects;

            }
            catch (Exception)
            {
                return _objects;
            }
        }
        public static bool AltSearch(object obj, string search)
        {
            try
            {
                string str = JsonSerializer.Serialize(obj);
                return str?.ToLower()?.Contains(search?.ToLower()) == true;
            }
            catch { }
            return false;
        }
        public static bool DeepSearch<QModel>(QModel value, string search)
        {
            //Check if the neccesary variables have been set

            search = search.ToLower().Trim();
            if (value == null) return false;
            try
            {
                string val = stringify(value).ToLower().Trim();
                return val.Contains(search);
            }
            catch (Exception) { }

            return false;
        }
        public static string stringify<QEntity>(QEntity entity)
        {

            var type = entity.GetType().FullName;
            if (type.ToLower().Contains("system."))
            {
                return entity.ToString();
            }

            PropertyInfo[] _PropertyInfos = null;

            _PropertyInfos = entity.GetType().GetProperties();

            var sb = new StringBuilder();

            foreach (var info in _PropertyInfos)
            {
                var value = info.GetValue(entity, null) ?? "(null)";
                sb.AppendLine(info.Name + ":" + value.ToString());
            }

            return sb.ToString();
        }
    }
}
