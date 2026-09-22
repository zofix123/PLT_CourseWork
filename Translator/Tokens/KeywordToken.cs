using System;
using System.Collections.Generic;
using System.Text;

namespace Translator.Tokens
{
    public class KeywordToken : Token
    {
        public KeywordType Keyword { get; }

        public KeywordToken(string lexeme, KeywordType keyword) : base(lexeme)
        {
            Keyword = keyword;
        }

        public static readonly Dictionary<KeywordType, string> KeywordTypesNames = new()
        {
            { KeywordType.Var, "VAR" },
            { KeywordType.Integer, "INTEGER" },
            { KeywordType.Begin, "BEGIN" },
            { KeywordType.End, "END" },
            { KeywordType.Read, "READ" },
            { KeywordType.Case, "CASE" },
            { KeywordType.Of, "OF" },
            { KeywordType.Write, "WRITE" },
        };

        public static string KeywordTypeToString(KeywordType type) => KeywordTypesNames[type];
        public static KeywordType? StringToKeywordType(string str)
        {
            foreach (var type in KeywordTypesNames)
                if (type.Value == str)
                    return type.Key;
            return null;
        }


    }
    public enum KeywordType
    {
        Var,
        Integer,
        Begin,
        End,
        Read,
        Case,
        Of,
        Write
    }


}
