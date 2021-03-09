using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models._03.Function
{
    public class Function
    {
        public static bool toBoolean(string s)
        {
            if (s == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        public static string cutSpaceAndConvert(string s)
        {
            string temp = "";
            string str = convertToUnSign3(s);
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] >= '0' && str[i] <= '9')
                    || (str[i] >= 'A' && str[i] <= 'z'
                        || (str[i] == ' ')))
                {
                    temp += Char.ToLower(str[i]);
                }
            }
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == ' ' && temp[i + 1] == ' ')
                {
                    temp = temp.Replace("  ", " ");
                }
            }
            for (int i = 0; i < temp.Length; i++)
            {
                temp = temp.Replace(" ", "-");
            }
            return temp;
        }
    }
}
