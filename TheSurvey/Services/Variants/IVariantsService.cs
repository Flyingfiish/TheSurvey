using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSurvey.Db.Repository.Specifications;
using TheSurvey.Entities;

namespace TheSurvey.Services.Variants
{
    public interface IVariantsService
    {
        public Task Create(Variant survey);

        public Task<List<Variant>> Get(Specification<Variant> spec);

        public Task Update(Specification<Variant> spec, Action<Variant> func);

        public Task Delete(Specification<Variant> spec);
    }
}
