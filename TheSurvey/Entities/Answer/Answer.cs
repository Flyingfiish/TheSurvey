using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSurvey.Entities
{
    public class Answer
    {
        public Guid Id { get; set; }
        public Guid VariantId { get; set; }
        public Variant Variant {get;set;}
        public string Text { get; set; }
    }
}
