using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Services.Common
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PasswordAttribute : ValidationAttribute
    {
        
        private int length;
        private bool upperCase;
        private bool lowerCase = false;
        private bool specialChar = false;

        public PasswordAttribute(int length = 8, bool upperCase = false, bool lowerCase = false, bool specialCharacter = false)
        {
            this.length = length;
            this.upperCase = upperCase;
            this.lowerCase = lowerCase;
            this.specialChar = specialCharacter;
        }
        public override bool IsValid(object value)
        {
            var password = value as string;
            string specialCh = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specialChArray = specialCh.ToCharArray();


            if (value == null || value.ToString().Length < length)
            {
                return false;
            }

            var checkSpecial = specialChArray.Any(x => password.Contains(x));
            if ((upperCase == true && !password.Any(char.IsUpper)) || (lowerCase == true && !password.Any(char.IsUpper)))
            {
                return false;
            }
            else if (specialChar == true && checkSpecial == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


    }
}

