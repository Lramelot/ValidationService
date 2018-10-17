using System.Collections;
using System.Collections.Generic;

namespace ServiceValidation.Presentation.Models.Article
{
    public class Index
    {
        public IEnumerable<Core.Domain.Article> Articles { get; set; }
    }
}