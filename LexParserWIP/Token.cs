using System;
namespace LexParserWIP
{
    public enum TokenCode
    {
        Keyword,
        Identifier,
        Number,
        Delimiter,
        Operator
    }
    public class Token
    {
        private string _str;
        private TokenCode _code;

        public Token(string str, TokenCode code)
        {
            _str = str;
            _code = code;
        }

        public string TokenString()
        {
            return _str;
        }

        public TokenCode GetTokCode()
        {
            return _code;
        }
    }
}
