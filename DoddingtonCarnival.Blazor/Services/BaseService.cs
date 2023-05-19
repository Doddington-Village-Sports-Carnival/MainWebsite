using DoddingtonCarnival.Blazor.Models;
using Newtonsoft.Json;

namespace DoddingtonCarnival.Blazor.Services
{
    public abstract class BaseService<T> where T : BaseClass
    {
        protected static IEnumerable<T>? dataCache = null;
        protected static DateTime? cacheExpiry = null;

        protected IEnumerable<T>? GetMaster(DataTypes dataType)
        {
            if (dataCache != null && DateTime.UtcNow <= cacheExpiry)
            {
                return dataCache;
            }

            var dataTypeName = dataType.ToString().ToLower();

            string filename = $"Data/{dataTypeName}.json";

            string? fileContents;

            try
            {
                fileContents = File.ReadAllText(filename);
            }
            catch
            {
                return null;
            }

            var data = JsonConvert.DeserializeObject<MasterData>(fileContents);

            if (data == null)
            {
                return null;
            }

            var results = new List<T>();

            foreach (var item in data.Files)
            {
                var kkk = this.GetReal(dataType, item);

                if (kkk == null)
                {
                    continue;
                }

                results.AddRange(kkk);
            }

            dataCache = results;
            cacheExpiry = DateTime.UtcNow.AddDays(1);

            return dataCache;
        }

        private IEnumerable<T>? GetReal(DataTypes dataType, int year)
        {
            if (year <= 0)
            {
                return null;
            }

            var fff = dataType.ToString().ToLower();

            string filename = $"Data/{year}/{year}_{fff}.json";

            try
            {
                var json = File.ReadAllText(filename);

                return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        protected bool WriteFile(DataTypes dataType, int year, IEnumerable<BaseClass>? list)
        {
            if (year <= 0 || list == null)
            {
                return false;
            }

            var fff = dataType.ToString().ToLower();

            string filename = $"Data/{year}/{year}_{fff}.json";

            var json = JsonConvert.SerializeObject(list);

            try
            {
                File.WriteAllText(filename, json);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        protected enum DataTypes
        {
            Calendar,
            Scarecrow,
            FanceDress,
            Float,
            PrincePrincess
        }
    }
}
