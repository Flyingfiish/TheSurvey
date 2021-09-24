using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSurvey.Entities;
using TheSurvey.Services.Questions;
using TheSurvey.Services.Surveys;

namespace TheSurvey.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsService _questionsService;

        public QuestionsController(IQuestionsService questionsService)
        {
            _questionsService = questionsService;
        }

        [Authorize]
        [HttpPost]
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
                    Question question = JsonConvert.DeserializeObject<Question>(json);

                    await _questionsService.Create(question);
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
