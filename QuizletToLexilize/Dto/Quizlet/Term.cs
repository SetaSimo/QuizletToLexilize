using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizletToLexilize.Dto.Quizlet
{
    public class Term
    {
        public int Type { get; set; }
        public bool IsDeleted { get; set; }
        public List<CardSide> CardSides { get; set; }
    }
}
