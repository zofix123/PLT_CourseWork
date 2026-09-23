using System;
using System.Collections.Generic;
using System.Text;
using Translator.Model;
using Translator.Model.Tokens;

namespace Translator.ViewModel
{
    public class TranslatorViewModel
    {
        public string InputText { get; set; }
        public string OutputText { get; set; }
        private readonly LexemeParser _parser;
        public TranslatorViewModel()
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
                OutputText = FormatTokens(tokens);
            }
            catch (Exception ex)
            {
                OutputText = ex.Message;
            }
        }

        private string FormatTokens(List<Token> tokens)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Лексический анализ выполнен успешно. Найдены токены:");
            foreach (var token in tokens)
            {
                sb.AppendLine($"[{token.ToString()}] : {token.GetType().Name}");
            }
            return sb.ToString();
        }
    }
}
