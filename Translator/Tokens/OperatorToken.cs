using System;
using System.Collections.Generic;
using System.Text;

namespace Translator.Tokens
{
    public class OperatorToken : Token
    {
        public OperatorType Operator { get; }

        public OperatorToken(string lexeme, OperatorType oper) : base(lexeme)
        {
            Operator = oper;
        }

        public static readonly Dictionary<OperatorType, string> OperatorTypesNames = new()
        {
            { OperatorType.Plus, "+" },
            { OperatorType.Minus, "-" },
            { OperatorType.Divide, "/" },
            { OperatorType.Multiply, "*" },
            { OperatorType.Assign, "=" }
        };

        public static string OperatorTypeToString(OperatorType type) => OperatorTypesNames[type];
        public static OperatorType? StringToOperatorType(string str)
        {
            foreach (var type in OperatorTypesNames)
                if (type.Value == str)
                    return type.Key;
            return null;
        }
    }

    public enum OperatorType
    {
        Plus,
        Minus,
        Divide,
        Multiply,
        Assign
    }
 
}
