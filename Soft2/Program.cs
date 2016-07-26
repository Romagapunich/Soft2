using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft2
{
    class Program
    {
        public static bool Primery(int number) // метод для проверки на целосность числа
        {

            int numbers = number;
            bool prostoe = true;

            if (numbers < 2)                  // что бы не проверять все числа меньше 2 и минусовые 
            {
                return false;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(numbers); i++) // проверка просто ли число
                {
                    if (numbers % i == 0)
                    {
                        prostoe = false;
                        break;
                    }
                }
            }

            if (prostoe)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public static bool Sdvig(int numbers)
        {
            int number = numbers;
            int proverkaprostoe;
            bool truefalse = true;
            string stringchar = Convert.ToString(number);
            char[] prstchisl = stringchar.ToCharArray();                          // масив числа который изменяем
            char[] prstchislzamen = stringchar.ToCharArray();                  // масив числа от куда берем число для замены

            for (int j = 0; j < prstchisl.Length; j++)
            {

                string convtoint = new string(prstchisl);                      // для конвертации в инт
                proverkaprostoe = Convert.ToInt32(convtoint);
                if (Primery(proverkaprostoe) == true)
                {
                    for (int i = 0; i < prstchisl.Length; i++)                // цыкл для сдвига числа делает из 197 =  971 719
                    {
                        if (i == prstchisl.Length - 1)
                        {
                            prstchisl[i] = prstchislzamen[0];
                        }
                        else
                        {
                            prstchisl[i] = prstchislzamen[i + 1];
                        }

                    }
                    for (int i = 0; i < prstchisl.Length; i++)                  // цыкл для замены чисел в  масиве           
                    {
                        prstchislzamen[i] = prstchisl[i];
                    }
                }
                else
                {
                    truefalse = false;
                    break;
                }


            }

            if (truefalse == true)
            {
                return true;
            }

            else
            {
                return false;

            }
        }

        static void Main(string[] args)
        {
            int count = 0;
            string result = String.Empty;

            for (int i = 0; i < 1000000; i++)
            {

                if (Sdvig(i) == true)
                {
                    count++;
                    result += " " + Convert.ToString(i);
                }
                
            }

            Console.WriteLine("Количетсов простых чисел " + count);
            Console.WriteLine("Простые числа " + result);
            Console.ReadKey();
        }
    }
}
