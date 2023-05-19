using DoddingtonCarnival.Blazor.Models;

namespace DoddingtonCarnival.Blazor.Services
{
    public class CalendarService : BaseService<CalendarEntry>
    {
        public void Export(int year)
        {
            var list = this.GetAll(year);

            var orderedList = list?.OrderBy(x => x.Start).ThenBy(x => x.End);

            base.WriteFile(DataTypes.Calendar, year, orderedList);
        }

        public IEnumerable<CalendarEntry>? GetAll()
        {
            return GetMaster(DataTypes.Calendar);
        }

        public IEnumerable<CalendarEntry>? GetAll(int year)
        {
            return GetAll()?.Where(x => x.Start.Year == year);
        }

        public IEnumerable<CalendarEntry>? GetAll(string tag)
        {
            return GetAll()?.Where(x => x.Start.Year == DateTime.Now.Year && x.Tags.Contains(tag));
        }

        public CalendarEntry? GetNext(string? tag = null)
        {
            if (string.IsNullOrEmpty(tag))
            {
                return GetAll()?.FirstOrDefault(x => x.Start >= DateTime.Now);
            }

            return GetAll()?.FirstOrDefault(x => x.Tags.Contains(tag) && x.Start >= DateTime.Now);
        }
    }
}