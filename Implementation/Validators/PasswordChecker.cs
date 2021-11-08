using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation
{
    public class PasswordChecker
    {
        private readonly int _minLength;
        private readonly List<char> _allowedSpecialCharacters = new List<char>();

        public PasswordChecker(int minLength, List<char> allowedSpecialCharacters)
        {
            _minLength = minLength;
            _allowedSpecialCharacters = allowedSpecialCharacters;
        }



        // In reality all if/else would be in their own methods
        public bool IsValid(string str)
        {

            if (str.Length < _minLength)
            {
                return false;
            }

            //Check for Upper char

            bool canProgress = false;

            foreach(var c in str)
            {
                if (char.IsUpper(c))
                {
                    canProgress = true;
                    break;
                }
            }

            if (!canProgress)
                return false;

            // Check for Special Char

            canProgress = false;

            foreach(var c in _allowedSpecialCharacters)
            {
                if (str.Contains(c))
                {
                    canProgress = true;
                }
            }

            if (!canProgress) return false;

            // Check for unallowed Chars

            canProgress = true;

            foreach(char c in str)
            {
                if (!_allowedSpecialCharacters.Contains(c) && char.IsLetter(c) && char.IsNumber(c))
                {
                    canProgress = false;
                }

            }

            if (!canProgress) return false;


            return true;
        }
    }
}
