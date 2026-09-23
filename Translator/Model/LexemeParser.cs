using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Translator.Model.Tokens;

namespace Translator.Model
{
    public class LexemeParser
    {

        public List<Token> Parse(string inputString)
        {
            inputString = inputString.Replace("\n", " ");
            inputString = inputString.Replace("\t", " ");
            inputString = inputString.Replace("\r", " ");
            inputString = inputString.Replace("(", " ( ");
            inputString = inputString.Replace(")", " ) ");
            inputString = inputString.Replace(":", " : ");
            inputString = inputString.Replace(";", " ; ");
            inputString = inputString.Replace(",", " , ");
            inputString = inputString.Replace("=", " = ");
            while (inputString.Contains("  "))
            {
                inputString = inputString.Replace("  ", " ");
            }

            string[] tokenList = inputString.Split(" ");
            List<Token> resultList = new List<Token>();
            foreach (string token in tokenList) 
            {
                if (KeywordToken.StringToKeywordType(token) is KeywordType keywordType)
                {
                    resultList.Add(new KeywordToken(token, keywordType));
                    continue;
                }

                if (OperatorToken.StringToOperatorType(token) is OperatorType operatorType)
                {
                    resultList.Add(new OperatorToken(token, operatorType));
                    continue;
                }

                if (DelimiterToken.StringToDelimiterType(token) is DelimiterType delimiterType)
                {
                    resultList.Add(new DelimiterToken(token, delimiterType));
                    continue;
                }

                if (int.TryParse(token, out int value))
                {
                    resultList.Add(new IntegerToken(token));
                    continue;
                }
                
                if (Regex.IsMatch(token, @"^[a-zA-Z]+$"))
                {
                    if (token.Length > 9)
                        throw new Exception("Ошибка: Имя переменной превышает допустимый размер");

                    resultList.Add(new VarToken(token));
                    continue;
                }

                throw new Exception("Ошибка: Некорректное имя переменной");
            }
            return resultList;
        }
    }
}
