using System;
using System.IO;

namespace LexParserWIP
{
    public class LexicalParser
    {
        Stream textStream;
        
        String[] Operators = new String[30] { "=", "<=", "<", ">", ">=", "!=", "?", "+", "?", ";", "-", "=", "*", "/",
        "++", "--", "+=", "-=", "*=", "/=", "&&", "||", "~", "!", "&", "&=", "|=", "~=", "^", "^="};
        string[] keywords = { "define", "thing", "template", "point", "int", "double", "float", "short", "byte",  "ushort", "sbyte", "uint"};

        public LexicalParser(Stream textStream)
        {
            this.textStream = textStream;
        }

        public Token GetNext()
        {
            TokenCode tokType = TokenCode.Operator;
            StreamReader sr = new StreamReader(textStream);
            String finalTokenStr = "";
            char firstChar;
            char nextLetter;
            do
            {
                firstChar = (char)sr.Read();
            } while (firstChar == ' ');
            finalTokenStr += firstChar;
            if (Char.IsLetter(firstChar) || firstChar.Equals('_'))
            {
                tokType = TokenCode.Identifier;
            }
            if (Char.IsDigit(firstChar))
            {
                tokType = TokenCode.Number;
            }
            
            switch (tokType)
            {
                case TokenCode.Identifier:
                    while((nextLetter = (char)sr.Read()) != ' ')
                    {
                        if (Char.IsLetterOrDigit(nextLetter))
                        {
                            finalTokenStr += nextLetter;
                        }
                        else
                        {
                            firstChar = nextLetter;
                            break;
                        }
                    }
                    break;
                case TokenCode.Number:
                    while((nextLetter = (char)sr.Read()) != ' ')
                    {
                        if(Char.IsDigit(nextLetter) || nextLetter.Equals('.'))
                        {
                            finalTokenStr += nextLetter;
                        }
                        else
                        {
                            firstChar = nextLetter;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            foreach(String keyword in keywords)
            {
                if (finalTokenStr.Equals(keyword))
                {
                    tokType = TokenCode.Keyword;
                }
            }
            Token retToken = new Token(finalTokenStr, tokType);
            return retToken;
        }
    }
}
