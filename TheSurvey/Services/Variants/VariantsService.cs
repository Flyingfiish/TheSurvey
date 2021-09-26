using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSurvey.Db.Repository;
using TheSurvey.Db.Repository.Specifications;
using TheSurvey.Entities;

namespace TheSurvey.Services.Variants
{
    public class VariantsService : IVariantsService
    {
        private readonly IRepository<Variant> _variantsRepository;

        public VariantsService(IRepository<Variant> variantsRepository)
        {
            _variantsRepository = variantsRepository;
        }
        public async Task Create(Variant variant)
        {
            await _variantsRepository.Create(variant);
        }

        public Task Delete(Specification<Variant> spec)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Variant>> Get(Specification<Variant> spec)
        {
            return await _variantsRepository.ReadMany(spec);
        }

        public Task Update(Specification<Variant> spec, Action<Variant> func)
        {
            throw new NotImplementedException();
        }
    }
}
