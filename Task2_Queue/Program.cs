using System;
using System.Collections.Generic;
using System.IO;
using Queue;

namespace Task2_Queue
{
    class Program
    {
        static string execute(Queue.Queue<object> stack, string command, out bool exit)
        {
            exit = false;
            string[] СomplexCommand = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (СomplexCommand.Length > 0)
                try
                {
                    switch (СomplexCommand[0])
                    {
                        case "push":
                            stack.push(СomplexCommand[1]);
                            return "ok";
                        case "pop":
                            return Convert.ToString(stack.pop());
                        case "front":
                            return Convert.ToString(stack.front());
                        case "size":
                            return Convert.ToString(stack.size);
                        case "clear":
                            stack.clear();
                            return "ok";
                        case "exit":
                            exit = true;
                            return "Bye";
                    }
                }
                catch
                {
                    return "error";
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
            Queue.Queue<object> str = new Queue.Queue<object>();
            string[] commands = ReadCommads("C:\\Users\\User\\source\\repos\\Metods\\Task2_Queue\\Task2_test1.txt");
            bool exit = false;
            for (int i = 0; i < commands.Length; i++)
            {
                Console.WriteLine(execute(str, commands[i], out exit));
                if (exit) Environment.Exit(0);
            }
        }
    }
}