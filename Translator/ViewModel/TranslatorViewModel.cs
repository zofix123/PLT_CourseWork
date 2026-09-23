using System;
using System.Collections.Generic;
using System.Text;
using Translator.Model;
using Translator.Model.Tokens;

namespace Translator.ViewModel
{
    public class TranslatorViewModel
    {
        private readonly MainForm _view;

        private readonly LexemeParser _parser;
        public TranslatorViewModel(MainForm view, LexemeParser parser)
        {
            _parser = parser;
            _view = view;

            _view.CodeExecuted += ExecuteParsing;
        }
        public void ExecuteParsing(string code) 
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                _view.SetOutput("Введите код программы");
                return;
            }

            try
            {
                List<Token> tokens = _parser.Parse(code);
                _view.SetOutput(FormatTokens(tokens));
            }
            catch (Exception ex)
            {
                _view.SetOutput(ex.Message);
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
