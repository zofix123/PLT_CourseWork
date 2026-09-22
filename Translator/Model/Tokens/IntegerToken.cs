using System;
using System.Collections.Generic;
using System.Text;

namespace Translator.Model.Tokens
{
    public class IntegerToken(string lexeme) : Token(lexeme)
    {
        public int Value { get; } = int.Parse(lexeme);
    }
}
