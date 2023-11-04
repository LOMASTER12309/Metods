using System;
using System.Collections.Generic;
using System.IO;
using Stack;

namespace Task1_Stack
{
    class Program
    {
        static string execute(Stack.Stack<object> stack, string command, out bool exit){
            exit = false;
            string[] СomplexCommand = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (СomplexCommand.Length > 0)
            switch (СomplexCommand[0]) 
            {
                case "push":
                    stack.push(СomplexCommand[1]);
                    return "ok";
                case "pop":
                    return Convert.ToString(stack.pop());
                case "back":
                    return Convert.ToString(stack.back());
                case "size":
                    return Convert.ToString(stack.size);
                case "clear":
                    stack.clear();
                    return "ok";
                case "exit":
                    exit = true;
                    return "Bye";
            }
            return "Не удалось распознать команду!";
        }
        static string[] ReadCommads(string FileName)
        {
            string[] arr = File.ReadAllLines(FileName);
            foreach (string str in arr) { str.Trim(); }
            return arr;
        }
        static void Main(string[] args)
        {
            Stack.Stack<object> str = new Stack.Stack<object>();
            string[] commands = ReadCommads("C:\\Users\\User\\source\\repos\\Metods\\Task1_Stack\\Task1_test1.txt");
            bool exit = false;
            for (int i = 0; i < commands.Length; i++)
            {
                Console.WriteLine(execute(str, commands[i], out exit));
                if (exit) Environment.Exit(0);
            }
        }
    }
}
