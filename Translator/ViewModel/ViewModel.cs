using System;
using System.Collections.Generic;
using System.Text;
using Translator.Tokens;

namespace Translator
{
    internal class ViewModel
    {
        public string InputText { get; set; }
        public string OutputText { get; set; }
        private readonly LexemeParser _parser;
        public ViewModel()
        {
            _parser = new LexemeParser();
        }
        public void ExecuteParsing() 
        {
            if (string.IsNullOrWhiteSpace(InputText))
            {
                OutputText = "Введите код программы";
                return;
            }

            try
            {
                List<Token> tokens = _parser.Parse(InputText);
                //OutputText = FormatTokens(tokens);
            }
            catch (Exception ex)
            {
                OutputText = ex.Message;
            }
        }

        //private string FormatTokens(List<Token> tokens)
        //{
        //    foreach (var token in tokens)
        //    {

        //    }
        //}
    }
}
