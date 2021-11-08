using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation
{
    public class PhoneValidator
    {
        readonly int _lenWithoutPrefix;
        readonly string _defaultPrefix;
        readonly string _shortcutPrefix;

        public PhoneValidator(int lenWithoutPrefix, string defaultPrefix, string shortcutPrefix)
        {
            _lenWithoutPrefix = lenWithoutPrefix;
            _defaultPrefix = defaultPrefix;
            _shortcutPrefix = shortcutPrefix;
        }

        public bool IsValid(string phone)
        {

            string prefix;
            string postfix;

            if (!phone.StartsWith(_defaultPrefix))
            {
                if (!phone.StartsWith(_shortcutPrefix))
                {
                    return false;
                }
                else
                {
                    prefix = new string(phone.Take(_shortcutPrefix.Length).ToArray());
                    postfix = new string(phone.Skip(_shortcutPrefix.Length).ToArray());
                }
            }
            else
            {
                prefix = new string(phone.Take(_defaultPrefix.Length).ToArray());
                postfix = new string(phone.Skip(_defaultPrefix.Length).ToArray());
            }


            if(postfix.Length != _lenWithoutPrefix)
            {
                return false;
            }


            if(phone.Any(x => char.IsLetter(x)))
            {
                return false;
            }

            return true;
        }

        public string ChangeShortcutPrefixToDefault(string phone)
        {
            if (!phone.StartsWith(_shortcutPrefix))
            {
                return "";
            }
            else
            {
                return _defaultPrefix + new string(phone.Skip(_shortcutPrefix.Length).ToArray());
            }
        }
    }
}
