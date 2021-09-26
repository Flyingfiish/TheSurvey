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
using TheSurvey.Services.Answers;
using TheSurvey.Services.Surveys;
using TheSurvey.Services.Variants;

namespace TheSurvey.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswersService _answersService;

        public AnswersController(IAnswersService answersService)
        {
            _answersService = answersService;
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Create()
        {
            try
            {
                using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    string json = await reader.ReadToEndAsync();
                    Answer answer = JsonConvert.DeserializeObject<Answer>(json);

                    await _answersService.Create(answer);
                }
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}