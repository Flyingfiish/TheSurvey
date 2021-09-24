using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSurvey.Db.Repository.Specifications;

namespace TheSurvey.Db.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        public Task Create(T item);
        public Task<T> ReadOne(Specification<T> spec);
        public Task<List<T>> ReadMany(Specification<T> spec);
        public Task Update(Specification<T> spec, Action<T> func);
        public Task Delete(Specification<T> spec);
    }
}
