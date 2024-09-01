using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClientProjectHandle_Utilities
{
    public static class Validations
    {
        private static string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        public static bool IsValidMail(string mailId)
        {
            try
            {
                return Regex.IsMatch(mailId, emailPattern);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
