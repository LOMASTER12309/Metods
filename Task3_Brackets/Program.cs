using System;
using System.IO;
using Stack;

namespace Task3_Brackets
{
    class Program
    {
        static int IsValid(string s)
        {
            Stack.Stack<int> st = new Stack.Stack<int>();
            for (int i = 0; i < s.Length; i++)
                if (s[i] == '(') st.push(i);
                else if (s[i] == ')')
                    if ((st.IsEmpty) || (s[st.back()] == ')')) return i;
                    else st.pop();
            if (!st.IsEmpty) return st.back();
            return -1;
        }
        static void Main(string[] args)
        {
            string expression = File.ReadAllText("C:\\Users\\User\\source\\repos\\Metods\\Task3_Brackets\\Task3_test1.txt");
            int num = 0;
            switch (num = IsValid(expression))
            {
                case -1:
                    Console.WriteLine("Да.");
                    return;
                default:
                    Console.Write("Нет. ");
                    if (expression[num] == ')')
                        Console.WriteLine($"Лишняя закрывающая скобка на позиции {num+1}");
                    else Console.WriteLine($"Лишняя открывабщая скобка на позиции {num+1}");
                    return;
            }
        }
    }
}
