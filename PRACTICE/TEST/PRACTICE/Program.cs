using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICE
{
    internal class Program
    {
        static void Main(string[] args)
        {
/*            string text = "Concepcion del Uruguay";

            for (int i = text.Length - 1; i >= 0; i--)
            {
                Console.Write(text[i]);
            }*/

            string ReverseString(string str)
            {
                if (str.Length == 0)
                {
                    return "";
                }
                else
                {
                    var aux = ReverseString(str.Substring(1)) + str[0];
                    Console.WriteLine(aux);
                    Console.ReadLine();
                    return aux;
                }
            }

            Console.WriteLine(ReverseString("Hola"));



            Console.WriteLine();

            Console.WriteLine("Hola".Substring(1));




            /*            int[] lyst1 = { 1, 2, 3, 4, 5 };
                        int[] lyst2 = { 6, 7, 8, 9, 10 };



                        *//*dynamic reverse = new int[] { lystOfNumber[lystOfNumber.Length - i] } +;*//*

                        int[] lyst3 = lyst1 + lyst2;

                        for (int i = 0; i < lyst1.Length; i++)
                        {   

                        }*/




            /*            int[] invertir(int[] lyst)
                        {
                            if (lyst.Length == 0)
                            {
                                return lyst;
                            }
                            else
                            {
                                return invertir(lyst.FirstOrDefault());
                            }
                        }*/
        }
    }
}
