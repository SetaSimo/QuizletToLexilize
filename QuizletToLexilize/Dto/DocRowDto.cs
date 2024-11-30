using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizletToLexilize.Dto
{
    public class DocRowDto
    {
        public DocRowDto(string russianWord, string japaneseWord)
        {
            RussianWord = russianWord;
            JapaneseWord = japaneseWord;
        }

        public string RussianWord { get; set; }
        public string JapaneseWord { get; set; }
    }
}
