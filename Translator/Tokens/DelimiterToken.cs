using System;
using System.Collections.Generic;
using System.Text;

namespace Translator.Tokens
{
    public class DelimiterToken : Token
    {
        private DelimiterType Delimiter;

        public DelimiterToken(string lexeme, DelimiterType delimiter) : base(lexeme)
        {
            Delimiter = delimiter;
        }

        public static readonly Dictionary<DelimiterType, string> DelimiterTypesNames = new()
        {
            { DelimiterType.LeftBracket, "(" },
            { DelimiterType.RightBracket, ")" },
            { DelimiterType.Colon, ":" },
            { DelimiterType.Semicolon, ";" },
            { DelimiterType.Comma, "," }

        };

        public static string DelimiterTypeToString(DelimiterType type) => DelimiterTypesNames[type];
        public static DelimiterType? StringToDelimiterType(string str)
        {
            foreach (var type in DelimiterTypesNames)
                if (type.Value == str)
                    return type.Key;
            return null;
        }

    }
    public enum DelimiterType
    {
        LeftBracket,
        RightBracket,
        Colon,
        Semicolon,
        Comma
    }

}
