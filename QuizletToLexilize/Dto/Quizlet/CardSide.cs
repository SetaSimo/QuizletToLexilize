using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizletToLexilize.Dto.Quizlet
{
    public class CardSide
    {
        public string Label { get; set; }
        public List<Media> Media { get; set; }
        //public List<object> Distractors { get; set; }
    }
}
