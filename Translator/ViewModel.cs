using System;
using System.Collections.Generic;
using System.Text;

namespace Translator
{
    internal class ViewModel
    {
        public string InputText { get; set; }
        public string OutputText { get; set; }
        private readonly LexemeParser _parser;
        public void ExecuteParsing() 
        {

        }
    }
}
