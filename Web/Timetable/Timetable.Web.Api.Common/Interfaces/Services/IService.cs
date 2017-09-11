using System.Linq;
namespace Timetable.Web.Api.Common.Interfaces.Services
{
    public interface IService<out T>
    {
        IQueryable<T> All();
        T GetById(long id);
        bool Delete(long id);
    }
}
