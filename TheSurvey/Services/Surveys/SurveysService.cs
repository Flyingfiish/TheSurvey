using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSurvey.Db.Repository;
using TheSurvey.Db.Repository.Specifications;
using TheSurvey.Entities;

namespace TheSurvey.Services.Surveys
{
    public class SurveysService : ISurveysService
    {
        private readonly IRepository<Survey> _surveysRepository;

        public SurveysService(IRepository<Survey> surveysRepository)
        {
            _surveysRepository = surveysRepository;
        }

        public async Task Create(Survey survey)
        {
            await _surveysRepository.Create(survey);
        }



        public async Task Delete(Specification<Survey> spec)
        {
            await _surveysRepository.Delete(spec);
        }

        public async Task<List<Survey>> Get(Specification<Survey> spec)
        {
            return await _surveysRepository.ReadMany(spec);
        }

        public async Task Update(Specification<Survey> spec, Action<Survey> func)
        {
            await _surveysRepository.Update(spec, func);
        }
    }
}
