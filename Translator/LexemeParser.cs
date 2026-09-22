using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Translator.Tokens;

namespace Translator
{
    public class LexemeParser
    {

        public List<Token> Parse(string inputString)
        {
            inputString.Replace("\n", " ");
            inputString.Replace("\t", " ");
            inputString.Replace("(", " ( ");
            inputString.Replace(")", " ) ");
            inputString.Replace(":", " : ");
            inputString.Replace(";", " ; ");
            inputString.Replace(",", " , ");
            while (inputString.Contains("  "))
            {
                inputString.Replace("  ", " ");
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
                    if (token.Length > 12)
                        throw new Exception("Братан, не помещается, отрезай");

                    resultList.Add(new VarToken(token));
                }

                throw new Exception("Хуйня имя переменной еблан");
            }
            return resultList;
        }
    }
}
