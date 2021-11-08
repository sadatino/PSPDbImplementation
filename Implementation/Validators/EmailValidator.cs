using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation
{
    public class EmailValidator
    {

        List<char> _invalidCharacters;
        List<char> _specialCharacters;

        public EmailValidator(List<char> invalidCharacters, List<char> specialCharacters)
        {
            _invalidCharacters = invalidCharacters;
            _specialCharacters = specialCharacters;
        }

        public bool IsFirstSpecialCharacter(string str)
        {
            if (_specialCharacters.Contains(str[0])) return true;

            return false;
        }

        public bool IsLastSpecialCharacter(string str)
        {
            if (_specialCharacters.Contains(str[str.Length-1])) return true;

            return false;
        }

        public bool IsHaveTwoOrMoreConsecutiveSpecialChars(string str)
        {

            for(int i=0;i< str.Length - 1; i++)
            {
                if(_specialCharacters.Contains(str[i]) && _specialCharacters.Contains(str[i + 1]))
                {
                    return true;
                }
            }

            return false;

        }

        public bool IsValid(string email)
        {
            
            foreach(var c in _invalidCharacters)
            {
                if (email.Contains(c))
                {
                    return false;
                }
            }

            if (!email.Contains("@")) return false;

            string domain = email.Split('@')[1];

            if (!domain.Contains('.')) return false;

            foreach(var c in domain)
            {
                if(!char.IsLetter(c) && c != '.' && !char.IsNumber(c))
                {
                    return false;
                }

            }

            


            return true;
        }
    }
}
