using DoddingtonCarnival.Blazor.Models;
using Newtonsoft.Json;

namespace DoddingtonCarnival.Blazor.Services
{
    public class CalendarService : BaseService<CalendarEntry>
    {
        private readonly HttpClient _httpClient;

        public CalendarService()
        {
            this._httpClient = new HttpClient();
        }

        public IEnumerable<CalendarEntry>? GetAll()
        {
            var content = this._httpClient.GetStringAsync("https://www.doddington.org.uk/api/calendar/Doddington%20Village%20Sports%20&%20Carnival").Result;

            return JsonConvert.DeserializeObject<IEnumerable<CalendarEntry>>(content);
        }

        public IEnumerable<CalendarEntry>? GetAll(int year)
        {
            return GetAll()?.Where(x => x.StartDateTime.Year == year);
        }

        public IEnumerable<CalendarEntry>? GetAll(string tag)
        {
            return GetAll()?.Where(x => x.StartDateTime.Year >= DateTime.Now.Year && x.Tags.Contains(tag));
        }

        public IEnumerable<CalendarEntry>? GetAll(int year, string tag)
        {
            return GetAll()?.Where(x => x.StartDateTime.Year == year && x.Tags.Contains(tag));
        }

        public CalendarEntry? GetNext(string? tag = null)
        {
            if (string.IsNullOrEmpty(tag))
            {
                return GetAll()?.FirstOrDefault(x => x.StartDateTime >= DateTime.Now);
            }

            return GetAll()?.FirstOrDefault(x => x.Tags.Contains(tag) && x.StartDateTime >= DateTime.Now);
        }
    }
}