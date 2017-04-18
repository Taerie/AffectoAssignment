using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIdProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = string.Empty;
            BusinessIdSpecification idCheck = new BusinessIdSpecification();

            Console.WriteLine("Anna y-tunnus:");
            userInput = Console.ReadLine();

            if (!idCheck.IsSatisfiedBy(userInput))
            {
                Console.WriteLine("Tunnusta ei voitu hyväksyä seuraavista syistä:");
                foreach (string strFailure in idCheck.ReasonsForDissatisfaction)
                {
                    Console.WriteLine("* " + strFailure);
                }
            }
            else
            {
                Console.WriteLine("Tunnus on hyväksyttävä.");
            }
        }
    }
}
