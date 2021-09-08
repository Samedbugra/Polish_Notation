using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//Author by Samed Buğra KARATAŞ 181213024

namespace Polish_Notation
{
    class Program
    {
        static void Main(string[] args)
        {
            String pNotation = null;
            Console.WriteLine("Polish notasyonunu giriniz :");
            pNotation = Console.ReadLine();

            String[] prefix=pNotation.Split(' ');
            Array.Reverse(prefix);

            PolishNotationCalculate(prefix);

            Console.ReadLine();
        }


        private static void PolishNotationCalculate(String[] pNotation)
        {

            String[] operators = new String[] { "+", "-", "*", "/" };
            String selected_operator = null;
            Boolean isOperator = false;

            Stack<String> stack = new Stack<String>();
            String num1, num2;
            for (int i = 0; i < pNotation.Length; i++)
            {
                for (int j = 0; j < operators.Length; j++)
                {
                    if(pNotation[i]==operators[j])
                    {
                        isOperator = true;
                        break;
                    } 
                }
                if (!isOperator)
                {
                    stack.Push(pNotation[i]);
                }
                else
                {
                    selected_operator = pNotation[i];
                    num2 = stack.Pop();
                    num1 = stack.Pop();
                    stack.Push(Calculate(num1, num2, selected_operator));
                }
                isOperator = false;
            }

            Console.WriteLine("Sonuc : " +stack.Pop());
        }


        private static String Calculate(String num1,String num2,string selected_operator)
        {
            int result=0;

            switch (selected_operator)
            {
                case "+":
                    result = Int32.Parse(num1) + Int32.Parse(num2);
                    break;
                case "-":
                    result = Int32.Parse(num2) - Int32.Parse(num1);
                    break;
                case "*":
                    result = Int32.Parse(num2) * Int32.Parse(num1);
                    break;
                case "/":
                    result = Int32.Parse(num2) / Int32.Parse(num1);
                    break;
                default:
                    break;
            }
            return result.ToString();
        }
    }


}