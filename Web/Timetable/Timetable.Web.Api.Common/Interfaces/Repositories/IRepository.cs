using System.Linq;
namespace Timetable.Web.Api.Common.Interfaces.Repositories
{
    public interface IRepository<out T>
    {
        IQueryable<T> All();
        T GetById(long id);
        bool Delete(long id);
    }
}
