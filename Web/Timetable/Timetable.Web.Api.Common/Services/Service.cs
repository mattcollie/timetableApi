using System.Linq;
using Timetable.Web.Api.Common.Interfaces.Services;
using Timetable.Web.Api.Common.Interfaces.Repositories;

namespace Timetable.Web.Api.Common.Services
{
    public class Service<T> : IService<T> where T : class
    {
        public Service(IRepository<T> repository)
        {
            Repository = repository;
        }

        protected IRepository<T> Repository { get; set; }

        public bool Delete(long id)
        {
            return Repository.Delete(id);
        }

        public IQueryable<T> All()
        {
            return Repository.All();
        }

        public T GetById(long id)
        {
            return Repository.GetById(id);
        }
    }
}
