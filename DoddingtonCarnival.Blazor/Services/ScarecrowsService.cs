using DoddingtonCarnival.Blazor.Interfaces;
using DoddingtonCarnival.Blazor.Models;

namespace DoddingtonCarnival.Blazor.Services
{
    public class ScarecrowsService : BaseService<CarnivalImage>, IBaseService
    {
        public IEnumerable<CarnivalImage>? GetAll()
        {
            return GetMaster(DataTypes.Scarecrow);
        }
    }
}