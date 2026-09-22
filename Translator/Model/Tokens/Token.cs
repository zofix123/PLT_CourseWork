using System;
using System.Collections.Generic;
using System.Text;

namespace Translator.Model.Tokens
{
    public abstract class Token(string lexeme)
    {
        protected readonly string _lexeme = lexeme;
    }
}
