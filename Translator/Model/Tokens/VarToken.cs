using System;
using System.Collections.Generic;
using System.Text;

namespace Translator.Model.Tokens
{
    //последовательность строчных букв
    internal class VarToken(string lexeme) : Token(lexeme)
    {
        public int IndexLength { get => _lexeme.Length; }
        //public Variable Variable { get; set; }
    }
}
