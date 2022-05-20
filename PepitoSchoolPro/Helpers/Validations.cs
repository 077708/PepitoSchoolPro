using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolPro.Helpers
{
    public class Validations
    {
        public static bool Validation(string name, string lastnames, string carnet, 
            string phone, string address, string email, string mat, string acounting, string programming, string statistic)
        {
            if (name.Equals(String.Empty) || lastnames.Equals(String.Empty)
                || carnet.Equals(String.Empty) || phone.Equals(String.Empty)
                || address.Equals(String.Empty) || email.Equals(String.Empty)
                )
            {
                throw new Exception("fill in all the fields");
            }

            if (!int.TryParse(mat, out int math))
                throw new Exception($"Error enters only numbers in the faithful \"Math\"");

            if (!int.TryParse(acounting, out int acc))
                throw new Exception($"Error enters only numbers in the faithful \"Accounting\"");


            if (!int.TryParse(programming, out int pro))
                throw new Exception($"Error enters only numbers in the faithful \"Programming\"");

            if (!int.TryParse(statistic, out int st))
                throw new Exception($"Error enters only numbers in the faithful \"Statictic\"");

            if (math < 0 || acc < 0 || pro < 0 || st < 0
                 || math > 101 || acc > 101 || pro > 101 || st > 101)
                throw new Exception("The score must be greater than zero and less than or equal to 100");


            return true;
        }
    }
}
