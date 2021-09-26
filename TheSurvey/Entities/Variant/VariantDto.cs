using System;
using System.Collections.Generic;

namespace TheSurvey.Entities
{
    public class VariantDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
