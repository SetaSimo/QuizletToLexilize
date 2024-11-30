using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizletToLexilize.Dto.Quizlet
{
    public class Media
    {
        public int Type { get; set; }
        public string PlainText { get; set; }
        public string LanguageCode { get; set; }
        public string TtsUrl { get; set; }
        public string TtsSlowUrl { get; set; }
        public string RichText { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }
        public string Attribution { get; set; }
    }
}
