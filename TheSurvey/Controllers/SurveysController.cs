using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSurvey.Db.Repository.Specifications;
using TheSurvey.Db.Repository.Specifications.Surveys;
using TheSurvey.Entities;
using TheSurvey.Services.Surveys;

namespace TheSurvey.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveysService _surveysService;

        public SurveysController(ISurveysService surveysService)
        {
            _surveysService = surveysService;
        }

        [Authorize]
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Create()
        {
            try
            {
                var id = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
                if (String.IsNullOrEmpty(id))
                {
                    return Unauthorized();
                }
                using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    string json = await reader.ReadToEndAsync();
                    Survey question = JsonConvert.DeserializeObject<Survey>(json);

                    await _surveysService.Create(question);
                }
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var id = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
                if (String.IsNullOrEmpty(id))
                {
                    return Unauthorized();
                }

                var ids = new { Ids = new List<Guid>() };
                string json;

                using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    json = await reader.ReadToEndAsync();
                    ids = JsonConvert.DeserializeAnonymousType(json, ids);
                }
                List<Survey> result;
                if (!string.IsNullOrEmpty(json))
                {
                    result = await _surveysService.Get(new GetSurveysByIdsSpec(ids.Ids));
                }
                else
                {
                    result = await _surveysService.Get(new Specification<Survey>((survey) => true));
                }
                return Ok(result);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAnswers()
        {
            try
            {
                var id = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
                if (String.IsNullOrEmpty(id))
                {
                    return Unauthorized();
                }

                var ids = new { Ids = new List<Guid>() };
                var result = await _surveysService.Get(new GetSurveysByIdsSpec(ids.Ids));
                return Ok(result);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Update(Guid surveyId)
        {
            try
            {
                var id = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
                if (String.IsNullOrEmpty(id))
                {
                    return Unauthorized();
                }
                var updateDefinition = new
                {
                    Name = "",
                    IsArchieve = false
                };
                using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    string json = await reader.ReadToEndAsync();
                    updateDefinition = JsonConvert.DeserializeAnonymousType(json, updateDefinition);

                    await _surveysService.Update(new GetSurveysByIdsSpec(new List<Guid>() { surveyId }),
                        (survey) =>
                        {
                            survey.Name = updateDefinition.Name;
                            survey.IsArchieve = updateDefinition.IsArchieve;
                        });
                }
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(Guid surveyId)
        {
            try
            {
                var id = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
                if (String.IsNullOrEmpty(id))
                {
                    return Unauthorized();
                }
                await _surveysService.Delete(new GetSurveysByIdsSpec(new List<Guid>() { surveyId }));
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message + "\n" + err.InnerException);
            }
        }
    }
}
