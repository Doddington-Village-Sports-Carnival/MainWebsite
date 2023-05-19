using DoddingtonCarnival.Blazor.Models;

namespace DoddingtonCarnival.Blazor.Interfaces
{
    public interface IBaseService
    {
        IEnumerable<CarnivalImage>? GetAll();
    }
}