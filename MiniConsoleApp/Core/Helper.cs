using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core
{
    public static class Helper
    {
        public static bool CheckName(this string name)
        {
            bool checkUpper = false;
            bool checkLength = false;

            if (name[0] >= 'A' && name[0] <= 'Z')
            {
                checkUpper = true;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Bash herf boyuk yazilmalidir");
            }

            if(name.Length >= 3 && name.Split(' ').Length == 1)
            {
                checkLength = true;
            }
            
            else
            {
                Console.WriteLine("");
                Console.WriteLine("1 den cox soz olmamali ve en azi uzunlugu 3 olmali");
            }
            return checkUpper && checkLength;
        }

        public static bool CheckSurname(this string surname)
        {
            bool checkUpper = false;
            bool checkLength = false;

            if (surname[0] >= 'A' && surname[0] <= 'Z')
            {
                checkUpper = true;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Bash herf boyuk yazilmalidir");
            }

            if (surname.Length >= 3 && surname.Split(' ').Length == 1)
            {
                checkLength = true;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("1 den cox soz olmamali ve en azi uzunlugu 3 olmali");
            }
            return checkUpper && checkLength;
        }

        public static bool CheckClassname(this string classname)
        {
            bool checkClassname = false;

            if(Regex.IsMatch(classname, @"^[A-Z]{2}\d{3}$"))
            {
                checkClassname = true;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Classroom-un adi 2 boyuk herf 3 reqemden ibaret olmalidi");
            }

            return checkClassname;
        }
    }
}
