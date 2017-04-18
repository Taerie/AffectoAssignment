using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessIdProject
{
    class BusinessIdSpecification : ISpecification<string>
    {
        private string codePattern = "\\b\\d{7}-\\d{1}";//looks for pattern 1234567-8
        private IEnumerable<string> failureReasons = Enumerable.Empty<string>();
        private Regex rgxYCode = null;


        public IEnumerable<string> ReasonsForDissatisfaction
        {
            get {return failureReasons;}
        }

        public bool IsSatisfiedBy(string code)
        {
            code = code.Trim(); //remove any whitespace
            rgxYCode = new Regex(codePattern);

            if (rgxYCode.IsMatch(code) && code.Length == 9) //check if string matches pattern
            {
                return true; //return true if it does
            }
            else //else, code is in wrong format
            {
                failureReasons = failureReasons.Concat(new[] { "Tunnus on viallinen, oletetaan muotoa 1234567-8. Ainoastaan numerot ovat hyväksyttäviä." });
            }

            if (code.Length > 9) //if the code is too long
            {
                failureReasons = failureReasons.Concat(new[] { "Tunnuksessa on liikaa merkkejä, y-tunnus sisältää 8 numeroa." });
            }
            else if (code.Length < 9) //if the code is too short
            {
                failureReasons = failureReasons.Concat(new[] { "Tunnuksessa on liian vähän merkkejä, y-tunnus sisältää 8 numeroa." });
            }


            return false;        
        }

      
    }
}
