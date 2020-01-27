using System;
using System.Collections.Generic;
using System.Text;

namespace Nummerplade_Tjekker
{
    class SearchValidation
    {
        private bool RegistrationNumber(string reg)
        {

            if (reg.Length <= 7) return true;
            return false;
        }
        public static bool VinNumber(string vin)
        {
            return ValidateVin(vin);
        }
        private static int VinTransliterate(char c)
        {
            return "0123456789.ABCDEFGH..JKLMN.P.R..STUVWXYZ".IndexOf(c) % 10;
        }
        private static bool ValidateVin(string vin)
        {
            if (vin.Length == 17)
            {
                String map = "0123456789X";
                String weights = "8765432X098765432";
                int sum = 0;
                for (int i = 0; i < 17; ++i)
                {
                    sum += VinTransliterate(vin[i]) * map.IndexOf(weights[i]);
                }
                return map[sum % 11] == vin[8];
            } return false;
        }
    }
}
