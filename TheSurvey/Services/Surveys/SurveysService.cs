using AutoMapper;
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
        private readonly IMapper _mapper;

        public SurveysService(IRepository<Survey> surveysRepository, IMapper mapper)
        {
            _surveysRepository = surveysRepository;
            _mapper = mapper;
        }

        public async Task Create(Survey survey)
        {
            await _surveysRepository.Create(survey);
        }



        public async Task Delete(Specification<Survey> spec)
        {
            await _surveysRepository.Delete(spec);
        }

        public async Task<List<SurveyDto>> Get(Specification<Survey> spec)
        {
            var surveys = await _surveysRepository.ReadMany(spec);
            return _mapper.Map<List<SurveyDto>>(surveys);
        }

        public async Task Update(Specification<Survey> spec, Action<Survey> func)
        {
            await _surveysRepository.Update(spec, func);
        }
    }
}
